// My Little RimPony - A RimWorld Mod
// Created by GeodesicDragon
// All aspects of MLP (except for Nurse Haywick) are property of Hasbro.
// Huge thanks to users of the official RimWorld Discord server for helping me with code.
// And also for being so damn patient with me while my slow brain figured it all out.
// I am always happy to accept updates to this code, especially if you have a better way of doing something I've done.
// Contact me via my Discord server and we'll talk! (Invite Code: BGKnpza)

using MLRP_ModSettings;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Verse;
using Verse.AI;

namespace MyLittleRimPony
{

    // GAME STARTUP

    [StaticConstructorOnStartup]
    public static class MLRP_Startup
    {
        static MLRP_Startup()
        {
            // DISPLAY WELCOME MESSAGE

            var MLRP_Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            Log.Message("MLRP_WelcomeMessage".Translate(MLRP_Version));

            if (ModsConfig.IsActive("geodesicdragon.rimpony.medieval"))
            {
                Log.Message("MLRP_MedievalOverhaul".Translate());
            }

            // APPLY MOD SETTINGS

            var MLRPOptions = LoadedModManager.GetMod<MLRP_SettingsWindow>();
            if (MLRPOptions != null)
            {
                // Access saved settings
                var settings = MLRP_SettingsWindow.settings;
                if (settings != null)
                {
                    MLRP_SettingsWindow.MLRP_ApplySettings();
                }
            }
        }
    }

    // ANTI BRONY PLUSHIE ALERT

    public class Alert_AntiBronyHasPlushie : Alert_Thought
    {
        protected override ThoughtDef Thought => DefDatabase<ThoughtDef>.GetNamed("MLRP_PonyPlushEquippedAntiBrony");

        public Alert_AntiBronyHasPlushie()
        {
            this.defaultLabel = "MLRP_AntiBronyHasPlushieAlert".Translate();
            this.explanationKey = "MLRP_AntiBronyHasPlushieExplanation";
        }
    }

    // ANTI BRONY HARMONY CHIP ALERT

    public class Alert_AntiBronyHasHarmonyChip : Alert_Thought
    {
        private bool royaltyActive;

        protected override ThoughtDef Thought
        {
            get
            {
                if (!royaltyActive)
                    return null;

                return DefDatabase<ThoughtDef>.GetNamed("MLRP_HarmonyChipInstalledAntiBrony", errorOnFail: false);
            }
        }

        public Alert_AntiBronyHasHarmonyChip()
        {
            royaltyActive = ModsConfig.IsActive("Ludeon.RimWorld.Royalty");

            if (royaltyActive)
            {
                this.defaultLabel = "MLRP_AntiBronyHasHarmonyChipAlert".Translate();
                this.explanationKey = "MLRP_AntiBronyHasHarmonyChipAlertText";
            }
        }

        public override AlertReport GetReport()
        {
            if (!royaltyActive)
                return false;

            return base.GetReport();
        }
    }

    // ANTI BRONIES DISLIKE BRONIES

    public class ThoughtWorker_AntiBronyVsBrony : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            if (!p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")))
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (!otherPawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
            {
                return false;
            }
            return true;
        }
    }

