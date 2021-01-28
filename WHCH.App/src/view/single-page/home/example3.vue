<style scoped  lang="less">
@bcolor : #16FDF5;
@size : 90px;
@move : -100px;
@minheight:600px;
@x:6;
@y:3;
@x_a:-20deg;
@y_a:-10deg;
@z_a:-3.5deg;

.scr{
    
    background-color: #f0f0f0;
    padding:10px;
    width: 99%;
    display: block;
    overflow: hidden;
    position: relative;
    .logo{
      position:absolute;
      top: 10px;
      z-index: 999;
      width: 60%;
      text-align: center;
      height: 30px;
      color:#fff;
      .ivu-dropdown-rel{
        a,a:hover{
          color:#fff !important;
        }
      }
      
      img{
        height: 100%;
        vertical-align:middle;
      }
    }
    .logo2{
      width: 30%;
      margin-top: 0px;
      margin-left: 35%;
      text-align: center;
      display: block;
      height: 60px;
      color:#fff;
      overflow: hidden;
      .hd{
        display: block;
        width: 100%;
        height: 25px;
        line-height: 25px;
        color:#ffff00;
      }
      .bar{
        
        width: 100%;
        height: 30px;
        .t1{
          float: left;
          display: block;
          width: 10%;
          height: 30px;
          line-height: 30px;
        }
        .t{
          position: relative;
          width: 80%;
          background-color:#111;
          .line{
            position:absolute;
            z-index: 10;
            // left: 0px;
            top: 0px;
            width: 0px;
            height: 30px;
            display: none;
            .t{
              color:#ffff00;
              margin: -28px auto;
              margin-left: -19px;
              width: 39px;
            }
          }
          .item{
            width: 1%;
            height: 30px;
            float: left;
            display: block;
          }
        }
      }
    }
    .power1{
            position:absolute;
            
            left: 0px;
            top: 0px;
            width: 50px;
            height: 90px;
            opacity: 0;
            .zi{
              font-size:18px;
              color:#fff; 
              height:30px;
              line-height:30px;
              width:50px;
              text-align: center;
              position:absolute;
              left: 0px;
              top:96px;
            }
            .i{
              transform:rotateX(180deg);
              width: 100%;
              height: 84px;
              margin: 0px auto;
              border-radius: 5px;
              border: 3px solid #fff;
              padding-bottom: 3.9px;
              background-color: #fff;
              .item{
                height: 20%;
                background-color: #3ADF00;
                width: 89%;
                margin: 0px auto;
                border-radius: 3px;
                .b{
                  width: 100%;
                  height: 28%;
                  float: left;
                  background-color: #FFF;
                }
              }
              .bc1{
                background-color: #FE9A2E;
              }
              .bc2{
                background-color: #DF0101;
              }
            }
          }

    .l{
      border-radius: 10px;
      width: 60%;
      min-height: 580px;
      display:block;
      float: left;
      background-color:#3e3e3e;
      background-repeat:no-repeat;
      background-size:100% 100%;
      -moz-background-size:100% 100%;
      .sput{
        margin:( @minheight/2 - 30 ) auto;
        padding-left: 20px;
        width: @size*@x+30px;
        height: auto;
      }
      .sput2{
        margin: 0px auto;
        width: @size*@x;
        height: auto;
      }

      .container {
          width: @size;
          height: @size;
          float: left;
          position: relative;
          transform-style: preserve-3d;
          transform:rotateX(@x_a) rotateY(@y_a) rotateZ(@z_a) ;
          // animation: rotate 10s linear infinite;
          transition: all 0.1s ease-out;
          overflow:visible;
          .wrap {
              opacity:0.8;
              width: @size;
              height: @size;
              border: 1px solid #333;
              box-sizing: border-box;
              top: 0;
              border-radius: 9px;
              background-color: @bcolor;
              transition: all 1s ease-out;
              font-size:30px;
              text-align: center;
              line-height: 90px;
              position: absolute;
          }
          .samev{
            position:absolute;
            left: 0px;
            top: 0px;
            width: 60px;
            height: 90px;
            line-height: 25px;
            color:#000;
            font-size: 13px;
            opacity: 0;
          }
          .power{
            position:absolute;
            right: 0px;
            top: 5px;
            transform:rotateX(180deg);
            width: 30px;
            height: 80px;
            .i{
              width: 100%;
              height: 76px;
              margin: 0px auto;
              border-radius: 5px;
              border: 3px solid #222;
              padding-bottom: 5px;
              background-color: #fff;
              .item{
                height: 20%;
                background-color: #3ADF00;
                width: 89%;
                margin: 0px auto;
                border-radius: 3px;
                .b{
                  width: 100%;
                  height: 28%;
                  float: left;
                  background-color: #FFF;
                }
              }
              .bc1{
                background-color: #FE9A2E;
              }
              .bc2{
                background-color: #DF0101;
              }
            }
          }


          
          img{
            position:absolute;
            left: 0px;
            top:0px;
            opacity: 0;
            width: 100%;
            height: 100%;
          }

          .ms{
            font-size:18px;
           // color:#fff; 
            opacity: 0;
            transform:rotateX(-7.6deg) rotateY(30deg) rotateZ(3.6deg);
            height: 130px;
            line-height: 30px;
            width: 170px;
            position: absolute;
            left: 120px;
            //left: -230px;
            top: -26px;
            background-size: 100% 100%;


            .msi{
              color: #fff;
              width: 170px;
              font-size: 18px;
              border:5px solid #D26900;
              border-radius: 8px;

              box-shadow: -10px 0px 10px rgba(0,0,0,0.9) ;
              background-color: #005500;
              padding: 8px;
              float: right;
              height: 110px;
              text-align: left;
            }
          }

          .wrap-front {
              transform: translateZ(@size/2);
          }
          .wrap-back {
              transform: translateZ(-@size/2) rotateY(180deg);
          }
          .wrap-left {
              transform: translateX(-@size/2) rotateY(-90deg);
          }
          .wrap-right {
              transform: translateX(@size/2) rotateY(90deg);
          }
          .wrap-top {
              transform: translateY(-@size/2) rotateX(90deg);
          }
          .wrap-bottom {
              transform: translateY(@size/2) rotateX(-90deg);
          }
      }
    }

    .r{
      border-radius: 10px;
      width: 38%;
      min-height: @minheight;
      display:block;
      float: left;
      margin-left: 2%;
      .item{
        height: 598px;
        width: 100%;
        position: relative;
        .onoff{
          position:absolute;
          width: 160px;
          height: 25px;
          line-height: 25px;
          top:3px;
          right: 0px;z-index: 899;
        }
      }
      .huikan{
        position:absolute;
        top: 3px;
        right: 6px;
        width: 50px;
        text-align: center;
        border: 1px solid #999;
        font-size: 12px;
        color: #666;
        background-color: #eef;
        cursor: pointer;
        border-radius: 5px;
        padding: 1px;
        
      }
      
      .ontime{
        width: 100%;
        height: 566px;
        background-color: #fff;
        margin-top: -16px;
        .itemr{
          // border: 1px solid #ddd;
          width: 100%;
          height: 283px;
          position: relative;
        }
        .item{
          border-bottom: 1px solid #ddd;
          width: 80%;
          height: 50px;
          line-height: 50px;
          margin: 0px auto;
          font-size: 14px;
          color: #222;
          .iteml{
            width: 50%;
            height: 50px;
            line-height: 50px;
            float: left;
          }
          .itemr{
            width: 50%;
            height: 50px;
            line-height: 50px;
            float: left;
            
            
            .ggg{
              margin-left: 8%;
            }
            .cl{
              background-color: #eeffee;
            }
            .chu{
              background-color: #ffeeee;
            }
          }

          .ip1{
              height: 30px;
              line-height: 30px;
              width: 15%;
              float: left;
              margin-top: 10px;
              text-align: left;
            }
            .ipt{
              float: left;
              height: 30px;
              line-height: 30px;
              width: 20%;
              border: 1px solid #ddd;
              border-radius: 3px;
              // box-shadow: inset 0px 0px 3px 1px #000 ;
              box-shadow:-2px 3px 3px rgba(0,0,0,0.9) ; 
              text-align: center;
              margin-top: 10px;
            }
        }
      }
      
    }

}
  
