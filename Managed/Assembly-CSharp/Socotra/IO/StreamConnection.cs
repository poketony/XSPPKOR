using System;

namespace Socotra.IO
{
	// Token: 0x02000131 RID: 305
	public interface StreamConnection : Connection
	{
		// Token: 0x0600168B RID: 5771
		OutputStream OpenOutputStream();

		// Token: 0x0600168C RID: 5772
		DataOutputStream OpenDataOutputStream();

		// Token: 0x0600168D RID: 5773
		InputStream OpenInputStream();

		// Token: 0x0600168E RID: 5774
		DataInputStream OpenDataInputStream();
	}
}
