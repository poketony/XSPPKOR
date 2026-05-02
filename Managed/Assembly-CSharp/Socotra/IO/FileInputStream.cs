using System;
using System.IO;

namespace Socotra.IO
{
	// Token: 0x02000126 RID: 294
	public class FileInputStream : DataInputStream
	{
		// Token: 0x06001634 RID: 5684 RVA: 0x0012D07F File Offset: 0x0012B27F
		public FileInputStream(InputStream input)
			: base(input)
		{
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x0012D088 File Offset: 0x0012B288
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x0012D090 File Offset: 0x0012B290
		public override int Read()
		{
			return base.Read();
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0012D098 File Offset: 0x0012B298
		public override int Read(sbyte[] data)
		{
			return base.Read(data);
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0012D0A1 File Offset: 0x0012B2A1
		public override int Read(sbyte[] data, int offset, int length)
		{
			return base.Read(data, offset, length);
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x0012D0AC File Offset: 0x0012B2AC
		public override sbyte ReadByte()
		{
			return base.ReadByte();
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x0012D0B4 File Offset: 0x0012B2B4
		public override long ReadLong()
		{
			return base.ReadLong();
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x0012D0BC File Offset: 0x0012B2BC
		public override short ReadShort()
		{
			return base.ReadShort();
		}

		// Token: 0x04000CA1 RID: 3233
		private FileStream fileStream;
	}
}
