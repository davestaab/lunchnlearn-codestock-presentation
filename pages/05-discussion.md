---
layout: default
---

# Discussion

Which one do we start with? Show of hands.

<ol class="mt-8 space-y-5 text-xl">
  <li v-for="t in takeaways" :key="t.id">
    <div class="text-sm uppercase tracking-wider opacity-60">{{ t.name }}</div>
    <div>{{ t.discussionPrompt }}</div>
  </li>
</ol>

<script setup>
import { takeaways } from '../data/takeaways'
</script>

<!--
Read all four, take a show of hands, start with the most popular. Bring your own takeaways too: this is the open part of the session.
-->
