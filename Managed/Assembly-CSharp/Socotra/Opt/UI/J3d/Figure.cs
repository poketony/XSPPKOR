using System;
using System.Collections.Generic;
using Socotra.IO;
using Socotra.Media;
using Socotra.UI.Graphics3D;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x0200010D RID: 269
	public class Figure : DrawableObject3D
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060014F6 RID: 5366 RVA: 0x00128C42 File Offset: 0x00126E42
		public string Name
		{
			get
			{
				if (this.rootObject)
				{
					return this.rootObject.name;
				}
				return "Noname";
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060014F7 RID: 5367 RVA: 0x00128C62 File Offset: 0x00126E62
		public Mesh[] Meshes
		{
			get
			{
				return this.meshes;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060014F8 RID: 5368 RVA: 0x00128C6A File Offset: 0x00126E6A
		public Renderer[] Renderers
		{
			get
			{
				return this.meshRenderers;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060014F9 RID: 5369 RVA: 0x00128C72 File Offset: 0x00126E72
		public GameObject RootObject
		{
			get
			{
				return this.rootObject;
			}
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x00128C7C File Offset: 0x00126E7C
		public Figure(sbyte[] data)
		{
			string hashCode = MediaManager.GetHashCode(data);
			Resources3D resources3D = (Resources3D)SingletonBehaviour<ResourcesManager>.Instance.GetResources(hashCode);
			if (resources3D == null || resources3D.Type3D != Resources3D.Type.Model)
			{
				string text = "Resouce Not Found!:";
				Resources3D resources3D2 = resources3D;
				throw new Exception(text + ((resources3D2 != null) ? resources3D2.ToString() : null));
			}
			this.CreateFromGameObject(SingletonBehaviour<ResourcesManager>.Instance.GetResources(hashCode).GetResource(0) as GameObject);
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x00128CF2 File Offset: 0x00126EF2
		public Figure(InputStream inputStream)
		{
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x00128CFA File Offset: 0x00126EFA
		public Figure(GameObject obj)
		{
			this.CreateFromGameObject(obj);
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x00128D09 File Offset: 0x00126F09
		public Figure(string resourceName)
		{
			this.CreateFromGameObject(SingletonBehaviour<ResourcesManager>.Instance.GetResources(resourceName).GetResource(0) as GameObject);
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x00128D2D File Offset: 0x00126F2D
		public void Destroy()
		{
			SingletonBehaviour<StScreenManager>.Instance.DestroyGameObject(this.rootObject);
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x00128D40 File Offset: 0x00126F40
		private void CreateFromGameObject(GameObject obj)
		{
			this.rootObject = SingletonBehaviour<StScreenManager>.Instance.AddGameObject(obj.name, obj, LayerMask.NameToLayer("StGraphics3D"), false);
			this.simpleAnimation = this.rootObject.GetComponentInChildren<SimpleAnimation>();
			if (this.simpleAnimation == null)
			{
				Transform transform = this.rootObject.transform.Find("Mesh");
				if (transform)
				{
					this.simpleAnimation = transform.gameObject.AddComponent<SimpleAnimation>();
				}
			}
			this.simpleAnimation.cullingMode = 0;
			this.meshFilters = this.rootObject.GetComponentsInChildren<MeshFilter>();
			this.meshRenderers = this.rootObject.GetComponentsInChildren<Renderer>();
			this.meshes = new Mesh[this.meshFilters.Length];
			for (int i = 0; i < this.meshFilters.Length; i++)
			{
				this.meshes[i] = this.meshFilters[i].mesh;
			}
			this.materials = new Dictionary<int, List<Material>>();
			for (int j = 0; j < this.meshRenderers.Length; j++)
			{
				List<Material> list = new List<Material>();
				this.meshRenderers[j].GetMaterials(list);
				this.materials.Add(j, list);
			}
			this.rootObject.transform.localScale = Figure.ConvertVector;
			this.SetRenderEnable(false);
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x00128E86 File Offset: 0x00127086
		public int GetNumPattern()
		{
			return 0;
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x00128E89 File Offset: 0x00127089
		public void SetPattern(int pattern)
		{
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x00128E8B File Offset: 0x0012708B
		public void SetAction(ActionTable action, int index)
		{
			this.SetPosture(action, index, 0);
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x00128E98 File Offset: 0x00127098
		public void SetPosture(ActionTable action, int index, int frame)
		{
			if (this.attachAction != action)
			{
				ActionTable actionTable = this.attachAction;
				this.attachAction = action;
				this.AddAnimationClip(this.attachAction.Clips);
			}
			if (action.Clips == null || action.Clips.Length == 0 || action.Clips[index] == null)
			{
				return;
			}
			if (index > this.simpleAnimation.GetClipCount())
			{
				throw new IndexOutOfRangeException("Not found Animationclip :" + index.ToString());
			}
			if (this.simpleAnimation.clip != action.Clips[index])
			{
				this.simpleAnimation.Play(action.Clips[index].name);
			}
			frame = Mathf.Min(frame, action.GetMaxFrame(index));
			SimpleAnimation.State state = this.simpleAnimation.GetState(action.Clips[index].name);
			state.normalizedTime = ((state.clip.length == 0f) ? 0f : ((float)frame / 65536f / (state.clip.frameRate * state.clip.length)));
			state.speed = 0f;
			this.rootObject.transform.localScale = Figure.ConvertVector;
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x00128FD0 File Offset: 0x001271D0
		public void SetTexture(StTexture texture)
		{
			if (this.textureNames != null && this.textureNames.Length != 0 && texture.Material.name.Equals(this.textureNames[0]))
			{
				return;
			}
			this.textureNames = new string[] { texture.Material.name };
			foreach (Renderer renderer in this.meshRenderers)
			{
				renderer.material.mainTexture = texture.Material.mainTexture;
				renderer.material.color = texture.Material.color;
				renderer.material.shader = texture.Material.shader;
				renderer.material.renderQueue = texture.Material.renderQueue;
			}
			if (this.materials.ContainsKey(0))
			{
				this.materials.Remove(0);
			}
			List<Material> list = new List<Material>();
			list.Add(texture.Material);
			this.materials.Add(0, list);
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x001290CC File Offset: 0x001272CC
		public void SetTextures(StTexture[] textures)
		{
			if (this.textureNames != null && this.textureNames.Length == textures.Length)
			{
				bool flag = true;
				for (int i = 0; i < textures.Length; i++)
				{
					if (!this.textureNames[i].Equals(textures[i].GetHashCode().ToString()))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return;
				}
			}
			this.textureNames = new string[textures.Length];
			for (int j = 0; j < this.textureNames.Length; j++)
			{
				this.textureNames[j] = textures[j].GetHashCode().ToString();
			}
			foreach (Renderer renderer in this.meshRenderers)
			{
				for (int l = 0; l < textures.Length; l++)
				{
					if (renderer.materials.Length <= l)
					{
						Debug.LogWarning("UnMatch Texture Volume and Mesh Material Volme");
						break;
					}
					if (textures[l].Materials.Length > l)
					{
						if (textures[l].Materials[l] == null)
						{
							return;
						}
						renderer.materials[l].mainTexture = textures[l].Materials[l].mainTexture;
						renderer.materials[l].shader = textures[l].Materials[l].shader;
						renderer.materials[l].renderQueue = textures[l].Materials[l].renderQueue;
					}
					else
					{
						if (textures[l].Material == null)
						{
							return;
						}
						renderer.materials[l].mainTexture = textures[l].Material.mainTexture;
						renderer.materials[l].shader = textures[l].Material.shader;
						renderer.materials[l].renderQueue = textures[l].Material.renderQueue;
					}
				}
			}
			if (this.materials.ContainsKey(0))
			{
				this.materials.Remove(0);
			}
			List<Material> list = new List<Material>();
			foreach (StTexture stTexture in textures)
			{
				list.Add(stTexture.Material);
			}
			this.materials.Add(0, list);
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x001292FD File Offset: 0x001274FD
		public List<Material> GetMaterials(int index)
		{
			return this.materials[index];
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x0012930C File Offset: 0x0012750C
		private void AddAnimationClip(AnimationClip[] anims)
		{
			this.simpleAnimation.GetClipCount();
			List<AnimationClip> list = new List<AnimationClip>();
			this.simpleAnimation.GetAnimationClips(list);
			foreach (AnimationClip animationClip in anims)
			{
				if (animationClip != null)
				{
					bool flag = false;
					using (List<AnimationClip>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.name == animationClip.name)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						this.simpleAnimation.AddClip(animationClip, animationClip.name);
					}
				}
			}
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x001293C0 File Offset: 0x001275C0
		private void RemoveAnimationClip(AnimationClip[] anims)
		{
			foreach (AnimationClip animationClip in anims)
			{
				this.simpleAnimation.RemoveClip(animationClip);
			}
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x001293ED File Offset: 0x001275ED
		public Mesh GetMesh(int index)
		{
			return this.meshFilters[index].mesh;
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x001293FC File Offset: 0x001275FC
		public Transform GetTransform(int index)
		{
			return this.meshFilters[index].transform;
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0012940B File Offset: 0x0012760B
		public void SetRenderEnable(bool b)
		{
			if (b)
			{
				this.RootObject.GetComponentInChildren<Renderer>().enabled = true;
				return;
			}
			this.RootObject.GetComponentInChildren<Renderer>().enabled = false;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x00129433 File Offset: 0x00127633
		public void StopAnimation()
		{
			this.simpleAnimation.Stop();
		}

		// Token: 0x04000C2C RID: 3116
		public static Vector3 ConvertVector = new Vector3(-1f, 1f, 1f);

		// Token: 0x04000C2D RID: 3117
		private GameObject rootObject;

		// Token: 0x04000C2E RID: 3118
		private Mesh[] meshes;

		// Token: 0x04000C2F RID: 3119
		private MeshFilter[] meshFilters;

		// Token: 0x04000C30 RID: 3120
		private Renderer[] meshRenderers;

		// Token: 0x04000C31 RID: 3121
		private Dictionary<int, List<Material>> materials;

		// Token: 0x04000C32 RID: 3122
		private string[] textureNames;

		// Token: 0x04000C33 RID: 3123
		private SimpleAnimation simpleAnimation;

		// Token: 0x04000C34 RID: 3124
		private ActionTable attachAction;
	}
}
