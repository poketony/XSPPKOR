using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000098 RID: 152
	[RequireComponent(typeof(ParticleSystem))]
	public class UnscaledTimeParticle : MonoBehaviour
	{
		// Token: 0x06000FAE RID: 4014 RVA: 0x00115AFC File Offset: 0x00113CFC
		private void Awake()
		{
			this.ps = base.GetComponent<ParticleSystem>();
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00115B0A File Offset: 0x00113D0A
		private void Update()
		{
			if (Time.timeScale < 0.01f)
			{
				this.ps.Simulate(Time.unscaledDeltaTime, true, false);
			}
		}

		// Token: 0x0400097B RID: 2427
		private ParticleSystem ps;
	}
}
