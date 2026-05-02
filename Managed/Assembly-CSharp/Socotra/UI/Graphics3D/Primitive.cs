using System;
using Socotra.Opt.UI.J3d;

namespace Socotra.UI.Graphics3D
{
	// Token: 0x02000107 RID: 263
	public class Primitive : DrawableObject3D
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x0012772A File Offset: 0x0012592A
		public PrimitiveArray PrimitiveData
		{
			get
			{
				return this.primitiveImpl;
			}
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x00127732 File Offset: 0x00125932
		public Primitive(int type, int param, int n)
		{
			this.primitiveImpl = new PrimitiveArray(type, param, n);
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x00127748 File Offset: 0x00125948
		public override void SetBlendMode(int mode)
		{
			base.SetBlendMode(mode);
			this.primitiveImpl.SetBlendMode(mode);
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x0012775D File Offset: 0x0012595D
		public override void SetTransparency(float v)
		{
			base.SetTransparency(v);
			this.primitiveImpl.SetTransparency(v);
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00127772 File Offset: 0x00125972
		public void SetTexture(StTexture texture)
		{
			this.primitiveImpl.SetTexture(texture);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00127780 File Offset: 0x00125980
		public int[] GetVertexArray()
		{
			return this.primitiveImpl.GetVertexArray();
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0012778D File Offset: 0x0012598D
		public int[] GetColorArray()
		{
			return this.primitiveImpl.GetColorArray();
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0012779A File Offset: 0x0012599A
		public int[] GetNormalArray()
		{
			return this.primitiveImpl.GetNormalArray();
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x001277A7 File Offset: 0x001259A7
		public int[] GetTextureCoordArray()
		{
			return this.primitiveImpl.GetTextureCoordArray();
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x001277B4 File Offset: 0x001259B4
		public int[] GetPointSpriteArray()
		{
			return this.primitiveImpl.GetPointSpriteArray();
		}

		// Token: 0x04000BF4 RID: 3060
		public const int COLOR_NONE = 0;

		// Token: 0x04000BF5 RID: 3061
		public const int COLOR_PER_FACE = 2048;

		// Token: 0x04000BF6 RID: 3062
		public const int COLOR_PER_PRIMITIVE = 1024;

		// Token: 0x04000BF7 RID: 3063
		public const int NORMAL_NONE = 0;

		// Token: 0x04000BF8 RID: 3064
		public const int NORMAL_PER_FACE = 512;

		// Token: 0x04000BF9 RID: 3065
		public const int NORMAL_PER_VERTEX = 768;

		// Token: 0x04000BFA RID: 3066
		public const int POINT_SPRITE_FLAG_LOCAL_SIZE = 0;

		// Token: 0x04000BFB RID: 3067
		public const int POINT_SPRITE_FLAG_NO_PERSPECTIVE = 2;

		// Token: 0x04000BFC RID: 3068
		public const int POINT_SPRITE_FLAG_PERSPECTIVE = 0;

		// Token: 0x04000BFD RID: 3069
		public const int POINT_SPRITE_FLAG_PIXEL_SIZE = 1;

		// Token: 0x04000BFE RID: 3070
		public const int POINT_SPRITE_PER_PRIMITIVE = 4096;

		// Token: 0x04000BFF RID: 3071
		public const int POINT_SPRITE_PER_VERTEX = 12288;

		// Token: 0x04000C00 RID: 3072
		public const int PRIMITIVE_LINES = 2;

		// Token: 0x04000C01 RID: 3073
		public const int PRIMITIVE_POINT_SPRITES = 5;

		// Token: 0x04000C02 RID: 3074
		public const int PRIMITIVE_POINTS = 1;

		// Token: 0x04000C03 RID: 3075
		public const int PRIMITIVE_QUADS = 4;

		// Token: 0x04000C04 RID: 3076
		public const int PRIMITIVE_TRIANGLES = 3;

		// Token: 0x04000C05 RID: 3077
		public const int TEXTURE_COLORKEY = 16;

		// Token: 0x04000C06 RID: 3078
		public const int TEXTURE_COORD_NONE = 0;

		// Token: 0x04000C07 RID: 3079
		public const int TEXTURE_COORD_PER_VERTEX = 12288;

		// Token: 0x04000C08 RID: 3080
		private PrimitiveArray primitiveImpl;
	}
}
