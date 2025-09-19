namespace WarBox.Content;

internal static class WarBoxActions
{
    public static void ToggleFactories(bool pCurrentValue)
    {
        WarBox.warbox_factories = pCurrentValue;
        WarBox.LogInfo("Factories toggled to " + pCurrentValue);
    }

    public static void ToggleArmyLimit(bool pCurrentValue)
    {
        WarBox.warbox_army_limits = pCurrentValue;
        WarBox.LogInfo("Army Limits toggled to " + pCurrentValue);
    }

    public static bool LaunchATGM(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
    {
        WarBox.LogInfo(pSelf.name);
        WarBox.LogInfo(pTarget.name);
        WarBox.LogInfo(pTile.pos.x.ToString() + ", " + pTile.pos.y.ToString());
        return true;
    }
}