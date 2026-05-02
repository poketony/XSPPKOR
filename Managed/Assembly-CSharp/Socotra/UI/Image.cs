using System;
using Socotra.Opt.UI;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x020000FC RID: 252
	public class Image : MonoBehaviour
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600138E RID: 5006 RVA: 0x00120EF4 File Offset: 0x0011F0F4
		// (set) Token: 0x0600138F RID: 5007 RVA: 0x00120F10 File Offset: 0x0011F110
		public Texture Texture
		{
			get
			{
				if (this.isEditedImage)
				{
					return this.graphics.RenderTexture;
				}
				return this.texture;
			}
			set
			{
				if (this.texture != null)
				{
					this.IsDisposable = false;
					Object.Destroy(this.texture);
				}
				this.texture = value as Texture2D;
				this.texture.filterMode = 0;
			}
		}

		// Token: 0x17000090 RID: 144
		// (set) Token: 0x06001390 RID: 5008 RVA: 0x00120F4A File Offset: 0x0011F14A
		public bool IsDisposable
		{
			set
			{
				this.isDisposable = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x00120F53 File Offset: 0x0011F153
		public int Alpha
		{
			get
			{
				return this.alpha;
			}
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x00120F5B File Offset: 0x0011F15B
		private void Start()
		{
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x00120F5D File Offset: 0x0011F15D
		private void Update()
		{
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x00120F5F File Offset: 0x0011F15F
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x00120F68 File Offset: 0x0011F168
		public virtual void Dispose()
		{
			if (this.graphics != null)
			{
				Object.Destroy(this.graphics);
			}
			if (this.texture != null && this.isDisposable)
			{
				Object.Destroy(this.texture);
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00120FBC File Offset: 0x0011F1BC
		public StGraphics GetGraphics()
		{
			this.graphics = base.GetComponent<StGraphics>();
			if (this.graphics == null)
			{
				this.graphics = base.gameObject.AddComponent<StGraphics2>();
				this.graphics.BaseTexture = this.texture;
				this.isEditedImage = true;
			}
			return this.graphics;
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00121012 File Offset: 0x0011F212
		public static Image CreateImage(int w, int h)
		{
			return SingletonBehaviour<StScreenManager>.Instance.AddImage(w, h);
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x00121020 File Offset: 0x0011F220
		public static Image CreateImage(int w, int h, int[] data, int off)
		{
			Color[] array = new Color[w * h];
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					int num = data[off + j * w + i] | -16777216;
					array[(h - j - 1) * w + i] = StGraphics.CalcColor(num);
				}
			}
			Texture2D texture2D = new Texture2D(w, h, 4, false);
			texture2D.SetPixels(array);
			texture2D.Apply();
			return SingletonBehaviour<StScreenManager>.Instance.AddImage(texture2D);
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x00121097 File Offset: 0x0011F297
		public void CreateTexture(int w, int h)
		{
			this.texture = new Texture2D(w, h);
			this.texture.filterMode = 0;
			this.IsDisposable = true;
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x001210B9 File Offset: 0x0011F2B9
		public int GetWidth()
		{
			if (!(this.texture == null))
			{
				return this.texture.width;
			}
			return 1;
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x001210D6 File Offset: 0x0011F2D6
		public int GetHeight()
		{
			if (!(this.texture == null))
			{
				return this.texture.height;
			}
			return 1;
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x001210F3 File Offset: 0x0011F2F3
		public void SetTransparentColor(int color)
		{
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x001210F5 File Offset: 0x0011F2F5
		public void SetTransparentEnabled(bool enabled)
		{
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x001210F7 File Offset: 0x0011F2F7
		public void SetAlpha(int alpha)
		{
			this.alpha = alpha;
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x00121100 File Offset: 0x0011F300
		public int GetAlpha()
		{
			return this.alpha;
		}

		// Token: 0x04000AF0 RID: 2800
		[SerializeField]
		protected Texture2D texture;

		// Token: 0x04000AF1 RID: 2801
		private bool isDisposable;

		// Token: 0x04000AF2 RID: 2802
		private bool isEditedImage;

		// Token: 0x04000AF3 RID: 2803
		private StGraphics graphics;

		// Token: 0x04000AF4 RID: 2804
		private int alpha = 255;
	}
}
