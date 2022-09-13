import Vue from 'vue/dist/vue.esm.js';
import App from './App.vue';

import './assets/global.css';
import './assets/formulate.css';
import 'sweetalert2/src/sweetalert2.scss'
import 'sweetalert2/dist/sweetalert2.min.css';
import 'animate.css';
import VueSweetalert2 from 'vue-sweetalert2';
import router from './router/index.js';
import VueFormulate from '@braid/vue-formulate';
import VueRouter from 'vue-router';

Vue.use(VueRouter);
Vue.use(VueFormulate);
Vue.use(router);
Vue.use(VueSweetalert2);


Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  router: router
}).$mount('#app')


