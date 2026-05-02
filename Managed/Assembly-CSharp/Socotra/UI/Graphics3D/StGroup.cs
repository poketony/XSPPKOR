using System;
using System.Collections.Generic;
using Socotra.Util3d;

namespace Socotra.UI.Graphics3D
{
	// Token: 0x02000108 RID: 264
	public class StGroup : DrawableObject3D
	{
		// Token: 0x0600148E RID: 5262 RVA: 0x001277C1 File Offset: 0x001259C1
		public StGroup()
		{
			this.groupList = new List<Object3D>();
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x001277D4 File Offset: 0x001259D4
		public void AddElement(Object3D obj)
		{
			this.groupList.Add(obj);
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x001277E4 File Offset: 0x001259E4
		public new void Dispose()
		{
			foreach (Object3D object3D in this.groupList)
			{
				object3D.Dispose();
			}
			this.groupList.Clear();
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x00127840 File Offset: 0x00125A40
		public Object3D GetElement(int index)
		{
			if (index < 0 || index > this.groupList.Count)
			{
				throw new Exception();
			}
			return this.groupList[index];
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x00127866 File Offset: 0x00125A66
		public int GetNumElements()
		{
			return this.groupList.Count;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x00127873 File Offset: 0x00125A73
		public void GetTransform(ref StTransform transform)
		{
			transform = this.groupTransform;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0012787D File Offset: 0x00125A7D
		public void RemoveElement(int index)
		{
			this.groupList.RemoveAt(index);
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0012788C File Offset: 0x00125A8C
		public new void SetBlendMode(int mode)
		{
			foreach (Object3D object3D in this.groupList)
			{
				if (object3D is DrawableObject3D)
				{
					(object3D as DrawableObject3D).SetBlendMode(mode);
				}
			}
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x001278EC File Offset: 0x00125AEC
		public new void SetPerspectiveCorrectionEnabled(bool isOn)
		{
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x001278F0 File Offset: 0x00125AF0
		public new void SetTime(int time)
		{
			foreach (Object3D object3D in this.groupList)
			{
				object3D.SetTime(time);
			}
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x00127944 File Offset: 0x00125B44
		public void SetTransform(StTransform transform)
		{
			this.groupTransform = transform;
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x00127950 File Offset: 0x00125B50
		public new void SetTransparency(float v)
		{
			foreach (Object3D object3D in this.groupList)
			{
				if (object3D is DrawableObject3D)
				{
					(object3D as DrawableObject3D).SetTransparency(v);
				}
			}
		}

		// Token: 0x04000C09 RID: 3081
		private List<Object3D> groupList;

		// Token: 0x04000C0A RID: 3082
		private StTransform groupTransform;
	}
}
