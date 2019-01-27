import Vue from 'vue'
import VueRouter from 'vue-router'
import BootstrapVue from "bootstrap-vue"


import App from './App.vue'
import WarehousesMain from './components/Warehouses/Warehouses.Main.vue'
import ProductsMain from './components/products/products.Main.vue'
import CustomersMain from './components/Customers/Customers.Main.vue'

import HelloWorld from './components/HelloWorld.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap-vue/dist/bootstrap-vue.css"


Vue.use(BootstrapVue);
Vue.use(VueRouter);

const routes = [

  { path: '/Warehouses', component: WarehousesMain },
  { path: '/Products', component: ProductsMain },
  { path: '/Customers', component: CustomersMain },
  { path: '/HelloWorld', component: HelloWorld },
];

const router = new VueRouter({
  routes // short for `routes: routes`
})



new Vue({
  router: router,
  el: '#app',
  render: h => h(App)
  // router
}).$mount('#app')