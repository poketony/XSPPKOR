using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200015B RID: 347
	public class DescriptorData
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06001830 RID: 6192 RVA: 0x00133A32 File Offset: 0x00131C32
		// (set) Token: 0x06001831 RID: 6193 RVA: 0x00133A3A File Offset: 0x00131C3A
		public long CompressedSize
		{
			get
			{
				return this.compressedSize;
			}
			set
			{
				this.compressedSize = value;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06001832 RID: 6194 RVA: 0x00133A43 File Offset: 0x00131C43
		// (set) Token: 0x06001833 RID: 6195 RVA: 0x00133A4B File Offset: 0x00131C4B
		public long Size
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06001834 RID: 6196 RVA: 0x00133A54 File Offset: 0x00131C54
		// (set) Token: 0x06001835 RID: 6197 RVA: 0x00133A5C File Offset: 0x00131C5C
		public long Crc
		{
			get
			{
				return this.crc;
			}
			set
			{
				this.crc = value & (long)((ulong)(-1));
			}
		}

		// Token: 0x04000DD2 RID: 3538
		private long size;

		// Token: 0x04000DD3 RID: 3539
		private long compressedSize;

		// Token: 0x04000DD4 RID: 3540
		private long crc;
	}
}
