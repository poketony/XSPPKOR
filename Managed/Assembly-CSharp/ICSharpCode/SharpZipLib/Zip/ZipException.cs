using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000145 RID: 325
	[Serializable]
	public class ZipException : SharpZipBaseException
	{
		// Token: 0x0600174E RID: 5966 RVA: 0x0012F9BB File Offset: 0x0012DBBB
		public ZipException()
		{
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x0012F9C3 File Offset: 0x0012DBC3
		public ZipException(string message)
			: base(message)
		{
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x0012F9CC File Offset: 0x0012DBCC
		public ZipException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0012F9D6 File Offset: 0x0012DBD6
		protected ZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
