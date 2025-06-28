using Mlie;
using UnityEngine;
using Verse;

namespace HarvestWhenButchering;

[StaticConstructorOnStartup]
internal class HarvestWhenButcheringMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static HarvestWhenButcheringMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public HarvestWhenButcheringMod(ModContentPack content) : base(content)
    {
        Instance = this;
        Settings = GetSettings<HarvestWhenButcheringSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal HarvestWhenButcheringSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Harvest When Butchering";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        listingStandard.Label("HWB.WildAnimalFactor".Translate(), -1, "FHWB.WildAnimalFactorTT".Translate());
        Settings.WildAnimalFactor = Widgets.HorizontalSlider(listingStandard.GetRect(20),
            Settings.WildAnimalFactor, 0, 1f, false, Settings.WildAnimalFactor.ToStringPercent());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("HWB.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}