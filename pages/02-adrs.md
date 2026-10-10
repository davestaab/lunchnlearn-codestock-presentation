---
layout: center
---

<TakeawayTitle id="adrs" />

<!--
Chad Green's session notes are thin (two lines), so the "what" and "why" here lean on Michael Nygard's original 2011 article that started ADRs. FACT-CHECK both slides against it: https://cognitect.com/blog/2011/11/15/documenting-architecture-decisions
-->

---

# What it is

A short text file that records **one** significant decision, and **why** it was made.

<div class="grid grid-cols-5 gap-2 mt-8 text-center text-sm">
  <div class="border border-primary rounded p-2"><strong>Title</strong><br><span class="opacity-70">a short noun phrase</span></div>
  <div class="border border-primary rounded p-2"><strong>Status</strong><br><span class="opacity-70">proposed, accepted, superseded</span></div>
  <div class="border border-primary rounded p-2"><strong>Context</strong><br><span class="opacity-70">the forces at play</span></div>
  <div class="border border-primary rounded p-2"><strong>Decision</strong><br><span class="opacity-70">what we will do</span></div>
  <div class="border border-primary rounded p-2"><strong>Consequences</strong><br><span class="opacity-70">good, bad and neutral</span></div>
</div>

<div class="h-6" />

- Lives in the repo, next to the code, numbered in order: `docs/adr/0001-….md`
- Never edited after the fact: a new ADR **supersedes** an old one
- **A one-paragraph ADR is valid.** Extra sections, such as Considered Options, are optional.

<!--
The five sections are Nygard's original format. Considered Options comes from later templates like MADR.
Non-Developer Angle: ADRs are the answer to "why on earth did we build it this way?", readable by anyone, without digging through old chat threads.
-->

---

# The problem it solves

<div class="text-2xl mt-8 leading-relaxed">
Decisions outlive the people who remember <em>why</em> they were made.
</div>

When a newcomer doesn't know why, they have two bad choices:

- **Blindly accept it**, even after the reasons stop being true
- **Blindly change it**, and break the thing it was protecting

<div class="mt-8 opacity-70">After Michael Nygard, <em>Documenting Architecture Decisions</em> (2011)</div>

---

# A strong ADR: this deck's ADR 0001

<div class="adr-columns">

<<< @/docs/adr/0001-slidev-for-the-deck.md md

</div>

<style>
.adr-columns .slidev-code {
  column-count: 2;
  column-gap: 1.5rem;
  font-size: 0.62rem !important;
  line-height: 1.35 !important;
}
.adr-columns .slidev-code, .adr-columns .slidev-code code { white-space: pre-wrap !important; }
</style>

<!--
Point at each section: Status in the frontmatter, Context, Decision, Considered Options (including the ones we rejected and why), and Consequences, including the bad ones. Writing down the bad consequences is what makes it honest.
-->

---
layout: two-cols
layoutClass: gap-8
---

# A borderline ADR: 0002

<<< @/docs/adr/0002-netlify-and-pdf-for-sharing.md#decision md

<style>
.slidev-code, .slidev-code code { white-space: pre-wrap !important; }
</style>

::right::

<div class="h-20" />

### Write an ADR only if it is all three:

1. **Hard to reverse**: <span class="text-red-600 font-semibold">✗ 0002 fails: switching hosts is one config file</span>
2. **Surprising without context**: ✓ why not Vercel?
3. **A real trade-off**: ✓ an existing account vs. a host with no advantage

<div class="mt-6 opacity-80">
0002 says so itself, in its Consequences:
</div>

<<< @/docs/adr/0002-netlify-and-pdf-for-sharing.md#teaching-example md

<div class="mt-4 opacity-80">
Smaller choices belong in the spec.
</div>

<!--
The three-question test is in this repo's AGENTS.md, so the agent applies it too.
-->

---

# First Step

<div class="text-3xl mt-12 leading-relaxed">
Write an ADR for the <strong>next</strong> real decision your team makes.
</div>

<div class="mt-12 opacity-80">
One paragraph is enough: what you decided, and why. Commit it to <code>docs/adr/0001-….md</code>.
</div>

<!--
Starting from zero: don't backfill old decisions. Start with the next one.
-->

---
layout: center
class: text-center
---

# Discussion Prompt

<div class="text-3xl mt-8 leading-relaxed">{{ takeaway.discussionPrompt }}</div>

<script setup>
import { takeawayById } from '../data/takeaways'
const takeaway = takeawayById('adrs')
</script>
