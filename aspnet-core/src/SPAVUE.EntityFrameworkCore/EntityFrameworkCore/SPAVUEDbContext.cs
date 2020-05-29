using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SPAVUE.Authorization.Roles;
using SPAVUE.Authorization.Users;
using SPAVUE.MultiTenancy;
using SPAVUE.Attachments;

namespace SPAVUE.EntityFrameworkCore
{
    public class SPAVUEDbContext : AbpZeroDbContext<Tenant, Role, User, SPAVUEDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<SPAVUE.Person.Person> Persons { get; set; }
        public DbSet<Attachment> attachments { get; set; }
        public SPAVUEDbContext(DbContextOptions<SPAVUEDbContext> options)
            : base(options)
        {
        }
    }
}
