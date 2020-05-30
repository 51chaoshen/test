using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
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
    public class CreatePersonDto: ICustomValidate
    { 
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        //[MaxLength(11)]
        [Required]
        public string phone { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (phone.Length > 11)
            {
                context.Results.Add(new ValidationResult("info:The field phone must be a string or array type with a maximum length of '11'"));
            }
        }
    }
}

