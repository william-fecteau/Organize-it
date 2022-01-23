<template>
  <div class="flex flex-col items-start">
    <h1 class="text-4xl mb-4">{{ title }}</h1>
    <slot></slot>
  </div>
</template>

<script>

export default {
  name: 'PageTemplate',
  props: {
    title: String
  },
  updated() {
    console.log(this.title);
  }

}
</script>
