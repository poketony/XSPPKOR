using System;
using Steezy.Utility;

namespace Socotra
{
	// Token: 0x020000E7 RID: 231
	public class StCalendar : SingletonBehaviour<StCalendar>
	{
		// Token: 0x060012FA RID: 4858 RVA: 0x0011F66F File Offset: 0x0011D86F
		public static StCalendar GetInstance()
		{
			StCalendar.dateTime = DateTime.Now;
			return SingletonBehaviour<StCalendar>.Instance;
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x0011F680 File Offset: 0x0011D880
		private void Start()
		{
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x0011F684 File Offset: 0x0011D884
		public int Get(int type)
		{
			switch (type)
			{
			case 1:
				return StCalendar.dateTime.Year;
			case 2:
				return StCalendar.dateTime.Month - 1;
			case 5:
				return StCalendar.dateTime.Day;
			case 7:
				return (int)(StCalendar.dateTime.DayOfWeek + 1);
			case 9:
				if (StCalendar.dateTime.Hour <= 12)
				{
					return 0;
				}
				return 1;
			case 10:
			{
				int hour = StCalendar.dateTime.Hour;
				if (hour < 12)
				{
					return hour;
				}
				return hour - 12;
			}
			case 11:
				return StCalendar.dateTime.Hour;
			case 12:
				return StCalendar.dateTime.Minute;
			case 13:
				return StCalendar.dateTime.Second;
			case 14:
				return StCalendar.dateTime.Millisecond;
			}
			return 0;
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x0011F75C File Offset: 0x0011D95C
		public DateTime GetTime()
		{
			return StCalendar.dateTime;
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x0011F764 File Offset: 0x0011D964
		public long GetTimeInMillis()
		{
			return (long)StCalendar.dateTime.ToUniversalTime().Subtract(StCalendar.UnixEpoch).TotalMilliseconds;
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x0011F791 File Offset: 0x0011D991
		public void SetTime(DateTime date)
		{
			StCalendar.dateTime = date;
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x0011F79C File Offset: 0x0011D99C
		public void SetTimeInMillis(long millis)
		{
			StCalendar.dateTime = StCalendar.UnixEpoch.AddMilliseconds((double)millis).ToLocalTime();
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x0011F7C4 File Offset: 0x0011D9C4
		public static DateTime CreateDate(long milliSecondsSinceEpoch)
		{
			return new DateTime(StCalendar.UnixEpoch.Ticks + milliSecondsSinceEpoch * 10000L).ToLocalTime();
		}

		// Token: 0x04000A8A RID: 2698
		public const int AM = 0;

		// Token: 0x04000A8B RID: 2699
		public const int AM_PM = 9;

		// Token: 0x04000A8C RID: 2700
		public const int APRIL = 3;

		// Token: 0x04000A8D RID: 2701
		public const int AUGUST = 7;

		// Token: 0x04000A8E RID: 2702
		public const int DATE = 5;

		// Token: 0x04000A8F RID: 2703
		public const int DAY_OF_MONTH = 5;

		// Token: 0x04000A90 RID: 2704
		public const int DAY_OF_WEEK = 7;

		// Token: 0x04000A91 RID: 2705
		public const int DECEMBER = 11;

		// Token: 0x04000A92 RID: 2706
		public const int FEBRUARY = 1;

		// Token: 0x04000A93 RID: 2707
		protected int[] fields;

		// Token: 0x04000A94 RID: 2708
		public const int FRIDAY = 6;

		// Token: 0x04000A95 RID: 2709
		public const int HOUR = 10;

		// Token: 0x04000A96 RID: 2710
		public const int HOUR_OF_DAY = 11;

		// Token: 0x04000A97 RID: 2711
		protected bool[] isSet;

		// Token: 0x04000A98 RID: 2712
		public const int JANUARY = 0;

		// Token: 0x04000A99 RID: 2713
		public const int JULY = 6;

		// Token: 0x04000A9A RID: 2714
		public const int JUNE = 5;

		// Token: 0x04000A9B RID: 2715
		public const int MARCH = 2;

		// Token: 0x04000A9C RID: 2716
		public const int MAY = 4;

		// Token: 0x04000A9D RID: 2717
		public const int MILLISECOND = 14;

		// Token: 0x04000A9E RID: 2718
		public const int MINUTE = 12;

		// Token: 0x04000A9F RID: 2719
		public const int MONDAY = 2;

		// Token: 0x04000AA0 RID: 2720
		public const int MONTH = 2;

		// Token: 0x04000AA1 RID: 2721
		public const int NOVEMBER = 10;

		// Token: 0x04000AA2 RID: 2722
		public const int OCTOBER = 9;

		// Token: 0x04000AA3 RID: 2723
		public const int PM = 1;

		// Token: 0x04000AA4 RID: 2724
		public const int SATURDAY = 7;

		// Token: 0x04000AA5 RID: 2725
		public const int SECOND = 13;

		// Token: 0x04000AA6 RID: 2726
		public const int SEPTEMBER = 8;

		// Token: 0x04000AA7 RID: 2727
		public const int SUNDAY = 1;

		// Token: 0x04000AA8 RID: 2728
		public const int THURSDAY = 5;

		// Token: 0x04000AA9 RID: 2729
		public const int TUESDAY = 3;

		// Token: 0x04000AAA RID: 2730
		public const int WEDNESDAY = 4;

		// Token: 0x04000AAB RID: 2731
		public const int YEAR = 1;

		// Token: 0x04000AAC RID: 2732
		public static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x04000AAD RID: 2733
		public static DateTime dateTime;
	}
}
