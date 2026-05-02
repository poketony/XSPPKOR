using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Socotra.IO
{
	// Token: 0x02000129 RID: 297
	public class InputStream
	{
		// Token: 0x0600164A RID: 5706 RVA: 0x0012D2BA File Offset: 0x0012B4BA
		public static Span<byte> ToBytesSpan(Span<sbyte> sbytes)
		{
			return MemoryMarshal.Cast<sbyte, byte>(sbytes);
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x0012D2C2 File Offset: 0x0012B4C2
		public static Span<sbyte> ToSBytesSpan(Span<byte> bytes)
		{
			return MemoryMarshal.Cast<byte, sbyte>(bytes);
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x0012D2CA File Offset: 0x0012B4CA
		public virtual int Available()
		{
			return 0;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x0012D2CD File Offset: 0x0012B4CD
		public virtual int Read()
		{
			return 0;
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x0012D2D0 File Offset: 0x0012B4D0
		public virtual sbyte ReadByte()
		{
			return 0;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x0012D2D3 File Offset: 0x0012B4D3
		public int Read(ref sbyte[] data)
		{
			return this.Read(data, 0, data.Length);
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x0012D2E2 File Offset: 0x0012B4E2
		public int Read(ref sbyte[] data, int offset, int length)
		{
			return this.Read(data, offset, length);
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x0012D2EE File Offset: 0x0012B4EE
		public virtual int Read(sbyte[] data)
		{
			return this.Read(data, 0, data.Length);
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x0012D2FB File Offset: 0x0012B4FB
		public virtual int Read(sbyte[] data, int offset, int length)
		{
			return 0;
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x0012D2FE File Offset: 0x0012B4FE
		public virtual long Skip(long length)
		{
			return 0L;
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0012D302 File Offset: 0x0012B502
		public virtual void Close()
		{
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x0012D304 File Offset: 0x0012B504
		protected byte[] GetByteArray(sbyte[] original)
		{
			new byte[original.Length];
			return original.Select((sbyte x) => (byte)x).ToArray<byte>();
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x0012D339 File Offset: 0x0012B539
		protected sbyte[] GetSByteArray(byte[] original)
		{
			new sbyte[original.Length];
			return original.Select((byte x) => (sbyte)x).ToArray<sbyte>();
		}
	}
}
