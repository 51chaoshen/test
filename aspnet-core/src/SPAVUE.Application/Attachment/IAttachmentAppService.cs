using Abp.Application.Services;
using SPAVUE.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAVUE
{
   public  interface IAttachmentAppService : IAsyncCrudAppService<AttachmentDto, string, PagedAttachmentResultRequestDto, CreateAttachmentDto, AttachmentDto>
    {

    }
}
