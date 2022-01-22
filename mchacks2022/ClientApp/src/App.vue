<template>
  <div class="w-full flex justify-center items-center flex-col pt-4">
    <!-- This should be replaced with a global header or something -->
    <img class="self-center w-auto" alt="McHacks logo" src="./assets/mchacks.png">
    <MessageDisplay class="my-8" msg="Welcome to McHacks 2022 babyy"/>
    <Counter/>
  </div>
  <div class="w-full flex justify-center items-center flex-col my-8">
    <div class="flex flex-row w-48 justify-between my-4">
      <router-link to="/">Home component</router-link>
      <router-link :to="{name: 'yeeted'}">Yayeet</router-link>
    </div>
    <router-view/>
  </div>
  <SimpleButton :click-function="seedDB" content="Seed the DB"/>
</template>

<script>
import MessageDisplay from './components/MessageDisplay.vue'
import Counter from "@/components/Counter";
import SimpleButton from "@/components/SimpleButton";
import axios from "axios";


export default {
  name: 'App',
  components: {
    SimpleButton,
    Counter,
    MessageDisplay
  },
  data() {
    return {

    }
  },
  methods: {
    async seedDB() {
      axios.get('/test/seed')
          .then((response) => {
            console.log(response);
          })
          .catch(() => {
            console.log("pain");
          });
    }
  }
}
</script>
