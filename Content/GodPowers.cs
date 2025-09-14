using System.Reflection;
using NeoModLoader.api;
using NeoModLoader.api.features;
using ReflectionUtility;

namespace WarBox.Content;

internal static class WarBoxGodPowers
{
    public static void Init()
    {
        AddDrops();
        AddPowers();
        Cache();
    }

    private static void AddDrops()
    {
        DropAsset bunker_drop = new DropAsset
        {
            id = "spawn_bunker",
            path_texture = "drops/drop_stone",
            default_scale = 0.2f,
            random_frame = true,
            random_flip = true,
            type = DropType.DropBuilding,
            building_asset = "bunker",
            action_landed = DropsLibrary.action_spawn_building
        };
        AssetManager.drops.add(bunker_drop);

        DropAsset artillery_bunker_drop = new DropAsset
        {
            id = "spawn_artillery_bunker",
            path_texture = "drops/drop_stone",
            default_scale = 0.2f,
            random_frame = true,
            random_flip = true,
            type = DropType.DropBuilding,
            building_asset = "artillery_bunker",
            action_landed = DropsLibrary.action_spawn_building
        };
        AssetManager.drops.add(artillery_bunker_drop);

        DropAsset tank_factory_drop = new DropAsset
        {
            id = "spawn_tank_factory",
            path_texture = "drops/drop_stone",
            default_scale = 0.2f,
            random_frame = true,
            random_flip = true,
            type = DropType.DropBuilding,
            building_asset = "tank_factory",
            action_landed = DropsLibrary.action_spawn_building
        };
        AssetManager.drops.add(tank_factory_drop);
    }

