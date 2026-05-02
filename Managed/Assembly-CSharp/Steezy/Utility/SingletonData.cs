using System;

namespace Steezy.Utility
{
	// Token: 0x0200009B RID: 155
	public abstract class SingletonData<T> where T : class, new()
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x00116BEF File Offset: 0x00114DEF
		public static T Instance
		{
			get
			{
				if (SingletonData<T>.inst == null)
				{
					SingletonData<T>.inst = new T();
				}
				return SingletonData<T>.inst;
			}
		}

		// Token: 0x04000982 RID: 2434
		private static T inst;
	}
}
