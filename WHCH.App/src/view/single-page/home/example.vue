<style  lang="less">
@h: 700px;
@bcolor : #3e3e3e;
.example{
  .ct{
    width: 100%;
  }
  
  .hhh{
    border: 2px solid #00ff00;
    background-color: #ebf7eb;
    position: relative;
    overflow: hidden;
    .tt{
      position:absolute;
      left: -28px;
      top:12px;
      height: 32px;
      width: 120px;
      font-size: 22px;
      color:#fff;
      background-color: #f33;
      line-height: 28px;
      transform:rotate(-45deg);
      -ms-transform:rotate(-45deg); 	/* IE 9 */
      -moz-transform:rotate(-45deg); 	/* Firefox */
      -webkit-transform:rotate(-45deg); /* Safari 和 Chrome */
      -o-transform:rotate(-45deg); 	/* Opera */
      border: 2px solid #f33;
      text-align: center;
      // opacity: 0.8;
    }
  }
  .kk{
    li{
      border-bottom: 1px solid #ddd;
    }
    
  }
  .l{
    width: 10%;
    height: auto;
    min-height: @h;
    display:block;
    float: left;
    position: relative;
    .huo{
      position:absolute;
      right:10px;
      top:5px;
      z-index: 999;
      width: 30px;
      cursor: pointer;
    }
    .drop{
          height:40px;
          line-height:40px;
          font-size:16px;
          position:absolute;
          left: 30px;
          top: 5px;
          z-index: 999;
        }
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
          height:300px;
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


    <Modal
        v-model="rlsj.opened"
        width=800
        :title="rlsj.title">
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <Form :model="rlsj.fields" ref="formFuelpara"  label-position="top">
                  <Row :gutter="16">
                              <Col span="24">
                              <FormItem label="名称" prop="k_Name_kw">
                              <Input v-model="rlsj.fields.k_Name_kw" placeholder="请输入名称"/>
                              </FormItem>
                              </Col>
                          </Row>
                  <Row :gutter="16">
                              <Col span="12">
                              <FormItem label="入炉燃料量" prop="Chargingfuel">
                              <Input-number  v-model="rlsj.fields.chargingfuel"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          
                              <Col span="12">
                              <FormItem label="碳(收到基)" prop="Carbon">
                              <Input-number  v-model="rlsj.fields.carbon"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          </Row><Row :gutter="16">
                              <Col span="12">
                              <FormItem label="氢(收到基)" prop="Hydrogen">
                              <Input-number  v-model="rlsj.fields.hydrogen"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          
                              <Col span="12">
                              <FormItem label="氧(收到基)" prop="O2">
                              <Input-number  v-model="rlsj.fields.o2"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          </Row><Row :gutter="16">
                              <Col span="12">
                              <FormItem label="氮(收到基)" prop="Nitrogen">
                              <Input-number  v-model="rlsj.fields.nitrogen"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          
                              <Col span="12">
                              <FormItem label="硫(收到基)" prop="Sulfur">
                              <Input-number  v-model="rlsj.fields.sulfur"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          </Row><Row :gutter="16">
                              <Col span="12">
                              <FormItem label="水分(收到基)" prop="H2o">
                              <Input-number  v-model="rlsj.fields.h2o"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          
                              <Col span="12">
                              <FormItem label="灰分(收到基)" prop="Ashcontent">
                              <Input-number  v-model="rlsj.fields.ashcontent"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          </Row><Row :gutter="16">
                              <Col span="12">
                              <FormItem label="飞灰可燃物（含碳量）" prop="Flyashfuel">
                              <Input-number  v-model="rlsj.fields.flyashfuel"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          
                              <Col span="12">
                              <FormItem label="大渣可燃物（含碳量）" prop="Cinderfuel">
                              <Input-number  v-model="rlsj.fields.cinderfuel"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          </Row><Row :gutter="16">
                              <Col span="12">
                              <FormItem label="AH出口一氧化碳" prop="Co">
                              <Input-number  v-model="rlsj.fields.co"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          
                              <Col span="12">
                              <FormItem label="收到基低位发热量" prop="Calorificvalue">
                              <Input-number  v-model="rlsj.fields.calorificvalue"  style="width:100%"></Input-number>
                              </FormItem>
                              </Col>
                          </Row>
                </Form>
              </div>
              <div class="update-paste-btn-con">
                <span class="paste-tip"> </span>
                <Button type="primary" style="float: right;margin-left:9px;" @click="handleShow2(-1)">提交</Button>
                <Button type="warning" style="float: right;margin-left:9px;" @click="handleShow2(0)">修改</Button>
                <Button type="success" style="float: right;margin-left:9px;" @click="handleShow2(1)">应用</Button>
                
                
              </div>
            </Card>
          </i-col>
        </Row>
        <div slot="footer">
        </div>
    </Modal>



    <Modal
        v-model="modal.opened"
        width=800
        :title="modal.title">
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <Form :model="modal.fields" ref="formLzburn" :rules="modal.rules" label-position="top">
                    <Row :gutter="16">
                                <Col span="12">
                                <FormItem label="化验员" prop="OptionUser" >
                                  <Input v-model="modal.fields.OptionUser" placeholder="请输入化验员"/>
                                </FormItem>
                                </Col>
                            
                                <Col span="12">
                                <FormItem label="炉渣可燃物值" prop="Pvalue">
                                  <Input-number  v-model="modal.fields.Pvalue"  style="width:100%"></Input-number>
                                </FormItem>
                                </Col>
                            </Row>
                            <Row :gutter="16">
                                <Col span="24">
                                <FormItem label="飞灰可燃物" prop="FJson" >
                                <Row :gutter="16"  v-for="(itemRight, index) in modal.classes" :key="`dra2g_li2_${index}`">
                                  <Col span="12">
                                   {{itemRight.k_Name_kw}} ( {{itemRight.startTime}}-{{itemRight.endTime}} )
                                  </Col>
                                  <Col span="12">
                                  <InputNumber :min="0" v-model="modal.FJson[index]"></InputNumber>
                                  </Col>
                                </Row>
                                </FormItem>
                                </Col>
                            </Row>
                            <Row :gutter="16">
                                <Col span="24">
                                <FormItem label="备注" prop="Remark" >
                                  <Input v-model="modal.fields.Remark" placeholder="请输入备注"/>
                                </FormItem>
                                </Col>
                            </Row>
                  </Form>
              </div>
              <div class="update-paste-btn-con">
                <span class="paste-tip"> </span>
                <Button type="primary" style="float: right;" @click="handleShow">提交</Button>
              </div>
            </Card>
          </i-col>
        </Row>
        <div slot="footer">
        </div>
    </Modal>
    <Card style="width:300px;position:absolute;left:180px;top:10px;z-index:999;border:2px solid #f66 " class="kk"  v-if="rlsj.data3.length>0 && showd">
              <p slot="title" >
                  燃料数据
              </p>
              <ul type="none">
                  <li >
                      <span style="">碳(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].carbon}}
                      </span>
                  </li>

                  <li >
                      <span style="">氢(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].hydrogen}}
                      </span>
                  </li>

                  <li >
                      <span style="">氧(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].o2}}
                      </span>
                  </li>

                  <li >
                      <span style="">氮(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].nitrogen}}
                      </span>
                  </li>

                  <li >
                      <span style="">硫(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].sulfur}}
                      </span>
                  </li>

                  <li >
                      <span style="">水分(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].h2o}}
                      </span>
                  </li>

                  <li >
                      <span style="">灰分(收到基)</span>
                      <span style="float:right">
                          {{rlsj.data3[0].ashcontent}}
                      </span>
                  </li>

                  <li >
                      <span style="">飞灰可燃物（含碳量）</span>
                      <span style="float:right">
                          {{rlsj.data3[0].flyashfuel}}
                      </span>
                  </li>

                  <li >
                      <span style="">大渣可燃物（含碳量）</span>
                      <span style="float:right">
                          {{rlsj.data3[0].cinderfuel}}
                      </span>
                  </li>

                  <li >
                      <span style="">AH出口一氧化碳</span>
                      <span style="float:right">
                          {{rlsj.data3[0].co}}
                      </span>
                  </li>

                  <li >
                      <span style="">收到基低位发热量</span>
                      <span style="float:right">
                          {{rlsj.data3[0].calorificvalue}}
                      </span>
                  </li>

                  <li >
                      <span style="">入炉燃料量</span>
                      <span style="float:right">
                          {{rlsj.data3[0].chargingfuel}}
                      </span>
                  </li>
              </ul>
          </Card>
    <div class="l">
      <img :src="huo" class="huo" @mouseover="mov" @mouseout="mou"/>
      <Dropdown class="drop"  @on-click="drophld">
        <a href="javascript:void(0)" >
            {{boiler}}
            <Icon type="ios-arrow-down"></Icon>
        </a>
        <DropdownMenu slot="list" >
            <DropdownItem v-for="(item,index) in boilers" :selected="item.id==boilerid" :name="item.k_Name_kw"  v-bind:key="'iuyiy'+index">{{item.k_Name_kw}}</DropdownItem>
        </DropdownMenu>
      </Dropdown>
      <Menu :theme="'light'" active-name="0"  style="width:96%;margin-top:50px" @on-select="hanldselect">
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
            <div class="t2">{{zqll.toFixed(2)}}</div>
          </div>

          <div class="y">
            <div class="t1" style="font-size:16px;line-height:20px">锅炉效率<br>（正平衡）</div>
            <div class="t2">{{boilerPositive.toFixed(2)}}%</div>
          </div>

          <div class="y">
            <div class="t1" style="font-size:16px;line-height:20px">锅炉效率<br>（反平衡）</div>
            <div class="t2">{{boilerCounter.toFixed(2)}}%</div>
          </div>

          <div class="y">
            <div class="t1">主汽压力</div>
            <div class="t2">{{zqyl.toFixed(2)}}</div>
          </div>
        </div>
        <div class="r">
          <Card :bordered="false">
                <span slot="title"><b>吹灰列表</b></span>
                <div class="b">
                  <Row :gutter="16">
                    <Col span="6">序号</Col>
                    <!-- <Col span="8">区域</Col> -->
                    <Col span="6">吹灰器</Col>
                    <Col span="6">出现时间</Col>
                    <Col span="6">执行时间</Col>
                  </Row>
                  <Row :gutter="16" v-for="(item,index ) in v1_3 " class="qlist"  v-bind:key="'yyuytyu'+index">
                    <Col span="6">{{index+1}}</Col>
                    <!-- <Col span="8">{{item.k_Name_kw}}</Col> -->
                    <Col span="6">{{item.dncChqpoint_Name}}</Col>
                    <Col span="6">{{item.addTime}}</Col>
                    <Col span="6">{{item.runTime=='0001-01-01'?'':item.runTime}}</Col>
                  </Row>
                </div>
                  
                
          </Card>
        </div>
      </div>
      <Tabs value="name1" v-if="pagenow==1" name="tab1">
        <TabPane tab="tab1" label="锅炉效率" name="name1"><v-chart :options="n2_1" autoresize  class="ct"></v-chart></TabPane>
        <TabPane tab="tab1" label="床温" name="name2"><v-chart :options="n2_2" autoresize  class="ct"></v-chart></TabPane>
        <TabPane tab="tab1" label="壁温" name="name3">
          <Card :bordered="false">
          <Tabs value="biwen1" name="tab1_3">
              <TabPane tab="tab1_3" label="低温过热器" name="biwen1"><v-chart :options="n2_3_1" autoresize  class="ct"></v-chart></TabPane>
              <TabPane tab="tab1_3" label="屏式过热器" name="biwen2"><v-chart :options="n2_3_2" autoresize  class="ct"></v-chart></TabPane>
              <TabPane tab="tab1_3" label="高温过热器" name="biwen3"><v-chart :options="n2_3_3" autoresize  class="ct"></v-chart></TabPane>
          </Tabs>
          </Card>
        </TabPane>
      </Tabs>
      <Tabs value="tb2" v-if="pagenow==2">
        <TabPane label="灰渣可燃物" name="tb2">
          <Card :bordered="false">
                
                <span slot="title"><b>日期范围:</b><DatePicker  @on-change="handleSearch"  type="datetimerange" format="yyyy-MM-dd" placeholder="选择日期范围" style="width: 200px;margin-left:20px"></DatePicker>
                <Button type="primary" style="float:right;margin-right:10px" @click="handleadd">添加</Button></span>
                <!-- <span style="float:right"><Button type="primary">新增</Button></span> -->
                <div class="b">
                  <Row :gutter="16" class="qlist2h" >
                    <Col span="3">日期</Col>
                    <Col span="6">班次</Col>
                    <Col span="3">飞灰可燃物</Col>
                    <Col span="4">飞灰可燃物平均值</Col>
                    <Col span="3">炉渣可燃物</Col>
                    <Col span="3">化检员</Col>
                    <Col span="2">操作</Col>
                  </Row>
                  <Row :gutter="16"  class="qlist2"  type="flex" justify="center" align="middle"   v-for="(itemRight, index) in lzlist" :key="`drwwag_li2_${index}`" >
                    <Col span="3">{{itemRight.addTime}}</Col>
                    <Col span="6" style="padding-top:10px;padding-bottom:10px;">
                      <p style="height: 30px;line-height:30px" v-for="(item, i) in modal.classes" :key="`itemhzkkk_${i}`" >{{item.k_Name_kw}} {{item.startTime}}-{{item.endTime}}</p>
                    </Col>
                    <Col span="3" style="padding-top:10px;padding-bottom:10px;">
                      <p style="height: 30px;line-height:30px" v-for="(item, i) in  JSON.parse(itemRight.fJson)" :key="`itemhzkkk_${i}`" >{{item}}</p>
                    </Col>
                    <Col span="4">{{itemRight.fvalue}}</Col>
                    <Col span="3">{{itemRight.pvalue}}</Col>
                    <Col span="3">{{itemRight.optionUser}}</Col>
                    <Col span="2"><Button type="warning"  @click="handleup(itemRight)">修改</Button></Col>
                  </Row>

                </div>
                  
                
          </Card>
        </TabPane>
        <TabPane label="燃料数据" name="tb3">
          <Card style="width:300px;margin-left:8px;float:left;" :class="index==0?'hhh kk':'kk'"  v-for="(iii, index) in rlsj.data3" :key="`opppo2_${index}`">
              <div class="tt" v-if="index==0">使用中</div>
              <p slot="title" style="text-align: center;">
                  {{iii.k_Name_kw}}
              </p>
              <a href="#" slot="extra" @click="hd(iii)">
                  调整
              </a>
              <ul type="none">
                  <li >
                      <span style="">碳(收到基)</span>
                      <span style="float:right">
                          {{iii.carbon}}
                      </span>
                  </li>

                  <li >
                      <span style="">氢(收到基)</span>
                      <span style="float:right">
                          {{iii.hydrogen}}
                      </span>
                  </li>

                  <li >
                      <span style="">氧(收到基)</span>
                      <span style="float:right">
                          {{iii.o2}}
                      </span>
                  </li>

                  <li >
                      <span style="">氮(收到基)</span>
                      <span style="float:right">
                          {{iii.nitrogen}}
                      </span>
                  </li>

                  <li >
                      <span style="">硫(收到基)</span>
                      <span style="float:right">
                          {{iii.sulfur}}
                      </span>
                  </li>

                  <li >
                      <span style="">水分(收到基)</span>
                      <span style="float:right">
                          {{iii.h2o}}
                      </span>
                  </li>

                  <li >
                      <span style="">灰分(收到基)</span>
                      <span style="float:right">
                          {{iii.ashcontent}}
                      </span>
                  </li>

                  <li >
                      <span style="">飞灰可燃物（含碳量）</span>
                      <span style="float:right">
                          {{iii.flyashfuel}}
                      </span>
                  </li>

                  <li >
                      <span style="">大渣可燃物（含碳量）</span>
                      <span style="float:right">
                          {{iii.cinderfuel}}
                      </span>
                  </li>

                  <li >
                      <span style="">AH出口一氧化碳</span>
                      <span style="float:right">
                          {{iii.co}}
                      </span>
                  </li>

                  <li >
                      <span style="">收到基低位发热量</span>
                      <span style="float:right">
                          {{iii.calorificvalue}}
                      </span>
                  </li>

                  <li >
                      <span style="">入炉燃料量</span>
                      <span style="float:right">
                          {{iii.chargingfuel}}
                      </span>
                  </li>
              </ul>
          </Card>
          <!-- <Table :columns="rlsj.columns3" :data="rlsj.data3"></Table> -->
        </TabPane>
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


