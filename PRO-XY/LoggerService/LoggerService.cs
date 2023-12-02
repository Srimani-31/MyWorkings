using System;
using NLog;
namespace LoggerService
{
  public class LoggerService : ILoggerService
  {
    private readonly ILogger _logger;
    public LoggerService(ILogger logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void LogInfo(string message)
    {
      _logger.Info(message);
    }
    public void LogErrorInfo(string message, Exception ex)
    {
      _logger.Error(message);
      _logger.Error($"Message:{ex.Message}");
      _logger.Error($"StackTrace:{ex.StackTrace}");
      _logger.Error($"InnerException:{ex.InnerException}");
    }
    public void LogErrorMessage(string message)
    {
      _logger.Info(message);
    }
    //add other logs if needed
  }
}
