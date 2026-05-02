using System;
using System.IO;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Encryption;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x0200016C RID: 364
	public class DeflaterOutputStream : Stream
	{
		// Token: 0x060018FF RID: 6399 RVA: 0x00138DD7 File Offset: 0x00136FD7
		public DeflaterOutputStream(Stream baseOutputStream)
			: this(baseOutputStream, new Deflater(), 512)
		{
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00138DEA File Offset: 0x00136FEA
		public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater)
			: this(baseOutputStream, deflater, 512)
		{
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00138DFC File Offset: 0x00136FFC
		public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufferSize)
		{
			if (baseOutputStream == null)
			{
				throw new ArgumentNullException("baseOutputStream");
			}
			if (!baseOutputStream.CanWrite)
			{
				throw new ArgumentException("Must support writing", "baseOutputStream");
			}
			if (bufferSize < 512)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			this.baseOutputStream_ = baseOutputStream;
			this.buffer_ = new byte[bufferSize];
			if (deflater == null)
			{
				throw new ArgumentNullException("deflater");
			}
			this.deflater_ = deflater;
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00138E78 File Offset: 0x00137078
		public virtual void Finish()
		{
			this.deflater_.Finish();
			while (!this.deflater_.IsFinished)
			{
				int num = this.deflater_.Deflate(this.buffer_, 0, this.buffer_.Length);
				if (num <= 0)
				{
					break;
				}
				if (this.cryptoTransform_ != null)
				{
					this.EncryptBlock(this.buffer_, 0, num);
				}
				this.baseOutputStream_.Write(this.buffer_, 0, num);
			}
			if (!this.deflater_.IsFinished)
			{
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			this.baseOutputStream_.Flush();
			if (this.cryptoTransform_ != null)
			{
				if (this.cryptoTransform_ is ZipAESTransform)
				{
					this.AESAuthCode = ((ZipAESTransform)this.cryptoTransform_).GetAuthCode();
				}
				this.cryptoTransform_.Dispose();
				this.cryptoTransform_ = null;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06001903 RID: 6403 RVA: 0x00138F47 File Offset: 0x00137147
		// (set) Token: 0x06001904 RID: 6404 RVA: 0x00138F4F File Offset: 0x0013714F
		public bool IsStreamOwner { get; set; } = true;

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06001905 RID: 6405 RVA: 0x00138F58 File Offset: 0x00137158
		public bool CanPatchEntries
		{
			get
			{
				return this.baseOutputStream_.CanSeek;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06001906 RID: 6406 RVA: 0x00138F65 File Offset: 0x00137165
		// (set) Token: 0x06001907 RID: 6407 RVA: 0x00138F6D File Offset: 0x0013716D
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				if (value != null && value.Length == 0)
				{
					this.password = null;
					return;
				}
				this.password = value;
			}
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00138F89 File Offset: 0x00137189
		protected void EncryptBlock(byte[] buffer, int offset, int length)
		{
			this.cryptoTransform_.TransformBlock(buffer, 0, length, buffer, 0);
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x00138F9C File Offset: 0x0013719C
		protected void InitializePassword(string password)
		{
			PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
			byte[] array = PkzipClassic.GenerateKeys(ZipStrings.ConvertToArray(password));
			this.cryptoTransform_ = pkzipClassicManaged.CreateEncryptor(array, null);
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x00138FCC File Offset: 0x001371CC
		protected void InitializeAESPassword(ZipEntry entry, string rawPassword, out byte[] salt, out byte[] pwdVerifier)
		{
			salt = new byte[entry.AESSaltLen];
			if (DeflaterOutputStream._aesRnd == null)
			{
				DeflaterOutputStream._aesRnd = RandomNumberGenerator.Create();
			}
			DeflaterOutputStream._aesRnd.GetBytes(salt);
			int num = entry.AESKeySize / 8;
			this.cryptoTransform_ = new ZipAESTransform(rawPassword, salt, num, true);
			pwdVerifier = ((ZipAESTransform)this.cryptoTransform_).PwdVerifier;
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x0013902F File Offset: 0x0013722F
		protected void Deflate()
		{
			this.Deflate(false);
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x00139038 File Offset: 0x00137238
		private void Deflate(bool flushing)
		{
			while (flushing || !this.deflater_.IsNeedingInput)
			{
				int num = this.deflater_.Deflate(this.buffer_, 0, this.buffer_.Length);
				if (num <= 0)
				{
					break;
				}
				if (this.cryptoTransform_ != null)
				{
					this.EncryptBlock(this.buffer_, 0, num);
				}
				this.baseOutputStream_.Write(this.buffer_, 0, num);
			}
			if (!this.deflater_.IsNeedingInput)
			{
				throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600190D RID: 6413 RVA: 0x001390B7 File Offset: 0x001372B7
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600190E RID: 6414 RVA: 0x001390BA File Offset: 0x001372BA
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600190F RID: 6415 RVA: 0x001390BD File Offset: 0x001372BD
		public override bool CanWrite
		{
			get
			{
				return this.baseOutputStream_.CanWrite;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06001910 RID: 6416 RVA: 0x001390CA File Offset: 0x001372CA
		public override long Length
		{
			get
			{
				return this.baseOutputStream_.Length;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06001911 RID: 6417 RVA: 0x001390D7 File Offset: 0x001372D7
		// (set) Token: 0x06001912 RID: 6418 RVA: 0x001390E4 File Offset: 0x001372E4
		public override long Position
		{
			get
			{
				return this.baseOutputStream_.Position;
			}
			set
			{
				throw new NotSupportedException("Position property not supported");
			}
		}

		// Token: 0x06001913 RID: 6419 RVA: 0x001390F0 File Offset: 0x001372F0
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DeflaterOutputStream Seek not supported");
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x001390FC File Offset: 0x001372FC
		public override void SetLength(long value)
		{
			throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x00139108 File Offset: 0x00137308
		public override int ReadByte()
		{
			throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
		}

		// Token: 0x06001916 RID: 6422 RVA: 0x00139114 File Offset: 0x00137314
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("DeflaterOutputStream Read not supported");
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x00139120 File Offset: 0x00137320
		public override void Flush()
		{
			this.deflater_.Flush();
			this.Deflate(true);
			this.baseOutputStream_.Flush();
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x00139140 File Offset: 0x00137340
		protected override void Dispose(bool disposing)
		{
			if (!this.isClosed_)
			{
				this.isClosed_ = true;
				try
				{
					this.Finish();
					if (this.cryptoTransform_ != null)
					{
						this.GetAuthCodeIfAES();
						this.cryptoTransform_.Dispose();
						this.cryptoTransform_ = null;
					}
				}
				finally
				{
					if (this.IsStreamOwner)
					{
						this.baseOutputStream_.Dispose();
					}
				}
			}
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x001391A8 File Offset: 0x001373A8
		protected void GetAuthCodeIfAES()
		{
			if (this.cryptoTransform_ is ZipAESTransform)
			{
				this.AESAuthCode = ((ZipAESTransform)this.cryptoTransform_).GetAuthCode();
			}
		}

		// Token: 0x0600191A RID: 6426 RVA: 0x001391D0 File Offset: 0x001373D0
		public override void WriteByte(byte value)
		{
			this.Write(new byte[] { value }, 0, 1);
		}

		// Token: 0x0600191B RID: 6427 RVA: 0x001391F1 File Offset: 0x001373F1
		public override void Write(byte[] buffer, int offset, int count)
		{
			this.deflater_.SetInput(buffer, offset, count);
			this.Deflate();
		}

		// Token: 0x04000E8E RID: 3726
		private string password;

		// Token: 0x04000E8F RID: 3727
		private ICryptoTransform cryptoTransform_;

		// Token: 0x04000E90 RID: 3728
		protected byte[] AESAuthCode;

		// Token: 0x04000E91 RID: 3729
		private byte[] buffer_;

		// Token: 0x04000E92 RID: 3730
		protected Deflater deflater_;

		// Token: 0x04000E93 RID: 3731
		protected Stream baseOutputStream_;

		// Token: 0x04000E94 RID: 3732
		private bool isClosed_;

		// Token: 0x04000E95 RID: 3733
		private static RandomNumberGenerator _aesRnd = RandomNumberGenerator.Create();
	}
}
