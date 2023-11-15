using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace No_Retreat
{
    [BepInPlugin("sonata.spaz2mods.no_retreat", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
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
        [HarmonyPatch(typeof(NetSlicedAIBrain), nameof(NetSlicedAIBrain.UpdateRetreat))]
        static bool Patch_NoRetreat(ref bool ___shouldRetreat)
        {
            if (!modEnabled.Value)
                return true;

            ___shouldRetreat = false;

            return false;
        }
    }
}
