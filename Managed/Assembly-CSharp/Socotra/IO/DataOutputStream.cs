using System;
using System.Text;

namespace Socotra.IO
{
	// Token: 0x02000122 RID: 290
	public class DataOutputStream : OutputStream
	{
		// Token: 0x0600160A RID: 5642 RVA: 0x0012CC00 File Offset: 0x0012AE00
		public DataOutputStream(OutputStream o)
		{
			this.output = o;
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x0012CC0F File Offset: 0x0012AE0F
		public override void Close()
		{
			this.Flush();
			this.output.Close();
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x0012CC22 File Offset: 0x0012AE22
		public override void Flush()
		{
			this.output.Flush();
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x0012CC2F File Offset: 0x0012AE2F
		public override void Write(int i)
		{
			this.output.Write(i);
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x0012CC3D File Offset: 0x0012AE3D
		public override void Write(sbyte[] b)
		{
			this.output.Write(b);
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x0012CC4B File Offset: 0x0012AE4B
		public override void Write(sbyte[] b, int off, int len)
		{
			this.output.Write(b, off, len);
		}

		// Token: 0x06001610 RID: 5648 RVA: 0x0012CC5C File Offset: 0x0012AE5C
		public override void WriteShort(short data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			this.WriteBitConverterData(bytes);
		}

		// Token: 0x06001611 RID: 5649 RVA: 0x0012CC78 File Offset: 0x0012AE78
		public virtual void WriteInt(int data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			this.WriteBitConverterData(bytes);
		}

		// Token: 0x06001612 RID: 5650 RVA: 0x0012CC94 File Offset: 0x0012AE94
		public virtual void WriteLong(long data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			this.WriteBitConverterData(bytes);
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x0012CCB0 File Offset: 0x0012AEB0
		public virtual void WriteFloat(float data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			this.WriteBitConverterData(bytes);
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x0012CCCC File Offset: 0x0012AECC
		public virtual void WriteDouble(double data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			this.WriteBitConverterData(bytes);
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x0012CCE7 File Offset: 0x0012AEE7
		public override void WriteByte(sbyte b)
		{
			this.output.WriteByte(b);
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x0012CCF5 File Offset: 0x0012AEF5
		public void WriteByte(int i)
		{
			this.Write(i & 255);
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x0012CD04 File Offset: 0x0012AF04
		public void WriteBoolean(bool b)
		{
			this.output.WriteByte((!b) ? 0 : 1);
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x0012CD18 File Offset: 0x0012AF18
		public void WriteUTF(string utf)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(utf);
			sbyte[] array = new sbyte[bytes.Length + 2];
			byte[] bytes2 = BitConverter.GetBytes((short)bytes.Length);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse<byte>(bytes2);
			}
			for (int i = 0; i < bytes2.Length; i++)
			{
				array[i] = (sbyte)bytes2[i];
			}
			for (int j = 0; j < bytes.Length; j++)
			{
				array[j + 2] = (sbyte)bytes[j];
			}
			this.output.Write(array, 0, array.Length);
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x0012CD98 File Offset: 0x0012AF98
		public virtual void WriteChars(string s)
		{
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				uint num = (uint)s[i];
				this.output.WriteByte((sbyte)((num >> 8) & 255U));
				this.output.WriteByte((sbyte)(num & 255U));
			}
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x0012CDE8 File Offset: 0x0012AFE8
		public virtual void WriteChar(uint i)
		{
			this.output.Write((int)((i >> 8) & 255U));
			this.output.Write((int)(i & 255U));
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x0012CE10 File Offset: 0x0012B010
		private void WriteBitConverterData(byte[] byteData)
		{
			sbyte[] array = new sbyte[byteData.Length];
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse<byte>(byteData);
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (sbyte)byteData[i];
			}
			this.output.Write(array, 0, byteData.Length);
		}

		// Token: 0x04000C9A RID: 3226
		private OutputStream output;
	}
}
