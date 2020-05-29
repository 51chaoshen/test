<template>
  <div>
    <Modal :title="L('预览')" :value="value"   @on-visible-change="visibleChange">
      <div   >
       
         <img style="width:100%;" :src=imgSrc />
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
import AppConsts from './../../../lib/appconst'
@Component
export default class upload extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  @Prop({ type: String ,default:''}) imgSrc: string;
  remoteServiceBaseUrl:string=  AppConsts.remoteServiceBaseUrl+"/api/FileManage/upload"
 
  cancel() {
    
           

     this.$emit('input',false);
     
  
  }
   visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
  
 
}
</script>

