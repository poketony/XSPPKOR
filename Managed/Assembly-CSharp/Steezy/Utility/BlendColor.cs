using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x020000A0 RID: 160
	[AddComponentMenu("UI/Effects/Blend Color")]
	[RequireComponent(typeof(Graphic))]
	public class BlendColor : BaseMeshEffect
	{
		// Token: 0x06001019 RID: 4121 RVA: 0x00116E9C File Offset: 0x0011509C
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

		// Token: 0x0600101A RID: 4122 RVA: 0x00116ED4 File Offset: 0x001150D4
		public void ModifyVertices(List<UIVertex> vList)
		{
			if (!this.IsActive() || vList == null || vList.Count == 0)
			{
				return;
			}
			UIVertex uivertex = vList[0];
			for (int i = 0; i < vList.Count; i++)
			{
				uivertex = vList[i];
				byte a = uivertex.color.a;
				switch (this.blendMode)
				{
				case BlendColor.BLEND_MODE.Multiply:
					uivertex.color *= this.color;
					break;
				case BlendColor.BLEND_MODE.Additive:
					uivertex.color += this.color;
					break;
				case BlendColor.BLEND_MODE.Subtractive:
					uivertex.color -= this.color;
					break;
				case BlendColor.BLEND_MODE.Override:
					uivertex.color = this.color;
					break;
				}
				uivertex.color.a = a;
				vList[i] = uivertex;
			}
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x00116FEC File Offset: 0x001151EC
		public void Refresh()
		{
			if (base.graphic != null)
			{
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x04000988 RID: 2440
		public BlendColor.BLEND_MODE blendMode;

		// Token: 0x04000989 RID: 2441
		public Color color = Color.grey;

		// Token: 0x02000209 RID: 521
		public enum BLEND_MODE
		{
			// Token: 0x04001404 RID: 5124
			Multiply,
			// Token: 0x04001405 RID: 5125
			Additive,
			// Token: 0x04001406 RID: 5126
			Subtractive,
			// Token: 0x04001407 RID: 5127
			Override
		}
	}
}
