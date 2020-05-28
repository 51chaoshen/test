using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SPAVUE.EntityFrameworkCore
{
    public static class SPAVUEDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SPAVUEDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SPAVUEDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
