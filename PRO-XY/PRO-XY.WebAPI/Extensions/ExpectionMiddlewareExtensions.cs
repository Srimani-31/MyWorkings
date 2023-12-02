using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggerService;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PRO_XY.WebAPI.Models;
using Microsoft.Extensions.Logging;
using PRO_XY.WebAPI.Controllers;

namespace PRO_XY.WebAPI.Extensions
{
  public static class ExpectionMiddlewareExtensions
  {
    public static void ConfigureExceptionalHandler(this IApplicationBuilder app, ILoggerService loggerService)
    {
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
        {
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          context.Response.ContentType = "application/json";

          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          if(contextFeature != null)
          {
            loggerService.LogErrorMessage($"Something went wrong:{contextFeature.Error}");

            await context.Response.WriteAsync(new ErrorDetails
            {
              StatusCode = context.Response.StatusCode,
              Message = "Internal Server Error"
            }.ToString());
          }
        });
      });
    }
  }
}
