using System;
using System.IO;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Encryption
{
	// Token: 0x02000188 RID: 392
	internal class ZipAESStream : CryptoStream
	{
		// Token: 0x06001A8C RID: 6796 RVA: 0x0013E18E File Offset: 0x0013C38E
		public ZipAESStream(Stream stream, ZipAESTransform transform, CryptoStreamMode mode)
			: base(stream, transform, mode)
		{
			this._stream = stream;
			this._transform = transform;
			this._slideBuffer = new byte[1024];
			if (mode != CryptoStreamMode.Read)
			{
				throw new Exception("ZipAESStream only for read");
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06001A8D RID: 6797 RVA: 0x0013E1C5 File Offset: 0x0013C3C5
		private bool HasBufferedData
		{
			get
			{
				return this._transformBuffer != null && this._transformBufferStartPos < this._transformBufferFreePos;
			}
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x0013E1E0 File Offset: 0x0013C3E0
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (count == 0)
			{
				return 0;
			}
			int num = 0;
			if (this.HasBufferedData)
			{
				num = this.ReadBufferedData(buffer, offset, count);
				if (num == count)
				{
					return num;
				}
				offset += num;
				count -= num;
			}
			if (this._slideBuffer != null)
			{
				num += this.ReadAndTransform(buffer, offset, count);
			}
			return num;
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x0013E22C File Offset: 0x0013C42C
		private int ReadAndTransform(byte[] buffer, int offset, int count)
		{
			int i = 0;
			while (i < count)
			{
				int num = count - i;
				int num2 = this._slideBufFreePos - this._slideBufStartPos;
				int num3 = 26 - num2;
				if (this._slideBuffer.Length - this._slideBufFreePos < num3)
				{
					int num4 = 0;
					int j = this._slideBufStartPos;
					while (j < this._slideBufFreePos)
					{
						this._slideBuffer[num4] = this._slideBuffer[j];
						j++;
						num4++;
					}
					this._slideBufFreePos -= this._slideBufStartPos;
					this._slideBufStartPos = 0;
				}
				int num5 = StreamUtils.ReadRequestedBytes(this._stream, this._slideBuffer, this._slideBufFreePos, num3);
				this._slideBufFreePos += num5;
				num2 = this._slideBufFreePos - this._slideBufStartPos;
				if (num2 < 26)
				{
					if (num2 > 10)
					{
						int num6 = num2 - 10;
						i += this.TransformAndBufferBlock(buffer, offset, num, num6);
					}
					else if (num2 < 10)
					{
						throw new Exception("Internal error missed auth code");
					}
					byte[] authCode = this._transform.GetAuthCode();
					for (int k = 0; k < 10; k++)
					{
						if (authCode[k] != this._slideBuffer[this._slideBufStartPos + k])
						{
							throw new Exception("AES Authentication Code does not match. This is a super-CRC check on the data in the file after compression and encryption. \r\nThe file may be damaged.");
						}
					}
					this._slideBuffer = null;
					break;
				}
				int num7 = this.TransformAndBufferBlock(buffer, offset, num, 16);
				i += num7;
				offset += num7;
			}
			return i;
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x0013E38C File Offset: 0x0013C58C
		private int ReadBufferedData(byte[] buffer, int offset, int count)
		{
			int num = Math.Min(count, this._transformBufferFreePos - this._transformBufferStartPos);
			Array.Copy(this._transformBuffer, this._transformBufferStartPos, buffer, offset, count);
			this._transformBufferStartPos += num;
			return num;
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x0013E3D0 File Offset: 0x0013C5D0
		private int TransformAndBufferBlock(byte[] buffer, int offset, int count, int blockSize)
		{
			bool flag = blockSize > count;
			if (flag && this._transformBuffer == null)
			{
				this._transformBuffer = new byte[16];
			}
			byte[] array = (flag ? this._transformBuffer : buffer);
			int num = (flag ? 0 : offset);
			this._transform.TransformBlock(this._slideBuffer, this._slideBufStartPos, blockSize, array, num);
			this._slideBufStartPos += blockSize;
			if (!flag)
			{
				return blockSize;
			}
			Array.Copy(this._transformBuffer, 0, buffer, offset, count);
			this._transformBufferStartPos = count;
			this._transformBufferFreePos = blockSize;
			return count;
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x0013E45E File Offset: 0x0013C65E
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000F54 RID: 3924
		private const int AUTH_CODE_LENGTH = 10;

		// Token: 0x04000F55 RID: 3925
		private const int CRYPTO_BLOCK_SIZE = 16;

		// Token: 0x04000F56 RID: 3926
		private const int BLOCK_AND_AUTH = 26;

		// Token: 0x04000F57 RID: 3927
		private Stream _stream;

		// Token: 0x04000F58 RID: 3928
		private ZipAESTransform _transform;

		// Token: 0x04000F59 RID: 3929
		private byte[] _slideBuffer;

		// Token: 0x04000F5A RID: 3930
		private int _slideBufStartPos;

		// Token: 0x04000F5B RID: 3931
		private int _slideBufFreePos;

		// Token: 0x04000F5C RID: 3932
		private byte[] _transformBuffer;

		// Token: 0x04000F5D RID: 3933
		private int _transformBufferFreePos;

		// Token: 0x04000F5E RID: 3934
		private int _transformBufferStartPos;
	}
}
