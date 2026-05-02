using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200019A RID: 410
	[Obsolete("Use ExtendedPathFilter instead")]
	public class NameAndSizeFilter : PathFilter
	{
		// Token: 0x06001AEE RID: 6894 RVA: 0x0013F0C6 File Offset: 0x0013D2C6
		public NameAndSizeFilter(string filter, long minSize, long maxSize)
			: base(filter)
		{
			this.MinSize = minSize;
			this.MaxSize = maxSize;
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x0013F0EC File Offset: 0x0013D2EC
		public override bool IsMatch(string name)
		{
			bool flag = base.IsMatch(name);
			if (flag)
			{
				long length = new FileInfo(name).Length;
				flag = this.MinSize <= length && this.MaxSize >= length;
			}
			return flag;
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06001AF0 RID: 6896 RVA: 0x0013F12A File Offset: 0x0013D32A
		// (set) Token: 0x06001AF1 RID: 6897 RVA: 0x0013F132 File Offset: 0x0013D332
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

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06001AF2 RID: 6898 RVA: 0x0013F154 File Offset: 0x0013D354
		// (set) Token: 0x06001AF3 RID: 6899 RVA: 0x0013F15C File Offset: 0x0013D35C
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

		// Token: 0x04000F85 RID: 3973
		private long minSize_;

		// Token: 0x04000F86 RID: 3974
		private long maxSize_ = long.MaxValue;
	}
}
