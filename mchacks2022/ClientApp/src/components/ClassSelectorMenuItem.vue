<template>
  <el-sub-menu index="1" :unique-opened="true">
    <template #title>Classes</template>
    <el-menu-item v-for="(value, key) in currentClasses" :key="key" :route="{name: 'classes', params: { classId: `${key}` }}">
      {{ value.classNum }}
    </el-menu-item>
    <el-menu-item class="mt-5" :route="{name: 'new-class'}">New class
      <font-awesome-icon class="ml-2" icon="plus-square"/>
    </el-menu-item>
  </el-sub-menu>
</template>

<script>

export default {
  name: 'ClassSelectorMenu',
  computed: {
    currentClasses() {
      return this.$store.state.classes;
    }
  }
}
</script>
