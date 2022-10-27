using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace MLRP_CurePoisonJokeAddiction
{
    [DefOf]
    class MLRP_PoisonJokeDef
    {
        static MLRP_PoisonJokeDef()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MLRP_PoisonJokeDef));
        }
    }

    public class IngestionOutcomeDoer_PoisonJokeAddictionCure : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            //List<Hediff> hediffs3 = pawn.health.hediffSet.GetHediffs<Hediff>().ToList();
            List<Hediff> MLRP_HediffsToCheck = pawn.health.hediffSet.hediffs;
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
