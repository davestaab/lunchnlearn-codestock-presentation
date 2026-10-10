<script setup lang="ts">
import type { TakeawayId } from '../data/takeaways'
import { computed } from 'vue'
import { takeawayById } from '../data/takeaways'

const props = defineProps<{
  id: TakeawayId
  focusNote?: string
}>()

const takeaway = computed(() => takeawayById(props.id))
</script>

<template>
  <div class="text-center">
    <h1>{{ takeaway.name }}</h1>
    <div class="text-2xl opacity-80 -mt-4">
      {{ takeaway.tool }}
    </div>
    <ArcStrip :current="id" />
    <div class="opacity-70">
      From <em>{{ takeaway.source.title }}</em>, {{ takeaway.source.speaker }}
    </div>
    <Callout v-if="focusNote" class="max-w-xl mx-auto mt-6">
      {{ focusNote }}
    </Callout>
  </div>
</template>
