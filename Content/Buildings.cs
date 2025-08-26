namespace WarBox.Content;

internal static class WarBoxBuildings
{
    public static void Init()
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
        metal_spawner.setShadow(0.86f, 0.23f, 0.28f);
        metal_spawner.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
        metal_spawner.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
        metal_spawner.has_sprites_spawn = true;
        metal_spawner.has_sprites_main = true;
        metal_spawner.has_sprites_ruin = true;
        metal_spawner.has_sprites_special = true;
        metal_spawner.sprite_path = "buildings/metal_spawner";
        //metal_spawner.
    }
}