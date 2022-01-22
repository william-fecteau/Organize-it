<template>
  <h1>TestView2 in da house B) {{ selectedClass }}</h1>
</template>

<script>

export default {
  name: "TestView2",
  props: {
    classId: {
      type: String,
      default: 'no class selected'
    }
  },
  mounted() {
    console.log('mounted');
  },
  computed: {
    selectedClass() {
      console.log('recomputed');
      return this.classId;
    }
  }
}
</script>