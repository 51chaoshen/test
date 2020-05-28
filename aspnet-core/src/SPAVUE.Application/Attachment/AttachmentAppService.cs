using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using SPAVUE.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPAVUE
{
   public  class AttachmentAppService : AsyncCrudAppService<Attachment, AttachmentDto, int, PagedAttachmentResultRequestDto, CreateAttachmentDto, AttachmentDto>, IAttachmentAppService
    {
        public AttachmentAppService(IRepository<Attachment, int> repository) : base(repository)
        {

        }


       
    }
}
