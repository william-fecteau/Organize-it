import { createApp } from "vue";
import { createStore } from "vuex";
import App from "./App.vue";
import "./styles/tailwind_base.css";
import router from "@/router";
import state from "@/store/state";
import mutations from "@/store/mutations";
import getters from "@/store/getters";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import { library } from "@fortawesome/fontawesome-svg-core";
import { faPlusSquare } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import axios from "axios";

library.add(faPlusSquare);

axios.defaults.headers.common["Authorization"] =
  "Bearer " + localStorage.getItem("jwt");

const store = createStore({
  state() {
    return state;
  },
  mutations,
  getters,
});

const app = createApp(App);
app.use(router).use(store).use(ElementPlus);
app.component("font-awesome-icon", FontAwesomeIcon);

app.mount("#app");
