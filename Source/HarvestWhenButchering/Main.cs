using System.Reflection;
using HarmonyLib;
using Verse;

namespace HarvestWhenButchering;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("Mlie.HarvestWhenButchering").PatchAll(Assembly.GetExecutingAssembly());
    }
}
