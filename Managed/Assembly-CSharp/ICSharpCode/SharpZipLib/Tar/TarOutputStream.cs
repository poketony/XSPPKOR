using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x0200017A RID: 378
	public class TarOutputStream : Stream
	{
		// Token: 0x06001A24 RID: 6692 RVA: 0x0013C7A6 File Offset: 0x0013A9A6
		public TarOutputStream(Stream outputStream)
			: this(outputStream, 20)
		{
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x0013C7B4 File Offset: 0x0013A9B4
		public TarOutputStream(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			this.outputStream = outputStream;
			this.buffer = TarBuffer.CreateOutputTarBuffer(outputStream, blockFactor);
			this.assemblyBuffer = new byte[512];
			this.blockBuffer = new byte[512];
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06001A26 RID: 6694 RVA: 0x0013C809 File Offset: 0x0013AA09
		// (set) Token: 0x06001A27 RID: 6695 RVA: 0x0013C816 File Offset: 0x0013AA16
		public bool IsStreamOwner
		{
			get
			{
				return this.buffer.IsStreamOwner;
			}
			set
			{
				this.buffer.IsStreamOwner = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06001A28 RID: 6696 RVA: 0x0013C824 File Offset: 0x0013AA24
		public override bool CanRead
		{
			get
			{
				return this.outputStream.CanRead;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06001A29 RID: 6697 RVA: 0x0013C831 File Offset: 0x0013AA31
		public override bool CanSeek
		{
			get
			{
				return this.outputStream.CanSeek;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06001A2A RID: 6698 RVA: 0x0013C83E File Offset: 0x0013AA3E
		public override bool CanWrite
		{
			get
			{
				return this.outputStream.CanWrite;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06001A2B RID: 6699 RVA: 0x0013C84B File Offset: 0x0013AA4B
		public override long Length
		{
			get
			{
				return this.outputStream.Length;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06001A2C RID: 6700 RVA: 0x0013C858 File Offset: 0x0013AA58
		// (set) Token: 0x06001A2D RID: 6701 RVA: 0x0013C865 File Offset: 0x0013AA65
		public override long Position
		{
			get
			{
				return this.outputStream.Position;
			}
			set
			{
				this.outputStream.Position = value;
			}
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x0013C873 File Offset: 0x0013AA73
		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.outputStream.Seek(offset, origin);
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x0013C882 File Offset: 0x0013AA82
		public override void SetLength(long value)
		{
			this.outputStream.SetLength(value);
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x0013C890 File Offset: 0x0013AA90
		public override int ReadByte()
		{
			return this.outputStream.ReadByte();
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x0013C89D File Offset: 0x0013AA9D
		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.outputStream.Read(buffer, offset, count);
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x0013C8AD File Offset: 0x0013AAAD
		public override void Flush()
		{
			this.outputStream.Flush();
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x0013C8BA File Offset: 0x0013AABA
		public void Finish()
		{
			if (this.IsEntryOpen)
			{
				this.CloseEntry();
			}
			this.WriteEofBlock();
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x0013C8D0 File Offset: 0x0013AAD0
		protected override void Dispose(bool disposing)
		{
			if (!this.isClosed)
			{
				this.isClosed = true;
				this.Finish();
				this.buffer.Close();
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06001A35 RID: 6709 RVA: 0x0013C8F2 File Offset: 0x0013AAF2
		public int RecordSize
		{
			get
			{
				return this.buffer.RecordSize;
			}
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x0013C8FF File Offset: 0x0013AAFF
		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return this.buffer.RecordSize;
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06001A37 RID: 6711 RVA: 0x0013C90C File Offset: 0x0013AB0C
		private bool IsEntryOpen
		{
			get
			{
				return this.currBytes < this.currSize;
			}
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x0013C91C File Offset: 0x0013AB1C
		public void PutNextEntry(TarEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (entry.TarHeader.Name.Length > 100)
			{
				TarHeader tarHeader = new TarHeader();
				tarHeader.TypeFlag = 76;
				tarHeader.Name += "././@LongLink";
				tarHeader.Mode = 420;
				tarHeader.UserId = entry.UserId;
				tarHeader.GroupId = entry.GroupId;
				tarHeader.GroupName = entry.GroupName;
				tarHeader.UserName = entry.UserName;
				tarHeader.LinkName = "";
				tarHeader.Size = (long)(entry.TarHeader.Name.Length + 1);
				tarHeader.WriteHeader(this.blockBuffer);
				this.buffer.WriteBlock(this.blockBuffer);
				int i = 0;
				while (i < entry.TarHeader.Name.Length + 1)
				{
					Array.Clear(this.blockBuffer, 0, this.blockBuffer.Length);
					TarHeader.GetAsciiBytes(entry.TarHeader.Name, i, this.blockBuffer, 0, 512);
					i += 512;
					this.buffer.WriteBlock(this.blockBuffer);
				}
			}
			entry.WriteEntryHeader(this.blockBuffer);
			this.buffer.WriteBlock(this.blockBuffer);
			this.currBytes = 0L;
			this.currSize = (entry.IsDirectory ? 0L : entry.Size);
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x0013CA90 File Offset: 0x0013AC90
		public void CloseEntry()
		{
			if (this.assemblyBufferLength > 0)
			{
				Array.Clear(this.assemblyBuffer, this.assemblyBufferLength, this.assemblyBuffer.Length - this.assemblyBufferLength);
				this.buffer.WriteBlock(this.assemblyBuffer);
				this.currBytes += (long)this.assemblyBufferLength;
				this.assemblyBufferLength = 0;
			}
			if (this.currBytes < this.currSize)
			{
				throw new TarException(string.Format("Entry closed at '{0}' before the '{1}' bytes specified in the header were written", this.currBytes, this.currSize));
			}
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x0013CB26 File Offset: 0x0013AD26
		public override void WriteByte(byte value)
		{
			this.Write(new byte[] { value }, 0, 1);
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x0013CB3C File Offset: 0x0013AD3C
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("offset and count combination is invalid");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (this.currBytes + (long)count > this.currSize)
			{
				string text = string.Format("request to write '{0}' bytes exceeds size in header of '{1}' bytes", count, this.currSize);
				throw new ArgumentOutOfRangeException("count", text);
			}
			if (this.assemblyBufferLength > 0)
			{
				if (this.assemblyBufferLength + count >= this.blockBuffer.Length)
				{
					int num = this.blockBuffer.Length - this.assemblyBufferLength;
					Array.Copy(this.assemblyBuffer, 0, this.blockBuffer, 0, this.assemblyBufferLength);
					Array.Copy(buffer, offset, this.blockBuffer, this.assemblyBufferLength, num);
					this.buffer.WriteBlock(this.blockBuffer);
					this.currBytes += (long)this.blockBuffer.Length;
					offset += num;
					count -= num;
					this.assemblyBufferLength = 0;
				}
				else
				{
					Array.Copy(buffer, offset, this.assemblyBuffer, this.assemblyBufferLength, count);
					offset += count;
					this.assemblyBufferLength += count;
					count -= count;
				}
			}
			while (count > 0)
			{
				if (count < this.blockBuffer.Length)
				{
					Array.Copy(buffer, offset, this.assemblyBuffer, this.assemblyBufferLength, count);
					this.assemblyBufferLength += count;
					return;
				}
				this.buffer.WriteBlock(buffer, offset);
				int num2 = this.blockBuffer.Length;
				this.currBytes += (long)num2;
				count -= num2;
				offset += num2;
			}
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x0013CCF2 File Offset: 0x0013AEF2
		private void WriteEofBlock()
		{
			Array.Clear(this.blockBuffer, 0, this.blockBuffer.Length);
			this.buffer.WriteBlock(this.blockBuffer);
			this.buffer.WriteBlock(this.blockBuffer);
		}

		// Token: 0x04000F1C RID: 3868
		private long currBytes;

		// Token: 0x04000F1D RID: 3869
		private int assemblyBufferLength;

		// Token: 0x04000F1E RID: 3870
		private bool isClosed;

		// Token: 0x04000F1F RID: 3871
		protected long currSize;

		// Token: 0x04000F20 RID: 3872
		protected byte[] blockBuffer;

		// Token: 0x04000F21 RID: 3873
		protected byte[] assemblyBuffer;

		// Token: 0x04000F22 RID: 3874
		protected TarBuffer buffer;

		// Token: 0x04000F23 RID: 3875
		protected Stream outputStream;
	}
}
