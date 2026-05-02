using System;

namespace Steezy.Utility
{
	// Token: 0x020000B7 RID: 183
	public static class TimeUtil
	{
		// Token: 0x060010B9 RID: 4281 RVA: 0x00119A50 File Offset: 0x00117C50
		public static DateTime GetDateTimeNowUtc()
		{
			return DateTime.UtcNow;
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x00119A57 File Offset: 0x00117C57
		public static DateTime GetDateTimeNow()
		{
			return DateTime.Now;
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x00119A5E File Offset: 0x00117C5E
		public static DateTime ToStringToDateTime(string val)
		{
			return DateTime.FromBinary(Convert.ToInt64(val));
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x00119A6C File Offset: 0x00117C6C
		public static string ToDateTimeToString(DateTime val)
		{
			return val.ToBinary().ToString();
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x00119A88 File Offset: 0x00117C88
		public static string ToHHmmssFormatString(this TimeSpan timeSpan)
		{
			TimeSpan timeSpan2 = timeSpan;
			string text;
			if (timeSpan2.Ticks <= 0L)
			{
				text = string.Format("{0:0}:{1:00}:{2:00}", 0, 0, 0);
			}
			else
			{
				text = string.Format("{0:0}:{1:00}:{2:00}", timeSpan2.Hours, timeSpan2.Minutes, timeSpan2.Seconds);
			}
			return text;
		}
	}
}
