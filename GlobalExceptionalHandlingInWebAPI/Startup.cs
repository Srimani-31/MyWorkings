using LoggerService;
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
using GlobalExceptionalHandlingInWebAPI.Extensions;
using NLog.Extensions.Logging;
using NLog;

namespace GlobalExceptionalHandlingInWebAPI
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
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlobalExceptionalHandlingInWebAPI", Version = "v1" });
      });
      ////configure dependency injection ILogger
      //DependencyInjection.ConfigureServices(services);
      ////configure dependency injection ILoggerService
      //services.AddTransient<ILoggerService,LoggerService.LoggerService>();

      LoggerService.LoggerFactory.ConfigureNLog();
      services.AddSingleton<NLog.ILogger>(provider => LogManager.GetCurrentClassLogger());
      services.AddTransient<ILoggerService, LoggerService.LoggerService>();
      services.AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        loggingBuilder.AddNLog(); // Add NLog as the logging provider
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerService loggerService)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalExceptionalHandlingInWebAPI v1"));
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
