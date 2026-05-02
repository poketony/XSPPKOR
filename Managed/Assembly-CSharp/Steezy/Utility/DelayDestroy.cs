using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000091 RID: 145
	public class DelayDestroy : MonoBehaviour
	{
		// Token: 0x06000F73 RID: 3955 RVA: 0x0011509F File Offset: 0x0011329F
		private void Start()
		{
			Object.Destroy(base.gameObject, this.delayTime);
		}

		// Token: 0x04000966 RID: 2406
		public float delayTime;
	}
}
