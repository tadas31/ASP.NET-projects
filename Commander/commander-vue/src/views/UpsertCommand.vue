<template>
  <div class="container">
    <h1>{{ action }}</h1>
     <div v-if="getError != null && getError == 404" class="text-danger">
       Command not found
        <div>
          <router-link to="/" class="btn btn-success form-control" >Back to Commands</router-link>
        </div>
      </div>
    <form v-if="getError == null || (getError != null && getError != 404)" @submit.prevent="upsert()">
      <div class="form-group row margin-top">
        <div class="col-3">
          <label for="task" class="col-form-label float-right">Task</label>
        </div>
        <div class="col-6">
          <input type="text" name="task" v-model="task" class="form-control" id="task"  placeholder="Task">
        </div>
        <span v-if="getError != null && getError.Task != null" class="text-danger col-form-label">{{ getError.Task[0] }}</span>
      </div>
       <div class="form-group row">
        <div class="col-3">
          <label for="command" class="col-form-label float-right">Command Line</label>
        </div>
        <div class="col-6">
          <input type="text" name="command" v-model="command" class="form-control" id="command" placeholder="Command Line">
        </div>
        <span v-if="getError != null && getError.CommandLine != null" class="text-danger col-form-label">{{ getError.CommandLine[0] }}</span>
      </div>
       <div class="form-group row">
        <div class="col-3">
          <label for="platform" class="col-form-label float-right">Platform</label>
        </div>
        <div class="col-6">
          <input type="text" name="platform" v-model="platform" class="form-control" id="platform" placeholder="Platform">
        </div>
        <span v-if="getError != null && getError.Platform != null" class="text-danger col-form-label">{{ getError.Platform[0] }}</span>
      </div>
      <div class="form-group row">
        <div class="col-3 offset-3">
          <input type="submit" :value="action" class="btn btn-primary form-control" />
        </div>
        <div class="col-3">
          <router-link to="/" class="btn btn-success form-control" >Back to Commands</router-link>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'UpsertCommand',
  data () {
    return {
      action: null,
      task: null,
      command: null,
      platform: null
    }
  },
  computed: mapGetters(['getCommandToUpdate', 'getError']),
  methods: {
    ...mapActions(['fetchCommandToUpdate', 'createNewCommand', 'updateCommand']),
    upsert () {
      if (this.$route.params.id != null) {
        this.updateCommand({ id: this.$route.params.id, Task: this.task, CommandLine: this.command, Platform: this.platform })
      } else {
        this.createNewCommand({ Task: this.task, CommandLine: this.command, Platform: this.platform })
      }
    }
  },
  async beforeMount () {
    if (this.$route.params.id != null) {
      this.action = 'Update'
      await this.fetchCommandToUpdate(this.$route.params.id)
      this.task = this.getCommandToUpdate.task
      this.command = this.getCommandToUpdate.commandLine
      this.platform = this.getCommandToUpdate.platform
    } else {
      this.action = 'Create'
    }
  }
}
</script>

<style scoped>
.margin-top {
  margin-top: 20px;
}
</style>
