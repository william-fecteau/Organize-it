<template>
  <div class="flex flex-row justify-between w-full h-20" style="background-color: #545c64 !important;">
    <el-menu
        mode="horizontal"
        class="w-full"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
    >
      <el-menu-item index="/">
        <img class="self-center w-auto h-14" alt="Beatuful logo" src="@/assets/logo2.png">
      </el-menu-item>

      <class-selector-menu-item v-if="loggedIn"/>

      <el-menu-item v-if="loggedIn" index="deadlines">Deadlines</el-menu-item>
    </el-menu>

    <div v-if="loggedIn" class="flex items-center justify-center w-full">
      <h1 class="mr-4 text-white">Current semester : </h1>
      <el-select v-model="$store.state.selectedSemester" placeholder="Select" size="large" class="mr-4">
        <el-option
            v-for="(value, key) in semesterList"
            :key="value.id"
            :label="key"
            :value="key"
        >
        </el-option>
      </el-select>
      <el-button class="font-bold" type="primary" plain @click="$router.push({name: 'new-semester'})">
        +
      </el-button>
    </div>
    <el-menu
        v-if="loggedIn"
        mode="horizontal"
        class="w-full flex flex-row-reverse"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b">
      <el-menu-item :disabled="true" class="cursor-default">Welcome {{ $store.state.user.userName }}</el-menu-item>
      <el-menu-item @click="logout" class="cursor-default">Disconnect</el-menu-item>
    </el-menu>
    <el-menu
        mode="horizontal"
        class="w-56 flex flex-row-reverse"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
        v-if="!loggedIn"
    >
      <el-menu-item index="/login">Login</el-menu-item>
    </el-menu>
  </div>
</template>

<script>
import ClassSelectorMenuItem from "@/components/ClassSelectorMenuItem";

export default {
  name: "TopNavigation",
  components: { ClassSelectorMenuItem},
  computed: {
    currentIndex() {
      return this.$route;
    },
    loggedIn() {
      return this.$store.getters.isUserLoggedIn;
    },
    selectedSemester() {
      return this.$store.state.selectedSemester;
    },
    semesterList() {
      return this.$store.state.semesters;
    }
  },
  methods: {
    logout() {
      localStorage.removeItem("jwt");
      this.$store.commit('clearUser');
      this.$router.push({name: 'HomeView'});
    },
    updateSemester(value) {
      this.$store.commit('setSelectedSemester', value);
    }
  }
}
</script>