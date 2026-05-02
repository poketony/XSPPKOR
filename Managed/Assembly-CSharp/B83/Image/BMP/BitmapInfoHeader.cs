using System;
using UnityEngine;

namespace B83.Image.BMP
{
	// Token: 0x02000069 RID: 105
	public struct BitmapInfoHeader
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x001111A6 File Offset: 0x0010F3A6
		public int absWidth
		{
			get
			{
				return Mathf.Abs(this.width);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x001111B3 File Offset: 0x0010F3B3
		public int absHeight
		{
			get
			{
				return Mathf.Abs(this.height);
			}
		}

		// Token: 0x040008AC RID: 2220
		public uint size;

		// Token: 0x040008AD RID: 2221
		public int width;

		// Token: 0x040008AE RID: 2222
		public int height;

		// Token: 0x040008AF RID: 2223
		public ushort nColorPlanes;

		// Token: 0x040008B0 RID: 2224
		public ushort nBitsPerPixel;

		// Token: 0x040008B1 RID: 2225
		public BMPComressionMode compressionMethod;

		// Token: 0x040008B2 RID: 2226
		public uint rawImageSize;

		// Token: 0x040008B3 RID: 2227
		public int xPPM;

		// Token: 0x040008B4 RID: 2228
		public int yPPM;

		// Token: 0x040008B5 RID: 2229
		public uint nPaletteColors;

		// Token: 0x040008B6 RID: 2230
		public uint nImportantColors;
	}
}
