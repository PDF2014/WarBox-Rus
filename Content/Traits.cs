namespace WarBox.Content;

internal static class WarBoxTraits
{
    public static void Init()
    {
        ActorTrait warboxUnit = new ActorTrait();
        warboxUnit.id = "warbox_unit";
        warboxUnit.needs_to_be_explored = false;
        warboxUnit.rarity = Rarity.R0_Normal;
        warboxUnit.path_icon = "ui/icons/items/icon_autorifle";
        warboxUnit.group_id = "special";
        warboxUnit.is_mutation_box_allowed = false;
        warboxUnit.can_be_given = false;
        warboxUnit.unlocked_with_achievement = false;
        warboxUnit.addOpposite("madness");
        warboxUnit.base_stats ??= new BaseStats();
        AssetManager.traits.add(warboxUnit);
    }
}