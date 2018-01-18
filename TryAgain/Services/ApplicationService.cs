using AutoMapper;
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
        private readonly IUserService _userService;


        public ApplicationService(
            ITeacherService teacherService, 
            ICourseService courseService, 
            ApplicationRepository applicationRepository,
            ITeacherConfirmationService teacherConfirmationService, IUserService userService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
            _applicationRepository = applicationRepository;
            _teacherConfirmationService = teacherConfirmationService;
            _userService = userService;
            _applicationModelMapper = new ApplicationModelMapper(_teacherService, _courseService);
        }

        public ApplicationModel CreateApplicationModel(ApplicationViewModel app, UserModel user)
        {
            var appModel = _applicationModelMapper.MapToModel(app, user);
            return appModel;
        }

        public void SaveApplication(ApplicationModel appModel)
        {
            var app = MapToApplication(appModel);
            app = _applicationRepository.Create(app);
            _teacherConfirmationService.CreateNewTeacherConfirmation(appModel.Teacher.Id, app.Id);
        }

        private static Application MapToApplication(ApplicationModel appModel)
        {
            var app = Mapper.Map<Application>(appModel);
            return app;
        }

        private static ApplicationModel MapToApplicationModel(
            Application app, 
            TeacherModel teacher, 
            CourseModel course, 
            UserModel organizer)
        {
            var appModel = Mapper.Map<ApplicationModel>(app);
            appModel.Teacher = teacher;
            appModel.Course = course;
            appModel.Organizer = organizer;

            return appModel;
        }

        public ApplicationModel GetById(int id)
        {
            //todo bind to one query
            var app = _applicationRepository.GetApplicationById(id);
            var course = _courseService.GetCourseById(app.CourseId);
            var confirmationTeacher = _teacherConfirmationService.TryGetTeacherConfirmationByAppId(app.Id);
            var teacher = _teacherService.GetTeacherById(confirmationTeacher.TeacherId);
            var organizer = _userService.GetUserById(app.OrganizerId);

            var appModel = MapToApplicationModel(app, teacher, course, organizer);
            return appModel;
        }

        public ApplicationViewModel CreateApplicationViewModel(ApplicationModel appModel)
        {
            var appViewModel = _applicationModelMapper.MapToViewModel(appModel);
            return appViewModel;
        }
    }
}