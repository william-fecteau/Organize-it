<template>
  <el-menu
      mode="horizontal"
      background-color="#545c64"
      text-color="#fff"
      active-text-color="#ffd04b"
      :router="true"
  >

    <el-menu-item index="/">
      <img class="self-center w-auto" style="height: 50px" alt="McHacks logo" src="./assets/mchacks.png">
    </el-menu-item>

    <el-menu-item index="/agenda">Agenda
    </el-menu-item>
    <class-selector-menu-item/>

    <el-menu-item index="deadlines">Deadlines</el-menu-item>

    <el-sub-menu>
      <template #title>Semesters</template>
      <el-menu-item :index="semester.semesterName" v-for="semester in semesters" :key="semester.id">{{ semester.semesterName }}</el-menu-item>
      <el-menu-item class="mt-5" index="/semesters/new-semester">New semester
        <font-awesome-icon class="ml-2" icon="plus-square"/>
      </el-menu-item>
    </el-sub-menu>

    <el-menu-item index="/login">Login</el-menu-item>

  </el-menu>
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
import ClassSelectorMenuItem from "./components/ClassSelectorMenuItem";
import axios from "axios"

export default {
  name: 'App',
  components: {ClassSelectorMenuItem},
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
          var response = await axios.get("/semester", {
              headers: {
                  "Authorization": 'Bearer ' + localStorage.getItem("jwt")
              }
          })

          this.semesters = response.data
      }
      catch (ex) {
          console.log("huhu")
      }
  }
}
</script>
