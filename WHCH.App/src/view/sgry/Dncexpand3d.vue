<style lang="less">
.Expand3d{
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
      width: 14.2857142857143%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
    .ivu-input-wrapper{
      width: 160px !important;
    }
  }  
</style>
<template>
  <div class="Expand3d">
    <Modal  class="Expand3d"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">点位名称</i-col><i-col  class="tdtd">实际时间</i-col><i-col  class="tdtd">X轴膨胀值</i-col><i-col  class="tdtd">Y轴膨胀值</i-col><i-col  class="tdtd">Z轴膨胀值</i-col><i-col  class="tdtd">备注</i-col><i-col  class="tdtd">锅炉名称</i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="7" />
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
        v-model="stores.Expand3d.data"
        :totalCount="stores.Expand3d.query.totalCount"
        :pageSize="stores.Expand3d.query.pageSize"
        :columns="stores.Expand3d.columns"
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

                    <DatePicker @on-change="handleSearchHztemp_point2" format="yyyy-MM-dd HH:mm:ss" type="datetime" placeholder="开始时间" style="width: 160px;"></DatePicker>
                    <DatePicker @on-change="handleSearchHztemp_point3" format="yyyy-MM-dd HH:mm:ss" type="datetime" placeholder="结束时间" style="width: 160px;"></DatePicker>
                     <Select
                        v-model="stores.Expand3d.query.boilerid"
                        @on-change="handleSearchExpand3d"
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
                    <Input
                      type="text"
                      search
                      :clearable="true"
                      v-model="stores.Expand3d.query.kw"
                      placeholder="输入点位名称搜索..."
                      width="200"
                      @on-search="handleSearchExpand3d()"
                    ></Input>


                    <!-- <Input
                      type="text"
                      search
                      :clearable="true"
                      v-model="stores.Expand3d.query.kw"
                      placeholder="输入点位名称搜索..."
                      @on-search="handleSearchExpand3d()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Expand3d.query.isDeleted"
                        @on-change="handleSearchExpand3d"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Expand3d.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Expand3d.query.status"
                        @on-change="handleSearchExpand3d"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Expand3d.sources.statusSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                    </Input> -->
                  </FormItem>
                </Form>
              </Col>
              <Col span="8" class="dnc-toolbar-btns">
                <!-- <ButtonGroup class="mr3">
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
                >新增</Button> -->
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
      <Form :model="formModel.fields" ref="formExpand3d" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="点位ID"  prop="DncExpand3d_base_Name">
                          <Select v-model="formModel.fields.DncExpand3d_base_Name" placeholder="点位ID">
                            <Option
                              v-for="item in formSource.DncExpand3d_base "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="实际时间" prop="RealTime">
                    <i-col span="12">
                        <Date-picker @on-change="handleRealTimeDateChange" type="date" placeholder="选择实际时间" style="width: 276px" v-model="formModel.fields.RealTime" format="yyyy年MM月dd日"></Date-picker>
                    </i-col>
                    </FormItem>
                    </Col>
                </Row></Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="备注" prop="Remarks" >
                      <Input v-model="formModel.fields.Remarks" placeholder="请输入备注"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="锅炉ID"  prop="DncBoiler_Name">
                          <Select v-model="formModel.fields.DncBoiler_Name" placeholder="锅炉ID">
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
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitExpand3d">保 存</Button>
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
import { getExpand3d_baseList,getExpand3d_baseListAll } from "@/api/ZNRS/Dncexpand3d_base";
import { getBoilerList,getBoilerListAll } from "@/api/ZNRS/Dncboiler";

