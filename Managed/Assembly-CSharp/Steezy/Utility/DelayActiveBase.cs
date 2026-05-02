using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000090 RID: 144
	public class DelayActiveBase : MonoBehaviour
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x00115053 File Offset: 0x00113253
		public static DelayActiveBase Instance
		{
			get
			{
				if (DelayActiveBase.instance == null)
				{
					DelayActiveBase.instance = (DelayActiveBase)Object.FindObjectOfType(typeof(DelayActiveBase));
				}
				return DelayActiveBase.instance;
			}
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00115080 File Offset: 0x00113280
		public void wakeUp(DelayActive da)
		{
			base.StartCoroutine(da.delayWakeUp());
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x0011508F File Offset: 0x0011328F
		private void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x04000965 RID: 2405
		private static DelayActiveBase instance;
	}
}
