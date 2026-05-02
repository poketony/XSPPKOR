using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	// Token: 0x02000137 RID: 311
	[Serializable]
	public class UnexpectedEndOfStreamException : StreamDecodingException
	{
		// Token: 0x060016AA RID: 5802 RVA: 0x0012DC27 File Offset: 0x0012BE27
		public UnexpectedEndOfStreamException()
			: base("Input stream ended unexpectedly")
		{
		}

		// Token: 0x060016AB RID: 5803 RVA: 0x0012DC34 File Offset: 0x0012BE34
		public UnexpectedEndOfStreamException(string message)
			: base(message)
		{
		}

		// Token: 0x060016AC RID: 5804 RVA: 0x0012DC3D File Offset: 0x0012BE3D
		public UnexpectedEndOfStreamException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x060016AD RID: 5805 RVA: 0x0012DC47 File Offset: 0x0012BE47
		protected UnexpectedEndOfStreamException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		// Token: 0x04000CF2 RID: 3314
		private const string GenericMessage = "Input stream ended unexpectedly";
	}
}
