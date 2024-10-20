using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Configuration;
using HarmonyLib;

namespace LevelEditor;

[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
public partial class LevelEditor : BasePlugin
{
    public Harmony Harmony { get; } = new(Id);
    public static ConfigEntry<string> editLevel;

    public override void Load()
    {
        editLevel = Config.Bind("LevelEditor",
                                "Level",
                                "",
                                "levels can only be within 0 and 4294967295. Decimal numbers will not work.");

        Harmony.PatchAll();
    }
}
