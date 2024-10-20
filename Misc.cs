using AmongUs.Data;
using HarmonyLib;

namespace LevelEditor;
public static class Misc
{
    public static uint parsedLevel;

    public static void editLevel()
    {
        if (!string.IsNullOrEmpty(LevelEditor.editLevel.Value) && 
            uint.TryParse(LevelEditor.editLevel.Value, out parsedLevel) &&
            parsedLevel != DataManager.Player.Stats.Level)
        {
            DataManager.Player.stats.level = parsedLevel - 1;
            DataManager.Player.Save();
        }
    }
}

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.Update))]
public static class AmongUsClient_Update
{
    public static void Postfix()
    {
        Misc.editLevel();
    }
}