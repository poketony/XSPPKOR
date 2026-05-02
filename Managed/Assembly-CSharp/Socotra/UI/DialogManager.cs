using System;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x020000FA RID: 250
	public class DialogManager : MonoBehaviour
	{
		// Token: 0x06001383 RID: 4995 RVA: 0x00120E62 File Offset: 0x0011F062
		private void Start()
		{
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00120E64 File Offset: 0x0011F064
		private void Update()
		{
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x00120E66 File Offset: 0x0011F066
		public static StDialog CreateDialog(int type, string title)
		{
			return new StDialog(type, title);
		}

		// Token: 0x04000AE1 RID: 2785
		private StDialog dialog;

		// Token: 0x04000AE2 RID: 2786
		public static int BUTTON_CANCEL = 2;

		// Token: 0x04000AE3 RID: 2787
		public static int BUTTON_NO = 8;

		// Token: 0x04000AE4 RID: 2788
		public static int BUTTON_OK = 1;

		// Token: 0x04000AE5 RID: 2789
		public static int BUTTON_YES = 4;

		// Token: 0x04000AE6 RID: 2790
		public static int DIALOG_ERROR = 2;

		// Token: 0x04000AE7 RID: 2791
		public static int DIALOG_INFO = 0;

		// Token: 0x04000AE8 RID: 2792
		public static int DIALOG_WARNING = 1;

		// Token: 0x04000AE9 RID: 2793
		public static int DIALOG_YESNO = 3;

		// Token: 0x04000AEA RID: 2794
		public static int DIALOG_YESNOCANCEL = 4;
	}
}
