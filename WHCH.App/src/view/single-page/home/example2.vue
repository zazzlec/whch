<style scoped  lang="less">
@bcolor : #3e3e3e;

.xyq{
    background:#fff;
    padding:10px;
    width: 99%;
    display: block;
    overflow: hidden;
    position: relative;
    .logonull{
      width: 100%;
      text-align: center;
      height: 30px;
    }
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
      width: 100%;
      text-align: center;
      height: 30px;
      color:#fff;
      margin-top: -20px;
    }
    .l{
      border-radius: 10px;
      width: 60%;
      min-height: 600px;
      display:block;
      float: left;
      background-color:@bcolor;
      background-repeat:no-repeat;
      background-size:100% 100%;
      -moz-background-size:100% 100%;
      .ctl{
        margin-left: -6%;
        width: 112%;
        margin-top: -30px;
        height: 590px;
      }
      
    }
    .r{
      border-radius: 10px;
      width: 38%;
      min-height: 600px;
      display:block;
      float: left;
      margin-left: 2%;
      background-color: #e6e6e6;
      .item{
        height: 200px;
        width: 100%;
        position: relative;
      }
      .ct{
        width: 100%;
        height: 100%;
      }
    }

    .huikan{
      position:absolute;
      top: 2px;
      right: 26px;
      width: 36px;
      text-align: center;
      // border: 1px solid #999;
      font-size: 12px;
      color: #666;
      background-color: #eef;
      cursor: pointer;
      // border-radius: 5px;
      padding: 0px;
      display: block;
      height: 23px;
      line-height: 23px;
    }
}
  
</style>
<template>
<div class="xyq">

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

  <div class="l" :style="{backgroundImage: 'url(' + clogo + ')' }">
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
      <span style="margin-left:30px;font-size:13px;">点位轮播</span>
      <i-switch size="large" style="margin-left:3px;"  @on-change="change" v-model="run">
        <span slot="open">开启</span>
        <span slot="close">关闭</span>
      </i-switch>
      <!--<span style="margin-left:10px;font-size:13px;">{{boilertime}}</span>-->
    </div>
    <div class="logonull"></div>
    <v-chart :options="o2data" autoresize  class="ctl"  @click="handleTooltipClick" ref="lineBar_chart"></v-chart>
    <div class="logo2">
      <span style="font-size:13px;">最新时间：{{boilertime}}</span>
    </div>
  </div>
  <div class="r">
    <div class="item">
      <v-chart :options="rdata1val" autoresize  class="ct"></v-chart>
      <span v-if="!run"  class="huikan" @click="haldleBack('x')">回看</span>
    </div>
    <div class="item">
      <v-chart :options="rdata2val" autoresize  class="ct"></v-chart>
      <span v-if="!run" class="huikan" @click="haldleBack('y')">回看</span>
    </div>
    <div class="item">
      <v-chart :options="rdata3val" autoresize  class="ct"></v-chart>
      <span v-if="!run" class="huikan" @click="haldleBack('z')">回看</span>
    </div>
  </div>
  <div style="clear:both"></div>

  
</div>   
</template>

<script>
//工具包
import { getDateMore,sortBy } from "@/libs/tools";
//全局配置
import { global } from "@/api/echart/config";
//机组
import { getBoilerListAll } from "@/api/ZNRS/Dncboiler";
import { getExpand3dList } from "@/api/ZNRS/Dncexpand3d";
import { getExpand3d_baseList } from "@/api/ZNRS/Dncexpand3d_base";
// //燃烧状态
// import { getError_statusList } from "@/api/ZNRS/Dncerror_status";
// import { getHztemp_realList } from "@/api/ZNRS/Dnchztemp_real";
// //温度状态
// import { getSrm_parameterList } from "@/api/ZNRS/Dncsrm_parameter";
// //煤耗影响  Dnchztemp_real
// //沾污系数  Dnchztemp_real
// import { getFireerror_adviceList,editFireerror_advice,batchok } from "@/api/ZNRS/Dncfireerror_advice";
// //o2nox  Dnchztemp_real
// //模块概览
// import { getO2nox_pointList } from "@/api/ZNRS/Dnco2nox_point";

