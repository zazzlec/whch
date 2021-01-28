<style lang="less">
.Hztemp_mid{
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
      width: 0.561797752808989%;
      float: left;
    }
    .tdtdselect{
      background: rgba(0,153,229,1) !important;
    }
  }  
</style>
<template>
  <div class="Hztemp_mid">
    <Modal  class="Hztemp_mid"
        v-model="modal1"
        width=800
        title="批量录入">
        <Row  ref="m1n1">
            <i-col  class="tdtd">实际时间</i-col><i-col  class="tdtd">分离器压力平均值</i-col><i-col  class="tdtd">分离器温度平均值</i-col><i-col  class="tdtd">末级过热器出口压力A</i-col><i-col  class="tdtd">末级过热器出口压力B</i-col><i-col  class="tdtd">末级过热器出口压力B</i-col><i-col  class="tdtd">末级过热器出口压力D</i-col><i-col  class="tdtd">末级过热器出口压力左侧平均值</i-col><i-col  class="tdtd">末级过热器出口压力右侧平均值</i-col><i-col  class="tdtd">低温过热器出口压力A</i-col><i-col  class="tdtd">低温过热器出口压力B</i-col><i-col  class="tdtd">低温过热器出口压力C</i-col><i-col  class="tdtd">低温过热器出口压力D</i-col><i-col  class="tdtd">低温过热器出口温度A</i-col><i-col  class="tdtd">低温过热器出口温度B</i-col><i-col  class="tdtd">低温过热器出口温度C</i-col><i-col  class="tdtd">低温过热器出口温度D</i-col><i-col  class="tdtd">低温过热器出口焓值A</i-col><i-col  class="tdtd">低温过热器出口焓值B</i-col><i-col  class="tdtd">低温过热器出口焓值C</i-col><i-col  class="tdtd">低温过热器出口焓值D</i-col><i-col  class="tdtd">低温过热器进口压力A</i-col><i-col  class="tdtd">低温过热器进口压力B</i-col><i-col  class="tdtd">低温过热器进口压力C</i-col><i-col  class="tdtd">低温过热器进口压力D</i-col><i-col  class="tdtd">低温过热器进口温度A</i-col><i-col  class="tdtd">低温过热器进口温度B</i-col><i-col  class="tdtd">低温过热器进口温度C</i-col><i-col  class="tdtd">低温过热器进口温度D</i-col><i-col  class="tdtd">低温过热器进口焓值A</i-col><i-col  class="tdtd">低温过热器进口焓值B</i-col><i-col  class="tdtd">低温过热器进口焓值C</i-col><i-col  class="tdtd">低温过热器进口焓值D</i-col><i-col  class="tdtd">分隔屏出口压力A</i-col><i-col  class="tdtd">分隔屏出口压力B</i-col><i-col  class="tdtd">分隔屏出口压力C</i-col><i-col  class="tdtd">分隔屏出口压力D</i-col><i-col  class="tdtd">分隔屏出口温度A</i-col><i-col  class="tdtd">分隔屏出口温度B</i-col><i-col  class="tdtd">分隔屏出口温度C</i-col><i-col  class="tdtd">分隔屏出口温度D</i-col><i-col  class="tdtd">分隔屏出口焓值A</i-col><i-col  class="tdtd">分隔屏出口焓值B</i-col><i-col  class="tdtd">分隔屏出口焓值C</i-col><i-col  class="tdtd">分隔屏出口焓值D</i-col><i-col  class="tdtd">分隔屏进口压力A</i-col><i-col  class="tdtd">分隔屏进口压力B</i-col><i-col  class="tdtd">分隔屏进口压力C</i-col><i-col  class="tdtd">分隔屏进口压力D</i-col><i-col  class="tdtd">分隔屏进口温度A</i-col><i-col  class="tdtd">分隔屏进口温度B</i-col><i-col  class="tdtd">分隔屏进口温度C</i-col><i-col  class="tdtd">分隔屏进口温度D</i-col><i-col  class="tdtd">分隔屏进口焓值A</i-col><i-col  class="tdtd">分隔屏进口焓值B</i-col><i-col  class="tdtd">分隔屏进口焓值C</i-col><i-col  class="tdtd">分隔屏进口焓值D</i-col><i-col  class="tdtd">后屏出口压力A</i-col><i-col  class="tdtd">后屏出口压力B</i-col><i-col  class="tdtd">后屏出口压力C</i-col><i-col  class="tdtd">后屏出口压力D</i-col><i-col  class="tdtd">后屏出口温度A</i-col><i-col  class="tdtd">后屏出口温度B</i-col><i-col  class="tdtd">后屏出口温度C</i-col><i-col  class="tdtd">后屏出口温度D</i-col><i-col  class="tdtd">后屏出口焓值A</i-col><i-col  class="tdtd">后屏出口焓值B</i-col><i-col  class="tdtd">后屏出口焓值C</i-col><i-col  class="tdtd">后屏出口焓值D</i-col><i-col  class="tdtd">后屏进口压力A</i-col><i-col  class="tdtd">后屏进口压力B</i-col><i-col  class="tdtd">后屏进口压力C</i-col><i-col  class="tdtd">后屏进口压力D</i-col><i-col  class="tdtd">后屏进口温度A</i-col><i-col  class="tdtd">后屏进口温度B</i-col><i-col  class="tdtd">后屏进口温度C</i-col><i-col  class="tdtd">后屏进口温度D</i-col><i-col  class="tdtd">后屏进口焓值A</i-col><i-col  class="tdtd">后屏进口焓值B</i-col><i-col  class="tdtd">后屏进口焓值C</i-col><i-col  class="tdtd">后屏进口焓值D</i-col><i-col  class="tdtd">末级过热器出口温度A</i-col><i-col  class="tdtd">末级过热器出口温度B</i-col><i-col  class="tdtd">末级过热器出口温度C</i-col><i-col  class="tdtd">末级过热器出口温度D</i-col><i-col  class="tdtd">末级过热器出口焓值A</i-col><i-col  class="tdtd">末级过热器出口焓值B</i-col><i-col  class="tdtd">末级过热器出口焓值C</i-col><i-col  class="tdtd">末级过热器出口焓值D</i-col><i-col  class="tdtd">末级过热器进口压力A</i-col><i-col  class="tdtd">末级过热器进口压力B</i-col><i-col  class="tdtd">末级过热器进口压力C</i-col><i-col  class="tdtd">末级过热器进口压力D</i-col><i-col  class="tdtd">末级过热器进口温度A</i-col><i-col  class="tdtd">末级过热器进口温度B</i-col><i-col  class="tdtd">末级过热器进口温度C</i-col><i-col  class="tdtd">末级过热器进口温度D</i-col><i-col  class="tdtd">末级过热器进口焓值A</i-col><i-col  class="tdtd">末级过热器进口焓值B</i-col><i-col  class="tdtd">末级过热器进口焓值C</i-col><i-col  class="tdtd">末级过热器进口焓值D</i-col><i-col  class="tdtd">低温再热器进口压力左侧</i-col><i-col  class="tdtd">低温再热器进口压力右侧</i-col><i-col  class="tdtd">高温再热器出口压力左侧</i-col><i-col  class="tdtd">高温再热器出口压力右侧</i-col><i-col  class="tdtd">低温再热器出口压力左侧</i-col><i-col  class="tdtd">低温再热器出口压力右侧</i-col><i-col  class="tdtd">低温再热器出口温度左侧</i-col><i-col  class="tdtd">低温再热器出口温度右侧</i-col><i-col  class="tdtd">低温再热器出口焓值左侧</i-col><i-col  class="tdtd">低温再热器出口焓值右侧</i-col><i-col  class="tdtd">低温再热器进口温度左侧</i-col><i-col  class="tdtd">低温再热器进口温度右侧</i-col><i-col  class="tdtd">低温再热器进口焓值左侧</i-col><i-col  class="tdtd">低温再热器进口焓值右侧</i-col><i-col  class="tdtd">高温再热器出口温度左侧</i-col><i-col  class="tdtd">高温再热器出口温度右侧</i-col><i-col  class="tdtd">高温再热器出口焓值左侧</i-col><i-col  class="tdtd">高温再热器出口焓值右侧</i-col><i-col  class="tdtd">高温再热器进口压力左侧</i-col><i-col  class="tdtd">高温再热器进口压力右侧</i-col><i-col  class="tdtd">高温再热器进口温度左侧</i-col><i-col  class="tdtd">高温再热器进口温度右侧</i-col><i-col  class="tdtd">高温再热器进口焓值左侧</i-col><i-col  class="tdtd">高温再热器进口焓值右侧</i-col><i-col  class="tdtd">左切圆左侧氧量平均值</i-col><i-col  class="tdtd">左切圆右侧氧量平均值</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁左侧最高点</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁右侧最高点</i-col><i-col  class="tdtd">右切圆左侧氧量平均值</i-col><i-col  class="tdtd">右切圆右侧氧量平均值</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁左侧最高点</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁右侧最高点</i-col><i-col  class="tdtd">左墙垂直段水冷壁温度</i-col><i-col  class="tdtd">右墙垂直段水冷壁温度</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁左侧最高三个点平均值</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁右侧最高三个点平均值</i-col><i-col  class="tdtd">左墙螺旋段水冷壁最高10个点的平均值</i-col><i-col  class="tdtd">右墙螺旋段水冷壁最高10个点的平均值</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁左侧最高三个点平均值</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁右侧最高三个点平均值</i-col><i-col  class="tdtd">左切圆后墙管屏水冷壁温度</i-col><i-col  class="tdtd">右切圆后墙管屏水冷壁温度</i-col><i-col  class="tdtd">左切圆前墙垂直水冷壁温度</i-col><i-col  class="tdtd">右切圆前墙垂直水冷壁温度</i-col><i-col  class="tdtd">左切圆后墙螺旋段水冷壁温度最高10个点的平均值</i-col><i-col  class="tdtd">右切圆后墙螺旋段水冷壁温度最高10个点的平均值</i-col><i-col  class="tdtd">左切圆前墙螺旋段水冷壁温度最高10个点的平均值</i-col><i-col  class="tdtd">右切圆前墙螺旋段水冷壁温度最高10个点的平均值</i-col><i-col  class="tdtd">低温再热器减温水压力</i-col><i-col  class="tdtd">低温再热器减温水温度</i-col><i-col  class="tdtd">低温再热器减温水焓值</i-col><i-col  class="tdtd">低温再热器减温器前温度（左侧）</i-col><i-col  class="tdtd">低温再热器减温器后温度（左侧）</i-col><i-col  class="tdtd">低温再热器减温器前温度（右侧）</i-col><i-col  class="tdtd">低温再热器减温器后温度（右侧）</i-col><i-col  class="tdtd">低温再热器减温器前再热蒸汽焓值（左侧）</i-col><i-col  class="tdtd">低温再热器减温器后再热蒸汽焓值（左侧）</i-col><i-col  class="tdtd">低温再热器减温器前再热蒸汽焓值（右侧）</i-col><i-col  class="tdtd">低温再热器减温器后再热蒸汽焓值（右侧）</i-col><i-col  class="tdtd">再热器减温水量（左侧）</i-col><i-col  class="tdtd">再热器减温水量（右侧）</i-col><i-col  class="tdtd">分隔屏设计焓增</i-col><i-col  class="tdtd">后屏设计焓增</i-col><i-col  class="tdtd">末级过热器设计焓增</i-col><i-col  class="tdtd">低温再热器设计焓增</i-col><i-col  class="tdtd">高温再热器设计焓增</i-col><i-col  class="tdtd">过热器减温水焓值</i-col><i-col  class="tdtd"></i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁左侧最高点</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁右侧最高点</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁左侧最高点</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁右侧最高点</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁左侧最高三个点</i-col><i-col  class="tdtd">左切圆后墙悬吊管水冷壁右侧最高三个点</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁左侧最高三个点</i-col><i-col  class="tdtd">右切圆后墙悬吊管水冷壁右侧最高三个点</i-col><i-col  class="tdtd">低温过热器设计焓增</i-col>
        </Row>
        <Row :gutter="10">
          <i-col span="24">
            <Card>
              <div class="update-paste-con">
                <paste-editor v-model="pasteDataArr" @on-success="handleSuccess" @on-error="handleError" @input="handleInput"  :colnumref="178" />
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
        v-model="stores.Hztemp_mid.data"
        :totalCount="stores.Hztemp_mid.query.totalCount"
        :pageSize="stores.Hztemp_mid.query.pageSize"
        :columns="stores.Hztemp_mid.columns"
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
                      v-model="stores.Hztemp_mid.query.kw"
                      placeholder="输入搜索..."
                      @on-search="handleSearchHztemp_mid()"
                    >
                      <Select
                        slot="prepend"
                        v-model="stores.Hztemp_mid.query.isDeleted"
                        @on-change="handleSearchHztemp_mid"
                        placeholder="删除状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Hztemp_mid.sources.isDeletedSources"
                          :value="item.value"
                          :key="item.value"
                        >{{item.text}}</Option>
                      </Select>
                      <Select
                        slot="prepend"
                        v-model="stores.Hztemp_mid.query.status"
                        @on-change="handleSearchHztemp_mid"
                        placeholder="状态"
                        style="width:60px;"
                      >
                        <Option
                          v-for="item in stores.Hztemp_mid.sources.statusSources"
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
      <Form :model="formModel.fields" ref="formHztemp_mid" :rules="formModel.rules" label-position="top">
        <Row :gutter="16">
                    <Col span="12">
                    <FormItem label="实际时间" prop="RealTime">
                    <i-col span="12">
                        <Date-picker @on-change="handleRealTimeDateChange" type="date" placeholder="选择实际时间" style="width: 276px" v-model="formModel.fields.RealTime" format="yyyy年MM月dd日"></Date-picker>
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
                </Row></Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="左切圆后墙悬吊管水冷壁左侧最高点" prop="left_qy_back_xdg_left_top_point" >
                      <Input v-model="formModel.fields.left_qy_back_xdg_left_top_point" placeholder="请输入左切圆后墙悬吊管水冷壁左侧最高点"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="左切圆后墙悬吊管水冷壁右侧最高点" prop="left_qy_back_xdg_right_top_point" >
                      <Input v-model="formModel.fields.left_qy_back_xdg_right_top_point" placeholder="请输入左切圆后墙悬吊管水冷壁右侧最高点"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="右切圆后墙悬吊管水冷壁左侧最高点" prop="right_qy_back_xdg_left_top_point" >
                      <Input v-model="formModel.fields.right_qy_back_xdg_left_top_point" placeholder="请输入右切圆后墙悬吊管水冷壁左侧最高点"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="右切圆后墙悬吊管水冷壁右侧最高点" prop="right_qy_back_xdg_right_top_point" >
                      <Input v-model="formModel.fields.right_qy_back_xdg_right_top_point" placeholder="请输入右切圆后墙悬吊管水冷壁右侧最高点"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="左切圆后墙悬吊管水冷壁左侧最高三个点" prop="left_qy_back_xdg_left_top3" >
                      <Input v-model="formModel.fields.left_qy_back_xdg_left_top3" placeholder="请输入左切圆后墙悬吊管水冷壁左侧最高三个点"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="左切圆后墙悬吊管水冷壁右侧最高三个点" prop="left_qy_back_xdg_right_top3" >
                      <Input v-model="formModel.fields.left_qy_back_xdg_right_top3" placeholder="请输入左切圆后墙悬吊管水冷壁右侧最高三个点"/>
                    </FormItem>
                    </Col>
                </Row><Row :gutter="16">
                    <Col span="12">
                    <FormItem label="右切圆后墙悬吊管水冷壁左侧最高三个点" prop="right_qy_back_xdg_left_top3" >
                      <Input v-model="formModel.fields.right_qy_back_xdg_left_top3" placeholder="请输入右切圆后墙悬吊管水冷壁左侧最高三个点"/>
                    </FormItem>
                    </Col>
                
                    <Col span="12">
                    <FormItem label="右切圆后墙悬吊管水冷壁右侧最高三个点" prop="right_qy_back_xdg_right_top3" >
                      <Input v-model="formModel.fields.right_qy_back_xdg_right_top3" placeholder="请输入右切圆后墙悬吊管水冷壁右侧最高三个点"/>
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
        <Button icon="md-checkmark-circle" type="primary" @click="handleSubmitHztemp_mid">保 存</Button>
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
  getHztemp_midList,
  createHztemp_mid,
  loadHztemp_mid,
  editHztemp_mid,
  deleteHztemp_mid,
  batchCommand,
  batchCreateHztemp_mid
} from "@/api/ZNRS/Dnchztemp_mid";
export default {
  name: "ZNRS_Hztemp_mid_page",
  components: {
    Tables,PasteEditor
  },
  data() {
    return {
      dataorder:["RealTime","flq_press_avg","flq_temp_avg","mg_press_out_a","mg_press_out_b","mg_press_out_c","mg_press_out_d","mg_press_out_left_avg","mg_press_out_right_avg","dg_press_out_a","dg_press_out_b","dg_press_out_c","dg_press_out_d","dg_temp_out_a","dg_temp_out_b","dg_temp_out_c","dg_temp_out_d","dg_out_hz_a","dg_out_hz_b","dg_out_hz_c","dg_out_hz_d","dg_press_in_a","dg_press_in_b","dg_press_in_c","dg_press_in_d","dg_temp_in_a","dg_temp_in_b","dg_temp_in_c","dg_temp_in_d","dg_in_hz_a","dg_in_hz_b","dg_in_hz_c","dg_in_hz_d","fgp_press_out_a","fgp_press_out_b","fgp_press_out_c","fgp_press_out_d","fgp_temp_out_a","fgp_temp_out_b","fgp_temp_out_c","fgp_temp_out_d","fgp_out_hz_a","fgp_out_hz_b","fgp_out_hz_c","fgp_out_hz_d","fgp_press_in_a","fgp_press_in_b","fgp_press_in_c","fgp_press_in_d","fgp_temp_in_a","fgp_temp_in_b","fgp_temp_in_c","fgp_temp_in_d","fgp_in_hz_a","fgp_in_hz_b","fgp_in_hz_c","fgp_in_hz_d","hp_press_out_a","hp_press_out_b","hp_press_out_c","hp_press_out_d","hp_temp_out_a","hp_temp_out_b","hp_temp_out_c","hp_temp_out_d","hp_out_hz_a","hp_out_hz_b","hp_out_hz_c","hp_out_hz_d","hp_press_in_a","hp_press_in_b","hp_press_in_c","hp_press_in_d","hp_temp_in_a","hp_temp_in_b","hp_temp_in_c","hp_temp_in_d","hp_in_hz_a","hp_in_hz_b","hp_in_hz_c","hp_in_hz_d","mg_temp_out_a","mg_temp_out_b","mg_temp_out_c","mg_temp_out_d","mg_out_hz_a","mg_out_hz_b","mg_out_hz_c","mg_out_hz_d","mg_press_in_a","mg_press_in_b","mg_press_in_c","mg_press_in_d","mg_temp_in_a","mg_temp_in_b","mg_temp_in_c","mg_temp_in_d","mg_in_hz_a","mg_in_hz_b","mg_in_hz_c","mg_in_hz_d","dz_press_in_left","dz_press_in_right","gz_press_out_left","gz_press_out_right","dz_press_out_left","dz_press_out_right","dz_temp_out_left","dz_temp_out_right","dz_out_hz_left","dz_out_hz_right","dz_temp_in_left","dz_temp_in_right","dz_in_hz_left","dz_in_hz_right","gz_temp_out_left","gz_temp_out_right","gz_out_hz_left","gz_out_hz_right","gz_press_in_left","gz_press_in_right","gz_temp_in_left","gz_temp_in_right","gz_in_hz_left","gz_in_hz_right","left_qy_o2_left_avg","left_qy_o2_right_avg","left_qy_back_xdg_left_top","left_qy_back_xdg_right_top","right_qy_o2_left_avg","right_qy_o2_right_avg","right_qy_back_xdg_left_top","right_qy_back_xdg_right_top","left_czd_temp","right_czd_temp","left_qy_back_xdg_left_top3_avg","left_qy_back_xdg_right_top3_avg","left_lxd_top10_avg","right_lxd_top10_avg","right_qy_back_xdg_left_top3_avg","right_qy_back_xdg_right_top3_avg","left_qy_back_gp_temp","right_qy_back_gp_temp","left_qy_front_gp_temp","right_qy_front_gp_temp","left_qy_back_lxd_top10_avg","right_qy_back_lxd_top10_avg","left_qy_front_lxd_top10_avg","right_qy_front_lxd_top10_avg","dz_jws_press","dz_jws_temp","dz_jws_hz","dz_jwq_front_left","dz_jwq_back_left","dz_jwq_front_right","dz_jwq_back_right","dz_jwq_front_hz_left","dz_jwq_back_hz_left","dz_jwq_front_hz_right","dz_jwq_back_hz_right","zrq_jws_left","zrq_jws_right","fgp_hz_design","hp_hz_design","mg_hz_design","dz_hz_design","gz_hz_design","grq_jws_hz","DncBoiler_Name","left_qy_back_xdg_left_top_point","left_qy_back_xdg_right_top_point","right_qy_back_xdg_left_top_point","right_qy_back_xdg_right_top_point","left_qy_back_xdg_left_top3","left_qy_back_xdg_right_top3","right_qy_back_xdg_left_top3","right_qy_back_xdg_right_top3","dg_hz_design"],
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
        Hztemp_mid: {
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
            { title: "分离器压力平均值", key: "flq_press_avg",  sortable: "custom" },    
            { title: "分离器温度平均值", key: "flq_temp_avg",  sortable: "custom" },    
            { title: "末级过热器出口压力A", key: "mg_press_out_a",  sortable: "custom" },    
            { title: "末级过热器出口压力B", key: "mg_press_out_b",  sortable: "custom" },    
            { title: "末级过热器出口压力B", key: "mg_press_out_c",  sortable: "custom" },    
            { title: "末级过热器出口压力D", key: "mg_press_out_d",  sortable: "custom" },    
            { title: "末级过热器出口压力左侧平均值", key: "mg_press_out_left_avg",  sortable: "custom" },    
            { title: "末级过热器出口压力右侧平均值", key: "mg_press_out_right_avg",  sortable: "custom" },    
            { title: "低温过热器出口压力A", key: "dg_press_out_a",  sortable: "custom" },    
            { title: "低温过热器出口压力B", key: "dg_press_out_b",  sortable: "custom" },    
            { title: "低温过热器出口压力C", key: "dg_press_out_c",  sortable: "custom" },    
            { title: "低温过热器出口压力D", key: "dg_press_out_d",  sortable: "custom" },    
            { title: "低温过热器出口温度A", key: "dg_temp_out_a",  sortable: "custom" },    
            { title: "低温过热器出口温度B", key: "dg_temp_out_b",  sortable: "custom" },    
            { title: "低温过热器出口温度C", key: "dg_temp_out_c",  sortable: "custom" },    
            { title: "低温过热器出口温度D", key: "dg_temp_out_d",  sortable: "custom" },    
            { title: "低温过热器出口焓值A", key: "dg_out_hz_a",  sortable: "custom" },    
            { title: "低温过热器出口焓值B", key: "dg_out_hz_b",  sortable: "custom" },    
            { title: "低温过热器出口焓值C", key: "dg_out_hz_c",  sortable: "custom" },    
            { title: "低温过热器出口焓值D", key: "dg_out_hz_d",  sortable: "custom" },    
            { title: "低温过热器进口压力A", key: "dg_press_in_a",  sortable: "custom" },    
            { title: "低温过热器进口压力B", key: "dg_press_in_b",  sortable: "custom" },    
            { title: "低温过热器进口压力C", key: "dg_press_in_c",  sortable: "custom" },    
            { title: "低温过热器进口压力D", key: "dg_press_in_d",  sortable: "custom" },    
            { title: "低温过热器进口温度A", key: "dg_temp_in_a",  sortable: "custom" },    
            { title: "低温过热器进口温度B", key: "dg_temp_in_b",  sortable: "custom" },    
            { title: "低温过热器进口温度C", key: "dg_temp_in_c",  sortable: "custom" },    
            { title: "低温过热器进口温度D", key: "dg_temp_in_d",  sortable: "custom" },    
            { title: "低温过热器进口焓值A", key: "dg_in_hz_a",  sortable: "custom" },    
            { title: "低温过热器进口焓值B", key: "dg_in_hz_b",  sortable: "custom" },    
            { title: "低温过热器进口焓值C", key: "dg_in_hz_c",  sortable: "custom" },    
            { title: "低温过热器进口焓值D", key: "dg_in_hz_d",  sortable: "custom" },    
            { title: "分隔屏出口压力A", key: "fgp_press_out_a",  sortable: "custom" },    
            { title: "分隔屏出口压力B", key: "fgp_press_out_b",  sortable: "custom" },    
            { title: "分隔屏出口压力C", key: "fgp_press_out_c",  sortable: "custom" },    
            { title: "分隔屏出口压力D", key: "fgp_press_out_d",  sortable: "custom" },    
            { title: "分隔屏出口温度A", key: "fgp_temp_out_a",  sortable: "custom" },    
            { title: "分隔屏出口温度B", key: "fgp_temp_out_b",  sortable: "custom" },    
            { title: "分隔屏出口温度C", key: "fgp_temp_out_c",  sortable: "custom" },    
            { title: "分隔屏出口温度D", key: "fgp_temp_out_d",  sortable: "custom" },    
            { title: "分隔屏出口焓值A", key: "fgp_out_hz_a",  sortable: "custom" },    
            { title: "分隔屏出口焓值B", key: "fgp_out_hz_b",  sortable: "custom" },    
            { title: "分隔屏出口焓值C", key: "fgp_out_hz_c",  sortable: "custom" },    
            { title: "分隔屏出口焓值D", key: "fgp_out_hz_d",  sortable: "custom" },    
            { title: "分隔屏进口压力A", key: "fgp_press_in_a",  sortable: "custom" },    
            { title: "分隔屏进口压力B", key: "fgp_press_in_b",  sortable: "custom" },    
            { title: "分隔屏进口压力C", key: "fgp_press_in_c",  sortable: "custom" },    
            { title: "分隔屏进口压力D", key: "fgp_press_in_d",  sortable: "custom" },    
            { title: "分隔屏进口温度A", key: "fgp_temp_in_a",  sortable: "custom" },    
            { title: "分隔屏进口温度B", key: "fgp_temp_in_b",  sortable: "custom" },    
            { title: "分隔屏进口温度C", key: "fgp_temp_in_c",  sortable: "custom" },    
            { title: "分隔屏进口温度D", key: "fgp_temp_in_d",  sortable: "custom" },    
            { title: "分隔屏进口焓值A", key: "fgp_in_hz_a",  sortable: "custom" },    
            { title: "分隔屏进口焓值B", key: "fgp_in_hz_b",  sortable: "custom" },    
            { title: "分隔屏进口焓值C", key: "fgp_in_hz_c",  sortable: "custom" },    
            { title: "分隔屏进口焓值D", key: "fgp_in_hz_d",  sortable: "custom" },    
            { title: "后屏出口压力A", key: "hp_press_out_a",  sortable: "custom" },    
            { title: "后屏出口压力B", key: "hp_press_out_b",  sortable: "custom" },    
            { title: "后屏出口压力C", key: "hp_press_out_c",  sortable: "custom" },    
            { title: "后屏出口压力D", key: "hp_press_out_d",  sortable: "custom" },    
            { title: "后屏出口温度A", key: "hp_temp_out_a",  sortable: "custom" },    
            { title: "后屏出口温度B", key: "hp_temp_out_b",  sortable: "custom" },    
            { title: "后屏出口温度C", key: "hp_temp_out_c",  sortable: "custom" },    
            { title: "后屏出口温度D", key: "hp_temp_out_d",  sortable: "custom" },    
            { title: "后屏出口焓值A", key: "hp_out_hz_a",  sortable: "custom" },    
            { title: "后屏出口焓值B", key: "hp_out_hz_b",  sortable: "custom" },    
            { title: "后屏出口焓值C", key: "hp_out_hz_c",  sortable: "custom" },    
            { title: "后屏出口焓值D", key: "hp_out_hz_d",  sortable: "custom" },    
            { title: "后屏进口压力A", key: "hp_press_in_a",  sortable: "custom" },    
            { title: "后屏进口压力B", key: "hp_press_in_b",  sortable: "custom" },    
            { title: "后屏进口压力C", key: "hp_press_in_c",  sortable: "custom" },    
            { title: "后屏进口压力D", key: "hp_press_in_d",  sortable: "custom" },    
            { title: "后屏进口温度A", key: "hp_temp_in_a",  sortable: "custom" },    
            { title: "后屏进口温度B", key: "hp_temp_in_b",  sortable: "custom" },    
            { title: "后屏进口温度C", key: "hp_temp_in_c",  sortable: "custom" },    
            { title: "后屏进口温度D", key: "hp_temp_in_d",  sortable: "custom" },    
            { title: "后屏进口焓值A", key: "hp_in_hz_a",  sortable: "custom" },    
            { title: "后屏进口焓值B", key: "hp_in_hz_b",  sortable: "custom" },    
            { title: "后屏进口焓值C", key: "hp_in_hz_c",  sortable: "custom" },    
            { title: "后屏进口焓值D", key: "hp_in_hz_d",  sortable: "custom" },    
            { title: "末级过热器出口温度A", key: "mg_temp_out_a",  sortable: "custom" },    
            { title: "末级过热器出口温度B", key: "mg_temp_out_b",  sortable: "custom" },    
            { title: "末级过热器出口温度C", key: "mg_temp_out_c",  sortable: "custom" },    
            { title: "末级过热器出口温度D", key: "mg_temp_out_d",  sortable: "custom" },    
            { title: "末级过热器出口焓值A", key: "mg_out_hz_a",  sortable: "custom" },    
            { title: "末级过热器出口焓值B", key: "mg_out_hz_b",  sortable: "custom" },    
            { title: "末级过热器出口焓值C", key: "mg_out_hz_c",  sortable: "custom" },    
            { title: "末级过热器出口焓值D", key: "mg_out_hz_d",  sortable: "custom" },    
            { title: "末级过热器进口压力A", key: "mg_press_in_a",  sortable: "custom" },    
            { title: "末级过热器进口压力B", key: "mg_press_in_b",  sortable: "custom" },    
            { title: "末级过热器进口压力C", key: "mg_press_in_c",  sortable: "custom" },    
            { title: "末级过热器进口压力D", key: "mg_press_in_d",  sortable: "custom" },    
            { title: "末级过热器进口温度A", key: "mg_temp_in_a",  sortable: "custom" },    
            { title: "末级过热器进口温度B", key: "mg_temp_in_b",  sortable: "custom" },    
            { title: "末级过热器进口温度C", key: "mg_temp_in_c",  sortable: "custom" },    
            { title: "末级过热器进口温度D", key: "mg_temp_in_d",  sortable: "custom" },    
            { title: "末级过热器进口焓值A", key: "mg_in_hz_a",  sortable: "custom" },    
            { title: "末级过热器进口焓值B", key: "mg_in_hz_b",  sortable: "custom" },    
            { title: "末级过热器进口焓值C", key: "mg_in_hz_c",  sortable: "custom" },    
            { title: "末级过热器进口焓值D", key: "mg_in_hz_d",  sortable: "custom" },    
            { title: "低温再热器进口压力左侧", key: "dz_press_in_left",  sortable: "custom" },    
            { title: "低温再热器进口压力右侧", key: "dz_press_in_right",  sortable: "custom" },    
            { title: "高温再热器出口压力左侧", key: "gz_press_out_left",  sortable: "custom" },    
            { title: "高温再热器出口压力右侧", key: "gz_press_out_right",  sortable: "custom" },    
            { title: "低温再热器出口压力左侧", key: "dz_press_out_left",  sortable: "custom" },    
            { title: "低温再热器出口压力右侧", key: "dz_press_out_right",  sortable: "custom" },    
            { title: "低温再热器出口温度左侧", key: "dz_temp_out_left",  sortable: "custom" },    
            { title: "低温再热器出口温度右侧", key: "dz_temp_out_right",  sortable: "custom" },    
            { title: "低温再热器出口焓值左侧", key: "dz_out_hz_left",  sortable: "custom" },    
            { title: "低温再热器出口焓值右侧", key: "dz_out_hz_right",  sortable: "custom" },    
            { title: "低温再热器进口温度左侧", key: "dz_temp_in_left",  sortable: "custom" },    
            { title: "低温再热器进口温度右侧", key: "dz_temp_in_right",  sortable: "custom" },    
            { title: "低温再热器进口焓值左侧", key: "dz_in_hz_left",  sortable: "custom" },    
            { title: "低温再热器进口焓值右侧", key: "dz_in_hz_right",  sortable: "custom" },    
            { title: "高温再热器出口温度左侧", key: "gz_temp_out_left",  sortable: "custom" },    
            { title: "高温再热器出口温度右侧", key: "gz_temp_out_right",  sortable: "custom" },    
            { title: "高温再热器出口焓值左侧", key: "gz_out_hz_left",  sortable: "custom" },    
            { title: "高温再热器出口焓值右侧", key: "gz_out_hz_right",  sortable: "custom" },    
            { title: "高温再热器进口压力左侧", key: "gz_press_in_left",  sortable: "custom" },    
            { title: "高温再热器进口压力右侧", key: "gz_press_in_right",  sortable: "custom" },    
            { title: "高温再热器进口温度左侧", key: "gz_temp_in_left",  sortable: "custom" },    
            { title: "高温再热器进口温度右侧", key: "gz_temp_in_right",  sortable: "custom" },    
            { title: "高温再热器进口焓值左侧", key: "gz_in_hz_left",  sortable: "custom" },    
            { title: "高温再热器进口焓值右侧", key: "gz_in_hz_right",  sortable: "custom" },    
            { title: "左切圆左侧氧量平均值", key: "left_qy_o2_left_avg",  sortable: "custom" },    
            { title: "左切圆右侧氧量平均值", key: "left_qy_o2_right_avg",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁左侧最高点", key: "left_qy_back_xdg_left_top",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁右侧最高点", key: "left_qy_back_xdg_right_top",  sortable: "custom" },    
            { title: "右切圆左侧氧量平均值", key: "right_qy_o2_left_avg",  sortable: "custom" },    
            { title: "右切圆右侧氧量平均值", key: "right_qy_o2_right_avg",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁左侧最高点", key: "right_qy_back_xdg_left_top",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁右侧最高点", key: "right_qy_back_xdg_right_top",  sortable: "custom" },    
            { title: "左墙垂直段水冷壁温度", key: "left_czd_temp",  sortable: "custom" },    
            { title: "右墙垂直段水冷壁温度", key: "right_czd_temp",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁左侧最高三个点平均值", key: "left_qy_back_xdg_left_top3_avg",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁右侧最高三个点平均值", key: "left_qy_back_xdg_right_top3_avg",  sortable: "custom" },    
            { title: "左墙螺旋段水冷壁最高10个点的平均值", key: "left_lxd_top10_avg",  sortable: "custom" },    
            { title: "右墙螺旋段水冷壁最高10个点的平均值", key: "right_lxd_top10_avg",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁左侧最高三个点平均值", key: "right_qy_back_xdg_left_top3_avg",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁右侧最高三个点平均值", key: "right_qy_back_xdg_right_top3_avg",  sortable: "custom" },    
            { title: "左切圆后墙管屏水冷壁温度", key: "left_qy_back_gp_temp",  sortable: "custom" },    
            { title: "右切圆后墙管屏水冷壁温度", key: "right_qy_back_gp_temp",  sortable: "custom" },    
            { title: "左切圆前墙垂直水冷壁温度", key: "left_qy_front_gp_temp",  sortable: "custom" },    
            { title: "右切圆前墙垂直水冷壁温度", key: "right_qy_front_gp_temp",  sortable: "custom" },    
            { title: "左切圆后墙螺旋段水冷壁温度最高10个点的平均值", key: "left_qy_back_lxd_top10_avg",  sortable: "custom" },    
            { title: "右切圆后墙螺旋段水冷壁温度最高10个点的平均值", key: "right_qy_back_lxd_top10_avg",  sortable: "custom" },    
            { title: "左切圆前墙螺旋段水冷壁温度最高10个点的平均值", key: "left_qy_front_lxd_top10_avg",  sortable: "custom" },    
            { title: "右切圆前墙螺旋段水冷壁温度最高10个点的平均值", key: "right_qy_front_lxd_top10_avg",  sortable: "custom" },    
            { title: "低温再热器减温水压力", key: "dz_jws_press",  sortable: "custom" },    
            { title: "低温再热器减温水温度", key: "dz_jws_temp",  sortable: "custom" },    
            { title: "低温再热器减温水焓值", key: "dz_jws_hz",  sortable: "custom" },    
            { title: "低温再热器减温器前温度（左侧）", key: "dz_jwq_front_left",  sortable: "custom" },    
            { title: "低温再热器减温器后温度（左侧）", key: "dz_jwq_back_left",  sortable: "custom" },    
            { title: "低温再热器减温器前温度（右侧）", key: "dz_jwq_front_right",  sortable: "custom" },    
            { title: "低温再热器减温器后温度（右侧）", key: "dz_jwq_back_right",  sortable: "custom" },    
            { title: "低温再热器减温器前再热蒸汽焓值（左侧）", key: "dz_jwq_front_hz_left",  sortable: "custom" },    
            { title: "低温再热器减温器后再热蒸汽焓值（左侧）", key: "dz_jwq_back_hz_left",  sortable: "custom" },    
            { title: "低温再热器减温器前再热蒸汽焓值（右侧）", key: "dz_jwq_front_hz_right",  sortable: "custom" },    
            { title: "低温再热器减温器后再热蒸汽焓值（右侧）", key: "dz_jwq_back_hz_right",  sortable: "custom" },    
            { title: "再热器减温水量（左侧）", key: "zrq_jws_left",  sortable: "custom" },    
            { title: "再热器减温水量（右侧）", key: "zrq_jws_right",  sortable: "custom" },    
            { title: "分隔屏设计焓增", key: "fgp_hz_design",  sortable: "custom" },    
            { title: "后屏设计焓增", key: "hp_hz_design",  sortable: "custom" },    
            { title: "末级过热器设计焓增", key: "mg_hz_design",  sortable: "custom" },    
            { title: "低温再热器设计焓增", key: "dz_hz_design",  sortable: "custom" },    
            { title: "高温再热器设计焓增", key: "gz_hz_design",  sortable: "custom" },    
            { title: "过热器减温水焓值", key: "grq_jws_hz",  sortable: "custom" },    
            { title: "", key: "dncBoiler_Name",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁左侧最高点", key: "left_qy_back_xdg_left_top_point",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁右侧最高点", key: "left_qy_back_xdg_right_top_point",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁左侧最高点", key: "right_qy_back_xdg_left_top_point",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁右侧最高点", key: "right_qy_back_xdg_right_top_point",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁左侧最高三个点", key: "left_qy_back_xdg_left_top3",  sortable: "custom" },    
            { title: "左切圆后墙悬吊管水冷壁右侧最高三个点", key: "left_qy_back_xdg_right_top3",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁左侧最高三个点", key: "right_qy_back_xdg_left_top3",  sortable: "custom" },    
            { title: "右切圆后墙悬吊管水冷壁右侧最高三个点", key: "right_qy_back_xdg_right_top3",  sortable: "custom" },    
            { title: "低温过热器设计焓增", key: "dg_hz_design",  sortable: "custom" },    
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
  
    loadHztemp_midList() {
      getHztemp_midList(this.stores.Hztemp_mid.query).then(res => {
        this.stores.Hztemp_mid.data = getDateMore(res.data.data,1,["realTime",]);
        this.stores.Hztemp_mid.query.totalCount = res.data.totalCount;
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
      this.handleResetFormHztemp_mid();
      this.doLoadAllForinkey();
      this.doLoadHztemp_mid(params.row.id);
    },
    handleSelect(selection, row) {},
    handleSelectionChange(selection) {
      this.formModel.selection = selection;
    },
    handleRefresh() {
      this.loadHztemp_midList();
    },
    handleShowCreateWindow() {
      this.handleSwitchFormModeToCreate();
      this.handleOpenFormWindow();
      this.handleResetFormHztemp_mid();
      this.doLoadAllForinkey();
      this.formModel.fields={
          RealTime:"",
          flq_press_avg:"",
          flq_temp_avg:"",
          mg_press_out_a:"",
          mg_press_out_b:"",
          mg_press_out_c:"",
          mg_press_out_d:"",
          mg_press_out_left_avg:"",
          mg_press_out_right_avg:"",
          dg_press_out_a:"",
          dg_press_out_b:"",
          dg_press_out_c:"",
          dg_press_out_d:"",
          dg_temp_out_a:"",
          dg_temp_out_b:"",
          dg_temp_out_c:"",
          dg_temp_out_d:"",
          dg_out_hz_a:"",
          dg_out_hz_b:"",
          dg_out_hz_c:"",
          dg_out_hz_d:"",
          dg_press_in_a:"",
          dg_press_in_b:"",
          dg_press_in_c:"",
          dg_press_in_d:"",
          dg_temp_in_a:"",
          dg_temp_in_b:"",
          dg_temp_in_c:"",
          dg_temp_in_d:"",
          dg_in_hz_a:"",
          dg_in_hz_b:"",
          dg_in_hz_c:"",
          dg_in_hz_d:"",
          fgp_press_out_a:"",
          fgp_press_out_b:"",
          fgp_press_out_c:"",
          fgp_press_out_d:"",
          fgp_temp_out_a:"",
          fgp_temp_out_b:"",
          fgp_temp_out_c:"",
          fgp_temp_out_d:"",
          fgp_out_hz_a:"",
          fgp_out_hz_b:"",
          fgp_out_hz_c:"",
          fgp_out_hz_d:"",
          fgp_press_in_a:"",
          fgp_press_in_b:"",
          fgp_press_in_c:"",
          fgp_press_in_d:"",
          fgp_temp_in_a:"",
          fgp_temp_in_b:"",
          fgp_temp_in_c:"",
          fgp_temp_in_d:"",
          fgp_in_hz_a:"",
          fgp_in_hz_b:"",
          fgp_in_hz_c:"",
          fgp_in_hz_d:"",
          hp_press_out_a:"",
          hp_press_out_b:"",
          hp_press_out_c:"",
          hp_press_out_d:"",
          hp_temp_out_a:"",
          hp_temp_out_b:"",
          hp_temp_out_c:"",
          hp_temp_out_d:"",
          hp_out_hz_a:"",
          hp_out_hz_b:"",
          hp_out_hz_c:"",
          hp_out_hz_d:"",
          hp_press_in_a:"",
          hp_press_in_b:"",
          hp_press_in_c:"",
          hp_press_in_d:"",
          hp_temp_in_a:"",
          hp_temp_in_b:"",
          hp_temp_in_c:"",
          hp_temp_in_d:"",
          hp_in_hz_a:"",
          hp_in_hz_b:"",
          hp_in_hz_c:"",
          hp_in_hz_d:"",
          mg_temp_out_a:"",
          mg_temp_out_b:"",
          mg_temp_out_c:"",
          mg_temp_out_d:"",
          mg_out_hz_a:"",
          mg_out_hz_b:"",
          mg_out_hz_c:"",
          mg_out_hz_d:"",
          mg_press_in_a:"",
          mg_press_in_b:"",
          mg_press_in_c:"",
          mg_press_in_d:"",
          mg_temp_in_a:"",
          mg_temp_in_b:"",
          mg_temp_in_c:"",
          mg_temp_in_d:"",
          mg_in_hz_a:"",
          mg_in_hz_b:"",
          mg_in_hz_c:"",
          mg_in_hz_d:"",
          dz_press_in_left:"",
          dz_press_in_right:"",
          gz_press_out_left:"",
          gz_press_out_right:"",
          dz_press_out_left:"",
          dz_press_out_right:"",
          dz_temp_out_left:"",
          dz_temp_out_right:"",
          dz_out_hz_left:"",
          dz_out_hz_right:"",
          dz_temp_in_left:"",
          dz_temp_in_right:"",
          dz_in_hz_left:"",
          dz_in_hz_right:"",
          gz_temp_out_left:"",
          gz_temp_out_right:"",
          gz_out_hz_left:"",
          gz_out_hz_right:"",
          gz_press_in_left:"",
          gz_press_in_right:"",
          gz_temp_in_left:"",
          gz_temp_in_right:"",
          gz_in_hz_left:"",
          gz_in_hz_right:"",
          left_qy_o2_left_avg:"",
          left_qy_o2_right_avg:"",
          left_qy_back_xdg_left_top:"",
          left_qy_back_xdg_right_top:"",
          right_qy_o2_left_avg:"",
          right_qy_o2_right_avg:"",
          right_qy_back_xdg_left_top:"",
          right_qy_back_xdg_right_top:"",
          left_czd_temp:"",
          right_czd_temp:"",
          left_qy_back_xdg_left_top3_avg:"",
          left_qy_back_xdg_right_top3_avg:"",
          left_lxd_top10_avg:"",
          right_lxd_top10_avg:"",
          right_qy_back_xdg_left_top3_avg:"",
          right_qy_back_xdg_right_top3_avg:"",
          left_qy_back_gp_temp:"",
          right_qy_back_gp_temp:"",
          left_qy_front_gp_temp:"",
          right_qy_front_gp_temp:"",
          left_qy_back_lxd_top10_avg:"",
          right_qy_back_lxd_top10_avg:"",
          left_qy_front_lxd_top10_avg:"",
          right_qy_front_lxd_top10_avg:"",
          dz_jws_press:"",
          dz_jws_temp:"",
          dz_jws_hz:"",
          dz_jwq_front_left:"",
          dz_jwq_back_left:"",
          dz_jwq_front_right:"",
          dz_jwq_back_right:"",
          dz_jwq_front_hz_left:"",
          dz_jwq_back_hz_left:"",
          dz_jwq_front_hz_right:"",
          dz_jwq_back_hz_right:"",
          zrq_jws_left:"",
          zrq_jws_right:"",
          fgp_hz_design:"",
          hp_hz_design:"",
          mg_hz_design:"",
          dz_hz_design:"",
          gz_hz_design:"",
          grq_jws_hz:"",
          DncBoiler:0,
          DncBoiler_Name:"",
          left_qy_back_xdg_left_top_point:"",
          left_qy_back_xdg_right_top_point:"",
          right_qy_back_xdg_left_top_point:"",
          right_qy_back_xdg_right_top_point:"",
          left_qy_back_xdg_left_top3:"",
          left_qy_back_xdg_right_top3:"",
          right_qy_back_xdg_left_top3:"",
          right_qy_back_xdg_right_top3:"",
          dg_hz_design:"",
          status: 1,
          isDeleted: 0
      };
    },
    handleSubmitHztemp_mid() {
      let valid = this.validateHztemp_midForm();
      let o=this;
      valid.then(function(data){ 
        if (data) {
          if (o.formModel.mode === "create") {
            o.doCreateHztemp_mid();
          }
          if (o.formModel.mode === "edit") {
            o.doEditHztemp_mid();
          }
        }
      });
    },
    handleResetFormHztemp_mid() {
      this.$refs["formHztemp_mid"].resetFields();
    },
    doCreateHztemp_mid() {
      
      createHztemp_mid(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_midList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    doEditHztemp_mid() {
      editHztemp_mid(this.formModel.fields).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_midList();
        } else {
          this.$Message.warning(res.data.message);
        }
        this.handleCloseFormWindow();
      });
    },
    validateHztemp_midForm() {
      let _valid = false;
      let o=this;
      return new Promise(function(resolve, reject){
        o.$refs["formHztemp_mid"].validate(valid => {
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
    doLoadHztemp_mid(id) {
      loadHztemp_mid({ code: id+"" }).then(res => {
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
      deleteHztemp_mid(ids).then(res => {
        if (res.data.code === 200) {
          this.$Message.success(res.data.message);
          this.loadHztemp_midList();
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
          this.loadHztemp_midList();
          this.formModel.selection=[];
        } else {
          this.$Message.warning(res.data.message);
        }
        this.$Modal.remove();
      });
    },
    handleSearchHztemp_mid() {
      this.loadHztemp_midList();
    },
    rowClsRender(row, index) {
      if (row.isDeleted) {
        return "table-row-disabled";
      }
      return "";
    },
    handlePageChanged(page) {
      this.stores.Hztemp_mid.query.currentPage = page;
      this.loadHztemp_midList();
    },
    handlePageSizeChanged(pageSize) {
      this.stores.Hztemp_mid.query.pageSize = pageSize;
      this.loadHztemp_midList();
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
        if(this.$refs.m1n1.$children && t<=178){
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
        batchCreateHztemp_mid({
          fsts: s
        }).then(res => {
            if (res.data.code === 200) {
              this.$Message.success(res.data.message);
              this.loadHztemp_midList();
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
      this.stores.Hztemp_mid.query.sort= [
        {
          direct: column.order,
          field: column.key
        }
      ];
      this.loadHztemp_midList();
    }
  },
  mounted() {
    this.loadHztemp_midList();
  }
};
</script>






