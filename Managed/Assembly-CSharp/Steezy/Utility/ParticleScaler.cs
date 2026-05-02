using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000097 RID: 151
	[RequireComponent(typeof(ParticleSystem))]
	[ExecuteInEditMode]
	public class ParticleScaler : MonoBehaviour
	{
		// Token: 0x06000FAB RID: 4011 RVA: 0x001159C8 File Offset: 0x00113BC8
		private void LateUpdate()
		{
			this.InitializeIfNeeded();
			int particles = this.m_System.GetParticles(this.m_Particles);
			float num = (base.transform.localScale.x + base.transform.localScale.y + base.transform.localScale.z) / 3f;
			this.m_System.main.startSpeed = this.m_StartSpeed * num;
			for (int i = 0; i < particles; i++)
			{
				this.m_Particles[i].startSize = num * this.m_Size;
			}
			this.m_System.SetParticles(this.m_Particles, particles);
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x00115A80 File Offset: 0x00113C80
		private void InitializeIfNeeded()
		{
			if (this.m_System == null)
			{
				this.m_System = base.GetComponent<ParticleSystem>();
			}
			ParticleSystem.MainModule main = this.m_System.main;
			if (this.m_Particles == null || this.m_Particles.Length < main.maxParticles)
			{
				this.m_Particles = new ParticleSystem.Particle[main.maxParticles];
			}
		}

		// Token: 0x04000977 RID: 2423
		private ParticleSystem m_System;

		// Token: 0x04000978 RID: 2424
		private ParticleSystem.Particle[] m_Particles;

		// Token: 0x04000979 RID: 2425
		public float m_Size = 1f;

		// Token: 0x0400097A RID: 2426
		public float m_StartSpeed = 1f;
	}
}
