<template>
  <page-template title="New Semester">
    <el-form ref="formRef" :model="form" class="flex flex-col justify-between w-full">

      <div class="flex flex-row flex-nowrap">
        <div class="text-lg pr-4">Semester name :</div>
        <el-input class="w-48" v-model="semesterName" placeholder="Semester name..."/>

      </div>

      <el-form-item class="flex flex-row my-8">
        <p class="text-lg pr-4">Semester weeks :</p>
        <el-input-number v-model="semesterWeeks" placeholder="Semester weeks..."/>
      </el-form-item>

      <el-form-item class="flex flex-row">
        <p class="text-lg pr-4">Semester start date :</p>
        <el-date-picker v-model="semesterStart" type="date" placeholder="Semester start date"/>
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
  name: "NewClass",
  components: {PageTemplate},
  data() {
    return {
      semesterName: '',
      semesterWeeks: 0,
      semesterStart: new Date(),
      createError: false
    }
  },
  mounted() {
    this.resetFields();
  },
  methods: {
    resetFields() {
      this.semesterName = '';
      this.semesterWeeks = 0;
      this.semesterStart = new Date();
    },
    async onSubmit() {
      try {
        let res = await axios.post('/semester', {
          SemesterName: this.semesterName,
          NbWeeks: this.semesterWeeks
        });

        if (res) {
          ElNotification({
            title: 'Create successful',
            message: `Semester ${this.semesterName} was created successfully`,
            duration: 5000
          });

          this.resetFields();
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