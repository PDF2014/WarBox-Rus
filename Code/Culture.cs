using System.Collections.Generic;
using NeoModLoader.General;

namespace ErexMod.Content;

internal static class ErexModCulture
{
    public static void init()
    {
        add_tech_items();
    }

    private static void add_tech_items()
    {
        CultureTechAsset tech_firearms = new CultureTechAsset
        {
            id = "firearm_production",
            required_level = 30,
            path_icon = "tech/icon_tech_firearms.png",
            requirements = new List<string> { "weapon_production", "material_steel" }
        };
        LM.Add("en", "tech_firearm_production", "Firearm Production");
        AssetManager.culture_tech.add(tech_firearms);
    }
}