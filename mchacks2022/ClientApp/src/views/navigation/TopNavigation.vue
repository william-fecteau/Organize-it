<template>
  <div class="flex flex-row justify-between">
    <el-menu
        mode="horizontal"
        class="w-full"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
    >
      <el-menu-item index="/" class="h-full">
        <img class="self-center w-auto h-14" alt="McHacks logo" src="@/assets/mchacks.png">
      </el-menu-item>

      <el-menu-item index="/agenda">Agenda</el-menu-item>

      <el-sub-menu >
        <template #title>Classes</template>
        <el-menu-item :route="{name: 'classes'}">GLO-1111</el-menu-item>
        <el-menu-item :route="{name: 'classes'}">MAT-1919</el-menu-item>
        <el-menu-item :route="{name: 'classes', params: { classId: 'huhuhuhu' }}">IFT-3001</el-menu-item>
        <el-menu-item class="mt-5" :route="{name: 'new-class'}">New class
          <font-awesome-icon class="ml-2" icon="plus-square"/>
        </el-menu-item>
      </el-sub-menu>

      <el-menu-item index="deadlines">Deadlines</el-menu-item>
    </el-menu>
    <el-menu
        mode="horizontal"
        class="w-full flex flex-row-reverse"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
        :router="true"
        :default-active="currentIndex"
    >
      <el-menu-item index="/login">Login</el-menu-item>
    </el-menu>
  </div>
</template>

<script>
export default {
  name: "TopNavigation",
  computed: {
    currentIndex() {
      return this.$route;
    }
  }
}
</script>