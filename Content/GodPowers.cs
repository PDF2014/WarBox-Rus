using System.Reflection;
using NeoModLoader.api;
using NeoModLoader.api.features;
using ReflectionUtility;

namespace WarBox.Content;

internal static class WarBoxGodPowers
{
    public static void Init()
    {
        DropAsset drop = new DropAsset
        {
            id = $"spawn_metal_spawner",
            path_texture = "ui/icon",
            default_scale = 0.2f,
            random_frame = true,
            random_flip = true,
            type = DropType.DropBuilding,
            building_asset = "metal_spawner",
            action_landed = DropsLibrary.action_spawn_building
        };
        AssetManager.drops.add(drop);

        GodPower metal_spawner = AssetManager.powers.clone("metal_spawner", "$template_drop_building$");
        metal_spawner.name = "Metal Spawner";
        metal_spawner.rank = PowerRank.Rank0_free;
        metal_spawner.drop_id = drop.id;
        metal_spawner.falling_chance = 0.5f;
        metal_spawner.click_power_action = Stuff_Drop;
        metal_spawner.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });

        FieldInfo dropField = typeof(GodPower).GetField("cached_drop_asset", BindingFlags.NonPublic | BindingFlags.Instance);
        if (dropField != null)
            dropField.SetValue(metal_spawner, drop);
    }

    private static bool Stuff_Drop(WorldTile pTile, GodPower pPower)
    {
        AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
        return true;
    }
    
    public static void action_MOABClick(WorldTile pTile, string pPowerID)
    {
        EffectsLibrary.spawn("fx_nuke_flash", pTile, "moab");
        //World.world.startShake(pIntensity: 2.5f, pShakeX: true);
    }
}