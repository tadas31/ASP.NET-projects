<template>
    <div>
      <div v-if="getErrorForDisplayingList != null && getErrorForDisplayingList == 404" class="text-danger">
        No Commands found
      </div>
      <table v-if="getErrorForDisplayingList == null || (getErrorForDisplayingList != null && getErrorForDisplayingList != 404)" class="table table-striped">
        <thead>
          <tr>
            <th>Task</th>
            <th>Command</th>
            <th>Platform</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="command in commands" v-bind:key="command.id">
            <td>{{ command.task }}</td>
            <td>{{ command.commandLine }}</td>
            <td>{{ command.platform }}</td>
            <td>
              <router-link :to="{ path: '/upsert/command/' + command.id }" class="btn btn-success" >Update</router-link>  &nbsp;
              <button type="button" class="btn btn-danger" @click="callDeleteCommand(command.id, command.task)">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'Commands',
  props: ['commands'],
  computed: mapGetters(['getErrorForDisplayingList']),
  methods: {
    ...mapActions(['deleteCommand']),
    callDeleteCommand (id, task) {
      if (confirm('Are you sure you want to delete command: "' + task + '"')) {
        this.deleteCommand(id)
      }
    }
  }
}
</script>

<style scoped>
h1 {
  display: inline-block;
}

.create-button {
  margin-top: -19px;
  margin-left: 20px;
}
</style>
