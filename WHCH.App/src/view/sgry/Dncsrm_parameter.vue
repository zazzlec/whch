<style lang="less">
.Srm_parameter{
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
      width: 1.88679245283019%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Srm_parameter">
    <Modal  class="Srm_parameter"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">再热蒸汽设计流量</i-col><i-col  class="tdtd">焓增计算公式参数1</i-col><i-col  class="tdtd">焓增计算公式参数2</i-col><i-col  class="tdtd">焓增计算公式参数3</i-col><i-col  class="tdtd">焓增计算公式参数4</i-col><i-col  class="tdtd">焓增计算公式参数5</i-col><i-col  class="tdtd">焓增计算公式参数6</i-col><i-col  class="tdtd">焓增计算公式参数7</i-col><i-col  class="tdtd">焓增计算公式参数8</i-col><i-col  class="tdtd">再热器减温水量对煤耗影响系数</i-col><i-col  class="tdtd">高温再热器出口温度额定值</i-col><i-col  class="tdtd">高温再热器出口温度上限值</i-col><i-col  class="tdtd">高温再热器出口温度下限值</i-col><i-col  class="tdtd">高温再热器出口温度对煤耗影响系数</i-col><i-col  class="tdtd">末级过热器出口温度额定值</i-col><i-col  class="tdtd">末级过热器出口温度上限值</i-col><i-col  class="tdtd">末级过热器出口温度下限值</i-col><i-col  class="tdtd">末级过热器出口温度对煤耗影响系数</i-col><i-col  class="tdtd">负荷区间</i-col><i-col  class="tdtd">氧量上限区间</i-col><i-col  class="tdtd">氧量下限区间</i-col><i-col  class="tdtd">Nox上限区间</i-col><i-col  class="tdtd">Nox下限区间</i-col><i-col  class="tdtd">沾污系数计算负荷区间</i-col><i-col  class="tdtd">分隔屏设计焓增参考值区间</i-col><i-col  class="tdtd">分隔屏设计沾污系数</i-col><i-col  class="tdtd">分隔屏沾污系数上限</i-col><i-col  class="tdtd">分隔屏沾污系数下限</i-col><i-col  class="tdtd">后屏设计焓增参考值区间</i-col><i-col  class="tdtd">后屏设计沾污系数</i-col><i-col  class="tdtd">后屏沾污系数上限</i-col><i-col  class="tdtd">后屏沾污系数下限</i-col><i-col  class="tdtd">末级过热器设计焓增参考值区间</i-col><i-col  class="tdtd">末级过热器设计沾污系数</i-col><i-col  class="tdtd">末级过热器沾污系数上限</i-col><i-col  class="tdtd">末级过热器沾污系数下限</i-col><i-col  class="tdtd">低温再热器设计焓增参考值区间</i-col><i-col  class="tdtd">低温再热器设计沾污系数</i-col><i-col  class="tdtd">低温再热器沾污系数上限</i-col><i-col  class="tdtd">低温再热器沾污系数下限</i-col><i-col  class="tdtd">高温再热器设计焓增参考值区间</i-col><i-col  class="tdtd">高温再热器设计沾污系数</i-col><i-col  class="tdtd">高温再热器沾污系数上限</i-col><i-col  class="tdtd">高温再热器沾污系数下限</i-col><i-col  class="tdtd">低温过热器设计焓值参考值</i-col><i-col  class="tdtd">低温过热器设计沾污系数</i-col><i-col  class="tdtd">低温过热器沾污系数上限</i-col><i-col  class="tdtd">低温过热器沾污系数下限</i-col><i-col  class="tdtd">AGP风量基础工况占比(%)</i-col><i-col  class="tdtd">一级过热器减温水量设计值</i-col><i-col  class="tdtd">二级过热器减温水量设计值</i-col><i-col  class="tdtd">三级过热器减温水量设计值</i-col><i-col  class="tdtd"></i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="53" />
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
        v-model="stores.Srm_parameter.data"
        :totalCount="stores.Srm_parameter.query.totalCount"
        :pageSize="stores.Srm_parameter.query.pageSize"
        :columns="stores.Srm_parameter.columns"
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
                      v-model="stores.Srm_parameter.query.kw"
                      placeholder="输入搜索..."
                      @on-search="handleSearchSrm_parameter()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Srm_parameter.query.isDeleted"
                        @on-change="handleSearchSrm_parameter"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Srm_parameter.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Srm_parameter.query.status"
                        @on-change="handleSearchSrm_parameter"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Srm_parameter.sources.statusSources"
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
      <Form :model="formModel.fields" ref="formSrm_parameter" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="负荷区间" prop="fh_zone" >
                      <Input v-model="formModel.fields.fh_zone" placeholder="请输入负荷区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="氧量上限区间" prop="o2_high_zone" >
                      <Input v-model="formModel.fields.o2_high_zone" placeholder="请输入氧量上限区间"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="氧量下限区间" prop="o2_low_zone" >
                      <Input v-model="formModel.fields.o2_low_zone" placeholder="请输入氧量下限区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="Nox上限区间" prop="nox_high_zone" >
                      <Input v-model="formModel.fields.nox_high_zone" placeholder="请输入Nox上限区间"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="Nox下限区间" prop="nox_low_zone" >
                      <Input v-model="formModel.fields.nox_low_zone" placeholder="请输入Nox下限区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="沾污系数计算负荷区间" prop="zwxs_fh_zone" >
                      <Input v-model="formModel.fields.zwxs_fh_zone" placeholder="请输入沾污系数计算负荷区间"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="分隔屏设计焓增参考值区间" prop="fgp_design_hz_zone" >
                      <Input v-model="formModel.fields.fgp_design_hz_zone" placeholder="请输入分隔屏设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="后屏设计焓增参考值区间" prop="hp_design_hz_zone" >
                      <Input v-model="formModel.fields.hp_design_hz_zone" placeholder="请输入后屏设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                </Row></Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="末级过热器设计焓增参考值区间" prop="mg_design_hz_zone" >
                      <Input v-model="formModel.fields.mg_design_hz_zone" placeholder="请输入末级过热器设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="低温再热器设计焓增参考值区间" prop="dz_design_hz_zone" >
                      <Input v-model="formModel.fields.dz_design_hz_zone" placeholder="请输入低温再热器设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                </Row></Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="高温再热器设计焓增参考值区间" prop="gz_design_hz_zone" >
                      <Input v-model="formModel.fields.gz_design_hz_zone" placeholder="请输入高温再热器设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="低温过热器设计焓值参考值" prop="dg_design_hz_zone" >
                      <Input v-model="formModel.fields.dg_design_hz_zone" placeholder="请输入低温过热器设计焓值参考值"/>
                    </FormItem>
                    </Col>
                </Row></Row></Row></Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="一级过热器减温水量设计值" prop="grq_jws_design_1" >
                      <Input v-model="formModel.fields.grq_jws_design_1" placeholder="请输入一级过热器减温水量设计值"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="二级过热器减温水量设计值" prop="grq_jws_design_2" >
                      <Input v-model="formModel.fields.grq_jws_design_2" placeholder="请输入二级过热器减温水量设计值"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="三级过热器减温水量设计值" prop="grq_jws_design_3" >
                      <Input v-model="formModel.fields.grq_jws_design_3" placeholder="请输入三级过热器减温水量设计值"/>
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
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitSrm_parameter">保 存</Button>
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
  getSrm_parameterList,
  createSrm_parameter,
  loadSrm_parameter,
  editSrm_parameter,
  deleteSrm_parameter,
  batchCommand,
  batchCreateSrm_parameter
} from "@/api/ZNRS/Dncsrm_parameter";
export default {
  name: "ZNRS_Srm_parameter_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      dataorder:["zrqll_design","hz_a1","hz_a2","hz_a3","hz_a4","hz_a5","hz_a6","hz_a7","hz_a8","zrq_jws_mh_xs","gz_out_temp_ed","gz_out_temp_high","gz_out_temp_low","gz_out_temp_mh_xs","mg_out_temp_ed","mg_out_temp_high","mg_out_temp_low","mg_out_temp_mh_xs","fh_zone","o2_high_zone","o2_low_zone","nox_high_zone","nox_low_zone","zwxs_fh_zone","fgp_design_hz_zone","fgp_design_zwxs","fgp_zwxs_high","fgp_zwxs_low","hp_design_hz_zone","hp_design_zwxs","hp_zwxs_high","hp_zwxs_low","mg_design_hz_zone","mg_design_zwxs","mg_zwxs_high","mg_zwxs_low","dz_design_hz_zone","dz_design_zwxs","dz_zwxs_high","dz_zwxs_low","gz_design_hz_zone","gz_design_zwxs","gz_zwxs_high","gz_zwxs_low","dg_design_hz_zone","dg_design_zwxs","dg_zwxs_high","dg_zwxs_low","agp_basic_percent","grq_jws_design_1","grq_jws_design_2","grq_jws_design_3","DncBoiler_Name"],
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
        Srm_parameter: {
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
            { title: "再热蒸汽设计流量", key: "zrqll_design",  sortable: "custom" },    
            { title: "焓增计算公式参数1", key: "hz_a1",  sortable: "custom" },    
            { title: "焓增计算公式参数2", key: "hz_a2",  sortable: "custom" },    
            { title: "焓增计算公式参数3", key: "hz_a3",  sortable: "custom" },    
            { title: "焓增计算公式参数4", key: "hz_a4",  sortable: "custom" },    
            { title: "焓增计算公式参数5", key: "hz_a5",  sortable: "custom" },    
            { title: "焓增计算公式参数6", key: "hz_a6",  sortable: "custom" },    
            { title: "焓增计算公式参数7", key: "hz_a7",  sortable: "custom" },    
            { title: "焓增计算公式参数8", key: "hz_a8",  sortable: "custom" },    
            { title: "再热器减温水量对煤耗影响系数", key: "zrq_jws_mh_xs",  sortable: "custom" },    
            { title: "高温再热器出口温度额定值", key: "gz_out_temp_ed",  sortable: "custom" },    
            { title: "高温再热器出口温度上限值", key: "gz_out_temp_high",  sortable: "custom" },    
            { title: "高温再热器出口温度下限值", key: "gz_out_temp_low",  sortable: "custom" },    
            { title: "高温再热器出口温度对煤耗影响系数", key: "gz_out_temp_mh_xs",  sortable: "custom" },    
            { title: "末级过热器出口温度额定值", key: "mg_out_temp_ed",  sortable: "custom" },    
            { title: "末级过热器出口温度上限值", key: "mg_out_temp_high",  sortable: "custom" },    
            { title: "末级过热器出口温度下限值", key: "mg_out_temp_low",  sortable: "custom" },    
            { title: "末级过热器出口温度对煤耗影响系数", key: "mg_out_temp_mh_xs",  sortable: "custom" },    
            { title: "负荷区间", key: "fh_zone",  sortable: "custom" },    
            { title: "氧量上限区间", key: "o2_high_zone",  sortable: "custom" },    
            { title: "氧量下限区间", key: "o2_low_zone",  sortable: "custom" },    
            { title: "Nox上限区间", key: "nox_high_zone",  sortable: "custom" },    
            { title: "Nox下限区间", key: "nox_low_zone",  sortable: "custom" },    
            { title: "沾污系数计算负荷区间", key: "zwxs_fh_zone",  sortable: "custom" },    
            { title: "分隔屏设计焓增参考值区间", key: "fgp_design_hz_zone",  sortable: "custom" },    
            { title: "分隔屏设计沾污系数", key: "fgp_design_zwxs",  sortable: "custom" },    
            { title: "分隔屏沾污系数上限", key: "fgp_zwxs_high",  sortable: "custom" },    
            { title: "分隔屏沾污系数下限", key: "fgp_zwxs_low",  sortable: "custom" },    
            { title: "后屏设计焓增参考值区间", key: "hp_design_hz_zone",  sortable: "custom" },    
            { title: "后屏设计沾污系数", key: "hp_design_zwxs",  sortable: "custom" },    
            { title: "后屏沾污系数上限", key: "hp_zwxs_high",  sortable: "custom" },    
            { title: "后屏沾污系数下限", key: "hp_zwxs_low",  sortable: "custom" },    
            { title: "末级过热器设计焓增参考值区间", key: "mg_design_hz_zone",  sortable: "custom" },    
            { title: "末级过热器设计沾污系数", key: "mg_design_zwxs",  sortable: "custom" },    
            { title: "末级过热器沾污系数上限", key: "mg_zwxs_high",  sortable: "custom" },    
            { title: "末级过热器沾污系数下限", key: "mg_zwxs_low",  sortable: "custom" },    
            { title: "低温再热器设计焓增参考值区间", key: "dz_design_hz_zone",  sortable: "custom" },    
            { title: "低温再热器设计沾污系数", key: "dz_design_zwxs",  sortable: "custom" },    
            { title: "低温再热器沾污系数上限", key: "dz_zwxs_high",  sortable: "custom" },    
            { title: "低温再热器沾污系数下限", key: "dz_zwxs_low",  sortable: "custom" },    
            { title: "高温再热器设计焓增参考值区间", key: "gz_design_hz_zone",  sortable: "custom" },    
            { title: "高温再热器设计沾污系数", key: "gz_design_zwxs",  sortable: "custom" },    
            { title: "高温再热器沾污系数上限", key: "gz_zwxs_high",  sortable: "custom" },    
            { title: "高温再热器沾污系数下限", key: "gz_zwxs_low",  sortable: "custom" },    
            { title: "低温过热器设计焓值参考值", key: "dg_design_hz_zone",  sortable: "custom" },    
            { title: "低温过热器设计沾污系数", key: "dg_design_zwxs",  sortable: "custom" },    
            { title: "低温过热器沾污系数上限", key: "dg_zwxs_high",  sortable: "custom" },    
            { title: "低温过热器沾污系数下限", key: "dg_zwxs_low",  sortable: "custom" },    
            { title: "AGP风量基础工况占比(%)", key: "agp_basic_percent",  sortable: "custom" },    
            { title: "一级过热器减温水量设计值", key: "grq_jws_design_1",  sortable: "custom" },    
            { title: "二级过热器减温水量设计值", key: "grq_jws_design_2",  sortable: "custom" },    
            { title: "三级过热器减温水量设计值", key: "grq_jws_design_3",  sortable: "custom" },    
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
  
    loadSrm_parameterList() {
      getSrm_parameterList(this.stores.Srm_parameter.query).then(res => {
        this.stores.Srm_parameter.data = getDateMore(res.data.data,1,[]);
        this.stores.Srm_parameter.query.totalCount = res.data.totalCount;
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
      this.handleResetFormSrm_parameter();
      this.doLoadAllForinkey();
      this.doLoadSrm_parameter(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadSrm_parameterList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormSrm_parameter();
      this.doLoadAllForinkey();
      this.formModel.fields={
          zrqll_design:"",
          hz_a1:"",
          hz_a2:"",
          hz_a3:"",
          hz_a4:"",
          hz_a5:"",
          hz_a6:"",
          hz_a7:"",
          hz_a8:"",
          zrq_jws_mh_xs:"",
          gz_out_temp_ed:"",
          gz_out_temp_high:"",
          gz_out_temp_low:"",
          gz_out_temp_mh_xs:"",
          mg_out_temp_ed:"",
          mg_out_temp_high:"",
          mg_out_temp_low:"",
          mg_out_temp_mh_xs:"",
          fh_zone:"",
          o2_high_zone:"",
          o2_low_zone:"",
          nox_high_zone:"",
          nox_low_zone:"",
          zwxs_fh_zone:"",
          fgp_design_hz_zone:"",
          fgp_design_zwxs:"",
          fgp_zwxs_high:"",
          fgp_zwxs_low:"",
          hp_design_hz_zone:"",
          hp_design_zwxs:"",
          hp_zwxs_high:"",
          hp_zwxs_low:"",
          mg_design_hz_zone:"",
          mg_design_zwxs:"",
          mg_zwxs_high:"",
          mg_zwxs_low:"",
          dz_design_hz_zone:"",
          dz_design_zwxs:"",
          dz_zwxs_high:"",
          dz_zwxs_low:"",
          gz_design_hz_zone:"",
          gz_design_zwxs:"",
          gz_zwxs_high:"",
          gz_zwxs_low:"",
          dg_design_hz_zone:"",
          dg_design_zwxs:"",
          dg_zwxs_high:"",
          dg_zwxs_low:"",
          agp_basic_percent:"",
          grq_jws_design_1:"",
          grq_jws_design_2:"",
          grq_jws_design_3:"",
          DncBoiler:0,
          DncBoiler_Name:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitSrm_parameter() {
      let valid = this.validateSrm_parameterForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateSrm_parameter();
          }
          if (o.formModel.mode === "edit") {
            o.doEditSrm_parameter();
          }
        }
      });
    },
    handleResetFormSrm_parameter() {
      this.$refs["formSrm_parameter"].resetFields();
    },
    doCreateSrm_parameter() {
      
      createSrm_parameter(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadSrm_parameterList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditSrm_parameter() {
      editSrm_parameter(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadSrm_parameterList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateSrm_parameterForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formSrm_parameter"].validate(valid => {
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
    doLoadSrm_parameter(id) {
      loadSrm_parameter({ code: id+"" }).then(res => {
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
      deleteSrm_parameter(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadSrm_parameterList();
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
          this.loadSrm_parameterList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchSrm_parameter() {
      this.loadSrm_parameterList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Srm_parameter.query.currentPage = page;
      this.loadSrm_parameterList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Srm_parameter.query.pageSize = pageSize;
      this.loadSrm_parameterList();
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
        if(this.$refs.m1n1.$children && t<=53){
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
        batchCreateSrm_parameter({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadSrm_parameterList();
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
      this.stores.Srm_parameter.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadSrm_parameterList();
    }
  },
  mounted() {
    this.loadSrm_parameterList();
  }
};
</script>






