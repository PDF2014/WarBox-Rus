using System.Collections.Generic;
using NeoModLoader.api.attributes;
using UnityEngine;

namespace WarBox.Content;

internal static class WarBoxGuns
{
    [Hotfixable]
    public static void Init()
    {
        AddTerraformOptions();
        AddProjectiles();
        AddGuns();
        AddVehicleWeapons();
        AddNameGenerators();
    }

    private static void AddGuns()
    {
        // Pistol 
        BaseStats stats_pistol = new BaseStats();
        stats_pistol["projectiles"] = 1;
        stats_pistol["accuracy"] = -10f;
        stats_pistol["range"] = 35f;
        stats_pistol["damage"] = 35f;
        stats_pistol["attack_speed"] = 0f;
        stats_pistol["speed"] = 7.5f;

        EquipmentAsset pistol = CreateGun(
            id: "pistol",
            stats: stats_pistol,
            equipment_value: 60,
            name: "Pistol",
            description: "A very handy semi-automatic firearm",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 3
        );

        // SMG
        BaseStats stats_smg = new BaseStats();
        stats_smg["projectiles"] = 1;
        stats_smg["accuracy"] = -25f;
        stats_smg["range"] = 15f;
        stats_smg["damage"] = 25f;
        stats_smg["attack_speed"] = 20f;
        stats_smg["speed"] = 5f;

        EquipmentAsset smg = CreateGun(
            id: "smg",
            stats: stats_smg,
            equipment_value: 65,
            name: "SMG",
            description: "A fast firing sub-machine gun, not very accurate",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 4,
            resource2: "wood", resource2Cost: 2
        );

        // Rifle
        BaseStats stats_rifle = new BaseStats();
        stats_rifle["projectiles"] = 1;
        stats_rifle["accuracy"] = 95f;
        stats_rifle["range"] = 72.5f;
        stats_rifle["damage"] = 75f;
        stats_rifle["attack_speed"] = -5f;

        EquipmentAsset rifle = CreateGun(
            id: "rifle",
            stats: stats_rifle,
            equipment_value: 70,
            name: "Rifle",
            description: "A standard bolt-action rifle",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 5,
            resource2: "wood", resource2Cost: 3
        );

        // Automatic Rifle
        BaseStats stats_autorifle = new BaseStats();
        stats_autorifle["projectiles"] = 1;
        stats_autorifle["accuracy"] = 10f;
        stats_autorifle["range"] = 20f;
        stats_autorifle["damage"] = 60f;
        stats_autorifle["attack_speed"] = 3.5f;

        EquipmentAsset autorifle = CreateGun(
            id: "autorifle",
            stats: stats_autorifle,
            equipment_value: 70,
            name: "Automatic Rifle",
            description: "A repeating rifle, hits fast and hard",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 5,
            resource2: "wood", resource2Cost: 3
        );

        // Sniper Rifle
        BaseStats stats_sniperrifle = new BaseStats();
        stats_sniperrifle["projectiles"] = 1;
        stats_sniperrifle["accuracy"] = 100f;
        stats_sniperrifle["critical_chance"] = 0.75f;
        stats_sniperrifle["range"] = 120f;
        stats_sniperrifle["damage"] = 160f;
        stats_sniperrifle["attack_speed"] = -3f;

        EquipmentAsset sniperrifle = CreateGun(
            id: "sniperrifle",
            stats: stats_sniperrifle,
            equipment_value: 65,
            name: "Sniper Rifle",
            description: "A very accurate bolt-action rifle, hits VERY hard",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 5,
            resource2: "wood", resource2Cost: 3
        );

        // Shotgun (does not actually replace ingame shotgun)
        BaseStats stats_shotgun = new BaseStats();
        stats_shotgun["projectiles"] = 6f;
        stats_shotgun["accuracy"] = -60f;
        stats_shotgun["range"] = 15f;
        stats_shotgun["damage"] = 10f;
        stats_shotgun["attack_speed"] = -5f;

        EquipmentAsset shotgun = CreateGun(
            id: "shotgunreplace",
            stats: stats_shotgun,
            equipment_value: 55,
            name: "Shotgun",
            description: "A shotgun firing many pellets, dangerous up close",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 5,
            resource2: "wood", resource2Cost: 3
        );

        // RPG
        BaseStats stats_rpg = new BaseStats();
        stats_rpg["projectiles"] = 1;
        stats_rpg["accuracy"] = 0f;
        stats_rpg["range"] = 40f;
        stats_rpg["damage"] = 10f;
        stats_rpg["attack_speed"] = -10f;
        stats_rpg["speed"] = -10f;

        EquipmentAsset rpg = CreateGun(
            id: "rpg",
            stats: stats_rpg,
            equipment_value: 55,
            name: "Rocket Launcher",
            projectile: "rpg_projectile",
            description: "A launcher firing rocket propelled grenades",
            goldCost: 0,
            resource1: "common_metals", resource1Cost: 9,
            resource2: "gems", resource2Cost: 4
        );

        if (!AssetManager.items.equipment_by_subtypes.ContainsKey("gun"))
        {
            AssetManager.items.equipment_by_subtypes.Add("gun", new List<EquipmentAsset>());
        }

        if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("firearm"))
        {
            AssetManager.items.pot_equipment_by_groups_all.Add("firearm", new List<EquipmentAsset>());
        }

        if (!AssetManager.items.pot_equipment_by_groups_unlocked.ContainsKey("firearm"))
        {
            AssetManager.items.pot_equipment_by_groups_unlocked.Add("firearm", new List<EquipmentAsset>());
        }

