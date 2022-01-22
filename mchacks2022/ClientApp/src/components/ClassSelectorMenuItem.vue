<template>
  <el-sub-menu :unique-opened="true">
    <template #title>Classes</template>
    <el-menu-item :route="{name: 'classes'}">GLO-1111</el-menu-item>
    <el-menu-item :route="{name: 'classes'}">MAT-1919</el-menu-item>
    <el-menu-item :route="{name: 'classes', params: { classId: 'huhuhuhu' }}">IFT-3001</el-menu-item>
    <el-menu-item class="mt-5" :route="{name: 'new-class'}">New class
      <font-awesome-icon class="ml-2" icon="plus-square"/>
    </el-menu-item>
  </el-sub-menu>
</template>

<script>

export default {
  name: 'ClassSelectorMenu',
  data() {
    return {
      activeName: "first"
    }
  },
  async mounted() {
    const res = 'TODO';

    console.log(res);
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event)
    },
  }
}
</script>
