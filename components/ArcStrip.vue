<script setup lang="ts">
import type { TakeawayId } from '../data/takeaways'
import { takeaways } from '../data/takeaways'

defineProps<{
  current?: TakeawayId
  showNames?: boolean
}>()
</script>

<template>
  <div class="flex items-start justify-center gap-2 my-6 text-sm">
    <template v-for="(takeaway, i) in takeaways" :key="takeaway.id">
      <span v-if="i > 0" class="opacity-40 pt-1">→</span>
      <div
        class="flex flex-col items-center text-center"
        :class="!current || current === takeaway.id ? '' : 'opacity-40'"
      >
        <span
          class="px-3 py-1 rounded border whitespace-nowrap w-full"
          :class="!current || current === takeaway.id
            ? 'border-primary bg-[#5d8392]/15 font-semibold'
            : 'border-gray-400/30'"
        >
          {{ takeaway.arcStep }}
        </span>
        <span v-if="showNames" class="mt-2 text-xs opacity-80 max-w-40">
          {{ takeaway.name }}<br>({{ takeaway.tool }})
        </span>
      </div>
    </template>
  </div>
</template>
