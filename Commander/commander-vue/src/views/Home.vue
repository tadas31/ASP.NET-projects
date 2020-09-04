<template>
  <div class="container">
    <h1>COMMANDS</h1>
    <router-link to="/upsert/command" class="btn btn-primary create-button" >Add new command</router-link>
    <Commands :commands=getCommands />
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import Commands from '@/components/Commands.vue'

export default {
  name: 'Home',
  components: {
    Commands
  },
  computed: mapGetters(['getCommands']),
  methods: mapActions(['fetchCommands']),
  mounted () {
    this.fetchCommands()
  }
}
</script>

<style scoped>
h1 {
  display: inline-block;
  margin-bottom: 40px;
}

.create-button {
  margin-top: -19px;
  margin-left: 20px;
}
</style>
