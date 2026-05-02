using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000144 RID: 324
	public class ZipEntryFactory : IEntryFactory
	{
		// Token: 0x0600173A RID: 5946 RVA: 0x0012F64C File Offset: 0x0012D84C
		public ZipEntryFactory()
		{
			this.nameTransform_ = new ZipNameTransform();
			this.isUnicodeText_ = ZipStrings.UseUnicode;
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x0012F67C File Offset: 0x0012D87C
		public ZipEntryFactory(ZipEntryFactory.TimeSetting timeSetting)
			: this()
		{
			this.timeSetting_ = timeSetting;
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x0012F68B File Offset: 0x0012D88B
		public ZipEntryFactory(DateTime time)
			: this()
		{
			this.timeSetting_ = ZipEntryFactory.TimeSetting.Fixed;
			this.FixedDateTime = time;
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x0012F6A1 File Offset: 0x0012D8A1
		// (set) Token: 0x0600173E RID: 5950 RVA: 0x0012F6A9 File Offset: 0x0012D8A9
		public INameTransform NameTransform
		{
			get
			{
				return this.nameTransform_;
			}
			set
			{
				if (value == null)
				{
					this.nameTransform_ = new ZipNameTransform();
					return;
				}
				this.nameTransform_ = value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600173F RID: 5951 RVA: 0x0012F6C1 File Offset: 0x0012D8C1
		// (set) Token: 0x06001740 RID: 5952 RVA: 0x0012F6C9 File Offset: 0x0012D8C9
		public ZipEntryFactory.TimeSetting Setting
		{
			get
			{
				return this.timeSetting_;
			}
			set
			{
				this.timeSetting_ = value;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06001741 RID: 5953 RVA: 0x0012F6D2 File Offset: 0x0012D8D2
		// (set) Token: 0x06001742 RID: 5954 RVA: 0x0012F6DA File Offset: 0x0012D8DA
		public DateTime FixedDateTime
		{
			get
			{
				return this.fixedDateTime_;
			}
			set
			{
				if (value.Year < 1970)
				{
					throw new ArgumentException("Value is too old to be valid", "value");
				}
				this.fixedDateTime_ = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06001743 RID: 5955 RVA: 0x0012F701 File Offset: 0x0012D901
		// (set) Token: 0x06001744 RID: 5956 RVA: 0x0012F709 File Offset: 0x0012D909
		public int GetAttributes
		{
			get
			{
				return this.getAttributes_;
			}
			set
			{
				this.getAttributes_ = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06001745 RID: 5957 RVA: 0x0012F712 File Offset: 0x0012D912
		// (set) Token: 0x06001746 RID: 5958 RVA: 0x0012F71A File Offset: 0x0012D91A
		public int SetAttributes
		{
			get
			{
				return this.setAttributes_;
			}
			set
			{
				this.setAttributes_ = value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06001747 RID: 5959 RVA: 0x0012F723 File Offset: 0x0012D923
		// (set) Token: 0x06001748 RID: 5960 RVA: 0x0012F72B File Offset: 0x0012D92B
		public bool IsUnicodeText
		{
			get
			{
				return this.isUnicodeText_;
			}
			set
			{
				this.isUnicodeText_ = value;
			}
		}

		// Token: 0x06001749 RID: 5961 RVA: 0x0012F734 File Offset: 0x0012D934
		public ZipEntry MakeFileEntry(string fileName)
		{
			return this.MakeFileEntry(fileName, null, true);
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0012F73F File Offset: 0x0012D93F
		public ZipEntry MakeFileEntry(string fileName, bool useFileSystem)
		{
			return this.MakeFileEntry(fileName, null, useFileSystem);
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x0012F74C File Offset: 0x0012D94C
		public ZipEntry MakeFileEntry(string fileName, string entryName, bool useFileSystem)
		{
			ZipEntry zipEntry = new ZipEntry(this.nameTransform_.TransformFile((!string.IsNullOrEmpty(entryName)) ? entryName : fileName));
			zipEntry.IsUnicodeText = this.isUnicodeText_;
			int num = 0;
			bool flag = this.setAttributes_ != 0;
			FileInfo fileInfo = null;
			if (useFileSystem)
			{
				fileInfo = new FileInfo(fileName);
			}
			if (fileInfo != null && fileInfo.Exists)
			{
				switch (this.timeSetting_)
				{
				case ZipEntryFactory.TimeSetting.LastWriteTime:
					zipEntry.DateTime = fileInfo.LastWriteTime;
					break;
				case ZipEntryFactory.TimeSetting.LastWriteTimeUtc:
					zipEntry.DateTime = fileInfo.LastWriteTimeUtc;
					break;
				case ZipEntryFactory.TimeSetting.CreateTime:
					zipEntry.DateTime = fileInfo.CreationTime;
					break;
				case ZipEntryFactory.TimeSetting.CreateTimeUtc:
					zipEntry.DateTime = fileInfo.CreationTimeUtc;
					break;
				case ZipEntryFactory.TimeSetting.LastAccessTime:
					zipEntry.DateTime = fileInfo.LastAccessTime;
					break;
				case ZipEntryFactory.TimeSetting.LastAccessTimeUtc:
					zipEntry.DateTime = fileInfo.LastAccessTimeUtc;
					break;
				case ZipEntryFactory.TimeSetting.Fixed:
					zipEntry.DateTime = this.fixedDateTime_;
					break;
				default:
					throw new ZipException("Unhandled time setting in MakeFileEntry");
				}
				zipEntry.Size = fileInfo.Length;
				flag = true;
				num = (int)(fileInfo.Attributes & (FileAttributes)this.getAttributes_);
			}
			else if (this.timeSetting_ == ZipEntryFactory.TimeSetting.Fixed)
			{
				zipEntry.DateTime = this.fixedDateTime_;
			}
			if (flag)
			{
				num |= this.setAttributes_;
				zipEntry.ExternalFileAttributes = num;
			}
			return zipEntry;
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0012F88C File Offset: 0x0012DA8C
		public ZipEntry MakeDirectoryEntry(string directoryName)
		{
			return this.MakeDirectoryEntry(directoryName, true);
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x0012F898 File Offset: 0x0012DA98
		public ZipEntry MakeDirectoryEntry(string directoryName, bool useFileSystem)
		{
			ZipEntry zipEntry = new ZipEntry(this.nameTransform_.TransformDirectory(directoryName));
			zipEntry.IsUnicodeText = this.isUnicodeText_;
			zipEntry.Size = 0L;
			int num = 0;
			DirectoryInfo directoryInfo = null;
			if (useFileSystem)
			{
				directoryInfo = new DirectoryInfo(directoryName);
			}
			if (directoryInfo != null && directoryInfo.Exists)
			{
				switch (this.timeSetting_)
				{
				case ZipEntryFactory.TimeSetting.LastWriteTime:
					zipEntry.DateTime = directoryInfo.LastWriteTime;
					break;
				case ZipEntryFactory.TimeSetting.LastWriteTimeUtc:
					zipEntry.DateTime = directoryInfo.LastWriteTimeUtc;
					break;
				case ZipEntryFactory.TimeSetting.CreateTime:
					zipEntry.DateTime = directoryInfo.CreationTime;
					break;
				case ZipEntryFactory.TimeSetting.CreateTimeUtc:
					zipEntry.DateTime = directoryInfo.CreationTimeUtc;
					break;
				case ZipEntryFactory.TimeSetting.LastAccessTime:
					zipEntry.DateTime = directoryInfo.LastAccessTime;
					break;
				case ZipEntryFactory.TimeSetting.LastAccessTimeUtc:
					zipEntry.DateTime = directoryInfo.LastAccessTimeUtc;
					break;
				case ZipEntryFactory.TimeSetting.Fixed:
					zipEntry.DateTime = this.fixedDateTime_;
					break;
				default:
					throw new ZipException("Unhandled time setting in MakeDirectoryEntry");
				}
				num = (int)(directoryInfo.Attributes & (FileAttributes)this.getAttributes_);
			}
			else if (this.timeSetting_ == ZipEntryFactory.TimeSetting.Fixed)
			{
				zipEntry.DateTime = this.fixedDateTime_;
			}
			num |= this.setAttributes_ | 16;
			zipEntry.ExternalFileAttributes = num;
			return zipEntry;
		}

		// Token: 0x04000D8A RID: 3466
		private INameTransform nameTransform_;

		// Token: 0x04000D8B RID: 3467
		private DateTime fixedDateTime_ = DateTime.Now;

		// Token: 0x04000D8C RID: 3468
		private ZipEntryFactory.TimeSetting timeSetting_;

		// Token: 0x04000D8D RID: 3469
		private bool isUnicodeText_;

		// Token: 0x04000D8E RID: 3470
		private int getAttributes_ = -1;

		// Token: 0x04000D8F RID: 3471
		private int setAttributes_;

		// Token: 0x0200024A RID: 586
		public enum TimeSetting
		{
			// Token: 0x04001526 RID: 5414
			LastWriteTime,
			// Token: 0x04001527 RID: 5415
			LastWriteTimeUtc,
			// Token: 0x04001528 RID: 5416
			CreateTime,
			// Token: 0x04001529 RID: 5417
			CreateTimeUtc,
			// Token: 0x0400152A RID: 5418
			LastAccessTime,
			// Token: 0x0400152B RID: 5419
			LastAccessTimeUtc,
			// Token: 0x0400152C RID: 5420
			Fixed
		}
	}
}
