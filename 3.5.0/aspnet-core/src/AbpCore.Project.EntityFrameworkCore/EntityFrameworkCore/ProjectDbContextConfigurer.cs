using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpCore.Project.EntityFrameworkCore
{
    public static class ProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
