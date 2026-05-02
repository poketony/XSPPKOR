using System;
using System.Collections;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000092 RID: 146
	public class DelayInActive : MonoBehaviour
	{
		// Token: 0x06000F75 RID: 3957 RVA: 0x001150BA File Offset: 0x001132BA
		private void OnEnable()
		{
			if (!this.enabledFlg)
			{
				base.StartCoroutine(this.delayInactive());
				this.enabledFlg = true;
			}
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x001150D8 File Offset: 0x001132D8
		public IEnumerator delayInactive()
		{
			yield return new WaitForSeconds(this.delayTime);
			base.gameObject.SetActive(false);
			yield break;
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x001150E7 File Offset: 0x001132E7
		private void OnDisable()
		{
			this.enabledFlg = false;
		}

		// Token: 0x04000967 RID: 2407
		public float delayTime;

		// Token: 0x04000968 RID: 2408
		private bool enabledFlg;
	}
}
