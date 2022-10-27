// Huge thanks to Aelanna from the official RimWorld Discord server for helping me out with this thing.
// And also for being so damn patient with me while my slow brain figured it all out.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Jobs;
using RimWorld;
using Verse;
using Verse.AI;

namespace MyLittleRimPony
{
    [DefOf]

    public static class MyDefOf
    {
        public static TraitDef MLRP_BronyTrait;
        public static TraitDef MLRP_AntiBronyTrait;
        public static ThoughtDef MLRP_PonyPlushEquippedAntiBrony;

        static MyDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MyDefOf));
        }
    }

    // ANTI BRONY PLUSHIE ALERT

    public class Alert_AntiBronyHasPlushie : Alert_Thought
    {
        protected override ThoughtDef Thought => MyDefOf.MLRP_PonyPlushEquippedAntiBrony;

        public Alert_AntiBronyHasPlushie()
        {
            this.defaultLabel = "Anti brony has plushie";
            this.defaultExplanation = "A pawn with the anti brony trait has a pony plushie equipped, causing a mood penalty.";
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

    public class IngestionOutcomeDoer_PoisonJokeAddictionCure : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            //List<Hediff> hediffs3 = pawn.health.hediffSet.GetHediffs<Hediff>().ToList();
            List<Hediff> MLRP_HediffsToCheck = pawn.health.hediffSet.hediffs.ToList();
            foreach (Hediff hediff in MLRP_HediffsToCheck)
            {
                switch (hediff.def.defName)
                {
                    case "MLRP_PoisonJokeAddiction":
                        pawn.health.RemoveHediff(hediff);
                        break;
                    case "MLRP_PoisonJokeTolerance":
                        pawn.health.RemoveHediff(hediff);
                        break;
                    case "MagicalCakeAddiction":
                        pawn.health.RemoveHediff(hediff);
                        break;
                    case "MagicalCakeTolerance":
                        pawn.health.RemoveHediff(hediff);
                        break;
                    default:
                        System.Console.WriteLine("Nothing found!");
                        break;
                }
            }
        }
    }
}