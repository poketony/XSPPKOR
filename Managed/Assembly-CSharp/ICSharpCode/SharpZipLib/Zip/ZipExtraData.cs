using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200014B RID: 331
	public sealed class ZipExtraData : IDisposable
	{
		// Token: 0x06001775 RID: 6005 RVA: 0x0012FFC7 File Offset: 0x0012E1C7
		public ZipExtraData()
		{
			this.Clear();
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x0012FFD5 File Offset: 0x0012E1D5
		public ZipExtraData(byte[] data)
		{
			if (data == null)
			{
				this._data = new byte[0];
				return;
			}
			this._data = data;
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x0012FFF4 File Offset: 0x0012E1F4
		public byte[] GetEntryData()
		{
			if (this.Length > 65535)
			{
				throw new ZipException("Data exceeds maximum length");
			}
			return (byte[])this._data.Clone();
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x0013001E File Offset: 0x0012E21E
		public void Clear()
		{
			if (this._data == null || this._data.Length != 0)
			{
				this._data = new byte[0];
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06001779 RID: 6009 RVA: 0x0013003D File Offset: 0x0012E23D
		public int Length
		{
			get
			{
				return this._data.Length;
			}
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x00130048 File Offset: 0x0012E248
		public Stream GetStreamForTag(int tag)
		{
			Stream stream = null;
			if (this.Find(tag))
			{
				stream = new MemoryStream(this._data, this._index, this._readValueLength, false);
			}
			return stream;
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x0013007C File Offset: 0x0012E27C
		public T GetData<T>() where T : class, ITaggedData, new()
		{
			T t = new T();
			if (this.Find((int)t.TagID))
			{
				t.SetData(this._data, this._readValueStart, this._readValueLength);
				return t;
			}
			return default(T);
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x001300CA File Offset: 0x0012E2CA
		public int ValueLength
		{
			get
			{
				return this._readValueLength;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600177D RID: 6013 RVA: 0x001300D2 File Offset: 0x0012E2D2
		public int CurrentReadIndex
		{
			get
			{
				return this._index;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x001300DA File Offset: 0x0012E2DA
		public int UnreadCount
		{
			get
			{
				if (this._readValueStart > this._data.Length || this._readValueStart < 4)
				{
					throw new ZipException("Find must be called before calling a Read method");
				}
				return this._readValueStart + this._readValueLength - this._index;
			}
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x00130114 File Offset: 0x0012E314
		public bool Find(int headerID)
		{
			this._readValueStart = this._data.Length;
			this._readValueLength = 0;
			this._index = 0;
			int num = this._readValueStart;
			int num2 = headerID - 1;
			while (num2 != headerID && this._index < this._data.Length - 3)
			{
				num2 = this.ReadShortInternal();
				num = this.ReadShortInternal();
				if (num2 != headerID)
				{
					this._index += num;
				}
			}
			bool flag = num2 == headerID && this._index + num <= this._data.Length;
			if (flag)
			{
				this._readValueStart = this._index;
				this._readValueLength = num;
			}
			return flag;
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x001301B2 File Offset: 0x0012E3B2
		public void AddEntry(ITaggedData taggedData)
		{
			if (taggedData == null)
			{
				throw new ArgumentNullException("taggedData");
			}
			this.AddEntry((int)taggedData.TagID, taggedData.GetData());
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x001301D4 File Offset: 0x0012E3D4
		public void AddEntry(int headerID, byte[] fieldData)
		{
			if (headerID > 65535 || headerID < 0)
			{
				throw new ArgumentOutOfRangeException("headerID");
			}
			int num = ((fieldData == null) ? 0 : fieldData.Length);
			if (num > 65535)
			{
				throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
			}
			int num2 = this._data.Length + num + 4;
			if (this.Find(headerID))
			{
				num2 -= this.ValueLength + 4;
			}
			if (num2 > 65535)
			{
				throw new ZipException("Data exceeds maximum length");
			}
			this.Delete(headerID);
			byte[] array = new byte[num2];
			this._data.CopyTo(array, 0);
			int num3 = this._data.Length;
			this._data = array;
			this.SetShort(ref num3, headerID);
			this.SetShort(ref num3, num);
			if (fieldData != null)
			{
				fieldData.CopyTo(array, num3);
			}
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x00130297 File Offset: 0x0012E497
		public void StartNewEntry()
		{
			this._newEntry = new MemoryStream();
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x001302A4 File Offset: 0x0012E4A4
		public void AddNewEntry(int headerID)
		{
			byte[] array = this._newEntry.ToArray();
			this._newEntry = null;
			this.AddEntry(headerID, array);
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x001302CC File Offset: 0x0012E4CC
		public void AddData(byte data)
		{
			this._newEntry.WriteByte(data);
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x001302DA File Offset: 0x0012E4DA
		public void AddData(byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			this._newEntry.Write(data, 0, data.Length);
		}

		// Token: 0x06001786 RID: 6022 RVA: 0x001302FA File Offset: 0x0012E4FA
		public void AddLeShort(int toAdd)
		{
			this._newEntry.WriteByte((byte)toAdd);
			this._newEntry.WriteByte((byte)(toAdd >> 8));
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x00130318 File Offset: 0x0012E518
		public void AddLeInt(int toAdd)
		{
			this.AddLeShort((int)((short)toAdd));
			this.AddLeShort((int)((short)(toAdd >> 16)));
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x0013032D File Offset: 0x0012E52D
		public void AddLeLong(long toAdd)
		{
			this.AddLeInt((int)(toAdd & (long)((ulong)(-1))));
			this.AddLeInt((int)(toAdd >> 32));
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x00130348 File Offset: 0x0012E548
		public bool Delete(int headerID)
		{
			bool flag = false;
			if (this.Find(headerID))
			{
				flag = true;
				int num = this._readValueStart - 4;
				byte[] array = new byte[this._data.Length - (this.ValueLength + 4)];
				Array.Copy(this._data, 0, array, 0, num);
				int num2 = num + this.ValueLength + 4;
				Array.Copy(this._data, num2, array, num, this._data.Length - num2);
				this._data = array;
			}
			return flag;
		}

		// Token: 0x0600178A RID: 6026 RVA: 0x001303BC File Offset: 0x0012E5BC
		public long ReadLong()
		{
			this.ReadCheck(8);
			return ((long)this.ReadInt() & (long)((ulong)(-1))) | ((long)this.ReadInt() << 32);
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x001303DC File Offset: 0x0012E5DC
		public int ReadInt()
		{
			this.ReadCheck(4);
			int num = (int)this._data[this._index] + ((int)this._data[this._index + 1] << 8) + ((int)this._data[this._index + 2] << 16) + ((int)this._data[this._index + 3] << 24);
			this._index += 4;
			return num;
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x00130443 File Offset: 0x0012E643
		public int ReadShort()
		{
			this.ReadCheck(2);
			int num = (int)this._data[this._index] + ((int)this._data[this._index + 1] << 8);
			this._index += 2;
			return num;
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x0013047C File Offset: 0x0012E67C
		public int ReadByte()
		{
			int num = -1;
			if (this._index < this._data.Length && this._readValueStart + this._readValueLength > this._index)
			{
				num = (int)this._data[this._index];
				this._index++;
			}
			return num;
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x001304CD File Offset: 0x0012E6CD
		public void Skip(int amount)
		{
			this.ReadCheck(amount);
			this._index += amount;
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x001304E4 File Offset: 0x0012E6E4
		private void ReadCheck(int length)
		{
			if (this._readValueStart > this._data.Length || this._readValueStart < 4)
			{
				throw new ZipException("Find must be called before calling a Read method");
			}
			if (this._index > this._readValueStart + this._readValueLength - length)
			{
				throw new ZipException("End of extra data");
			}
			if (this._index + length < 4)
			{
				throw new ZipException("Cannot read before start of tag");
			}
		}

		// Token: 0x06001790 RID: 6032 RVA: 0x00130550 File Offset: 0x0012E750
		private int ReadShortInternal()
		{
			if (this._index > this._data.Length - 2)
			{
				throw new ZipException("End of extra data");
			}
			int num = (int)this._data[this._index] + ((int)this._data[this._index + 1] << 8);
			this._index += 2;
			return num;
		}

		// Token: 0x06001791 RID: 6033 RVA: 0x001305A7 File Offset: 0x0012E7A7
		private void SetShort(ref int index, int source)
		{
			this._data[index] = (byte)source;
			this._data[index + 1] = (byte)(source >> 8);
			index += 2;
		}

		// Token: 0x06001792 RID: 6034 RVA: 0x001305C9 File Offset: 0x0012E7C9
		public void Dispose()
		{
			if (this._newEntry != null)
			{
				this._newEntry.Dispose();
			}
		}

		// Token: 0x04000D99 RID: 3481
		private int _index;

		// Token: 0x04000D9A RID: 3482
		private int _readValueStart;

		// Token: 0x04000D9B RID: 3483
		private int _readValueLength;

		// Token: 0x04000D9C RID: 3484
		private MemoryStream _newEntry;

		// Token: 0x04000D9D RID: 3485
		private byte[] _data;
	}
}
