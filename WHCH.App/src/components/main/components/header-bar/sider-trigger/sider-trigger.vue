<template>
  <a @click="handleChange" type="text" :class="['sider-trigger-a', collapsed ? 'collapsed' : '']" style="height:40px;line-height:40px;padding:0px;margin:0px;display:block;float:left;">
    <Icon :type="icon" :size="size"  style="height:40px;line-height:40px;padding:0px;margin:0px;"/>
  </a>
</template>
<script>
import store from '@/store'
export default {
  name: "siderTrigger",
  props: {
    collapsed: Boolean,
    icon: {
      type: String,
      default: "navicon-round"
    },
    size: {
      type: Number,
      default: 26
    }
  },
  methods: {
    handleChange() {
      this.$emit("on-change", !this.collapsed);
      store.commit('changecoll', this.collapsed?"1":"0");
      setTimeout(function(){
        var evt = window.document.createEvent("UIEvents");
        evt.initUIEvent("resize", true, false, window, 0);
        window.dispatchEvent(evt);
      },200);
    }
  }
};
</script>
<style lang="less">
@import "./sider-trigger.less";
</style>
