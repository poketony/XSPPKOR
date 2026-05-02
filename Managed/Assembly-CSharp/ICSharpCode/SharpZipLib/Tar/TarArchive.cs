using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000173 RID: 371
	public class TarArchive : IDisposable
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06001963 RID: 6499 RVA: 0x00139F30 File Offset: 0x00138130
		// (remove) Token: 0x06001964 RID: 6500 RVA: 0x00139F68 File Offset: 0x00138168
		public event ProgressMessageHandler ProgressMessageEvent;

		// Token: 0x06001965 RID: 6501 RVA: 0x00139FA0 File Offset: 0x001381A0
		protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
		{
			ProgressMessageHandler progressMessageEvent = this.ProgressMessageEvent;
			if (progressMessageEvent != null)
			{
				progressMessageEvent(this, entry, message);
			}
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x00139FC0 File Offset: 0x001381C0
		protected TarArchive()
		{
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x00139FDE File Offset: 0x001381DE
		protected TarArchive(TarInputStream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.tarIn = stream;
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x0013A011 File Offset: 0x00138211
		protected TarArchive(TarOutputStream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.tarOut = stream;
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x0013A044 File Offset: 0x00138244
		public static TarArchive CreateInputTarArchive(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			TarInputStream tarInputStream = inputStream as TarInputStream;
			TarArchive tarArchive;
			if (tarInputStream != null)
			{
				tarArchive = new TarArchive(tarInputStream);
			}
			else
			{
				tarArchive = TarArchive.CreateInputTarArchive(inputStream, 20);
			}
			return tarArchive;
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x0013A07C File Offset: 0x0013827C
		public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (inputStream is TarInputStream)
			{
				throw new ArgumentException("TarInputStream not valid");
			}
			return new TarArchive(new TarInputStream(inputStream, blockFactor));
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x0013A0AC File Offset: 0x001382AC
		public static TarArchive CreateOutputTarArchive(Stream outputStream)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			TarOutputStream tarOutputStream = outputStream as TarOutputStream;
			TarArchive tarArchive;
			if (tarOutputStream != null)
			{
				tarArchive = new TarArchive(tarOutputStream);
			}
			else
			{
				tarArchive = TarArchive.CreateOutputTarArchive(outputStream, 20);
			}
			return tarArchive;
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x0013A0E4 File Offset: 0x001382E4
		public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (outputStream is TarOutputStream)
			{
				throw new ArgumentException("TarOutputStream is not valid");
			}
			return new TarArchive(new TarOutputStream(outputStream, blockFactor));
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x0013A113 File Offset: 0x00138313
		public void SetKeepOldFiles(bool keepExistingFiles)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			this.keepOldFiles = keepExistingFiles;
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600196E RID: 6510 RVA: 0x0013A12F File Offset: 0x0013832F
		// (set) Token: 0x0600196F RID: 6511 RVA: 0x0013A14A File Offset: 0x0013834A
		public bool AsciiTranslate
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.asciiTranslate;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.asciiTranslate = value;
			}
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x0013A166 File Offset: 0x00138366
		[Obsolete("Use the AsciiTranslate property")]
		public void SetAsciiTranslation(bool translateAsciiFiles)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			this.asciiTranslate = translateAsciiFiles;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06001971 RID: 6513 RVA: 0x0013A182 File Offset: 0x00138382
		// (set) Token: 0x06001972 RID: 6514 RVA: 0x0013A19D File Offset: 0x0013839D
		public string PathPrefix
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.pathPrefix;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.pathPrefix = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06001973 RID: 6515 RVA: 0x0013A1B9 File Offset: 0x001383B9
		// (set) Token: 0x06001974 RID: 6516 RVA: 0x0013A1D4 File Offset: 0x001383D4
		public string RootPath
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.rootPath;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.rootPath = value.Replace('\\', '/').TrimEnd('/');
			}
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x0013A200 File Offset: 0x00138400
		public void SetUserInfo(int userId, string userName, int groupId, string groupName)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			this.userId = userId;
			this.userName = userName;
			this.groupId = groupId;
			this.groupName = groupName;
			this.applyUserInfoOverrides = true;
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06001976 RID: 6518 RVA: 0x0013A239 File Offset: 0x00138439
		// (set) Token: 0x06001977 RID: 6519 RVA: 0x0013A254 File Offset: 0x00138454
		public bool ApplyUserInfoOverrides
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.applyUserInfoOverrides;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.applyUserInfoOverrides = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06001978 RID: 6520 RVA: 0x0013A270 File Offset: 0x00138470
		public int UserId
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.userId;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06001979 RID: 6521 RVA: 0x0013A28B File Offset: 0x0013848B
		public string UserName
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.userName;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600197A RID: 6522 RVA: 0x0013A2A6 File Offset: 0x001384A6
		public int GroupId
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.groupId;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600197B RID: 6523 RVA: 0x0013A2C1 File Offset: 0x001384C1
		public string GroupName
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.groupName;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600197C RID: 6524 RVA: 0x0013A2DC File Offset: 0x001384DC
		public int RecordSize
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				if (this.tarIn != null)
				{
					return this.tarIn.RecordSize;
				}
				if (this.tarOut != null)
				{
					return this.tarOut.RecordSize;
				}
				return 10240;
			}
		}

		// Token: 0x1700016A RID: 362
		// (set) Token: 0x0600197D RID: 6525 RVA: 0x0013A329 File Offset: 0x00138529
		public bool IsStreamOwner
		{
			set
			{
				if (this.tarIn != null)
				{
					this.tarIn.IsStreamOwner = value;
					return;
				}
				this.tarOut.IsStreamOwner = value;
			}
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x0013A34C File Offset: 0x0013854C
		[Obsolete("Use Close instead")]
		public void CloseArchive()
		{
			this.Close();
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x0013A354 File Offset: 0x00138554
		public void ListContents()
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			for (;;)
			{
				TarEntry nextEntry = this.tarIn.GetNextEntry();
				if (nextEntry == null)
				{
					break;
				}
				this.OnProgressMessageEvent(nextEntry, null);
			}
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x0013A390 File Offset: 0x00138590
		public void ExtractContents(string destinationDirectory)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			for (;;)
			{
				TarEntry nextEntry = this.tarIn.GetNextEntry();
				if (nextEntry == null)
				{
					break;
				}
				if (nextEntry.TarHeader.TypeFlag != 49 && nextEntry.TarHeader.TypeFlag != 50)
				{
					this.ExtractEntry(destinationDirectory, nextEntry);
				}
			}
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x0013A3E8 File Offset: 0x001385E8
		private void ExtractEntry(string destDir, TarEntry entry)
		{
			this.OnProgressMessageEvent(entry, null);
			string text = entry.Name;
			if (Path.IsPathRooted(text))
			{
				text = text.Substring(Path.GetPathRoot(text).Length);
			}
			text = text.Replace('/', Path.DirectorySeparatorChar);
			string text2 = Path.Combine(destDir, text);
			if (entry.IsDirectory)
			{
				TarArchive.EnsureDirectoryExists(text2);
				return;
			}
			TarArchive.EnsureDirectoryExists(Path.GetDirectoryName(text2));
			bool flag = true;
			FileInfo fileInfo = new FileInfo(text2);
			if (fileInfo.Exists)
			{
				if (this.keepOldFiles)
				{
					this.OnProgressMessageEvent(entry, "Destination file already exists");
					flag = false;
				}
				else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != FileAttributes.None)
				{
					this.OnProgressMessageEvent(entry, "Destination file already exists, and is read-only");
					flag = false;
				}
			}
			if (flag)
			{
				using (FileStream fileStream = File.Create(text2))
				{
					if (this.asciiTranslate)
					{
						this.ExtractAndTranslateEntry(text2, fileStream);
					}
					else
					{
						this.tarIn.CopyEntryContents(fileStream);
					}
				}
			}
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x0013A4D8 File Offset: 0x001386D8
		private void ExtractAndTranslateEntry(string destFile, Stream outputStream)
		{
			if (!TarArchive.IsBinary(destFile))
			{
				using (StreamWriter streamWriter = new StreamWriter(outputStream, new UTF8Encoding(false), 1024, true))
				{
					byte[] array = new byte[32768];
					for (;;)
					{
						int num = this.tarIn.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						int num2 = 0;
						for (int i = 0; i < num; i++)
						{
							if (array[i] == 10)
							{
								string @string = Encoding.ASCII.GetString(array, num2, i - num2);
								streamWriter.WriteLine(@string);
								num2 = i + 1;
							}
						}
					}
					return;
				}
			}
			this.tarIn.CopyEntryContents(outputStream);
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x0013A588 File Offset: 0x00138788
		public void WriteEntry(TarEntry sourceEntry, bool recurse)
		{
			if (sourceEntry == null)
			{
				throw new ArgumentNullException("sourceEntry");
			}
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			try
			{
				if (recurse)
				{
					TarHeader.SetValueDefaults(sourceEntry.UserId, sourceEntry.UserName, sourceEntry.GroupId, sourceEntry.GroupName);
				}
				this.WriteEntryCore(sourceEntry, recurse);
			}
			finally
			{
				if (recurse)
				{
					TarHeader.RestoreSetValues();
				}
			}
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x0013A5FC File Offset: 0x001387FC
		private void WriteEntryCore(TarEntry sourceEntry, bool recurse)
		{
			string text = null;
			string text2 = sourceEntry.File;
			TarEntry tarEntry = (TarEntry)sourceEntry.Clone();
			if (this.applyUserInfoOverrides)
			{
				tarEntry.GroupId = this.groupId;
				tarEntry.GroupName = this.groupName;
				tarEntry.UserId = this.userId;
				tarEntry.UserName = this.userName;
			}
			this.OnProgressMessageEvent(tarEntry, null);
			if (this.asciiTranslate && !tarEntry.IsDirectory && !TarArchive.IsBinary(text2))
			{
				text = Path.GetTempFileName();
				using (StreamReader streamReader = File.OpenText(text2))
				{
					using (Stream stream = File.Create(text))
					{
						for (;;)
						{
							string text3 = streamReader.ReadLine();
							if (text3 == null)
							{
								break;
							}
							byte[] bytes = Encoding.ASCII.GetBytes(text3);
							stream.Write(bytes, 0, bytes.Length);
							stream.WriteByte(10);
						}
						stream.Flush();
					}
				}
				tarEntry.Size = new FileInfo(text).Length;
				text2 = text;
			}
			string text4 = null;
			if (!string.IsNullOrEmpty(this.rootPath) && tarEntry.Name.StartsWith(this.rootPath, StringComparison.OrdinalIgnoreCase))
			{
				text4 = tarEntry.Name.Substring(this.rootPath.Length + 1);
			}
			if (this.pathPrefix != null)
			{
				text4 = ((text4 == null) ? (this.pathPrefix + "/" + tarEntry.Name) : (this.pathPrefix + "/" + text4));
			}
			if (text4 != null)
			{
				tarEntry.Name = text4;
			}
			this.tarOut.PutNextEntry(tarEntry);
			if (tarEntry.IsDirectory)
			{
				if (recurse)
				{
					TarEntry[] directoryEntries = tarEntry.GetDirectoryEntries();
					for (int i = 0; i < directoryEntries.Length; i++)
					{
						this.WriteEntryCore(directoryEntries[i], recurse);
					}
					return;
				}
			}
			else
			{
				using (Stream stream2 = File.OpenRead(text2))
				{
					byte[] array = new byte[32768];
					for (;;)
					{
						int num = stream2.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						this.tarOut.Write(array, 0, num);
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					File.Delete(text);
				}
				this.tarOut.CloseEntry();
			}
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x0013A844 File Offset: 0x00138A44
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x0013A854 File Offset: 0x00138A54
		protected virtual void Dispose(bool disposing)
		{
			if (!this.isDisposed)
			{
				this.isDisposed = true;
				if (disposing)
				{
					if (this.tarOut != null)
					{
						this.tarOut.Flush();
						this.tarOut.Dispose();
					}
					if (this.tarIn != null)
					{
						this.tarIn.Dispose();
					}
				}
			}
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x0013A8A4 File Offset: 0x00138AA4
		public virtual void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x0013A8B0 File Offset: 0x00138AB0
		~TarArchive()
		{
			this.Dispose(false);
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x0013A8E0 File Offset: 0x00138AE0
		private static void EnsureDirectoryExists(string directoryName)
		{
			if (!Directory.Exists(directoryName))
			{
				try
				{
					Directory.CreateDirectory(directoryName);
				}
				catch (Exception ex)
				{
					throw new TarException("Exception creating directory '" + directoryName + "', " + ex.Message, ex);
				}
			}
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x0013A92C File Offset: 0x00138B2C
		private static bool IsBinary(string filename)
		{
			using (FileStream fileStream = File.OpenRead(filename))
			{
				int num = Math.Min(4096, (int)fileStream.Length);
				byte[] array = new byte[num];
				int num2 = fileStream.Read(array, 0, num);
				for (int i = 0; i < num2; i++)
				{
					byte b = array[i];
					if (b < 8 || (b > 13 && b < 32) || b == 255)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04000EAF RID: 3759
		private bool keepOldFiles;

		// Token: 0x04000EB0 RID: 3760
		private bool asciiTranslate;

		// Token: 0x04000EB1 RID: 3761
		private int userId;

		// Token: 0x04000EB2 RID: 3762
		private string userName = string.Empty;

		// Token: 0x04000EB3 RID: 3763
		private int groupId;

		// Token: 0x04000EB4 RID: 3764
		private string groupName = string.Empty;

		// Token: 0x04000EB5 RID: 3765
		private string rootPath;

		// Token: 0x04000EB6 RID: 3766
		private string pathPrefix;

		// Token: 0x04000EB7 RID: 3767
		private bool applyUserInfoOverrides;

		// Token: 0x04000EB8 RID: 3768
		private TarInputStream tarIn;

		// Token: 0x04000EB9 RID: 3769
		private TarOutputStream tarOut;

		// Token: 0x04000EBA RID: 3770
		private bool isDisposed;
	}
}
