using System;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x020000FB RID: 251
	public class Frame : MonoBehaviour
	{
		// Token: 0x06001388 RID: 5000 RVA: 0x00120EAF File Offset: 0x0011F0AF
		private void Awake()
		{
			this.graphics = base.GetComponent<StGraphics>();
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x00120EBD File Offset: 0x0011F0BD
		public virtual void SetBackground(int c)
		{
			this.graphics.BackgroundColor = StGraphics.CalcColor(c);
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x00120ED0 File Offset: 0x0011F0D0
		public virtual void SetSoftLabel(int key, string label)
		{
			SingletonBehaviour<StDisplay>.Instance.SetSoftkeyLabel(key, label);
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x00120EDE File Offset: 0x0011F0DE
		public virtual int GetWidth()
		{
			return 240;
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x00120EE5 File Offset: 0x0011F0E5
		public virtual int GetHeight()
		{
			return 240;
		}

		// Token: 0x04000AEB RID: 2795
		public const int SOFT_KEY_1 = 0;

		// Token: 0x04000AEC RID: 2796
		public const int SOFT_KEY_2 = 1;

		// Token: 0x04000AED RID: 2797
		public const int SOFT_KEY_3 = 2;

		// Token: 0x04000AEE RID: 2798
		public const int SOFT_KEY_4 = 3;

		// Token: 0x04000AEF RID: 2799
		protected StGraphics graphics;
	}
}
