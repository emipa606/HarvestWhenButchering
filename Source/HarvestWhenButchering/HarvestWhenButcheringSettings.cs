using Verse;

namespace HarvestWhenButchering;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class HarvestWhenButcheringSettings : ModSettings
{
    public float WildAnimalFactor = 1f;
    private bool useButcherLogic = true;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref useButcherLogic, "UseButcherLogic", true);
        Scribe_Values.Look(ref WildAnimalFactor, "WildAnimalFactor", 1f);
    }
}