# Tasks: CodeStock Lunch & Learn Deck

## Implementation Tasks

- [x] 1. Check that Markdown region imports work, then add the region markers
  - **Files:** `.kiro/specs/codestock-lunch-and-learn-deck/requirements.md`, `CONTEXT.md`
  - Wrap one criterion in `requirements.md` (the example criterion added for 2.3) in `<!-- #region ears-example -->` / `<!-- #endregion ears-example -->`, and wrap a short excerpt of `CONTEXT.md` (e.g. the **Takeaway** and **Discussion Prompt** entries) in `<!-- #region glossary-excerpt -->` / `<!-- #endregion glossary-excerpt -->`. Then add a throwaway slide with `<<< @/.kiro/specs/codestock-lunch-and-learn-deck/requirements.md#ears-example md` and run `pnpm run dev` to confirm Slidev 53 honours HTML-comment regions in `.md` files. If it doesn't, record the fallback chosen (line-range highlighting or a hand-copied excerpt with a "from requirements.md" caption) in `design.md` under Key Implementation Details, and remove the markers. Delete the throwaway slide either way.

- [x] 2. Add the Takeaway data file
  - **Files:** `data/takeaways.ts`
  - Export the `SourceSession` and `Takeaway` interfaces and the `takeaways` array exactly as in the design's Data Model, in Arc order (1.2). Take `name` from the `CONTEXT.md` terms, `source` from the requirements' Source Sessions table, `arcStep` from The Arc ("Plan before you prompt", "Record why", "See it run", "Keep it running"), and `discussionPrompt` word for word from criteria 2.6, 3.5, 4.7 and 4.8. Also export a `takeawayById(id)` helper (or equivalent) so components don't each re-implement the lookup.

- [x] 3. Add the `Callout` and `ArcStrip` components
  - **Files:** `components/Callout.vue`, `components/ArcStrip.vue`
  - `Callout`: an optional `label` prop and a default slot, rendered as a bordered box with UnoCSS utilities only. `ArcStrip`: an optional `current?: Takeaway['id']` prop. It renders the four `arcStep` labels from `takeaways` as one horizontal row joined by arrows, dims every step except `current` when it is set, and shows all four equally when it isn't. Check that the row fits on one line at the seriph theme's slide width.

- [x] 4. Add the `TakeawayTitle` component
  - **Files:** `components/TakeawayTitle.vue`
  - Props: `id: Takeaway['id']` and an optional `focusNote: string`. Render the Takeaway's `name` and `tool` as the heading, `<ArcStrip :current="id" />`, the credit line "From *{source.title}*, {source.speaker}" (1.4) and, when `focusNote` is set, a `<Callout>` containing it (4.4). Depends on tasks 2–3.

- [x] 5. Replace the template with the entry file and remove the template demos
  - **Files:** `slides.md`, `pages/imported-slides.md`, `components/Counter.vue`, `snippets/external.ts`
  - Rewrite `slides.md` with the headmatter from the design (`theme: seriph`, `title: What I Brought Back From CodeStock`, `duration: 45min`, `exportFilename: codestock-lunch-and-learn`, `transition: slide-left`, and no `background:`), then the three opening slides: the title slide with "Bring your lunch, bring an opinion.", "What is CodeStock" (community-run, Knoxville, the four sessions attended; mark it in the speaker notes as one for the presenter to fact-check), and the agenda with `<ArcStrip />` plus "then: Discussion" (1.1). Add `src:` imports for `pages/01-…` through `pages/06-…`, then create each of those six page files as a one-slide placeholder so the build stays green. Delete the three template demo files, and run `pnpm run dev` to confirm nothing still references them.

