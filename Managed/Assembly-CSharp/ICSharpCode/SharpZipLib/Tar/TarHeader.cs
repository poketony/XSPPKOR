using System;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000178 RID: 376
	public class TarHeader
	{
		// Token: 0x060019D0 RID: 6608 RVA: 0x0013B5DC File Offset: 0x001397DC
		public TarHeader()
		{
			this.Magic = "ustar";
			this.Version = " ";
			this.Name = "";
			this.LinkName = "";
			this.UserId = TarHeader.defaultUserId;
			this.GroupId = TarHeader.defaultGroupId;
			this.UserName = TarHeader.defaultUser;
			this.GroupName = TarHeader.defaultGroupName;
			this.Size = 0L;
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060019D1 RID: 6609 RVA: 0x0013B64F File Offset: 0x0013984F
		// (set) Token: 0x060019D2 RID: 6610 RVA: 0x0013B657 File Offset: 0x00139857
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.name = value;
			}
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x0013B66E File Offset: 0x0013986E
		[Obsolete("Use the Name property instead", true)]
		public string GetName()
		{
			return this.name;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060019D4 RID: 6612 RVA: 0x0013B676 File Offset: 0x00139876
		// (set) Token: 0x060019D5 RID: 6613 RVA: 0x0013B67E File Offset: 0x0013987E
		public int Mode
		{
			get
			{
				return this.mode;
			}
			set
			{
				this.mode = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060019D6 RID: 6614 RVA: 0x0013B687 File Offset: 0x00139887
		// (set) Token: 0x060019D7 RID: 6615 RVA: 0x0013B68F File Offset: 0x0013988F
		public int UserId
		{
			get
			{
				return this.userId;
			}
			set
			{
				this.userId = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060019D8 RID: 6616 RVA: 0x0013B698 File Offset: 0x00139898
		// (set) Token: 0x060019D9 RID: 6617 RVA: 0x0013B6A0 File Offset: 0x001398A0
		public int GroupId
		{
			get
			{
				return this.groupId;
			}
			set
			{
				this.groupId = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060019DA RID: 6618 RVA: 0x0013B6A9 File Offset: 0x001398A9
		// (set) Token: 0x060019DB RID: 6619 RVA: 0x0013B6B1 File Offset: 0x001398B1
		public long Size
		{
			get
			{
				return this.size;
			}
			set
			{
				if (value < 0L)
				{
					throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
				}
				this.size = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060019DC RID: 6620 RVA: 0x0013B6CF File Offset: 0x001398CF
		// (set) Token: 0x060019DD RID: 6621 RVA: 0x0013B6D8 File Offset: 0x001398D8
		public DateTime ModTime
		{
			get
			{
				return this.modTime;
			}
			set
			{
				if (value < TarHeader.dateTime1970)
				{
					throw new ArgumentOutOfRangeException("value", "ModTime cannot be before Jan 1st 1970");
				}
				this.modTime = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060019DE RID: 6622 RVA: 0x0013B737 File Offset: 0x00139937
		public int Checksum
		{
			get
			{
				return this.checksum;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060019DF RID: 6623 RVA: 0x0013B73F File Offset: 0x0013993F
		public bool IsChecksumValid
		{
			get
			{
				return this.isChecksumValid;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060019E0 RID: 6624 RVA: 0x0013B747 File Offset: 0x00139947
		// (set) Token: 0x060019E1 RID: 6625 RVA: 0x0013B74F File Offset: 0x0013994F
		public byte TypeFlag
		{
			get
			{
				return this.typeFlag;
			}
			set
			{
				this.typeFlag = value;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060019E2 RID: 6626 RVA: 0x0013B758 File Offset: 0x00139958
		// (set) Token: 0x060019E3 RID: 6627 RVA: 0x0013B760 File Offset: 0x00139960
		public string LinkName
		{
			get
			{
				return this.linkName;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.linkName = value;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060019E4 RID: 6628 RVA: 0x0013B777 File Offset: 0x00139977
		// (set) Token: 0x060019E5 RID: 6629 RVA: 0x0013B77F File Offset: 0x0013997F
		public string Magic
		{
			get
			{
				return this.magic;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.magic = value;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060019E6 RID: 6630 RVA: 0x0013B796 File Offset: 0x00139996
		// (set) Token: 0x060019E7 RID: 6631 RVA: 0x0013B79E File Offset: 0x0013999E
		public string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.version = value;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060019E8 RID: 6632 RVA: 0x0013B7B5 File Offset: 0x001399B5
		// (set) Token: 0x060019E9 RID: 6633 RVA: 0x0013B7C0 File Offset: 0x001399C0
		public string UserName
		{
			get
			{
				return this.userName;
			}
			set
			{
				if (value != null)
				{
					this.userName = value.Substring(0, Math.Min(32, value.Length));
					return;
				}
				string text = "user";
				if (text.Length > 32)
				{
					text = text.Substring(0, 32);
				}
				this.userName = text;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060019EA RID: 6634 RVA: 0x0013B80C File Offset: 0x00139A0C
		// (set) Token: 0x060019EB RID: 6635 RVA: 0x0013B814 File Offset: 0x00139A14
		public string GroupName
		{
			get
			{
				return this.groupName;
			}
			set
			{
				if (value == null)
				{
					this.groupName = "None";
					return;
				}
				this.groupName = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060019EC RID: 6636 RVA: 0x0013B82C File Offset: 0x00139A2C
		// (set) Token: 0x060019ED RID: 6637 RVA: 0x0013B834 File Offset: 0x00139A34
		public int DevMajor
		{
			get
			{
				return this.devMajor;
			}
			set
			{
				this.devMajor = value;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060019EE RID: 6638 RVA: 0x0013B83D File Offset: 0x00139A3D
		// (set) Token: 0x060019EF RID: 6639 RVA: 0x0013B845 File Offset: 0x00139A45
		public int DevMinor
		{
			get
			{
				return this.devMinor;
			}
			set
			{
				this.devMinor = value;
			}
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x0013B84E File Offset: 0x00139A4E
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x0013B858 File Offset: 0x00139A58
		public void ParseBuffer(byte[] header)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			int num = 0;
			this.name = TarHeader.ParseName(header, num, 100).ToString();
			num += 100;
			this.mode = (int)TarHeader.ParseOctal(header, num, 8);
			num += 8;
			this.UserId = (int)TarHeader.ParseOctal(header, num, 8);
			num += 8;
			this.GroupId = (int)TarHeader.ParseOctal(header, num, 8);
			num += 8;
			this.Size = TarHeader.ParseBinaryOrOctal(header, num, 12);
			num += 12;
			this.ModTime = TarHeader.GetDateTimeFromCTime(TarHeader.ParseOctal(header, num, 12));
			num += 12;
			this.checksum = (int)TarHeader.ParseOctal(header, num, 8);
			num += 8;
			this.TypeFlag = header[num++];
			this.LinkName = TarHeader.ParseName(header, num, 100).ToString();
			num += 100;
			this.Magic = TarHeader.ParseName(header, num, 6).ToString();
			num += 6;
			if (this.Magic == "ustar")
			{
				this.Version = TarHeader.ParseName(header, num, 2).ToString();
				num += 2;
				this.UserName = TarHeader.ParseName(header, num, 32).ToString();
				num += 32;
				this.GroupName = TarHeader.ParseName(header, num, 32).ToString();
				num += 32;
				this.DevMajor = (int)TarHeader.ParseOctal(header, num, 8);
				num += 8;
				this.DevMinor = (int)TarHeader.ParseOctal(header, num, 8);
				num += 8;
				string text = TarHeader.ParseName(header, num, 155).ToString();
				if (!string.IsNullOrEmpty(text))
				{
					this.Name = text + "/" + this.Name;
				}
			}
			this.isChecksumValid = this.Checksum == TarHeader.MakeCheckSum(header);
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x0013BA10 File Offset: 0x00139C10
		public void WriteHeader(byte[] outBuffer)
		{
			if (outBuffer == null)
			{
				throw new ArgumentNullException("outBuffer");
			}
			int i = 0;
			i = TarHeader.GetNameBytes(this.Name, outBuffer, i, 100);
			i = TarHeader.GetOctalBytes((long)this.mode, outBuffer, i, 8);
			i = TarHeader.GetOctalBytes((long)this.UserId, outBuffer, i, 8);
			i = TarHeader.GetOctalBytes((long)this.GroupId, outBuffer, i, 8);
			i = TarHeader.GetBinaryOrOctalBytes(this.Size, outBuffer, i, 12);
			i = TarHeader.GetOctalBytes((long)TarHeader.GetCTime(this.ModTime), outBuffer, i, 12);
			int num = i;
			for (int j = 0; j < 8; j++)
			{
				outBuffer[i++] = 32;
			}
			outBuffer[i++] = this.TypeFlag;
			i = TarHeader.GetNameBytes(this.LinkName, outBuffer, i, 100);
			i = TarHeader.GetAsciiBytes(this.Magic, 0, outBuffer, i, 6);
			i = TarHeader.GetNameBytes(this.Version, outBuffer, i, 2);
			i = TarHeader.GetNameBytes(this.UserName, outBuffer, i, 32);
			i = TarHeader.GetNameBytes(this.GroupName, outBuffer, i, 32);
			if (this.TypeFlag == 51 || this.TypeFlag == 52)
			{
				i = TarHeader.GetOctalBytes((long)this.DevMajor, outBuffer, i, 8);
				i = TarHeader.GetOctalBytes((long)this.DevMinor, outBuffer, i, 8);
			}
			while (i < outBuffer.Length)
			{
				outBuffer[i++] = 0;
			}
			this.checksum = TarHeader.ComputeCheckSum(outBuffer);
			TarHeader.GetCheckSumOctalBytes((long)this.checksum, outBuffer, num, 8);
			this.isChecksumValid = true;
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x0013BB6C File Offset: 0x00139D6C
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x0013BB7C File Offset: 0x00139D7C
		public override bool Equals(object obj)
		{
			TarHeader tarHeader = obj as TarHeader;
			return tarHeader != null && (this.name == tarHeader.name && this.mode == tarHeader.mode && this.UserId == tarHeader.UserId && this.GroupId == tarHeader.GroupId && this.Size == tarHeader.Size && this.ModTime == tarHeader.ModTime && this.Checksum == tarHeader.Checksum && this.TypeFlag == tarHeader.TypeFlag && this.LinkName == tarHeader.LinkName && this.Magic == tarHeader.Magic && this.Version == tarHeader.Version && this.UserName == tarHeader.UserName && this.GroupName == tarHeader.GroupName && this.DevMajor == tarHeader.DevMajor) && this.DevMinor == tarHeader.DevMinor;
		}

		// Token: 0x060019F5 RID: 6645 RVA: 0x0013BCA9 File Offset: 0x00139EA9
		internal static void SetValueDefaults(int userId, string userName, int groupId, string groupName)
		{
			TarHeader.userIdAsSet = userId;
			TarHeader.defaultUserId = userId;
			TarHeader.userNameAsSet = userName;
			TarHeader.defaultUser = userName;
			TarHeader.groupIdAsSet = groupId;
			TarHeader.defaultGroupId = groupId;
			TarHeader.groupNameAsSet = groupName;
			TarHeader.defaultGroupName = groupName;
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x0013BCDB File Offset: 0x00139EDB
		internal static void RestoreSetValues()
		{
			TarHeader.defaultUserId = TarHeader.userIdAsSet;
			TarHeader.defaultUser = TarHeader.userNameAsSet;
			TarHeader.defaultGroupId = TarHeader.groupIdAsSet;
			TarHeader.defaultGroupName = TarHeader.groupNameAsSet;
		}

		// Token: 0x060019F7 RID: 6647 RVA: 0x0013BD08 File Offset: 0x00139F08
		private static long ParseBinaryOrOctal(byte[] header, int offset, int length)
		{
			if (header[offset] >= 128)
			{
				long num = 0L;
				for (int i = length - 8; i < length; i++)
				{
					num = (num << 8) | (long)((ulong)header[offset + i]);
				}
				return num;
			}
			return TarHeader.ParseOctal(header, offset, length);
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x0013BD48 File Offset: 0x00139F48
		public static long ParseOctal(byte[] header, int offset, int length)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			long num = 0L;
			bool flag = true;
			int num2 = offset + length;
			int num3 = offset;
			while (num3 < num2 && header[num3] != 0)
			{
				if (header[num3] != 32 && header[num3] != 48)
				{
					goto IL_0038;
				}
				if (!flag)
				{
					if (header[num3] != 32)
					{
						goto IL_0038;
					}
					break;
				}
				IL_0046:
				num3++;
				continue;
				IL_0038:
				flag = false;
				num = (num << 3) + (long)(header[num3] - 48);
				goto IL_0046;
			}
			return num;
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x0013BDA4 File Offset: 0x00139FA4
		public static StringBuilder ParseName(byte[] header, int offset, int length)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be less than zero");
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Cannot be less than zero");
			}
			if (offset + length > header.Length)
			{
				throw new ArgumentException("Exceeds header size", "length");
			}
			StringBuilder stringBuilder = new StringBuilder(length);
			int num = offset;
			while (num < offset + length && header[num] != 0)
			{
				stringBuilder.Append((char)header[num]);
				num++;
			}
			return stringBuilder;
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x0013BE24 File Offset: 0x0013A024
		public static int GetNameBytes(StringBuilder name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return TarHeader.GetNameBytes(name.ToString(), nameOffset, buffer, bufferOffset, length);
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0013BE54 File Offset: 0x0013A054
		public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int i;
			for (i = 0; i < length; i++)
			{
				if (nameOffset + i >= name.Length)
				{
					break;
				}
				buffer[bufferOffset + i] = (byte)name[nameOffset + i];
			}
			while (i < length)
			{
				buffer[bufferOffset + i] = 0;
				i++;
			}
			return bufferOffset + length;
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x0013BEB9 File Offset: 0x0013A0B9
		public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return TarHeader.GetNameBytes(name.ToString(), 0, buffer, offset, length);
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x0013BEE6 File Offset: 0x0013A0E6
		public static int GetNameBytes(string name, byte[] buffer, int offset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return TarHeader.GetNameBytes(name, 0, buffer, offset, length);
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x0013BF10 File Offset: 0x0013A110
		public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (toAdd == null)
			{
				throw new ArgumentNullException("toAdd");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int i;
			for (i = 0; i < length; i++)
			{
				if (nameOffset + i >= toAdd.Length)
				{
					break;
				}
				buffer[bufferOffset + i] = (byte)toAdd[nameOffset + i];
			}
			while (i < length)
			{
				buffer[bufferOffset + i] = 0;
				i++;
			}
			return bufferOffset + length;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x0013BF78 File Offset: 0x0013A178
		public static int GetOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int i = length - 1;
			buffer[offset + i] = 0;
			i--;
			if (value > 0L)
			{
				long num = value;
				while (i >= 0)
				{
					if (num <= 0L)
					{
						break;
					}
					buffer[offset + i] = 48 + (byte)(num & 7L);
					num >>= 3;
					i--;
				}
			}
			while (i >= 0)
			{
				buffer[offset + i] = 48;
				i--;
			}
			return offset + length;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x0013BFE0 File Offset: 0x0013A1E0
		private static int GetBinaryOrOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			if (value > 8589934591L)
			{
				for (int i = length - 1; i > 0; i--)
				{
					buffer[offset + i] = (byte)value;
					value >>= 8;
				}
				buffer[offset] = 128;
				return offset + length;
			}
			return TarHeader.GetOctalBytes(value, buffer, offset, length);
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x0013C028 File Offset: 0x0013A228
		private static void GetCheckSumOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			TarHeader.GetOctalBytes(value, buffer, offset, length - 1);
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x0013C038 File Offset: 0x0013A238
		private static int ComputeCheckSum(byte[] buffer)
		{
			int num = 0;
			for (int i = 0; i < buffer.Length; i++)
			{
				num += (int)buffer[i];
			}
			return num;
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x0013C05C File Offset: 0x0013A25C
		private static int MakeCheckSum(byte[] buffer)
		{
			int num = 0;
			for (int i = 0; i < 148; i++)
			{
				num += (int)buffer[i];
			}
			for (int j = 0; j < 8; j++)
			{
				num += 32;
			}
			for (int k = 156; k < buffer.Length; k++)
			{
				num += (int)buffer[k];
			}
			return num;
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x0013C0AB File Offset: 0x0013A2AB
		private static int GetCTime(DateTime dateTime)
		{
			return (int)((dateTime.Ticks - TarHeader.dateTime1970.Ticks) / 10000000L);
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x0013C0C8 File Offset: 0x0013A2C8
		private static DateTime GetDateTimeFromCTime(long ticks)
		{
			DateTime dateTime;
			try
			{
				dateTime = new DateTime(TarHeader.dateTime1970.Ticks + ticks * 10000000L);
			}
			catch (ArgumentOutOfRangeException)
			{
				dateTime = TarHeader.dateTime1970;
			}
			return dateTime;
		}

		// Token: 0x04000ED5 RID: 3797
		public const int NAMELEN = 100;

		// Token: 0x04000ED6 RID: 3798
		public const int MODELEN = 8;

		// Token: 0x04000ED7 RID: 3799
		public const int UIDLEN = 8;

		// Token: 0x04000ED8 RID: 3800
		public const int GIDLEN = 8;

		// Token: 0x04000ED9 RID: 3801
		public const int CHKSUMLEN = 8;

		// Token: 0x04000EDA RID: 3802
		public const int CHKSUMOFS = 148;

		// Token: 0x04000EDB RID: 3803
		public const int SIZELEN = 12;

		// Token: 0x04000EDC RID: 3804
		public const int MAGICLEN = 6;

		// Token: 0x04000EDD RID: 3805
		public const int VERSIONLEN = 2;

		// Token: 0x04000EDE RID: 3806
		public const int MODTIMELEN = 12;

		// Token: 0x04000EDF RID: 3807
		public const int UNAMELEN = 32;

		// Token: 0x04000EE0 RID: 3808
		public const int GNAMELEN = 32;

		// Token: 0x04000EE1 RID: 3809
		public const int DEVLEN = 8;

		// Token: 0x04000EE2 RID: 3810
		public const int PREFIXLEN = 155;

		// Token: 0x04000EE3 RID: 3811
		public const byte LF_OLDNORM = 0;

		// Token: 0x04000EE4 RID: 3812
		public const byte LF_NORMAL = 48;

		// Token: 0x04000EE5 RID: 3813
		public const byte LF_LINK = 49;

		// Token: 0x04000EE6 RID: 3814
		public const byte LF_SYMLINK = 50;

		// Token: 0x04000EE7 RID: 3815
		public const byte LF_CHR = 51;

		// Token: 0x04000EE8 RID: 3816
		public const byte LF_BLK = 52;

		// Token: 0x04000EE9 RID: 3817
		public const byte LF_DIR = 53;

		// Token: 0x04000EEA RID: 3818
		public const byte LF_FIFO = 54;

		// Token: 0x04000EEB RID: 3819
		public const byte LF_CONTIG = 55;

		// Token: 0x04000EEC RID: 3820
		public const byte LF_GHDR = 103;

		// Token: 0x04000EED RID: 3821
		public const byte LF_XHDR = 120;

		// Token: 0x04000EEE RID: 3822
		public const byte LF_ACL = 65;

		// Token: 0x04000EEF RID: 3823
		public const byte LF_GNU_DUMPDIR = 68;

		// Token: 0x04000EF0 RID: 3824
		public const byte LF_EXTATTR = 69;

		// Token: 0x04000EF1 RID: 3825
		public const byte LF_META = 73;

		// Token: 0x04000EF2 RID: 3826
		public const byte LF_GNU_LONGLINK = 75;

		// Token: 0x04000EF3 RID: 3827
		public const byte LF_GNU_LONGNAME = 76;

		// Token: 0x04000EF4 RID: 3828
		public const byte LF_GNU_MULTIVOL = 77;

		// Token: 0x04000EF5 RID: 3829
		public const byte LF_GNU_NAMES = 78;

		// Token: 0x04000EF6 RID: 3830
		public const byte LF_GNU_SPARSE = 83;

		// Token: 0x04000EF7 RID: 3831
		public const byte LF_GNU_VOLHDR = 86;

		// Token: 0x04000EF8 RID: 3832
		public const string TMAGIC = "ustar";

		// Token: 0x04000EF9 RID: 3833
		public const string GNU_TMAGIC = "ustar  ";

		// Token: 0x04000EFA RID: 3834
		private const long timeConversionFactor = 10000000L;

		// Token: 0x04000EFB RID: 3835
		private static readonly DateTime dateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

		// Token: 0x04000EFC RID: 3836
		private string name;

		// Token: 0x04000EFD RID: 3837
		private int mode;

		// Token: 0x04000EFE RID: 3838
		private int userId;

		// Token: 0x04000EFF RID: 3839
		private int groupId;

		// Token: 0x04000F00 RID: 3840
		private long size;

		// Token: 0x04000F01 RID: 3841
		private DateTime modTime;

		// Token: 0x04000F02 RID: 3842
		private int checksum;

		// Token: 0x04000F03 RID: 3843
		private bool isChecksumValid;

		// Token: 0x04000F04 RID: 3844
		private byte typeFlag;

		// Token: 0x04000F05 RID: 3845
		private string linkName;

		// Token: 0x04000F06 RID: 3846
		private string magic;

		// Token: 0x04000F07 RID: 3847
		private string version;

		// Token: 0x04000F08 RID: 3848
		private string userName;

		// Token: 0x04000F09 RID: 3849
		private string groupName;

		// Token: 0x04000F0A RID: 3850
		private int devMajor;

		// Token: 0x04000F0B RID: 3851
		private int devMinor;

		// Token: 0x04000F0C RID: 3852
		internal static int userIdAsSet;

		// Token: 0x04000F0D RID: 3853
		internal static int groupIdAsSet;

		// Token: 0x04000F0E RID: 3854
		internal static string userNameAsSet;

		// Token: 0x04000F0F RID: 3855
		internal static string groupNameAsSet = "None";

		// Token: 0x04000F10 RID: 3856
		internal static int defaultUserId;

		// Token: 0x04000F11 RID: 3857
		internal static int defaultGroupId;

		// Token: 0x04000F12 RID: 3858
		internal static string defaultGroupName = "None";

		// Token: 0x04000F13 RID: 3859
		internal static string defaultUser;
	}
}
