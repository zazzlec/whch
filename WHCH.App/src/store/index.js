import Vue from 'vue'
import Vuex from 'vuex'

import user from './module/user'
import app from './module/app'

Vue.use(Vuex)

const mutations = {
  changecoll(state, str){
      state.iscoll = str;
  }
}


export default new Vuex.Store({
  mutations: mutations,
  state: {
    iscoll:"0"
  },
  actions: {
    //
  },
  modules: {
    user,
    app
  }
})
