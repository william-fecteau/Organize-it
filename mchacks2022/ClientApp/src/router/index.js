import { createWebHistory, createRouter } from "vue-router";
import TestView1 from "@/views/TestView1";
import TestView2 from "@/views/TestView2";
import LoginView from "@/views/LoginView";


const routes = [
    {
        path: "/",
        name: "HomeView",
        component: TestView1
    },
    {
        path: "/YEET",
        name: "yeeted",
        component: TestView2
    },
    {
        path: "/login",
        name: "login",
        component: LoginView
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;