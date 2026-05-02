using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x0200016E RID: 366
	public class InflaterInputStream : Stream
	{
		// Token: 0x0600192F RID: 6447 RVA: 0x001395B6 File Offset: 0x001377B6
		public InflaterInputStream(Stream baseInputStream)
			: this(baseInputStream, new Inflater(), 4096)
		{
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x001395C9 File Offset: 0x001377C9
		public InflaterInputStream(Stream baseInputStream, Inflater inf)
			: this(baseInputStream, inf, 4096)
		{
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x001395D8 File Offset: 0x001377D8
		public InflaterInputStream(Stream baseInputStream, Inflater inflater, int bufferSize)
		{
			if (baseInputStream == null)
			{
				throw new ArgumentNullException("baseInputStream");
			}
			if (inflater == null)
			{
				throw new ArgumentNullException("inflater");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			this.baseInputStream = baseInputStream;
			this.inf = inflater;
			this.inputBuffer = new InflaterInputBuffer(baseInputStream, bufferSize);
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06001932 RID: 6450 RVA: 0x00139638 File Offset: 0x00137838
		// (set) Token: 0x06001933 RID: 6451 RVA: 0x00139640 File Offset: 0x00137840
		public bool IsStreamOwner { get; set; } = true;

		// Token: 0x06001934 RID: 6452 RVA: 0x0013964C File Offset: 0x0013784C
		public long Skip(long count)
		{
			if (count <= 0L)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this.baseInputStream.CanSeek)
			{
				this.baseInputStream.Seek(count, SeekOrigin.Current);
				return count;
			}
			int num = 2048;
			if (count < (long)num)
			{
				num = (int)count;
			}
			byte[] array = new byte[num];
			int num2 = 1;
			long num3 = count;
			while (num3 > 0L && num2 > 0)
			{
				if (num3 < (long)num)
				{
					num = (int)num3;
				}
				num2 = this.baseInputStream.Read(array, 0, num);
				num3 -= (long)num2;
			}
			return count - num3;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x001396C9 File Offset: 0x001378C9
		protected void StopDecrypting()
		{
			this.inputBuffer.CryptoTransform = null;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06001936 RID: 6454 RVA: 0x001396D7 File Offset: 0x001378D7
		public virtual int Available
		{
			get
			{
				if (!this.inf.IsFinished)
				{
					return 1;
				}
				return 0;
			}
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x001396EC File Offset: 0x001378EC
		protected void Fill()
		{
			if (this.inputBuffer.Available <= 0)
			{
				this.inputBuffer.Fill();
				if (this.inputBuffer.Available <= 0)
				{
					throw new SharpZipBaseException("Unexpected EOF");
				}
			}
			this.inputBuffer.SetInflaterInput(this.inf);
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06001938 RID: 6456 RVA: 0x0013973C File Offset: 0x0013793C
		public override bool CanRead
		{
			get
			{
				return this.baseInputStream.CanRead;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06001939 RID: 6457 RVA: 0x00139749 File Offset: 0x00137949
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600193A RID: 6458 RVA: 0x0013974C File Offset: 0x0013794C
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600193B RID: 6459 RVA: 0x0013974F File Offset: 0x0013794F
		public override long Length
		{
			get
			{
				throw new NotSupportedException("InflaterInputStream Length is not supported");
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600193C RID: 6460 RVA: 0x0013975B File Offset: 0x0013795B
		// (set) Token: 0x0600193D RID: 6461 RVA: 0x00139768 File Offset: 0x00137968
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

		// Token: 0x0600193E RID: 6462 RVA: 0x00139774 File Offset: 0x00137974
		public override void Flush()
		{
			this.baseInputStream.Flush();
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00139781 File Offset: 0x00137981
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x0013978D File Offset: 0x0013798D
		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00139799 File Offset: 0x00137999
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x001397A5 File Offset: 0x001379A5
		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x001397B1 File Offset: 0x001379B1
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

		// Token: 0x06001944 RID: 6468 RVA: 0x001397D8 File Offset: 0x001379D8
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.inf.IsNeedingDictionary)
			{
				throw new SharpZipBaseException("Need a dictionary");
			}
			int num = count;
			for (;;)
			{
				int num2 = this.inf.Inflate(buffer, offset, num);
				offset += num2;
				num -= num2;
				if (num == 0 || this.inf.IsFinished)
				{
					goto IL_0065;
				}
				if (this.inf.IsNeedingInput)
				{
					this.Fill();
				}
				else if (num2 == 0)
				{
					break;
				}
			}
			throw new ZipException("Invalid input data");
			IL_0065:
			return count - num;
		}

		// Token: 0x04000E9F RID: 3743
		protected Inflater inf;

		// Token: 0x04000EA0 RID: 3744
		protected InflaterInputBuffer inputBuffer;

		// Token: 0x04000EA1 RID: 3745
		private Stream baseInputStream;

		// Token: 0x04000EA2 RID: 3746
		protected long csize;

		// Token: 0x04000EA3 RID: 3747
		private bool isClosed;
	}
}
