<template>
  <h1>TestView2 in da house B) {{ classId }}</h1>
</template>

<script>
export default {
  name: "TestView2",
  props: {
    classId: {
      type: String,
      default: 'no class selected'
    }
  }
}
</script>