using System;

namespace B83.Image.BMP
{
	// Token: 0x02000068 RID: 104
	public struct BMPFileHeader
	{
		// Token: 0x040008A8 RID: 2216
		public ushort magic;

		// Token: 0x040008A9 RID: 2217
		public uint filesize;

		// Token: 0x040008AA RID: 2218
		public uint reserved;

		// Token: 0x040008AB RID: 2219
		public uint offset;
	}
}
