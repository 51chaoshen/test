<template>
  <div>
    <Card dis-hover>
      <div class="page-body">
          <div>
              <i-button type="primary" @click="upload">上传</i-button>
          </div>
        <div class="margin-top-10">
          <Table
            :loading="loading"
            :columns="columns"
            :no-data-text="L('NoDatas')"
            border
            :data="list"
          ></Table>
          <Page
            show-sizer
            class-name="fengpage"
            :total="totalCount"
            class="margin-top-10"
            @on-change="pageChange"
            @on-page-size-change="pagesizeChange"
            :page-size="pageSize"
            :current="currentPage"
          ></Page>
        </div>
      </div>
    </Card>
    <upload-Attachment v-model="uploadModalShow" @save-success="getpage"></upload-Attachment>
    <preview-Attachment v-model="previewModalShow" :imgSrc="previewImgSrc" ></preview-Attachment>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "@/lib/util";
import AbpBase from "@/lib/abpbase";
import PageRequest from "@/store/entities/page-request";
import uploadAttachment from "./upload.vue";
import previewAttachment from "./preview.vue";
import Ajax from "./../../../lib/ajax";
import Attachment from "./../../../store/entities/attachment";
import AppConsts from './../../../lib/appconst'
class PageAttachmentRequest extends PageRequest {
  keyword: string;
  isActive: boolean = null; //nullable
  from: Date;
  to: Date;
}

@Component({
  components: { uploadAttachment, previewAttachment}
})
export default class Attachments extends AbpBase {
  //filters
  pagerequest: PageAttachmentRequest = new PageAttachmentRequest();
  creationTime: Date[] = [];

  uploadModalShow: boolean = false;
  previewModalShow: boolean = false;
  previewImgSrc:string=""
  public list: Attachment[] = [];

  get loading() {
    return this.$store.state.user.loading;
  }
  upload() {
    this.uploadModalShow = true;
  }
  async download(id: string) {
    let a = document.createElement('a')
    a.href =AppConsts.remoteServiceBaseUrl+'/api/FileManage/Download?id='+id
    a.click();
  


  }
  async preview(imgSrc: string) {
      debugger
     this.previewModalShow = true;
     this.previewImgSrc=imgSrc

  }
   async delete(id: string) {
    
    await Ajax.delete('/api/FileManage/Delete?id='+id)
    await this.getpage();
  }

  pageChange(page: number) {
    this.$store.commit("user/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("user/setPageSize", pagesize);
    this.getpage();
  }
  async getpage() {
      debugger
    // this.pagerequest.maxResultCount = this.pageSize;
    // this.pagerequest.skipCount = (this.currentPage - 1) * this.pageSize;
    // //filters

    // if (this.creationTime.length > 0) {
    //   this.pagerequest.from = this.creationTime[0];
    // }
    // if (this.creationTime.length > 1) {
    //   this.pagerequest.to = this.creationTime[1];
    // }

    let reponse = await Ajax.get("/api/services/app/Attachment/GetAll");
    this.list = reponse.data.result.items;
     this.$set(this.list,'list',reponse.data.result.items)
  }
  get pageSize() {
    return this.$store.state.user.pageSize;
  }
  get totalCount() {
    return this.$store.state.user.totalCount;
  }
  get currentPage() {
    return this.$store.state.user.currentPage;
  }

  columns = [
    {
      title: this.L("Name"),
      key: "name"
    },
    {
      title: this.L("文件大小(字节)"),
      key: "fileSize"
    },
     {
      title: this.L("上传时间"),
      key: "creationTime",
       render:(h:any,params:any)=>{
                return h('span',new Date(params.row.creationTime).toLocaleString())
            }
    },
    {
      title: this.L("Actions"),
      key: "Actions",
     
      render: (h: any, params: any) => {
        return h("div", [
          h(
            "Button",
            {
              props: {
                type: "primary",
                size: "small"
              },
              style: {
                marginRight: "5px"
              },
              on: {
                click: () => {
                
                  let attach = params.row as Attachment;
                  this.download(attach.id).catch(err=>{});
                }
              }
            },
            this.L("Download")
          ),
           h(
            "Button",
            {
              props: {
                type: "success",
                size: "small"
              },
              style: {
                marginRight: "5px",
                display: ['.jpg','.png'].indexOf((params.row.extenson as string).toLowerCase() )>-1?'': 'none'
              },
              on: {
                click: () => {
                
                  let attach = params.row as Attachment;
                  debugger
                  this.preview(attach.absoluteUrl).catch(err=>{});
                }
              }
            },
            this.L("Preview")
          ),
              h(
            "Button",
            {
              props: {
                type: "warning",
                size: "small"
              },
              style: {
                marginRight: "5px"
              },
              on: {
                click: () => {
                
                  let attach = params.row as Attachment;
                  this.delete(attach.id).catch(err=>{});
                }
              }
            },
            this.L("Delete")
          )
        ]);
      }
    }
  ];
  async created() {
    this.getpage();
   
  }
}
</script>