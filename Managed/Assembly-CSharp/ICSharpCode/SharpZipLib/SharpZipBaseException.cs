using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	// Token: 0x02000134 RID: 308
	[Serializable]
	public class SharpZipBaseException : Exception
	{
		// Token: 0x0600169E RID: 5790 RVA: 0x0012DBAE File Offset: 0x0012BDAE
		public SharpZipBaseException()
		{
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x0012DBB6 File Offset: 0x0012BDB6
		public SharpZipBaseException(string message)
			: base(message)
		{
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x0012DBBF File Offset: 0x0012BDBF
		public SharpZipBaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x0012DBC9 File Offset: 0x0012BDC9
		protected SharpZipBaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