    public class Thought_AntiBronyVsBrony : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
            {
                return -10f;
            }
            return 0f;
        }
    }

    // BRONIES LIKE BRONIES

    public class ThoughtWorker_BronyLikesBrony : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            if (!p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (!otherPawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
            {
                return false;
            }
            return true;
        }
    }
    public class Thought_BronyLikesBrony : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
            {
                return 10f;
            }
            return 0f;
        }
    }

    // HERBAL CURE KIT

    public class PoisonJokeAddictionCure : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            List<Hediff> MLRP_HediffsToCheck = pawn.health.hediffSet.hediffs.ToList();
            foreach (Hediff hediff in MLRP_HediffsToCheck)
            {
                switch (hediff.def.defName)
                {
                    case "Flu":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "Animal_Flu":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "Malaria":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "FoodPoisoning":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "MLRP_PoisonJokeAddiction":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "MLRP_PoisonJokeTolerance":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "Plague":
                        System.Random PlagueCureChance = new System.Random();
                        int LuckyPlagueNumber = PlagueCureChance.Next(1, 11);
                        if (LuckyPlagueNumber == 7)
                        {
                            pawn.health.RemoveHediff(hediff);
                            Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        else if (LuckyPlagueNumber != 7)
                        {
                            Messages.Message("MLRP_CureFailed".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        break;
                    case "Animal_Plague":
                        System.Random AnimalPlagueCureChance = new System.Random();
                        int LuckyAnimalPlagueNumber = AnimalPlagueCureChance.Next(1, 11);
                        if (LuckyAnimalPlagueNumber == 7)
                        {
                            pawn.health.RemoveHediff(hediff);
                            Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        else if (LuckyAnimalPlagueNumber != 7)
                        {
                            Messages.Message("MLRP_CureFailed".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        break;
                    case "Diarrhea": // Dubs Bad Hygiene
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    default:
                        Log.Warning("MLRP_NothingToCure".Translate(pawn));
                        break;
                }
            }
        }
    }

    // POISON JOKE RANDOM EFFECT

    public class PoisonJokeSmoked : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            System.Random r = new System.Random();
            int n = r.Next(1, 18); // maxValue must always be one greater than the number of available hediffs, otherwise the first hediff will always be chosen.
            var affliction = "";

            switch (n)
            {
                case 1:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeIncreasedConsciousness"));
                    affliction = "MLRP_PoisonJokeGoodConsciousness".Translate(pawn);
                    break;
                case 2:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeReducedConsciousness"));
                    affliction = "MLRP_PoisonJokeBadConsciousness".Translate(pawn);
                    break;
                case 3:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeSuperSpeedy"));
                    affliction = "MLRP_PoisonJokeGoodSpeed".Translate(pawn);
                    break;
                case 4:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeSlowAndSluggish"));
                    affliction = "MLRP_PoisonJokeBadSpeed".Translate(pawn);
                    break;
                case 5:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeGoodManipulation"));
                    affliction = "MLRP_PoisonJokeGoodManipulation".Translate(pawn);
                    break;
                case 6:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokePoorManipulation"));
                    affliction = "MLRP_PoisonJokeBadManipulation".Translate(pawn);
                    break;
                case 7:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeIncreasedTalking"));
                    affliction = "MLRP_PoisonJokeGoodTalking".Translate(pawn);
                    break;
                case 8:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeReducedTalking"));
                    affliction = "MLRP_PoisonJokeBadTalking".Translate(pawn);
                    break;
                case 9:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeIncreasedEating"));
                    affliction = "MLRP_PoisonJokeGoodEating".Translate(pawn);
                    break;
                case 10:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeReducedEating"));
                    affliction = "MLRP_PoisonJokeBadEating".Translate(pawn);
                    break;
                case 11:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeSightBeyondSight"));
                    affliction = "MLRP_PoisonJokeGoodSight".Translate(pawn);
                    break;
                case 12:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeBlindness"));
                    affliction = "MLRP_PoisonJokeBadSight".Translate(pawn);
                    break;
                case 13:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeIncreasedHearing"));
                    affliction = "MLRP_PoisonJokeGoodHearing".Translate(pawn);
                    break;
                case 14:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeReducedHearing"));
                    affliction = "MLRP_PoisonJokeBadHearing".Translate(pawn);
                    break;
                case 15:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeIncreasedBreathing"));
                    affliction = "MLRP_PoisonJokeGoodBreathing".Translate(pawn);
                    break;
                case 16:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_PoisonJokeReducedBreathing"));
                    affliction = "MLRP_PoisonJokeBadBreathing".Translate(pawn);
                    break;
                case 17:
                    pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("MLRP_CutiePox"));
                    affliction = "MLRP_PoisonJokeCutiePox".Translate(pawn);
                    break;
            }
            if (n == 2 || n == 4 || n == 6 || n == 8 || n == 10 || n == 12 || n == 14 || n == 16 || n == 17)
            {
                LetterDef MLRP_PoisonJokeAfflictionLetter = LetterDefOf.ThreatSmall;
                string title = "MLRP_PoisonJokeLetterTitle".Translate();
                string text = affliction;
                Find.LetterStack.ReceiveLetter(title, text, MLRP_PoisonJokeAfflictionLetter);
            }
            else
            {
                LetterDef MLRP_PoisonJokeAfflictionLetter = LetterDefOf.NeutralEvent;
                string title = "MLRP_PoisonJokeLetterTitle".Translate();
                string text = affliction;
                Find.LetterStack.ReceiveLetter(title, text, MLRP_PoisonJokeAfflictionLetter);
            }
        }
    }

    // PORTAL ROOM

    public class RoomRoleWorker_PortalRoom : RoomRoleWorker
    {
        public override float GetScore(Room room)
        {
            int num = 0;
            List<Thing> andAdjacentThings = room.ContainedAndAdjacentThings;
            for (int index = 0; index < andAdjacentThings.Count; ++index)
            {
                if (andAdjacentThings[index].def == DefDatabase<ThingDef>.GetNamed("MLRP_MagicMirrorGenerator"))
                    ++num;
            }
            return 10f * (float)num;
        }
    }

    // PARTY CANNON

    public class MLRP_PartyCannonMoodBoost : CompTargetEffect
    {
        public override void DoEffectOn(Pawn user, Thing target)
        {
            Pawn pawn = (Pawn)target;
            if (pawn.Dead || pawn.needs == null || pawn.needs.mood == null)
                return;
            if (pawn.IsColonist) // Pawn is a colonist
            {
                if (!pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")) && !pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait"))) // Colonist has neither the brony or anti brony trait
                {
                    pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory)ThoughtMaker.MakeThought(DefDatabase<ThoughtDef>.GetNamed("MLRP_PartyCannonBoostRegularPawn")));
                }
                if (pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")) && !pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait"))) // Colonist has the brony trait
                {
                    pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory)ThoughtMaker.MakeThought(DefDatabase<ThoughtDef>.GetNamed("MLRP_PartyCannonBoostBrony")));
                }
                if (!pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")) && pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait"))) // Colonist has the anti brony trait
                {
                    pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory)ThoughtMaker.MakeThought(DefDatabase<ThoughtDef>.GetNamed("MLRP_PartyCannonBoostAntiBrony")));
                }
            }
            if (pawn.IsPrisoner) // Pawn is a prisoner
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory)ThoughtMaker.MakeThought(DefDatabase<ThoughtDef>.GetNamed("MLRP_PartyCannonBoostPrisoner")));
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Ideology") && pawn.IsSlave) // Pawn is a slave (requires Ideology DLC)
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory)ThoughtMaker.MakeThought(DefDatabase<ThoughtDef>.GetNamed("MLRP_PartyCannonBoostSlave")));
            }
        }
    }

    // SCREWBALL ROOM

    public class RoomRoleWorker_ScrewballRoom : RoomRoleWorker
    {
        public override float GetScore(Room room)
        {
            int num = 0;
            List<Thing> andAdjacentThings = room.ContainedAndAdjacentThings;
            for (int index = 0; index < andAdjacentThings.Count; ++index)
            {
                if (andAdjacentThings[index].def == DefDatabase<ThingDef>.GetNamed("MLRP_ScrewballGenerator"))
                    ++num;
            }
            return 10f * (float)num;
        }
    }

    // PLUSHIE RECYCLING
	
	public class RecyclePlushieExtension : DefModExtension
	{
		public int reclaimedAmount = 75; // Default value if not specified
	}

    public class Recipe_RecyclePlushie : RecipeWorker
    {
        public override void ConsumeIngredient(Thing ingredient, RecipeDef recipe, Map map)
        {
            base.ConsumeIngredient(ingredient, recipe, map);
            ThingDef stuff = ingredient.Stuff;

            if (stuff != null)
            {
                // Try to get the mod extension that contains the 'reclaimedAmount' value
                var extension = recipe.GetModExtension<RecyclePlushieExtension>();

                // Use the value from the extension, default to 75 if not found
                int amount = extension?.reclaimedAmount ?? 75;

                Thing reclaimedMaterial = ThingMaker.MakeThing(stuff);
                reclaimedMaterial.stackCount = amount;
                GenPlace.TryPlaceThing(reclaimedMaterial, ingredient.Position, map, ThingPlaceMode.Near);
            }
        }
    }

    // CUTIE POX CURE

    public class CutiePoxCure : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            List<Hediff> MLRP_HediffsToCheck = pawn.health.hediffSet.hediffs.ToList();
            foreach (Hediff hediff in MLRP_HediffsToCheck)
            {
                switch (hediff.def.defName)
                {
                    case "MLRP_CutiePox":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    default:
                        Log.Warning("MLRP_NothingToCure".Translate(pawn));
                        break;
                }
            }
        }
    }

    // CHANGE STANDARD PLUSHIE STUFF COST

    public class PatchOperationDynamicPlushieCost : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Pull the current setting
            int newCost = MLRP_SettingsWindow.settings.ingredientCount;

            // Build the xpath dynamically
            string xpath = $"Defs/ThingDef[defName=\"{defName}\"]/costStuffCount";

            XmlNode node = xml.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = newCost.ToString();
                return true;
            }

            return false;
        }
    }

    // CHANGE ELEMENTS OF HARMONY COST

    public class PatchOperationDynamicEOHCost : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Pull the current setting

            int baseCost = MLRP_SettingsWindow.settings.ingredientCount;
            int newCost = baseCost * 6;

            // Build the xpath dynamically
            string xpath = $"Defs/ThingDef[defName=\"{defName}\"]/costStuffCount";

            XmlNode node = xml.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = newCost.ToString();
                return true;
            }

            return false;
        }
    }

    // CHANGE CUTIE MARK CRUSADERS COST

    public class PatchOperationDynamicCMCCost : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Pull the current setting

            int baseCost = MLRP_SettingsWindow.settings.ingredientCount;
            int newCost = baseCost * 3;

            // Build the xpath dynamically
            string xpath = $"Defs/ThingDef[defName=\"{defName}\"]/costStuffCount";

            XmlNode node = xml.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = newCost.ToString();
                return true;
            }

            return false;
        }
    }

    // CHANGE CHILD PLUSHIE COST

    public class PatchOperationDynamicChildCost : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Pull the current setting

            int baseCost = MLRP_SettingsWindow.settings.ingredientCount;
            int newCost = baseCost / 2;

            // Build the xpath dynamically
            string xpath = $"Defs/ThingDef[defName=\"{defName}\"]/costStuffCount";

            XmlNode node = xml.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = newCost.ToString();
                return true;
            }

            return false;
        }
    }

    // CHANGE CHILD CMC COST

    public class PatchOperationDynamicChildCMCCost : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Pull the current setting

            int baseCost = MLRP_SettingsWindow.settings.ingredientCount;
            int newCost = ((baseCost * 3) / 2);

            // Build the xpath dynamically
            string xpath = $"Defs/ThingDef[defName=\"{defName}\"]/costStuffCount";

            XmlNode node = xml.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = newCost.ToString();
                return true;
            }

            return false;
        }
    }

    // SET TEXTURE OF TWILIGHT SPARKLE PLUSHIE

    public class PatchOperationTSTexture : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Pull the current setting

            string oldPath = "Things/PonyPlush/TwilightSparkle_OLD";
            string newPath = "Things/PonyPlush/TwilightSparkle";

            // Build the xpath dynamically
            string xpath = $"Defs/ThingDef[defName=\"{defName}\"]/graphicData/texPath";

            XmlNode node = xml.SelectSingleNode(xpath);
            if (node != null)
            {
                if (MLRP_SettingsWindow.settings.useOldTSTex == true)
                {
                    node.InnerText = oldPath;
                }
                else if (MLRP_SettingsWindow.settings.useOldTSTex == false)
                {
                    node.InnerText = newPath;
                }
                return true;
            }

            return false;
        }
    }

    // PATCH THE ANIMA TREE INTO THE TREE OF HARMONY

    public class PatchOperationDynamicAnimaTree : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            string thingXpath = $"Defs/ThingDef[defName=\"{defName}\"]";
            XmlNode thingNode = xml.SelectSingleNode(thingXpath);
            if (thingNode == null)
            {
                return false;
            }

            // helper to set or create a node
            void SetNode(string relativeXpath, string value)
            {
                XmlNode node = thingNode.SelectSingleNode(relativeXpath);
                if (node == null)
                {
                    string[] parts = relativeXpath.Split('/');
                    XmlNode parent = thingNode;
                    foreach (var part in parts)
                    {
                        XmlNode child = parent.SelectSingleNode(part);
                        if (child == null)
                        {
                            child = xml.CreateElement(part);
                            parent.AppendChild(child);
                        }
                        parent = child;
                    }
                    node = parent;
                }
                node.InnerText = value;
            }

            // Apply changes
            if (MLRP_SettingsWindow.settings.TreeOfHarmony == true)
            {
                SetNode("label", "Tree of Harmony");
                SetNode("description", "The Tree of Harmony is a magical tree that once held the Elements of Harmony. Nobody knows how it ended up on the rim, but many people suspect that science was involved.\n\nIf a person (psycaster or not) meditates near the tree, it will grow harmony grass around its base. Once enough grass is grown, it becomes possible to carry out a psychic linking ritual with the tree and upgrade a person's psychic powers. Only tribal peoples know the secret of this ritual. Tribal psycasters are also able to draw psyfocus from the Tree of Harmony while meditating at it.\n\nThe tree's psychic properties are weakened if artificial structures are placed nearby. They refuse to be caged or studied, and must remain part of nature.\n\nMost tribes believe that these trees are not simply trees, but are rather the physical extremities of a single world spirit, while bronies believe them to be a physical extension of their beliefs.");
                SetNode("comps/li[4]/enoughPlantsLetterLabel", "About: Linking with the Tree of Harmony");
                SetNode("comps/li[4]/enoughPlantsLetterText", "The Tree of Harmony now has {0} harmony grass around it. This is enough for a tribal person to begin their first linking ritual!\n\nThe linking ritual gives a level of psylink and the ability to use psychic powers. Upgrading to a higher level requires 20 grass.\n\nThe harmony grass requirements for linking rituals to upgrade psycasters are:\n\n{1}\n\nNote: Only those with the nature focus type can meditate to or link with the Tree of Harmony. You can see a person's focus types by looking at their info card with the 'i' button.");
                SetNode("graphicData/texPath", "Things/Plant/TreeOfHarmony");
                SetNode("plant/immatureGraphicPath", "Things/Plant/TreeOfHarmony_Immature");
                SetNode("plant/snowOverlayGraphicPath", "Things/Plant/TreeOfHarmony_Snowy");
                SetNode("plant/immatureSnowOverlayGraphicPath", "Things/Plant/TreeOfHarmony_ImmatureSnowy");
                SetNode("graphicData/graphicClass", "Graphic_Single");
                SetNode("graphicData/drawSize", "(2,2)");
                SetNode("comps/li[5]/message", "The Tree of Harmony has died and emitted a disturbing psychic scream.");

                return true;
            }

            return true;

        }
    }

    // PATCH ANIMA GRASS INTO HARMONY GRASS

    public class PatchOperationDynamicAnimaGrass : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
                string thingXpath = $"Defs/ThingDef[defName=\"{defName}\"]";
                XmlNode thingNode = xml.SelectSingleNode(thingXpath);
                if (thingNode == null)
                {
                    return false;
                }

                // helper to set or create a node
                void SetNode(string relativeXpath, string value)
                {
                    XmlNode node = thingNode.SelectSingleNode(relativeXpath);
                    if (node == null)
                    {
                        string[] parts = relativeXpath.Split('/');
                        XmlNode parent = thingNode;
                        foreach (var part in parts)
                        {
                            XmlNode child = parent.SelectSingleNode(part);
                            if (child == null)
                            {
                                child = xml.CreateElement(part);
                                parent.AppendChild(child);
                            }
                            parent = child;
                        }
                        node = parent;
                    }
                    node.InnerText = value;
                }

            // Apply changes

            if (MLRP_SettingsWindow.settings.TreeOfHarmony == true)
            {
                SetNode("label", "harmony grass");
                SetNode("description", "A grass infused with luminous microorganisms. Tribal peoples find that this grass grows around the base of the Tree of Harmony as they meditate. It seems to reflect some kind of strengthening of the tree's psychic power.\n\nAnimals refuse to eat anima grass, which tribal stories say is done out of respect.\n\nBronies believe that the grass is a physical extension of the tree's power, and that it holds the key to opening a link to Equestria, but the grass degenerates into normal plant matter when observed too closely.");

                return true;
            }

            return true;
            
        }
    }

    // LIMESTONE PIE WORKGIVER

    public class WorkGiver_LimestonePie : WorkGiver_Scanner
    {
        public override ThingRequest PotentialWorkThingRequest
        {
            get => ThingRequest.ForDef(DefDatabase<ThingDef>.GetNamed("MLRP_LimestonePie"));
        }

        public override PathEndMode PathEndMode => PathEndMode.InteractionCell;

        public override Danger MaxPathDanger(Pawn pawn) => Danger.Deadly;

        public override bool ShouldSkip(Pawn pawn, bool forced = false)
        {
            List<Building> buildingsColonist = pawn.Map.listerBuildings.allBuildingsColonist;
            for (int index = 0; index < buildingsColonist.Count; ++index)
            {
                Building t = buildingsColonist[index];
                if (t.def == DefDatabase<ThingDef>.GetNamed("MLRP_LimestonePie"))
                {
                    CompPowerTrader comp = t.GetComp<CompPowerTrader>();
                    if ((comp == null || comp.PowerOn) && t.Map.designationManager.DesignationOn((Thing)t, DesignationDefOf.Uninstall) == null)
                        return false;
                }
            }
            return true;
        }

        public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            return t.Faction == pawn.Faction && t is Building building && pawn.CanReserve((LocalTargetInfo)(Thing)building, ignoreOtherReservations: forced) && building.TryGetComp<CompDeepDrill>().CanDrillNow() && building.Map.designationManager.DesignationOn((Thing)building, DesignationDefOf.Uninstall) == null && !building.IsBurning();
        }

        public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            return JobMaker.MakeJob(JobDefOf.OperateDeepDrill, (LocalTargetInfo)t, 1500, true);
        }
    }

}