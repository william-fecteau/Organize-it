<template>
  <div>
    <h1 class="text-4xl">{{ title }}</h1>
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
