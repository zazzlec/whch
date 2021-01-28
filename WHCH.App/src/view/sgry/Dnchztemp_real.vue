<style lang="less">
.Hztemp_real{
    .vertical-center-modal{
        display: flex;
        align-items: center;
        justify-content: center;
        .ivu-modal{
            top: 0;
        }
    }
    .update-paste{
      &-con{
        height: 350px;
      }
      &-btn-con{
        box-sizing: content-box;
        height: 30px;
        padding: 15px 0 5px;
      }
    }
    .paste-tip{
      color: #19be6b;
    }
    .ivu-modal-footer {
      padding: 1px 18px 8px 18px !important;
    }
    .CodeMirror-sizer{
      margin-left: 30px !important;
    }
    .CodeMirror-linenumbers{
      width: 29px !important;
    }
    .tdtd{
      color: #fff;
      padding: 10px 0;
      text-align: center;
      background: rgba(0,153,229,.5);
      width: 1.58730158730159%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Hztemp_real">
    <Modal  class="Hztemp_real"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">当前时间</i-col><i-col  class="tdtd">低温过热器焓增A</i-col><i-col  class="tdtd">低温过热器焓增B</i-col><i-col  class="tdtd">低温过热器焓增C</i-col><i-col  class="tdtd">低温过热器焓增D</i-col><i-col  class="tdtd">分隔屏焓增A</i-col><i-col  class="tdtd">分隔屏焓增B</i-col><i-col  class="tdtd">分隔屏焓增C</i-col><i-col  class="tdtd">分隔屏焓增D</i-col><i-col  class="tdtd">后屏焓增A</i-col><i-col  class="tdtd">后屏焓增B</i-col><i-col  class="tdtd">后屏焓增C</i-col><i-col  class="tdtd">后屏焓增D</i-col><i-col  class="tdtd">末级过热器焓增A</i-col><i-col  class="tdtd">末级过热器焓增B</i-col><i-col  class="tdtd">末级过热器焓增C</i-col><i-col  class="tdtd">末级过热器焓增D</i-col><i-col  class="tdtd">低温再热器焓增左侧</i-col><i-col  class="tdtd">低温再热器焓增右侧</i-col><i-col  class="tdtd">高温再热器焓增左侧</i-col><i-col  class="tdtd">高温再热器焓增右侧</i-col><i-col  class="tdtd">低温过热器左侧出口温度</i-col><i-col  class="tdtd">低温过热器右侧出口温度</i-col><i-col  class="tdtd">分隔屏左出口温度</i-col><i-col  class="tdtd">分隔屏右出口温度</i-col><i-col  class="tdtd">后屏左出口温度</i-col><i-col  class="tdtd">后屏右出口温度</i-col><i-col  class="tdtd">高过左出口温度</i-col><i-col  class="tdtd">高过右出口温度</i-col><i-col  class="tdtd">低再左出口温度</i-col><i-col  class="tdtd">低再右出口温度</i-col><i-col  class="tdtd">高再左出口温度</i-col><i-col  class="tdtd">高再右出口温度</i-col><i-col  class="tdtd">nox测点平均值</i-col><i-col  class="tdtd">NOx偏高值</i-col><i-col  class="tdtd">O2氧量偏低值</i-col><i-col  class="tdtd">O2测点平均值</i-col><i-col  class="tdtd">O2氧量偏高值</i-col><i-col  class="tdtd">O2氧量偏低值</i-col><i-col  class="tdtd">机组实时负荷</i-col><i-col  class="tdtd">抽汽量</i-col><i-col  class="tdtd">再热器减温水对煤耗影响</i-col><i-col  class="tdtd">再热器出口蒸汽温度对煤耗影响</i-col><i-col  class="tdtd">过热器出口蒸汽温度对煤耗影响</i-col><i-col  class="tdtd">低温过热器沾污程度</i-col><i-col  class="tdtd">分隔屏粘污系数</i-col><i-col  class="tdtd">后屏粘污系数</i-col><i-col  class="tdtd">高过粘污系数</i-col><i-col  class="tdtd">低再粘污系数</i-col><i-col  class="tdtd">高再粘污系数</i-col><i-col  class="tdtd">过热器一级减温水量A</i-col><i-col  class="tdtd">过热器一级减温水量B</i-col><i-col  class="tdtd">过热器一级减温水量C</i-col><i-col  class="tdtd">过热器一级减温水量D</i-col><i-col  class="tdtd">过热器二级减温水量A</i-col><i-col  class="tdtd">过热器二级减温水量B</i-col><i-col  class="tdtd">过热器二级减温水量C</i-col><i-col  class="tdtd">过热器二级减温水量D</i-col><i-col  class="tdtd">过热器三级减温水量A</i-col><i-col  class="tdtd">过热器三级减温水量B</i-col><i-col  class="tdtd">过热器三级减温水量C</i-col><i-col  class="tdtd">过热器三级减温水量D</i-col><i-col  class="tdtd"></i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="63" />
              </div>
              <div class="update-paste-btn-con">
                <span class="paste-tip">使用Tab键换列，使用回车键换行</span>
                <Button type="primary" style="float: right;" @click="handleShow">数据上传</Button>
              </div>
            </Card>
          </i-col>
        </Row>
        <div slot="footer">
        </div>
    </Modal>
    <Card>
      <tables
        ref="tables"
        editable
        searchable
        :border="false"
        size="small"
        search-place="top"
        v-model="stores.Hztemp_real.data"
        :totalCount="stores.Hztemp_real.query.totalCount"
        :pageSize="stores.Hztemp_real.query.pageSize"
        :columns="stores.Hztemp_real.columns"
        @on-delete="handleDelete"
        @on-edit="handleEdit"
        @on-select="handleSelect"
        @on-selection-change="handleSelectionChange"
        @on-refresh="handleRefresh"
        :row-class-name="rowClsRender"
        @on-page-change="handlePageChanged"
        @on-page-size-change="handlePageSizeChanged"
        @on-sort-change="handleSortChange"
      >
        <div slot="search">
          <section class="dnc-toolbar-wrap">
            <Row :gutter="16">
              <Col span="16">
                <Form inline @submit.native.prevent>
                  <FormItem>
                    <Input
                      type="text"
                      search
                      :clearable="true"
                      v-model="stores.Hztemp_real.query.kw"
                      placeholder="输入搜索..."
                      @on-search="handleSearchHztemp_real()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Hztemp_real.query.isDeleted"
                        @on-change="handleSearchHztemp_real"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Hztemp_real.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Hztemp_real.query.status"
                        @on-change="handleSearchHztemp_real"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Hztemp_real.sources.statusSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                    </Input>
                  </FormItem>
                </Form>
              </Col>
              <Col span="8" class="dnc-toolbar-btns">
                <ButtonGroup class="mr3">
                  <Button
                    class="txt-danger"
                    icon="md-trash"
                    title="删除"
                    @click="handleBatchCommand('delete')"
                  ></Button>
                  <Button
                    class="txt-success"
                    icon="md-redo"
                    title="恢复"
                    @click="handleBatchCommand('recover')"
                  ></Button>
                  <Button
                    class="txt-danger"
                    icon="md-hand"
                    title="禁用"
                    @click="handleBatchCommand('forbidden')"
                  ></Button>
                  <Button
                    class="txt-success"
                    icon="md-checkmark"
                    title="启用"
                    @click="handleBatchCommand('normal')"
                  ></Button>
                  <Button icon="md-refresh" title="刷新" @click="handleRefresh"></Button>
                  <Button icon="md-list-box" title="批量录入" @click="handleInputData" ></Button>
                </ButtonGroup>
                <Button
                  icon="md-create"
                  type="primary"
                  @click="handleShowCreateWindow"
                  title="新增"
                >新增</Button>
              </Col>
            </Row>
          </section>
        </div>
      </tables>
    </Card>
    <Drawer
      :title="formTitle"
      v-model="formModel.opened"
      width="600"
      :mask-closable="false"
      :mask="true"
      :styles="styles"
    >
      <Form :model="formModel.fields" ref="formHztemp_real" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="当前时间" prop="RealTime">
                    <i-col span="12">
                        <Date-picker @on-change="handleRealTimeDateChange" type="date" placeholder="选择当前时间" style="width: 276px" v-model="formModel.fields.RealTime" format="yyyy年MM月dd日"></Date-picker>
                    </i-col>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label=""  prop="DncBoiler_Name">
                          <Select v-model="formModel.fields.DncBoiler_Name" placeholder="">
                            <Option
                              v-for="item in formSource.DncBoiler "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
                </Row></Row>
        <Row :gutter="16">
        <!-- 
        <Col span="12">
        <FormItem label="状态" >
          <i-switch size="large" v-model="formModel.fields.Status" :true-value="1" :false-value="0">
            <span slot="open">正常</span>
            <span slot="close">禁用</span>
          </i-switch>
        </FormItem>
        </Col>
        -->
        </Row>
        

      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitHztemp_real">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel.opened = false">取 消</Button>
      </div>
    </Drawer>
  </div>
</template>

<script>
import PasteEditor from '_c/paste-editor'
import { getTableDataFromArray } from '@/libs/util'
import Tables from "_c/tables";
import {
  getDateMore,
  upperKey
} from "@/libs/tools";
import { getBoilerList,getBoilerListAll } from "@/api/ZNRS/Dncboiler";
import {
  getHztemp_realList,
  createHztemp_real,
  loadHztemp_real,
  editHztemp_real,
  deleteHztemp_real,
  batchCommand,
  batchCreateHztemp_real
} from "@/api/ZNRS/Dnchztemp_real";
export default {
  name: "ZNRS_Hztemp_real_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      dataorder:["RealTime","dg_hz_a","dg_hz_b","dg_hz_c","dg_hz_d","fgp_hz_a","fgp_hz_b","fgp_hz_c","fgp_hz_d","hp_hz_a","hp_hz_b","hp_hz_c","hp_hz_d","mg_hz_a","mg_hz_b","mg_hz_c","mg_hz_d","dz_hz_left","dz_hz_right","gz_hz_left","gz_hz_right","dg_temp_out_left","dg_temp_out_right","fgp_temp_out_left","fgp_temp_out_right","hp_temp_out_left","hp_temp_out_right","mg_temp_out_left","mg_temp_out_right","dz_temp_out_left","dz_temp_out_right","gz_temp_out_left","gz_temp_out_right","nox_avg","nox_high","nox_low","o2_avg","o2_high","o2_low","yl_fh_out","cql","dz_jws_mh","gz_temp_mh","mg_temp_mh","dg_zwxs","fgp_zwxs","hp_zwxs","mg_zwxs","dz_zwxs","gz_zwxs","grq_jws_1a","grq_jws_1b","grq_jws_1c","grq_jws_1d","grq_jws_2a","grq_jws_2b","grq_jws_2c","grq_jws_2d","grq_jws_3a","grq_jws_3b","grq_jws_3c","grq_jws_3d","DncBoiler_Name"],
      pasteDataArr: [],
      columns: [],
      validated: true,
      errorIndex: 0,
      modal1:false,
      commands: {
        delete: { name: "delete", title: "删除" },
        recover: { name: "recover", title: "恢复" },
        forbidden: { name: "forbidden", title: "禁用" },
        normal: { name: "normal", title: "启用" }
      },
      formModel: {
        opened: false,
        title: "创建",
        mode: "create",
        selection: [],
        fields: {

        },
        rules: {
           DncBoiler_Name: [
            {
              type: "string",
              required: true,
              message: "请输入",
              min: 1
            }
          ], 
        }
      },
      stores: {
        Hztemp_real: {
          query: {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          },
          sources: {
            isDeletedSources: [
              { value: -1, text: "全部" },
              { value: 0, text: "正常" },
              { value: 1, text: "已删" }
            ],
            statusSources: [
              { value: -1, text: "全部" },
              { value: 0, text: "禁用" },
              { value: 1, text: "正常" }
            ],
            statusFormSources: [
              { value: 0, text: "禁用" },
              { value: 1, text: "正常" }
            ]
          },
          columns: [
            { type: "selection", width: 50, key: "handle" },
            { title: "当前时间",width: 100, key: "realTime",  sortable: "custom" ,
              render: (h, params) => {
                let realTime = params.row.realTime;
                if(realTime=="0001-01-01"){
                  realTime= "";
                }else{
                  realTime = params.row.realTime;
                }
                return h('span', [
                                h('strong', realTime)
                            ]);
              }
            }, 
            { title: "低温过热器焓增A", key: "dg_hz_a",  sortable: "custom" },    
            { title: "低温过热器焓增B", key: "dg_hz_b",  sortable: "custom" },    
            { title: "低温过热器焓增C", key: "dg_hz_c",  sortable: "custom" },    
            { title: "低温过热器焓增D", key: "dg_hz_d",  sortable: "custom" },    
            { title: "分隔屏焓增A", key: "fgp_hz_a",  sortable: "custom" },    
            { title: "分隔屏焓增B", key: "fgp_hz_b",  sortable: "custom" },    
            { title: "分隔屏焓增C", key: "fgp_hz_c",  sortable: "custom" },    
            { title: "分隔屏焓增D", key: "fgp_hz_d",  sortable: "custom" },    
            { title: "后屏焓增A", key: "hp_hz_a",  sortable: "custom" },    
            { title: "后屏焓增B", key: "hp_hz_b",  sortable: "custom" },    
            { title: "后屏焓增C", key: "hp_hz_c",  sortable: "custom" },    
            { title: "后屏焓增D", key: "hp_hz_d",  sortable: "custom" },    
            { title: "末级过热器焓增A", key: "mg_hz_a",  sortable: "custom" },    
            { title: "末级过热器焓增B", key: "mg_hz_b",  sortable: "custom" },    
            { title: "末级过热器焓增C", key: "mg_hz_c",  sortable: "custom" },    
            { title: "末级过热器焓增D", key: "mg_hz_d",  sortable: "custom" },    
            { title: "低温再热器焓增左侧", key: "dz_hz_left",  sortable: "custom" },    
            { title: "低温再热器焓增右侧", key: "dz_hz_right",  sortable: "custom" },    
            { title: "高温再热器焓增左侧", key: "gz_hz_left",  sortable: "custom" },    
            { title: "高温再热器焓增右侧", key: "gz_hz_right",  sortable: "custom" },    
            { title: "低温过热器左侧出口温度", key: "dg_temp_out_left",  sortable: "custom" },    
            { title: "低温过热器右侧出口温度", key: "dg_temp_out_right",  sortable: "custom" },    
            { title: "分隔屏左出口温度", key: "fgp_temp_out_left",  sortable: "custom" },    
            { title: "分隔屏右出口温度", key: "fgp_temp_out_right",  sortable: "custom" },    
            { title: "后屏左出口温度", key: "hp_temp_out_left",  sortable: "custom" },    
            { title: "后屏右出口温度", key: "hp_temp_out_right",  sortable: "custom" },    
            { title: "高过左出口温度", key: "mg_temp_out_left",  sortable: "custom" },    
            { title: "高过右出口温度", key: "mg_temp_out_right",  sortable: "custom" },    
            { title: "低再左出口温度", key: "dz_temp_out_left",  sortable: "custom" },    
            { title: "低再右出口温度", key: "dz_temp_out_right",  sortable: "custom" },    
            { title: "高再左出口温度", key: "gz_temp_out_left",  sortable: "custom" },    
            { title: "高再右出口温度", key: "gz_temp_out_right",  sortable: "custom" },    
            { title: "nox测点平均值", key: "nox_avg",  sortable: "custom" },    
            { title: "NOx偏高值", key: "nox_high",  sortable: "custom" },    
            { title: "O2氧量偏低值", key: "nox_low",  sortable: "custom" },    
            { title: "O2测点平均值", key: "o2_avg",  sortable: "custom" },    
            { title: "O2氧量偏高值", key: "o2_high",  sortable: "custom" },    
            { title: "O2氧量偏低值", key: "o2_low",  sortable: "custom" },    
            { title: "机组实时负荷", key: "yl_fh_out",  sortable: "custom" },    
            { title: "抽汽量", key: "cql",  sortable: "custom" },    
            { title: "再热器减温水对煤耗影响", key: "dz_jws_mh",  sortable: "custom" },    
            { title: "再热器出口蒸汽温度对煤耗影响", key: "gz_temp_mh",  sortable: "custom" },    
            { title: "过热器出口蒸汽温度对煤耗影响", key: "mg_temp_mh",  sortable: "custom" },    
            { title: "低温过热器沾污程度", key: "dg_zwxs",  sortable: "custom" },    
            { title: "分隔屏粘污系数", key: "fgp_zwxs",  sortable: "custom" },    
            { title: "后屏粘污系数", key: "hp_zwxs",  sortable: "custom" },    
            { title: "高过粘污系数", key: "mg_zwxs",  sortable: "custom" },    
            { title: "低再粘污系数", key: "dz_zwxs",  sortable: "custom" },    
            { title: "高再粘污系数", key: "gz_zwxs",  sortable: "custom" },    
            { title: "过热器一级减温水量A", key: "grq_jws_1a",  sortable: "custom" },    
            { title: "过热器一级减温水量B", key: "grq_jws_1b",  sortable: "custom" },    
            { title: "过热器一级减温水量C", key: "grq_jws_1c",  sortable: "custom" },    
            { title: "过热器一级减温水量D", key: "grq_jws_1d",  sortable: "custom" },    
            { title: "过热器二级减温水量A", key: "grq_jws_2a",  sortable: "custom" },    
            { title: "过热器二级减温水量B", key: "grq_jws_2b",  sortable: "custom" },    
            { title: "过热器二级减温水量C", key: "grq_jws_2c",  sortable: "custom" },    
            { title: "过热器二级减温水量D", key: "grq_jws_2d",  sortable: "custom" },    
            { title: "过热器三级减温水量A", key: "grq_jws_3a",  sortable: "custom" },    
            { title: "过热器三级减温水量B", key: "grq_jws_3b",  sortable: "custom" },    
            { title: "过热器三级减温水量C", key: "grq_jws_3c",  sortable: "custom" },    
            { title: "过热器三级减温水量D", key: "grq_jws_3d",  sortable: "custom" },    
            { title: "", key: "dncBoiler_Name",  sortable: "custom" },    
            {
              title: "状态",
              key: "status",
              align: "center",
              width: 120,
              render: (h, params) => {
                let status = params.row.status;
                let statusColor = "success";
                let statusText = "正常";
                switch (status) {
                  case 0:
                    statusText = "禁用";
                    statusColor = "default";
                    break;
                }
                return h(
                  "Tooltip",
                  {
                    props: {
                      placement: "top",
                      transfer: true,
                      delay: 500
                    }
                  },
                  [
                    //这个中括号表示是Tooltip标签的子标签
                    h(
                      "Tag",
                      {
                        props: {
                          //type: "dot",
                          color: statusColor
                        }
                      },
                      statusText
                    ), //表格列显示文字
                    h(
                      "p",
                      {
                        slot: "content",
                        style: {
                          whiteSpace: "normal"
                        }
                      },
                      statusText //整个的信息即气泡内文字
                    )
                  ]
                );
              }
            },
            {
              title: "操作",
              align: "center",
              key: "handle",
              width: 150,
              className: "table-command-column",
              options: ["edit"],
              button: [
                (h, params, vm) => {
                  return h(
                    "Poptip",
                    {
                      props: {
                        confirm: true,
                        title: "你确定要删除吗?"
                      },
                      on: {
                        "on-ok": () => {
                          vm.$emit("on-delete", params);
                        }
                      }
                    },
                    [
                      h(
                        "Tooltip",
                        {
                          props: {
                            placement: "left",
                            transfer: true,
                            delay: 1000
                          }
                        },
                        [
                          h("Button", {
                            props: {
                              shape: "circle",
                              size: "small",
                              icon: "md-trash",
                              type: "error"
                            }
                          }),
                          h(
                            "p",
                            {
                              slot: "content",
                              style: {
                                whiteSpace: "normal"
                              }
                            },
                            "删除"
                          )
                        ]
                      )
                    ]
                  );
                },
                (h, params, vm) => {
                  return h(
                    "Tooltip",
                    {
                      props: {
                        placement: "left",
                        transfer: true,
                        delay: 1000
                      }
                    },
                    [
                      h("Button", {
                        props: {
                          shape: "circle",
                          size: "small",
                          icon: "md-create",
                          type: "primary"
                        },
                        on: {
                          click: () => {
                            vm.$emit("on-edit", params);
                            vm.$emit("input", params.tableData);
                          }
                        }
                      }),
                      h(
                        "p",
                        {
                          slot: "content",
                          style: {
                            whiteSpace: "normal"
                          }
                        },
                        "编辑"
                      )
                    ]
                  );
                }
              ]
            }
          ],
          data: []
        }
      },
      formSource: {
            DncBoiler : [] ,
      },
      styles: {
        height: "calc(100% - 55px)",
        overflow: "auto",
        paddingBottom: "53px",
        position: "static"
      }
    };
  },
  computed: {
    formTitle() {
      if (this.formModel.mode === "create") {
        return "创建";
      }
      if (this.formModel.mode === "edit") {
        return "编辑";
      }
      return "";
    },
    selectedRows() {
      return this.formModel.selection;
    },
    selectedRowsId() {
      return this.formModel.selection.map(x => x.id);
    }
  },
  methods: {
    handleRealTimeDateChange(date) {
      this.formModel.fields.RealTime=date
    },
  
    loadHztemp_realList() {
      getHztemp_realList(this.stores.Hztemp_real.query).then(res => {
        this.stores.Hztemp_real.data = getDateMore(res.data.data,1,["realTime",]);
        this.stores.Hztemp_real.query.totalCount = res.data.totalCount;
      });
    },
    handleOpenFormWindow() {
      this.formModel.opened = true;
    },
    handleCloseFormWindow() {
      this.formModel.opened = false;
    },
    handleSwitchFormModeToCreate() {
      this.formModel.mode = "create";
    },
    handleSwitchFormModeToEdit() {
      this.formModel.mode = "edit";
      this.handleOpenFormWindow();
    },
    handleEdit(params) {
      this.handleSwitchFormModeToEdit();
      this.handleResetFormHztemp_real();
      this.doLoadAllForinkey();
      this.doLoadHztemp_real(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadHztemp_realList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormHztemp_real();
      this.doLoadAllForinkey();
      this.formModel.fields={
          RealTime:"",
          dg_hz_a:"",
          dg_hz_b:"",
          dg_hz_c:"",
          dg_hz_d:"",
          fgp_hz_a:"",
          fgp_hz_b:"",
          fgp_hz_c:"",
          fgp_hz_d:"",
          hp_hz_a:"",
          hp_hz_b:"",
          hp_hz_c:"",
          hp_hz_d:"",
          mg_hz_a:"",
          mg_hz_b:"",
          mg_hz_c:"",
          mg_hz_d:"",
          dz_hz_left:"",
          dz_hz_right:"",
          gz_hz_left:"",
          gz_hz_right:"",
          dg_temp_out_left:"",
          dg_temp_out_right:"",
          fgp_temp_out_left:"",
          fgp_temp_out_right:"",
          hp_temp_out_left:"",
          hp_temp_out_right:"",
          mg_temp_out_left:"",
          mg_temp_out_right:"",
          dz_temp_out_left:"",
          dz_temp_out_right:"",
          gz_temp_out_left:"",
          gz_temp_out_right:"",
          nox_avg:"",
          nox_high:"",
          nox_low:"",
          o2_avg:"",
          o2_high:"",
          o2_low:"",
          yl_fh_out:"",
          cql:"",
          dz_jws_mh:"",
          gz_temp_mh:"",
          mg_temp_mh:"",
          dg_zwxs:"",
          fgp_zwxs:"",
          hp_zwxs:"",
          mg_zwxs:"",
          dz_zwxs:"",
          gz_zwxs:"",
          grq_jws_1a:"",
          grq_jws_1b:"",
          grq_jws_1c:"",
          grq_jws_1d:"",
          grq_jws_2a:"",
          grq_jws_2b:"",
          grq_jws_2c:"",
          grq_jws_2d:"",
          grq_jws_3a:"",
          grq_jws_3b:"",
          grq_jws_3c:"",
          grq_jws_3d:"",
          DncBoiler:0,
          DncBoiler_Name:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitHztemp_real() {
      let valid = this.validateHztemp_realForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateHztemp_real();
          }
          if (o.formModel.mode === "edit") {
            o.doEditHztemp_real();
          }
        }
      });
    },
    handleResetFormHztemp_real() {
      this.$refs["formHztemp_real"].resetFields();
    },
    doCreateHztemp_real() {
      
      createHztemp_real(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_realList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditHztemp_real() {
      editHztemp_real(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_realList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateHztemp_realForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formHztemp_real"].validate(valid => {
          if (!valid) {
            o.$Message.error("请完善表单信息");
            _valid = false;
          } else {
            _valid = true;
          }
          resolve(_valid);
        });
      });
    },
    doLoadHztemp_real(id) {
      loadHztemp_real({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
   //     op.DncBoiler_Name=parseInt(op.DncBoiler_Name);
        this.formModel.fields = op;
      });
    },
    doLoadAllForinkey() {
      let o=this;
      ////{PageSize:10,CurrentPage:1,Status:1,IsDeleted:0,Sort:[{Field:"id",Direct:"Desc"}],Kw:""}
      getBoilerListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.DncBoiler=t;
      });
    },
    handleDelete(params) {
      this.doDelete(params.row.id);
    },
    doDelete(ids) {
      if (!ids) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      deleteHztemp_real(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_realList();
        } else {
          this.$Message.warning(res.data.message);
        }
      });
    },
    handleBatchCommand(command) {
      if (!this.selectedRowsId || this.selectedRowsId.length <= 0) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      this.$Modal.confirm({
        title: "操作提示",
        content:
          "<p>确定要执行当前 [" +
          this.commands[command].title +
          "] 操作吗?</p>",
        loading: true,
        onOk: () => {
          this.doBatchCommand(command);
        }
      });
    },
    doBatchCommand(command) {
      batchCommand({
        command: command,
        ids: this.selectedRowsId.join(",")
      }).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_realList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchHztemp_real() {
      this.loadHztemp_realList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Hztemp_real.query.currentPage = page;
      this.loadHztemp_realList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Hztemp_real.query.pageSize = pageSize;
      this.loadHztemp_realList();
    },
    handleInputData(){
      this.modal1=true;
    },
    handleSuccess () {
      this.validated = true
    },
    handleInput (dd) {
      if(dd[0]){
        let len=dd.length;
        let t=dd[len-1].length;
        if(this.$refs.m1n1.$children && t<=63){
          for (let index = 0; index < this.$refs.m1n1.$children.length; index++) {
            this.$refs.m1n1.$children[index].$el.className ="tdtd";
          }
          this.$refs.m1n1.$children[t-1].$el.className ="tdtd tdtdselect";
        }
      }
    },
    handleError (index) {
      this.validated = false
      this.errorIndex = index
    },
    handleShow () {
      if (!this.validated) {
        let row=this.errorIndex+1;
        this.$Modal.confirm({
                        title: '您的内容不规范',
                        content: '您的第 '+row+' 行 字段数不匹配，请修改'
              });
      } else {
        let puto = [];
        puto.push(this.dataorder);
        puto.push(this.pasteDataArr);
        let s= JSON.stringify(puto);
        batchCreateHztemp_real({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadHztemp_realList();
              this.modal1=false;
            } else {
              this.$Modal.confirm({
                        title: '您的内容不规范',
                        content: res.data.message
              });
            }
        });
      }
    },
    handleSortChange(column){
      this.stores.Hztemp_real.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadHztemp_realList();
    }
  },
  mounted() {
    this.loadHztemp_realList();
  }
};
</script>






