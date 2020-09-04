import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'
import UpsertCommand from '../views/UpsertCommand'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/upsert/command',
    name: 'Create command',
    component: UpsertCommand
  },
  {
    path: '/upsert/command/:id',
    name: 'Update command',
    component: UpsertCommand
  }
]

const router = new VueRouter({
  routes
})

export default router
