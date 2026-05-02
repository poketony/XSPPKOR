using System;
using UnityEngine;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x02000112 RID: 274
	public class Vector3D
	{
		// Token: 0x06001573 RID: 5491 RVA: 0x0012B445 File Offset: 0x00129645
		public Vector3D()
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x0012B462 File Offset: 0x00129662
		public Vector3D(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0012B480 File Offset: 0x00129680
		public Vector3D(Vector3 vec3)
		{
			this.x = (int)(vec3.x * 4096f);
			this.y = (int)(vec3.y * 4096f);
			this.z = (int)(vec3.z * 4096f);
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0012B4CC File Offset: 0x001296CC
		public void Cross(Vector3D v)
		{
			this.Cross(this, v);
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0012B4D8 File Offset: 0x001296D8
		public void Cross(Vector3D u, Vector3D v)
		{
			Vector3.Cross(u.GetUnityVector(), v.GetUnityVector());
			int num = u.y * v.z - u.z * v.y;
			int num2 = u.z * v.x - u.x * v.z;
			int num3 = u.x * v.y - u.y * v.x;
			this.x = num;
			this.y = num2;
			this.z = num3;
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0012B560 File Offset: 0x00129760
		public int Dot(Vector3D v)
		{
			return Vector3D.Dot(this, v);
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x0012B569 File Offset: 0x00129769
		public static int Dot(Vector3D v1, Vector3D v2)
		{
			return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x0012B594 File Offset: 0x00129794
		public void Normalize()
		{
			Vector3 normalized = this.GetUnityVector().normalized;
			this.x = (int)(normalized.x * 4096f);
			this.y = (int)(normalized.y * 4096f);
			this.z = (int)(normalized.z * 4096f);
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x0012B5E9 File Offset: 0x001297E9
		public Vector3 GetUnityVector()
		{
			return new Vector3((float)this.x / 4096f, (float)this.y / 4096f, (float)this.z / 4096f);
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x0012B618 File Offset: 0x00129818
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Vector3D X:",
				this.x.ToString(),
				" Y:",
				this.y.ToString(),
				" Z:",
				this.z.ToString()
			});
		}

		// Token: 0x04000C53 RID: 3155
		public int x;

		// Token: 0x04000C54 RID: 3156
		public int y;

		// Token: 0x04000C55 RID: 3157
		public int z;
	}
}
