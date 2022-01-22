import { createWebHistory, createRouter } from "vue-router";
import TestView1 from "@/views/HomeView";
import Class from "@/views/classes/Class"
import LoginView from "@/views/LoginView";
import SeederComponent from "@/components/SeederComponent";

const routes = [
  {
    path: "/",
    name: "HomeView",
    component: TestView1,
  },
  {
    path: "/seedDatabase",
    name: 'seed',
    component: SeederComponent
  },
  {
    path: "/classes/:classId?",
    name: "classes",
    component: Class,
    props: true,
  },
  {
    path: "/classes/new-class",
    name: "new-class",
    component: Class //TODO make component for class create
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
