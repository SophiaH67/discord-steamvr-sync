namespace discord_steamvr_sync;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Starting monitoring...");
    while (true)
    {
      EnsureSynced();
      Thread.Sleep(10_000);
    }
  }

  private static void EnsureSynced()
  {
    if (SteamVR.IsRunning())
    {
      Discord.EnsureRunning();
    }
    else
    {
      Discord.EnsureClosed();
    }
  }
}