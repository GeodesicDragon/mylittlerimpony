using MyLittleRimPony;
using RimWorld;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace MLRP_ModSettings
{
    // Mod Settings Storage
    public class MLRP_Settings : ModSettings
    {
        // Note to self: Remember to add any new settings to the 'reset to default' code block!

        public bool enableResearchLetters = true;
        public int ingredientCount = 300;
        public int SunnyMinRaidThreat = 5000;
        public int craftingSkillRequirement = 5;
        public bool taintedOnDeath = true;
        public bool dbhPippIsShort = true;
        public float BronyCommonality = 0.1f;
        public float AntiBronyCommonality = 0.2f;
        public int DiscordBrightness = 8;
        public int DiscordStuff = 300;
        public int ScrewballStuff = 300;
        public int SisterStuff = 750;
        public int DBChemfuelCost = 50;
        public int SweetieBotRange = 46;
        public float SweetieBotAccuracyCE = 0.5f;
        public float SweetieBotAccuracyTouch = 0.3f;
        public float SweetieBotAccuracyShort = 0.4f;
        public float SweetieBotAccuracyMedium = 0.8f;
        public float SweetieBotAccuracyLong = 0.8f;
        public bool NRSpawnGlitterworld = false;
        public int NRSpawnAmount = 5;
        public int NRSpawnTime = 10;
        public int CiderSpawnAmount = 30;
        public int CiderSpawnTime = 30;
        public int DerpyMass = 300;
        public bool OldHPBonuses = false;
        public bool SBMechCluster = true;
        public bool SBMute = false;
        public bool NPCFactionNewGame = true;
        public bool DogFactionNewGame = true;
        public bool BatFactionNewGame = true;
        public int plushieRecycling = 75;
        public int TreeHuggerStuff = 200;
        public int ThingponeStuff = 250;
        public bool xenoChem = false;
        public bool useOldTSTex = false;
        public bool TreeOfHarmony = true;

        public void ResetToDefaults()
        {
            enableResearchLetters = true;
            ingredientCount = 300;
            SunnyMinRaidThreat = 5000;
            craftingSkillRequirement = 5;
            taintedOnDeath = true;
            dbhPippIsShort = true;
            BronyCommonality = 0.1f;
            AntiBronyCommonality = 0.2f;
            DiscordBrightness = 8;
            DiscordStuff = 300;
            ScrewballStuff = 300;
            SisterStuff = 750;
            DBChemfuelCost = 50;
            SweetieBotRange = 46;
            SweetieBotAccuracyCE = 0.5f;
            SweetieBotAccuracyTouch = 0.3f;
            SweetieBotAccuracyShort = 0.4f;
            SweetieBotAccuracyMedium = 0.8f;
            SweetieBotAccuracyLong = 0.8f;
            NRSpawnGlitterworld = false;
            NRSpawnAmount = 5;
            NRSpawnTime = 10;
            CiderSpawnAmount = 30;
            CiderSpawnTime = 30;
            DerpyMass = 300;
            OldHPBonuses = false;
            SBMechCluster = true;
            SBMute = false;
            NPCFactionNewGame = true;
            DogFactionNewGame = true;
            BatFactionNewGame = true;
            plushieRecycling = 75;
            TreeHuggerStuff = 200;
            ThingponeStuff = 250;
            xenoChem = false;
            useOldTSTex = false;
            TreeOfHarmony = true;
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref enableResearchLetters, "enableResearchLetters", true);
            Scribe_Values.Look(ref ingredientCount, "ingredientCount", 300);
            Scribe_Values.Look(ref SunnyMinRaidThreat, "SunnyMinRaidThreat", 5000);
            Scribe_Values.Look(ref craftingSkillRequirement, "craftingSkillRequirement", 5);
            Scribe_Values.Look(ref taintedOnDeath, "taintedOnDeath", true);
            Scribe_Values.Look(ref dbhPippIsShort, "dbhPippIsShort", true);
            Scribe_Values.Look(ref BronyCommonality, "BronyCommonality", 0.1f);
            Scribe_Values.Look(ref AntiBronyCommonality, "AntiBronyCommonality", 0.2f);
            Scribe_Values.Look(ref DiscordBrightness, "DiscordBrightness", 8);
            Scribe_Values.Look(ref DiscordStuff, "DiscordStuff", 300);
            Scribe_Values.Look(ref ScrewballStuff, "ScrewballStuff", 300);
            Scribe_Values.Look(ref SisterStuff, "SisterStuff", 750);
            Scribe_Values.Look(ref DBChemfuelCost, "DBChemfuelCost", 50);
            Scribe_Values.Look(ref SweetieBotRange, "SweetieBotRange", 46);
            Scribe_Values.Look(ref SweetieBotAccuracyCE, "SweetieBotAccuracyCE", 0.5f);
            Scribe_Values.Look(ref SweetieBotAccuracyTouch, "SweetieBotAccuracyTouch", 0.3f);
            Scribe_Values.Look(ref SweetieBotAccuracyShort, "SweetieBotAccuracyShort", 0.4f);
            Scribe_Values.Look(ref SweetieBotAccuracyMedium, "SweetieBotAccuracyMedium", 0.8f);
            Scribe_Values.Look(ref SweetieBotAccuracyLong, "SweetieBotAccuracyLong", 0.8f);
            Scribe_Values.Look(ref NRSpawnGlitterworld, "NRSpawnGlitterworld", false);
            Scribe_Values.Look(ref NRSpawnAmount, "NRSpawnAmount", 5);
            Scribe_Values.Look(ref NRSpawnTime, "NRSpawnTime", 10);
            Scribe_Values.Look(ref CiderSpawnAmount, "CiderSpawnAmount", 30);
            Scribe_Values.Look(ref CiderSpawnTime, "CiderSpawnTime", 30);
            Scribe_Values.Look(ref DerpyMass, "DerpyMass", 300);
            Scribe_Values.Look(ref OldHPBonuses, "OldHPBonuses", false);
            Scribe_Values.Look(ref SBMechCluster, "SBMechCluster", false);
            Scribe_Values.Look(ref SBMute, "SBMute", false);
            Scribe_Values.Look(ref NPCFactionNewGame, "NPCFactionNewGame", false);
            Scribe_Values.Look(ref DogFactionNewGame, "DogFactionNewGame", false);
            Scribe_Values.Look(ref BatFactionNewGame, "BatFactionNewGame", false);
            Scribe_Values.Look(ref plushieRecycling, "plushieRecycling", 75);
            Scribe_Values.Look(ref TreeHuggerStuff, "TreeHuggerStuff", 200);
            Scribe_Values.Look(ref ThingponeStuff, "ThingponeStuff", 250);
            Scribe_Values.Look(ref xenoChem, "xenoChem", false);
            Scribe_Values.Look(ref useOldTSTex, "useOldTSTex", false);
            Scribe_Values.Look(ref TreeOfHarmony, "TreeOfHarmony", true);
            base.ExposeData();
        }
    }

    // Settings Window
    public class MLRP_SettingsWindow : Mod
    {
        public static MLRP_Settings settings;
        private Vector2 scrollPosition = Vector2.zero;

        public MLRP_SettingsWindow(ModContentPack content) : base(content)
        {
            settings = GetSettings<MLRP_Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var MLRP_Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            Rect scrollRect = new Rect(inRect.x, inRect.y, inRect.width - 20f, inRect.height);
            float viewHeight = 2500f;
            Rect viewRect = new Rect(0f, 0f, scrollRect.width - 16f, viewHeight);
            Widgets.BeginScrollView(inRect, ref scrollPosition, viewRect);

            Listing_Standard MLRP_Options = new Listing_Standard();
            MLRP_Options.Begin(viewRect);

            Text.Font = GameFont.Small;
            MLRP_Options.Label("Version " + MLRP_Version);
            MLRP_Options.Label("MLRP_SettingsApplyOnClose".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_GeneralHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.CheckboxLabeled("enableResearchLettersExplanation".Translate(), ref settings.enableResearchLetters, "enableResearchLettersToolTip".Translate());

            MLRP_Options.Label("MLRP_SunnyMinRaidThreat".Translate(settings.SunnyMinRaidThreat));
            settings.SunnyMinRaidThreat = (int)MLRP_Options.Slider(settings.SunnyMinRaidThreat, 1000, 10000);

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_BuildingHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.Label("MLRP_DiscordStuff".Translate(settings.DiscordStuff));
            settings.DiscordStuff = (int)MLRP_Options.Slider(settings.DiscordStuff, 100, 1000);

            MLRP_Options.Label("MLRP_DiscordBrightness".Translate(settings.DiscordBrightness));
            settings.DiscordBrightness = (int)MLRP_Options.Slider(settings.DiscordBrightness, 8, 16);

            MLRP_Options.Label("MLRP_ScrewballStuff".Translate(settings.ScrewballStuff));
            settings.ScrewballStuff = (int)MLRP_Options.Slider(settings.ScrewballStuff, 100, 1000);

            MLRP_Options.Label("MLRP_DerpyMass".Translate(settings.DerpyMass));
            settings.DerpyMass = (int)MLRP_Options.Slider(settings.DerpyMass, 300, 1500);

            MLRP_Options.Label("MLRP_TreeHuggerStuff".Translate(settings.TreeHuggerStuff));
            settings.TreeHuggerStuff = (int)MLRP_Options.Slider(settings.TreeHuggerStuff, 100, 500);

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_PlushieHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.Label("MLRP_PlushieStuffNeeded".Translate(settings.ingredientCount));
            settings.ingredientCount = (int)MLRP_Options.Slider(settings.ingredientCount, 2, 750);
            MLRP_Options.Label("MLRP_ChangeNeedsRestart".Translate());

            MLRP_Options.Label("MLRP_PlushieSkillNeeded".Translate(settings.craftingSkillRequirement));
            settings.craftingSkillRequirement = (int)MLRP_Options.Slider(settings.craftingSkillRequirement, 0, 20);

            MLRP_Options.Label("MLRP_PlushieRecyling".Translate(settings.plushieRecycling));
            settings.plushieRecycling = (int)MLRP_Options.Slider(settings.plushieRecycling, 1, 375);

            MLRP_Options.CheckboxLabeled("MLRP_PlushiesTaintedOnDeath".Translate(), ref settings.taintedOnDeath);

            MLRP_Options.CheckboxLabeled("MLRP_OldTSTex".Translate(), ref settings.useOldTSTex);
            MLRP_Options.Label("MLRP_ChangeNeedsRestart".Translate());

            if (ModsConfig.IsActive("Dubwise.DubsBadHygiene"))
            {
                MLRP_Options.CheckboxLabeled("MLRP_DBHPippSetting".Translate(), ref settings.dbhPippIsShort, "MLRP_DBHPippExplanation".Translate());
            }

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_FactionHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.CheckboxLabeled("MLRP_NPCFaction".Translate(), ref settings.NPCFactionNewGame, "MLRP_FactionExplanation".Translate());
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech"))
            {
                MLRP_Options.CheckboxLabeled("MLRP_DogFaction".Translate(), ref settings.DogFactionNewGame, "MLRP_FactionExplanation".Translate());
            }
            if (ModsConfig.IsActive("sarg.alphagenes"))
            {
                MLRP_Options.CheckboxLabeled("MLRP_BatFaction".Translate(), ref settings.BatFactionNewGame, "MLRP_FactionExplanation".Translate());
            }

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_TraitHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.Label("MLRP_BronyTrait".Translate(settings.BronyCommonality.ToString("0.0")));
            settings.BronyCommonality = MLRP_Options.Slider(settings.BronyCommonality,0.1f, 1f);

            MLRP_Options.Label("MLRP_AntiBronyTrait".Translate(settings.AntiBronyCommonality.ToString("0.0")));
            settings.AntiBronyCommonality = MLRP_Options.Slider(settings.AntiBronyCommonality, 0.1f, 1f);

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_EvilSistersHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.Label("MLRP_SisterStuff".Translate(settings.SisterStuff));
            settings.SisterStuff = (int)MLRP_Options.Slider(settings.SisterStuff, 100, 1500);

            MLRP_Options.Label("MLRP_DBChemfuel".Translate(settings.DBChemfuelCost));
            settings.DBChemfuelCost = (int)MLRP_Options.Slider(settings.DBChemfuelCost, 2, 100);
            MLRP_Options.Label("MLRP_DBChemfuelExplanation".Translate());

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_SweetieBotHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.Label("MLRP_SBRange".Translate(settings.SweetieBotRange));
            settings.SweetieBotRange = (int)MLRP_Options.Slider(settings.SweetieBotRange, 40, 80);

            if (!ModsConfig.IsActive("CETeam.CombatExtended"))
            {
                MLRP_Options.Label("MLRP_SBTouch".Translate(settings.SweetieBotAccuracyTouch.ToString("0.0")));
                settings.SweetieBotAccuracyTouch = MLRP_Options.Slider(settings.SweetieBotAccuracyTouch, 0.1f, 1f);

                MLRP_Options.Label("MLRP_SBShort".Translate(settings.SweetieBotAccuracyShort.ToString("0.0")));
                settings.SweetieBotAccuracyShort = MLRP_Options.Slider(settings.SweetieBotAccuracyShort, 0.1f, 1f);

                MLRP_Options.Label("MLRP_SBMedium".Translate(settings.SweetieBotAccuracyMedium.ToString("0.0")));
                settings.SweetieBotAccuracyMedium = MLRP_Options.Slider(settings.SweetieBotAccuracyMedium, 0.1f, 1f);

                MLRP_Options.Label("MLRP_SBLong".Translate(settings.SweetieBotAccuracyLong.ToString("0.0")));
                settings.SweetieBotAccuracyLong = MLRP_Options.Slider(settings.SweetieBotAccuracyLong, 0.1f, 1f);
            }
            else if (ModsConfig.IsActive("CETeam.CombatExtended"))
            {
                MLRP_Options.Label("MLRP_SBCE".Translate(settings.SweetieBotAccuracyCE.ToString("0.0")));
                settings.SweetieBotAccuracyCE = MLRP_Options.Slider(settings.SweetieBotAccuracyCE, 0.1f, 1f);
            }

            MLRP_Options.Label("MLRP_HigherIsBetter".Translate());

            MLRP_Options.GapLine();

            Text.Font = GameFont.Medium;
            MLRP_Options.Label("MLRP_SpawnerHeader".Translate());
            Text.Font = GameFont.Small;

            MLRP_Options.CheckboxLabeled("MLRP_NRItemToSpawn".Translate(), ref settings.NRSpawnGlitterworld);

            MLRP_Options.Label("MLRP_NRSpawnAmount".Translate(settings.NRSpawnAmount));
            settings.NRSpawnAmount = (int)MLRP_Options.Slider(settings.NRSpawnAmount, 5, 30);

            MLRP_Options.Label("MLRP_NRSpawnTime".Translate(settings.NRSpawnTime));
            settings.NRSpawnTime = (int)MLRP_Options.Slider(settings.NRSpawnTime, 1, 30);

            MLRP_Options.Label("MLRP_CiderSpawnAmount".Translate(settings.CiderSpawnAmount));
            settings.CiderSpawnAmount = (int)MLRP_Options.Slider(settings.CiderSpawnAmount, 5, 50);

            MLRP_Options.Label("MLRP_CiderSpawnTime".Translate(settings.CiderSpawnTime));
            settings.CiderSpawnTime = (int)MLRP_Options.Slider(settings.CiderSpawnTime, 1, 30);

            MLRP_Options.GapLine();

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty"))
            {
                Text.Font = GameFont.Medium;
                MLRP_Options.Label("MLRP_RoyaltyHeader".Translate());
                Text.Font = GameFont.Small;

                MLRP_Options.CheckboxLabeled("MLRP_TreeOfHarmony".Translate(), ref settings.TreeOfHarmony);
                MLRP_Options.Label("MLRP_ChangeNeedsRestart".Translate());
            }

            MLRP_Options.GapLine();

            if (ModsConfig.IsActive("Ludeon.RimWorld.Ideology"))
            {
                Text.Font = GameFont.Medium;
                MLRP_Options.Label("MLRP_IdeologyHeader".Translate());
                Text.Font = GameFont.Small;

                MLRP_Options.CheckboxLabeled("MLRP_HPOldBonuses".Translate(), ref settings.OldHPBonuses, "MLRP_HPOldBonusesExp".Translate());
            }

            MLRP_Options.GapLine();

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech"))
            {
                Text.Font = GameFont.Medium;
                MLRP_Options.Label("MLRP_BiotechHeader".Translate());
                Text.Font = GameFont.Small;

                MLRP_Options.CheckboxLabeled("MLRP_SBMechCluster".Translate(), ref settings.SBMechCluster);
                MLRP_Options.CheckboxLabeled("MLRP_SBMute".Translate(), ref settings.SBMute);

                MLRP_Options.CheckboxLabeled("MLRP_XenoChem".Translate(), ref settings.xenoChem);
                MLRP_Options.Label("MLRP_XenoReminder".Translate());
            }

            MLRP_Options.GapLine();

            if (ModsConfig.IsActive("Ludeon.RimWorld.Anomaly"))
            {
                Text.Font = GameFont.Medium;
                MLRP_Options.Label("MLRP_AnomalyHeader".Translate());
                Text.Font = GameFont.Small;

				MLRP_Options.Label("MLRP_ThingponeStuff".Translate(settings.ThingponeStuff));
				settings.ThingponeStuff = (int)MLRP_Options.Slider(settings.ThingponeStuff, 100, 500);
            }

            MLRP_Options.GapLine();

            if (MLRP_Options.ButtonText("MLRP_DefaultSettings".Translate()))
            {
                Find.WindowStack.Add(Dialog_MessageBox.CreateConfirmation(
                    "MLRP_ConfirmReset".Translate(),
                    delegate
                    {
                        settings.ResetToDefaults();
                        MLRP_ApplySettings(); // <— reapply everything in-game
                        SoundDefOf.Click.PlayOneShotOnCamera();
                    }
                ));
            }

            MLRP_Options.End();
            Widgets.EndScrollView();
        }

        public override string SettingsCategory()
        {
            return "MLRP_ModName".Translate();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            MLRP_ApplySettings();
        }

        public static void MLRP_ApplySettings()
        {
            int BaseCount = settings.ingredientCount;
            int EOHCount = BaseCount * 6; // Making the Elements of Harmony uses 6 times more cloth than normal
            int CMCCount = BaseCount * 3; // Making the Cutie Mark Crusaders uses 3 times more cloth than normal
            int CMCCountChild = CMCCount / 2; // Half the value of the normal version
            int ChildCount = BaseCount / 2; // Making child-equippable plushies uses half as much cloth than normal
            float BronyTrait = settings.BronyCommonality;
            float AntiBronyTrait = settings.AntiBronyCommonality;
            int DiscordLampGR = settings.DiscordBrightness;
            int DiscordCost = settings.DiscordStuff;
            int ScrewballCost = settings.ScrewballStuff;
            int SisterCost = settings.SisterStuff;
            int ThingponeCost = settings.SisterStuff;
            int TreeHuggerCost = settings.TreeHuggerStuff;
            int DBChemfuelCost = settings.DBChemfuelCost;
            int DBChemfuelHalfCost = DBChemfuelCost / 2;
            int DBChemfuelDoubleCost = DBChemfuelCost * 2;
            int DBChemfuelTripleCost = DBChemfuelCost * 3;
            int DBChemfuelQuintupleCost = DBChemfuelCost * 5;
            int SBRange = settings.SweetieBotRange;
            float SBAccuracy = settings.SweetieBotAccuracyCE;
            float SBTouch = settings.SweetieBotAccuracyTouch;
            float SBShort = settings.SweetieBotAccuracyShort;
            float SBMedium = settings.SweetieBotAccuracyMedium;
            float SBLong = settings.SweetieBotAccuracyLong;
            int NRSpawnAmount = settings.NRSpawnAmount;
            int NRSpawnTime = settings.NRSpawnTime;
            int NRSpawnTicks = NRSpawnTime * 60000;
            int CiderSpawnAmount = settings.CiderSpawnAmount;
            int CiderSpawnTime = settings.CiderSpawnTime;
            int CiderSpawnTicks = CiderSpawnTime * 60000;
            int DerpyMass = settings.DerpyMass;
            int SunnyMinRaidThreat = settings.SunnyMinRaidThreat;
            int plushieRecyclingAmount = settings.plushieRecycling;

            // UPDATE TRAITS

            DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait").degreeDatas[0].commonality = BronyTrait; 
            DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait").degreeDatas[0].commonality = AntiBronyTrait;

            // UPDATE BUILDINGS

            DefDatabase<ThingDef>.GetNamed("MLRP_DiscordLamp").costStuffCount = DiscordCost;

            var DiscordLampDef = DefDatabase<ThingDef>.GetNamed("MLRP_DiscordLamp");
            if (DiscordLampDef != null)
            {
                var comp = DiscordLampDef.comps.FirstOrDefault(c => c is CompProperties_Glower) as CompProperties_Glower;
                if (comp != null)
                {
                    comp.glowRadius = DiscordLampGR;
                }
            }

            DefDatabase<ThingDef>.GetNamed("MLRP_DiscordLamp").specialDisplayRadius = DiscordLampGR;

            DefDatabase<ThingDef>.GetNamed("MLRP_ScrewballGenerator").costStuffCount = ScrewballCost;

            DefDatabase<ThingDef>.GetNamed("MLRP_Daybreaker").costStuffCount = SisterCost;
            DefDatabase<ThingDef>.GetNamed("MLRP_NightmareMoon").costStuffCount = SisterCost;

            DefDatabase<ThingDef>.GetNamed("MLRP_TreeHugger").costStuffCount = TreeHuggerCost;

            // UPDATE SUNNY STARSCOUT

            var SunnyDef = DefDatabase<StorytellerDef>.GetNamed("MLRP_Storyteller_Sunny");

            if (SunnyDef != null)
            {
                var comp = SunnyDef.comps.FirstOrDefault(c => c is StorytellerCompProperties_ThreatsGenerator) as StorytellerCompProperties_ThreatsGenerator;
                if (comp != null)
                {
                    comp.parms.minThreatPoints = SunnyMinRaidThreat;
                }
            }

            // UPDATE FACTIONS

            if (settings.NPCFactionNewGame == true)
            {
                DefDatabase<FactionDef>.GetNamed("MLRP_NPC_Faction").startingCountAtWorldCreation = 1;
            }
            else if (settings.NPCFactionNewGame == false)
            {
                DefDatabase<FactionDef>.GetNamed("MLRP_NPC_Faction").startingCountAtWorldCreation = 0;
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech"))
            {
                if (settings.DogFactionNewGame == true)
                {
                    DefDatabase<FactionDef>.GetNamed("MLRP_DiamondDog_Faction").startingCountAtWorldCreation = 1;
                }
                else if (settings.DogFactionNewGame == false)
                {
                    DefDatabase<FactionDef>.GetNamed("MLRP_DiamondDog_Faction").startingCountAtWorldCreation = 0;
                }
            }

            if (ModsConfig.IsActive("sarg.alphagenes"))
            {
                if (settings.BatFactionNewGame == true)
                {
                    DefDatabase<FactionDef>.GetNamed("MLRP_Batpony_Faction").startingCountAtWorldCreation = 1;
                }
                else if (settings.BatFactionNewGame == false)
                {
                    DefDatabase<FactionDef>.GetNamed("MLRP_Batpony_Faction").startingCountAtWorldCreation = 0;
                }
            }

            // UPDATE DERPY CARRY CAPACITY AND STUFF REQUIRED

            var DerpyDef = DefDatabase<ThingDef>.GetNamed("MLRP_DerpyHooves");
            if (DerpyDef != null)
            {
                var comp = DerpyDef.comps.FirstOrDefault(c => c is CompProperties_Transporter) as CompProperties_Transporter;
                if (comp != null)
                {
                    comp.massCapacity = DerpyMass;
                }
            }
            DerpyDef.costStuffCount = DerpyMass;

            // UPDATE CHEMFUEL COSTS

            foreach (string defName in HalfChemfuelRecipes)
                {
                    RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                    if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                    {
                        recipe.ingredients[0].SetBaseCount(DBChemfuelHalfCost);
                    }
                }

            foreach (string defName in RegularChemfuelRecipes)
            {
                RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                {
                    recipe.ingredients[0].SetBaseCount(DBChemfuelCost);
                }
            }

            foreach (string defName in DoubleChemfuelRecipes)
            {
                RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                {
                    recipe.ingredients[0].SetBaseCount(DBChemfuelDoubleCost);
                }
            }

            foreach (string defName in QuintupleChemfuelRecipes)
            {
                RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                {
                    recipe.ingredients[0].SetBaseCount(DBChemfuelQuintupleCost);
                }
            }

            // UPDATE SWEETIE BOT TURRET

            DefDatabase<ThingDef>.GetNamed("MLRP_SweetieBotTurret").Verbs[0].range = SBRange;

            if (!ModsConfig.IsActive("CETeam.CombatExtended"))
            {
                ThingDef SweetieBot = DefDatabase<ThingDef>.GetNamed("MLRP_Turret_SweetieBot");

               if (SweetieBot != null && SweetieBot.statBases != null)
                {
                    void SetStat(StatDef statDef, float newValue)
                    {
                        var mod = SweetieBot.statBases.FirstOrDefault(s => s.stat == statDef);
                        if (mod != null)
                        {
                            mod.value = newValue;
                        }
                        else
                        {
                            SweetieBot.statBases.Add(new StatModifier { stat = statDef, value = newValue });
                        }
                    }

                    SetStat(StatDefOf.AccuracyTouch, SBTouch);
                    SetStat(StatDefOf.AccuracyShort, SBShort);
                    SetStat(StatDefOf.AccuracyMedium, SBMedium);
                    SetStat(StatDefOf.AccuracyLong, SBLong);
                    SetStat(StatDefOf.ShootingAccuracyTurret, SBLong);
                }
            }
            else if (ModsConfig.IsActive("CETeam.CombatExtended"))
            {
                ThingDef SweetieBot = DefDatabase<ThingDef>.GetNamed("MLRP_Turret_SweetieBot");
                StatDef aimingAccuracy = DefDatabase<StatDef>.GetNamed("AimingAccuracy");

                if (aimingAccuracy != null)
                {
                    var mod = SweetieBot.statBases.FirstOrDefault(s => s.stat == aimingAccuracy);
                    if (mod != null)
                    {
                        mod.value = SBAccuracy;
                    }
                    else
                    {
                        SweetieBot.statBases.Add(new StatModifier
                        {
                            stat = aimingAccuracy,
                            value = SBAccuracy
                        });
                    }
                }
            }

            // UPDATE NURSE REDHEART

            var RedheartDef = DefDatabase<ThingDef>.GetNamed("MLRP_NurseRedheart");
            if (RedheartDef != null)
            {
                var comp = RedheartDef.comps.FirstOrDefault(c => c is CompProperties_Spawner) as CompProperties_Spawner;
                if (comp != null)
                {
                    comp.spawnCount = NRSpawnAmount;
                    comp.spawnIntervalRange.min = NRSpawnTicks;
                    comp.spawnIntervalRange.max = NRSpawnTicks;

                    if (settings.NRSpawnGlitterworld == true)
                    {
                        comp.thingToSpawn = DefDatabase<ThingDef>.GetNamed("MedicineUltratech");
                    }
                    else if (settings.NRSpawnGlitterworld == false)
                    {
                        comp.thingToSpawn = DefDatabase<ThingDef>.GetNamed("MedicineIndustrial");
                    }
                }
            }

            // UPDATE SSCS6K

            var CiderDef = DefDatabase<ThingDef>.GetNamed("MLRP_SSCS6K");
            if (CiderDef != null)
            {
                var comp = CiderDef.comps.FirstOrDefault(c => c is CompProperties_Spawner) as CompProperties_Spawner;
                if (comp != null)
                {
                    comp.spawnCount = CiderSpawnAmount;
                    comp.spawnIntervalRange.min = CiderSpawnTicks;
                    comp.spawnIntervalRange.max = CiderSpawnTicks;
                }
            }

            // UPDATE UNICORN TWILIGHT (REQUIRES A RIMWORLD OF MAGIC)

            if (ModsConfig.IsActive("Torann.ARimworldOfMagic"))
            {
                DefDatabase<ThingDef>.GetNamed("PonyPlush_UnicornTwilight").recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                DefDatabase<ThingDef>.GetNamed("PonyPlush_UnicornTwilight").apparel.careIfWornByCorpse = settings.taintedOnDeath;
            }

            // UPDATE PIPP PETALS (REQUIRES DUBS BAD HYGIENE)

            if (ModsConfig.IsActive("Dubwise.DubsBadHygiene"))
            {
                DefDatabase<ThingDef>.GetNamed("PonyPlush_PippPetals").recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                DefDatabase<ThingDef>.GetNamed("PonyPlush_PippPetals").apparel.careIfWornByCorpse = settings.taintedOnDeath;

                if (settings.dbhPippIsShort == true)
                {
                    DefDatabase<ThingDef>.GetNamed("PonyPlush_PippPetals").graphic.drawSize = new UnityEngine.Vector2(0.5f, 0.5f);
                }
                else if (settings.dbhPippIsShort == false)
                {
                    DefDatabase<ThingDef>.GetNamed("PonyPlush_PippPetals").graphic.drawSize = new UnityEngine.Vector2(1f, 1f);
                }
            }

            // UPDATE MEADOWBROOK (REQUIRES ALLERGIES)

            if (ModsConfig.IsActive("phil42.allergies"))
            {
                DefDatabase<ThingDef>.GetNamed("PonyPlush_Meadowbrook").recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                DefDatabase<ThingDef>.GetNamed("PonyPlush_Meadowbrook").apparel.careIfWornByCorpse = settings.taintedOnDeath;
            }

            // UPDATE PLUSHIES

            DefDatabase<ThingDef>.GetNamed("MLRP_ElementsOfHarmony").costStuffCount = EOHCount;
            DefDatabase<ThingDef>.GetNamed("PonyPlush_CutieMarkCrusaders").costStuffCount = CMCCount;

            DefDatabase<ThingDef>.GetNamed("MLRP_ElementsOfHarmony").recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
            DefDatabase<ThingDef>.GetNamed("PonyPlush_CutieMarkCrusaders").recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;

            foreach (string defName in CorePlushies)
            {
                ThingDef corePlush = DefDatabase<ThingDef>.GetNamed(defName);
                corePlush.recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                corePlush.apparel.careIfWornByCorpse = settings.taintedOnDeath;
            }

            // UPDATE PLUSHIE RECYCLING AMOUNT

            RecipeDef RecyleDef = DefDatabase<RecipeDef>.GetNamedSilentFail("MLRP_RecyclePlushies");
            if (RecyleDef != null)
            {
                var ext = RecyleDef.GetModExtension<RecyclePlushieExtension>();
                if (ext != null)
                {
                    ext.reclaimedAmount = settings.plushieRecycling;
                }
            }

            // APPLY ROYALTY SETTINGS

            if (ModsConfig.IsActive("Ludeon.RimWorld.Royalty"))
            {
                foreach (string defName in RoyaltyPlushies)
                {
                    ThingDef royaltyPlush = DefDatabase<ThingDef>.GetNamed(defName);
                    royaltyPlush.recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                    royaltyPlush.apparel.careIfWornByCorpse = settings.taintedOnDeath;
                }
            }

            // APPLY IDEOLOGY SETTINGS

            if (ModsConfig.IsActive("Ludeon.RimWorld.Ideology"))
            {
                foreach (string defName in IdeologyPlushies)
                {
                    ThingDef ideologyPlush = DefDatabase<ThingDef>.GetNamed(defName);
                    ideologyPlush.recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                    ideologyPlush.apparel.careIfWornByCorpse = settings.taintedOnDeath;
                }

                PreceptDef HarmonyPrecept = DefDatabase<PreceptDef>.GetNamed("MLRP_HarmonyPrecept");

                if (settings.OldHPBonuses == true)
                {
                    SetStatOffset(HarmonyPrecept, "PlantWorkSpeed", 0.25f);
                    SetStatOffset(HarmonyPrecept, "PlantHarvestYield", 0.25f);
                    SetStatOffset(HarmonyPrecept, "TameAnimalChance", 0.25f);
                    SetStatOffset(HarmonyPrecept, "TrainAnimalChance", 0.25f);
                    SetStatOffset(HarmonyPrecept, "AnimalGatherSpeed", 0.25f);
                    SetStatOffset(HarmonyPrecept, "AnimalGatherYield", 0.25f);
                    SetStatOffset(HarmonyPrecept, "SocialImpact", 0.25f);
                    SetStatOffset(HarmonyPrecept, "MoveSpeed", 1);
                    SetStatOffset(HarmonyPrecept, "MeleeHitChance", 5);
                    SetStatOffset(HarmonyPrecept, "MeleeHitChance", 5);
                    SetStatOffset(HarmonyPrecept, "ShootingAccuracyPawn", 5);
                    SetStatOffset(HarmonyPrecept, "TradePriceImprovement", 0.25f);
                    SetStatOffset(HarmonyPrecept, "ResearchSpeed", 0.25f);
                    SetStatOffset(HarmonyPrecept, "HackingSpeed", 0.25f);
                }
                else if (settings.OldHPBonuses == false)
                {
                    SetStatOffset(HarmonyPrecept, "PlantWorkSpeed", 0.1f);
                    SetStatOffset(HarmonyPrecept, "PlantHarvestYield", 0.1f);
                    SetStatOffset(HarmonyPrecept, "TameAnimalChance", 0.1f);
                    SetStatOffset(HarmonyPrecept, "TrainAnimalChance", 0.1f);
                    SetStatOffset(HarmonyPrecept, "AnimalGatherSpeed", 0.1f);
                    SetStatOffset(HarmonyPrecept, "AnimalGatherYield", 0.1f);
                    SetStatOffset(HarmonyPrecept, "SocialImpact", 0.1f);
                    SetStatOffset(HarmonyPrecept, "MoveSpeed", 0.5f);
                    SetStatOffset(HarmonyPrecept, "MeleeHitChance", 1);
                    SetStatOffset(HarmonyPrecept, "MeleeHitChance", 1);
                    SetStatOffset(HarmonyPrecept, "ShootingAccuracyPawn", 1);
                    SetStatOffset(HarmonyPrecept, "TradePriceImprovement", 0.1f);
                    SetStatOffset(HarmonyPrecept, "ResearchSpeed", 0.1f);
                    SetStatOffset(HarmonyPrecept, "HackingSpeed", 0.1f);
                }
            }

            // APPLY BIOTECH SETTINGS

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech"))
            {
                DefDatabase<ThingDef>.GetNamed("PonyPlush_CutieMarkCrusaders_Child").recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                DefDatabase<ThingDef>.GetNamed("PonyPlush_CutieMarkCrusaders_Child").costStuffCount = CMCCountChild;

                DefDatabase<PawnKindDef>.GetNamed("MLRP_SweetieBotMech").allowInMechClusters = settings.SBMechCluster;

                SoundDef SBCall = DefDatabase<SoundDef>.GetNamed("SweetieBotMech_Call");

                if (settings.SBMute == true)
                {
                    SBCall.subSounds[0].volumeRange.min = 0;
                    SBCall.subSounds[0].volumeRange.max = 0;
                }
                else if (settings.SBMute == false)
                {
                    SBCall.subSounds[0].volumeRange.min = 50;
                    SBCall.subSounds[0].volumeRange.max = 50;
                }

                foreach (string defName in BiotechPlushies)
                {
                    ThingDef biotechPlush = DefDatabase<ThingDef>.GetNamed(defName);
                    biotechPlush.recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                    biotechPlush.apparel.careIfWornByCorpse = settings.taintedOnDeath;
                }

                foreach (string defName in ChildPlushies)
                {
                    ThingDef childPlush = DefDatabase<ThingDef>.GetNamed(defName);
                    childPlush.recipeMaker.skillRequirements.FirstOrDefault(r => r.skill == SkillDefOf.Crafting).minLevel = settings.craftingSkillRequirement;
                    childPlush.apparel.careIfWornByCorpse = settings.taintedOnDeath;
                }

                foreach (string defName in QuintupleChemfuelRecipesBiotech)
                {
                    RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                    if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                    {
                        recipe.ingredients[0].SetBaseCount(DBChemfuelQuintupleCost);
                    }
                }

                XenotypeDef diamonddog = DefDatabase<XenotypeDef>.GetNamedSilentFail("MLRP_Xeno_DiamondDog");
                GeneDef dogDep = DefDatabase<GeneDef>.GetNamedSilentFail("ChemicalDependency_MLRP_PoisonJoke");

                XenotypeDef pegasus = DefDatabase<XenotypeDef>.GetNamedSilentFail("MLRP_Xeno_Pegasus");
                GeneDef pegDep = DefDatabase<GeneDef>.GetNamedSilentFail("ChemicalDependency_GoJuice");

                XenotypeDef unicorn = DefDatabase<XenotypeDef>.GetNamedSilentFail("MLRP_Xeno_Unicorn");
                GeneDef uniDep = DefDatabase<GeneDef>.GetNamedSilentFail("ChemicalDependency_WakeUp");

                if (settings.xenoChem == false)
                {
                    diamonddog.genes.Remove(dogDep);
                    pegasus.genes.Remove(pegDep);
                    unicorn.genes.Remove(uniDep);
                }
                else if (settings.xenoChem == true)
                {
                    // Re-add if missing
                    if (!diamonddog.genes.Contains(dogDep))
                    {
                        diamonddog.genes.Add(dogDep);
                    }
                    if (!pegasus.genes.Contains(pegDep))
                    {
                        pegasus.genes.Add(pegDep);
                    }
                    if (!unicorn.genes.Contains(uniDep))
                    {
                        unicorn.genes.Add(uniDep);
                    }
                }
            }

            // APPLY ANOMALY SETTINGS

            if (ModsConfig.IsActive("Ludeon.RimWorld.Animaly"))
            {
                DefDatabase<ThingDef>.GetNamed("MLRP_Thingpone").costStuffCount = ThingponeCost;

                foreach (string defName in TripleChemfuelRecipesAnomaly)
                {
                    RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                    if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                    {
                        recipe.ingredients[0].SetBaseCount(DBChemfuelTripleCost);
                    }
                }
            }

            // APPLY ODYSSEY SETTINGS

            if (ModsConfig.IsActive("Ludeon.RimWorld.Odyssey"))
            {
                foreach (string defName in RegularChemfuelRecipesOdyssey)
                {
                    RecipeDef recipe = DefDatabase<RecipeDef>.GetNamed(defName);
                    if (recipe != null && recipe.ingredients != null && recipe.ingredients.Count > 0)
                    {
                        recipe.ingredients[0].SetBaseCount(DBChemfuelCost);
                    }
                }
            }

            Log.Message("MLRP_SettingsApplied".Translate());
        }

        // Random stuff that is associated with the above
        // I've put it down here to keep things tidy...ish

        // Quick code for altering precepts
        // Should only be called if Ideology is enabled
        public static void SetStatOffset(PreceptDef precept, string statDefName, float value)
        {
            if (!ModsConfig.IsActive("Ludeon.RimWorld.Ideology"))
            {
                return;
            }
            else if (ModsConfig.IsActive("Ludeon.RimWorld.Ideology"))
            {
                StatDef stat = DefDatabase<StatDef>.GetNamedSilentFail(statDefName);
                if (stat == null || precept?.statOffsets == null) return;

                StatModifier mod = precept.statOffsets.FirstOrDefault(sm => sm.stat == stat);
                if (mod != null)
                    mod.value = value;
                else
                    precept.statOffsets.Add(new StatModifier { stat = stat, value = value });
            }
        }

        // LONG-ASS LIST OF RECIPES
        // IS ANYONE EVEN READING THIS?

        private static readonly string[] CorePlushies =
        {
            "PonyPlush_AppleBloom",
            "PonyPlush_Applejack",
            "PonyPlush_BigMacintosh",
            "PonyPlush_Cheerilee",
            "PonyPlush_DaringDo",
            "PonyPlush_Discord",
            "PonyPlush_FleurDeLis",
            "PonyPlush_Fluttershy",
            "PonyPlush_Haywick",
            "PonyPlush_IzzyMoonbow",
            "PonyPlush_MaudPie",
            "PonyPlush_PinkiePie",
            "PonyPlush_PrincessCadence",
            "PonyPlush_PrincessCelestia",
            "PonyPlush_PrincessLuna",
            "PonyPlush_RainbowDash",
            "PonyPlush_Rarity",
            "PonyPlush_Scootaloo",
            "PonyPlush_ShiningArmour",
            "PonyPlush_SpoiledRich",
            "PonyPlush_StarlightGlimmer",
            "PonyPlush_SweetieBelle",
            "PonyPlush_TwilightSparkle",
        };

        private static readonly string[] RoyaltyPlushies =
        {
            "PonyPlush_AloeAndLotus",
            "PonyPlush_Trixie",
        };

        private static readonly string[] IdeologyPlushies =
        {
            "PonyPlush_FlimAndFlam",
            "PonyPlush_KingSombra",
            "PonyPlush_QueenChrysalis",
            "PonyPlush_Zecora",
        };

        private static readonly string[] BiotechPlushies =
        {
            "PonyPlush_ButtonMash",
        };

        private static readonly string[] ChildPlushies =
        {
            "PonyPlush_AppleBloom_Child",
            "PonyPlush_Cheerilee_Child",
            "PonyPlush_Discord_Child",
            "PonyPlush_IzzyMoonbow_Child",
            "PonyPlush_PrincessCadence_Child",
            "PonyPlush_PrincessCelestia_Child",
            "PonyPlush_PrincessLuna_Child",
            "PonyPlush_RainbowDash_Child",
            "PonyPlush_Scootaloo_Child",
            "PonyPlush_ShiningArmour_Child",
            "PonyPlush_SpoiledRich_Child",
            "PonyPlush_StarlightGlimmer_Child",
            "PonyPlush_SweetieBelle_Child",
            "PonyPlush_CombatRainbowDash",
        };

        private static readonly string[] HalfChemfuelRecipes =
        {
            "MLRP_DB_CreateTwoHundredFiftyBeer",
            "MLRP_DB_MakeFlake",
            "MLRP_DB_MakeGoJuice",
            "MLRP_DB_MakePenoxycyline",
            "MLRP_DB_MakePoisonJokeJoint",
            "MLRP_DB_MakePsychiteTea",
            "MLRP_DB_MakeSmokeleafJoints",
            "MLRP_DB_MakeWakeUp",
            "MLRP_DB_MakeYayo",
        };

        private static readonly string[] RegularChemfuelRecipes =
        {
            "MLRP_DB_CreateComponentIndustrial",
            "MLRP_DB_CreateComponentSpacer",
            "MLRP_DB_ConvertGoldIntoJade",
            "MLRP_DB_ConvertGoldIntoSteel",
            "MLRP_DB_ConvertGoldIntoPlasteel",
            "MLRP_DB_ConvertGoldIntoUranium",
            "MLRP_DB_ConvertSilverIntoJade",
            "MLRP_DB_ConvertSilverIntoSteel",
            "MLRP_DB_ConvertSilverIntoPlasteel",
            "MLRP_DB_ConvertSilverIntoUranium",
            "MLRP_DB_ConvertSilverIntoGold",
            "MLRP_DB_ConvertJadeIntoSilver",
            "MLRP_DB_ConvertSteelIntoSilver",
            "MLRP_DB_ConvertPlasteelIntoSilver",
            "MLRP_DB_ConvertUraniumIntoSilver",
            "MLRP_DB_ConvertGoldIntoSilver",
        };

        private static readonly string[] RegularChemfuelRecipesOdyssey =
        {
            "MLRP_DB_ConvertSilverIntoObsidian",
            "MLRP_DB_ConvertObsidianIntoSilver",
        };

        private static readonly string[] DoubleChemfuelRecipes =
        {
            "MLRP_DB_CreateComponentIndustrialTen",
            "MLRP_DB_CreateComponentSpacerTen",
        };

        private static readonly string[] TripleChemfuelRecipesAnomaly =
        {
            "MLRP_DB_ConvertSilverIntoBioferrite",
            "MLRP_DB_ConvertBioferriteIntoSilver",
        };

        private static readonly string[] QuintupleChemfuelRecipes =
        {
            "MLRP_DB_ConvertOneThousandGoldIntoSilver",
            "MLRP_DB_ConvertTenThousandSilverIntoGold",
        };

        private static readonly string[] QuintupleChemfuelRecipesBiotech =
        {
            "MLRP_DB_ToxicWasteRemoval",
        };
    }
}
