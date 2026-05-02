using System;
using UnityEngine;

namespace Socotra.Util3d
{
	// Token: 0x020000F8 RID: 248
	public class FastMath
	{
		// Token: 0x06001366 RID: 4966 RVA: 0x00120784 File Offset: 0x0011E984
		public static int FloatToInnerInt(float v)
		{
			return (int)(4096f * v);
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0012078E File Offset: 0x0011E98E
		public static float InnerIntToFloat(int v)
		{
			return (float)v / 4096f;
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x00120798 File Offset: 0x0011E998
		public static float Add(float x, float y)
		{
			return x + y;
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x0012079D File Offset: 0x0011E99D
		public static float Sub(float x, float y)
		{
			return x - y;
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x001207A2 File Offset: 0x0011E9A2
		public static float Mul(float x, float y)
		{
			return x * y;
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x001207A7 File Offset: 0x0011E9A7
		public static float Div(float x, float y)
		{
			return x / y;
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x001207AC File Offset: 0x0011E9AC
		public static float Sin(float degree)
		{
			return Mathf.Sin(degree * 0.017453292f);
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x001207BA File Offset: 0x0011E9BA
		public static float Cos(float degree)
		{
			return Mathf.Cos(degree * 0.017453292f);
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x001207C8 File Offset: 0x0011E9C8
		public static float Atan2(float t1, float t2)
		{
			return Mathf.Atan2(t2, t1) * 57.29578f;
		}
	}
}
