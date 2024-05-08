using System;
using RimWorld;
using Verse;

namespace ApitecturePlus
{

	public class ApiPlus_HediffCompProperties_HoneyBurn : HediffCompProperties
	{
		public ApiPlus_HediffCompProperties_HoneyBurn()
		{
			this.compClass = typeof(ApiPlus_HediffComp_HoneyBurn);
		}

		public override IEnumerable<string> ConfigErrors(HediffDef parentDef)
		{
			foreach (string text in base.ConfigErrors(parentDef))
			{
				yield return text;
			}
			yield break;
		}

		public int damageAmount = 5;
		public int ticksToInjure = 250;
		public int ticksToInjureTotal = 250;


	}

}