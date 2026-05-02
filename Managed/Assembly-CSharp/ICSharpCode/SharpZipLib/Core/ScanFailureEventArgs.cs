using System;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200018D RID: 397
	public class ScanFailureEventArgs : EventArgs
	{
		// Token: 0x06001AAA RID: 6826 RVA: 0x0013E75E File Offset: 0x0013C95E
		public ScanFailureEventArgs(string name, Exception e)
		{
			this.name_ = name;
			this.exception_ = e;
			this.continueRunning_ = true;
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06001AAB RID: 6827 RVA: 0x0013E77B File Offset: 0x0013C97B
		public string Name
		{
			get
			{
				return this.name_;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06001AAC RID: 6828 RVA: 0x0013E783 File Offset: 0x0013C983
		public Exception Exception
		{
			get
			{
				return this.exception_;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06001AAD RID: 6829 RVA: 0x0013E78B File Offset: 0x0013C98B
		// (set) Token: 0x06001AAE RID: 6830 RVA: 0x0013E793 File Offset: 0x0013C993
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

		// Token: 0x04000F72 RID: 3954
		private string name_;

		// Token: 0x04000F73 RID: 3955
		private Exception exception_;

		// Token: 0x04000F74 RID: 3956
		private bool continueRunning_;
	}
}
