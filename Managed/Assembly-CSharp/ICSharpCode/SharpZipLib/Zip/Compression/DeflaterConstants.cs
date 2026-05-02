using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	// Token: 0x02000163 RID: 355
	public static class DeflaterConstants
	{
		// Token: 0x04000E08 RID: 3592
		public const bool DEBUGGING = false;

		// Token: 0x04000E09 RID: 3593
		public const int STORED_BLOCK = 0;

		// Token: 0x04000E0A RID: 3594
		public const int STATIC_TREES = 1;

		// Token: 0x04000E0B RID: 3595
		public const int DYN_TREES = 2;

		// Token: 0x04000E0C RID: 3596
		public const int PRESET_DICT = 32;

		// Token: 0x04000E0D RID: 3597
		public const int DEFAULT_MEM_LEVEL = 8;

		// Token: 0x04000E0E RID: 3598
		public const int MAX_MATCH = 258;

		// Token: 0x04000E0F RID: 3599
		public const int MIN_MATCH = 3;

		// Token: 0x04000E10 RID: 3600
		public const int MAX_WBITS = 15;

		// Token: 0x04000E11 RID: 3601
		public const int WSIZE = 32768;

		// Token: 0x04000E12 RID: 3602
		public const int WMASK = 32767;

		// Token: 0x04000E13 RID: 3603
		public const int HASH_BITS = 15;

		// Token: 0x04000E14 RID: 3604
		public const int HASH_SIZE = 32768;

		// Token: 0x04000E15 RID: 3605
		public const int HASH_MASK = 32767;

		// Token: 0x04000E16 RID: 3606
		public const int HASH_SHIFT = 5;

		// Token: 0x04000E17 RID: 3607
		public const int MIN_LOOKAHEAD = 262;

		// Token: 0x04000E18 RID: 3608
		public const int MAX_DIST = 32506;

		// Token: 0x04000E19 RID: 3609
		public const int PENDING_BUF_SIZE = 65536;

		// Token: 0x04000E1A RID: 3610
		public static int MAX_BLOCK_SIZE = Math.Min(65535, 65531);

		// Token: 0x04000E1B RID: 3611
		public const int DEFLATE_STORED = 0;

		// Token: 0x04000E1C RID: 3612
		public const int DEFLATE_FAST = 1;

		// Token: 0x04000E1D RID: 3613
		public const int DEFLATE_SLOW = 2;

		// Token: 0x04000E1E RID: 3614
		public static int[] GOOD_LENGTH = new int[] { 0, 4, 4, 4, 4, 8, 8, 8, 32, 32 };

		// Token: 0x04000E1F RID: 3615
		public static int[] MAX_LAZY = new int[] { 0, 4, 5, 6, 4, 16, 16, 32, 128, 258 };

		// Token: 0x04000E20 RID: 3616
		public static int[] NICE_LENGTH = new int[] { 0, 8, 16, 32, 16, 32, 128, 128, 258, 258 };

		// Token: 0x04000E21 RID: 3617
		public static int[] MAX_CHAIN = new int[] { 0, 4, 8, 32, 16, 32, 128, 256, 1024, 4096 };

		// Token: 0x04000E22 RID: 3618
		public static int[] COMPR_FUNC = new int[] { 0, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
	}
}
