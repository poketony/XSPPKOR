using System;
using System.Collections.Generic;

namespace Steezy.Utility
{
	// Token: 0x020000A6 RID: 166
	internal static class ListPool<T>
	{
		// Token: 0x0600103A RID: 4154 RVA: 0x00117A91 File Offset: 0x00115C91
		public static List<T> Get()
		{
			return ListPool<T>.s_ListPool.Get();
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x00117A9D File Offset: 0x00115C9D
		public static void Release(List<T> toRelease)
		{
			ListPool<T>.s_ListPool.Release(toRelease);
		}

		// Token: 0x040009A0 RID: 2464
		private static readonly ObjectPool<List<T>> s_ListPool = new ObjectPool<List<T>>(null, delegate(List<T> l)
		{
			l.Clear();
		});
	}
}
