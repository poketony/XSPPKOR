using System;
using UnityEngine;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x0200010E RID: 270
	public class Math3D
	{
		// Token: 0x0600150E RID: 5390 RVA: 0x0012945B File Offset: 0x0012765B
		public static int Abs(int x)
		{
			return Mathf.Abs(x);
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x00129463 File Offset: 0x00127663
		public static int Sin(int x)
		{
			return Math3D.FloatToInt(Mathf.Sin((float)x * Math3D.DEGREE_CONVERTRATE));
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x00129477 File Offset: 0x00127677
		public static int Cos(int x)
		{
			return Math3D.FloatToInt(Mathf.Cos((float)x * Math3D.DEGREE_CONVERTRATE));
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0012948B File Offset: 0x0012768B
		public static int Tan(int x)
		{
			return Math3D.FloatToInt(Mathf.Tan(Math3D.IntToFloat(x)));
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0012949D File Offset: 0x0012769D
		public static int Atan(int x)
		{
			return Math3D.FloatToInt(Mathf.Atan(Math3D.IntToFloat(x)));
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x001294AF File Offset: 0x001276AF
		public static int Atan2(int y, int x)
		{
			return (int)(Mathf.Atan2(Math3D.IntToFloat(y), Math3D.IntToFloat(x)) * Math3D.RADIAN_CONVERTRATE);
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x001294C9 File Offset: 0x001276C9
		public static int Sqrt(int x)
		{
			return (int)Mathf.Sqrt((float)x);
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x001294D3 File Offset: 0x001276D3
		public static float IntToFloat(int x)
		{
			return (float)x / 4096f;
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x001294DD File Offset: 0x001276DD
		public static float IntToRadian(int x)
		{
			return (float)x / Math3D.RADIAN_CONVERTRATE;
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x001294E7 File Offset: 0x001276E7
		public static int FloatToInt(float x)
		{
			return (int)(x * 4096f);
		}

		// Token: 0x04000C35 RID: 3125
		public static float RADIAN_CONVERTRATE = 651.8986f;

		// Token: 0x04000C36 RID: 3126
		public static float DEGREE_CONVERTRATE = 0.0015339808f;
	}
}
