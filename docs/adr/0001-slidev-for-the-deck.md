---
status: accepted
date: 2026-10-01
deciders: Dave Staab
---

# Build the deck in Slidev, not PowerPoint or Google Slides

## Context

The Lunch & Learn shares four Takeaways from CodeStock. Most of its examples are code: OpenTelemetry setup, Polly resilience pipelines, and spec and ADR files. Two of the Takeaways (Structured AI Development and ADRs) are meant to be Dogfooded: the deck itself should be built with the practices it presents, so the examples are real.

## Decision

Build the deck in [Slidev](https://sli.dev), as Markdown slides in a git repo, alongside its own `CONTEXT.md`, Kiro-style spec and ADRs.

## Considered Options

- **PowerPoint**: familiar to everyone, and easy for people who don't code to edit and comment on. Code has to be pasted in as images or poorly formatted text, and there's nowhere natural for specs and ADRs to live.
- **Google Slides**: the same trade-offs as PowerPoint, plus easy sharing. It has the same weakness with code.
- **Slidev** (chosen): code highlighting built in (Shiki), slides are plain text that an AI agent can read and edit, and the deck's spec, glossary and ADRs live in the same repo as the slides.

## Consequences

- Good: code snippets look right without extra effort, and an AI agent can work on the deck the same way it works on code.
- Good: the Dogfood is honest. The ADRs and spec shown on the slides are the real files that shaped the deck.
- Bad: managers, QA and designers can't easily edit or comment on the slides. Feedback has to come through the presenter or a PDF export.
- Bad: moving to another tool later means rebuilding every slide by hand.
- Follow-on: sharing the deck needs a hosting decision (see [ADR 0002](0002-netlify-and-pdf-for-sharing.md)).
