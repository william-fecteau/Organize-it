<template>
  <page-template title="Login">
    <div style="width: 20%" class="mt-20 mx-auto">


      <h1>Login</h1>

      <el-form ref="formRef" :model="form" label-width="120px">
        <el-form-item label="Username">
          <el-input class="mb-3" v-model="username" placeholder="Your username..."></el-input>
        </el-form-item>

        <el-form-item label="Password">
          <el-input v-model="password" placeholder="Your password..."></el-input>
        </el-form-item>

        <div class="text-red-600" v-show="loginError">Invalid username/password combination</div>

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
      try {
        const response = await axios.post('/account/login', {
          username: this.username,
          password: this.password
        });

        this.loginError = false;
        console.log(response);
        localStorage.setItem("jwt", response.data.jwt);

      } catch (ex) {
        this.loginError = true;
      }

    }
  }
}
</script>