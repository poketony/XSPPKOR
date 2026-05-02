using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200004A RID: 74
[RequireComponent(typeof(RankingManager))]
public class AppliArchiveRankingManager : SingletonBehaviour<AppliArchiveRankingManager>
{
	// Token: 0x06000D8A RID: 3466 RVA: 0x0010CCF1 File Offset: 0x0010AEF1
	public void SubmitScore(RankingSettings.Category category, long score, RankingManager.RankingSortOrder rankingSortOrder)
	{
		this.SubmitScore((int)category, score, rankingSortOrder);
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x0010CCFC File Offset: 0x0010AEFC
	public void SubmitScore(int category, long score, RankingManager.RankingSortOrder rankingSortOrder)
	{
		SingletonBehaviour<RankingManager>.Instance.SubmitScore(category, score, rankingSortOrder);
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x0010CD0B File Offset: 0x0010AF0B
	private void LateUpdate()
	{
		if (this.isShowDialog)
		{
			this.isShowDialog = false;
			this.ShowRankingDialogAndPause(this.firstViewCategory, this.onCloseCallback);
		}
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x0010CD30 File Offset: 0x0010AF30
	public void ShowRankingDialog(UnityAction onCloseCallback = null)
	{
		this.ShowRankingDialog(null, onCloseCallback);
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x0010CD4D File Offset: 0x0010AF4D
	public void ShowRankingDialog(int firstViewCategory, UnityAction onCloseCallback = null)
	{
		this.ShowRankingDialog(new RankingSettings.Category?((RankingSettings.Category)firstViewCategory), onCloseCallback);
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x0010CD5C File Offset: 0x0010AF5C
	public void ShowRankingDialog(RankingSettings.Category? firstViewCategory, UnityAction onCloseCallback = null)
	{
		this.firstViewCategory = firstViewCategory;
		this.onCloseCallback = onCloseCallback;
		this.isShowDialog = true;
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x0010CD73 File Offset: 0x0010AF73
	private void ShowRankingDialogAndPause(RankingSettings.Category? firstViewCategory, UnityAction onCloseCallback = null)
	{
		SingletonBehaviour<AppliArchive>.Instance.Pause(null);
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Ranking", delegate(GameObject popupObj)
		{
		}, true);
	}

	// Token: 0x04000811 RID: 2065
	private bool isShowDialog;

	// Token: 0x04000812 RID: 2066
	private RankingSettings.Category? firstViewCategory;

	// Token: 0x04000813 RID: 2067
	private UnityAction onCloseCallback;
}
