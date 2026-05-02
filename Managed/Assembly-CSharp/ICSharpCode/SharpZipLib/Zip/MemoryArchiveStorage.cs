using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200015A RID: 346
	public class MemoryArchiveStorage : BaseArchiveStorage
	{
		// Token: 0x06001828 RID: 6184 RVA: 0x00133948 File Offset: 0x00131B48
		public MemoryArchiveStorage()
			: base(FileUpdateMode.Direct)
		{
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x00133951 File Offset: 0x00131B51
		public MemoryArchiveStorage(FileUpdateMode updateMode)
			: base(updateMode)
		{
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600182A RID: 6186 RVA: 0x0013395A File Offset: 0x00131B5A
		public MemoryStream FinalStream
		{
			get
			{
				return this.finalStream_;
			}
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x00133962 File Offset: 0x00131B62
		public override Stream GetTemporaryOutput()
		{
			this.temporaryStream_ = new MemoryStream();
			return this.temporaryStream_;
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x00133975 File Offset: 0x00131B75
		public override Stream ConvertTemporaryToFinal()
		{
			if (this.temporaryStream_ == null)
			{
				throw new ZipException("No temporary stream has been created");
			}
			this.finalStream_ = new MemoryStream(this.temporaryStream_.ToArray());
			return this.finalStream_;
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x001339A6 File Offset: 0x00131BA6
		public override Stream MakeTemporaryCopy(Stream stream)
		{
			this.temporaryStream_ = new MemoryStream();
			stream.Position = 0L;
			StreamUtils.Copy(stream, this.temporaryStream_, new byte[4096]);
			return this.temporaryStream_;
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x001339D8 File Offset: 0x00131BD8
		public override Stream OpenForDirectUpdate(Stream stream)
		{
			Stream stream2;
			if (stream == null || !stream.CanWrite)
			{
				stream2 = new MemoryStream();
				if (stream != null)
				{
					stream.Position = 0L;
					StreamUtils.Copy(stream, stream2, new byte[4096]);
					stream.Dispose();
				}
			}
			else
			{
				stream2 = stream;
			}
			return stream2;
		}

		// Token: 0x0600182F RID: 6191 RVA: 0x00133A1D File Offset: 0x00131C1D
		public override void Dispose()
		{
			if (this.temporaryStream_ != null)
			{
				this.temporaryStream_.Dispose();
			}
		}

		// Token: 0x04000DD0 RID: 3536
		private MemoryStream temporaryStream_;

		// Token: 0x04000DD1 RID: 3537
		private MemoryStream finalStream_;
	}
}
