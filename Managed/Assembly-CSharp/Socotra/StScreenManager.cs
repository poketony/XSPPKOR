using System;
using System.Collections.Generic;
using Socotra.Opt.UI;
using Socotra.UI;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000F3 RID: 243
	public class StScreenManager : SingletonBehaviour<StScreenManager>
	{
		// Token: 0x0600132E RID: 4910 RVA: 0x0011FF10 File Offset: 0x0011E110
		private void Start()
		{
			this.addedObjects = new List<GameObject>();
			if (this.drawImageMaterial != null && this.drawGlMaterial == null)
			{
				this.drawGlMaterial = new Material(this.drawImageMaterial);
				this.drawGlMaterial.SetFloat("_UseVertexColor", 1f);
			}
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x0011FF6A File Offset: 0x0011E16A
		private void Update()
		{
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x0011FF6C File Offset: 0x0011E16C
		public T AddFrame<T>(string name, int w, int h) where T : Frame
		{
			GameObject gameObject = new GameObject(name);
			gameObject.transform.parent = base.transform;
			gameObject.AddComponent<StGraphics2>();
			return gameObject.AddComponent(typeof(T)) as T;
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x0011FFA8 File Offset: 0x0011E1A8
		public Image AddImage(int w, int h)
		{
			Image image = new GameObject("image:" + w.ToString() + " / " + h.ToString())
			{
				transform = 
				{
					parent = base.transform
				}
			}.AddComponent<Image>();
			image.CreateTexture(w, h);
			return image;
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x0011FFF8 File Offset: 0x0011E1F8
		public Image AddImage(Texture tex)
		{
			Image image = new GameObject("image:" + tex.width.ToString() + " / " + tex.height.ToString())
			{
				transform = 
				{
					parent = base.transform
				}
			}.AddComponent<Image>();
			image.Texture = tex;
			return image;
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x00120052 File Offset: 0x0011E252
		public Image AddImage()
		{
			return new GameObject("image")
			{
				transform = 
				{
					parent = base.transform
				}
			}.AddComponent<Image>();
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00120074 File Offset: 0x0011E274
		public PalettedImage AddPalettedImage(int w, int h)
		{
			return new GameObject("palettedimage:" + w.ToString() + " / " + h.ToString())
			{
				transform = 
				{
					parent = base.transform
				}
			}.AddComponent<PalettedImage>();
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x001200B0 File Offset: 0x0011E2B0
		public GameObject AddGameObject(string name, GameObject obj, LayerMask layer, bool disposeThisFrame = false)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.transform.parent = base.transform;
			GameObject gameObject2 = Object.Instantiate<GameObject>(obj, gameObject.transform);
			gameObject2.name = "Mesh";
			gameObject2.SetLayer(layer, true);
			if (disposeThisFrame)
			{
				this.frameAddedObjects.Add(gameObject);
			}
			else
			{
				this.addedObjects.Add(gameObject);
			}
			return gameObject;
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x0012011A File Offset: 0x0011E31A
		public void DestroyGameObject(GameObject obj)
		{
			if (this.addedObjects.Contains(obj))
			{
				this.addedObjects.Remove(obj);
				Object.Destroy(obj);
			}
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x00120140 File Offset: 0x0011E340
		public GameObject AddPrimitiveObject()
		{
			if (this.primitiveObject.Count <= this.primitiveIndex)
			{
				if (this.primitiveBase == null)
				{
					this.primitiveBase = new GameObject("PrimitiveArray", new Type[]
					{
						typeof(MeshFilter),
						typeof(MeshRenderer)
					});
				}
				this.primitiveObject.Add(this.AddGameObject("Primitive_" + this.primitiveIndex.ToString(), this.primitiveBase, LayerMask.NameToLayer("StGraphics3D"), false));
			}
			List<GameObject> list = this.primitiveObject;
			int num = this.primitiveIndex;
			this.primitiveIndex = num + 1;
			return list[num];
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x001201F6 File Offset: 0x0011E3F6
		public void ResetPrimitiveBuffer()
		{
			this.primitiveIndex = 0;
		}

		// Token: 0x06001339 RID: 4921 RVA: 0x00120200 File Offset: 0x0011E400
		public GameObject AddBillboardObject()
		{
			if (this.billboardObject.Count <= this.billboardIndex)
			{
				if (this.primitiveBase == null)
				{
					this.primitiveBase = new GameObject("PrimitiveArray", new Type[]
					{
						typeof(MeshFilter),
						typeof(MeshRenderer)
					});
				}
				this.billboardObject.Add(this.AddGameObject("Billboard_" + this.billboardIndex.ToString(), this.primitiveBase, LayerMask.NameToLayer("StGraphics3D"), false));
			}
			List<GameObject> list = this.billboardObject;
			int num = this.billboardIndex;
			this.billboardIndex = num + 1;
			return list[num];
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x001202B6 File Offset: 0x0011E4B6
		public void ResetBillboardBuffer()
		{
			this.billboardIndex = 0;
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x001202C0 File Offset: 0x0011E4C0
		public void DestroyFrameObjects()
		{
			foreach (GameObject gameObject in this.frameAddedObjects)
			{
				Object.Destroy(gameObject);
			}
			this.frameAddedObjects.Clear();
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x0012031C File Offset: 0x0011E51C
		private string GetObjectName(GameObject obj)
		{
			return obj.name + "_" + obj.GetHashCode().ToString("X8");
		}

		// Token: 0x04000AC1 RID: 2753
		[SerializeField]
		public Material defaultMaterial;

		// Token: 0x04000AC2 RID: 2754
		[SerializeField]
		public Material drawImageMaterial;

		// Token: 0x04000AC3 RID: 2755
		[SerializeField]
		public Material drawGlMaterial;

		// Token: 0x04000AC4 RID: 2756
		public Material draw3DMaterial;

		// Token: 0x04000AC5 RID: 2757
		[SerializeField]
		public Material copyMaterial;

		// Token: 0x04000AC6 RID: 2758
		[Header("StGraphics2#OP_ADD")]
		[SerializeField]
		public Material optionAddMaterial;

		// Token: 0x04000AC7 RID: 2759
		[Header("StGraphics2#OP_SUB(未実装）")]
		[SerializeField]
		public Material optionSubMaterial;

		// Token: 0x04000AC8 RID: 2760
		[Header("Textureなし色ポリゴン用")]
		[SerializeField]
		public Material NonTexture3DMaterial;

		// Token: 0x04000AC9 RID: 2761
		public List<GameObject> addedObjects;

		// Token: 0x04000ACA RID: 2762
		public List<GameObject> frameAddedObjects;

		// Token: 0x04000ACB RID: 2763
		private List<GameObject> billboardObject = new List<GameObject>();

		// Token: 0x04000ACC RID: 2764
		private List<GameObject> primitiveObject = new List<GameObject>();

		// Token: 0x04000ACD RID: 2765
		private int primitiveIndex;

		// Token: 0x04000ACE RID: 2766
		private int billboardIndex;

		// Token: 0x04000ACF RID: 2767
		private GameObject primitiveBase;

		// Token: 0x04000AD0 RID: 2768
		public GameObject primitiveArray;

		// Token: 0x04000AD1 RID: 2769
		public GameObject primitiveBillboard;
	}
}
