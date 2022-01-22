<template>
    <TopNavigation/>
  <router-view/>

  <!--  <div class="w-full flex justify-center items-center flex-col pt-4">-->
  <!--    &lt;!&ndash; This should be replaced with a global header or something &ndash;&gt;-->
  <!--    <MessageDisplay class="my-8" msg="Welcome to McHacks 2022 babyy"/>-->
  <!--    <Counter/>-->
  <!--  </div>-->
  <!--  <div class="w-full flex justify-center items-center flex-col my-8">-->
  <!--    <div class="flex flex-row w-48 justify-between my-4">-->
  <!--      <router-link to="/">Home component</router-link>-->
  <!--      <router-link :to="{name: 'yeeted'}">Yayeet</router-link>-->
  <!--      <router-link :to="{name: 'login'}">Login</router-link>-->
  <!--    </div>-->
  <!--  </div>-->
</template>

<script>


import TopNavigation from "@/views/navigation/TopNavigation";
export default {
  name: 'App',
  components: {TopNavigation},
  data() {
    return {
      activeName: "first"
    }
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event)
    },
  }
}
</script>
