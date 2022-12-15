using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonTestTask.Layers.BLL.Extensions;
using AkvelonTestTask.Layers.BLL.Services;
using AkvelonTestTask.Layers.DAL.DbContexts;
using AkvelonTestTask.Layers.DAL.Repositories;
using AkvelonTestTask.MiddleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace AkvelonTestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddDbContext<ProjectDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("project_db")));

            // repositories
            // project
            services.AddScoped<ProjectRepository, ProjectRepository>();
            // task
            services.AddScoped<TaskRepository, TaskRepository>();

            // crud services
            // project
            services.AddScoped<ProjectsCrudService, ProjectsCrudService>();
            services.AddScoped<ProjectsSortingService, ProjectsSortingService>();
            services.AddScoped<ProjectsFilterService, ProjectsFilterService>();
            services.AddScoped<ProjectsPagingService, ProjectsPagingService>();
            services.AddScoped<ApplyProjectFiltersService, ApplyProjectFiltersService>();
            // task
            services.AddScoped<TasksCrudService, TasksCrudService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");

                    // Opens swagger UI as a default page.
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.AddGlobalErrorHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}