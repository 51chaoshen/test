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
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "@/lib/util";
import AbpBase from "@/lib/abpbase";
import PageRequest from "@/store/entities/page-request";
import uploadAttachment from "./upload.vue";

import Ajax from "./../../../lib/ajax";
import Attachment from "./../../../store/entities/attachment";
class PageAttachmentRequest extends PageRequest {
  keyword: string;
  isActive: boolean = null; //nullable
  from: Date;
  to: Date;
}

@Component({
  components: { uploadAttachment }
})
export default class Attachments extends AbpBase {
  //filters
  pagerequest: PageAttachmentRequest = new PageAttachmentRequest();
  creationTime: Date[] = [];

  uploadModalShow: boolean = false;

  public list: Attachment[] = [];

  get loading() {
    return this.$store.state.user.loading;
  }
  upload() {
    this.uploadModalShow = true;
  }
  async download(id: number) {
    let a = document.createElement('a')
    a.href ='http://localhost:21021/api/FileManage/Download?id='+id
    a.click();
  


  }
   async delete(id: number) {
    
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
      title: this.L("文件大小"),
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
      width: 200,
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
            this.L("下载")
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
            this.L("删除")
          )
        ]);
      }
    }
  ];
  async created() {
    this.getpage();
    await this.$store.dispatch({
      type: "user/getRoles"
    });
  }
}
</script>