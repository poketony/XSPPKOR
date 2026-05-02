using System;
using System.Collections.Generic;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000080 RID: 128
	public class TweenPath : Tweener
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x00113FA0 File Offset: 0x001121A0
		// (set) Token: 0x06000F13 RID: 3859 RVA: 0x00113FA8 File Offset: 0x001121A8
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
						this.target.position = this.GetCRSPoint(this.mValue);
						return;
					}
					this.target.localPosition = this.GetCRSPoint(this.mValue);
				}
			}
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x00114001 File Offset: 0x00112201
		protected override void Start()
		{
			this.pathPoints = this.BuildCRSplinePath(new List<Vector3>(this.path));
			if (this.target == null)
			{
				this.target = base.transform;
			}
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x00114034 File Offset: 0x00112234
		protected override void OnUpdate(float factor, bool isFinished)
		{
			float num = this.from + factor * (this.to - this.from);
			this.value = Mathf.Clamp01(num);
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x00114064 File Offset: 0x00112264
		public List<Vector3> BuildCRSplinePath(List<Vector3> pts)
		{
			List<Vector3> list = new List<Vector3>(pts);
			if (pts[0] == pts[pts.Count - 1])
			{
				list.Insert(0, pts[pts.Count - 2]);
				list.Add(pts[1]);
			}
			else
			{
				list.Insert(0, pts[0] + (pts[0] - pts[1]));
				list.Add(pts[pts.Count - 1] + (pts[pts.Count - 1] - pts[pts.Count - 2]));
			}
			return list;
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x0011411C File Offset: 0x0011231C
		public Vector3 CRSpline(List<Vector3> pts, float t)
		{
			int num = pts.Count - 3;
			int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
			float num3 = t * (float)num - (float)num2;
			Vector3 vector = pts[num2];
			Vector3 vector2 = pts[num2 + 1];
			Vector3 vector3 = pts[num2 + 2];
			Vector3 vector4 = pts[num2 + 3];
			return 0.5f * ((-vector + 3f * vector2 - 3f * vector3 + vector4) * (num3 * num3 * num3) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * (num3 * num3) + (-vector + vector3) * num3 + 2f * vector2);
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x00114222 File Offset: 0x00112422
		public Vector3 GetCRSPoint(float t)
		{
			return this.CRSpline(this.pathPoints, t);
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x00114234 File Offset: 0x00112434
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

		// Token: 0x04000929 RID: 2345
		public Transform target;

		// Token: 0x0400092A RID: 2346
		public Vector3[] path;

		// Token: 0x0400092B RID: 2347
		public bool isWorld;

		// Token: 0x0400092C RID: 2348
		private float from;

		// Token: 0x0400092D RID: 2349
		private float to = 1f;

		// Token: 0x0400092E RID: 2350
		private List<Vector3> pathPoints = new List<Vector3>();

		// Token: 0x0400092F RID: 2351
		private float mValue;
	}
}
