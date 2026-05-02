using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000159 RID: 345
	public class DiskArchiveStorage : BaseArchiveStorage
	{
		// Token: 0x06001820 RID: 6176 RVA: 0x001336C8 File Offset: 0x001318C8
		public DiskArchiveStorage(ZipFile file, FileUpdateMode updateMode)
			: base(updateMode)
		{
			if (file.Name == null)
			{
				throw new ZipException("Cant handle non file archives");
			}
			this.fileName_ = file.Name;
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x001336F0 File Offset: 0x001318F0
		public DiskArchiveStorage(ZipFile file)
			: this(file, FileUpdateMode.Safe)
		{
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x001336FC File Offset: 0x001318FC
		public override Stream GetTemporaryOutput()
		{
			if (this.temporaryName_ != null)
			{
				this.temporaryName_ = DiskArchiveStorage.GetTempFileName(this.temporaryName_, true);
				this.temporaryStream_ = File.Open(this.temporaryName_, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			}
			else
			{
				this.temporaryName_ = Path.GetTempFileName();
				this.temporaryStream_ = File.Open(this.temporaryName_, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			}
			return this.temporaryStream_;
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x00133760 File Offset: 0x00131960
		public override Stream ConvertTemporaryToFinal()
		{
			if (this.temporaryStream_ == null)
			{
				throw new ZipException("No temporary stream has been created");
			}
			Stream stream = null;
			string tempFileName = DiskArchiveStorage.GetTempFileName(this.fileName_, false);
			bool flag = false;
			try
			{
				this.temporaryStream_.Dispose();
				File.Move(this.fileName_, tempFileName);
				File.Move(this.temporaryName_, this.fileName_);
				flag = true;
				File.Delete(tempFileName);
				stream = File.Open(this.fileName_, FileMode.Open, FileAccess.Read, FileShare.Read);
			}
			catch (Exception)
			{
				stream = null;
				if (!flag)
				{
					File.Move(tempFileName, this.fileName_);
					File.Delete(this.temporaryName_);
				}
				throw;
			}
			return stream;
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x00133804 File Offset: 0x00131A04
		public override Stream MakeTemporaryCopy(Stream stream)
		{
			stream.Dispose();
			this.temporaryName_ = DiskArchiveStorage.GetTempFileName(this.fileName_, true);
			File.Copy(this.fileName_, this.temporaryName_, true);
			this.temporaryStream_ = new FileStream(this.temporaryName_, FileMode.Open, FileAccess.ReadWrite);
			return this.temporaryStream_;
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x00133854 File Offset: 0x00131A54
		public override Stream OpenForDirectUpdate(Stream stream)
		{
			Stream stream2;
			if (stream == null || !stream.CanWrite)
			{
				if (stream != null)
				{
					stream.Dispose();
				}
				stream2 = new FileStream(this.fileName_, FileMode.Open, FileAccess.ReadWrite);
			}
			else
			{
				stream2 = stream;
			}
			return stream2;
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x00133888 File Offset: 0x00131A88
		public override void Dispose()
		{
			if (this.temporaryStream_ != null)
			{
				this.temporaryStream_.Dispose();
			}
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x001338A0 File Offset: 0x00131AA0
		private static string GetTempFileName(string original, bool makeTempFile)
		{
			string text = null;
			if (original == null)
			{
				text = Path.GetTempFileName();
			}
			else
			{
				int num = 0;
				int num2 = DateTime.Now.Second;
				while (text == null)
				{
					num++;
					string text2 = string.Format("{0}.{1}{2}.tmp", original, num2, num);
					if (!File.Exists(text2))
					{
						if (makeTempFile)
						{
							try
							{
								using (File.Create(text2))
								{
								}
								text = text2;
								continue;
							}
							catch
							{
								num2 = DateTime.Now.Second;
								continue;
							}
						}
						text = text2;
					}
				}
			}
			return text;
		}

		// Token: 0x04000DCD RID: 3533
		private Stream temporaryStream_;

		// Token: 0x04000DCE RID: 3534
		private readonly string fileName_;

		// Token: 0x04000DCF RID: 3535
		private string temporaryName_;
	}
}
