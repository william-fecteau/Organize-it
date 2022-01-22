import { createApp } from "vue";
import { createStore } from "vuex";
import App from "./App.vue";
import "./styles/tailwind_base.css";
import router from "./router";
import state from "./store/state";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import { library } from "@fortawesome/fontawesome-svg-core";
import { faPlusSquare } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

library.add(faPlusSquare);

const store = createStore({
  state() {
    return state;
  },
});

const app = createApp(App);
app.use(router).use(store).use(ElementPlus);
app.component("font-awesome-icon", FontAwesomeIcon);

app.mount("#app");
