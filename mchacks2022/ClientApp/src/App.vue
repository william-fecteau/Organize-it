<template>
  <el-tabs class="ml-4" v-model="activeName" @tab-click="handleClick">
    <el-tab-pane label="User" name="first">User</el-tab-pane>
    <el-tab-pane label="Config" name="second">Config</el-tab-pane>
    <el-tab-pane label="Role" name="third">Role</el-tab-pane>
    <el-tab-pane label="Task" name="fourth">Task</el-tab-pane>
  </el-tabs>

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
      <router-link :to="{name: 'login'}">Login</router-link>
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
      activeName: "first"
    }
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event)
    },
    async seedDB() {
      axios.get('/test/seed')
          .then((response) => {
            console.log(response);
            //localStorage.setItem("", "")
          })
          .catch(() => {
            console.log("pain");
          });
    }
  }
}
</script>
