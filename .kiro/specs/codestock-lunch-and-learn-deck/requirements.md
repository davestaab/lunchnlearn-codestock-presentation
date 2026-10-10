# Requirements: CodeStock Lunch & Learn Deck

## Overview
A Slidev deck for the internal Lunch & Learn "What I Brought Back From CodeStock". It covers four Takeaways (Structured AI Development, ADRs, Observability with OpenTelemetry, and Resilience with Polly), and each one follows the same five Beats. A Discussion fills the second half of the session. The deck Dogfoods its own first two Takeaways: the repo's `CONTEXT.md`, this Kiro-style spec and its ADRs are the concrete examples. Terms follow `CONTEXT.md`, and decisions follow `docs/adr/`.

Acceptance criteria are written in EARS (*WHEN … THE DECK SHALL …*), the requirements notation Kiro uses and the Structured AI Development Source Session recommended.

## User Stories

### 1. Follow the four Takeaways
**As an** Audience member (mostly .NET developers, plus managers, QA and designers)
**I want** each Takeaway presented in the same short, predictable shape
**So that** I understand what each idea is and what I could try next week, in about 5 minutes each

#### Acceptance Criteria
- [x] 1.1 WHEN the presenter advances past the title slide THE DECK SHALL show one "What is CodeStock" slide followed by an agenda that states The Arc: plan before you prompt → record why → see it run → keep it running.
- [x] 1.2 THE DECK SHALL present the Takeaways in Arc order: Structured AI Development, ADRs, Observability (OpenTelemetry), Resilience (Polly).
- [x] 1.3 WHEN a Takeaway is presented THE DECK SHALL show its Beats in order: what it is → the problem it solves → a concrete example → First Step → Discussion Prompt.
- [x] 1.4 WHEN a Takeaway is presented THE DECK SHALL credit its Source Session's title and speaker.
- [x] 1.5 WHEN a Takeaway reaches its First Step THE DECK SHALL name exactly one small action that assumes the team is starting from zero.
- [x] 1.6 WHEN a slide contains code THE DECK SHALL show it as a highlighted snippet that needs no live demo.
- [x] 1.7 WHEN the presenter opens a Takeaway's speaker notes THE DECK SHALL include a one-line Non-Developer Angle.

### 2. Structured AI Development, with the deck as its own example
**As an** Audience member
**I want** Structured AI Development illustrated with artifacts from the deck's own repo
**So that** the examples are real, not hypothetical

