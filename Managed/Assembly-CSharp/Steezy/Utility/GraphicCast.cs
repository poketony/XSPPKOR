using System;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x0200009E RID: 158
	public class GraphicCast : Graphic
	{
		// Token: 0x06001013 RID: 4115 RVA: 0x00116E35 File Offset: 0x00115035
		protected override void OnPopulateMesh(VertexHelper v)
		{
			base.OnPopulateMesh(v);
			v.Clear();
		}
	}
}
