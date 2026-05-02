using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000176 RID: 374
	[Serializable]
	public class TarException : SharpZipBaseException
	{
		// Token: 0x060019C6 RID: 6598 RVA: 0x0013B41D File Offset: 0x0013961D
		public TarException()
		{
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x0013B425 File Offset: 0x00139625
		public TarException(string message)
			: base(message)
		{
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x0013B42E File Offset: 0x0013962E
		public TarException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x0013B438 File Offset: 0x00139638
		protected TarException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
