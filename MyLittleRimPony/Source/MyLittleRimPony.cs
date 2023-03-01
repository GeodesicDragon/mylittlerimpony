// My Little RimPony - A RimWorld Mod
// Created by GeodesicDragon
// MLP is property of Hasbro.
// Huge thanks to users of the official RimWorld Discord server for helping me with code.
// And also for being so damn patient with me while my slow brain figured it all out.
// I am always happy to accept updates to this code, especially if you have a better way of doing something I've done.
// Contact me via my Discord server and we'll talk! (Invite Code: BGKnpza)

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
using Verse;

namespace MyLittleRimPony
{
    [DefOf]
    public static class MyDefOf
    {
        // Game related stuff because I don't know how to access the DefDatabase
        public static HediffDef FibrousMechanites;
        public static HediffDef SensoryMechanites;
        // Mod related stuff
        public static HediffDef MLRP_PoisonJokeIncreasedConsciousness;
        public static HediffDef MLRP_PoisonJokeReducedConsciousness;
        public static HediffDef MLRP_PoisonJokeSuperSpeedy;
        public static HediffDef MLRP_PoisonJokeSlowAndSluggish;
        public static HediffDef MLRP_PoisonJokeGoodManipulation;
        public static HediffDef MLRP_PoisonJokePoorManipulation;
        public static HediffDef MLRP_PoisonJokeIncreasedTalking;
        public static HediffDef MLRP_PoisonJokeReducedTalking;
        public static HediffDef MLRP_PoisonJokeIncreasedEating;
        public static HediffDef MLRP_PoisonJokeReducedEating;
        public static HediffDef MLRP_PoisonJokeSightBeyondSight;
        public static HediffDef MLRP_PoisonJokeBlindness;
        public static HediffDef MLRP_PoisonJokeIncreasedHearing;
        public static HediffDef MLRP_PoisonJokeReducedHearing;
        public static HediffDef MLRP_PoisonJokeIncreasedBreathing;
        public static HediffDef MLRP_PoisonJokeReducedBreathing;
        public static HediffDef MLRP_PoisonJokeIncreasedBloodFiltration;
        public static HediffDef MLRP_PoisonJokeReducedBloodFiltration;
        public static HediffDef MLRP_PoisonJokeIncreasedBloodPumping;
        public static HediffDef MLRP_PoisonJokeReducedBloodPumping;
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
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            Log.Message("[" + "MLRP_ModName".Translate() + "] v" + version.ToString(3) + " " + "MLRP_ModIntro".Translate());

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
            int n = r.Next(1, 21); // maxValue must always be one greater than the number of available hediffs, otherwise the first hediff will always be chosen.
            var affliction = "";

            switch (n)
            {
                case 1:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedConsciousness);
                    affliction = "increased consciousness";
                    break;
                case 2:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedConsciousness);
                    affliction = "reduced consciousness";
                    break;
                case 3:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeSuperSpeedy);
                    affliction = "super speedy";
                    break;
                case 4:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeSlowAndSluggish);
                    affliction = "slow and sluggish";
                    break;
                case 5:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeGoodManipulation);
                    affliction = "good manipulation";
                    break;
                case 6:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokePoorManipulation);
                    affliction = "poor manipulation";
                    break;
                case 7:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedTalking);
                    affliction = "gift of the gab";
                    break;
                case 8:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedTalking);
                    affliction = "total silence";
                    break;
                case 9:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedEating);
                    affliction = "quick eater";
                    break;
                case 10:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedEating);
                    affliction = "slow eater";
                    break;
                case 11:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeSightBeyondSight);
                    affliction = "sight beyond sight";
                    break;
                case 12:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeBlindness);
                    affliction = "blindness";
                    break;
                case 13:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedHearing);
                    affliction = "improved hearing";
                    break;
                case 14:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedHearing);
                    affliction = "deafness";
                    break;
                case 15:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedBreathing);
                    affliction = "improved breathing";
                    break;
                case 16:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedBreathing);
                    affliction = "struggling for breath";
                    break;
                case 17:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedBloodFiltration);
                    affliction = "improved blood filtration";
                    break;
                case 18:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedBloodFiltration);
                    affliction = "poor blood filtration";
                    break;
                case 19:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeIncreasedBloodPumping);
                    affliction = "improved blood pumping";
                    break;
                case 20:
                    pawn.health.AddHediff(MyDefOf.MLRP_PoisonJokeReducedBloodPumping);
                    affliction = "poor blood pumping";
                    break;
            }
            if (n == 12 || n == 16 || n == 20)
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
            return 10f * (float)num;
        }
    }

    // PORTAL ROOM IMPRESSIVENESS

    public class ThoughtWorker_PortalRoomImpressiveness : ThoughtWorker_RoomImpressiveness
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (!p.IsColonist)
                return ThoughtState.Inactive;
            ThoughtState thoughtState = base.CurrentStateInternal(p);
            return thoughtState.Active && p.GetRoom().Role == MyDefOf.MLRP_PortalRoom ? thoughtState : ThoughtState.Inactive;
        }
    }
}