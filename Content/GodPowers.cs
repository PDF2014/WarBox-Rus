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
        artillery_bunker_builder.name = "Bunker";
        artillery_bunker_builder.rank = PowerRank.Rank0_free;
        artillery_bunker_builder.drop_id = "spawn_bunker";
        artillery_bunker_builder.falling_chance = 0f;
        artillery_bunker_builder.force_brush = "circ_0";
        artillery_bunker_builder.click_power_action = StuffDrop;
        artillery_bunker_builder.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });
    }

    private static void Cache()
    {
        FieldInfo dropField = typeof(GodPower).GetField("cached_drop_asset", BindingFlags.NonPublic | BindingFlags.Instance);
        if (dropField != null)
        {
            dropField.SetValue(AssetManager.powers.get("bunker_builder"), AssetManager.drops.get("spawn_bunker"));
            dropField.SetValue(AssetManager.powers.get("artillery_bunker_builder"), AssetManager.drops.get("spawn_artillery_bunker"));
        }
    }

    private static bool StuffDrop(WorldTile pTile, GodPower pPower)
    {
        AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
        return true;
    }
}