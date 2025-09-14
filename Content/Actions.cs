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
}