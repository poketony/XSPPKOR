using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Steezy.Utility
{
	// Token: 0x020000A8 RID: 168
	public class ObjectPool<T> where T : new()
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06001040 RID: 4160 RVA: 0x00117B0F File Offset: 0x00115D0F
		// (set) Token: 0x06001041 RID: 4161 RVA: 0x00117B17 File Offset: 0x00115D17
		public int countAll { get; private set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06001042 RID: 4162 RVA: 0x00117B20 File Offset: 0x00115D20
		public int countActive
		{
			get
			{
				return this.countAll - this.countInactive;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06001043 RID: 4163 RVA: 0x00117B2F File Offset: 0x00115D2F
		public int countInactive
		{
			get
			{
				return this.m_Stack.Count;
			}
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00117B3C File Offset: 0x00115D3C
		public ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x00117B60 File Offset: 0x00115D60
		public T Get()
		{
			T t;
			if (this.m_Stack.Count == 0)
			{
				t = new T();
				int countAll = this.countAll;
				this.countAll = countAll + 1;
			}
			else
			{
				t = this.m_Stack.Pop();
			}
			if (this.m_ActionOnGet != null)
			{
				this.m_ActionOnGet.Invoke(t);
			}
			return t;
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x00117BB4 File Offset: 0x00115DB4
		public void Release(T element)
		{
			if (this.m_Stack.Count > 0 && this.m_Stack.Peek() == element)
			{
				Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
			}
			if (this.m_ActionOnRelease != null)
			{
				this.m_ActionOnRelease.Invoke(element);
			}
			this.m_Stack.Push(element);
		}

		// Token: 0x040009A1 RID: 2465
		private readonly Stack<T> m_Stack = new Stack<T>();

		// Token: 0x040009A2 RID: 2466
		private readonly UnityAction<T> m_ActionOnGet;

		// Token: 0x040009A3 RID: 2467
		private readonly UnityAction<T> m_ActionOnRelease;
	}
}
