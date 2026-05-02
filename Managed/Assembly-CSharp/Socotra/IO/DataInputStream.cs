using System;
using System.IO;
using System.Text;

namespace Socotra.IO
{
	// Token: 0x02000121 RID: 289
	public class DataInputStream : InputStream
	{
		// Token: 0x060015F4 RID: 5620 RVA: 0x0012C9CC File Offset: 0x0012ABCC
		public DataInputStream(InputStream input)
		{
			this.baseStream = input;
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x0012C9DB File Offset: 0x0012ABDB
		public virtual short ReadShort()
		{
			return BitConverter.ToInt16(this.ReadToBitConverterData(2), 0);
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0012C9EA File Offset: 0x0012ABEA
		public virtual ushort ReadUnsignedShort()
		{
			return (ushort)this.ReadShort();
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0012C9F3 File Offset: 0x0012ABF3
		public virtual int ReadInt()
		{
			return BitConverter.ToInt32(this.ReadToBitConverterData(4), 0);
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x0012CA02 File Offset: 0x0012AC02
		public virtual long ReadLong()
		{
			return BitConverter.ToInt64(this.ReadToBitConverterData(8), 0);
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x0012CA11 File Offset: 0x0012AC11
		public virtual float ReadFloat()
		{
			return BitConverter.ToSingle(this.ReadToBitConverterData(4), 0);
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x0012CA20 File Offset: 0x0012AC20
		public virtual double ReadDouble()
		{
			return BitConverter.ToDouble(this.ReadToBitConverterData(8), 0);
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0012CA30 File Offset: 0x0012AC30
		public virtual string ReadUTF()
		{
			short num = this.ReadShort();
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				array[i] = (byte)this.ReadByte();
			}
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x0012CA6C File Offset: 0x0012AC6C
		public virtual char ReadChar()
		{
			byte b = (byte)this.baseStream.ReadByte();
			byte b2 = (byte)this.baseStream.ReadByte();
			return (char)((b << 8) + b2);
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x0012CA97 File Offset: 0x0012AC97
		public override int Available()
		{
			return this.baseStream.Available();
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x0012CAA4 File Offset: 0x0012ACA4
		public override int Read()
		{
			return this.baseStream.Read();
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x0012CAB1 File Offset: 0x0012ACB1
		public virtual bool ReadBoolean()
		{
			return this.baseStream.ReadByte() != 0;
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x0012CAC3 File Offset: 0x0012ACC3
		public override sbyte ReadByte()
		{
			return this.baseStream.ReadByte();
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x0012CAD0 File Offset: 0x0012ACD0
		public virtual byte ReadUnsignedByte()
		{
			return (byte)this.ReadByte();
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x0012CAD9 File Offset: 0x0012ACD9
		public override int Read(sbyte[] data)
		{
			return this.baseStream.Read(data);
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x0012CAE7 File Offset: 0x0012ACE7
		public override int Read(sbyte[] data, int offset, int length)
		{
			return this.baseStream.Read(data, offset, length);
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x0012CAF7 File Offset: 0x0012ACF7
		public virtual void ReadFully(ref sbyte[] b)
		{
			this.ReadFully(ref b, 0, b.Length);
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x0012CB08 File Offset: 0x0012AD08
		public virtual void ReadFully(ref sbyte[] buf, int offset, int len)
		{
			if (len < 0)
			{
				throw new IndexOutOfRangeException("Negative length: " + len.ToString());
			}
			while (len > 0)
			{
				int num = base.Read(ref buf, offset, len);
				if (num < 0)
				{
					throw new EndOfStreamException();
				}
				len -= num;
				offset += num;
			}
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x0012CB52 File Offset: 0x0012AD52
		public override long Skip(long length)
		{
			return this.baseStream.Skip(length);
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x0012CB60 File Offset: 0x0012AD60
		public virtual int SkipBytes(int n)
		{
			long num = this.Skip((long)n);
			if (num > 2147483647L || num < -2147483648L)
			{
				new Exception(string.Format("Illegal return value. param:{0}, result:{1}", n, num));
			}
			return (int)num;
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x0012CBA6 File Offset: 0x0012ADA6
		public override void Close()
		{
			this.baseStream.Close();
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x0012CBB4 File Offset: 0x0012ADB4
		private byte[] ReadToBitConverterData(int length)
		{
			sbyte[] array = new sbyte[length];
			this.baseStream.Read(ref array);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse<sbyte>(array);
			}
			byte[] array2 = new byte[length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = (byte)array[i];
			}
			return array2;
		}

		// Token: 0x04000C99 RID: 3225
		private InputStream baseStream;
	}
}
