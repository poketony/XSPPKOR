using System;
using System.Collections.Generic;

namespace Socotra.IO
{
	// Token: 0x0200011D RID: 285
	public class ByteArrayOutputStream : OutputStream
	{
		// Token: 0x060015D7 RID: 5591 RVA: 0x0012C63E File Offset: 0x0012A83E
		public ByteArrayOutputStream()
		{
			this.buf = new List<sbyte>();
			this.count = this.buf.Count;
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x0012C662 File Offset: 0x0012A862
		public ByteArrayOutputStream(int size)
		{
			this.buf = new List<sbyte>();
			this.buf.Capacity = size;
			this.count = this.buf.Count;
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x0012C694 File Offset: 0x0012A894
		public override void Write(sbyte[] b, int off, int len)
		{
			for (int i = 0; i < len; i++)
			{
				this.buf.Add(b[i + off]);
			}
		}

		// Token: 0x060015DA RID: 5594 RVA: 0x0012C6C0 File Offset: 0x0012A8C0
		public void Write(byte[] b, int off, int len)
		{
			for (int i = 0; i < len; i++)
			{
				this.buf.Add((sbyte)b[i + off]);
			}
		}

		// Token: 0x060015DB RID: 5595 RVA: 0x0012C6EA File Offset: 0x0012A8EA
		public override void WriteByte(sbyte b)
		{
			this.buf.Add(b);
		}

		// Token: 0x060015DC RID: 5596 RVA: 0x0012C6F8 File Offset: 0x0012A8F8
		public override void Write(int i)
		{
			this.buf.Add((sbyte)i);
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x0012C707 File Offset: 0x0012A907
		public byte[] ToByteArray()
		{
			return base.GetByteArray(this.buf.ToArray());
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x0012C71A File Offset: 0x0012A91A
		public sbyte[] ToSByteArray()
		{
			return this.buf.ToArray();
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0012C727 File Offset: 0x0012A927
		public static sbyte[] ToSByteArray(ByteArrayOutputStream baos)
		{
			return baos.ToSByteArray();
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x0012C72F File Offset: 0x0012A92F
		public virtual void WriteTo(OutputStream @out)
		{
			@out.Write(this.buf.ToArray(), 0, this.buf.Count);
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x0012C74E File Offset: 0x0012A94E
		public int Size()
		{
			return this.buf.Count;
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x0012C75B File Offset: 0x0012A95B
		public void Reset()
		{
			this.buf = new List<sbyte>();
			this.count = this.buf.Count;
		}

		// Token: 0x04000C91 RID: 3217
		private int pointer;

		// Token: 0x04000C92 RID: 3218
		protected List<sbyte> buf;

		// Token: 0x04000C93 RID: 3219
		protected int count;
	}
}
