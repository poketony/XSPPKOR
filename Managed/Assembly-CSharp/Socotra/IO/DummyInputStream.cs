using System;

namespace Socotra.IO
{
	// Token: 0x02000123 RID: 291
	public class DummyInputStream : InputStream
	{
		// Token: 0x0600161C RID: 5660 RVA: 0x0012CE58 File Offset: 0x0012B058
		public override int Available()
		{
			return this.dummy.Length - this.pointer;
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x0012CE69 File Offset: 0x0012B069
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x0012CE71 File Offset: 0x0012B071
		public override int Read()
		{
			int num = (int)this.dummy[this.pointer];
			this.pointer++;
			return num;
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x0012CE8E File Offset: 0x0012B08E
		public override int Read(sbyte[] data)
		{
			return base.Read(data);
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x0012CE97 File Offset: 0x0012B097
		public override int Read(sbyte[] data, int offset, int length)
		{
			return base.Read(data, offset, length);
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x0012CEA2 File Offset: 0x0012B0A2
		public override sbyte ReadByte()
		{
			return (sbyte)this.Read();
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x0012CEAB File Offset: 0x0012B0AB
		public override long Skip(long length)
		{
			if (length + (long)this.pointer > (long)this.dummy.Length)
			{
				throw new Exception("length error!");
			}
			return base.Skip(length);
		}

		// Token: 0x04000C9B RID: 3227
		private int pointer;

		// Token: 0x04000C9C RID: 3228
		private byte[] dummy = new byte[4096];
	}
}
