# Requirements: CodeStock Lunch & Learn Deck

## Overview
A Slidev deck for the internal Lunch & Learn "What I Brought Back From CodeStock". It covers four Takeaways (Structured AI Development, ADRs, Observability with OpenTelemetry, and Resilience with Polly), and each one follows the same five Beats. A Discussion fills the second half of the session. The deck Dogfoods its own first two Takeaways: the repo's `CONTEXT.md`, its Kiro-style spec and its ADRs are the concrete examples. Terms follow `CONTEXT.md`, and decisions follow `docs/adr/`.

## User Stories

### Follow the four Takeaways
**As an** Audience member (mostly .NET developers, plus managers, QA and designers)
**I want** each Takeaway presented in the same short, predictable shape
**So that** I understand what each idea is and what I could try next week, in about 5 minutes each

#### Acceptance Criteria
- [ ] Given the deck opens, when I advance past the title slide, then I see one "What is CodeStock" slide followed by an agenda that states The Arc: plan before you prompt → record why → see it run → keep it running
- [ ] Given any of the four Takeaways, when I step through it, then it presents the Beats in order: what it is → the problem it solves → a concrete example → First Step → Discussion Prompt
- [ ] Given the Takeaways, when I go through the deck, then they appear in Arc order: Structured AI Development, ADRs, Observability (OpenTelemetry), Resilience (Polly)
- [ ] Given each Takeaway, when I reach its First Step, then it names exactly one small action that assumes the team is starting from zero (for OpenTelemetry, extending it to projects that don't use it yet)
- [ ] Given any slide with code, when it is shown, then it uses a highlighted snippet and needs no live demo
- [ ] Given each Takeaway, when I open the presenter notes, then they contain a one-line Non-Developer Angle

### See the practices used on the deck itself (Dogfood)
**As an** Audience member
**I want** the Structured AI Development and ADR Takeaways illustrated with artifacts from the deck's own repo
**So that** the examples are real, not hypothetical

#### Acceptance Criteria
- [ ] Given the Structured AI Development Takeaway, when it reaches the concrete example, then it shows the grilling session producing `CONTEXT.md` (Matt Pocock's skills) next to this Kiro-style requirements → design → tasks spec, and labels the spec as Kiro-*style*, not Kiro
- [ ] Given the Structured AI Development Takeaway, when it introduces examples, then it presents Kiro as a dedicated IDE and Skill Packs (Matt Pocock's skills, pstack) as structure added to the agent you already use
- [ ] Given the end of Structured AI Development, when I move to ADRs, then a transition slide notes that the grilling session produced ADRs
- [ ] Given the ADR Takeaway, when it reaches the concrete example, then it shows `docs/adr/0001-slidev-for-the-deck.md`

### Run the Discussion
**As the** presenter
**I want** the Discussion Prompts gathered on one slide after the Takeaways
**So that** the room can choose where to start and talk for 20+ minutes

#### Acceptance Criteria
- [ ] Given all four Takeaways are done, when I advance, then one slide lists the four Discussion Prompts, each labelled with its Takeaway, ready for a show of hands
- [ ] Given the Discussion is over, when I advance, then a resources slide links to the relevant docs for Kiro, Matt Pocock's skills, pstack, ADRs, OpenTelemetry .NET and Polly
- [ ] Given the speaker notes have been scanned and fact-checked, when a Takeaway draws on a CodeStock session, then that session's speaker is credited on the Takeaway's slides

### Share the deck afterwards
**As an** Audience member who couldn't attend, or wants to revisit
**I want** to open the deck after the talk
**So that** I can follow the links and examples at my own pace

#### Acceptance Criteria
- [ ] Given the repo, when it is deployed, then it builds and publishes to Netlify using `netlify.toml` (no Vercel config is present)
- [ ] Given the finished deck, when `pnpm run export` is run, then a PDF is produced with every slide legible
- [ ] Given any project OpenTelemetry snippet in the deck, when it is published, then it contains no internal service names, internal URLs or customer data

## Out of Scope
- Live demos of Kiro, OpenTelemetry trace viewers or Polly
- Frontend-specific content (browser tracing, client-side retries)
- Deep-dive or tutorial-level coverage of any Takeaway
- Trying pstack on this deck; it is mentioned only
- Committing scanned notes (`notes/` is gitignored)
- Custom Slidev theme work beyond what the existing themes provide

## Open Questions
- Which CodeStock sessions and speakers map to each Takeaway? This is blocked until the paper notes are scanned.
- Which project OpenTelemetry snippets are worth showing, once they've been cleaned up?
- What is the exact wording of each Discussion Prompt?
