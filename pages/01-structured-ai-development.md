---
layout: center
---

<TakeawayTitle id="structured-ai" />

<!--
Chris Gonzalez's session was about Kiro, AWS's agentic AI IDE. 

This talk uses Kiro but the idea is bigger than one tool, so I'm calling it Structured AI Development.

This this session I've come across similar ideas in skill packs. AI skills designed to work together to accomplish AI work.
-->

---

# What it is: specs, not vibes

Give AI-assisted coding a deliberate workflow, so you plan before you prompt.

<div class="flex items-center justify-center gap-4 mt-12 text-xl">
  <div class="border-2 border-primary rounded-lg px-6 py-4 text-center">
    <div class="font-bold">Requirements</div>
    <div class="text-sm opacity-70">what must be true</div>
  </div>
  <div class="text-3xl opacity-50">→</div>
  <div class="border-2 border-primary rounded-lg px-6 py-4 text-center">
    <div class="font-bold">Design</div>
    <div class="text-sm opacity-70">how we'll build it</div>
  </div>
  <div class="text-3xl opacity-50">→</div>
  <div class="border-2 border-primary rounded-lg px-6 py-4 text-center">
    <div class="font-bold">Tasks</div>
    <div class="text-sm opacity-70">small, reviewable steps</div>
  </div>
</div>

<div class="text-center mt-10 opacity-80">
Each step is a Markdown file a human reviews and edits <em>before</em> any code is written.
</div>

<!--
Non-Developer Angle: the requirements are plain-language acceptance criteria that managers, QA and designers can review before a single line of code exists.
-->

---

# The problem it solves

- Ad-hoc prompting produces code **nobody planned**, so nobody can really **review** it
- The agent fills every gap with a guess, and the guesses only show up later
- Context lives in one chat window, then it's gone

<div class="text-center text-3xl mt-16 italic">
"The work you do up front matters 10x more."
</div>
<div class="text-center opacity-70 mt-2">Chris Gonzalez</div>

---

# Same building blocks, packaged differently

| Building block | Kiro: [kiro-quickstart](https://github.com/chrismgonzalez/kiro-quickstart) | General-purpose agent: this repo |
|---|---|---|
| **Steering**: standing guidance | `.kiro/steering/` | `AGENTS.md` |
| **Skills**: reusable workflows | `.kiro/skills/` | Skill Packs: Matt Pocock's skills, pstack |
| **Hooks**: automation on events | `.kiro/hooks/` (quality checks, docs sync) | <span class="opacity-60 italic">empty: the next thing to try</span> |
| **Specs**: requirements → design → tasks | `.kiro/specs/` (on the `demo/*` branches) | `.kiro/specs/codestock-lunch-and-learn-deck/` |

<div class="text-sm opacity-70 mt-6">
Kiro column: Chris Gonzalez's example repo, github.com/chrismgonzalez/kiro-quickstart
</div>

<!--
Kiro bakes these four building blocks into the IDE. A general-purpose agent like Codex or Claude Code gets the same four from files in the repo plus a Skill Pack. Hooks are the gap on our side: that's what I'd try next, e.g. run the build after every edit.
-->

---
layout: two-cols
layoutClass: gap-8
---

# Dogfood: this deck

### A grilling session → `CONTEXT.md`

The agent interviewed me (Matt Pocock's skills) and wrote down the vocabulary we settled on:

<<< @/CONTEXT.md#glossary-excerpt md

<style>
.slidev-code, .slidev-code code { white-space: pre-wrap !important; }
</style>

::right::

<div class="h-20" />

### A Kiro-*style* spec

The same requirements → design → tasks flow, written by a general-purpose agent. No Kiro involved.

```text
.kiro/specs/codestock-lunch-and-learn-deck/
├── requirements.md   user stories + EARS criteria
├── design.md         files, components, edge cases
└── tasks.md          ordered, checkable tasks
```

<!--
The context excerpt on this slide is imported from the repo at build time, so it's the real file, not a copy. The glossary gives the presentation it's structure with the arc and beats.
-->

---

# A real requirement, in EARS

**E**asy **A**pproach to **R**equirements **S**yntax: *WHEN* ‹trigger› *THE* ‹system› *SHALL* ‹response›

<<< @/.kiro/specs/codestock-lunch-and-learn-deck/requirements.md#ears-example md

<style>
.slidev-code, .slidev-code code { white-space: pre-wrap !important; }
</style>

<div class="mt-8 text-xl text-center">
This slide is the one that satisfies 2.3.
</div>

<div class="mt-8 text-sm opacity-70 text-center">
Imported from <code>requirements.md</code> at build time
</div>

<!--
The requirements section of KIRO creates requirements in the EARS format.

EARS came out of aerospace requirements work around 2000. Kiro writes its acceptance criteria in it. It's structured enough for an agent to check against, and plain enough for anyone in the room to read.
-->

---

# The Six Principles

From Chris Gonzalez's session

1. Understand the behavior.
2. <span class="bg-yellow-300/50 px-1 font-semibold">You're now an architect and decision maker.</span>
3. The work you do up front matters 10x more.
4. Review, review, review.
5. You're still responsible for AI-written code.
6. Discipline = freedom.

<!--
Fact-checked: the Six Principles wording, from Chris Gonzalez's session.
Number 2 is the one I want to argue about, so it's this Takeaway's Discussion Prompt. We'll come back to it in the Discussion.
-->

---

# First Step

<div class="text-3xl mt-12 leading-relaxed">
Install <strong>one</strong> Skill Pack in the agent your project already uses, and run it on your next ticket.
</div>

<div class="mt-12 opacity-80">
<strong>Worked example, Codex:</strong> put your project's conventions in <code>AGENTS.md</code> (steering), and install the skills wherever your agent loads them.
</div>

<div class="mt-8 text-sm opacity-80">
Two Skill Packs to start from:

- Matt Pocock's skills: [github.com/mattpocock/skills](https://github.com/mattpocock/skills)
- pstack, by Lauren Tan (poteto): [x.com/poteto/article/2094457600259842065](https://x.com/poteto/article/2094457600259842065)

</div>

<!--
Starting from zero: no Kiro, no new IDE. One Skill Pack, one ticket, then decide if it was worth it.
-->

---
layout: center
class: text-center
---

# That grilling session also produced this repo's ADRs →

<div class="opacity-70 mt-4">Which is where we're going next.</div>
