# Design: CodeStock Lunch & Learn Deck

## Approach
Replace the Slidev starter content with a thin entry file (`slides.md`) that holds the headmatter and the opening slides, then imports one page file per Takeaway, plus the Discussion and resources, using Slidev's `src:` imports. That's the pattern the template already demonstrates in `pages/imported-slides.md`. Facts that appear in more than one place (each Takeaway's Arc step, Source Session, speaker and Discussion Prompt) live in one data file, so the agenda, the Takeaway title slides and the Discussion slide can't drift apart. Dogfood artifacts (`AGENTS.md`, `CONTEXT.md`, the ADRs, an EARS line from `requirements.md`) are pulled into slides with Slidev's `<<< @/…` snippet import instead of being copied. What the room sees is the real file at build time.

## Files Changed

| File | Change |
|------|--------|
| `slides.md` | Modify: replace the template with headmatter, the title slide, "What is CodeStock", the agenda (The Arc), and `src:` imports of the pages below |
| `pages/01-structured-ai-development.md` | Add: Takeaway 1 (Beats, building-blocks mapping, Dogfood, Six Principles, transition slide) |
| `pages/02-adrs.md` | Add: Takeaway 2 (Beats, ADR 0001 strong, ADR 0002 borderline + three-question test) |
| `pages/03-observability.md` | Add: Takeaway 3 (Shift Left framing, Beats, Aspire as Recurring Signal) |
| `pages/04-resilience.md` | Add: Takeaway 4 (focus-shift note, Beats, resilience pipeline + chaos example) |
| `pages/05-discussion.md` | Add: the Discussion slide listing all four Discussion Prompts |
| `pages/06-resources.md` | Add: the resources slide |
| `pages/imported-slides.md` | Delete: template demo |
| `data/takeaways.ts` | Add: the single source of truth for per-Takeaway facts |
| `components/TakeawayTitle.vue` | Add: Takeaway opening slide body (Arc position + Source Session credit + optional focus note) |
| `components/ArcStrip.vue` | Add: renders The Arc as four steps, with the current one highlighted |
| `components/Callout.vue` | Add: a small boxed aside, used for the Recurring Signal and the focus-shift note |
| `components/Counter.vue` | Delete: template demo |
| `snippets/external.ts` | Delete: template demo |
| `snippets/otel-setup.cs` | Add: OpenTelemetry tracing setup with OTLP export (illustrative .NET) |
| `snippets/otel-custom-span.cs` | Add: a custom span via `ActivitySource` |
| `snippets/resilience-pipeline.cs` | Add: `AddStandardResilienceHandler()` on an `HttpClient` |
| `snippets/resilience-chaos.cs` | Add: a chaos strategy that injects faults into the same client |
| `snippets/aspire-dashboard.sh` | Add: the one-line `docker run` for the standalone Aspire dashboard (First Step) |
| `.kiro/specs/codestock-lunch-and-learn-deck/requirements.md` | Modify: add region markers around the EARS criterion shown on a slide (2.3) |
| `package.json` | Modify: add `playwright-chromium` as a dev dependency (required by `slidev export`) |
| `README.md` | Modify: describe the deck and point to `CONTEXT.md`, the spec and the ADRs |

`netlify.toml` stays as it is (ADR 0002). `vercel.json` has already been deleted.

## Data Model

```ts
// data/takeaways.ts
export interface SourceSession {
  title: string
  speaker: string
}

export interface Takeaway {
  id: 'structured-ai' | 'adrs' | 'observability' | 'resilience'
  name: string            // CONTEXT.md term, e.g. "Structured AI Development"
  tool: string            // shown alongside the name, e.g. "Kiro & Skill Packs", "OpenTelemetry", "Polly"
  arcStep: string         // "Plan before you prompt" | "Record why" | "See it run" | "Keep it running"
  source: SourceSession
  discussionPrompt: string
}

export const takeaways: Takeaway[] // in Arc order (1.2)
```

The values come straight from the requirements' Source Sessions table and the Discussion Prompts in criteria 2.6, 3.5, 4.7 and 4.8.

## Component / Module Design

### `slides.md` (entry)
- **Headmatter:** `theme: seriph`, `title: What I Brought Back From CodeStock`, `duration: 45min`, `exportFilename: codestock-lunch-and-learn`, `transition: slide-left`. The template's random `background: https://cover.sli.dev` is replaced with a local copy of a chosen Unsplash photo (`public/title-background.jpg`, credited in the title slide's speaker notes), so every build and the PDF look the same.
- **Slides:**
  1. Title, with the tagline "Bring your lunch, bring an opinion."
  2. What is CodeStock: community-run, Knoxville, the four sessions attended. The presenter fact-checks this slide.
  3. Agenda: `<ArcStrip />`, with no current step, plus "then: Discussion" (1.1).
