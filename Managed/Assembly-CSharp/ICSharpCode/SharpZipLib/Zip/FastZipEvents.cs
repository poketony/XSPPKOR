using System;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000139 RID: 313
	public class FastZipEvents
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060016B4 RID: 5812 RVA: 0x0012DCDC File Offset: 0x0012BEDC
		// (remove) Token: 0x060016B5 RID: 5813 RVA: 0x0012DD14 File Offset: 0x0012BF14
		public event EventHandler<DirectoryEventArgs> ProcessDirectory;

		// Token: 0x060016B6 RID: 5814 RVA: 0x0012DD4C File Offset: 0x0012BF4C
		public bool OnDirectoryFailure(string directory, Exception e)
		{
			bool flag = false;
			DirectoryFailureHandler directoryFailure = this.DirectoryFailure;
			if (directoryFailure != null)
			{
				ScanFailureEventArgs scanFailureEventArgs = new ScanFailureEventArgs(directory, e);
				directoryFailure(this, scanFailureEventArgs);
				flag = scanFailureEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x0012DD80 File Offset: 0x0012BF80
		public bool OnFileFailure(string file, Exception e)
		{
			FileFailureHandler fileFailure = this.FileFailure;
			bool flag = fileFailure != null;
			if (flag)
			{
				ScanFailureEventArgs scanFailureEventArgs = new ScanFailureEventArgs(file, e);
				fileFailure(this, scanFailureEventArgs);
				flag = scanFailureEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x0012DDB4 File Offset: 0x0012BFB4
		public bool OnProcessFile(string file)
		{
			bool flag = true;
			ProcessFileHandler processFile = this.ProcessFile;
			if (processFile != null)
			{
				ScanEventArgs scanEventArgs = new ScanEventArgs(file);
				processFile(this, scanEventArgs);
				flag = scanEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x0012DDE4 File Offset: 0x0012BFE4
		public bool OnCompletedFile(string file)
		{
			bool flag = true;
			CompletedFileHandler completedFile = this.CompletedFile;
			if (completedFile != null)
			{
				ScanEventArgs scanEventArgs = new ScanEventArgs(file);
				completedFile(this, scanEventArgs);
				flag = scanEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x0012DE14 File Offset: 0x0012C014
		public bool OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			bool flag = true;
			EventHandler<DirectoryEventArgs> processDirectory = this.ProcessDirectory;
			if (processDirectory != null)
			{
				DirectoryEventArgs directoryEventArgs = new DirectoryEventArgs(directory, hasMatchingFiles);
				processDirectory(this, directoryEventArgs);
				flag = directoryEventArgs.ContinueRunning;
			}
			return flag;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060016BB RID: 5819 RVA: 0x0012DE45 File Offset: 0x0012C045
		// (set) Token: 0x060016BC RID: 5820 RVA: 0x0012DE4D File Offset: 0x0012C04D
		public TimeSpan ProgressInterval
		{
			get
			{
				return this.progressInterval_;
			}
			set
			{
				this.progressInterval_ = value;
			}
		}

		// Token: 0x04000CF4 RID: 3316
		public ProcessFileHandler ProcessFile;

		// Token: 0x04000CF5 RID: 3317
		public ProgressHandler Progress;

		// Token: 0x04000CF6 RID: 3318
		public CompletedFileHandler CompletedFile;

		// Token: 0x04000CF7 RID: 3319
		public DirectoryFailureHandler DirectoryFailure;

		// Token: 0x04000CF8 RID: 3320
		public FileFailureHandler FileFailure;

		// Token: 0x04000CF9 RID: 3321
		private TimeSpan progressInterval_ = TimeSpan.FromSeconds(3.0);
	}
}
