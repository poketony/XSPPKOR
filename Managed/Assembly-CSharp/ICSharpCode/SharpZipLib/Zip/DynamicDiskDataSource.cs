using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000156 RID: 342
	public class DynamicDiskDataSource : IDynamicDataSource
	{
		// Token: 0x06001811 RID: 6161 RVA: 0x0013368C File Offset: 0x0013188C
		public Stream GetSource(ZipEntry entry, string name)
		{
			Stream stream = null;
			if (name != null)
			{
				stream = File.Open(name, FileMode.Open, FileAccess.Read, FileShare.Read);
			}
			return stream;
		}
	}
}
