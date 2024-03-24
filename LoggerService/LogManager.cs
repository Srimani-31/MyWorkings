using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LoggerService
{
  public static class LoggerFactory
  {
    public static void ConfigureNLog()
    {
      string filePath = Path.Combine(Directory.GetCurrentDirectory().Replace("\\bin\\Debug", string.Empty), "nlog.config");
      // Load NLog configuration from the file
      LogManager.LoadConfiguration(filePath);
    }
  }

}
