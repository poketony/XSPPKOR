using System;
using B83.Image.BMP;
using Socotra.IO;
using Socotra.Media;
using Socotra.UI.Graphics3D;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x02000111 RID: 273
	public class StTexture : Object3D
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06001564 RID: 5476 RVA: 0x0012AF48 File Offset: 0x00129148
		public Material Material
		{
			get
			{
				return this.materials[0];
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06001565 RID: 5477 RVA: 0x0012AF52 File Offset: 0x00129152
		public Material[] Materials
		{
			get
			{
				return this.materials;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06001566 RID: 5478 RVA: 0x0012AF5A File Offset: 0x0012915A
		public Texture2D Texture
		{
			get
			{
				return this.textures[0];
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06001567 RID: 5479 RVA: 0x0012AF64 File Offset: 0x00129164
		public Texture2D[] Textures
		{
			get
			{
				return this.textures;
			}
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0012AF6C File Offset: 0x0012916C
		public StTexture(sbyte[] data, bool forEnv)
		{
			this.materials = new Material[1];
			this.textures = new Texture2D[1];
			this.GenerateTexture(data, forEnv, 0);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0012AF9C File Offset: 0x0012919C
		public StTexture(InputStream inputStream, bool forEnv)
		{
			this.materials = new Material[1];
			this.textures = new Texture2D[1];
			sbyte[] array = new sbyte[inputStream.Available()];
			inputStream.Read(ref array);
			this.GenerateTexture(array, forEnv, 0);
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x0012AFEC File Offset: 0x001291EC
		public StTexture(string resName, bool forEnv)
		{
			Resources3D resources3D = (Resources3D)SingletonBehaviour<ResourcesManager>.Instance.GetResources(resName);
			this.CreateFromResource3D(resources3D, forEnv);
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x0012B01F File Offset: 0x0012921F
		public StTexture(Object mat, bool forEnv)
		{
			this.materials = new Material[1];
			this.textures = new Texture2D[1];
			this.InitFromMaterial(mat, 0);
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x0012B04E File Offset: 0x0012924E
		public StTexture(Resources3D res, bool forEnv)
		{
			this.CreateFromResource3D(res, forEnv);
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0012B068 File Offset: 0x00129268
		private void CreateFromResource3D(Resources3D res, bool forEnv)
		{
			int num = res.GetResources().Length;
			this.materials = new Material[num];
			this.textures = new Texture2D[num];
			for (int i = 0; i < num; i++)
			{
				this.InitFromMaterial(res.GetResource(i), i);
			}
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x0012B0B0 File Offset: 0x001292B0
		public void InitFromMaterial(Object mat, int index = 0)
		{
			if (mat is Material)
			{
				Material material = mat as Material;
				this.materials[index] = new Material(material);
				this.textures[index] = (Texture2D)material.mainTexture;
				return;
			}
			throw new Exception("Material Not Found");
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x0012B0F8 File Offset: 0x001292F8
		private void GenerateTexture(sbyte[] data, bool forEnv, int index = 0)
		{
			string hashCode = MediaManager.GetHashCode(data);
			Debug.Log("StTexture Hash:" + hashCode + " Length:" + data.Length.ToString());
			if (this.materials[index] != null)
			{
				this.materials[index] = null;
			}
			Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(hashCode);
			Color color;
			color..ctor(0f, 0f, 0f, 1f);
			if (resources && resources.GetResource(0) is Texture2D)
			{
				this.textures[index] = resources.GetResource(0) as Texture2D;
				this.isDisposable = false;
			}
			else if (resources is Resources3D && ((Resources3D)resources).Type3D == Resources3D.Type.Texture)
			{
				Debug.Log("Material: " + (resources.GetResource(0) as Material).name);
				this.materials[index] = new Material(resources.GetResource(0) as Material);
				this.textures[index] = this.materials[index].mainTexture as Texture2D;
			}
			else if (this.IsBitmapBinary(data))
			{
				byte[] array = new byte[data.Length];
				for (int i = 0; i < data.Length; i++)
				{
					array[i] = (byte)data[i];
				}
				BMPImage bmpimage = new BMPLoader().LoadBMP(array);
				color..ctor((float)bmpimage.palette[0].r / 255f, (float)bmpimage.palette[0].g / 255f, (float)bmpimage.palette[0].b / 255f, (float)bmpimage.palette[0].a / 255f);
				this.textures[index] = bmpimage.ToTexture2D();
				this.textures[index].filterMode = 0;
				this.isDisposable = true;
			}
			else
			{
				byte[] array2 = new byte[data.Length];
				for (int j = 0; j < data.Length; j++)
				{
					array2[j] = (byte)data[j];
				}
				this.textures[index] = new Texture2D(1, 1, 4, false);
				ImageConversion.LoadImage(this.textures[index], array2);
				this.isDisposable = true;
			}
			if (this.materials[index] == null)
			{
				this.materials[index] = new Material(SingletonBehaviour<StScreenManager>.Instance.draw3DMaterial);
				this.materials[index].mainTexture = this.textures[index];
				this.materials[index].SetFloat("_BlendSrc", 1f);
				this.materials[index].SetFloat("_BlendDst", 6f);
				this.materials[index].SetColor("_Color", color);
			}
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x0012B3AC File Offset: 0x001295AC
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x0012B3B4 File Offset: 0x001295B4
		public new void Dispose()
		{
			Texture2D[] array = this.textures;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					bool flag = this.isDisposable;
				}
			}
			this.textures = null;
			Material[] array2 = this.materials;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] != null;
			}
			this.materials = null;
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0012B418 File Offset: 0x00129618
		private bool IsBitmapBinary(sbyte[] data)
		{
			bool flag = false;
			if (data != null && data.Length >= 2)
			{
				flag = (byte)data[0] == 66 && (byte)data[1] == 77;
			}
			return flag;
		}

		// Token: 0x04000C50 RID: 3152
		private Texture2D[] textures;

		// Token: 0x04000C51 RID: 3153
		private Material[] materials;

		// Token: 0x04000C52 RID: 3154
		private bool isDisposable = true;
	}
}
