import { createWebHistory, createRouter } from "vue-router";
import TestView1 from "@/views/TestView1";
import TestView2 from "@/views/TestView2";

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
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;