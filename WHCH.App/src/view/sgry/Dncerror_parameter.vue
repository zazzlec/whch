<style lang="less">
.Error_parameter{
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
      width: 2.63157894736842%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Error_parameter">
    <Modal  class="Error_parameter"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">分隔屏焓增B比A高</i-col><i-col  class="tdtd">后屏焓增B比A高</i-col><i-col  class="tdtd">高过焓增A比B高</i-col><i-col  class="tdtd">低再焓增A比B高</i-col><i-col  class="tdtd">末再焓增A比B高</i-col><i-col  class="tdtd">烟气浓度左比右高（左切圆）</i-col><i-col  class="tdtd">悬吊管最高点左比右高(左切圆)</i-col><i-col  class="tdtd">消旋、起旋动量不足异常值条件数量</i-col><i-col  class="tdtd">分隔屏焓增C比D高</i-col><i-col  class="tdtd">后屏焓增C比D高</i-col><i-col  class="tdtd">高过焓增A比B高</i-col><i-col  class="tdtd">低再焓增D比C高</i-col><i-col  class="tdtd">末再焓增D比C高</i-col><i-col  class="tdtd">烟气浓度右比左高（右切圆）</i-col><i-col  class="tdtd">悬吊管最高点右比左高(右切圆)</i-col><i-col  class="tdtd">分隔屏焓增B比A低</i-col><i-col  class="tdtd">后屏焓增B比A低</i-col><i-col  class="tdtd">高过焓增A比B低</i-col><i-col  class="tdtd">低再焓增A比B低</i-col><i-col  class="tdtd">末再焓增A比B低</i-col><i-col  class="tdtd">烟气浓度左比右低（左切圆）</i-col><i-col  class="tdtd">悬吊管最高点左比右低(左切圆)</i-col><i-col  class="tdtd">分隔屏焓增C比D低</i-col><i-col  class="tdtd">后屏焓增C比D低</i-col><i-col  class="tdtd">高过焓增D比C低</i-col><i-col  class="tdtd">低再焓增D比C低</i-col><i-col  class="tdtd">末再焓增D比C低</i-col><i-col  class="tdtd">烟气浓度右比左低（右切圆）</i-col><i-col  class="tdtd">悬吊管最高点右比左低(右切圆)</i-col><i-col  class="tdtd">垂直段水冷壁左墙右墙温度差</i-col><i-col  class="tdtd">左、右切圆后墙悬吊管水冷壁左侧、右侧最高三点平均值的差值</i-col><i-col  class="tdtd">螺旋段水冷壁壁温左侧、右侧最高10个点平均值的差值</i-col><i-col  class="tdtd">左、右切圆向左、向右偏斜异常值条件数量</i-col><i-col  class="tdtd">左、右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高</i-col><i-col  class="tdtd">左、右切圆前墙管屏水冷壁温度比后墙垂直水冷壁高</i-col><i-col  class="tdtd">左、右切圆前墙、后墙螺旋段水冷壁温度差值</i-col><i-col  class="tdtd">左、右切圆向前、向后偏斜异常值条件数量</i-col><i-col  class="tdtd"></i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="38" />
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
        v-model="stores.Error_parameter.data"
        :totalCount="stores.Error_parameter.query.totalCount"
        :pageSize="stores.Error_parameter.query.pageSize"
        :columns="stores.Error_parameter.columns"
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
                      v-model="stores.Error_parameter.query.kw"
                      placeholder="输入搜索..."
                      @on-search="handleSearchError_parameter()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Error_parameter.query.isDeleted"
                        @on-change="handleSearchError_parameter"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Error_parameter.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Error_parameter.query.status"
                        @on-change="handleSearchError_parameter"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Error_parameter.sources.statusSources"
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
      <Form :model="formModel.fields" ref="formError_parameter" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="消旋、起旋动量不足异常值条件数量" prop="xx_qxbz_error_num">
                      <i-switch size="large" v-model="formModel.fields.xx_qxbz_error_num" :true-value="1" :false-value="0">
                        <span slot="open">是</span>
                        <span slot="close">否</span>
                      </i-switch>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="左、右切圆向左、向右偏斜异常值条件数量" prop="qy_px_l_r_num">
                      <i-switch size="large" v-model="formModel.fields.qy_px_l_r_num" :true-value="1" :false-value="0">
                        <span slot="open">是</span>
                        <span slot="close">否</span>
                      </i-switch>
                    </FormItem>
                    </Col>
                </Row></Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="左、右切圆向前、向后偏斜异常值条件数量" prop="qy_px_q_h_num">
                      <i-switch size="large" v-model="formModel.fields.qy_px_q_h_num" :true-value="1" :false-value="0">
                        <span slot="open">是</span>
                        <span slot="close">否</span>
                      </i-switch>
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
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitError_parameter">保 存</Button>
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
  getError_parameterList,
  createError_parameter,
  loadError_parameter,
  editError_parameter,
  deleteError_parameter,
  batchCommand,
  batchCreateError_parameter
} from "@/api/ZNRS/Dncerror_parameter";
export default {
  name: "ZNRS_Error_parameter_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      dataorder:["fgp_hz_b_big_a","hp_hz_b_big_a","mg_hz_a_big_b","dz_hz_a_big_b","mz_hz_a_big_b","left_qy_yqnd_l_big_r","left_qy_xdgtop_l_big_r","xx_qxbz_error_num","fgp_hz_c_big_d","hp_hz_c_big_d","mg_hz_d_big_c","dz_hz_d_big_c","mz_hz_d_big_c","right_qy_yqnd_r_big_l","right_qy_xdgtop_r_big_l","fgp_hz_b_small_a","hp_hz_b_small_a","mg_hz_a_small_b","dz_hz_a_small_b","mz_hz_a_small_b","left_qy_yqnd_l_small_r","left_qy_xdgtop_l_small_r","fgp_hz_c_small_d","hp_hz_c_small_d","mg_hz_d_small_c","dz_hz_d_small_c","mz_hz_dsmall_c","right_qy_yqnd_r_small_l","right_qy_xdgtop_r_small_l","czd_temp_left_right","qy_back_xdg_top3_avg_l_r","lxd_temp_top10_l_r","qy_px_l_r_num","qy_gp_h_big_q","qy_gp_q_big_h","qy_lxd_q_h","qy_px_q_h_num","DncBoiler_Name"],
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
        Error_parameter: {
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
            { title: "分隔屏焓增B比A高", key: "fgp_hz_b_big_a",  sortable: "custom" },    
            { title: "后屏焓增B比A高", key: "hp_hz_b_big_a",  sortable: "custom" },    
            { title: "高过焓增A比B高", key: "mg_hz_a_big_b",  sortable: "custom" },    
            { title: "低再焓增A比B高", key: "dz_hz_a_big_b",  sortable: "custom" },    
            { title: "末再焓增A比B高", key: "mz_hz_a_big_b",  sortable: "custom" },    
            { title: "烟气浓度左比右高（左切圆）", key: "left_qy_yqnd_l_big_r",  sortable: "custom" },    
            { title: "悬吊管最高点左比右高(左切圆)", key: "left_qy_xdgtop_l_big_r",  sortable: "custom" },    
            { title: "消旋、起旋动量不足异常值条件数量", key: "xx_qxbz_error_num",  sortable: "custom" },    
            { title: "分隔屏焓增C比D高", key: "fgp_hz_c_big_d",  sortable: "custom" },    
            { title: "后屏焓增C比D高", key: "hp_hz_c_big_d",  sortable: "custom" },    
            { title: "高过焓增A比B高", key: "mg_hz_d_big_c",  sortable: "custom" },    
            { title: "低再焓增D比C高", key: "dz_hz_d_big_c",  sortable: "custom" },    
            { title: "末再焓增D比C高", key: "mz_hz_d_big_c",  sortable: "custom" },    
            { title: "烟气浓度右比左高（右切圆）", key: "right_qy_yqnd_r_big_l",  sortable: "custom" },    
            { title: "悬吊管最高点右比左高(右切圆)", key: "right_qy_xdgtop_r_big_l",  sortable: "custom" },    
            { title: "分隔屏焓增B比A低", key: "fgp_hz_b_small_a",  sortable: "custom" },    
            { title: "后屏焓增B比A低", key: "hp_hz_b_small_a",  sortable: "custom" },    
            { title: "高过焓增A比B低", key: "mg_hz_a_small_b",  sortable: "custom" },    
            { title: "低再焓增A比B低", key: "dz_hz_a_small_b",  sortable: "custom" },    
            { title: "末再焓增A比B低", key: "mz_hz_a_small_b",  sortable: "custom" },    
            { title: "烟气浓度左比右低（左切圆）", key: "left_qy_yqnd_l_small_r",  sortable: "custom" },    
            { title: "悬吊管最高点左比右低(左切圆)", key: "left_qy_xdgtop_l_small_r",  sortable: "custom" },    
            { title: "分隔屏焓增C比D低", key: "fgp_hz_c_small_d",  sortable: "custom" },    
            { title: "后屏焓增C比D低", key: "hp_hz_c_small_d",  sortable: "custom" },    
            { title: "高过焓增D比C低", key: "mg_hz_d_small_c",  sortable: "custom" },    
            { title: "低再焓增D比C低", key: "dz_hz_d_small_c",  sortable: "custom" },    
            { title: "末再焓增D比C低", key: "mz_hz_dsmall_c",  sortable: "custom" },    
            { title: "烟气浓度右比左低（右切圆）", key: "right_qy_yqnd_r_small_l",  sortable: "custom" },    
            { title: "悬吊管最高点右比左低(右切圆)", key: "right_qy_xdgtop_r_small_l",  sortable: "custom" },    
            { title: "垂直段水冷壁左墙右墙温度差", key: "czd_temp_left_right",  sortable: "custom" },    
            { title: "左、右切圆后墙悬吊管水冷壁左侧、右侧最高三点平均值的差值", key: "qy_back_xdg_top3_avg_l_r",  sortable: "custom" },    
            { title: "螺旋段水冷壁壁温左侧、右侧最高10个点平均值的差值", key: "lxd_temp_top10_l_r",  sortable: "custom" },    
            { title: "左、右切圆向左、向右偏斜异常值条件数量", key: "qy_px_l_r_num",  sortable: "custom" },    
            { title: "左、右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高", key: "qy_gp_h_big_q",  sortable: "custom" },    
            { title: "左、右切圆前墙管屏水冷壁温度比后墙垂直水冷壁高", key: "qy_gp_q_big_h",  sortable: "custom" },    
            { title: "左、右切圆前墙、后墙螺旋段水冷壁温度差值", key: "qy_lxd_q_h",  sortable: "custom" },    
            { title: "左、右切圆向前、向后偏斜异常值条件数量", key: "qy_px_q_h_num",  sortable: "custom" },    
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
  
    loadError_parameterList() {
      getError_parameterList(this.stores.Error_parameter.query).then(res => {
        this.stores.Error_parameter.data = getDateMore(res.data.data,1,[]);
        this.stores.Error_parameter.query.totalCount = res.data.totalCount;
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
      this.handleResetFormError_parameter();
      this.doLoadAllForinkey();
      this.doLoadError_parameter(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadError_parameterList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormError_parameter();
      this.doLoadAllForinkey();
      this.formModel.fields={
          fgp_hz_b_big_a:"",
          hp_hz_b_big_a:"",
          mg_hz_a_big_b:"",
          dz_hz_a_big_b:"",
          mz_hz_a_big_b:"",
          left_qy_yqnd_l_big_r:"",
          left_qy_xdgtop_l_big_r:"",
          xx_qxbz_error_num:0,
          fgp_hz_c_big_d:"",
          hp_hz_c_big_d:"",
          mg_hz_d_big_c:"",
          dz_hz_d_big_c:"",
          mz_hz_d_big_c:"",
          right_qy_yqnd_r_big_l:"",
          right_qy_xdgtop_r_big_l:"",
          fgp_hz_b_small_a:"",
          hp_hz_b_small_a:"",
          mg_hz_a_small_b:"",
          dz_hz_a_small_b:"",
          mz_hz_a_small_b:"",
          left_qy_yqnd_l_small_r:"",
          left_qy_xdgtop_l_small_r:"",
          fgp_hz_c_small_d:"",
          hp_hz_c_small_d:"",
          mg_hz_d_small_c:"",
          dz_hz_d_small_c:"",
          mz_hz_dsmall_c:"",
          right_qy_yqnd_r_small_l:"",
          right_qy_xdgtop_r_small_l:"",
          czd_temp_left_right:"",
          qy_back_xdg_top3_avg_l_r:"",
          lxd_temp_top10_l_r:"",
          qy_px_l_r_num:0,
          qy_gp_h_big_q:"",
          qy_gp_q_big_h:"",
          qy_lxd_q_h:"",
          qy_px_q_h_num:0,
          DncBoiler:0,
          DncBoiler_Name:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitError_parameter() {
      let valid = this.validateError_parameterForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateError_parameter();
          }
          if (o.formModel.mode === "edit") {
            o.doEditError_parameter();
          }
        }
      });
    },
    handleResetFormError_parameter() {
      this.$refs["formError_parameter"].resetFields();
    },
    doCreateError_parameter() {
      
      createError_parameter(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadError_parameterList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditError_parameter() {
      editError_parameter(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadError_parameterList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateError_parameterForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formError_parameter"].validate(valid => {
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
    doLoadError_parameter(id) {
      loadError_parameter({ code: id+"" }).then(res => {
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
      deleteError_parameter(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadError_parameterList();
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
          this.loadError_parameterList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchError_parameter() {
      this.loadError_parameterList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Error_parameter.query.currentPage = page;
      this.loadError_parameterList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Error_parameter.query.pageSize = pageSize;
      this.loadError_parameterList();
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
        if(this.$refs.m1n1.$children && t<=38){
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
        batchCreateError_parameter({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadError_parameterList();
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
      this.stores.Error_parameter.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadError_parameterList();
    }
  },
  mounted() {
    this.loadError_parameterList();
  }
};
</script>






