using System;
using System.Collections.Generic;
using Steezy.Utility;

namespace Socotra
{
	// Token: 0x020000F6 RID: 246
	public class StThreadManager : SingletonBehaviour<StThreadManager>
	{
		// Token: 0x0600134B RID: 4939 RVA: 0x001203F0 File Offset: 0x0011E5F0
		private void Start()
		{
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x001203F2 File Offset: 0x0011E5F2
		private void Update()
		{
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x001203F4 File Offset: 0x0011E5F4
		public void AddThread(StThread thread)
		{
			if (!this.threadList.Contains(thread))
			{
				if (thread.Runnable != null)
				{
					thread.enumerator = thread.Runnable.Run();
				}
				else
				{
					thread.enumerator = thread.Run();
				}
				thread.coroutine = base.StartCoroutine(thread.enumerator);
				this.threadList.Add(thread);
			}
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x00120454 File Offset: 0x0011E654
		public void RemoveThread(StThread thread)
		{
			if (this.threadList.Contains(thread))
			{
				base.StopCoroutine(thread.enumerator);
				this.threadList.Remove(thread);
			}
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0012047D File Offset: 0x0011E67D
		public void Pause()
		{
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x0012047F File Offset: 0x0011E67F
		public void Restart()
		{
		}

		// Token: 0x04000AD8 RID: 2776
		private List<StThread> threadList = new List<StThread>();
	}
}
