using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.GZip
{
	// Token: 0x02000180 RID: 384
	[Serializable]
	public class GZipException : SharpZipBaseException
	{
		// Token: 0x06001A59 RID: 6745 RVA: 0x0013D634 File Offset: 0x0013B834
		public GZipException()
		{
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x0013D63C File Offset: 0x0013B83C
		public GZipException(string message)
			: base(message)
		{
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x0013D645 File Offset: 0x0013B845
		public GZipException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x0013D64F File Offset: 0x0013B84F
		protected GZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
