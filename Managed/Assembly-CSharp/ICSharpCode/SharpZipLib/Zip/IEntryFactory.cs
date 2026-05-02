using System;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200013B RID: 315
	public interface IEntryFactory
	{
		// Token: 0x060016DD RID: 5853
		ZipEntry MakeFileEntry(string fileName);

		// Token: 0x060016DE RID: 5854
		ZipEntry MakeFileEntry(string fileName, bool useFileSystem);

		// Token: 0x060016DF RID: 5855
		ZipEntry MakeFileEntry(string fileName, string entryName, bool useFileSystem);

		// Token: 0x060016E0 RID: 5856
		ZipEntry MakeDirectoryEntry(string directoryName);

		// Token: 0x060016E1 RID: 5857
		ZipEntry MakeDirectoryEntry(string directoryName, bool useFileSystem);

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060016E2 RID: 5858
		// (set) Token: 0x060016E3 RID: 5859
		INameTransform NameTransform { get; set; }
	}
}
