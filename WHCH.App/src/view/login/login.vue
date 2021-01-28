<style lang="less">
@import "./login.less";

</style>

<template>
  <div>
    <div class="bg bg-blur"></div>
    <div class="content content-front">
      <div class="login">
        <div class="login-con">
          <Card  :bordered="false">
            <div slot="title" style="width:100%;height:20px">
                <div style="width:20px;height:20px;float:left"><img  :src="maxLogo" style="width:20px;height:20px" /></div>
                <div style="width:50%;height:20px;line-height:20px;float:left;color:#222;font-weight: bold;margin-left:6px">国华锦界锅炉智能运行系统</div>
            </div>
            <div class="form-con">
              <login-form
                @on-success-valid="handleSubmit"
                :processing="processing"
                :loading="loading"
              ></login-form>
            </div>
          </Card>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import maxLogo from "@/assets/images/logo.jpg";
import LoginForm from "_c/login-form";
import { Encrypt, Decrypt } from '@/libs/aes';
import { mapActions } from "vuex";
import axios from "@/libs/api.request";
import store from "@/store";
import { initRouter } from "@/libs/router-util";

export default {
  components: {
    LoginForm
  },
  data() {
    return {
      processing: false,
      loading: false,
      maxLogo
    };
  },
  methods: {
    ...mapActions(["handleLogin", "getUserInfo"]),
    //// 将 `this.handleLogin()` 映射为 `this.$store.dispatch('handleLogin')` 
    handleSubmit({ userName, password }) {
      var target = this;
      this.loading = true;
      password=Encrypt(password);
      this.handleLogin({ userName, password })
        .then(res => {
          if (res.data.code == 200) {
            this.processing = true;
            this.$Message.loading({
              duration: 0,
              closable: false,
              content: "用户信息验证成功,正在登录系统..."
            });
            this.getUserInfo().then(res => {
              setTimeout(() => {
                initRouter(target);
                this.$router.push({
                  name: "home"
                });

                setTimeout(() => {
                  this.$Message.destroy();
                }, 1000);
              }, 1500);
            });
          } else {
            this.processing = false;
            this.loading = false;
            this.$Message.error(res.data.message);
          }
        })
        .catch(error => {
          target.loading = false;
          if (!error.status) {
            this.$Message.error({
              content: "网络出错,请检查你的网络或者服务是否可用",
              duration: 5
            });
          }
        });
    }
  }
};
</script>

<style>
.demo-spin-icon-load {
  animation: ani-demo-spin 1s linear infinite;
}
.content {
  color: #ffffff;
  font-size: 40px;
}

.bg {
  background: url("../../assets/images/login-bg.png");
  height: 100%;
  text-align: center;
  line-height: 100%;
  position:fixed;
  background-size:100% 100%;
  background-repeat:no-repeat;
}
.bg-blur {
  float: left;
  width: 100%;
  background-repeat: no-repeat;
  background-position: center;

}
.content-front {
  position: absolute;
  left: 10px;
  right: 10px;
  height: 100%;
  line-height: 100%;
}
</style>
