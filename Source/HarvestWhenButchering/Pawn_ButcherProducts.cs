using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace HarvestWhenButchering;

[HarmonyPatch(typeof(Pawn), "ButcherProducts")]
public static class Pawn_ButcherProducts
{
    private static void gather(CompHasGatherableBodyResource comp, Pawn doer, float efficiency)
    {
        if (!comp.Active)
        {
            return;
        }

        if (!Rand.Chance(doer.GetStatValue(StatDefOf.AnimalGatherYield)))
        {
            return;
        }

        var i = GenMath.RoundRandom(comp.ResourceAmount * comp.fullness * efficiency);
        while (i > 0)
        {
            var num = Mathf.Clamp(i, 1, comp.ResourceDef.stackLimit);
            i -= num;
            var thing = ThingMaker.MakeThing(comp.ResourceDef);
            thing.stackCount = num;
            GenPlace.TryPlaceThing(thing, doer.Position, doer.Map, ThingPlaceMode.Near);
        }
    }

    public static IEnumerable<Thing> Postfix(IEnumerable<Thing> values, Pawn butcher, float efficiency, Pawn __instance)
    {
        foreach (var thing in values)
        {
            yield return thing;
        }

        if (!__instance.AllComps.Any())
        {
            yield break;
        }

        foreach (var thingComp in __instance.AllComps)
        {
            if (!thingComp.GetType().IsSubclassOf(typeof(CompHasGatherableBodyResource)))
            {
                continue;
            }

            gather(thingComp as CompHasGatherableBodyResource, butcher, efficiency);
        }
    }
}