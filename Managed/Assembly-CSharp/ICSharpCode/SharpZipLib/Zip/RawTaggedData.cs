using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000147 RID: 327
	public class RawTaggedData : ITaggedData
	{
		// Token: 0x06001755 RID: 5973 RVA: 0x0012F9E0 File Offset: 0x0012DBE0
		public RawTaggedData(short tag)
		{
			this._tag = tag;
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06001756 RID: 5974 RVA: 0x0012F9EF File Offset: 0x0012DBEF
		// (set) Token: 0x06001757 RID: 5975 RVA: 0x0012F9F7 File Offset: 0x0012DBF7
		public short TagID
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
			}
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0012FA00 File Offset: 0x0012DC00
		public void SetData(byte[] data, int offset, int count)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			this._data = new byte[count];
			Array.Copy(data, offset, this._data, 0, count);
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x0012FA2B File Offset: 0x0012DC2B
		public byte[] GetData()
		{
			return this._data;
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600175A RID: 5978 RVA: 0x0012FA33 File Offset: 0x0012DC33
		// (set) Token: 0x0600175B RID: 5979 RVA: 0x0012FA3B File Offset: 0x0012DC3B
		public byte[] Data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x04000D90 RID: 3472
		private short _tag;

		// Token: 0x04000D91 RID: 3473
		private byte[] _data;
	}
}
