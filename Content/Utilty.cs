using System.Collections.Generic;
using System.Text;
using ReflectionUtility;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WarBox.Content;

internal static class WarBoxUtils
{
    // this function exists until NML fixes range weapon creation
    public static ItemAsset CreateRangeWeapon(string id, string projectile, BaseStats base_stats = null, string material = null, List<string> item_modifiers = null, string name_class = null, List<string> name_templates = null, string tech_needed = null, AttackAction action_attack_target = null, WorldAction action_special_effect = null, float special_effect_interval = 1f, int equipment_value = 0, string path_slash_animation = "effects/slashes/slash_punch")
    {
        ItemAsset itemAsset = AssetManager.items.clone(id, "$range");
        itemAsset.base_stats = base_stats ?? itemAsset.base_stats;
        itemAsset.material = material ?? itemAsset.material;
        itemAsset.item_modifier_ids = ((item_modifiers != null) ? item_modifiers.ToArray() : itemAsset.item_modifier_ids);
        itemAsset.name_class = (string.IsNullOrEmpty(name_class) ? itemAsset.name_class : name_class);
        itemAsset.name_templates = name_templates ?? itemAsset.name_templates;
        itemAsset.action_attack_target = action_attack_target;
        itemAsset.action_special_effect = action_special_effect;
        itemAsset.special_effect_interval = special_effect_interval;
        itemAsset.equipment_value = equipment_value;
        itemAsset.path_slash_animation = path_slash_animation;
        itemAsset.projectile = (string.IsNullOrEmpty(projectile) ? "snowball" : projectile);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Some unexpected for " + id + " as a range weapon:");
        if (string.IsNullOrEmpty(projectile))
        {
            stringBuilder.AppendLine("\t projectile is null or empty. ");
        }
        itemAsset.attack_type = WeaponType.Range;
        itemAsset.equipment_type = EquipmentType.Weapon;
        return itemAsset;
    }

    public static void AddWeaponsSprite(string id)
    {
        var sprite = Resources.Load<Sprite>("weapons/" + id);
        AssetManager.items.get(id).gameplay_sprites = new Sprite[] { sprite };
        //return new Sprite[] { sprite };
    }
}