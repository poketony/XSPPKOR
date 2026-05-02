using System;
using Socotra.IO;
using Socotra.Media;
using Socotra.UI.Graphics3D;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x0200010B RID: 267
	public class ActionTable : Object3D
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060014B9 RID: 5305 RVA: 0x00127BA2 File Offset: 0x00125DA2
		public AnimationClip[] Clips
		{
			get
			{
				return this.animationList;
			}
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x00127BAC File Offset: 0x00125DAC
		public ActionTable(sbyte[] data)
		{
			string hashCode = MediaManager.GetHashCode(data);
			Debug.Log("Load Action:" + hashCode);
			this.LoadResource(hashCode);
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x00127BDD File Offset: 0x00125DDD
		public ActionTable(InputStream inputStream)
		{
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x00127BE5 File Offset: 0x00125DE5
		public ActionTable(AnimationClip[] anims)
		{
			this.animationList = anims;
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x00127BF4 File Offset: 0x00125DF4
		public ActionTable(string resourceName)
		{
			this.LoadResource(resourceName);
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x00127C04 File Offset: 0x00125E04
		public void LoadResource(string name)
		{
			Object[] resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(name).GetResources();
			this.animationList = new AnimationClip[resources.Length];
			for (int i = 0; i < resources.Length; i++)
			{
				this.animationList[i] = (AnimationClip)resources[i];
			}
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x00127C50 File Offset: 0x00125E50
		public int GetMaxFrame(int index)
		{
			if (index < 0 || index > this.animationList.Length)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.animationList[index] == null)
			{
				return 0;
			}
			return (int)(this.animationList[index].length * this.animationList[index].frameRate * 65536f);
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x00127CA6 File Offset: 0x00125EA6
		public int GetNumAction()
		{
			return this.animationList.Length;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x00127CB0 File Offset: 0x00125EB0
		public AnimationClip GetAnimationClip(int index)
		{
			if (index < 0 || index > this.animationList.Length)
			{
				throw new IndexOutOfRangeException();
			}
			return this.animationList[index];
		}

		// Token: 0x04000C1E RID: 3102
		private AnimationClip[] animationList;
	}
}
