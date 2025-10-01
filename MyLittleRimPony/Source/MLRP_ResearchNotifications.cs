using HarmonyLib;
using MLRP_ModSettings;
using RimWorld;
using System.Reflection;
using Verse;

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
    // Should only send letters if the corresponding DLC/mod is enabled.

    [HarmonyPatch(typeof(ResearchManager), "FinishProject")]
    public static class MLRP_ResearchTracker
    {
        private static void Postfix(ResearchProjectDef proj)
        {
            // VARIABLES

            LetterDef MLRP_NewRecipeUnlocked = LetterDefOf.PositiveEvent;
            string LetterTitle = "MLRP_NewRecipeUnlockedTitle".Translate();

            string DBRecipeUnlocked = "";
            string NMMRecipeUnlocked = "";
            string PBRecipeUnlocked = "";
            string FERecipeUnlocked = "";
            string TPRecipeUnlocked = "";
            string SERecipeUnlocked = "";
            string THRecipeUnlocked = "";
            string NVRecipeUnlocked = "";

            var LettersEnabled = LoadedModManager.GetMod<MLRP_SettingsWindow>().GetSettings<MLRP_Settings>().enableResearchLetters;

            // DAYBREAKER: CORE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Brewing"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_CreateTwentyFiveWort").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_CreateTwoHundredFiftyBeer").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoBeer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertBeerIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);

                if (LettersEnabled == true)
                {
                    Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
                }
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Fabrication"))
            {
				DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_CreateComponentIndustrial").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_CreateComponentIndustrialTen").label;
				string DBLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked);
				
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, DBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("AdvancedFabrication"))
            {
				DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_CreateComponentSpacer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_CreateComponentSpacerTen").label;
				string DBLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked);
                
				if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, DBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("DrugProduction"))
            {
				
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakePoisonJokeJoint").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakeSmokeleafJoints").label;
                PBRecipeUnlocked = DefDatabase<ThingDef>.GetNamed("MLRP_PoisonJokeJoint").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_Luciferium").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_Neutroamine").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoPoisonJoke").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertPoisonJokeIntoSilver").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoSmokeleaf").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSmokeleafIntoSilver").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoAmbrosia").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertAmbrosiaIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_PBLetterText".Translate(PBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);
                if (LettersEnabled == true)
                {
                    Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
                }
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("PsychiteRefining"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakeFlake").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakeYayo").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoYayo").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertYayoIntoSilver").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoFlake").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertFlakeIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);
				
				if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("WakeUpProduction"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakeWakeUp").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoWakeUp").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertWakeUpIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);

                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("PenoxycylineProduction"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakePenoxycyline").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoPenoxycyline").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertPenoxycylineIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);
				
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("GoJuiceProduction"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakeGoJuice").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoGoJuice").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertGoJuiceIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("PsychoidBrewing"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_MakePsychiteTea").label;
                THRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertSilverIntoPsychiteTea").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_TH_ConvertPsychiteTeaIntoSilver").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_THLetterText".Translate(THRecipeUnlocked);
                
				if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // DAYBREAKER: BIOTECH DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("WastepackAtomizer"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_ToxicWasteRemoval").label;
                string DBLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, DBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // DAYBREAKER: ANOMALY DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("BioferriteShaping"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_ConvertSilverIntoBioferrite").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_ConvertBioferriteIntoSilver").label;
                string DBLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, DBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // DAYBREAKER: VANILLA RECYCLING EXPANDED MOD

            if (ModsConfig.IsActive("VanillaExpanded.Recycling") && proj == DefDatabase<ResearchProjectDef>.GetNamed("VRecyclingE_ComplexRecycling"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_VAE_BulkCreateTrashbrick").label;
                SERecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_SE_BuyTrashbricks").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_SE_SellTrashbricks").label;
                string MultLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked) + "\n\n" + "MLRP_SELetterText".Translate(SERecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // DAYBREAKER: DUBS BAD HYGIENE MOD

            if (ModsConfig.IsActive("Dubwise.DubsBadHygiene") && proj == DefDatabase<ResearchProjectDef>.GetNamed("BiofuelRefining"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_FecalSludge").label;
                string DBLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, DBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // PONY WORKBENCH: CORE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_PlushieRecycling"))
            {
                PBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_RecyclePlushies").label;
                string PBLetterText = "MLRP_PBLetterText".Translate(PBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, PBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_CurePoisonJokeAddictionResearch"))
            {
                PBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_MakeHerbalCureKit").label;
                string PBLetterText = "MLRP_PBLetterText".Translate(PBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, PBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Gunsmithing"))
            {
                PBRecipeUnlocked = DefDatabase<ThingDef>.GetNamed("Izzy_SmokeLauncher").label;
                string PBLetterText = "MLRP_PBLetterText".Translate(PBRecipeUnlocked);
                Find.LetterStack.ReceiveLetter(LetterTitle, PBLetterText, MLRP_NewRecipeUnlocked);
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_WeaponisedElementsResearch"))
            {
                PBRecipeUnlocked = DefDatabase<ThingDef>.GetNamed("MLRP_ElementsOfHarmonyWeaponised").label;
                string PBLetterText = "MLRP_PBLetterText".Translate(PBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, PBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // PONY WORKBENCH: COMBAT EXTENDED MOD

            if (ModsConfig.IsActive("CETeam.CombatExtended") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_CE_AmmoResearch"))
            {
                PBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MakeAmmo_CadenceJavelin").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MakeAmmo_HarmonyLaser").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MakeAmmo_HarmonyLaser_Sabot").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MakeAmmo_TennisBalls").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MakeAmmo_WoodenBullets").label;
                string PBLetterText = "MLRP_PBLetterText".Translate(PBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, PBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // FABRIC EXCHANGE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Devilstrand"))
            {
                FERecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_FE_DevilstrandCloth").label;
                string FELetterText = "MLRP_FELetterText".Translate(FERecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, FELetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // NIGHTMARE MOON: CORE

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("ShipComputerCore"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_AIPersonaCore").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MedicineProduction"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_GlitterworldMedicine").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Mortars"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_AntigrainWarhead").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ReinforcedBarrel").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("Bionics"))
            {
                if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
                {
                    NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicEye").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicArm").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicLeg").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicSpine").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicHeart").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicStomach").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicEar").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicTongue").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicJaw").label;
                    string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
					if (LettersEnabled == true)
					{
						Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
					}
                }
                else
                {
                    NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicEye").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicArm").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicLeg").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicSpine").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicHeart").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicStomach").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicEar").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicTongue").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicJaw").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_POTR_NMM_BionicWing").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_POTR_NMM_BionicHorn").label;
                    string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
					if (LettersEnabled == true)
					{
						Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
					}
                }
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_MagicMirrorResearch"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_SunsetShimmer").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_ArchotechResearch"))
            {
                if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
                {
                    NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArchotechArm").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArchotechEye").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArchotechLeg").label;
                    string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
					if (LettersEnabled == true)
					{
						Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
					}
                }
                else
                {
                    NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArchotechArm").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArchotechEye").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArchotechLeg").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_POTR_NMM_ArchotechWing").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_POTR_NMM_ArchotechHorn").label;
                    string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
					if (LettersEnabled == true)
					{
						Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
					}
                }
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_GetSkilltrainersFromNMM"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ShootingSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_MeleeSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ConstructionSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_MiningSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_CookingSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_PlantSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_AnimalSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_CraftingSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArtisticSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_MedicineSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_SocialSkilltrainer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_IntellectualSkilltrainer").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // NIGHTMARE MOON: ROYALTY DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("HealingFactors"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_Coagulator").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_HealingEnhancer").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("NeuralComputation"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_Neurocalculator").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_LearningAssistant").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MolecularAnalysis"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_Immunoenhancer").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("SkinHardening"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ToughskinGland").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ArmorskinGland").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_StoneskinGland").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("FleshShaping"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_AestheticShaper").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_AestheticNose").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_LoveEnhancer").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("ArtificialMetabolism"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_DetoxifierStomach").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ReprocessorStomach").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_NuclearStomach").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("CircadianInfluence"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_CircadianAssistant").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_CircadianHalfCycler").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MLRP_PsychicItemsResearch"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_PsychicSensitizer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_PsychicHarmonizer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_PsychicReader").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (proj == DefDatabase<ResearchProjectDef>.GetNamed("HospitalBed"))
            {
				NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_MechSerumHealer").label;
				string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // NIGHTMARE MOON: BIOTECH DLC

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("StandardMechtech"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ControlSublinkStandard").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_MechGestationProcessor").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_SignalChip").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("HighMechtech"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_ControlSublinkHigh").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_RemoteRepairer").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_RemoteShielder").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_HighSubcore").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_PowerfocusChip").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("UltraMechtech"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_RepairProbe").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_NanostructuringChip").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("Deathrest"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_DeathrestCapacitySerum").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && proj == DefDatabase<ResearchProjectDef>.GetNamed("ToxFiltration"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_DetoxifierLung").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_DetoxifierKidney").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // NIGHTMARE MOON: MEDPOD MOD

            if (ModsConfig.IsActive("sumghai.medpod") && proj == DefDatabase<ResearchProjectDef>.GetNamed("AcceleratedCellularRegeneration"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_IsolinearProcessor").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
            }

            // NIGHTMARE MOON: REPLIMAT MOD

            if (ModsConfig.IsActive("sumghai.Replimat") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MolecularNutrientResequencing"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_IsolinearModule").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // NIGHTMARE MOON: BANDWIDTH ENHANCER MOD

            if (ModsConfig.IsActive("iexist.biotech.morebandwidth"))
            {
                if (proj == DefDatabase<ResearchProjectDef>.GetNamed("UltraMechtech"))
                {
                    NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BandwidthEnhancer").label;
                    string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
					if (LettersEnabled == true)
					{
						Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
					}
                }

                if (proj == DefDatabase<ResearchProjectDef>.GetNamed("AdvancedBandwidthEnhancer"))
                {
                    NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_HighMechBandwidthImprover").label;
                    string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
					if (LettersEnabled == true)
					{
						Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
					}
                }
            }

            // NIGHTMARE MOON: DUBS BAD HYGIENE MOD

            if (ModsConfig.IsActive("Dubwise.DubsBadHygiene") && proj == DefDatabase<ResearchProjectDef>.GetNamed("HygieneBionics"))
            {
                NMMRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_BionicBladder").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NMM_HygieneEnhancer").label;
                string NMMLetterText = "MLRP_NMMLetterText".Translate(NMMRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NMMLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // THINGPONE (REQUIRES ANOMALY DLC)

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("DeadlifeDust"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_Shell_Deadlife").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("SerumSynthesis"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_VoidsightSerum").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MetalbloodSerum"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_MetalbloodSerum").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("JuggernautSerum"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_JuggernautSerum").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("MindNumbSerum"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_MindNumbSerum").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("GhoulResurrection"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_GhoulResurrectionSerum").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly") && proj == DefDatabase<ResearchProjectDef>.GetNamed("RevenantInvisibility"))
            {
                TPRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_Thingpone_RevenantVertebrae").label;
                string TPLetterText = "MLRP_TPLetterText".Translate(TPRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, TPLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // SCREWBALL: HIGHER POWER MOD

            if (ModsConfig.IsActive("leion247612.HigherHPower") && proj == DefDatabase<ResearchProjectDef>.GetNamed("HP_AdvancedPower"))
            {
                LetterDef MLRP_ExtraScrewballOutput = LetterDefOf.PositiveEvent;
                string title = "MLRP_ExtraScrewballOutputTitle".Translate();
                string text = "MLRP_ExtraScrewballOutputText".Translate();
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(title, text, MLRP_ExtraScrewballOutput);
				}
            }

            // DAYBREAKER: RIMEFELLER MOD

            if (ModsConfig.IsActive("Dubwise.Rimefeller") && proj == DefDatabase<ResearchProjectDef>.GetNamed("SynthyleneProduction"))
            {
                DBRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_DB_ConvertSilverIntoSynthylene").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_DB_ConvertSynthyleneIntoSilver").label;
                string DBLetterText = "MLRP_DBLetterText".Translate(DBRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, DBLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // FABRIC EXCHANGE: RIMEFELLER MOD

            if (ModsConfig.IsActive("Dubwise.Rimefeller") && proj == DefDatabase<ResearchProjectDef>.GetNamed("SynthamideProduction"))
            {
                FERecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_FE_Rimefeller_Synthamide").label;
                string FELetterText = "MLRP_FELetterText".Translate(FERecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, FELetterText, MLRP_NewRecipeUnlocked);
				}
            }

            // NEBULA VEIL (REQUIRES ODYSSEY DLC)

            if (ModsConfig.IsActive("Ludeon.RimWorld.Odyssey") && proj == DefDatabase<ResearchProjectDef>.GetNamed("AdvancedGravtech"))
            {
                NVRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NV_GravlitePanels").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_NV_PilotAssistant").label;
                SERecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_SE_VacstoneBlocks").label + "\n" + DefDatabase<RecipeDef>.GetNamed("MLRP_SE_SellVacstoneBlocks").label;
                string MultLetterText = "MLRP_NVLetterText".Translate(NVRecipeUnlocked) + "\n\n" + "MLRP_SELetterText".Translate(SERecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, MultLetterText, MLRP_NewRecipeUnlocked);
				}
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Odyssey") && proj == DefDatabase<ResearchProjectDef>.GetNamed("Shuttles"))
            {
                NVRecipeUnlocked = DefDatabase<RecipeDef>.GetNamed("MLRP_NV_ShuttleEngine").label;
                string NVLetterText = "MLRP_NVLetterText".Translate(NVRecipeUnlocked);
                
                if (LettersEnabled == true)
                {
					Find.LetterStack.ReceiveLetter(LetterTitle, NVLetterText, MLRP_NewRecipeUnlocked);
				}
            }
        }
    }
}
