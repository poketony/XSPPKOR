using System;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	// Token: 0x02000168 RID: 360
	public class Inflater
	{
		// Token: 0x060018D1 RID: 6353 RVA: 0x00137C1E File Offset: 0x00135E1E
		public Inflater()
			: this(false)
		{
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x00137C27 File Offset: 0x00135E27
		public Inflater(bool noHeader)
		{
			this.noHeader = noHeader;
			if (!noHeader)
			{
				this.adler = new Adler32();
			}
			this.input = new StreamManipulator();
			this.outputWindow = new OutputWindow();
			this.mode = (noHeader ? 2 : 0);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x00137C68 File Offset: 0x00135E68
		public void Reset()
		{
			this.mode = (this.noHeader ? 2 : 0);
			this.totalIn = 0L;
			this.totalOut = 0L;
			this.input.Reset();
			this.outputWindow.Reset();
			this.dynHeader = null;
			this.litlenTree = null;
			this.distTree = null;
			this.isLastBlock = false;
			Adler32 adler = this.adler;
			if (adler == null)
			{
				return;
			}
			adler.Reset();
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x00137CDC File Offset: 0x00135EDC
		private bool DecodeHeader()
		{
			int num = this.input.PeekBits(16);
			if (num < 0)
			{
				return false;
			}
			this.input.DropBits(16);
			num = ((num << 8) | (num >> 8)) & 65535;
			if (num % 31 != 0)
			{
				throw new SharpZipBaseException("Header checksum illegal");
			}
			if ((num & 3840) != 2048)
			{
				throw new SharpZipBaseException("Compression Method unknown");
			}
			if ((num & 32) == 0)
			{
				this.mode = 2;
			}
			else
			{
				this.mode = 1;
				this.neededBits = 32;
			}
			return true;
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x00137D64 File Offset: 0x00135F64
		private bool DecodeDict()
		{
			while (this.neededBits > 0)
			{
				int num = this.input.PeekBits(8);
				if (num < 0)
				{
					return false;
				}
				this.input.DropBits(8);
				this.readAdler = (this.readAdler << 8) | num;
				this.neededBits -= 8;
			}
			return false;
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x00137DBC File Offset: 0x00135FBC
		private bool DecodeHuffman()
		{
			int i = this.outputWindow.GetFreeSpace();
			while (i >= 258)
			{
				int num;
				switch (this.mode)
				{
				case 7:
					while (((num = this.litlenTree.GetSymbol(this.input)) & -256) == 0)
					{
						this.outputWindow.Write(num);
						if (--i < 258)
						{
							return true;
						}
					}
					if (num >= 257)
					{
						try
						{
							this.repLength = Inflater.CPLENS[num - 257];
							this.neededBits = Inflater.CPLEXT[num - 257];
						}
						catch (Exception)
						{
							throw new SharpZipBaseException("Illegal rep length code");
						}
						goto IL_00C4;
					}
					if (num < 0)
					{
						return false;
					}
					this.distTree = null;
					this.litlenTree = null;
					this.mode = 2;
					return true;
				case 8:
					goto IL_00C4;
				case 9:
					goto IL_0113;
				case 10:
					break;
				default:
					throw new SharpZipBaseException("Inflater unknown mode");
				}
				IL_0154:
				if (this.neededBits > 0)
				{
					this.mode = 10;
					int num2 = this.input.PeekBits(this.neededBits);
					if (num2 < 0)
					{
						return false;
					}
					this.input.DropBits(this.neededBits);
					this.repDist += num2;
				}
				this.outputWindow.Repeat(this.repLength, this.repDist);
				i -= this.repLength;
				this.mode = 7;
				continue;
				IL_0113:
				num = this.distTree.GetSymbol(this.input);
				if (num < 0)
				{
					return false;
				}
				try
				{
					this.repDist = Inflater.CPDIST[num];
					this.neededBits = Inflater.CPDEXT[num];
				}
				catch (Exception)
				{
					throw new SharpZipBaseException("Illegal rep dist code");
				}
				goto IL_0154;
				IL_00C4:
				if (this.neededBits > 0)
				{
					this.mode = 8;
					int num3 = this.input.PeekBits(this.neededBits);
					if (num3 < 0)
					{
						return false;
					}
					this.input.DropBits(this.neededBits);
					this.repLength += num3;
				}
				this.mode = 9;
				goto IL_0113;
			}
			return true;
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x00137FC4 File Offset: 0x001361C4
		private bool DecodeChksum()
		{
			while (this.neededBits > 0)
			{
				int num = this.input.PeekBits(8);
				if (num < 0)
				{
					return false;
				}
				this.input.DropBits(8);
				this.readAdler = (this.readAdler << 8) | num;
				this.neededBits -= 8;
			}
			Adler32 adler = this.adler;
			if ((int)((adler != null) ? new long?(adler.Value) : null).Value != this.readAdler)
			{
				string text = "Adler chksum doesn't match: ";
				Adler32 adler2 = this.adler;
				throw new SharpZipBaseException(text + ((int)((adler2 != null) ? new long?(adler2.Value) : null).Value).ToString() + " vs. " + this.readAdler.ToString());
			}
			this.mode = 12;
			return false;
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x001380A4 File Offset: 0x001362A4
		private bool Decode()
		{
			switch (this.mode)
			{
			case 0:
				return this.DecodeHeader();
			case 1:
				return this.DecodeDict();
			case 2:
				if (this.isLastBlock)
				{
					if (this.noHeader)
					{
						this.mode = 12;
						return false;
					}
					this.input.SkipToByteBoundary();
					this.neededBits = 32;
					this.mode = 11;
					return true;
				}
				else
				{
					int num = this.input.PeekBits(3);
					if (num < 0)
					{
						return false;
					}
					this.input.DropBits(3);
					this.isLastBlock |= (num & 1) != 0;
					switch (num >> 1)
					{
					case 0:
						this.input.SkipToByteBoundary();
						this.mode = 3;
						break;
					case 1:
						this.litlenTree = InflaterHuffmanTree.defLitLenTree;
						this.distTree = InflaterHuffmanTree.defDistTree;
						this.mode = 7;
						break;
					case 2:
						this.dynHeader = new InflaterDynHeader(this.input);
						this.mode = 6;
						break;
					default:
						throw new SharpZipBaseException("Unknown block type " + num.ToString());
					}
					return true;
				}
				break;
			case 3:
				if ((this.uncomprLen = this.input.PeekBits(16)) < 0)
				{
					return false;
				}
				this.input.DropBits(16);
				this.mode = 4;
				break;
			case 4:
				break;
			case 5:
				goto IL_01B3;
			case 6:
				if (!this.dynHeader.AttemptRead())
				{
					return false;
				}
				this.litlenTree = this.dynHeader.LiteralLengthTree;
				this.distTree = this.dynHeader.DistanceTree;
				this.mode = 7;
				goto IL_0233;
			case 7:
			case 8:
			case 9:
			case 10:
				goto IL_0233;
			case 11:
				return this.DecodeChksum();
			case 12:
				return false;
			default:
				throw new SharpZipBaseException("Inflater.Decode unknown mode");
			}
			int num2 = this.input.PeekBits(16);
			if (num2 < 0)
			{
				return false;
			}
			this.input.DropBits(16);
			if (num2 != (this.uncomprLen ^ 65535))
			{
				throw new SharpZipBaseException("broken uncompressed block");
			}
			this.mode = 5;
			IL_01B3:
			int num3 = this.outputWindow.CopyStored(this.input, this.uncomprLen);
			this.uncomprLen -= num3;
			if (this.uncomprLen == 0)
			{
				this.mode = 2;
				return true;
			}
			return !this.input.IsNeedingInput;
			IL_0233:
			return this.DecodeHuffman();
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x001382F7 File Offset: 0x001364F7
		public void SetDictionary(byte[] buffer)
		{
			this.SetDictionary(buffer, 0, buffer.Length);
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x00138304 File Offset: 0x00136504
		public void SetDictionary(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (!this.IsNeedingDictionary)
			{
				throw new InvalidOperationException("Dictionary is not needed");
			}
			Adler32 adler = this.adler;
			if (adler != null)
			{
				adler.Update(new ArraySegment<byte>(buffer, index, count));
			}
			if (this.adler != null && (int)this.adler.Value != this.readAdler)
			{
				throw new SharpZipBaseException("Wrong adler checksum");
			}
			Adler32 adler2 = this.adler;
			if (adler2 != null)
			{
				adler2.Reset();
			}
			this.outputWindow.CopyDict(buffer, index, count);
			this.mode = 2;
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x001383B6 File Offset: 0x001365B6
		public void SetInput(byte[] buffer)
		{
			this.SetInput(buffer, 0, buffer.Length);
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x001383C3 File Offset: 0x001365C3
		public void SetInput(byte[] buffer, int index, int count)
		{
			this.input.SetInput(buffer, index, count);
			this.totalIn += (long)count;
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x001383E2 File Offset: 0x001365E2
		public int Inflate(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return this.Inflate(buffer, 0, buffer.Length);
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x00138400 File Offset: 0x00136600
		public int Inflate(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "count cannot be negative");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentException("count exceeds buffer bounds");
			}
			if (count == 0)
			{
				if (!this.IsFinished)
				{
					this.Decode();
				}
				return 0;
			}
			int num = 0;
			for (;;)
			{
				if (this.mode != 11)
				{
					int num2 = this.outputWindow.CopyOutput(buffer, offset, count);
					if (num2 > 0)
					{
						Adler32 adler = this.adler;
						if (adler != null)
						{
							adler.Update(new ArraySegment<byte>(buffer, offset, num2));
						}
						offset += num2;
						num += num2;
						this.totalOut += (long)num2;
						count -= num2;
						if (count == 0)
						{
							break;
						}
					}
				}
				if (!this.Decode() && (this.outputWindow.GetAvailable() <= 0 || this.mode == 11))
				{
					return num;
				}
			}
			return num;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060018DF RID: 6367 RVA: 0x001384E5 File Offset: 0x001366E5
		public bool IsNeedingInput
		{
			get
			{
				return this.input.IsNeedingInput;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060018E0 RID: 6368 RVA: 0x001384F2 File Offset: 0x001366F2
		public bool IsNeedingDictionary
		{
			get
			{
				return this.mode == 1 && this.neededBits == 0;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060018E1 RID: 6369 RVA: 0x00138508 File Offset: 0x00136708
		public bool IsFinished
		{
			get
			{
				return this.mode == 12 && this.outputWindow.GetAvailable() == 0;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060018E2 RID: 6370 RVA: 0x00138524 File Offset: 0x00136724
		public int Adler
		{
			get
			{
				if (this.IsNeedingDictionary)
				{
					return this.readAdler;
				}
				if (this.adler != null)
				{
					return (int)this.adler.Value;
				}
				return 0;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060018E3 RID: 6371 RVA: 0x0013854B File Offset: 0x0013674B
		public long TotalOut
		{
			get
			{
				return this.totalOut;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060018E4 RID: 6372 RVA: 0x00138553 File Offset: 0x00136753
		public long TotalIn
		{
			get
			{
				return this.totalIn - (long)this.RemainingInput;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060018E5 RID: 6373 RVA: 0x00138563 File Offset: 0x00136763
		public int RemainingInput
		{
			get
			{
				return this.input.AvailableBytes;
			}
		}

		// Token: 0x04000E55 RID: 3669
		private static readonly int[] CPLENS = new int[]
		{
			3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
			15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
			67, 83, 99, 115, 131, 163, 195, 227, 258
		};

		// Token: 0x04000E56 RID: 3670
		private static readonly int[] CPLEXT = new int[]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
			4, 4, 4, 4, 5, 5, 5, 5, 0
		};

		// Token: 0x04000E57 RID: 3671
		private static readonly int[] CPDIST = new int[]
		{
			1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
			33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
			1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
		};

		// Token: 0x04000E58 RID: 3672
		private static readonly int[] CPDEXT = new int[]
		{
			0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
			4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
			9, 9, 10, 10, 11, 11, 12, 12, 13, 13
		};

		// Token: 0x04000E59 RID: 3673
		private const int DECODE_HEADER = 0;

		// Token: 0x04000E5A RID: 3674
		private const int DECODE_DICT = 1;

		// Token: 0x04000E5B RID: 3675
		private const int DECODE_BLOCKS = 2;

		// Token: 0x04000E5C RID: 3676
		private const int DECODE_STORED_LEN1 = 3;

		// Token: 0x04000E5D RID: 3677
		private const int DECODE_STORED_LEN2 = 4;

		// Token: 0x04000E5E RID: 3678
		private const int DECODE_STORED = 5;

		// Token: 0x04000E5F RID: 3679
		private const int DECODE_DYN_HEADER = 6;

		// Token: 0x04000E60 RID: 3680
		private const int DECODE_HUFFMAN = 7;

		// Token: 0x04000E61 RID: 3681
		private const int DECODE_HUFFMAN_LENBITS = 8;

		// Token: 0x04000E62 RID: 3682
		private const int DECODE_HUFFMAN_DIST = 9;

		// Token: 0x04000E63 RID: 3683
		private const int DECODE_HUFFMAN_DISTBITS = 10;

		// Token: 0x04000E64 RID: 3684
		private const int DECODE_CHKSUM = 11;

		// Token: 0x04000E65 RID: 3685
		private const int FINISHED = 12;

		// Token: 0x04000E66 RID: 3686
		private int mode;

		// Token: 0x04000E67 RID: 3687
		private int readAdler;

		// Token: 0x04000E68 RID: 3688
		private int neededBits;

		// Token: 0x04000E69 RID: 3689
		private int repLength;

		// Token: 0x04000E6A RID: 3690
		private int repDist;

		// Token: 0x04000E6B RID: 3691
		private int uncomprLen;

		// Token: 0x04000E6C RID: 3692
		private bool isLastBlock;

		// Token: 0x04000E6D RID: 3693
		private long totalOut;

		// Token: 0x04000E6E RID: 3694
		private long totalIn;

		// Token: 0x04000E6F RID: 3695
		private bool noHeader;

		// Token: 0x04000E70 RID: 3696
		private readonly StreamManipulator input;

		// Token: 0x04000E71 RID: 3697
		private OutputWindow outputWindow;

		// Token: 0x04000E72 RID: 3698
		private InflaterDynHeader dynHeader;

		// Token: 0x04000E73 RID: 3699
		private InflaterHuffmanTree litlenTree;

		// Token: 0x04000E74 RID: 3700
		private InflaterHuffmanTree distTree;

		// Token: 0x04000E75 RID: 3701
		private Adler32 adler;
	}
}
