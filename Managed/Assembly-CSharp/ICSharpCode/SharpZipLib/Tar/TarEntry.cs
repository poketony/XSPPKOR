using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000175 RID: 373
	public class TarEntry
	{
		// Token: 0x060019A5 RID: 6565 RVA: 0x0013AF5C File Offset: 0x0013915C
		private TarEntry()
		{
			this.header = new TarHeader();
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x0013AF6F File Offset: 0x0013916F
		public TarEntry(byte[] headerBuffer)
		{
			this.header = new TarHeader();
			this.header.ParseBuffer(headerBuffer);
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x0013AF8E File Offset: 0x0013918E
		public TarEntry(TarHeader header)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			this.header = (TarHeader)header.Clone();
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x0013AFB5 File Offset: 0x001391B5
		public object Clone()
		{
			return new TarEntry
			{
				file = this.file,
				header = (TarHeader)this.header.Clone(),
				Name = this.Name
			};
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x0013AFEA File Offset: 0x001391EA
		public static TarEntry CreateTarEntry(string name)
		{
			TarEntry tarEntry = new TarEntry();
			TarEntry.NameTarHeader(tarEntry.header, name);
			return tarEntry;
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x0013AFFD File Offset: 0x001391FD
		public static TarEntry CreateEntryFromFile(string fileName)
		{
			TarEntry tarEntry = new TarEntry();
			tarEntry.GetFileTarHeader(tarEntry.header, fileName);
			return tarEntry;
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x0013B014 File Offset: 0x00139214
		public override bool Equals(object obj)
		{
			TarEntry tarEntry = obj as TarEntry;
			return tarEntry != null && this.Name.Equals(tarEntry.Name);
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x0013B03E File Offset: 0x0013923E
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x0013B04B File Offset: 0x0013924B
		public bool IsDescendent(TarEntry toTest)
		{
			if (toTest == null)
			{
				throw new ArgumentNullException("toTest");
			}
			return toTest.Name.StartsWith(this.Name, StringComparison.Ordinal);
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060019AE RID: 6574 RVA: 0x0013B06D File Offset: 0x0013926D
		public TarHeader TarHeader
		{
			get
			{
				return this.header;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060019AF RID: 6575 RVA: 0x0013B075 File Offset: 0x00139275
		// (set) Token: 0x060019B0 RID: 6576 RVA: 0x0013B082 File Offset: 0x00139282
		public string Name
		{
			get
			{
				return this.header.Name;
			}
			set
			{
				this.header.Name = value;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060019B1 RID: 6577 RVA: 0x0013B090 File Offset: 0x00139290
		// (set) Token: 0x060019B2 RID: 6578 RVA: 0x0013B09D File Offset: 0x0013929D
		public int UserId
		{
			get
			{
				return this.header.UserId;
			}
			set
			{
				this.header.UserId = value;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060019B3 RID: 6579 RVA: 0x0013B0AB File Offset: 0x001392AB
		// (set) Token: 0x060019B4 RID: 6580 RVA: 0x0013B0B8 File Offset: 0x001392B8
		public int GroupId
		{
			get
			{
				return this.header.GroupId;
			}
			set
			{
				this.header.GroupId = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060019B5 RID: 6581 RVA: 0x0013B0C6 File Offset: 0x001392C6
		// (set) Token: 0x060019B6 RID: 6582 RVA: 0x0013B0D3 File Offset: 0x001392D3
		public string UserName
		{
			get
			{
				return this.header.UserName;
			}
			set
			{
				this.header.UserName = value;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060019B7 RID: 6583 RVA: 0x0013B0E1 File Offset: 0x001392E1
		// (set) Token: 0x060019B8 RID: 6584 RVA: 0x0013B0EE File Offset: 0x001392EE
		public string GroupName
		{
			get
			{
				return this.header.GroupName;
			}
			set
			{
				this.header.GroupName = value;
			}
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x0013B0FC File Offset: 0x001392FC
		public void SetIds(int userId, int groupId)
		{
			this.UserId = userId;
			this.GroupId = groupId;
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x0013B10C File Offset: 0x0013930C
		public void SetNames(string userName, string groupName)
		{
			this.UserName = userName;
			this.GroupName = groupName;
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060019BB RID: 6587 RVA: 0x0013B11C File Offset: 0x0013931C
		// (set) Token: 0x060019BC RID: 6588 RVA: 0x0013B129 File Offset: 0x00139329
		public DateTime ModTime
		{
			get
			{
				return this.header.ModTime;
			}
			set
			{
				this.header.ModTime = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060019BD RID: 6589 RVA: 0x0013B137 File Offset: 0x00139337
		public string File
		{
			get
			{
				return this.file;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060019BE RID: 6590 RVA: 0x0013B13F File Offset: 0x0013933F
		// (set) Token: 0x060019BF RID: 6591 RVA: 0x0013B14C File Offset: 0x0013934C
		public long Size
		{
			get
			{
				return this.header.Size;
			}
			set
			{
				this.header.Size = value;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060019C0 RID: 6592 RVA: 0x0013B15C File Offset: 0x0013935C
		public bool IsDirectory
		{
			get
			{
				if (this.file != null)
				{
					return Directory.Exists(this.file);
				}
				return this.header != null && (this.header.TypeFlag == 53 || this.Name.EndsWith("/", StringComparison.Ordinal));
			}
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x0013B1AC File Offset: 0x001393AC
		public void GetFileTarHeader(TarHeader header, string file)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}
			this.file = file;
			string text = file;
			if (text.IndexOf(Directory.GetCurrentDirectory(), StringComparison.Ordinal) == 0)
			{
				text = text.Substring(Directory.GetCurrentDirectory().Length);
			}
			text = text.Replace(Path.DirectorySeparatorChar, '/');
			while (text.StartsWith("/", StringComparison.Ordinal))
			{
				text = text.Substring(1);
			}
			header.LinkName = string.Empty;
			header.Name = text;
			if (Directory.Exists(file))
			{
				header.Mode = 1003;
				header.TypeFlag = 53;
				if (header.Name.Length == 0 || header.Name[header.Name.Length - 1] != '/')
				{
					header.Name += "/";
				}
				header.Size = 0L;
			}
			else
			{
				header.Mode = 33216;
				header.TypeFlag = 48;
				header.Size = new FileInfo(file.Replace('/', Path.DirectorySeparatorChar)).Length;
			}
			header.ModTime = global::System.IO.File.GetLastWriteTime(file.Replace('/', Path.DirectorySeparatorChar)).ToUniversalTime();
			header.DevMajor = 0;
			header.DevMinor = 0;
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x0013B2F8 File Offset: 0x001394F8
		public TarEntry[] GetDirectoryEntries()
		{
			if (this.file == null || !Directory.Exists(this.file))
			{
				return new TarEntry[0];
			}
			string[] fileSystemEntries = Directory.GetFileSystemEntries(this.file);
			TarEntry[] array = new TarEntry[fileSystemEntries.Length];
			for (int i = 0; i < fileSystemEntries.Length; i++)
			{
				array[i] = TarEntry.CreateEntryFromFile(fileSystemEntries[i]);
			}
			return array;
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x0013B350 File Offset: 0x00139550
		public void WriteEntryHeader(byte[] outBuffer)
		{
			this.header.WriteHeader(outBuffer);
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x0013B35E File Offset: 0x0013955E
		public static void AdjustEntryName(byte[] buffer, string newName)
		{
			TarHeader.GetNameBytes(newName, buffer, 0, 100);
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x0013B36C File Offset: 0x0013956C
		public static void NameTarHeader(TarHeader header, string name)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			bool flag = name.EndsWith("/", StringComparison.Ordinal);
			header.Name = name;
			header.Mode = (flag ? 1003 : 33216);
			header.UserId = 0;
			header.GroupId = 0;
			header.Size = 0L;
			header.ModTime = DateTime.UtcNow;
			header.TypeFlag = (flag ? 53 : 48);
			header.LinkName = string.Empty;
			header.UserName = string.Empty;
			header.GroupName = string.Empty;
			header.DevMajor = 0;
			header.DevMinor = 0;
		}

		// Token: 0x04000EC6 RID: 3782
		private string file;

		// Token: 0x04000EC7 RID: 3783
		private TarHeader header;
	}
}
