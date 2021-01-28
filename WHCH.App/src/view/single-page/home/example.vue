<style lang="less">
@bcolor : #3e3e3e;

.ec{
  .ct{
    width: 100%;
  }
  position: relative;
  .ivu-tabs-nav-wrap {
    text-align: right;
  }
  .ivu-tabs-nav-scroll {
    display: inline-block;
  }
  .logo{
    position:absolute;
    left: 8px;
    top: 0px;
    width: 580px;
    height: 30px;
    img{
      height: 100%;
      vertical-align:middle;
    }
  }
  .rszt{
    background:#eee;
    padding:20px;
    width: 100%;
    height: auto;
    display: block;
    .l{
      width: 53%;
      min-height: 100px;
      display:block;
      float: left;
    }
    .r{
      width: 45%;
      min-height: 100px;
      display:block;
      float: left;
      margin-left: 2%;
      .ivu-tabs-nav-wrap {
        text-align: center;
      }
      .ivu-card-body{
        padding: 11px;
      }
      .ivu-tabs-nav-container{
        font-size: 13px;
      }
      
    }
  }
  .wdzt{
    background:#eee;
    padding:20px;
    width: 100%;
    height: auto;
    display: block;
    .l{
      width: 49%;
      min-height: 100px;
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
    }
    .r{
      width: 49%;
      min-height: 100px;
      display:block;
      float: left;
      margin-left: 2%;
      .ivu-tabs-nav-wrap {
        text-align: center;
      }
      .ivu-card-body{
        padding: 11px;
      }
      .ivu-tabs-nav-container{
        font-size: 13px;
      }
    }
  }
  .mhyx{
    background:#eee;
    padding:20px;
    width: 100%;
    height: auto;
    display: block;
    .q{
      width: 99%;
      min-height: 100px;
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
    }
  }

  .dwxs{
    background:#eee;
    padding:20px;
    width: 100%;
    height: auto;
    display: block;
    .lm{
      width: 59%;
      min-height: 100px;
      display:block;
      float: left;
      .ivu-tabs-nav-wrap {
        text-align: left;
      }
      .ivu-card-body{
        padding: 11px;
      }
      .ivu-tabs-nav-container{
        font-size: 13px;
      }
    }
    .rr{
      width: 39%;
      min-height: 100px;
      display:block;
      float: left;
      margin-left: 2%;
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
        margin-top: 8px;
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


  .o2{
    background:#eee;
    padding:20px;
    width: 100%;
    height: auto;
    display: block;
    .q{
      width: 99%;
      min-height: 100px;
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
    }
  }

  .huikan{
    position:absolute;
    top: 12px;
    right: 6px;
    width: 58px;
    text-align: center;
    border: 1px solid #999;
    font-size: 12px;
    color: #666;
    background-color: #eef;
    cursor: pointer;
    border-radius: 5px;
    padding: 3px;
    
  }
  // .ivu-slider{
  //   margin-top:10px !important;
  // }
  .ivu-slider-wrap {
    height: 10px !important;
  }
  .ivu-slider-bar{
    height: 10px !important;
  }
}
  
</style>
<template>
<div class="ec">
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


   <Tabs name="name1"  :value="'ffffff'">
        <TabPane label="燃烧状态" tab="name1" icon="ios-bonfire-outline" >
          <div class="rszt">
            <div class="l">
              <Card :bordered="false">
                <span slot="title"><b>燃烧状态异常展示图</b></span>
                <v-chart :options="leftdata" autoresize  class="ct"></v-chart>
                <span class="huikan" @click="haldleBack('燃烧状态异常展示图')"><icon type="md-skip-backward"/> 回看</span>
              </Card>
            </div>
            <div class="r">
              <Card :bordered="false">
                <Tabs name="name1-1"  type="card"  size="small"  v-model="tab.tab_rszt">
                  <TabPane label="左右侧各级焓增对(kj/kg)" tab="name1-1"   name="tab_rszt_1">
                    <v-chart :options="rightdata1" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="左右侧各级出口汽温对比" tab="name1-1"    name="tab_rszt_2">
                    <v-chart :options="rightdata2" autoresize  class="ct"></v-chart>
                  </TabPane>
                </Tabs>
                <span v-if="tab.tab_rszt=='tab_rszt_1'" class="huikan" style="background-color: #fee;" @click="haldleVedio('左右侧各级焓增对(kj/kg)')"><icon type="ios-videocam"/>焓增</span>
                <span v-if="tab.tab_rszt=='tab_rszt_2'" class="huikan" style="background-color: #fee;" @click="haldleVedio('左右侧各级出口汽温对比')"><icon type="ios-videocam"/>汽温</span>
              </Card>
            </div>
            
            <div style='clear:both'></div>
          </div>
        </TabPane>
        <TabPane label="温度状态" tab="name1" icon="ios-thermometer-outline">
          <div class="wdzt">
            <div class="l">
              <Card :bordered="false">
                <Tabs name="name2-1"  type="card"  size="small" v-model="tab.tab_wdzt_l">
                  <TabPane label="高温再热器出口温度对比图" tab="name2-1" name="tab_wdzt_l_1" >
                    <v-chart :options="leftdata_2" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="高温再热器出口温度左右偏差图" tab="name2-1"  name="tab_wdzt_l_2">
                    <v-chart :options="leftdata_2_2" autoresize  class="ct"></v-chart>
                  </TabPane>
                </Tabs>
                <span v-if="tab.tab_wdzt_l=='tab_wdzt_l_1'" class="huikan" @click="haldleBack('高温再热器出口温度对比图')"><icon type="md-skip-backward"/>对比图</span>
                <span v-if="tab.tab_wdzt_l=='tab_wdzt_l_2'" class="huikan" @click="haldleBack('高温再热器出口温度左右偏差图')"><icon type="md-skip-backward"/>偏差图</span>
              </Card>
            </div>
            <div class="r">
              <Card :bordered="false">
               <Tabs name="name3-1"  type="card"  size="small" v-model="tab.tab_wdzt_r">
                  <TabPane label="末级过热器出口温度对比图" tab="name3-1"  name="tab_wdzt_r_1">
                    <v-chart :options="rightdata_2" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="末级过热器出口温度左右偏差图" tab="name3-1" name="tab_wdzt_r_2" >
                    <v-chart :options="rightdata_2_2" autoresize  class="ct"></v-chart>
                  </TabPane>
                </Tabs>
                <span v-if="tab.tab_wdzt_r=='tab_wdzt_r_1'" class="huikan" @click="haldleBack('末级过热器出口温度对比图')"><icon type="md-skip-backward"/>对比图</span>
                <span v-if="tab.tab_wdzt_r=='tab_wdzt_r_2'" class="huikan" @click="haldleBack('末级过热器出口温度左右偏差图')"><icon type="md-skip-backward"/>偏差图</span>
              </Card>
            </div>
            <div style='clear:both'></div>
          </div>
        </TabPane>
        <TabPane label="煤耗影响" tab="name1" icon="ios-trending-up">
          <div class="mhyx">
            <div class="q">
              <Card :bordered="false">
                <Tabs name="name4-1"  type="card"  size="small" v-model="tab.tab_mhyx">
                  <TabPane label="所有因素对煤耗的影响程度" tab="name4-1"   name="tab_mhyx_1">
                    <v-chart :options="mhyx_1" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="不同因素对煤耗的影响程度" tab="name4-1"   name="tab_mhyx_2">
                    <v-chart :options="mhyx_2" autoresize  class="ct"></v-chart>
                  </TabPane>
                </Tabs>
                <span v-if="tab.tab_mhyx=='tab_mhyx_1'" class="huikan" style="width:98px" @click="haldleBack('所有因素对煤耗的影响程度')"><icon type="md-skip-backward"/>所有因素</span>
                <span v-if="tab.tab_mhyx=='tab_mhyx_2'" class="huikan" style="width:98px" @click="haldleBack('不同因素对煤耗的影响程度')"><icon type="md-skip-backward"/>不同因素</span>
              </Card>
            </div>
            <div style='clear:both'></div>
          </div>
        </TabPane>
        <TabPane label="沾污系数" tab="name1" icon="ios-aperture-outline" >
          <div class="dwxs">
            <div class="lm">
              <Card :bordered="false">
                <span slot="title"><b>各个受热面沾污程度(系数)</b></span>
                <Tabs name="name5-1"  type="card"  size="small" v-model="tab.tab_dwxs">
                  <TabPane label="低温过热器" tab="name5-1"   name="tab_dwxs_1">
                    <v-chart :options="zwxs_1" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="分隔屏过热器" tab="name5-1" name="tab_dwxs_2" >
                    <v-chart :options="zwxs_2" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="后屏过热器" tab="name5-1"   name="tab_dwxs_3">
                    <v-chart :options="zwxs_3" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="末级过热器" tab="name5-1"   name="tab_dwxs_4">
                    <v-chart :options="zwxs_4" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="低温再热器" tab="name5-1"   name="tab_dwxs_5">
                    <v-chart :options="zwxs_5" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane label="高温再热器" tab="name5-1"   name="tab_dwxs_6">
                    <v-chart :options="zwxs_6" autoresize  class="ct"></v-chart>
                  </TabPane>
                </Tabs>
                <span v-if="tab.tab_dwxs=='tab_dwxs_1'" class="huikan" style="top:55px;right:10px" @click="haldleBack('低温过热器')"><icon type="md-skip-backward"/>低过</span>
                <span v-if="tab.tab_dwxs=='tab_dwxs_2'" class="huikan" style="top:55px;right:10px" @click="haldleBack('分隔屏过热器')"><icon type="md-skip-backward"/>分隔屏</span>
                <span v-if="tab.tab_dwxs=='tab_dwxs_3'" class="huikan" style="top:55px;right:10px" @click="haldleBack('后屏过热器')"><icon type="md-skip-backward"/>后屏</span>
                <span v-if="tab.tab_dwxs=='tab_dwxs_4'" class="huikan" style="top:55px;right:10px" @click="haldleBack('末级过热器')"><icon type="md-skip-backward"/>高过</span>
                <span v-if="tab.tab_dwxs=='tab_dwxs_5'" class="huikan" style="top:55px;right:10px" @click="haldleBack('低温再热器')"><icon type="md-skip-backward"/>低再</span>
                <span v-if="tab.tab_dwxs=='tab_dwxs_6'" class="huikan" style="top:55px;right:10px" @click="haldleBack('高温再热器')"><icon type="md-skip-backward"/>高再</span>
              </Card>
            </div>
            <div class="rr">
              <Card :bordered="false">
                <span slot="title"><b>吹灰调整建议</b></span>
                <div class="t">
                  <List  size="small" >
                    <ListItem  v-for="item in name3.data5 ">
                        <ListItemMeta :avatar="item.pic" :title="item.tit" :description="item.ad" />
                    </ListItem>
                  </List>
                </div>
                <div class="b">
                  <Row :gutter="16">
                    <Col span="3">编号</Col>
                    <Col span="5">类型</Col>
                    <Col span="3">状态</Col>
                    <Col span="4">出现时间</Col>
                    <Col span="4">确认时间</Col>
                    <Col span="3"><Button type="primary" size="small" @click="handleall">一键确认</Button></Col>
                  </Row>
                  <Row :gutter="16" v-for="item in name3.data6 " class="qlist">
                    <Col span="3">{{item.id}}</Col>
                    <Col span="5">{{item.t}}</Col>
                    <Col span="3">{{item.s}}</Col>
                    <Col span="4">{{item.t1}}</Col>
                    <Col span="4"><span :title="item.p">{{item.t2}}</span></Col>
                    <Col span="3">
                    <Button v-if="item.t2!=''" type="success" size="small" style="width:64px">已确定</Button>
                    <Button v-if="item.t2==''" type="error" size="small" style="width:64px" @click="handleqr(item.id)">请确认</Button>
                    </Col>
                  </Row>
                </div>
                  
                
              </Card>
            </div>
            <div style='clear:both'></div>
          </div>
        </TabPane>
        <TabPane :label="lable5" tab="name1">
          <div class="o2">
            <div class="q">
              <Card :bordered="false">
                <Tabs name="name6-1"  type="card"  size="small"   v-model="tab.tab_o2">
                  <TabPane :label="o2l1" tab="name6-1"  name="tab_o2_1">
                    <v-chart :options="o2x1" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane :label="o2l2" tab="name6-1"  name="tab_o2_2">
                    <v-chart :options="o2x2" autoresize  class="ct"></v-chart>
                  </TabPane>
                </Tabs>
                <span v-if="tab.tab_o2=='tab_o2_1'" class="huikan" style="width:98px" @click="haldleBack('O2(%)平均值与预期值对比图')"><icon type="md-skip-backward"/>O<sub>2</sub></span>
                <span v-if="tab.tab_o2=='tab_o2_2'" class="huikan" style="width:98px" @click="haldleBack('NOx(mp/Nm3)平均值与预期值对比图')"><icon type="md-skip-backward"/>NO<sub>x</sub></span>
              </Card>
            </div>
            <div style='clear:both'></div>
          </div>
        </TabPane>
        <TabPane label="模块概览" tab="name1"  icon="ios-options-outline"  name="ffffff">
          <div class="dwxs">
            <div class="lm">
              <Card :bordered="false">
                <Tabs name="name5-1"  type="card"  size="small" v-model="tab.tab_dwxs">
                  <TabPane :label="ll1" tab="name5-1"   name="tab_dwxs_1">
                    <v-chart :options="o2data" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane :label="ll2" tab="name5-1"   name="tab_dwxs_2">
                    <v-chart :options="noxdata" autoresize  class="ct"></v-chart>
                  </TabPane>
                  <TabPane :label="ll3" tab="name5-1"   name="tab_dwxs_3">
                    <img style="width:100%"  :src="mm" />
                  </TabPane>
                </Tabs>
                <!-- <span v-if="tab.tab_dwxs=='tab_dwxs_1'" class="huikan" style="background-color: #fee;" @click="haldleVedio('O2测点分布图')"><icon type="ios-videocam"/>O<sub>2</sub></span>
                <span v-if="tab.tab_dwxs=='tab_dwxs_2'" class="huikan" style="background-color: #fee;" @click="haldleVedio('NOx测点分布图')"><icon type="ios-videocam"/>NO<sub>x</sub></span> -->
              </Card>
            </div>
            <div class="rr">
              <Card :bordered="false">
                <span slot="title"><b>燃烧调整建议</b></span>
                <div class="t">
                  <List  size="small" >
                      <ListItem  v-for="item in name6.data5 ">
                        <ListItemMeta avatar="" :title="item.tit" :description="item.ad" />
                      </ListItem>
                  </List>
                </div>
                <div class="b">
                  <Row :gutter="16">
                    <Col span="3">编号</Col>
                    <Col span="8">类型</Col>
                    <Col span="4">出现时间</Col>
                    <Col span="4">确认时间</Col>
                    <Col span="3"><Button type="primary" size="small" @click="handleall6">一键确认</Button></Col>
                  </Row>
                  <Row :gutter="16" v-for="item in name6.data6 " class="qlist">
                    <Col span="3">{{item.id}}</Col>
                    <Col span="8">{{item.t}}</Col>
                    <Col span="4">{{item.t1}}</Col>
                    <Col span="4"><span :title="item.p">{{item.t2}}</span></Col>
                    <Col span="3">
                    <Button v-if="item.t2!=''" type="success" size="small" style="width:64px">已确定</Button>
                    <Button v-if="item.t2==''" type="error" size="small" style="width:64px" @click="handleqr6(item.id)">请确认</Button>
                    </Col>
                  </Row>
                </div>
                  
                
              </Card>
            </div>
            <div style='clear:both'></div>
          </div>
        </TabPane>
    </Tabs>

    <div class="logo">
      <!-- <img :src="clogo"  /> -->
      <Dropdown style="height:30px;line-height:30px;font-size:15px;margin-left:30px" @on-click="drophld">
        <a href="javascript:void(0)" style="color:#000;">
            {{boiler}}
            <Icon type="ios-arrow-down"></Icon>
        </a>
        <DropdownMenu slot="list" >
            <DropdownItem v-for="(item,index) in boilers" :selected="item.id==boilerid" :name="item.k_Name_kw">{{item.k_Name_kw}}</DropdownItem>
        </DropdownMenu>
      </Dropdown>
      <span style="margin-left:30px;font-size:13px;">实时刷新</span>
      <i-switch size="large" style="margin-left:3px;"  @on-change="change" v-model="run">
        <span slot="open">开启</span>
        <span slot="close">关闭</span>
      </i-switch>
      <span style="margin-left:10px;font-size:13px;">{{boilertime}}</span>
    </div>
</div>   
</template>

<script>
//工具包
import { getDateMore } from "@/libs/tools";
//全局配置
import { global } from "@/api/echart/config";
//机组
import { getBoilerListAll } from "@/api/ZNRS/Dncboiler";
//燃烧状态
import { getError_statusList } from "@/api/ZNRS/Dncerror_status";
import { getHztemp_realList } from "@/api/ZNRS/Dnchztemp_real";
//温度状态
import { getSrm_parameterList } from "@/api/ZNRS/Dncsrm_parameter";
//煤耗影响  Dnchztemp_real
//沾污系数  Dnchztemp_real
import { getFireerror_adviceList,editFireerror_advice,batchok } from "@/api/ZNRS/Dncfireerror_advice";
//o2nox  Dnchztemp_real
//模块概览
import { getO2nox_pointList } from "@/api/ZNRS/Dnco2nox_point";



import { leftdata,leftdata_back,rightdata1,rightdata2,rightdata1_back,rightdata2_back } from "@/api/echart/rszt";
import { leftdata_2,leftdata_2_back,leftdata_2_2,leftdata_2_2_back,rightdata_2,rightdata_2_back,rightdata_2_2,rightdata_2_2_back} from "@/api/echart/wdzt";
import { mhyx_1,mhyx_1_back,mhyx_2,mhyx_2_back } from "@/api/echart/mhyx";
import { zwxs_now,zwxs_now_back } from "@/api/echart/zwxs";
import { o2x1,o2x2,o2x1_back,o2x2_back } from "@/api/echart/o2nox";
import { o2data,o2data_back,noxdata,noxdata_back } from "@/api/echart/mkgl";


import highico from "@/assets/images/high.png";
import lowico from "@/assets/images/low.png";
import clogo from "@/assets/images/logo-shdq.svg";
import mm from "@/assets/images/wdc.png";
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



export default {
  name: "ZNRS_ecdemo_page",
  components: {
    "v-chart": ECharts
  },
  data() {
    return {
      tab:{
        //回看tab
        tab_wdzt_l:"tab_wdzt_l_1",
        tab_wdzt_r:"tab_wdzt_r_1",
        tab_mhyx:"tab_mhyx_1",
        tab_dwxs:"tab_dwxs_1",
        tab_o2:"tab_o2_1",
        //播放tab
        tab_rszt:"tab_rszt_1",
        tab_dwxs:"tab_dwxs_1"
      },

      mm,
      huikan:{
        modal2:false,
        title:"",
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


      timer: '',
      run:true,
      clogo,
      //自定义标签
      lable5:(h)=>{
        return h("div", [
          h("i", {class:'ivu-icon ivu-icon-ios-timer-outline'}),
          h("span","O"),
          h("sub","2"),
          h("span","/NO"),
          h("sub","x")
        ]);
      },
      o2l1:(h)=>{
        return h("div",[
          h("span","O"),
          h("sub","2"),
          h("span","(%)平均值与预期值对比图")
        ]);
      },
      o2l2:(h)=>{
        return h("div",[
          h("span","NO"),
          h("sub","x"),
          h("span","(mp/Nm"),
          h("sup","3"),
          h("span",")平均值与预期值对比图"),
        ]);
      },
      ll1:(h)=>{
        return h("div",[
          h("span","O"),
          h("sub","2"),
          h("span","测点分布图")
        ]);
      },
      ll2:(h)=>{
        return h("div",[
          h("span","NO"),
          h("sub","x"),
          h("span","测点分布图")
        ]);
      },
      ll3:(h)=>{
        return h("div",[
          h("span","温度场")
        ]);
      },
      //机组
      boilertime:"",
      boilerid:-1,
      boiler:"",
      boilers:[],
      //燃烧状态
      leftdata,
      leftdata_back,
      rightdata1,rightdata1_back,
      rightdata2,rightdata2_back,
      //温度状态
      leftdata_2,leftdata_2_back,
      leftdata_2_2,leftdata_2_2_back,
      rightdata_2,rightdata_2_back,
      rightdata_2_2,rightdata_2_2_back,
      //煤耗影响
      mhyx_1,mhyx_1_back,
      mhyx_2,mhyx_2_back,
      //沾污系数
      zwxs_1:{},
      zwxs_2:{},
      zwxs_3:{},
      zwxs_4:{},
      zwxs_5:{},
      zwxs_6:{},
      name3:{
        data5:[],
        data6:[]
      },
      //O2/NOx
      o2x1,o2x1_back,
      o2x2,o2x2_back,
      name5:{

      },
      //模块概览
      o2data,o2data_back,
      noxdata,noxdata_back,
      name6:{
        data5:[],
        data6:[]
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
          this.loadECharList(this.boilerid);
        }
      });
      
    },
    loadECharList(bid) {
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
          //燃烧状态
          getError_statusList({
            totalCount: 0,
            pageSize: global.x_num,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: data,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,2,["realTime",]);
            //console.log(JSON.stringify(d));
            leftdata.xAxis.data=d.map(x=>{
              return x.realTime;
            }).reverse();
            let state =d.map(x=>{
              return [
              x.leftqy_xxbz,
              x.rightqy_xxbz,
              x.leftqy_qxbz,
              x.rightqy_qxbz,
              x.leftqy_px,
              x.rightqy_px,
              x.cxbj,
              x.normal
              ].reverse()
            }).reverse();
            let reData = new Array(), i;
            for (i = 0; i < 8; i++) {
                for (var j = state.length - 1; j >= 0; j--) {
                    reData.push([i, j, state[j][i]]);
                }
            }
            let lll=reData.map(item=>{
              return  [item[1], item[0], item[2] || '-'];
            })
            leftdata.series[0].data = lll;
          });


          getHztemp_realList({
            totalCount: 0,
            pageSize: global.x_num,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            boilerid: data,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let l= res.data.data[0];
            
            //左右
            rightdata1.series[1].data=[
              -(l.dg_hz_a+l.dg_hz_b)/2,
              -(l.fgp_hz_a+l.fgp_hz_b)/2,
              -(l.hp_hz_a+l.hp_hz_b)/2,
              -(l.mg_hz_a+l.mg_hz_b)/2,
              -l.dz_hz_left,
              -l.gz_hz_left
            ].reverse();
            rightdata1.series[0].data=[
              (l.dg_hz_c+l.dg_hz_d)/2,
              (l.fgp_hz_c+l.fgp_hz_d)/2,
              (l.hp_hz_c+l.hp_hz_d)/2,
              (l.mg_hz_c+l.mg_hz_d)/2,
              l.dz_hz_right,
              l.gz_hz_right
            ].reverse();

            rightdata2.series[1].data=[
              -l.dg_temp_out_left,
              -l.fgp_temp_out_left,
              -l.hp_temp_out_left,
              -l.mg_temp_out_left,
              -l.dz_temp_out_left,
              -l.gz_temp_out_left
            ].reverse();

            rightdata2.series[0].data=[
              l.dg_temp_out_right,
              l.fgp_temp_out_right,
              l.hp_temp_out_right,
              l.mg_temp_out_right,
              l.dz_temp_out_right,
              l.gz_temp_out_right
            ].reverse();

            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度
            leftdata_2.xAxis.data=realtime;
            leftdata_2.series[0].data=k.map(x=>{ 
              return (x.gz_temp_out_right + x.gz_temp_out_left )/2
            });
            leftdata_2.series[4].data=k.map(x=>{ return x.yl_fh_out});

            leftdata_2_2.xAxis[0].data=realtime;
            leftdata_2_2.series[0].data=k.map(x=>{ 
              return ((x.gz_temp_out_left - x.gz_temp_out_right )/2).toFixed(2)
            });
            leftdata_2_2.series[0].itemStyle.normal.color=(param)=>{
              return k.map(x=>{ 
                return (x.gz_temp_out_left - x.gz_temp_out_right )>=0?"#C23531":"#2F4554"
              })[param.dataIndex]
            } 

            rightdata_2_2.xAxis[0].data=realtime;
            rightdata_2_2.series[0].data=k.map(x=>{ 
              return ((x.mg_temp_out_left - x.mg_temp_out_right )/2).toFixed(2)
            });
            rightdata_2_2.series[0].itemStyle.normal.color=(param)=>{
              return k.map(x=>{ 
                return (x.mg_temp_out_left - x.mg_temp_out_right )>=0?"#C23531":"#2F4554"
              })[param.dataIndex]
            } 


            rightdata_2.xAxis.data=realtime;
            rightdata_2.series[0].data=k.map(x=>{ 
              return (x.mg_temp_out_right + x.mg_temp_out_left )/2
            });
            rightdata_2.series[4].data=k.map(x=>{ return x.yl_fh_out});


            //煤耗
            mhyx_2.xAxis[0].data=realtime;
            mhyx_2.series[0].data=k.map(x=>{return x.dz_jws_mh.toFixed(2) });
            mhyx_2.series[1].data=k.map(x=>{return x.gz_temp_mh.toFixed(2) });
            mhyx_2.series[2].data=k.map(x=>{return x.mg_temp_mh.toFixed(2) });

            mhyx_1.xAxis[0].data=realtime;
            mhyx_1.series[0].data=k.map(x=>{return (x.dz_jws_mh + x.gz_temp_mh + x.mg_temp_mh).toFixed(2) });

            

            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: data,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              leftdata_2.series[1].data=k.map(x=>{ 
                return res.data.data[0].gz_out_temp_ed;
              });
              leftdata_2.series[2].data=k.map(x=>{ 
                return res.data.data[0].gz_out_temp_high;
              });
              leftdata_2.series[3].data=k.map(x=>{ 
                return res.data.data[0].gz_out_temp_low;
              });

              rightdata_2.series[1].data=k.map(x=>{ 
                return res.data.data[0].mg_out_temp_ed;
              });
              rightdata_2.series[2].data=k.map(x=>{ 
                return res.data.data[0].mg_out_temp_high;
              });
              rightdata_2.series[3].data=k.map(x=>{ 
                return res.data.data[0].mg_out_temp_low;
              });

              //沾污系数
              let d1=k.map(x=>{ return res.data.data[0].dg_zwxs_high;});
              let d2=k.map(x=>{ return x.dg_zwxs.toFixed(2);});
              let d3=k.map(x=>{ return res.data.data[0].dg_zwxs_low;});
              o.zwxs_1= zwxs_now("dg",realtime,d1,d2,d3);

              d1=k.map(x=>{ return res.data.data[0].fgp_zwxs_high;});
              d2=k.map(x=>{ return x.fgp_zwxs.toFixed(2);});
              d3=k.map(x=>{ return res.data.data[0].fgp_zwxs_low;});
              o.zwxs_2=zwxs_now("fgp",realtime,d1,d2,d3);

              d1=k.map(x=>{ return res.data.data[0].hp_zwxs_high;});
              d2=k.map(x=>{ return x.hp_zwxs.toFixed(2);});
              d3=k.map(x=>{ return res.data.data[0].hp_zwxs_low;});
              o.zwxs_3=zwxs_now("hp",realtime,d1,d2,d3);
              
              d1=k.map(x=>{ return res.data.data[0].mg_zwxs_high;});
              d2=k.map(x=>{ return x.mg_zwxs.toFixed(2);});
              d3=k.map(x=>{ return res.data.data[0].mg_zwxs_low;});
              o.zwxs_4=zwxs_now("mg",realtime,d1,d2,d3);
             
              d1=k.map(x=>{ return res.data.data[0].dz_zwxs_high;});
              d2=k.map(x=>{ return x.dz_zwxs.toFixed(2);});
              d3=k.map(x=>{ return res.data.data[0].dz_zwxs_low;});
              o.zwxs_5=zwxs_now("dz",realtime,d1,d2,d3);

              d1=k.map(x=>{ return res.data.data[0].gz_zwxs_high;});
              d2=k.map(x=>{ return x.gz_zwxs.toFixed(2);});
              d3=k.map(x=>{ return res.data.data[0].gz_zwxs_low;});
              o.zwxs_6=zwxs_now("gz",realtime,d1,d2,d3);


              //o2x
              o2x1.xAxis[0].data=realtime;
              o2x1.series[1].data=k.map(x=>{return x.o2_avg.toFixed(2) });
              o2x1.series[0].data=k.map(x=>{return x.o2_high.toFixed(2) });
              o2x1.series[2].data=k.map(x=>{return x.o2_low.toFixed(2) });
              o2x1.series[3].data=k.map(x=>{return x.yl_fh_out.toFixed(2) });

              o2x2.xAxis[0].data=realtime;
              o2x2.series[1].data=k.map(x=>{return x.nox_avg.toFixed(2) });
              o2x2.series[0].data=k.map(x=>{return x.nox_high.toFixed(2) });
              o2x2.series[2].data=k.map(x=>{return x.nox_low.toFixed(2) });
              o2x2.series[3].data=k.map(x=>{return x.yl_fh_out.toFixed(2) });

              
            });
          });

          getO2nox_pointList({
              totalCount: 0,
              pageSize: 100,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: data,
              boilertime: o.boilertime,
              sort: [
                {
                  direct: "ASC",
                  field: "id"
                }
              ]
            }).then(res => {
              let t=res.data.data;
              let h=t[0];
              let hj=eval("("+h.ovalue+")");
              let mp={"1":"一","2":"二","3":"三","4":"四","5":"五","6":"六","7":"七","8":"八","9":"九","10":"十"};
              let hours=[];
              for (let index = 0; index < hj.length; index++) {
                hours.push("左"+mp[""+(index+1)]);
              }
              for (let index = 0; index < hj.length; index++) {
                hours.push("右"+mp[""+(index+1)]);
              }
              o2data.xAxis.data=hours;
              noxdata.xAxis.data=hours;
              let sd1=[],sd2=[],sd3=[];
              let nox1=[],nox2=[],nox3=[];
              t.map(x=>{
                let d=[];
                if(x.dncTypeId==40){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ sd1.push(x) });
                }else if(x.dncTypeId==43){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ sd1.push(x) });
                }else if(x.dncTypeId==41){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ sd2.push(x) });
                }else if(x.dncTypeId==44){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ sd2.push(x) });
                }else if(x.dncTypeId==42){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ sd3.push(x) });
                }else if(x.dncTypeId==45){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ sd3.push(x) });
                }else if(x.dncTypeId==46){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ nox1.push(x) });
                }else if(x.dncTypeId==49){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ nox1.push(x) });
                }else if(x.dncTypeId==47){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ nox2.push(x) });
                }else if(x.dncTypeId==50){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ nox2.push(x) });
                }else if(x.dncTypeId==48){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ nox3.push(x) });
                }else if(x.dncTypeId==51){
                  d=eval("("+x.ovalue+")");
                  d.map(x=>{ nox3.push(x) });
                }
              })
              let i=0,j=0,k=0;
              o2data.series[0].data=sd1.map(x=>{
                return [0,i++,parseFloat(x.toFixed(2))]
              }).concat(
                sd2.map(x=>{
                  return [1,j++,parseFloat(x.toFixed(2))]
                })
              ).concat(
                sd3.map(x=>{
                  return [2,k++,parseFloat(x.toFixed(2))]
                })
              ).map(function (item) {
                  return [item[1], item[0],  item[2] || '-'];
              });
              
              i=0;j=0;k=0;
              noxdata.series[0].data=nox1.map(x=>{
                return [0,i++,parseFloat(x.toFixed(2))]
              }).concat(
                nox2.map(x=>{
                  return [1,j++,parseFloat(x.toFixed(2))]
                })
              ).concat(
                nox3.map(x=>{
                  return [2,k++,parseFloat(x.toFixed(2))]
                })
              ).map(function (item) {
                  return [item[1], item[0],  item[2] || '-'];
              });
              //console.log(JSON.stringify(nox3));
              //console.log(JSON.stringify(noxdata.series[0].data));
              
          });
          
          getFireerror_adviceList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: data,
              boilertime: o.boilertime,
              t: "1",
              sort: [
                {
                  direct: "ASC",
                  field: "dnctypeid"
                }
              ]
            }).then(res => {
              o.name3.data5=res.data.data.map(x=>{
                let t=x.dncType_Name+"_"+(x.evalue==1?"偏高":"偏低");
                return { "ad" : x.advice , "tit": t ,"pic" : (x.evalue==1?highico:lowico) }
              });
              o.name3.data6=res.data.data.map(x=>{
                return { 
                  "id": x.id,
                  "t" : x.dncType_Name.replace("沾污异常","") , 
                  "s" : (x.evalue==1?"偏高":"偏低") ,
                  "t1" :  x.realTime.substr(11,9) ,
                  "t2" :  x.checkTime?x.checkTime.substr(11,9):"",
                  "p" : x.checkPerson
                }
              });
          });

          getFireerror_adviceList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: data,
              boilertime: o.boilertime,
              t: "2",
              sort: [
                {
                  direct: "ASC",
                  field: "dnctypeid"
                }
              ]
            }).then(res => {
              o.name6.data5=res.data.data.map(x=>{
                let t=x.dncType_Name;
                return { "ad" : x.advice , "tit": t ,"pic" : (x.evalue==1?highico:lowico) }
              });
              o.name6.data6=res.data.data.map(x=>{
                return { 
                  "id": x.id,
                  "t" : x.dncType_Name.replace("沾污异常","") , 
                  "s" : (x.evalue==1?"偏高":"偏低") ,
                  "t1" :  x.realTime.substr(11,9) ,
                  "t2" :  x.checkTime?x.checkTime.substr(11,9):"",
                  "p" : x.checkPerson
                }
              });
          });


        }
      });

    },
    handleqr(id){
      let o=this;
      //this.$store.state.user.userName
      
      editFireerror_advice({id:id,CheckPerson:this.$store.state.user.userName,DncBoilerId:o.boilerid}).then(res => {
        if(res.data.code==500){
          this.$Modal.error({
            title: '提示',
            content: res.data.message
            ,onOk: () => {
              this.loadECharList(this.boilerid);
            }
          })
        }else{
          getFireerror_adviceList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              boilertime: o.boilertime,
              t: "1",
              sort: [
                {
                  direct: "ASC",
                  field: "dnctypeid"
                }
              ]
            }).then(res => {
              o.name3.data6=res.data.data.map(x=>{
                return { 
                  "id": x.id,
                  "t" : x.dncType_Name.replace("沾污异常","") , 
                  "s" : (x.evalue==1?"偏高":"偏低") ,
                  "t1" :  x.realTime.substr(11,9) ,
                  "t2" :  x.checkTime?x.checkTime.substr(11,9):""
                }
              });
          });
        }
      });
    },
    handleqr6(id){
      let o=this;
      //this.$store.state.user.userName
      
      editFireerror_advice({id:id,CheckPerson:this.$store.state.user.userName,DncBoilerId:o.boilerid}).then(res => {
        if(res.data.code==500){
          this.$Modal.error({
            title: '提示',
            content: res.data.message
            ,onOk: () => {
              this.loadECharList(this.boilerid);
            }
          })
        }else{
          getFireerror_adviceList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              boilertime: o.boilertime,
              t: "2",
              sort: [
                {
                  direct: "ASC",
                  field: "dnctypeid"
                }
              ]
            }).then(res => {
              o.name6.data6=res.data.data.map(x=>{
                return { 
                  "id": x.id,
                  "t" : x.dncType_Name.replace("沾污异常","") , 
                  "s" : (x.evalue==1?"偏高":"偏低") ,
                  "t1" :  x.realTime.substr(11,9) ,
                  "t2" :  x.checkTime?x.checkTime.substr(11,9):""
                }
              });
          });
        }
        
      });
    },
    handleall(){
      let o=this;

      if(o.name3.data6.filter(x=>x.t2=="").length==0){
        this.$Modal.warning({
        title: '提示',
        content: '已全部处理！'
        ,onOk: () => {}
        })
        return;
      }

      this.$Modal.confirm({
        title: '提示',
        content: '<p>是否一键确定?</p>',
        onOk: () => {
          batchok({
            fsts: o.name3.data6.filter(x=>x.t2=="").map(x=>{return x.id}).join(","),
            bid:o.boilerid
          }).then(res => {
              if(res.data.code==500){
                this.$Modal.error({
                  title: '提示',
                  content: res.data.message
                  ,onOk: () => {
                    this.loadECharList(this.boilerid);
                  }
                })
              }else{
                getFireerror_adviceList({
                    totalCount: 0,
                    pageSize: 20,
                    currentPage: 1,
                    kw: "",
                    isDeleted: -1,
                    status: -1,
                    boilerid: o.boilerid,
                    boilertime: o.boilertime,
                    t: "1",
                    sort: [
                      {
                        direct: "ASC",
                        field: "dnctypeid"
                      }
                    ]
                  }).then(res => {
                    o.name3.data6=res.data.data.map(x=>{
                      return { 
                        "id": x.id,
                        "t" : x.dncType_Name.replace("沾污异常","") , 
                        "s" : (x.evalue==1?"偏高":"偏低") ,
                        "t1" :  x.realTime.substr(11,9) ,
                        "t2" :  x.checkTime?x.checkTime.substr(11,9):""
                      }
                    });
                });
              }
              
          });
        },
        onCancel: () => {
        }
      });
    },


    handleall6(){
      let o=this;

      if(o.name6.data6.filter(x=>x.t2=="").length==0){
        this.$Modal.warning({
          title: '提示',
          content: '已全部处理！',
          onOk: () => {}
        })
        return;
      }

      this.$Modal.confirm({
        title: '提示',
        content: '<p>是否一键确定?</p>',
        onOk: () => {
          batchok({
            fsts: o.name6.data6.filter(x=>x.t2=="").map(x=>{return x.id}).join(","),
            bid:o.boilerid
          }).then(res => {
              if(res.data.code==500){
                this.$Modal.error({
                  title: '提示',
                  content: res.data.message
                  ,onOk: () => {
                    this.loadECharList(this.boilerid);
                  }
                })
              }else{
                getFireerror_adviceList({
                    totalCount: 0,
                    pageSize: 20,
                    currentPage: 1,
                    kw: "",
                    isDeleted: -1,
                    status: -1,
                    boilerid: o.boilerid,
                    boilertime: o.boilertime,
                    t: "1",
                    sort: [
                      {
                        direct: "ASC",
                        field: "dnctypeid"
                      }
                    ]
                  }).then(res => {
                    o.name6.data6=res.data.data.map(x=>{
                      return { 
                        "id": x.id,
                        "t" : x.dncType_Name.replace("沾污异常","") , 
                        "s" : (x.evalue==1?"偏高":"偏低") ,
                        "t1" :  x.realTime.substr(11,9) ,
                        "t2" :  x.checkTime?x.checkTime.substr(11,9):""
                      }
                    });
                });
              }
              
          });
        },
        onCancel: () => {
        }
      });
    },


    change (status) {
      if(status){
        this.$Message.info('实时刷新已打开');
      }else{
        this.$Message.warning('实时刷新已关闭');
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
      let huikandata={};
      if(title=="燃烧状态异常展示图"){
        huikandata=leftdata_back;
        getError_statusList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: o.boilerid,
            d1:d1,
            d2:d2,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let d= getDateMore(res.data.data,2,["realTime",]);
            //console.log(JSON.stringify(d));
            huikandata.xAxis.data=d.map(x=>{
              return x.realTime.substr(0,11);
            }).reverse();
            let state =d.map(x=>{
              return [
              x.leftqy_xxbz,
              x.rightqy_xxbz,
              x.leftqy_qxbz,
              x.rightqy_qxbz,
              x.leftqy_px,
              x.rightqy_px,
              x.cxbj,
              x.normal
              ].reverse()
            }).reverse();
            let reData = new Array(), i;
            for (i = 0; i < 8; i++) {
                for (var j = state.length - 1; j >= 0; j--) {
                    reData.push([i, j, state[j][i]]);
                }
            }
            let lll=reData.map(item=>{
              return  [item[1], item[0], item[2] || '-'];
            })
            huikandata.series[0].data = lll;

            o.huikan={
              title:title,
              modal2:true,
              data:huikandata,
              timebe:[d1,d2]
            };

           // console.log(JSON.stringify(o.huikan.data.dataZoom));
          });


      }else if(title=='高温再热器出口温度对比图'){
          huikandata=leftdata_2_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度
            huikandata.xAxis.data=realtime;
            huikandata.series[0].data=k.map(x=>{ 
              return (x.gz_temp_out_right + x.gz_temp_out_left )/2
            });
            huikandata.series[4].data=k.map(x=>{ return x.yl_fh_out});

            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              huikandata.series[1].data=k.map(x=>{ 
                return res.data.data[0].gz_out_temp_ed;
              });
              huikandata.series[2].data=k.map(x=>{ 
                return res.data.data[0].gz_out_temp_high;
              });
              huikandata.series[3].data=k.map(x=>{ 
                return res.data.data[0].gz_out_temp_low;
              });

              o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
              };
            });
          });


      }else if(title=='高温再热器出口温度左右偏差图'){
          huikandata=leftdata_2_2_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度
            huikandata.xAxis[0].data=realtime;
            huikandata.series[0].data=k.map(x=>{ 
              return ((x.gz_temp_out_left - x.gz_temp_out_right )/2).toFixed(2)
            });
            huikandata.series[0].itemStyle.normal.color=(param)=>{
              return k.map(x=>{ 
                return (x.gz_temp_out_left - x.gz_temp_out_right )>=0?"#C23531":"#2F4554"
              })[param.dataIndex]
            } 

            o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
            };
            
          });


      }else if(title=='末级过热器出口温度对比图'){

          huikandata=rightdata_2_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度

            huikandata.xAxis.data=realtime;
            huikandata.series[0].data=k.map(x=>{ 
              return (x.mg_temp_out_right + x.mg_temp_out_left )/2
            });
            huikandata.series[4].data=k.map(x=>{ return x.yl_fh_out});

            

            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              huikandata.series[1].data=k.map(x=>{ 
                return res.data.data[0].mg_out_temp_ed;
              });
              huikandata.series[2].data=k.map(x=>{ 
                  return res.data.data[0].mg_out_temp_high;
              });
              huikandata.series[3].data=k.map(x=>{ 
                  return res.data.data[0].mg_out_temp_low;
              });

              o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
              };
            });
          });


      }else if(title=='末级过热器出口温度左右偏差图'){

          huikandata=rightdata_2_2_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度
            
            huikandata.xAxis[0].data=realtime;
            huikandata.series[0].data=k.map(x=>{ 
              return ((x.mg_temp_out_left - x.mg_temp_out_right )/2).toFixed(2)
            });
            huikandata.series[0].itemStyle.normal.color=(param)=>{
              return k.map(x=>{ 
                return (x.mg_temp_out_left - x.mg_temp_out_right )>=0?"#C23531":"#2F4554"
              })[param.dataIndex]
            } 

            o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
            };
            
          });


      }else if(title=='所有因素对煤耗的影响程度'){

          huikandata=mhyx_1_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度
            
            huikandata.xAxis[0].data=realtime;
            huikandata.series[0].data=k.map(x=>{return (x.dz_jws_mh + x.gz_temp_mh + x.mg_temp_mh).toFixed(2) });

            o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
            };
            
          });


      }else if(title=='不同因素对煤耗的影响程度'){

          huikandata=mhyx_2_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});
            //温度
            
            huikandata.xAxis[0].data=realtime;
            huikandata.series[0].data=k.map(x=>{return x.dz_jws_mh.toFixed(2) });
            huikandata.series[1].data=k.map(x=>{return x.gz_temp_mh.toFixed(2) });
            huikandata.series[2].data=k.map(x=>{return x.mg_temp_mh.toFixed(2) });

            o.huikan={
                title:title,
                modal2:true,
                data:huikandata,
                timebe:[d1,d2]
            };
            
          });

      /////玷污系数开始------------------------------------
      }else if(title=='低温过热器'){

          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});

            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //沾污系数
              let dd1=k.map(x=>{ return res.data.data[0].dg_zwxs_high;});
              let dd2=k.map(x=>{ return x.dg_zwxs.toFixed(2);});
              let dd3=k.map(x=>{ return res.data.data[0].dg_zwxs_low;});
              huikandata= zwxs_now_back("dg",realtime,dd1,dd2,dd3);

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });


      }else if(title=='分隔屏过热器'){

          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});


            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //沾污系数

              let dd1=k.map(x=>{ return res.data.data[0].fgp_zwxs_high;});
              let dd2=k.map(x=>{ return x.fgp_zwxs.toFixed(2);});
              let dd3=k.map(x=>{ return res.data.data[0].fgp_zwxs_low;});
              huikandata=zwxs_now_back("fgp",realtime,dd1,dd2,dd3);

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });
      }else if(title=='后屏过热器'){

          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});

            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //沾污系数

              let dd1=k.map(x=>{ return res.data.data[0].hp_zwxs_high;});
              let dd2=k.map(x=>{ return x.hp_zwxs.toFixed(2);});
              let dd3=k.map(x=>{ return res.data.data[0].hp_zwxs_low;});
              huikandata=zwxs_now_back("hp",realtime,dd1,dd2,dd3);
                

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });
      }else if(title=='末级过热器'){

          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});


            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //沾污系数

              let dd1=k.map(x=>{ return res.data.data[0].mg_zwxs_high;});
              let dd2=k.map(x=>{ return x.mg_zwxs.toFixed(2);});
              let dd3=k.map(x=>{ return res.data.data[0].mg_zwxs_low;});
              huikandata=zwxs_now_back("mg",realtime,dd1,dd2,dd3);


              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });
      }else if(title=='低温再热器'){

          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});


            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //沾污系数
            
              let dd1=k.map(x=>{ return res.data.data[0].dz_zwxs_high;});
              let dd2=k.map(x=>{ return x.dz_zwxs.toFixed(2);});
              let dd3=k.map(x=>{ return res.data.data[0].dz_zwxs_low;});
              huikandata=zwxs_now_back("dz",realtime,dd1,dd2,dd3);

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });
      }else if(title=='高温再热器'){

          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});


            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //沾污系数
              let dd1=k.map(x=>{ return res.data.data[0].gz_zwxs_high;});
              let dd2=k.map(x=>{ return x.gz_zwxs.toFixed(2);});
              let dd3=k.map(x=>{ return res.data.data[0].gz_zwxs_low;});
              huikandata=zwxs_now_back("gz",realtime,dd1,dd2,dd3);  

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });

      }else if(title=='O2(%)平均值与预期值对比图'){
        huikandata=o2x1_back;
        getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});


            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //o2x
              huikandata.xAxis[0].data=realtime;
              huikandata.series[1].data=k.map(x=>{return x.o2_avg.toFixed(2) });
              huikandata.series[0].data=k.map(x=>{return x.o2_high.toFixed(2) });
              huikandata.series[2].data=k.map(x=>{return x.o2_low.toFixed(2) });
              huikandata.series[3].data=k.map(x=>{return x.yl_fh_out.toFixed(2) });

              // huikandata.xAxis[0].data=realtime;
              // huikandata.series[1].data=k.map(x=>{return x.nox_avg.toFixed(2) });
              // huikandata.series[0].data=k.map(x=>{return x.nox_high.toFixed(2) });
              // huikandata.series[2].data=k.map(x=>{return x.nox_low.toFixed(2) });
              // huikandata.series[3].data=k.map(x=>{return x.yl_fh_out.toFixed(2) });


              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });
      }else if(title=='NOx(mp/Nm3)平均值与预期值对比图'){
        huikandata=o2x2_back;
        getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "DESC",
                field: "realTime"
              }
            ]
          }).then(res1 => {
            let k= getDateMore(res1.data.data,3,["realTime",]).reverse();

            let realtime=k.map(x=>{ return x.realTime});


            getSrm_parameterList({
              totalCount: 0,
              pageSize: 1,
              currentPage: 1,
              kw: "",
              isDeleted: -1,
              status: -1,
              boilerid: o.boilerid,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
              //o2x
              // huikandata.xAxis[0].data=realtime;
              // huikandata.series[1].data=k.map(x=>{return x.o2_avg.toFixed(2) });
              // huikandata.series[0].data=k.map(x=>{return x.o2_high.toFixed(2) });
              // huikandata.series[2].data=k.map(x=>{return x.o2_low.toFixed(2) });
              // huikandata.series[3].data=k.map(x=>{return x.yl_fh_out.toFixed(2) });

              huikandata.xAxis[0].data=realtime;
              huikandata.series[1].data=k.map(x=>{return x.nox_avg.toFixed(2) });
              huikandata.series[0].data=k.map(x=>{return x.nox_high.toFixed(2) });
              huikandata.series[2].data=k.map(x=>{return x.nox_low.toFixed(2) });
              huikandata.series[3].data=k.map(x=>{return x.yl_fh_out.toFixed(2) });


              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            });
          });
      }



    },



    // haldleVedioData(date){
    //   let d1=date[0];
    //   let d2=date[1];
    //   this.Vedioview(this.huikan.title,d1,d2);
    // },
    haldleVedio(title){
      let dateTime=new Date();
      dateTime=dateTime.setDate(dateTime.getDate()-1);
      this.Vedioview(title,this.dateFormat("yyyy-MM-dd HH:mm",new Date(dateTime)),this.dateFormat("yyyy-MM-dd HH:mm",new Date()));
    },
    //播放函数
    Vedioview(title,d1,d2){
      let o=this;
      let huikandata={};
      if(title=="左右侧各级焓增对(kj/kg)"){
          huikandata=rightdata1_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "ASC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,-1,["realTime",]);
            let realtime=k.map(x=>{ return x.realTime});
            o.vdata=k;
            o.vmax=k.length - 1 ;
            o.vdatanow=0;

            if(k.length>0){
              let l= k[0];
              //温度
              //左右
              huikandata.series[1].data=[
                -(l.dg_hz_a+l.dg_hz_b)/2,
                -(l.fgp_hz_a+l.fgp_hz_b)/2,
                -(l.hp_hz_a+l.hp_hz_b)/2,
                -(l.mg_hz_a+l.mg_hz_b)/2,
                -l.dz_hz_left,
                -l.gz_hz_left
              ].reverse();

              huikandata.series[0].data=[
                (l.dg_hz_c+l.dg_hz_d)/2,
                (l.fgp_hz_c+l.fgp_hz_d)/2,
                (l.hp_hz_c+l.hp_hz_d)/2,
                (l.mg_hz_c+l.mg_hz_d)/2,
                l.dz_hz_right,
                l.gz_hz_right
              ].reverse();

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            }else{
              huikandata.series[1].data=[];
              huikandata.series[0].data=[];
              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            }
            
            
          });
      }else if(title=="左右侧各级出口汽温对比"){
          huikandata=rightdata2_back;
          getHztemp_realList({
            totalCount: 0,
            pageSize: 2000,
            currentPage: 1,
            kw: "",
            isDeleted: -1,
            status: -1,
            d1:d1,
            d2:d2,
            boilerid: o.boilerid,
            sort: [
              {
                direct: "ASC",
                field: "realTime"
              }
            ]
          }).then(res => {
            let k= getDateMore(res.data.data,-1,["realTime",]);
            let realtime=k.map(x=>{ return x.realTime});
            o.vdata=k;
            o.vmax=k.length - 1 ;
            o.vdatanow=0;
            if(k.length>0){
              let l= k[0];
              huikandata.series[1].data=[
                -l.dg_temp_out_left,
                -l.fgp_temp_out_left,
                -l.hp_temp_out_left,
                -l.mg_temp_out_left,
                -l.dz_temp_out_left,
                -l.gz_temp_out_left
              ].reverse();

              huikandata.series[0].data=[
                l.dg_temp_out_right,
                l.fgp_temp_out_right,
                l.hp_temp_out_right,
                l.mg_temp_out_right,
                l.dz_temp_out_right,
                l.gz_temp_out_right
              ].reverse();

              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            }else{
              huikandata.series[1].data=[];
              huikandata.series[0].data=[];
              o.huikan={
                  title:title,
                  modal2:true,
                  data:huikandata,
                  timebe:[d1,d2]
              };
            }
            
          });
      }else if(title=='O2测点分布图'){
        
      }else if(title=='NOx测点分布图'){
        
      }
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
      if(this.huikan.title=='左右侧各级焓增对(kj/kg)'){
        huikandata=rightdata1_back;
        let l=o.vdata[o.vdatanow];
        huikandata.series[1].data=[
              -(l.dg_hz_a+l.dg_hz_b)/2,
              -(l.fgp_hz_a+l.fgp_hz_b)/2,
              -(l.hp_hz_a+l.hp_hz_b)/2,
              -(l.mg_hz_a+l.mg_hz_b)/2,
              -l.dz_hz_left,
              -l.gz_hz_left
            ].reverse();

        huikandata.series[0].data=[
              (l.dg_hz_c+l.dg_hz_d)/2,
              (l.fgp_hz_c+l.fgp_hz_d)/2,
              (l.hp_hz_c+l.hp_hz_d)/2,
              (l.mg_hz_c+l.mg_hz_d)/2,
              l.dz_hz_right,
              l.gz_hz_right
            ].reverse();
      }else if(this.huikan.title=='左右侧各级出口汽温对比'){
        huikandata=rightdata2_back;
        let l=o.vdata[o.vdatanow];
        huikandata.series[1].data=[
              -l.dg_temp_out_left,
              -l.fgp_temp_out_left,
              -l.hp_temp_out_left,
              -l.mg_temp_out_left,
              -l.dz_temp_out_left,
              -l.gz_temp_out_left
            ].reverse();

        huikandata.series[0].data=[
              l.dg_temp_out_right,
              l.fgp_temp_out_right,
              l.hp_temp_out_right,
              l.mg_temp_out_right,
              l.dz_temp_out_right,
              l.gz_temp_out_right
            ].reverse();
      }else if(this.huikan.title=='O2测点分布图'){

      }else if(this.huikan.title=='NOx测点分布图'){
        
      }
      o.huikan.data=huikandata;
    }
  },
  mounted() {

    this.loadECharList(null);
    this.timer =setInterval(() => {
      if(this.run){
        if(this.boilerid==-1){
          this.loadECharList(null);
        }else{
          this.loadECharList(this.boilerid);
        }
      }
    }, 60000);//1分钟
  },
  beforeDestroy() {
    clearInterval(this.timer);
  }
};
</script>






