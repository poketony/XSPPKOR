using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200014F RID: 335
	public class TestStatus
	{
		// Token: 0x06001798 RID: 6040 RVA: 0x0013061C File Offset: 0x0012E81C
		public TestStatus(ZipFile file)
		{
			this.file_ = file;
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06001799 RID: 6041 RVA: 0x0013062B File Offset: 0x0012E82B
		public TestOperation Operation
		{
			get
			{
				return this.operation_;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600179A RID: 6042 RVA: 0x00130633 File Offset: 0x0012E833
		public ZipFile File
		{
			get
			{
				return this.file_;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600179B RID: 6043 RVA: 0x0013063B File Offset: 0x0012E83B
		public ZipEntry Entry
		{
			get
			{
				return this.entry_;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x00130643 File Offset: 0x0012E843
		public int ErrorCount
		{
			get
			{
				return this.errorCount_;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600179D RID: 6045 RVA: 0x0013064B File Offset: 0x0012E84B
		public long BytesTested
		{
			get
			{
				return this.bytesTested_;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x00130653 File Offset: 0x0012E853
		public bool EntryValid
		{
			get
			{
				return this.entryValid_;
			}
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x0013065B File Offset: 0x0012E85B
		internal void AddError()
		{
			this.errorCount_++;
			this.entryValid_ = false;
		}

		// Token: 0x060017A0 RID: 6048 RVA: 0x00130672 File Offset: 0x0012E872
		internal void SetOperation(TestOperation operation)
		{
			this.operation_ = operation;
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x0013067B File Offset: 0x0012E87B
		internal void SetEntry(ZipEntry entry)
		{
			this.entry_ = entry;
			this.entryValid_ = true;
			this.bytesTested_ = 0L;
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x00130693 File Offset: 0x0012E893
		internal void SetBytesTested(long value)
		{
			this.bytesTested_ = value;
		}

		// Token: 0x04000DAA RID: 3498
		private readonly ZipFile file_;

		// Token: 0x04000DAB RID: 3499
		private ZipEntry entry_;

		// Token: 0x04000DAC RID: 3500
		private bool entryValid_;

		// Token: 0x04000DAD RID: 3501
		private int errorCount_;

		// Token: 0x04000DAE RID: 3502
		private long bytesTested_;

		// Token: 0x04000DAF RID: 3503
		private TestOperation operation_;
	}
}
