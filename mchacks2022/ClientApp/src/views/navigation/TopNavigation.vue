<template>
  <div class="flex flex-row justify-between">
    <el-menu
        mode="horizontal"
        class="w-full"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
    >
      <el-menu-item index="/" class="h-full">
        <img class="self-center w-auto h-14" alt="McHacks logo" src="@/assets/mchacks.png">
      </el-menu-item>

      <el-menu-item index="/agenda">Agenda</el-menu-item>

      <class-selector-menu-item/>

      <el-menu-item index="deadlines">Deadlines</el-menu-item>

      <semester-selector-sub-menu/>

    </el-menu>

    <el-menu
        mode="horizontal"
        class="w-56 flex flex-row-reverse"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
        v-if="loggedIn"
    >
      <el-menu-item index="/login">Login</el-menu-item>
    </el-menu>
    <el-menu
        v-else
        mode="horizontal"
        class="w-full flex flex-row-reverse"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b">
      <el-menu-item :disabled="true" class="cursor-default">Welcome {{ $store.state.user.userName }}</el-menu-item>
      <el-menu-item @click="logout" class="cursor-default">Disconnect</el-menu-item>
    </el-menu>
  </div>
</template>

<script>
import ClassSelectorMenuItem from "@/components/ClassSelectorMenuItem";
import axios from "axios";
import SemesterSelectorSubMenu from "./SemesterSelectorSubMenu";

export default {
  name: "TopNavigation",
  components: {SemesterSelectorSubMenu, ClassSelectorMenuItem},
  data() {
    return {
      semesters: [{semesterName: 'AAAAA', id: 2}]
    }
  },
  computed: {
    currentIndex() {
      return this.$route;
    },
    loggedIn() {
      return this.$store.getters.isUserLoggedIn;
    }
  },
  async mounted() {
    try {
      var response = await axios.get("/semester", {
        headers: {
          "Authorization": 'Bearer ' + localStorage.getItem("jwt")
        }
      })

      this.semesters = response.data
    } catch (ex) {
      console.log("huhu");
    }
  },
  methods: {
    logout() {
      localStorage.removeItem("jwt");
      this.$store.commit('clearUser');
      this.$router.push({name: 'HomeView'});
    }
  }
}
</script>