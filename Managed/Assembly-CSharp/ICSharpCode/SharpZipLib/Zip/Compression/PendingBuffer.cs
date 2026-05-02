using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	// Token: 0x0200016B RID: 363
	public class PendingBuffer
	{
		// Token: 0x060018F1 RID: 6385 RVA: 0x00138A15 File Offset: 0x00136C15
		public PendingBuffer()
			: this(4096)
		{
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x00138A22 File Offset: 0x00136C22
		public PendingBuffer(int bufferSize)
		{
			this.buffer = new byte[bufferSize];
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x00138A38 File Offset: 0x00136C38
		public void Reset()
		{
			this.start = (this.end = (this.bitCount = 0));
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x00138A60 File Offset: 0x00136C60
		public void WriteByte(int value)
		{
			byte[] array = this.buffer;
			int num = this.end;
			this.end = num + 1;
			array[num] = (byte)value;
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x00138A88 File Offset: 0x00136C88
		public void WriteShort(int value)
		{
			byte[] array = this.buffer;
			int num = this.end;
			this.end = num + 1;
			array[num] = (byte)value;
			byte[] array2 = this.buffer;
			num = this.end;
			this.end = num + 1;
			array2[num] = (byte)(value >> 8);
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x00138ACC File Offset: 0x00136CCC
		public void WriteInt(int value)
		{
			byte[] array = this.buffer;
			int num = this.end;
			this.end = num + 1;
			array[num] = (byte)value;
			byte[] array2 = this.buffer;
			num = this.end;
			this.end = num + 1;
			array2[num] = (byte)(value >> 8);
			byte[] array3 = this.buffer;
			num = this.end;
			this.end = num + 1;
			array3[num] = (byte)(value >> 16);
			byte[] array4 = this.buffer;
			num = this.end;
			this.end = num + 1;
			array4[num] = (byte)(value >> 24);
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00138B49 File Offset: 0x00136D49
		public void WriteBlock(byte[] block, int offset, int length)
		{
			Array.Copy(block, offset, this.buffer, this.end, length);
			this.end += length;
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060018F8 RID: 6392 RVA: 0x00138B6D File Offset: 0x00136D6D
		public int BitCount
		{
			get
			{
				return this.bitCount;
			}
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x00138B78 File Offset: 0x00136D78
		public void AlignToByte()
		{
			if (this.bitCount > 0)
			{
				byte[] array = this.buffer;
				int num = this.end;
				this.end = num + 1;
				array[num] = (byte)this.bits;
				if (this.bitCount > 8)
				{
					byte[] array2 = this.buffer;
					num = this.end;
					this.end = num + 1;
					array2[num] = (byte)(this.bits >> 8);
				}
			}
			this.bits = 0U;
			this.bitCount = 0;
		}

		// Token: 0x060018FA RID: 6394 RVA: 0x00138BE8 File Offset: 0x00136DE8
		public void WriteBits(int b, int count)
		{
			this.bits |= (uint)((uint)b << this.bitCount);
			this.bitCount += count;
			if (this.bitCount >= 16)
			{
				byte[] array = this.buffer;
				int num = this.end;
				this.end = num + 1;
				array[num] = (byte)this.bits;
				byte[] array2 = this.buffer;
				num = this.end;
				this.end = num + 1;
				array2[num] = (byte)(this.bits >> 8);
				this.bits >>= 16;
				this.bitCount -= 16;
			}
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x00138C84 File Offset: 0x00136E84
		public void WriteShortMSB(int s)
		{
			byte[] array = this.buffer;
			int num = this.end;
			this.end = num + 1;
			array[num] = (byte)(s >> 8);
			byte[] array2 = this.buffer;
			num = this.end;
			this.end = num + 1;
			array2[num] = (byte)s;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060018FC RID: 6396 RVA: 0x00138CC7 File Offset: 0x00136EC7
		public bool IsFlushed
		{
			get
			{
				return this.end == 0;
			}
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x00138CD4 File Offset: 0x00136ED4
		public int Flush(byte[] output, int offset, int length)
		{
			if (this.bitCount >= 8)
			{
				byte[] array = this.buffer;
				int num = this.end;
				this.end = num + 1;
				array[num] = (byte)this.bits;
				this.bits >>= 8;
				this.bitCount -= 8;
			}
			if (length > this.end - this.start)
			{
				length = this.end - this.start;
				Array.Copy(this.buffer, this.start, output, offset, length);
				this.start = 0;
				this.end = 0;
			}
			else
			{
				Array.Copy(this.buffer, this.start, output, offset, length);
				this.start += length;
			}
			return length;
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x00138D8C File Offset: 0x00136F8C
		public byte[] ToByteArray()
		{
			this.AlignToByte();
			byte[] array = new byte[this.end - this.start];
			Array.Copy(this.buffer, this.start, array, 0, array.Length);
			this.start = 0;
			this.end = 0;
			return array;
		}

		// Token: 0x04000E88 RID: 3720
		private readonly byte[] buffer;

		// Token: 0x04000E89 RID: 3721
		private int start;

		// Token: 0x04000E8A RID: 3722
		private int end;

		// Token: 0x04000E8B RID: 3723
		private uint bits;

		// Token: 0x04000E8C RID: 3724
		private int bitCount;
	}
}