- **Imports:** `src: ./pages/0N-….md` for each page, in order.

### `components/ArcStrip.vue`
- **Inputs:** `current?: Takeaway['id']`.
- **Output:** renders the four `arcStep` labels from `takeaways` as a horizontal row joined by arrows. It dims all but `current` when `current` is set, and shows all four equally on the agenda.
- **Styling:** UnoCSS utility classes only, matching the template's style. No custom theme work (out of scope).

### `components/TakeawayTitle.vue`
- **Inputs:** `id: Takeaway['id']`, an optional `focusNote: string`.
- **Output:**
  - The Takeaway `name` and `tool` as the heading.
  - `<ArcStrip :current="id" />`.
  - "From *{source.title}*, {source.speaker}" (1.4).
  - If `focusNote` is set, a `<Callout>` containing it. This is used by Resilience for 4.4.
- **Usage:** every page's first slide is `<TakeawayTitle id="…" />`, so the credit and the Arc position are always shown the same way.

### `components/Callout.vue`
- **Inputs:** `label?: string` (e.g. "Recurring Signal"), plus a default slot.
- **Output:** a bordered box with an optional label. It has no logic.

### Page files (shared shape)
Every Takeaway page follows the Beats (1.3). Each Beat is one slide unless noted below:

1. `<TakeawayTitle id>`
2. What it is
3. The problem it solves
4. Concrete example (may be 2–3 slides)
5. First Step: one action (1.5)
6. Discussion Prompt, rendered from `takeaways[i].discussionPrompt` so it matches the Discussion slide

Each slide's final HTML comment is its speaker notes. Each Takeaway's "What it is" slide carries the one-line Non-Developer Angle (1.7).

