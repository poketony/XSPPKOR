using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200015D RID: 349
	internal class ZipHelperStream : Stream
	{
		// Token: 0x0600183C RID: 6204 RVA: 0x00133A9A File Offset: 0x00131C9A
		public ZipHelperStream(string name)
		{
			this.stream_ = new FileStream(name, FileMode.Open, FileAccess.ReadWrite);
			this.isOwner_ = true;
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x00133AB7 File Offset: 0x00131CB7
		public ZipHelperStream(Stream stream)
		{
			this.stream_ = stream;
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600183E RID: 6206 RVA: 0x00133AC6 File Offset: 0x00131CC6
		// (set) Token: 0x0600183F RID: 6207 RVA: 0x00133ACE File Offset: 0x00131CCE
		public bool IsStreamOwner
		{
			get
			{
				return this.isOwner_;
			}
			set
			{
				this.isOwner_ = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06001840 RID: 6208 RVA: 0x00133AD7 File Offset: 0x00131CD7
		public override bool CanRead
		{
			get
			{
				return this.stream_.CanRead;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06001841 RID: 6209 RVA: 0x00133AE4 File Offset: 0x00131CE4
		public override bool CanSeek
		{
			get
			{
				return this.stream_.CanSeek;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06001842 RID: 6210 RVA: 0x00133AF1 File Offset: 0x00131CF1
		public override bool CanTimeout
		{
			get
			{
				return this.stream_.CanTimeout;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06001843 RID: 6211 RVA: 0x00133AFE File Offset: 0x00131CFE
		public override long Length
		{
			get
			{
				return this.stream_.Length;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06001844 RID: 6212 RVA: 0x00133B0B File Offset: 0x00131D0B
		// (set) Token: 0x06001845 RID: 6213 RVA: 0x00133B18 File Offset: 0x00131D18
		public override long Position
		{
			get
			{
				return this.stream_.Position;
			}
			set
			{
				this.stream_.Position = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06001846 RID: 6214 RVA: 0x00133B26 File Offset: 0x00131D26
		public override bool CanWrite
		{
			get
			{
				return this.stream_.CanWrite;
			}
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x00133B33 File Offset: 0x00131D33
		public override void Flush()
		{
			this.stream_.Flush();
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x00133B40 File Offset: 0x00131D40
		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_.Seek(offset, origin);
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x00133B4F File Offset: 0x00131D4F
		public override void SetLength(long value)
		{
			this.stream_.SetLength(value);
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x00133B5D File Offset: 0x00131D5D
		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.stream_.Read(buffer, offset, count);
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x00133B6D File Offset: 0x00131D6D
		public override void Write(byte[] buffer, int offset, int count)
		{
			this.stream_.Write(buffer, offset, count);
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x00133B80 File Offset: 0x00131D80
		protected override void Dispose(bool disposing)
		{
			Stream stream = this.stream_;
			this.stream_ = null;
			if (this.isOwner_ && stream != null)
			{
				this.isOwner_ = false;
				stream.Dispose();
			}
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x00133BB4 File Offset: 0x00131DB4
		private void WriteLocalHeader(ZipEntry entry, EntryPatchData patchData)
		{
			CompressionMethod compressionMethod = entry.CompressionMethod;
			bool flag = true;
			bool flag2 = false;
			this.WriteLEInt(67324752);
			this.WriteLEShort(entry.Version);
			this.WriteLEShort(entry.Flags);
			this.WriteLEShort((int)((byte)compressionMethod));
			this.WriteLEInt((int)entry.DosTime);
			if (flag)
			{
				this.WriteLEInt((int)entry.Crc);
				if (entry.LocalHeaderRequiresZip64)
				{
					this.WriteLEInt(-1);
					this.WriteLEInt(-1);
				}
				else
				{
					this.WriteLEInt(entry.IsCrypted ? ((int)entry.CompressedSize + 12) : ((int)entry.CompressedSize));
					this.WriteLEInt((int)entry.Size);
				}
			}
			else
			{
				if (patchData != null)
				{
					patchData.CrcPatchOffset = this.stream_.Position;
				}
				this.WriteLEInt(0);
				if (patchData != null)
				{
					patchData.SizePatchOffset = this.stream_.Position;
				}
				if (entry.LocalHeaderRequiresZip64 && flag2)
				{
					this.WriteLEInt(-1);
					this.WriteLEInt(-1);
				}
				else
				{
					this.WriteLEInt(0);
					this.WriteLEInt(0);
				}
			}
			byte[] array = ZipStrings.ConvertToArray(entry.Flags, entry.Name);
			if (array.Length > 65535)
			{
				throw new ZipException("Entry name too long.");
			}
			ZipExtraData zipExtraData = new ZipExtraData(entry.ExtraData);
			if (entry.LocalHeaderRequiresZip64 && (flag || flag2))
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
				if (patchData != null)
				{
					patchData.SizePatchOffset = (long)zipExtraData.CurrentReadIndex;
				}
			}
			else
			{
				zipExtraData.Delete(1);
			}
			byte[] entryData = zipExtraData.GetEntryData();
			this.WriteLEShort(array.Length);
			this.WriteLEShort(entryData.Length);
			if (array.Length != 0)
			{
				this.stream_.Write(array, 0, array.Length);
			}
			if (entry.LocalHeaderRequiresZip64 && flag2)
			{
				patchData.SizePatchOffset += this.stream_.Position;
			}
			if (entryData.Length != 0)
			{
				this.stream_.Write(entryData, 0, entryData.Length);
			}
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x00133DD4 File Offset: 0x00131FD4
		public long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			long num = endLocation - (long)minimumBlockSize;
			if (num < 0L)
			{
				return -1L;
			}
			long num2 = Math.Max(num - (long)maximumVariableData, 0L);
			while (num >= num2)
			{
				long num3 = num;
				num = num3 - 1L;
				this.Seek(num3, SeekOrigin.Begin);
				if (this.ReadLEInt() == signature)
				{
					return this.Position;
				}
			}
			return -1L;
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x00133E20 File Offset: 0x00132020
		public void WriteZip64EndOfCentralDirectory(long noOfEntries, long sizeEntries, long centralDirOffset)
		{
			long num = centralDirOffset + sizeEntries;
			this.WriteLEInt(101075792);
			this.WriteLELong(44L);
			this.WriteLEShort(51);
			this.WriteLEShort(45);
			this.WriteLEInt(0);
			this.WriteLEInt(0);
			this.WriteLELong(noOfEntries);
			this.WriteLELong(noOfEntries);
			this.WriteLELong(sizeEntries);
			this.WriteLELong(centralDirOffset);
			this.WriteLEInt(117853008);
			this.WriteLEInt(0);
			this.WriteLELong(num);
			this.WriteLEInt(1);
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x00133EA0 File Offset: 0x001320A0
		public void WriteEndOfCentralDirectory(long noOfEntries, long sizeEntries, long startOfCentralDirectory, byte[] comment)
		{
			if (noOfEntries >= 65535L || startOfCentralDirectory >= (long)((ulong)(-1)) || sizeEntries >= (long)((ulong)(-1)))
			{
				this.WriteZip64EndOfCentralDirectory(noOfEntries, sizeEntries, startOfCentralDirectory);
			}
			this.WriteLEInt(101010256);
			this.WriteLEShort(0);
			this.WriteLEShort(0);
			if (noOfEntries >= 65535L)
			{
				this.WriteLEUshort(ushort.MaxValue);
				this.WriteLEUshort(ushort.MaxValue);
			}
			else
			{
				this.WriteLEShort((int)((short)noOfEntries));
				this.WriteLEShort((int)((short)noOfEntries));
			}
			if (sizeEntries >= (long)((ulong)(-1)))
			{
				this.WriteLEUint(uint.MaxValue);
			}
			else
			{
				this.WriteLEInt((int)sizeEntries);
			}
			if (startOfCentralDirectory >= (long)((ulong)(-1)))
			{
				this.WriteLEUint(uint.MaxValue);
			}
			else
			{
				this.WriteLEInt((int)startOfCentralDirectory);
			}
			int num = ((comment != null) ? comment.Length : 0);
			if (num > 65535)
			{
				throw new ZipException(string.Format("Comment length({0}) is too long can only be 64K", num));
			}
			this.WriteLEShort(num);
			if (num > 0)
			{
				this.Write(comment, 0, comment.Length);
			}
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x00133F84 File Offset: 0x00132184
		public int ReadLEShort()
		{
			int num = this.stream_.ReadByte();
			if (num < 0)
			{
				throw new EndOfStreamException();
			}
			int num2 = this.stream_.ReadByte();
			if (num2 < 0)
			{
				throw new EndOfStreamException();
			}
			return num | (num2 << 8);
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x00133FC0 File Offset: 0x001321C0
		public int ReadLEInt()
		{
			return this.ReadLEShort() | (this.ReadLEShort() << 16);
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x00133FD2 File Offset: 0x001321D2
		public long ReadLELong()
		{
			return (long)((ulong)this.ReadLEInt() | (ulong)((ulong)((long)this.ReadLEInt()) << 32));
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x00133FE6 File Offset: 0x001321E6
		public void WriteLEShort(int value)
		{
			this.stream_.WriteByte((byte)(value & 255));
			this.stream_.WriteByte((byte)((value >> 8) & 255));
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x00134010 File Offset: 0x00132210
		public void WriteLEUshort(ushort value)
		{
			this.stream_.WriteByte((byte)(value & 255));
			this.stream_.WriteByte((byte)(value >> 8));
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x00134034 File Offset: 0x00132234
		public void WriteLEInt(int value)
		{
			this.WriteLEShort(value);
			this.WriteLEShort(value >> 16);
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x00134047 File Offset: 0x00132247
		public void WriteLEUint(uint value)
		{
			this.WriteLEUshort((ushort)(value & 65535U));
			this.WriteLEUshort((ushort)(value >> 16));
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x00134062 File Offset: 0x00132262
		public void WriteLELong(long value)
		{
			this.WriteLEInt((int)value);
			this.WriteLEInt((int)(value >> 32));
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00134077 File Offset: 0x00132277
		public void WriteLEUlong(ulong value)
		{
			this.WriteLEUint((uint)(value & (ulong)(-1)));
			this.WriteLEUint((uint)(value >> 32));
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x00134090 File Offset: 0x00132290
		public int WriteDataDescriptor(ZipEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			int num = 0;
			if ((entry.Flags & 8) != 0)
			{
				this.WriteLEInt(134695760);
				this.WriteLEInt((int)entry.Crc);
				num += 8;
				if (entry.LocalHeaderRequiresZip64)
				{
					this.WriteLELong(entry.CompressedSize);
					this.WriteLELong(entry.Size);
					num += 16;
				}
				else
				{
					this.WriteLEInt((int)entry.CompressedSize);
					this.WriteLEInt((int)entry.Size);
					num += 8;
				}
			}
			return num;
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x0013411C File Offset: 0x0013231C
		public void ReadDataDescriptor(bool zip64, DescriptorData data)
		{
			if (this.ReadLEInt() != 134695760)
			{
				throw new ZipException("Data descriptor signature not found");
			}
			data.Crc = (long)this.ReadLEInt();
			if (zip64)
			{
				data.CompressedSize = this.ReadLELong();
				data.Size = this.ReadLELong();
				return;
			}
			data.CompressedSize = (long)this.ReadLEInt();
			data.Size = (long)this.ReadLEInt();
		}

		// Token: 0x04000DD7 RID: 3543
		private bool isOwner_;

		// Token: 0x04000DD8 RID: 3544
		private Stream stream_;
	}
}
