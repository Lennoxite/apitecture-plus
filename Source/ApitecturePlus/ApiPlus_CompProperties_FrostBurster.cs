using System;
using Verse;
using RimWorld;

namespace ApitecturePlus
{

	public class ApiPlus_CompProperties_FrostBurster : CompProperties
	{

		public ApiPlus_CompProperties_FrostBurster()
		{
			this.compClass = typeof(ApiPlus_CompFrostBurster);
		}


		public float f_mistSize = 1.5f;
	}
}
