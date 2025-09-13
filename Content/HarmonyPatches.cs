using NeoModLoader.General.Event.Handlers;
using NeoModLoader.General.Event.Listeners;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using ai.behaviours;
using System;
using UnityEngine.UI;

namespace WarBox.Content;

[HarmonyPatch(typeof(City), "update")]
public static class CityUpdate_Patch //adding units according to population
{
    static readonly Dictionary<long, float> times = new Dictionary<long, float>();

    static void Prefix(City __instance, float pElapsed)
    {
        if (!WarBox.warbox_factories) return;
        if (__instance == null) return;
        if (!times.ContainsKey(__instance.id)) times[__instance.id] = 20f;

        if (times[__instance.id] > 0)
        {
            times[__instance.id] -= pElapsed;
            return;
        }

        times[__instance.id] = 20f;

        Dictionary<WorldTile, string> can_produce = new Dictionary<WorldTile, string> { };

        foreach (Building building in __instance.buildings)
        {
            BuildingAsset buildingAsset = building.asset;
            if (buildingAsset == null) continue;

            switch (buildingAsset.type)
            {
                case "type_tankfactory":
                    can_produce.Add(building.current_tile, "warbox_tank");
                    break;
                default:
                    break;
            }
        }

        if (can_produce.Count == 0) return;

        int people = __instance.getPopulationPeople();
        int total_vehicles = 0;

        int vehicle_count = Math.Max(people / 25, 0);
        foreach (Actor actor in __instance.units) if (actor.hasTrait("warbox_unit")) total_vehicles++;


        if (total_vehicles > vehicle_count) return;

        foreach (KeyValuePair<WorldTile, string> pair in can_produce)
        {
            if (total_vehicles > vehicle_count) break;

            WorldTile tile = pair.Key;
            if (tile == null) continue;

            ActorAsset asset = AssetManager.actor_library.get(pair.Value);
            if (asset == null) continue;
            if (__instance.getResourcesAmount("common_metals") < asset.cost.common_metals) continue;
            __instance.takeResource("common_metals", asset.cost.common_metals);

            Actor unit = World.world.units.createNewUnit(
                pair.Value,
                tile,
                pMiracleSpawn: false,
                0f,
                null,
                null,
                pSpawnWithItems: false
            );

            unit.makeWait(1f);
            unit.setKingdom(__instance.kingdom);
            unit.setCity(__instance);
        }
    }
}

[HarmonyPatch(typeof(ActorAnimationLoader), nameof(ActorAnimationLoader.loadAnimationBoat))]
public static class Patch_ActorAnimationLoader_Fix
{
    static bool Prefix(string pTexturePath)
    {
        if (SpriteTextureLoader.getSpriteList("actors/boats/" + pTexturePath).Length == 0)
            return false;
        return true;
    }
}


[HarmonyPatch(typeof(Actor), "setFamily")]
public static class Patch_Actor_Exclude_WarBoxUnit_Family
{
    static bool Prefix(Actor __instance, Family pObject)
    {
        if (__instance.hasTrait("warbox_unit"))
            return false;
        return true;
    }
}


[HarmonyPatch(typeof(Kingdom), "setKing")]
public static class Patch_Kingdom_Exclude_WarBoxUnit_King
{
    static bool Prefix(Kingdom __instance, Actor pActor, bool pFromLoad)
    {
        if (pActor.hasTrait("warbox_unit"))
            return false;
        return true;
    }
}



[HarmonyPatch(typeof(City), "setLeader")]
public static class Patch_City_Exclude_WarBoxUnit_Leader
{
    static bool Prefix(City __instance, Actor pActor, bool pNew)
    {
        if (pActor.hasTrait("warbox_unit"))
            return false;
        return true;
    }
}



[HarmonyPatch(typeof(TileZone), nameof(TileZone.canBeClaimedByCity))]
public static class Patch_TileZone_CanBeClaimedByCity_WarBoxUnit
{
    static bool Prefix(TileZone __instance, City pCity, ref bool __result)
    {
        if (pCity != null && pCity.leader != null && pCity.leader.hasTrait("warbox_unit"))
        {
            __result = false;
            return false;
        }
        return true;
    }
}


[HarmonyPatch(typeof(TileZone), "isGoodForNewCity", new[] { typeof(Actor) })]
public static class Patch_TileZone_IsGoodForNewCity_WarBoxUnit
{
    static bool Prefix(TileZone __instance, Actor pActor, ref bool __result)
    {
        if (pActor != null && pActor.hasTrait("warbox_unit"))
        {
            __result = false;
            return false;
        }

        return true;
    }
}

[HarmonyPatch(typeof(Clan), "newClan")]
public static class Patch_Clan_NewClan
{
    static bool Prefix(Actor pFounder, bool pAddDefaultTraits)
    {
        return pFounder != null && !pFounder.hasTrait("warbox_unit");
    }
}


