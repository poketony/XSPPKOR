using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000157 RID: 343
	public interface IArchiveStorage
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06001813 RID: 6163
		FileUpdateMode UpdateMode { get; }

		// Token: 0x06001814 RID: 6164
		Stream GetTemporaryOutput();

		// Token: 0x06001815 RID: 6165
		Stream ConvertTemporaryToFinal();

		// Token: 0x06001816 RID: 6166
		Stream MakeTemporaryCopy(Stream stream);

		// Token: 0x06001817 RID: 6167
		Stream OpenForDirectUpdate(Stream stream);

		// Token: 0x06001818 RID: 6168
		void Dispose();
	}
}
