<template>
  <page-template title="New Class">
    <div class="text-lg">
      <h1 v-if="selectedSemester">Current semester selected : <strong>{{ selectedSemester }}</strong></h1>
      <div v-else class="flex text-red-600 items-center">
        <font-awesome-icon icon="plus-square" />
        <h1 class="ml-4">Please select a semester for this class</h1>
      </div>
    </div>
    <el-form ref="formRef" class="flex flex-col justify-between w-full mt-4">
      <div class="flex flex-row flex-nowrap">
        <div class="text-lg pr-4">Class name :</div>
        <el-input class="w-48" v-model="className" placeholder="Ex: History 3"/>
      </div>

      <el-form-item class="flex flex-row my-8">
        <p class="text-lg pr-4">Class number :</p>
        <el-input class="w-48" v-model="classNum" placeholder="Ex: HST-1003"/>
      </el-form-item>

      <div class="text-red-600" v-if="createError">A field is invalid, please check</div>

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
      classNum: null,
      className: null,
      createError: false
    }
  },
  mounted() {
    this.resetFields();
  },
  computed: {
    selectedSemester() {
      return this.$store.state.selectedSemester;
    }
  },
  methods: {
    resetFields() {
      this.classNum = null;
      this.className = null;
    },
    async onSubmit() {
      try {
        let res = await axios.post(`/semester/${this.selectedSemester}`, {
          ClassNum: this.classNum,
          Name: this.className
        });

        if (res) {
          ElNotification({
            title: 'Create successful',
            message: `Class ${this.className} (${this.classNum}) was created successfully`,
            duration: 5000
          });

          this.resetFields();
          this.$store.commit('addSemesterClass', res.data);
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