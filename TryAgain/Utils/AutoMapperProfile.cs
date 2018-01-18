using AutoMapper;
using TryAgain.Models;
using TryAgain.Persistance.Entity;

namespace TryAgain.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationModel, Application>()
                .ForMember(dest => dest.OrganizerId, opt => opt.MapFrom(src => src.Organizer.Id))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course.Id))
                .ForMember(dest => dest.ApplicationType, opt => opt.MapFrom( src => "KursPoprawkowy"))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Application, ApplicationModel>();

            CreateMap<CourseModel, Course>();
            CreateMap<Course, CourseModel>();

            CreateMap<TeacherModel, Teacher>();
            CreateMap<Teacher, TeacherModel>();

            CreateMap<TeacherConfirmationModel, TeacherConfirmation>();
            CreateMap<TeacherConfirmation, TeacherConfirmationModel>();

            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
        }
    }
}