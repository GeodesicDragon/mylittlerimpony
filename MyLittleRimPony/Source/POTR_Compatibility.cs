using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MLRP_PoniesOfTheRim
{
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
				if (otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony_PegasusBody") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony_EarthponyBody") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony_UnicornBody"))
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
					if (otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony_PegasusBody") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony_EarthponyBody") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony_UnicornBody"))
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
				if (otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony_PegasusBody") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony_EarthponyBody") && otherPawn.def.race.body != DefDatabase<BodyDef>.GetNamed("Pony_UnicornBody"))
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
					if (otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony_PegasusBody") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony_EarthponyBody") || otherPawn.def.race.body == DefDatabase<BodyDef>.GetNamed("Pony_UnicornBody"))
					{
						return -40f;
					}
				}
			}
			return 0f;
		}
	}
		
	// PONY LEATHER CLOTHING

	public class ThoughtWorker_PonyLeatherApparel : ThoughtWorker
	{
		// Cache the ThingDef for "PonyFur" to avoid repeatedly querying DefDatabase
		private static ThingDef PonyFurDef => DefDatabase<ThingDef>.GetNamedSilentFail("PonyFur");

		public static ThoughtState CurrentThoughtState(Pawn p)
		{
			// If "PonyFur" is not defined, the mod is not active. Return inactive thought.
			if (PonyFurDef == null)
			{
				return ThoughtState.Inactive;
			}

			string reason = null;
			int num = 0;
			List<Apparel> wornApparel = p.apparel.WornApparel;

			for (int index = 0; index < wornApparel.Count; ++index)
			{
				if (wornApparel[index].Stuff == PonyFurDef)
				{
					if (reason == null)
						reason = wornApparel[index].def.label;
					++num;
				}
			}

			if (num == 0)
				return ThoughtState.Inactive;

			return num >= 5 ? ThoughtState.ActiveAtStage(4, reason) : ThoughtState.ActiveAtStage(num - 1, reason);
		}

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			return CurrentThoughtState(p);
		}
	}

    // PONY MEAT CONSUMPTION

    [HarmonyPatch(typeof(JobDriver_Ingest), "MakeNewToils")]
    public static class JobDriver_Ingest_MakeNewToils_Patch
    {
        static void Postfix(JobDriver_Ingest __instance)
        {
            Pawn pawn = __instance.pawn;
            Thing food = __instance.job.targetA.Thing;

            if (food != null && pawn.story?.traits?.HasTrait(TraitDef.Named("MLRP_BronyTrait")) == true)
            {
                if (food.def == DefDatabase<ThingDef>.GetNamedSilentFail("Meat_Pony") ||
                    food.TryGetComp<CompIngredients>()?.ingredients?.Contains(DefDatabase<ThingDef>.GetNamedSilentFail("Meat_Pony")) == true)
                {
                    // Add memory thought
                    pawn.needs.mood.thoughts.memories.TryGainMemory(DefDatabase<ThoughtDef>.GetNamed("MLRP_BronyAtePonyMeat"));
                    //Log.Message($"[DEBUG] Thought applied to {pawn.Name}");
                }
            }

            if (food != null && pawn.story?.traits?.HasTrait(TraitDef.Named("MLRP_AntiBronyTrait")) == true)
            {
                if (food.def == DefDatabase<ThingDef>.GetNamedSilentFail("Meat_Pony") ||
                    food.TryGetComp<CompIngredients>()?.ingredients?.Contains(DefDatabase<ThingDef>.GetNamedSilentFail("Meat_Pony")) == true)
                {
                    // Add memory thought
                    pawn.needs.mood.thoughts.memories.TryGainMemory(DefDatabase<ThoughtDef>.GetNamed("MLRP_AntiBronyAtePonyMeat"));
                    //Log.Message($"[DEBUG] Thought applied to {pawn.Name}");
                }
            }
        }
    }

    // BRONIES LOVE PONYX

    public class ThoughtWorker_BronyLovesPonyx : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
		{
			if (ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
			{
				if (!p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
				{
					return false;
				}
				if (otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("Ponyx"))
				{
					return false;
				}
			}
			return true;
		}
	}

	public class Thought_BronyLovesPonyx : Thought_SituationalSocial
	{
		public override float OpinionOffset()
		{
			if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
				return 0f;

			if (ThoughtUtility.ThoughtNullified(pawn, def))
				return 0f;

			if (pawn?.story?.traits?.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")) == true)
			{
				if (otherPawn?.genes?.Xenotype == DefDatabase<XenotypeDef>.GetNamed("Ponyx"))
				{
					return 20f;
				}
			}

			return 0f;
		}
	}

	// ANTI BRONIES HATE PONYX

	public class ThoughtWorker_AntiBronyHatesPonyx : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
		{
			if (ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
			{
				if (!p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")))
				{
					return false;
				}
				if (otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("Ponyx"))
				{
					return false;
				}
			}
			return true;
		}
	}

    public class Thought_AntiBronyHatesPonyx : Thought_SituationalSocial
    {
        public override float OpinionOffset()
        {
            if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
                return 0f;

            if (ThoughtUtility.ThoughtNullified(pawn, def))
                return 0f;

            if (pawn.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")) == true)
            {
                if (otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("Ponyx"))
                {
                    return -40f;
                }
            }

            return 0f;
        }
    }

    // ANTI BRONIES DON'T FIND PONIES ATTRACTIVE

    [HarmonyPatch(typeof(ThoughtWorker_Pretty), "CurrentSocialStateInternal")]
    public static class Patch_ThoughtWorker_Pretty
    {
        static void Postfix(ref ThoughtState __result, Pawn pawn, Pawn other)
        {
            if (!ModsConfig.IsActive("Pony.PoniesOfTheRim.Core"))
                return;

            if (!__result.Active)
                return;

            TraitDef antiRaceTrait = DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait");
            if (pawn.story.traits.HasTrait(antiRaceTrait) != true)
                return;

            BodyDef body = other.def.race.body;
            XenotypeDef xenotype = other.genes.Xenotype;

            bool isPonyRace =
                body == DefDatabase<BodyDef>.GetNamed("Pony_PegasusBody") ||
                body == DefDatabase<BodyDef>.GetNamed("Pony_EarthponyBody") ||
                body == DefDatabase<BodyDef>.GetNamed("Pony_UnicornBody") ||
                xenotype == DefDatabase<XenotypeDef>.GetNamed("Ponyx");

            if (isPonyRace)
            {
                __result = ThoughtState.Inactive;
            }
        }
    }
}
