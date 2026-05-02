using System;

namespace ICSharpCode.SharpZipLib.GZip
{
	// Token: 0x0200017F RID: 383
	public sealed class GZipConstants
	{
		// Token: 0x06001A58 RID: 6744 RVA: 0x0013D62C File Offset: 0x0013B82C
		private GZipConstants()
		{
		}

		// Token: 0x04000F47 RID: 3911
		public const int GZIP_MAGIC = 8075;

		// Token: 0x04000F48 RID: 3912
		public const int FTEXT = 1;

		// Token: 0x04000F49 RID: 3913
		public const int FHCRC = 2;

		// Token: 0x04000F4A RID: 3914
		public const int FEXTRA = 4;

		// Token: 0x04000F4B RID: 3915
		public const int FNAME = 8;

		// Token: 0x04000F4C RID: 3916
		public const int FCOMMENT = 16;
	}
}
