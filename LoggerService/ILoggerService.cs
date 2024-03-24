using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
  public interface ILoggerService
  {
    public void LogInfo(string message);
    public void LogErrorInfo(string message, Exception ex);
    public void LogErrorMessage(string message);
  }
}
