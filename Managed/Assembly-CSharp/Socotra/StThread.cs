using System;
using System.Collections;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000F5 RID: 245
	public class StThread : StRunnable
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06001344 RID: 4932 RVA: 0x001203AD File Offset: 0x0011E5AD
		public StRunnable Runnable
		{
			get
			{
				return this.runnable;
			}
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x001203B5 File Offset: 0x0011E5B5
		public StThread(StRunnable runnable)
		{
			this.runnable = runnable;
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x001203C4 File Offset: 0x0011E5C4
		public StThread()
		{
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x001203CC File Offset: 0x0011E5CC
		public IEnumerator Run()
		{
			yield return null;
			yield break;
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x001203D4 File Offset: 0x0011E5D4
		public void SetPriority(int priority)
		{
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x001203D6 File Offset: 0x0011E5D6
		public void Start()
		{
			SingletonBehaviour<StThreadManager>.Instance.AddThread(this);
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x001203E3 File Offset: 0x0011E5E3
		public virtual void Interrupt()
		{
			SingletonBehaviour<StThreadManager>.Instance.RemoveThread(this);
		}

		// Token: 0x04000AD2 RID: 2770
		public const int MAX_PRIORITY = 10;

		// Token: 0x04000AD3 RID: 2771
		public const int MIN_PRIORITY = 1;

		// Token: 0x04000AD4 RID: 2772
		public const int NORM_PRIORITY = 5;

		// Token: 0x04000AD5 RID: 2773
		private StRunnable runnable;

		// Token: 0x04000AD6 RID: 2774
		public Coroutine coroutine;

		// Token: 0x04000AD7 RID: 2775
		public IEnumerator enumerator;
	}
}
