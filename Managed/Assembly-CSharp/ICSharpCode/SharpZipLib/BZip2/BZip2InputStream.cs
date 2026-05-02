using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.BZip2
{
	// Token: 0x020001A4 RID: 420
	public class BZip2InputStream : Stream
	{
		// Token: 0x06001B20 RID: 6944 RVA: 0x0013F940 File Offset: 0x0013DB40
		public BZip2InputStream(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			for (int i = 0; i < 6; i++)
			{
				this.limit[i] = new int[258];
				this.baseArray[i] = new int[258];
				this.perm[i] = new int[258];
			}
			this.baseStream = stream;
			this.bsLive = 0;
			this.bsBuff = 0;
			this.Initialize();
			this.InitBlock();
			this.SetupBlock();
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06001B21 RID: 6945 RVA: 0x0013FA7A File Offset: 0x0013DC7A
		// (set) Token: 0x06001B22 RID: 6946 RVA: 0x0013FA82 File Offset: 0x0013DC82
		public bool IsStreamOwner { get; set; } = true;

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06001B23 RID: 6947 RVA: 0x0013FA8B File Offset: 0x0013DC8B
		public override bool CanRead
		{
			get
			{
				return this.baseStream.CanRead;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06001B24 RID: 6948 RVA: 0x0013FA98 File Offset: 0x0013DC98
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06001B25 RID: 6949 RVA: 0x0013FA9B File Offset: 0x0013DC9B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06001B26 RID: 6950 RVA: 0x0013FA9E File Offset: 0x0013DC9E
		public override long Length
		{
			get
			{
				return this.baseStream.Length;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06001B27 RID: 6951 RVA: 0x0013FAAB File Offset: 0x0013DCAB
		// (set) Token: 0x06001B28 RID: 6952 RVA: 0x0013FAB8 File Offset: 0x0013DCB8
		public override long Position
		{
			get
			{
				return this.baseStream.Position;
			}
			set
			{
				throw new NotSupportedException("BZip2InputStream position cannot be set");
			}
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x0013FAC4 File Offset: 0x0013DCC4
		public override void Flush()
		{
			this.baseStream.Flush();
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x0013FAD1 File Offset: 0x0013DCD1
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("BZip2InputStream Seek not supported");
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x0013FADD File Offset: 0x0013DCDD
		public override void SetLength(long value)
		{
			throw new NotSupportedException("BZip2InputStream SetLength not supported");
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x0013FAE9 File Offset: 0x0013DCE9
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("BZip2InputStream Write not supported");
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x0013FAF5 File Offset: 0x0013DCF5
		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("BZip2InputStream WriteByte not supported");
		}

		// Token: 0x06001B2E RID: 6958 RVA: 0x0013FB04 File Offset: 0x0013DD04
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			for (int i = 0; i < count; i++)
			{
				int num = this.ReadByte();
				if (num == -1)
				{
					return i;
				}
				buffer[offset + i] = (byte)num;
			}
			return count;
		}

		// Token: 0x06001B2F RID: 6959 RVA: 0x0013FB40 File Offset: 0x0013DD40
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.IsStreamOwner)
			{
				this.baseStream.Dispose();
			}
		}

		// Token: 0x06001B30 RID: 6960 RVA: 0x0013FB58 File Offset: 0x0013DD58
		public override int ReadByte()
		{
			if (this.streamEnd)
			{
				return -1;
			}
			int num = this.currentChar;
			switch (this.currentState)
			{
			case 3:
				this.SetupRandPartB();
				break;
			case 4:
				this.SetupRandPartC();
				break;
			case 6:
				this.SetupNoRandPartB();
				break;
			case 7:
				this.SetupNoRandPartC();
				break;
			}
			return num;
		}

		// Token: 0x06001B31 RID: 6961 RVA: 0x0013FBC4 File Offset: 0x0013DDC4
		private void MakeMaps()
		{
			this.nInUse = 0;
			for (int i = 0; i < 256; i++)
			{
				if (this.inUse[i])
				{
					this.seqToUnseq[this.nInUse] = (byte)i;
					this.unseqToSeq[i] = (byte)this.nInUse;
					this.nInUse++;
				}
			}
		}

		// Token: 0x06001B32 RID: 6962 RVA: 0x0013FC20 File Offset: 0x0013DE20
		private void Initialize()
		{
			int num = (int)this.BsGetUChar();
			char c = this.BsGetUChar();
			char c2 = this.BsGetUChar();
			char c3 = this.BsGetUChar();
			if (num != 66 || c != 'Z' || c2 != 'h' || c3 < '1' || c3 > '9')
			{
				this.streamEnd = true;
				return;
			}
			this.SetDecompressStructureSizes((int)(c3 - '0'));
			this.computedCombinedCRC = 0U;
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x0013FC7C File Offset: 0x0013DE7C
		private void InitBlock()
		{
			char c = this.BsGetUChar();
			char c2 = this.BsGetUChar();
			char c3 = this.BsGetUChar();
			char c4 = this.BsGetUChar();
			char c5 = this.BsGetUChar();
			char c6 = this.BsGetUChar();
			if (c == '\u0017' && c2 == 'r' && c3 == 'E' && c4 == '8' && c5 == 'P' && c6 == '\u0090')
			{
				this.Complete();
				return;
			}
			if (c != '1' || c2 != 'A' || c3 != 'Y' || c4 != '&' || c5 != 'S' || c6 != 'Y')
			{
				BZip2InputStream.BadBlockHeader();
				this.streamEnd = true;
				return;
			}
			this.storedBlockCRC = this.BsGetInt32();
			this.blockRandomised = this.BsR(1) == 1;
			this.GetAndMoveToFrontDecode();
			this.mCrc.Reset();
			this.currentState = 1;
		}

		// Token: 0x06001B34 RID: 6964 RVA: 0x0013FD40 File Offset: 0x0013DF40
		private void EndBlock()
		{
			this.computedBlockCRC = (int)this.mCrc.Value;
			if (this.storedBlockCRC != this.computedBlockCRC)
			{
				BZip2InputStream.CrcError();
			}
			this.computedCombinedCRC = ((this.computedCombinedCRC << 1) & uint.MaxValue) | (this.computedCombinedCRC >> 31);
			this.computedCombinedCRC ^= (uint)this.computedBlockCRC;
		}

		// Token: 0x06001B35 RID: 6965 RVA: 0x0013FD9F File Offset: 0x0013DF9F
		private void Complete()
		{
			this.storedCombinedCRC = this.BsGetInt32();
			if (this.storedCombinedCRC != (int)this.computedCombinedCRC)
			{
				BZip2InputStream.CrcError();
			}
			this.streamEnd = true;
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x0013FDC8 File Offset: 0x0013DFC8
		private void FillBuffer()
		{
			int num = 0;
			try
			{
				num = this.baseStream.ReadByte();
			}
			catch (Exception)
			{
				BZip2InputStream.CompressedStreamEOF();
			}
			if (num == -1)
			{
				BZip2InputStream.CompressedStreamEOF();
			}
			this.bsBuff = (this.bsBuff << 8) | (num & 255);
			this.bsLive += 8;
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x0013FE2C File Offset: 0x0013E02C
		private int BsR(int n)
		{
			while (this.bsLive < n)
			{
				this.FillBuffer();
			}
			int num = (this.bsBuff >> this.bsLive - n) & ((1 << n) - 1);
			this.bsLive -= n;
			return num;
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x0013FE68 File Offset: 0x0013E068
		private char BsGetUChar()
		{
			return (char)this.BsR(8);
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x0013FE72 File Offset: 0x0013E072
		private int BsGetIntVS(int numBits)
		{
			return this.BsR(numBits);
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x0013FE7B File Offset: 0x0013E07B
		private int BsGetInt32()
		{
			return (((((this.BsR(8) << 8) | this.BsR(8)) << 8) | this.BsR(8)) << 8) | this.BsR(8);
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x0013FEA4 File Offset: 0x0013E0A4
		private void RecvDecodingTables()
		{
			char[][] array = new char[6][];
			for (int i = 0; i < 6; i++)
			{
				array[i] = new char[258];
			}
			bool[] array2 = new bool[16];
			for (int j = 0; j < 16; j++)
			{
				array2[j] = this.BsR(1) == 1;
			}
			for (int k = 0; k < 16; k++)
			{
				if (array2[k])
				{
					for (int l = 0; l < 16; l++)
					{
						this.inUse[k * 16 + l] = this.BsR(1) == 1;
					}
				}
				else
				{
					for (int m = 0; m < 16; m++)
					{
						this.inUse[k * 16 + m] = false;
					}
				}
			}
			this.MakeMaps();
			int num = this.nInUse + 2;
			int num2 = this.BsR(3);
			int num3 = this.BsR(15);
			for (int n = 0; n < num3; n++)
			{
				int num4 = 0;
				while (this.BsR(1) == 1)
				{
					num4++;
				}
				this.selectorMtf[n] = (byte)num4;
			}
			byte[] array3 = new byte[6];
			for (int num5 = 0; num5 < num2; num5++)
			{
				array3[num5] = (byte)num5;
			}
			for (int num6 = 0; num6 < num3; num6++)
			{
				int num7 = (int)this.selectorMtf[num6];
				byte b = array3[num7];
				while (num7 > 0)
				{
					array3[num7] = array3[num7 - 1];
					num7--;
				}
				array3[0] = b;
				this.selector[num6] = b;
			}
			for (int num8 = 0; num8 < num2; num8++)
			{
				int num9 = this.BsR(5);
				for (int num10 = 0; num10 < num; num10++)
				{
					while (this.BsR(1) == 1)
					{
						if (this.BsR(1) == 0)
						{
							num9++;
						}
						else
						{
							num9--;
						}
					}
					array[num8][num10] = (char)num9;
				}
			}
			for (int num11 = 0; num11 < num2; num11++)
			{
				int num12 = 32;
				int num13 = 0;
				for (int num14 = 0; num14 < num; num14++)
				{
					num13 = Math.Max(num13, (int)array[num11][num14]);
					num12 = Math.Min(num12, (int)array[num11][num14]);
				}
				BZip2InputStream.HbCreateDecodeTables(this.limit[num11], this.baseArray[num11], this.perm[num11], array[num11], num12, num13, num);
				this.minLens[num11] = num12;
			}
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x001400F0 File Offset: 0x0013E2F0
		private void GetAndMoveToFrontDecode()
		{
			byte[] array = new byte[256];
			int num = 100000 * this.blockSize100k;
			this.origPtr = this.BsGetIntVS(24);
			this.RecvDecodingTables();
			int num2 = this.nInUse + 1;
			int num3 = -1;
			int num4 = 0;
			for (int i = 0; i <= 255; i++)
			{
				this.unzftab[i] = 0;
			}
			for (int j = 0; j <= 255; j++)
			{
				array[j] = (byte)j;
			}
			this.last = -1;
			if (num4 == 0)
			{
				num3++;
				num4 = 50;
			}
			num4--;
			int num5 = (int)this.selector[num3];
			int num6 = this.minLens[num5];
			int k;
			int num7;
			for (k = this.BsR(num6); k > this.limit[num5][num6]; k = (k << 1) | num7)
			{
				if (num6 > 20)
				{
					throw new BZip2Exception("Bzip data error");
				}
				num6++;
				while (this.bsLive < 1)
				{
					this.FillBuffer();
				}
				num7 = (this.bsBuff >> this.bsLive - 1) & 1;
				this.bsLive--;
			}
			if (k - this.baseArray[num5][num6] < 0 || k - this.baseArray[num5][num6] >= 258)
			{
				throw new BZip2Exception("Bzip data error");
			}
			int num8 = this.perm[num5][k - this.baseArray[num5][num6]];
			while (num8 != num2)
			{
				if (num8 == 0 || num8 == 1)
				{
					int l = -1;
					int num9 = 1;
					do
					{
						if (num8 == 0)
						{
							l += num9;
						}
						else if (num8 == 1)
						{
							l += 2 * num9;
						}
						num9 <<= 1;
						if (num4 == 0)
						{
							num3++;
							num4 = 50;
						}
						num4--;
						num5 = (int)this.selector[num3];
						num6 = this.minLens[num5];
						for (k = this.BsR(num6); k > this.limit[num5][num6]; k = (k << 1) | num7)
						{
							num6++;
							while (this.bsLive < 1)
							{
								this.FillBuffer();
							}
							num7 = (this.bsBuff >> this.bsLive - 1) & 1;
							this.bsLive--;
						}
						num8 = this.perm[num5][k - this.baseArray[num5][num6]];
					}
					while (num8 == 0 || num8 == 1);
					l++;
					byte b = this.seqToUnseq[(int)array[0]];
					this.unzftab[(int)b] += l;
					while (l > 0)
					{
						this.last++;
						this.ll8[this.last] = b;
						l--;
					}
					if (this.last >= num)
					{
						BZip2InputStream.BlockOverrun();
					}
				}
				else
				{
					this.last++;
					if (this.last >= num)
					{
						BZip2InputStream.BlockOverrun();
					}
					byte b2 = array[num8 - 1];
					this.unzftab[(int)this.seqToUnseq[(int)b2]]++;
					this.ll8[this.last] = this.seqToUnseq[(int)b2];
					for (int m = num8 - 1; m > 0; m--)
					{
						array[m] = array[m - 1];
					}
					array[0] = b2;
					if (num4 == 0)
					{
						num3++;
						num4 = 50;
					}
					num4--;
					num5 = (int)this.selector[num3];
					num6 = this.minLens[num5];
					for (k = this.BsR(num6); k > this.limit[num5][num6]; k = (k << 1) | num7)
					{
						num6++;
						while (this.bsLive < 1)
						{
							this.FillBuffer();
						}
						num7 = (this.bsBuff >> this.bsLive - 1) & 1;
						this.bsLive--;
					}
					num8 = this.perm[num5][k - this.baseArray[num5][num6]];
				}
			}
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x001404C8 File Offset: 0x0013E6C8
		private void SetupBlock()
		{
			int[] array = new int[257];
			array[0] = 0;
			Array.Copy(this.unzftab, 0, array, 1, 256);
			for (int i = 1; i <= 256; i++)
			{
				array[i] += array[i - 1];
			}
			for (int j = 0; j <= this.last; j++)
			{
				byte b = this.ll8[j];
				this.tt[array[(int)b]] = j;
				array[(int)b]++;
			}
			this.tPos = this.tt[this.origPtr];
			this.count = 0;
			this.i2 = 0;
			this.ch2 = 256;
			if (this.blockRandomised)
			{
				this.rNToGo = 0;
				this.rTPos = 0;
				this.SetupRandPartA();
				return;
			}
			this.SetupNoRandPartA();
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x0014059C File Offset: 0x0013E79C
		private void SetupRandPartA()
		{
			if (this.i2 <= this.last)
			{
				this.chPrev = this.ch2;
				this.ch2 = (int)this.ll8[this.tPos];
				this.tPos = this.tt[this.tPos];
				if (this.rNToGo == 0)
				{
					this.rNToGo = BZip2Constants.RandomNumbers[this.rTPos];
					this.rTPos++;
					if (this.rTPos == 512)
					{
						this.rTPos = 0;
					}
				}
				this.rNToGo--;
				this.ch2 ^= ((this.rNToGo == 1) ? 1 : 0);
				this.i2++;
				this.currentChar = this.ch2;
				this.currentState = 3;
				this.mCrc.Update(this.ch2);
				return;
			}
			this.EndBlock();
			this.InitBlock();
			this.SetupBlock();
		}

		// Token: 0x06001B3F RID: 6975 RVA: 0x00140698 File Offset: 0x0013E898
		private void SetupNoRandPartA()
		{
			if (this.i2 <= this.last)
			{
				this.chPrev = this.ch2;
				this.ch2 = (int)this.ll8[this.tPos];
				this.tPos = this.tt[this.tPos];
				this.i2++;
				this.currentChar = this.ch2;
				this.currentState = 6;
				this.mCrc.Update(this.ch2);
				return;
			}
			this.EndBlock();
			this.InitBlock();
			this.SetupBlock();
		}

		// Token: 0x06001B40 RID: 6976 RVA: 0x0014072C File Offset: 0x0013E92C
		private void SetupRandPartB()
		{
			if (this.ch2 != this.chPrev)
			{
				this.currentState = 2;
				this.count = 1;
				this.SetupRandPartA();
				return;
			}
			this.count++;
			if (this.count >= 4)
			{
				this.z = this.ll8[this.tPos];
				this.tPos = this.tt[this.tPos];
				if (this.rNToGo == 0)
				{
					this.rNToGo = BZip2Constants.RandomNumbers[this.rTPos];
					this.rTPos++;
					if (this.rTPos == 512)
					{
						this.rTPos = 0;
					}
				}
				this.rNToGo--;
				this.z ^= ((this.rNToGo == 1) ? 1 : 0);
				this.j2 = 0;
				this.currentState = 4;
				this.SetupRandPartC();
				return;
			}
			this.currentState = 2;
			this.SetupRandPartA();
		}

		// Token: 0x06001B41 RID: 6977 RVA: 0x00140824 File Offset: 0x0013EA24
		private void SetupRandPartC()
		{
			if (this.j2 < (int)this.z)
			{
				this.currentChar = this.ch2;
				this.mCrc.Update(this.ch2);
				this.j2++;
				return;
			}
			this.currentState = 2;
			this.i2++;
			this.count = 0;
			this.SetupRandPartA();
		}

		// Token: 0x06001B42 RID: 6978 RVA: 0x00140890 File Offset: 0x0013EA90
		private void SetupNoRandPartB()
		{
			if (this.ch2 != this.chPrev)
			{
				this.currentState = 5;
				this.count = 1;
				this.SetupNoRandPartA();
				return;
			}
			this.count++;
			if (this.count >= 4)
			{
				this.z = this.ll8[this.tPos];
				this.tPos = this.tt[this.tPos];
				this.currentState = 7;
				this.j2 = 0;
				this.SetupNoRandPartC();
				return;
			}
			this.currentState = 5;
			this.SetupNoRandPartA();
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x00140920 File Offset: 0x0013EB20
		private void SetupNoRandPartC()
		{
			if (this.j2 < (int)this.z)
			{
				this.currentChar = this.ch2;
				this.mCrc.Update(this.ch2);
				this.j2++;
				return;
			}
			this.currentState = 5;
			this.i2++;
			this.count = 0;
			this.SetupNoRandPartA();
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x0014098C File Offset: 0x0013EB8C
		private void SetDecompressStructureSizes(int newSize100k)
		{
			if (0 > newSize100k || newSize100k > 9 || 0 > this.blockSize100k || this.blockSize100k > 9)
			{
				throw new BZip2Exception("Invalid block size");
			}
			this.blockSize100k = newSize100k;
			if (newSize100k == 0)
			{
				return;
			}
			int num = 100000 * newSize100k;
			this.ll8 = new byte[num];
			this.tt = new int[num];
		}

		// Token: 0x06001B45 RID: 6981 RVA: 0x001409EB File Offset: 0x0013EBEB
		private static void CompressedStreamEOF()
		{
			throw new EndOfStreamException("BZip2 input stream end of compressed stream");
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x001409F7 File Offset: 0x0013EBF7
		private static void BlockOverrun()
		{
			throw new BZip2Exception("BZip2 input stream block overrun");
		}

		// Token: 0x06001B47 RID: 6983 RVA: 0x00140A03 File Offset: 0x0013EC03
		private static void BadBlockHeader()
		{
			throw new BZip2Exception("BZip2 input stream bad block header");
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x00140A0F File Offset: 0x0013EC0F
		private static void CrcError()
		{
			throw new BZip2Exception("BZip2 input stream crc error");
		}

		// Token: 0x06001B49 RID: 6985 RVA: 0x00140A1C File Offset: 0x0013EC1C
		private static void HbCreateDecodeTables(int[] limit, int[] baseArray, int[] perm, char[] length, int minLen, int maxLen, int alphaSize)
		{
			int num = 0;
			for (int i = minLen; i <= maxLen; i++)
			{
				for (int j = 0; j < alphaSize; j++)
				{
					if ((int)length[j] == i)
					{
						perm[num] = j;
						num++;
					}
				}
			}
			for (int k = 0; k < 23; k++)
			{
				baseArray[k] = 0;
			}
			for (int l = 0; l < alphaSize; l++)
			{
				baseArray[(int)(length[l] + '\u0001')]++;
			}
			for (int m = 1; m < 23; m++)
			{
				baseArray[m] += baseArray[m - 1];
			}
			for (int n = 0; n < 23; n++)
			{
				limit[n] = 0;
			}
			int num2 = 0;
			for (int num3 = minLen; num3 <= maxLen; num3++)
			{
				num2 += baseArray[num3 + 1] - baseArray[num3];
				limit[num3] = num2 - 1;
				num2 <<= 1;
			}
			for (int num4 = minLen + 1; num4 <= maxLen; num4++)
			{
				baseArray[num4] = (limit[num4 - 1] + 1 << 1) - baseArray[num4];
			}
		}

		// Token: 0x04000F9B RID: 3995
		private const int START_BLOCK_STATE = 1;

		// Token: 0x04000F9C RID: 3996
		private const int RAND_PART_A_STATE = 2;

		// Token: 0x04000F9D RID: 3997
		private const int RAND_PART_B_STATE = 3;

		// Token: 0x04000F9E RID: 3998
		private const int RAND_PART_C_STATE = 4;

		// Token: 0x04000F9F RID: 3999
		private const int NO_RAND_PART_A_STATE = 5;

		// Token: 0x04000FA0 RID: 4000
		private const int NO_RAND_PART_B_STATE = 6;

		// Token: 0x04000FA1 RID: 4001
		private const int NO_RAND_PART_C_STATE = 7;

		// Token: 0x04000FA2 RID: 4002
		private int last;

		// Token: 0x04000FA3 RID: 4003
		private int origPtr;

		// Token: 0x04000FA4 RID: 4004
		private int blockSize100k;

		// Token: 0x04000FA5 RID: 4005
		private bool blockRandomised;

		// Token: 0x04000FA6 RID: 4006
		private int bsBuff;

		// Token: 0x04000FA7 RID: 4007
		private int bsLive;

		// Token: 0x04000FA8 RID: 4008
		private IChecksum mCrc = new BZip2Crc();

		// Token: 0x04000FA9 RID: 4009
		private bool[] inUse = new bool[256];

		// Token: 0x04000FAA RID: 4010
		private int nInUse;

		// Token: 0x04000FAB RID: 4011
		private byte[] seqToUnseq = new byte[256];

		// Token: 0x04000FAC RID: 4012
		private byte[] unseqToSeq = new byte[256];

		// Token: 0x04000FAD RID: 4013
		private byte[] selector = new byte[18002];

		// Token: 0x04000FAE RID: 4014
		private byte[] selectorMtf = new byte[18002];

		// Token: 0x04000FAF RID: 4015
		private int[] tt;

		// Token: 0x04000FB0 RID: 4016
		private byte[] ll8;

		// Token: 0x04000FB1 RID: 4017
		private int[] unzftab = new int[256];

		// Token: 0x04000FB2 RID: 4018
		private int[][] limit = new int[6][];

		// Token: 0x04000FB3 RID: 4019
		private int[][] baseArray = new int[6][];

		// Token: 0x04000FB4 RID: 4020
		private int[][] perm = new int[6][];

		// Token: 0x04000FB5 RID: 4021
		private int[] minLens = new int[6];

		// Token: 0x04000FB6 RID: 4022
		private readonly Stream baseStream;

		// Token: 0x04000FB7 RID: 4023
		private bool streamEnd;

		// Token: 0x04000FB8 RID: 4024
		private int currentChar = -1;

		// Token: 0x04000FB9 RID: 4025
		private int currentState = 1;

		// Token: 0x04000FBA RID: 4026
		private int storedBlockCRC;

		// Token: 0x04000FBB RID: 4027
		private int storedCombinedCRC;

		// Token: 0x04000FBC RID: 4028
		private int computedBlockCRC;

		// Token: 0x04000FBD RID: 4029
		private uint computedCombinedCRC;

		// Token: 0x04000FBE RID: 4030
		private int count;

		// Token: 0x04000FBF RID: 4031
		private int chPrev;

		// Token: 0x04000FC0 RID: 4032
		private int ch2;

		// Token: 0x04000FC1 RID: 4033
		private int tPos;

		// Token: 0x04000FC2 RID: 4034
		private int rNToGo;

		// Token: 0x04000FC3 RID: 4035
		private int rTPos;

		// Token: 0x04000FC4 RID: 4036
		private int i2;

		// Token: 0x04000FC5 RID: 4037
		private int j2;

		// Token: 0x04000FC6 RID: 4038
		private byte z;
	}
}
