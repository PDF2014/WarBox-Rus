using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace WarBox.Content;

internal static class WarBoxBuildings
{
    private static readonly string[] civs = { "human", "orc", "elf", "dwarf" };
    public static void Init()
    {
        AddBuildings();
        AddBuildingOrders();
        AddArchitectures();

        PreloadHelpers.preloadBuildingSprites();
    }

    private static void AddBuildings()
    {
        foreach (ActorAsset race in AssetManager.actor_library.list.Where(race => race.architecture_id != string.Empty && race.canBecomeSapient() == true)) // this does double work for actors that have both non-spaient and sapient
        {
            BuildingAsset watch_tower = AssetManager.buildings.get($"watch_tower_{race.architecture_id}");
            if (watch_tower != null)
            {
                watch_tower.can_be_upgraded = true;
                watch_tower.upgrade_level = 1;
                watch_tower.upgrade_to = "bunker";
            }
        }

        BuildingAsset bunker = AssetManager.buildings.clone("bunker", "$building_civ_human$");
        bunker.upgrade_level = 2;
        bunker.can_be_upgraded = false;
        bunker.has_sprite_construction = false;
        bunker.burnable = false;
        bunker.has_sprites_main_disabled = false;
        bunker.has_sprites_main = true;
        bunker.has_sprites_ruin = true;
        bunker.draw_light_area = true;
        bunker.draw_light_size = 1f;
        bunker.build_road_to = false;
        bunker.base_stats["health"] = 10000f;
        bunker.base_stats["targets"] = 1f;
        bunker.base_stats["area_of_effect"] = 1f;
        bunker.base_stats["damage"] = 20f;
        bunker.base_stats["knockback"] = 1f;
        bunker.smoke = true;
        bunker.smoke_interval = 2.5f;
        bunker.smoke_offset = new Vector2Int(2, 3);
        bunker.priority = 100;
        bunker.type = "type_watch_tower";
        bunker.fundament = new BuildingFundament(1, 1, 1, 0);
        bunker.cost = new ConstructionCost(0, 10, 5, 5);
        bunker.tower = true;
        bunker.sprite_path = "buildings/bunker";
        bunker.tower_projectile = "shotgun_bullet";
        bunker.tower_projectile_offset = 2f;
        bunker.tower_projectile_amount = 1;
        bunker.tower_projectile_reload = 0f;
        bunker.build_place_borders = true;
        bunker.build_place_batch = false;
        bunker.build_place_single = true;
        bunker.setShadow(0.5f, 0.23f, 0.27f);
        bunker.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleWatchTower";
        bunker.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
        bunker.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
        bunker.has_sprites_special = false;
        bunker.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");

        BuildingAsset artillery_bunker = AssetManager.buildings.clone("artillery_bunker", "bunker");
        artillery_bunker.sprite_path = "buildings/artillery_bunker";
        artillery_bunker.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        artillery_bunker.priority = 50;
        artillery_bunker.cost = new ConstructionCost(0, 12, 8, 5);
        artillery_bunker.base_stats["damage"] = 1000f;
        artillery_bunker.tower_projectile = "cannon_shell";
        artillery_bunker.tower_projectile_offset = 4f;
        artillery_bunker.tower_projectile_reload = 5f;
        artillery_bunker.setShadow(0.5f, 0.23f, 0.27f);
        artillery_bunker.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleWatchTower";
        artillery_bunker.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
        artillery_bunker.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
        artillery_bunker.max_houses = 1;

        BuildingAsset tank_factory = AssetManager.buildings.clone("tank_factory", "$building_civ_human$");
        tank_factory.can_be_upgraded = false;
        tank_factory.has_sprite_construction = false;
        tank_factory.burnable = false;
        tank_factory.has_sprites_main_disabled = false;
        tank_factory.has_sprites_main = true;
        //tank_factory.has_sprites_ruin = true;
        tank_factory.draw_light_area = true;
        tank_factory.draw_light_size = 1f;
        tank_factory.build_road_to = true;
        tank_factory.base_stats["health"] = 2000f;
        tank_factory.smoke = true;
        tank_factory.smoke_interval = 2.5f;
        tank_factory.smoke_offset = new Vector2Int(2, 3);
        tank_factory.priority = 9999;
        tank_factory.type = "type_tankfactory";
        tank_factory.fundament = new BuildingFundament(2, 2, 1, 1);
        tank_factory.cost = new ConstructionCost(0, 10, 7, 5);
        tank_factory.tower = false;
        tank_factory.sprite_path = "buildings/tank_factory";
        tank_factory.build_place_borders = true;
        tank_factory.build_place_batch = false;
        tank_factory.build_place_single = true;
        tank_factory.setShadow(0.7f, 0.32f, 0.38f);
        tank_factory.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleTownHall";
        tank_factory.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
        tank_factory.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
        tank_factory.has_sprites_special = false;
        tank_factory.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        tank_factory.max_houses = 1;
    }

    private static void AddBuildingOrders()
    {
        foreach (CityBuildOrderAsset civ in AssetManager.city_build_orders.list)
        {
            BuildOrder order;

            civ.addUpgrade("order_watch_tower");
            order = civ.list.Last();
            order.requirements_orders = AssetLibrary<CityBuildOrderAsset>.a<string>("order_bonfire");

            civ.addBuilding("order_artillery_bunker", 1);
            order = civ.list.Last();
            order.requirements_orders = AssetLibrary<CityBuildOrderAsset>.a<string>("order_bonfire", "order_watch_tower");

            civ.addBuilding("order_tank_factory", 1);
            order = civ.list.Last();
            order.requirements_orders = AssetLibrary<CityBuildOrderAsset>.a<string>("order_hall_0");
        }
    }

    private static void AddArchitectures()
    {
        var customOrders = new Dictionary<string, string>
        {
            {"order_artillery_bunker", "artillery_bunker"},
            {"order_tank_factory", "tank_factory"}

        };

        foreach (var arch in AssetManager.architecture_library.list)
        {
            if (arch.building_ids_for_construction == null)
                arch.building_ids_for_construction = new Dictionary<string, string>();
            foreach (var kvp in customOrders)
            {
                if (!arch.building_ids_for_construction.ContainsKey(kvp.Key))
                {
                    arch.building_ids_for_construction.Add(kvp.Key, kvp.Value);
                }
            }
        }
    }
}