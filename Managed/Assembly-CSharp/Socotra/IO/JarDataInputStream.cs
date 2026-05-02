using System;

namespace Socotra.IO
{
	// Token: 0x0200012B RID: 299
	public class JarDataInputStream : DataInputStream
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06001661 RID: 5729 RVA: 0x0012D494 File Offset: 0x0012B694
		public ScratchPadDataJar Jar
		{
			get
			{
				return this.baseJar;
			}
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x0012D49C File Offset: 0x0012B69C
		public JarDataInputStream(InputStream input)
			: base(input)
		{
			if (input is JarInputStream)
			{
				this.baseJar = (input as JarInputStream).Jar;
				return;
			}
			this.baseJar = null;
		}

		// Token: 0x04000CD0 RID: 3280
		private ScratchPadDataJar baseJar;
	}
}
