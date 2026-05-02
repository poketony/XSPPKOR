using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x02000193 RID: 403
	public class FileSystemScanner
	{
		// Token: 0x06001AC3 RID: 6851 RVA: 0x0013E79C File Offset: 0x0013C99C
		public FileSystemScanner(string filter)
		{
			this.fileFilter_ = new PathFilter(filter);
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x0013E7B0 File Offset: 0x0013C9B0
		public FileSystemScanner(string fileFilter, string directoryFilter)
		{
			this.fileFilter_ = new PathFilter(fileFilter);
			this.directoryFilter_ = new PathFilter(directoryFilter);
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x0013E7D0 File Offset: 0x0013C9D0
		public FileSystemScanner(IScanFilter fileFilter)
		{
			this.fileFilter_ = fileFilter;
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x0013E7DF File Offset: 0x0013C9DF
		public FileSystemScanner(IScanFilter fileFilter, IScanFilter directoryFilter)
		{
			this.fileFilter_ = fileFilter;
			this.directoryFilter_ = directoryFilter;
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06001AC7 RID: 6855 RVA: 0x0013E7F8 File Offset: 0x0013C9F8
		// (remove) Token: 0x06001AC8 RID: 6856 RVA: 0x0013E830 File Offset: 0x0013CA30
		public event EventHandler<DirectoryEventArgs> ProcessDirectory;

		// Token: 0x06001AC9 RID: 6857 RVA: 0x0013E868 File Offset: 0x0013CA68
		private bool OnDirectoryFailure(string directory, Exception e)
		{
			DirectoryFailureHandler directoryFailure = this.DirectoryFailure;
			bool flag = directoryFailure != null;
			if (flag)
			{
				ScanFailureEventArgs scanFailureEventArgs = new ScanFailureEventArgs(directory, e);
				directoryFailure(this, scanFailureEventArgs);
				this.alive_ = scanFailureEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x0013E8A0 File Offset: 0x0013CAA0
		private bool OnFileFailure(string file, Exception e)
		{
			bool flag = this.FileFailure != null;
			if (flag)
			{
				ScanFailureEventArgs scanFailureEventArgs = new ScanFailureEventArgs(file, e);
				this.FileFailure(this, scanFailureEventArgs);
				this.alive_ = scanFailureEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x0013E8DC File Offset: 0x0013CADC
		private void OnProcessFile(string file)
		{
			ProcessFileHandler processFile = this.ProcessFile;
			if (processFile != null)
			{
				ScanEventArgs scanEventArgs = new ScanEventArgs(file);
				processFile(this, scanEventArgs);
				this.alive_ = scanEventArgs.ContinueRunning;
			}
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x0013E910 File Offset: 0x0013CB10
		private void OnCompleteFile(string file)
		{
			CompletedFileHandler completedFile = this.CompletedFile;
			if (completedFile != null)
			{
				ScanEventArgs scanEventArgs = new ScanEventArgs(file);
				completedFile(this, scanEventArgs);
				this.alive_ = scanEventArgs.ContinueRunning;
			}
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x0013E944 File Offset: 0x0013CB44
		private void OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			EventHandler<DirectoryEventArgs> processDirectory = this.ProcessDirectory;
			if (processDirectory != null)
			{
				DirectoryEventArgs directoryEventArgs = new DirectoryEventArgs(directory, hasMatchingFiles);
				processDirectory(this, directoryEventArgs);
				this.alive_ = directoryEventArgs.ContinueRunning;
			}
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x0013E977 File Offset: 0x0013CB77
		public void Scan(string directory, bool recurse)
		{
			this.alive_ = true;
			this.ScanDir(directory, recurse);
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x0013E988 File Offset: 0x0013CB88
		private void ScanDir(string directory, bool recurse)
		{
			try
			{
				string[] files = Directory.GetFiles(directory);
				bool flag = false;
				for (int i = 0; i < files.Length; i++)
				{
					if (!this.fileFilter_.IsMatch(files[i]))
					{
						files[i] = null;
					}
					else
					{
						flag = true;
					}
				}
				this.OnProcessDirectory(directory, flag);
				if (this.alive_ && flag)
				{
					foreach (string text in files)
					{
						try
						{
							if (text != null)
							{
								this.OnProcessFile(text);
								if (!this.alive_)
								{
									break;
								}
							}
						}
						catch (Exception ex)
						{
							if (!this.OnFileFailure(text, ex))
							{
								throw;
							}
						}
					}
				}
			}
			catch (Exception ex2)
			{
				if (!this.OnDirectoryFailure(directory, ex2))
				{
					throw;
				}
			}
			if (this.alive_ && recurse)
			{
				try
				{
					foreach (string text2 in Directory.GetDirectories(directory))
					{
						if (this.directoryFilter_ == null || this.directoryFilter_.IsMatch(text2))
						{
							this.ScanDir(text2, true);
							if (!this.alive_)
							{
								break;
							}
						}
					}
				}
				catch (Exception ex3)
				{
					if (!this.OnDirectoryFailure(directory, ex3))
					{
						throw;
					}
				}
			}
		}

		// Token: 0x04000F76 RID: 3958
		public ProcessFileHandler ProcessFile;

		// Token: 0x04000F77 RID: 3959
		public CompletedFileHandler CompletedFile;

		// Token: 0x04000F78 RID: 3960
		public DirectoryFailureHandler DirectoryFailure;

		// Token: 0x04000F79 RID: 3961
		public FileFailureHandler FileFailure;

		// Token: 0x04000F7A RID: 3962
		private IScanFilter fileFilter_;

		// Token: 0x04000F7B RID: 3963
		private IScanFilter directoryFilter_;

		// Token: 0x04000F7C RID: 3964
		private bool alive_;
	}
}
