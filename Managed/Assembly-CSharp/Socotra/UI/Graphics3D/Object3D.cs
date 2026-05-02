using System;
using Socotra.IO;
using Socotra.Media;
using Socotra.Opt.UI.J3d;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI.Graphics3D
{
	// Token: 0x02000106 RID: 262
	public class Object3D
	{
		// Token: 0x0600147C RID: 5244 RVA: 0x00127550 File Offset: 0x00125750
		public static Object3D CreateInstance(sbyte[] data)
		{
			string hashCode = MediaManager.GetHashCode(data);
			Resources3D resources3D = SingletonBehaviour<ResourcesManager>.Instance.GetResources(hashCode) as Resources3D;
			if (resources3D == null)
			{
				Debug.Log("Not Found:" + hashCode + " data length:" + data.Length.ToString());
				return null;
			}
			switch (resources3D.Type3D)
			{
			case Resources3D.Type.Animation:
				Debug.Log("Animation Hash:" + hashCode + " length:" + data.Length.ToString());
				return new ActionTable(new AnimationClip[] { resources3D.GetResource(0) as AnimationClip });
			case Resources3D.Type.Model:
				Debug.Log("Model Hash:" + hashCode + " length:" + data.Length.ToString());
				return new Figure(resources3D.GetResource(0) as GameObject);
			case Resources3D.Type.Texture:
				Debug.Log("Texture Hash:" + hashCode + " length:" + data.Length.ToString());
				return new StTexture(resources3D, false);
			default:
				return null;
			}
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x00127656 File Offset: 0x00125856
		public static Object3D CreateInstance(InputStream input)
		{
			return null;
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x0012765C File Offset: 0x0012585C
		public static Object3D CreateInstance(string name)
		{
			Resources3D resources3D = SingletonBehaviour<ResourcesManager>.Instance.GetResources(name) as Resources3D;
			if (resources3D == null)
			{
				Debug.Log("Not Found:" + name);
				return null;
			}
			switch (resources3D.Type3D)
			{
			case Resources3D.Type.Animation:
				Debug.Log("Animation Hash:" + name);
				return new ActionTable(new AnimationClip[] { resources3D.GetResource(0) as AnimationClip });
			case Resources3D.Type.Model:
				Debug.Log("Model Hash:" + name);
				return new Figure(resources3D.GetResource(0) as GameObject);
			case Resources3D.Type.Texture:
				Debug.Log("Texture Hash:" + name);
				return new StTexture(resources3D, false);
			default:
				return null;
			}
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x00127718 File Offset: 0x00125918
		public void Dispose()
		{
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0012771A File Offset: 0x0012591A
		public int GetTime()
		{
			return 0;
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x0012771D File Offset: 0x0012591D
		public void SetTime(int time)
		{
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0012771F File Offset: 0x0012591F
		public new int GetType()
		{
			return 0;
		}

		// Token: 0x04000BEB RID: 3051
		public const int TYPE_ACTION_TABLE = 1;

		// Token: 0x04000BEC RID: 3052
		public const int TYPE_FIGURE = 2;

		// Token: 0x04000BED RID: 3053
		public const int TYPE_FOG = 4;

		// Token: 0x04000BEE RID: 3054
		public const int TYPE_GROUP = 7;

		// Token: 0x04000BEF RID: 3055
		public const int TYPE_GROUP_MESH = 8;

		// Token: 0x04000BF0 RID: 3056
		public const int TYPE_LIGHT = 5;

		// Token: 0x04000BF1 RID: 3057
		public const int TYPE_NONE = 0;

		// Token: 0x04000BF2 RID: 3058
		public const int TYPE_PRIMITIVE = 6;

		// Token: 0x04000BF3 RID: 3059
		public const int TYPE_TEXTURE = 3;
	}
}
