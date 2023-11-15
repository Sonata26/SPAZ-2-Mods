using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace CatalogPerk
{
    [BepInPlugin("sonata.spaz2mods.catalogperk", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
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
        [HarmonyPatch(typeof(StarmapCatalog), nameof(StarmapCatalog.GetConstructedPriceMult))]
        static bool Patch_CatalogPerkPatch(ref StarmapCatalog __instance, ref float __result)
        {
            if (!modEnabled.Value)
                return true;

            float perkValue = __instance.GetTraderEntity().GetPerkValue(PerkClass.Trading);
            __result = (float)GameManager.Tuning().GetTunableInt(ST_Tunable.CustomPartPriceMult) * (1.5f - perkValue);

            return false;
        }
    }
}
