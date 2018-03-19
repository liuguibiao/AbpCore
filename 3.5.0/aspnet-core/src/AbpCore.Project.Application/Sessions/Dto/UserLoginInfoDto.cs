using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCore.Project.Authorization.Users;

namespace AbpCore.Project.Sessions.Dto
{
    [AutoMapFrom(typeof(Authorization.Users.User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
