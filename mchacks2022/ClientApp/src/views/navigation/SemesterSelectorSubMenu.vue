<template>
  <el-sub-menu index="2" :unique-opened="true">
    <template #title>Semesters</template>
    <el-menu-item @click="getSemesterClasses(semester.semesterName)" :index="semester.semesterName"
                  v-for="semester in semesters" :key="semester.id">
      {{ semester.semesterName }}
    </el-menu-item>
    <el-menu-item class="mt-5" index="/semesters/new-semester">New semester
      <font-awesome-icon class="ml-2" icon="plus-square"/>
    </el-menu-item>
  </el-sub-menu>

</template>

<script>
import axios from "axios";

export default {
  name: "SemesterSelectorSubMenu",
  data() {
    return {
      semesters: [{semesterName: 'AAAAA', id: 2}]
    }
  },
  computed: {
    currentIndex() {
      return this.$route;
    }
  },
  methods: {
    async getSemesterClasses(semesterName) {
      const {data: semesterClasses} = await axios.get(`/semester/${semesterName}`);
      console.log(semesterClasses)

    }
  },
  async mounted() {
    try {
      var response = await axios.get("/semester")

      this.semesters = response.data

      this.$store.commit("setSelectedSemester", response.data)


    } catch (ex) {
      console.log("huhu");
    }
  }
}
</script>