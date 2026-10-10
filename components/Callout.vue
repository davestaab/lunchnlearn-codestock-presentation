<script setup lang="ts">
defineProps<{
  label?: string
}>()
</script>

<template>
  <div class="border-l-4 border-primary bg-[#5d8392]/10 rounded px-4 py-3 my-4 text-left">
    <div v-if="label" class="text-xs uppercase tracking-widest font-bold opacity-70 mb-1">
      {{ label }}
    </div>
    <slot />
  </div>
</template>
