<style lang="less">
.Kyqmade{
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
      width: 16.6666666666667%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Kyqmade">
    <Modal  class="Kyqmade"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">名称</i-col><i-col  class="tdtd">寿命</i-col><i-col  class="tdtd">单位</i-col><i-col  class="tdtd">更换时间</i-col><i-col  class="tdtd">类型</i-col><i-col  class="tdtd">锅炉描述</i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="6" />
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
        v-model="stores.Kyqmade.data"
        :totalCount="stores.Kyqmade.query.totalCount"
        :pageSize="stores.Kyqmade.query.pageSize"
        :columns="stores.Kyqmade.columns"
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
                      v-model="stores.Kyqmade.query.kw"
                      placeholder="输入名称/搜索..."
                      @on-search="handleSearchKyqmade()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Kyqmade.query.isDeleted"
                        @on-change="handleSearchKyqmade"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Kyqmade.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <!-- <Select
                        slot="prepend"
                        v-model="stores.Kyqmade.query.status"
                        @on-change="handleSearchKyqmade"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Kyqmade.sources.statusSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select> -->
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
                  <!-- <Button
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
                  ></Button> -->
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
      <Form :model="formModel.fields" ref="formKyqmade" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="名称" prop="K_Name_kw" >
                      <Input v-model="formModel.fields.K_Name_kw" placeholder="请输入名称"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="寿命" prop="Life_Val">
                    <Input-number  v-model="formModel.fields.Life_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="单位" prop="unit" >
                      <Input v-model="formModel.fields.Unit" placeholder="请输入单位"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="更换时间" prop="changedate">
                    <i-col span="12">
                        <Date-picker @on-change="handlechangedateDateChange" type="date" placeholder="选择更换时间" style="width: 276px" v-model="formModel.fields.Changedate" format="yyyy年MM月dd日"></Date-picker>
                    </i-col>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="类型"  prop="DncKyqTpye_Name">
                          <Select v-model="formModel.fields.DncKyqTpye_Name" placeholder="类型">
                            <Option
                              v-for="item in formSource.DncKyqTpye "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="锅炉ID"  prop="DncBoiler_Name">
                          <Select v-model="formModel.fields.DncBoiler_Name" placeholder="锅炉ID" @on-change="hhh">
                            <Option
                              v-for="item in formSource.DncBoiler "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="空预器Id"  prop="DncKyq_Name">
                          <Select v-model="formModel.fields.DncKyq_Name" placeholder="空预器Id">
                            <Option
                              v-for="item in formSource.DncKyq "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
        </Row>
        

      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitKyqmade">保 存</Button>
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
import { getKyqtypeList,getKyqtypeListAll } from "@/api/ZNRS/Dnckyqtype";
import { getBoilerList,getBoilerListAll } from "@/api/ZNRS/Dncboiler";
import { getKyqList,getKyqListAll } from "@/api/ZNRS/Dnckyq";
import {
  getKyqmadeList,
  createKyqmade,
  loadKyqmade,
  editKyqmade,
  deleteKyqmade,
  batchCommand,
  batchCreateKyqmade
} from "@/api/ZNRS/Dnckyqmade";
export default {
  name: "ZNRS_Kyqmade_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      dataorder:["K_Name_kw","life_Val","unit","changedate","DncKyqTpye_Name","DncBoiler_Name"],
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
              message: "请输入名称",
              min: 1
            }
          ],
           DncKyqTpye_Name: [
            {
              type: "string",
              required: true,
              message: "请输入类型",
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
        Kyqmade: {
          query: {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: -1,
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
            { title: "名称", key: "k_Name_kw",  sortable: "custom" },    
            { title: "寿命", key: "life_Val",  sortable: "custom" },    
            { title: "单位", key: "unit",  sortable: "custom" },    
            { title: "更换时间",width: 100, key: "changedate",  sortable: "custom" ,
              render: (h, params) => {
                let changedate = params.row.changedate;
                if(changedate=="0001-01-01"){
                  changedate= "";
                }else{
                  changedate = params.row.changedate;
                }
                return h('span', [
                                h('strong', changedate)
                            ]);
              }
            }, 
            { title: "类型", key: "dncKyqTpye_Name",  sortable: "custom" },    
            { title: "空预器", key: "dncKyq_Name",  sortable: "custom" },    
            { title: "锅炉描述", key: "dncBoiler_Name",  sortable: "custom" },    
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
            DncKyqTpye : [] ,
            DncBoiler : [] ,
            DncKyq : [] ,
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
    handlechangedateDateChange(date) {
      this.formModel.fields.changedate=date
    },
    hhh(){
    let o=this;
     getKyqList(
       {
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: -1,
            boilerid: -1,
            bname:this.formModel.fields.DncBoiler_Name ,
            sort: [
              {
                direct: "ASC",
                field: "id"
              }
            ]
          }
     ).then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.DncKyq=t;
      });
    },
    loadKyqmadeList() {
      getKyqmadeList(this.stores.Kyqmade.query).then(res => {
        console.log(JSON.stringify(res.data.data));
        this.stores.Kyqmade.data = getDateMore(res.data.data,1,["changedate",]);
        this.stores.Kyqmade.query.totalCount = res.data.totalCount;
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
      this.handleResetFormKyqmade();
      this.doLoadAllForinkey();
      this.doLoadKyqmade(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadKyqmadeList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormKyqmade();
      this.doLoadAllForinkey();
      this.formModel.fields={
          K_Name_kw:"",
          life_Val:0,
          unit:"",
          changedate:"",
          DncKyqTpye_Name:"",
          DncBoiler_Name:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitKyqmade() {
      let valid = this.validateKyqmadeForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateKyqmade();
          }
          if (o.formModel.mode === "edit") {
            o.doEditKyqmade();
          }
        }
      });
    },
    handleResetFormKyqmade() {
      this.$refs["formKyqmade"].resetFields();
    },
    doCreateKyqmade() {
      
      createKyqmade(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadKyqmadeList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditKyqmade() {
      editKyqmade(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadKyqmadeList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateKyqmadeForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formKyqmade"].validate(valid => {
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
    doLoadKyqmade(id) {
      let o=this;
      loadKyqmade({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
   //     op.DncKyqTpye_Name=parseInt(op.DncKyqTpye_Name);
   //     op.DncBoiler_Name=parseInt(op.DncBoiler_Name);
        console.log(JSON.stringify(op));
        this.formModel.fields = op;
        getKyqList(
          {
                totalCount: 0,
                pageSize: 20,
                currentPage: 1,
                kw: "",
                isDeleted: 0,
                status: -1,
                boilerid: -1,
                bname:this.formModel.fields.DncBoiler_Name ,
                sort: [
                  {
                    direct: "ASC",
                    field: "id"
                  }
                ]
              }
        ).then(res => {
            let t=[];
            for(var i=0;i<res.data.data.length;i++){
                var item = res.data.data[i];
                t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
            }
            o.formSource.DncKyq=t;
          });
          this.formModel.fields = op;
      });
    },
    doLoadAllForinkey() {
      let o=this;
      ////{PageSize:10,CurrentPage:1,Status:1,IsDeleted:0,Sort:[{Field:"id",Direct:"Desc"}],Kw:""}
      getKyqtypeListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            if(item.k_Name_kw.indexOf("检修")!=-1)
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.DncKyqTpye=t;
      });
      getBoilerListAll().then(res => {
        let t=[];
        for(var i=0;i<res.data.data.length;i++){
            var item = res.data.data[i];
            t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
        }
        o.formSource.DncBoiler=t;
      });
      // getKyqListAll().then(res => {
      //   let t=[];
      //   for(var i=0;i<res.data.data.length;i++){
      //       var item = res.data.data[i];
      //       t.push({ value: item.id , text: item.k_Name_kw, disabled: !item.status });
      //   }
      //   o.formSource.DncKyq=t;
      // });
    },
    handleDelete(params) {
      this.doDelete(params.row.id);
    },
    doDelete(ids) {
      if (!ids) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      deleteKyqmade(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadKyqmadeList();
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
          this.loadKyqmadeList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchKyqmade() {
      this.loadKyqmadeList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Kyqmade.query.currentPage = page;
      this.loadKyqmadeList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Kyqmade.query.pageSize = pageSize;
      this.loadKyqmadeList();
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
        if(this.$refs.m1n1.$children && t<=6){
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
        batchCreateKyqmade({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadKyqmadeList();
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
      this.stores.Kyqmade.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadKyqmadeList();
    }
  },
  mounted() {
    this.loadKyqmadeList();
  }
};
</script>






