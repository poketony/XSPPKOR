using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000160 RID: 352
	public class ZipOutputStream : DeflaterOutputStream
	{
		// Token: 0x06001878 RID: 6264 RVA: 0x00134F10 File Offset: 0x00133110
		public ZipOutputStream(Stream baseOutputStream)
			: base(baseOutputStream, new Deflater(-1, true))
		{
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x00134F74 File Offset: 0x00133174
		public ZipOutputStream(Stream baseOutputStream, int bufferSize)
			: base(baseOutputStream, new Deflater(-1, true), bufferSize)
		{
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x00134FD7 File Offset: 0x001331D7
		public bool IsFinished
		{
			get
			{
				return this.entries == null;
			}
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00134FE4 File Offset: 0x001331E4
		public void SetComment(string comment)
		{
			byte[] array = ZipStrings.ConvertToArray(comment);
			if (array.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("comment");
			}
			this.zipComment = array;
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x00135014 File Offset: 0x00133214
		public void SetLevel(int level)
		{
			this.deflater_.SetLevel(level);
			this.defaultCompressionLevel = level;
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x00135029 File Offset: 0x00133229
		public int GetLevel()
		{
			return this.deflater_.GetLevel();
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600187E RID: 6270 RVA: 0x00135036 File Offset: 0x00133236
		// (set) Token: 0x0600187F RID: 6271 RVA: 0x0013503E File Offset: 0x0013323E
		public UseZip64 UseZip64
		{
			get
			{
				return this.useZip64_;
			}
			set
			{
				this.useZip64_ = value;
			}
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x00135047 File Offset: 0x00133247
		private void WriteLeShort(int value)
		{
			this.baseOutputStream_.WriteByte((byte)(value & 255));
			this.baseOutputStream_.WriteByte((byte)((value >> 8) & 255));
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x00135071 File Offset: 0x00133271
		private void WriteLeInt(int value)
		{
			this.WriteLeShort(value);
			this.WriteLeShort(value >> 16);
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x00135084 File Offset: 0x00133284
		private void WriteLeLong(long value)
		{
			this.WriteLeInt((int)value);
			this.WriteLeInt((int)(value >> 32));
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x0013509C File Offset: 0x0013329C
		public void PutNextEntry(ZipEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (this.entries == null)
			{
				throw new InvalidOperationException("ZipOutputStream was finished");
			}
			if (this.curEntry != null)
			{
				this.CloseEntry();
			}
			if (this.entries.Count == 2147483647)
			{
				throw new ZipException("Too many entries for Zip file");
			}
			CompressionMethod compressionMethod = entry.CompressionMethod;
			int num = this.defaultCompressionLevel;
			entry.Flags &= 2048;
			this.patchEntryHeader = false;
			bool flag;
			if (entry.Size == 0L)
			{
				entry.CompressedSize = entry.Size;
				entry.Crc = 0L;
				compressionMethod = CompressionMethod.Stored;
				flag = true;
			}
			else
			{
				flag = entry.Size >= 0L && entry.HasCrc && entry.CompressedSize >= 0L;
				if (compressionMethod == CompressionMethod.Stored)
				{
					if (!flag)
					{
						if (!base.CanPatchEntries)
						{
							compressionMethod = CompressionMethod.Deflated;
							num = 0;
						}
					}
					else
					{
						entry.CompressedSize = entry.Size;
						flag = entry.HasCrc;
					}
				}
			}
			if (!flag)
			{
				if (!base.CanPatchEntries)
				{
					entry.Flags |= 8;
				}
				else
				{
					this.patchEntryHeader = true;
				}
			}
			if (base.Password != null)
			{
				entry.IsCrypted = true;
				if (entry.Crc < 0L)
				{
					entry.Flags |= 8;
				}
			}
			entry.Offset = this.offset;
			entry.CompressionMethod = compressionMethod;
			this.curMethod = compressionMethod;
			this.sizePatchPos = -1L;
			if (this.useZip64_ == UseZip64.On || (entry.Size < 0L && this.useZip64_ == UseZip64.Dynamic))
			{
				entry.ForceZip64();
			}
			this.WriteLeInt(67324752);
			this.WriteLeShort(entry.Version);
			this.WriteLeShort(entry.Flags);
			this.WriteLeShort((int)((byte)entry.CompressionMethodForHeader));
			this.WriteLeInt((int)entry.DosTime);
			if (flag)
			{
				this.WriteLeInt((int)entry.Crc);
				if (entry.LocalHeaderRequiresZip64)
				{
					this.WriteLeInt(-1);
					this.WriteLeInt(-1);
				}
				else
				{
					this.WriteLeInt(entry.IsCrypted ? ((int)entry.CompressedSize + 12) : ((int)entry.CompressedSize));
					this.WriteLeInt((int)entry.Size);
				}
			}
			else
			{
				if (this.patchEntryHeader)
				{
					this.crcPatchPos = this.baseOutputStream_.Position;
				}
				this.WriteLeInt(0);
				if (this.patchEntryHeader)
				{
					this.sizePatchPos = this.baseOutputStream_.Position;
				}
				if (entry.LocalHeaderRequiresZip64 || this.patchEntryHeader)
				{
					this.WriteLeInt(-1);
					this.WriteLeInt(-1);
				}
				else
				{
					this.WriteLeInt(0);
					this.WriteLeInt(0);
				}
			}
			byte[] array = ZipStrings.ConvertToArray(entry.Flags, entry.Name);
			if (array.Length > 65535)
			{
				throw new ZipException("Entry name too long.");
			}
			ZipExtraData zipExtraData = new ZipExtraData(entry.ExtraData);
			if (entry.LocalHeaderRequiresZip64)
			{
				zipExtraData.StartNewEntry();
				if (flag)
				{
					zipExtraData.AddLeLong(entry.Size);
					zipExtraData.AddLeLong(entry.CompressedSize);
				}
				else
				{
					zipExtraData.AddLeLong(-1L);
					zipExtraData.AddLeLong(-1L);
				}
				zipExtraData.AddNewEntry(1);
				if (!zipExtraData.Find(1))
				{
					throw new ZipException("Internal error cant find extra data");
				}
				if (this.patchEntryHeader)
				{
					this.sizePatchPos = (long)zipExtraData.CurrentReadIndex;
				}
			}
			else
			{
				zipExtraData.Delete(1);
			}
			if (entry.AESKeySize > 0)
			{
				ZipOutputStream.AddExtraDataAES(entry, zipExtraData);
			}
			byte[] entryData = zipExtraData.GetEntryData();
			this.WriteLeShort(array.Length);
			this.WriteLeShort(entryData.Length);
			if (array.Length != 0)
			{
				this.baseOutputStream_.Write(array, 0, array.Length);
			}
			if (entry.LocalHeaderRequiresZip64 && this.patchEntryHeader)
			{
				this.sizePatchPos += this.baseOutputStream_.Position;
			}
			if (entryData.Length != 0)
			{
				this.baseOutputStream_.Write(entryData, 0, entryData.Length);
			}
			this.offset += (long)(30 + array.Length + entryData.Length);
			if (entry.AESKeySize > 0)
			{
				this.offset += (long)entry.AESOverheadSize;
			}
			this.curEntry = entry;
			this.crc.Reset();
			if (compressionMethod == CompressionMethod.Deflated)
			{
				this.deflater_.Reset();
				this.deflater_.SetLevel(num);
			}
			this.size = 0L;
			if (entry.IsCrypted)
			{
				if (entry.AESKeySize > 0)
				{
					this.WriteAESHeader(entry);
					return;
				}
				if (entry.Crc < 0L)
				{
					this.WriteEncryptionHeader(entry.DosTime << 16);
					return;
				}
				this.WriteEncryptionHeader(entry.Crc);
			}
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x001354F0 File Offset: 0x001336F0
		public void CloseEntry()
		{
			if (this.curEntry == null)
			{
				throw new InvalidOperationException("No open entry");
			}
			long totalOut = this.size;
			if (this.curMethod == CompressionMethod.Deflated)
			{
				if (this.size >= 0L)
				{
					base.Finish();
					totalOut = this.deflater_.TotalOut;
				}
				else
				{
					this.deflater_.Reset();
				}
			}
			else if (this.curMethod == CompressionMethod.Stored)
			{
				base.GetAuthCodeIfAES();
			}
			if (this.curEntry.AESKeySize > 0)
			{
				this.baseOutputStream_.Write(this.AESAuthCode, 0, 10);
			}
			if (this.curEntry.Size < 0L)
			{
				this.curEntry.Size = this.size;
			}
			else if (this.curEntry.Size != this.size)
			{
				throw new ZipException("size was " + this.size.ToString() + ", but I expected " + this.curEntry.Size.ToString());
			}
			if (this.curEntry.CompressedSize < 0L)
			{
				this.curEntry.CompressedSize = totalOut;
			}
			else if (this.curEntry.CompressedSize != totalOut)
			{
				throw new ZipException("compressed size was " + totalOut.ToString() + ", but I expected " + this.curEntry.CompressedSize.ToString());
			}
			if (this.curEntry.Crc < 0L)
			{
				this.curEntry.Crc = this.crc.Value;
			}
			else if (this.curEntry.Crc != this.crc.Value)
			{
				throw new ZipException("crc was " + this.crc.Value.ToString() + ", but I expected " + this.curEntry.Crc.ToString());
			}
			this.offset += totalOut;
			if (this.curEntry.IsCrypted)
			{
				if (this.curEntry.AESKeySize > 0)
				{
					this.curEntry.CompressedSize += (long)this.curEntry.AESOverheadSize;
				}
				else
				{
					this.curEntry.CompressedSize += 12L;
				}
			}
			if (this.patchEntryHeader)
			{
				this.patchEntryHeader = false;
				long position = this.baseOutputStream_.Position;
				this.baseOutputStream_.Seek(this.crcPatchPos, SeekOrigin.Begin);
				this.WriteLeInt((int)this.curEntry.Crc);
				if (this.curEntry.LocalHeaderRequiresZip64)
				{
					if (this.sizePatchPos == -1L)
					{
						throw new ZipException("Entry requires zip64 but this has been turned off");
					}
					this.baseOutputStream_.Seek(this.sizePatchPos, SeekOrigin.Begin);
					this.WriteLeLong(this.curEntry.Size);
					this.WriteLeLong(this.curEntry.CompressedSize);
				}
				else
				{
					this.WriteLeInt((int)this.curEntry.CompressedSize);
					this.WriteLeInt((int)this.curEntry.Size);
				}
				this.baseOutputStream_.Seek(position, SeekOrigin.Begin);
			}
			if ((this.curEntry.Flags & 8) != 0)
			{
				this.WriteLeInt(134695760);
				this.WriteLeInt((int)this.curEntry.Crc);
				if (this.curEntry.LocalHeaderRequiresZip64)
				{
					this.WriteLeLong(this.curEntry.CompressedSize);
					this.WriteLeLong(this.curEntry.Size);
					this.offset += 24L;
				}
				else
				{
					this.WriteLeInt((int)this.curEntry.CompressedSize);
					this.WriteLeInt((int)this.curEntry.Size);
					this.offset += 16L;
				}
			}
			this.entries.Add(this.curEntry);
			this.curEntry = null;
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x001358A0 File Offset: 0x00133AA0
		private void WriteEncryptionHeader(long crcValue)
		{
			this.offset += 12L;
			base.InitializePassword(base.Password);
			byte[] array = new byte[12];
			new Random().NextBytes(array);
			array[11] = (byte)(crcValue >> 24);
			base.EncryptBlock(array, 0, array.Length);
			this.baseOutputStream_.Write(array, 0, array.Length);
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00135900 File Offset: 0x00133B00
		private static void AddExtraDataAES(ZipEntry entry, ZipExtraData extraData)
		{
			extraData.StartNewEntry();
			extraData.AddLeShort(2);
			extraData.AddLeShort(17729);
			extraData.AddData(entry.AESEncryptionStrength);
			extraData.AddLeShort((int)entry.CompressionMethod);
			extraData.AddNewEntry(39169);
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x00135940 File Offset: 0x00133B40
		private void WriteAESHeader(ZipEntry entry)
		{
			byte[] array;
			byte[] array2;
			base.InitializeAESPassword(entry, base.Password, out array, out array2);
			this.baseOutputStream_.Write(array, 0, array.Length);
			this.baseOutputStream_.Write(array2, 0, array2.Length);
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00135980 File Offset: 0x00133B80
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.curEntry == null)
			{
				throw new InvalidOperationException("No open entry.");
			}
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
			this.crc.Update(new ArraySegment<byte>(buffer, offset, count));
			this.size += (long)count;
			CompressionMethod compressionMethod = this.curMethod;
			if (compressionMethod != CompressionMethod.Stored)
			{
				if (compressionMethod == CompressionMethod.Deflated)
				{
					base.Write(buffer, offset, count);
					return;
				}
			}
			else
			{
				if (base.Password != null)
				{
					this.CopyAndEncrypt(buffer, offset, count);
					return;
				}
				this.baseOutputStream_.Write(buffer, offset, count);
			}
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00135A44 File Offset: 0x00133C44
		private void CopyAndEncrypt(byte[] buffer, int offset, int count)
		{
			byte[] array = new byte[4096];
			while (count > 0)
			{
				int num = ((count < 4096) ? count : 4096);
				Array.Copy(buffer, offset, array, 0, num);
				base.EncryptBlock(array, 0, num);
				this.baseOutputStream_.Write(array, 0, num);
				count -= num;
				offset += num;
			}
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x00135AA0 File Offset: 0x00133CA0
		public override void Finish()
		{
			if (this.entries == null)
			{
				return;
			}
			if (this.curEntry != null)
			{
				this.CloseEntry();
			}
			long num = (long)this.entries.Count;
			long num2 = 0L;
			foreach (ZipEntry zipEntry in this.entries)
			{
				this.WriteLeInt(33639248);
				this.WriteLeShort((zipEntry.HostSystem << 8) | zipEntry.VersionMadeBy);
				this.WriteLeShort(zipEntry.Version);
				this.WriteLeShort(zipEntry.Flags);
				this.WriteLeShort((int)((short)zipEntry.CompressionMethodForHeader));
				this.WriteLeInt((int)zipEntry.DosTime);
				this.WriteLeInt((int)zipEntry.Crc);
				if (zipEntry.IsZip64Forced() || zipEntry.CompressedSize >= (long)((ulong)(-1)))
				{
					this.WriteLeInt(-1);
				}
				else
				{
					this.WriteLeInt((int)zipEntry.CompressedSize);
				}
				if (zipEntry.IsZip64Forced() || zipEntry.Size >= (long)((ulong)(-1)))
				{
					this.WriteLeInt(-1);
				}
				else
				{
					this.WriteLeInt((int)zipEntry.Size);
				}
				byte[] array = ZipStrings.ConvertToArray(zipEntry.Flags, zipEntry.Name);
				if (array.Length > 65535)
				{
					throw new ZipException("Name too long.");
				}
				ZipExtraData zipExtraData = new ZipExtraData(zipEntry.ExtraData);
				if (zipEntry.CentralHeaderRequiresZip64)
				{
					zipExtraData.StartNewEntry();
					if (zipEntry.IsZip64Forced() || zipEntry.Size >= (long)((ulong)(-1)))
					{
						zipExtraData.AddLeLong(zipEntry.Size);
					}
					if (zipEntry.IsZip64Forced() || zipEntry.CompressedSize >= (long)((ulong)(-1)))
					{
						zipExtraData.AddLeLong(zipEntry.CompressedSize);
					}
					if (zipEntry.Offset >= (long)((ulong)(-1)))
					{
						zipExtraData.AddLeLong(zipEntry.Offset);
					}
					zipExtraData.AddNewEntry(1);
				}
				else
				{
					zipExtraData.Delete(1);
				}
				if (zipEntry.AESKeySize > 0)
				{
					ZipOutputStream.AddExtraDataAES(zipEntry, zipExtraData);
				}
				byte[] entryData = zipExtraData.GetEntryData();
				byte[] array2 = ((zipEntry.Comment != null) ? ZipStrings.ConvertToArray(zipEntry.Flags, zipEntry.Comment) : new byte[0]);
				if (array2.Length > 65535)
				{
					throw new ZipException("Comment too long.");
				}
				this.WriteLeShort(array.Length);
				this.WriteLeShort(entryData.Length);
				this.WriteLeShort(array2.Length);
				this.WriteLeShort(0);
				this.WriteLeShort(0);
				if (zipEntry.ExternalFileAttributes != -1)
				{
					this.WriteLeInt(zipEntry.ExternalFileAttributes);
				}
				else if (zipEntry.IsDirectory)
				{
					this.WriteLeInt(16);
				}
				else
				{
					this.WriteLeInt(0);
				}
				if (zipEntry.Offset >= (long)((ulong)(-1)))
				{
					this.WriteLeInt(-1);
				}
				else
				{
					this.WriteLeInt((int)zipEntry.Offset);
				}
				if (array.Length != 0)
				{
					this.baseOutputStream_.Write(array, 0, array.Length);
				}
				if (entryData.Length != 0)
				{
					this.baseOutputStream_.Write(entryData, 0, entryData.Length);
				}
				if (array2.Length != 0)
				{
					this.baseOutputStream_.Write(array2, 0, array2.Length);
				}
				num2 += (long)(46 + array.Length + entryData.Length + array2.Length);
			}
			using (ZipHelperStream zipHelperStream = new ZipHelperStream(this.baseOutputStream_))
			{
				zipHelperStream.WriteEndOfCentralDirectory(num, num2, this.offset, this.zipComment);
			}
			this.entries = null;
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00135DFC File Offset: 0x00133FFC
		public override void Flush()
		{
			if (this.curMethod == CompressionMethod.Stored)
			{
				this.baseOutputStream_.Flush();
				return;
			}
			base.Flush();
		}

		// Token: 0x04000DE3 RID: 3555
		private List<ZipEntry> entries = new List<ZipEntry>();

		// Token: 0x04000DE4 RID: 3556
		private Crc32 crc = new Crc32();

		// Token: 0x04000DE5 RID: 3557
		private ZipEntry curEntry;

		// Token: 0x04000DE6 RID: 3558
		private int defaultCompressionLevel = -1;

		// Token: 0x04000DE7 RID: 3559
		private CompressionMethod curMethod = CompressionMethod.Deflated;

		// Token: 0x04000DE8 RID: 3560
		private long size;

		// Token: 0x04000DE9 RID: 3561
		private long offset;

		// Token: 0x04000DEA RID: 3562
		private byte[] zipComment = new byte[0];

		// Token: 0x04000DEB RID: 3563
		private bool patchEntryHeader;

		// Token: 0x04000DEC RID: 3564
		private long crcPatchPos = -1L;

		// Token: 0x04000DED RID: 3565
		private long sizePatchPos = -1L;

		// Token: 0x04000DEE RID: 3566
		private UseZip64 useZip64_ = UseZip64.Dynamic;
	}
}
