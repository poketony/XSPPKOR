using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000148 RID: 328
	public class ExtendedUnixData : ITaggedData
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600175C RID: 5980 RVA: 0x0012FA44 File Offset: 0x0012DC44
		public short TagID
		{
			get
			{
				return 21589;
			}
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x0012FA4C File Offset: 0x0012DC4C
		public void SetData(byte[] data, int index, int count)
		{
			using (MemoryStream memoryStream = new MemoryStream(data, index, count, false))
			{
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(memoryStream))
				{
					this._flags = (ExtendedUnixData.Flags)zipHelperStream.ReadByte();
					if ((this._flags & ExtendedUnixData.Flags.ModificationTime) != (ExtendedUnixData.Flags)0)
					{
						int num = zipHelperStream.ReadLEInt();
						this._modificationTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, num, 0);
						if (count <= 5)
						{
							return;
						}
					}
					if ((this._flags & ExtendedUnixData.Flags.AccessTime) != (ExtendedUnixData.Flags)0)
					{
						int num2 = zipHelperStream.ReadLEInt();
						this._lastAccessTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, num2, 0);
					}
					if ((this._flags & ExtendedUnixData.Flags.CreateTime) != (ExtendedUnixData.Flags)0)
					{
						int num3 = zipHelperStream.ReadLEInt();
						this._createTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, num3, 0);
					}
				}
			}
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x0012FB5C File Offset: 0x0012DD5C
		public byte[] GetData()
		{
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(memoryStream))
				{
					zipHelperStream.IsStreamOwner = false;
					zipHelperStream.WriteByte((byte)this._flags);
					if ((this._flags & ExtendedUnixData.Flags.ModificationTime) != (ExtendedUnixData.Flags)0)
					{
						int num = (int)(this._modificationTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
						zipHelperStream.WriteLEInt(num);
					}
					if ((this._flags & ExtendedUnixData.Flags.AccessTime) != (ExtendedUnixData.Flags)0)
					{
						int num2 = (int)(this._lastAccessTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
						zipHelperStream.WriteLEInt(num2);
					}
					if ((this._flags & ExtendedUnixData.Flags.CreateTime) != (ExtendedUnixData.Flags)0)
					{
						int num3 = (int)(this._createTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
						zipHelperStream.WriteLEInt(num3);
					}
					array = memoryStream.ToArray();
				}
			}
			return array;
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x0012FC70 File Offset: 0x0012DE70
		public static bool IsValidValue(DateTime value)
		{
			return value >= new DateTime(1901, 12, 13, 20, 45, 52) || value <= new DateTime(2038, 1, 19, 3, 14, 7);
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06001760 RID: 5984 RVA: 0x0012FCA7 File Offset: 0x0012DEA7
		// (set) Token: 0x06001761 RID: 5985 RVA: 0x0012FCAF File Offset: 0x0012DEAF
		public DateTime ModificationTime
		{
			get
			{
				return this._modificationTime;
			}
			set
			{
				if (!ExtendedUnixData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._flags |= ExtendedUnixData.Flags.ModificationTime;
				this._modificationTime = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x0012FCD9 File Offset: 0x0012DED9
		// (set) Token: 0x06001763 RID: 5987 RVA: 0x0012FCE1 File Offset: 0x0012DEE1
		public DateTime AccessTime
		{
			get
			{
				return this._lastAccessTime;
			}
			set
			{
				if (!ExtendedUnixData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._flags |= ExtendedUnixData.Flags.AccessTime;
				this._lastAccessTime = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x0012FD0B File Offset: 0x0012DF0B
		// (set) Token: 0x06001765 RID: 5989 RVA: 0x0012FD13 File Offset: 0x0012DF13
		public DateTime CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				if (!ExtendedUnixData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._flags |= ExtendedUnixData.Flags.CreateTime;
				this._createTime = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x0012FD3D File Offset: 0x0012DF3D
		// (set) Token: 0x06001767 RID: 5991 RVA: 0x0012FD45 File Offset: 0x0012DF45
		public ExtendedUnixData.Flags Include
		{
			get
			{
				return this._flags;
			}
			set
			{
				this._flags = value;
			}
		}

		// Token: 0x04000D92 RID: 3474
		private ExtendedUnixData.Flags _flags;

		// Token: 0x04000D93 RID: 3475
		private DateTime _modificationTime = new DateTime(1970, 1, 1);

		// Token: 0x04000D94 RID: 3476
		private DateTime _lastAccessTime = new DateTime(1970, 1, 1);

		// Token: 0x04000D95 RID: 3477
		private DateTime _createTime = new DateTime(1970, 1, 1);

		// Token: 0x0200024B RID: 587
		[Flags]
		public enum Flags : byte
		{
			// Token: 0x0400152E RID: 5422
			ModificationTime = 1,
			// Token: 0x0400152F RID: 5423
			AccessTime = 2,
			// Token: 0x04001530 RID: 5424
			CreateTime = 4
		}
	}
}
