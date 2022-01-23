<template>
  <TopNavigation/>
  <div class="m-8">
    <router-view/>
  </div>
  <page-footer class="fixed bottom-0 left-0"/>
</template>

<script>
import axios from "axios"

import TopNavigation from "@/views/navigation/TopNavigation";
import PageFooter from "@/components/PageFooter";

export default {
  name: 'App',
  components: {PageFooter, TopNavigation},
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
    let jwt = localStorage.getItem("jwt");

    if (jwt) {
      try {
        let response = await axios.get("/init", {
          headers: {
            "Authorization": 'Bearer ' + localStorage.getItem("jwt")
          }
        })

        this.$store.commit('initUser', response.data);
      }
      catch (ex) {
        console.log("failed, get rekt, pain");
        await this.$router.push({name: 'HomeView'})
      }
    } else {
      await this.$router.push({name: 'HomeView'})
    }

    this.$store.state.ready = true;
  }
}
</script>
