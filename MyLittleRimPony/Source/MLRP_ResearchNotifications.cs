using System.Collections.Generic;
using RimWorld;
using Verse;

public class MLRP_ResearchTracker : GameComponent
{
    private HashSet<string> completedResearches = new HashSet<string>();

    // Lists of research to track
    private List<string> researchesToTrackFE = new List<string>
    {
        "Devilstrand"
    };
	
    private List<string> researchesToTrackDB = new List<string>
    {
        "Brewing",
        "Fabrication",
        "AdvancedFabrication"
    };
	
    private List<string> researchesToTrackNMM  = new List<string>
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
		"RM_SunBlocker" // Reinforced Mechanoids 2
    };

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

    public override void GameComponentTick()
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
                else if (!ResearchProjectDef.Named("HospitalBed").IsFinished)
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
