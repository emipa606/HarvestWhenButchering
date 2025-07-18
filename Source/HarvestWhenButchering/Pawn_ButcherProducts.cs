using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace HarvestWhenButchering;

[HarmonyPatch(typeof(Pawn), nameof(Pawn.ButcherProducts))]
public static class Pawn_ButcherProducts
{
    private static readonly MethodInfo resourceAmountMethod =
        AccessTools.PropertyGetter(typeof(CompHasGatherableBodyResource), "ResourceAmount");

    private static readonly MethodInfo resourceDefField =
        AccessTools.PropertyGetter(typeof(CompHasGatherableBodyResource), "ResourceDef");

    private static void gather(CompHasGatherableBodyResource comp, Pawn doer, float efficiency)
    {
        var animalYield = doer.GetStatValue(StatDefOf.AnimalGatherYield);
        if (!Rand.Chance(animalYield))
        {
            return;
        }

        var baseValue = (int)resourceAmountMethod.Invoke(comp, null) * comp.Fullness * efficiency;

        if (comp.parent is not Pawn pawn || pawn.Faction == null || pawn.Suspended)
        {
            return;
        }

        if (pawn.Faction?.IsPlayer == false)
        {
            baseValue *= HarvestWhenButcheringMod.Instance.Settings.WildAnimalFactor;
        }

        var i = GenMath.RoundRandom(baseValue);
        var resourceDef = (ThingDef)resourceDefField.Invoke(comp, null);
        if (resourceDef == null)
        {
            return;
        }

        while (i > 0)
        {
            var num = Mathf.Clamp(i, 1, resourceDef.stackLimit);
            i -= num;
            var thing = ThingMaker.MakeThing(resourceDef);
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