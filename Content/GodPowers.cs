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
        DropAsset metal_drop = new DropAsset
        {
            id = "spawn_metal_spawner",
            path_texture = "drops/drop_stone",
            default_scale = 0.2f,
            random_frame = true,
            random_flip = true,
            type = DropType.DropBuilding,
            building_asset = "metal_spawner",
            action_landed = DropsLibrary.action_spawn_building
        };
        AssetManager.drops.add(metal_drop);

        DropAsset gold_drop = AssetManager.drops.clone("spawn_gold_spawner", metal_drop.id);
        gold_drop.building_asset = "gold_spawner";
    }

    private static void AddPowers()
    {
        GodPower metal_spawner = AssetManager.powers.clone("metal_spawner", "$template_drop_building$");
        metal_spawner.name = "Metal Spawner";
        metal_spawner.rank = PowerRank.Rank0_free;
        metal_spawner.drop_id = "spawn_metal_spawner";
        metal_spawner.falling_chance = 0f;
        metal_spawner.force_brush = "circ_0";
        metal_spawner.click_power_action = StuffDrop;
        metal_spawner.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });

        GodPower gold_spawner = AssetManager.powers.clone("gold_spawner", metal_spawner.id);
        gold_spawner.name = "Gold Spawner";
        gold_spawner.drop_id = "spawn_gold_spawner";
    }

    private static void Cache()
    {
        FieldInfo dropField = typeof(GodPower).GetField("cached_drop_asset", BindingFlags.NonPublic | BindingFlags.Instance);
        if (dropField != null)
            dropField.SetValue(AssetManager.powers.get("metal_spawner"), AssetManager.drops.get("spawn_metal_spawner"));
            dropField.SetValue(AssetManager.powers.get("gold_spawner"), AssetManager.drops.get("spawn_gold_spawner"));
    }

    private static bool StuffDrop(WorldTile pTile, GodPower pPower)
    {
        AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
        return true;
    }
}