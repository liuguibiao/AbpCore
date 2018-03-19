using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpCore.Project.Authorization.Roles;
using AbpCore.Project.Authorization.Users;
using AbpCore.Project.MultiTenancy;

namespace AbpCore.Project.EntityFrameworkCore
{
    public class ProjectDbContext : AbpZeroDbContext<Tenant, Role, User, ProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }
    }
}
