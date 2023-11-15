using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace DisableMenuBattleCam
{
    [BepInPlugin("sonata.spaz2mods.disablemenucam", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static ConfigEntry<bool> modEnabled;
        static ManualLogSource logger;

        private void Awake()
        {
            logger = Logger;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            modEnabled = Config.Bind("General", "Enabled", true, "Is the mod enabled?");

            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(SpawnManager), nameof(SpawnManager.Update))]
        static bool Patch_DisableMenuCam()
        {
            if (!modEnabled.Value)
                return true;

            return false;
        }
    }
}
