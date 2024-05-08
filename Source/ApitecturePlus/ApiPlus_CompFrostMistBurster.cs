using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ApitecturePlus
{

	public class ApiPlus_CompFrostBurster : ThingComp
	{

		public ApiPlus_CompProperties_FrostBurster Props
		{
			get
			{
				return (ApiPlus_CompProperties_FrostBurster)this.props;
			}
		}

		//Produce frost mist explosion wherever pawn user is.
		public override void Notify_UsedWeapon(Pawn pawn)
		{
			
			GenExplosion.DoExplosion(pawn.PositionHeld, pawn.MapHeld, this.Props.f_mistSize, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null,
				ApiPlus_ThingDefOf.ApiPlus_Gas_FrostHoneyMist, 1f, 1, false, null, 0f, 1, 0f, false, null, null);
		}


	}
}
