---
theme: seriph
# local copy of an Unsplash photo, so every build and PDF look the same
background: /title-background.jpg
title: What I Brought Back From CodeStock
info: |
  An internal Lunch & Learn: four Takeaways from CodeStock 2026, then a Discussion.
class: text-center
transition: slide-left
duration: 45min
exportFilename: codestock-lunch-and-learn
drawings:
  persist: false
---

# What I Brought Back From CodeStock

A Lunch & Learn

<div class="mt-12 text-xl opacity-80">
Bring your lunch, bring an opinion.
</div>

<!--
Background photo: Unsplash, https://unsplash.com/photos/hoZeHN9fxvk (photographer credit TBD).

Welcome everyone. Four ideas from CodeStock, about 5 minutes each, then the rest of the hour is Discussion.

Disclaimer: This is just what I found interesting and the sessions I went to. Your experience may vary.
-->

---
layout: default
---

# What is CodeStock?

- A **community-run** tech conference in **Knoxville, TN**
- Sessions across languages, process, AI and soft skills
- I attended four sessions, and each became a Takeaway:

<div class="grid grid-cols-2 gap-3 mt-6 text-sm text-left">
  <div v-for="t in takeaways" :key="t.id" class="border border-gray-400/30 rounded px-3 py-2">
    <div class="font-semibold">{{ t.source.title }}</div>
    <div class="opacity-70">{{ t.source.speaker }}</div>
  </div>
</div>

<script setup>
import { takeaways } from './data/takeaways'
</script>

<!--
FACT-CHECK before presenting: the conference description (community-run, Knoxville) and the session titles and speakers, against the printed schedule.

todo: fix i attended sessions
-->

---
layout: center
class: text-center
---

# Agenda: The Arc

<ArcStrip show-names />

<div class="mt-10 text-xl">then: <strong>Discussion</strong></div>

<!--
The four Takeaways build on each other: plan before you prompt, record why, see it run, keep it running. About 5 minutes each, then we open the floor.
-->

---
src: ./pages/01-structured-ai-development.md
---

---
src: ./pages/02-adrs.md
---

---
src: ./pages/03-observability.md
---

---
src: ./pages/04-resilience.md
---

---
src: ./pages/05-discussion.md
---

---
src: ./pages/06-resources.md
---
