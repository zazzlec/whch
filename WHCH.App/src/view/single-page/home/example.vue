<style  lang="less">
@h: 700px;
@bcolor : #3e3e3e;
.example{
  .ct{
    width: 100%;
  }
  .l{
    width: 10%;
    height: auto;
    min-height: @h;
    display:block;
    float: left;
    // border: 1px solid red;
    padding-top: 38px;
  }
  .r{
    width: 90%;
    height: auto;
    min-height: @h;
    display:block;
    float: left;
    border: 1px solid #ddd;
    .qlist2{
          font-weight: normal !important;
          font-size: 13px;
          border-bottom: 1px solid #eee;
          text-align: center;
        }
    .qlist2h{
      color:#fff;
      background-color: #666;
      text-align: center;
      height: 36px;
      line-height: 36px;
    }
    .m{
      width: 100%;
      height: auto;
      min-height: @h;
      // border:1px solid red;
      .l{
        width: 45%;
        height: auto;
        min-height: @h;
        // border:1px solid red;
        display:block;
        float: left;
      }
      .c{
        width: 10%;
        height: auto;
        min-height: @h;
        // border:1px solid red;
        display:block;
        float: left;
        .y{
          width: 90%;
          height: 70px;
          margin-left: 5%;
          border: 3px solid #111;
          float: left;
          margin-top: 20px;
          border-radius: 15px;
          .t1{
            height: 38px;
            color: #111;
            font-size: 20px;
            line-height: 38px;
            text-align: center;
            font-weight: bold;
          }
          .t2{
            height: 32px;
            border: 1px solid #ddd;
            border-radius: 15px;
            float: left;
            width: 100%;
            height: 28px;
            line-height: 28px;
            font-size: 22px;
            font-family: EEE;
            color:greenyellow;
            background-color: #000;
            text-align: center;
            letter-spacing:2px;
          }
        }
      }
      .r{
        width: 45%;
        height: auto;
        min-height: @h;
        // border:1px solid red;
        display:block;
        float: left;
        .ivu-tabs-nav-wrap {
          text-align: center;
        }
        .ivu-card-body{
          padding: 11px;
        }
        .ivu-tabs-nav-container{
          font-size: 13px;
        }
        .t{
          display: block;
          padding-top: 5px;
          padding-left:5px;
          width:100%;
          height: 250px;
          background-color: @bcolor;
          border-radius: 5px;
          color: aliceblue;
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
          margin-top: 3px;
          display: block;
          width:100%;
          height:189px;
          background-color: @bcolor;
          .ivu-col{
            height: 30px;
            line-height: 32px;
            color: aliceblue;
          }
          overflow-y:auto;
          overflow-x: hidden;
        }
        .qlist{
          font-weight: normal !important;
          font-size: 13px;
        }
      }
    }
  }
}
</style>
<template  >
  <div class="example"  :style="{width:'100%',height:'100%',margin:'0px',padding:'0px' }">
    <div class="l">
      <Menu :theme="'light'" active-name="0"  style="width:96%" @on-select="hanldselect">
            <MenuItem name="0">
                主界面
            </MenuItem>
            <MenuItem name="1">
                锅炉状态
            </MenuItem>
            <MenuItem name="2">
                燃料数据
            </MenuItem>
            <MenuItem name="3">
                污染状态
            </MenuItem>
            <MenuItem name="5">
                堵塞状态
            </MenuItem>
      </Menu>
    </div>
    <div class="r">
      <div class="m" v-if="pagenow==0">
        <div class="l">
          <v-chart :options="noxdata" autoresize  class="ct"></v-chart>
        </div>
        <div class="c">
          <div class="y">
            <div class="t1">主汽流量</div>
            <div class="t2">25.22</div>
          </div>

          <div class="y">
            <div class="t1" style="font-size:16px;line-height:20px">锅炉效率<br>（正平衡）</div>
            <div class="t2">25.22</div>
          </div>

          <div class="y">
            <div class="t1" style="font-size:16px;line-height:20px">锅炉效率<br>（反平衡）</div>
            <div class="t2">25.22</div>
          </div>

          <div class="y">
            <div class="t1">主汽压力</div>
            <div class="t2">25.22</div>
          </div>
        </div>
        <div class="r">
          <Card :bordered="false">
                <span slot="title"><b>燃烧调整建议</b></span>
                <div class="b">
                  <Row :gutter="16">
                    <Col span="3">序号</Col>
                    <Col span="8">区域</Col>
                    <Col span="4">吹灰器</Col>
                    <Col span="4">出现时间</Col>
                    <Col span="3">执行时间</Col>
                  </Row>
                  <Row :gutter="16" v-for="(item,index ) in name6.data6 " class="qlist"  v-bind:key="'yyuytyu'+index">
                    <Col span="3">{{item.id}}</Col>
                    <Col span="8">{{item.t}}</Col>
                    <Col span="4">{{item.t1}}</Col>
                    <Col span="4"><span :title="item.p">{{item.t2}}</span></Col>
                    <Col span="3">
                    
                    </Col>
                  </Row>
                </div>
                  
                
          </Card>
        </div>
      </div>
      <Tabs value="name1" v-if="pagenow==1">
        <TabPane label="锅炉效率" name="name1"><v-chart :options="n2_1" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="床温" name="name2"><v-chart :options="n2_2" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="壁温" name="name3"><v-chart :options="n2_3" autoresize  class="ct"></v-chart></TabPane>
      </Tabs>
      <Tabs value="name1" v-if="pagenow==2">
        <TabPane label="灰渣可燃物" name="name1">
          <Card :bordered="false">
                <span slot="title"><b>灰渣可燃物</b></span>
                <!-- <span style="float:right"><Button type="primary">新增</Button></span> -->
                <div class="b">
                  <Row :gutter="16" class="qlist2h" >
                    <Col span="3">日期</Col>
                    <Col span="8">班次</Col>
                    <Col span="4">飞灰可燃物</Col>
                    <Col span="4">炉渣可燃物</Col>
                    <Col span="3">化检员</Col>
                    <Col span="2">操作</Col>
                  </Row>
                  <Row :gutter="16"  class="qlist2"  type="flex" justify="center" align="middle" >
                    <Col span="3">2021-2-1</Col>
                    <Col span="8" style="padding-top:10px;padding-bottom:10px;">
                      <p style="height: 30px;line-height:30px">8:00-12:00</p>
                      <p style="height: 30px;line-height:30px">8:00-12:00</p>
                      <p style="height: 30px;line-height:30px">8:00-12:00</p>
                    </Col>
                    <Col span="4" style="padding-top:10px;padding-bottom:10px;">
                      <p style="height: 30px;line-height:30px">22</p>
                      <p style="height: 30px;line-height:30px">33</p>
                      <p style="height: 30px;line-height:30px">33</p>
                    </Col>
                    <Col span="4">123</Col>
                    <Col span="3">123</Col>
                    <Col span="2"><Button type="warning">修改</Button></Col>
                  </Row>

                </div>
                  
                
          </Card>
        </TabPane>
        <TabPane label="燃料数据" name="name2"><v-chart :options="n3_2" autoresize  class="ct"></v-chart></TabPane>
      </Tabs>
      <Tabs value="name1" v-if="pagenow==3">
        <TabPane label="低过" name="name1"><v-chart :options="n4_1" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="省煤器" name="name2"><v-chart :options="n4_2" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="空预器" name="name3"><v-chart :options="n4_3" autoresize  class="ct"></v-chart></TabPane>
      </Tabs>
      <Tabs value="name1" v-if="pagenow==5">
        <TabPane label="低过" name="name1"><v-chart :options="n5_1" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="省煤器" name="name2"><v-chart :options="n5_2" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="节能器" name="name3"><v-chart :options="n5_3" autoresize  class="ct"></v-chart></TabPane>
        <TabPane label="空预器" name="name4"><v-chart :options="n5_4" autoresize  class="ct"></v-chart></TabPane>
      </Tabs>
    </div>
    
  
  </div>
</template>

<script>
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
//ziti
import EEE from "@/assets/font/iconfont.css";


import { noxdata,n2_1,n2_2,n2_3,n3_2, n4_1, n4_2, n4_3,n5_1, n5_2, n5_3,n5_4} from "@/api/echart/mkgl";

export default {
  name: 'home',
  components: {
    "v-chart": ECharts
  },
  data () {
    return {
      noxdata,n2_1,n2_2,n2_3,n3_2, n4_1, n4_2, n4_3,n5_1, n5_2, n5_3,n5_4,
      pagenow:0,
      name6:{
        data5:[],
        data6:[]
      }
    }
  },
  methods:{
    hanldselect(n){
      this.pagenow=n;
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
