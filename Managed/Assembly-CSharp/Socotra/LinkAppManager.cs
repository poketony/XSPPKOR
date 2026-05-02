using System;
using System.Collections.Generic;
using Socotra.UI;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000DB RID: 219
	public class LinkAppManager : SingletonBehaviour<LinkAppManager>
	{
		// Token: 0x060012A6 RID: 4774 RVA: 0x0011ED4C File Offset: 0x0011CF4C
		public void StartApp(int appIndex)
		{
			foreach (int num in this.targetSoftKeys)
			{
				string softkeyLabel = SingletonBehaviour<StDisplay>.Instance.GetSoftkeyLabel(num);
				if (!this.backupSoftKeyLabel.ContainsKey(appIndex))
				{
					this.backupSoftKeyLabel.Add(appIndex, new Dictionary<int, string>());
				}
				if (!this.backupSoftKeyLabel[appIndex].ContainsKey(num))
				{
					this.backupSoftKeyLabel[appIndex].Add(num, softkeyLabel);
				}
				else
				{
					this.backupSoftKeyLabel[appIndex][num] = softkeyLabel;
				}
			}
			this.nowAppIndexQueue.Enqueue(appIndex);
			this.applications[appIndex].Started(0);
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x0011EDF4 File Offset: 0x0011CFF4
		public void ResumeApp(int appIndex)
		{
			if (this.nowAppIndexQueue.Count <= 1)
			{
				return;
			}
			this.nowAppIndexQueue.Dequeue();
			int num = this.nowAppIndexQueue.Peek();
			foreach (KeyValuePair<int, string> keyValuePair in this.backupSoftKeyLabel[num])
			{
				SingletonBehaviour<StDisplay>.Instance.SetSoftkeyLabel(keyValuePair.Key, keyValuePair.Value);
			}
			this.applications[appIndex].Resume();
		}

		// Token: 0x04000A6F RID: 2671
		[SerializeField]
		private StApplication[] applications;

		// Token: 0x04000A70 RID: 2672
		private Queue<int> nowAppIndexQueue = new Queue<int>();

		// Token: 0x04000A71 RID: 2673
		private Dictionary<int, Dictionary<int, string>> backupSoftKeyLabel = new Dictionary<int, Dictionary<int, string>>();

		// Token: 0x04000A72 RID: 2674
		private readonly int[] targetSoftKeys = new int[] { 0, 1 };
	}
}
