using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using PRO_XY.WebAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Entities;
using PRO_XY.WebAPI.Repositories.Interfaces;
using PRO_XY.WebAPI.Repositories;
using PRO_XY.WebAPI.Data;
using PRO_XY.WebAPI.Data.Interfaces;

namespace PRO_XY.WebAPI
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
      #region Connection Config
      //adding connection globally
      services.AddDbContext<PRO_XYContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("PRO_XY_DB"));
        options.EnableSensitiveDataLogging();
      }); 
      #endregion
      #region Logger Config
      // Enable NLog as the logging provider for ASP.NET Core
      LoggerService.LoggerFactory.ConfigureNLog();
      services.AddSingleton<NLog.ILogger>(provider => LogManager.GetCurrentClassLogger());
      services.AddTransient<ILoggerService, LoggerService.LoggerService>();
      services.AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        loggingBuilder.AddNLog(); // Add NLog as the logging provider
      });
      #endregion

      services.AddScoped<IProXYDbContext, PRO_XYContext>();
      services.AddScoped<IHelper, Helper>();

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRO_XY.WebAPI", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerService loggerService)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRO_XY.WebAPI v1"));
      }

      //configuring the built-in exceptional hanlder
      app.ConfigureExceptionalHandler(loggerService);

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
