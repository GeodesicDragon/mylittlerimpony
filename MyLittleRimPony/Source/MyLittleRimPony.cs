// My Little RimPony - A RimWorld Mod
// Created by GeodesicDragon
// MLP is property of Hasbro.
// Huge thanks to users of the official RimWorld Discord server for helping me with code.
// And also for being so damn patient with me while my slow brain figured it all out.

// NOTE TO SELF: REMEMBER TO UPDATE THE VERSION NUMBER IN THE CONSOLE MESSAGE!

using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MyLittleRimPony
{
    [DefOf]

    public static class MyDefOf
    {
        // Game related stuff because I don't know how to access the DefDatabase
        public static HediffDef HeartAttack;
        public static HediffDef FibrousMechanites;
        public static HediffDef SensoryMechanites;
        // Mod related stuff
        public static HediffDef MLRP_PoisonJokeSightBeyondSight;
        public static HediffDef MLRP_PoisonJokeSlowAndSluggish;
        public static HediffDef MLRP_PoisonJokeSuperSpeedy;
        public static HediffDef MLRP_PoisonJokeGoodManipulation;
        public static HediffDef MLRP_PoisonJokePoorManipulation;
        public static HediffDef MLRP_PoisonJokeGoodMood;
        public static HediffDef MLRP_PoisonJokeBadMood;
        public static ThingDef MLRP_MagicMirrorGenerator;
        public static TraitDef MLRP_BronyTrait;
        public static TraitDef MLRP_AntiBronyTrait;
        public static ThoughtDef MLRP_PonyPlushEquippedAntiBrony;
        public static RoomRoleDef MLRP_PortalRoom;
        [MayRequireRoyalty]
        public static ThoughtDef MLRP_HarmonyChipInstalledAntiBrony;

        static MyDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MyDefOf));
            Log.Message("[" + "MLRP_ModName".Translate() + "] v3.47.63 " + "MLRP_ModIntro".Translate()); // If anyone is reading this and can tell me how to get the version number automatically using a method that DOESN'T crash the game, please let me know!
            if (ModsConfig.IsActive("CETeam.CombatExtended"))
            {
                Log.Message("[" + "MLRP_ModName".Translate() + "] " + "MLRP_CEDetected".Translate());
                Log.Warning("[" + "MLRP_ModName".Translate() + "] " + "MLRP_CEDetectedWarning".Translate());
            }
            if (ModsConfig.IsActive("imranfish.xmlextensions"))
            {
                Log.Message("[" + "MLRP_ModName".Translate() + "] " + "MLRP_XMLExtensionsDetected".Translate());
            }
        }
    }

    // ANTI BRONY PLUSHIE ALERT

    public class Alert_AntiBronyHasPlushie : Alert_Thought
    {
        protected override ThoughtDef Thought => MyDefOf.MLRP_PonyPlushEquippedAntiBrony;

        public Alert_AntiBronyHasPlushie()
        {
            this.defaultLabel = "MLRP_AntiBronyHasPlushieAlert".Translate();
            this.explanationKey = "MLRP_AntiBronyHasPlushieExplanation".Translate();
        }
    }

    // ANTI BRONY HARMONY CHIP ALERT

    public class Alert_AntiBronyHasHarmonyChip : Alert_Thought
    {
        protected override ThoughtDef Thought => MyDefOf.MLRP_HarmonyChipInstalledAntiBrony;

        public Alert_AntiBronyHasHarmonyChip()
        {
            this.defaultLabel = "MLRP_AntiBronyHasHarmonyChipAlert".Translate();
            this.explanationKey = "MLRP_AntiBronyHasHarmonyChipExplanation".Translate();
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
            if (!p.story.traits.HasTrait(MyDefOf.MLRP_AntiBronyTrait))
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (!otherPawn.story.traits.HasTrait(MyDefOf.MLRP_BronyTrait))
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

            if (otherPawn.story.traits.HasTrait(MyDefOf.MLRP_BronyTrait))
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
            if (!p.story.traits.HasTrait(MyDefOf.MLRP_BronyTrait))
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (!otherPawn.story.traits.HasTrait(MyDefOf.MLRP_BronyTrait))
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

            if (otherPawn.story.traits.HasTrait(MyDefOf.MLRP_BronyTrait))
            {
                return 10f;
            }
            return 0f;
        }
    }

    // CURE POISON JOKE ADDICTION

    public class PoisonJokeAddictionCure : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            List<Hediff> MLRP_HediffsToCheck = pawn.health.hediffSet.hediffs.ToList();
            foreach (Hediff hediff in MLRP_HediffsToCheck)
            {
                switch (hediff.def.defName)
                {
                    case "MLRP_PoisonJokeAddiction":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "MLRP_PoisonJokeTolerance":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "MagicalCakeAddiction":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "MagicalCakeTolerance":
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    default:
                        Log.Warning("[" + "MLRP_ModName".Translate() + "] " + "MLRP_NothingToCure".Translate());
                        break;
                }
            }
        }
    }

    // POISON JOKE RANDOM EFFECT

    public class PoisonJokeSmoked : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            System.Random r = new System.Random();
            int n = r.Next(1, 11); // maxValue must always be one greater than the number of available hediffs, otherwise the poison joke will always cause a heart attack!
            var affliction = "";

            switch (n)
            {
                case 1:
                    pawn.health.AddHediff(MyDefOf.HeartAttack);
                    affliction = "Heart attack";
                    break;
                case 2:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeSightBeyondSight);
                    affliction = "Sight beyond sight";
                    break;
                case 3:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeSlowAndSluggish);
                    affliction = "Slow and sluggish";
                    break;
                case 4:
                    pawn.health.AddHediff(MyDefOf.FibrousMechanites);
                    affliction = "Fibrous mechanites";
                    break;
                case 5:
                    pawn.health.AddHediff(MyDefOf.SensoryMechanites);
                    affliction = "Sensory mechanites";
                    break;
                case 6:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeSuperSpeedy);
                    affliction = "Super speedy";
                    break;
                case 7:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeGoodManipulation);
                    affliction = "Improved manipulation";
                    break;
                case 8:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokePoorManipulation);
                    affliction = "Reduced manipulation";
                    break;
                case 9:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeGoodMood);
                    affliction = "Good mood";
                    break;
                case 10:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeBadMood);
                    affliction = "Bad mood";
                    break;
            }
            if (n == 1)
            {
                LetterDef MLRP_PoisonJokeAfflictionLetter = LetterDefOf.ThreatSmall;
                string title = "MLRP_PoisonJokeLetterTitle".Translate();
                string text = "MLRP_PoisonJokeLetterText".Translate(pawn, affliction);
                Find.LetterStack.ReceiveLetter(title, text, MLRP_PoisonJokeAfflictionLetter);
            }
            else
            {
                LetterDef MLRP_PoisonJokeAfflictionLetter = LetterDefOf.NeutralEvent;
                string title = "MLRP_PoisonJokeLetterTitle".Translate();
                string text = "MLRP_PoisonJokeLetterText".Translate(pawn, affliction);
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
                if (andAdjacentThings[index].def == MyDefOf.MLRP_MagicMirrorGenerator)
                    ++num;
            }
            return 50f * (float)num;
        }
    }
}