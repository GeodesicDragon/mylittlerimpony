// Decompiled with JetBrains decompiler
// Type: ResearchFinished.ResearchFinished
// Assembly: MyLittleRimPony, Version=3.91.102.0, Culture=neutral, PublicKeyToken=null
// MVID: 87877B54-16EA-4064-B632-262BD214ED29
// Assembly location: C:\Users\Panda\Desktop\MyLittleRimPony.dll

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace ResearchFinished
{
    public class ResearchFinished : GameComponent
    {
        private List<ResearchProjectDef> monitoredProjects = new List<ResearchProjectDef>();
        private HashSet<string> completedProjects = new HashSet<string>();
        private HashSet<string> letterReceived = new HashSet<string>();

        public ResearchFinished(Game game)
        {
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("Brewing"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("Fabrication"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("AdvancedFabrication"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("ShipComputerCore"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("MedicineProduction"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("DrugProduction"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("Mortars"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("MLRP_MagicMirrorResearch"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("Bionics"));
            monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("Devilstrand"));

            if (!ModsConfig.IsActive("Ludeon.RimWorld.Royalty"))
            {
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("HospitalBed"));
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty"))
            {
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("HealingFactors"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("NeuralComputation"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("MolecularAnalysis"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("SkinHardening"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("FleshShaping"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("ArtificialMetabolism"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("CircadianInfluence"));
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech"))
            {
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("StandardMechtech"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("HighMechtech"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("UltraMechtech"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("Deathrest"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("ToxFiltration"));
            }

            if (ModsConfig.IsActive("sumghai.Replimat"))
            {
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("MolecularNutrientResequencing"));
            }

            if (ModsConfig.IsActive("sumghai.medpod"))
            {
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("AcceleratedCellularRegeneration"));
            }

            if (!ModsConfig.IsActive("hlx.ReinforcedMechanoids2"))
            {
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("RM_WeatherController"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("RM_ClimateAdjuster"));
                monitoredProjects.Add(DefDatabase<ResearchProjectDef>.GetNamed("RM_SunBlocker"));
            }
        }

        public override void GameComponentTick()
        {
            base.GameComponentTick();
            foreach (ResearchProjectDef monitoredProject in monitoredProjects)
            {
                if (!completedProjects.Contains(monitoredProject.defName) && monitoredProject.IsFinished)
                {
                    if (monitoredProject.defName == "Brewing" || monitoredProject.defName == "Fabrication" || monitoredProject.defName == "AdvancedFabrication")
                    {
                        Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_DB".Translate(), LetterDefOf.PositiveEvent);
                    }
                    else if (monitoredProject.defName == "Devilstrand")
                    {
                        Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_FE".Translate(), LetterDefOf.PositiveEvent);
                    }
                    else if (monitoredProject.defName != "Brewing" && monitoredProject.defName != "Fabrication" && monitoredProject.defName != "AdvancedFabrication" && monitoredProject.defName != "Devilstrand")
                    {
                        Find.LetterStack.ReceiveLetter("MLRP_RecipeUnlockedLetterHeader".Translate(), "MLRP_RecipeUnlockedLetterText_NMM".Translate(), LetterDefOf.PositiveEvent);
                    }

                    completedProjects.Add(monitoredProject.defName);
                }
            }
        }
    }
}
