using System;
using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x0200016D RID: 365
	public class InflaterInputBuffer
	{
		// Token: 0x0600191D RID: 6429 RVA: 0x00139213 File Offset: 0x00137413
		public InflaterInputBuffer(Stream stream)
			: this(stream, 4096)
		{
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x00139221 File Offset: 0x00137421
		public InflaterInputBuffer(Stream stream, int bufferSize)
		{
			this.inputStream = stream;
			if (bufferSize < 1024)
			{
				bufferSize = 1024;
			}
			this.rawData = new byte[bufferSize];
			this.clearText = this.rawData;
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600191F RID: 6431 RVA: 0x00139257 File Offset: 0x00137457
		public int RawLength
		{
			get
			{
				return this.rawLength;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06001920 RID: 6432 RVA: 0x0013925F File Offset: 0x0013745F
		public byte[] RawData
		{
			get
			{
				return this.rawData;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06001921 RID: 6433 RVA: 0x00139267 File Offset: 0x00137467
		public int ClearTextLength
		{
			get
			{
				return this.clearTextLength;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06001922 RID: 6434 RVA: 0x0013926F File Offset: 0x0013746F
		public byte[] ClearText
		{
			get
			{
				return this.clearText;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06001923 RID: 6435 RVA: 0x00139277 File Offset: 0x00137477
		// (set) Token: 0x06001924 RID: 6436 RVA: 0x0013927F File Offset: 0x0013747F
		public int Available
		{
			get
			{
				return this.available;
			}
			set
			{
				this.available = value;
			}
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x00139288 File Offset: 0x00137488
		public void SetInflaterInput(Inflater inflater)
		{
			if (this.available > 0)
			{
				inflater.SetInput(this.clearText, this.clearTextLength - this.available, this.available);
				this.available = 0;
			}
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x001392BC File Offset: 0x001374BC
		public void Fill()
		{
			this.rawLength = 0;
			int num = this.rawData.Length;
			while (num > 0 && this.inputStream.CanRead)
			{
				int num2 = this.inputStream.Read(this.rawData, this.rawLength, num);
				if (num2 <= 0)
				{
					break;
				}
				this.rawLength += num2;
				num -= num2;
			}
			if (this.cryptoTransform != null)
			{
				this.clearTextLength = this.cryptoTransform.TransformBlock(this.rawData, 0, this.rawLength, this.clearText, 0);
			}
			else
			{
				this.clearTextLength = this.rawLength;
			}
			this.available = this.clearTextLength;
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x00139362 File Offset: 0x00137562
		public int ReadRawBuffer(byte[] buffer)
		{
			return this.ReadRawBuffer(buffer, 0, buffer.Length);
		}

		// Token: 0x06001928 RID: 6440 RVA: 0x00139370 File Offset: 0x00137570
		public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = offset;
			int i = length;
			while (i > 0)
			{
				if (this.available <= 0)
				{
					this.Fill();
					if (this.available <= 0)
					{
						return 0;
					}
				}
				int num2 = Math.Min(i, this.available);
				Array.Copy(this.rawData, this.rawLength - this.available, outBuffer, num, num2);
				num += num2;
				i -= num2;
				this.available -= num2;
			}
			return length;
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x001393F0 File Offset: 0x001375F0
		public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = offset;
			int i = length;
			while (i > 0)
			{
				if (this.available <= 0)
				{
					this.Fill();
					if (this.available <= 0)
					{
						return 0;
					}
				}
				int num2 = Math.Min(i, this.available);
				Array.Copy(this.clearText, this.clearTextLength - this.available, outBuffer, num, num2);
				num += num2;
				i -= num2;
				this.available -= num2;
			}
			return length;
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x00139470 File Offset: 0x00137670
		public int ReadLeByte()
		{
			if (this.available <= 0)
			{
				this.Fill();
				if (this.available <= 0)
				{
					throw new ZipException("EOF in header");
				}
			}
			int num = (int)this.rawData[this.rawLength - this.available];
			this.available--;
			return num;
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x001394C2 File Offset: 0x001376C2
		public int ReadLeShort()
		{
			return this.ReadLeByte() | (this.ReadLeByte() << 8);
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x001394D3 File Offset: 0x001376D3
		public int ReadLeInt()
		{
			return this.ReadLeShort() | (this.ReadLeShort() << 16);
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x001394E5 File Offset: 0x001376E5
		public long ReadLeLong()
		{
			return (long)((ulong)this.ReadLeInt() | (ulong)((ulong)((long)this.ReadLeInt()) << 32));
		}

		// Token: 0x17000156 RID: 342
		// (set) Token: 0x0600192E RID: 6446 RVA: 0x001394FC File Offset: 0x001376FC
		public ICryptoTransform CryptoTransform
		{
			set
			{
				this.cryptoTransform = value;
				if (this.cryptoTransform != null)
				{
					if (this.rawData == this.clearText)
					{
						if (this.internalClearText == null)
						{
							this.internalClearText = new byte[this.rawData.Length];
						}
						this.clearText = this.internalClearText;
					}
					this.clearTextLength = this.rawLength;
					if (this.available > 0)
					{
						this.cryptoTransform.TransformBlock(this.rawData, this.rawLength - this.available, this.available, this.clearText, this.rawLength - this.available);
						return;
					}
				}
				else
				{
					this.clearText = this.rawData;
					this.clearTextLength = this.rawLength;
				}
			}
		}

		// Token: 0x04000E96 RID: 3734
		private int rawLength;

		// Token: 0x04000E97 RID: 3735
		private byte[] rawData;

		// Token: 0x04000E98 RID: 3736
		private int clearTextLength;

		// Token: 0x04000E99 RID: 3737
		private byte[] clearText;

		// Token: 0x04000E9A RID: 3738
		private byte[] internalClearText;

		// Token: 0x04000E9B RID: 3739
		private int available;

		// Token: 0x04000E9C RID: 3740
		private ICryptoTransform cryptoTransform;

		// Token: 0x04000E9D RID: 3741
		private Stream inputStream;
	}
}