//工具包
import { getDateMore,sortBy,gradientColor,getDate ,eqarr} from "@/libs/tools";
import {
  getBoilerListAll
} from "@/api/ZNRS/Dncboiler";
import {
  getHzpointnowList
} from "@/api/ZNRS/Dnchzpointnow";
import {
  getHzpointList
} from "@/api/ZNRS/Dnchzpoint";
import {
  getChlistList
} from "@/api/ZNRS/Dncchlist";
import {
  getBoilerratList
} from "@/api/ZNRS/Dncboilerrat";
import {
  getLzburnListk,
  createLzburn
} from "@/api/ZNRS/Dnclzburn";
import {
  getClassesListAll
} from "@/api/ZNRS/Dncclasses";
import {
  getPointkks_dataList
} from "@/api/ZNRS/Dncpointkks_data";

import {
  getFuelparaList,
  createFuelpara
} from "@/api/ZNRS/Dncfuelpara";

import {
  getChareahisList
} from "@/api/ZNRS/Dncchareahis";

import { noxdata,n2_1,n2_2,n2_3_1,n2_3_2,n2_3_3, n4_1, n4_2, n4_3,n5_1, n5_2, n5_3,n5_4} from "@/api/echart/mkgl";
import huo from "@/assets/images/huo.png";
export default {
  name: 'home',
  components: {
    "v-chart": ECharts
  },
  data () {
    return {
      noxdata,n2_1,n2_2,n2_3_1,n2_3_2,n2_3_3, n4_1, n4_2, n4_3,n5_1, n5_2, n5_3,n5_4,huo,
      showd:false,
      rlsj:{
        data3:[],
        opened:false,
        title:"",
        fields:{
          DncBoiler_Name:"",
          Carbon:0,  
          Hydrogen:0,  
          O2:0,  
          Nitrogen:0,  
          Sulfur:0,  
          H2o:0,  
          Ashcontent:0,  
          Flyashfuel:0,  
          Cinderfuel:0,  
          Co:0,  
          Calorificvalue:0,  
          Chargingfuel:0,  
          RealTime:"",
          status: 1,
          isDeleted: 0
        }
      },
      pagenow:0,
      modal:{
        type:1,
        opened:false,
        title:"",
        fields:{
          OptionUser:"",
          AddTime:"",
          DncBoiler_Name:"",
          Pvalue:0,  
          Remark:"",
          Fvalue:0,  
          BJson:[],
          FJson:[],
          status: 1,
          isDeleted: 0
        },
        classes:[],
        rules:{}
      },
      name6:{
        data5:[],
        data6:[]
      },
      dat:[],
      lzlist:[],
      timer2:null,
      //机组
      boilertime:"",
      boilerid:-1,
      boiler:"",
      boilers:[],
      boilerPositive:"",//（正平衡）
      boilerCounter:"",//（反平衡）
      zqll:"",
      zqyl:"",

      v1_3:[],
    }
  },
  methods:{
    mov(){
      this.showd=true;
    },
    mou(){
      this.showd=false;
    },
    //机组加载
    initboiler(){
      let o=this;
      getBoilerListAll().then(res => {
        console.log(JSON.stringify(res.data.data));
          o.boilers=getDateMore(res.data.data,-1,["syntime",]);
          if(o.boilerid==-1){
            o.boiler=o.boilers[0].k_Name_kw;
            o.boilerid=o.boilers[0].id;
            o.boilertime=o.boilers[0].syntime;
            o.boilerPositive=o.boilers[0].positive;
            o.boilerCounter=o.boilers[0].counter;
          }else{
            o.boilers.map(x=>{
              if(x.id==o.boilerid){
                o.boilertime=x.syntime;
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
          this.boilerPositive=o.positive;
          this.boilerCounter=o.counter;
          this.refreshall(this.boilerid);
        }
      });
    },
    hanldselect(n){
      this.pagenow=n;
    },
    handleSearch(d){
      let o=this;
      this.dat=d;
      getLzburnListk({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: o.boilerid,
            dat:JSON.stringify(o.dat),
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,1,["addTime",]);
          o.lzlist=d;  
      });
    },
    hzburn(bid){
      
    },
    ViewData1(bid){
      let o=this;
      getHzpointList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            t:"10",
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,2,["realTime",]);
            //console.log(JSON.stringify(d));
            noxdata.xAxis.data=d.map(x=>{
              return x.realTime;
            }).reverse();

            noxdata.series[0].data = d.map(x=>{
              let arr=eval("("+x.pvalue+")") ;
              let sum=0;
              for (let index = 0; index < arr.length; index++) {
                sum+=arr[index];
              }
              return sum/arr.length;
            }).reverse();;
            // let reData = new Array(), i;
            // for (i = 0; i < 8; i++) {
            //     for (var j = state.length - 1; j >= 0; j--) {
            //         reData.push([i, j, state[j][i]]);
            //     }
            // }
            // let lll=reData.map(item=>{
            //   return  [item[1], item[0], item[2] || '-'];
            // })
            // leftdata.series[0].data = lll;
      });
      getHzpointnowList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            t:"12,11",
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,2,["realTime",]);
            if(d.filter(x=>x.dncTypeId==11)[0]){
              let v1= eval("("+d.filter(x=>x.dncTypeId==11)[0].pvalue+")")  ;//压力
              let s1=0;
              v1.map(x=>{
                s1+=x;
              });
              o.zqyl=s1/v1.length;
            }else{
              o.zqyl="";
            }
            if(d.filter(x=>x.dncTypeId==12)[0]){
              let v2= eval("("+d.filter(x=>x.dncTypeId==12)[0].pvalue+")")   ;//流量
              let s2=0;
              v2.map(x=>{
                s2+=x;
              });
              o.zqll=s2/v2.length;
            }else{
              o.zqll="";
            }
      });
      getChlistList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,1,["addTime","runTime",]);
          o.v1_3=d;
      });
    
    },
    ViewData2(bid){
      let o=this;
      getBoilerratList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,2,["realTime",]);
            n2_1.xAxis.data=d.map(x=>{
              return x.realTime;
            }).reverse();

            n2_1.series[0].data = d.map(x=>{
              return x.positive;
            }).reverse();

            n2_1.series[1].data = d.map(x=>{
              return x.counter;
            }).reverse();
      });

      getPointkks_dataList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,2,["realTime",]);

            let r=[];
            d.map(x=>{
              if(r.indexOf(x.realTime)==-1){
                r.push(x.realTime);
              }
            });
            let xz=r.reverse();
            n2_2.xAxis.data=xz;
            n2_3_1.xAxis.data=xz;
            n2_3_2.xAxis.data=xz;
            n2_3_3.xAxis.data=xz;

            n2_2.series[0].data = d.filter(x=>x.remarks=='左墙沸下温度').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_2.series[1].data = d.filter(x=>x.remarks=='右墙沸下温度').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_2.series[2].data = d.filter(x=>x.remarks=='右墙沸上温度').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_2.series[3].data = d.filter(x=>x.remarks=='前墙#1沸上温度').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_2.series[4].data = d.filter(x=>x.remarks=='前墙#2沸上温度').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_2.series[5].data = d.filter(x=>x.remarks=='前墙#3沸上温度').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_2.series[6].data = d.filter(x=>x.remarks=='右墙沸中温度').map(x=>{
              return x.pvalue;
            }).reverse();


            n2_3_1.series[0].data = d.filter(x=>x.remarks=='低温过热器壁温1').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_1.series[1].data = d.filter(x=>x.remarks=='低温过热器壁温2').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_1.series[2].data = d.filter(x=>x.remarks=='低温过热器壁温3').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_1.series[3].data = d.filter(x=>x.remarks=='低温过热器壁温4').map(x=>{
              return x.pvalue;
            }).reverse();
