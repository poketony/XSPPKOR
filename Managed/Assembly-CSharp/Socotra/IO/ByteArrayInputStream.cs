using System;
using System.IO;

namespace Socotra.IO
{
	// Token: 0x0200011C RID: 284
	public class ByteArrayInputStream : InputStream
	{
		// Token: 0x060015CB RID: 5579 RVA: 0x0012C3D0 File Offset: 0x0012A5D0
		public ByteArrayInputStream(sbyte[] baseData)
		{
			this.data = new sbyte[baseData.Length];
			Array.Copy(baseData, 0, this.data, 0, baseData.Length);
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x0012C3F7 File Offset: 0x0012A5F7
		public ByteArrayInputStream(byte[] baseData)
		{
			this.data = base.GetSByteArray(baseData);
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x0012C40C File Offset: 0x0012A60C
		public ByteArrayInputStream(byte[] baseData, int offset, int length)
		{
			int num = Math.Min(baseData.Length - offset, length);
			this.data = new sbyte[num];
			for (int i = 0; i < num; i++)
			{
				this.data[i] = (sbyte)baseData[offset + i];
			}
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x0012C454 File Offset: 0x0012A654
		public ByteArrayInputStream(sbyte[] baseData, int offset, int length)
		{
			int num = Math.Min(baseData.Length - offset, length);
			this.data = new sbyte[num];
			Array.Copy(baseData, offset, this.data, 0, num);
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x0012C48E File Offset: 0x0012A68E
		public override int Available()
		{
			return this.data.Length;
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x0012C498 File Offset: 0x0012A698
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x0012C4A0 File Offset: 0x0012A6A0
		public override int Read()
		{
			if (this.IsEndStream())
			{
				return -1;
			}
			sbyte[] array = this.data;
			long num = this.index;
			this.index = num + 1L;
			return (int)array[(int)(checked((IntPtr)num))];
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x0012C4D4 File Offset: 0x0012A6D4
		public override int Read(sbyte[] dst)
		{
			if (this.IsEndStream())
			{
				return -1;
			}
			int num = dst.Length;
			if ((long)num + this.index > (long)this.data.Length)
			{
				num = this.data.Length - (int)this.index;
			}
			Array.ConstrainedCopy(this.data, (int)this.index, dst, 0, num);
			this.index += (long)dst.Length;
			return num;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x0012C53C File Offset: 0x0012A73C
		public override int Read(sbyte[] dst, int offset, int length)
		{
			if (offset < 0 || length < 0 || offset + length > dst.Length)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.IsEndStream())
			{
				return -1;
			}
			int num = length;
			if ((long)num + this.index > (long)this.data.Length)
			{
				num = this.data.Length - (int)this.index;
			}
			Array.ConstrainedCopy(this.data, (int)this.index, dst, offset, num);
			this.index += (long)num;
			return num;
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x0012C5B8 File Offset: 0x0012A7B8
		public override sbyte ReadByte()
		{
			if (this.IsEndStream())
			{
				throw new IOException("End of Stream");
			}
			sbyte[] array = this.data;
			long num = this.index;
			this.index = num + 1L;
			return array[(int)(checked((IntPtr)num))];
		}

		// Token: 0x060015D5 RID: 5589 RVA: 0x0012C5F2 File Offset: 0x0012A7F2
		public override long Skip(long length)
		{
			if ((long)this.data.Length <= this.index + length)
			{
				length = (long)this.data.Length - this.index;
			}
			this.index += length;
			return length;
		}

		// Token: 0x060015D6 RID: 5590 RVA: 0x0012C628 File Offset: 0x0012A828
		private bool IsEndStream()
		{
			return this.index >= (long)this.data.Length;
		}

		// Token: 0x04000C8F RID: 3215
		private sbyte[] data;

		// Token: 0x04000C90 RID: 3216
		private long index;
	}
}