import {
  getExpand3dList,
  createExpand3d,
  loadExpand3d,
  editExpand3d,
  deleteExpand3d,
  batchCommand,
  batchCreateExpand3d
} from "@/api/ZNRS/Dncexpand3d";
export default {
  name: "sgry_Expand3d_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      boilers:[],
      dataorder:["DncExpand3d_base_Name","RealTime","R_X_expand","R_Y_expand","R_Z_expand","Remarks","DncBoiler_Name"],
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
           DncExpand3d_base_Name: [
            {
              type: "string",
              required: true,
              message: "请输入点位ID",
              min: 1
            }
          ], 
           DncBoiler_Name: [
            {
              type: "string",
              required: true,
              message: "请输入锅炉ID",
              min: 1
            }
          ], 
        }
      },
      stores: {
        Expand3d: {
          query: {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid:-1,
            btime:"",
            etime:"",
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
            // { type: "selection", width: 50, key: "handle" },
            { title: "锅炉名称", key: "dncBoiler_Name" }, 
            { title: "点位名称", key: "dncexpand3d_base_Name" }, 
            { title: "实际时间", key: "realTime" ,
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
            { title: "X轴膨胀值", key: "r_X_expand" ,render: (h, params) => {return h("span",params.row.r_X_expand.toFixed(2))} },    
            { title: "Y轴膨胀值", key: "r_Y_expand" ,render: (h, params) => {return h("span",params.row.r_Y_expand.toFixed(2))} },    
            { title: "Z轴膨胀值", key: "r_Z_expand" ,render: (h, params) => {return h("span",params.row.r_Z_expand.toFixed(2))} },    
            { title: "备注", key: "remarks" },    
               
            // {
            //   title: "状态",
            //   key: "status",
            //   align: "center",
            //   render: (h, params) => {
            //     let status = params.row.status;
            //     let statusColor = "success";
            //     let statusText = "正常";
            //     switch (status) {
            //       case 0:
            //         statusText = "禁用";
            //         statusColor = "default";
            //         break;
            //     }
            //     return h(
            //       "Tooltip",
            //       {
            //         props: {
            //           placement: "top",
            //           transfer: true,
            //           delay: 500
            //         }
            //       },
            //       [
            //         //这个中括号表示是Tooltip标签的子标签
            //         h(
            //           "Tag",
            //           {
            //             props: {
            //               //type: "dot",
            //               color: statusColor
            //             }
            //           },
            //           statusText
            //         ), //表格列显示文字
            //         h(
            //           "p",
            //           {
            //             slot: "content",
            //             style: {
            //               whiteSpace: "normal"
            //             }
            //           },
            //           statusText //整个的信息即气泡内文字
            //         )
            //       ]
            //     );
            //   }
            // },
            // {
            //   title: "操作",
            //   align: "center",
            //   key: "handle",
            //   width: 150,
            //   className: "table-command-column",
            //   options: ["edit"],
            //   button: [
            //     (h, params, vm) => {
            //       return h(
            //         "Poptip",
            //         {
            //           props: {
            //             confirm: true,
            //             title: "你确定要删除吗?"
            //           },
            //           on: {
            //             "on-ok": () => {
            //               vm.$emit("on-delete", params);
            //             }
            //           }
            //         },
            //         [
            //           h(
            //             "Tooltip",
            //             {
            //               props: {
            //                 placement: "left",
            //                 transfer: true,
            //                 delay: 1000
            //               }
            //             },
            //             [
            //               h("Button", {
            //                 props: {
            //                   shape: "circle",
            //                   size: "small",
            //                   icon: "md-trash",
            //                   type: "error"
            //                 }
            //               }),
            //               h(
            //                 "p",
            //                 {
            //                   slot: "content",
            //                   style: {
            //                     whiteSpace: "normal"
            //                   }
            //                 },
            //                 "删除"
            //               )
            //             ]
            //           )
            //         ]
            //       );
            //     },
            //     (h, params, vm) => {
            //       return h(
            //         "Tooltip",
            //         {
            //           props: {
            //             placement: "left",
            //             transfer: true,
            //             delay: 1000
            //           }
            //         },
            //         [
            //           h("Button", {
            //             props: {
            //               shape: "circle",
            //               size: "small",
            //               icon: "md-create",
            //               type: "primary"
            //             },
            //             on: {
            //               click: () => {
            //                 vm.$emit("on-edit", params);
            //                 vm.$emit("input", params.tableData);
            //               }
            //             }
            //           }),
            //           h(
            //             "p",
            //             {
            //               slot: "content",
            //               style: {
            //                 whiteSpace: "normal"
            //               }
            //             },
            //             "编辑"
            //           )
            //         ]
            //       );
            //     }
            //   ]
            // }
          ],
          data: []
        }
      },
      formSource: {
            DncExpand3d_base : [] ,
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
  
    loadExpand3dList() {
      getExpand3dList(this.stores.Expand3d.query).then(res => {
        this.stores.Expand3d.data = getDateMore(res.data.data,-1,["realTime",]);
        this.stores.Expand3d.query.totalCount = res.data.totalCount;
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
      this.handleResetFormExpand3d();
      this.doLoadAllForinkey();
      this.doLoadExpand3d(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadExpand3dList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormExpand3d();
      this.doLoadAllForinkey();
      this.formModel.fields={
          DncExpand3d_base:0,
          DncExpand3d_base_Name:"",
          RealTime:"",
          R_X_expand:"",
          R_Y_expand:"",
          R_Z_expand:"",
          Remarks:"",
          DncBoiler:0,
          DncBoiler_Name:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitExpand3d() {
      let valid = this.validateExpand3dForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateExpand3d();
          }
          if (o.formModel.mode === "edit") {
            o.doEditExpand3d();
          }
        }
      });
    },
    handleResetFormExpand3d() {
      this.$refs["formExpand3d"].resetFields();
    },
    doCreateExpand3d() {
      
      createExpand3d(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadExpand3dList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditExpand3d() {
      editExpand3d(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadExpand3dList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateExpand3dForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formExpand3d"].validate(valid => {
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
    doLoadExpand3d(id) {
      loadExpand3d({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
   //     op.DncExpand3d_base_Name=parseInt(op.DncExpand3d_base_Name);
   //     op.DncBoiler_Name=parseInt(op.DncBoiler_Name);
        this.formModel.fields = op;
      });
    },
    doLoadAllForinkey() {
      let o=this;
      ////{PageSize:10,CurrentPage:1,Status:1,IsDeleted:0,Sort:[{Field:"id",Direct:"Desc"}],Kw:""}
      getExpand3d_baseListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.DncExpand3d_base=t;
      });
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
      deleteExpand3d(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadExpand3dList();
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
          this.loadExpand3dList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchExpand3d() {
      this.loadExpand3dList();
    },
    handleSearchHztemp_point2(d) {
      this.stores.Expand3d.query.btime=d;
      this.loadExpand3dList();
    },
    handleSearchHztemp_point3(d) {
      this.stores.Expand3d.query.etime=d;
      this.loadExpand3dList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Expand3d.query.currentPage = page;
      this.loadExpand3dList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Expand3d.query.pageSize = pageSize;
      this.loadExpand3dList();
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
        if(this.$refs.m1n1.$children && t<=7){
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
        batchCreateExpand3d({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadExpand3dList();
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
      this.stores.Expand3d.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadExpand3dList();
    }
  },
  mounted() {
    this.loadExpand3dList();
  }
};
</script>






