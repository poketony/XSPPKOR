using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200013F RID: 319
	public enum EncryptionAlgorithm
	{
		// Token: 0x04000D1F RID: 3359
		None,
		// Token: 0x04000D20 RID: 3360
		PkzipClassic,
		// Token: 0x04000D21 RID: 3361
		Des = 26113,
		// Token: 0x04000D22 RID: 3362
		RC2,
		// Token: 0x04000D23 RID: 3363
		TripleDes168,
		// Token: 0x04000D24 RID: 3364
		TripleDes112 = 26121,
		// Token: 0x04000D25 RID: 3365
		Aes128 = 26126,
		// Token: 0x04000D26 RID: 3366
		Aes192,
		// Token: 0x04000D27 RID: 3367
		Aes256,
		// Token: 0x04000D28 RID: 3368
		RC2Corrected = 26370,
		// Token: 0x04000D29 RID: 3369
		Blowfish = 26400,
		// Token: 0x04000D2A RID: 3370
		Twofish,
		// Token: 0x04000D2B RID: 3371
		RC4 = 26625,
		// Token: 0x04000D2C RID: 3372
		Unknown = 65535
	}
}
