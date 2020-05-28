using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SPAVUE.Person
{
    [Table("pb_person")]
    public  class Person:FullAuditedEntity<int>
    {
  



        [MaxLength(50)]
        public string Name { get; set; }


        [MaxLength(11)]
        public string phone { get; set; }
    }
}
