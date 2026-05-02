using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200015C RID: 348
	internal class EntryPatchData
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06001837 RID: 6199 RVA: 0x00133A70 File Offset: 0x00131C70
		// (set) Token: 0x06001838 RID: 6200 RVA: 0x00133A78 File Offset: 0x00131C78
		public long SizePatchOffset
		{
			get
			{
				return this.sizePatchOffset_;
			}
			set
			{
				this.sizePatchOffset_ = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06001839 RID: 6201 RVA: 0x00133A81 File Offset: 0x00131C81
		// (set) Token: 0x0600183A RID: 6202 RVA: 0x00133A89 File Offset: 0x00131C89
		public long CrcPatchOffset
		{
			get
			{
				return this.crcPatchOffset_;
			}
			set
			{
				this.crcPatchOffset_ = value;
			}
		}

		// Token: 0x04000DD5 RID: 3541
		private long sizePatchOffset_;

		// Token: 0x04000DD6 RID: 3542
		private long crcPatchOffset_;
	}
}
