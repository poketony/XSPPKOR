using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x0200008E RID: 142
	public class WaitForAnimation : CustomYieldInstruction
	{
		// Token: 0x06000F67 RID: 3943 RVA: 0x00114F6C File Offset: 0x0011316C
		public WaitForAnimation(Animator animator, int layerNo)
		{
			this.Init(animator, layerNo, animator.GetCurrentAnimatorStateInfo(layerNo).fullPathHash);
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x00114F96 File Offset: 0x00113196
		private void Init(Animator animator, int layerNo, int hash)
		{
			this.m_layerNo = layerNo;
			this.m_animator = animator;
			this.m_lastStateHash = hash;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000F69 RID: 3945 RVA: 0x00114FB0 File Offset: 0x001131B0
		public override bool keepWaiting
		{
			get
			{
				AnimatorStateInfo currentAnimatorStateInfo = this.m_animator.GetCurrentAnimatorStateInfo(this.m_layerNo);
				return currentAnimatorStateInfo.fullPathHash == this.m_lastStateHash && currentAnimatorStateInfo.normalizedTime < 1f;
			}
		}

		// Token: 0x0400095F RID: 2399
		private Animator m_animator;

		// Token: 0x04000960 RID: 2400
		private int m_lastStateHash;

		// Token: 0x04000961 RID: 2401
		private int m_layerNo;
	}
}
