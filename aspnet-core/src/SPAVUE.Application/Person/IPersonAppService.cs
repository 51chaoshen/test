using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPAVUE.Person
{
    public interface IPersonAppService : IAsyncCrudAppService<PersonDto, int, PagedPersonResultRequestDto, CreatePersonDto, PersonDto>
    {
    }

    [AutoMapFrom(typeof(SPAVUE.Person.Person))]
   
    public class PersonDto : EntityDto<int>
    {
       
       [StringLength(50)]
        public string Name { get; set; }

    }
    public class PagedPersonResultRequestDto : PagedResultRequestDto
    {
    }


    [AutoMapTo(typeof(SPAVUE.Person.Person))]
    public class CreatePersonDto
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}

