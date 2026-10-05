# AGENTS.md

This repo is a Slidev deck for an internal Lunch & Learn, "What I Brought Back From CodeStock". The deck Dogfoods its own Takeaways: the files below are shown on its slides, so keep them real and current.

- **Vocabulary**: `CONTEXT.md` is the glossary. Use its canonical terms in slides, notes and docs, and add new terms there when they are settled.
- **Spec**: `.kiro/specs/codestock-lunch-and-learn-deck/` holds requirements → design → tasks. Write acceptance criteria in EARS (`WHEN … THE DECK SHALL …`), and tick a criterion only when the slide that satisfies it exists.
- **Decisions**: `docs/adr/` holds the ADRs. Keep it to a handful. Write an ADR only for a decision that is hard to reverse, would surprise a future reader, and came from a real trade-off. Record smaller choices in the spec.
- **Source material**: `notes/` (gitignored) holds the presenter's transcribed CodeStock session notes. Treat them as unverified: the presenter fact-checks anything drawn from them, and credits each Source Session's speaker.
- **Snippets**: code on slides is illustrative .NET. Any snippet adapted from a real project uses made-up service names and no internal URLs or customer data.
