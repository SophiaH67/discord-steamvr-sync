
namespace discord_steamvr_sync;

public class SteamVR()
{
  public static bool IsRunning()
  {
    return ProcessUtil.IsRunning("vrserver");
  }
}