using System;
using RimWorld;
using Verse;

namespace ApitecturePlus
{

	public class ApiPlus_HediffComp_HoneyBurn : HediffComp
	{
		public ApiPlus_HediffCompProperties_HoneyBurn Props
		{
			get
			{
				return (ApiPlus_HediffCompProperties_HoneyBurn)this.props;
			}
		}

		public override void CompPostTick(ref float severityAdjustment)
		{
			this.Props.ticksToInjure--;
			if (this.Props.ticksToInjure <= 0f)
			{
				this.Props.ticksToInjure = this.Props.ticksToInjureTotal;
				BodyPartRecord randomPart = base.Pawn.health.hediffSet.GetRandomNotMissingPart(DamageDefOf.Burn);
				if (randomPart == null)
				{
					return;
				}
				int randomInRange = new IntRange(0, this.Props.damageAmount).RandomInRange;
				base.Pawn.TakeDamage(new DamageInfo(DamageDefOf.Burn, (float)randomInRange, 0f, -1f, null, randomPart, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true));
				//Messages.Message("MessageReceivedBrainDamageFromHediff".Translate(base.Pawn.Named("PAWN"), randomInRange, this.parent.Label), base.Pawn, MessageTypeDefOf.NegativeEvent, true);
				
			}
		}
	}
}
