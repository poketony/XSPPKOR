using System;
using System.Collections.Generic;
using Steezy.Localize;
using Steezy.Utility;

// Token: 0x0200001A RID: 26
public class RankingSettings : SingletonData<RankingSettings>
{
	// Token: 0x06000077 RID: 119 RVA: 0x0000AC8D File Offset: 0x00008E8D
	public Dictionary<RankingSettings.Category, string> GetRankingTitleNameMap()
	{
		if (Localization.language == "ja")
		{
			return this.rankingTitleNameMap;
		}
		return this.rankingTitleNameMapEn;
	}

	// Token: 0x040000B2 RID: 178
	private Dictionary<RankingSettings.Category, string> rankingTitleNameMap = new Dictionary<RankingSettings.Category, string>
	{
		{
			RankingSettings.Category.Ranking,
			"ランキング"
		},
		{
			RankingSettings.Category.Ranking2,
			"ランキング2"
		},
		{
			RankingSettings.Category.Ranking3,
			"ランキング3"
		}
	};

	// Token: 0x040000B3 RID: 179
	private Dictionary<RankingSettings.Category, string> rankingTitleNameMapEn = new Dictionary<RankingSettings.Category, string>
	{
		{
			RankingSettings.Category.Ranking,
			"Ranking"
		},
		{
			RankingSettings.Category.Ranking2,
			"Ranking2"
		},
		{
			RankingSettings.Category.Ranking3,
			"Ranking3"
		}
	};

	// Token: 0x040000B4 RID: 180
	public static readonly Dictionary<RankingSettings.Category, string> SteamLeaderboardNameMap = new Dictionary<RankingSettings.Category, string>
	{
		{
			RankingSettings.Category.Ranking,
			"Ranking"
		},
		{
			RankingSettings.Category.Ranking2,
			"Ranking2"
		},
		{
			RankingSettings.Category.Ranking3,
			"Ranking3"
		}
	};

	// Token: 0x020001B4 RID: 436
	public enum Category
	{
		// Token: 0x040012BF RID: 4799
		Ranking = 1000,
		// Token: 0x040012C0 RID: 4800
		Ranking2,
		// Token: 0x040012C1 RID: 4801
		Ranking3
	}
}
