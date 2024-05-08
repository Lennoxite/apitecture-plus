using System;
using RimWorld;
using Verse;

namespace ApitecturePlus
{

	public class ApiPlus_HediffComp_PrismRefract : HediffComp
	{
		public ApiPlus_HediffCompProperties_PrismRefract Props
		{
			get
			{
				return (ApiPlus_HediffCompProperties_PrismRefract)this.props;
			}
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x0000313F File Offset: 0x0000133F
		public override void Notify_PawnPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
		{
			if (dinfo.Def == null)
				return;
			// If pawn is hit by a Prism attack, create a slightly weaker projectile that "bounces" off affected pawns.
			
			if (dinfo.Def == ApiPlus_DamageDefOf.Prism && this.Props.f_refractPercent * totalDamageDealt > 5.0f)
			{
				//Find any pawns nearby within range.
				List<Pawn> list;
				List<Pawn> targets = new List<Pawn>();
				Pawn victim = null;
				list = Pawn.Map.mapPawns.AllPawns;
				foreach (Pawn paw in list)
				{
					if (paw == null)
						continue;
					if (!paw.Dead && paw.health != null && paw != this.Pawn && paw.Position.DistanceTo(base.Pawn.Position) <= this.Props.f_refractRange && this.Props.tParam.CanTarget(paw, null))
					{
						targets.Add(paw);
					}

				}

				if (!targets.NullOrEmpty())
				{
					int i_count = targets.Count;
					int chosenTarget = Verse.Rand.Range(0, i_count - 1);

					victim = targets[chosenTarget];
				}
				else { return; }

				if (victim != null)
				{
					float f_newDamage = this.Props.f_refractPercent * totalDamageDealt;
					BodyPartRecord randomPart = victim.health.hediffSet.GetRandomNotMissingPart(ApiPlus_DamageDefOf.Prism);
					if (randomPart == null)
					{
						return;
					}
					victim.TakeDamage(new DamageInfo(ApiPlus_DamageDefOf.Prism, f_newDamage, 1f, -1f, null, randomPart, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true));
					RimWorld.FleckMaker.ThrowAirPuffUp(victim.Drawer.DrawPos, victim.Map);
					RimWorld.FleckMaker.ThrowAirPuffUp(base.Pawn.Drawer.DrawPos, base.Pawn.Map);
				}

			}
		}


	}
}
