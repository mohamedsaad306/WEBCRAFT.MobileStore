import Vue from 'vue'
import Router from 'vue-router'
// import HelloWorld from '@/components/HelloWorld'
import Home from '@/components/home'
import UsersManagement from '@/components/UsersManagement'
Vue.use(Router)

export default new Router({
  routes: [{
    path: '/Users',
    name: 'Users',
    component: UsersManagement
  },
  {
    path: '/',
    name: 'Home',
    component: Home
  }
  ]
})
