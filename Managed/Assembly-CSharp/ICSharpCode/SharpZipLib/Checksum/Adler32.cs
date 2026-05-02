using System;

namespace ICSharpCode.SharpZipLib.Checksum
{
	// Token: 0x0200019D RID: 413
	public sealed class Adler32 : IChecksum
	{
		// Token: 0x06001AFD RID: 6909 RVA: 0x0013F536 File Offset: 0x0013D736
		public Adler32()
		{
			this.Reset();
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x0013F544 File Offset: 0x0013D744
		public void Reset()
		{
			this.checkValue = 1U;
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06001AFF RID: 6911 RVA: 0x0013F54D File Offset: 0x0013D74D
		public long Value
		{
			get
			{
				return (long)((ulong)this.checkValue);
			}
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x0013F558 File Offset: 0x0013D758
		public void Update(int bval)
		{
			uint num = this.checkValue & 65535U;
			uint num2 = this.checkValue >> 16;
			num = (num + (uint)(bval & 255)) % Adler32.BASE;
			num2 = (num + num2) % Adler32.BASE;
			this.checkValue = (num2 << 16) + num;
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x0013F5A2 File Offset: 0x0013D7A2
		public void Update(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			this.Update(new ArraySegment<byte>(buffer, 0, buffer.Length));
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x0013F5C4 File Offset: 0x0013D7C4
		public void Update(ArraySegment<byte> segment)
		{
			uint num = this.checkValue & 65535U;
			uint num2 = this.checkValue >> 16;
			int i = segment.Count;
			int offset = segment.Offset;
			while (i > 0)
			{
				int num3 = 3800;
				if (num3 > i)
				{
					num3 = i;
				}
				i -= num3;
				while (--num3 >= 0)
				{
					num += (uint)(segment.Array[offset++] & byte.MaxValue);
					num2 += num;
				}
				num %= Adler32.BASE;
				num2 %= Adler32.BASE;
			}
			this.checkValue = (num2 << 16) | num;
		}

		// Token: 0x04000F87 RID: 3975
		private static readonly uint BASE = 65521U;

		// Token: 0x04000F88 RID: 3976
		private uint checkValue;
	}
}
