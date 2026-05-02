using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.PageFlow
{
	// Token: 0x020000CA RID: 202
	[RequireComponent(typeof(Selectable))]
	public class DefaultSelected : MonoBehaviour
	{
		// Token: 0x0600122A RID: 4650 RVA: 0x0011D351 File Offset: 0x0011B551
		private void Start()
		{
			if (this.delaySelectTime > 0f)
			{
				base.StartCoroutine(this.DelayCoroutine());
				return;
			}
			base.GetComponent<Selectable>().Select();
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x0011D379 File Offset: 0x0011B579
		private IEnumerator DelayCoroutine()
		{
			yield return new WaitForSecondsRealtime(this.delaySelectTime);
			base.GetComponent<Selectable>().Select();
			yield break;
		}

		// Token: 0x04000A2C RID: 2604
		public float delaySelectTime;
	}
}
