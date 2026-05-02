using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000140 RID: 320
	[Flags]
	public enum GeneralBitFlags
	{
		// Token: 0x04000D2E RID: 3374
		Encrypted = 1,
		// Token: 0x04000D2F RID: 3375
		Method = 6,
		// Token: 0x04000D30 RID: 3376
		Descriptor = 8,
		// Token: 0x04000D31 RID: 3377
		ReservedPKware4 = 16,
		// Token: 0x04000D32 RID: 3378
		Patched = 32,
		// Token: 0x04000D33 RID: 3379
		StrongEncryption = 64,
		// Token: 0x04000D34 RID: 3380
		Unused7 = 128,
		// Token: 0x04000D35 RID: 3381
		Unused8 = 256,
		// Token: 0x04000D36 RID: 3382
		Unused9 = 512,
		// Token: 0x04000D37 RID: 3383
		Unused10 = 1024,
		// Token: 0x04000D38 RID: 3384
		UnicodeText = 2048,
		// Token: 0x04000D39 RID: 3385
		EnhancedCompress = 4096,
		// Token: 0x04000D3A RID: 3386
		HeaderMasked = 8192,
		// Token: 0x04000D3B RID: 3387
		ReservedPkware14 = 16384,
		// Token: 0x04000D3C RID: 3388
		ReservedPkware15 = 32768
	}
}
