using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	// Token: 0x02000166 RID: 358
	public class DeflaterHuffman
	{
		// Token: 0x060018C3 RID: 6339 RVA: 0x001374C8 File Offset: 0x001356C8
		static DeflaterHuffman()
		{
			int i = 0;
			while (i < 144)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(48 + i << 8);
				DeflaterHuffman.staticLLength[i++] = 8;
			}
			while (i < 256)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(256 + i << 7);
				DeflaterHuffman.staticLLength[i++] = 9;
			}
			while (i < 280)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(-256 + i << 9);
				DeflaterHuffman.staticLLength[i++] = 7;
			}
			while (i < 286)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(-88 + i << 8);
				DeflaterHuffman.staticLLength[i++] = 8;
			}
			DeflaterHuffman.staticDCodes = new short[30];
			DeflaterHuffman.staticDLength = new byte[30];
			for (i = 0; i < 30; i++)
			{
				DeflaterHuffman.staticDCodes[i] = DeflaterHuffman.BitReverse(i << 11);
				DeflaterHuffman.staticDLength[i] = 5;
			}
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00137608 File Offset: 0x00135808
		public DeflaterHuffman(DeflaterPending pending)
		{
			this.pending = pending;
			this.literalTree = new DeflaterHuffman.Tree(this, 286, 257, 15);
			this.distTree = new DeflaterHuffman.Tree(this, 30, 1, 15);
			this.blTree = new DeflaterHuffman.Tree(this, 19, 4, 7);
			this.d_buf = new short[16384];
			this.l_buf = new byte[16384];
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0013767B File Offset: 0x0013587B
		public void Reset()
		{
			this.last_lit = 0;
			this.extra_bits = 0;
			this.literalTree.Reset();
			this.distTree.Reset();
			this.blTree.Reset();
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x001376AC File Offset: 0x001358AC
		public void SendAllTrees(int blTreeCodes)
		{
			this.blTree.BuildCodes();
			this.literalTree.BuildCodes();
			this.distTree.BuildCodes();
			this.pending.WriteBits(this.literalTree.numCodes - 257, 5);
			this.pending.WriteBits(this.distTree.numCodes - 1, 5);
			this.pending.WriteBits(blTreeCodes - 4, 4);
			for (int i = 0; i < blTreeCodes; i++)
			{
				this.pending.WriteBits((int)this.blTree.length[DeflaterHuffman.BL_ORDER[i]], 3);
			}
			this.literalTree.WriteTree(this.blTree);
			this.distTree.WriteTree(this.blTree);
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x0013776C File Offset: 0x0013596C
		public void CompressBlock()
		{
			for (int i = 0; i < this.last_lit; i++)
			{
				int num = (int)(this.l_buf[i] & byte.MaxValue);
				int num2 = (int)this.d_buf[i];
				if (num2-- != 0)
				{
					int num3 = DeflaterHuffman.Lcode(num);
					this.literalTree.WriteSymbol(num3);
					int num4 = (num3 - 261) / 4;
					if (num4 > 0 && num4 <= 5)
					{
						this.pending.WriteBits(num & ((1 << num4) - 1), num4);
					}
					int num5 = DeflaterHuffman.Dcode(num2);
					this.distTree.WriteSymbol(num5);
					num4 = num5 / 2 - 1;
					if (num4 > 0)
					{
						this.pending.WriteBits(num2 & ((1 << num4) - 1), num4);
					}
				}
				else
				{
					this.literalTree.WriteSymbol(num);
				}
			}
			this.literalTree.WriteSymbol(256);
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x00137848 File Offset: 0x00135A48
		public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
			this.pending.WriteBits(lastBlock ? 1 : 0, 3);
			this.pending.AlignToByte();
			this.pending.WriteShort(storedLength);
			this.pending.WriteShort(~storedLength);
			this.pending.WriteBlock(stored, storedOffset, storedLength);
			this.Reset();
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x001378A4 File Offset: 0x00135AA4
		public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
			short[] freqs = this.literalTree.freqs;
			int num = 256;
			freqs[num] += 1;
			this.literalTree.BuildTree();
			this.distTree.BuildTree();
			this.literalTree.CalcBLFreq(this.blTree);
			this.distTree.CalcBLFreq(this.blTree);
			this.blTree.BuildTree();
			int num2 = 4;
			for (int i = 18; i > num2; i--)
			{
				if (this.blTree.length[DeflaterHuffman.BL_ORDER[i]] > 0)
				{
					num2 = i + 1;
				}
			}
			int num3 = 14 + num2 * 3 + this.blTree.GetEncodedLength() + this.literalTree.GetEncodedLength() + this.distTree.GetEncodedLength() + this.extra_bits;
			int num4 = this.extra_bits;
			for (int j = 0; j < 286; j++)
			{
				num4 += (int)(this.literalTree.freqs[j] * (short)DeflaterHuffman.staticLLength[j]);
			}
			for (int k = 0; k < 30; k++)
			{
				num4 += (int)(this.distTree.freqs[k] * (short)DeflaterHuffman.staticDLength[k]);
			}
			if (num3 >= num4)
			{
				num3 = num4;
			}
			if (storedOffset >= 0 && storedLength + 4 < num3 >> 3)
			{
				this.FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
				return;
			}
			if (num3 == num4)
			{
				this.pending.WriteBits(2 + (lastBlock ? 1 : 0), 3);
				this.literalTree.SetStaticCodes(DeflaterHuffman.staticLCodes, DeflaterHuffman.staticLLength);
				this.distTree.SetStaticCodes(DeflaterHuffman.staticDCodes, DeflaterHuffman.staticDLength);
				this.CompressBlock();
				this.Reset();
				return;
			}
			this.pending.WriteBits(4 + (lastBlock ? 1 : 0), 3);
			this.SendAllTrees(num2);
			this.CompressBlock();
			this.Reset();
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x00137A62 File Offset: 0x00135C62
		public bool IsFull()
		{
			return this.last_lit >= 16384;
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x00137A74 File Offset: 0x00135C74
		public bool TallyLit(int literal)
		{
			this.d_buf[this.last_lit] = 0;
			byte[] array = this.l_buf;
			int num = this.last_lit;
			this.last_lit = num + 1;
			array[num] = (byte)literal;
			short[] freqs = this.literalTree.freqs;
			freqs[literal] += 1;
			return this.IsFull();
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x00137AC8 File Offset: 0x00135CC8
		public bool TallyDist(int distance, int length)
		{
			this.d_buf[this.last_lit] = (short)distance;
			byte[] array = this.l_buf;
			int num = this.last_lit;
			this.last_lit = num + 1;
			array[num] = (byte)(length - 3);
			int num2 = DeflaterHuffman.Lcode(length - 3);
			short[] freqs = this.literalTree.freqs;
			int num3 = num2;
			freqs[num3] += 1;
			if (num2 >= 265 && num2 < 285)
			{
				this.extra_bits += (num2 - 261) / 4;
			}
			int num4 = DeflaterHuffman.Dcode(distance - 1);
			short[] freqs2 = this.distTree.freqs;
			int num5 = num4;
			freqs2[num5] += 1;
			if (num4 >= 4)
			{
				this.extra_bits += num4 / 2 - 1;
			}
			return this.IsFull();
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x00137B82 File Offset: 0x00135D82
		public static short BitReverse(int toReverse)
		{
			return (short)(((int)DeflaterHuffman.bit4Reverse[toReverse & 15] << 12) | ((int)DeflaterHuffman.bit4Reverse[(toReverse >> 4) & 15] << 8) | ((int)DeflaterHuffman.bit4Reverse[(toReverse >> 8) & 15] << 4) | (int)DeflaterHuffman.bit4Reverse[toReverse >> 12]);
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x00137BBC File Offset: 0x00135DBC
		private static int Lcode(int length)
		{
			if (length == 255)
			{
				return 285;
			}
			int num = 257;
			while (length >= 8)
			{
				num += 4;
				length >>= 1;
			}
			return num + length;
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x00137BF0 File Offset: 0x00135DF0
		private static int Dcode(int distance)
		{
			int num = 0;
			while (distance >= 4)
			{
				num += 2;
				distance >>= 1;
			}
			return num + distance;
		}

		// Token: 0x04000E3F RID: 3647
		private const int BUFSIZE = 16384;

		// Token: 0x04000E40 RID: 3648
		private const int LITERAL_NUM = 286;

		// Token: 0x04000E41 RID: 3649
		private const int DIST_NUM = 30;

		// Token: 0x04000E42 RID: 3650
		private const int BITLEN_NUM = 19;

		// Token: 0x04000E43 RID: 3651
		private const int REP_3_6 = 16;

		// Token: 0x04000E44 RID: 3652
		private const int REP_3_10 = 17;

		// Token: 0x04000E45 RID: 3653
		private const int REP_11_138 = 18;

		// Token: 0x04000E46 RID: 3654
		private const int EOF_SYMBOL = 256;

		// Token: 0x04000E47 RID: 3655
		private static readonly int[] BL_ORDER = new int[]
		{
			16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
			11, 4, 12, 3, 13, 2, 14, 1, 15
		};

		// Token: 0x04000E48 RID: 3656
		private static readonly byte[] bit4Reverse = new byte[]
		{
			0, 8, 4, 12, 2, 10, 6, 14, 1, 9,
			5, 13, 3, 11, 7, 15
		};

		// Token: 0x04000E49 RID: 3657
		private static short[] staticLCodes = new short[286];

		// Token: 0x04000E4A RID: 3658
		private static byte[] staticLLength = new byte[286];

		// Token: 0x04000E4B RID: 3659
		private static short[] staticDCodes;

		// Token: 0x04000E4C RID: 3660
		private static byte[] staticDLength;

		// Token: 0x04000E4D RID: 3661
		public DeflaterPending pending;

		// Token: 0x04000E4E RID: 3662
		private DeflaterHuffman.Tree literalTree;

		// Token: 0x04000E4F RID: 3663
		private DeflaterHuffman.Tree distTree;

		// Token: 0x04000E50 RID: 3664
		private DeflaterHuffman.Tree blTree;

		// Token: 0x04000E51 RID: 3665
		private short[] d_buf;

		// Token: 0x04000E52 RID: 3666
		private byte[] l_buf;

		// Token: 0x04000E53 RID: 3667
		private int last_lit;

		// Token: 0x04000E54 RID: 3668
		private int extra_bits;

		// Token: 0x02000257 RID: 599
		private class Tree
		{
			// Token: 0x06001DF6 RID: 7670 RVA: 0x00147ED3 File Offset: 0x001460D3
			public Tree(DeflaterHuffman dh, int elems, int minCodes, int maxLength)
			{
				this.dh = dh;
				this.minNumCodes = minCodes;
				this.maxLength = maxLength;
				this.freqs = new short[elems];
				this.bl_counts = new int[maxLength];
			}

			// Token: 0x06001DF7 RID: 7671 RVA: 0x00147F0C File Offset: 0x0014610C
			public void Reset()
			{
				for (int i = 0; i < this.freqs.Length; i++)
				{
					this.freqs[i] = 0;
				}
				this.codes = null;
				this.length = null;
			}

			// Token: 0x06001DF8 RID: 7672 RVA: 0x00147F43 File Offset: 0x00146143
			public void WriteSymbol(int code)
			{
				this.dh.pending.WriteBits((int)this.codes[code] & 65535, (int)this.length[code]);
			}

			// Token: 0x06001DF9 RID: 7673 RVA: 0x00147F6C File Offset: 0x0014616C
			public void CheckEmpty()
			{
				bool flag = true;
				for (int i = 0; i < this.freqs.Length; i++)
				{
					flag &= this.freqs[i] == 0;
				}
				if (!flag)
				{
					throw new SharpZipBaseException("!Empty");
				}
			}

			// Token: 0x06001DFA RID: 7674 RVA: 0x00147FAA File Offset: 0x001461AA
			public void SetStaticCodes(short[] staticCodes, byte[] staticLengths)
			{
				this.codes = staticCodes;
				this.length = staticLengths;
			}

			// Token: 0x06001DFB RID: 7675 RVA: 0x00147FBC File Offset: 0x001461BC
			public void BuildCodes()
			{
				int num = this.freqs.Length;
				int[] array = new int[this.maxLength];
				int num2 = 0;
				this.codes = new short[this.freqs.Length];
				for (int i = 0; i < this.maxLength; i++)
				{
					array[i] = num2;
					num2 += this.bl_counts[i] << 15 - i;
				}
				for (int j = 0; j < this.numCodes; j++)
				{
					int num3 = (int)this.length[j];
					if (num3 > 0)
					{
						this.codes[j] = DeflaterHuffman.BitReverse(array[num3 - 1]);
						array[num3 - 1] += 1 << 16 - num3;
					}
				}
			}

			// Token: 0x06001DFC RID: 7676 RVA: 0x00148068 File Offset: 0x00146268
			public void BuildTree()
			{
				int num = this.freqs.Length;
				int[] array = new int[num];
				int i = 0;
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					int num3 = (int)this.freqs[j];
					if (num3 != 0)
					{
						int num4 = i++;
						int num5;
						while (num4 > 0 && (int)this.freqs[array[num5 = (num4 - 1) / 2]] > num3)
						{
							array[num4] = array[num5];
							num4 = num5;
						}
						array[num4] = j;
						num2 = j;
					}
				}
				while (i < 2)
				{
					int num6 = ((num2 < 2) ? (++num2) : 0);
					array[i++] = num6;
				}
				this.numCodes = Math.Max(num2 + 1, this.minNumCodes);
				int num7 = i;
				int[] array2 = new int[4 * i - 2];
				int[] array3 = new int[2 * i - 1];
				int num8 = num7;
				for (int k = 0; k < i; k++)
				{
					int num9 = array[k];
					array2[2 * k] = num9;
					array2[2 * k + 1] = -1;
					array3[k] = (int)this.freqs[num9] << 8;
					array[k] = k;
				}
				do
				{
					int num10 = array[0];
					int num11 = array[--i];
					int num12 = 0;
					int l;
					for (l = 1; l < i; l = l * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num12] = array[l];
						num12 = l;
					}
					int num13 = array3[num11];
					while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
					{
						array[l] = array[num12];
					}
					array[l] = num11;
					int num14 = array[0];
					num11 = num8++;
					array2[2 * num11] = num10;
					array2[2 * num11 + 1] = num14;
					int num15 = Math.Min(array3[num10] & 255, array3[num14] & 255);
					num13 = (array3[num11] = array3[num10] + array3[num14] - num15 + 1);
					num12 = 0;
					for (l = 1; l < i; l = num12 * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num12] = array[l];
						num12 = l;
					}
					while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
					{
						array[l] = array[num12];
					}
					array[l] = num11;
				}
				while (i > 1);
				if (array[0] != array2.Length / 2 - 1)
				{
					throw new SharpZipBaseException("Heap invariant violated");
				}
				this.BuildLength(array2);
			}

			// Token: 0x06001DFD RID: 7677 RVA: 0x001482D4 File Offset: 0x001464D4
			public int GetEncodedLength()
			{
				int num = 0;
				for (int i = 0; i < this.freqs.Length; i++)
				{
					num += (int)(this.freqs[i] * (short)this.length[i]);
				}
				return num;
			}

			// Token: 0x06001DFE RID: 7678 RVA: 0x0014830C File Offset: 0x0014650C
			public void CalcBLFreq(DeflaterHuffman.Tree blTree)
			{
				int num = -1;
				int i = 0;
				while (i < this.numCodes)
				{
					int num2 = 1;
					int num3 = (int)this.length[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							short[] array = blTree.freqs;
							int num6 = num3;
							array[num6] += 1;
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < this.numCodes && num == (int)this.length[i])
					{
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						short[] array2 = blTree.freqs;
						int num7 = num;
						array2[num7] += (short)num2;
					}
					else if (num != 0)
					{
						short[] array3 = blTree.freqs;
						int num8 = 16;
						array3[num8] += 1;
					}
					else if (num2 <= 10)
					{
						short[] array4 = blTree.freqs;
						int num9 = 17;
						array4[num9] += 1;
					}
					else
					{
						short[] array5 = blTree.freqs;
						int num10 = 18;
						array5[num10] += 1;
					}
				}
			}

			// Token: 0x06001DFF RID: 7679 RVA: 0x001483F8 File Offset: 0x001465F8
			public void WriteTree(DeflaterHuffman.Tree blTree)
			{
				int num = -1;
				int i = 0;
				while (i < this.numCodes)
				{
					int num2 = 1;
					int num3 = (int)this.length[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							blTree.WriteSymbol(num3);
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < this.numCodes && num == (int)this.length[i])
					{
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						while (num2-- > 0)
						{
							blTree.WriteSymbol(num);
						}
					}
					else if (num != 0)
					{
						blTree.WriteSymbol(16);
						this.dh.pending.WriteBits(num2 - 3, 2);
					}
					else if (num2 <= 10)
					{
						blTree.WriteSymbol(17);
						this.dh.pending.WriteBits(num2 - 3, 3);
					}
					else
					{
						blTree.WriteSymbol(18);
						this.dh.pending.WriteBits(num2 - 11, 7);
					}
				}
			}

			// Token: 0x06001E00 RID: 7680 RVA: 0x001484F4 File Offset: 0x001466F4
			private void BuildLength(int[] childs)
			{
				this.length = new byte[this.freqs.Length];
				int num = childs.Length / 2;
				int num2 = (num + 1) / 2;
				int num3 = 0;
				for (int i = 0; i < this.maxLength; i++)
				{
					this.bl_counts[i] = 0;
				}
				int[] array = new int[num];
				array[num - 1] = 0;
				for (int j = num - 1; j >= 0; j--)
				{
					if (childs[2 * j + 1] != -1)
					{
						int num4 = array[j] + 1;
						if (num4 > this.maxLength)
						{
							num4 = this.maxLength;
							num3++;
						}
						array[childs[2 * j]] = (array[childs[2 * j + 1]] = num4);
					}
					else
					{
						int num5 = array[j];
						this.bl_counts[num5 - 1]++;
						this.length[childs[2 * j]] = (byte)array[j];
					}
				}
				if (num3 == 0)
				{
					return;
				}
				int num6 = this.maxLength - 1;
				for (;;)
				{
					if (this.bl_counts[--num6] != 0)
					{
						do
						{
							this.bl_counts[num6]--;
							this.bl_counts[++num6]++;
							num3 -= 1 << this.maxLength - 1 - num6;
						}
						while (num3 > 0 && num6 < this.maxLength - 1);
						if (num3 <= 0)
						{
							break;
						}
					}
				}
				this.bl_counts[this.maxLength - 1] += num3;
				this.bl_counts[this.maxLength - 2] -= num3;
				int num7 = 2 * num2;
				for (int num8 = this.maxLength; num8 != 0; num8--)
				{
					int k = this.bl_counts[num8 - 1];
					while (k > 0)
					{
						int num9 = 2 * childs[num7++];
						if (childs[num9 + 1] == -1)
						{
							this.length[childs[num9]] = (byte)num8;
							k--;
						}
					}
				}
			}

			// Token: 0x04001552 RID: 5458
			public short[] freqs;

			// Token: 0x04001553 RID: 5459
			public byte[] length;

			// Token: 0x04001554 RID: 5460
			public int minNumCodes;

			// Token: 0x04001555 RID: 5461
			public int numCodes;

			// Token: 0x04001556 RID: 5462
			private short[] codes;

			// Token: 0x04001557 RID: 5463
			private readonly int[] bl_counts;

			// Token: 0x04001558 RID: 5464
			private readonly int maxLength;

			// Token: 0x04001559 RID: 5465
			private DeflaterHuffman dh;
		}
	}
}