</style>
<template>
<div class="scr" >

  <!-- 回看开始  -->
  <Modal v-model="huikan.modal2" width="1100" class-name="vertical-center-modal" :mask-closable="false">
        <p slot="header" >
          {{huikan.title}}
          <Button type="warning" @click="hqkdate(2)" style="width: 80px;position:absolute;right:470px;top:8px">前天</Button>
          <Button type="success" @click="hqkdate(1)" style="width: 80px;position:absolute;right:380px;top:8px">昨天</Button>
          <DatePicker type="datetimerange" v-model="huikan.timebe"  @on-change="haldleBackData" format="yyyy-MM-dd HH:mm" placeholder="选择时间段" style="width: 320px;position:absolute;right:50px;top:8px"></DatePicker>
        </p>
        <div style="text-align:center">
            <v-chart :options="huikan.data" autoresize  style="width:100%"></v-chart>
        </div>
        <div slot="footer">
            
        </div>
  </Modal>
  <!-- 回看结束  -->


  <!-- <span style="color:#fff;font-size:18px;position: absolute;">{{tpx}}:{{tpy}}</span> -->
  <div id="power" class="power1" :style="styles2">
    <div style="width: 50%;margin:0px auto;height: 6px;background-color: #fff;"></div>
    <div class="i" style="">
      <div :class="'item bc'+it" v-for="(it, i) in itemRightdc" style="border-radius: 0px;">
        <div class="b"></div>
      </div>
    </div>    
    <div class="zi">{{txnow}}%</div>     
  </div>

  

  <div class="l" @mousemove="mousemove">
    <div class="logo">
      <Dropdown style="height:30px;line-height:30px;font-size:15px;color:#fff" @on-click="drophld">
        <a href="javascript:void(0)" style="color:#000;">
            {{boiler}}
            <Icon type="ios-arrow-down"></Icon>
        </a>
        <DropdownMenu slot="list" >
            <DropdownItem v-for="(item,index) in boilers" :selected="item.id==boilerid" :name="item.k_Name_kw">{{item.k_Name_kw}}</DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </div>
    <div class="sput" :style="styles">
      <div :id="'t'+itemRight.id" class="container" :style="container(itemRight)" v-for="(itemRight, index) in sx" >
        <div :class="'wrap wrap-front w' +itemRight.id"  :style="{backgroundColor:''+ itemRight.boxcolor +''}" @click="clickitem(itemRight.id)" >
          {{itemRight.id}}
          <div class="ms"  :id="'title'+itemRight.id" style="display:none">
            <div class="msi">氨逃逸:{{blank.aty}}ppm<br>脱销效率:{{blank.txxl}}%<br>催化剂寿命:{{blank.chjsm}}</div>
          </div>
        </div>
        <div :class="'wrap wrap-back w' +itemRight.id" :style="{backgroundColor:''+ itemRight.boxcolor +''}"></div>
        <div :class="'wrap wrap-left w' +itemRight.id" :style="{backgroundColor:''+ itemRight.boxcolor +''}"></div>
        <div :class="'wrap wrap-right w' +itemRight.id" :style="{backgroundColor:''+ itemRight.boxcolor +''}" ></div>
        <div :class="'wrap wrap-top w' +itemRight.id+' topw'+itemRight.id" :style="{backgroundColor:''+ itemRight.boxcolor +''}">
          {{itemRight.id}}<!--@click.stop="showpower(itemRight)"-->
          <div v-if="itemRight.dc.length>0" :id="'pw'+itemRight.id" class="power" :style="{backgroundImage: 'url(' + dc + ')' }"  @click="showpower(itemRight)">
            <div class="i">
              <div :class="'item bc'+it" v-for="(it, i) in itemRight.dc">
                <div class="b"></div>
              </div>
            </div>
          </div>

          <div :class="'samev sv'+itemRight.id" @click="clickitem(itemRight.id)" >{{itemRight.nh3out}}</div>
        </div>
        <div :class="'wrap wrap-bottom w' +itemRight.id" :style="{backgroundColor:''+ itemRight.boxcolor +''}"></div>
        <img :src="clogo" :id="'img'+itemRight.id" style="display:none"/>
        <img :src="gif" :id="'gif'+itemRight.id" style="display:none"/>
        <img :src="qi" :id="'qi'+itemRight.id" style="display:none"/>
        
      </div>
    </div>
    <div style="clear:both"></div>
    <div class="logo2">
      <div class="hd"></div>
      <div class="bar">
        <div class="t1">0</div>
        <div class="t1 t"   >
          <div class="line"  ><div class="t">≈ {{sameval}}</div></div>
          <div  :title="it" :class="'item www' + i " v-for="(it, i) in colorstep" :style="{backgroundColor:''+ it +''}"   @mouseover.stop="mouseover(it,i)" @mouseout.stop="mouseout(it,i)" ></div>
        </div>
        <div class="t1">10</div>
      </div>
    </div>
  </div>
  <div class="r">
    <div class="item">
      <div class="onoff">
        <span style="margin-left:30px;font-size:13px;">巡测同步</span>
        <i-switch size="large" style="margin-left:3px;"  @on-change="change" v-model="run">
          <span slot="open">开启</span>
          <span slot="close">关闭</span>
        </i-switch>
      </div>
      
      <Tabs name="name1-1"  type="card"  size="small"  @on-click="hldtab"  v-model="tabs">
        <TabPane label="实时" tab="name1-1"  name="tabs1">
            <!--文字-->
            <div class="ontime">
              <div class="item">
                <div class="iteml">测点位置:</div><div class="itemr">{{nowitem.k_Name_kw}}</div>
              </div>
              <div class="item">
                <div class="iteml">测量时间:</div><div class="itemr">{{nowitem.realTime}}</div>
              </div>
              <div class="item">
                <div class="iteml">入口测点:</div>
                <div class="itemr">
                  <div class="ip1 ">O<sub>2</sub></div><div class="ipt cl">{{nowitem.o2_in}}</div>
                  <div class="ip1 ggg ">NO<sub>x</sub></div><div class="ipt cl">{{nowitem.nox_in}}</div>
                </div>
              </div>
              <div class="item">
                <div class="iteml">出口测点:</div>
                <div class="itemr">
                  <div class="ip1">O<sub>2</sub></div><div class="ipt chu">{{nowitem.o2_out}}</div>
                  <div class="ip1 ggg">NO<sub>x</sub></div><div class="ipt chu">{{nowitem.nox_out}}</div>
                </div>
              </div>
              <div class="item">
                <div class="iteml">氨逃逸(ppm):</div><div class="itemr">{{nowitem.nh3out}}</div>
              </div>
              <div class="item">
                <div class="iteml">脱硝效率(%):</div><div class="itemr">{{nowitem.scr_ratio}}%</div>
              </div>
              
              <div class="item" >
                <div class="iteml">催化剂寿命:</div><div class="itemr">{{nowitem.catalysts_life}}</div>
              </div>

              <div class="item" style="height:100px">
                <div class="iteml" style="font-weight: bold;font-size:15px;height:30px">调整建议:</div>
                <div class="ipt" style="font-family: '楷体';font-size:18px;width:100%;height:50px;line-height:50px; padding-left:5px;padding-right:8px;margin:9px auto;text-align: center;background-color: #eeeeff;">{{nowitem.advice==''?"无":nowitem.advice}}</div>
              </div>


              <div class="item"  v-if="nowitem.advice!=''">
                <div class="iteml">调整人:</div><div class="itemr">{{nowitem.checkPerson}}</div>
              </div>

              <div class="item" style="border-bottom:0px" v-if="nowitem.advice!=''">
                <div class="iteml">调整时间:</div><div class="itemr ">
                  {{nowitem.checkTime}}
                  <Button v-if="nowitem.checkTime!=''" type="success" size="small" style="float:right;margin-top:11px">已调整</Button>
                  <Button v-if="nowitem.checkTime==''" type="error" size="small" style="float:right;margin-top:11px" @click="handleqr6()">请调整</Button>
                </div>
              </div>



            </div>         
        </TabPane>
        <TabPane   label="曲线图" tab="name1-1" name="tabs2" :disabled="distab1">
            <div class="ontime">
              <div class="itemr" style="border-top:0px">
                <v-chart :options="option1" autoresize  style="width:100%;height:100%"></v-chart>
                <span class="huikan" @click="haldleBack(nowitem.nameId_Val+'号格进出口NOx和脱销效率对比')"><icon type="md-skip-backward"/> 回看</span>
              </div>
              <div class="itemr" style="border-top:0px">
                <v-chart :options="option2" autoresize  style="width:100%;height:100%"></v-chart>
                <span class="huikan" @click="haldleBack(nowitem.nameId_Val+'号格氨逃逸脱硝效率对比图')"><icon type="md-skip-backward"/> 回看</span>
              </div>
            </div>          
        </TabPane>
      </Tabs>
    </div>


  </div>
  <div style="clear:both"></div>

  
