using System;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200018B RID: 395
	public class ProgressEventArgs : EventArgs
	{
		// Token: 0x06001AA1 RID: 6817 RVA: 0x0013E6C0 File Offset: 0x0013C8C0
		public ProgressEventArgs(string name, long processed, long target)
		{
			this.name_ = name;
			this.processed_ = processed;
			this.target_ = target;
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06001AA2 RID: 6818 RVA: 0x0013E6E4 File Offset: 0x0013C8E4
		public string Name
		{
			get
			{
				return this.name_;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06001AA3 RID: 6819 RVA: 0x0013E6EC File Offset: 0x0013C8EC
		// (set) Token: 0x06001AA4 RID: 6820 RVA: 0x0013E6F4 File Offset: 0x0013C8F4
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

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06001AA5 RID: 6821 RVA: 0x0013E700 File Offset: 0x0013C900
		public float PercentComplete
		{
			get
			{
				float num;
				if (this.target_ <= 0L)
				{
					num = 0f;
				}
				else
				{
					num = (float)this.processed_ / (float)this.target_ * 100f;
				}
				return num;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06001AA6 RID: 6822 RVA: 0x0013E736 File Offset: 0x0013C936
		public long Processed
		{
			get
			{
				return this.processed_;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06001AA7 RID: 6823 RVA: 0x0013E73E File Offset: 0x0013C93E
		public long Target
		{
			get
			{
				return this.target_;
			}
		}

		// Token: 0x04000F6D RID: 3949
		private string name_;

		// Token: 0x04000F6E RID: 3950
		private long processed_;

		// Token: 0x04000F6F RID: 3951
		private long target_;

		// Token: 0x04000F70 RID: 3952
		private bool continueRunning_ = true;
	}
}
