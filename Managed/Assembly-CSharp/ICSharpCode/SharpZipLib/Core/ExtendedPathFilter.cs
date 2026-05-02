using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x02000199 RID: 409
	public class ExtendedPathFilter : PathFilter
	{
		// Token: 0x06001AE2 RID: 6882 RVA: 0x0013EEDF File Offset: 0x0013D0DF
		public ExtendedPathFilter(string filter, long minSize, long maxSize)
			: base(filter)
		{
			this.MinSize = minSize;
			this.MaxSize = maxSize;
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x0013EF1B File Offset: 0x0013D11B
		public ExtendedPathFilter(string filter, DateTime minDate, DateTime maxDate)
			: base(filter)
		{
			this.MinDate = minDate;
			this.MaxDate = maxDate;
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x0013EF58 File Offset: 0x0013D158
		public ExtendedPathFilter(string filter, long minSize, long maxSize, DateTime minDate, DateTime maxDate)
			: base(filter)
		{
			this.MinSize = minSize;
			this.MaxSize = maxSize;
			this.MinDate = minDate;
			this.MaxDate = maxDate;
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x0013EFB0 File Offset: 0x0013D1B0
		public override bool IsMatch(string name)
		{
			bool flag = base.IsMatch(name);
			if (flag)
			{
				FileInfo fileInfo = new FileInfo(name);
				flag = this.MinSize <= fileInfo.Length && this.MaxSize >= fileInfo.Length && this.MinDate <= fileInfo.LastWriteTime && this.MaxDate >= fileInfo.LastWriteTime;
			}
			return flag;
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06001AE6 RID: 6886 RVA: 0x0013F014 File Offset: 0x0013D214
		// (set) Token: 0x06001AE7 RID: 6887 RVA: 0x0013F01C File Offset: 0x0013D21C
		public long MinSize
		{
			get
			{
				return this.minSize_;
			}
			set
			{
				if (value < 0L || this.maxSize_ < value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.minSize_ = value;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06001AE8 RID: 6888 RVA: 0x0013F03E File Offset: 0x0013D23E
		// (set) Token: 0x06001AE9 RID: 6889 RVA: 0x0013F046 File Offset: 0x0013D246
		public long MaxSize
		{
			get
			{
				return this.maxSize_;
			}
			set
			{
				if (value < 0L || this.minSize_ > value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.maxSize_ = value;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06001AEA RID: 6890 RVA: 0x0013F068 File Offset: 0x0013D268
		// (set) Token: 0x06001AEB RID: 6891 RVA: 0x0013F070 File Offset: 0x0013D270
		public DateTime MinDate
		{
			get
			{
				return this.minDate_;
			}
			set
			{
				if (value > this.maxDate_)
				{
					throw new ArgumentOutOfRangeException("value", "Exceeds MaxDate");
				}
				this.minDate_ = value;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06001AEC RID: 6892 RVA: 0x0013F097 File Offset: 0x0013D297
		// (set) Token: 0x06001AED RID: 6893 RVA: 0x0013F09F File Offset: 0x0013D29F
		public DateTime MaxDate
		{
			get
			{
				return this.maxDate_;
			}
			set
			{
				if (this.minDate_ > value)
				{
					throw new ArgumentOutOfRangeException("value", "Exceeds MinDate");
				}
				this.maxDate_ = value;
			}
		}

		// Token: 0x04000F81 RID: 3969
		private long minSize_;

		// Token: 0x04000F82 RID: 3970
		private long maxSize_ = long.MaxValue;

		// Token: 0x04000F83 RID: 3971
		private DateTime minDate_ = DateTime.MinValue;

		// Token: 0x04000F84 RID: 3972
		private DateTime maxDate_ = DateTime.MaxValue;
	}
}
