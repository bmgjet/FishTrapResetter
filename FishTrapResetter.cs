/*▄▄▄    ███▄ ▄███▓  ▄████  ▄▄▄██▀▀▀▓█████▄▄▄█████▓
▓█████▄ ▓██▒▀█▀ ██▒ ██▒ ▀█▒   ▒██   ▓█   ▀▓  ██▒ ▓▒
▒██▒ ▄██▓██    ▓██░▒██░▄▄▄░   ░██   ▒███  ▒ ▓██░ ▒░
▒██░█▀  ▒██    ▒██ ░▓█  ██▓▓██▄██▓  ▒▓█  ▄░ ▓██▓ ░ 
░▓█  ▀█▓▒██▒   ░██▒░▒▓███▀▒ ▓███▒   ░▒████▒ ▒██▒ ░ 
░▒▓███▀▒░ ▒░   ░  ░ ░▒   ▒  ▒▓▒▒░   ░░ ▒░ ░ ▒ ░░   
▒░▒   ░ ░  ░      ░  ░   ░  ▒ ░▒░    ░ ░  ░   ░    
 ░    ░ ░      ░   ░ ░   ░  ░ ░ ░      ░    ░      
 ░             ░         ░  ░   ░      ░  ░*/
using HarmonyLib;
using Oxide.Core.Plugins;
namespace Oxide.Plugins
{
    [Info("FishTrapResetter", "bmgjet", "1.0.0")]
    [Description("Resets fish traps on each catch.")]
    class FishTrapResetter : RustPlugin
    {
        [AutoPatch]
        [HarmonyPatch(typeof(WildlifeTrap), "OnTrappedWildlife", typeof(bool))]
        public static class WildlifeTrap_OnTrappedWildlife
        {
            [HarmonyPostfix]
            public static void Postfix(WildlifeTrap __instance)
            {
                __instance.Invoke(() =>
                {
                    __instance.SetTrapActive(__instance.HasBait());
                    __instance.ClearTrap();
                }, 5);
            }
        }
    }
}
