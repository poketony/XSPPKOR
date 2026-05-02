using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	// Token: 0x02000135 RID: 309
	[Serializable]
	public class StreamDecodingException : SharpZipBaseException
	{
		// Token: 0x060016A2 RID: 5794 RVA: 0x0012DBD3 File Offset: 0x0012BDD3
		public StreamDecodingException()
			: base("Input stream could not be decoded")
		{
		}

		// Token: 0x060016A3 RID: 5795 RVA: 0x0012DBE0 File Offset: 0x0012BDE0
		public StreamDecodingException(string message)
			: base(message)
		{
		}

		// Token: 0x060016A4 RID: 5796 RVA: 0x0012DBE9 File Offset: 0x0012BDE9
		public StreamDecodingException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x0012DBF3 File Offset: 0x0012BDF3
		protected StreamDecodingException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		// Token: 0x04000CF0 RID: 3312
		private const string GenericMessage = "Input stream could not be decoded";
	}
}
