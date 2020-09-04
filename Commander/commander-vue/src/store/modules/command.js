import axios from 'axios'
import router from '../../router'

const state = {
  commands: null,
  commandToUpdate: null,
  error: null,
  errorForDisplayingList: null
}

const getters = {
  getCommands (state) {
    return state.commands
  },
  getCommandToUpdate (state) {
    return state.commandToUpdate
  },
  getError (state) {
    return state.error
  },
  getErrorForDisplayingList (state) {
    return state.errorForDisplayingList
  }
}

const actions = {
  async fetchCommands ({ commit }) {
    await axios.get(process.env.VUE_APP_API + 'command')
      .then(response => {
        commit('setCommands', response.data)
      })
      .catch(error => {
        commit('setErrorForDisplayingList', error.response.data.status)
      })
  },
  async fetchCommandToUpdate ({ commit }, id) {
    await axios.get(process.env.VUE_APP_API + 'command/' + id)
      .then(response => {
        commit('setCommandToUpdate', response.data)
      })
      .catch(error => {
        commit('setError', error.response.data.status)
      })
  },
  async createNewCommand ({ commit }, command) {
    await axios.post(process.env.VUE_APP_API + 'command', command)
      .then(response => {
        commit('addCommand', response)
      })
      .catch(error => {
        commit('setError', error.response.data.errors)
      })
  },
  async updateCommand ({ commit }, command) {
    await axios.put(process.env.VUE_APP_API + 'command/' + command.id, command)
      .then(response => {
        router.push('/')
      })
      .catch(error => {
        commit('setError', error.response.data.errors)
      })
  },
  async deleteCommand ({ commit }, id) {
    await axios.delete(process.env.VUE_APP_API + 'command/' + id)
      .then(response => {
        commit('deleteCommandFromList', id)
      })
      .catch(response => {
        commit('deleteCommandFromList', id)
      })
  }
}

const mutations = {
  setCommands (state, commands) {
    state.error = null
    state.errorForDisplayingList = null
    state.commands = commands
  },
  setCommandToUpdate (state, commandToUpdate) {
    state.error = null
    state.errorForDisplayingList = null
    state.commandToUpdate = commandToUpdate
  },
  addCommand (state, command) {
    state.error = null
    state.errorForDisplayingList = null
    router.push('/')
  },
  setError (state, error) {
    state.error = error
  },
  setErrorForDisplayingList (state, error) {
    state.errorForDisplayingList = error
  },
  deleteCommandFromList (state, id) {
    const i = state.commands.map(item => item.id).indexOf(id)
    state.commands.splice(i, 1)
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
