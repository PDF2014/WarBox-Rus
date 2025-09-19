using System.Collections.Generic;

namespace WarBox.Content;

internal static class WarBoxTraits
{
    public static void Init()
    {
        ActorTrait warbox_unit = new ActorTrait();
        warbox_unit.id = "warbox_unit";
        warbox_unit.needs_to_be_explored = false;
        warbox_unit.rarity = Rarity.R0_Normal;
        warbox_unit.path_icon = "ui/icons/items/icon_autorifle";
        warbox_unit.group_id = "special";
        warbox_unit.is_mutation_box_allowed = false;
        warbox_unit.can_be_given = false;
        warbox_unit.unlocked_with_achievement = false;
        warbox_unit.addOpposite("madness");
        warbox_unit.base_stats ??= new BaseStats();
        AssetManager.traits.add(warbox_unit);

        ActorTrait atgm_launcher = new ActorTrait();
        atgm_launcher.id = "atgm_launcher";
        atgm_launcher.needs_to_be_explored = false;
        atgm_launcher.rarity = Rarity.R3_Legendary;
        atgm_launcher.path_icon = "ui/icons/items/icon_rpg";
        atgm_launcher.group_id = "fun";
        atgm_launcher.is_mutation_box_allowed = false;
        atgm_launcher.can_be_given = true;
        atgm_launcher.unlocked_with_achievement = false;
        atgm_launcher.addOpposite("bomberman");
        atgm_launcher.base_stats ??= new BaseStats();
        atgm_launcher.combat_actions_ids = new List<string>{ "combat_launch_atgm" };
        atgm_launcher.linkCombatActions();
        AssetManager.traits.add(atgm_launcher);
    }
}