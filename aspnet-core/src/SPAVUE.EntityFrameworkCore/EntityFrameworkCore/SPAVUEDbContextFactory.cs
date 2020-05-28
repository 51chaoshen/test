using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SPAVUE.Configuration;
using SPAVUE.Web;

namespace SPAVUE.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SPAVUEDbContextFactory : IDesignTimeDbContextFactory<SPAVUEDbContext>
    {
        public SPAVUEDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SPAVUEDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SPAVUEDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SPAVUEConsts.ConnectionStringName));

            return new SPAVUEDbContext(builder.Options);
        }
    }
}
