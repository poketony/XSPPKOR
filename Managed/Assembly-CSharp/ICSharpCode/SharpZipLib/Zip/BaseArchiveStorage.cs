using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000158 RID: 344
	public abstract class BaseArchiveStorage : IArchiveStorage
	{
		// Token: 0x06001819 RID: 6169 RVA: 0x001336B1 File Offset: 0x001318B1
		protected BaseArchiveStorage(FileUpdateMode updateMode)
		{
			this.updateMode_ = updateMode;
		}

		// Token: 0x0600181A RID: 6170
		public abstract Stream GetTemporaryOutput();

		// Token: 0x0600181B RID: 6171
		public abstract Stream ConvertTemporaryToFinal();

		// Token: 0x0600181C RID: 6172
		public abstract Stream MakeTemporaryCopy(Stream stream);

		// Token: 0x0600181D RID: 6173
		public abstract Stream OpenForDirectUpdate(Stream stream);

		// Token: 0x0600181E RID: 6174
		public abstract void Dispose();

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600181F RID: 6175 RVA: 0x001336C0 File Offset: 0x001318C0
		public FileUpdateMode UpdateMode
		{
			get
			{
				return this.updateMode_;
			}
		}

		// Token: 0x04000DCC RID: 3532
		private readonly FileUpdateMode updateMode_;
	}
}
