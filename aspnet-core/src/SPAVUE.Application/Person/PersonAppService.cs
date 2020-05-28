using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPAVUE.Person
{
    public class PersonAppService : AsyncCrudAppService<Person, PersonDto, int, PagedPersonResultRequestDto, CreatePersonDto, PersonDto>, IPersonAppService
    {

        public PersonAppService(IRepository<Person, int> repository) :base(repository)
        {

        }
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PersonDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }
    }

}
