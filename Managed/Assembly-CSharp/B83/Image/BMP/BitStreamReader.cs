using System;
using System.IO;

namespace B83.Image.BMP
{
	// Token: 0x0200006C RID: 108
	public class BitStreamReader
	{
		// Token: 0x06000E7C RID: 3708 RVA: 0x001120D9 File Offset: 0x001102D9
		public BitStreamReader(BinaryReader aReader)
		{
			this.m_Reader = aReader;
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x001120E8 File Offset: 0x001102E8
		public BitStreamReader(Stream aStream)
			: this(new BinaryReader(aStream))
		{
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x001120F8 File Offset: 0x001102F8
		public byte ReadBit()
		{
			if (this.m_Bits <= 0)
			{
				this.m_Data = this.m_Reader.ReadByte();
				this.m_Bits = 8;
			}
			byte data = this.m_Data;
			int num = this.m_Bits - 1;
			this.m_Bits = num;
			return (byte)((data >> (num & 31)) & 1);
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x00112144 File Offset: 0x00110344
		public ulong ReadBits(int aCount)
		{
			ulong num = 0UL;
			if (aCount <= 0 || aCount > 32)
			{
				throw new ArgumentOutOfRangeException("aCount", "aCount must be between 1 and 32 inclusive");
			}
			for (int i = aCount - 1; i >= 0; i--)
			{
				num |= (ulong)this.ReadBit() << i;
			}
			return num;
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x0011218B File Offset: 0x0011038B
		public void Flush()
		{
			this.m_Data = 0;
			this.m_Bits = 0;
		}

		// Token: 0x040008C2 RID: 2242
		private BinaryReader m_Reader;

		// Token: 0x040008C3 RID: 2243
		private byte m_Data;

		// Token: 0x040008C4 RID: 2244
		private int m_Bits;
	}
}
