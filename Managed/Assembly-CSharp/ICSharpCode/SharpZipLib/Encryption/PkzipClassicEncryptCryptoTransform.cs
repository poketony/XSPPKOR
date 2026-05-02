using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	// Token: 0x02000185 RID: 389
	internal class PkzipClassicEncryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform, IDisposable
	{
		// Token: 0x06001A71 RID: 6769 RVA: 0x0013DFA7 File Offset: 0x0013C1A7
		internal PkzipClassicEncryptCryptoTransform(byte[] keyBlock)
		{
			base.SetKeys(keyBlock);
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x0013DFB8 File Offset: 0x0013C1B8
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] array = new byte[inputCount];
			this.TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
			return array;
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x0013DFDC File Offset: 0x0013C1DC
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; i++)
			{
				byte b = inputBuffer[i];
				outputBuffer[outputOffset++] = inputBuffer[i] ^ base.TransformByte();
				base.UpdateKeys(b);
			}
			return inputCount;
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06001A74 RID: 6772 RVA: 0x0013E018 File Offset: 0x0013C218
		public bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06001A75 RID: 6773 RVA: 0x0013E01B File Offset: 0x0013C21B
		public int InputBlockSize
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06001A76 RID: 6774 RVA: 0x0013E01E File Offset: 0x0013C21E
		public int OutputBlockSize
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06001A77 RID: 6775 RVA: 0x0013E021 File Offset: 0x0013C221
		public bool CanTransformMultipleBlocks
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x0013E024 File Offset: 0x0013C224
		public void Dispose()
		{
			base.Reset();
		}
	}
}
