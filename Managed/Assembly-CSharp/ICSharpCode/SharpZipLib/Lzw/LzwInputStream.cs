using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Lzw
{
	// Token: 0x0200017D RID: 381
	public class LzwInputStream : Stream
	{
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06001A42 RID: 6722 RVA: 0x0013CD57 File Offset: 0x0013AF57
		// (set) Token: 0x06001A43 RID: 6723 RVA: 0x0013CD5F File Offset: 0x0013AF5F
		public bool IsStreamOwner { get; set; } = true;

		// Token: 0x06001A44 RID: 6724 RVA: 0x0013CD68 File Offset: 0x0013AF68
		public LzwInputStream(Stream baseInputStream)
		{
			this.baseInputStream = baseInputStream;
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x0013CDB5 File Offset: 0x0013AFB5
		public override int ReadByte()
		{
			if (this.Read(this.one, 0, 1) == 1)
			{
				return (int)(this.one[0] & byte.MaxValue);
			}
			return -1;
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x0013CDD8 File Offset: 0x0013AFD8
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (!this.headerParsed)
			{
				this.ParseHeader();
			}
			if (this.eof)
			{
				return 0;
			}
			int num = offset;
			int[] array = this.tabPrefix;
			byte[] array2 = this.tabSuffix;
			byte[] array3 = this.stack;
			int num2 = this.nBits;
			int num3 = this.maxCode;
			int num4 = this.maxMaxCode;
			int num5 = this.bitMask;
			int num6 = this.oldCode;
			byte b = this.finChar;
			int num7 = this.stackP;
			int num8 = this.freeEnt;
			byte[] array4 = this.data;
			int i = this.bitPos;
			int num9 = array3.Length - num7;
			if (num9 > 0)
			{
				int num10 = ((num9 >= count) ? count : num9);
				Array.Copy(array3, num7, buffer, offset, num10);
				offset += num10;
				count -= num10;
				num7 += num10;
			}
			if (count == 0)
			{
				this.stackP = num7;
				return offset - num;
			}
			int j;
			for (;;)
			{
				IL_00C6:
				if (this.end < 64)
				{
					this.Fill();
				}
				int num11 = ((this.got > 0) ? (this.end - this.end % num2 << 3) : ((this.end << 3) - (num2 - 1)));
				while (i < num11)
				{
					if (count == 0)
					{
						goto Block_8;
					}
					if (num8 > num3)
					{
						int num12 = num2 << 3;
						i = i - 1 + num12 - (i - 1 + num12) % num12;
						num2++;
						num3 = ((num2 == this.maxBits) ? num4 : ((1 << num2) - 1));
						num5 = (1 << num2) - 1;
						i = this.ResetBuf(i);
						goto IL_00C6;
					}
					int num13 = i >> 3;
					j = (((int)(array4[num13] & byte.MaxValue) | ((int)(array4[num13 + 1] & byte.MaxValue) << 8) | ((int)(array4[num13 + 2] & byte.MaxValue) << 16)) >> (i & 7)) & num5;
					i += num2;
					if (num6 == -1)
					{
						if (j >= 256)
						{
							goto Block_12;
						}
						b = (byte)(num6 = j);
						buffer[offset++] = b;
						count--;
					}
					else
					{
						if (j == 256 && this.blockMode)
						{
							Array.Copy(this.zeros, 0, array, 0, this.zeros.Length);
							num8 = 256;
							int num14 = num2 << 3;
							i = i - 1 + num14 - (i - 1 + num14) % num14;
							num2 = 9;
							num3 = (1 << num2) - 1;
							num5 = num3;
							i = this.ResetBuf(i);
							goto IL_00C6;
						}
						int num15 = j;
						num7 = array3.Length;
						if (j >= num8)
						{
							if (j > num8)
							{
								goto Block_16;
							}
							array3[--num7] = b;
							j = num6;
						}
						while (j >= 256)
						{
							array3[--num7] = array2[j];
							j = array[j];
						}
						b = array2[j];
						buffer[offset++] = b;
						count--;
						num9 = array3.Length - num7;
						int num16 = ((num9 >= count) ? count : num9);
						Array.Copy(array3, num7, buffer, offset, num16);
						offset += num16;
						count -= num16;
						num7 += num16;
						if (num8 < num4)
						{
							array[num8] = num6;
							array2[num8] = b;
							num8++;
						}
						num6 = num15;
						if (count == 0)
						{
							goto Block_20;
						}
					}
				}
				i = this.ResetBuf(i);
				if (this.got <= 0)
				{
					goto Block_22;
				}
			}
			Block_8:
			this.nBits = num2;
			this.maxCode = num3;
			this.maxMaxCode = num4;
			this.bitMask = num5;
			this.oldCode = num6;
			this.finChar = b;
			this.stackP = num7;
			this.freeEnt = num8;
			this.bitPos = i;
			return offset - num;
			Block_12:
			throw new LzwException("corrupt input: " + j.ToString() + " > 255");
			Block_16:
			throw new LzwException("corrupt input: code=" + j.ToString() + ", freeEnt=" + num8.ToString());
			Block_20:
			this.nBits = num2;
			this.maxCode = num3;
			this.bitMask = num5;
			this.oldCode = num6;
			this.finChar = b;
			this.stackP = num7;
			this.freeEnt = num8;
			this.bitPos = i;
			return offset - num;
			Block_22:
			this.nBits = num2;
			this.maxCode = num3;
			this.bitMask = num5;
			this.oldCode = num6;
			this.finChar = b;
			this.stackP = num7;
			this.freeEnt = num8;
			this.bitPos = i;
			this.eof = true;
			return offset - num;
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x0013D204 File Offset: 0x0013B404
		private int ResetBuf(int bitPosition)
		{
			int num = bitPosition >> 3;
			Array.Copy(this.data, num, this.data, 0, this.end - num);
			this.end -= num;
			return 0;
		}

		// Token: 0x06001A48 RID: 6728 RVA: 0x0013D240 File Offset: 0x0013B440
		private void Fill()
		{
			this.got = this.baseInputStream.Read(this.data, this.end, this.data.Length - 1 - this.end);
			if (this.got > 0)
			{
				this.end += this.got;
			}
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x0013D298 File Offset: 0x0013B498
		private void ParseHeader()
		{
			this.headerParsed = true;
			byte[] array = new byte[3];
			if (this.baseInputStream.Read(array, 0, array.Length) < 0)
			{
				throw new LzwException("Failed to read LZW header");
			}
			if (array[0] != 31 || array[1] != 157)
			{
				throw new LzwException(string.Format("Wrong LZW header. Magic bytes don't match. 0x{0:x2} 0x{1:x2}", array[0], array[1]));
			}
			this.blockMode = (array[2] & 128) > 0;
			this.maxBits = (int)(array[2] & 31);
			if (this.maxBits > 16)
			{
				throw new LzwException(string.Concat(new string[]
				{
					"Stream compressed with ",
					this.maxBits.ToString(),
					" bits, but decompression can only handle ",
					16.ToString(),
					" bits."
				}));
			}
			if ((array[2] & 96) > 0)
			{
				throw new LzwException("Unsupported bits set in the header.");
			}
			this.maxMaxCode = 1 << this.maxBits;
			this.nBits = 9;
			this.maxCode = (1 << this.nBits) - 1;
			this.bitMask = this.maxCode;
			this.oldCode = -1;
			this.finChar = 0;
			this.freeEnt = (this.blockMode ? 257 : 256);
			this.tabPrefix = new int[1 << this.maxBits];
			this.tabSuffix = new byte[1 << this.maxBits];
			this.stack = new byte[1 << this.maxBits];
			this.stackP = this.stack.Length;
			for (int i = 255; i >= 0; i--)
			{
				this.tabSuffix[i] = (byte)i;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06001A4A RID: 6730 RVA: 0x0013D44C File Offset: 0x0013B64C
		public override bool CanRead
		{
			get
			{
				return this.baseInputStream.CanRead;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06001A4B RID: 6731 RVA: 0x0013D459 File Offset: 0x0013B659
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06001A4C RID: 6732 RVA: 0x0013D45C File Offset: 0x0013B65C
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06001A4D RID: 6733 RVA: 0x0013D45F File Offset: 0x0013B65F
		public override long Length
		{
			get
			{
				return (long)this.got;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06001A4E RID: 6734 RVA: 0x0013D468 File Offset: 0x0013B668
		// (set) Token: 0x06001A4F RID: 6735 RVA: 0x0013D475 File Offset: 0x0013B675
		public override long Position
		{
			get
			{
				return this.baseInputStream.Position;
			}
			set
			{
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x0013D481 File Offset: 0x0013B681
		public override void Flush()
		{
			this.baseInputStream.Flush();
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x0013D48E File Offset: 0x0013B68E
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x0013D49A File Offset: 0x0013B69A
		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		// Token: 0x06001A53 RID: 6739 RVA: 0x0013D4A6 File Offset: 0x0013B6A6
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x0013D4B2 File Offset: 0x0013B6B2
		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x0013D4BE File Offset: 0x0013B6BE
		protected override void Dispose(bool disposing)
		{
			if (!this.isClosed)
			{
				this.isClosed = true;
				if (this.IsStreamOwner)
				{
					this.baseInputStream.Dispose();
				}
			}
		}

		// Token: 0x04000F2D RID: 3885
		private Stream baseInputStream;

		// Token: 0x04000F2E RID: 3886
		private bool isClosed;

		// Token: 0x04000F2F RID: 3887
		private readonly byte[] one = new byte[1];

		// Token: 0x04000F30 RID: 3888
		private bool headerParsed;

		// Token: 0x04000F31 RID: 3889
		private const int TBL_CLEAR = 256;

		// Token: 0x04000F32 RID: 3890
		private const int TBL_FIRST = 257;

		// Token: 0x04000F33 RID: 3891
		private int[] tabPrefix;

		// Token: 0x04000F34 RID: 3892
		private byte[] tabSuffix;

		// Token: 0x04000F35 RID: 3893
		private readonly int[] zeros = new int[256];

		// Token: 0x04000F36 RID: 3894
		private byte[] stack;

		// Token: 0x04000F37 RID: 3895
		private bool blockMode;

		// Token: 0x04000F38 RID: 3896
		private int nBits;

		// Token: 0x04000F39 RID: 3897
		private int maxBits;

		// Token: 0x04000F3A RID: 3898
		private int maxMaxCode;

		// Token: 0x04000F3B RID: 3899
		private int maxCode;

		// Token: 0x04000F3C RID: 3900
		private int bitMask;

		// Token: 0x04000F3D RID: 3901
		private int oldCode;

		// Token: 0x04000F3E RID: 3902
		private byte finChar;

		// Token: 0x04000F3F RID: 3903
		private int stackP;

		// Token: 0x04000F40 RID: 3904
		private int freeEnt;

		// Token: 0x04000F41 RID: 3905
		private readonly byte[] data = new byte[8192];

		// Token: 0x04000F42 RID: 3906
		private int bitPos;

		// Token: 0x04000F43 RID: 3907
		private int end;

		// Token: 0x04000F44 RID: 3908
		private int got;

		// Token: 0x04000F45 RID: 3909
		private bool eof;

		// Token: 0x04000F46 RID: 3910
		private const int EXTRA = 64;
	}
}
