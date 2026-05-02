using System;

namespace Socotra.IO
{
	// Token: 0x0200011E RID: 286
	public class ByteOutputStream : OutputStream
	{
		// Token: 0x060015E3 RID: 5603 RVA: 0x0012C779 File Offset: 0x0012A979
		public ByteOutputStream()
		{
			this.data = new sbyte[4096];
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x0012C791 File Offset: 0x0012A991
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0012C799 File Offset: 0x0012A999
		public override void Flush()
		{
			base.Flush();
		}

		// Token: 0x060015E6 RID: 5606 RVA: 0x0012C7A1 File Offset: 0x0012A9A1
		public override void Write(int i)
		{
			int num = this.index;
			int num2 = this.data.Length;
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x0012C7B3 File Offset: 0x0012A9B3
		public override void Write(sbyte[] b, int off, int len)
		{
			if (this.index + off >= this.data.Length)
			{
				return;
			}
			b.CopyTo(this.data, this.index + off);
			this.index = this.index + off + len;
		}

		// Token: 0x060015E8 RID: 5608 RVA: 0x0012C7EC File Offset: 0x0012A9EC
		public override void WriteByte(sbyte b)
		{
			if (this.index >= this.data.Length)
			{
				return;
			}
			sbyte[] array = this.data;
			int num = this.index;
			this.index = num + 1;
			array[num] = b;
		}

		// Token: 0x060015E9 RID: 5609 RVA: 0x0012C823 File Offset: 0x0012AA23
		public override void WriteShort(short s)
		{
			base.WriteShort(s);
		}

		// Token: 0x04000C94 RID: 3220
		private sbyte[] data;

		// Token: 0x04000C95 RID: 3221
		private int index;
	}
}
