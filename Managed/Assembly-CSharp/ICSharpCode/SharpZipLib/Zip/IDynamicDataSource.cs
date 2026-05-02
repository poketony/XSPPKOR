using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000154 RID: 340
	public interface IDynamicDataSource
	{
		// Token: 0x0600180E RID: 6158
		Stream GetSource(ZipEntry entry, string name);
	}
}
