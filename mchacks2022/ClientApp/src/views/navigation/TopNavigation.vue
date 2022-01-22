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

      <el-sub-menu >
        <template #title>Classes</template>
        <el-menu-item :route="{name: 'classes'}">GLO-1111</el-menu-item>
        <el-menu-item :route="{name: 'classes'}">MAT-1919</el-menu-item>
        <el-menu-item :route="{name: 'classes', params: { classId: 'huhuhuhu' }}">IFT-3001</el-menu-item>
        <el-menu-item class="mt-5" :route="{name: 'new-class'}">New class
          <font-awesome-icon class="ml-2" icon="plus-square"/>
        </el-menu-item>
      </el-sub-menu>

      <el-menu-item index="deadlines">Deadlines</el-menu-item>

      <el-sub-menu>
        <template #title>Semesters</template>
        <el-menu-item :index="semester.semesterName" v-for="semester in semesters" :key="semester.id">{{ semester.semesterName }}</el-menu-item>
        <el-menu-item class="mt-5" index="/semesters/new-semester">New semester
          <font-awesome-icon class="ml-2" icon="plus-square"/>
        </el-menu-item>
      </el-sub-menu>
    </el-menu>
    <el-menu
        mode="horizontal"
        class="w-full flex flex-row-reverse"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
    >
      <el-menu-item index="/login">Login</el-menu-item>
    </el-menu>
  </div>
</template>

<script>
import ClassSelectorMenuItem from "./components/ClassSelectorMenuItem";
import axios from "axios";

export default {
  name: "TopNavigation",
  components: {ClassSelectorMenuItem},
  data() {
    return {
      semesters: []
    }
  },
  computed: {
    currentIndex() {
      return this.$route;
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
    }
    catch (ex) {
      console.log("huhu")
    }
  }
}
</script>