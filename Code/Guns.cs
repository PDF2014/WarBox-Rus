using System.Collections.Generic;
using NeoModLoader.General;
using NeoModLoader.General.Game;

namespace ErexMod.Content;

internal static class ErexModGuns
{
    public static void init()
    {
        add_projectiles();
        add_guns();
        add_preferences();

        // var attack_speed_global = AssetManager.base_stats_library.get(S.attack_speed);
        // attack_speed_global.normalize_max = 1000;
    }

    private static void add_preferences()
    {
        Race human = AssetManager.raceLibrary.get(S.human);
        addPreferredWeapon(human, "rifle", 10);
        addPreferredWeapon(human, "pistol", 6);
        addPreferredWeapon(human, "smg", 10);
        addPreferredWeapon(human, "autorifle", 10);
        addPreferredWeapon(human, "sniperrifle", 10);
        addPreferredWeapon(human, "rpg", 6);
        addPreferredWeapon(human, "shotgunreplace", 10);

        Race elf = AssetManager.raceLibrary.get(S.elf);
        addPreferredWeapon(elf, "rifle", 10);
        addPreferredWeapon(elf, "pistol", 6);
        addPreferredWeapon(elf, "smg", 10);
        addPreferredWeapon(elf, "autorifle", 10);
        addPreferredWeapon(elf, "sniperrifle", 10);
        addPreferredWeapon(elf, "rpg", 6);
        addPreferredWeapon(elf, "shotgunreplace", 10);

        Race orc = AssetManager.raceLibrary.get(S.orc);
        addPreferredWeapon(orc, "rifle", 10);
        addPreferredWeapon(orc, "pistol", 6);
        addPreferredWeapon(orc, "smg", 10);
        addPreferredWeapon(orc, "autorifle", 10);
        addPreferredWeapon(orc, "sniperrifle", 10);
        addPreferredWeapon(orc, "rpg", 6);
        addPreferredWeapon(orc, "shotgunreplace", 10);

        Race dwarf = AssetManager.raceLibrary.get(S.dwarf);
        addPreferredWeapon(dwarf, "rifle", 10);
        addPreferredWeapon(dwarf, "pistol", 6);
        addPreferredWeapon(dwarf, "smg", 10);
        addPreferredWeapon(dwarf, "autorifle", 10);
        addPreferredWeapon(dwarf, "sniperrifle", 10);
        addPreferredWeapon(dwarf, "rpg", 6);
        addPreferredWeapon(dwarf, "shotgunreplace", 10);
    }

