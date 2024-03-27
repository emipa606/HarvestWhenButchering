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
    private static readonly MethodInfo activeMethod =
        AccessTools.PropertyGetter(typeof(CompHasGatherableBodyResource), "Active");

    private static readonly MethodInfo resourceAmountMethod =
        AccessTools.PropertyGetter(typeof(CompHasGatherableBodyResource), "ResourceAmount");

    private static readonly FieldInfo fullnessField =
        AccessTools.Field(typeof(CompHasGatherableBodyResource), "fullness");

    private static readonly FieldInfo resourceDefField =
        AccessTools.Field(typeof(CompHasGatherableBodyResource), "ResourceDef");

    private static void gather(CompHasGatherableBodyResource comp, Pawn doer, float efficiency)
    {
        if ((bool)activeMethod.Invoke(comp, null) == false)
        {
            return;
        }

        if (!Rand.Chance(doer.GetStatValue(StatDefOf.AnimalGatherYield)))
        {
            return;
        }

        var baseValue = (int)resourceAmountMethod.Invoke(comp, null) * (float)fullnessField.GetValue(comp) * efficiency;
        if (comp.parent is not Pawn pawn || pawn.Faction?.IsPlayer == false)
        {
            baseValue *= HarvestWhenButcheringMod.instance.Settings.WildAnimalFactor;
        }

        var i = GenMath.RoundRandom(baseValue);
        var resourceDef = (ThingDef)resourceDefField.GetValue(comp);
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