<template>
  <page-template title="Login">
    <el-alert title="App in construction, the temporary account is user: 'gamer' and password: '1234'" type="warning" />
    <div style="width: 50%" class="mt-20 mx-auto">
      <el-form ref="formRef" label-width="120px">
        <el-form-item label="Username">
          <el-input class="mb-3 w-40" v-model="username" placeholder="Your username..."></el-input>
        </el-form-item>

        <el-form-item label="Password">
          <el-input class="w-40" v-model="password" placeholder="Your password..."></el-input>
        </el-form-item>

        <div class="text-red-600" v-show="loginError">
          <h1>Invalid username/password combination</h1>
          <el-alert title="Go to /test/seed to reset the database if you believe you entered the right credentials" type="alert" />
        </div>

        <el-form-item>
          <el-button type="primary" @click="onSubmit">Login</el-button>
        </el-form-item>
      </el-form>
    </div>
  </page-template>
</template>

<script>
import axios from "axios";
import PageTemplate from "../components/PageTemplate";

export default {
  name: "LoginView",
  components: {PageTemplate},
  data() {
    return {
      username: '',
      password: '',
      loginError: false
    }
  },
  methods: {
    async onSubmit() {
      this.loginError = false;

      try {
        const loginResponse = await axios.post('/account/login', {
          username: this.username,
          password: this.password
        });

        if (loginResponse.status === 200) {
          localStorage.setItem("jwt", loginResponse.data.jwt);
          axios.defaults.headers.common["Authorization"] =
              "Bearer " + loginResponse.data.jwt;

          const initResponse = await axios.get("/init");

          this.$store.commit('initUser', initResponse.data);
          await this.$router.push({name: 'HomeView'});
        } else {
          this.loginError = true;
        }
      } catch (ex) {
        this.loginError = true;
      }

    }
  }
}
</script>