        AssetManager.items.equipment_by_subtypes["gun"].Add(pistol);
        AssetManager.items.equipment_by_subtypes["gun"].Add(smg);
        AssetManager.items.equipment_by_subtypes["gun"].Add(rifle);
        AssetManager.items.equipment_by_subtypes["gun"].Add(autorifle);
        AssetManager.items.equipment_by_subtypes["gun"].Add(sniperrifle);
        AssetManager.items.equipment_by_subtypes["gun"].Add(shotgun);
        AssetManager.items.equipment_by_subtypes["gun"].Add(rpg);

        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(pistol);
        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(smg);
        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(rifle);
        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(autorifle);
        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(sniperrifle);
        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(shotgun);
        AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(rpg);

        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(pistol);
        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(smg);
        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(rifle);
        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(autorifle);
        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(sniperrifle);
        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(shotgun);
        AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(rpg);
    }

    private static void AddVehicleWeapons()
    {
        EquipmentAsset tester = AssetManager.items.clone("tank_attack", "$range");
        tester.has_locales = false;
        tester.projectile = "tank_shell";
        tester.base_stats["projectiles"] = 1f;
        tester.path_slash_animation = "effects/gunshots/shot_gun";
        tester.show_in_meta_editor = false;
        tester.show_in_knowledge_window = false;
    }

    private static void AddTerraformOptions()
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

        TerraformOptions soft_grenade = AssetManager.terraform.clone("soft_grenade", "grenade");
        soft_grenade.shake = false;
        soft_grenade.explode_and_set_random_fire = false;
    }

    private static void AddProjectiles()
    {
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
            can_be_blocked = true,
        });

        AssetManager.projectiles.add(new ProjectileAsset
        {
            id = "cannon_shell",
            speed = 45f,
            texture = "pr_shell",
            look_at_target = true,
            texture_shadow = "shadows/projectiles/shadow_arrow",
            end_effect = "fx_fireball_explosion",
            hit_shake = false,
            scale_start = 0.08f,
            scale_target = 0.08f,
            draw_light_area = false,
            sound_launch = "event:/SFX/WEAPONS/WeaponStartThrow",
            terraform_option = "soft_grenade",
            terraform_range = 6,
            can_be_blocked = false,
        });

        AssetManager.projectiles.add(new ProjectileAsset
        {
            id = "tank_shell",
            speed = 48f,
            texture = "pr_shell",
            look_at_target = true,
            texture_shadow = "shadows/projectiles/shadow_arrow",
            end_effect = "fx_fireball_explosion",
            hit_shake = false,
            scale_start = 0.04f,
            scale_target = 0.04f,
            draw_light_area = false,
            sound_launch = "event:/SFX/WEAPONS/WeaponStartThrow",
            terraform_option = "soft_grenade",
            terraform_range = 3,
            can_be_blocked = false,
        });
    }

    private static void AddNameGenerators()
    {
        NameGeneratorAsset gun_namegenerator = new NameGeneratorAsset
        {
            id = "gun_name"
        };
        gun_namegenerator.addPartGroup("M,MG,SG,G,MP,AK,XM,P,HK,RPG,FIM,AEK,AN,FAMAS,UMP,AR,LR,SR,SMG,LMG,SCAR,MAC,TEC,PM,PMM,USP,PP,PPK,AWP,AWM,TAR,RPK,PPSh,DP");
        gun_namegenerator.addPartGroup("-");
        gun_namegenerator.addPartGroup("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100");
        gun_namegenerator.addPartGroup("A1,A2,A3,A4,MK1,MK2,MK3,MK4,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z");
        gun_namegenerator.addTemplate("Part_group");
        AssetManager.name_generator.add(gun_namegenerator);

        NameGeneratorAsset tank_namegenerator = new NameGeneratorAsset
        {
            id = "tank_name"
        };
        tank_namegenerator.addOnomastic("`0_1_###u|0:tank;1:unit`");
        AssetManager.name_generator.add(tank_namegenerator);

        NameSetAsset tank_nameset = new NameSetAsset
        {
            id = "tank_set",
            city = "tank_name",
            clan = "tank_name",
            culture = "tank_name",
            family = "tank_name",
            kingdom = "tank_name",
            language = "tank_name",
            unit = "tank_name",
            religion = "tank_name"
        };
        AssetManager.name_sets.add(tank_nameset);
    }

    private static EquipmentAsset CreateGun(string id, BaseStats stats, string projectile = "shotgun_bullet", int equipment_value = 100, string name = "", string description = "", int goldCost = 0, string resource1 = "none", int resource1Cost = 0, string resource2 = "none", int resource2Cost = 0)
    {
        EquipmentAsset gun = AssetManager.items.clone(id, "$range");
        gun.material = "steel";
        gun.path_slash_animation = "effects/gunshots/shot_gun";
        gun.name_class = "item_class_weapon";
        gun.equipment_subtype = "gun";
        gun.group_id = "firearm";
        gun.name_templates = new List<string>() { "gun_name" };
        gun.base_stats = stats;
        gun.translation_key = gun.id;
        gun.path_icon = "ui/icons/items/icon_" + gun.id;

        gun.equipment_type = EquipmentType.Weapon;
        gun.projectile = projectile;
        gun.metallic = true;

        gun.equipment_value = equipment_value;
        gun.minimum_city_storage_resource_1 = 10;
        gun.rigidity_rating = 1;

        gun.setCost(goldCost, resource1, resource1Cost, resource2, resource2Cost);
        gun.gameplay_sprites = new Sprite[] { SpriteTextureLoader.getSprite("weapons/" + id) };

        return gun;
    }
}