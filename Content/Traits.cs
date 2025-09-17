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
    }
}