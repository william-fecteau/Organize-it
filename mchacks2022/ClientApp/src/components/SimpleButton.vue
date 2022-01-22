<template>
  <div class="w-6 h-6 rounded text-center" :class="backgroundColor" @click="clickFunction">
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