<style  lang="less">
@size : 120px;
.home{
  .kz{
    position: fixed;
    width: 50%;
    height: 380px;
    right: 50px;
    top: 120px;
    .item{
      margin-left: 30px;
      margin-top: 20px;
      width:@size*5/3;
      height: @size+30;
      float: left;
      .h{
        width: @size*5/3;
        height: @size;
        img{
          margin: 0px auto;
          max-width: 100%;
          max-height: 100%;
        }
        background-color: #fff;
        border-radius: 10px;
        overflow: hidden;
        display:flex;
        border: 2px solid #fff;
      }
      .z{
        width: @size*5/3;
        height: 30px;
        line-height: 30px;
        color:#fff;
        text-align: center;
        font-size: 18px;
      }
    }
    .item:hover{
      cursor: pointer;
      transform:scale(1.2);
      -webkit-transform:scale(1.2);  /*兼容-webkit-引擎浏览器*/
      -moz-transform:scale(1.2);     /*兼容-moz-引擎浏览器*/
    }
  }
}
</style>
<template  >
  <div class="home"  :style="{backgroundImage: 'url(' + homebg + ')',width:'100%',height:'100%',margin:'0px',padding:'0px',backgroundSize:'100% 100%' }">
  <div class="kz">
    <div class="item" v-for="(item, index) in zooms" :key="`homeiytem1_${index}`" @click="gogo(item)">
      <div class="h">
      <img :src="item.icon" />
      </div>
      <div class="z">
      {{item.title}}
      </div>
    </div>
  </div>
  
  </div>
</template>

<script>
import InforCard from '_c/info-card'
import CountTo from '_c/count-to'
import { ChartPie, ChartBar } from '_c/charts'
import homebg from "@/assets/images/home-bg.png";
import znrs from "@/assets/images/snap/znrs.jpg";
import swpz from "@/assets/images/snap/swpz.jpg";
import scr from "@/assets/images/snap/scr.jpg";
import gwfs from "@/assets/images/snap/gwfs.jpg";
import ch from "@/assets/images/snap/ch.png";
import kyq from "@/assets/images/snap/kyq.png";
import kfz from "@/assets/images/1.png";
export default {
  name: 'home',
  components: {
    InforCard,
    CountTo,
    ChartPie,
    ChartBar
  },
  data () {
    return {
      homebg,znrs,swpz,scr,gwfs,kfz,kyq,

      zooms: [
        //{ title: '智能燃烧', icon: znrs,url:'/znrs'},
        //{ title: '三维膨胀', icon: swpz,url:'/zxswpz' },
        //{ title: '智能SCR', icon: scr ,url:'/znscrjb'},
       // { title: '高温腐蚀监测', icon: gwfs,url:'/gwfs' },
        { title: '智能吹灰', icon: ch,url:'/znch' }
       // { title: '智能空预器', icon: kyq ,url:'/znkyq'}
      ]
    }
  },
  methods:{
    gogo(item){
       this.$router.push(item.url);
    }
  },
  mounted () {
    //
  }
}
</script>

<style lang="less">
.count-style{
  font-size: 50px;
}
</style>
