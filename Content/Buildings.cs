using System.Net.Mime;

namespace WarBox.Content;

internal static class WarBoxBuildings
{
    public static void Init()
    {
        AddBuildings();
    }

    private static void AddBuildings()
    {
        BuildingAsset watch_tower = AssetManager.buildings.get("watch_tower_human");
        watch_tower.upgrade_level = 1;
        watch_tower.can_be_upgraded = true;
        watch_tower.upgrade_to = "bunker";

        BuildingAsset bunker = AssetManager.buildings.clone("bunker", "watch_tower_human");
        bunker.sprite_path = "buildings/bunker";
        bunker.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        bunker.tower_projectile_reload = 0.025f;
        bunker.base_stats["health"] = 10000f;
        bunker.base_stats["attack_speed"] = 10f;
        bunker.base_stats["damage"] = 55f;
        bunker.base_stats["range"] = 50f;
        bunker.fundament = new BuildingFundament(1, 1, 0, 0);
        bunker.cost = new ConstructionCost(0, 0, 0, 0);
        bunker.priority = 9999;
        bunker.can_be_upgraded = false;
        bunker.upgrade_level = 2;
        bunker.upgraded_from = "watch_tower_human";
        bunker.tower_projectile = "shotgun_bullet";
        bunker.tower_projectile_amount = 1;
        bunker.burnable = false;
        bunker.build_road_to = false;
        bunker.tower_projectile_offset = 0.2f;
    }
}