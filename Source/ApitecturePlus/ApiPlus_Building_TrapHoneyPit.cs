using System;
using Verse;
using Verse.Sound;
using RimWorld;

namespace ApitecturePlus
{
	public class ApiPlus_Building_TrapHoneyPit : Building_Trap
	{
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
			if (!respawningAfterLoad)
			{
				SoundDefOf.TrapArm.PlayOneShot(new TargetInfo(base.Position, map, false));
			}
		}

		protected override void SpringSub(Pawn p)
		{
			SoundDefOf.TrapSpring.PlayOneShot(new TargetInfo(base.Position, base.Map, false));
			if (p == null)
			{
				return;
			}
			float num = this.GetStatValue(StatDefOf.TrapMeleeDamage, true) * ApiPlus_Building_TrapHoneyPit.DamageRandomFactorRange.RandomInRange / ApiPlus_Building_TrapHoneyPit.DamageCount;
			float armorPenetration = num * 0.015f;
			int num2 = 0;
			while ((float)num2 < ApiPlus_Building_TrapHoneyPit.DamageCount)
			{
				DamageInfo dinfo = new DamageInfo(ApiPlus_DamageDefOf.HoneyBash, num, armorPenetration, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true);
				DamageWorker.DamageResult damageResult = p.TakeDamage(dinfo);
				if (num2 == 0)
				{
					BattleLogEntry_DamageTaken battleLogEntry_DamageTaken = new BattleLogEntry_DamageTaken(p, ApiPlus_RulePackDefOf.DamageEvent_TrapHoneyPit, null);
					Find.BattleLog.Add(battleLogEntry_DamageTaken);
					damageResult.AssociateWithLog(battleLogEntry_DamageTaken);
				}
				num2++;
			}
		}

		private static readonly FloatRange DamageRandomFactorRange = new FloatRange(0.8f, 1.2f);

		private static readonly float DamageCount = 5f;
	}
}