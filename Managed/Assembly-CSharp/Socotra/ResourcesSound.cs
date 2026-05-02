using System;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000DF RID: 223
	public class ResourcesSound : Resources
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x0011EFD8 File Offset: 0x0011D1D8
		// (set) Token: 0x060012B8 RID: 4792 RVA: 0x0011EFE0 File Offset: 0x0011D1E0
		public bool Loop
		{
			get
			{
				return this.isLoop;
			}
			set
			{
				this.isLoop = value;
			}
		}

		// Token: 0x04000A77 RID: 2679
		[SerializeField]
		private bool isLoop;
	}
}
