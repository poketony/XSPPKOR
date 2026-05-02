using System;

// Token: 0x0200004C RID: 76
public class RankingData
{
	// Token: 0x06000D97 RID: 3479 RVA: 0x0010CDDC File Offset: 0x0010AFDC
	public RankingData()
	{
		this.commonData = new RankingData.RankingCommonData();
	}

	// Token: 0x04000814 RID: 2068
	public int rank;

	// Token: 0x04000815 RID: 2069
	public long score;

	// Token: 0x04000816 RID: 2070
	public RankingData.RankingCommonData commonData;

	// Token: 0x020001D4 RID: 468
	public class RankingCommonData
	{
		// Token: 0x06001C43 RID: 7235 RVA: 0x00145440 File Offset: 0x00143640
		public RankingCommonData()
		{
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x00145448 File Offset: 0x00143648
		public RankingCommonData(string userName)
		{
			this.userName = userName;
		}

		// Token: 0x0400133A RID: 4922
		public string userName;
	}
}
