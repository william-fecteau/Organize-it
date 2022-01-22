import { createWebHistory, createRouter } from "vue-router";
import TestView1 from "@/views/TestView1";
import Class from "@/views/classes/Class"
import LoginView from "@/views/LoginView";

const routes = [
  {
    path: "/",
    name: "HomeView",
    component: TestView1,
  },
  {
    path: "/classes/:classId",
    component: Class,
    props: true,
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
