using System;
using UnityEngine;

namespace WarBox.Content;

internal static class WarBoxActions
{
    public static void ToggleFactories(bool pCurrentValue)
    {
        WarBox.warbox_factories = pCurrentValue;
        WarBox.LogInfo("Factories toggled to " + pCurrentValue);
    }

    public static void ToggleArmyLimit(bool pCurrentValue)
    {
        WarBox.warbox_army_limits = pCurrentValue;
        WarBox.LogInfo("Army Limits toggled to " + pCurrentValue);
    }

    public static void UpdateArmyPerPop(int pCurrentValue)
    {
        WarBox.warbox_army_per_pop = pCurrentValue;
        WarBox.LogInfo("Army Limits toggled to " + pCurrentValue);
    }

    public static bool LaunchATGM(Actor pSelf, Vector2 pTarget, WorldTile pTile = null)
    {
        Vector2Int pos = pTile.pos;
        Vector3 vector = pSelf.current_position;
        float pDist = Vector2.Distance(vector, pos);
        Vector3 newPoint = Toolbox.getNewPoint(vector.x, vector.y, pos.x, pos.y, pDist);
        Vector3 newPoint2 = Toolbox.getNewPoint(vector.x, vector.y, pos.x, pos.y, pSelf.a.stats["size"]);
        newPoint2.y += 0.5f;
        World.world.projectiles.spawn(pSelf, null, "rpg_projectile", newPoint2, newPoint);
        return true;
    }

    public static bool LaunchArtilleryStrike(BaseSimObject pTarget, WorldTile pTile = null)
    {
        if (pTarget == null || !pTarget.isActor())
            return false;

        Actor caster = pTarget.a;
        if (!caster.isAlive() || !caster.kingdom.hasEnemies())
            return false;

        if (caster.getStamina() < 100) return false;

        using (var enemies = caster.kingdom.getEnemiesKingdoms())
        {
            foreach (var enemyKingdom in enemies)
            {
                if (enemyKingdom.hasKing() && enemyKingdom.cities.Count > 0)
                {
                    var targetCity = enemyKingdom.cities.GetRandom();
                    if (targetCity == null)
                        continue;

                    float roll = UnityEngine.Random.value;
                    Vector2? attackPos = null;

                    if (attackPos == null && targetCity.hasArmy() && targetCity.army.countUnits() >= 15) attackPos = targetCity.army.getRandomUnit().current_position;
                    if (attackPos == null && targetCity.buildings.Count > 0)
                    {
                        var building = targetCity.buildings.GetRandom();
                        if (building != null && building.current_tile != null)
                            attackPos = building.current_tile.pos;
                    }
                    if (attackPos == null && targetCity.hasLeader() && targetCity.leader.isAlive()) attackPos = targetCity.leader.current_position;
                    if (attackPos == null && enemyKingdom.hasKing() && enemyKingdom.king.isAlive()) attackPos = enemyKingdom.king.current_position;
                    if (attackPos == null)
                    {
                        WorldTile tile = targetCity.getTile();
                        if (tile != null) attackPos = tile.pos;
                    }

                    if (attackPos == null) continue;

                    Vector3 selfPos = caster.current_position;
                    float dist = Vector2.Distance(selfPos, attackPos.Value);
                    if (dist < 100f || dist > 225f)
                        continue;

                    // projectile calculations untouched
                    Vector3 attackVector = Toolbox.getNewPoint(
                        selfPos.x, selfPos.y,
                        attackPos.Value.x, attackPos.Value.y,
                        dist
                    );

                    Vector3 startProjectile = Toolbox.getNewPoint(
                        selfPos.x, selfPos.y,
                        attackPos.Value.x, attackPos.Value.y,
                        caster.stats["size"]
                    );
                    startProjectile.y += 0.5f;

                    World.world.projectiles.spawn(caster, null, "cannon_shell", startProjectile, attackVector);
                    caster.punchTargetAnimation(attackVector, true, false, 45f);
                    caster.spendStamina(100);
                    return true;
                }
            }
        }
        return false;
    }

}