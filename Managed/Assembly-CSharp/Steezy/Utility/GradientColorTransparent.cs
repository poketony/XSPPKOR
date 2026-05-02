using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x020000A1 RID: 161
	[AddComponentMenu("UI/Effects/Gradient Color Transparent")]
	[RequireComponent(typeof(Graphic))]
	public class GradientColorTransparent : BaseMeshEffect
	{
		// Token: 0x0600101D RID: 4125 RVA: 0x0011701C File Offset: 0x0011521C
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!this.IsActive())
			{
				return;
			}
			List<UIVertex> list = new List<UIVertex>();
			vh.GetUIVertexStream(list);
			this.ModifyVertices(list);
			vh.Clear();
			vh.AddUIVertexTriangleStream(list);
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x00117054 File Offset: 0x00115254
		public void ModifyVertices(List<UIVertex> vList)
		{
			if (!this.IsActive() || vList == null || vList.Count == 0)
			{
				return;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < vList.Count; i++)
			{
				UIVertex uivertex = vList[i];
				num = Mathf.Max(num, uivertex.position.x);
				num2 = Mathf.Max(num2, uivertex.position.y);
				num3 = Mathf.Min(num3, uivertex.position.x);
				num4 = Mathf.Min(num4, uivertex.position.y);
			}
			float num5 = num - num3;
			float num6 = num2 - num4;
			UIVertex uivertex2 = vList[0];
			for (int j = 0; j < vList.Count; j++)
			{
				uivertex2 = vList[j];
				float a = uivertex2.color.a;
				Color color = uivertex2.color;
				Color color2 = Color.Lerp(this.colorBottom, this.colorTop, (uivertex2.position.y - num4) / num6);
				Color color3 = Color.Lerp(this.colorLeft, this.colorRight, (uivertex2.position.x - num3) / num5);
				switch (this.direction)
				{
				case GradientColorTransparent.DIRECTION.Vertical:
					uivertex2.color = color * color2;
					break;
				case GradientColorTransparent.DIRECTION.Horizontal:
					uivertex2.color = color * color3;
					break;
				case GradientColorTransparent.DIRECTION.Both:
					uivertex2.color = color * color2 * color3;
					break;
				}
				uivertex2.color.a = (byte)((float)uivertex2.color.a * a);
				vList[j] = uivertex2;
			}
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x00117227 File Offset: 0x00115427
		public void Refresh()
		{
			if (base.graphic != null)
			{
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x0400098A RID: 2442
		public GradientColorTransparent.DIRECTION direction = GradientColorTransparent.DIRECTION.Both;

		// Token: 0x0400098B RID: 2443
		public Color colorTop = Color.white;

		// Token: 0x0400098C RID: 2444
		public Color colorBottom = Color.black;

		// Token: 0x0400098D RID: 2445
		public Color colorLeft = Color.red;

		// Token: 0x0400098E RID: 2446
		public Color colorRight = Color.blue;

		// Token: 0x0200020A RID: 522
		public enum DIRECTION
		{
			// Token: 0x04001409 RID: 5129
			Vertical,
			// Token: 0x0400140A RID: 5130
			Horizontal,
			// Token: 0x0400140B RID: 5131
			Both
		}
	}
}
