using NeoModLoader.General.Event.Handlers;
using NeoModLoader.General.Event.Listeners;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;


namespace WarBox.Content;

internal static class WarBoxActors
{
    public static void Init()
    {
        ActorAsset tank = new ActorAsset();
        tank.id = "warbox_tank";
    }
}

[HarmonyPatch(typeof(City), "update")]
public static class CityUpdate_Patch //adding units according to population
{
    static Dictionary<long, float> times = new Dictionary<long, float>();
    static void Prefix(City __instance, float pElapsed)
    {
        if (!times.ContainsKey(__instance.id)) times[__instance.id] = 20f;

        if (times[__instance.id] > 0)
        {
            times[__instance.id] -= pElapsed;
            return;
        }

        times[__instance.id] = 20f;

        List<string> can_produce = new List<string> { };

        foreach (Building building in __instance.buildings)
        {
            FieldInfo fieldInfo = typeof(Building).GetField("asset", BindingFlags.NonPublic | BindingFlags.Instance);
            BuildingAsset buildingAsset = fieldInfo?.GetValue(building) as BuildingAsset;
            if (buildingAsset == null) continue;

            string type = buildingAsset.type;
            switch (type)
            {
                case "type_tankfactory":
                    can_produce.Add("warbox_tank");
                    break;
                default:
                    break;
            }
        }

        if (can_produce.Count == 0) return;

        int people = __instance.getPopulationPeople();
        int total_vehicles = 0;

        int vehicle_count;
        if (people > 100)  vehicle_count = people / 100;
        else return;

        foreach (Actor actor in __instance.units)
        {
            if (actor.hasTrait("warbox_unit"))
            {
                total_vehicles++;
            }
        }

        if (total_vehicles < vehicle_count)
        {
            string to_produce = Randy.getRandom<string>(can_produce);
            WarBox.LogInfo(to_produce);
        }
    }
}