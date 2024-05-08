using System;
using Verse;
using RimWorld;

namespace ApitecturePlus
{
	[DefOf]
	public static class ApiPlus_ThingDefOf
	{
		static ApiPlus_ThingDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(ApiPlus_ThingDefOf));
		}

		public static ThingDef ApiPlus_Gas_FrostHoneyMist;

	}
}
