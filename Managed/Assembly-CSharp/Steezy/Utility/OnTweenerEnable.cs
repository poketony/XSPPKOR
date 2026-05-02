using System;
using UnityEngine;
using uTools;

namespace Steezy.Utility
{
	// Token: 0x020000AE RID: 174
	public class OnTweenerEnable : MonoBehaviour
	{
		// Token: 0x06001067 RID: 4199 RVA: 0x001183C4 File Offset: 0x001165C4
		private void OnEnable()
		{
			foreach (Tweener tweener in base.GetComponentsInChildren<Tweener>())
			{
				if (this.tweenResetToBeginning)
				{
					tweener.ResetToBeginning();
					tweener.tweenFactor = 0f;
				}
				tweener.enabled = true;
			}
		}

		// Token: 0x040009B4 RID: 2484
		public bool tweenResetToBeginning = true;
	}
}
