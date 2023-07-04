using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//my dependencies
using RiddleWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using RiddleWebAPI.Repository;
using RiddleWebAPI.Service;
using System.Reflection;
using AutoMapper;
using RiddleWebAPI.Mappings;
using RiddleWebAPI.Dtos;

namespace RiddleWebAPI
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
            //adding connection globally
            services.AddDbContext<MyRiddleDatabaseContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("MyRiddleDatabase"));
                options.EnableSensitiveDataLogging();
                    });
            //configuring the dependency injection
            services.AddTransient<IUserRepository, UserRepository>();//map the interface to their implementation
            services.AddTransient<MyRiddleDatabaseContext>();
            services.AddTransient<IUserService, UserService>();
            //automapper configuration
            var mappingConfig = new MapperConfiguration(
                 mc => mc.AddProfile(new UserProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RiddleWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RiddleWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