#### Acceptance Criteria
- [x] 2.1 WHEN the Takeaway introduces its examples THE DECK SHALL show Kiro's building blocks (steering, skills, hooks, specs) next to their equivalents in a general-purpose agent, presented as the same building blocks packaged differently, with real files for each: Chris Gonzalez's kiro-quickstart repo on the Kiro side (credited and linked) and this repo on the general-purpose side (e.g. `AGENTS.md` for steering). Where this repo doesn't have a building block yet (currently hooks, which kiro-quickstart does have), THE DECK SHALL show it as empty and name it as the next thing to try.
- [x] 2.2 WHEN the Takeaway reaches its concrete example THE DECK SHALL show the grilling session producing `CONTEXT.md` (Matt Pocock's skills) next to this Kiro-style requirements → design → tasks spec, labelled as Kiro-*style*, not Kiro.
<!-- #region ears-example -->
- [x] 2.3 WHEN the Takeaway shows the spec THE DECK SHALL include at least one real EARS acceptance criterion from this file.
<!-- #endregion ears-example -->
- [x] 2.4 WHEN the Takeaway shows the Source Session's Six Principles THE DECK SHALL call them "Six Principles", not "takeaways".
- [x] 2.5 WHEN the Takeaway reaches its First Step THE DECK SHALL keep the step agent-agnostic (try a Skill Pack in whichever agent your project uses), using Codex as the worked example.
- [x] 2.6 WHEN the Takeaway reaches its Discussion Prompt THE DECK SHALL ask whether the Audience agrees that "you're now an architect and decision maker."
- [x] 2.7 WHEN the Takeaway ends THE DECK SHALL show a transition slide noting that the grilling session also produced this repo's ADRs.

### 3. ADRs, with the deck's own decisions as examples
**As an** Audience member
**I want** to see real, fully worked ADRs
**So that** I know what a good one looks like before writing my own

#### Acceptance Criteria
- [x] 3.1 WHEN the ADR Takeaway reaches its concrete example THE DECK SHALL show ADR 0001 as a strong ADR, including Status, Context, Decision, Considered Options and Consequences.
- [x] 3.2 WHEN the ADR Takeaway has shown ADR 0001 THE DECK SHALL show ADR 0002 as a borderline ADR, alongside the three-question test (hard to reverse, surprising without context, a real trade-off) for when to write one.
- [x] 3.3 WHEN the ADR Takeaway explains what an ADR is THE DECK SHALL note that a one-paragraph ADR is also valid, and that the extra sections are optional.
- [ ] 3.4 WHERE the Source Session notes are thin THE DECK SHALL draw the "what it is" and "problem it solves" beats from Michael Nygard's original ADR article, fact-checked by the presenter.
- [x] 3.5 WHEN the ADR Takeaway reaches its Discussion Prompt THE DECK SHALL ask "Name a decision in our codebase nobody can explain anymore. What would it have cost to write it down?"

### 4. Observability and Resilience
**As a** .NET developer in the Audience
**I want** OpenTelemetry and Polly shown through small .NET snippets
**So that** I can see how I would start on my own project

#### Acceptance Criteria
- [x] 4.1 WHEN the Observability Takeaway begins THE DECK SHALL frame it around Shift Left, the Source Session's theme that observability starts in dev, not in production.
- [x] 4.2 WHEN the Observability Takeaway reaches its First Step THE DECK SHALL recommend running the Aspire dashboard locally to view traces.
- [x] 4.3 WHEN the Aspire dashboard is first mentioned THE DECK SHALL note that it is a Recurring Signal, mentioned in both the observability and resilience Source Sessions.
- [x] 4.4 WHEN the Resilience Takeaway begins THE DECK SHALL state that it deliberately shifts the focus from the Source Session's chaos engineering to resilience.
- [x] 4.5 WHEN the Resilience Takeaway reaches its concrete example THE DECK SHALL show a resilience pipeline (e.g. `Microsoft.Extensions.Http.Resilience`) and then a chaos strategy that injects a fault to show the pipeline working.
- [x] 4.6 WHEN the presenter opens the Resilience Takeaway's speaker notes THE DECK SHALL include EF Core's retry-on-failure option, in case someone asks.
- [x] 4.7 WHEN the Observability Takeaway reaches its Discussion Prompt THE DECK SHALL ask "Do our dev and prod environments tell the same story?"
- [x] 4.8 WHEN the Resilience Takeaway reaches its Discussion Prompt THE DECK SHALL ask "Which dependency, if it went down for 10 minutes, would take us down with it?"
- [x] 4.9 IF a project OpenTelemetry snippet is used THEN THE DECK SHALL contain no internal service names, internal URLs or customer data.

### 5. Run the Discussion and share the deck
**As the** presenter and the Audience
**I want** the Discussion Prompts gathered in one place and the deck available afterwards
**So that** the room can pick where to start, and anyone can revisit the links later

#### Acceptance Criteria
- [x] 5.1 WHEN all four Takeaways are done THE DECK SHALL show one slide listing the four Discussion Prompts, each labelled with its Takeaway, ready for a show of hands.
- [ ] 5.2 WHEN the Discussion is over THE DECK SHALL show a resources slide linking to Kiro, Chris Gonzalez's example repo (https://github.com/chrismgonzalez/kiro-quickstart), Matt Pocock's skills, pstack, Michael Nygard's ADR article, OpenTelemetry .NET, the Aspire dashboard and Polly.
- [ ] 5.3 WHEN the repo is deployed THE DECK SHALL build and publish to Netlify using `netlify.toml`.
- [x] 5.4 WHEN `pnpm run export` is run THE DECK SHALL produce a PDF with every slide legible.

## Source Sessions
Taken from `notes/CodeStock 2026 Session Notes.md` (gitignored).

| Takeaway | Session | Speaker |
|---|---|---|
| Structured AI Development | What the Spec! Battle-Tested Practices for Spec-Driven Development Using Kiro | Chris Gonzalez |
| ADRs | Navigating the Maze of Communicating Architecture Decisions | Chad Green |
| Observability (OpenTelemetry) | Shift Observability Left: Why It Starts in Dev | Victor Lyuboslavsky |
| Resilience (Polly) | Polly Want a 500? Chaos Engineering for .NET Apps | Victor Frye |

## Out of Scope
- Live demos of Kiro, OpenTelemetry trace viewers or Polly
- Frontend-specific content (browser tracing, client-side retries, Cockatiel)
- Chaos engineering beyond the single fault-injection example: no game days or feature management
- Deep-dive or tutorial-level coverage of any Takeaway
- Trying pstack on this deck; it is mentioned only
- Committing scanned notes (`notes/` is gitignored)
- Custom Slidev theme work beyond what the existing themes provide

## Open Questions
- Which project OpenTelemetry snippets are worth showing, once they've been cleaned up?
