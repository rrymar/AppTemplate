using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Core.Web.DependencyInjection;
using Core.Web.Errors;
using Microsoft.EntityFrameworkCore;
using Users;
using App.Database;
using Core.Authentication;

namespace App.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureMigrationServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(o => o.UseSqlServer("Server=.;Database=dummy"));
            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();


            var mvcBuilder = services.AddControllers();

            services.RegisterModule<CoreAuthenticationModule>();
            services.RegisterTopLevelModule<UsersModule>(mvcBuilder, Configuration);

            var apiInfo = new OpenApiInfo { Title = "App", Version = "v1" };
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", apiInfo));

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App API V1"));

            if (!env.IsDevelopment())
                app.UseHsts();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                    spa.UseAngularCliServer(npmScript: "start");
            });
        }
    }
}
