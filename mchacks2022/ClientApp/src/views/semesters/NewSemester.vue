<template>
  <page-template title="New Semester">
    <el-form ref="formRef" :model="form" label-width="120px">
      <el-form-item label="Semester name">
        <el-input class="mb-3" v-model="semesterName" placeholder="Semester name..."/>
        <el-input-number v-model="semesterWeeks" placeholder="Semester weeks..."/>
      </el-form-item>

      <div class="text-red-600" v-if="createError">Invalid semester name</div>

      <el-form-item>
        <el-button type="primary" @click="onSubmit">Create</el-button>
      </el-form-item>
    </el-form>
  </page-template>
</template>

<script>
import axios from "axios";
import PageTemplate from "@/components/PageTemplate";
import {ElNotification} from "element-plus";

export default {
  name: "LoginView",
  components: {PageTemplate},
  data() {
    return {
      semesterName: '',
      semesterWeeks: 0,
      createError: false
    }
  },
  methods: {
    async onSubmit() {
      try {
        let res = await axios.post('/semester', {
          username: this.semesterName
        });

        if (res) {
          ElNotification({
            title: 'Create successful',
            message: `Semester ${this.semesterName} was created successfully`,
            duration: 5
          });
        } else {
          this.createError = true;
        }

      } catch (e) {
        console.log(e);
        this.createError = true;
      }
    }
  }
}
</script>