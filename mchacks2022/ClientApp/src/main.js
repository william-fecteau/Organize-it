import { createApp } from 'vue'
import { createStore } from "vuex";
import App from './App.vue'
import './styles/tailwind_base.css'
import router from './router'
import state from './store/state'

const store = createStore({
    state() {
        return state;
    }
});


const app = createApp(App);
app.use(router).use(store);
app.mount('#app');