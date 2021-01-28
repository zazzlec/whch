<style lang="less">
.Hztemp_point{
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
      width: 20%;
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
  <div class="Hztemp_point">
    <Modal  class="Hztemp_point"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">测点类型名称</i-col><i-col  class="tdtd">实际时间</i-col><i-col  class="tdtd">测点数值（数组）</i-col><i-col  class="tdtd">备注</i-col><i-col  class="tdtd"></i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="5" />
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
        v-model="stores.Hztemp_point.data"
        :totalCount="stores.Hztemp_point.query.totalCount"
        :pageSize="stores.Hztemp_point.query.pageSize"
        :columns="stores.Hztemp_point.columns"
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
              <Col span="24">
                <Form inline @submit.native.prevent>
                  <FormItem>
                    <DatePicker @on-change="handleSearchHztemp_point2" format="yyyy-MM-dd HH:mm:ss" type="datetime" placeholder="开始时间" style="width: 160px;"></DatePicker>
                    <DatePicker @on-change="handleSearchHztemp_point3" format="yyyy-MM-dd HH:mm:ss" type="datetime" placeholder="结束时间" style="width: 160px;"></DatePicker>
                     <Select
                        v-model="stores.Hztemp_point.query.boilerid"
                        @on-change="handleSearchHztemp_point"
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
                      v-model="stores.Hztemp_point.query.kw"
                      placeholder="输入测点类型名称搜索..."
                      width="200"
                      @on-search="handleSearchHztemp_point()"
                    ></Input>
<!--                      
                    <Input
                      type="text"
                      search
                      :clearable="true"
                      v-model="stores.Hztemp_point.query.kw"
                      placeholder="输入测点类型名称搜索..."
                      @on-search="handleSearchHztemp_point()"
                    >
                    <Select
                        slot="prepend"
                        v-model="stores.Hztemp_point.query.boilerid"
                        @on-change="handleSearchHztemp_point"
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

                    </Input> -->
                  </FormItem>
                </Form>
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
      <Form :model="formModel.fields" ref="formHztemp_point" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="测点类型"  prop="DncType_Name">
                          <Select v-model="formModel.fields.DncType_Name" placeholder="测点类型">
                            <Option
                              v-for="item in formSource.DncType "
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
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="测点数值（数组）" prop="Pvalue" >
                      <Input v-model="formModel.fields.Pvalue" placeholder="请输入测点数值（数组）"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="备注" prop="Remarks" >
                      <Input v-model="formModel.fields.Remarks" placeholder="请输入备注"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
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
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitHztemp_point">保 存</Button>
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
import { getTypeList,getTypeListAll } from "@/api/ZNRS/Dnctype";
import { getBoilerList,getBoilerListAll } from "@/api/ZNRS/Dncboiler";
import {
  getHztemp_pointList,
  createHztemp_point,
  loadHztemp_point,
  editHztemp_point,
  deleteHztemp_point,
  batchCommand,
  batchCreateHztemp_point
} from "@/api/ZNRS/Dnchztemp_point";
export default {
  name: "ZNRS_Hztemp_point_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      boilers:[],
      dataorder:["DncType_Name","RealTime","Pvalue","Remarks","DncBoiler_Name"],
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
           DncType_Name: [
            {
              type: "string",
              required: true,
              message: "请输入测点类型",
              min: 1
            }
          ], 
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
        Hztemp_point: {
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
            { title: "机组名称", key: "dncBoiler_Name",  width:150},  
            { title: "测点类型ID", key: "dncTypeId",  width:150},   
            { title: "测点类型名称", key: "dncType_Name"},    
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
            { title: "测点数值（数组）", key: "pvalue"},    
            { title: "备注", key: "remarks" },    
              
          
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
            //     }
            //   ]
            // }
          ],
          data: []
        }
      },
      formSource: {
            DncType : [] ,
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
  
    loadHztemp_pointList() {
      getHztemp_pointList(this.stores.Hztemp_point.query).then(res => {
        this.stores.Hztemp_point.data = getDateMore(res.data.data,-1,["realTime",]);
        this.stores.Hztemp_point.query.totalCount = res.data.totalCount;
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
      this.handleResetFormHztemp_point();
      this.doLoadAllForinkey();
      this.doLoadHztemp_point(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadHztemp_pointList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormHztemp_point();
      this.doLoadAllForinkey();
      this.formModel.fields={
          DncType:0,
          DncType_Name:"",
          RealTime:"",
          Pvalue:"",
          Remarks:"",
          DncBoiler:0,
          DncBoiler_Name:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitHztemp_point() {
      let valid = this.validateHztemp_pointForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateHztemp_point();
          }
          if (o.formModel.mode === "edit") {
            o.doEditHztemp_point();
          }
        }
      });
    },
    handleResetFormHztemp_point() {
      this.$refs["formHztemp_point"].resetFields();
    },
    doCreateHztemp_point() {
      
      createHztemp_point(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_pointList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditHztemp_point() {
      editHztemp_point(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_pointList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateHztemp_pointForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formHztemp_point"].validate(valid => {
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
    doLoadHztemp_point(id) {
      loadHztemp_point({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
   //     op.DncType_Name=parseInt(op.DncType_Name);
   //     op.DncBoiler_Name=parseInt(op.DncBoiler_Name);
        this.formModel.fields = op;
      });
    },
    doLoadAllForinkey() {
      let o=this;
      ////{PageSize:10,CurrentPage:1,Status:1,IsDeleted:0,Sort:[{Field:"id",Direct:"Desc"}],Kw:""}
      getTypeListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.DncType=t;
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
      deleteHztemp_point(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_pointList();
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
          this.loadHztemp_pointList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchHztemp_point() {
      this.loadHztemp_pointList();
    },
    handleSearchHztemp_point2(d) {
      this.stores.Hztemp_point.query.btime=d;
      this.loadHztemp_pointList();
    },
    handleSearchHztemp_point3(d) {
      this.stores.Hztemp_point.query.etime=d;
      this.loadHztemp_pointList();
    },
    // stores.Hztemp_point.query.btime
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Hztemp_point.query.currentPage = page;
      this.loadHztemp_pointList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Hztemp_point.query.pageSize = pageSize;
      this.loadHztemp_pointList();
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
        if(this.$refs.m1n1.$children && t<=5){
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
        batchCreateHztemp_point({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadHztemp_pointList();
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
      this.stores.Hztemp_point.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadHztemp_pointList();
    }
  },
  mounted() {
    this.loadHztemp_pointList();
  }
};
</script>






