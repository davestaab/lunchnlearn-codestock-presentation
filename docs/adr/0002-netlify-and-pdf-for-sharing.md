---
status: accepted
date: 2026-10-01
deciders: Dave Staab
---

# Share the deck on Netlify plus a PDF export, not Vercel

## Context

Building in Slidev ([ADR 0001](0001-slidev-for-the-deck.md)) means the deck is a static site, not a file. Attendees, and people who missed the Lunch & Learn, need a way to revisit it afterwards. The Slidev starter template came with deployment configs for *both* Netlify (`netlify.toml`) and Vercel (`vercel.json`). Keeping both means two deployment targets to keep in sync, with no clear owner.

## Decision

Host the deck on Netlify, and delete `vercel.json`. Netlify is the default because the presenter already uses it for other projects; another host would need a compelling feature to win. Also export a PDF (`pnpm run export`) for people who want a file they can keep or attach.

## Considered Options

- **Netlify** (chosen): the presenter already has a Netlify account with several projects on it, so nothing new to sign up for or learn. The config is also already in the repo and works with Slidev's single-page-app routing out of the box.
- **Vercel**: works just as well technically, but offers nothing compelling enough for a static deck to outweigh using an existing account.
- **PDF only**: the simplest option, but it loses clickable navigation, and code slides with step-through highlighting flatten into a single frame.
- **Both hosts**: no benefit for a one-off internal deck, and twice the configuration to maintain.

## Consequences

- Good: one deployment target and one URL to share.
- Good: the PDF covers anyone who can't, or doesn't want to, open a link.
- Bad: the PDF loses click-through animations, so slides need to read clearly in their final state.
- Neutral: switching to Vercel later is cheap (one config file), which is why this ADR is short on drama. It is recorded mainly as a teaching example.
