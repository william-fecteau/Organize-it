<template>
  <div class="flex flex-row">
    <SimpleButton :click-function="decrementNumber" content="-" />
    <h2 class="px-2">{{ number }}</h2>
    <SimpleButton :click-function="incrementNumber" content="+" />
  </div>
</template>

<script>
import SimpleButton from "@/components/SimpleButton";
export default {
  name: "Counter",
  components: {SimpleButton},
  data() {
    return {
      number: 0
    }
  },
  methods: {
    incrementNumber() {
      this.number++;
    },
    decrementNumber() {
      this.number--;
    }
  }
}
</script>

<style scoped>

</style>