using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000A4 RID: 164
	public class BoxOutline : ModifiedShadow
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x00117763 File Offset: 0x00115963
		// (set) Token: 0x0600102D RID: 4141 RVA: 0x0011776B File Offset: 0x0011596B
		public int halfSampleCountX
		{
			get
			{
				return this.m_halfSampleCountX;
			}
			set
			{
				this.m_halfSampleCountX = Mathf.Clamp(value, 1, 20);
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x00117795 File Offset: 0x00115995
		// (set) Token: 0x0600102F RID: 4143 RVA: 0x0011779D File Offset: 0x0011599D
		public int halfSampleCountY
		{
			get
			{
				return this.m_halfSampleCountY;
			}
			set
			{
				this.m_halfSampleCountY = Mathf.Clamp(value, 1, 20);
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x001177C8 File Offset: 0x001159C8
		public override void ModifyVertices(List<UIVertex> verts)
		{
			if (!this.IsActive())
			{
				return;
			}
			int num = verts.Count * (this.m_halfSampleCountX * 2 + 1) * (this.m_halfSampleCountY * 2 + 1);
			if (verts.Capacity < num)
			{
				verts.Capacity = num;
			}
			int count = verts.Count;
			int num2 = 0;
			float num3 = base.effectDistance.x / (float)this.m_halfSampleCountX;
			float num4 = base.effectDistance.y / (float)this.m_halfSampleCountY;
			for (int i = -this.m_halfSampleCountX; i <= this.m_halfSampleCountX; i++)
			{
				for (int j = -this.m_halfSampleCountY; j <= this.m_halfSampleCountY; j++)
				{
					if (i != 0 || j != 0)
					{
						int num5 = num2 + count;
						base.ApplyShadow(verts, base.effectColor, num2, num5, num3 * (float)i, num4 * (float)j);
						num2 = num5;
					}
				}
			}
		}

		// Token: 0x0400099A RID: 2458
		private const int maxHalfSampleCount = 20;

		// Token: 0x0400099B RID: 2459
		[SerializeField]
		[Range(1f, 20f)]
		private int m_halfSampleCountX = 1;

		// Token: 0x0400099C RID: 2460
		[SerializeField]
		[Range(1f, 20f)]
		private int m_halfSampleCountY = 1;
	}
}