#### `pages/01-structured-ai-development.md`
- **What it is:** specs vs. vibes, giving AI-assisted coding a deliberate workflow. The Kiro flow requirements → design → tasks is shown as three boxes.
- **Problem:** ad-hoc prompting gives code nobody planned or can review. Uses "the work you do up front matters 10x more" from the notes.
- **Building blocks mapping (2.1):** a table with the columns Building block | Kiro ([kiro-quickstart](https://github.com/chrismgonzalez/kiro-quickstart)) | General-purpose agent (this repo):
  - Steering: `.kiro/steering/` | `AGENTS.md`
  - Skills: `.kiro/skills/` | Matt Pocock's skills, pstack
  - Hooks: `.kiro/hooks/` (a quality-check hook and a docs-sync hook) | empty, labelled "next thing to try"
  - Specs: `.kiro/specs/` (only on the repo's `demo/*` branches, e.g. `task-creation-and-storage` on `demo/03-tasks`; `main` has none) | `.kiro/specs/codestock-lunch-and-learn-deck`
- **Concrete example (2.2, 2.3):**
  - A two-column slide (`layout: two-cols`). On the left: "grilling session → `CONTEXT.md`", with a short excerpt imported from `CONTEXT.md`. On the right: "Kiro-*style* spec", with the file tree of `.kiro/specs/codestock-lunch-and-learn-deck/`.
  - A follow-on slide shows one real EARS criterion, imported by region from `requirements.md`.
- **Six Principles (2.4):** the list, credited to Chris Gonzalez, with "You're now an architect and decision maker" highlighted.
- **First Step (2.5):** "Install one Skill Pack in the agent your project uses and run it on your next ticket." Codex is the worked example: the file is `AGENTS.md`, and skills go wherever your agent loads them.
- **Discussion Prompt (2.6).**
- **Transition (2.7):** "This session also produced this repo's ADRs →".

#### `pages/02-adrs.md`
- **What it is:** a lightweight record of one decision and why it was made, from Chad Green's notes plus Nygard (3.4). A one-paragraph ADR is valid, and the extra sections are optional (3.3).
- **Problem:** decisions outlive the people who remember why they were made.
- **Concrete example (3.1):** `<<< @/docs/adr/0001-slidev-for-the-deck.md md`, spread over 1–2 slides with `maxHeight` so the PDF stays legible.
- **Borderline example (3.2):** an excerpt from ADR 0002, next to the three-question test: hard to reverse, surprising without context, a real trade-off. 0002 fails the first question, and the slide says so.
- **First Step:** "Write an ADR for the next real decision your team makes."
- **Discussion Prompt (3.5).**

#### `pages/03-observability.md`
- **Title:** `<TakeawayTitle id="observability" />`, followed by a Shift Left framing slide: "Observability starts in dev, not in production" (4.1).
- **What it is:** metrics, logs and traces. Each gets a one-line definition taken from Victor Lyuboslavsky's notes.
- **Problem:** code intent ≠ runtime behavior. "The response was correct, but the path it took was not."
- **Concrete example:**
  - The pipeline App (OpenTelemetry SDK) → Collector → Backend.
  - `snippets/otel-setup.cs`.
  - The anatomy of a trace: request span → child spans → DB → outgoing HTTP → errors.
  - `snippets/otel-custom-span.cs`.
- **Aspire (4.3):** a `<Callout label="Recurring Signal">` saying the Aspire dashboard came up in *both* the observability and resilience Source Sessions.
- **First Step (4.2):** `snippets/aspire-dashboard.sh`, with "point your local OTLP exporter at it and look at a trace."
- **Discussion Prompt (4.7).**

#### `pages/04-resilience.md`
- **Title:** `<TakeawayTitle id="resilience" focusNote="Victor Frye's session was about chaos engineering. We're focusing on resilience, and using chaos only to prove it works." />` (4.4).
- **What it is:** retry, circuit breaker, timeout and fallback, each in a sentence anyone in the room can follow.
- **Problem:** every remote call can fail, and an unprotected one becomes your outage.
- **Concrete example (4.5):**
  - `snippets/resilience-pipeline.cs`, using `AddStandardResilienceHandler()`.
  - `snippets/resilience-chaos.cs`, which adds a chaos fault or outcome strategy to the same client to show the pipeline absorbing it. It has a one-line back-reference to Aspire as a place to watch it happen.
- **First Step:** "Add the standard resilience handler to one flaky `HttpClient`."
- **Discussion Prompt (4.8).**
- **Speaker notes (4.6):** the EF Core SQL Server provider's `EnableRetryOnFailure()` covers database retries.

#### `pages/05-discussion.md`
- **Discussion slide (5.1):** loops over `takeaways` and shows a numbered list of `name` → `discussionPrompt`, with a line inviting a show of hands.

#### `pages/06-resources.md`
- **Resources slide (5.2):** links to Kiro, kiro-quickstart, Matt Pocock's skills, pstack, Nygard's ADR article, OpenTelemetry .NET, the Aspire dashboard and Polly. Each link is written out as visible text as well, so it can still be read in the PDF.

## Key Implementation Details
- **Real files, imported, not copied.** Dogfood slides use `<<< @/AGENTS.md`, `<<< @/CONTEXT.md#region`, `<<< @/docs/adr/0001-….md` and so on. Editing a file updates the slide on the next build, which keeps the Dogfood honest.
- **Markdown region markers.** For 2.3, wrap one criterion in `requirements.md` with `<!-- #region ears-example -->` / `<!-- #endregion ears-example -->`. Use the same approach for a short excerpt in `CONTEXT.md`. Slidev 53's snippet import honours HTML-comment regions in `.md` files (checked with a probe build). The `CONTEXT.md` excerpt is `glossary-excerpt`, which covers **Discussion** and **Discussion Prompt**. Watch for one thing: a misspelled region name doesn't fail the build, because Slidev silently imports the whole file instead.
- **Code is illustrative .NET** (1.6, `AGENTS.md`), using made-up service names such as `OrdersApi` and `inventory-service`. The snippets are written against the current OpenTelemetry .NET, `Microsoft.Extensions.Http.Resilience` and Polly v8 chaos (`Polly.Simmy`) APIs, and checked against their docs before the snippets are finalized.
- **The open question about project OpenTelemetry snippets.** The design doesn't depend on them. If the presenter supplies them, they replace `snippets/otel-*.cs` one-for-one, after the clean-up in 4.9.
- **Kiro side of the mapping.** It's written from kiro-quickstart's directory structure (file and folder names only), not by copying its contents. Credit it and link to it.
- **Speaker notes** use Slidev's last-HTML-comment convention, as the template already does.
- **Terminology.** Slide text uses the `CONTEXT.md` terms: Takeaway, Discussion, Discussion Prompt, Six Principles, Recurring Signal and Shift Left. Use "Six Principles" for Chris Gonzalez's list, and "Discussion" for the open floor.
- **Timing.** About 5 minutes per Takeaway means each page has roughly 7–9 slides. Use v-clicks sparingly: the PDF captures each slide in its final state (ADR 0002), so no slide may depend on an animation to make sense.

## Edge Cases & Error Handling
- **The PDF loses click-through animations.** No content is hidden behind `v-click` that the slide needs to make sense, and every slide reads correctly in its final state.
- **Long imported files** (an ADR, `AGENTS.md`). Use `{maxHeight:'…'}` on the snippet import, or split the file across two slides, so text stays legible both on screen and in the PDF (5.4).
- **Dogfood files change after the talk.** That's expected: the deck rebuilds from the current files. Any slide caption that quotes a file's content must use only text that is also in the import.
- **Links in the PDF.** Every URL is also shown as visible text, so it can still be read in a printed copy.
- **Netlify build.** `playwright-chromium` is only needed for the export, so the Netlify build (`pnpm run build`) doesn't depend on it.
- **The Hooks row is empty on this repo's side.** Show it as an intentional empty cell with "next thing to try", not as a missing value.

## Testing Approach
There is no app logic to unit-test. Verification is building the deck and walking through it against the EARS criteria:

1. **Build:** `pnpm run build` succeeds with no snippet-import errors. This proves every `<<< @/…` path and region resolves.
2. **Export:** `pnpm run export` produces `codestock-lunch-and-learn.pdf`. Skim every page for legibility, overflow and missing animated content (5.4).
3. **Criteria walkthrough:** run `pnpm run dev`, step through in presenter mode, and tick each criterion in `requirements.md` only once its slide exists (per `AGENTS.md`). Use presenter mode to check the speaker-notes criteria (1.7, 4.6).
4. **Consistency:** check that the agenda, every Takeaway title slide and the Discussion slide show the same Arc steps and prompts. They all render from `data/takeaways.ts`, so a mismatch indicates a bug in a component.
5. **Snippet hygiene (4.9):** grep the `snippets/` folder for internal hostnames and service names before publishing.
6. **Timing:** a dry run with the Slidev presenter timer against the `duration: 45min` headmatter. Highlights should end by about the 25-minute mark.
