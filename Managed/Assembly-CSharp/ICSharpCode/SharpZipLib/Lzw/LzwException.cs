using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Lzw
{
	// Token: 0x0200017C RID: 380
	[Serializable]
	public class LzwException : SharpZipBaseException
	{
		// Token: 0x06001A3E RID: 6718 RVA: 0x0013CD32 File Offset: 0x0013AF32
		public LzwException()
		{
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x0013CD3A File Offset: 0x0013AF3A
		public LzwException(string message)
			: base(message)
		{
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x0013CD43 File Offset: 0x0013AF43
		public LzwException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x0013CD4D File Offset: 0x0013AF4D
		protected LzwException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
