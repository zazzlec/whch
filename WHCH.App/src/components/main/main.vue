<template>
  <Layout style="height: 100%" class="main">
          <Content class="content-wrapper">
            <keep-alive :include="cacheList">
              <router-view/>
            </keep-alive>
            <ABackTop :height="100" :bottom="80" :right="50" container=".content-wrapper"></ABackTop>
          </Content>
  </Layout>
</template>
<script>
import SideMenu from "./components/side-menu";
import HeaderBar from "./components/header-bar";
import TagsNav from "./components/tags-nav";
import User from "./components/user";
import ABackTop from "./components/a-back-top";
import Fullscreen from "./components/fullscreen";
import Language from "./components/language";
import {
  hasnoreadmassage
} from "@/api/ZNRS/DncMessage";
import ErrorStore from "./components/error-store";
import { mapMutations, mapActions, mapGetters } from "vuex";
import { getNewTagList, getNextRoute, routeEqual } from "@/libs/util";
import routers from "@/router/routers";
import minLogo from "@/assets/images/smallogo.png";
import maxLogo from "@/assets/images/logo.jpg";
import biglogo from "@/assets/images/biglogo.png";
import "./main.less";
export default {
  name: "Main",
  components: {
    SideMenu,
    HeaderBar,
    Language,
    TagsNav,
    Fullscreen,
    ErrorStore,
    User,
    ABackTop
  },
  data() {
    return {
      timer: '',
      collapsed: true,
      minLogo,
      maxLogo,
      biglogo,
      isFullscreen: false,
      msgs:[]
    };
  },
  computed: {
    ...mapGetters(["errorCount"]),
    tagNavList() {
      return this.$store.state.app.tagNavList;
    },
    tagRouter() {
      return this.$store.state.app.tagRouter;
    },
    userAvator() {
      return this.$store.state.user.avatorImgPath;
    },
    cacheList() {
      return [
        "ParentView",
        ...(this.tagNavList.length
          ? this.tagNavList
              .filter(item => !(item.meta && item.meta.notCache))
              .map(item => item.name)
          : [])
      ];
    },
    menuList() {
      let menus = this.$store.getters.menuList;
      return menus;
    },
    local() {
      return this.$store.state.app.local;
    },
    hasReadErrorPage() {
      return this.$store.state.app.hasReadErrorPage;
    },
    unreadCount() {
      return this.$store.state.user.unreadCount;
    }
  },
  methods: {
    ...mapMutations([
      "setBreadCrumb",
      "setTagNavList",
      "addTag",
      "setLocal",
      "setHomeRoute"
    ]),
    ...mapActions(["handleLogin", "getUnreadMessageCount"]),
    turnToPage(route) {
      let { name, params, query } = {};
      if (typeof route === "string") name = route;
      else {
        name = route.name;
        params = route.params;
        query = route.query;
      }
      if (name.indexOf("isTurnByHref_") > -1) {
        window.open(name.split("_")[1]);
        return;
      }
      this.$router.push({
        name,
        params,
        query
      });
    },
    handleCollapsedChange(state) {
      this.collapsed = state;
    },
    handleCloseTag(res, type, route) {
      if (type === "all") {
        this.turnToPage(this.$config.homeName);
      } else if (routeEqual(this.$route, route)) {
        if (type !== "others") {
          const nextRoute = getNextRoute(this.tagNavList, route);
          this.$router.push(nextRoute);
        }
      }
      this.setTagNavList(res);
    },
    handleClick(item) {
      this.turnToPage(item);
    },
    get(){
      let o=this;
      // hasnoreadmassage({ ids: ""+JSON.stringify(o.msgs) }).then(res => {
      //   if(res.data.code==404){
          
      //   }else{
      //     this.$Notice.info({
      //       title: res.data.data.k_Msg_kw,
      //       desc: res.data.data.remark,
      //       duration: 0,
      //       name: res.data.data.id,
      //       onClose : function(){
      //         for (let index = 0; index < o.msgs.length; index++) {
      //           const element = o.msgs[index];
      //           if(element==this.name){
      //             o.msgs.splice(index,1);
      //             break;
      //           }
      //         }
      //       }
      //     });

      //     if(o.msgs.indexOf(res.data.data.id)==-1){
      //       o.msgs.push(res.data.data.id);
      //     }
      //   }
      // });
      
    }
  },
  watch: {
    $route(newRoute) {
      const { name, query, params, meta } = newRoute;
      this.addTag({
        route: { name, query, params, meta },
        type: "push"
      });
      this.setBreadCrumb(newRoute);
      this.setTagNavList(getNewTagList(this.tagNavList, newRoute));
      // this.$refs.sideMenu.updateOpenName(newRoute.name);
    }
  },
  mounted() {
    /**
     * @description 初始化设置面包屑导航和标签导航
     */
    this.setTagNavList();
    this.setHomeRoute(routers);
    this.addTag({
      route: this.$store.state.app.homeRoute
    });
    this.setBreadCrumb(this.$route);
    // 设置初始语言
    this.setLocal(this.$i18n.locale);
    // 如果当前打开页面不在标签栏中，跳到homeName页
    // if (!this.tagNavList.find(item => item.name === this.$route.name)) {
    //   this.$router.push({
    //     name: this.$config.homeName
    //   });
    // }
    // 获取未读消息条数
    //this.getUnreadMessageCount();
    this.$Loading.destroy();
    
    this.timer = setInterval(this.get, 10000);
    
  },
  beforeDestroy() {
      clearInterval(this.timer);
  }
};
</script>
