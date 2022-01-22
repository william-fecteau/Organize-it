<template>
  <div>
    <h1>{{ title }}</h1>
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
