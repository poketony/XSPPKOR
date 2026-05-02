using System;
using System.Collections;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x0200008F RID: 143
	public class DelayActive : MonoBehaviour
	{
		// Token: 0x06000F6A RID: 3946 RVA: 0x00114FEE File Offset: 0x001131EE
		private void LateUpdate()
		{
			if (this.disabledFlg)
			{
				base.gameObject.SetActive(false);
				this.disabledFlg = false;
			}
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x0011500B File Offset: 0x0011320B
		private void OnEnable()
		{
			if (!this.enabledFlg)
			{
				DelayActiveBase.Instance.wakeUp(this);
				this.enabledFlg = true;
				return;
			}
			this.enabledFlg = false;
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x0011502F File Offset: 0x0011322F
		public IEnumerator delayWakeUp()
		{
			this.disabledFlg = true;
			yield return new WaitForSeconds(this.delayTime);
			if (base.gameObject != null)
			{
				base.gameObject.SetActive(true);
			}
			yield break;
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x0011503E File Offset: 0x0011323E
		public void PlayDelayActive()
		{
			DelayActiveBase.Instance.wakeUp(this);
		}

		// Token: 0x04000962 RID: 2402
		public float delayTime;

		// Token: 0x04000963 RID: 2403
		private bool enabledFlg;

		// Token: 0x04000964 RID: 2404
		private bool disabledFlg;
	}
}
