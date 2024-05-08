using System;
using Verse;
using RimWorld;
namespace ApitecturePlus
{
	[DefOf]
	public static class ApiPlus_RulePackDefOf
	{
		static ApiPlus_RulePackDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(RulePackDefOf));
		}

		public static RulePackDef DamageEvent_TrapHoneyPit;


	}
}
