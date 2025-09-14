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
            "builders",
            "spawners",
            "warriors"
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
        tab.AddPowerButton("builders", PowerButtonCreator.CreateGodPowerButton(
            "bunker_builder",
            SpriteTextureLoader.getSprite("ui/icons/buttons/bunker_spawner")
        ));

        tab.AddPowerButton("builders", PowerButtonCreator.CreateGodPowerButton(
            "artillery_bunker_builder",
            SpriteTextureLoader.getSprite("ui/icons/buttons/artillery_bunker_spawner")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "spawn_tank",
            SpriteTextureLoader.getSprite("ui/icons/buttons/spawn_tank")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "tank_factory_builder",
            SpriteTextureLoader.getSprite("ui/icons/buttons/tank_factory_spawner")
        ));

        CreateWarriorButton("pistol");
        CreateWarriorButton("smg");
        CreateWarriorButton("shotgunreplace");
        CreateWarriorButton("rifle");
        CreateWarriorButton("autorifle");
        CreateWarriorButton("sniperrifle");
        CreateWarriorButton("rpg");
    }

    private static void CreateWarriorButton(string equipment_id)
    {
        tab.AddPowerButton("warriors", PowerButtonCreator.CreateGodPowerButton(
            "spawn_warrior_" + equipment_id,
            SpriteTextureLoader.getSprite("ui/icons/items/icon_" + equipment_id)
        ));
    }
}