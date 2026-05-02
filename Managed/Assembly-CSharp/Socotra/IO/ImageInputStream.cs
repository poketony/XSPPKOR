using System;

namespace Socotra.IO
{
	// Token: 0x02000128 RID: 296
	public class ImageInputStream : InputStream
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06001648 RID: 5704 RVA: 0x0012D2A3 File Offset: 0x0012B4A3
		public ScratchPadDataImage Image
		{
			get
			{
				return this.baseImage;
			}
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x0012D2AB File Offset: 0x0012B4AB
		public ImageInputStream(ScratchPadDataImage image)
		{
			this.baseImage = image;
		}

		// Token: 0x04000CCC RID: 3276
		private ScratchPadDataImage baseImage;
	}
}