//echart数据
import { leftdata,rightdata1,rightdata2 } from "@/api/echart/rszt";
import { leftdata_2,leftdata_2_2,rightdata_2,rightdata_2_2 } from "@/api/echart/wdzt";
import { mhyx_1,mhyx_2 } from "@/api/echart/mhyx";
import { zwxs_now } from "@/api/echart/zwxs";
import { o2x1,o2x2 } from "@/api/echart/o2nox";
import { o2data,noxdata } from "@/api/echart/mkgl";



import clogo from "@/assets/images/expendbg.jpg";
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
// 点图
import "echarts/lib/chart/scatter";
import "echarts/lib/chart/effectScatter";

// import "echarts/lib/component/markPoint";
// import "echarts/lib/component/markLine";
// import "echarts/lib/component/graphic";
//标题




export default {
  name: "ZNRS_xyq_page",
  components: {
    "v-chart": ECharts
  },
  data() {
    return {
      huikan:{
        modal2:false,
        title:"",
        timebe:[],
        data:{}
      },
      hktime:1000,
      timer: '',

      run:true,
      run1:true,
      timer2: '',
      timesec:0,
      //机组
      boilertime:"",
      boilerid:-1,
      boiler:"",
      boilers:[],
      clogo,

      groups:[],
      grouppoints:[],
      points:[],
      pointindex:-1,
      o2data:{
                xAxis: [{ // 纵轴标尺固定
                    type: 'value',
                    scale: true,
                    max: 15,
                    min: -15,
                    splitNumber: 30,
                    show: false

                }],
                yAxis: [{ // 纵轴标尺固定
                    type: 'value',
                    scale: true,
                    max: 15,
                    min: -15,
                    splitNumber: 30,
                    show: false
                }],
                series: [
                         {
                            type: 'effectScatter',
                            symbolSize: 25,
                            color:'#00ff00',
                            data: [],
                            label: {
                                show: true,
                                color:'#000',
                                formatter: function (params) {
                                  var value = params.value;
                                  return value[2];
                                },
                            }
                        },
                        {
                            symbolSize: 20,
                            data: [],
                            type: 'scatter',
                            //type: 'effectScatter',
                            label: {
                                show: true,
                                formatter: function (params) {
                                  var value = params.value;
                                  return value[2];
                                },
                            }
                        },
                        {
                            type: 'scatter',
                            symbolSize: 20,
                            color:'#FFFF00',
                            data: [],
                            label: {
                                show: true,
                                color:'#000',
                                formatter: function (params) {
                                  var value = params.value;
                                  return value[2];
                                },
                            }
                        },
                       
                        ],
                tooltip: {
                  formatter: []
                },        
      },
      alldata:[],
      rdata1val:{},
      rdata2val:{},
      rdata3val:{},
      rdata1val_back:{},
      rdata2val_back:{},
      rdata3val_back:{},
      rdata1:(p,t,r)=>{
        let text="";
        let data1=[];
        let data2=[];
        let data3=[];
        let data5=[];
        if(t==1){
          text=p[2]+'号测点 X轴膨胀检测数据';
          data1=this.alldata.filter(x=>x.dncexpand3d_baseId==p[3]).map(x=>{
            data2.push(p[4][0]);
            data3.push(p[4][1]);
            data5.push(p[4][2]);
            return x.r_X_expand;
          })
        }else if(t==2){
          text=p[2]+'号测点 Y轴膨胀检测数据';
          data1=this.alldata.filter(x=>x.dncexpand3d_baseId==p[3]).map(x=>{
            data2.push(p[5][0]);
            data3.push(p[5][1]);
            data5.push(p[5][2]);
            return x.r_Y_expand;
          })
        }else if(t==3){
          text=p[2]+'号测点 Z轴膨胀检测数据';
          data1=this.alldata.filter(x=>x.dncexpand3d_baseId==p[3]).map(x=>{
            data2.push(p[6][0]);
            data3.push(p[6][1]);
            data5.push(p[6][2]);
            return x.r_Z_expand;
          })
        }
        return {
                            title: {
                                left: 'center',
                                text: text
                             },
                            legend: {
                                //data: ['实测值','额定值', '上限值', '下限值'],
                                data: ['实测值', '上限值', '下限值'],
                                x: "center",
                                y: "25px",

                                textStyle: {
                                    fontSize: 12,//字体大小
                                    color: '#3e3e3e'//字体颜色
                                }
                            },
                            tooltip: {
                                trigger: 'axis',
                                showContent: true
                            },

                            xAxis: {
                                type: 'category',
                                axisLabel: {
                                    show: true,
                                    textStyle: {
                                        color: '#3e3e3e'
                                    },
                                    rotate: 45
                                },
                                data: r
                   
                            },
                            yAxis: {
                                gridIndex: 0,
                                splitNumber:1,
                                show: true,
                                axisLabel: {
                                    show: true,
                                    textStyle: {
                                        color: '#3e3e3e'
                                    }
                                },
                                scale: true
                            },
                            series: [
                                {
                                    name: '实测值',
                                    type: 'line',
                                    smooth: true,
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                            }
                                        }
                                    },
                                    seriesLayoutBy: 'row',
                                    data: data1
                                },
                                {
                                    name: '额定值',
                                    type: 'line',
                                    smooth: true,
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                            }
                                        }
                                    },
                                    seriesLayoutBy: 'row',
                                    //data: data5
                                },
                                {
                                    name: '上限值',
                                    type: 'line',
                                    smooth: false,
                                    seriesLayoutBy: 'row',
                                    areaStyle: {
                                        color:'#9DE49d',
                                        origin:'start',
                                    },
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                                type: 'dotted',

                                            }
                                        }
                                    },
                                    data: data2
                                },
                                {
                                    name: '下限值',
                                    type: 'line',
                                    smooth: false,
                                    seriesLayoutBy: 'row',
                                    areaStyle: {
                                        color:'#C8DDC8',
                                        origin:'start',
                                        opacity:1
                                    },
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                                type: 'dotted',

                                            }
                                        }
                                    },
                                    data: data3
                                }
                            ]
        }                 
      },


      rdata1_back:(a,p,t,r)=>{
        console.log(JSON.stringify(a));
        console.log("-------------------");
        
        console.log(JSON.stringify(p));console.log("-------------------");
        console.log(t);console.log("-------------------");
        console.log(JSON.stringify(r));

        let text="";
        let data1=[];
        let data2=[];
        let data3=[];
        let data5=[];
        if(t==1){
          text=p[2]+'号测点 X轴膨胀检测 历史数据';
          data1=a.filter(x=>x.dncexpand3d_baseId==p[3]).map(x=>{
            data2.push(p[4][0]);
            data3.push(p[4][1]);
            data5.push(p[4][2]);
            return x.r_X_expand;
          })
        }else if(t==2){
          text=p[2]+'号测点 Y轴膨胀检测 历史数据';
          data1=a.filter(x=>x.dncexpand3d_baseId==p[3]).map(x=>{
            data2.push(p[5][0]);
            data3.push(p[5][1]);
            data5.push(p[5][2]);
            return x.r_Y_expand;
          })
        }else if(t==3){
          text=p[2]+'号测点 Z轴膨胀检测 历史数据';
          data1=a.filter(x=>x.dncexpand3d_baseId==p[3]).map(x=>{
            data2.push(p[6][0]);
            data3.push(p[6][1]);
            data5.push(p[6][2]);
            return x.r_Z_expand;
          })
        }
        return {
                            toolbox: {
                                feature: {
                                    saveAsImage: {}
                                }
                            },
                            dataZoom:[{
                                type: 'inside',
                                start: 90,
                                end: 100
                            }, {
                                bottom:"0%", 
                                handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
                                handleSize: '80%',
                                handleStyle: {
                                    color: '#fff',
                                    shadowBlur: 3,
                                    shadowColor: '#11111',
                                    shadowOffsetX: 2,
                                    shadowOffsetY: 2
                                }
                            }],
                            title: {
                                left: 'center',
                                text: text
                             },
                            legend: {
                                //data: ['实测值','额定值', '上限值', '下限值'],
                                data: ['实测值', '上限值', '下限值'],
                                x: "center",
                                y: "25px",

                                textStyle: {
                                    fontSize: 12,//字体大小
                                    color: '#3e3e3e'//字体颜色
                                }
                            },
                            tooltip: {
                                trigger: 'axis',
                                showContent: true
                            },

                            xAxis: {
                                type: 'category',
                                axisLabel: {
                                    show: true,
                                    textStyle: {
                                        color: '#3e3e3e'
                                    },
                                    rotate: 45
                                },
                                data: r
                   
                            },
                            yAxis: {
                                gridIndex: 0,
                                splitNumber:1,
                                show: true,
                                axisLabel: {
                                    show: true,
                                    textStyle: {
                                        color: '#3e3e3e'
                                    }
                                },
                                scale: true
                            },
                            series: [
                                {
                                    name: '实测值',
                                    type: 'line',
                                    smooth: true,
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                            }
                                        }
                                    },
                                    seriesLayoutBy: 'row',
                                    data: data1
                                },
                                {
                                    name: '额定值',
                                    type: 'line',
                                    smooth: true,
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                            }
                                        }
                                    },
                                    seriesLayoutBy: 'row',
                                    //data: data5
                                },
                                {
                                    name: '上限值',
                                    type: 'line',
                                    smooth: false,
                                    seriesLayoutBy: 'row',
                                    areaStyle: {
                                        color:'#9DE49d',
                                        origin:'start',
                                    },
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                                type: 'dotted',

                                            }
                                        }
                                    },
                                    data: data2
                                },
                                {
                                    name: '下限值',
                                    type: 'line',
                                    smooth: false,
                                    seriesLayoutBy: 'row',
                                    areaStyle: {
                                        color:'#C8DDC8',
                                        origin:'start',
                                        opacity:1
                                    },
                                    itemStyle: {
                                        normal:
                                        {
                                            lineStyle: {
                                                width: 2,
                                                type: 'dotted',

                                            }
                                        }
                                    },
                                    data: data3
                                }
                            ]
        }                 
      }
    }
  },
  computed: {},
  methods: {
    drophld(name){
      this.boilers.map(o=>{
        if(o.k_Name_kw==name){
          this.boilerid=o.id;
          this.boiler=o.k_Name_kw;
          this.boilertime=o.syntime;
          console.log(this.boilertime);
          this.loadXYQList(this.boilerid,1);
        }
      });
      
    },
    loadXYQList(bid,t) {
      let o=this;
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
          getExpand3d_baseList({
            totalCount: 0,
            pageSize: 100,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid: data,
            sort: [
              {
                direct: "ASC",
                field: "r_GroupId"
              }
            ]
          }).then(res => {
            
            //异常点计算
            o.grouppoints=res.data.data.filter(x=>x.dncexpandgroupId!=0);
            o.groups = o.groupBy(o.grouppoints, (item) => {
              return [item.dncexpandgroupId];
            });
            
            o.o2data.series[1].data=res.data.data.map(x=>{
              return [x.r_X_axis,x.r_Y_axis,parseInt(x.r_GroupId),x.id,[x.r_X_up,x.r_X_down,x.r_X_ed],[x.r_Y_up,x.r_Y_down,x.r_Y_ed],[x.r_Z_up,x.r_Z_down,x.r_Z_ed]];
            });

            o.points=sortBy(o.o2data.series[1].data,2);
            //console.log(JSON.stringify(o.points));
            if(t==1){
              o.pointindex=-1;
            }



            getExpand3dList({
              totalCount: 0,
              pageSize: 1000,
              currentPage: 1,
              kw: "",
              isDeleted: 0,
              status: 1,
              boilerid: data,
              sort: [
                {
                  direct: "ASC",
                  field: "realTime"
                }
              ]
            }).then(res => {
              let d= getDateMore(res.data.data,5,["realTime"]);
              o.alldata=d.reverse(); ;

              o.o2data.tooltip.formatter=(param)=>{
                var value = param.value;
                let r={};

                for (let index = d.length-1; index >=0; index--) {
                  if(d[index]["dncexpand3d_baseId"]+""==value[3]+""){
                    r=d[index];
                    break;
                  }
                }
                return   '<div style="border-bottom: 1px solid rgba(255,255,255,.3); font-size: 16px;padding-bottom: 7px;margin-bottom: 7px;"> '
                                  + 'X:' + r.r_X_expand + '; Y:' + r.r_Y_expand + '; Z:' + r.r_Z_expand + ';<br/>'+ r.dncexpand3d_base_Name+
                                      '<br/></div>';   
              }

              let errpoints=[];
              o.groups.map(x=>{
                //循环组别
                let sumz=0;
                x.map(y=>{
                  let newz=0;
                  for (let index = d.length-1; index >=0; index--) {
                    if(d[index]["dncexpand3d_baseId"]+""==y["id"]+""){
                      newz=d[index].r_Z_expand;
                      break;
                    }
                  }
                  sumz+=newz;
                });
                let avg=(sumz/x.length).toFixed(2);

                x.map(y=>{
                  let newz=0;
                  for (let index = d.length-1; index >=0; index--) {
                    if(d[index]["dncexpand3d_baseId"]+""==y["id"]+""){
                      newz=d[index].r_Z_expand;
                      break;
                    }
                  }
                  let mo=Math.abs(newz-avg);
                  if(mo > parseFloat( y.z_errornum) ){
                    errpoints.push([y.r_X_axis,y.r_Y_axis,parseInt(y.r_GroupId),y.id,[y.r_X_up,y.r_X_down,y.r_X_ed],[y.r_Y_up,y.r_Y_down,y.r_Y_ed],[y.r_Z_up,y.r_Z_down,y.r_Z_ed]]);
                  }
                });
              });

              o.o2data.series[2].data=errpoints;


            });

            
          });

          
        }
      });


    },
    bindright(val,t){
      
      let o=this;

      o.o2data.series[0].data=[val];

      let realtime=this.alldata.filter(x=>x.dncexpand3d_baseId==val[3]).map(x=>{
        return x.realTime;
      });
      o.rdata1val=o.rdata1(val,1,realtime);
      o.rdata2val=o.rdata1(val,2,realtime);
      o.rdata3val=o.rdata1(val,3,realtime);

      if(t==0){
        o.pointindex=o.nextgroup(val[2]);
      }
      
      if(t==1){
        this.run1=false;
        setTimeout(() => {
          this.run1=true;
        }, 5000);
      }
    },

    nextgroup(gp){
      let o=this;
      let r=0;
      for (let index = 0; index < o.points.length; index++) {
        if(gp==o.points[index][2]){
          if(index==o.points.length-1){
            r=o.points[0][2];
            break;
          }else{
            r=o.points[index+1][2];
            break;
          }
        }
      }

      return r;
    },
    handleTooltipClick(val) {
      //this.$Message.info(val.data[2]+ ' 号测点');
      this.bindright(val.data,1);
    },
    change (status) {
      if(status){
        this.$Message.info('点位轮播已打开');
      }else{
        this.$Message.warning('点位轮播已关闭');
      }        
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

      huikandata=o.rdata1val_back;
      getExpand3dList({
              totalCount: 0,
              pageSize: 1000,
              currentPage: 1,
              kw: "",
              isDeleted: 0,
              status: -1,
              boilerid: o.boilerid,
              btime:d1,
              etime:d2,
              sort: [
                {
                  direct: "ASC",
                  field: "realTime"
                }
              ]
            }).then(res => {
              let d= getDateMore(res.data.data,5,["realTime"]);
              let ralldata=d.reverse();
              
              
              let val=o.o2data.series[0].data[0];

              let realtime=ralldata.filter(x=>x.dncexpand3d_baseId==val[3]).map(x=>{
                return x.realTime;
              });

              if(title=="x"){
                huikandata=o.rdata1_back(ralldata,val,1,realtime);
              }else if(title=='y'){
                huikandata=o.rdata1_back(ralldata,val,2,realtime);
              }else if(title=='z'){
                huikandata=o.rdata1_back(ralldata,val,3,realtime);
              }

              o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
            };

      });

      
    },
    groupBy(array, f) {
      const groups = {};
      array.forEach(function (o) {
        const group = JSON.stringify(f(o));
        groups[group] = groups[group] || [];
        groups[group].push(o);
      });
      return Object.keys(groups).map(function (group) {
        return groups[group];
      });
    }
  },
  mounted() {
    this.loadXYQList(null,0);
    this.timer2 =setInterval(() => {
      
        //秒数走
        this.timesec += 3;
      //   points:[],
      // pointindex:0,
        
        if(this.run && this.run1){
          if(this.points.length==0){

          }else{
            if(this.pointindex==-1){
              this.pointindex=this.points[0][2];
            }
            //this.$Message.info(this.pointindex+ ' 号测点');
            for (let index = 0; index < this.points.length; index++) {
              if(this.pointindex==this.points[index][2]){
                this.bindright(this.points[index],0);
                break;
              }
            }
          }
        } 
        
        //1分钟请求下数据
        if(this.timesec % 60 == 0){
          if(this.boilerid==-1){
            this.loadXYQList(null,0);
          }else{
            this.loadXYQList(this.boilerid,0);
          }
        }
        
      
    }, 3000);//3秒一次
  },
  beforeDestroy() {
    clearInterval(this.timer2);
  }
};
</script>






