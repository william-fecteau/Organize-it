<template>
  <h1>New Semester</h1>

  <el-form ref="formRef" :model="form" label-width="120px">
    <el-form-item label="Semester name">
      <el-input class="mb-3" v-model="semesterName" placeholder="Semester name..."></el-input>
    </el-form-item>

    <div class="text-red-600" v-show="loginError">Invalid semester name</div>

    <el-form-item>
      <el-button type="primary" @click="onSubmit">Create</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import axios from "axios";

export default {
  name: "LoginView",
  data() {
    return {
      semesterName: '',
      createError: false
    }
  },
  methods: {
    onSubmit() {
      axios.post('/semesters', {
        username: this.semesterName
      })
          .then((response) => {
            this.createError = false;
            console.log(response);
          })
          .catch(() => {
            this.createError = true;
          });
    }
  }
}
</script>