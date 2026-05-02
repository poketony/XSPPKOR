using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000A2 RID: 162
	public interface IInfiniteScrollSetup
	{
		// Token: 0x06001021 RID: 4129
		void OnPostSetupItems();

		// Token: 0x06001022 RID: 4130
		void OnUpdateItem(int itemCount, GameObject obj);
	}
}
