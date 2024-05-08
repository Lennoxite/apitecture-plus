using System;
using RimWorld;
using Verse;

namespace ApitecturePlus
{

	public class ApiPlus_HediffCompProperties_PrismRefract : HediffCompProperties
	{
		public ApiPlus_HediffCompProperties_PrismRefract()
		{
			this.compClass = typeof(ApiPlus_HediffComp_PrismRefract);
		}

		public override IEnumerable<string> ConfigErrors(HediffDef parentDef)
		{
			foreach (string text in base.ConfigErrors(parentDef))
			{
				yield return text;
			}
			yield break;
		}

		public float f_refractRange = 10.0f;
		public float f_refractPercent = 0.75f;
		public TargetingParameters tParam = new TargetingParameters();


	}

}