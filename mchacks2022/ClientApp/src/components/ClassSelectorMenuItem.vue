<template>
  <el-sub-menu>
    <template #title>Classes</template>
    <el-menu-item index="/classes/glo-1111">GLO-1111</el-menu-item>
    <el-menu-item index="/classes/mat-1919">MAT-1919</el-menu-item>
    <el-menu-item index="/classes/ift-3001">IFT-3001</el-menu-item>
    <el-menu-item class="mt-5" index="/classes/new-class">New class
      <font-awesome-icon class="ml-2" icon="plus-square"/>
    </el-menu-item>
  </el-sub-menu>
</template>

<script>


import axios from "axios";

export default {
  name: 'ClassSelectorMenu',
  data() {
    return {
      activeName: "first"
    }
  },
  async mounted() {

    const res = await axios.get("/semester/H2022",
        {
          headers: {
            "Authorization": `Bearer ${localStorage.getItem("jwt")}`,
          }
        }
    );

    console.log(res);

  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event)
    },
  }
}
</script>
