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
    public static HarvestWhenButcheringMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public HarvestWhenButcheringMod(ModContentPack content) : base(content)
    {
        instance = this;
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.Label("HWB.WildAnimalFactor".Translate(), -1, "FHWB.WildAnimalFactorTT".Translate());
        Settings.WildAnimalFactor = Widgets.HorizontalSlider(listing_Standard.GetRect(20),
            Settings.WildAnimalFactor, 0, 1f, false, Settings.WildAnimalFactor.ToStringPercent());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("HWB.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}