using AutoMapper;
using TryAgain.Models;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class ApplicationService : IApplicationService
    {
        private readonly ApplicationRepository _applicationRepository;

        public ApplicationService(ApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public int SaveApplication(ApplicationModel appModel)
        {
            var app = MapToApplication(appModel);
            app = _applicationRepository.Create(app);
            return app.Id;
        }

        public ApplicationModel GetById(int id)
        {
            var app = _applicationRepository.GetApplicationById(id, true);

            var appModel = MapToApplicationModel(app);
            return appModel;
        }

        private static ApplicationModel MapToApplicationModel(Application app)
        {
            var appModel = Mapper.Map<ApplicationModel>(app);
            return appModel;
        }

        private static Application MapToApplication(ApplicationModel appModel)
        {
            var app = Mapper.Map<Application>(appModel);
            return app;
        }
    }
}