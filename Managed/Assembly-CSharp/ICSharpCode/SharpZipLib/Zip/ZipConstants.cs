using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000141 RID: 321
	public static class ZipConstants
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060016F3 RID: 5875 RVA: 0x0012EA2F File Offset: 0x0012CC2F
		// (set) Token: 0x060016F4 RID: 5876 RVA: 0x0012EA36 File Offset: 0x0012CC36
		[Obsolete("Use ZipStrings instead")]
		public static int DefaultCodePage
		{
			get
			{
				return ZipStrings.CodePage;
			}
			set
			{
				ZipStrings.CodePage = value;
			}
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x0012EA3E File Offset: 0x0012CC3E
		[Obsolete("Use ZipStrings.ConvertToString instead")]
		public static string ConvertToString(byte[] data, int count)
		{
			return ZipStrings.ConvertToString(data, count);
		}

		// Token: 0x060016F6 RID: 5878 RVA: 0x0012EA47 File Offset: 0x0012CC47
		[Obsolete("Use ZipStrings.ConvertToString instead")]
		public static string ConvertToString(byte[] data)
		{
			return ZipStrings.ConvertToString(data);
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x0012EA4F File Offset: 0x0012CC4F
		[Obsolete("Use ZipStrings.ConvertToStringExt instead")]
		public static string ConvertToStringExt(int flags, byte[] data, int count)
		{
			return ZipStrings.ConvertToStringExt(flags, data, count);
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x0012EA59 File Offset: 0x0012CC59
		[Obsolete("Use ZipStrings.ConvertToStringExt instead")]
		public static string ConvertToStringExt(int flags, byte[] data)
		{
			return ZipStrings.ConvertToStringExt(flags, data);
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x0012EA62 File Offset: 0x0012CC62
		[Obsolete("Use ZipStrings.ConvertToArray instead")]
		public static byte[] ConvertToArray(string str)
		{
			return ZipStrings.ConvertToArray(str);
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x0012EA6A File Offset: 0x0012CC6A
		[Obsolete("Use ZipStrings.ConvertToArray instead")]
		public static byte[] ConvertToArray(int flags, string str)
		{
			return ZipStrings.ConvertToArray(flags, str);
		}

		// Token: 0x04000D3D RID: 3389
		public const int VersionMadeBy = 51;

		// Token: 0x04000D3E RID: 3390
		[Obsolete("Use VersionMadeBy instead")]
		public const int VERSION_MADE_BY = 51;

		// Token: 0x04000D3F RID: 3391
		public const int VersionStrongEncryption = 50;

		// Token: 0x04000D40 RID: 3392
		[Obsolete("Use VersionStrongEncryption instead")]
		public const int VERSION_STRONG_ENCRYPTION = 50;

		// Token: 0x04000D41 RID: 3393
		public const int VERSION_AES = 51;

		// Token: 0x04000D42 RID: 3394
		public const int VersionZip64 = 45;

		// Token: 0x04000D43 RID: 3395
		public const int LocalHeaderBaseSize = 30;

		// Token: 0x04000D44 RID: 3396
		[Obsolete("Use LocalHeaderBaseSize instead")]
		public const int LOCHDR = 30;

		// Token: 0x04000D45 RID: 3397
		public const int Zip64DataDescriptorSize = 24;

		// Token: 0x04000D46 RID: 3398
		public const int DataDescriptorSize = 16;

		// Token: 0x04000D47 RID: 3399
		[Obsolete("Use DataDescriptorSize instead")]
		public const int EXTHDR = 16;

		// Token: 0x04000D48 RID: 3400
		public const int CentralHeaderBaseSize = 46;

		// Token: 0x04000D49 RID: 3401
		[Obsolete("Use CentralHeaderBaseSize instead")]
		public const int CENHDR = 46;

		// Token: 0x04000D4A RID: 3402
		public const int EndOfCentralRecordBaseSize = 22;

		// Token: 0x04000D4B RID: 3403
		[Obsolete("Use EndOfCentralRecordBaseSize instead")]
		public const int ENDHDR = 22;

		// Token: 0x04000D4C RID: 3404
		public const int CryptoHeaderSize = 12;

		// Token: 0x04000D4D RID: 3405
		[Obsolete("Use CryptoHeaderSize instead")]
		public const int CRYPTO_HEADER_SIZE = 12;

		// Token: 0x04000D4E RID: 3406
		public const int Zip64EndOfCentralDirectoryLocatorSize = 20;

		// Token: 0x04000D4F RID: 3407
		public const int LocalHeaderSignature = 67324752;

		// Token: 0x04000D50 RID: 3408
		[Obsolete("Use LocalHeaderSignature instead")]
		public const int LOCSIG = 67324752;

		// Token: 0x04000D51 RID: 3409
		public const int SpanningSignature = 134695760;

		// Token: 0x04000D52 RID: 3410
		[Obsolete("Use SpanningSignature instead")]
		public const int SPANNINGSIG = 134695760;

		// Token: 0x04000D53 RID: 3411
		public const int SpanningTempSignature = 808471376;

		// Token: 0x04000D54 RID: 3412
		[Obsolete("Use SpanningTempSignature instead")]
		public const int SPANTEMPSIG = 808471376;

		// Token: 0x04000D55 RID: 3413
		public const int DataDescriptorSignature = 134695760;

		// Token: 0x04000D56 RID: 3414
		[Obsolete("Use DataDescriptorSignature instead")]
		public const int EXTSIG = 134695760;

		// Token: 0x04000D57 RID: 3415
		[Obsolete("Use CentralHeaderSignature instead")]
		public const int CENSIG = 33639248;

		// Token: 0x04000D58 RID: 3416
		public const int CentralHeaderSignature = 33639248;

		// Token: 0x04000D59 RID: 3417
		public const int Zip64CentralFileHeaderSignature = 101075792;

		// Token: 0x04000D5A RID: 3418
		[Obsolete("Use Zip64CentralFileHeaderSignature instead")]
		public const int CENSIG64 = 101075792;

		// Token: 0x04000D5B RID: 3419
		public const int Zip64CentralDirLocatorSignature = 117853008;

		// Token: 0x04000D5C RID: 3420
		public const int ArchiveExtraDataSignature = 117853008;

		// Token: 0x04000D5D RID: 3421
		public const int CentralHeaderDigitalSignature = 84233040;

		// Token: 0x04000D5E RID: 3422
		[Obsolete("Use CentralHeaderDigitalSignaure instead")]
		public const int CENDIGITALSIG = 84233040;

		// Token: 0x04000D5F RID: 3423
		public const int EndOfCentralDirectorySignature = 101010256;

		// Token: 0x04000D60 RID: 3424
		[Obsolete("Use EndOfCentralDirectorySignature instead")]
		public const int ENDSIG = 101010256;
	}
}
