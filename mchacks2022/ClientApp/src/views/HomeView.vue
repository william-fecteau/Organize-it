<template>
  <div class="flex flex-col items-center justify-center">
    <h1 class="text-6xl my-4">Welcome Organize-it!</h1>
    <p class="text-xl my-4">All of your classes and deadlines in one convinient place!</p>
    <el-button v-if="showDashboardButton" type="primary" @click="$router.push({name: 'Dashboard'})">
      Go to your dashboard <font-awesome-icon class="ml-2" icon="plus-square"/></el-button>
    <el-button v-else type="primary" @click="seedDB">Seed da DB</el-button>
  </div>

</template>

<script>

export default {
  name: "HomeView",
  computed: {
    showDashboardButton() {
      return this.$store.getters.isUserLoggedIn;
    }
  },
  methods: {
  }
}
</script>