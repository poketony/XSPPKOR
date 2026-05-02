using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000149 RID: 329
	public class NTTaggedData : ITaggedData
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x0012FD8C File Offset: 0x0012DF8C
		public short TagID
		{
			get
			{
				return 10;
			}
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x0012FD90 File Offset: 0x0012DF90
		public void SetData(byte[] data, int index, int count)
		{
			using (MemoryStream memoryStream = new MemoryStream(data, index, count, false))
			{
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(memoryStream))
				{
					zipHelperStream.ReadLEInt();
					while (zipHelperStream.Position < zipHelperStream.Length)
					{
						int num = zipHelperStream.ReadLEShort();
						int num2 = zipHelperStream.ReadLEShort();
						if (num == 1)
						{
							if (num2 >= 24)
							{
								long num3 = zipHelperStream.ReadLELong();
								this._lastModificationTime = DateTime.FromFileTimeUtc(num3);
								long num4 = zipHelperStream.ReadLELong();
								this._lastAccessTime = DateTime.FromFileTimeUtc(num4);
								long num5 = zipHelperStream.ReadLELong();
								this._createTime = DateTime.FromFileTimeUtc(num5);
								break;
							}
							break;
						}
						else
						{
							zipHelperStream.Seek((long)num2, SeekOrigin.Current);
						}
					}
				}
			}
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x0012FE58 File Offset: 0x0012E058
		public byte[] GetData()
		{
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(memoryStream))
				{
					zipHelperStream.IsStreamOwner = false;
					zipHelperStream.WriteLEInt(0);
					zipHelperStream.WriteLEShort(1);
					zipHelperStream.WriteLEShort(24);
					zipHelperStream.WriteLELong(this._lastModificationTime.ToFileTimeUtc());
					zipHelperStream.WriteLELong(this._lastAccessTime.ToFileTimeUtc());
					zipHelperStream.WriteLELong(this._createTime.ToFileTimeUtc());
					array = memoryStream.ToArray();
				}
			}
			return array;
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x0012FEFC File Offset: 0x0012E0FC
		public static bool IsValidValue(DateTime value)
		{
			bool flag = true;
			try
			{
				value.ToFileTimeUtc();
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x0012FF2C File Offset: 0x0012E12C
		// (set) Token: 0x0600176E RID: 5998 RVA: 0x0012FF34 File Offset: 0x0012E134
		public DateTime LastModificationTime
		{
			get
			{
				return this._lastModificationTime;
			}
			set
			{
				if (!NTTaggedData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._lastModificationTime = value;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600176F RID: 5999 RVA: 0x0012FF50 File Offset: 0x0012E150
		// (set) Token: 0x06001770 RID: 6000 RVA: 0x0012FF58 File Offset: 0x0012E158
		public DateTime CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				if (!NTTaggedData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._createTime = value;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06001771 RID: 6001 RVA: 0x0012FF74 File Offset: 0x0012E174
		// (set) Token: 0x06001772 RID: 6002 RVA: 0x0012FF7C File Offset: 0x0012E17C
		public DateTime LastAccessTime
		{
			get
			{
				return this._lastAccessTime;
			}
			set
			{
				if (!NTTaggedData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._lastAccessTime = value;
			}
		}

		// Token: 0x04000D96 RID: 3478
		private DateTime _lastAccessTime = DateTime.FromFileTimeUtc(0L);

		// Token: 0x04000D97 RID: 3479
		private DateTime _lastModificationTime = DateTime.FromFileTimeUtc(0L);

		// Token: 0x04000D98 RID: 3480
		private DateTime _createTime = DateTime.FromFileTimeUtc(0L);
	}
}
