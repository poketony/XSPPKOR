using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200014C RID: 332
	public class KeysRequiredEventArgs : EventArgs
	{
		// Token: 0x06001793 RID: 6035 RVA: 0x001305DE File Offset: 0x0012E7DE
		public KeysRequiredEventArgs(string name)
		{
			this.fileName = name;
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x001305ED File Offset: 0x0012E7ED
		public KeysRequiredEventArgs(string name, byte[] keyValue)
		{
			this.fileName = name;
			this.key = keyValue;
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06001795 RID: 6037 RVA: 0x00130603 File Offset: 0x0012E803
		public string FileName
		{
			get
			{
				return this.fileName;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x0013060B File Offset: 0x0012E80B
		// (set) Token: 0x06001797 RID: 6039 RVA: 0x00130613 File Offset: 0x0012E813
		public byte[] Key
		{
			get
			{
				return this.key;
			}
			set
			{
				this.key = value;
			}
		}

		// Token: 0x04000D9E RID: 3486
		private readonly string fileName;

		// Token: 0x04000D9F RID: 3487
		private byte[] key;
	}
}
