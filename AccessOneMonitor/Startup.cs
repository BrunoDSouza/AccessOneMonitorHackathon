using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessOneMonitor.Api.Services;
using AccessOneMonitor.Data.Configuration;
using AccessOneMonitor.Data.Repositories;
using AccessOneMonitor.Data.Repositories.Interfaces;
using AccessOneMonitor.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccessOneMonitor
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
            services.AddDbContext<DbContextConfiguration>(options => {
                options.UseSqlServer(Configuration["DefaultConnection:ConnectionString"]);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>

            options.AddPolicy("_myAllowSpecificOrigins",
            builder =>
            {
                builder.WithOrigins("*");
            }));

            #region Repositories Dependecies Injection

            services.AddScoped<IComputerRepository, ComputerRepository>();
            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IExecutionRepository, ExecutionRepository>();
            services.AddScoped<IMonitorService, MonitorService>();
            services.AddScoped<ICommandRepository, CommandRepository>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("_myAllowSpecificOrigins");
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });

            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DbContextConfiguration>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