    private static void AddPowers()
    {
        GodPower bunker_builder = AssetManager.powers.clone("bunker_builder", "$template_drop_building$");
        bunker_builder.name = "Bunker";
        bunker_builder.rank = PowerRank.Rank0_free;
        bunker_builder.drop_id = "spawn_bunker";
        bunker_builder.falling_chance = 0f;
        bunker_builder.force_brush = "circ_0";
        bunker_builder.click_power_action = StuffDrop;
        bunker_builder.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });

        GodPower artillery_bunker_builder = AssetManager.powers.clone("artillery_bunker_builder", "$template_drop_building$");
        artillery_bunker_builder.name = "Artillery Bunker";
        artillery_bunker_builder.rank = PowerRank.Rank0_free;
        artillery_bunker_builder.drop_id = "spawn_artillery_bunker";
        artillery_bunker_builder.falling_chance = 0f;
        artillery_bunker_builder.force_brush = "circ_0";
        artillery_bunker_builder.click_power_action = StuffDrop;
        artillery_bunker_builder.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });

        GodPower tank_factory_builder = AssetManager.powers.clone("tank_factory_builder", "$template_drop_building$");
        tank_factory_builder.name = "Tank Factory";
        tank_factory_builder.rank = PowerRank.Rank0_free;
        tank_factory_builder.drop_id = "spawn_tank_factory";
        tank_factory_builder.falling_chance = 0f;
        tank_factory_builder.force_brush = "circ_0";
        tank_factory_builder.click_power_action = StuffDrop;
        tank_factory_builder.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });

        GodPower spawn_tank = AssetManager.powers.clone("spawn_tank", "$template_spawn_actor$");
        spawn_tank.name = "spawn_tank";
        spawn_tank.actor_asset_id = "warbox_tank";
        spawn_tank.click_action = new PowerActionWithID(SpawnVehicle);

        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_pistol", "pistol"));
        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_smg", "smg"));
        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_shotgunreplace", "shotgunreplace"));
        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_rifle", "rifle"));
        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_autorifle", "autorifle"));
        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_sniperrifle", "sniperrifle"));
        AssetManager.powers.add(CreateWarriorPower("spawn_warrior_rpg", "rpg"));
    }

    private static void Cache()
    {
        FieldInfo dropField = typeof(GodPower).GetField("cached_drop_asset", BindingFlags.NonPublic | BindingFlags.Instance);
        if (dropField != null)
        {
            dropField.SetValue(AssetManager.powers.get("bunker_builder"), AssetManager.drops.get("spawn_bunker"));
            dropField.SetValue(AssetManager.powers.get("artillery_bunker_builder"), AssetManager.drops.get("spawn_artillery_bunker"));
            dropField.SetValue(AssetManager.powers.get("tank_factory_builder"), AssetManager.drops.get("spawn_tank_factory"));
        }
    }

    private static bool StuffDrop(WorldTile pTile, GodPower pPower)
    {
        AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
        return true;
    }

    private static bool SpawnVehicle(WorldTile pTile, string pPowerID)
    {
        City city = pTile.zone.city;
        if (pTile.zone.city == null)
        {
            WorldTip.showNow("cant_spawn_vehicle_kingdom", true, "top", 3f);
            return false;
        }

        Kingdom kingdom = city.kingdom;
        if (kingdom == null)
        {
            WorldTip.showNow("cant_spawn_vehicle_kingdom", true, "top", 3f);
            return false;
        }

        GodPower power = AssetManager.powers.get(pPowerID);
        if (power == null) return false;

        MusicBox.playSound("event:/SFX/UNIQUE/SpawnWhoosh", (float)pTile.pos.x, (float)pTile.pos.y, false, false);
        EffectsLibrary.spawn("fx_spawn", pTile, null, null, 0f, -1f, -1f);

        Actor unit = World.world.units.createNewUnit(
               power.actor_asset_id,
               pTile,
               pMiracleSpawn: false,
               0f,
               null,
               null,
               pSpawnWithItems: false
        );
        unit.makeWait(1f);
        unit.setKingdom(kingdom);
        unit.setCity(city);

        //AssetManager.powers.CallMethod("spawnActor", pTile, pPower);
        return true;
    }

    private static bool SpawnWarrior(WorldTile pTile, string item)
    {
        City city = pTile.zone.city;
        if (pTile.zone.city == null)
        {
            WorldTip.showNow("cant_spawn_vehicle_kingdom", true, "top", 3f);
            return false;
        }

        Kingdom kingdom = city.kingdom;
        if (kingdom == null)
        {
            WorldTip.showNow("cant_spawn_vehicle_kingdom", true, "top", 3f);
            return false;
        }

        MusicBox.playSound("event:/SFX/UNIQUE/SpawnWhoosh", (float)pTile.pos.x, (float)pTile.pos.y, false, false);
        EffectsLibrary.spawn("fx_spawn", pTile, null, null, 0f, -1f, -1f);

        Subspecies subspecies = city.getMainSubspecies();
        Actor unit = World.world.units.createNewUnit(
            subspecies.getActorAsset().id,
            pTile,
            pMiracleSpawn: false,
            0f,
            subspecies,
            null,
            false,
            true
        );

        EquipmentAsset equipmentAsset = AssetManager.items.get(item);
        Item item_asset = World.world.items.generateItem(equipmentAsset);
        unit.equipment.setItem(item_asset, unit);

        unit.makeWait(1f);
        unit.setKingdom(kingdom);
        unit.setCity(city);
        city.makeWarrior(unit);

        return true;
    }

    private static GodPower CreateWarriorPower(string id, string equipment_id)
    {
        GodPower spawn_warrior = new GodPower()
        {
            id = id,
            type = PowerActionType.PowerSpecial,
            rank = PowerRank.Rank0_free,
            unselect_when_window = true,
            show_spawn_effect = true,
            actor_spawn_height = 3f,
            multiple_spawn_tip = true,
            show_unit_stats_overview = true,
            set_used_camera_drag_on_long_move = true
        };
        spawn_warrior.name = id;
        spawn_warrior.click_action = new PowerActionWithID((pTile, pPower) =>
        {
            return SpawnWarrior(pTile, equipment_id);
        });

        return spawn_warrior;
    }
}