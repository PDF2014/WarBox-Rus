using NCMS.Utils;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.Events;
using WarBox.Content;

namespace WarBox.UI;

internal static class WarBoxUI
{
    public static void Init()
    {
        // Bigger TODO: do not use any builder
        // TODO: do not use tab builder
        new TabBuilder()
        .SetTabID("warbox_tab")
        .SetName("WarBox")
        .SetDescription("WarBox Tab")
        .SetPosition(200)
        .SetIcon("ui/icon")
        .Build();

        PowersTab tab = getPowersTab("warbox_tab");

        PowerButton metal_spawner_button = PowerButtonCreator.CreateGodPowerButton(
            "metal_spawner",
            WarBoxUtils.FetchSingleSprite("ui/icons/items/icon_pistol")[0],
            tab.transform,
            new Vector2(14, 0)
        );
        PowerButton gold_spawner_button = PowerButtonCreator.CreateGodPowerButton(
            "gold_spawner",
            WarBoxUtils.FetchSingleSprite("ui/icons/items/icon_rifle")[0],
            tab.transform,
            new Vector2(14, 0)
        );
    }

    public static PowersTab getPowersTab(string id)
    {
        GameObject gameObject = GameObjects.FindEvenInactive(id);
        return gameObject.GetComponent<PowersTab>();
    }
}