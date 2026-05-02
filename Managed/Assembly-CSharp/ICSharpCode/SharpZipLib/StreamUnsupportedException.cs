using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	// Token: 0x02000136 RID: 310
	[Serializable]
	public class StreamUnsupportedException : StreamDecodingException
	{
		// Token: 0x060016A6 RID: 5798 RVA: 0x0012DBFD File Offset: 0x0012BDFD
		public StreamUnsupportedException()
			: base("Input stream is in a unsupported format")
		{
		}

		// Token: 0x060016A7 RID: 5799 RVA: 0x0012DC0A File Offset: 0x0012BE0A
		public StreamUnsupportedException(string message)
			: base(message)
		{
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x0012DC13 File Offset: 0x0012BE13
		public StreamUnsupportedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x0012DC1D File Offset: 0x0012BE1D
		protected StreamUnsupportedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		// Token: 0x04000CF1 RID: 3313
		private const string GenericMessage = "Input stream is in a unsupported format";
	}
}
