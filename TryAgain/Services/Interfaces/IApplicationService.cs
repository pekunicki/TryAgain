using TryAgain.Models;
using TryAgain.Models.ViewModels;

namespace TryAgain.Services.Interfaces
{
    public interface IApplicationService
    {
        int SaveApplication(ApplicationModel app);
        ApplicationModel GetById(int id);
    }
}
