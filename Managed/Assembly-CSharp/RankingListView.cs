using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000019 RID: 25
public class RankingListView : SingletonBehaviour<RankingListView>
{
	// Token: 0x04000099 RID: 153
	[SerializeField]
	private ButtonPopupCloseAnimation closeAnimation;

	// Token: 0x0400009A RID: 154
	[SerializeField]
	private RankingListItem playerRankingItem;

	// Token: 0x0400009B RID: 155
	[SerializeField]
	private GameObject loadingObj;

	// Token: 0x0400009C RID: 156
	[SerializeField]
	private InfiniteScroll infiniteScroll;

	// Token: 0x0400009D RID: 157
	[SerializeField]
	private ScrollRect scrollRect;

	// Token: 0x0400009E RID: 158
	[SerializeField]
	private GameObject arrowLeftObj;

	// Token: 0x0400009F RID: 159
	[SerializeField]
	private GameObject arrowRightObj;

	// Token: 0x040000A0 RID: 160
	[SerializeField]
	private Text rankingTitleText;

	// Token: 0x040000A1 RID: 161
	[SerializeField]
	private GameObject getRankingObj;

	// Token: 0x040000A2 RID: 162
	[SerializeField]
	private GameObject backIconBackObj;

	// Token: 0x040000A3 RID: 163
	private int listCnt;

	// Token: 0x040000A4 RID: 164
	private const int CenterListItemCnt = 10;

	// Token: 0x040000A5 RID: 165
	private const float ScrollSpeed = 20f;

	// Token: 0x040000A6 RID: 166
	private const float KeyDownMoveFirstDelayTime = 0.5f;

	// Token: 0x040000A7 RID: 167
	private const float KeyDownMoveDelayTime = 0.2f;

	// Token: 0x040000A8 RID: 168
	private bool isInputStart;

	// Token: 0x040000A9 RID: 169
	private bool isInitRanking;

	// Token: 0x040000AA RID: 170
	private bool isCallBackFlow;

	// Token: 0x040000AB RID: 171
	private int pageCount = 1;

	// Token: 0x040000AC RID: 172
	private int nowPage = 1;

	// Token: 0x040000AD RID: 173
	private bool enableGetRanking;

	// Token: 0x040000AE RID: 174
	private float mKeyDownTimeLeft;

	// Token: 0x040000AF RID: 175
	private float mKeyDownTimeRight;

	// Token: 0x040000B0 RID: 176
	private UnityAction _onCloseCallback;

	// Token: 0x040000B1 RID: 177
	private bool _playPopupCloseAnimation;
}
