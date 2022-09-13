import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Form from "../views/Form.vue";
import Vocabulary1 from "../views/Vocabulary1.vue";
import Vocabulary2 from "../views/Vocabulary2.vue";
import Forward from "../views/Forward.vue";
import Sentences from "../views/Sentences.vue";
import Language from "../views/Language.vue"
import Final from "../views/Final.vue";
import Others from "../views/Others.vue";


Vue.use(VueRouter);

export default new VueRouter({
    mode: 'history',
    routes : [
      {
        path : '/',
        name: 'Home',
        component: Home
      },
      {
        path: '/Form',
        name: 'Form',
        component: Form,
      },
      {
        path: '/Vocabulary1',
        name: 'Vocabulary1',
        component: Vocabulary1,
      },
      {
        path: '/Vocabulary2',
        name: 'Vocabulary2',
        component: Vocabulary2,
      },
      {
        path: '/Forward',
        name: 'Forward',
        component: Forward,
      },
      {
        path: '/Sentences',
        name: 'Sentences',
        component: Sentences,
      },
      {
        path: '/Final',
        name: 'Final',
        component: Final,
      },
      {
        path: '/Language',
        name: 'Language',
        component: Language,
      },
      {
        path: '/Others',
        name: 'Others',
        component: Others,
      }
    ]
});

