<template>
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
</template>

<script>
import axios from "axios";

export default {
  name: "LoginView",
  data() {
    return {
      username: '',
      password: '',
      loginError: false
    }
  },
  methods: {
    onSubmit() {
      axios.post('/account/login', {
        username: this.username,
        password: this.password
      })
          .then((response) => {
            this.loginError = false;
            console.log(response);
          })
          .catch(() => {
            this.loginError = true;
          });
    }
  }
}
</script>