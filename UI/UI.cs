using System;
using System.Collections.Generic;
using NCMS.Utils;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NeoModLoader.General.UI.Tab;
using WarBox.UI.Windows;

namespace WarBox.UI;

internal static class WarBoxUI
{
    public static PowersTab tab;

    public static void Init()
    {
        tab = TabManager.CreateTab(
            "warbox_tab",
            "warbox_tab_name",
            "warbox_tab_description",
            SpriteTextureLoader.getSprite("ui/icons/warbox_tab_icon")
        );

        tab.SetLayout(new List<string>()
        {
            "spawners"
        });

        CreateWindows();
        CreateButtons();
        tab.UpdateLayout();
    }

    private static void CreateWindows()
    {
        WarBoxAutoLayoutWindow.CreateWindow("warbox_auto_layout_window", "warbox_auto_layout_window_title");
    }

    private static void CreateButtons()
    {
        // tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
        //     "metal_spawner",
        //     SpriteTextureLoader.getSprite("ui/icons/buttons/metal_spawner")
        // ));

        // tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
        //     "gold_spawner",
        //     SpriteTextureLoader.getSprite("ui/icons/buttons/gold_spawner")
        // ));
    }
}