using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MLRP_AntiBronyPlushAlert
{
    public static class MLRPCustomDefs
    {
        public static ThoughtDef MLRP_PonyPlushEquippedAntiBrony;

        static MLRPCustomDefs()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MLRPCustomDefs));
        }
    }
    public class Alert_AntiBronyHasPlushie : Alert_Thought
    {
        protected override ThoughtDef Thought => MLRPCustomDefs.MLRP_PonyPlushEquippedAntiBrony;

        public Alert_AntiBronyHasPlushie()
        {
            this.defaultLabel = "Anti brony has plushie";
            this.defaultExplanation = "A pawn with the anti brony trait has a pony plushie equipped, causing a mood penalty.";
        }
    }
}
