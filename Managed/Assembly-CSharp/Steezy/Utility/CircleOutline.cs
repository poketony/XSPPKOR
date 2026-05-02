using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000A5 RID: 165
	public class CircleOutline : ModifiedShadow
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06001032 RID: 4146 RVA: 0x001178B9 File Offset: 0x00115AB9
		// (set) Token: 0x06001033 RID: 4147 RVA: 0x001178C1 File Offset: 0x00115AC1
		public int circleCount
		{
			get
			{
				return this.m_circleCount;
			}
			set
			{
				this.m_circleCount = Mathf.Max(value, 1);
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06001034 RID: 4148 RVA: 0x001178E9 File Offset: 0x00115AE9
		// (set) Token: 0x06001035 RID: 4149 RVA: 0x001178F1 File Offset: 0x00115AF1
		public int firstSample
		{
			get
			{
				return this.m_firstSample;
			}
			set
			{
				this.m_firstSample = Mathf.Max(value, 2);
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06001036 RID: 4150 RVA: 0x00117919 File Offset: 0x00115B19
		// (set) Token: 0x06001037 RID: 4151 RVA: 0x00117921 File Offset: 0x00115B21
		public int sampleIncrement
		{
			get
			{
				return this.m_sampleIncrement;
			}
			set
			{
				this.m_sampleIncrement = Mathf.Max(value, 1);
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0011794C File Offset: 0x00115B4C
		public override void ModifyVertices(List<UIVertex> verts)
		{
			if (!this.IsActive())
			{
				return;
			}
			int num = (this.m_firstSample * 2 + this.m_sampleIncrement * (this.m_circleCount - 1)) * this.m_circleCount / 2;
			int num2 = verts.Count * (num + 1);
			if (verts.Capacity < num2)
			{
				verts.Capacity = num2;
			}
			int count = verts.Count;
			int num3 = 0;
			int num4 = this.m_firstSample;
			float num5 = base.effectDistance.x / (float)this.circleCount;
			float num6 = base.effectDistance.y / (float)this.circleCount;
			for (int i = 1; i <= this.m_circleCount; i++)
			{
				float num7 = num5 * (float)i;
				float num8 = num6 * (float)i;
				float num9 = 6.2831855f / (float)num4;
				float num10 = (float)(i % 2) * num9 * 0.5f;
				for (int j = 0; j < num4; j++)
				{
					int num11 = num3 + count;
					base.ApplyShadow(verts, base.effectColor, num3, num11, num7 * Mathf.Cos(num10), num8 * Mathf.Sin(num10));
					num3 = num11;
					num10 += num9;
				}
				num4 += this.m_sampleIncrement;
			}
		}

		// Token: 0x0400099D RID: 2461
		[SerializeField]
		private int m_circleCount = 2;

		// Token: 0x0400099E RID: 2462
		[SerializeField]
		private int m_firstSample = 4;

		// Token: 0x0400099F RID: 2463
		[SerializeField]
		private int m_sampleIncrement = 2;
	}
}
