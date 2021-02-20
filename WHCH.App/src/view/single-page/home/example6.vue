<style scoped  lang="less">

.znch{
   
    position: relative;
    background-color: #f0f0f0;
    width: 100%;
    display: block;
    overflow: hidden;
    position: relative;
    .tip12{
      
      min-width: 120px;
      padding: 8px;
      height: auto;
      position: absolute;
      background-color: #000;
      color: #fff;
      opacity: 0.7;
      left: 0px;
      top: 0px;
      z-index: 888;
      white-space:pre-line;
      display: none;
    }
    .svg{
      height: auto;
      background-color: #fff;
      float: left;
      width: 100%;
      border: 1px solid #ddd;
      position: relative;
      overflow: hidden;
      .tab{
        position:absolute;
        left: 0px;
        top:10px;
        width: 100%;
        height: calc(100%-1.5px);
        .dcall{
          width: 100%;
          height: calc(100%-5.5px);
          border: 1px solid #4169E1;
          margin-top: -10px;
          .main{
            width: 25%;
            height: 100%;
            border-right: 1px solid #4169E1;
            float: left;
            
            .h{
              width: 100%;
              height: 8%;
              color:#222;
              font-size: 20px;
              text-align: center;
              .b{
                border-radius: 10px;
                width: 50%;
                height: 80%;
                line-height: 230%;
                margin:5px auto;
                border: 1px solid #ddd;
                background-color: #4169E1;
                color:#fff;
              }
            }
            .lp{
              width: 100%;
              height: 11%;
              font-size: 20px;
              text-align: center;
              border: 1px solid #ddd;
              .lplable{
                height: 80%;
                width: 25%;
                float: left;
                text-align: center;
                margin:12px auto;
                font-size: 18px;
              }
              .lpitem{
                .hao{
                  border: 1px solid #880000;
                  border-radius: 50%;
                  font-size: 16px;
                  width: 20px;
                  height: 20px;
                  line-height: 20px;
                  color:#880000;
                  display:inline-block;
                }
                .hao2{
                  border: 1px solid #fff;
                  font-size: 18px;
                  width: 20px;
                  height: 20px;
                  line-height: 20px;
                  color:#111;
                  display:inline-block;
                }
                width: 24%;
                height: 39%;
                line-height: 130%;
                margin:5px auto;
                margin-left: 7%;
              
                color:#191970;
                float: left;
              }
            }
            .item{
              width: 100%;
              height: 20%;
              .t1{
                width: 100%;
                height: 35%;
                color:#222;
                font-size: 16px;
                text-align: center;
                position: relative;
                .line{
                  width: 100%;
                  height: 50%;
                  border-bottom:1px solid  #4169E1;
                }
                .cl{
                  border: 1px solid #4169E1;
                  background-color: #87CEFA;
                  color:#f00;
                  float: left;
                  border-radius: 50% ;
                }
              }
              .t2{
                width: 100%;
                height: 35%;
                color:#222;
                font-size: 13px;
                text-align: center;
                .wd{
                  border: 1px solid #4169E1;
                  background-color: #87CEFA;
                  color:#fff;
                  float: left;
                  border-radius: 5px ;
                  color:#111;
                }
              }
              .t3{
                width: 100%;
                height: 30%;
                color:#222;
                font-size: 18px;
                text-align: center;
                .b{
                  border-radius: 10px;
                  width: 50%;
                  height: 80%;
                  line-height: 180%;
                  margin:5px auto;
                  border: 1px solid #191970;
                  background-color: #87CEFA;
                  color:#191970;
                }
              }
            }
          }
        }
      
      }
      .logo{
        position:absolute;
        top: 10px;
        z-index: 999;

        
        width: 160px;
        text-align: center;
        height: 30px;
        color:#fff;
        .time{
          margin-left:10px;font-size:13px;
        }
        .drop{
          height:30px;line-height:30px;font-size:15px;
        }
        .ivu-dropdown-rel{
          a,a:hover{
            color:#fff ;
          }
        }
        
        img{
          height: 100%;
          vertical-align:middle;
        }
      }
      .allp{
        width: 100%;
        height: 100%;
        position:absolute;
        top: 0px;
        left: 0px;
      }
      .liumian{
        position:absolute;
        top: 20px;
        left: 1px;
        width: 205px;
        height: auto;
        z-index: 999;
      }

      .areacolor{
        position:absolute;
        top: 230px;
        left: 80px;
        width: 100px;
        height: 219px;
        z-index: 999;
        .s{
          position:absolute;
          top: 0px;
          left: 0px;
          width: 39px;
          height: 160px;
          background: -webkit-linear-gradient(#fff, green ); /* Safari 5.1 - 6.0 */
          background: -o-linear-gradient(#fff, green); /* Opera 11.1 - 12.0 */
          background: -moz-linear-gradient(#fff, green); /* Firefox 3.6 - 15 */
          background: linear-gradient( #fff, green ); /* 标准的语法（必须放在最后） */
        }
        .x{
          position:absolute;
          top: 160px;
          left: 0px;
          width: 39px;
          height: 58px;
          background: -webkit-linear-gradient(#f00, rgb(66, 1, 1) ); /* Safari 5.1 - 6.0 */
          background: -o-linear-gradient(#f00, rgb(66, 1, 1)); /* Opera 11.1 - 12.0 */
          background: -moz-linear-gradient(#f00, rgb(66, 1, 1)); /* Firefox 3.6 - 15 */
          background: linear-gradient( #f00, rgb(66, 1, 1) ); /* 标准的语法（必须放在最后） */
        }
        .t1{
          color: #fff;
          font-size: 15px;
          position:absolute;
          top: -10px;
          left: 50px;
          width: 60px;
          height: 20px;
        }
        .t2{
          color: #fff;
          font-size: 15px;
          position:absolute;
          top: 150px;
          left: 50px;
          width: 60px;
          height: 20px;
        }
        .t3{
          color: #fff;
          font-size: 15px;
          position:absolute;
          top: 210px;
          left: 50px;
          width: 60px;
          height: 20px;
        }
        .wrl{
          color: #fff;
          font-size: 16px;
          position:absolute;
          top: 39px;
          left: -28px;
          width: 20px;
          height: 20px;
        }
      }
      .viewway2{
        position:absolute;
        left:203px;
        top: 6px;
        width: 280px;
        height: 30px;
        line-height: 30px;
        font-size: 16px;
        color:#fff;
        z-index: 899;
        .l{
          float: left;
          width: 138px;
          height: 30px;
          line-height: 30px;
        }
        .r{
          float: left;
          width: 138px;
          height: 30px;
          line-height: 30px;
          margin-top:-2px;
        }
      }
      .viewway{
        position:absolute;
        top: 6px;
        width: 80px;
        height: 30px;
        background-color: #fff;
        z-index: 899;
        border: 1px solid #ddd;
        .t1{
          width: 50%;
          float: left;
          height: 30px;
          line-height: 30px;
          font-size: 16px;
          text-align: center;
          cursor: pointer;
        }
        .t2{
          width: 50%;
          float: left;
          height: 30px;
          line-height: 30px;
          font-size: 16px;
          text-align: center;
          cursor: pointer;
        }
        .c{
          background-color: dodgerblue;
          color:#fff;
          height: 28px;
        }
      }
      .loading{
        position:absolute;
        top:0px;
        left: 0px;
        width: 100%;
        height: 100%;
        z-index: 1800;
        background-color: #000000;
        opacity: 0.7;
        img{
          width: 130px;
          margin: 300px auto;;
        }
      }
      .queue{
        position:absolute;
        top:50px;
        right: 0px;
        width: 250px;
        height: 420px;
        z-index: 1000;
        background:transparent;
        opacity: 0.9;
        .btn{
          width: 32px;
          height: 106px;
          position:absolute;
          left: 2px;
          z-index: 999;
          top:158px;
          cursor: pointer;
          border-top-left-radius: 10px;
          border-bottom-left-radius: 10px;
          border-top: 2px solid #666;
          border-bottom: 2px solid #666;
          border-left: 2px solid #666;
          .wenzi{
            position:absolute;
            left: 9px;
            width: 18px;
            top:25px;
            height: 70px;
            color:#000;
            font-size: 15px;
            font-family: '微软雅黑';
            line-height: 18px;
            font-weight: bold;
          }
        }
        .q{
          position:absolute;
          top:0px;
          right: 0px;
          width:218px;
          height: 420px;
          background-color: #fff;
          border-top-left-radius: 10px;
          border-bottom-left-radius: 10px;
          border-top: 2px solid #666;
          border-bottom: 2px solid #666;
          border-left: 2px solid #666;
          color:#000;
          font-size: 13px;
          font-family: '微软雅黑';
          line-height: 18px;
          .h{
            margin: 0px auto;
            width: 80%;
            height: 30px;
            line-height: 30px;
            border-bottom: 1px solid #ddd;
            text-align: center;
          }
          .waith{
            margin: 0px auto;
            width: 100%;
            height: 30px;
            line-height: 30px;
            border-bottom: 1px solid #ddd;
            text-align: center;
            .t1{
              height: 30px;
              line-height: 30px;
              width: 39%;
              text-align: center;
              float: left;
            }
            .t2{
              height: 30px;
              line-height: 30px;
              width: 15%;
              text-align: center;
              float: left;
            }
            .t3{
              height: 30px;
              line-height: 30px;
              width: 46%;
              text-align: center;
              float: left;
            }
          }
          .wait{
            margin: 0px auto;
            width: 100%;
            height: 352px;
            line-height: 30px;
            overflow-y: scroll;
            text-align: center;
            .t1{
              height: 30px;
              line-height: 30px;
              width: 33%;
              text-align: center;
              float: left;
            }
            .t2{
              height: 30px;
              line-height: 30px;
              width: 33%;
              text-align: center;
              float: left;
            }
            .t3{
              height: 30px;
              line-height: 30px;
              width: 34%;
              text-align: center;
              float: left;
            }
          }
          .runh{
            margin: 0px auto;
            width: 100%;
            height: 30px;
            line-height: 30px;
            border-bottom: 1px solid #ddd;
            text-align: center;
            .t1{
              height: 30px;
              line-height: 30px;
              width: 39%;
              text-align: center;
              float: left;
            }
            .t2{
              height: 30px;
              line-height: 30px;
              width: 15%;
              text-align: center;
              float: left;
            }
            .t3{
              height: 30px;
              line-height: 30px;
              width: 46%;
              text-align: center;
              float: left;
            }
          }
          .run{
            margin: 0px auto;
            width: 100%;
            height: 352px;
            line-height: 30px;
            overflow-y: scroll;
            text-align: center;
            
            .t1{
              height: 30px;
              line-height: 30px;
              width: 33%;
              text-align: center;
              float: left;
            }
            .t2{
              height: 30px;
              line-height: 30px;
              width: 33%;
              text-align: center;
              float: left;
            }
            .t3{
              height: 30px;
              line-height: 30px;
              width: 34%;
              text-align: center;
              float: left;
            }
          }
        }
      }


      .queue1{
        position:absolute;
        top:480px;
        right: 0px;
        width: 250px;
        height: 190px;
        z-index: 1000;
        background:transparent;
        opacity: 0.9;
        .btn{
          width: 32px;
          height: 106px;
          position:absolute;
          left: 2px;
          z-index: 999;
          top:43px;
          cursor: pointer;
          border-top-left-radius: 10px;
          border-bottom-left-radius: 10px;
          border-top: 2px solid #666;
          border-bottom: 2px solid #666;
          border-left: 2px solid #666;
          .wenzi{
            position:absolute;
            left: 9px;
            width: 18px;
            top:25px;
            height: 70px;
            color:#000;
            font-size: 15px;
            font-family: '微软雅黑';
            line-height: 18px;
            font-weight: bold;
          }
        }
        .q{
          position:absolute;
          top:0px;
          right: 0px;
          width:218px;
          height: 190px;
          background-color: #fff;
          border-top-left-radius: 10px;
          border-bottom-left-radius: 10px;
          border-top: 2px solid #666;
          border-bottom: 2px solid #666;
          border-left: 2px solid #666;
          color:#000;
          font-size: 13px;
          font-family: '微软雅黑';
          line-height: 18px;
          .h{
            margin: 0px auto;
            width: 80%;
            height: 30px;
            line-height: 30px;
            border-bottom: 1px solid #ddd;
            text-align: center;
          }
          .runh{
            margin: 0px auto;
            width: 100%;
            height: 30px;
            line-height: 30px;
            border-bottom: 1px solid #ddd;
            text-align: center;
            .t1{
              height: 30px;
              line-height: 30px;
              width: 39%;
              text-align: center;
              float: left;
            }
            .t2{
              height: 30px;
              line-height: 30px;
              width: 61%;
              text-align: center;
              float: left;
            }
            .t3{
              height: 30px;
              line-height: 30px;
              width: 46%;
              text-align: center;
              float: left;
            }
          }
          .run{
            margin: 0px auto;
            width: 100%;
            height: 122px;
            line-height: 30px;
            overflow-y: scroll;
            text-align: center;
            
            .t1{
              height: 30px;
              line-height: 30px;
              width: 39%;
              text-align: center;
              float: left;
            }
            .t2{
              height: 30px;
              line-height: 30px;
              width: 61%;
              text-align: center;
              float: left;
            }
            .t3{
              height: 30px;
              line-height: 30px;
              width: 34%;
              text-align: center;
              float: left;
            }
          }
        }
      }
    }


    @keyframes Glow {
        from {
            box-shadow: 0 0 1px #ffffff,
                        0 0 8px #ffffff,
                        0 0 9px #ffffff,
                        0 0 13px #ffffff,
                        0 0 16px #ffffff;
        }
        to {
            box-shadow: 0 0 0px #ffffff,
                        0 0 0px #ffffff,
                        0 0 0px #ffffff,
                        0 0 0px #ffffff,
                        0 0 0px #ffffff;
        }
    }

   .active{
      
      color: #fff;
      background-color: #00a67c;
      font-weight: bold;
    } 
    .end{
      color:#ddd;
    }
    .act{
      -webkit-animation: Glow 2.0s ease infinite alternate;
      animation: Glow 2.0s ease infinite alternate;
      display:inline-block;
      width: 8px;
      height: 8px;
      border-radius: 50%;
      margin-right: 13px;
      background-color:#ffffff;
    }

    @keyframes Glow2 {
        from {
            box-shadow: 0 0 3px #00a67c,
                        0 0 8px #00a67c,
                        0 0 9px #00a67c,
                        0 0 13px #00a67c,
                        0 0 16px #00a67c;
        }
        to {
            box-shadow: 0 0 3px #00a67c,
                        0 0 3px #00a67c,
                        0 0 3px #00a67c,
                        0 0 3px #00a67c,
                        0 0 3px #00a67c;
        }
    }
    .act2d{
      -webkit-animation: Glow2 0.5s ease infinite alternate;
      animation: Glow2 0.5s ease infinite alternate;
      background-color:#00a67c;
    }
}



</style>
<template>
<div class="znch">

  <!-- 回看结束  -->
  <div id="svg" class="svg" :style="{height:h2+'px',width:(w2-10)+'px'}">
    <div  class="loading" id="pload">
      <center>
      <img :src="publicPath+'loading.gif'" />
      </center>
    </div>


    <div class="logo" id="logo"  :style="{left:(w2-10-160)/2+'px'}">
      <Dropdown class="drop" :style="{color:pageview==3?'#fff':'#222'}" @on-click="drophld">
        <a href="javascript:void(0)" :style="{color:pageview==3?'#fff':'#222'}">
            {{boiler}}
            <Icon type="ios-arrow-down"></Icon>
        </a>
        <DropdownMenu slot="list" >
            <DropdownItem v-for="(item,index) in boilers" :selected="item.id==boilerid" :name="item.k_Name_kw"  v-bind:key="'iuyiy'+index">{{item.k_Name_kw}}</DropdownItem>
        </DropdownMenu>
      </Dropdown>
      <!-- <span class="time" :style="{color:pageview==3?'#fff':'#222'}">{{boilertime}}</span> -->
    </div>

    <!--主页面-->
    <div  id="d3" class="allp" ></div>


    <div id="way" class="liumian" ></div>

    <!-- <div id="area" class="areacolor" :style="{display:pageview==3?'':'none'}">
      <div class="s"></div>
      <div class="x"></div>
      <div class="t1">0</div>
      <div class="t2">1</div>
      <div class="t3">1.35</div>
      <div class="wrl">污染率色条</div>
    </div> -->

    
    <!-- 吹灰侧边栏 -->
    <div id="queue" class="queue" >
      <div class="btn" @click="togle">
        <img :src="cebtn" />
        <div class="wenzi">吹灰列表</div>
      </div>
      <div class="q">
        <div class="waith" >
          <div class="t1">序号</div>
          <div class="t2">编号</div>
          <div class="t3">时间</div>
        </div>
        <div class="wait" >
          <div style="width:100%;height:30px;" v-for="(info,iop) in waitlist" v-bind:key="'oop'+iop">
            <div class="t1">{{iop+1}}</div>
            <div class="t2">{{info.dncChqpoint_Name}}</div>
            <div class="t3">{{info.addTime}}</div>
          </div>
          
        </div>
        <Button  :disabled="waitlist.length==0" @click="okchui" type="primary" style="margin:2px 70px">吹灰执行</Button>

      </div>
    </div>

    <!-- 空预器 -->
    <div id="queue1" class="queue1" v-if="loadok==1">
      <div class="btn" @click="togle1">
        <img :src="cebtn1" />
        <div class="wenzi">空预器</div>
      </div>
      <div class="q">
        <div class="runh" >
          <div class="t1">编号</div>
          <div class="t2">时间</div>
        </div>
        <div class="run" >
          <div    style="width:100%;height:30px;" v-for="(info,iop) in kyqlist" v-bind:key="'kyqlist'+iop">
            <div class="t1"><span ></span>{{info.name_kw}}</div>
            <div class="t2">{{info.addTime}}</div>
            <!-- <div class="t2" >{{lll}}</div> -->
          </div>
        </div>
        <Button  :disabled="kyqlist.length==0" @click="okchui2" type="primary" style="margin:2px 70px">吹灰执行</Button>

      </div>
    </div>





  </div>

</div>
</template>

<script>
import store from '@/store'
//工具包
import { getDateMore,sortBy,gradientColor,getDate ,eqarr} from "@/libs/tools";
//机组
import { getBoilerListAll } from "@/api/ZNRS/Dncboiler";
import anime from 'animejs/lib/anime.js';
//echart数据
import {  } from '_c/charts'
import ECharts from "vue-echarts";
// 柱状图
import "echarts/lib/chart/bar";
// 折线
import "echarts/lib/chart/line";
// 饼状图
//import "echarts/lib/chart/pie";
// 提示
import "echarts/lib/component/tooltip";
import "echarts/lib/component/title";
//热力图
import "echarts/lib/chart/heatmap";
import "echarts/lib/component/visualMap";
// 图例

// import "echarts/lib/component/markPoint";
// import "echarts/lib/component/markLine";
// import "echarts/lib/component/graphic";
//标题
import "echarts/lib/component/legend";

//c吹灰队列
import {
  getChlistList,dochui,dochui2
} from "@/api/ZNRS/Dncchlist";

import {
  getParameterList,
} from "@/api/ZNRS/Dncparameter";

import {
  getHzpointList
} from "@/api/ZNRS/Dnchzpoint";
import {
  getChqpointList,
} from "@/api/ZNRS/Dncchqpoint";
import {
  getChareaList
} from "@/api/ZNRS/Dnccharea";
import {
  getChrunlist_kyqList
} from "@/api/ZNRS/Dncchrunlist_kyq";

//右键菜单
import VueContextMenu from 'vue-contextmenu/src/VueContextMenu';
//threejs
import * as THREE from 'three';
// import {MTLLoader, OBJLoader} from 'three-obj-mtl-loader';
import { OrbitControls } from 'three/examples/js/controls/CCC';
import { CSS2DRenderer, CSS2DObject } from 'three/examples/jsm/renderers/CSS2DRenderer';
import { ColladaLoader } from 'three/examples/js/loaders/LLL';

import { STLLoader } from 'three/examples/js/loaders/STLLoader';


// import stats from 'stats-js';
// import dat from 'dat.gui';
import { ibs,ias} from "@/api/chuihui/point";

import chu from "@/assets/images/chu.png";
import ru from "@/assets/images/ru.png";
import pic2d from "@/assets/images/2d.svg";

//ziti
// import EEE from "@/assets/font/iconfont.css";
export default {
  name: "ZNRS_znch_page",
  components: {
    "vue-context-menu" : VueContextMenu,
     "v-chart": ECharts
  },
  data() {
    return {
      loop:true,
      paramobj:{},
      //背火侧温差临界值
      ljz:40,
      ljzcolorstep:[],
      wrldmes:{
        pg_z:[],
        pg_y:[],
        gg_z:[],
        gg_y:[],
        gz_z:[],
        gz_y:[],
        dz_z:[],
        dz_y:[],
        dg_z:[],
        dg_y:[],
        zs_z:[],
        zs_y:[],
        fjs:[]
      },
      colorstep:[],
      huikan:{
        modal2:false,
        title:"",
        timebe:[],
        data:{}
      },
      //吹灰总时长
      chuilong:0,
      //执行列表加入时间
      runtime:'',
      runtimekyq:'',
      waitlist:[],
      runlist:[],
      kyqlist:[],
      chuirun:0,
      lll:'',
      loadok:0,loadok1:0,
      chu,ru,cebtn:ru,pic2d,
      cebtn1:ru,
      time2d:'',
      //3d 2d
      pageview:3,
      //three 
      publicPath: process.env.BASE_URL,
      scene: null,
      camera: null,
      renderer: null,
      labelRenderer:null,
      controls:null,
      st:null,
      rotationSpeed: 0.02,

      scene2: null,
      camera2: null,
      renderer2: null,

      btncolors:['#c23531','#2f4554','#61a0a8'],

      timer2:null,

      //机组
      boilertime:"",
      boilerid:-1,
      boiler:"",
      boilerNowStatus:-1,
      boilerSta_time:"",
      boilers:[],

      h2:0,
      w2:0,

      x:0,
      y:0,
      z:0,

      ir_points:[],
      ik_points:[],
      il_points:[],
      ia_points:[],


      ir_rouletteScene:[],
      ib_rouletteScene:[],
      il_rouletteScene:[],
      ia_rouletteScene:[],

      templist:[],
      pointall:[],
      errlist:[],
      justlistc:[],justlistmes:[],
      jiaoti:1,fx:1,


      queues:[],
      queueshis:[],

      trans:0,
      tamap:{},
      scales:0,

      //lable
      lables:[],


      idandwd:[],
      //2d
      data2d:[
        {h:'左墙',w:[1,2,3,5],item:[
          {y:['IR78','IR77','IR76','IR75','IR74','IR73'],b:90},
          {y:['IR54','IR53','IR52','IR51','IR50','IR49'],b:90},
          {y:['IR30','IR29','IR28','IR27','IR26','IR25'],b:90},
          {y:['IR6','IR5','IR4','IR3','IR2','IR1'],b:90}
        ]},
        {h:'前墙',w:[1,2,3,5],item:[
          {y:['IR96','IR95','IR94','IR93','IR92','IR91'],b:90},
          {y:['IR72','IR71','IR70','IR69','IR68','IR67'],b:90},
          {y:['IR48','IR47','IR46','IR45','IR44','IR43'],b:90},
          {y:['IR24','IR23','IR22','IR21','IR20','IR19'],b:90}
        ]},
        {h:'右墙',w:[1,2,3,5],item:[
          {y:['IR90','IR89','IR88','IR87','IR86','IR85'],b:90},
          {y:['IR66','IR65','IR64','IR63','IR62','IR61'],b:90},
          {y:['IR42','IR41','IR40','IR39','IR38','IR37'],b:90},
          {y:['IR18','IR17','IR16','IR15','IR14','IR13'],b:90}
        ]},
        {h:'后墙',w:[1,2,3,5],item:[
          {y:['IR79','IR80','IR81','IR82','IR83','IR84'],b:90},
          {y:['IR55','IR56','IR57','IR58','IR59','IR60'],b:90},
          {y:['IR31','IR32','IR33','IR34','IR35','IR36'],b:90},
          {y:['IR7','IR8','IR9','IR10','IR11','IR12'],b:90}
        ]}
      ],
      mini2d:0,
      mg1:0,mg2:0,tipmes:"",

      ccdada:[
        {n:'屏式过热器',l:0,r:0,h:0},
        {n:'高温过热器',l:0,r:0,h:0},
        {n:'高温再热器',l:0,r:0,h:0},
        {n:'低温再热器',l:0,r:0,h:0},
        {n:'低温过热器',l:0,r:0,h:0},
        {n:'主省煤器',l:0,r:0,h:0},
        {n:'分级省煤器',l:0,h:0},
        {n:'空气预热器',l:0,h:0}
      ],


    }
  },
  watch:{
    
  },
  computed:{
  },
  methods: {
    drophld(name){
      this.boilers.map(o=>{
        if(o.k_Name_kw==name){
          this.boilerid=o.id;
          this.boiler=o.k_Name_kw;
          this.boilertime=o.syntime;
          // this.loadXYQList(this.boilerid,1);
          this.quenlist(this.boilerid);
          this.initpoint(this.boilerid);
        }
      });
      
    },
    togle(){
      let t=document.querySelectorAll(".queue");
      if(this.cebtn==this.ru){
        this.cebtn=this.chu;
        anime({
            targets: t[0],
            translateX: 218,
            duration: 1000
          });
      }else{
        this.cebtn=this.ru;
        anime({
            targets: t[0],
            translateX: 0,
            duration: 1000
          });
      }
    },
    togle1(){
      let t=document.querySelectorAll(".queue1");
      if(this.cebtn1==this.ru){
        this.cebtn1=this.chu;
        anime({
            targets: t[0],
            translateX: 218,
            duration: 1000
          });
      }else{
        this.cebtn1=this.ru;
        anime({
            targets: t[0],
            translateX: 0,
            duration: 1000
          });
      }
    },
    chooceview(u){
      this.pageview=u;
    },
    initway(){
      let o=this;
      let container = document.getElementById('way');
      o.scene2 = new THREE.Scene();
      // o.camera2 = new THREE.PerspectiveCamera(60, 200 / 200, 0.1, 10);
      // o.camera2.position.set( 0.1, 0.2, 0.5 );
      o.renderer2 = new THREE.WebGLRenderer({
        antialias: true, // true/false表示是否开启反锯齿
        alpha: false, // true/false 表示是否可以设置背景色透明
        precision: 'highp', // highp/mediump/lowp 表示着色精度选择
        premultipliedAlpha: false, // true/false 表示是否可以设置像素深度（用来度量图像的分辨率）
        preserveDrawingBuffer: true, // true/false 表示是否保存绘图缓冲
        maxLights: 3, // 最大灯光数
        stencil: false // false/true 表示是否使用模板字体或图案
      });
      o.renderer2.setSize(200, 200 * o.h2/(o.w2*0.8)  );

      // let controls = new OrbitControls(o.camera2, o.renderer2.domElement);
      // controls.target.set(0, 0, 0);// 设置控制器的焦点，使控制器围绕这个焦点进行旋转
      // controls.update();// 照相机转动时，必须更新该控制器

      container.appendChild(o.renderer2.domElement);

      o.scene2.add(new THREE.AmbientLight(0xffffff));
      var loader = new ColladaLoader();
      loader.load(`${o.publicPath}model/way.dae`, function( collada ){
        //将模型的场景加入到整体的场景
        let rouletteScene = collada.scene;
        rouletteScene.scale.set(0.05,0.05,0.05);
        o.scene2.add(rouletteScene);
      },
      function( xhr) {
        //console.log((xhr.loaded/xhr.total * 100)+"% loaded");
      });

      
    },
    //5mian 刷一次，吹运行中的点位u
    chui(u){
      let o=this;
      o.trans=0;

      if(Object.keys(o.tamap).length==0){
        o.templist.map(x=>{
          if(x.updown==0){
            let q=x.name_kw;
            q=q.toLowerCase();
            if(!o.tamap.hasOwnProperty(q)){
              o.tamap[q]=0;
            }
          }
        });
      }
      
      o.scales=0;
      let t=[];
      u.map(x=>{
        t.push(x.name_kw);
      });
      o.queueshis=o.queues;
      o.queues=t;
      o.chuisingle();
    },
    //场景加风扇
    chuisingle(){
      let o=this;
      let exit=eqarr(o.queueshis,o.queues);
      if(exit){
        return;
      }
      //还原退回map
      o.tamap={};
      //清空扇叶
      o.ir_rouletteScene.map(x=>{
        o.scene.remove(x);
      });
      o.ib_rouletteScene.map(x=>{
        o.scene.remove(x);
      });
      o.il_rouletteScene.map(x=>{
        o.scene.remove(x);
      });
      o.ia_rouletteScene.map(x=>{
        o.scene.remove(x);
      });
      //还原钢管
      // o.ir_points.map(x=>{
      //   x.scale.y=1;
      // });
      // o.ik_points.map(x=>{
      //   x.scale.y=1;
      // });
      // o.il_points.map(x=>{
      //   x.scale.y=1;
      // });
      // o.ia_points.map(x=>{
      //   x.scale.y=1;
      // });
      //加风扇
      for (let index = 0; index < o.queues.length; index++) {
          let element = o.queues[index];
          let key=element.substr(0,2).toLowerCase();
          let i=parseInt(element.substr(2));
          
          if(key=="ir"){
            o.scene.add(o.ir_rouletteScene[i-1]);
          }else if(key=="ik"){
            o.scene.add(o.ib_rouletteScene[i-1]);
          }else if(key=="il"){
            o.scene.add(o.il_rouletteScene[i-1]);
          }else if(key=="ia"){
            o.scene.add(o.ia_rouletteScene[i-1]);
          }
      }
    },

    init() {
      let o=this;
      let container = document.getElementById('d3');

      o.scene = new THREE.Scene();
      o.camera = new THREE.PerspectiveCamera(60, (o.w2-10) / o.h2, 0.1, 10);
      o.camera.position.set( 0.1, 0.2, 0.5 );
      o.camera2 = new THREE.PerspectiveCamera(60, o.w2*0.8 / o.h2, 0.1, 10);
      o.camera2.position.set( 0.1, 0.2, 0.5 );

      var loader = new ColladaLoader();

      loader.load(`${o.publicPath}model/fs.dae`, function( collada ){
        let rouletteScene = collada.scene;
        rouletteScene.scale.set(0.09,0.09,0.09);


        let kk=ibs({x:o.x,z:o.z,y:o.y,col:rouletteScene});
        o.ib_points=kk[0];
        //长吹
        o.ib_points.map(mess=>{
          o.scene.add( mess );
        });
        o.ib_rouletteScene=kk[1];

        let aa=ias({x:o.x,z:o.z,y:o.y,col:rouletteScene});
        o.ia_points=aa[0];
        //长吹
        o.ia_points.map(mess=>{
          o.scene.add( mess );
        });
        o.ia_rouletteScene=aa[1];


        o.chuisingle();

        //loading close
        let loading=document.querySelectorAll("#pload");
        loading[0].style.display="none";
        o.loadok=1;
      },
      function( xhr) {
        //ole.log((xhr.loaded/xhr.total * 100)+"% loaded");
      });


      let t=0;
      let loader2 = new STLLoader();
			loader2.load( `${o.publicPath}model/1.stl`, function ( geometry ) {
          let material = new THREE.MeshPhongMaterial( { color: 0x009ad6, specular: 0x666666, shininess: 200 } );
          material.opacity = 0.8 ;
          material.transparent = true ;
					let mesh = new THREE.Mesh( geometry,material );
					mesh.scale.set(0.1,0.1,0.1);
          mesh.rotation.z = 0;
          mesh.rotation.x = -1.56;
          mesh.rotation.y = 0;
					o.scene.add( mesh );
			});
      loader2.load( `${o.publicPath}model/2.stl`, function ( geometry ) {
          let material = new THREE.MeshPhongMaterial( { color: 0xffffff, specular: 0x111111, shininess: 200 } );
          material.opacity = 0.8 ;
          material.transparent = true ;
					let mesh = new THREE.Mesh( geometry,material );
					mesh.scale.set(0.1,0.1,0.1);
          mesh.rotation.z = 0;
          mesh.rotation.x = -1.56;
          mesh.rotation.y = 0;
					o.scene.add( mesh );
			});
      o.wrldmes={
        pg_z:[],
        pg_y:[],
        gg_z:[],
        gg_y:[],
        gz_z:[],
        gz_y:[],
        dz_z:[],
        dz_y:[],
        dg_z:[],
        dg_y:[],
        zs_z:[],
        zs_y:[],
        fjs:[]
      };


      //面
      let grid = new THREE.GridHelper(1, 20, 0x883333, 0x444444);
      grid.position.set(0, -0.16, 0);
      grid.material.transparent = true;
      o.scene.add(grid);

      


      o.renderer = new THREE.WebGLRenderer({
        antialias: true, // true/false表示是否开启反锯齿
        alpha: false, // true/false 表示是否可以设置背景色透明
        precision: 'highp', // highp/mediump/lowp 表示着色精度选择
        premultipliedAlpha: false, // true/false 表示是否可以设置像素深度（用来度量图像的分辨率）
        preserveDrawingBuffer: true, // true/false 表示是否保存绘图缓冲
        maxLights: 1, // 最大灯光数
        stencil: false // false/true 表示是否使用模板字体或图案
      });
      o.renderer.setSize(o.w2-10, o.h2);


      o.labelRenderer = new CSS2DRenderer();
      o.labelRenderer.setSize(o.w2-10, o.h2);
      o.labelRenderer.domElement.style.position = 'absolute';
      o.labelRenderer.domElement.style.top = '0px';
      container.appendChild(o.labelRenderer.domElement);


      o.controls = new OrbitControls(o.camera,o.labelRenderer.domElement);
      o.controls.target.set(0, 0, 0);// 设置控制器的焦点，使控制器围绕这个焦点进行旋转
      o.controls.update();// 照相机转动时，必须更新该控制器
        
      container.appendChild(o.renderer.domElement);


      let raycaster = new THREE.Raycaster();
      let mouse = new THREE.Vector2();
      o.labelRenderer.domElement.addEventListener("mousemove", (event) => {
        // console.log(1);
          // mouse.x = (event.clientX / o.labelRenderer.domElement.clientWidth) * 2 - 1 - 0.1;
          // mouse.y = -(event.clientY / o.labelRenderer.domElement.clientHeight) * 2 + 1 + 0.1 ;
          
          mouse.x = (event.clientX / o.labelRenderer.domElement.clientWidth) * 2 - 1-0.01;
          mouse.y = -(event.clientY / o.labelRenderer.domElement.clientHeight) * 2  + 1+0.01;
          

          
          raycaster.setFromCamera(mouse, o.camera);
          let objects=o.ib_points.concat(o.ia_points);
          let intersects = raycaster.intersectObjects(objects);
         // console.log(intersects.length);
          
          if (intersects.length > 0) {
              let obj = intersects[0].object;
              o.showlable(obj);
          }else{
              o.clearlable();
          }

      })


      //环境光会均匀的照亮场景中的所有物体。
      // o.scene.add(new THREE.AmbientLight("#ccffcc"));

      var pointLight = new THREE.PointLight("#ccffcc");
      pointLight.position.set(0.3,0.3,0.3);
      pointLight.intensity = 1.2;
      o.scene.add(pointLight);

      var pointLight2 = new THREE.PointLight("#ccffcc");
      pointLight2.position.set(-0.3,-0.3,-0.3);
      pointLight2.intensity = 1.2;
      o.scene.add(pointLight2);
    },
    blow(){
      let o=this;
      //找退回的点
      o.templist.map(x=>{
        if(x.updown==0){
          let q=x.name_kw;
          q=q.toLowerCase();
          let i=parseInt(q.substr(2));
          if(q.indexOf("ir")!=-1){
            o.__blowingir(i);
          }else if(q.indexOf("ik")!=-1){
            o.__blowingik(i);
          }else if(q.indexOf("il")!=-1){
            o.__blowingil(i);
          }else if(q.indexOf("ia")!=-1){
            o.__blowingia(i);
          }
        }
      });



      o.queues.map(q=>{
        q=q.toLowerCase();
        //["ir1","ik2"]
        let i=parseInt(q.substr(2));
        if(q.indexOf("ir")!=-1){
          o.blowingir(i);
        }else if(q.indexOf("ik")!=-1){
          o.blowingik(i);
        }else if(q.indexOf("il")!=-1){
          o.blowingil(i);
        }else if(q.indexOf("ia")!=-1){
          o.blowingia(i);
        }
      });
      
      o.queueshis.map(q=>{
        q=q.toLowerCase();
        //["ir1","ik2"]
        let i=parseInt(q.substr(2));
        if(q.indexOf("ir")!=-1){
          o._blowingir(i);
        }else if(q.indexOf("ik")!=-1){
          o._blowingik(i);
        }else if(q.indexOf("il")!=-1){
          o._blowingil(i);
        }else if(q.indexOf("ia")!=-1){
          o._blowingia(i);
        }
      });
      o.trans += 0.001;
      o.scales += 0.1;


      if(Object.keys(o.tamap).length>0){
        o.templist.map(x=>{
          if(x.updown==0){
            let q=x.name_kw;
            q=q.toLowerCase();
            if(o.tamap.hasOwnProperty(q)){
              o.tamap[q]=o.tamap[q]+0.001;
            }
          }
        });
      }
    },
    animate() {
      let o=this;
      //开始吹啊。。
      if(o.ia_rouletteScene.length>0){
        o.blow();
      }

      if(o.justlistc.length>0){
        o.pointlight();
      }
      


      requestAnimationFrame(o.animate);

      let l = 0.1*0.1 + 0.2*0.2 + 0.5*0.5;
      let m = o.camera.position.x*o.camera.position.x + o.camera.position.y*o.camera.position.y + o.camera.position.z*o.camera.position.z;

      let jg=[];
      jg=o.clsxyz(l,o.camera.position.x,o.camera.position.y,o.camera.position.z);
      if(jg.length>0){
        o.camera2.position.x=jg[0];
        o.camera2.position.y=jg[1];
        o.camera2.position.z=jg[2];
      }else{
        o.camera2.position.x=o.camera.position.x;
        o.camera2.position.y=o.camera.position.y;
        o.camera2.position.z=o.camera.position.z;
      }

      o.camera2.lookAt(o.scene2.position);
      o.renderer.render(o.scene, o.camera);
      o.renderer2.render(o.scene2, o.camera2);
      o.labelRenderer.render(o.scene, o.camera);
    },

    clsxyz(l,x,y,z){
      let jindu=0.010000;
      let arr=[];
      let x1=0,y1=0,z1=0;
      x1=x;y1=y;z1=z;
      let jli=0.036;
      for (let j = 0; j < 10; j++) {
        //变远
        for (let index = 1; index <= 50; index++) {
          x1=x1*(1+jindu*index);
          y1=y1*(1+jindu*index);
          z1=z1*(1+jindu*index);
          let m = x1*x1 +y1*y1 + z1*z1;
          if(Math.abs(l-m)<jli){
            arr.push(x1);
            arr.push(y1);
            arr.push(z1);
            break;
          }
        }
        if(arr.length==0){
          //变近
          x1=x;y1=y;z1=z;
          for (let index = 1; index <= 50; index++) {
            x1=x1*(1-jindu*index);
            y1=y1*(1-jindu*index);
            z1=z1*(1-jindu*index);
            let m = x1*x1 +y1*y1 + z1*z1;
            if(Math.abs(l-m)<jli){
              arr.push(x1);
              arr.push(y1);
              arr.push(z1);
              break;
            }
          }
        }
        
        if(arr.length==0){
          jli+=0.003;//允许距离加大再算算
          continue;
        }else{
          break;
        }
      }

      
      
      return arr;
    },
    

    //右侧队列
    quenlist(bid){
      let o=this;
      getChlistList({
            totalCount: 0,
            pageSize: 200,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid:bid,
            sort: [
              {
                direct: "ASC",
                field: "id"
              }
            ]
          }).then(res => {
        o.waitlist = getDateMore(res.data.data,5,["addTime"]);

      });



      // k空预器
      getChrunlist_kyqList({
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid:bid,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            o.kyqlist=getDateMore(res.data.data,5,["addTime","runTime","offTime",]);
            if(o.kyqlist.length>0){
              o.runtimekyq=o.kyqlist[0].addTime;
            }else{
              o.runtimekyq='';
            }
            
        // this.stores.Chrunlist_kyq.data = getDateMore(res.data.data,1,["addTime","runTime","offTime",]);
        // this.stores.Chrunlist_kyq.query.totalCount = res.data.totalCount;
      });
    },
    //刷点 5miao
    initpoint(bid){
      let o=this;
      if(o.boilerid!=-1){
        getParameterList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: 0,
              status: 1,
              boilerid:o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
          if(res.data.data.length==0){
            o.$Message.warning('该机组不存在或已停用！');
          }else{
            let t=getDateMore(res.data.data,1,[])[0];
            // o.paramobj=res.data.data[0];
            // o.loop=(t.loop==1);
            // console.log(o.loop);
          }
        });
      }
      getChqpointList({
            totalCount: 0,
            pageSize: 200,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid:bid,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
        o.pointall = getDateMore(res.data.data,1,["lastchtime","realtime",]);
        o.pointall=o.pointall.map(x=>{
          let y=x;
          y.now_temp_qp_Val=Math.round(x.now_temp_qp_Val*10)/10;
          y.now_temp_bh_Val=Math.round(x.now_temp_bh_Val*10)/10;

          let ttt="";
          ttt=x.name_kw+" "+x.remarks+"<br/>"+x.dncChstatus_Name;
          if(x.dncChtypeId==1){
            ttt+="<br>当前鳍片温度:"+  x.now_temp_qp_Val.toFixed(1)+"<br>当前背火侧温度:"+x.now_temp_bh_Val;
          }
          if(x.dncChstatusId==2){
            ttt+="<br>当前动作:"+ (x.updown==0?"后退":"前进");
          }

          y["ttt"]=ttt;
          return y;
        });

        o.idandwd=[];
		if(o.pointall.length==0){
          let y2d=document.querySelectorAll(".wd");
          for (let index = 0; index < y2d.length; index++) {
              let element = y2d[index];
              // console.log("----------"+x.now_temp_qp_Val.toFixed(1));
              element.innerHTML="";
          }
          //背火侧温度
          for (let i = 0; i < 4; i++) {
              o.data2d[0].item[3-i].b="";
              o.data2d[1].item[3-i].b="";
              o.data2d[2].item[3-i].b="";
              o.data2d[3].item[3-i].b="";
          }
          o.data2d[0].w=[];
          o.data2d[1].w=[];
          o.data2d[2].w=[];
          o.data2d[3].w=[];
        }
        o.pointall.map(x=>{
          let ttt="";
          ttt=x.ttt;
          // ttt=x.name_kw+" "+x.remarks+"<br/>"+x.dncChstatus_Name;
          // if(x.dncChtypeId==1){
          //   ttt+="<br>当前鳍片温度:"+  x.now_temp_qp_Val.toFixed(1)+"<br>当前背火侧温度:"+x.now_temp_bh_Val;
          // }
          // if(x.dncChstatusId==2){
          //   ttt+="<br>当前动作:"+ (x.updown==0?"后退":"前进");
          // }

          let n=x.name_kw;
          n=n.toLowerCase();
          let tpe=n.substr(0,2);
          let index=n.substr(2);


        });


        o.templist.map(u=>{
          let dian=u.name_kw;
          let y2d=document.querySelectorAll("."+dian);
          for (let index = 0; index < y2d.length; index++) {
            let element = y2d[index];
            let t=element.className;
            element.className=t.replace("act2d","");
          }
        });

        o.templist=o.pointall.filter(x=>x.dncChstatusId==2);
        o.errlist=o.pointall.filter(x=>x.dncChstatusId==3);

        o.chui(o.templist);
        o.pointcolor(o.errlist,0xffff00,'#ffff00');
        o.pointcolor(o.templist,0x00FF00,'#00FF00');
        


        o.templist.map(u=>{
          let dian=u.name_kw;
          let y2d=document.querySelectorAll("."+dian);
          for (let index = 0; index < y2d.length; index++) {
            let element = y2d[index];
            element.className +=" act2d";
          }
        });
      });

      //2d 燃烧区域漆片温度
      getHzpointList({
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid:bid,
            typeid:85,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
        if(res.data.data.length>0){
          let ty=eval("("+res.data.data[0].pvalue+")") ;
          o.data2d[0].w=[];
          o.data2d[1].w=[];
          o.data2d[2].w=[];
          o.data2d[3].w=[];
          for (let index = 0; index < ty.length; index++) {
            if(index<4){
              o.data2d[0].w.push(ty[index]);
            }else if(index<8){
              o.data2d[1].w.push(ty[index]);
            }else if(index<12){
              o.data2d[2].w.push(ty[index]);
            }else if(index<16){
              o.data2d[3].w.push(ty[index]);
            }

          }
        }
        
      });

      //2d 长吹
    //  getChareaList({
    //         totalCount: 0,
    //         pageSize: 20,
    //         currentPage: 1,
    //         kw: "",
    //         isDeleted: 0,
    //         status: -1,
    //         boilerid:bid,
    //         sort: [
    //           {
    //             direct: "DESC",
    //             field: "id"
    //           }
    //         ]
    //       }).then(res => {
    //     let t = getDateMore(res.data.data,2,["realTime",]);;
    //     if(t.length>0){
    //       o.time2d=t[0].realTime;
    //     }
    //     o.ccdada=o.ccdada.map(x=>{
    //       let l=0;
    //       let r=0;
    //       let h=0;
    //       for (let index = 0; index < t.length; index++) {
    //         let y = t[index];
    //         let arrn=y.k_Name_kw.split('（');
    //         let now=y.wrl_Val;
    //         let high=y.wrlhigh_Val;
            
    //         if(arrn[0]==x.n){
    //           if(arrn.length>1){
    //             if(arrn[1].indexOf("左")!=-1){
    //               l=now;
    //             }else{
    //               r=now;
    //             }
    //           }else{
    //             l=now;
    //           }
    //           h=high;
    //         }
    //       }
    //       return {
    //         n:x.n,
    //         l:l,
    //         r:r,
    //         h:h
    //       }
    //     });

    //     if(o.ccdada.length==8){
    //       o.lll=o.ccdada[7].l;
    //     }
        
    //    // console.log(JSON.stringify(o.ccdada));
    //   });
    },
    //点涂色
    pointcolor(u,color,color2d){
      let o=this;
      //2d 涂色
      u.map(u=>{
        let dian=u.name_kw;
    //    console.log(dian+"_"+color2d);
        let y2d=document.querySelectorAll("."+dian);
        for (let index = 0; index < y2d.length; index++) {
          let element = y2d[index];
          element.style.backgroundColor=color2d;
        }
      });
      

      //3d 涂色
      let path = "/";
      let urls = [
        path + "2.png", path + "2.png",
        path + "2.png", path + "2.png",
        path + "2.png", path + "2.png"
      ];

      let textureCube = new THREE.CubeTextureLoader().load(urls);
      textureCube.encoding = THREE.sRGBEncoding;
      let m=new THREE.MeshPhysicalMaterial({
          color:color,
          metalness: 1.0,
          roughness: 0.1,
          envMap: textureCube
      });

      u.map(u=>{
        let n=u.name_kw;
        n=n.toLowerCase();
        let tpe=n.substr(0,2);
        let index=n.substr(2);
        if(tpe=="ir"){
          o.ir_points[index-1].material=m;
        }else if(tpe=="ik"){
          o.ik_points[index-1].material=m;
        }else if(tpe=="il"){
          o.il_points[index-1].material=m;
        }else if(tpe=="ia"){
          o.ia_points[index-1].material=m;
        }
      });
      
    },

    //点发光
    pointlight(){
      let o=this;
      // console.log(o.justlistmes.length);
      o.justlistmes.map(u=>{
          o.donghua(u);
      });
      
    },

    donghua(mes){
      let o=this;
      if(o.jiaoti>=3){
        o.fx=0;
      }
      if(o.jiaoti<=1){
        o.fx=1;
      }
      if(o.fx==1){
        o.jiaoti+=0.05;
      }else{
        o.jiaoti-=0.1;
      }
      // let mes=mesh.clone();
      let gg=0;
      if(o.jiaoti>=2.6){
        gg=3;
      }else{
        gg=o.jiaoti;
      }
      let meshmaterial=new THREE.MeshBasicMaterial( {color: 0xFFFFFF,opacity:1-(0.1*gg*3),transparent:true});
      mes.material=meshmaterial;

      mes.scale.x = o.jiaoti;
      mes.scale.y = o.jiaoti;
      mes.scale.z = o.jiaoti;
      // mes.scale.set(o.jiaoti,o.jiaoti,o.jiaoti);
    },
    //机组加载
    initboiler(){
      let o=this;
      getBoilerListAll().then(res => {
          o.boilers=getDateMore(res.data.data,-1,["syntime",]);
          if(o.boilerid==-1){
            o.boiler=o.boilers[0].k_Name_kw;
            o.boilerid=o.boilers[0].id;
            o.boilertime=o.boilers[0].syntime;
          }else{
            o.boilers.map(x=>{
              if(x.id==o.boilerid){
                o.boilertime=x.syntime;
              }
            });
            
          }
          //初始化吹灰列表
          //o.quenlist(o.boilerid);
        });
    },
    //标签
    clearlable(){
      let o=this;
      o.lables.map(x=>{
        let n=x.k;
          n=n.toLowerCase();
          let tpe=n.substr(0,2);
          let index=n.substr(2);
          if(o.ib_points[index*2-2]){
            o.ib_points[index*2-2].remove(x.v);
          }
          if(o.ia_points[index*2-2]){
            o.ia_points[index*2-2].remove(x.v);
          }
      });
      o.lables=[];
    },
    showlable(nm){
      // console.log(nm.name);
      let o=this;
      o.clearlable();
        let earthDiv = document.createElement( 'div' );
        earthDiv.id=nm.name;
        earthDiv.className = 'labeles6';
        earthDiv.innerHTML = nm.name.toUpperCase() ;
        // if(nm.name.toLowerCase().substr(0,2)=="ir"){
        //   earthDiv.style.marginTop = '-4.5em';
        // }else{
        //   earthDiv.style.marginTop = '-2.8em';
        // }   ib_points
        earthDiv.style.marginTop = '-1.8em';


        let earthLabel = new CSS2DObject( earthDiv );
        earthLabel.position.set( 0, 0, 0 );

        let index=nm.name.substr(2);


        if(nm.name.toLowerCase().substr(0,2)=="ib"){
          o.ib_points[index*2-2].add( earthLabel );
        }else{
          o.ia_points[index*2-2].add( earthLabel );
        }
        
        // let n=nm.name;
        // n=n.toLowerCase();
        // let tpe=n.substr(0,2);
        // let index=n.substr(2);
        // if(tpe=="ir"){
        //   o.ir_points[index-1].add( earthLabel );
        // }else if(tpe=="ik"){
        //   o.ik_points[index-1].add( earthLabel );
        // }else if(tpe=="il"){
        //   o.il_points[index-1].add( earthLabel );
        // }else if(tpe=="ia"){
        //   o.ia_points[index-1].add( earthLabel );
        // }
        o.lables.push({k:nm.name,v:earthLabel});
    },
    
    hanldlermove(e){
      let k177=document.querySelectorAll(".tip12");
      k177[0].style.top=e.clientY-35 +"px";
      k177[0].style.left=e.clientX-75+"px";
    },
    okchui(){
      let o=this;
      dochui({
            code:o.boilerid
          }).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          
        } else {
          this.$Message.warning(res.data.message);
        }
      });
    },

    okchui2(){
      let o=this;
      dochui2({
            code:o.boilerid
          }).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          
        } else {
          this.$Message.warning(res.data.message);
        }
      });
    }
  },
  mounted() {
    let o = this;

    o.colorstep=gradientColor('#ffffff','#00dd00',10);
    o.colorstep=o.colorstep.concat(gradientColor('#FF0000','#730303',3));

    o.ljzcolorstep=['#008000'].concat(gradientColor('#FF0000','#000000',o.ljz));
    // console.log(JSON.stringify(o.colorstep));

    o.h2=window.screen.height-90;
    o.w2=window.screen.width-90;

    o.mini2d=(o.w2-10)/4/6-(o.w2-10)/4/18;
    o.mg1=(o.w2-10)/4/22;
    o.mg2=-(o.w2-10)/4/6/3;
    //初始化3d
    o.init();
    //初始化左上角
    o.initway();
    //动画
    o.animate();
    //初始化机组
    o.initboiler();
    //初始化吹灰列表
    // o.quenlist(o.boilerid);


    o.timer2=setInterval(() => {

      if(o.boilerid==-1){
        return;
      }
      o.quenlist(o.boilerid);
      o.initpoint(o.boilerid);
    }, 5000);



    
    
    // if (document.hidden !== undefined) {
      // document.addEventListener('visibilitychange', () => {
      //   o.$router.go(0);
      // })
    // }
  },
  beforeDestroy() {
    clearInterval(this.timer2);
  }
};
</script>
<!--  加上私有化属性scoped后 threejs找不到，所以不能加 -->
<style>

.znch .labeles6 {
  color: #FFF;
  font-family: sans-serif;
  font-size: 16px;
  border: 1px solid #fff;
  padding-left: 3px;
  padding-right: 3px;
  padding-top: 3px;
  padding-bottom: 3px;

  background: rgba(21, 29, 9, 0.6);
}
.znch .ivu-tabs .ivu-tabs-content-animated {
  height: 100% !important;
}
</style>
