// My Little RimPony - A RimWorld Mod
// Created by GeodesicDragon
// MLP is property of Hasbro.
// Huge thanks to Aelanna from the official RimWorld Discord server for helping me out with this thing.
// And also for being so damn patient with me while my slow brain figured it all out.
// IMPORTANT: This version of the DLL is only compatible with RimWorld 1.4 and above.

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
            Verse.Log.Message("[My Little RimPony] Version 3.38.34 loaded. Remember, friendship is magic!");
            if (ModsConfig.IsActive("CETeam.CombatExtended"))
            {
                Verse.Log.Message("[My Little RimPony] Combat Extended has been detected.");
                Verse.Log.Warning("[My Little RimPony] IMPORTANT: I don't use CE, so patches for it are untested; please alert me ASAP if you encounter any problems!");
            }
            if (ModsConfig.IsActive("imranfish.xmlextensions"))
            {
                Verse.Log.Message("[My Little RimPony] XML Extensions has been detected.");
            }
        }
    }

    // ANTI BRONY PLUSHIE ALERT

    public class Alert_AntiBronyHasPlushie : Alert_Thought
    {
        protected override ThoughtDef Thought => MyDefOf.MLRP_PonyPlushEquippedAntiBrony;

        public Alert_AntiBronyHasPlushie()
        {
            this.defaultLabel = "Anti brony has plushie";
            this.explanationKey = "MLRP_AntiBronyHasPlushie";
        }
    }

    // ANTI BRONY HARMONY CHIP ALERT

    public class Alert_AntiBronyHasHarmonyChip : Alert_Thought
    {
        protected override ThoughtDef Thought => MyDefOf.MLRP_HarmonyChipInstalledAntiBrony;

        public Alert_AntiBronyHasHarmonyChip()
        {
            this.defaultLabel = "Anti brony has harmony chip";
            this.explanationKey = "MLRP_AntiBronyHasHarmonyChip";
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
                        if (ModsConfig.IsActive("SovietRabotyaga.RimPonkOld"))
                        {
                            Messages.Message("MLRP_NothingToCure_RimPonk".Translate(pawn), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        else
                        {
                            Messages.Message("MLRP_NothingToCure_NoRimPonk".Translate(pawn), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        break;
                }
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