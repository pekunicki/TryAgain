﻿using Microsoft.Extensions.DependencyInjection;
using TryAgain.Models.Mappers;
using TryAgain.Persistance.Repository;
using TryAgain.Services;
using TryAgain.Services.Interfaces;

namespace TryAgain.DI
{
    internal class DependencyInjectionService
    {

        public void BindDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITeacherConfirmationService, TeacherConfirmationService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ApplicationRepository>();
            services.AddScoped<ITeacherConfirmationRepository, TeacherConfirmationRepository>();
            services.AddScoped<CourseRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<TeacherRepository>();

            services.AddScoped<ApplicationModelMapper>();
        }
    }
}