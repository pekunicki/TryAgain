using System;
using TryAgain.Models.Constants;
using TryAgain.Models.ViewModels;
using TryAgain.Services.Interfaces;
using TryAgain.Utils.Extensions;

namespace TryAgain.Models.Mappers
{
    public class ApplicationModelMapper
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public ApplicationModelMapper(ITeacherService teacherService, ICourseService courseService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
        }

        public ApplicationModel MapToModel(ApplicationViewModel appViewModel, UserModel organizerModel)
        {
            return new ApplicationModel
            {
                State = ApplicationState.Utworzony,
                Classroom = appViewModel.Classroom,
                Day = appViewModel.Date.Day,
                Week = appViewModel.Date.Week,
                Course = new CourseModel
                {
                    CourseName = appViewModel.Course.CourseName,
                    Ects = appViewModel.Course.Ects,
                    Type = appViewModel.Type,
                    Id = GetCourseId(appViewModel.Course.CourseName)
                },
                Teacher = GetTeacher(appViewModel.ProposedTeacherFullName),
                Organizer = organizerModel,
                StartTime = GetTimeSpan(appViewModel.Date.StartTime),
                EndTime = GetTimeSpan(appViewModel.Date.EndTime)
            };
        }

        private static TimeSpan GetTimeSpan(string time)
        {
            try
            {
                return time.TryParseToTimeSpan().Value;
            }
            catch (InvalidOperationException exception)
            {
                throw new ArgumentException("Wartość godziny rozpoczęcia lub godzin zakończenia jest niepoprawna.", exception);
            }
        }

        private  int GetCourseId(string courseName)
        {
            var course = _courseService.GetCourseByCourseName(courseName);
            return course.Id;
        }

        private TeacherModel GetTeacher(string fullname)
        {
            return _teacherService.GetTeacherByTeacherFullName(fullname);
        }
    }
}