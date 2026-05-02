using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	// Token: 0x02000187 RID: 391
	public sealed class PkzipClassicManaged : PkzipClassic
	{
		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06001A81 RID: 6785 RVA: 0x0013E0AE File Offset: 0x0013C2AE
		// (set) Token: 0x06001A82 RID: 6786 RVA: 0x0013E0B1 File Offset: 0x0013C2B1
		public override int BlockSize
		{
			get
			{
				return 8;
			}
			set
			{
				if (value != 8)
				{
					throw new CryptographicException("Block size is invalid");
				}
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06001A83 RID: 6787 RVA: 0x0013E0C2 File Offset: 0x0013C2C2
		public override KeySizes[] LegalKeySizes
		{
			get
			{
				return new KeySizes[]
				{
					new KeySizes(96, 96, 0)
				};
			}
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x0013E0D7 File Offset: 0x0013C2D7
		public override void GenerateIV()
		{
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06001A85 RID: 6789 RVA: 0x0013E0D9 File Offset: 0x0013C2D9
		public override KeySizes[] LegalBlockSizes
		{
			get
			{
				return new KeySizes[]
				{
					new KeySizes(8, 8, 0)
				};
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06001A86 RID: 6790 RVA: 0x0013E0EC File Offset: 0x0013C2EC
		// (set) Token: 0x06001A87 RID: 6791 RVA: 0x0013E10C File Offset: 0x0013C30C
		public override byte[] Key
		{
			get
			{
				if (this.key_ == null)
				{
					this.GenerateKey();
				}
				return (byte[])this.key_.Clone();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != 12)
				{
					throw new CryptographicException("Key size is illegal");
				}
				this.key_ = (byte[])value.Clone();
			}
		}

		// Token: 0x06001A88 RID: 6792 RVA: 0x0013E13F File Offset: 0x0013C33F
		public override void GenerateKey()
		{
			this.key_ = new byte[12];
			new Random().NextBytes(this.key_);
		}

		// Token: 0x06001A89 RID: 6793 RVA: 0x0013E15E File Offset: 0x0013C35E
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			this.key_ = rgbKey;
			return new PkzipClassicEncryptCryptoTransform(this.Key);
		}

		// Token: 0x06001A8A RID: 6794 RVA: 0x0013E172 File Offset: 0x0013C372
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			this.key_ = rgbKey;
			return new PkzipClassicDecryptCryptoTransform(this.Key);
		}

		// Token: 0x04000F53 RID: 3923
		private byte[] key_;
	}
}
