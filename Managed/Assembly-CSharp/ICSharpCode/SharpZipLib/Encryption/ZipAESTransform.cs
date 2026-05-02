using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	// Token: 0x02000189 RID: 393
	internal class ZipAESTransform : ICryptoTransform, IDisposable
	{
		// Token: 0x06001A93 RID: 6803 RVA: 0x0013E468 File Offset: 0x0013C668
		public ZipAESTransform(string key, byte[] saltBytes, int blockSize, bool writeMode)
		{
			if (blockSize != 16 && blockSize != 32)
			{
				throw new Exception("Invalid blocksize " + blockSize.ToString() + ". Must be 16 or 32.");
			}
			if (saltBytes.Length != blockSize / 2)
			{
				throw new Exception("Invalid salt len. Must be " + (blockSize / 2).ToString() + " for blocksize " + blockSize.ToString());
			}
			this._blockSize = blockSize;
			this._encryptBuffer = new byte[this._blockSize];
			this._encrPos = 16;
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, saltBytes, 1000);
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.ECB;
			this._counterNonce = new byte[this._blockSize];
			byte[] bytes = rfc2898DeriveBytes.GetBytes(this._blockSize);
			byte[] bytes2 = rfc2898DeriveBytes.GetBytes(this._blockSize);
			this._encryptor = aes.CreateEncryptor(bytes, new byte[16]);
			this._pwdVerifier = rfc2898DeriveBytes.GetBytes(2);
			this._hmacsha1 = IncrementalHash.CreateHMAC(HashAlgorithmName.SHA1, bytes2);
			this._writeMode = writeMode;
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x0013E570 File Offset: 0x0013C770
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			if (!this._writeMode)
			{
				this._hmacsha1.AppendData(inputBuffer, inputOffset, inputCount);
			}
			for (int i = 0; i < inputCount; i++)
			{
				if (this._encrPos == 16)
				{
					int num = 0;
					for (;;)
					{
						byte[] counterNonce = this._counterNonce;
						int num2 = num;
						byte b = counterNonce[num2] + 1;
						counterNonce[num2] = b;
						if (b != 0)
						{
							break;
						}
						num++;
					}
					this._encryptor.TransformBlock(this._counterNonce, 0, this._blockSize, this._encryptBuffer, 0);
					this._encrPos = 0;
				}
				int num3 = i + outputOffset;
				byte b2 = inputBuffer[i + inputOffset];
				byte[] encryptBuffer = this._encryptBuffer;
				int encrPos = this._encrPos;
				this._encrPos = encrPos + 1;
				outputBuffer[num3] = b2 ^ encryptBuffer[encrPos];
			}
			if (this._writeMode)
			{
				this._hmacsha1.AppendData(outputBuffer, outputOffset, inputCount);
			}
			return inputCount;
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06001A95 RID: 6805 RVA: 0x0013E62E File Offset: 0x0013C82E
		public byte[] PwdVerifier
		{
			get
			{
				return this._pwdVerifier;
			}
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x0013E636 File Offset: 0x0013C836
		public byte[] GetAuthCode()
		{
			if (this._authCode == null)
			{
				this._authCode = this._hmacsha1.GetHashAndReset();
			}
			return this._authCode;
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x0013E657 File Offset: 0x0013C857
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			if (inputCount > 0)
			{
				throw new NotImplementedException("TransformFinalBlock is not implemented and inputCount is greater than 0");
			}
			return new byte[0];
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06001A98 RID: 6808 RVA: 0x0013E66E File Offset: 0x0013C86E
		public int InputBlockSize
		{
			get
			{
				return this._blockSize;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06001A99 RID: 6809 RVA: 0x0013E676 File Offset: 0x0013C876
		public int OutputBlockSize
		{
			get
			{
				return this._blockSize;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06001A9A RID: 6810 RVA: 0x0013E67E File Offset: 0x0013C87E
		public bool CanTransformMultipleBlocks
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06001A9B RID: 6811 RVA: 0x0013E681 File Offset: 0x0013C881
		public bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x0013E684 File Offset: 0x0013C884
		public void Dispose()
		{
			this._encryptor.Dispose();
		}

		// Token: 0x04000F5F RID: 3935
		private const int PWD_VER_LENGTH = 2;

		// Token: 0x04000F60 RID: 3936
		private const int KEY_ROUNDS = 1000;

		// Token: 0x04000F61 RID: 3937
		private const int ENCRYPT_BLOCK = 16;

		// Token: 0x04000F62 RID: 3938
		private int _blockSize;

		// Token: 0x04000F63 RID: 3939
		private readonly ICryptoTransform _encryptor;

		// Token: 0x04000F64 RID: 3940
		private readonly byte[] _counterNonce;

		// Token: 0x04000F65 RID: 3941
		private byte[] _encryptBuffer;

		// Token: 0x04000F66 RID: 3942
		private int _encrPos;

		// Token: 0x04000F67 RID: 3943
		private byte[] _pwdVerifier;

		// Token: 0x04000F68 RID: 3944
		private IncrementalHash _hmacsha1;

		// Token: 0x04000F69 RID: 3945
		private byte[] _authCode;

		// Token: 0x04000F6A RID: 3946
		private bool _writeMode;
	}
}
