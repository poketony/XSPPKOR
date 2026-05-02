using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	// Token: 0x02000186 RID: 390
	internal class PkzipClassicDecryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform, IDisposable
	{
		// Token: 0x06001A79 RID: 6777 RVA: 0x0013E02C File Offset: 0x0013C22C
		internal PkzipClassicDecryptCryptoTransform(byte[] keyBlock)
		{
			base.SetKeys(keyBlock);
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x0013E03C File Offset: 0x0013C23C
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] array = new byte[inputCount];
			this.TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
			return array;
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x0013E060 File Offset: 0x0013C260
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; i++)
			{
				byte b = inputBuffer[i] ^ base.TransformByte();
				outputBuffer[outputOffset++] = b;
				base.UpdateKeys(b);
			}
			return inputCount;
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06001A7C RID: 6780 RVA: 0x0013E09A File Offset: 0x0013C29A
		public bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06001A7D RID: 6781 RVA: 0x0013E09D File Offset: 0x0013C29D
		public int InputBlockSize
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06001A7E RID: 6782 RVA: 0x0013E0A0 File Offset: 0x0013C2A0
		public int OutputBlockSize
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06001A7F RID: 6783 RVA: 0x0013E0A3 File Offset: 0x0013C2A3
		public bool CanTransformMultipleBlocks
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x0013E0A6 File Offset: 0x0013C2A6
		public void Dispose()
		{
			base.Reset();
		}
	}
}
