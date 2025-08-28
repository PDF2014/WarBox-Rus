using System;
using System.Collections.Generic;
using NCMS.Utils;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NeoModLoader.General.UI.Tab;
using UnityEngine;
using UnityEngine.Events;
using WarBox.Content;
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
            SpriteTextureLoader.getSprite("ui/icons/iconSteam")//WarBoxUtils.FetchSingleSprite("ui/icon")[0]
        );

        tab.SetLayout(new List<string>()
        {
            "spawners"
        });

        CreateWindows();
        CreateButtons();
        tab.UpdateLayout();
        // Bigger TODO: do not use any builder
        // TODO: do not use tab builder
        // new TabBuilder()
        // .SetTabID("warbox_tab")
        // .SetName("WarBox")
        // .SetDescription("WarBox Tab")
        // .SetPosition(200)
        // .SetIcon("ui/icon")
        // .Build();

        // PowersTab tab = getPowersTab("warbox_tab");

        // PowerButton metal_spawner_button = PowerButtonCreator.CreateGodPowerButton(
        //     "metal_spawner",
        //     WarBoxUtils.FetchSingleSprite("ui/icons/items/icon_pistol")[0],
        //     tab.transform,
        //     new Vector2(14, 0)
        // );
        // PowerButton gold_spawner_button = PowerButtonCreator.CreateGodPowerButton(
        //     "gold_spawner",
        //     WarBoxUtils.FetchSingleSprite("ui/icons/items/icon_rifle")[0],
        //     tab.transform,
        //     new Vector2(14, 0)
        // );
    }

    private static void CreateWindows()
    {
        WarBoxAutoLayoutWindow.CreateWindow("warbox_auto_layout_window", "warbox_auto_layout_window_title");
    }

    private static void CreateButtons()
    {
        //tab.AddPowerButton

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "metal_spawner",
            SpriteTextureLoader.getSprite("ui/icons/items/icon_pistol")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "gold_spawner",
            SpriteTextureLoader.getSprite("ui/icons/items/icon_rifle")
        ));
    }

    // public static PowersTab getPowersTab(string id)
    // {
    //     GameObject gameObject = GameObjects.FindEvenInactive(id);
    //     return gameObject.GetComponent<PowersTab>();
    // }
}