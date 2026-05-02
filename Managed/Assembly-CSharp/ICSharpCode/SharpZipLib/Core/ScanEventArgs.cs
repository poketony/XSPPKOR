using System;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200018A RID: 394
	public class ScanEventArgs : EventArgs
	{
		// Token: 0x06001A9D RID: 6813 RVA: 0x0013E691 File Offset: 0x0013C891
		public ScanEventArgs(string name)
		{
			this.name_ = name;
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06001A9E RID: 6814 RVA: 0x0013E6A7 File Offset: 0x0013C8A7
		public string Name
		{
			get
			{
				return this.name_;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06001A9F RID: 6815 RVA: 0x0013E6AF File Offset: 0x0013C8AF
		// (set) Token: 0x06001AA0 RID: 6816 RVA: 0x0013E6B7 File Offset: 0x0013C8B7
		public bool ContinueRunning
		{
			get
			{
				return this.continueRunning_;
			}
			set
			{
				this.continueRunning_ = value;
			}
		}

		// Token: 0x04000F6B RID: 3947
		private string name_;

		// Token: 0x04000F6C RID: 3948
		private bool continueRunning_ = true;
	}
}
