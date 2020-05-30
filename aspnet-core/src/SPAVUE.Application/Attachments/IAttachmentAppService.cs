using Abp.Application.Services;
using SPAVUE.Attachments.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAVUE.Attachments
{
   public  interface IAttachmentAppService : IAsyncCrudAppService<AttachmentDto, Guid, PagedAttachmentResultRequestDto, CreateAttachmentDto, AttachmentDto>
    {
      
    }
}
