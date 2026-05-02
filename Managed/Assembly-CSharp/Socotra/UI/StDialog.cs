using System;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x02000101 RID: 257
	public class StDialog : Frame
	{
		// Token: 0x060013CA RID: 5066 RVA: 0x001217C4 File Offset: 0x0011F9C4
		public StDialog()
		{
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x001217CC File Offset: 0x0011F9CC
		public StDialog(int t, string title)
		{
			Debug.Log("Create Dialog:" + t.ToString() + " Title:" + title);
			this.type = t;
			this.title = title;
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x001217FE File Offset: 0x0011F9FE
		private void Start()
		{
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x00121800 File Offset: 0x0011FA00
		private void Update()
		{
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x00121802 File Offset: 0x0011FA02
		public void SetText(string message)
		{
			Debug.Log("Dialog Text:" + message);
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x00121814 File Offset: 0x0011FA14
		public void Show()
		{
		}

		// Token: 0x04000B28 RID: 2856
		public static int DIALOG_INFO = 0;

		// Token: 0x04000B29 RID: 2857
		public static int DIALOG_ERROR = 1;

		// Token: 0x04000B2A RID: 2858
		[SerializeField]
		private int type;

		// Token: 0x04000B2B RID: 2859
		[SerializeField]
		private string title;
	}
}
