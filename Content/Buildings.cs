using System.Net.Mime;

namespace WarBox.Content;

internal static class WarBoxBuildings
{
    public static void Init()
    {
        AddSpawners();
    }

    private static void AddSpawners()
    {
        BuildingAsset metal_spawner = AssetManager.buildings.clone("metal_spawner", "$building$");
        metal_spawner.building_type = BuildingType.Building_Nature;
        metal_spawner.draw_light_area = true;
        metal_spawner.ignored_by_cities = false;
        metal_spawner.draw_light_size = 1f;
        metal_spawner.base_stats["health"] = 50000f;
        metal_spawner.fundament = new BuildingFundament(1, 1, 1, 0);
        metal_spawner.group = "nature";
        metal_spawner.kingdom = "nature";
        metal_spawner.can_be_placed_on_liquid = false;
        metal_spawner.ignore_buildings = true;
        metal_spawner.check_for_close_building = false;
        metal_spawner.can_be_living_house = true;
        metal_spawner.burnable = false;
        metal_spawner.setShadow(0.28f, 0.86f, 0f);
        metal_spawner.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
        metal_spawner.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
        metal_spawner.has_sprites_spawn = true;
        metal_spawner.has_sprites_main = true;
        metal_spawner.has_sprites_ruin = true;
        metal_spawner.has_sprites_special = false;
        metal_spawner.has_sprites_main_disabled = false;
        metal_spawner.sprite_path = "buildings/metal_spawner";
        metal_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        metal_spawner.spawn_drops = true;
        metal_spawner.spawn_drop_id = "metals";
        metal_spawner.spawn_drop_interval = 1f;
        metal_spawner.spawn_drop_min_height = 10f;
        metal_spawner.spawn_drop_min_radius = 1f;
        metal_spawner.spawn_drop_max_radius = 12.5f;
        metal_spawner.spawn_drop_max_height = 20f;
        metal_spawner.spawn_drop_start_height = 10f;

        BuildingAsset gold_spawner = AssetManager.buildings.clone("gold_spawner", metal_spawner.id);
        gold_spawner.sprite_path = "buildings/gold_spawner";
        gold_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        gold_spawner.spawn_drop_id = "gold";
        gold_spawner.spawn_drop_max_radius = 8.5f;

        BuildingAsset watch_tower = AssetManager.buildings.get("watch_tower_human");
        watch_tower.upgrade_level = 0;
        watch_tower.can_be_upgraded = true;
        watch_tower.upgrade_to = "bunker";

        BuildingAsset bunker = AssetManager.buildings.clone("bunker", "watch_tower_human");
        bunker.sprite_path = "buildings/bunker";
        bunker.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        bunker.tower_projectile_reload = 0.025f;
        bunker.base_stats["health"] = 9000f;
        bunker.base_stats["attack_speed"] = 10f;
        bunker.base_stats["damage"] = 55f;
        bunker.fundament = new BuildingFundament(1, 1, 0, 0);
        bunker.cost = new ConstructionCost(0, 30, 15, 10);
        bunker.upgrade_level = 1;
        bunker.tower_projectile = "shotgun_bullet";
        bunker.tower_projectile_amount = 1;
        bunker.tower_projectile_offset = 0;
        AssetManager.buildings.add(bunker);
    }
}