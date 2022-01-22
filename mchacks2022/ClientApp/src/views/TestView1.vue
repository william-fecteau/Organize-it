<template>
  <h1>This is component TestView1 ! </h1>
  <el-button type="primary" @click="seedDB">Seed da DB</el-button>

</template>

<script>
import axios from "axios";


export default {
  name: "TestView1",
  methods: {
    async seedDB() {
      axios.get('/test/seed')
          .then((response) => {
            console.log(response);
          })
          .catch(() => {
            console.log("pain");
          });
    },
  }
}
</script>