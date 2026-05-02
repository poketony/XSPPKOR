using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	// Token: 0x02000162 RID: 354
	public class Deflater
	{
		// Token: 0x06001899 RID: 6297 RVA: 0x00135FA7 File Offset: 0x001341A7
		public Deflater()
			: this(-1, false)
		{
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00135FB1 File Offset: 0x001341B1
		public Deflater(int level)
			: this(level, false)
		{
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00135FBC File Offset: 0x001341BC
		public Deflater(int level, bool noZlibHeaderOrFooter)
		{
			if (level == -1)
			{
				level = 6;
			}
			else if (level < 0 || level > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			this.pending = new DeflaterPending();
			this.engine = new DeflaterEngine(this.pending, noZlibHeaderOrFooter);
			this.noZlibHeaderOrFooter = noZlibHeaderOrFooter;
			this.SetStrategy(DeflateStrategy.Default);
			this.SetLevel(level);
			this.Reset();
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x00136024 File Offset: 0x00134224
		public void Reset()
		{
			this.state = (this.noZlibHeaderOrFooter ? 16 : 0);
			this.totalOut = 0L;
			this.pending.Reset();
			this.engine.Reset();
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600189D RID: 6301 RVA: 0x00136057 File Offset: 0x00134257
		public int Adler
		{
			get
			{
				return this.engine.Adler;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600189E RID: 6302 RVA: 0x00136064 File Offset: 0x00134264
		public long TotalIn
		{
			get
			{
				return this.engine.TotalIn;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600189F RID: 6303 RVA: 0x00136071 File Offset: 0x00134271
		public long TotalOut
		{
			get
			{
				return this.totalOut;
			}
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00136079 File Offset: 0x00134279
		public void Flush()
		{
			this.state |= 4;
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00136089 File Offset: 0x00134289
		public void Finish()
		{
			this.state |= 12;
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060018A2 RID: 6306 RVA: 0x0013609A File Offset: 0x0013429A
		public bool IsFinished
		{
			get
			{
				return this.state == 30 && this.pending.IsFlushed;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060018A3 RID: 6307 RVA: 0x001360B3 File Offset: 0x001342B3
		public bool IsNeedingInput
		{
			get
			{
				return this.engine.NeedsInput();
			}
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x001360C0 File Offset: 0x001342C0
		public void SetInput(byte[] input)
		{
			this.SetInput(input, 0, input.Length);
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x001360CD File Offset: 0x001342CD
		public void SetInput(byte[] input, int offset, int count)
		{
			if ((this.state & 8) != 0)
			{
				throw new InvalidOperationException("Finish() already called");
			}
			this.engine.SetInput(input, offset, count);
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x001360F2 File Offset: 0x001342F2
		public void SetLevel(int level)
		{
			if (level == -1)
			{
				level = 6;
			}
			else if (level < 0 || level > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			if (this.level != level)
			{
				this.level = level;
				this.engine.SetLevel(level);
			}
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x0013612D File Offset: 0x0013432D
		public int GetLevel()
		{
			return this.level;
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00136135 File Offset: 0x00134335
		public void SetStrategy(DeflateStrategy strategy)
		{
			this.engine.Strategy = strategy;
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00136143 File Offset: 0x00134343
		public int Deflate(byte[] output)
		{
			return this.Deflate(output, 0, output.Length);
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x00136150 File Offset: 0x00134350
		public int Deflate(byte[] output, int offset, int length)
		{
			int num = length;
			if (this.state == 127)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (this.state < 16)
			{
				int num2 = 30720;
				int num3 = this.level - 1 >> 1;
				if (num3 < 0 || num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if ((this.state & 1) != 0)
				{
					num2 |= 32;
				}
				num2 += 31 - num2 % 31;
				this.pending.WriteShortMSB(num2);
				if ((this.state & 1) != 0)
				{
					int adler = this.engine.Adler;
					this.engine.ResetAdler();
					this.pending.WriteShortMSB(adler >> 16);
					this.pending.WriteShortMSB(adler & 65535);
				}
				this.state = 16 | (this.state & 12);
			}
			for (;;)
			{
				int num4 = this.pending.Flush(output, offset, length);
				offset += num4;
				this.totalOut += (long)num4;
				length -= num4;
				if (length == 0 || this.state == 30)
				{
					goto IL_01D3;
				}
				if (!this.engine.Deflate((this.state & 4) != 0, (this.state & 8) != 0))
				{
					int num5 = this.state;
					if (num5 == 16)
					{
						break;
					}
					if (num5 != 20)
					{
						if (num5 == 28)
						{
							this.pending.AlignToByte();
							if (!this.noZlibHeaderOrFooter)
							{
								int adler2 = this.engine.Adler;
								this.pending.WriteShortMSB(adler2 >> 16);
								this.pending.WriteShortMSB(adler2 & 65535);
							}
							this.state = 30;
						}
					}
					else
					{
						if (this.level != 0)
						{
							for (int i = 8 + (-this.pending.BitCount & 7); i > 0; i -= 10)
							{
								this.pending.WriteBits(2, 10);
							}
						}
						this.state = 16;
					}
				}
			}
			return num - length;
			IL_01D3:
			return num - length;
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00136333 File Offset: 0x00134533
		public void SetDictionary(byte[] dictionary)
		{
			this.SetDictionary(dictionary, 0, dictionary.Length);
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00136340 File Offset: 0x00134540
		public void SetDictionary(byte[] dictionary, int index, int count)
		{
			if (this.state != 0)
			{
				throw new InvalidOperationException();
			}
			this.state = 1;
			this.engine.SetDictionary(dictionary, index, count);
		}

		// Token: 0x04000DF3 RID: 3571
		public const int BEST_COMPRESSION = 9;

		// Token: 0x04000DF4 RID: 3572
		public const int BEST_SPEED = 1;

		// Token: 0x04000DF5 RID: 3573
		public const int DEFAULT_COMPRESSION = -1;

		// Token: 0x04000DF6 RID: 3574
		public const int NO_COMPRESSION = 0;

		// Token: 0x04000DF7 RID: 3575
		public const int DEFLATED = 8;

		// Token: 0x04000DF8 RID: 3576
		private const int IS_SETDICT = 1;

		// Token: 0x04000DF9 RID: 3577
		private const int IS_FLUSHING = 4;

		// Token: 0x04000DFA RID: 3578
		private const int IS_FINISHING = 8;

		// Token: 0x04000DFB RID: 3579
		private const int INIT_STATE = 0;

		// Token: 0x04000DFC RID: 3580
		private const int SETDICT_STATE = 1;

		// Token: 0x04000DFD RID: 3581
		private const int BUSY_STATE = 16;

		// Token: 0x04000DFE RID: 3582
		private const int FLUSHING_STATE = 20;

		// Token: 0x04000DFF RID: 3583
		private const int FINISHING_STATE = 28;

		// Token: 0x04000E00 RID: 3584
		private const int FINISHED_STATE = 30;

		// Token: 0x04000E01 RID: 3585
		private const int CLOSED_STATE = 127;

		// Token: 0x04000E02 RID: 3586
		private int level;

		// Token: 0x04000E03 RID: 3587
		private bool noZlibHeaderOrFooter;

		// Token: 0x04000E04 RID: 3588
		private int state;

		// Token: 0x04000E05 RID: 3589
		private long totalOut;

		// Token: 0x04000E06 RID: 3590
		private DeflaterPending pending;

		// Token: 0x04000E07 RID: 3591
		private DeflaterEngine engine;

		// Token: 0x02000256 RID: 598
		public enum CompressionLevel
		{
			// Token: 0x0400154D RID: 5453
			BEST_COMPRESSION = 9,
			// Token: 0x0400154E RID: 5454
			BEST_SPEED = 1,
			// Token: 0x0400154F RID: 5455
			DEFAULT_COMPRESSION = -1,
			// Token: 0x04001550 RID: 5456
			NO_COMPRESSION,
			// Token: 0x04001551 RID: 5457
			DEFLATED = 8
		}
	}
}
