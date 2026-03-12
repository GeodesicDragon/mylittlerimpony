using MLRP_ModSettings;
using RimWorld;
using System.Xml;
using Verse;

namespace MLRP_Biotech
{

    // BRONIES LOVE MLP XENOTYPES

    public class ThoughtWorker_BronyLovesMLPXenotype : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")))
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")) && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") || p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") || p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") || p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus") || p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !p.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")))
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !p.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))
            {
                return 5f;
            }
            return 0f;
        }
    }

    // ANTI BRONY HATES BEING MLP XENOTYPE

    public class ThoughtWorker_AntiBronyIsPonyXenotype : ThoughtWorker
    {

        protected override ThoughtState CurrentStateInternal(Pawn p) => (ThoughtState)(ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_AntiBronyTrait")) && p.story.traits.HasTrait(DefDatabase<TraitDef>.GetNamed("MLRP_BronyTrait")) && p.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") || p.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") || p.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") || p.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus") || p.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"));

    }

    // CHANGELINGS LIKE MLP XENOTYPES

    public class ThoughtWorker_ChangelingsHateMLPXenotype : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
        {
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !p.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") || otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !p.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Alicorn") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_EarthPony") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Unicorn") && p.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Pegasus"))

            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && !otherPawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype != DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
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
            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && ThoughtUtility.ThoughtNullified(pawn, def))
            {
                return 0f;
            }

            if (ModsConfig.IsActive("Ludeon.RimWorld.Biotech") && otherPawn.genes.Xenotype == DefDatabase<XenotypeDef>.GetNamed("MLRP_Xeno_Changeling"))
            {
                return 5f;
            }
            return 0f;
        }
    }

    // CALCULATE CHEMFUEL THE RENEGADE ALICORN STARTS WITH

    public class PatchOperationRenegadeAlicornChemfuel : PatchOperation
    {
        public string defName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            string thingXpath =
                $"Defs/ScenarioDef[defName=\"{defName}\"]/scenario/parts/li[@Name='MLRP_RenegadeAlicornFuel']";

            XmlNode thingNode = xml.SelectSingleNode(thingXpath);
            if (thingNode == null)
            {
                Log.Warning($"[MLRP] Could not find ThingDef {defName}");
                return false;
            }

            // Helper to set or create a node
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

            // Get mod setting
            int baseChemfuel = MLRP_SettingsWindow.settings.DBChemfuelCost;

            // Multiply by 10
            int raChemfuel = baseChemfuel * 10;

            // IMPORTANT: Convert to string
            SetNode("count", raChemfuel.ToString());

            return true;
        }
    }
}
