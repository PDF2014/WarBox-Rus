using System.Collections.Generic;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NeoModLoader.General.UI.Tab;
using UnityEngine;

namespace WarBox.UI;

internal static class WarBoxTab
{
    public const string CREATURES = "creatures";
    public static PowersTab tab;

    public static void init()
    {
        tab = TabManager.CreateTab("WarBox", "tab_WarBox", "tab_WarBox_desc", SpriteTextureLoader.getSprite("ui/icons/iconSteam"));

        tab.SetLayout(new List<string>()
        {
            CREATURES
        });

        addButtons();
        tab.UpdateLayout();
    }

    private static void addButtons()
    {
        tab.AddPowerButton(CREATURES,
            PowerButtonCreator.CreateGodPowerButton("WarBox_spawntank",
                SpriteTextureLoader.getSprite("ui/icons/iconSteam")));
    }
}