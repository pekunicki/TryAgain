using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TryAgain.DI;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TryAgain.Persistance;

namespace TryAgain
{
    public class Startup
    {
        private readonly DependencyInjectionService _dependencyInjectionService;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _dependencyInjectionService = new DependencyInjectionService();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddFluentValidation(fvc => 
                        fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            var connectionString = Configuration.GetConnectionString("TryAgain");
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

            services.AddAutoMapper();

            _dependencyInjectionService.BindDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
