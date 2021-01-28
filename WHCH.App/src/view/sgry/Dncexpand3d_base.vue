<style lang="less">
.Expand3d_base{
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
      width: 6.25%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Expand3d_base">
    <Modal  class="Expand3d_base"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">点位名称</i-col><i-col  class="tdtd">点位号</i-col><i-col  class="tdtd">X坐标</i-col><i-col  class="tdtd">Y坐标</i-col><i-col  class="tdtd">X轴膨胀上限值</i-col><i-col  class="tdtd">X轴膨胀下限值</i-col><i-col  class="tdtd">Y轴膨胀上限值</i-col><i-col  class="tdtd">Y轴膨胀下限值</i-col><i-col  class="tdtd">Z轴膨胀上限值</i-col><i-col  class="tdtd">Z轴膨胀下限值</i-col><i-col  class="tdtd">X轴额定值</i-col><i-col  class="tdtd">Y轴额定值</i-col><i-col  class="tdtd">Z轴额定值</i-col><i-col  class="tdtd">备注</i-col><i-col  class="tdtd">锅炉名称</i-col><i-col  class="tdtd">组别名称</i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="16" />
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
        v-model="stores.Expand3d_base.data"
        :totalCount="stores.Expand3d_base.query.totalCount"
        :pageSize="stores.Expand3d_base.query.pageSize"
        :columns="stores.Expand3d_base.columns"
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
                      v-model="stores.Expand3d_base.query.kw"
                      placeholder="输入点位名称/搜索..."
                      @on-search="handleSearchExpand3d_base()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Expand3d_base.query.isDeleted"
                        @on-change="handleSearchExpand3d_base"
                        placeholder="删除状态"
                        style="width:100px;"
                      >
                        <Option
                          v-for="item in stores.Expand3d_base.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Expand3d_base.query.status"
                        @on-change="handleSearchExpand3d_base"
                        placeholder="状态"
                        style="width:100px;"
                      >
                        <Option
                          v-for="item in stores.Expand3d_base.sources.statusSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>

                      <Select
                        slot="prepend"
                        v-model="stores.Expand3d_base.query.boilerid"
                        @on-change="handleSearchExpand3d_base"
                        placeholder="机组"
                        style="width:100px;"
                      >
                      <Option
                          value="-1"
                          key="-1"
                        >不限机组</Option>
                        <Option
                          v-for="item in boilers"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                    </Select>

                    <Select
                        slot="prepend"
                        v-model="stores.Expand3d_base.query.gid"
                        @on-change="handleSearchExpand3d_base"
                        placeholder="组别"
                        style="width:100px;"
                      >
                      <Option
                          value=""
                          key=""
                        >不限组别</Option>
                        <Option
                          v-for="item in groups"
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
      <Form :model="formModel.fields" ref="formExpand3d_base" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="点位名称" prop="K_Name_kw">
                      <Input v-model="formModel.fields.K_Name_kw" placeholder="请输入点位名称"/>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="点位号" prop="R_GroupId" >
                      <Input v-model="formModel.fields.R_GroupId" placeholder="请输入点位号"/>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="X坐标" prop="R_X_axis">
                    <Input-number  v-model="formModel.fields.R_X_axis" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="8">
                    <FormItem label="Y坐标" prop="R_Y_axis">
                    <Input-number  v-model="formModel.fields.R_Y_axis" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="X轴膨胀上限值" prop="R_X_up">
                    <Input-number  v-model="formModel.fields.R_X_up" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="X轴膨胀下限值" prop="R_X_down">
                    <Input-number  v-model="formModel.fields.R_X_down" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="8">
                    <FormItem label="Y轴膨胀上限值" prop="R_Y_up">
                    <Input-number  v-model="formModel.fields.R_Y_up" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="Y轴膨胀下限值" prop="R_Y_down">
                    <Input-number  v-model="formModel.fields.R_Y_down" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="Z轴膨胀上限值" prop="R_Z_up">
                    <Input-number  v-model="formModel.fields.R_Z_up" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="8">
                    <FormItem label="Z轴膨胀下限值" prop="R_Z_down">
                    <Input-number  v-model="formModel.fields.R_Z_down" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="X轴额定值" prop="R_X_ed">
                    <Input-number  v-model="formModel.fields.R_X_ed" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="Y轴额定值" prop="R_Y_ed">
                    <Input-number  v-model="formModel.fields.R_Y_ed" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="8">
                    <FormItem label="Z轴额定值" prop="R_Z_ed">
                    <Input-number  v-model="formModel.fields.R_Z_ed" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="锅炉ID"  prop="DncBoiler_Name">
                          <Select v-model="formModel.fields.DncBoiler_Name" placeholder="锅炉ID"  @on-change="hdld">
                            <Option
                              v-for="item in formSource.Dncboiler "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    
                    </Col>
                
                    <Col span="8">
                      <FormItem label="分组号"  prop="Dncexpandgroup_Name">
                                          <Select v-model="formModel.fields.Dncexpandgroup_Name" placeholder="分组号">
                                            <Option
                                              v-for="item in formSource.Dncexpandgroup "
                                              :value="item.text"
                                              :disabled="item.disabled"
                                              :key="item.text"
                                            >{{item.text}}</Option>
                                          </Select>
                        </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="24">
                    <FormItem label="备注" prop="Remarks" >
                      <Input v-model="formModel.fields.Remarks" placeholder="请输入备注"/>
                    </FormItem>
                    </Col>
                </Row>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitExpand3d_base">保 存</Button>
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
  getExpand3d_baseList,
  createExpand3d_base,
  loadExpand3d_base,
  editExpand3d_base,
  deleteExpand3d_base,
  batchCommand,
  batchCreateExpand3d_base
} from "@/api/ZNRS/Dncexpand3d_base";
import { getExpandgroupListAll } from "@/api/ZNRS/Dncexpandgroup";
export default {
  name: "znrs_Expand3d_base_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      boilers:[],
      groups:[],
      dataorder:["K_Name_kw","R_GroupId","R_X_axis","R_Y_axis","R_X_up","R_X_down","R_Y_up","R_Y_down","R_Z_up","R_Z_down","R_X_ed","R_Y_ed","R_Z_ed","Remarks","Dncboiler_Name","Dncexpandgroup_Name"],
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
          K_Name_kw: [
            {
              type: "string",
              required: true,
              message: "请输入点位名称",
              min: 1
            }
          ],
           Dncboiler_Name: [
            {
              type: "string",
              required: true,
              message: "请选择锅炉",
              min: 1
            }
          ], 
        }
      },
      stores: {
        Expand3d_base: {
          query: {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid:-1,
            gid:"",
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
            { title: "点位名称", key: "k_Name_kw",  sortable: "custom" ,width:100},    
            { title: "点位号", key: "r_GroupId",  sortable: "custom" ,align:"center"},    
            { title: "X坐标", key: "r_X_axis",  sortable: "custom",render: (h, params) => {return h("span",params.row.r_X_axis.toFixed(2))} },    
            { title: "Y坐标", key: "r_Y_axis",  sortable: "custom",render: (h, params) => {return h("span",params.row.r_Y_axis.toFixed(2))}  },    
            { title: "X轴膨胀上限值", key: "r_X_up",  sortable: "custom" },    
            { title: "X轴膨胀下限值", key: "r_X_down",  sortable: "custom" },    
            { title: "Y轴膨胀上限值", key: "r_Y_up",  sortable: "custom" },    
            { title: "Y轴膨胀下限值", key: "r_Y_down",  sortable: "custom" },    
            { title: "Z轴膨胀上限值", key: "r_Z_up",  sortable: "custom" },    
            { title: "Z轴膨胀下限值", key: "r_Z_down",  sortable: "custom" },    
            { title: "X轴额定值", key: "r_X_ed",  sortable: "custom" },    
            { title: "Y轴额定值", key: "r_Y_ed",  sortable: "custom" },    
            { title: "Z轴额定值", key: "r_Z_ed",  sortable: "custom" },    
            

            { title: "分组名称", key: "dncexpandgroup_Name",  sortable: "custom" }, 
            { title: "锅炉名称", key: "dncBoiler_Name",  sortable: "custom" },  
            { title: "备注", key: "remarks",  sortable: "custom" },      
            {
              title: "状态",
              key: "status",
              align: "center",
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
            Dncboiler : [] ,
            Dncexpandgroup : [] ,
            Dncexpandgroupbak : [] ,
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
  
    loadExpand3d_baseList() {
      getExpand3d_baseList(this.stores.Expand3d_base.query).then(res => {
        this.stores.Expand3d_base.data = getDateMore(res.data.data,1,[]);
        this.stores.Expand3d_base.query.totalCount = res.data.totalCount;
      });

      let o=this;
      getBoilerListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.boilers=t;
      });

      getExpandgroupListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status , bname : item.dncboiler_Name });
        }
        // console.log(JSON.stringify(t));
        o.groups=t;
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
      this.handleResetFormExpand3d_base();
      this.doLoadAllForinkey();
      this.doLoadExpand3d_base(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadExpand3d_baseList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormExpand3d_base();
      this.doLoadAllForinkey();
      this.formModel.fields={
          K_Name_kw:"",
          Remarks:"",
          Dncexpandgroup_Name:"无",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitExpand3d_base() {
      let valid = this.validateExpand3d_baseForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateExpand3d_base();
          }
          if (o.formModel.mode === "edit") {
            o.doEditExpand3d_base();
          }
        }
      });
    },
    handleResetFormExpand3d_base() {
      this.$refs["formExpand3d_base"].resetFields();
    },
    doCreateExpand3d_base() {
      if(!this.formModel.fields.DncBoiler_Name || this.formModel.fields.DncBoiler_Name == null){
        this.$Message.error("请选择锅炉");
        return;
      }
      createExpand3d_base(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadExpand3d_baseList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditExpand3d_base() {
      if(!this.formModel.fields.DncBoiler_Name || this.formModel.fields.DncBoiler_Name == null){
        this.$Message.error("请选择锅炉");
        return;
      }
      editExpand3d_base(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadExpand3d_baseList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateExpand3d_baseForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formExpand3d_base"].validate(valid => {
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
    doLoadExpand3d_base(id) {
      loadExpand3d_base({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
        this.formModel.fields = op;
        this.formSource.Dncexpandgroup=this.formSource.Dncexpandgroupbak.filter(x=>x.bname==this.formModel.fields.DncBoiler_Name);
      });
    },
    doLoadAllForinkey() {
      let o=this;
      getBoilerListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.Dncboiler=t;
      });

      getExpandgroupListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status , bname : item.dncboiler_Name });
        }
        // console.log(JSON.stringify(t));
        o.formSource.Dncexpandgroupbak=t;
        o.formSource.Dncexpandgroup=t;
      });
    },
    hdld(){
      let o=this;
      // alert(JSON.stringify(o.formSource.Dncexpandgroupbak))
      o.formSource.Dncexpandgroup=o.formSource.Dncexpandgroupbak.filter(x=>x.bname==this.formModel.fields.DncBoiler_Name);
    },
    handleDelete(params) {
      this.doDelete(params.row.id);
    },
    doDelete(ids) {
      if (!ids) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      deleteExpand3d_base(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadExpand3d_baseList();
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
          this.loadExpand3d_baseList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchExpand3d_base() {
      this.loadExpand3d_baseList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Expand3d_base.query.currentPage = page;
      this.loadExpand3d_baseList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Expand3d_base.query.pageSize = pageSize;
      this.loadExpand3d_baseList();
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
        if(this.$refs.m1n1.$children && t<=16){
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
        batchCreateExpand3d_base({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadExpand3d_baseList();
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
      this.stores.Expand3d_base.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadExpand3d_baseList();
    }
  },
  mounted() {
    this.loadExpand3d_baseList();
  }
};
</script>






