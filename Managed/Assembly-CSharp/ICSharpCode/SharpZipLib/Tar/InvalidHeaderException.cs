using System;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000171 RID: 369
	public class InvalidHeaderException : TarException
	{
		// Token: 0x0600195C RID: 6492 RVA: 0x00139F12 File Offset: 0x00138112
		public InvalidHeaderException()
		{
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x00139F1A File Offset: 0x0013811A
		public InvalidHeaderException(string message)
			: base(message)
		{
		}

		// Token: 0x0600195E RID: 6494 RVA: 0x00139F23 File Offset: 0x00138123
		public InvalidHeaderException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
