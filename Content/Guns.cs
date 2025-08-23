using System.Collections.Generic;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NeoModLoader.utils.Builders;
using NCMS.Utils;
using System.Data.SqlClient;

namespace WarBox.Content;

internal static class WarBoxGuns
{
    [Hotfixable]
    public static void Init()
    {
        AddProjectiles();
        AddGuns();
        // add_preferences();
        AddNameGenerators();
        // var attack_speed_global = AssetManager.base_stats_library.get("attack_speed");
        // attack_speed_global.normalize_max = 1000;
    }

    private static void AddGuns()
    {

        BaseStats stats_rifle = new BaseStats();
        stats_rifle["projectiles"] = 1;
        stats_rifle["accuracy"] = 95f;
        stats_rifle["range"] = 72.5f;
        stats_rifle["damage"] = 75f;
        stats_rifle["attack_speed"] = -5f;

        ItemAsset rifle = WarBoxUtils.CreateRangeWeapon(
            id: "rifle",
            projectile: "shotgun_bullet",
            base_stats: stats_rifle,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        rifle.setCost(0, "common_metals", 9, "wood", 3);
        rifle.group_id = "firearm";
        rifle.equipment_subtype = "gun";
        rifle.path_icon = "ui/icons/items/icon_rifle";
        rifle.quality = Rarity.R3_Legendary;
        rifle.translation_key = "rifle";
        LM.Add("en", "rifle", "Rifle");
        LM.Add("en", "rifle_description", "A standard bolt-action rifle");
        WarBoxUtils.AddWeaponsSprite(rifle.id);

        BaseStats stats_pistol = new BaseStats();
        stats_pistol["projectiles"] = 1;
        stats_pistol["accuracy"] = -10f;
        stats_pistol["range"] = 35f;
        stats_pistol["damage"] = 35f;
        stats_pistol["attack_speed"] = 0f;

        ItemAsset pistol = WarBoxUtils.CreateRangeWeapon(
            id: "pistol",
            projectile: "shotgun_bullet",
            base_stats: stats_pistol,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        pistol.setCost(0, "common_metals", 6);
        pistol.group_id = "firearm";
        pistol.equipment_subtype = "gun";
        pistol.path_icon = "ui/icons/items/icon_pistol";
        pistol.quality = Rarity.R3_Legendary;
        pistol.translation_key = "pistol";
        LM.Add("en", "pistol", "Pistol");
        LM.Add("en", "pistol_description", "A very handy semi-automatic firearm");
        WarBoxUtils.AddWeaponsSprite(pistol.id);

        BaseStats stats_smg = new BaseStats();
        stats_smg["projectiles"] = 1;
        stats_smg["accuracy"] = -25f;
        stats_smg["range"] = 15f;
        stats_smg["damage"] = 25f;
        stats_smg["attack_speed"] = 20f;

        ItemAsset smg = WarBoxUtils.CreateRangeWeapon(
            id: "smg",
            projectile: "shotgun_bullet",
            base_stats: stats_smg,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        smg.setCost(0, "common_metals", 7, "wood", 1);
        smg.group_id = "firearm";
        smg.equipment_subtype = "gun";
        smg.path_icon = "ui/icons/items/icon_smg";
        smg.quality = Rarity.R3_Legendary;
        smg.translation_key = "smg";
        LM.Add("en", "smg", "SMG");
        LM.Add("en", "smg_description", "A fast firing sub machine gun, not very accurate");
        WarBoxUtils.AddWeaponsSprite(smg.id);

        BaseStats stats_autorifle = new BaseStats();
        stats_autorifle["projectiles"] = 1;
        stats_autorifle["accuracy"] = 10f;
        stats_autorifle["range"] = 65f;
        stats_autorifle["damage"] = 60f;
        stats_autorifle["attack_speed"] = 3.5f;

        ItemAsset autorifle = WarBoxUtils.CreateRangeWeapon(
            id: "autorifle",
            projectile: "shotgun_bullet",
            base_stats: stats_autorifle,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        autorifle.setCost(0, "common_metals", 15, "wood", 4);
        autorifle.group_id = "firearm";
        autorifle.equipment_subtype = "gun";
        autorifle.path_icon = "ui/icons/items/icon_autorifle";
        autorifle.quality = Rarity.R3_Legendary;
        autorifle.translation_key = "autorifle";
        LM.Add("en", "autorifle", "Automatic Rifle");
        LM.Add("en", "autorifle_description", "A repeating rifle, hits fast and hard");
        WarBoxUtils.AddWeaponsSprite(autorifle.id);

        BaseStats stats_sniperrifle = new BaseStats();
        stats_sniperrifle["projectiles"] = 1;
        stats_sniperrifle["accuracy"] = 100f;
        stats_sniperrifle["critical_chance"] = 0.75f;
        stats_sniperrifle["range"] = 120f;
        stats_sniperrifle["damage"] = 160f;
        stats_sniperrifle["attack_speed"] = -3f;

        ItemAsset sniperrifle = WarBoxUtils.CreateRangeWeapon(
            id: "sniperrifle",
            projectile: "shotgun_bullet",
            base_stats: stats_sniperrifle,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        sniperrifle.setCost(3, "common_metals", 13, "wood", 4);
        sniperrifle.group_id = "firearm";
        sniperrifle.equipment_subtype = "gun";
        sniperrifle.path_icon = "ui/icons/items/icon_sniperrifle";
        sniperrifle.quality = Rarity.R3_Legendary;
        sniperrifle.translation_key = "sniperrifle";
        LM.Add("en", "sniperrifle", "Sniper Rifle");
        LM.Add("en", "sniperrifle_description", "A very accurate bolt-action rifle, hits VERY hard");
        WarBoxUtils.AddWeaponsSprite(sniperrifle.id);

        BaseStats stats_rpg = new BaseStats();
        stats_rpg["projectiles"] = 1;
        stats_rpg["accuracy"] = 0f;
        stats_rpg["range"] = 40f;
        stats_rpg["damage"] = 10f;
        stats_rpg["attack_speed"] = -10f;

        ItemAsset rpg = WarBoxUtils.CreateRangeWeapon(
            id: "rpg",
            projectile: "rpg_projectile",
            base_stats: stats_rpg,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        rpg.setCost(0, "common_metals", 25, "gems", 3);
        rpg.group_id = "firearm";
        rpg.equipment_subtype = "gun";
        rpg.path_icon = "ui/icons/items/icon_rpg";
        rpg.quality = Rarity.R3_Legendary;
        rpg.translation_key = "rpg";
        LM.Add("en", "rpg", "Rocket Launcher");
        LM.Add("en", "rpg_description", "A launcher firing rocket propelled grenades");
        WarBoxUtils.AddWeaponsSprite(rpg.id);

        BaseStats stats_shotgun = new BaseStats();
        stats_shotgun["projectiles"] = 12f;
        stats_shotgun["accuracy"] = -60f;
        stats_shotgun["range"] = 15f;
        stats_shotgun["damage"] = 10f;
        stats_shotgun["attack_speed"] = -5f;

        ItemAsset shotgun = WarBoxUtils.CreateRangeWeapon(
            id: "shotgunreplace",
            projectile: "shotgun_bullet",
            base_stats: stats_shotgun,
            material: "steel",
            item_modifiers: new List<string> { },
            name_templates: new List<string>() { "gun_name" },
            //tech_needed: "firearm_production",
            action_attack_target: null,
            action_special_effect: null,
            special_effect_interval: 1,
            equipment_value: 500,
            path_slash_animation: "effects/slashes/slash_punch",
            name_class: "item_class_weapon"
        );
        shotgun.setCost(0, "common_metals", 9, "wood", 3);
        shotgun.group_id = "firearm";
        shotgun.equipment_subtype = "gun";
        shotgun.path_icon = "ui/icons/items/icon_shotgunreplace";
        shotgun.quality = Rarity.R3_Legendary;
        shotgun.translation_key = "shotgunreplace";
        LM.Add("en", "shotgunreplace", "Shotgun");
        LM.Add("en", "shotgunreplace_description", "A shotgun firing many pellets, dangerous up close");
        WarBoxUtils.AddWeaponsSprite(shotgun.id);
    }

    private static void AddProjectiles()
    {
        AssetManager.terraform.add(new TerraformOptions
        {
            id = "rpg",
            flash = true,
            damage_buildings = true,
            damage = 100,
            apply_force = true,
            explode_and_set_random_fire = false,
            explode_tile = true,
            explosion_pixel_effect = true,
            explode_strength = 1,
            shake = false,
            remove_tornado = true,
            remove_frozen = true,
        });

        AssetManager.projectiles.add(new ProjectileAsset
        {
            id = "rpg_projectile",
            speed = 35f,
            texture = "pr_rpg",
            look_at_target = true,
            texture_shadow = "shadows/projectiles/shadow_arrow",
            end_effect = "fx_fireball_explosion",
            hit_shake = false,
            scale_start = 0.075f,
            scale_target = 0.075f,
            draw_light_area = true,
            draw_light_size = 0.1f,
            sound_launch = "event:/SFX/WEAPONS/WeaponStartThrow",
            terraform_option = "rpg",
            terraform_range = 4,
            can_be_blocked = false,
        });
        
        //AssetManager.projectiles.get("shotgun_bullet").speed = 55f;
    }

    private static void AddNameGenerators()
    {
        NameGeneratorAsset gun_namegenerator = new NameGeneratorAsset
        {
            id = "gun_name"
        };
        gun_namegenerator.addPartGroup("M,MG,SG,G,MP,AK,XM,P,HK,RPG,FIM");
        gun_namegenerator.addPartGroup("-");
        gun_namegenerator.addPartGroup("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100");
        gun_namegenerator.addPartGroup("A1,A2,A3,A4,MK1,MK2,MK3,MK4,J");
        gun_namegenerator.addTemplate("Part_group");
        AssetManager.name_generator.add(gun_namegenerator);
    }
}