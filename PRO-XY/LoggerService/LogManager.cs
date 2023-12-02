using NLog;
using System.IO;

namespace LoggerService
{
  public static class LoggerFactory
  {
    [System.Obsolete]
    public static void ConfigureNLog()
    {
      string filePath = Path.Combine(Directory.GetCurrentDirectory().Replace("\\bin\\Debug", string.Empty), "nlog.config");
      // Load NLog configuration from the file
      LogManager.LoadConfiguration(filePath);
    }
  }

}
