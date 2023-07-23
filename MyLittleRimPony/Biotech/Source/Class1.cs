using MyLittleRimPony;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MLRP_Biotech
{

    [DefOf]
    public static class MLRP_BiotechDefOf
    {
        public static XenotypeDef MLRP_Xeno_Alicorn;
        public static XenotypeDef MLRP_Xeno_EarthPony;
        public static XenotypeDef MLRP_Xeno_Unicorn;
        public static XenotypeDef MLRP_Xeno_Pegasus;
        public static XenotypeDef MLRP_Xeno_Changeling;

        static MLRP_BiotechDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MLRP_BiotechDefOf));
        }
    }

    // BRONIES LOVE MLP XENOTYPES

    public class ThoughtWorker_BronyLovesMLPXenotype : ThoughtWorker
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
            if (p.story.traits.HasTrait(MyDefOf.MLRP_BronyTrait) && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn || p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony || p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn || p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus || p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return false;
            }
            return true;
        }
    }

    public class Thought_BronyLovesMLPXenotype : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Alicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_EarthPony || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Unicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)
            {
                return 10f;
            }
            return 0f;
        }
    }

    // ANTI BRONIES DISLIKE MLP XENOTYPES

    public class ThoughtWorker_AntiBronyVsMLPXenotype : ThoughtWorker
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
            if (otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return false;
            }
            return true;
        }
    }

    public class Thought_AntiBronyVsMLPXenotype : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Alicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_EarthPony || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Unicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Pegasus || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return -20f;
            }
            return 0f;
        }
    }

    // MLP XENOTYPES LIKE EACH OTHER

    public class ThoughtWorker_MLPXenotypeAppreciation : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            if (p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)
            {
                return false;
            }
            return true;
        }
    }

    public class Thought_MLPXenotypeAppreciation : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Alicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_EarthPony || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Unicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)
            {
                return 5f;
            }
            return 0f;
        }
    }


    // ANTI BRONY HATES BEING MLP XENOTYPE

    public class ThoughtWorker_AntiBronyIsPonyXenotype : ThoughtWorker
    {

        protected override ThoughtState CurrentStateInternal(Pawn p) => (ThoughtState)(p.story.traits.HasTrait(MyDefOf.MLRP_AntiBronyTrait) && p.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Alicorn || p.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_EarthPony || p.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Unicorn || p.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Pegasus || p.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Changeling);

    }

    // CHANGELINGS LIKE MLP XENOTYPES

    public class ThoughtWorker_ChangelingsHateMLPXenotype : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            if (p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn && otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)
            {
                return false;
            }
            return true;
        }
    }

    public class Thought_ChangelingsHateMLPXenotype : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Alicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_EarthPony || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Unicorn || otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)
            {
                return 5f;
            }
            return 0f;
        }
    }

    // MLP XENOTYPES LIKE CHANGELINGS

    public class ThoughtWorker_MLPXenotypesHateChangelings : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            if (p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Alicorn && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_EarthPony && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Unicorn && p.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Pegasus)

            {
                return false;
            }
            if (!otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (otherPawn.genes.Xenotype != MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return false;
            }
            return true;
        }
    }

    public class Thought_MLPXenotypesHateChangelings : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (otherPawn.genes.Xenotype == MLRP_BiotechDefOf.MLRP_Xeno_Changeling)
            {
                return 5f;
            }
            return 0f;
        }
    }

}
