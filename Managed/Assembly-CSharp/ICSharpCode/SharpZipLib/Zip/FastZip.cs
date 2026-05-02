using System;
using System.Collections;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200013A RID: 314
	public class FastZip
	{
		// Token: 0x060016BE RID: 5822 RVA: 0x0012DE72 File Offset: 0x0012C072
		public FastZip()
		{
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x0012DE93 File Offset: 0x0012C093
		public FastZip(FastZipEvents events)
		{
			this.events_ = events;
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060016C0 RID: 5824 RVA: 0x0012DEBB File Offset: 0x0012C0BB
		// (set) Token: 0x060016C1 RID: 5825 RVA: 0x0012DEC3 File Offset: 0x0012C0C3
		public bool CreateEmptyDirectories
		{
			get
			{
				return this.createEmptyDirectories_;
			}
			set
			{
				this.createEmptyDirectories_ = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x0012DECC File Offset: 0x0012C0CC
		// (set) Token: 0x060016C3 RID: 5827 RVA: 0x0012DED4 File Offset: 0x0012C0D4
		public string Password
		{
			get
			{
				return this.password_;
			}
			set
			{
				this.password_ = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060016C4 RID: 5828 RVA: 0x0012DEDD File Offset: 0x0012C0DD
		// (set) Token: 0x060016C5 RID: 5829 RVA: 0x0012DEEA File Offset: 0x0012C0EA
		public INameTransform NameTransform
		{
			get
			{
				return this.entryFactory_.NameTransform;
			}
			set
			{
				this.entryFactory_.NameTransform = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060016C6 RID: 5830 RVA: 0x0012DEF8 File Offset: 0x0012C0F8
		// (set) Token: 0x060016C7 RID: 5831 RVA: 0x0012DF00 File Offset: 0x0012C100
		public IEntryFactory EntryFactory
		{
			get
			{
				return this.entryFactory_;
			}
			set
			{
				if (value == null)
				{
					this.entryFactory_ = new ZipEntryFactory();
					return;
				}
				this.entryFactory_ = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060016C8 RID: 5832 RVA: 0x0012DF18 File Offset: 0x0012C118
		// (set) Token: 0x060016C9 RID: 5833 RVA: 0x0012DF20 File Offset: 0x0012C120
		public UseZip64 UseZip64
		{
			get
			{
				return this.useZip64_;
			}
			set
			{
				this.useZip64_ = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060016CA RID: 5834 RVA: 0x0012DF29 File Offset: 0x0012C129
		// (set) Token: 0x060016CB RID: 5835 RVA: 0x0012DF31 File Offset: 0x0012C131
		public bool RestoreDateTimeOnExtract
		{
			get
			{
				return this.restoreDateTimeOnExtract_;
			}
			set
			{
				this.restoreDateTimeOnExtract_ = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060016CC RID: 5836 RVA: 0x0012DF3A File Offset: 0x0012C13A
		// (set) Token: 0x060016CD RID: 5837 RVA: 0x0012DF42 File Offset: 0x0012C142
		public bool RestoreAttributesOnExtract
		{
			get
			{
				return this.restoreAttributesOnExtract_;
			}
			set
			{
				this.restoreAttributesOnExtract_ = value;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060016CE RID: 5838 RVA: 0x0012DF4B File Offset: 0x0012C14B
		// (set) Token: 0x060016CF RID: 5839 RVA: 0x0012DF53 File Offset: 0x0012C153
		public Deflater.CompressionLevel CompressionLevel
		{
			get
			{
				return this.compressionLevel_;
			}
			set
			{
				this.compressionLevel_ = value;
			}
		}

		// Token: 0x060016D0 RID: 5840 RVA: 0x0012DF5C File Offset: 0x0012C15C
		public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
		{
			this.CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, directoryFilter);
		}

		// Token: 0x060016D1 RID: 5841 RVA: 0x0012DF70 File Offset: 0x0012C170
		public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter)
		{
			this.CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, null);
		}

		// Token: 0x060016D2 RID: 5842 RVA: 0x0012DF84 File Offset: 0x0012C184
		public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
		{
			this.NameTransform = new ZipNameTransform(sourceDirectory);
			this.sourceDirectory_ = sourceDirectory;
			using (this.outputStream_ = new ZipOutputStream(outputStream))
			{
				this.outputStream_.SetLevel((int)this.CompressionLevel);
				if (this.password_ != null)
				{
					this.outputStream_.Password = this.password_;
				}
				this.outputStream_.UseZip64 = this.UseZip64;
				FileSystemScanner fileSystemScanner = new FileSystemScanner(fileFilter, directoryFilter);
				FileSystemScanner fileSystemScanner2 = fileSystemScanner;
				fileSystemScanner2.ProcessFile = (ProcessFileHandler)Delegate.Combine(fileSystemScanner2.ProcessFile, new ProcessFileHandler(this.ProcessFile));
				if (this.CreateEmptyDirectories)
				{
					fileSystemScanner.ProcessDirectory += this.ProcessDirectory;
				}
				if (this.events_ != null)
				{
					if (this.events_.FileFailure != null)
					{
						FileSystemScanner fileSystemScanner3 = fileSystemScanner;
						fileSystemScanner3.FileFailure = (FileFailureHandler)Delegate.Combine(fileSystemScanner3.FileFailure, this.events_.FileFailure);
					}
					if (this.events_.DirectoryFailure != null)
					{
						FileSystemScanner fileSystemScanner4 = fileSystemScanner;
						fileSystemScanner4.DirectoryFailure = (DirectoryFailureHandler)Delegate.Combine(fileSystemScanner4.DirectoryFailure, this.events_.DirectoryFailure);
					}
				}
				fileSystemScanner.Scan(sourceDirectory, recurse);
			}
		}

		// Token: 0x060016D3 RID: 5843 RVA: 0x0012E0C0 File Offset: 0x0012C2C0
		public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter)
		{
			this.ExtractZip(zipFileName, targetDirectory, FastZip.Overwrite.Always, null, fileFilter, null, this.restoreDateTimeOnExtract_, false);
		}

		// Token: 0x060016D4 RID: 5844 RVA: 0x0012E0E0 File Offset: 0x0012C2E0
		public void ExtractZip(string zipFileName, string targetDirectory, FastZip.Overwrite overwrite, FastZip.ConfirmOverwriteDelegate confirmDelegate, string fileFilter, string directoryFilter, bool restoreDateTime, bool allowParentTraversal = false)
		{
			Stream stream = File.Open(zipFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			this.ExtractZip(stream, targetDirectory, overwrite, confirmDelegate, fileFilter, directoryFilter, restoreDateTime, true, allowParentTraversal);
		}

		// Token: 0x060016D5 RID: 5845 RVA: 0x0012E10C File Offset: 0x0012C30C
		public void ExtractZip(Stream inputStream, string targetDirectory, FastZip.Overwrite overwrite, FastZip.ConfirmOverwriteDelegate confirmDelegate, string fileFilter, string directoryFilter, bool restoreDateTime, bool isStreamOwner, bool allowParentTraversal = false)
		{
			if (overwrite == FastZip.Overwrite.Prompt && confirmDelegate == null)
			{
				throw new ArgumentNullException("confirmDelegate");
			}
			this.continueRunning_ = true;
			this.overwrite_ = overwrite;
			this.confirmDelegate_ = confirmDelegate;
			this.extractNameTransform_ = new WindowsNameTransform(targetDirectory, allowParentTraversal);
			this.fileFilter_ = new NameFilter(fileFilter);
			this.directoryFilter_ = new NameFilter(directoryFilter);
			this.restoreDateTimeOnExtract_ = restoreDateTime;
			using (this.zipFile_ = new ZipFile(inputStream, !isStreamOwner))
			{
				if (this.password_ != null)
				{
					this.zipFile_.Password = this.password_;
				}
				IEnumerator enumerator = this.zipFile_.GetEnumerator();
				while (this.continueRunning_ && enumerator.MoveNext())
				{
					ZipEntry zipEntry = (ZipEntry)enumerator.Current;
					if (zipEntry.IsFile)
					{
						if (this.directoryFilter_.IsMatch(Path.GetDirectoryName(zipEntry.Name)) && this.fileFilter_.IsMatch(zipEntry.Name))
						{
							this.ExtractEntry(zipEntry);
						}
					}
					else if (zipEntry.IsDirectory && this.directoryFilter_.IsMatch(zipEntry.Name) && this.CreateEmptyDirectories)
					{
						this.ExtractEntry(zipEntry);
					}
				}
			}
		}

		// Token: 0x060016D6 RID: 5846 RVA: 0x0012E250 File Offset: 0x0012C450
		private void ProcessDirectory(object sender, DirectoryEventArgs e)
		{
			if (!e.HasMatchingFiles && this.CreateEmptyDirectories)
			{
				if (this.events_ != null)
				{
					this.events_.OnProcessDirectory(e.Name, e.HasMatchingFiles);
				}
				if (e.ContinueRunning && e.Name != this.sourceDirectory_)
				{
					ZipEntry zipEntry = this.entryFactory_.MakeDirectoryEntry(e.Name);
					this.outputStream_.PutNextEntry(zipEntry);
				}
			}
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x0012E2C8 File Offset: 0x0012C4C8
		private void ProcessFile(object sender, ScanEventArgs e)
		{
			if (this.events_ != null && this.events_.ProcessFile != null)
			{
				this.events_.ProcessFile(sender, e);
			}
			if (e.ContinueRunning)
			{
				try
				{
					using (FileStream fileStream = File.Open(e.Name, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						ZipEntry zipEntry = this.entryFactory_.MakeFileEntry(e.Name);
						this.outputStream_.PutNextEntry(zipEntry);
						this.AddFileContents(e.Name, fileStream);
					}
				}
				catch (Exception ex)
				{
					if (this.events_ == null)
					{
						this.continueRunning_ = false;
						throw;
					}
					this.continueRunning_ = this.events_.OnFileFailure(e.Name, ex);
				}
			}
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x0012E398 File Offset: 0x0012C598
		private void AddFileContents(string name, Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (this.buffer_ == null)
			{
				this.buffer_ = new byte[4096];
			}
			if (this.events_ != null && this.events_.Progress != null)
			{
				StreamUtils.Copy(stream, this.outputStream_, this.buffer_, this.events_.Progress, this.events_.ProgressInterval, this, name);
			}
			else
			{
				StreamUtils.Copy(stream, this.outputStream_, this.buffer_);
			}
			if (this.events_ != null)
			{
				this.continueRunning_ = this.events_.OnCompletedFile(name);
			}
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0012E438 File Offset: 0x0012C638
		private void ExtractFileEntry(ZipEntry entry, string targetName)
		{
			bool flag = true;
			if (this.overwrite_ != FastZip.Overwrite.Always && File.Exists(targetName))
			{
				flag = this.overwrite_ == FastZip.Overwrite.Prompt && this.confirmDelegate_ != null && this.confirmDelegate_(targetName);
			}
			if (flag)
			{
				if (this.events_ != null)
				{
					this.continueRunning_ = this.events_.OnProcessFile(entry.Name);
				}
				if (this.continueRunning_)
				{
					try
					{
						using (FileStream fileStream = File.Create(targetName))
						{
							if (this.buffer_ == null)
							{
								this.buffer_ = new byte[4096];
							}
							if (this.events_ != null && this.events_.Progress != null)
							{
								StreamUtils.Copy(this.zipFile_.GetInputStream(entry), fileStream, this.buffer_, this.events_.Progress, this.events_.ProgressInterval, this, entry.Name, entry.Size);
							}
							else
							{
								StreamUtils.Copy(this.zipFile_.GetInputStream(entry), fileStream, this.buffer_);
							}
							if (this.events_ != null)
							{
								this.continueRunning_ = this.events_.OnCompletedFile(entry.Name);
							}
						}
						if (this.restoreDateTimeOnExtract_)
						{
							File.SetLastWriteTime(targetName, entry.DateTime);
						}
						if (this.RestoreAttributesOnExtract && entry.IsDOSEntry && entry.ExternalFileAttributes != -1)
						{
							FileAttributes fileAttributes = (FileAttributes)entry.ExternalFileAttributes;
							fileAttributes &= FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive | FileAttributes.Normal;
							File.SetAttributes(targetName, fileAttributes);
						}
					}
					catch (Exception ex)
					{
						if (this.events_ == null)
						{
							this.continueRunning_ = false;
							throw;
						}
						this.continueRunning_ = this.events_.OnFileFailure(targetName, ex);
					}
				}
			}
		}

		// Token: 0x060016DA RID: 5850 RVA: 0x0012E5E8 File Offset: 0x0012C7E8
		private void ExtractEntry(ZipEntry entry)
		{
			bool flag = entry.IsCompressionMethodSupported();
			string text = entry.Name;
			if (flag)
			{
				if (entry.IsFile)
				{
					text = this.extractNameTransform_.TransformFile(text);
				}
				else if (entry.IsDirectory)
				{
					text = this.extractNameTransform_.TransformDirectory(text);
				}
				flag = !string.IsNullOrEmpty(text);
			}
			string text2 = null;
			if (flag)
			{
				if (entry.IsDirectory)
				{
					text2 = text;
				}
				else
				{
					text2 = Path.GetDirectoryName(Path.GetFullPath(text));
				}
			}
			if (flag && !Directory.Exists(text2) && (!entry.IsDirectory || this.CreateEmptyDirectories))
			{
				try
				{
					Directory.CreateDirectory(text2);
				}
				catch (Exception ex)
				{
					flag = false;
					if (this.events_ == null)
					{
						this.continueRunning_ = false;
						throw;
					}
					if (entry.IsDirectory)
					{
						this.continueRunning_ = this.events_.OnDirectoryFailure(text, ex);
					}
					else
					{
						this.continueRunning_ = this.events_.OnFileFailure(text, ex);
					}
				}
			}
			if (flag && entry.IsFile)
			{
				this.ExtractFileEntry(entry, text);
			}
		}

		// Token: 0x060016DB RID: 5851 RVA: 0x0012E6EC File Offset: 0x0012C8EC
		private static int MakeExternalAttributes(FileInfo info)
		{
			return (int)info.Attributes;
		}

		// Token: 0x060016DC RID: 5852 RVA: 0x0012E6F4 File Offset: 0x0012C8F4
		private static bool NameIsValid(string name)
		{
			return !string.IsNullOrEmpty(name) && name.IndexOfAny(Path.GetInvalidPathChars()) < 0;
		}

		// Token: 0x04000CFA RID: 3322
		private bool continueRunning_;

		// Token: 0x04000CFB RID: 3323
		private byte[] buffer_;

		// Token: 0x04000CFC RID: 3324
		private ZipOutputStream outputStream_;

		// Token: 0x04000CFD RID: 3325
		private ZipFile zipFile_;

		// Token: 0x04000CFE RID: 3326
		private string sourceDirectory_;

		// Token: 0x04000CFF RID: 3327
		private NameFilter fileFilter_;

		// Token: 0x04000D00 RID: 3328
		private NameFilter directoryFilter_;

		// Token: 0x04000D01 RID: 3329
		private FastZip.Overwrite overwrite_;

		// Token: 0x04000D02 RID: 3330
		private FastZip.ConfirmOverwriteDelegate confirmDelegate_;

		// Token: 0x04000D03 RID: 3331
		private bool restoreDateTimeOnExtract_;

		// Token: 0x04000D04 RID: 3332
		private bool restoreAttributesOnExtract_;

		// Token: 0x04000D05 RID: 3333
		private bool createEmptyDirectories_;

		// Token: 0x04000D06 RID: 3334
		private FastZipEvents events_;

		// Token: 0x04000D07 RID: 3335
		private IEntryFactory entryFactory_ = new ZipEntryFactory();

		// Token: 0x04000D08 RID: 3336
		private INameTransform extractNameTransform_;

		// Token: 0x04000D09 RID: 3337
		private UseZip64 useZip64_ = UseZip64.Dynamic;

		// Token: 0x04000D0A RID: 3338
		private Deflater.CompressionLevel compressionLevel_ = Deflater.CompressionLevel.DEFAULT_COMPRESSION;

		// Token: 0x04000D0B RID: 3339
		private string password_;

		// Token: 0x02000247 RID: 583
		public enum Overwrite
		{
			// Token: 0x0400151B RID: 5403
			Prompt,
			// Token: 0x0400151C RID: 5404
			Never,
			// Token: 0x0400151D RID: 5405
			Always
		}

		// Token: 0x02000248 RID: 584
		// (Invoke) Token: 0x06001DAF RID: 7599
		public delegate bool ConfirmOverwriteDelegate(string fileName);
	}
}
