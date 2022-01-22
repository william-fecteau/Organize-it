<template>
  <page-template title="Class">
    <h1>TestView2 in da house B) {{ selectedClass }}</h1>
  </page-template>
</template>

<script>
import PageTemplate from "../../components/PageTemplate";

export default {
  name: "TestView2",
  components: {PageTemplate},
  props: {
    classId: {
      type: String,
      default: 'no class selected'
    }
  },
}
</script>