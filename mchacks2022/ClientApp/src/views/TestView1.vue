<template>
  <h1>This is component TestView1 ! </h1>
  <SimpleButton :click-function="seedDB" content="Seed the DB"/>

</template>

<script>
import SimpleButton from "@/components/SimpleButton";
import axios from "axios";


export default {
  name: "TestView1",
  components: {SimpleButton},
  methods: {
    async seedDB() {
      axios.get('/test/seed')
          .then((response) => {
            console.log(response);
            //localStorage.setItem("", "")
          })
          .catch(() => {
            console.log("pain");
          });
    },
  }
}
</script>