# SPAZ 2 Mods
Mods for the game "Space Pirates and Zombies 2"

### To Install
1. Download the BepInEx Loader for SPAZ 2 and the mod files from the **[Latest releases](https://github.com/Sonata26/SPAZ-2-Mods/releases)**
2. Extract the BepInEx loader into your game folder `\Steam\steamapps\common\SPAZ2`
3. Launch the game once to generate the config for BepInEx and verify it works (you will see a console appear).
4. Extract the mods you want into `SPAZ2\BepInEx\plugins`
5. You can put the "all-mods" folder in there or only the plugin folders you want.


### To Configure Mods
1. Download the [Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager/releases) mod and extract it into the game folder so that you have `SPAZ2\BepInEx\plugins\ConfigurationManager.dll`.
2. Press F1 in-game to configure mods, but don't use this during a battle as the game will lock you in the menu. Make sure to enable the main menu fix mod to use it safely in the main menu. Using it on the Starmap is fine.
3. Mods can be enabled or disabled during the game, more settings might be added in the future.


### Disable BepInEx Console
* Optionally, you can disable the console after verifying everything works. Edit `BepInEx\config\BepInEx.cfg` find the option for `[Logging.Console]` set `Enabled = false`.
* Alternatively, you can use the Configuration Manager (F1 after installing with the above instructions), check the advance checkbox, and under BepInEx settings uncheck enabled for `Logging.Console` setting.
