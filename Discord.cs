
namespace discord_steamvr_sync;

public class Discord()
{
  private static string GetDiscordPath()
  {
    return Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + @"\Programs\Discord Inc\Discord.lnk";
  }

  public static void EnsureRunning()
  {
    if (ProcessUtil.IsRunning("Discord")) return;
    if (ProcessUtil.IsRunning("Update")) return;

    Console.WriteLine("Discord not running, starting...");
    ProcessUtil.Start(GetDiscordPath());
  }

  public static void EnsureClosed()
  {
    if (ProcessUtil.IsRunning("Discord"))
    {
      Console.WriteLine("Discord is running, closing...");
      ProcessUtil.KillAll("Discord");
    }
  }
}