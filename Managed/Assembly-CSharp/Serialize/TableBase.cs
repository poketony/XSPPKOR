using System;
using System.Collections.Generic;
using UnityEngine;

namespace Serialize
{
	// Token: 0x020000D9 RID: 217
	[Serializable]
	public class TableBase<TKey, TValue, Type> where Type : KeyAndValue<TKey, TValue>
	{
		// Token: 0x060012A0 RID: 4768 RVA: 0x0011EC78 File Offset: 0x0011CE78
		public Dictionary<TKey, TValue> GetTable()
		{
			if (this.table == null)
			{
				this.table = TableBase<TKey, TValue, Type>.ConvertListToDictionary(this.list);
			}
			return this.table;
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x0011EC99 File Offset: 0x0011CE99
		public List<Type> GetList()
		{
			return this.list;
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x0011ECA4 File Offset: 0x0011CEA4
		private static Dictionary<TKey, TValue> ConvertListToDictionary(List<Type> list)
		{
			Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
			foreach (Type type in list)
			{
				KeyAndValue<TKey, TValue> keyAndValue = type;
				dictionary.Add(keyAndValue.Key, keyAndValue.Value);
			}
			return dictionary;
		}

		// Token: 0x04000A6B RID: 2667
		[SerializeField]
		private List<Type> list;

		// Token: 0x04000A6C RID: 2668
		private Dictionary<TKey, TValue> table;
	}
}
