using System.Diagnostics;

namespace discord_steamvr_sync;

public class ProcessUtil
{

  public static bool IsRunning(string processName)
  {
    return Process.GetProcessesByName(processName).Length > 0;
  }

  public static void KillAll(string processName)
  {
    foreach (var process in Process.GetProcessesByName(processName))
    {
      process.Kill();
    }
  }


  public static void Start(string exePath)
  {
    Process.Start(exePath);
  }
  public static void Start(string exePath, string args)
  {
    Process.Start(exePath, args);
  }
}