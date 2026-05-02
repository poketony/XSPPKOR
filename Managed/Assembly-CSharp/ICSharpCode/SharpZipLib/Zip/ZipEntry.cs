using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000143 RID: 323
	public class ZipEntry
	{
		// Token: 0x060016FB RID: 5883 RVA: 0x0012EA73 File Offset: 0x0012CC73
		public ZipEntry(string name)
			: this(name, 0, 51, CompressionMethod.Deflated)
		{
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x0012EA80 File Offset: 0x0012CC80
		internal ZipEntry(string name, int versionRequiredToExtract)
			: this(name, versionRequiredToExtract, 51, CompressionMethod.Deflated)
		{
		}

		// Token: 0x060016FD RID: 5885 RVA: 0x0012EA90 File Offset: 0x0012CC90
		internal ZipEntry(string name, int versionRequiredToExtract, int madeByInfo, CompressionMethod method)
		{
			this.externalFileAttributes = -1;
			this.method = CompressionMethod.Deflated;
			this.zipFileIndex = -1L;
			base..ctor();
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length > 65535)
			{
				throw new ArgumentException("Name is too long", "name");
			}
			if (versionRequiredToExtract != 0 && versionRequiredToExtract < 10)
			{
				throw new ArgumentOutOfRangeException("versionRequiredToExtract");
			}
			this.DateTime = DateTime.Now;
			this.name = name;
			this.versionMadeBy = (ushort)madeByInfo;
			this.versionToExtract = (ushort)versionRequiredToExtract;
			this.method = method;
			this.IsUnicodeText = ZipStrings.UseUnicode;
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x0012EB2C File Offset: 0x0012CD2C
		[Obsolete("Use Clone instead")]
		public ZipEntry(ZipEntry entry)
		{
			this.externalFileAttributes = -1;
			this.method = CompressionMethod.Deflated;
			this.zipFileIndex = -1L;
			base..ctor();
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			this.known = entry.known;
			this.name = entry.name;
			this.size = entry.size;
			this.compressedSize = entry.compressedSize;
			this.crc = entry.crc;
			this.dosTime = entry.dosTime;
			this.method = entry.method;
			this.comment = entry.comment;
			this.versionToExtract = entry.versionToExtract;
			this.versionMadeBy = entry.versionMadeBy;
			this.externalFileAttributes = entry.externalFileAttributes;
			this.flags = entry.flags;
			this.zipFileIndex = entry.zipFileIndex;
			this.offset = entry.offset;
			this.forceZip64_ = entry.forceZip64_;
			if (entry.extra != null)
			{
				this.extra = new byte[entry.extra.Length];
				Array.Copy(entry.extra, 0, this.extra, 0, entry.extra.Length);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060016FF RID: 5887 RVA: 0x0012EC4D File Offset: 0x0012CE4D
		public bool HasCrc
		{
			get
			{
				return (this.known & ZipEntry.Known.Crc) > ZipEntry.Known.None;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06001700 RID: 5888 RVA: 0x0012EC5A File Offset: 0x0012CE5A
		// (set) Token: 0x06001701 RID: 5889 RVA: 0x0012EC67 File Offset: 0x0012CE67
		public bool IsCrypted
		{
			get
			{
				return (this.flags & 1) != 0;
			}
			set
			{
				if (value)
				{
					this.flags |= 1;
					return;
				}
				this.flags &= -2;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x0012EC8A File Offset: 0x0012CE8A
		// (set) Token: 0x06001703 RID: 5891 RVA: 0x0012EC9B File Offset: 0x0012CE9B
		public bool IsUnicodeText
		{
			get
			{
				return (this.flags & 2048) != 0;
			}
			set
			{
				if (value)
				{
					this.flags |= 2048;
					return;
				}
				this.flags &= -2049;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0012ECC5 File Offset: 0x0012CEC5
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x0012ECCD File Offset: 0x0012CECD
		internal byte CryptoCheckValue
		{
			get
			{
				return this.cryptoCheckValue_;
			}
			set
			{
				this.cryptoCheckValue_ = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x0012ECD6 File Offset: 0x0012CED6
		// (set) Token: 0x06001707 RID: 5895 RVA: 0x0012ECDE File Offset: 0x0012CEDE
		public int Flags
		{
			get
			{
				return this.flags;
			}
			set
			{
				this.flags = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x0012ECE7 File Offset: 0x0012CEE7
		// (set) Token: 0x06001709 RID: 5897 RVA: 0x0012ECEF File Offset: 0x0012CEEF
		public long ZipFileIndex
		{
			get
			{
				return this.zipFileIndex;
			}
			set
			{
				this.zipFileIndex = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x0012ECF8 File Offset: 0x0012CEF8
		// (set) Token: 0x0600170B RID: 5899 RVA: 0x0012ED00 File Offset: 0x0012CF00
		public long Offset
		{
			get
			{
				return this.offset;
			}
			set
			{
				this.offset = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600170C RID: 5900 RVA: 0x0012ED09 File Offset: 0x0012CF09
		// (set) Token: 0x0600170D RID: 5901 RVA: 0x0012ED1E File Offset: 0x0012CF1E
		public int ExternalFileAttributes
		{
			get
			{
				if ((this.known & ZipEntry.Known.ExternalAttributes) == ZipEntry.Known.None)
				{
					return -1;
				}
				return this.externalFileAttributes;
			}
			set
			{
				this.externalFileAttributes = value;
				this.known |= ZipEntry.Known.ExternalAttributes;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600170E RID: 5902 RVA: 0x0012ED36 File Offset: 0x0012CF36
		public int VersionMadeBy
		{
			get
			{
				return (int)(this.versionMadeBy & 255);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600170F RID: 5903 RVA: 0x0012ED44 File Offset: 0x0012CF44
		public bool IsDOSEntry
		{
			get
			{
				return this.HostSystem == 0 || this.HostSystem == 10;
			}
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x0012ED5C File Offset: 0x0012CF5C
		private bool HasDosAttributes(int attributes)
		{
			bool flag = false;
			if ((this.known & ZipEntry.Known.ExternalAttributes) != ZipEntry.Known.None)
			{
				flag |= (this.HostSystem == 0 || this.HostSystem == 10) && (this.ExternalFileAttributes & attributes) == attributes;
			}
			return flag;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06001711 RID: 5905 RVA: 0x0012ED9A File Offset: 0x0012CF9A
		// (set) Token: 0x06001712 RID: 5906 RVA: 0x0012EDAA File Offset: 0x0012CFAA
		public int HostSystem
		{
			get
			{
				return (this.versionMadeBy >> 8) & 255;
			}
			set
			{
				this.versionMadeBy &= 255;
				this.versionMadeBy |= (ushort)((value & 255) << 8);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06001713 RID: 5907 RVA: 0x0012EDD8 File Offset: 0x0012CFD8
		public int Version
		{
			get
			{
				if (this.versionToExtract != 0)
				{
					return (int)(this.versionToExtract & 255);
				}
				int num = 10;
				if (this.AESKeySize > 0)
				{
					num = 51;
				}
				else if (this.CentralHeaderRequiresZip64)
				{
					num = 45;
				}
				else if (CompressionMethod.Deflated == this.method)
				{
					num = 20;
				}
				else if (this.IsDirectory)
				{
					num = 20;
				}
				else if (this.IsCrypted)
				{
					num = 20;
				}
				else if (this.HasDosAttributes(8))
				{
					num = 11;
				}
				return num;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x0012EE50 File Offset: 0x0012D050
		public bool CanDecompress
		{
			get
			{
				return this.Version <= 51 && (this.Version == 10 || this.Version == 11 || this.Version == 20 || this.Version == 45 || this.Version == 51) && this.IsCompressionMethodSupported();
			}
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x0012EEA1 File Offset: 0x0012D0A1
		public void ForceZip64()
		{
			this.forceZip64_ = true;
		}

		// Token: 0x06001716 RID: 5910 RVA: 0x0012EEAA File Offset: 0x0012D0AA
		public bool IsZip64Forced()
		{
			return this.forceZip64_;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06001717 RID: 5911 RVA: 0x0012EEB4 File Offset: 0x0012D0B4
		public bool LocalHeaderRequiresZip64
		{
			get
			{
				bool flag = this.forceZip64_;
				if (!flag)
				{
					ulong num = this.compressedSize;
					if (this.versionToExtract == 0 && this.IsCrypted)
					{
						num += 12UL;
					}
					flag = (this.size >= (ulong)(-1) || num >= (ulong)(-1)) && (this.versionToExtract == 0 || this.versionToExtract >= 45);
				}
				return flag;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0012EF14 File Offset: 0x0012D114
		public bool CentralHeaderRequiresZip64
		{
			get
			{
				return this.LocalHeaderRequiresZip64 || this.offset >= (long)((ulong)(-1));
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x0012EF2D File Offset: 0x0012D12D
		// (set) Token: 0x0600171A RID: 5914 RVA: 0x0012EF43 File Offset: 0x0012D143
		public long DosTime
		{
			get
			{
				if ((this.known & ZipEntry.Known.Time) == ZipEntry.Known.None)
				{
					return 0L;
				}
				return (long)((ulong)this.dosTime);
			}
			set
			{
				this.dosTime = (uint)value;
				this.known |= ZipEntry.Known.Time;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x0012EF5C File Offset: 0x0012D15C
		// (set) Token: 0x0600171C RID: 5916 RVA: 0x0012F000 File Offset: 0x0012D200
		public DateTime DateTime
		{
			get
			{
				uint num = Math.Min(59U, 2U * (this.dosTime & 31U));
				uint num2 = Math.Min(59U, (this.dosTime >> 5) & 63U);
				uint num3 = Math.Min(23U, (this.dosTime >> 11) & 31U);
				uint num4 = Math.Max(1U, Math.Min(12U, (this.dosTime >> 21) & 15U));
				uint num5 = ((this.dosTime >> 25) & 127U) + 1980U;
				int num6 = Math.Max(1, Math.Min(DateTime.DaysInMonth((int)num5, (int)num4), (int)((this.dosTime >> 16) & 31U)));
				return new DateTime((int)num5, (int)num4, num6, (int)num3, (int)num2, (int)num);
			}
			set
			{
				uint num = (uint)value.Year;
				uint num2 = (uint)value.Month;
				uint num3 = (uint)value.Day;
				uint num4 = (uint)value.Hour;
				uint num5 = (uint)value.Minute;
				uint num6 = (uint)value.Second;
				if (num < 1980U)
				{
					num = 1980U;
					num2 = 1U;
					num3 = 1U;
					num4 = 0U;
					num5 = 0U;
					num6 = 0U;
				}
				else if (num > 2107U)
				{
					num = 2107U;
					num2 = 12U;
					num3 = 31U;
					num4 = 23U;
					num5 = 59U;
					num6 = 59U;
				}
				this.DosTime = (long)((ulong)((((num - 1980U) & 127U) << 25) | (num2 << 21) | (num3 << 16) | (num4 << 11) | (num5 << 5) | (num6 >> 1)));
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600171D RID: 5917 RVA: 0x0012F0A7 File Offset: 0x0012D2A7
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x0012F0AF File Offset: 0x0012D2AF
		// (set) Token: 0x0600171F RID: 5919 RVA: 0x0012F0C4 File Offset: 0x0012D2C4
		public long Size
		{
			get
			{
				if ((this.known & ZipEntry.Known.Size) == ZipEntry.Known.None)
				{
					return -1L;
				}
				return (long)this.size;
			}
			set
			{
				this.size = (ulong)value;
				this.known |= ZipEntry.Known.Size;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06001720 RID: 5920 RVA: 0x0012F0DB File Offset: 0x0012D2DB
		// (set) Token: 0x06001721 RID: 5921 RVA: 0x0012F0F0 File Offset: 0x0012D2F0
		public long CompressedSize
		{
			get
			{
				if ((this.known & ZipEntry.Known.CompressedSize) == ZipEntry.Known.None)
				{
					return -1L;
				}
				return (long)this.compressedSize;
			}
			set
			{
				this.compressedSize = (ulong)value;
				this.known |= ZipEntry.Known.CompressedSize;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x0012F107 File Offset: 0x0012D307
		// (set) Token: 0x06001723 RID: 5923 RVA: 0x0012F120 File Offset: 0x0012D320
		public long Crc
		{
			get
			{
				if ((this.known & ZipEntry.Known.Crc) == ZipEntry.Known.None)
				{
					return -1L;
				}
				return (long)((ulong)this.crc & (ulong)(-1));
			}
			set
			{
				if (((ulong)this.crc & 18446744069414584320UL) != 0UL)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.crc = (uint)value;
				this.known |= ZipEntry.Known.Crc;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0012F156 File Offset: 0x0012D356
		// (set) Token: 0x06001725 RID: 5925 RVA: 0x0012F15E File Offset: 0x0012D35E
		public CompressionMethod CompressionMethod
		{
			get
			{
				return this.method;
			}
			set
			{
				if (!ZipEntry.IsCompressionMethodSupported(value))
				{
					throw new NotSupportedException("Compression method not supported");
				}
				this.method = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06001726 RID: 5926 RVA: 0x0012F17A File Offset: 0x0012D37A
		internal CompressionMethod CompressionMethodForHeader
		{
			get
			{
				if (this.AESKeySize <= 0)
				{
					return this.method;
				}
				return CompressionMethod.WinZipAES;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x0012F18E File Offset: 0x0012D38E
		// (set) Token: 0x06001728 RID: 5928 RVA: 0x0012F198 File Offset: 0x0012D398
		public byte[] ExtraData
		{
			get
			{
				return this.extra;
			}
			set
			{
				if (value == null)
				{
					this.extra = null;
					return;
				}
				if (value.Length > 65535)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.extra = new byte[value.Length];
				Array.Copy(value, 0, this.extra, 0, value.Length);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x0012F1E4 File Offset: 0x0012D3E4
		// (set) Token: 0x0600172A RID: 5930 RVA: 0x0012F240 File Offset: 0x0012D440
		public int AESKeySize
		{
			get
			{
				switch (this._aesEncryptionStrength)
				{
				case 0:
					return 0;
				case 1:
					return 128;
				case 2:
					return 192;
				case 3:
					return 256;
				default:
					throw new ZipException("Invalid AESEncryptionStrength " + this._aesEncryptionStrength.ToString());
				}
			}
			set
			{
				if (value == 0)
				{
					this._aesEncryptionStrength = 0;
					return;
				}
				if (value == 128)
				{
					this._aesEncryptionStrength = 1;
					return;
				}
				if (value != 256)
				{
					throw new ZipException("AESKeySize must be 0, 128 or 256: " + value.ToString());
				}
				this._aesEncryptionStrength = 3;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600172B RID: 5931 RVA: 0x0012F290 File Offset: 0x0012D490
		internal byte AESEncryptionStrength
		{
			get
			{
				return (byte)this._aesEncryptionStrength;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600172C RID: 5932 RVA: 0x0012F299 File Offset: 0x0012D499
		internal int AESSaltLen
		{
			get
			{
				return this.AESKeySize / 16;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600172D RID: 5933 RVA: 0x0012F2A4 File Offset: 0x0012D4A4
		internal int AESOverheadSize
		{
			get
			{
				return 12 + this.AESSaltLen;
			}
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x0012F2B0 File Offset: 0x0012D4B0
		internal void ProcessExtraData(bool localHeader)
		{
			ZipExtraData zipExtraData = new ZipExtraData(this.extra);
			if (zipExtraData.Find(1))
			{
				this.forceZip64_ = true;
				if (zipExtraData.ValueLength < 4)
				{
					throw new ZipException("Extra data extended Zip64 information length is invalid");
				}
				if (this.size == (ulong)(-1))
				{
					this.size = (ulong)zipExtraData.ReadLong();
				}
				if (this.compressedSize == (ulong)(-1))
				{
					this.compressedSize = (ulong)zipExtraData.ReadLong();
				}
				if (!localHeader && this.offset == (long)((ulong)(-1)))
				{
					this.offset = zipExtraData.ReadLong();
				}
			}
			else if ((this.versionToExtract & 255) >= 45 && (this.size == (ulong)(-1) || this.compressedSize == (ulong)(-1)))
			{
				throw new ZipException("Zip64 Extended information required but is missing.");
			}
			this.DateTime = this.GetDateTime(zipExtraData);
			if (this.method == CompressionMethod.WinZipAES)
			{
				this.ProcessAESExtraData(zipExtraData);
			}
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x0012F384 File Offset: 0x0012D584
		private DateTime GetDateTime(ZipExtraData extraData)
		{
			ExtendedUnixData data = extraData.GetData<ExtendedUnixData>();
			if (data != null && (data.Include & ExtendedUnixData.Flags.ModificationTime) != (ExtendedUnixData.Flags)0 && (data.Include & ExtendedUnixData.Flags.AccessTime) != (ExtendedUnixData.Flags)0 && (data.Include & ExtendedUnixData.Flags.CreateTime) != (ExtendedUnixData.Flags)0)
			{
				return data.ModificationTime;
			}
			uint num = Math.Min(59U, 2U * (this.dosTime & 31U));
			uint num2 = Math.Min(59U, (this.dosTime >> 5) & 63U);
			uint num3 = Math.Min(23U, (this.dosTime >> 11) & 31U);
			uint num4 = Math.Max(1U, Math.Min(12U, (this.dosTime >> 21) & 15U));
			uint num5 = ((this.dosTime >> 25) & 127U) + 1980U;
			int num6 = Math.Max(1, Math.Min(DateTime.DaysInMonth((int)num5, (int)num4), (int)((this.dosTime >> 16) & 31U)));
			return new DateTime((int)num5, (int)num4, num6, (int)num3, (int)num2, (int)num, DateTimeKind.Utc);
		}

		// Token: 0x06001730 RID: 5936 RVA: 0x0012F45C File Offset: 0x0012D65C
		private void ProcessAESExtraData(ZipExtraData extraData)
		{
			if (!extraData.Find(39169))
			{
				throw new ZipException("AES Extra Data missing");
			}
			this.versionToExtract = 51;
			int valueLength = extraData.ValueLength;
			if (valueLength < 7)
			{
				throw new ZipException("AES Extra Data Length " + valueLength.ToString() + " invalid.");
			}
			int num = extraData.ReadShort();
			extraData.ReadShort();
			int num2 = extraData.ReadByte();
			int num3 = extraData.ReadShort();
			this._aesVer = num;
			this._aesEncryptionStrength = num2;
			this.method = (CompressionMethod)num3;
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06001731 RID: 5937 RVA: 0x0012F4E1 File Offset: 0x0012D6E1
		// (set) Token: 0x06001732 RID: 5938 RVA: 0x0012F4E9 File Offset: 0x0012D6E9
		public string Comment
		{
			get
			{
				return this.comment;
			}
			set
			{
				if (value != null && value.Length > 65535)
				{
					throw new ArgumentOutOfRangeException("value", "cannot exceed 65535");
				}
				this.comment = value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06001733 RID: 5939 RVA: 0x0012F514 File Offset: 0x0012D714
		public bool IsDirectory
		{
			get
			{
				int length = this.name.Length;
				return (length > 0 && (this.name[length - 1] == '/' || this.name[length - 1] == '\\')) || this.HasDosAttributes(16);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06001734 RID: 5940 RVA: 0x0012F55F File Offset: 0x0012D75F
		public bool IsFile
		{
			get
			{
				return !this.IsDirectory && !this.HasDosAttributes(8);
			}
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x0012F575 File Offset: 0x0012D775
		public bool IsCompressionMethodSupported()
		{
			return ZipEntry.IsCompressionMethodSupported(this.CompressionMethod);
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x0012F584 File Offset: 0x0012D784
		public object Clone()
		{
			ZipEntry zipEntry = (ZipEntry)base.MemberwiseClone();
			if (this.extra != null)
			{
				zipEntry.extra = new byte[this.extra.Length];
				Array.Copy(this.extra, 0, zipEntry.extra, 0, this.extra.Length);
			}
			return zipEntry;
		}

		// Token: 0x06001737 RID: 5943 RVA: 0x0012F5D4 File Offset: 0x0012D7D4
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x0012F5DC File Offset: 0x0012D7DC
		public static bool IsCompressionMethodSupported(CompressionMethod method)
		{
			return method == CompressionMethod.Deflated || method == CompressionMethod.Stored;
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x0012F5E8 File Offset: 0x0012D7E8
		public static string CleanName(string name)
		{
			if (name == null)
			{
				return string.Empty;
			}
			if (Path.IsPathRooted(name))
			{
				name = name.Substring(Path.GetPathRoot(name).Length);
			}
			name = name.Replace("\\", "/");
			while (name.Length > 0 && name[0] == '/')
			{
				name = name.Remove(0, 1);
			}
			return name;
		}

		// Token: 0x04000D77 RID: 3447
		private ZipEntry.Known known;

		// Token: 0x04000D78 RID: 3448
		private int externalFileAttributes;

		// Token: 0x04000D79 RID: 3449
		private ushort versionMadeBy;

		// Token: 0x04000D7A RID: 3450
		private string name;

		// Token: 0x04000D7B RID: 3451
		private ulong size;

		// Token: 0x04000D7C RID: 3452
		private ulong compressedSize;

		// Token: 0x04000D7D RID: 3453
		private ushort versionToExtract;

		// Token: 0x04000D7E RID: 3454
		private uint crc;

		// Token: 0x04000D7F RID: 3455
		private uint dosTime;

		// Token: 0x04000D80 RID: 3456
		private CompressionMethod method;

		// Token: 0x04000D81 RID: 3457
		private byte[] extra;

		// Token: 0x04000D82 RID: 3458
		private string comment;

		// Token: 0x04000D83 RID: 3459
		private int flags;

		// Token: 0x04000D84 RID: 3460
		private long zipFileIndex;

		// Token: 0x04000D85 RID: 3461
		private long offset;

		// Token: 0x04000D86 RID: 3462
		private bool forceZip64_;

		// Token: 0x04000D87 RID: 3463
		private byte cryptoCheckValue_;

		// Token: 0x04000D88 RID: 3464
		private int _aesVer;

		// Token: 0x04000D89 RID: 3465
		private int _aesEncryptionStrength;

		// Token: 0x02000249 RID: 585
		[Flags]
		private enum Known : byte
		{
			// Token: 0x0400151F RID: 5407
			None = 0,
			// Token: 0x04001520 RID: 5408
			Size = 1,
			// Token: 0x04001521 RID: 5409
			CompressedSize = 2,
			// Token: 0x04001522 RID: 5410
			Crc = 4,
			// Token: 0x04001523 RID: 5411
			Time = 8,
			// Token: 0x04001524 RID: 5412
			ExternalAttributes = 16
		}
	}
}
