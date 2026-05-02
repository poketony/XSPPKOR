using System;
using System.Linq;

namespace Socotra.IO
{
	// Token: 0x0200012D RID: 301
	public class OutputStream
	{
		// Token: 0x0600166C RID: 5740 RVA: 0x0012D508 File Offset: 0x0012B708
		public virtual void Write(int i)
		{
			throw new Exception();
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x0012D50F File Offset: 0x0012B70F
		public virtual void WriteByte(sbyte b)
		{
			throw new Exception();
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x0012D518 File Offset: 0x0012B718
		public virtual void WriteShort(short s)
		{
			sbyte b = (sbyte)(s & 255);
			sbyte b2 = (sbyte)(s >> 8);
			this.WriteByte(b2);
			this.WriteByte(b);
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x0012D541 File Offset: 0x0012B741
		public virtual void Write(sbyte[] b, int off, int len)
		{
			throw new Exception();
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x0012D548 File Offset: 0x0012B748
		public virtual void Write(sbyte[] b)
		{
			this.Write(b, 0, b.Length);
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x0012D555 File Offset: 0x0012B755
		public virtual void Flush()
		{
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x0012D557 File Offset: 0x0012B757
		public virtual void Close()
		{
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x0012D559 File Offset: 0x0012B759
		public virtual long Skip(long length)
		{
			return 0L;
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0012D55D File Offset: 0x0012B75D
		protected byte[] GetByteArray(sbyte[] original)
		{
			new byte[original.Length];
			return original.Select((sbyte x) => (byte)x).ToArray<byte>();
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x0012D592 File Offset: 0x0012B792
		protected sbyte[] GetSByteArray(byte[] original)
		{
			new sbyte[original.Length];
			return original.Select((byte x) => (sbyte)x).ToArray<sbyte>();
		}
	}
}
