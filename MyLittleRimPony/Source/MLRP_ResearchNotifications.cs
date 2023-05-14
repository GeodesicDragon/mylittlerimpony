// Having this enabled eats up a LOT of your TPS.
// Feel free to add it and recompile the DLL, but don't say I didn't warn you.
// As always, if you have a better way of doing this, then please let me know!

using System.Collections.Generic;
using RimWorld;
using Verse;

public class MLRP_ResearchTracker : GameComponent
{
    private HashSet<string> completedResearches = new HashSet<string>();

    // Research which unlocks recipes at the Fabric Exchange
    private List<string> researchesToTrackFE = new List<string>
    {
        "Devilstrand"
    };

	// Research which unlocks recipes at the Statue of Daybreaker
	
    private List<string> researchesToTrackDB = new List<string>
    {
        "Brewing",
        "Fabrication",
        "AdvancedFabrication"
    };

	// Research which unlocks recipes at the Statue of Nightmare Moon
    private List<string> researchesToTrackNMM = new List<string>
    {
        "ShipComputerCore",
        "MedicineProduction",
        "DrugProduction",
        "Mortars",
        "Bionics",
        "HospitalBed",
        "HealingFactors",
        "NeuralComputation",
        "MolecularAnalysis",
        "SkinHardening",
        "FleshShaping",
        "ArtificialMetabolism",
        "CircadianInfluence",
        "StandardMechtech",
        "HighMechtech",
        "UltraMechtech",
        "Deathrest",
        "ToxFiltration",
        "MLRP_MagicMirrorResearch", // My Little RimPony
        "MLRP_ArchotechResearch", // My Little RimPony
        "MolecularNutrientResequencing", // Replimat
		"AcceleratedCellularRegeneration", // MedPod
		"RM_WeatherController", // Reinforced Mechanoids 2
		"RM_ClimateAdjuster", // Reinforced Mechanoids 2
		"RM_SunBlocker", // Reinforced Mechanoids 2
        "AdvancedFabrication" // Vanilla Factions Expanded - Vikings
    };

	// Track research on Sweetie Bot mechanoids to send a brief letter about them when it's finished
    private List<string> otherResearchToTrack = new List<string>
    {
        "MLRP_SweetieBotMechResearch"
    };

    public MLRP_ResearchTracker(Game game) { }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref completedResearches, "completedResearches", LookMode.Value);
    }

    public override void GameComponentTick() // This is probably why it was eating so much CPU
    {
        base.GameComponentTick();

        foreach (var researchFE in researchesToTrackFE)
        {
            if (!completedResearches.Contains(researchFE) && ResearchProjectDef.Named(researchFE).IsFinished)
            {
                Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_FE".Translate(), LetterDefOf.PositiveEvent);
                completedResearches.Add(researchFE);
            }
        }

        foreach (var researchDB in researchesToTrackDB)
        {
            if (!completedResearches.Contains(researchDB) && ResearchProjectDef.Named(researchDB).IsFinished)
            {
                Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_DB".Translate(), LetterDefOf.PositiveEvent);
                completedResearches.Add(researchDB);
            }
        }

        foreach (var researchNMM in researchesToTrackNMM)
        {
            if (!completedResearches.Contains(researchNMM) && ResearchProjectDef.Named(researchNMM).IsFinished)
            {
                if (ResearchProjectDef.Named("HospitalBed").IsFinished)
                {
                    if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty"))
                    {
                        return; // Don't send a letter if the player researches hospital beds with Royalty enabled
                    }
                    else
                    {
                        Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_NMM".Translate(), LetterDefOf.PositiveEvent);
                        completedResearches.Add(researchNMM);
                    }
                }
                else if (ResearchProjectDef.Named("AdvancedFabrication").IsFinished)
                {
                    if (!ModsConfig.IsActive("OskarPotocki.VFE.Vikings"))
                    {
                        return; // Don't send a NMM letter when the player researches advanced fabrication without having Vanilla Factions Expanded - Vikings enabled
                    }
                    else
                    {
                        Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_NMM".Translate(), LetterDefOf.PositiveEvent);
                        completedResearches.Add(researchNMM);
                    }
                }
                else
                {
                    Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_NMM".Translate(), LetterDefOf.PositiveEvent);
                    completedResearches.Add(researchNMM);
                }
            }
        }

        foreach (var researchSBM in otherResearchToTrack)
        {
            if (!completedResearches.Contains(researchSBM) && ResearchProjectDef.Named(researchSBM).IsFinished)
            {
                Find.LetterStack.ReceiveLetter("MLRP_AboutSweetieBotMechLetterHeader".Translate(), "MLRP_AboutSweetieBotMechLetterText".Translate(), LetterDefOf.PositiveEvent);
                completedResearches.Add(researchSBM);
            }
        }
    }
}
