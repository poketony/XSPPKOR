using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x02000195 RID: 405
	[Serializable]
	public class InvalidNameException : SharpZipBaseException
	{
		// Token: 0x06001AD2 RID: 6866 RVA: 0x0013EABC File Offset: 0x0013CCBC
		public InvalidNameException()
			: base("An invalid name was specified")
		{
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x0013EAC9 File Offset: 0x0013CCC9
		public InvalidNameException(string message)
			: base(message)
		{
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x0013EAD2 File Offset: 0x0013CCD2
		public InvalidNameException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x0013EADC File Offset: 0x0013CCDC
		protected InvalidNameException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
