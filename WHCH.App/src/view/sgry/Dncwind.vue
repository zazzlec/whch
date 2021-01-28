<style lang="less">
.Wind{
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
      width: 7.69%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Wind">
    <Modal  class="Wind"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">风门名称</i-col><i-col  class="tdtd">组别名称</i-col><i-col  class="tdtd">门宽</i-col><i-col  class="tdtd">门高</i-col><i-col  class="tdtd">0%角度</i-col><i-col  class="tdtd">风门角度（基础工况）</i-col><i-col  class="tdtd">流通面积（基础工况）</i-col><i-col  class="tdtd">百分比（基础工况）</i-col><i-col  class="tdtd">风门角度（实际工况）</i-col><i-col  class="tdtd">流通面积（实际工况）</i-col><i-col  class="tdtd">百分比（实际工况）</i-col><i-col  class="tdtd">锅炉描述</i-col><i-col  class="tdtd">备注</i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="13" />
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
        v-model="stores.Wind.data"
        :totalCount="stores.Wind.query.totalCount"
        :pageSize="stores.Wind.query.pageSize"
        :columns="stores.Wind.columns"
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
                      v-model="stores.Wind.query.kw"
                      placeholder="输入风门名称/搜索..."
                      @on-search="handleSearchWind()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Wind.query.isDeleted"
                        @on-change="handleSearchWind"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Wind.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Wind.query.status"
                        @on-change="handleSearchWind"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Wind.sources.statusSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>

                      <Select
                        slot="prepend"
                        v-model="stores.Wind.query.boilerid"
                        @on-change="handleSearchWind"
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
      <Form :model="formModel.fields" ref="formWind" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="锅炉ID"  prop="DncBoiler_Name">
                          <Select v-model="formModel.fields.DncBoiler_Name" placeholder="锅炉ID" @on-change="handleWindGroup">
                            <Option
                              v-for="item in formSource.DncBoiler "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="组别Id" prop="DncGroup_Name">
                        <Select v-model="formModel.fields.DncGroup_Name" placeholder="组别Id"  >
                            <Option
                              v-for="item in formSource.DncGroup "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                      <!-- <Input-number  v-model="formModel.fields.DncWindgroupId" style="width:100%"></Input-number> -->
                    </FormItem>
                    </Col>
                </Row></Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="风门名称" prop="Wind_Name_kw" >
                      <Input v-model="formModel.fields.Wind_Name_kw" placeholder="请输入风门名称"/>
                    </FormItem>

                    
                    </Col>
                
                    <Col span="12">
                    <FormItem label="0%角度" prop="Angle0">
                      <Input-number  v-model="formModel.fields.Angle0" style="width:100%"></Input-number>
                    </FormItem>
                    
                    </Col>
                </Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="风门角度（基础工况）" prop="Base_angle">
                      <Input-number  v-model="formModel.fields.Base_angle" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="风门角度（实际工况）" prop="Real_angle">
                      <Input-number  v-model="formModel.fields.Real_angle" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row></Row></Row><Row :gutter="16">
                    <Col span="24">
                    <FormItem label="备注" prop="Remarks" >
                      <Input v-model="formModel.fields.Remarks" placeholder="请输入备注"/>
                    </FormItem>
                    </Col>
                </Row>
        

      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitWind">保 存</Button>
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
  getWindgroupList
} from "@/api/ZNRS/Dncwindgroup";
import {
  getWindList,
  createWind,
  loadWind,
  editWind,
  deleteWind,
  batchCommand,
  batchCreateWind
} from "@/api/ZNRS/Dncwind";
export default {
  name: "ZNRS_Wind_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      boilers:[],
      dataorder:["Wind_Name_kw","DncGroup_Name","Doorwitdh","Doorheight","Angle0","Base_angle","Base_ltmj","Base_percent","Real_angle","Real_ltmj","Real_percent","DncBoiler_Name","Remarks"],
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
          Wind_Name_kw: [
            {
              type: "string",
              required: true,
              message: "请输入风门名称",
              min: 1
            }
          ],
           DncBoiler_Name: [
            {
              type: "string",
              required: true,
              message: "请选择锅炉",
              min: 1
            }
          ], 
          DncGroup_Name: [
            {
              type: "string",
              required: true,
              message: "请选择组别",
              min: 1
            }
          ], 
        }
      },
      stores: {
        Wind: {
          query: {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid:-1,
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
            { title: "风门名称", key: "wind_Name_kw",  sortable: "custom" },    
            { title: "组别Id", key: "dncWindgroupId",  sortable: "custom" },    
            { title: "组别名称", key: "dncGroup_Name",  sortable: "custom" },    
            { title: "门宽", key: "doorwitdh",  sortable: "custom" },    
            { title: "门高", key: "doorheight",  sortable: "custom" },    
            { title: "0%角度", key: "angle0",  sortable: "custom" },    
            { title: "风门角度（基础工况）", key: "base_angle",  sortable: "custom" },    
            { title: "流通面积（基础工况）", key: "base_ltmj",  sortable: "custom" },    
            { title: "百分比（基础工况）", key: "base_percent",  sortable: "custom" },    
            { title: "实际时间",width: 100, key: "realTime",  sortable: "custom" ,
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
            { title: "风门角度（实际工况）", key: "real_angle",  sortable: "custom" },    
            { title: "流通面积（实际工况）", key: "real_ltmj",  sortable: "custom" },    
            { title: "百分比（实际工况）", key: "real_percent",  sortable: "custom" },    
            { title: "锅炉描述", key: "dncBoiler_Name",  sortable: "custom" },    
            { title: "备注", key: "remarks",  sortable: "custom" },    
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
            DncGroup:[]
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
  
    loadWindList() {
      getWindList(this.stores.Wind.query).then(res => {
        this.stores.Wind.data = getDateMore(res.data.data,1,["realTime",]);
        this.stores.Wind.query.totalCount = res.data.totalCount;
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
      this.handleResetFormWind();
      this.doLoadAllForinkey();
      this.doLoadWind(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadWindList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormWind();
      this.doLoadAllForinkey();
      this.formModel.fields={
          Wind_Name_kw:"",
          DncGroup_Name:"",
          Doorwitdh:0,
          Doorheight:0,
          Angle0:0,
          Base_angle:0,
          Base_ltmj:0,
          Base_percent:0,
          RealTime:"",
          Real_angle:0,
          Real_ltmj:0,
          Real_percent:0,
          DncBoiler_Name:"",
          Remarks:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitWind() {
      let valid = this.validateWindForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateWind();
          }
          if (o.formModel.mode === "edit") {
            o.doEditWind();
          }
        }
      });
    },
    handleResetFormWind() {
      this.$refs["formWind"].resetFields();
    },
    doCreateWind() {
      
      createWind(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadWindList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditWind() {
      editWind(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadWindList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateWindForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formWind"].validate(valid => {
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
    doLoadWind(id) {
      loadWind({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
        
        let o=this;
        let bid=-1;

        o.formSource.DncBoiler.map(x=>{
          if(x.text== o.formModel.fields.DncBoiler_Name){
            bid=x.value;
          }
        });

        getWindgroupList({
              totalCount: 0,
              pageSize: 20,
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
          let t=[];
          for(var i=0;i<res.data.data.length;i++){
              var item = res.data.data[i];
              t.push({ value: item.id , text: item.group_Name_kw, disabled: !item.status });
          }
          o.formSource.DncGroup=t;
          o.formModel.fields = op;
        });


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

      
      //DncGroup
    },
    handleWindGroup(){
      //formModel.fields.DncBoiler_Name
      let o=this;
      let bid=-1;

      o.formSource.DncBoiler.map(x=>{
        if(x.text== o.formModel.fields.DncBoiler_Name){
          bid=x.value;
        }
      });

      getWindgroupList({
            totalCount: 0,
            pageSize: 20,
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
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.group_Name_kw, disabled: !item.status });
        }
        o.formSource.DncGroup=t;
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
      deleteWind(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadWindList();
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
          this.loadWindList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchWind() {
      this.loadWindList();
    },
    
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Wind.query.currentPage = page;
      this.loadWindList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Wind.query.pageSize = pageSize;
      this.loadWindList();
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
        if(this.$refs.m1n1.$children && t<=13){
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
        batchCreateWind({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadWindList();
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
      this.stores.Wind.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadWindList();
    }
  },
  mounted() {
    this.loadWindList();
  }
};
</script>






