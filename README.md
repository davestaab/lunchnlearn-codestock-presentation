# What I Brought Back From CodeStock

A [Slidev](https://sli.dev) deck for an internal Lunch & Learn. It covers four Takeaways from CodeStock 2026, each in about 5 minutes, then opens the floor for Discussion:

1. **Structured AI Development** (Kiro & Skill Packs): plan before you prompt
2. **Architecture Decision Records**: record why
3. **Observability** (OpenTelemetry): see it run
4. **Resilience** (Polly): keep it running

## Run it

- `pnpm install`
- `pnpm run dev`: start the deck at <http://localhost:3030> (press `p` for presenter mode and speaker notes)
- `pnpm run build`: build the static site into `dist/`, which Netlify publishes
- `pnpm run export`: export `codestock-lunch-and-learn.pdf`

## The Dogfood

The deck is built with the practices it presents, and these files are shown on its slides:

- [`CONTEXT.md`](./CONTEXT.md): the glossary, produced by a grilling session
- [`.kiro/specs/codestock-lunch-and-learn-deck/`](./.kiro/specs/codestock-lunch-and-learn-deck/): a Kiro-style requirements → design → tasks spec
- [`docs/adr/`](./docs/adr/): the deck's Architecture Decision Records
- [`AGENTS.md`](./AGENTS.md): standing guidance for coding agents working on the deck

Slides import these files with Slidev's `<<<` snippet syntax, so editing a file changes its slide on the next build. Some files have `#region` markers around the parts a slide shows, so keep them in place.

## Layout

- `slides.md`: headmatter, opening slides, and imports of `pages/`
- `pages/`: one file per Takeaway, then the Discussion and resources
- `data/takeaways.ts`: per-Takeaway facts (Arc step, Source Session, Discussion Prompt), shared by the agenda, title slides and the Discussion slide
- `components/`: `TakeawayTitle`, `ArcStrip` and `Callout`
- `snippets/`: illustrative .NET and shell snippets shown on slides
