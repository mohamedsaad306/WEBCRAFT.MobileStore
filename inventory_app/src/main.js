import Vue from 'vue'
import Router from 'vue-router'
import BootstrapVue from "bootstrap-vue"

import App from './App.vue'
import products from'./components/products.vue'
import HelloWorld from'./components/HelloWorld.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap-vue/dist/bootstrap-vue.css"

 
Vue.use(BootstrapVue)

// const routes = [
//   { path: '/home', component: App },
//   { path: '/prroducts', component: products },
//   { path: '/HelloWorld', component: HelloWorld },
// ]
// const router = new VueRouter({
//   routes // short for `routes: routes`
// })

 

new Vue({  
   el: '#app',
  render: h => h(App)
  // router
}).$mount('#app')