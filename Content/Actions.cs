namespace WarBox.Content;

internal static class WarBoxActions
{
    public static void ToggleFactories(bool pCurrentValue)
    {
        WarBox.warbox_factories = pCurrentValue;
        WarBox.LogInfo("Factories toggled to " + pCurrentValue);
    }
}