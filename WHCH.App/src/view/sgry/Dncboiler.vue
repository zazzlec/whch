<style lang="less">
.Boiler{
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
      width: 25%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Boiler">
    <Modal  class="Boiler"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd"></i-col><i-col  class="tdtd">最新同步时间</i-col><i-col  class="tdtd"></i-col><i-col  class="tdtd">额定负荷（MW）</i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="4" />
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
        v-model="stores.Boiler.data"
        :totalCount="stores.Boiler.query.totalCount"
        :pageSize="stores.Boiler.query.pageSize"
        :columns="stores.Boiler.columns"
        @on-delete="handleDelete"
        @on-edit="handleEdit"
        @on-edit8="handleEdit8"
        @on-edit9="handleEdit9"
        @on-edit99="handleEdit99"
        @on-edit100="handleEdit100"
        @on-edit110="handleEdit110"
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
                      v-model="stores.Boiler.query.kw"
                      placeholder="输入/搜索..."
                      @on-search="handleSearchBoiler()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Boiler.query.isDeleted"
                        @on-change="handleSearchBoiler"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Boiler.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Boiler.query.status"
                        @on-change="handleSearchBoiler"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Boiler.sources.statusSources"
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
      <Form :model="formModel.fields" ref="formBoiler" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="机组" prop="K_Name_kw" >
                      <Input v-model="formModel.fields.K_Name_kw" placeholder="请输入机组"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="额定负荷（MW）" prop="Edfh">
                      <Input v-model="formModel.fields.Edfh" placeholder="额定负荷（MW）"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="备注" prop="Remarks" >
                      <Input v-model="formModel.fields.Remarks" placeholder="请输入备注"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    
                    </Col>
                </Row>
        

      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitBoiler">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel.opened = false">取 消</Button>
      </div>
    </Drawer>




    <Drawer
      :title="formModel8.title"
      v-model="formModel8.opened"
      width="1000"
      :mask-closable="false"
      :mask="true"
      :styles="styles"
    >
      <Form :model="formModel8.fields" ref="formSrm_parameter" :rules="formModel8.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="6">
                    <FormItem label="再热蒸汽设计流量" prop="zrqll_design">
                    <Input-number  v-model="formModel8.fields.zrqll_design" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="焓增计算公式参数1" prop="hz_a1">
                    <Input-number  v-model="formModel8.fields.hz_a1" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="焓增计算公式参数2" prop="hz_a2">
                    <Input-number  v-model="formModel8.fields.hz_a2" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="焓增计算公式参数3" prop="hz_a3">
                    <Input-number  v-model="formModel8.fields.hz_a3" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="焓增计算公式参数4" prop="hz_a4">
                    <Input-number  v-model="formModel8.fields.hz_a4" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="焓增计算公式参数5" prop="hz_a5">
                    <Input-number  v-model="formModel8.fields.hz_a5" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="焓增计算公式参数6" prop="hz_a6">
                    <Input-number  v-model="formModel8.fields.hz_a6" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="焓增计算公式参数7" prop="hz_a7">
                    <Input-number  v-model="formModel8.fields.hz_a7" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="焓增计算公式参数8" prop="hz_a8">
                    <Input-number  v-model="formModel8.fields.hz_a8" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="再热器减温水量对煤耗影响系数" prop="zrq_jws_mh_xs">
                    <Input-number  v-model="formModel8.fields.zrq_jws_mh_xs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高温再热器出口温度额定值" prop="gz_out_temp_ed">
                    <Input-number  v-model="formModel8.fields.gz_out_temp_ed" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高温再热器出口温度上限值" prop="gz_out_temp_high">
                    <Input-number  v-model="formModel8.fields.gz_out_temp_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="高温再热器出口温度下限值" prop="gz_out_temp_low">
                    <Input-number  v-model="formModel8.fields.gz_out_temp_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高温再热器出口温度对煤耗影响系数" prop="gz_out_temp_mh_xs">
                    <Input-number  v-model="formModel8.fields.gz_out_temp_mh_xs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末级过热器出口温度额定值" prop="mg_out_temp_ed">
                    <Input-number  v-model="formModel8.fields.mg_out_temp_ed" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末级过热器出口温度上限值" prop="mg_out_temp_high">
                    <Input-number  v-model="formModel8.fields.mg_out_temp_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="末级过热器出口温度下限值" prop="mg_out_temp_low">
                    <Input-number  v-model="formModel8.fields.mg_out_temp_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末级过热器出口温度对煤耗影响系数" prop="mg_out_temp_mh_xs">
                    <Input-number  v-model="formModel8.fields.mg_out_temp_mh_xs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="负荷区间" prop="fh_zone" >
                      <Input v-model="formModel8.fields.fh_zone" placeholder="请输入负荷区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="氧量上限区间" prop="o2_high_zone" >
                      <Input v-model="formModel8.fields.o2_high_zone" placeholder="请输入氧量上限区间"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="氧量下限区间" prop="o2_low_zone" >
                      <Input v-model="formModel8.fields.o2_low_zone" placeholder="请输入氧量下限区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="Nox上限区间" prop="nox_high_zone" >
                      <Input v-model="formModel8.fields.nox_high_zone" placeholder="请输入Nox上限区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="Nox下限区间" prop="nox_low_zone" >
                      <Input v-model="formModel8.fields.nox_low_zone" placeholder="请输入Nox下限区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="沾污系数计算负荷区间" prop="zwxs_fh_zone" >
                      <Input v-model="formModel8.fields.zwxs_fh_zone" placeholder="请输入沾污系数计算负荷区间"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="分隔屏设计焓增参考值区间" prop="fgp_design_hz_zone" >
                      <Input v-model="formModel8.fields.fgp_design_hz_zone" placeholder="请输入分隔屏设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="分隔屏设计沾污系数" prop="fgp_design_zwxs">
                    <Input-number  v-model="formModel8.fields.fgp_design_zwxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="分隔屏沾污系数上限" prop="fgp_zwxs_high">
                    <Input-number  v-model="formModel8.fields.fgp_zwxs_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="分隔屏沾污系数下限" prop="fgp_zwxs_low">
                    <Input-number  v-model="formModel8.fields.fgp_zwxs_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="后屏设计焓增参考值区间" prop="hp_design_hz_zone" >
                      <Input v-model="formModel8.fields.hp_design_hz_zone" placeholder="请输入后屏设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="后屏设计沾污系数" prop="hp_design_zwxs">
                    <Input-number  v-model="formModel8.fields.hp_design_zwxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="后屏沾污系数上限" prop="hp_zwxs_high">
                    <Input-number  v-model="formModel8.fields.hp_zwxs_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="后屏沾污系数下限" prop="hp_zwxs_low">
                    <Input-number  v-model="formModel8.fields.hp_zwxs_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="末级过热器设计焓增参考值区间" prop="mg_design_hz_zone" >
                      <Input v-model="formModel8.fields.mg_design_hz_zone" placeholder="请输入末级过热器设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末级过热器设计沾污系数" prop="mg_design_zwxs">
                    <Input-number  v-model="formModel8.fields.mg_design_zwxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末级过热器沾污系数上限" prop="mg_zwxs_high">
                    <Input-number  v-model="formModel8.fields.mg_zwxs_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末级过热器沾污系数下限" prop="mg_zwxs_low">
                    <Input-number  v-model="formModel8.fields.mg_zwxs_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="低温再热器设计焓增参考值区间" prop="dz_design_hz_zone" >
                      <Input v-model="formModel8.fields.dz_design_hz_zone" placeholder="请输入低温再热器设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低温再热器设计沾污系数" prop="dz_design_zwxs">
                    <Input-number  v-model="formModel8.fields.dz_design_zwxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低温再热器沾污系数上限" prop="dz_zwxs_high">
                    <Input-number  v-model="formModel8.fields.dz_zwxs_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低温再热器沾污系数下限" prop="dz_zwxs_low">
                    <Input-number  v-model="formModel8.fields.dz_zwxs_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="高温再热器设计焓增参考值区间" prop="gz_design_hz_zone" >
                      <Input v-model="formModel8.fields.gz_design_hz_zone" placeholder="请输入高温再热器设计焓增参考值区间"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高温再热器设计沾污系数" prop="gz_design_zwxs">
                    <Input-number  v-model="formModel8.fields.gz_design_zwxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高温再热器沾污系数上限" prop="gz_zwxs_high">
                    <Input-number  v-model="formModel8.fields.gz_zwxs_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高温再热器沾污系数下限" prop="gz_zwxs_low">
                    <Input-number  v-model="formModel8.fields.gz_zwxs_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="低温过热器设计焓值参考值" prop="dg_design_hz_zone" >
                      <Input v-model="formModel8.fields.dg_design_hz_zone" placeholder="请输入低温过热器设计焓值参考值"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低温过热器设计沾污系数" prop="dg_design_zwxs">
                    <Input-number  v-model="formModel8.fields.dg_design_zwxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低温过热器沾污系数上限" prop="dg_zwxs_high">
                    <Input-number  v-model="formModel8.fields.dg_zwxs_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低温过热器沾污系数下限" prop="dg_zwxs_low">
                    <Input-number  v-model="formModel8.fields.dg_zwxs_low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="AGP风量基础工况占比(%)" prop="agp_basic_percent">
                    <Input-number  v-model="formModel8.fields.agp_basic_percent" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="一级过热器减温水量设计值" prop="grq_jws_design_1" >
                      <Input v-model="formModel8.fields.grq_jws_design_1" placeholder="请输入一级过热器减温水量设计值"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="二级过热器减温水量设计值" prop="grq_jws_design_2" >
                      <Input v-model="formModel8.fields.grq_jws_design_2" placeholder="请输入二级过热器减温水量设计值"/>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="三级过热器减温水量设计值" prop="grq_jws_design_3" >
                      <Input v-model="formModel8.fields.grq_jws_design_3" placeholder="请输入三级过热器减温水量设计值"/>
                    </FormItem>
                    </Col>
                </Row>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitSrm_parameter">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel8.opened = false">取 消</Button>
      </div>
    </Drawer>






    <Drawer
      :title="formModel99.title"
      v-model="formModel99.opened"
      width="600"
      :mask-closable="false"
      :mask="true"
      :styles="styles"
    >
      <Form :model="formModel99.fields" ref="formGwfs_parameter" :rules="formModel99.rules" label-position="top">
        <!-- <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="锅炉ID"  prop="DncBoiler_Name">
                          <Select v-model="formModel99.fields.DncBoiler_Name" placeholder="锅炉ID">
                            <Option
                              v-for="item in formSource.DncBoiler "
                              :value="item.text"
                              :disabled="item.disabled"
                              :key="item.text"
                            >{{item.text}}</Option>
                          </Select>
                    </FormItem>
                    </Col>
        </Row> -->
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="材料系数" prop="clxs">
                    <Input-number  v-model="formModel99.fields.clxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="温度系数" prop="wdxs">
                    <Input-number  v-model="formModel99.fields.wdxs" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="周期（小时）" prop="circle">
                    <Input-number  v-model="formModel99.fields.circle" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="巡测时间（小时）" prop="cir_time">
                    <Input-number  v-model="formModel99.fields.cir_time" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="密度（kg/m3）" prop="density">
                    <Input-number  v-model="formModel99.fields.density" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="PBR" prop="pbr">
                    <Input-number  v-model="formModel99.fields.pbr" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="硫化氢预警值" prop="h2s_alert">
                    <Input-number  v-model="formModel99.fields.h2s_alert" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="硫化氢上限值" prop="h2s_high">
                    <Input-number  v-model="formModel99.fields.h2s_high" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>

      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitGwfs_parameter">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel99.opened = false">取 消</Button>
      </div>
    </Drawer>





    <Drawer
      :title="formModel100.title"
      v-model="formModel100.opened"
      width="900"
      :mask-closable="false"
      :mask="true"
      :styles="styles"
    >
      <Form :model="formModel99.fields" ref="formch_parameter" :rules="formModel100.rules" label-position="top">

        <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="低过设计沾污系数" prop="dg_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.dg_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="屏过设计沾污系数" prop="pg_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.pg_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>

                    <Col span="8">
                    <FormItem label="高过设计沾污系数" prop="mg_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.mg_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
            </Row>
            <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="低再设计沾污系数" prop="dz_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.dz_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                    <Col span="8">
                    <FormItem label="高再设计沾污系数" prop="gz_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.gz_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                    <Col span="8">
                    <FormItem label="分级省煤器设计沾污系数" prop="fs_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.fs_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="主省煤器设计沾污系数" prop="zs_zwxs_design_Val">
                    <Input-number  v-model="formModel100.fields.zs_zwxs_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="给水泵中间抽头压力系数" prop="ctylxs_Val">
                    <Input-number  v-model="formModel100.fields.ctylxs_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="经X比修正后排烟温度变化值系数" prop="xs_py_x_modify_Val">
                    <Input-number  v-model="formModel100.fields.xs_py_x_modify_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="设计进口风温" prop="wind_temp_in_design_Val">
                    <Input-number  v-model="formModel100.fields.wind_temp_in_design_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="经进口风温修正后排烟温度变化值系数" prop="py_temp_in_wind_temp_modify_xs_Val">
                    <Input-number  v-model="formModel100.fields.py_temp_in_wind_temp_modify_xs_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="屏过污染率上限" prop="pg_wrl_high_Val">
                    <Input-number  v-model="formModel100.fields.pg_wrl_high_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
               <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="高过污染率上限" prop="mg_wrl_high_Val">
                    <Input-number  v-model="formModel100.fields.mg_wrl_high_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="高再污染率上限" prop="gz_wrl_high_Val">
                    <Input-number  v-model="formModel100.fields.gz_wrl_high_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="低再污染率上限" prop="dz_wrl_high_Val">
                    <Input-number  v-model="formModel100.fields.dz_wrl_high_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="低过污染率上限" prop="dg_wrl_high_Val">
                    <Input-number  v-model="formModel100.fields.dg_wrl_high_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="分级省煤器污染率上限" prop="fs_wrl_high_Val">
                    <Input-number  v-model="formModel100.fields.fs_wrl_high_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="空预器烟气侧效率下限" prop="kyq_yq_ratio_low_Val">
                    <Input-number  v-model="formModel100.fields.kyq_yq_ratio_low_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>

                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="高过污染率下限" prop="mg_wrl_low_Val">
                    <Input-number  v-model="formModel100.fields.mg_wrl_low_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="高再污染率上限" prop="gz_wrl_low_Val">
                    <Input-number  v-model="formModel100.fields.gz_wrl_low_Val"  style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    
                    </Col>
                </Row>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitch_parameter">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel100.opened = false">取 消</Button>
      </div>
    </Drawer>


    <Drawer
      :title="formModel110.title"
      v-model="formModel110.opened"
      width="900"
      :mask-closable="false"
      :mask="true"
      :styles="styles"
    >
      <Form  ref="formkyq"  label-position="top">

        <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="空预器额定电流(A)" prop="Eddl_Val">
                    <Input-number  v-model="formModel110.fields.eddl_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="支承轴承油温偏高值(℃)" prop="Zczc_Oiltemp_Warn_Val">
                    <Input-number  v-model="formModel110.fields.zczc_Oiltemp_Warn_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>

                    <Col span="8">
                    <FormItem label="支承轴承油温偏报警值(℃)" prop="Zczc_Oiltemp_High_Val">
                    <Input-number  v-model="formModel110.fields.zczc_Oiltemp_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
            </Row>
            <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="导向轴承油温偏高值(℃)" prop="Dxzc_Oiltemp_Warn_Val">
                    <Input-number  v-model="formModel110.fields.dxzc_Oiltemp_Warn_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                    <Col span="8">
                    <FormItem label="导向轴承油温报警值(℃)" prop="Dxzc_Oiltemp_High_Val">
                    <Input-number  v-model="formModel110.fields.dxzc_Oiltemp_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                    <Col span="8">
                    <FormItem label="支承/导向轴承润滑油压差(MPa)" prop="Oil_Press_Dif_Val">
                    <Input-number  v-model="formModel110.fields.oil_Press_Dif_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="空气预热器转速下限报警值(rpm)" prop="Kyq_Speed_Low_Val">
                    <Input-number  v-model="formModel110.fields.kyq_Speed_Low_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="漏风率设计值" prop="Ifl_Design_Val">
                    <Input-number  v-model="formModel110.fields.ifl_Design_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    
                    <FormItem label="漏风率偏大值" prop="Lfl_High_Val">
                    <Input-number  v-model="formModel110.fields.lfl_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="热端吹灰器蒸汽压力上限(MPa)" prop="Hot_Chq_Press_High_Val">
                    <Input-number  v-model="formModel110.fields.hot_Chq_Press_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="热端吹灰器蒸汽压力下限(MPa)" prop="Hot_Chq_Press_Low_Val">
                    <Input-number  v-model="formModel110.fields.hot_Chq_Press_Low_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="冷端吹灰器蒸汽压力上限(MPa)" prop="Cold_Chq_Press_High_Val">
                    <Input-number  v-model="formModel110.fields.cold_Chq_Press_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
               <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="冷端吹灰器蒸汽压力下限(MPa)" prop="Cold_Chq_Press_Low_Val">
                    <Input-number  v-model="formModel110.fields.cold_Chq_Press_Low_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="吹灰器蒸汽温度下限(℃)" prop="Chq_Temp_Low_Val">
                    <Input-number  v-model="formModel110.fields.chq_Temp_Low_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="高压水水泵压力上限(MPa)" prop="Gysb_Press_High_Val">
                    <Input-number  v-model="formModel110.fields.gysb_Press_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="高压水水泵压力下限(MPa)" prop="Gysb_Press_Low_Val">
                    <Input-number  v-model="formModel110.fields.gysb_Press_Low_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    
                    <FormItem label="密封间隙检测" prop="Mfjx_Test">
                      <Select v-model="formModel110.fields.mfjx_Test">
                        <Option v-for="item in formModel110.designList" :value="item.value" :key="item.value">{{ item.label }}</Option>
                      </Select>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="烟空气阻力初始值(KPa)" prop="Gasair_Res_Ini_Val">
                    <Input-number  v-model="formModel110.fields.gasair_Res_Ini_Val" style="width:100%"></Input-number>
                    </FormItem>

                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="烟空气阻力偏大值(KPa)" prop="Gasair_Res_High_Val">
                    <Input-number  v-model="formModel110.fields.gasair_Res_High_Val" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="温差" prop="TemperatureDifference">
                    <Input-number  v-model="formModel110.fields.temperatureDifference" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="沉积区域A" prop="CJQY_A">
                      <Input-number  v-model="formModel110.fields.cjqY_A" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="沉积区域B" prop="CJQY_B">
                      <Input-number  v-model="formModel110.fields.cjqY_B" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="沉积区域K" prop="CJQY_K">
                      <Input-number  v-model="formModel110.fields.cjqY_K" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="沉积区域峰值" prop="CJQY_Up">
                      <Input-number  v-model="formModel110.fields.cjqY_Up" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="8">
                    <FormItem label="沉积区域谷值" prop="CJQY_Down">
                      <Input-number  v-model="formModel110.fields.cjqY_Down" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
               
                    <Col span="8">
                    <FormItem label="空气,烟气侧效率下限" prop="Xl_Low">
                      <Input-number  v-model="formModel110.fields.xl_Low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="8">
                    <FormItem label="维修寿命下限" prop="Life_Low">
                      <Input-number  v-model="formModel110.fields.life_Low" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitKyqconfig">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel110.opened = false">取 消</Button>
      </div>
    </Drawer>


    <Drawer
      :title="formModel9.title"
      v-model="formModel9.opened"
      width="1000"
      :mask-closable="false"
      :mask="true"
      :styles="styles"
    >
      <Form :model="formModel9.fields" ref="formErr_parameter" :rules="formModel9.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="6">
                    <FormItem label="分隔屏焓增B比A高" prop="fgp_hz_b_big_a">
                    <Input-number  v-model="formModel9.fields.fgp_hz_b_big_a" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="后屏焓增B比A高" prop="hp_hz_b_big_a">
                    <Input-number  v-model="formModel9.fields.hp_hz_b_big_a" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高过焓增A比B高" prop="mg_hz_a_big_b">
                    <Input-number  v-model="formModel9.fields.mg_hz_a_big_b" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低再焓增A比B高" prop="dz_hz_a_big_b">
                    <Input-number  v-model="formModel9.fields.dz_hz_a_big_b" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="末再焓增A比B高" prop="mz_hz_a_big_b">
                    <Input-number  v-model="formModel9.fields.mz_hz_a_big_b" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="烟气浓度左比右高（左切圆）" prop="left_qy_yqnd_l_big_r">
                    <Input-number  v-model="formModel9.fields.left_qy_yqnd_l_big_r" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="悬吊管最高点左比右高(左切圆)" prop="left_qy_xdgtop_l_big_r">
                    <Input-number  v-model="formModel9.fields.left_qy_xdgtop_l_big_r" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="消旋、起旋动量不足异常值条件数量" prop="xx_qxbz_error_num">
                    <Input-number  v-model="formModel9.fields.xx_qxbz_error_num" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="分隔屏焓增C比D高" prop="fgp_hz_c_big_d">
                    <Input-number  v-model="formModel9.fields.fgp_hz_c_big_d" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="后屏焓增C比D高" prop="hp_hz_c_big_d">
                    <Input-number  v-model="formModel9.fields.hp_hz_c_big_d" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高过焓增A比B高" prop="mg_hz_d_big_c">
                    <Input-number  v-model="formModel9.fields.mg_hz_d_big_c" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低再焓增D比C高" prop="dz_hz_d_big_c">
                    <Input-number  v-model="formModel9.fields.dz_hz_d_big_c" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="末再焓增D比C高" prop="mz_hz_d_big_c">
                    <Input-number  v-model="formModel9.fields.mz_hz_d_big_c" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="烟气浓度右比左高（右切圆）" prop="right_qy_yqnd_r_big_l">
                    <Input-number  v-model="formModel9.fields.right_qy_yqnd_r_big_l" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="悬吊管最高点右比左高(右切圆)" prop="right_qy_xdgtop_r_big_l">
                    <Input-number  v-model="formModel9.fields.right_qy_xdgtop_r_big_l" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="分隔屏焓增B比A低" prop="fgp_hz_b_small_a">
                    <Input-number  v-model="formModel9.fields.fgp_hz_b_small_a" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="后屏焓增B比A低" prop="hp_hz_b_small_a">
                    <Input-number  v-model="formModel9.fields.hp_hz_b_small_a" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="高过焓增A比B低" prop="mg_hz_a_small_b">
                    <Input-number  v-model="formModel9.fields.mg_hz_a_small_b" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低再焓增A比B低" prop="dz_hz_a_small_b">
                    <Input-number  v-model="formModel9.fields.dz_hz_a_small_b" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末再焓增A比B低" prop="mz_hz_a_small_b">
                    <Input-number  v-model="formModel9.fields.mz_hz_a_small_b" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="烟气浓度左比右低（左切圆）" prop="left_qy_yqnd_l_small_r">
                    <Input-number  v-model="formModel9.fields.left_qy_yqnd_l_small_r" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="悬吊管最高点左比右低(左切圆)" prop="left_qy_xdgtop_l_small_r">
                    <Input-number  v-model="formModel9.fields.left_qy_xdgtop_l_small_r" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="分隔屏焓增C比D低" prop="fgp_hz_c_small_d">
                    <Input-number  v-model="formModel9.fields.fgp_hz_c_small_d" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="后屏焓增C比D低" prop="hp_hz_c_small_d">
                    <Input-number  v-model="formModel9.fields.hp_hz_c_small_d" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="高过焓增D比C低" prop="mg_hz_d_small_c">
                    <Input-number  v-model="formModel9.fields.mg_hz_d_small_c" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="低再焓增D比C低" prop="dz_hz_d_small_c">
                    <Input-number  v-model="formModel9.fields.dz_hz_d_small_c" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="末再焓增D比C低" prop="mz_hz_dsmall_c">
                    <Input-number  v-model="formModel9.fields.mz_hz_dsmall_c" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="烟气浓度右比左低（右切圆）" prop="right_qy_yqnd_r_small_l">
                    <Input-number  v-model="formModel9.fields.right_qy_yqnd_r_small_l" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="悬吊管最高点右比左低(右切圆)" prop="right_qy_xdgtop_r_small_l">
                    <Input-number  v-model="formModel9.fields.right_qy_xdgtop_r_small_l" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="垂直段水冷壁左墙右墙温度差" prop="czd_temp_left_right">
                    <Input-number  v-model="formModel9.fields.czd_temp_left_right" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="左、右切圆后墙悬吊管水冷壁左侧、右侧最高三点平均值的差值" prop="qy_back_xdg_top3_avg_l_r">
                    <Input-number  v-model="formModel9.fields.qy_back_xdg_top3_avg_l_r" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="螺旋段水冷壁壁温左侧、右侧最高10个点平均值的差值" prop="lxd_temp_top10_l_r">
                    <Input-number  v-model="formModel9.fields.lxd_temp_top10_l_r" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="6">
                    <FormItem label="左、右切圆向左、向右偏斜异常值条件数量" prop="qy_px_l_r_num">
                    <Input-number  v-model="formModel9.fields.qy_px_l_r_num" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="左、右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高" prop="qy_gp_h_big_q">
                    <Input-number  v-model="formModel9.fields.qy_gp_h_big_q" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="左、右切圆前墙管屏水冷壁温度比后墙垂直水冷壁高" prop="qy_gp_q_big_h">
                    <Input-number  v-model="formModel9.fields.qy_gp_q_big_h" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
                    <FormItem label="左、右切圆前墙、后墙螺旋段水冷壁温度差值" prop="qy_lxd_q_h">
                    <Input-number  v-model="formModel9.fields.qy_lxd_q_h" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                </Row>
                <Row :gutter="16">
                    <Col span="6">
                    <FormItem label="左、右切圆向前、向后偏斜异常值条件数量" prop="qy_px_q_h_num">
                    <Input-number  v-model="formModel9.fields.qy_px_q_h_num" style="width:100%"></Input-number>
                    </FormItem>
                    </Col>
                
                    <Col span="6">
             
                    </Col>
        </Row>
      </Form>
      <div class="demo-drawer-footer">
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitError_parameter">保 存</Button>
        <Button style="margin-left: 8px" icon="md-close" @click="formModel9.opened = false">取 消</Button>
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
import {
  getBoilerList,
  createBoiler,
  loadBoiler,
  editBoiler,
  deleteBoiler,
  batchCommand,
  batchCreateBoiler,
  getBoilerListAll
} from "@/api/ZNRS/Dncboiler";
import {
  getSrm_parameterList,
  editSrm_parameter
} from "@/api/ZNRS/Dncsrm_parameter";
import {
  getError_parameterList,
  editError_parameter
} from "@/api/ZNRS/Dncerror_parameter";
import {
  getCh_parameterList,
  editCh_parameter
} from "@/api/ZNRS/Dncch_parameter";
import {
  getGwfs_parameterList,
  editGwfs_parameter
} from "@/api/ZNRS/Dncgwfs_parameter";

import {
  getKyqconfigList,
  createKyqconfig,
  loadKyqconfig,
  editKyqconfig,
  deleteKyqconfig,
  batchCreateKyqconfig
} from "@/api/ZNRS/Dnckyqconfig";

export default {
  name: "ZNRS_Boiler_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      dataorder:["K_Name_kw","Syntime","Remarks","Edfh"],
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
              message: "请输入",
              min: 1
            }
          ],
        }
      },
      formModel8: {
        opened: false,
        title: "受热面参数编辑",
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
      formModel9: {
        opened: false,
        title: "",
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

      formModel99: {
        opened: false,
        title: "",
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

      formModel100: {
        opened: false,
        title: "",
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

      formModel110: {
        opened: false,
        title: "",
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
        },
        designList: [
                    {
                        value: 1,
                        label: '配置有LCS'
                    },
                    {
                        value: 2,
                        label: '无LCS系统'
                    },
                    {
                        value: 3,
                        label: '径向密封设置软密封'
                    }
                ]
      },

      stores: {
        Boiler: {
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
            { title: "机组名", key: "k_Name_kw",  sortable: "custom" },    
            { title: "最新同步时间", key: "syntime",  sortable: "custom" ,
              render: (h, params) => {
                let syntime = params.row.syntime;
                if(syntime=="0001-01-01"){
                  syntime= "";
                }else{
                  syntime = params.row.syntime;
                }
                return h('span', [
                                h('strong', syntime)
                            ]);
              }
            }, 
            { title: "备注", key: "remarks",  sortable: "custom" },    
            { title: "额定负荷（MW）", key: "edfh",  sortable: "custom" },    
           
            {
              title: "操作",
              align: "center",
              key: "handle",
              width: 600,
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
                            delay: 15000
                          }
                        },
                        [
                          h("Button", {
                            props: {
                              shape: "circle",
                              type: "error"
                            }
                          }
                          ,"删除"
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
                        delay: 16000
                      }
                    },
                    [
                      h("Button", {
                        props: {
                          shape: "circle",
                          type: "primary"
                        },
                        on: {
                          click: () => {
                            vm.$emit("on-edit", params);
                            vm.$emit("input", params.tableData);
                          }
                        }
                      }
                      ,"编辑"
                        
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
                        delay: 16000
                      }
                    },
                    [
                      h("Button", {
                          props: {
                            shape: "circle",
                            type: "primary"
                          },
                          on: {
                            click: () => {
                              vm.$emit("on-edit8", params);
                            }
                          }
                        }
                        ,"受热面参数"
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
                        delay: 16000
                      }
                    },
                    [
                      h("Button", {
                          props: {
                            shape: "circle",
                            type: "primary"
                          },
                          on: {
                            click: () => {
                              vm.$emit("on-edit9", params);
                            }
                          }
                        }
                        ,"异常参数"
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
                        delay: 16000
                      }
                    },
                    [
                      h("Button", {
                          props: {
                            shape: "circle",
                            type: "primary"
                          },
                          on: {
                            click: () => {
                              vm.$emit("on-edit99", params);
                            }
                          }
                        }
                        ,"腐蚀参数"
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
                        delay: 16000
                      }
                    },
                    [
                      h("Button", {
                          props: {
                            shape: "circle",
                            type: "primary"
                          },
                          on: {
                            click: () => {
                              vm.$emit("on-edit100", params);
                            }
                          }
                        }
                        ,"吹灰参数"
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
                        delay: 16000
                      }
                    },
                    [
                      h("Button", {
                          props: {
                            shape: "circle",
                            type: "primary"
                          },
                          on: {
                            click: () => {
                              vm.$emit("on-edit110", params);
                            }
                          }
                        }
                        ,"空预器参数"
                        )
                    ]
                  );
                },

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
    handleSyntimeDateChange(date) {
      this.formModel.fields.Syntime=date
    },
  
    loadBoilerList() {
      getBoilerList(this.stores.Boiler.query).then(res => {
        this.stores.Boiler.data = getDateMore(res.data.data,-1,["syntime",]);
        this.stores.Boiler.query.totalCount = res.data.totalCount;
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
      this.handleResetFormBoiler();
      this.doLoadAllForinkey();
      this.doLoadBoiler(params.row.id);
    },
    handleEdit8(params) {
      this.formModel8.opened=true;
      this.formModel8.title=params.row.k_Name_kw  +"__受热面参数编辑";
      getSrm_parameterList({
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid:params.row.id,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
        if(res.data.data.length==0){
          this.$Message.warning('该机组不存在或已停用！');
          this.formModel8.opened=false;
        }else{
          this.formModel8.fields=getDateMore(res.data.data,1,[])[0];
        }
      });

    },
    handleSubmitSrm_parameter(){
      editSrm_parameter(this.formModel8.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
        } else {
          this.$Message.warning(res.data.message);
        }
        this.formModel8.opened=false;
      });
    },



    handleEdit9(params) {
      this.formModel9.opened=true;
      this.formModel9.title=params.row.k_Name_kw  +"__异常参数编辑";
      getError_parameterList({
            totalCount: 0,
            pageSize: 20,
            currentPage: 1,
            kw: "",
            isDeleted: 0,
            status: 1,
            boilerid:params.row.id,
            sort: [
              {
                direct: "DESC",
                field: "id"
              }
            ]
          }).then(res => {
        if(res.data.data.length==0){
          this.$Message.warning('该机组不存在或已停用！');
          this.formModel9.opened=false;
        }else{
          this.formModel9.fields=getDateMore(res.data.data,1,[])[0];
        }
      });
    },

    doEditGwfs_parameter() {
      editGwfs_parameter(this.formModel99.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
        } else {
          this.$Message.warning(res.data.message);
        }
        this.formModel99.opened=false;
      });
    },
    validateGwfs_parameterForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formGwfs_parameter"].validate(valid => {
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
    handleSubmitGwfs_parameter() {
      let valid = this.validateGwfs_parameterForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
            o.doEditGwfs_parameter();
        }
      });
    },
    handleEdit99(params) {
      this.formModel99.opened=true;
      this.formModel99.title=params.row.k_Name_kw  +"__高温腐蚀参数编辑";
      let o=this;
      getGwfs_parameterList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: 0,
              status: 1,
              boilerid:params.row.id,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
          if(res.data.data.length==0){
            o.$Message.warning('该机组不存在或已停用！');
            o.formModel99.opened=false;
          }else{
            o.formModel99.fields=getDateMore(res.data.data,1,[])[0];
          }
      });
    },
    handleEdit100(params){
      this.formModel100.opened=true;
      this.formModel100.title=params.row.k_Name_kw  +"__吹灰参数编辑";
      let o=this;
      getCh_parameterList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: 0,
              status: 1,
              boilerid:params.row.id,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
          if(res.data.data.length==0){
            o.$Message.warning('该机组不存在或已停用！');
            o.formModel100.opened=false;
          }else{
            o.formModel100.fields=getDateMore(res.data.data,1,[])[0];
          }
      });
    },

    handleEdit110(params){
      this.formModel110.opened=true;
      this.formModel110.title=params.row.k_Name_kw  +"__空预器参数编辑";
      let o=this;


      getKyqconfigList({
              totalCount: 0,
              pageSize: 20,
              currentPage: 1,
              kw: "",
              isDeleted: 0,
              status: 1,
              boilerid:params.row.id,
              sort: [
                {
                  direct: "DESC",
                  field: "id"
                }
              ]
            }).then(res => {
          if(res.data.data.length==0){
            o.$Message.warning('该机组不存在或已停用！');
            o.formModel110.opened=false;
          }else{
            o.formModel110.fields=getDateMore(res.data.data,1,[])[0];
          }
      });
    },

    handleSubmitKyqconfig(){
      editKyqconfig(this.formModel110.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
        } else {
          this.$Message.warning(res.data.message);
        }
        this.formModel110.opened=false;
      });
    },

    handleSubmitError_parameter(){
      editError_parameter(this.formModel9.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
        } else {
          this.$Message.warning(res.data.message);
        }
        this.formModel9.opened=false;
      });
    },


    handleSubmitch_parameter(){
      editCh_parameter(this.formModel100.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
        } else {
          this.$Message.warning(res.data.message);
        }
        this.formModel100.opened=false;
      });
    },







    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadBoilerList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormBoiler();
      this.doLoadAllForinkey();
      this.formModel.fields={
          K_Name_kw:"",
          Syntime:"",
          Remarks:"",
          Edfh:0,
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitBoiler() {
      let valid = this.validateBoilerForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateBoiler();
          }
          if (o.formModel.mode === "edit") {
            o.doEditBoiler();
          }
        }
      });
    },
    handleResetFormBoiler() {
      this.$refs["formBoiler"].resetFields();
    },
    doCreateBoiler() {
      
      createBoiler(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadBoilerList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditBoiler() {
      editBoiler(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadBoilerList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateBoilerForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formBoiler"].validate(valid => {
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
    doLoadBoiler(id) {
      loadBoiler({ code: id+"" }).then(res => {
        var op=upperKey(res.data.data);
        this.formModel.fields = op;
      });
    },
    doLoadAllForinkey() {
      let o=this;
      ////{PageSize:10,CurrentPage:1,Status:1,IsDeleted:0,Sort:[{Field:"id",Direct:"Desc"}],Kw:""}
    },
    handleDelete(params) {
      this.doDelete(params.row.id);
    },
    doDelete(ids) {
      if (!ids) {
        this.$Message.warning("请选择至少一条数据");
        return;
      }
      deleteBoiler(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadBoilerList();
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
          this.loadBoilerList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchBoiler() {
      this.loadBoilerList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Boiler.query.currentPage = page;
      this.loadBoilerList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Boiler.query.pageSize = pageSize;
      this.loadBoilerList();
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
        if(this.$refs.m1n1.$children && t<=4){
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
        batchCreateBoiler({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadBoilerList();
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
      this.stores.Boiler.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadBoilerList();
    }
  },
  mounted() {
    this.loadBoilerList();
  }
};
</script>






