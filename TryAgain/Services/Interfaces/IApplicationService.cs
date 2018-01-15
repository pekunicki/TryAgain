using TryAgain.Models;
using TryAgain.Models.ViewModels;

namespace TryAgain.Services.Interfaces
{
    public interface IApplicationService
    {
        ApplicationModel CreateApplicationModel(ApplicationViewModel app, UserModel user);
        ApplicationModel SaveApplication(ApplicationModel app);
    }
}
