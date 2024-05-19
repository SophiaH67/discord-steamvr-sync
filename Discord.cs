
namespace discord_steamvr_sync;

public class Discord()
{
  private static string GetDiscordPath()
  {
    string discordAppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Discord\\";
    // Grab the last subfolder that starts with "app-" (discord does not always delete old folders)
    var appFolders = Directory.GetDirectories(discordAppdataFolder).Where(x => x.Split('\\').Last().StartsWith("app-"));
    if (appFolders.Count() == 0)
    {
      throw new Exception("No Discord app folder found");
    }
    return appFolders.Last() + "\\Discord.exe";
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