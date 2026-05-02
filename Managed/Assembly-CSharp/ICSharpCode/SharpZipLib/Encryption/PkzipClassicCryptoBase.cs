using System;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.Encryption
{
	// Token: 0x02000184 RID: 388
	internal class PkzipClassicCryptoBase
	{
		// Token: 0x06001A6C RID: 6764 RVA: 0x0013DE56 File Offset: 0x0013C056
		protected byte TransformByte()
		{
			uint num = (this.keys[2] & 65535U) | 2U;
			return (byte)(num * (num ^ 1U) >> 8);
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x0013DE70 File Offset: 0x0013C070
		protected void SetKeys(byte[] keyData)
		{
			if (keyData == null)
			{
				throw new ArgumentNullException("keyData");
			}
			if (keyData.Length != 12)
			{
				throw new InvalidOperationException("Key length is not valid");
			}
			this.keys = new uint[3];
			this.keys[0] = (uint)(((int)keyData[3] << 24) | ((int)keyData[2] << 16) | ((int)keyData[1] << 8) | (int)keyData[0]);
			this.keys[1] = (uint)(((int)keyData[7] << 24) | ((int)keyData[6] << 16) | ((int)keyData[5] << 8) | (int)keyData[4]);
			this.keys[2] = (uint)(((int)keyData[11] << 24) | ((int)keyData[10] << 16) | ((int)keyData[9] << 8) | (int)keyData[8]);
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x0013DF0C File Offset: 0x0013C10C
		protected void UpdateKeys(byte ch)
		{
			this.keys[0] = Crc32.ComputeCrc32(this.keys[0], ch);
			this.keys[1] = this.keys[1] + (uint)((byte)this.keys[0]);
			this.keys[1] = this.keys[1] * 134775813U + 1U;
			this.keys[2] = Crc32.ComputeCrc32(this.keys[2], (byte)(this.keys[1] >> 24));
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x0013DF82 File Offset: 0x0013C182
		protected void Reset()
		{
			this.keys[0] = 0U;
			this.keys[1] = 0U;
			this.keys[2] = 0U;
		}

		// Token: 0x04000F52 RID: 3922
		private uint[] keys;
	}
}
