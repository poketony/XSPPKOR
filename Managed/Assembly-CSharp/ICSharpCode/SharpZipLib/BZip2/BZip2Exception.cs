using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.BZip2
{
	// Token: 0x020001A3 RID: 419
	[Serializable]
	public class BZip2Exception : SharpZipBaseException
	{
		// Token: 0x06001B1C RID: 6940 RVA: 0x0013F918 File Offset: 0x0013DB18
		public BZip2Exception()
		{
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x0013F920 File Offset: 0x0013DB20
		public BZip2Exception(string message)
			: base(message)
		{
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x0013F929 File Offset: 0x0013DB29
		public BZip2Exception(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x0013F933 File Offset: 0x0013DB33
		protected BZip2Exception(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