[HarmonyPatch(typeof(ai.behaviours.BehFightCheckEnemyIsOk), "execute")]
public static class BehFightCheckEnemyIsOk_Patch
{
    static bool Prefix(Actor pActor, ref BehResult __result)
    {
        if (!pActor.has_attack_target || !pActor.isEnemyTargetAlive())
        {
            __result = BehResult.Stop;
            return false;
        }

        Actor tTarget = pActor.attack_target as Actor;
        if (tTarget == null)
        {
            __result = BehResult.Stop;
            return false;
        }

        bool isValidMilitaryTarget = tTarget.isWarrior()
            || (tTarget.profession_asset != null && (
                tTarget.profession_asset.profession_id == UnitProfession.King ||
                tTarget.profession_asset.profession_id == UnitProfession.Leader))
            || tTarget.hasTrait("warbox_unit")
            || tTarget.hasTrait("boat")
            || tTarget.asset.is_boat;

        if (pActor.hasTrait("warbox_unit") && !isValidMilitaryTarget)
        {
            pActor.ignoreTarget(tTarget);
            pActor.clearAttackTarget();
            __result = BehResult.Stop;
            return false;
        }

        if (tTarget.isKingdomCiv() && tTarget.hasCity() && !isValidMilitaryTarget)
        {
            pActor.ignoreTarget(tTarget);
            pActor.clearAttackTarget();
            __result = BehResult.Stop;
            return false;
        }

        Kingdom actorKingdom = pActor.kingdom;
        if (pActor.hasTrait("warbox_unit") && pActor.city != null)
        {
            actorKingdom = pActor.city.kingdom;
        }

        if (!actorKingdom.isEnemy(tTarget.kingdom))
        {
            pActor.clearAttackTarget();
            __result = BehResult.Stop;
            return false;
        }

        if (!pActor.canAttackTarget(tTarget))
        {
            pActor.ignoreTarget(tTarget);
            pActor.clearAttackTarget();
            __result = BehResult.Stop;
            return false;
        }

        if (!pActor.isInAttackRange(tTarget))
        {
            if ((pActor.isWaterCreature() && (!tTarget.isInLiquid() && !pActor.asset.force_land_creature)) || tTarget.isFlying() ||
                (!pActor.isWaterCreature() && tTarget.isInLiquid()))
            {
                pActor.ignoreTarget(tTarget);
                pActor.clearAttackTarget();
                __result = BehResult.Stop;
                return false;
            }
        }

        if (Toolbox.Dist(pActor.chunk.x, pActor.chunk.y, tTarget.chunk.x, tTarget.chunk.y) >= SimGlobals.m.unit_chunk_sight_range + 1f)
        {
            pActor.clearAttackTarget();
            __result = BehResult.Stop;
            return false;
        }

        pActor.beh_actor_target = tTarget;
        __result = BehResult.Continue;
        return false;
    }
}



[HarmonyPatch(typeof(UtilityBasedDecisionSystem), "registerBasicDecisionLists")]
public static class Patch_UtilityBasedDecisionSystem_RegisterBasicDecisionLists
{
    static bool Prefix(Actor pActor, bool pGameplay)
    {
        if (pActor.asset.is_boat || pActor.hasTrait("warbox_unit"))
        {
            return false;
        }
        return true;
    }
}

[HarmonyPatch(typeof(ItemCrafting), nameof(ItemCrafting.tryToCraftRandomWeapon))]
public class Patch_TryToCraftRandomWeapon
{
    static bool Prefix(Actor pActor, City pCity)
    {
        if (pActor == null)
        {
            return false;
        }
        if (pActor.hasTrait("warbox_unit"))
        {
            return false;
        }

        if (pActor.equipment?.getSlot(EquipmentType.Weapon) == null)
        {
            return false;
        }

        return true;
    }
}


[HarmonyPatch]
public static class Patch_ItemCrafting_ExcludeWarBoxUnit
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemCrafting), nameof(ItemCrafting.tryToCraftRandomWeapon))]
    public static bool Prefix_Weapon(Actor pActor, City pCity)
    {
        return isSafeToCraft(pActor, EquipmentType.Weapon);
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemCrafting), nameof(ItemCrafting.tryToCraftRandomArmor))]
    public static bool Prefix_Armor(Actor pActor, City pCity)
    {
        return isSafeToCraft(pActor, EquipmentType.Armor);
    }

    private static bool isSafeToCraft(Actor pActor, EquipmentType type)
    {
        if (pActor == null || pActor.hasTrait("warbox_unit"))
            return false;

        if (pActor.equipment == null)
            return false;

        if (pActor.equipment.getSlot(type) == null)
            return false;

        return true;
    }
}

[HarmonyPatch(typeof(CityBehBuild), "upgradeBuilding")]
public static class Patch_CityBehBuild
{
    static bool Prefix(Building pBuilding, City pCity)
    {
        string upgrade_to = pBuilding.asset.upgrade_to;
        BuildingAsset buildingAsset = AssetManager.buildings.get(upgrade_to);
        if (buildingAsset == null)
        {
            WarBox.LogInfo("Building asset is null for upgrade_to: " + pBuilding.asset.id);
            WarBox.LogInfo("Building asset is null for upgrade_to: " + pBuilding.asset.type);
        }
        return true;
    }
}