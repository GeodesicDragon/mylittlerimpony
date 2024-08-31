// My Little RimPony - A RimWorld Mod
// Created by GeodesicDragon
// All aspects of MLP (except for Nurse Haywick) are property of Hasbro.
// Huge thanks to users of the official RimWorld Discord server for helping me with code.
// And also for being so damn patient with me while my slow brain figured it all out.
// I am always happy to accept updates to this code, especially if you have a better way of doing something I've done.
// Contact me via my Discord server and we'll talk! (Invite Code: BGKnpza)

using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Verse;

namespace MyLittleRimPony
{

    // GAME STARTUP

    [StaticConstructorOnStartup]
    public static class MLRP_Startup
    {
        static MLRP_Startup()
        {
            var MLRP_Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            Log.Message("MLRP_WelcomeMessage".Translate(MLRP_Version));
        }
    }

    // ANTI BRONY PLUSHIE ALERT

    public class Alert_AntiBronyHasPlushie : Alert_Thought
    {
        protected override ThoughtDef Thought => DefDatabase<ThoughtDef>.GetNamed("MLRP_PonyPlushEquippedAntiBrony");

        public Alert_AntiBronyHasPlushie()
        {
            this.defaultLabel = "MLRP_AntiBronyHasPlushieAlert".Translate();
            this.explanationKey = "MLRP_AntiBronyHasPlushieExplanation".Translate();
        }
    }

    // ANTI BRONY HARMONY CHIP ALERT

    public class Alert_AntiBronyHasHarmonyChip : Alert_Thought
    {
        protected override ThoughtDef Thought => DefDatabase<ThoughtDef>.GetNamed("MLRP_HarmonyChipInstalledAntiBrony");

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

    // BRONIES LOVE ACTUAL PONIES

    public class ThoughtWorker_BronyLovesPony : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
            {
                if (!p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
                {
                    return false;
                }
                if (otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pegasus") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Unicorn"))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Thought_BronyLovesPony : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
            {

            }
            else
            {
                if (ThoughtUtility.ThoughtNullified(pawn, def))
                {
                    return 0f;
                }
                if (pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
                {
                    if (otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pegasus") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Unicorn"))
                    {
                        return 20f;
                    }
                }
            }
            return 0f;
        }
    }

    // ANTI BRONIES HATE ACTUAL PONIES

    public class ThoughtWorker_AntiBronyHatesPony : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
            {
                if (!p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")))
                {
                    return false;
                }
                if (otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pegasus") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Unicorn"))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Thought_AntiBronyHatesPony : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
            {

            }
            else
            {
                if (ThoughtUtility.ThoughtNullified(pawn, def))
                {
                    return 0f;
                }
                if (pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")))
                {
                    if (otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pegasus") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Unicorn"))
                    {
                        return -120f; // Needs to be this high in order to negate the +20 bonus from the fact that ponies are seen by all as physically appealing.
                    }
                }
            }
            return 0f;
        }
    }

    // CURE POISON JOKE ADDICTION

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
                    case "MLRP_CutiePox":
                        System.Random cureChance = new System.Random();
                        int luckyNumber = cureChance.Next(1, 11);
                        if (luckyNumber == 7)
                        {
                            pawn.health.RemoveHediff(hediff);
                            Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        if (luckyNumber != 7)
                        {
                            Messages.Message("MLRP_CureFailed".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        }
                        break;
                    case "MagicalCakeAddiction": // RimPonk
                        pawn.health.RemoveHediff(hediff);
                        Messages.Message("MLRP_PawnCured".Translate(pawn, hediff.Label), MessageTypeDefOf.TaskCompletion, historical: false);
                        break;
                    case "MagicalCakeTolerance": // RimPonk
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

    public class Recipe_RecyclePlushie : RecipeWorker
    {
        public override void ConsumeIngredient(Thing ingredient, RecipeDef recipe, Map map)
        {
            base.ConsumeIngredient(ingredient, recipe, map);
            ThingDef stuff = ingredient.Stuff;

            if (stuff != null)
            {
                int amount = 75;
                Thing reclaimedMaterial = ThingMaker.MakeThing(stuff);
                reclaimedMaterial.stackCount = amount;
                GenPlace.TryPlaceThing(reclaimedMaterial, ingredient.Position, map, ThingPlaceMode.Near);
            }
        }
    }
}