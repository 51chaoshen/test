using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
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
                    CheckFile(file, _configuration["App:AllowExtension"], _configuration["App:MaxSize"]);
                   
                   
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

        private void CheckFile(IFormFile file,string  allowExtension,string maxSize)
        {
            //格式验证
            if (checkType(file, allowExtension.ToLower().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)))
            {
                throw new Exception("不允许的文件类型");
            }
            long size;
            if(!long.TryParse(maxSize,out size))
            {
                throw new Exception("文件配置异常");
            }
            //大小验证
            if (checkSize(file, size))
            {
                throw new Exception("文件大小超出网站限制");
            }
        }

        private bool checkSize(IFormFile file, long maxSize)
        {
            return file.Length >= (maxSize * 1024 * 1024);
        }

        private bool checkType(IFormFile file, string[] exts)
        {
            var currentType = Path.GetExtension(file.FileName).ToLower().Trim('.');
            return Array.IndexOf(exts, currentType) == -1;
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
        //        Response.Headers.Add("Content-Disposition", string.Format("filename={0}", attachment.Name));//没有这行浏览器没有反应
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
        public async Task<ActionResult> Download(Guid id)
        {

            var attachment = await _attachmentAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<Guid>(id));
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
        public async Task Delete(Guid id)
        {

            var attachment = await _attachmentAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<Guid>(id));
            await _attachmentAppService.DeleteAsync(new Abp.Application.Services.Dto.EntityDto<Guid>(id));
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
