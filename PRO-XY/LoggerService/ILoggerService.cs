using System;

namespace LoggerService
{
  public interface ILoggerService
  {
    public void LogInfo(string message);
    public void LogErrorInfo(string message, Exception ex);
    public void LogErrorMessage(string message);
  }
}
