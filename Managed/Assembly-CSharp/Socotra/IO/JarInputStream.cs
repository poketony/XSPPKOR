using System;

namespace Socotra.IO
{
	// Token: 0x0200012C RID: 300
	public class JarInputStream : InputStream
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06001663 RID: 5731 RVA: 0x0012D4C6 File Offset: 0x0012B6C6
		public ScratchPadDataJar Jar
		{
			get
			{
				return this.baseJar;
			}
		}

		// Token: 0x06001664 RID: 5732 RVA: 0x0012D4CE File Offset: 0x0012B6CE
		public JarInputStream()
		{
			this.baseJar = null;
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x0012D4DD File Offset: 0x0012B6DD
		public JarInputStream(ScratchPadDataJar jar)
		{
			this.baseJar = jar;
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x0012D4EC File Offset: 0x0012B6EC
		public override int Available()
		{
			return base.Available();
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x0012D4F4 File Offset: 0x0012B6F4
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x0012D4FC File Offset: 0x0012B6FC
		public override int Read()
		{
			return 0;
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x0012D4FF File Offset: 0x0012B6FF
		public override int Read(sbyte[] data)
		{
			return 0;
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x0012D502 File Offset: 0x0012B702
		public override int Read(sbyte[] data, int offset, int length)
		{
			return 0;
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x0012D505 File Offset: 0x0012B705
		public override sbyte ReadByte()
		{
			return 0;
		}

		// Token: 0x04000CD1 RID: 3281
		private ScratchPadDataJar baseJar;
	}
}
