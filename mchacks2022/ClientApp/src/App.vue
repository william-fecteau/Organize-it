<template>
  <TopNavigation/>
  <router-view/>
</template>

<script>
import axios from "axios"

import TopNavigation from "@/views/navigation/TopNavigation";

export default {
  name: 'App',
  components: {TopNavigation},
  data() {
    return {
      activeName: "first",
      semesters: [],
    }
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event)
    },
  },
  async mounted() {
    try {
      var response = await axios.get("/semester")

      this.semesters = response.data
    } catch (ex) {
      console.log("huhu")
    }
  }
}
</script>
