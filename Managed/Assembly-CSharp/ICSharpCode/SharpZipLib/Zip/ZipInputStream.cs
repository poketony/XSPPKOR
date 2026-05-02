using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200015E RID: 350
	public class ZipInputStream : InflaterInputStream
	{
		// Token: 0x0600185C RID: 6236 RVA: 0x00134184 File Offset: 0x00132384
		public ZipInputStream(Stream baseInputStream)
			: base(baseInputStream, new Inflater(true))
		{
			this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x001341B0 File Offset: 0x001323B0
		public ZipInputStream(Stream baseInputStream, int bufferSize)
			: base(baseInputStream, new Inflater(true), bufferSize)
		{
			this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600185E RID: 6238 RVA: 0x001341DD File Offset: 0x001323DD
		// (set) Token: 0x0600185F RID: 6239 RVA: 0x001341E5 File Offset: 0x001323E5
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06001860 RID: 6240 RVA: 0x001341EE File Offset: 0x001323EE
		public bool CanDecompressEntry
		{
			get
			{
				return this.entry != null && this.entry.CanDecompress;
			}
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x00134208 File Offset: 0x00132408
		public ZipEntry GetNextEntry()
		{
			if (this.crc == null)
			{
				throw new InvalidOperationException("Closed.");
			}
			if (this.entry != null)
			{
				this.CloseEntry();
			}
			int num = this.inputBuffer.ReadLeInt();
			if (num == 33639248 || num == 101010256 || num == 84233040 || num == 117853008 || num == 101075792)
			{
				base.Dispose();
				return null;
			}
			if (num == 808471376 || num == 134695760)
			{
				num = this.inputBuffer.ReadLeInt();
			}
			if (num != 67324752)
			{
				throw new ZipException("Wrong Local header signature: 0x" + string.Format("{0:X}", num));
			}
			short num2 = (short)this.inputBuffer.ReadLeShort();
			this.flags = this.inputBuffer.ReadLeShort();
			this.method = this.inputBuffer.ReadLeShort();
			uint num3 = (uint)this.inputBuffer.ReadLeInt();
			int num4 = this.inputBuffer.ReadLeInt();
			this.csize = (long)this.inputBuffer.ReadLeInt();
			this.size = (long)this.inputBuffer.ReadLeInt();
			int num5 = this.inputBuffer.ReadLeShort();
			int num6 = this.inputBuffer.ReadLeShort();
			bool flag = (this.flags & 1) == 1;
			byte[] array = new byte[num5];
			this.inputBuffer.ReadRawBuffer(array);
			string text = ZipStrings.ConvertToStringExt(this.flags, array);
			this.entry = new ZipEntry(text, (int)num2, 51, (CompressionMethod)this.method)
			{
				Flags = this.flags
			};
			if ((this.flags & 8) == 0)
			{
				this.entry.Crc = (long)num4 & (long)((ulong)(-1));
				this.entry.Size = this.size & (long)((ulong)(-1));
				this.entry.CompressedSize = this.csize & (long)((ulong)(-1));
				this.entry.CryptoCheckValue = (byte)((num4 >> 24) & 255);
			}
			else
			{
				if (num4 != 0)
				{
					this.entry.Crc = (long)num4 & (long)((ulong)(-1));
				}
				if (this.size != 0L)
				{
					this.entry.Size = this.size & (long)((ulong)(-1));
				}
				if (this.csize != 0L)
				{
					this.entry.CompressedSize = this.csize & (long)((ulong)(-1));
				}
				this.entry.CryptoCheckValue = (byte)((num3 >> 8) & 255U);
			}
			this.entry.DosTime = (long)((ulong)num3);
			if (num6 > 0)
			{
				byte[] array2 = new byte[num6];
				this.inputBuffer.ReadRawBuffer(array2);
				this.entry.ExtraData = array2;
			}
			this.entry.ProcessExtraData(true);
			if (this.entry.CompressedSize >= 0L)
			{
				this.csize = this.entry.CompressedSize;
			}
			if (this.entry.Size >= 0L)
			{
				this.size = this.entry.Size;
			}
			if (this.method == 0 && ((!flag && this.csize != this.size) || (flag && this.csize - 12L != this.size)))
			{
				throw new ZipException("Stored, but compressed != uncompressed");
			}
			if (this.entry.IsCompressionMethodSupported())
			{
				this.internalReader = new ZipInputStream.ReadDataHandler(this.InitialRead);
			}
			else
			{
				this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotSupported);
			}
			return this.entry;
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0013453C File Offset: 0x0013273C
		private void ReadDataDescriptor()
		{
			if (this.inputBuffer.ReadLeInt() != 134695760)
			{
				throw new ZipException("Data descriptor signature not found");
			}
			this.entry.Crc = (long)this.inputBuffer.ReadLeInt() & (long)((ulong)(-1));
			if (this.entry.LocalHeaderRequiresZip64)
			{
				this.csize = this.inputBuffer.ReadLeLong();
				this.size = this.inputBuffer.ReadLeLong();
			}
			else
			{
				this.csize = (long)this.inputBuffer.ReadLeInt();
				this.size = (long)this.inputBuffer.ReadLeInt();
			}
			this.entry.CompressedSize = this.csize;
			this.entry.Size = this.size;
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x001345F8 File Offset: 0x001327F8
		private void CompleteCloseEntry(bool testCrc)
		{
			base.StopDecrypting();
			if ((this.flags & 8) != 0)
			{
				this.ReadDataDescriptor();
			}
			this.size = 0L;
			if (testCrc && (this.crc.Value & (long)((ulong)(-1))) != this.entry.Crc && this.entry.Crc != -1L)
			{
				throw new ZipException("CRC mismatch");
			}
			this.crc.Reset();
			if (this.method == 8)
			{
				this.inf.Reset();
			}
			this.entry = null;
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x00134684 File Offset: 0x00132884
		public void CloseEntry()
		{
			if (this.crc == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (this.entry == null)
			{
				return;
			}
			if (this.method == 8)
			{
				if ((this.flags & 8) != 0)
				{
					byte[] array = new byte[4096];
					while (this.Read(array, 0, array.Length) > 0)
					{
					}
					return;
				}
				this.csize -= this.inf.TotalIn;
				this.inputBuffer.Available += this.inf.RemainingInput;
			}
			if ((long)this.inputBuffer.Available > this.csize && this.csize >= 0L)
			{
				this.inputBuffer.Available = (int)((long)this.inputBuffer.Available - this.csize);
			}
			else
			{
				this.csize -= (long)this.inputBuffer.Available;
				this.inputBuffer.Available = 0;
				while (this.csize != 0L)
				{
					long num = base.Skip(this.csize);
					if (num <= 0L)
					{
						throw new ZipException("Zip archive ends early.");
					}
					this.csize -= num;
				}
			}
			this.CompleteCloseEntry(false);
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06001865 RID: 6245 RVA: 0x001347AF File Offset: 0x001329AF
		public override int Available
		{
			get
			{
				if (this.entry == null)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06001866 RID: 6246 RVA: 0x001347BC File Offset: 0x001329BC
		public override long Length
		{
			get
			{
				if (this.entry == null)
				{
					throw new InvalidOperationException("No current entry");
				}
				if (this.entry.Size >= 0L)
				{
					return this.entry.Size;
				}
				throw new ZipException("Length not available for the current entry");
			}
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x001347F8 File Offset: 0x001329F8
		public override int ReadByte()
		{
			byte[] array = new byte[1];
			if (this.Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return (int)(array[0] & byte.MaxValue);
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x00134823 File Offset: 0x00132A23
		private int ReadingNotAvailable(byte[] destination, int offset, int count)
		{
			throw new InvalidOperationException("Unable to read from this stream");
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x0013482F File Offset: 0x00132A2F
		private int ReadingNotSupported(byte[] destination, int offset, int count)
		{
			throw new ZipException("The compression method for this entry is not supported");
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x0013483C File Offset: 0x00132A3C
		private int InitialRead(byte[] destination, int offset, int count)
		{
			if (!this.CanDecompressEntry)
			{
				throw new ZipException("Library cannot extract this entry. Version required is (" + this.entry.Version.ToString() + ")");
			}
			if (this.entry.IsCrypted)
			{
				if (this.password == null)
				{
					throw new ZipException("No password set.");
				}
				PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
				byte[] array = PkzipClassic.GenerateKeys(ZipStrings.ConvertToArray(this.password));
				this.inputBuffer.CryptoTransform = pkzipClassicManaged.CreateDecryptor(array, null);
				byte[] array2 = new byte[12];
				this.inputBuffer.ReadClearTextBuffer(array2, 0, 12);
				if (array2[11] != this.entry.CryptoCheckValue)
				{
					throw new ZipException("Invalid password");
				}
				if (this.csize >= 12L)
				{
					this.csize -= 12L;
				}
				else if ((this.entry.Flags & 8) == 0)
				{
					throw new ZipException(string.Format("Entry compressed size {0} too small for encryption", this.csize));
				}
			}
			else
			{
				this.inputBuffer.CryptoTransform = null;
			}
			if (this.csize > 0L || (this.flags & 8) != 0)
			{
				if (this.method == 8 && this.inputBuffer.Available > 0)
				{
					this.inputBuffer.SetInflaterInput(this.inf);
				}
				this.internalReader = new ZipInputStream.ReadDataHandler(this.BodyRead);
				return this.BodyRead(destination, offset, count);
			}
			this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
			return 0;
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x001349B8 File Offset: 0x00132BB8
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Invalid offset/count combination");
			}
			return this.internalReader(buffer, offset, count);
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x00134A1C File Offset: 0x00132C1C
		private int BodyRead(byte[] buffer, int offset, int count)
		{
			if (this.crc == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (this.entry == null || count <= 0)
			{
				return 0;
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentException("Offset + count exceeds buffer size");
			}
			bool flag = false;
			int num = this.method;
			if (num != 0)
			{
				if (num == 8)
				{
					count = base.Read(buffer, offset, count);
					if (count <= 0)
					{
						if (!this.inf.IsFinished)
						{
							throw new ZipException("Inflater not finished!");
						}
						this.inputBuffer.Available = this.inf.RemainingInput;
						if ((this.flags & 8) == 0 && ((this.inf.TotalIn != this.csize && this.csize != (long)((ulong)(-1)) && this.csize != -1L) || this.inf.TotalOut != this.size))
						{
							throw new ZipException(string.Concat(new string[]
							{
								"Size mismatch: ",
								this.csize.ToString(),
								";",
								this.size.ToString(),
								" <-> ",
								this.inf.TotalIn.ToString(),
								";",
								this.inf.TotalOut.ToString()
							}));
						}
						this.inf.Reset();
						flag = true;
					}
				}
			}
			else
			{
				if ((long)count > this.csize && this.csize >= 0L)
				{
					count = (int)this.csize;
				}
				if (count > 0)
				{
					count = this.inputBuffer.ReadClearTextBuffer(buffer, offset, count);
					if (count > 0)
					{
						this.csize -= (long)count;
						this.size -= (long)count;
					}
				}
				if (this.csize == 0L)
				{
					flag = true;
				}
				else if (count < 0)
				{
					throw new ZipException("EOF in stored block");
				}
			}
			if (count > 0)
			{
				this.crc.Update(new ArraySegment<byte>(buffer, offset, count));
			}
			if (flag)
			{
				this.CompleteCloseEntry(true);
			}
			return count;
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x00134C12 File Offset: 0x00132E12
		protected override void Dispose(bool disposing)
		{
			this.internalReader = new ZipInputStream.ReadDataHandler(this.ReadingNotAvailable);
			this.crc = null;
			this.entry = null;
			base.Dispose(disposing);
		}

		// Token: 0x04000DD9 RID: 3545
		private ZipInputStream.ReadDataHandler internalReader;

		// Token: 0x04000DDA RID: 3546
		private Crc32 crc = new Crc32();

		// Token: 0x04000DDB RID: 3547
		private ZipEntry entry;

		// Token: 0x04000DDC RID: 3548
		private long size;

		// Token: 0x04000DDD RID: 3549
		private int method;

		// Token: 0x04000DDE RID: 3550
		private int flags;

		// Token: 0x04000DDF RID: 3551
		private string password;

		// Token: 0x02000255 RID: 597
		// (Invoke) Token: 0x06001DF3 RID: 7667
		private delegate int ReadDataHandler(byte[] b, int offset, int length);
	}
}
