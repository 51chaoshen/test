using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SPAVUE.Attachments;
using SPAVUE.Attachments.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SPAVUE.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileManageController : SPAVUEControllerBase
    {

        private readonly IAttachmentAppService _attachmentAppService;

        private readonly IWebHostEnvironment _webEnvironment;


        private readonly IConfiguration _configuration;

        private  string updateDir = "";



        public FileManageController(IWebHostEnvironment webEnvironment, IAttachmentAppService attachmentAppService, IConfiguration configuration)
        {
            _webEnvironment = webEnvironment;
            _attachmentAppService = attachmentAppService;
            _configuration = configuration;
            updateDir = configuration["UploadConfig:UploadPath"];
        }


      

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Upload()
        {
            

            var files = Request.Form?.Files;

            if (files == null || files.Count == 0)
            {
                throw new Exception("请上传文件");
            }

            try
            {

                var realDir = Path.Combine(_webEnvironment.WebRootPath, updateDir);

                if (!Directory.Exists(realDir))
                {
                   Directory.CreateDirectory(realDir);
                   
                }
                foreach (var file in files)
                {
                    var attachment = new CreateAttachmentDto();

                    var fileName = file.FileName.Split('.')[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999) + Path.GetExtension(file.FileName);

                    using (var fileSteam = new FileStream(Path.Combine(realDir, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileSteam);
                    }
                        
                    

                  
                    attachment.FileSize =file.Length;
                    attachment.Name = file.FileName;                    
                    attachment.Extenson = Path.GetExtension(file.FileName);
                    attachment.FileName = fileName;
                    attachment.AbsoluteUrl = _configuration["App:ServerRootAddress"] + updateDir +"/"+fileName;
                    attachment.RelativeUrl ="/"+ updateDir +"/"+ fileName;
                    attachment.AttachmentId = Guid.NewGuid().ToString("N");
                    await _attachmentAppService.CreateAsync(attachment);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


           
        }



        ///// <summary>
        ///// 下载
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task Download(int id)
        //{

        //    var attachment = await _attachmentAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<int>(id));
        //    if (attachment == null)
        //    {
        //        throw new ArgumentException("参数异常");
        //    }

        //    var path = Path.Combine(_webEnvironment.WebRootPath, updateDir, attachment.FileName);
        //    if (!System.IO.File.Exists(path))
        //    {
        //        Response.StatusCode = 404;
        //    }

        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {

        //        Response.ContentType = "application/octet-stream";
        //        Response.Headers.Add("Content-Disposition", string.Format("filename={0}", attachment.Name));
        //        Response.ContentLength = stream.Length;
        //        await stream.CopyToAsync(Response.Body);

        //    }


        // }


        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Download(int id)
        {

            var attachment = await _attachmentAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<int>(id));
            if (attachment == null)
            {
                throw new ArgumentException("参数异常");
            }

            var path = Path.Combine(_webEnvironment.WebRootPath, updateDir, attachment.FileName);
            if (!System.IO.File.Exists(path))
            {
                return new EmptyResult();
            }


            return File(new FileStream(path, FileMode.Open), "application/octet-stream", attachment.Name);

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id)
        {

            var attachment = await _attachmentAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<int>(id));
            await _attachmentAppService.DeleteAsync(new Abp.Application.Services.Dto.EntityDto<int>(id));
            if (attachment == null)
            {
                throw new ArgumentException("参数异常");
            }

            var path = Path.Combine(_webEnvironment.WebRootPath, updateDir, attachment.FileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
           



        }
    }
}
