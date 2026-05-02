using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000179 RID: 377
	public class TarInputStream : Stream
	{
		// Token: 0x06001A07 RID: 6663 RVA: 0x0013C137 File Offset: 0x0013A337
		public TarInputStream(Stream inputStream)
			: this(inputStream, 20)
		{
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x0013C142 File Offset: 0x0013A342
		public TarInputStream(Stream inputStream, int blockFactor)
		{
			this.inputStream = inputStream;
			this.tarBuffer = TarBuffer.CreateInputTarBuffer(inputStream, blockFactor);
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06001A09 RID: 6665 RVA: 0x0013C15E File Offset: 0x0013A35E
		// (set) Token: 0x06001A0A RID: 6666 RVA: 0x0013C16B File Offset: 0x0013A36B
		public bool IsStreamOwner
		{
			get
			{
				return this.tarBuffer.IsStreamOwner;
			}
			set
			{
				this.tarBuffer.IsStreamOwner = value;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06001A0B RID: 6667 RVA: 0x0013C179 File Offset: 0x0013A379
		public override bool CanRead
		{
			get
			{
				return this.inputStream.CanRead;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06001A0C RID: 6668 RVA: 0x0013C186 File Offset: 0x0013A386
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06001A0D RID: 6669 RVA: 0x0013C189 File Offset: 0x0013A389
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06001A0E RID: 6670 RVA: 0x0013C18C File Offset: 0x0013A38C
		public override long Length
		{
			get
			{
				return this.inputStream.Length;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06001A0F RID: 6671 RVA: 0x0013C199 File Offset: 0x0013A399
		// (set) Token: 0x06001A10 RID: 6672 RVA: 0x0013C1A6 File Offset: 0x0013A3A6
		public override long Position
		{
			get
			{
				return this.inputStream.Position;
			}
			set
			{
				throw new NotSupportedException("TarInputStream Seek not supported");
			}
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x0013C1B2 File Offset: 0x0013A3B2
		public override void Flush()
		{
			this.inputStream.Flush();
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x0013C1BF File Offset: 0x0013A3BF
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("TarInputStream Seek not supported");
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x0013C1CB File Offset: 0x0013A3CB
		public override void SetLength(long value)
		{
			throw new NotSupportedException("TarInputStream SetLength not supported");
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x0013C1D7 File Offset: 0x0013A3D7
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("TarInputStream Write not supported");
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x0013C1E3 File Offset: 0x0013A3E3
		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("TarInputStream WriteByte not supported");
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x0013C1F0 File Offset: 0x0013A3F0
		public override int ReadByte()
		{
			byte[] array = new byte[1];
			if (this.Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return (int)array[0];
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x0013C218 File Offset: 0x0013A418
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = 0;
			if (this.entryOffset >= this.entrySize)
			{
				return 0;
			}
			long num2 = (long)count;
			if (num2 + this.entryOffset > this.entrySize)
			{
				num2 = this.entrySize - this.entryOffset;
			}
			if (this.readBuffer != null)
			{
				int num3 = ((num2 > (long)this.readBuffer.Length) ? this.readBuffer.Length : ((int)num2));
				Array.Copy(this.readBuffer, 0, buffer, offset, num3);
				if (num3 >= this.readBuffer.Length)
				{
					this.readBuffer = null;
				}
				else
				{
					int num4 = this.readBuffer.Length - num3;
					byte[] array = new byte[num4];
					Array.Copy(this.readBuffer, num3, array, 0, num4);
					this.readBuffer = array;
				}
				num += num3;
				num2 -= (long)num3;
				offset += num3;
			}
			while (num2 > 0L)
			{
				byte[] array2 = this.tarBuffer.ReadBlock();
				if (array2 == null)
				{
					throw new TarException("unexpected EOF with " + num2.ToString() + " bytes unread");
				}
				int num5 = (int)num2;
				int num6 = array2.Length;
				if (num6 > num5)
				{
					Array.Copy(array2, 0, buffer, offset, num5);
					this.readBuffer = new byte[num6 - num5];
					Array.Copy(array2, num5, this.readBuffer, 0, num6 - num5);
				}
				else
				{
					num5 = num6;
					Array.Copy(array2, 0, buffer, offset, num6);
				}
				num += num5;
				num2 -= (long)num5;
				offset += num5;
			}
			this.entryOffset += (long)num;
			return num;
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x0013C394 File Offset: 0x0013A594
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.tarBuffer.Close();
			}
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x0013C3A4 File Offset: 0x0013A5A4
		public void SetEntryFactory(TarInputStream.IEntryFactory factory)
		{
			this.entryFactory = factory;
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06001A1A RID: 6682 RVA: 0x0013C3AD File Offset: 0x0013A5AD
		public int RecordSize
		{
			get
			{
				return this.tarBuffer.RecordSize;
			}
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x0013C3BA File Offset: 0x0013A5BA
		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return this.tarBuffer.RecordSize;
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06001A1C RID: 6684 RVA: 0x0013C3C7 File Offset: 0x0013A5C7
		public long Available
		{
			get
			{
				return this.entrySize - this.entryOffset;
			}
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x0013C3D8 File Offset: 0x0013A5D8
		public void Skip(long skipCount)
		{
			byte[] array = new byte[8192];
			int num3;
			for (long num = skipCount; num > 0L; num -= (long)num3)
			{
				int num2 = ((num > (long)array.Length) ? array.Length : ((int)num));
				num3 = this.Read(array, 0, num2);
				if (num3 == -1)
				{
					break;
				}
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06001A1E RID: 6686 RVA: 0x0013C41B File Offset: 0x0013A61B
		public bool IsMarkSupported
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x0013C41E File Offset: 0x0013A61E
		public void Mark(int markLimit)
		{
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x0013C420 File Offset: 0x0013A620
		public void Reset()
		{
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x0013C424 File Offset: 0x0013A624
		public TarEntry GetNextEntry()
		{
			if (this.hasHitEOF)
			{
				return null;
			}
			if (this.currentEntry != null)
			{
				this.SkipToNextEntry();
			}
			byte[] array = this.tarBuffer.ReadBlock();
			if (array == null)
			{
				this.hasHitEOF = true;
			}
			else if (TarBuffer.IsEndOfArchiveBlock(array))
			{
				this.hasHitEOF = true;
				this.tarBuffer.ReadBlock();
			}
			else
			{
				this.hasHitEOF = false;
			}
			if (this.hasHitEOF)
			{
				this.currentEntry = null;
			}
			else
			{
				try
				{
					TarHeader tarHeader = new TarHeader();
					tarHeader.ParseBuffer(array);
					if (!tarHeader.IsChecksumValid)
					{
						throw new TarException("Header checksum is invalid");
					}
					this.entryOffset = 0L;
					this.entrySize = tarHeader.Size;
					StringBuilder stringBuilder = null;
					if (tarHeader.TypeFlag == 76)
					{
						byte[] array2 = new byte[512];
						long num = this.entrySize;
						stringBuilder = new StringBuilder();
						while (num > 0L)
						{
							int num2 = this.Read(array2, 0, (num > (long)array2.Length) ? array2.Length : ((int)num));
							if (num2 == -1)
							{
								throw new InvalidHeaderException("Failed to read long name entry");
							}
							stringBuilder.Append(TarHeader.ParseName(array2, 0, num2).ToString());
							num -= (long)num2;
						}
						this.SkipToNextEntry();
						array = this.tarBuffer.ReadBlock();
					}
					else if (tarHeader.TypeFlag == 103)
					{
						this.SkipToNextEntry();
						array = this.tarBuffer.ReadBlock();
					}
					else if (tarHeader.TypeFlag == 120)
					{
						byte[] array3 = new byte[512];
						long num3 = this.entrySize;
						TarExtendedHeaderReader tarExtendedHeaderReader = new TarExtendedHeaderReader();
						while (num3 > 0L)
						{
							int num4 = this.Read(array3, 0, (num3 > (long)array3.Length) ? array3.Length : ((int)num3));
							if (num4 == -1)
							{
								throw new InvalidHeaderException("Failed to read long name entry");
							}
							tarExtendedHeaderReader.Read(array3, num4);
							num3 -= (long)num4;
						}
						string text;
						if (tarExtendedHeaderReader.Headers.TryGetValue("path", out text))
						{
							stringBuilder = new StringBuilder(text);
						}
						this.SkipToNextEntry();
						array = this.tarBuffer.ReadBlock();
					}
					else if (tarHeader.TypeFlag == 86)
					{
						this.SkipToNextEntry();
						array = this.tarBuffer.ReadBlock();
					}
					else if (tarHeader.TypeFlag != 48 && tarHeader.TypeFlag != 0 && tarHeader.TypeFlag != 49 && tarHeader.TypeFlag != 50 && tarHeader.TypeFlag != 53)
					{
						this.SkipToNextEntry();
						array = this.tarBuffer.ReadBlock();
					}
					if (this.entryFactory == null)
					{
						this.currentEntry = new TarEntry(array);
						if (stringBuilder != null)
						{
							this.currentEntry.Name = stringBuilder.ToString();
						}
					}
					else
					{
						this.currentEntry = this.entryFactory.CreateEntry(array);
					}
					this.entryOffset = 0L;
					this.entrySize = this.currentEntry.Size;
				}
				catch (InvalidHeaderException ex)
				{
					this.entrySize = 0L;
					this.entryOffset = 0L;
					this.currentEntry = null;
					throw new InvalidHeaderException(string.Format("Bad header in record {0} block {1} {2}", this.tarBuffer.CurrentRecord, this.tarBuffer.CurrentBlock, ex.Message));
				}
			}
			return this.currentEntry;
		}

		// Token: 0x06001A22 RID: 6690 RVA: 0x0013C744 File Offset: 0x0013A944
		public void CopyEntryContents(Stream outputStream)
		{
			byte[] array = new byte[32768];
			for (;;)
			{
				int num = this.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				outputStream.Write(array, 0, num);
			}
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x0013C778 File Offset: 0x0013A978
		private void SkipToNextEntry()
		{
			long num = this.entrySize - this.entryOffset;
			if (num > 0L)
			{
				this.Skip(num);
			}
			this.readBuffer = null;
		}

		// Token: 0x04000F14 RID: 3860
		protected bool hasHitEOF;

		// Token: 0x04000F15 RID: 3861
		protected long entrySize;

		// Token: 0x04000F16 RID: 3862
		protected long entryOffset;

		// Token: 0x04000F17 RID: 3863
		protected byte[] readBuffer;

		// Token: 0x04000F18 RID: 3864
		protected TarBuffer tarBuffer;

		// Token: 0x04000F19 RID: 3865
		private TarEntry currentEntry;

		// Token: 0x04000F1A RID: 3866
		protected TarInputStream.IEntryFactory entryFactory;

		// Token: 0x04000F1B RID: 3867
		private readonly Stream inputStream;

		// Token: 0x02000259 RID: 601
		public interface IEntryFactory
		{
			// Token: 0x06001E09 RID: 7689
			TarEntry CreateEntry(string name);

			// Token: 0x06001E0A RID: 7690
			TarEntry CreateEntryFromFile(string fileName);

			// Token: 0x06001E0B RID: 7691
			TarEntry CreateEntry(byte[] headerBuffer);
		}

		// Token: 0x0200025A RID: 602
		public class EntryFactoryAdapter : TarInputStream.IEntryFactory
		{
			// Token: 0x06001E0C RID: 7692 RVA: 0x00148B03 File Offset: 0x00146D03
			public TarEntry CreateEntry(string name)
			{
				return TarEntry.CreateTarEntry(name);
			}

			// Token: 0x06001E0D RID: 7693 RVA: 0x00148B0B File Offset: 0x00146D0B
			public TarEntry CreateEntryFromFile(string fileName)
			{
				return TarEntry.CreateEntryFromFile(fileName);
			}

			// Token: 0x06001E0E RID: 7694 RVA: 0x00148B13 File Offset: 0x00146D13
			public TarEntry CreateEntry(byte[] headerBuffer)
			{
				return new TarEntry(headerBuffer);
			}
		}
	}
}
