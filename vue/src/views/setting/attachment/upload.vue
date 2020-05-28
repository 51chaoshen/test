<template>
  <div>
    <Modal :title="L('上传')" :value="value">
      <Form ref="Form" label-position="top" :model="user">
        <FormItem  >
          <Upload multiple type="drag" action="http://localhost:21021/api/FileManage/upload" :on-success="handleSuccess">
            <div style="padding: 20px 0">
              <Icon type="ios-cloud-upload" size="52" style="color: #3399ff"></Icon>
              <p>点击或将文件拖拽到这里上传</p>
            </div>
          </Upload>
        </FormItem>
      </Form>
      <div slot="footer">
        <!-- <Button @click="cancel">{{L('Cancel')}}</Button> -->
        
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../../lib/util";
import AbpBase from "../../../lib/abpbase";

@Component
export default class CreateUser extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;



  cancel() {
    (this.$refs.Form as any).resetFields();
  
  }
  handleSuccess(){
      debugger
       //刷新列表
       this.$parent.getpage()
  }
 
}
</script>

