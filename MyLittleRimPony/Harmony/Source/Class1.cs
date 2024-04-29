﻿using RimWorld;
using System.Reflection;
using Verse;
using HarmonyLib;

namespace MLRP_ResearchTracker
{
    [StaticConstructorOnStartup]
    static class MLRP_HarmonyPatch
    {
        static MLRP_HarmonyPatch()
        {
            var rimpony_harmony = new Harmony("geodesicdragon.rimpony");
            rimpony_harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    // RESEARCH TRACKER
    // Only sends letters if the corresponding DLC/mod is enabled.

    [HarmonyPatch(typeof(ResearchManager), "FinishProject")]
        public static class MLRP_ResearchTracker
    {
        private static void Postfix(ResearchProjectDef proj)
        {
            // DAYBREAKER: CORE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Brewing") || proj == DefDatabase<ResearchProjectDef>.GetNamed("Fabrication") || proj == DefDatabase<ResearchProjectDef>.GetNamed("AdvancedFabrication"))
            {
                LetterDef MLRP_NewDBRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextDB".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewDBRecipe);
            }

            // DAYBREAKER: ANOMALY DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("BioferriteShaping"))
            {
                LetterDef MLRP_NewDBRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextDB".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewDBRecipe);
            }

            // FABRIC EXCHANGE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Devilstrand"))
            {
                LetterDef MLRP_NewFERecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextFE".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewFERecipe);
            }

            // NIGHTMARE MOON: CORE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("ShipComputerCore") || proj == DefDatabase<ResearchProjectDef>.GetNamed("MedicineProduction") || proj == DefDatabase<ResearchProjectDef>.GetNamed("DrugProduction") || proj == DefDatabase<ResearchProjectDef>.GetNamed("Mortars") || proj == DefDatabase<ResearchProjectDef>.GetNamed("Bionics") || proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_MagicMirrorResearch") || proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_ArchotechResearch") || proj == DefDatabase<ResearchProjectDef>.GetNamed("AdvancedBandwidthEnhancer"))
            {
                LetterDef MLRP_NewNMMRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextNMM".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewNMMRecipe);
            }

            // NIGHTMARE MOON: ROYALTY DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("HealingFactors") || proj == DefDatabase<ResearchProjectDef>.GetNamed("NeuralComputation") || proj == DefDatabase<ResearchProjectDef>.GetNamed("MolecularAnalysis") || proj == DefDatabase<ResearchProjectDef>.GetNamed("SkinHardening") || proj == DefDatabase<ResearchProjectDef>.GetNamed("FleshShaping") || proj == DefDatabase<ResearchProjectDef>.GetNamed("ArtificialMetabolism") || proj == DefDatabase<ResearchProjectDef>.GetNamed("CircadianInfluence"))
            {
                LetterDef MLRP_NewDBRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextDB".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewDBRecipe);
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("HospitalBed"))
            {
                if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty"))
                {
                    return; // Don't send a letter if the player researches hospital beds with Royalty enabled
                }
                else
                {
                    LetterDef MLRP_NewNMMRecipe = LetterDefOf.PositiveEvent;
                    string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                    string text = "MLRP_NewRecipeUnlockedTextNMM".Translate();
                    Find.LetterStack.ReceiveLetter(title, text, MLRP_NewNMMRecipe);
                }
            }

            // NIGHTMARE MOON: BIOTECH DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("StandardMechtech") || proj == DefDatabase<ResearchProjectDef>.GetNamed("HighMechtech") || proj == DefDatabase<ResearchProjectDef>.GetNamed("UltraMechtech") || proj == DefDatabase<ResearchProjectDef>.GetNamed("Deathrest") || proj == DefDatabase<ResearchProjectDef>.GetNamed("ToxFiltration"))
            {
                LetterDef MLRP_NewDBRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextDB".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewDBRecipe);
            }

            // NIGHTMARE MOON: MEDPOD MOD

            if (ModsConfig.IsActive("sumghai.medpod") && proj == DefDatabase<ResearchProjectDef>.GetNamed("AcceleratedCellularRegeneration"))
            {
                LetterDef MLRP_NewDBRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextDB".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewDBRecipe);
            }

            // NIGHTMARE MOON: REPLIMAT MOD

            if (ModsConfig.IsActive("sumghai.Replimat") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MolecularNutrientResequencing"))
            {
                LetterDef MLRP_NewDBRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextDB".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewDBRecipe);
            }

            // THINGPONE (REQUIRES ANOMALY DLC)

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("DeadlifeDust") || proj == DefDatabase<ResearchProjectDef>.GetNamed("SerumSynthesis") || proj == DefDatabase<ResearchProjectDef>.GetNamed("MetalbloodSerum") || proj == DefDatabase<ResearchProjectDef>.GetNamed("JuggernautSerum") || proj == DefDatabase<ResearchProjectDef>.GetNamed("MindNumbSerum") || proj == DefDatabase<ResearchProjectDef>.GetNamed("GhoulResurrection"))
            {
                LetterDef MLRP_NewTPRecipe = LetterDefOf.PositiveEvent;
                string title = "MLRP_NewRecipeUnlockedTitle".Translate();
                string text = "MLRP_NewRecipeUnlockedTextTP".Translate();
                Find.LetterStack.ReceiveLetter(title, text, MLRP_NewTPRecipe);
            }
        }
    }
}