    private static void add_guns()
    {
        BaseStats stats_rifle = new BaseStats();
        stats_rifle[S.projectiles] = 1;
        stats_rifle[S.accuracy] = 95f;
        stats_rifle[S.range] = 72.5f;
        stats_rifle[S.damage] = 75f;
        stats_rifle[S.attack_speed] = 20f;
        
        ItemAsset rifle = ItemAssetCreator.CreateRangeWeapon(
            id: "rifle",
            projectile: "shotgun_bullet",
            base_stats: stats_rifle,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "Rifle"
        );
        rifle.path_icon = "ui/icons/items/icon_rifle";
        rifle.quality = ItemQuality.Legendary;
        LM.Add("en", "item_rifle", "Rifle");

        BaseStats stats_pistol = new BaseStats();
        stats_pistol[S.projectiles] = 1;
        stats_pistol[S.accuracy] = 65f;
        stats_pistol[S.range] = 35f;
        stats_pistol[S.damage] = 35f;
        stats_pistol[S.attack_speed] = 40f;
        
        ItemAsset pistol = ItemAssetCreator.CreateRangeWeapon(
            id: "pistol",
            projectile: "shotgun_bullet",
            base_stats: stats_pistol,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "Pistol"
        );
        pistol.path_icon = "ui/icons/items/icon_pistol";
        pistol.quality = ItemQuality.Legendary;
        LM.Add("en", "item_pistol", "Pistol");

        BaseStats stats_smg = new BaseStats();
        stats_smg[S.projectiles] = 1;
        stats_smg[S.accuracy] = 55f;
        stats_smg[S.range] = 15f;
        stats_smg[S.damage] = 25f;
        stats_smg[S.attack_speed] = 300f;
        
        ItemAsset smg = ItemAssetCreator.CreateRangeWeapon(
            id: "smg",
            projectile: "shotgun_bullet",
            base_stats: stats_smg,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "SMG"
        );
        smg.path_icon = "ui/icons/items/icon_smg";
        smg.quality = ItemQuality.Legendary;
        LM.Add("en", "item_smg", "SMG");

        BaseStats stats_autorifle = new BaseStats();
        stats_autorifle[S.projectiles] = 1;
        stats_autorifle[S.accuracy] = 75f;
        stats_autorifle[S.range] = 65f;
        stats_autorifle[S.damage] = 60f;
        stats_autorifle[S.attack_speed] = 200f;
        
        ItemAsset autorifle = ItemAssetCreator.CreateRangeWeapon(
            id: "autorifle",
            projectile: "shotgun_bullet",
            base_stats: stats_autorifle,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "Automatic Rifle"
        );
        autorifle.path_icon = "ui/icons/items/icon_autorifle";
        autorifle.quality = ItemQuality.Legendary;
        LM.Add("en", "item_autorifle", "Automatic Rifle");

        BaseStats stats_sniperrifle = new BaseStats();
        stats_sniperrifle[S.projectiles] = 1;
        stats_sniperrifle[S.accuracy] = 99f;
        stats_sniperrifle[S.range] = 120f;
        stats_sniperrifle[S.damage] = 160f;
        stats_sniperrifle[S.attack_speed] = -30f;
        
        ItemAsset sniperrifle = ItemAssetCreator.CreateRangeWeapon(
            id: "sniperrifle",
            projectile: "shotgun_bullet",
            base_stats: stats_sniperrifle,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "Sniper Rifle"
        );
        sniperrifle.path_icon = "ui/icons/items/icon_sniperrifle";
        sniperrifle.quality = ItemQuality.Legendary;
        LM.Add("en", "item_sniperrifle", "Sniper Rifle");

        BaseStats stats_rpg = new BaseStats();
        stats_rpg[S.projectiles] = 1;
        stats_rpg[S.accuracy] = 70f;
        stats_rpg[S.range] = 40f;
        stats_rpg[S.damage] = 0f;
        stats_rpg[S.attack_speed] = -40f;
        
        ItemAsset rpg = ItemAssetCreator.CreateRangeWeapon(
            id: "rpg",
            projectile: "rpg_projectile",
            base_stats: stats_rpg,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "Rocket Launcher"
        );
        rpg.path_icon = "ui/icons/items/icon_rpg";
        rpg.quality = ItemQuality.Legendary;
        LM.Add("en", "item_rpg", "Rocket Launcher");

        BaseStats stats_shotgun = new BaseStats();
        stats_shotgun[S.projectiles] = 12f;
        stats_shotgun[S.accuracy] = 45f;
        stats_shotgun[S.range] = 15f;
        stats_shotgun[S.damage] = 10f;
        stats_shotgun[S.attack_speed] = 10f;
        
        ItemAsset shotgun = ItemAssetCreator.CreateRangeWeapon(
            id: "shotgunreplace",
            projectile: "shotgun_bullet",
            base_stats: stats_shotgun,
            materials: new List<string> { "steel" },
            item_modifiers: new List<string> {},
            name_templates: Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            }),
            tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "Shotgun"
        );
        shotgun.path_icon = "ui/icons/items/icon_shotgunreplace";
        shotgun.quality = ItemQuality.Legendary;
        LM.Add("en", "item_shotgunreplace", "Shotgun");
    }

    private static void add_projectiles()
    {
        AssetManager.terraform.add(new TerraformOptions
        {
            id = "rpg",
            flash = true,
            damageBuildings = true,
            damage = 100,
            applyForce = true,
            explode_and_set_random_fire = true,
            explode_tile = true,
            explosion_pixel_effect = true,
            explode_strength = 1,
            shake = false,
            removeTornado = true,
            removeFrozen = true,
        });

        AssetManager.projectiles.add(new ProjectileAsset
        {
            id = "rpg_projectile",
            speed = 9f,
            texture = "pr_rpg",
            parabolic = false,
            look_at_target = true,
            texture_shadow = "shadow_ball",
            endEffect = "fx_fireball_explosion",
            hitShake = false,
            shakeDuration = 0.01f,
            shakeInterval = 0.01f,
            shakeIntensity = 0.25f,
            startScale = 0.075f,
            targetScale = 0.075f,
            draw_light_area = true,
            sound_launch = "event:/SFX/WEAPONS/WeaponStartThrow",
            terraformOption = "rpg",
            terraformRange = 4
        });
    }

    private static void addPreferredWeapon(Race race, string pID, int pAmount)
    {
        for (int i = 0; i < pAmount; i++)
        {
            race.preferred_weapons.Add(pID);
        }
    }
}