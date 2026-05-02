using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200013E RID: 318
	public enum CompressionMethod
	{
		// Token: 0x04000D17 RID: 3351
		Stored,
		// Token: 0x04000D18 RID: 3352
		Deflated = 8,
		// Token: 0x04000D19 RID: 3353
		Deflate64,
		// Token: 0x04000D1A RID: 3354
		BZip2 = 12,
		// Token: 0x04000D1B RID: 3355
		LZMA = 14,
		// Token: 0x04000D1C RID: 3356
		PPMd = 98,
		// Token: 0x04000D1D RID: 3357
		WinZipAES
	}
}
