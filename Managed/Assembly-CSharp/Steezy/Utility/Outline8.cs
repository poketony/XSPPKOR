using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000A9 RID: 169
	public class Outline8 : ModifiedShadow
	{
		// Token: 0x06001047 RID: 4167 RVA: 0x00117C14 File Offset: 0x00115E14
		public override void ModifyVertices(List<UIVertex> verts)
		{
			if (!this.IsActive())
			{
				return;
			}
			int num = verts.Count * 9;
			if (verts.Capacity < num)
			{
				verts.Capacity = num;
			}
			int count = verts.Count;
			int num2 = 0;
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i != 0 || j != 0)
					{
						int num3 = num2 + count;
						base.ApplyShadow(verts, base.effectColor, num2, num3, base.effectDistance.x * (float)i, base.effectDistance.y * (float)j);
						num2 = num3;
					}
				}
			}
		}
	}
}
