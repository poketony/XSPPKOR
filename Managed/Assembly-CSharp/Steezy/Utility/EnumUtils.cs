using System;
using System.Linq;

namespace Steezy.Utility
{
	// Token: 0x020000B2 RID: 178
	public static class EnumUtils
	{
		// Token: 0x060010A0 RID: 4256 RVA: 0x0011913C File Offset: 0x0011733C
		public static T Random<T>()
		{
			return (from T c in Enum.GetValues(typeof(T))
				orderby EnumUtils.mRandom.Next()
				select c).FirstOrDefault<T>();
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x0011917B File Offset: 0x0011737B
		public static int GetLength<T>()
		{
			return Enum.GetValues(typeof(T)).Length;
		}

		// Token: 0x040009B5 RID: 2485
		private static readonly Random mRandom = new Random();
	}
}
