using System;

namespace ICSharpCode.SharpZipLib.Lzw
{
	// Token: 0x0200017B RID: 379
	public sealed class LzwConstants
	{
		// Token: 0x06001A3D RID: 6717 RVA: 0x0013CD2A File Offset: 0x0013AF2A
		private LzwConstants()
		{
		}

		// Token: 0x04000F24 RID: 3876
		public const int MAGIC = 8093;

		// Token: 0x04000F25 RID: 3877
		public const int MAX_BITS = 16;

		// Token: 0x04000F26 RID: 3878
		public const int BIT_MASK = 31;

		// Token: 0x04000F27 RID: 3879
		public const int EXTENDED_MASK = 32;

		// Token: 0x04000F28 RID: 3880
		public const int RESERVED_MASK = 96;

		// Token: 0x04000F29 RID: 3881
		public const int BLOCK_MODE_MASK = 128;

		// Token: 0x04000F2A RID: 3882
		public const int HDR_SIZE = 3;

		// Token: 0x04000F2B RID: 3883
		public const int INIT_BITS = 9;
	}
}
