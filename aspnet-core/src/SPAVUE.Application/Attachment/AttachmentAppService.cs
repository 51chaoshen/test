using Abp.Application.Services;
using Abp.Domain.Repositories;
using SPAVUE.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAVUE
{
   public  class AttachmentAppService : AsyncCrudAppService<Attachment, AttachmentDto, string, PagedAttachmentResultRequestDto, CreateAttachmentDto, AttachmentDto>, IAttachmentAppService
    {
        public AttachmentAppService(IRepository<Attachment, string> repository) : base(repository)
        {

        }
      
    }
}
