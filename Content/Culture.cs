using System.Collections.Generic;
using UnityEngine;
using NeoModLoader.General;
using System.Linq;

namespace WarBox.Content;

internal static class WarBoxCulture
{
    public static void Init()
    {
        AddTechItems();
    }

    private static void AddTechItems()
    {
        CultureTrait firearms = new CultureTrait
        {
            id = "craft_firearms",
            group_id = "craft",
            path_icon = "ui/icons/culture/culture_trait_firearms.png",
            value = 10f,
            is_weapon_trait = true,
            priority = -2,
        };
        firearms.addWeaponSubtype("gun");
        AssetManager.culture_traits.add(firearms);
        EnableForAll(firearms.id);
    }

    private static void EnableForAll(string id)
    {
        foreach (ActorAsset race in AssetManager.actor_library.list.Where(race => race.canBecomeSapient() == true))
        {
            race.addCultureTrait(id);
        }
    }
}