</div>   
</template>

<script>
import store from '@/store'
//工具包
import { getDateMore,sortBy,gradientColor } from "@/libs/tools";
//全局配置
import { global } from "@/api/echart/config";
//机组
import { getBoilerListAll } from "@/api/ZNRS/Dncboiler";
import { getScrpointList,Debugbug } from "@/api/ZNRS/Dncscrpoint";
import { getScrpointdataList } from "@/api/ZNRS/Dncscrpointdata";
import anime from 'animejs/lib/anime.js';
import qi from "@/assets/images/qi1.png";
import clogo from "@/assets/images/qi.png";
import gif from "@/assets/images/10.gif";
import dc from "@/assets/images/dc.png";
import ms from "@/assets/images/ms.png";

//图形依赖包
import ECharts from "vue-echarts";
// 柱状图
import "echarts/lib/chart/bar";
// 折线
import "echarts/lib/chart/line";
// 提示
import "echarts/lib/component/tooltip";
import "echarts/lib/component/toolbox";
import "echarts/lib/component/title";
import "echarts/lib/component/dataZoom";
//热力图
import "echarts/lib/chart/heatmap";
import "echarts/lib/component/visualMap";
//标题
import "echarts/lib/component/legend";

//echart数据
// import echarts from 'echarts';









//数据
import { option1,option2,option1_back,option2_back } from "@/api/echart/scr";



