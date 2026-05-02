using System;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000DD RID: 221
	public class Resources3D : Resources
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x0011EF5B File Offset: 0x0011D15B
		public Resources3D.Type Type3D
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x04000A74 RID: 2676
		[SerializeField]
		private Resources3D.Type type;

		// Token: 0x02000237 RID: 567
		public enum Type
		{
			// Token: 0x040014D4 RID: 5332
			Model = 2,
			// Token: 0x040014D5 RID: 5333
			Animation = 1,
			// Token: 0x040014D6 RID: 5334
			Texture = 3
		}
	}
}
