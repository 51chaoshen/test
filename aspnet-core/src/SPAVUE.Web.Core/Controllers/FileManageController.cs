using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using SPAVUE.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SPAVUE.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileManageController : SPAVUEControllerBase
    {

        private readonly IAttachmentAppService _attachmentAppService;

        private readonly IHostingEnvironment _hostingEnvironment;




        public FileManageController(IHostingEnvironment hostingEnvironment, IAttachmentAppService attachmentAppService)
        {
            _hostingEnvironment = hostingEnvironment;
            _attachmentAppService = attachmentAppService;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AttachmentDto> Update([FromBody] CreateAttachmentDto data)
        {
            var result = new AttachmentDto();

            var files = Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                throw new Exception("请上传文件");
            }

            try
            {
                //TODO
                var updateDir = "/Attachment";

                var realDir = Path.Combine(_hostingEnvironment.WebRootPath, updateDir);

                if (!Directory.Exists(realDir))
                {
                    Directory.CreateDirectory(realDir);
                }
                foreach (var file in files)
                {
                    var fileSteam = new FileStream(realDir, FileMode.CreateNew);
                    await file.CopyToAsync(fileSteam);

                    var attachment = new CreateAttachmentDto();

                    attachment.Name = file.FileName;
                    attachment.RelativeUrl = updateDir+ file.FileName;
                    await _attachmentAppService.CreateAsync(attachment);

                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            return result;
        }
    }
}
