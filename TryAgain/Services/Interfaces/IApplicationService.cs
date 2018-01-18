using TryAgain.Models;
using TryAgain.Models.ViewModels;

namespace TryAgain.Services.Interfaces
{
    public interface IApplicationService
    {
        ApplicationModel CreateApplicationModel(ApplicationViewModel app, UserModel user);
        void SaveApplication(ApplicationModel app);
        ApplicationModel GetById(int id);
        ApplicationViewModel CreateApplicationViewModel(ApplicationModel appModel);
    }
}
