using System;
using System.Collections.Generic;
using UnityEngine;

namespace B83.Image.BMP
{
	// Token: 0x0200006A RID: 106
	public class BMPImage
	{
		// Token: 0x06000E6A RID: 3690 RVA: 0x001111C0 File Offset: 0x0010F3C0
		public Texture2D ToTexture2D()
		{
			Texture2D texture2D = new Texture2D(this.info.absWidth, this.info.absHeight);
			texture2D.SetPixels32(this.imageData);
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x040008B7 RID: 2231
		public BMPFileHeader header;

		// Token: 0x040008B8 RID: 2232
		public BitmapInfoHeader info;

		// Token: 0x040008B9 RID: 2233
		public uint rMask = 16711680U;

		// Token: 0x040008BA RID: 2234
		public uint gMask = 65280U;

		// Token: 0x040008BB RID: 2235
		public uint bMask = 255U;

		// Token: 0x040008BC RID: 2236
		public uint aMask;

		// Token: 0x040008BD RID: 2237
		public List<Color32> palette;

		// Token: 0x040008BE RID: 2238
		public Color32[] imageData;
	}
}
