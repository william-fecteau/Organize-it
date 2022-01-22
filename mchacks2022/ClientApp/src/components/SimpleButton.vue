<template>
  <div class="p-4 rounded text-center" :class="backgroundColor" @click="clickFunction">
    {{ content }}
  </div>
</template>

<script>
export default {
  name: "SimpleButton",
  props: {
    clickFunction: {Function, required: true},
    backgroundColor: {String, default: 'bg-blue-700'},
    content: String
  }
}
</script>

<style scoped>

</style>