using System.Threading.Tasks;
using SPAVUE.Configuration.Dto;

namespace SPAVUE.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
