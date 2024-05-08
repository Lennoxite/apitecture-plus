using System;
using Verse;
using RimWorld;

namespace ApitecturePlus
{
	[DefOf]
	public static class ApiPlus_DamageDefOf
	{
		static ApiPlus_DamageDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(ApiPlus_DamageDefOf));
		}

		public static DamageDef HoneyBash;

		public static DamageDef BurningHoneyBash;

		public static DamageDef HoneyGlob;

		public static DamageDef Prism;

	}
}
