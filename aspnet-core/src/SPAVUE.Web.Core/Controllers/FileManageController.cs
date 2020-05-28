using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using SPAVUE.Dto;
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

        private const string updateDir = "Attachment";



        public FileManageController(IWebHostEnvironment webEnvironment, IAttachmentAppService attachmentAppService)
        {
            _webEnvironment = webEnvironment;
            _attachmentAppService = attachmentAppService;
        }


      

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Update()
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
                    var fileSteam = new FileStream(realDir, FileMode.Create);
                    await file.CopyToAsync(fileSteam);

                    var attachment = new CreateAttachmentDto();

                    attachment.Name = file.FileName;
                    attachment.RelativeUrl = updateDir + file.FileName;
                    await _attachmentAppService.CreateAsync(attachment);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


           
        }



        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Download(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("参数异常");
            }
            var attachment = await _attachmentAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<string>(id));
            if (attachment == null)
            {
                throw new ArgumentException("参数异常");
            }

            var path = Path.Combine(updateDir, attachment.Url);
            var stream = new FileStream(path, FileMode.Open);


            //读取到内存
            MemoryStream temp = new MemoryStream();
            byte[] buffer = new byte[1024];
            int i;
            //将字节逐个放入到Byte中
            while ((i = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                temp.Write(buffer, 0, i);
            }
            temp.Close();
            return File(buffer, "application/octet-stream", attachment.Name);

        }
    }
}
