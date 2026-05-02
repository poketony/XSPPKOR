using System;
using System.Collections.Generic;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200004D RID: 77
public class RankingManager : SingletonBehaviour<RankingManager>
{
	// Token: 0x06000D98 RID: 3480 RVA: 0x0010CDEF File Offset: 0x0010AFEF
	private void Awake()
	{
		this.rankingManager = new DummyRankingManager();
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x0010CDFC File Offset: 0x0010AFFC
	public void Init(Dictionary<int, long> savedScoreDataMap)
	{
		Debug.Log("RankingManager Init()");
		this.savedScoreDataMap = savedScoreDataMap;
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x0010CE0F File Offset: 0x0010B00F
	public void GetRankingData(UnityAction<bool> callback, UnityAction sysErrorCallback)
	{
		this.GetRankingDataAsync(1000, callback, sysErrorCallback);
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x0010CE1E File Offset: 0x0010B01E
	public void GetRankingDataAsync(int category, UnityAction<bool> callback, UnityAction sysErrorCallback)
	{
		if (!this.m_UseConnectRanking)
		{
			callback.Invoke(true);
			return;
		}
		this.rankingManager.GetRankingDataAsync(category, callback, sysErrorCallback);
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x0010CE3E File Offset: 0x0010B03E
	public List<RankingData> GetTopRankDataList()
	{
		return this.rankingManager.GetTopRankDataList();
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x0010CE4B File Offset: 0x0010B04B
	public RankingData GetMyRankData()
	{
		return this.rankingManager.GetMyRankData();
	}

	// Token: 0x06000D9E RID: 3486 RVA: 0x0010CE58 File Offset: 0x0010B058
	public void SubmitScore(int category, long score, RankingManager.RankingSortOrder rankingSortOrder)
	{
		if (this.SetSavedScoreData(category, score, rankingSortOrder))
		{
			this.rankingManager.SubmitScore(category, score, false, delegate(bool result)
			{
			}, delegate
			{
			});
		}
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x0010CEBC File Offset: 0x0010B0BC
	public void SubmitScore(long score, UnityAction<bool> callback, UnityAction sysErrorCallback)
	{
		if (!this.m_UseConnectRanking)
		{
			callback.Invoke(true);
			return;
		}
		this.rankingManager.SubmitScore(1000, score, false, callback, sysErrorCallback);
	}

	// Token: 0x06000DA0 RID: 3488 RVA: 0x0010CEE4 File Offset: 0x0010B0E4
	public void SyncSubmitScore(int category, UnityAction<bool> callback, UnityAction sysErrorCallback)
	{
		long? savedScoreData = this.GetSavedScoreData(category);
		if (savedScoreData != null)
		{
			this.rankingManager.SubmitScore(category, savedScoreData.Value, true, callback, sysErrorCallback);
			return;
		}
		callback.Invoke(true);
	}

	// Token: 0x06000DA1 RID: 3489 RVA: 0x0010CF20 File Offset: 0x0010B120
	private long? GetSavedScoreData(int category)
	{
		if (this.savedScoreDataMap.ContainsKey(category))
		{
			return new long?(this.savedScoreDataMap[category]);
		}
		return null;
	}

	// Token: 0x06000DA2 RID: 3490 RVA: 0x0010CF58 File Offset: 0x0010B158
	private bool SetSavedScoreData(int category, long score, RankingManager.RankingSortOrder rankingSortOrder)
	{
		long? savedScoreData = this.GetSavedScoreData(category);
		bool flag = false;
		if (savedScoreData == null)
		{
			flag = true;
		}
		else if (rankingSortOrder == RankingManager.RankingSortOrder.Descending)
		{
			long? num = savedScoreData;
			if ((score > num.GetValueOrDefault()) & (num != null))
			{
				flag = true;
			}
		}
		else
		{
			long? num = savedScoreData;
			if ((score < num.GetValueOrDefault()) & (num != null))
			{
				flag = true;
			}
		}
		if (flag)
		{
			this.savedScoreDataMap[category] = score;
			SaveDataManager.SaveRankingScoreDataMap(this.savedScoreDataMap, true);
		}
		return flag;
	}

	// Token: 0x04000817 RID: 2071
	public const int GetTopRankingCount = 100;

	// Token: 0x04000818 RID: 2072
	[SerializeField]
	private bool m_UseConnectRanking = true;

	// Token: 0x04000819 RID: 2073
	private RankingManager.IRankingManager rankingManager;

	// Token: 0x0400081A RID: 2074
	private Dictionary<int, long> savedScoreDataMap = new Dictionary<int, long>();

	// Token: 0x020001D5 RID: 469
	public enum RankingSortOrder
	{
		// Token: 0x0400133C RID: 4924
		Descending,
		// Token: 0x0400133D RID: 4925
		Ascending
	}

	// Token: 0x020001D6 RID: 470
	public abstract class IRankingManager
	{
		// Token: 0x06001C45 RID: 7237 RVA: 0x00145457 File Offset: 0x00143657
		public virtual void Init()
		{
		}

		// Token: 0x06001C46 RID: 7238
		public abstract void GetRankingDataAsync(int category, UnityAction<bool> callback, UnityAction sysErrorCallback);

		// Token: 0x06001C47 RID: 7239
		public abstract List<RankingData> GetTopRankDataList();

		// Token: 0x06001C48 RID: 7240
		public abstract RankingData GetMyRankData();

		// Token: 0x06001C49 RID: 7241
		public abstract void SubmitScore(int category, long score, bool isShowError, UnityAction<bool> callback, UnityAction sysErrorCallback);
	}
}
