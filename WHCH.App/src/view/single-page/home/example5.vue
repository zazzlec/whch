<style scoped  lang="less">
@minheight:600px;
@size:360px;
@bgc:#3e3e3e;
.gwfs{
    
    background-color: #f0f0f0;
    padding:10px;
    width: 99%;
    display: block;
    overflow: hidden;
    position: relative;
    
   
    .h{
      width: 100%;
      float: left;
      height: 120px;
    }

    .l{
      // border:1px  solid red;
      // border-radius: 10px;
      width: 60%;
      min-height: @minheight;
      display:block;
      float: left;
      background-color:@bgc;
      background-repeat:no-repeat;
      background-size:100% 100%;
      -moz-background-size:100% 100%;
      position: relative;
      .logo{
        position:absolute;
        top: 10px;
        left:10px;
        // border:1px solid red;
        z-index: 999;
        width: 12%;
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
      .cl{
        margin: 100px auto;
        width: @size+200;
        height: @size;
        
        position: relative;
        //transform: rotateX(70deg);
        .octagon {
            width: @size+200;
            height: @size;
            position: relative;
            background-size: 100% 100%;
            .cc{
              position:absolute;
              left: (@size+200 - @size*4/5)/2-10 ;
              top: @size*1/5/2+10;
              background-size: 100% 100%;
              width:@size*4/5+20;
              height:@size*4/5-20 ;
              .nzi{
                position:absolute;
                // top: (@size*4/5-20-100)/2;
                left:(@size*4/5+20)*0.2;
                height: 50px;
                line-height: 50px;
                text-align: center;
                width: 60%;
                background-color: #f00;
                color:#fff;
                opacity: 0.6;
                border-radius: 11px;
                font-size: 26px;
                // font-weight: bold;
                z-index: 122;
              }
              // border: 1px solid red;
              img{
                position:absolute;
                left: 0px;
                top: 0px;
                width: 100%;
                height: 100%;
                z-index: 99;
                // border: 1px solid #f77;
              }
              .dd{
                position:absolute;
                left: 0px;
                top: 0px;
                width: 100%;
                height: 100%;
                z-index: 33;
                background-color: bisque;
                .pt{
                  position:absolute;
                  width: 8px;
                  height: 8px;
                  border-radius: 4px;
                  background-color: #da630b;
                  z-index: 55;
                }
                // border: 1px solid #000;
              }
            }
            .font{
              font-size: 23px;
              color: #fff;
              text-align: center;
            }
            .point{
              .font;
              position:absolute;
              width: @size/6;
              height:  @size/6;
              border-radius: 50%;
              background: radial-gradient(circle at 10px 10px ,#6ddcf6,#2d8cf0);
              line-height: @size/6;
              z-index: 1001;
            }
            .go{
              display: none;
            }

            //四角 go
            .go3{
              position:absolute;
              top:-@size/25;
              left:-@size/25;
              width: @size/5;
              height:  @size/5;
            }
            .go6{
              position:absolute;
              top:-@size/30;
              right:-@size/25;
              width: @size/5;
              height:  @size/5;
              transform:rotate(90deg)
            }
            .go9{
              position:absolute;
              bottom:-@size/30;
              right:-@size/30;
              width: @size/5;
              height:  @size/5;
              transform:rotate(180deg)
            }
            .go12{
              position:absolute;
              bottom:-@size/30;
              left:-@size/25;
              width: @size/5;
              height:  @size/5;
              transform:rotate(270deg)
            }

            // 上下 4个 go
            .go4{
              position:absolute;
              top:-@size/13;
              left: (@size+200)*1/4 + @size/11;
              width: @size/5;
              height:  @size/5;
            }
            
            .go5{
              position:absolute;
              top:-@size/13;
              left: (@size+200)*2/4 + @size/11;
              width: @size/5;
              height:  @size/5;
            }

            .go10{
              position:absolute;
              bottom:-@size/13;
              left: (@size+200)*2/4 + @size/11;
              width: @size/5;
              height:  @size/5;
              transform:rotate(180deg)
            }

            .go11{
              position:absolute;
              bottom:-@size/13;
              left: (@size+200)*1/4 + @size/11;
              width: @size/5;
              height:  @size/5;
              transform:rotate(180deg)
            }

            .go1{
              position:absolute;
              top: @size*3/4-@size*2/9;
              left:-@size/12;
              width: @size/5;
              height:  @size/5;
              transform:rotate(-90deg)
            }

            .go2{
              position:absolute;
              top: @size*2/4-@size*2/9;
              left:-@size/12;
              width: @size/5;
              height:  @size/5;
              transform:rotate(-90deg)
            }

            .go7{
              position:absolute;
              top: @size*2/4-@size*2/9;
              right:-@size/12;
              width: @size/5;
              height:  @size/5;
              transform:rotate(90deg)
            }

            .go8{
              position:absolute;
              top: @size*3/4-@size*2/9;
              right:-@size/12;
              width: @size/5;
              height:  @size/5;
              transform:rotate(90deg)
            }


            .r1{
              .point;
              top: @size*3/4-@size/6/2;
              left:-@size/8/2;
              .inset{
                position:absolute;
                top:0px;
                left: @size/5;
              }
            }
            .r2{
              .point;
              top: @size*2/4-@size/6/2;
              left:-@size/8/2;
              .inset{
                position:absolute;
                top:0px;
                left: @size/5;
              }
            }
            .r3{
              .point;
              top: @size*1/4-@size/6/2;
              left:-@size/8/2;
              .inset{
                position:absolute;
                top:0px;
                left: @size/5;
              }
            }
            .r4{
              .point;
              top: -@size/8/2;
              left: (@size+200)*1/4-@size/6/2;
              .inset{
                position:absolute;
                left:0px;
                top: -@size/6;
                width: @size/6;
              }
            }
            .r5{
              .point;
              top: -@size/8/2;
              left:(@size+200)*2/4-@size/6/2;
              .inset{
                position:absolute;
                left:0px;
                top: -@size/6;
                width: @size/6;
              }
            }
            .r6{
              .point;
              top: -@size/8/2;
              left:(@size+200)*3/4-@size/6/2;
              .inset{
                position:absolute;
                left:0px;
                top: -@size/6;
                width: @size/6;
              }
            }
            .r7{
              .point;
              top: @size*1/4-@size/6/2;
              right:-@size/8/2;
              .inset{
                position:absolute;
                top:0px;
                left: -@size/6;
              }
            }
            .r8{
              .point;
              top: @size*2/4-@size/6/2;
              right:-@size/8/2;
              .inset{
                position:absolute;
                top:0px;
                left: -@size/6;
              }
            }
            .r9{
              .point;
              top: @size*3/4-@size/6/2;
              right:-@size/8/2;
              .inset{
                position:absolute;
                top:0px;
                left: -@size/6;
              }
            }
            .r10{
              .point;
              right:  (@size+200)*1/4-@size/6/2;
              bottom:-@size/8/2;
              .inset{
                position:absolute;
                left:0px;
                top: @size/6;
                width: @size/6;
              }
            }
            .r11{
              .point;
              right: (@size+200)*2/4-@size/6/2;
              bottom:-@size/8/2;
              .inset{
                position:absolute;
                left:0px;
                top: @size/6;
                width: @size/6;
              }
            }
            .r12{
              .point;
              right:  (@size+200)*3/4-@size/6/2;
              bottom:-@size/8/2;
              .inset{
                position:absolute;
                left:0px;
                top: @size/6;
                width: @size/6;
              }

              
            }
            .active{
              -webkit-animation: Glow 1.0s ease infinite alternate;
              animation: Glow 1.0s ease infinite alternate;
            }
            .j1{
              .font;
              position:absolute;
              left: -@size/8;
              bottom: -@size/8;
              width: 80px;
              height: 30px;
              line-height: 30px;
            }
            .j2{
              .font;
              position:absolute;
              left: -@size/8;
              top: -@size/8;
              width: 80px;
              height: 30px;
              line-height: 30px;
            }
            .j3{
              .font;
              position:absolute;
              right: -@size/8;
              top: -@size/8;
              width: 80px;
              height: 30px;
              line-height: 30px;
            }
            .j4{
              .font;
              position:absolute;
              right: -@size/8;
              bottom: -@size/8;
              width: 80px;
              height: 30px;
              line-height: 30px;
            }
        }
        

      }
    }
    .ivu-card-body{
        padding: 5px !important;
      }
    .r{
      // border:1px  solid red;
      // border-radius: 10px;
      width: 38%;
      min-height: @minheight;
      display:block;
      float: left;
      height:600px;
      margin-left: 2%;
      .item{
        border: 1px solid #999;
        height: 50%;
        width: 100%;
        position: relative;
        display: block;
        .bt1{
          position:absolute;
          top: 7px;
          right:130px;
          width: 200px;
          height: 30px;
          line-height: 30px;
          cursor: pointer;
          // box-shadow: -5px 3px 5px rgba(0,0,0,0.3) ;
          color:#060;
          text-align: center;
        }
        .bt{
          position:absolute;
          top: 7px;
          right: 10px;
          width: 70px;
          height: 30px;
          line-height: 30px;
          background-color: rgb(90, 15, 15);
          border-radius: 5px;
          cursor: pointer;
          box-shadow: -5px 3px 5px rgba(0,0,0,0.3) ;
          color:#fff;
          text-align: center;
        }
        .bt:hover{
          background-color: rgb(255, 15, 15);
          box-shadow: -5px 3px 20px rgba(0,0,0,0.6) ;
        }
        .bt2{
          position:absolute;
          top: 7px;
          right: 10px;
          width: 70px;
          height: 30px;
          line-height: 30px;
          background-color: #060;
          border-radius: 5px;
          // cursor: pointer;
          box-shadow: -5px 3px 5px rgba(0,0,0,0.3) ;
          color:#fff;
          text-align: center;
        }
      }
      .ivu-tabs-nav-wrap {
        text-align: center;
      }
      
      .ivu-tabs-nav-container{
        font-size: 13px;
      }
      .t{
        display: block;
        padding-top: 5px;
        padding-left:5px;
        width:100%;
        height: 100px;
        // background-color: @bgc;
        border:1px solid #ddd;
        border-radius: 5px;
        color: red;
        .ivu-list-item{
          border: 0px;
          // height: 24px;
          // line-height: 24px;
          padding-top:0px;
          padding-bottom: 0px;;
        }
        .ivu-list-item-meta-title{
          color: aliceblue;
        }
        .ivu-list-item-meta-description{
          color: rgb(197, 202, 206);
        }
        .ivu-list-bordered{
          border: 0px;
          padding-top:5px;
        }
        overflow-y:auto;
        overflow-x: hidden;
      }
      .b{
        padding-left:5px;
        border-radius: 5px;
        margin-top: 8px;
        display: block;
        width:100%;
        height:108px;
        // background-color: @bcolor;
        .ivu-col{
          height: 30px;
          line-height: 32px;
          color: #666;
        }
        overflow-y:auto;
        overflow-x: hidden;
      }
      
    }



//00a67c
    @keyframes Glow {
        from {
            box-shadow: 0 0 10px #fff,
                        0 0 50px #fff,
                        0 0 70px #fff,
                        0 0 90px #00a67c,
                        0 0 100px #00a67c,
                        0 0 130px #00a67c,
                        0 0 160px #00a67c,
                        0 0 200px #00a67c;
        }
        to {
            box-shadow: 0 0 1px #fff,
                        0 0 3px #fff,
                        0 0 6px #fff,
                        0 0 8px #00a67c,
                        0 0 10px #00a67c,
                        0 0 15px #00a67c,
                        0 0 20px #00a67c,
                        0 0 25px #00a67c;
        }
    }

   .active2{
              -webkit-animation: Glow 1.0s ease infinite alternate;
              animation: Glow 1.0s ease infinite alternate;
    } 
}



</style>
<template>
<div class="gwfs" >


  <!-- 回看开始  -->
  <Modal v-model="huikan.modal2" width="1100" class-name="vertical-center-modal" :mask-closable="false">
        <p slot="header" >
          {{huikan.title}}
          <div v-if="!huikan.data.dataZoom" style="width: 290px;position:absolute;right:500px;top:8px;font-size:14px;">
          <span>播放速度:</span>
          <Select v-model="hktime" prefix="ios-time" style="width:70px"   >
              <Option  :value="200" :key="200">0.2</Option>
              <Option  :value="500" :key="500" >0.5</Option>
              <Option  :value="1000" :key="1000" selected="selected">1</Option>
              <Option  :value="3000" :key="3000">3</Option>
              <Option  :value="5000" :key="5000">5</Option>
          </Select>
          <span>秒/次</span>
          </div>
          <Button type="warning" @click="hqkdate(2)" style="width: 80px;position:absolute;right:470px;top:8px">前天</Button>
          <Button type="success" @click="hqkdate(1)" style="width: 80px;position:absolute;right:380px;top:8px">昨天</Button>
          <DatePicker type="datetimerange" v-model="huikan.timebe"  @on-change="haldleBackData" format="yyyy-MM-dd HH:mm" placeholder="选择时间段" style="width: 320px;position:absolute;right:50px;top:8px"></DatePicker>
        </p>
        <div style="text-align:center">
            <v-chart :options="huikan.data" autoresize  style="width:100%"></v-chart>
            <p v-if="!huikan.data.dataZoom" style="margin:0px auto;width: 1000px;height:50px;background: linear-gradient(to top,#212325,#999);border-radius: 5px; ">
              <span style="height:50px;float:left;display:block;width:60px;line-height:50px;"><icon style="color:#fff;font-size:22px;cursor: pointer;" type="ios-square" @click="hdstop"/></span>
              <span style="height:50px;float:left;display:block;width:22px;line-height:50px;margin-left:-6px"><icon style="color:#fff;font-size:22px;cursor: pointer;" :type="playbtn" @click="hdplay"/></span>
              <span style="height:50px;float:left;display:block;width:850px;line-height:50px;margin-left:30px">
                <Slider @on-input="ontimechange" v-model="vdatanow" :marks="vmarks" style="margin-top:22px;height:20px" :tip-format="vtip" :min="vmin" :max="vmax" :step="vstep" show-tip="always" show-stops></Slider>
              </span>
            </p>
        </div>
        <div slot="footer">
            
        </div>
  </Modal>
  <!-- 回看结束  -->




  <!-- 基础工况调整开始  -->
  <Modal v-model="jcgk.modal2" width="1100" class-name="rtertery5" :mask-closable="false">
        <p slot="header" >
          基础工况调整
        </p>
        <div  class="jcgk">
            <div class="l" >
              <div @mouseover="handleGo(iop)" @mouseout="handleGo2(iop)" class="btn" style="background-color:#999"  v-for="(info,iop) in fxoption.yAxis.data" v-bind:key="info">
                <div class="pros"  :style="'background-color:'+btncolors[iop]+';width:'+ processbtn(info) +'%;'">{{processbtn(info)}}%</div>
                <div class="g1">{{info}}</div>
              </div>
            </div> 
            <div class="r" > 
              <Table  height="450" :row-class-name="rowClassName" :columns="columns1" :data="data2" size="large" :loading="loading"></Table>
            </div> 
            <div v-if="tzbtn" class="tz" @click="handleTZ"> 保 存 </div>
        </div>
        <div slot="footer" style="height:0px">
        </div>
  </Modal>
  <!-- 基础工况调整结束  -->


  <div class="h">
    <Row :gutter="20">
      <i-col :xs="12" :md="8" :lg="4" v-for="(infor, i) in inforCardData" :key="`infor-${i}`" style="height: 120px;padding-bottom: 10px;">
        <infor-card shadow :color="infor.color" :icon="infor.icon" :icon-size="39">
          <div class="zi">
          <count-to :decimals="i<2?0:2" :end="infor.count" count-class="count-style"/>
          <p>{{ infor.title }}(<span v-if="i<2" >h</span><span v-if="i>=2" >%</span>)</p>
          </div>
          <div class="wv" :style="'top:-'+infor.count+'px'"  v-if="i>=2">
            <img  :src="ware" />
          </div>          
        </infor-card>
      </i-col>
    </Row>
  </div>
  <div class="l" >

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

    <div class="cl" >
      
      <div class="octagon" :style="{backgroundImage: 'url(' + rec + ')' }">
        <div  @contextmenu="showMenu(indexc)"  v-for="(info,indexc) in fsarr" :class="[{ active: info.x==nowfs.x }, 'r'+info.x ]"   v-bind:key="info.x"    :style="{'background':'radial-gradient(circle at 10px 10px,' + colorstep[Math.floor(info.v/10)] + ', #000)'}">
          <vue-context-menu :contextMenuData="contextMenuData"  :transferIndex="transferIndex"
            @savedata="savedata(info)" @savedata3="savedata3(info)"
             ></vue-context-menu>
          {{info.x}}#
          <div class="inset"><count-to :end="info.v"/>
          </div>
        </div>
        <div class="j1">1号角</div>
        <div class="j2">2号角</div>
        <div class="j3">3号角</div>
        <div class="j4">4号角</div>
        
        <img :class="'go'+nowfs.x" :src="g1gif" v-if="[3,6,9,12].indexOf(nowfs.x)!=-1" />
        <img :class="'go'+nowfs.x" :src="g2gif" v-if="[4,5,10,11].indexOf(nowfs.x)!=-1"/>
        <img :class="'go'+nowfs.x" :src="g3gif" v-if="[1,2,7,8].indexOf(nowfs.x)!=-1"/>

        <div class="cc">
          <div class="nzi" :style="{'background-color':''+colorstep[Math.floor(nowfs.v/10)]+'',color:''+ nowfs.v<300?'#000':'#fff' +''}">当前测点:{{nowfs.x}}#</div>
          <img :src="centerbk"  /> 
          <div class="dd">
            <div class="pt" v-for="f in points"  :style="{'background-color':''+f.c+'',top:''+f.t+'px',left:''+f.l+'px'}" ></div>
          </div>
        </div>
      </div>

    </div>
    <div style="clear:both"></div>
  </div>
  <div class="r">
    <div class="item" @contextmenu="showMenu2">
      <vue-context-menu :contextMenuData="contextMenuData2"  
            @savedata2="savedata2()" @savedata5="savedata5()"
             ></vue-context-menu>
      <Card :bordered="false">
        <span slot="title" ><b>风量配比实时对比</b></span>
        <Tabs name="name1" type="card">
        <TabPane label="风量对比图" tab="name1" >
          <v-chart :options="fxoption" autoresize  style="width:100%;height:270px"></v-chart>
        </TabPane>
        <TabPane label="各风量占比图" tab="name1" >
          <v-chart :options="fxoption2" autoresize  style="width:100%;height:270px"></v-chart>
        </TabPane>
        </Tabs>
        
      </Card>
    </div>
    <div class="item lll" style="height:49%;margin-top:5px">
      <Card :bordered="false">
        <span slot="title"><b>硫化氢超标列表</b></span>
              <Row :gutter="16">
                    <Col span="4">测点</Col>
                    <Col span="10">硫化氢检测值</Col>
                    <Col span="10">出现时间</Col>
                  </Row>  
                <div class="b">

                  <Row :gutter="16" v-for="t in tention" :style="{'background-color':''+ (t.j >= param.higtv ?'#fdd':'#fff') +''}">
                    <Col span="4">{{t.i}}</Col>
                    <Col span="10">{{t.j}}</Col> 
                    <Col span="10">{{t.k}}</Col>
                  </Row>

                </div>

                <div class="t" style="margin-top:7px;height:90px;margin-bottom:6px;box-shadow: -6px 6px 6px rgba(0,0,0,0.6) ;background-color:#fee">
                  <p style="color:#222;"><b>调整建议</b></p>
                  {{ad}}
                </div>
              </Card>
              <div class="bt1">{{time12}}</div>
              <div class="bt" @click="handleall6" v-if="isqr==0"> 确认处理 </div>
              <div class="bt2"  v-if="isqr==1"> 已处理 </div>
    </div>
  </div>
  <div style="clear:both"></div>

  
</div>   
</template>

<script>
import store from '@/store'
//工具包
import { getDateMore,sortBy,gradientColor,getDate } from "@/libs/tools";
//全局配置
import { global } from "@/api/echart/config";
//机组
import { getBoilerListAll } from "@/api/ZNRS/Dncboiler";

import {
  getGwfs_parameterList,
  editGwfs_parameter
} from "@/api/ZNRS/Dncgwfs_parameter";
import {
  getGwfspointList,
  getGwfspointListAll
} from "@/api/ZNRS/Dncgwfspoint";
import {
  getGwfspointdataList,
  batchok,
  Reset,
  ChangeBaseAgle
} from "@/api/ZNRS/Dncgwfspointdata";
import {
  getWindgroupList
} from "@/api/ZNRS/Dncwindgroup";
import {
  getWindList
} from "@/api/ZNRS/Dncwind";
import anime from 'animejs/lib/anime.js';


//图形依赖包
import ECharts from "vue-echarts";
// 柱状图
import "echarts/lib/chart/bar";
// 折线
import "echarts/lib/chart/line";

import "echarts/lib/chart/pie";
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
import InforCard from '_c/info-card';
import CountTo from '_c/count-to';

//右键菜单
import VueContextMenu from 'vue-contextmenu/src/VueContextMenu'
//数据
import { fxoption,fxoption2,fsoption,fxoption_back } from "@/api/echart/fsfx";

import ware from "@/assets/images/timg.gif";
import rec from "@/assets/images/1.png";
import centerbk from "@/assets/images/2.png";
import g1gif from "@/assets/images/g1.gif";
import g2gif from "@/assets/images/g2.gif";
import g3gif from "@/assets/images/g3.gif";



export default {
  name: "ZNRS_gwfs_page",
  components: {
    "v-chart": ECharts,
    InforCard,
    CountTo,
    "vue-context-menu" : VueContextMenu
  },
  data() {
    return {

      huikan:{
        modal2:false,
        title:"数据回看",
        timebe:[],
        data:{}
      },
      playbtn:"md-play",
      hktime:1000,
      vtimer:'',
      vdata:[],
      vmin:0,
      vmax:10,
      vdatanow:0,
      vstep:1,
      vtip:(val)=>{
        if(this.vdata.length==0){
          return 0;
        }else{
          return this.vdata[val].realTime;
        }
      },
      vmarks: {
        0: '0°C',
      },


      tzbtn:true,
      btncolors:['#c23531','#2f4554','#61a0a8','#d48265','#91c7ae','#749f83','#ca8622','#484891','#336666','#bda29a'],
      transferIndex: null,  
      	// contextmenu data (菜单数据)
      contextMenuData: {
        // the contextmenu name(@1.4.1 updated)
        menuName: 'demo',
        // The coordinates of the display(菜单显示的位置)
        axis: {
          x: null,
          y: null
        },
        // Menu options (菜单选项)
        menulists: [{
          fnHandler: 'savedata', // Binding events(绑定事件)
          icoName: 'icon ivu-icon ios-refresh-circle', // icon (icon图标 )
          btnName: '数据重置' // The name of the menu option (菜单名称)
        },{
          fnHandler: 'savedata3', // Binding events(绑定事件)
          icoName: 'icon ivu-icon logo-steam', // icon (icon图标 )
          btnName: '数据回看' // The name of the menu option (菜单名称)
        }]
      },

      contextMenuData2: {
        // the contextmenu name(@1.4.1 updated)
        menuName: 'demo2',
        // The coordinates of the display(菜单显示的位置)
        axis: {
          x: null,
          y: null
        },
        // Menu options (菜单选项)
        menulists: [{
          fnHandler: 'savedata2', // Binding events(绑定事件)
          icoName: 'icon ivu-icon ios-refresh-circle', // icon (icon图标 )
          btnName: '基础工况调整' // The name of the menu option (菜单名称)
        }
        // ,
        // {
        //   fnHandler: 'savedata5', // Binding events(绑定事件)
        //   icoName: 'icon ivu-icon logo-steam', // icon (icon图标 )
        //   btnName: '数据回看' // The name of the menu option (菜单名称)
        // }
        ]
      },
      isqr:0,
      param:{
        alertv:0,
        higtv:0
      },
      timer2:null,
      tu:true,
      fxoption,fxoption2,fsoption,fxoption_back,
      inforCardData: [
        { title: '总燃烧时间', icon: 'md-time', count: 803, color: '#2d8cf0' },
        { title: '总腐蚀时间', icon: 'md-timer', count: 232, color: '#19be6b' },
        { title: '腐蚀风险率', icon: 'md-warning', count: 99, color: '#ff9900' },
        { title: '水冷壁寿命', icon: 'md-pulse', count: 100, color: '#ed3f14' }
      ],
      fsarr:[],
      points:[],
      nowfs:{},
      nowindex:-1,
      ware,rec,centerbk,g1gif,g2gif,g3gif,
      colorstep:[],
      pointstep:[],


      //机组
      boilertime:"",
      boilerid:-1,
      boiler:"",
      boilerNowStatus:-1,
      boilerSta_time:"",
      boilers:[],


      //advice
      tention:[],
      ad:"",
      id12:-1,
      time12:"",

      //基础工况
      jcgk:{
        modal2:false,
        title:""
      },
      loading:true,


      columns1: [
                    {
                        title: '风门名称',
                        key: 'wind_Name_kw'
                    },
                    {
                        title: '风门开度',
                        key: 'fmkd',
                        render: (h, params)=>{
                            return h('Input', {
                                  props:{
                                      value:  params.row.fmkd,
                                      autosize: true
                                  } ,
                                  on: {
                                      'on-keyup': (event) => {
                                          let ty=this.data2;
                                          params.row.fmkd=event.target.value;
                                          ty[params.index].fmkd=params.row.fmkd;
                                          if(params.row.fmkd>100){
                                            this.$Message.warning("风门开度不能超过100");
                                            params.row.fmkd=100;
                                            ty[params.index].fmkd=100;
                                          }
                                          if(params.row.fmkd<0){
                                            this.$Message.warning("风门开度不能低于0");
                                            params.row.fmkd=0;
                                            ty[params.index].fmkd=0;
                                          }
                                          
                                          params.row.ltmj = params.row.mk / Math.cos(params.row.jd * Math.PI / 180) * (params.row.mg - params.row.mg * Math.cos((params.row.jd + params.row.fmkd * ((90 - params.row.jd)*1.00 / 100)) * Math.PI / 180));
                                          ty[params.index].ltmj = params.row.ltmj;
                                          let sum=eval(ty.map(x=>{return x.ltmj}).join("+"));

                                          for (let index = 0; index < ty.length; index++) {
                                            let element = ty[index];
                                          //  console.log(element.ltmj);
                                            element.bfb = Math.round(element.ltmj / sum * 100 * 100) / 100;
                                            ty[index].bfb=element.bfb;
                                          }
                                          this.data2 =  ty;
                                          this.tzbtn=true;
                                          // console.log(JSON.stringify(ty));
                                      },
                                      'on-focus': (event) => {
                                        event.target.select();
                                      }
                                  }
                            })
                        }
                    },
                    {
                        title: '门宽',
                        key: 'mk'
                    },
                    {
                        title: '门高',
                        key: 'mg'
                    },
                    {
                        title: '0%角度',
                        key: 'jd'
                    },
                    // {
                    //     title: '流通面积',
                    //     key: 'ltmj'
                    // },
                    {
                        title: '百分比',
                        key: 'bfb'
                    }
                ],
      data2: []
    }
  },
  watch:{
    
  },
  computed:{

  },
  methods: {

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
      if(this.huikan.data.dataZoom){
        if(t==1){
          this.backview(this.huikan.title,this.dateFormat("yyyy-MM-dd 00:00",new Date(d1)),this.dateFormat("yyyy-MM-dd 23:59",new Date(d1)));
        }else if(t==2){
          this.backview(this.huikan.title,this.dateFormat("yyyy-MM-dd 00:00",new Date(d2)),this.dateFormat("yyyy-MM-dd 23:59",new Date(d2)));
        }
      }else{
        if(t==1){
          this.Vedioview(this.huikan.title,this.dateFormat("yyyy-MM-dd 00:00",new Date(d1)),this.dateFormat("yyyy-MM-dd 23:59",new Date(d1)));
        }else if(t==2){
          this.Vedioview(this.huikan.title,this.dateFormat("yyyy-MM-dd 00:00",new Date(d2)),this.dateFormat("yyyy-MM-dd 23:59",new Date(d2)));
        }
      }
    },
    haldleBackData(date){
      let d1=date[0];
      let d2=date[1];
      if(this.huikan.data.dataZoom){
        this.backview(this.huikan.title,d1,d2);
      }else{
        this.Vedioview(this.huikan.title,d1,d2);
      }
    },
    haldleBack(title){
      let dateTime=new Date();
      dateTime=dateTime.setDate(dateTime.getDate()-1);
      this.backview(title,this.dateFormat("yyyy-MM-dd HH:mm",new Date(dateTime)),this.dateFormat("yyyy-MM-dd HH:mm",new Date()));
    },
    
    //回看函数
    backview(title,d1,d2){
      let o=this;
      let huikandata=fsoption;

      getGwfspointdataList({
                totalCount: 0,
                pageSize: 7000,
                currentPage: 1,
                kw: "",
                isDeleted: 0,
                boilerid:o.boilerid,
                status: -1,
                d1:d1,
                d2:d2,
                nid:o.huikan.info.nameId_Val,
                sort: [
                  {
                    direct: "DESC",
                    field: "id"
                  }
                ]
              }).then(res => {
                let uu = getDateMore(res.data.data,2,["realTime"]).reverse();
                huikandata.xAxis.data=uu.map(x=>{
                  return x.realTime;
                });

                huikandata.series[0].data=uu.map(x=>{
                  return x.h2s;
                });

                huikandata.series[2].data=uu.map(x=>{
                  return o.param.alertv;
                });

                huikandata.series[1].data=uu.map(x=>{
                  return o.param.higtv;
                });


                o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2],
                  info:{}
                };

              }
      );

    },

    haldleVedio(title){
      let dateTime=new Date();
      dateTime=dateTime.setDate(dateTime.getDate()-1);
      this.Vedioview(title,this.dateFormat("yyyy-MM-dd HH:mm",new Date(dateTime)),this.dateFormat("yyyy-MM-dd HH:mm",new Date()));
    },

    //播放函数
    Vedioview(title,d1,d2){
      let o=this;
      let huikandata={};
      huikandata=o.fxoption_back;

      getWindgroupList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            boilerid:o.boilerid,
            status: -1,
            d1:d1,
            d2:d2,
            sort: [
              {
                direct: "asc",
                field: "id"
              }
            ]
          }).then(res => {
        let t = getDateMore(res.data.data,1,["realTime",]);
        let realtime=t.map(x=>{ return x.realTime});
        o.vdata=t;
        o.vmax=t.length - 1 ;
        o.vdatanow=0;

        o.fxoption_back.yAxis.data=t.map(x=>{
          return x.group_Name_kw;
        });
        o.fxoption_back.series[0].data=t.map(x=>{
          return Math.floor(x.base_percent * 100) / 100;
        });
        o.fxoption_back.series[1].data=t.map(x=>{
          return Math.floor(x.real_percent * 100) / 100;
        });
        huikandata=o.fxoption_back;


        console.log(JSON.stringify(huikandata));
        
        o.huikan={
          title:title,
          modal2:true,
          data:huikandata,
          timebe:[d1,d2]
        };
      });

      
    },

    hdstop(){
      let o=this;
      o.playbtn="md-play";
      o.vdatanow=0;
    },
    hdplay(){
      let o=this;
      if(o.playbtn=="md-play"){
        o.playbtn="md-pause";
        o.tt();
      }else{
        o.playbtn="md-play";
      }
    },
    tt(){
      let o=this;
      if(o.playbtn=="md-pause"&&!o.huikan.data.dataZoom&&o.huikan.modal2){
        if(o.vdatanow>=0 && o.vdatanow<o.vmax){
          o.vdatanow++;
          o.junpto();
          setTimeout(o.tt, o.hktime);
        }else if(o.vdatanow >= o.vmax){
          o.playbtn="md-play";
        }
      }
    },
    ontimechange(){
      let o=this;
      o.junpto();
    },
    junpto(){
      let o=this;
      let huikandata={};
      huikandata=fxoption_back;
      o.huikan.data=huikandata;
    },

    savedata3 (index) {
      //{"id":5,"nameId_Val":5,"k_Name_kw":"5#","remarks":"5号测点","dncBoiler":null,"dncBoiler_Name":"1号机组","nowStatus":0,"realTime":"2020-05-12","h2s":909,"advice":"以5%的幅度开大CD/EF/FF层风门。","checkTime":null,"checkPerson":null,"fstime":105,"fsrisk":0.01824368245808471,"slblife":99.89684862273333,"last_fire_time_sum":812,"status":1,"isDeleted":0,"x":5,"v":909}
      let o=this;
      o.huikan.info=index;
      o.haldleBack(index.k_Name_kw+"回看");
    },

    savedata5 () {
      let o=this;
      o.haldleVedio("风量配比回看");
    },



    processbtn(r){
      return Math.round((eval(this.data2.filter(x=>x.dncGroup_Name==r).map(x=>{return x.bfb}).join("+"))) * 100) / 100;　
    },
    handleGo(r){
      let container = document.querySelectorAll('.ivu-table-tbody .tbrow'+r);
      container[0].scrollIntoView();
      anime({
            targets: container,
            fontSize:18,
            duration: 100,
            easing: 'linear'
          });
    },
    handleGo2(r){
      let container = document.querySelectorAll('.ivu-table-tbody .tbrow'+r);
      anime({
            targets: container,
            fontSize:16,
            duration: 100,
            easing: 'linear'
          });
    },
    showMenu (index) {
      let o=this;
      o.transferIndex = index;
      event.preventDefault();
      var x = event.clientX
      var y = event.clientY
      o.contextMenuData.axis = {
        x, y
      }
    },
    showMenu2 () {
      let o=this;
      event.preventDefault();
      var x = event.clientX
      var y = event.clientY
      o.contextMenuData2.axis = {
        x, y
      }
    },
    rowClassName (row, index) {
      let o=this;
      let t=0;
      // tbrow1
      for (let index = 0; index < o.fxoption.yAxis.data.length; index++) {
        let element = o.fxoption.yAxis.data[index];
        if(row.dncGroup_Name==element){
          // console.log(row.dncGroup_Name+"--"+element+"--"+t);
          break;
        }
        t++;
      }
      return 'tbrow'+t;
    },
    savedata2 () {
      let o=this;
      o.jcgk.modal2=true;
      o.loading=true;

      o.tzbtn=false;
      getWindList({
            totalCount: 0,
            pageSize: 50,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid:o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "wind_Name_kw"
              }
            ]
          }).then(res => {
        let tt = getDateMore(res.data.data,-1,["realTime",]);
        let xx=tt.map(x=>{
          return {
                        id:x.id,
                        wind_Name_kw:x.wind_Name_kw,
                        dncGroup_Name:x.dncGroup_Name,
                        fmkd: x.base_angle,
                        mk: x.doorwitdh,
                        mg: x.doorheight,
                        jd: x.angle0,
                        ltmj:x.base_ltmj,
                        bfb:Math.round(x.base_percent * 100) / 100
          }
        });


        let result=[];
        o.fxoption.yAxis.data.map(x=>{
          xx.map(dd=>{
            if(x==dd.dncGroup_Name){
              result.push(dd);
            }
          });
        });


        o.data2=result;
        o.loading=false;
      });
    },
    savedata (index) {
      //{"id":5,"nameId_Val":5,"k_Name_kw":"5#","remarks":"5号测点","dncBoiler":null,"dncBoiler_Name":"1号机组","nowStatus":0,"realTime":"2020-05-12","h2s":909,"advice":"以5%的幅度开大CD/EF/FF层风门。","checkTime":null,"checkPerson":null,"fstime":105,"fsrisk":0.01824368245808471,"slblife":99.89684862273333,"last_fire_time_sum":812,"status":1,"isDeleted":0,"x":5,"v":909}
      let rr="";
      if(this.boilerNowStatus==1){
        rr="<span style='color:red'><b>锅炉当前处于运行状态</b></span>,是否确定重置？"
      }else{
        rr="是否确定重置？";
      }
      
      this.$Modal.confirm({
        title: '提示',
        content: '<p>'+rr+'</p>',
        onOk: () => {
          Reset(index).then(res => {
            if(res.data.code==500){
              this.$Modal.error({
                title: '提示',
                content: res.data.message
              })
            }else{
              this.$Message.success(res.data.message);
            }
          });
        }
      });
    },

    drophld(name){
      this.boilers.map(o=>{
        if(o.k_Name_kw==name){
          this.boilerid=o.id;
          this.boiler=o.k_Name_kw;
          this.boilertime=o.syntime;
          this.boilerNowStatus=o.nowStatus;
          this.boilerSta_time=o.sta_time;
          // console.log(this.boilertime);
          this.loadit(this.boilerid,1);
        }
      });
    },
    loadit(bid,t){
      let o=this;//16FDF5

      

      let op1 = new Promise(function(resolve, reject){
        getBoilerListAll().then(res => {
          o.boilers=getDateMore(res.data.data,-1,["syntime",]);
          if(bid==null){
            o.boiler=o.boilers[0].k_Name_kw;
            o.boilerid=o.boilers[0].id;
            o.boilertime=o.boilers[0].syntime;
            o.boilerNowStatus=o.boilers[0].nowStatus;
            o.boilerSta_time=o.boilers[0].sta_time;
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
          //加载配置
          getGwfs_parameterList({
                  totalCount: 0,
                  pageSize: 20,
                  currentPage: 1,
                  kw: "",
                  isDeleted: 0,
                  boilerid:data,
                  status: -1,
                  sort: [
                    {
                      direct: "DESC",
                      field: "id"
                    }
                  ]
                }).then(res => {
              let t = res.data.data;
              if(t.length>0){
                o.param={
                  alertv:t[0].h2s_alert,
                  higtv:t[0].h2s_high
                };
                let f1=Math.floor(o.param.alertv/10);
                let f2=Math.floor(o.param.higtv/10)-f1;
                let f3=100-f2-f1;
                // console.log(f1+"-"+f2+"-"+f3);
                
                o.colorstep=gradientColor('#00aa00','#77ff77',f1);
                o.colorstep=o.colorstep.concat(gradientColor('#FFFFb0','#FFA500',f2));
                o.colorstep=o.colorstep.concat(gradientColor('#FF0000','#4D0000',f3));
              }
              
          });
          //gogogog
          o.freshdata(data);
          o.windfresh(data);
          //加载上一次建议
          o.loadadvice(data);
        }
      });
      
    },

    freshdata(data){
      let o=this;
      let old=o.nowindex;
      getGwfspointList({
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            boilerid:data,
            isDeleted: 0,
            status: -1,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let arr = getDateMore(res.data.data,1,["realTime"]);
            let tarr=arr.map(a=>{
              let d=a;
              d.x=a.nameId_Val;
              d.v=a.h2s;
              if(a.nowStatus==1){
                o.nowindex=a.nameId_Val;
                o.nowfs=d;
              }
              return d;
            });
            // console.log(old+"---"+o.nowindex);
            if(old!=o.nowindex){
              // console.log(1);
              o.fsarr=tarr;
              //o.nowfs.v
              let tp=[];
              for (let index = 0; index <  o.nowfs.v ; index++) {
                let oo = {};
                oo.c = o.pointstep[Math.floor(Math.random()*3)];
                oo.t = Math.floor((Math.random()*320*4/5));
                oo.l = Math.floor((Math.random()*350*4/5));
                tp.push(oo);
              }
              o.points=tp;

              if(o.nowfs.v>o.param.higtv){
                var utterThis = new window.SpeechSynthesisUtterance(o.nowindex+"号测点,硫化氢"+o.nowfs.v+",已超标");
                window.speechSynthesis.speak(utterThis);
              }else if(o.nowfs.v>o.param.alertv){
                var utterThis = new window.SpeechSynthesisUtterance(o.nowindex+"号测点,硫化氢"+o.nowfs.v+",偏高");
                window.speechSynthesis.speak(utterThis);
              }
              if(o.boilerNowStatus==0){
                o.inforCardData[0].count=o.nowfs.last_fire_time_sum;
              }else if(o.boilerNowStatus==1){
                let new_date = new Date(); //新建一个日期对象，默认现在的时间
	              let old_date = new Date(o.boilerSta_time.replace("T"," ")); //设置过去的一个时间点，"yyyy-MM-dd HH:mm:ss"格式化日期
                let difftime = Math.floor((new_date - old_date)/1000/60/60); //计算时间差,并把毫秒转换成秒
                o.inforCardData[0].count=o.nowfs.last_fire_time_sum+difftime;
              }
              // console.log(o.nowfs.fstime);
              
              o.inforCardData[1].count=Math.floor(o.nowfs.fstime / 60);
              o.inforCardData[2].count=Math.floor(o.nowfs.fsrisk * 100) / 100;
              o.inforCardData[3].count=Math.floor(o.nowfs.slblife * 100) / 100;
            }

            //建议查询
            if(o.nowindex==1){
              o.loadadvice(data);
            }
            
          });
    },

    //加载建议
    loadadvice(bid){
      let o=this;
      getGwfspointdataList({
                totalCount: 0,
                pageSize: 50,
                currentPage: 1,
                kw: "",
                isDeleted: 0,
                boilerid:bid,
                status: -1,
                sort: [
                  {
                    direct: "DESC",
                    field: "id"
                  }
                ]
              }).then(res => {
                let uu = getDateMore(res.data.data,-1,["realTime","checkTime"]);
                let shows=[];
                let b=false;
                let ii=0;

                let t=null,isi=0;
                uu.map(x=>{
                  if(x.nameId_Val==12){
                    b=true;
                  }
                  if(b){
                    // console.log(ii);
                    
                    if(ii<12){
                      shows.push({
                        i:x.nameId_Val+"#",
                        j:x.h2s,
                        k:x.realTime
                      });
                    }
                    
                    ii++;
                    if(ii==1){
                      o.id12=x.id;
                      o.ad=x.advice;

                      t=x.checkTime;
                      isi=x.checkPerson==null?0:1;
                      // console.log("112:"+o.ad);
                    }
                    if(ii==12){
                      b=false;
                      return;
                    }
                  }
                });

                o.tention=shows;

                //o.time12 ="确认时间:"+ getDate(Math.floor(Date.parse(new Date()) / 1000),'year');
                if(isi==1){
                  o.time12="确认时间:"+t;
                  o.isqr=1;
                }else{
                  o.time12="";
                  o.isqr=0;
                }

                


                
      });
    },

    //风向数据
    windfresh(data){
      let o=this;
      getWindgroupList({
            totalCount: 0,
            pageSize: 200,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            boilerid:data,
            status: -1,
            sort: [
              {
                direct: "asc",
                field: "id"
              }
            ]
          }).then(res => {
        let t = getDateMore(res.data.data,1,["realTime",]);
        o.fxoption.yAxis.data=t.map(x=>{
          return x.group_Name_kw;
        });
        o.fxoption.series[0].data=t.map(x=>{
          return Math.floor(x.base_percent * 100) / 100;
        });
        o.fxoption.series[1].data=t.map(x=>{
          return Math.floor(x.real_percent * 100) / 100;
        });

        o.fxoption2.series[0].data=t.map(x=>{
          return {
            name: x.group_Name_kw,
            value: Math.floor(x.base_percent * 100) / 100
          }
        });

        o.fxoption2.series[1].data=t.map(x=>{
          return {
            name: x.group_Name_kw,
            value: Math.floor(x.real_percent * 100) / 100
          }
        });
        //console.log(JSON.stringify(o.fxoption.yAxis.data));
        
      });
    },

    //确定处理按钮
    handleall6(){
      let o=this;
      if(o.id12==-1){
        return;
      }
      this.$Modal.confirm({
        title: '提示',
        content: '<p>是否已确认处理?</p>',
        onOk: () => {
          batchok({
            fsts: o.id12
          }).then(res => {
              if(res.data.code==500){
                this.$Modal.error({
                  title: '提示',
                  content: res.data.message
                  ,onOk: () => {
                    
                  }
                })
              }else{
                o.time12 ="确认时间:"+ getDate(Math.floor(Date.parse(new Date()) / 1000),'year');
                o.isqr=1;
              }
              
          });
        },
        onCancel: () => {
        }
      });
    },

    //基础工况调整
    handleTZ(){
      let o=this;
      this.$Modal.confirm({
        title: '提示',
        content: '<p>是否确认调整基础工况？</p>',
        onOk: () => {
          
          let j={};
          j.bid=o.boilerid;
          j.arr=o.data2.map(x=>{
            return {
              id:x.id,
              fmkd:x.fmkd,
              ltmj:x.ltmj,
              bfb:x.bfb
            }
          });
          //processbtn
          j.grp=o.fxoption.yAxis.data.map(x=>{
            return {
              n:x,
              p:o.processbtn(x)
            }
          });

          o.tzbtn=false;
          o.loading=true;
          ChangeBaseAgle({
            fsts: JSON.stringify(j)
          }).then(res => {
              if(res.data.code==200){
                o.jcgk.modal2=false;
                o.$Message.success('调整成功');
              }
          });
        },
        onCancel: () => {
        }
      });
    }
  },
  mounted() {

    let o = this;
    o.pointstep=['#843213','#914018','#990000'];

    o.loadit(null,0);
    
    o.timer2=setInterval(() => {

      if(o.boilerid==-1){
        return;
      }
      o.freshdata(o.boilerid);
      o.windfresh(o.boilerid);
    }, 5000);


  },
  beforeDestroy() {
    clearInterval(this.timer2);
  }
};
</script>
<style lang="less">
.gwfs{
.count-style{
  font-size:38px;
}
.ivu-col-span-lg-4 {
  display: block;
  width: 25%;
}
.right-area{
  width: 100%;
  height: 110%;
  position: absolute;
  right: 0px;
  top:0px;
  z-index: 888;
  // box-shadow:inset 3px 0px 3px rgba(0,0,0,0.9) ; 
  .zi{
    position: absolute;
    width: 100%;
    height: 100%;
    left: 0px;
    top: 20px;
    z-index: 999;
  }
  .wv{
    // opacity: 0.9;
    	width: 100%;
    	height: 200%;
    	position: absolute;
    	left: 0px;
      bottom:0px;
      background-color: #b6d7ec;
      img{
        width: 100%;
        height:  130px;
        top:0px;
        left: 0px;
      }
  }
  
}
.ivu-tabs-nav-wrap {
    text-align: right;
}
.ivu-tabs-nav-scroll {
    display: inline-block;
}
.ivu-card-body{
  padding: 6px;
  margin-top: -41px;;
}
.lll{
  .ivu-card-body{
    padding: 16px;
    margin-top: 0px;
    padding-top:6px ;
    padding-bottom:2px ;
  }
}


.h{
  .ivu-card-body{
    padding: 16px;
    margin-top: 0px;
    padding-top:6px ;
    padding-bottom:2px ;
  }
}
.ivu-card-head{
  border: 0px;
}

.vue-contextmenu-listWrapper{
  // z-index: 11112 !important;
  color:#222;
  font-family: "微软雅黑";
  font-weight: bold;
}
.no-child-btn{
  height: 22px !important;
  line-height: 22px !important;
  box-shadow: -5px 3px 5px rgba(231, 199, 199, 0.3) !important;
}
.ios-refresh-circle:before {
    content: "\F28E";
    height: 20px;
    width: 20px;
    font-size: 20px;
    float: left;
    margin-top: -2px;
    margin-left: 6px;
}
.logo-steam:before {
    content: "\F321";
    height: 20px;
    width: 20px;
    font-size: 20px;
    float: left;
    margin-top: -2px;
    margin-left: 6px;
}

}

