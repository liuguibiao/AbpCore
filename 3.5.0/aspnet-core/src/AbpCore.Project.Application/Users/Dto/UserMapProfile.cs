using AutoMapper;
using AbpCore.Project.Authorization.Users;

namespace AbpCore.Project.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, Authorization.Users.User>();
            CreateMap<UserDto, Authorization.Users.User>().ForMember(
                x => x.Roles,
                (IMemberConfigurationExpression<UserDto, Authorization.Users.User,
                System.Collections.Generic.ICollection<Abp.Authorization.Users.UserRole>> opt)
                => opt.Ignore()
                );

            CreateMap<CreateUserDto, Authorization.Users.User>();
            CreateMap<CreateUserDto, Authorization.Users.User>().ForMember(x => x.Roles, (IMemberConfigurationExpression<CreateUserDto, Authorization.Users.User, System.Collections.Generic.ICollection<Abp.Authorization.Users.UserRole>> opt) => opt.Ignore());
        }
    }
}
