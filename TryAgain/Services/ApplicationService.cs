using TryAgain.Models;
using TryAgain.Models.Mappers;
using TryAgain.Models.ViewModels;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class ApplicationService : IApplicationService
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly ApplicationRepository _applicationRepository;
        private readonly ITeacherConfirmationService _teacherConfirmationService;
        private readonly ApplicationModelMapper _applicationModelMapper;


        public ApplicationService(
            ITeacherService teacherService, 
            ICourseService courseService, 
            ApplicationRepository applicationRepository,
            ITeacherConfirmationService teacherConfirmationService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
            _applicationRepository = applicationRepository;
            _teacherConfirmationService = teacherConfirmationService;
            _applicationModelMapper = new ApplicationModelMapper(_teacherService, _courseService);
        }

        public ApplicationModel CreateApplicationModel(ApplicationViewModel app, UserModel user)
        {
            var appModel = _applicationModelMapper.MapToModel(app, user);
            return appModel;
        }

        public ApplicationModel SaveApplication(ApplicationModel appModel)
        {
            //todo Todo mapping
            var app = _applicationRepository.Create(new Application());
            //todo appid isntead of '1'
            _teacherConfirmationService.CreateNewTeacherConfirmation(1, appModel);
            //todo Todo mapping from entity to model

            return appModel;
        }

        public ApplicationModel GetById(int id)
        {
            var app = _applicationRepository.GetApplicationById(id);
            //todo mapping
            return new ApplicationModel();
        }

        public ApplicationViewModel CreateApplicationViewModel(ApplicationModel appModel)
        {
            var appViewModel = _applicationModelMapper.MapToViewModel(appModel);
            return appViewModel;
        }
    }
}