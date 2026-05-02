using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000016 RID: 22
[RequireComponent(typeof(InfiniteScroll))]
public class RankingListControllerLimited : UIBehaviour, IInfiniteScrollSetup
{
	// Token: 0x06000071 RID: 113 RVA: 0x0000AC5B File Offset: 0x00008E5B
	public void OnPostSetupItems()
	{
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000AC5D File Offset: 0x00008E5D
	public void OnUpdateItem(int itemCount, GameObject obj)
	{
	}

	// Token: 0x04000091 RID: 145
	private int max;
}
