using System;
using Socotra.Opt.UI.J3d;
using Socotra.UI;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.Opt.UI
{
	// Token: 0x0200010A RID: 266
	public class StGraphics2 : StGraphics
	{
		// Token: 0x060014AB RID: 5291 RVA: 0x00127A36 File Offset: 0x00125C36
		public new void Awake()
		{
			base.Awake();
			this.currentMaterial = SingletonBehaviour<StScreenManager>.Instance.defaultMaterial;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x00127A4E File Offset: 0x00125C4E
		public void DrawImage(Image image, AffineTrans at)
		{
			Debug.LogWarning("Use dummy method");
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x00127A5A File Offset: 0x00125C5A
		public void DrawImage(Image image, AffineTrans at, int sx, int sy, int width, int height)
		{
			Debug.LogWarning("Use dummy method");
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x00127A66 File Offset: 0x00125C66
		public void DrawNthImage(Image image, int k, int x, int y)
		{
			Debug.LogWarning("Use dummy method");
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x00127A72 File Offset: 0x00125C72
		public void DrawNumber(int x, int y, int value, int digit)
		{
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x00127A74 File Offset: 0x00125C74
		public Image GetImage(int x, int y, int width, int height)
		{
			Debug.LogWarning("Use dummy method");
			return null;
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x00127A81 File Offset: 0x00125C81
		public static int GetIntermediateColor(int color1, int color2, int ratio)
		{
			Debug.LogWarning("Use dummy method");
			return -1;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x00127A8E File Offset: 0x00125C8E
		public int GetSyncUnlockInterval()
		{
			Debug.LogWarning("Use dummy method");
			return -1;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x00127A9B File Offset: 0x00125C9B
		public void SetCoordinateMode(int mode)
		{
			Debug.LogWarning("Use dummy method");
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x00127AA8 File Offset: 0x00125CA8
		public void SetRenderMode(int op, int srcRatio, int dstRatio)
		{
			switch (op)
			{
			case 0:
				this.currentMaterial = SingletonBehaviour<StScreenManager>.Instance.defaultMaterial;
				this.renderModeOpAddSrcAlpha = -1f;
				return;
			case 1:
			{
				this.currentMaterial = SingletonBehaviour<StScreenManager>.Instance.optionAddMaterial;
				float num = (float)srcRatio / 255f;
				float num2 = (float)dstRatio / 255f;
				this.currentMaterial.SetColor("_SrcBlend", new Color(0f, 0f, 0f, num));
				this.currentMaterial.SetColor("_DstBlend", new Color(0f, 0f, 0f, num2));
				this.renderModeOpAddSrcAlpha = num;
				return;
			}
			case 2:
				this.currentMaterial = SingletonBehaviour<StScreenManager>.Instance.optionAddMaterial;
				this.renderModeOpAddSrcAlpha = -1f;
				return;
			default:
				return;
			}
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00127B73 File Offset: 0x00125D73
		public int syncUnlock(int interval)
		{
			Debug.LogWarning("Use dummy method");
			return -1;
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x00127B80 File Offset: 0x00125D80
		protected override Material GetGlMaterial()
		{
			return this.currentMaterial;
		}

		// Token: 0x04000C18 RID: 3096
		public static int CM_NORMAL = 0;

		// Token: 0x04000C19 RID: 3097
		public static int CM_ZOOM = 256;

		// Token: 0x04000C1A RID: 3098
		public const int OP_ADD = 1;

		// Token: 0x04000C1B RID: 3099
		public const int OP_REPL = 0;

		// Token: 0x04000C1C RID: 3100
		public const int OP_SUB = 2;

		// Token: 0x04000C1D RID: 3101
		public Material currentMaterial;
	}
}
