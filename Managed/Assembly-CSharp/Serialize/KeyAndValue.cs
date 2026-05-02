using System;
using System.Collections.Generic;

namespace Serialize
{
	// Token: 0x020000DA RID: 218
	[Serializable]
	public class KeyAndValue<TKey, TValue>
	{
		// Token: 0x060012A4 RID: 4772 RVA: 0x0011ED14 File Offset: 0x0011CF14
		public KeyAndValue(TKey key, TValue value)
		{
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x0011ED2A File Offset: 0x0011CF2A
		public KeyAndValue(KeyValuePair<TKey, TValue> pair)
		{
			this.Key = pair.Key;
			this.Value = pair.Value;
		}

		// Token: 0x04000A6D RID: 2669
		public TKey Key;

		// Token: 0x04000A6E RID: 2670
		public TValue Value;
	}
}