export default {
  name: "ZNRS_scr_page",
  components: {
    "v-chart": ECharts
  },
  data() {
    return {
      //回看
      huikan:{
        modal2:false,
        title:"",
        timebe:[],
        data:{}
      },

      //tab
      tabs:"tabs1",
      
      distab1: true,

      option1,option2,option1_back,option2_back,

      run:true,
      timer2:null,
      //{blank.aty}}<br>脱销效率:{{blank.txxl}}<br>催化剂寿命:{{blank.chjsm}}</div
      blank:{
        aty:0,
        txxl:0,
        chjsm:0
      },
      colorstep:[],
      clogo,gif,qi,dc,ms,
      itemRightdc:[2,1,1,1,1],
      xjindex:0,
      tpx:0,tpy:0,
      movex:0,movey:0,moverun:true,left:0,top:0,txnow:0,
      nowstate:-1,
      sx:[],
      sy:3,
      //机组
      boilertime:"",
      boilerid:-1,
      boiler:"",
      boilers:[],

      screenWidth: document.documentElement.clientWidth,//屏幕宽度
      initwidth:0,
      bili:1,

      //same相似
      sameval:0,
      inbar:false,
      sames:[],

      //右边
      nowitem:{},
      itemall:[]
    }
  },
  watch:{
    'screenWidth':function(val){ //监听屏幕宽度变化
      this.bili=val/this.initwidth;
    }
  },
  computed: {
    styles () {
      return {
        transform:`scale(${this.bili})`,
        width: ((100*6-100/3)- (3 * (1-this.bili))) +"px"
      }
    },
    styles2 () {
      return {
        left:`${this.left}px`,
        top:`${this.top}px`
      }
    },
  },

  methods: {

    hldtab(){
      let o=this;
      if(o.tabs=="tabs2"){
        //  :disabled=nowitem.nameId_Val
        if(!o.nowitem.nameId_Val||o.nowitem.nameId_Val==-1){
          this.$Message.warning('请先选择测点');

          //o.$refs.tab2.style.display="false";
          //o.distab=false;
          return;
        }else{
          //o.$refs.tab2.style.display="true";
          //o.distab=true;
        }


        getScrpointdataList({
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            boilerid: o.boilerid,
            DncScrpointId : o.nowitem.nameId_Val,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,5,["realTime","checkTime"]).reverse(); 
            o.option1.title.text= o.nowitem.nameId_Val+'号格进出口NOx和脱销效率对比';
            o.option2.title.text= o.nowitem.nameId_Val+'号格氨逃逸脱硝效率对比图';

            let times=d.map(x=>{
              return x.realTime;
            })
            o.option1.xAxis[0].data=times;
            o.option2.xAxis.data=times;
            //进口NOx
            o.option1.series[0].data=d.map(x=>{
              return x.nox_in;
            });
            //出口NOx
            o.option1.series[1].data=d.map(x=>{
              return x.nox_out;
            });
            //脱硝效率
            o.option1.series[2].data=d.map(x=>{
              return x.scr_ratio;
            });

            //氨逃逸
            o.option2.series[0].data=d.map(x=>{
              return x.nh3out;
            });
            //脱硝效率
            o.option2.series[1].data=d.map(x=>{
              return x.scr_ratio;
            });
          }
        );
      }
    },
    handleqr6(){
      let o=this;
      //this.$store.state.user.userName
      if(o.nowitem.checkTime&&o.nowitem.checkTime!=""&&o.nowitem.checkTime!="null"){
        // console.log(11);
      }else{
        
        Debugbug({id:o.nowitem.id,CheckPerson:this.$store.state.user.userName}).then(res => {
          // console.log(JSON.stringify(res.data));
          if(res.data.code==500){
            this.$Modal.error({
              title: '提示',
              content: res.data.message
              ,onOk: () => {
                o.loadSCRList(o.boilerid,1);
              }
            })
          }else if(res.data.code==200){
            o.nowitem.checkTime=res.data.message.replace("T","");
            o.nowitem.checkPerson=this.$store.state.user.userName;
          }
        
       });
      }
      
    },
    change (status) {
      if(status){
        this.$Message.info('巡测同步已打开');

        let o=this;
        let a={};

        o.itemall.map(x=>{
          if(x.nameId_Val==o.nowstate){
            a=x;
          }
        })

        if(!a.checkTime||a.checkTime=="null"){
          a.checkTime="";
        }
        o.nowitem=a;
      }else{
        this.$Message.warning('巡测同步已关闭');
      }        
    },
    drophld(name){
      this.boilers.map(o=>{
        if(o.k_Name_kw==name){
          this.boilerid=o.id;
          this.boiler=o.k_Name_kw;
          this.boilertime=o.syntime;
          console.log(this.boilertime);
          this.loadSCRList(this.boilerid,1);
        }
      });
      
    },
    container(item){
      if(item.y_axis_Val==3){
        return "transform:rotateX(-20deg) rotateY(-10deg) rotateZ(-3.5deg) translateY(-120px) translateX(-30px) ;";
      }else if(item.y_axis_Val==2){
        return "transform:rotateX(-20deg) rotateY(-10deg) rotateZ(-3.5deg) translateY(-60px) translateX(-15px) ;";
      }else{
        return "";
      }
    },
    mousemove: function (site) {
      if(store.state.iscoll=="1"){
          this.movex=site.x-293;
          this.movey=site.y-58;
      }else{
          this.movex=site.x-101;
          this.movey=site.y-58;
      }
      if(this.moverun){
        this.left=this.movex;
        this.top=this.movey;
      }
      
      if(this.inbar){
        let w=document.querySelectorAll('.l')[0].offsetWidth;
        if(store.state.iscoll=="1"){
            this.tpx=site.x-293 - w*35/100 -6;
        }else{
            this.tpx=site.x-101 - w*35/100 -6;
        }
        let r=document.querySelectorAll('.line');
        r[0].style.left=this.tpx+"px";
      }
      
      
    },

    mouseover: function (site,i) {
      this.inbar=true;
      let s=document.querySelectorAll('.www'+i)[0];
      s.style.backgroundColor="#fff";
      this.sameval=i/10;
      //标准尺
      let r=document.querySelectorAll('.line');
      r[0].style.display="block";

      //盖子动画
      this.sx.map(x=>{
        if(Math.abs(x.nh3out-this.sameval)<=0.5){
          let t=document.querySelectorAll(".topw"+x.id);
          let sv=document.querySelectorAll(".sv"+x.id);
          //console.log(t.length);
          //translateY(-65px) rotateX(90deg)
          anime({
            targets: t[0],
            translateX: 0,
            translateY: -85,
            rotateX:-3,
            rotateZ:0,
            duration: 10,
            easing: 'linear'
          });
          anime({
            targets: sv[0],
            opacity: [
              { value: 1, duration: 0 }
            ],
            duration: 10,
            easing: 'linear'
          });
        }
      });
    },
    mouseout: function (site,i) {
      this.inbar=false;
      let s=document.querySelectorAll('.www'+i)[0];
      s.style.backgroundColor=s.title;
      //标准尺
      let r=document.querySelectorAll('.line');
      r[0].style.display="none";

      //盖子动画
      this.sx.map(x=>{
        // if(Math.abs(x.nh3out-this.sameval)<=0.5){
          let t=document.querySelectorAll(".topw"+x.id);
          let sv=document.querySelectorAll(".sv"+x.id);
          anime({
            targets: t[0],
            translateX: 0,
            translateY: -45,
            rotateX:90,
            rotateZ:0,
            duration: 2,
            easing: 'linear'
          });
          anime({
            targets: sv[0],
            opacity: [
              { value: 0, duration: 0 }
            ],
            duration: 10,
            easing: 'linear'
          });
        // }
      });
    },


    loadSCRList(bid,t) {
      let o=this;//16FDF5

      o.colorstep=gradientColor('#00aa00','#77ff77',15);
      o.colorstep=o.colorstep.concat(gradientColor('#FFFFb0','#FFA500',15));
      o.colorstep=o.colorstep.concat(gradientColor('#FF0000','#4D0000',70));

      let op1 = new Promise(function(resolve, reject){
        getBoilerListAll().then(res => {
          o.boilers=getDateMore(res.data.data,-1,["syntime",]);
          if(bid==null){
            o.boiler=o.boilers[0].k_Name_kw;
            o.boilerid=o.boilers[0].id;
            o.boilertime=o.boilers[0].syntime;
            
            resolve(o.boilerid);
          }else{
            o.boilers.map(x=>{
              if(x.id==bid){
                o.boilertime=x.syntime;
                resolve(bid);
              }
            });
            
          }
        });
      });

      op1.then(function(data){ 
        if (data) {
          getScrpointList({
            totalCount: 100,
            pageSize: 100,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid: data,
            sort: [
              {
                direct: "ASC",
                field: "Id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,-2,["realTime","checkTime"]); 
            o.sx=d.map(x=>{
              let tx=[0,0,0,0,0];
              if(x.scr_ratio<20){
                tx=[2];
              }else if(x.scr_ratio>=20&&x.scr_ratio<40){
                tx=[1,1];
              }else if(x.scr_ratio>=40&&x.scr_ratio<60){
                tx=[1,1,1];
              }else if(x.scr_ratio>=60&&x.scr_ratio<80){
                tx=[0,0,0,0];
              }
              if(x.nowStatus==1){
                o.nowstate=x.nameId_Val;
              }
              let aty= Math.floor( x.nh3out*10);
              return {
                x_axis_Val : x.x_axis_Val,
                y_axis_Val : x.y_axis_Val,
                id : x.nameId_Val,
                dc:tx,
                scr_ratio:x.scr_ratio,
                nh3out:x.nh3out,
                boxcolor: o.colorstep[aty-1]
              }
            });

          });
        }
      });

    },

    dateFormat(fmt, date) {
        let ret;
        const opt = {
            "y+": date.getFullYear().toString(),        // 年
            "M+": (date.getMonth() + 1).toString(),     // 月
            "d+": date.getDate().toString(),            // 日
            "H+": date.getHours().toString(),           // 时
            "m+": date.getMinutes().toString(),         // 分
            "s+": date.getSeconds().toString()          // 秒
            // 有其他格式化字符需求可以继续添加，必须转化成字符串
        };
        for (let k in opt) {
            ret = new RegExp("(" + k + ")").exec(fmt);
            if (ret) {
                fmt = fmt.replace(ret[1], (ret[1].length == 1) ? (opt[k]) : (opt[k].padStart(ret[1].length, "0")))
            };
        };
        return fmt;
    },
    hqkdate(t){
      let d1=new Date();
      d1=d1.setDate(d1.getDate()-1);
      let d2=new Date();
      d2=d2.setDate(d2.getDate()-2);
      if(t==1){
        this.backview(this.huikan.title,this.dateFormat("yyyy-MM-dd 00:00",new Date(d1)),this.dateFormat("yyyy-MM-dd 23:59",new Date(d1)));
      }else if(t==2){
        this.backview(this.huikan.title,this.dateFormat("yyyy-MM-dd 00:00",new Date(d2)),this.dateFormat("yyyy-MM-dd 23:59",new Date(d2)));
      }
    },
    haldleBackData(date){
      let d1=date[0];
      let d2=date[1];
      this.backview(this.huikan.title,d1,d2);
    },
    haldleBack(title){
      let dateTime=new Date();
      dateTime=dateTime.setDate(dateTime.getDate()-1);
      this.backview(title,this.dateFormat("yyyy-MM-dd HH:mm",new Date(dateTime)),this.dateFormat("yyyy-MM-dd HH:mm",new Date()));
    },
    //回看函数
    backview(title,d1,d2){
      let o=this;
      let huikandata={};

      getScrpointdataList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            boilerid: o.boilerid,
            DncScrpointId : o.nowitem.nameId_Val,
            d1:d1,
            d2:d2,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,5,["realTime","checkTime"]).reverse(); 
            let times=d.map(x=>{
              return x.realTime;
            });
            let t="";
            if(title==o.nowitem.nameId_Val+'号格进出口NOx和脱销效率对比'){
              huikandata=o.option1_back;
              t=o.nowitem.nameId_Val+'号格进出口NOx和脱销效率对比';
              huikandata.xAxis[0].data=times;
              //进口NOx
              huikandata.series[0].data=d.map(x=>{
                return x.nox_in;
              });
              //出口NOx
              huikandata.series[1].data=d.map(x=>{
                return x.nox_out;
              });
              //脱硝效率
              huikandata.series[2].data=d.map(x=>{
                return x.scr_ratio;
              });
            }else if(title==o.nowitem.nameId_Val+'号格氨逃逸脱硝效率对比图'){
              huikandata=o.option2_back;
              t=o.nowitem.nameId_Val+'号格氨逃逸脱硝效率对比图';
              huikandata.xAxis.data=times;
              //氨逃逸
              huikandata.series[0].data=d.map(x=>{
                return x.nh3out;
              });
              //脱硝效率
              huikandata.series[1].data=d.map(x=>{
                return x.scr_ratio;
              });
            }

            

            o.huikan={
              title:t,
              modal2:true,
              data:huikandata,
              timebe:[d1,d2]
            };

            
          }
      );

      
    },




    clickitem(id){
      let o=this;
      let a={};

      o.itemall.map(x=>{
        if(x.nameId_Val==id){
          a=x;
          if(!a.checkTime||a.checkTime=="null"){
            a.checkTime="";
          }
          o.nowitem=a;

          o.run=false;
          if(!o.nowitem.nameId_Val||o.nowitem.nameId_Val==-1){
            //o.$refs.tab2.style.display="true";
            o.distab1=true;
            
          }else{
            o.distab1=false;
          }
        }
      })

      


    },
    aa(a){
      let o=this;
      let tx=[0,0,0,0,0];
      if(a.scr_ratio<20){
        tx=[2];
      }else if(a.scr_ratio >= 20 && a.scr_ratio < 40){
        tx=[1,1];
      }else if(a.scr_ratio >= 40 && a.scr_ratio < 60){
        tx=[1,1,1];
      }else if(a.scr_ratio >= 60 && a.scr_ratio < 80){
        tx=[0,0,0,0];
      }
      if(a.nowStatus==1){
        o.nowstate = a.nameId_Val;
      }
      //右边
      if(o.run){
        o.nowitem=a;
      }

      // 
      //氨逃逸比例
      let aty=1.8 * a.nh3out;//0-10
      //各层升起和回落幅度
      let py=0,back=0;
      if(a.y_axis_Val==1){
        py=-210;
      }else if(a.y_axis_Val==2){
        py=-280;back=-60;
      }else if(a.y_axis_Val==3){
        py=-340;back=-120;
      }

      //黑板
      o.blank={
        aty:a.nh3out,
        txxl:a.scr_ratio,
        chjsm:a.catalysts_life
      };

      //电池先影藏
      o.sx=o.sx.map(x=>{
        if(x.id==a.nameId_Val){
          x.dc=[];
          return x;
        }else{
          return x;
        }
      });

      

      //各元素
      let r=document.querySelectorAll('#t'+a.id);
      let img=document.querySelectorAll('#img'+a.id);
      let gif=document.querySelectorAll('#gif'+a.id);
      let qi=document.querySelectorAll('#qi'+a.id);
      let title=document.querySelectorAll('#title'+a.id);



      // 方块升起动画
      anime({
        targets: r[0],
        translateY: py,
        rotateX: '-20deg',
        rotateY: '-10deg',
        rotateZ: '-3.5deg',
        //backgroundColor: '#FFF',
        duration: 300,
        easing: 'linear',
        complete: function(anim) {
          console.log(a.id+"箭头动画");
        }
      });


      // 箭头动画
      gif[0].style.display="block";
      anime({
            targets: gif[0],
            opacity: [
              { value: 0, duration: 0 },
              { value: 1, duration: 3000 }
            ],
            rotate: '95',
            delay: 1300,
            translateX:-70,
            duration: 1,
            easing: 'linear',
            complete: function(anim) {
              console.log(a.id+"说话");
              let zi=a.nameId_Val+"号格，氨逃逸"+o.nowitem.nh3out+"ppm，"+(o.nowitem.nh3out >=3?"已超标":"正常")+",脱销效率"+o.nowitem.scr_ratio+"%";
              if(o.nowitem.nh3out==0){
                zi=a.nameId_Val+"号格，未检测到氨逃逸 ,脱销效率"+o.nowitem.scr_ratio+"%";
              }
              
              
              if(o.nowitem.advice!=""&&o.nowitem.advice!=null){
                zi+=" ,调整建议："+o.nowitem.advice;
              }
              if((o.nowitem.advice!=""&&o.nowitem.advice!=null)|| o.nowitem.nh3out >=3){
                var utterThis = new window.SpeechSynthesisUtterance(zi);
                window.speechSynthesis.speak(utterThis);
              }
              qi[0].style.display="block";
            }
          });


      console.log(a.id+"反应气动画");
      // 反应气动画
      
      anime({
                  targets: qi[0],
                  opacity: [
                    { value: 1, duration: 0 },
                    { value: 1, duration: 10000 },
                    { value: 0, duration: 0 },
                  ],
                  delay: 4300,
                  rotate: '1000turn',
                  duration: 10000,
                  complete: function(anim) {
                    qi[0].style.display="none";
                    console.log(a.id+"放屁动画");
                    //放屁动画
                    img[0].style.display="block";
                    anime({
                      targets: img[0],
                      opacity: [
                        { value: 1, duration: 0 }
                      ],
                      translateY: [{
                        value: aty,
                        duration: 0,
                      },{
                        value: 100+aty,
                        duration: 300,
                      }],
                      scale: [{
                        value: 1*(aty/10),
                        duration: 0
                      }],
                      delay: 1000,
                      duration: 10000,
                      easing: 'linear',
                      complete: function(anim) {
                         console.log(a.id+"电池出来");
                        //电池出来
                        o.sx=o.sx.map(x=>{
                          if(x.id==a.nameId_Val){
                            x.dc=tx;
                            return x;
                          }else{
                            return x;
                          }
                        });
                        console.log(a.id+"颜色");
                        //各面变颜色
                        let index=o.colorstep[Math.floor( a.nh3out*10)-1];
                        if(a.nh3out==0){
                          index='#16FDF5';
                        }
                        anime({
                          targets: ".w"+a.id,
                          backgroundColor: [
                            { value: index, duration: 1300 }
                          ],
                          duration: 1300,
                          easing: 'linear',
                          complete: function(anim) {
                            
                          }
                        });
                        console.log(a.id+"概况面板动画");
                        //概况面板动画
                        title[0].style.display="block";
                        anime({
                          targets: title[0],
                          opacity: [
                            { value: 0, duration: 0 },
                            { value: 1, duration: 1300 },
                            { value: 1, duration: 5000 },
                          ],
                          rotateX:[{
                            value: -7.3 ,
                            duration: 0,
                          }],
                          rotateY:[{
                            value: 30 ,
                            duration: 0,
                          }],
                          rotateZ:[{
                            value: 3.7 ,
                            duration: 0,
                          }],
                          //后排最后两个展示在左边
                          translateX: [{
                            value: (a.id==5||a.id==6||a.id==11||a.id==12||a.id==17||a.id==18)? -330:0 ,
                            duration: 0,
                          }],
                          duration: 6300,
                          easing: 'linear',
                          complete: function(anim) {
                            console.log(a.id+"关闭开始");
                            
                            //关闭开始
                            anime({
                              targets: title[0],
                              opacity: [
                                { value: 0, duration: 300 }
                              ],
                              translateX: [{
                                value: (a.id==5||a.id==6||a.id==11||a.id==12||a.id==17||a.id==18)? -330:0 ,
                                duration: 0,
                              }],
                              duration: 300,
                              easing: 'linear',
                              complete: function(anim) {
                                  title[0].style.display="none";
                              }
                            });

                            anime({
                              targets: gif[0],
                              opacity: [
                                { value: 0, duration: 300 }
                              ],
                              duration: 300,
                              easing: 'linear',
                              complete: function(anim) {
                                gif[0].style.display="none";
                              }
                            });
                            
                            anime({
                              targets: img[0],
                              opacity: [
                                { value: 0, duration: 330 }
                              ],
                              translateY: [{
                                value: aty,
                                duration: 330,
                              }],
                              scale: [{
                                value: 1*(aty/10),
                                duration: 330
                              }],
                              duration: 300,
                              easing: 'linear',
                              complete: function(anim) {
                                // console.log(a.id+"下去");
                                img[0].style.display="none";
                                anime({
                                  targets: r[0],
                                  translateY: back,
                                  rotateX: '-20deg',
                                  rotateY: '-10deg',
                                  rotateZ: '-3.5deg',
                                  duration: 300,
                                  easing: 'linear'
                                });


                                //巡测数据同步更新 开始
                                o.sx=o.sx.map(x=>{

                                  if(x.id==a.nameId_Val){
                                    let tx=[0,0,0,0,0];
                                    if(a.scr_ratio<20){
                                      tx=[2];
                                    }else if(a.scr_ratio>=20&&a.scr_ratio<40){
                                      tx=[1,1];
                                    }else if(a.scr_ratio>=40&&a.scr_ratio<60){
                                      tx=[1,1,1];
                                    }else if(a.scr_ratio>=60&&a.scr_ratio<80){
                                      tx=[0,0,0,0];
                                    }
                                    // if(x.nowStatus==1){
                                    //   o.nowstate=x.nameId_Val;
                                    // }
                                    let aty= Math.floor( a.nh3out*10);

                                    let index=o.colorstep[Math.floor( a.nh3out*10)-1];
                                    if(a.nh3out==0){
                                      index='#16FDF5';
                                    }
                                    return {
                                      x_axis_Val : a.x_axis_Val,
                                      y_axis_Val : a.y_axis_Val,
                                      id : a.nameId_Val,
                                      dc:tx,
                                      scr_ratio:a.scr_ratio,
                                      nh3out:a.nh3out,
                                      boxcolor: index
                                    }
                                  }else{
                                    return x;
                                  }
   
                                });

                                //巡测数据同步更新 结束

                                
                              }
                            });

                            //关闭结束
                          }
                        });
                      }
                    });
                  }
                });
    },

    showpower(a){

      //alert(1)
      let o=this;
      if(!o.moverun){
        return;
      }
      o.itemRightdc=a.dc;
      o.moverun=false;
      o.left=o.movex;
      o.top=o.movey;
      o.txnow=a.scr_ratio;
      let pw=document.querySelectorAll('#pw'+a.id);
      anime({
            targets: pw[0],
            opacity: [
              { value: 0, duration: 1880 }
            ],
            duration: 1880
      });
      let power=document.querySelectorAll('#power');
      power[0].style.zIndex=999;
      power[0].style.display='block';
      anime({
            targets: power[0],
            translateY: [{
              value: -200,
              duration: 600,
            }],
            opacity: [
              { value: 0, duration: 0 },
              { value: 1, duration: 600 },
              { value: 1, duration: 3000 },
            ],
            //zindex: 999,
            scale: [{
              value: 0.2,
              duration: 0
            },{
              value: 1,
              duration: 600
            }],
            duration: 3600,
            easing: 'linear',
            complete: function(anim) {
              anime({
                    targets: pw[0],
                    opacity: [
                      { value: 1, duration: 380 }
                    ],
                    duration: 380
              });
              anime({
                targets: power[0],
                translateY: [{
                  value: 0,
                  duration: 50,
                }],
                opacity: [
                  { value: 0, duration: 50 }
                ],
                scale: [{
                  value: 0.2,
                  duration: 50
                }],
                duration: 0,
                easing: 'linear',
                complete: function(anim) {
                    power[0].style.zIndex=0;
                    power[0].style.left=0;
                    power[0].style.top=0;
                    power[0].style.display='none';
                    o.moverun=true;
                }
              });
            }
      });
      
    },
  

  },
  mounted() {

    let o = this;

    o.loadSCRList(null,0);

    //o.sx
    
    o.timer2=setInterval(() => {

      if(o.boilerid==-1){
        return;
      }
      getScrpointList({
            totalCount: 100,
            pageSize: 100,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "ASC",
                field: "Id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,-2,["realTime","checkTime"]); 
            o.itemall=d;
            d.map(x=>{
              if(x.nowStatus==1){
                if(o.nowstate!=-1 && o.nowstate!=x.nameId_Val){
                  o.aa(x);
                }
              }
            });
          });
    }, 3000);
    
    
    o.initwidth=window.screen.width;
    window.onresize = function(){ // 定义窗口大小变更通知事件
      o.screenWidth = document.documentElement.clientWidth; //窗口宽度
    };



    if (document.hidden !== undefined) {
      document.addEventListener('visibilitychange', () => {
        o.$router.go(0);
      })
    }
  },
  beforeDestroy() {
    clearInterval(this.timer2);
  }
};
</script>






