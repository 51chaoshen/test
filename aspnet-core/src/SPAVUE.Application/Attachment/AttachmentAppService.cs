using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using SPAVUE.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
