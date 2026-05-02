using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x0200009A RID: 154
	public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x00116B94 File Offset: 0x00114D94
		public static T Instance
		{
			get
			{
				if (SingletonBehaviour<T>.instance == null)
				{
					SingletonBehaviour<T>.instance = Object.FindObjectOfType(typeof(T)) as T;
					SingletonBehaviour<T>.instance == null;
				}
				return SingletonBehaviour<T>.instance;
			}
		}

		// Token: 0x04000981 RID: 2433
		private static T instance;
	}
}
