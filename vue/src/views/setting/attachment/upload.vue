<template>
  <div>
    <Modal :title="L('上传')" :value="value"   @on-visible-change="visibleChange">
      <div   >
       
          <Upload ref="upload" multiple type="drag" action="http://localhost:21021/api/FileManage/upload" :on-success="handleSuccess">
            <div style="padding: 20px 0">
              <Icon type="ios-cloud-upload" size="52" style="color: #3399ff"></Icon>
              <p>点击或将文件拖拽到这里上传</p>
            </div>
          </Upload>
        
      </div>
      <div slot="footer">
        <Button @click="cancel">{{L('关闭')}}</Button>
        
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../../lib/util";
import AbpBase from "../../../lib/abpbase";

@Component
export default class upload extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;



  cancel() {
     const mainImg = this.$refs.upload as any; 
     mainImg.clearFiles();
           


     this.$emit('input',false);
     
  
  }
   visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
  handleSuccess(){
   
       //刷新列表
       (this.$parent as any).getpage()
  }
 
}
</script>

