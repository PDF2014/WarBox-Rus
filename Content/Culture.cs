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
        // CultureTechAsset tech_firearms = new CultureTechAsset
        // {
        //     id = "firearm_production",
        //     required_level = 30,
        //     path_icon = "tech/icon_tech_firearms.png",
        //     requirements = new List<string> { "weapon_production", "material_steel" }
        // };
        // LM.Add("en", "tech_firearm_production", "Firearm Production");
        // AssetManager.culture_tech.add(tech_firearms);
        CultureTrait firearms = new CultureTrait
        {
            id = "craft_firearms",
            group_id = "craft",
            path_icon = "ui/icons/culture/culture_trait_firearms.png",
            value = 10f,
            is_weapon_trait = true,
            priority = -2,
        };
        firearms.addWeaponSpecial("rifle");
        firearms.addWeaponSpecial("pistol");
        firearms.addWeaponSpecial("smg");
        firearms.addWeaponSpecial("autorifle");
        firearms.addWeaponSpecial("sniperrifle");
        firearms.addWeaponSpecial("rpg");
        firearms.addWeaponSpecial("shotgunreplace");
        AssetManager.culture_traits.add(firearms);
        LM.Add("en", "culture_trait_craft_firearms", "Firearms");
        LM.Add("en", "culture_trait_craft_firearms_info", "Allows for the production of guns.");
        LM.Add("en", "culture_trait_craft_firearms_info2", "These pointy boom sticks sure hit hard");

        foreach (ActorAsset race in AssetManager.actor_library.list.Where(race => race.canBecomeSapient() == true))
        {
            //race.preferred_weapons.Add("easternarmor_thriller");
            race.addCultureTrait(firearms.id);
        }


        // ActorAsset human = AssetManager.actor_library.get("human");
        // human.addCultureTrait("craft_firearms");

        // ActorAsset orc = AssetManager.actor_library.get("orc");
        // orc.addCultureTrait("craft_firearms");

        // ActorAsset elf = AssetManager.actor_library.get("elf");
        // elf.addCultureTrait("craft_firearms");

        // ActorAsset dwarf = AssetManager.actor_library.get("dwarf");
        // dwarf.addCultureTrait("craft_firearms");

    }
}