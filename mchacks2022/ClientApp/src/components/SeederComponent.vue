<template>
  <div>You should not be seeing this.</div>
</template>

<script>
import axios from "axios";

export default {
  name: "SeederComponent",
  async mounted() {
    try {
      await axios.get('/test/seed');
      console.log('Database seeded');
    } catch (e) {
      console.log('Seed failed')
    }

    await this.$router.push({name: 'HomeView'});
  }
}
</script>

<style scoped>

</style>