- [x] 6. Write Takeaway 1, part 1: the opening Beats and the building-blocks mapping
  - **Files:** `pages/01-structured-ai-development.md`
  - Slides: `<TakeawayTitle id="structured-ai" />`; "What it is" (specs vs. vibes, with requirements → design → tasks as three boxes, and the Non-Developer Angle in the speaker notes, 1.7); "The problem it solves" (ad-hoc prompting gives code nobody planned or can review, plus "the work you do up front matters 10x more"); and the building-blocks table (2.1) with the columns Building block | Kiro ([kiro-quickstart](https://github.com/chrismgonzalez/kiro-quickstart)) | General-purpose agent (this repo), and the four rows from the design. Show the Hooks row as an intentional empty cell labelled "next thing to try" on both sides. Write the Kiro column from kiro-quickstart's folder names only, and credit and link it.

- [x] 7. Write Takeaway 1, part 2: the Dogfood example through the transition
  - **Files:** `pages/01-structured-ai-development.md`
  - Add: a `layout: two-cols` slide (2.2) with "grilling session → `CONTEXT.md`" and the `glossary-excerpt` import on the left, and "Kiro-*style* spec" with the file tree of `.kiro/specs/codestock-lunch-and-learn-deck/` on the right; a slide with the `ears-example` import (2.3), or the fallback chosen in task 1; the Six Principles (2.4), credited to Chris Gonzalez, with "You're now an architect and decision maker" highlighted (take the list from `notes/` and flag it for the presenter to fact-check); the First Step from the design (2.5), using Codex and `AGENTS.md` as the worked example; the Discussion Prompt rendered from `takeaways` (2.6); and the transition slide "This session also produced this repo's ADRs →" (2.7).

- [x] 8. Write Takeaway 2: ADRs
  - **Files:** `pages/02-adrs.md`
  - Slides: `<TakeawayTitle id="adrs" />`; "What it is", drawn from Chad Green's notes plus Michael Nygard's original article (3.4), stating that a one-paragraph ADR is valid and the extra sections are optional (3.3), with the Non-Developer Angle in the notes; "The problem it solves"; ADR 0001 in full via `<<< @/docs/adr/0001-slidev-for-the-deck.md md {maxHeight:'…'}`, split over two slides if needed so the PDF stays legible (3.1); an ADR 0002 excerpt next to the three-question test, saying that 0002 fails "hard to reverse" (3.2); the First Step; and the Discussion Prompt from `takeaways` (3.5). Put the Nygard link in the speaker notes so the presenter can fact-check against it.

- [x] 9. Write the OpenTelemetry snippets
  - **Files:** `snippets/otel-setup.cs`, `snippets/otel-custom-span.cs`, `snippets/aspire-dashboard.sh`
  - `otel-setup.cs`: `AddOpenTelemetry().WithTracing(...)` with ASP.NET Core and HttpClient instrumentation and an OTLP exporter for a made-up `OrdersApi`. `otel-custom-span.cs`: an `ActivitySource` with one custom span, a tag and error status. `aspire-dashboard.sh`: the one-line `docker run` for the standalone Aspire dashboard, with its UI and OTLP ports. Check each against the current OpenTelemetry .NET and Aspire docs. Keep each snippet short enough to fit on one slide, and use no internal names or URLs (4.9).

- [x] 10. Write Takeaway 3: Observability
  - **Files:** `pages/03-observability.md`
  - Slides: `<TakeawayTitle id="observability" />`; the Shift Left framing slide "Observability starts in dev, not in production" (4.1); "What it is" (metrics, logs and traces, one line each, plus the Non-Developer Angle in the notes); "The problem it solves" ("The response was correct, but the path it took was not."); the App (OpenTelemetry SDK) → Collector → Backend pipeline; `<<< @/snippets/otel-setup.cs`; the anatomy of a trace; `<<< @/snippets/otel-custom-span.cs`; a `<Callout label="Recurring Signal">` for the Aspire dashboard at its first mention (4.3); the First Step with `<<< @/snippets/aspire-dashboard.sh` (4.2); and the Discussion Prompt from `takeaways` (4.7). Depends on task 9.

- [x] 11. Write the resilience snippets
  - **Files:** `snippets/resilience-pipeline.cs`, `snippets/resilience-chaos.cs`
  - `resilience-pipeline.cs`: `AddHttpClient<InventoryClient>(...)` for a made-up `inventory-service`, with `.AddStandardResilienceHandler()`. `resilience-chaos.cs`: the same client, with a Polly v8 chaos fault or outcome strategy (`Polly.Simmy`, e.g. `AddChaosOutcome` returning a 500 at a set injection rate) added so the standard handler visibly absorbs it. Check both against the current `Microsoft.Extensions.Http.Resilience` and Polly docs, including where the chaos strategy has to sit relative to the standard handler.

- [x] 12. Write Takeaway 4: Resilience
  - **Files:** `pages/04-resilience.md`
  - Slides: `<TakeawayTitle id="resilience" focusNote="…" />` with the focus note text from the design (4.4); "What it is" (retry, circuit breaker, timeout and fallback, each in a sentence anyone in the room can follow, plus the Non-Developer Angle in the notes); "The problem it solves"; `<<< @/snippets/resilience-pipeline.cs` and then `<<< @/snippets/resilience-chaos.cs`, with a one-line back-reference to Aspire as a place to watch it (4.5); the First Step "Add the standard resilience handler to one flaky `HttpClient`."; and the Discussion Prompt from `takeaways` (4.8). Put EF Core's `EnableRetryOnFailure()` in the speaker notes (4.6). Depends on task 11.

- [x] 13. Write the Discussion and resources slides
  - **Files:** `pages/05-discussion.md`, `pages/06-resources.md`
  - Discussion (5.1): loop over `takeaways` and show a numbered list of `name` → `discussionPrompt`, with a line inviting a show of hands. Resources (5.2): links to Kiro, https://github.com/chrismgonzalez/kiro-quickstart, Matt Pocock's skills, pstack, Nygard's ADR article, OpenTelemetry .NET, the Aspire dashboard and Polly, each with its URL written out as visible text so it can be read in the PDF.

- [x] 14. Update the README
  - **Files:** `README.md`
  - Replace the template README with a short description of the deck, the `pnpm run dev` / `build` / `export` commands, and pointers to `CONTEXT.md`, `.kiro/specs/codestock-lunch-and-learn-deck/` and `docs/adr/`, explaining that they are the Dogfood shown on the slides.

- [x] 15. Enable the PDF export, and verify the build and the export
  - **Files:** `package.json`
  - Add `playwright-chromium` as a dev dependency (`pnpm add -D playwright-chromium`), leaving `build` independent of it. Run `pnpm run build` and fix any snippet-import errors. Then run `pnpm run export` and check every page of `codestock-lunch-and-learn.pdf` for legibility, overflow and content that only appears through `v-click` (5.4). Confirm that `netlify.toml` still builds with `pnpm run build` and publishes `dist` (5.3).

- [ ] 16. Walk through the criteria and tick the requirements
  - **Files:** `.kiro/specs/codestock-lunch-and-learn-deck/requirements.md`, `.kiro/specs/codestock-lunch-and-learn-deck/tasks.md`
  - Step through `pnpm run dev` in presenter mode and tick each criterion only once its slide exists (`AGENTS.md`), checking 1.7 and 4.6 in the speaker notes. Confirm the agenda, the four title slides and the Discussion slide all show the same Arc steps and prompts. Grep `snippets/` and `pages/` for internal hostnames and service names (4.9). Do a timed dry run against `duration: 45min`: the Highlights should end by about the 25-minute mark, so trim slides if they don't. Tick the completed tasks in this file.