//屏式过热器
            n2_3_2.series[0].data = d.filter(x=>x.remarks=='屏式过热器壁温1').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_2.series[1].data = d.filter(x=>x.remarks=='屏式过热器壁温2').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_2.series[2].data = d.filter(x=>x.remarks=='屏式过热器壁温3').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_2.series[3].data = d.filter(x=>x.remarks=='屏式过热器壁温4').map(x=>{
              return x.pvalue;
            }).reverse();

            n2_3_3.series[0].data = d.filter(x=>x.remarks=='高温过热器壁温1').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_3.series[1].data = d.filter(x=>x.remarks=='高温过热器壁温2').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_3.series[2].data = d.filter(x=>x.remarks=='高温过热器壁温3').map(x=>{
              return x.pvalue;
            }).reverse();
            n2_3_3.series[3].data = d.filter(x=>x.remarks=='高温过热器壁温4').map(x=>{
              return x.pvalue;
            }).reverse();
      });
    },
    ViewData3(bid){
      let o=this;
      getLzburnListk({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            dat:JSON.stringify(o.dat),
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,1,["addTime",]);
          o.lzlist=d;  
      });

      getFuelparaList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
        o.rlsj.data3 = getDateMore(res.data.data,1,["realTime",]);
      });
    },
    ViewData5(bid){
      let o=this;
      getChareahisList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: bid,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,1,["realTime",]);
            //低过
            let dg=d.filter(x=>x.areaId==1);
            //省煤器
            let smq=d.filter(x=>x.areaId==2);
            //节能器
            let jnq=d.filter(x=>x.areaId==3);
            //空预器
            let kyq=d.filter(x=>x.areaId==4);

            //低过
            n4_1.xAxis.data=dg.map(x=>{
              return x.realTime;
            }).reverse();

            n4_1.series[0].data = dg.map(x=>{
              return x.wrl_Val;
            }).reverse();
            n4_1.series[1].markLine.data[0].yAxis=dg[0].wrldch_Val;
            n4_1.series[2].markLine.data[0].yAxis=dg[0].wrlexcu_Val;
            n4_1.tooltip.t1=dg[0].wrldch_Val;
            n4_1.tooltip.y=dg[0].wrlexcu_Val;

            //省煤器
            n4_2.xAxis.data=smq.map(x=>{
              return x.realTime;
            }).reverse();

            n4_2.series[0].data = smq.map(x=>{
              return x.wrl_Val;
            }).reverse();
            n4_2.series[1].markLine.data[0].yAxis=smq[0].wrldch_Val;
            n4_2.series[2].markLine.data[0].yAxis=smq[0].wrlexcu_Val;
            n4_2.tooltip.t1=smq[0].wrldch_Val;
            n4_2.tooltip.y=smq[0].wrlexcu_Val;

            //空预器
            n4_3.xAxis.data=kyq.map(x=>{
              return x.realTime;
            }).reverse();

            n4_3.series[0].data = kyq.map(x=>{
              return x.wrl_Val;
            }).reverse();
            n4_3.series[1].markLine.data[0].yAxis=kyq[0].wrldch_Val;
            n4_3.series[2].markLine.data[0].yAxis=kyq[0].wrlexcu_Val;
            n4_3.tooltip.t1=kyq[0].wrldch_Val;
            n4_3.tooltip.y=kyq[0].wrlexcu_Val;


            //低过
            n5_1.xAxis.data=dg.map(x=>{
              return x.realTime;
            }).reverse();

            n5_1.series[0].data = dg.map(x=>{
              return x.dsl_Val;
            }).reverse();
            n5_1.series[1].markLine.data[0].yAxis=dg[0].dslhigh_Val;
            n5_1.series[2].markLine.data[0].yAxis=dg[0].dslexcu_Val;
            n5_1.tooltip.t1=dg[0].dslhigh_Val;
            n5_1.tooltip.y=dg[0].dslexcu_Val;

            //省煤器
            n5_2.xAxis.data=smq.map(x=>{
              return x.realTime;
            }).reverse();

            n5_2.series[0].data = smq.map(x=>{
              return x.dsl_Val;
            }).reverse();
            n5_2.series[1].markLine.data[0].yAxis=smq[0].dslhigh_Val;
            n5_2.series[2].markLine.data[0].yAxis=smq[0].dslexcu_Val;
            n5_2.tooltip.t1=smq[0].dslhigh_Val;
            n5_2.tooltip.y=smq[0].dslexcu_Val;
            //节能器
            n5_3.xAxis.data=jnq.map(x=>{
              return x.realTime;
            }).reverse();

            n5_3.series[0].data = jnq.map(x=>{
              return x.dsl_Val;
            }).reverse();
            n5_3.series[1].markLine.data[0].yAxis=jnq[0].dslhigh_Val;
            n5_3.series[2].markLine.data[0].yAxis=jnq[0].dslexcu_Val;
            n5_3.tooltip.t1=jnq[0].dslhigh_Val;
            n5_3.tooltip.y=jnq[0].dslexcu_Val;
            //空预器
            n5_4.xAxis.data=kyq.map(x=>{
              return x.realTime;
            }).reverse();

            n5_4.series[0].data = kyq.map(x=>{
              return x.dsl_Val;
            }).reverse();
            n5_4.series[1].markLine.data[0].yAxis=kyq[0].dslhigh_Val;
            n5_4.series[2].markLine.data[0].yAxis=kyq[0].dslexcu_Val;
            n5_4.tooltip.t1=kyq[0].dslhigh_Val;
            n5_4.tooltip.y=kyq[0].dslexcu_Val;
      });
    },
    refreshall(bid){
      // console.log(bid);
      this.ViewData1(bid);
      this.ViewData2(bid);
      this.ViewData3(bid);
      this.ViewData5(bid);
    },



    handleadd(){
      let o=this;
      let date = new Date();
      this.modal.opened=true;
      this.modal.title="灰渣可燃物数据录入_"+date.getFullYear()+"年"+(date.getMonth()+1)+"月"+date.getDate()+"日 周"+(date.getDay()==0?"日":date.getDay())+" "+date.getHours()+":"+date.getMinutes()+"";
      this.modal.type=1;
      o.modal.fields.AddTime='';
      o.modal.fields.OptionUser='';
      o.modal.fields.Pvalue=0;
      o.modal.fields.Remark='';
      let b=[],t=[];
      o.modal.classes.map(x=>{
        b.push(x.id);
        t.push(0);
      });
      o.modal.BJson=b;
      o.modal.FJson=t;
    },
    handleup(p){
      let o=this;
      let date = new Date();
      o.modal.opened=true;
      o.modal.title=p.addTime+" 灰渣可燃物 数据更新";
      o.modal.type=0;
      o.modal.fields.OptionUser=p.optionUser;
      o.modal.fields.AddTime=p.addTime;
      o.modal.fields.DncBoiler_Name=o.boilerid;
      o.modal.fields.Pvalue=parseFloat(p.pvalue);
      o.modal.fields.Remark=p.remark;
      o.modal.BJson= JSON.parse(p.bJson);
      o.modal.FJson= JSON.parse(p.fJson);
    },
    ClearModal(){
      this.modal.opened=false;
      this.modal.title="";
      this.modal.type=1;
    },
    handleShow(){
      let o=this;
      let f=false;
      let pass=false;
      for (let index = 0; index < o.modal.FJson.length; index++) {
        let element = o.modal.FJson[index];
        if(element!=0){
          f=true;
        }
      }
      //录明细，不看大的，直接提交
      if (f) {
        pass=true;
      }else{
        if (o.modal.fields.OptionUser==''&& o.modal.fields.Pvalue==0) {
          pass=false;
        }else{
          pass=true;
        }
      }

      if(pass){
        //开始录入
        o.modal.fields.DncBoiler_Name=o.boilerid;
        let t=o.modal.FJson;
        let n=0,s=0;
        for (let index = 0; index < t.length; index++) {
          let x = t[index];
          if(x!=0){
            n++;
            s+=x;
          }
        }
     
        o.modal.fields.Fvalue=JSON.stringify(s/n);
        o.modal.fields.FJson=JSON.stringify(o.modal.FJson);
        o.modal.fields.BJson=JSON.stringify(o.modal.BJson);

        createLzburn(o.modal.fields).then(res => {
          if (res.data.code === 200) {
            o.$Message.success(res.data.message);
            o.ViewData3(o.boilerid);
          } else {
            o.$Message.warning(res.data.message);
          }
          o.ClearModal();
        });


      }else{
        o.$Message.error("请完善表单信息");
      }
    },
    
    handleShow2(k){
      let o=this;
      //提交-1   修改0  应用1
      //开始录入
      o.rlsj.fields.dncBoiler_Name=o.boilerid;
      o.rlsj.fields.status=k;
      createFuelpara(o.rlsj.fields).then(res => {
        if (res.data.code === 200) {
          o.$Message.success(res.data.message);

          getFuelparaList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            o.rlsj.data3 = getDateMore(res.data.data,1,["realTime",]);
            o.rlsj.opened=false;
          });
        } else {
          o.$Message.warning(res.data.message);
          o.rlsj.opened=false;
        }
        // o.rlsj.opened=false;
        
      });
    },
    hd(p){
      let o=this;
      let date = new Date();
      o.rlsj.opened=true;
      o.rlsj.title="燃料数据__"+p.k_Name_kw;
      o.rlsj.fields=p;
    }
  },
  mounted () {
    let o=this;
    getClassesListAll().then(res => {
      o.modal.classes = getDateMore(res.data.data,6,["startTime","endTime",]);
      // console.log(JSON.stringify(o.modal.classes));
      let b=[],t=[];
      o.modal.classes.map(x=>{
        b.push(x.id);
        t.push(0);
      });
      o.modal.BJson=b;
      o.modal.FJson=t;
    });
    getBoilerListAll().then(res => {
      o.boilers=getDateMore(res.data.data,-1,["syntime",]);
      o.boiler=o.boilers[0].k_Name_kw;
      o.boilerid=o.boilers[0].id;
      o.boilertime=o.boilers[0].syntime;
      o.boilerPositive=o.boilers[0].positive;
      o.boilerCounter=o.boilers[0].counter;
      o.refreshall(o.boilerid);
    });
    o.timer2=setInterval(() => {
      if(o.boilerid==-1){
        return;
      }
      o.refreshall(o.boilerid);
      clearInterval(this.timer2);
    }, 5000);
  },
  beforeDestroy() {
    clearInterval(this.timer2);
  }
}
</script>

<style lang="less">
.count-style{
  font-size: 50px;
}
</style>
