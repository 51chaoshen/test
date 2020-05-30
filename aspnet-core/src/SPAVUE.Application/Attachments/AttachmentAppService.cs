using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SPAVUE.Attachments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SPAVUE.Attachments
{
   public  class AttachmentAppService : AsyncCrudAppService<Attachment, AttachmentDto, Guid, PagedAttachmentResultRequestDto, CreateAttachmentDto, AttachmentDto>, IAttachmentAppService
    {
        public AttachmentAppService(IRepository<Attachment, Guid> repository) : base(repository)
        {

        }

       
    }
}
