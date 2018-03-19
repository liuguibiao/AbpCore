using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using AbpCore.Project.Authorization.Users;

namespace AbpCore.Project.Authorization.Roles
{
    public class Role : AbpRole<Users.User>
    {
        public const int MaxDescriptionLength = 5000;

        public Role()
        {
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {
        }

        [StringLength(MaxDescriptionLength)]
        public string Description {get; set;}
    }
}