.rtertery5{
  .jcgk{
      height:450px;
      width:100%;
      position: relative;
      .tz{
          position:absolute;
          bottom: 7px;
          right: 25px;
          text-align: center;
          width: 97px;
          height: 38px;
          font-size: 18px;
          line-height: 36px;
          background-color: #a00;
          border-radius: 9px;
          border: 2px solid #fff;
          cursor: pointer;
          box-shadow: -5px 3px 5px rgba(0,0,0,0.3) ;
          color:#fff;
          text-align: center;
          opacity: 0.6;
      }
      .tz:hover{
          opacity: 1;
          box-shadow: -5px 3px 20px rgba(0,0,0,0.6) ;
      }
      .k{
        height:450px;float:left;
      }
      .l{
        .k;
        border:1px solid #ddd;
        width:20%;
        .btn{
          position: relative;
          cursor: pointer;
          width:80%;
          height: 38px;
          border-radius: 5px;
          // background-color: #2d8cf0;
          line-height: 38px;
          text-align: center;
          font-size: 20px;
          color:#fff;
          margin: 15px auto;
        }
        .pros{
          float:left;
          height:100%;
          border-radius: 5px;
          text-align: center;
          color: #fff;
          font-size: 13px;
        }
        .g1{
          position:absolute;
          height: 100%;
          width: 100%;
          text-align: center;
          color: #333;
        }
        .btn:hover{
          box-shadow: 0px 3px 12px rgba(15, 2, 75, 0.8) ;
        }
      }
      .r{
        .k;
        width:80%;
      }
  }
  //['#c23531','#2f4554','#61a0a8','#d48265','#91c7ae','#749f83','#ca8622','#484891','#336666','#bda29a']
  .ff{
    color: #fff;
  }
  .tbrow0{
    td{
      .ff;
      background-color:rgb(194, 52, 49);
    }
  }
  .tbrow1{
    td{
    .ff;
    background-color:rgb(47, 69, 84);
    }
  }
  .tbrow2{
    td{
    .ff;
    background-color:rgb(97, 160, 168);
    }
  }
  .tbrow3{
    td{
    .ff;
    background-color:rgb(212, 130, 101);
    }
  }
  .tbrow4{
    td{
    .ff;
    background-color:rgb(145, 199 , 174);
    }
  }
  .tbrow5{
    td{
    .ff;
    background-color:rgb(116, 159, 131);
    }
  }
  .tbrow6{
    td{
    .ff;
    background-color:rgb(202, 134, 34);
    }
  }
  .tbrow7{
    td{
    .ff;
    background-color:rgb(72, 72, 145);
    }
  }
  .tbrow8{
    td{
    .ff;
    background-color:rgb(51, 102, 102);
    }
  }
  .tbrow9{
    td{
    .ff;
    background-color:rgb(189, 152, 104);
    }
  }
  // .ivu-table td{
  //   background:transparent !important;
  // }

}

</style>





