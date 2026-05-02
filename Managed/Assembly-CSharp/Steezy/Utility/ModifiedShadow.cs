using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x020000A7 RID: 167
	public class ModifiedShadow : Shadow
	{
		// Token: 0x0600103D RID: 4157 RVA: 0x00117AC8 File Offset: 0x00115CC8
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!this.IsActive())
			{
				return;
			}
			List<UIVertex> list = ListPool<UIVertex>.Get();
			vh.GetUIVertexStream(list);
			this.ModifyVertices(list);
			vh.Clear();
			vh.AddUIVertexTriangleStream(list);
			ListPool<UIVertex>.Release(list);
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00117B05 File Offset: 0x00115D05
		public virtual void ModifyVertices(List<UIVertex> verts)
		{
		}
	}
}
