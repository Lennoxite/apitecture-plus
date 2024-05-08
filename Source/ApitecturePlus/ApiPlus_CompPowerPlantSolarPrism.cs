using System;
using UnityEngine;
using Verse;
using RimWorld;

namespace ApitecturePlus
{
	// Token: 0x02000CF8 RID: 3320
	[StaticConstructorOnStartup]
	public class ApiPlus_CompPowerPlantSolarPrism : RimWorld.CompPowerPlant
	{
		// Token: 0x17000D86 RID: 3462
		// (get) Token: 0x06004DDF RID: 19935 RVA: 0x001A0F25 File Offset: 0x0019F125
		protected override float DesiredPowerOutput
		{
			get
			{
				return Mathf.Lerp(0f, FullSunPower, this.parent.Map.skyManager.CurSkyGlow) * this.RoofedPowerOutputFactor;
			}
		}

		// Token: 0x17000D87 RID: 3463
		// (get) Token: 0x06004DE0 RID: 19936 RVA: 0x001A0F54 File Offset: 0x0019F154
		private float RoofedPowerOutputFactor
		{
			get
			{
				int num = 0;
				int num2 = 0;
				foreach (IntVec3 c in this.parent.OccupiedRect())
				{
					num++;
					if (this.parent.Map.roofGrid.Roofed(c))
					{
						num2++;
					}
				}
				return (float)(num - num2) / (float)num;
			}
		}

		// Token: 0x06004DE1 RID: 19937 RVA: 0x001A0FD8 File Offset: 0x0019F1D8
		public override void PostDraw()
		{
			base.PostDraw();
			GenDraw.FillableBarRequest r = default(GenDraw.FillableBarRequest);
			r.center = this.parent.DrawPos + Vector3.up * 0.1f;
			r.size = ApiPlus_CompPowerPlantSolarPrism.BarSize;
			r.fillPercent = base.PowerOutput / FullSunPower;
			r.filledMat = ApiPlus_CompPowerPlantSolarPrism.PowerPlantSolarBarFilledMat;
			r.unfilledMat = ApiPlus_CompPowerPlantSolarPrism.PowerPlantSolarBarUnfilledMat;
			r.margin = 0.15f;
			Rot4 rotation = this.parent.Rotation;
			rotation.Rotate(RotationDirection.Clockwise);
			r.rotation = rotation;
			GenDraw.DrawFillableBar(r);
		}

		private const float FullSunPower = 3000f;

		private const float NightPower = 0f;

		private static readonly Vector2 BarSize = new Vector2(2.3f, 0.14f);

		private static readonly Material PowerPlantSolarBarFilledMat = SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.5f, 0.475f, 0.1f), false);

		private static readonly Material PowerPlantSolarBarUnfilledMat = SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.15f, 0.15f, 0.15f), false);
	}
}
