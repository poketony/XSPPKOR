using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000155 RID: 341
	public class StaticDiskDataSource : IStaticDataSource
	{
		// Token: 0x0600180F RID: 6159 RVA: 0x0013366C File Offset: 0x0013186C
		public StaticDiskDataSource(string fileName)
		{
			this.fileName_ = fileName;
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x0013367B File Offset: 0x0013187B
		public Stream GetSource()
		{
			return File.Open(this.fileName_, FileMode.Open, FileAccess.Read, FileShare.Read);
		}

		// Token: 0x04000DCB RID: 3531
		private readonly string fileName_;
	}
}
