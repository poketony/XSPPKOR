using System;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200018C RID: 396
	public class DirectoryEventArgs : ScanEventArgs
	{
		// Token: 0x06001AA8 RID: 6824 RVA: 0x0013E746 File Offset: 0x0013C946
		public DirectoryEventArgs(string name, bool hasMatchingFiles)
			: base(name)
		{
			this.hasMatchingFiles_ = hasMatchingFiles;
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06001AA9 RID: 6825 RVA: 0x0013E756 File Offset: 0x0013C956
		public bool HasMatchingFiles
		{
			get
			{
				return this.hasMatchingFiles_;
			}
		}

		// Token: 0x04000F71 RID: 3953
		private readonly bool hasMatchingFiles_;
	}
}
