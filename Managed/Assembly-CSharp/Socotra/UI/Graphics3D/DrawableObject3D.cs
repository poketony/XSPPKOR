using System;
using Socotra.Util3d;

namespace Socotra.UI.Graphics3D
{
	// Token: 0x02000105 RID: 261
	public class DrawableObject3D : Object3D
	{
		// Token: 0x06001476 RID: 5238 RVA: 0x0012751D File Offset: 0x0012571D
		public bool IsCross(DrawableObject3D obj, StTransform t_myself, StTransform t_obj)
		{
			return false;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x00127520 File Offset: 0x00125720
		public virtual void SetBlendMode(int mode)
		{
			this.blendMode = mode;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x00127529 File Offset: 0x00125729
		public virtual void SetPerspectiveCorrectionEnabled(bool isOn)
		{
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x0012752B File Offset: 0x0012572B
		public virtual void SetTransparency(float v)
		{
			this.transparency = v;
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x00127534 File Offset: 0x00125734
		public virtual float GetTransparency()
		{
			return this.transparency;
		}

		// Token: 0x04000BE6 RID: 3046
		public const int BLEND_ADD = 64;

		// Token: 0x04000BE7 RID: 3047
		public const int BLEND_ALPHA = 32;

		// Token: 0x04000BE8 RID: 3048
		public const int BLEND_NORMAL = 0;

		// Token: 0x04000BE9 RID: 3049
		public int blendMode;

		// Token: 0x04000BEA RID: 3050
		public float transparency = 1f;
	}
}
