using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000071 RID: 113
	public class Bezier : Tweener
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x001123AE File Offset: 0x001105AE
		// (set) Token: 0x06000E8D RID: 3725 RVA: 0x001123B8 File Offset: 0x001105B8
		public float value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
				if (this.target != null)
				{
					if (this.isWorld)
					{
						this.target.position = this.GetBezierPoint(this.mValue);
						return;
					}
					this.target.localPosition = this.GetBezierPoint(this.mValue);
				}
			}
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x00112411 File Offset: 0x00110611
		protected override void Start()
		{
			if (this.target == null)
			{
				this.target = base.transform;
			}
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x00112430 File Offset: 0x00110630
		protected override void OnUpdate(float factor, bool isFinished)
		{
			float num = this.from + factor * (this.to - this.from);
			this.value = Mathf.Clamp01(num);
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x00112460 File Offset: 0x00110660
		public void OnDrawGizmos()
		{
			if (this.path == null)
			{
				return;
			}
			for (int i = 0; i < this.path.Length; i++)
			{
				Gizmos.DrawWireSphere(this.path[i], 1f);
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0011249F File Offset: 0x0011069F
		public Vector3 GetBezierPoint(float t)
		{
			return this.GetBezierPoint(t, this.path[0], this.path[1], this.path[2], this.path[3]);
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x001124D8 File Offset: 0x001106D8
		public Vector3 GetBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			float num = 1f - t;
			float num2 = t * t;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = t * num2;
			return num4 * p0 + 3f * num3 * t * p1 + 3f * num * num2 * p2 + num5 * p3;
		}

		// Token: 0x040008C8 RID: 2248
		public Transform target;

		// Token: 0x040008C9 RID: 2249
		public Vector3[] path;

		// Token: 0x040008CA RID: 2250
		public bool isWorld;

		// Token: 0x040008CB RID: 2251
		private float from;

		// Token: 0x040008CC RID: 2252
		private float to = 1f;

		// Token: 0x040008CD RID: 2253
		private float mValue;
	}
}
