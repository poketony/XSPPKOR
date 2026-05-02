using System;
using System.Collections.Generic;
using UnityEngine.Events;

// Token: 0x0200004B RID: 75
public class DummyRankingManager : RankingManager.IRankingManager
{
	// Token: 0x06000D92 RID: 3474 RVA: 0x0010CDB7 File Offset: 0x0010AFB7
	public override void GetRankingDataAsync(int category, UnityAction<bool> callback, UnityAction sysErrorCallback)
	{
		callback.Invoke(true);
	}

	// Token: 0x06000D93 RID: 3475 RVA: 0x0010CDC0 File Offset: 0x0010AFC0
	public override List<RankingData> GetTopRankDataList()
	{
		return new List<RankingData>();
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x0010CDC7 File Offset: 0x0010AFC7
	public override RankingData GetMyRankData()
	{
		return null;
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x0010CDCA File Offset: 0x0010AFCA
	public override void SubmitScore(int category, long score, bool isShowError, UnityAction<bool> callback, UnityAction sysErrorCallback)
	{
		callback.Invoke(true);
	}
}
