using System.Threading.Tasks;
using AbpCore.Project.Configuration.Dto;

namespace AbpCore.Project.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
