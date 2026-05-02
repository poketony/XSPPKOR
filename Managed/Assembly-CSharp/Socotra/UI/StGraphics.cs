using System;
using System.Collections.Generic;
using System.Linq;
using Socotra.Opt.UI;
using Socotra.Opt.UI.J3d;
using Socotra.UI.Graphics3D;
using Socotra.Util3d;
using Steezy.PageFlow;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x02000104 RID: 260
	public class StGraphics : MonoBehaviour, StGraphics3D
	{
		// Token: 0x17000098 RID: 152
		// (set) Token: 0x060013F8 RID: 5112 RVA: 0x0012247A File Offset: 0x0012067A
		public Color BackgroundColor
		{
			set
			{
				this.backgroundColor = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060013F9 RID: 5113 RVA: 0x00122483 File Offset: 0x00120683
		// (set) Token: 0x060013FA RID: 5114 RVA: 0x0012248B File Offset: 0x0012068B
		public bool DisableOnDestroy
		{
			get
			{
				return this.disableOnDestroy;
			}
			set
			{
				this.disableOnDestroy = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060013FB RID: 5115 RVA: 0x00122494 File Offset: 0x00120694
		// (set) Token: 0x060013FC RID: 5116 RVA: 0x0012249C File Offset: 0x0012069C
		public Texture2D BaseTexture
		{
			get
			{
				return this.baseTexture;
			}
			set
			{
				this.baseTexture = value;
				if (this.renderTexture != null)
				{
					this.renderTexture.Release();
					Object.Destroy(this.renderTexture);
					this.renderTexture = null;
				}
				this.renderTexture = new RenderTexture(this.baseTexture.width, this.baseTexture.height, 0);
				this.renderTexture.Create();
				StGraphics.ClearRenderTexture(this.renderTexture);
				Graphics.Blit(this.baseTexture, this.renderTexture);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060013FD RID: 5117 RVA: 0x00122525 File Offset: 0x00120725
		// (set) Token: 0x060013FE RID: 5118 RVA: 0x0012252D File Offset: 0x0012072D
		public RenderTexture RenderTexture
		{
			get
			{
				return this.renderTexture;
			}
			set
			{
				if (this.renderTexture != value)
				{
					if (this.renderTexture != null)
					{
						this.renderTexture.Release();
						Object.Destroy(this.renderTexture);
					}
					this.renderTexture = value;
				}
			}
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00122568 File Offset: 0x00120768
		protected void Awake()
		{
			this.renderTexture = new RenderTexture(240, 240, 16);
			this.renderTexture.Create();
			StGraphics.ClearRenderTexture(this.renderTexture);
			this.currentFont = StFont.GetDefaultFont();
			this.Init3D();
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x001225B4 File Offset: 0x001207B4
		private void Start()
		{
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x001225B6 File Offset: 0x001207B6
		private void Update()
		{
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x001225B8 File Offset: 0x001207B8
		private void OnDestroy()
		{
			if (this.disableOnDestroy)
			{
				return;
			}
			Object.Destroy(this.baseTexture);
			this.baseTexture = null;
			if (this.renderTexture)
			{
				this.renderTexture.Release();
				Object.Destroy(this.renderTexture);
				this.renderTexture = null;
			}
			if (this.workTexture)
			{
				this.workTexture.Release();
				Object.Destroy(this.workTexture);
				this.workTexture = null;
			}
			if (this.bgWorkTexture)
			{
				this.bgWorkTexture.Release();
				Object.Destroy(this.bgWorkTexture);
				this.bgWorkTexture = null;
			}
			if (this.gomiTexture)
			{
				this.gomiTexture.Release();
				Object.Destroy(this.gomiTexture);
				this.gomiTexture = null;
			}
			if (this.copyTexture)
			{
				this.copyTexture.Release();
				Object.Destroy(this.copyTexture);
				this.copyTexture = null;
			}
			if (this.g3dRenderTexture)
			{
				RenderTexture.ReleaseTemporary(this.g3dRenderTexture);
				this.g3dRenderTexture = null;
			}
			if (this.workGetPixelTexture)
			{
				Object.Destroy(this.workGetPixelTexture);
				this.workGetPixelTexture = null;
			}
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x001226F0 File Offset: 0x001208F0
		public void Lock()
		{
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x001226F2 File Offset: 0x001208F2
		public void Unlock(bool isForced)
		{
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x001226F4 File Offset: 0x001208F4
		public static int GetColorOfRGB(int r, int g, int b)
		{
			return StGraphics.GetColorOfRGB(r, g, b, 255);
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x00122703 File Offset: 0x00120903
		public static int GetColorOfRGB(int r, int g, int b, int a)
		{
			return (a << 24) + (r << 16) + (g << 8) + b;
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x00122714 File Offset: 0x00120914
		public static int GetColorOfName(int colorName)
		{
			if (colorName < 0 || colorName >= StGraphics.DEFAULT_COLORS.Length)
			{
				return 0;
			}
			return StGraphics.DEFAULT_COLORS[colorName];
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0012272D File Offset: 0x0012092D
		public void SetColor(int color)
		{
			this.currentColor = StGraphics.CalcColor(color);
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x0012273C File Offset: 0x0012093C
		public static Color CalcColor(int color)
		{
			Color color2 = default(Color);
			color2.a = (float)((color >> 24) & 255) / 255f;
			color2.r = (float)((color >> 16) & 255) / 255f;
			color2.g = (float)((color >> 8) & 255) / 255f;
			color2.b = (float)(color & 255) / 255f;
			return color2;
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x001227B0 File Offset: 0x001209B0
		private void CopyRenderTexture()
		{
			if (this.renderTexture == null)
			{
				return;
			}
			if (this.copyTexture == null)
			{
				this.copyTexture = new RenderTexture(this.renderTexture);
				this.copyTexture.Create();
			}
			Graphics.Blit(this.renderTexture, this.copyTexture);
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x00122808 File Offset: 0x00120A08
		private void ApplyPaletteImage(Image image)
		{
			if (image is PalettedImage)
			{
				PalettedImage palettedImage = (PalettedImage)image;
				Palette palette = palettedImage.GetPalette();
				if (palette.isDirtySetEntryColors)
				{
					palette.isDirtySetEntryColors = false;
					palettedImage.ApplyPalette();
				}
			}
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x00122840 File Offset: 0x00120A40
		public void DrawChars(char[] data, int x, int y, int off, int len)
		{
			char[] array = new char[len];
			Array.Copy(data, off, array, 0, len);
			this.DrawCharImpl(array, x, y);
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x0012286C File Offset: 0x00120A6C
		public void DrawImage(Image image, int x, int y)
		{
			if (this.renderTexture == null || image.Texture == null)
			{
				return;
			}
			this.ApplyPaletteImage(image);
			Texture texture = image.Texture;
			if (image.Texture == this.renderTexture)
			{
				this.CopyRenderTexture();
				texture = this.copyTexture;
			}
			float num = (float)image.Alpha / 255f;
			this.RenderStart();
			this.DrawImageImpl(texture, (float)x, (float)y, 0f, 0f, (float)image.Texture.width, (float)image.Texture.height, num, false);
			this.RenderEnd();
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x00122910 File Offset: 0x00120B10
		public void DrawImage(Image image, int dx, int dy, int sx, int sy, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null || image.Texture == null)
			{
				return;
			}
			this.ApplyPaletteImage(image);
			Texture texture = image.Texture;
			if (image.Texture == this.renderTexture)
			{
				this.CopyRenderTexture();
				texture = this.copyTexture;
			}
			float num = (float)image.Alpha / 255f;
			this.RenderStart();
			this.DrawImageImpl(texture, (float)dx, (float)dy, (float)sx, (float)sy, (float)width, (float)height, num, false);
			this.RenderEnd();
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x001229AC File Offset: 0x00120BAC
		private void DrawImageImpl(Texture texture, float dx, float dy, float sx, float sy, float width, float height, float alpha = 1f, bool ignoreFlip = false)
		{
			dx += (float)((int)this.drawOrigin.x);
			dy += (float)((int)this.drawOrigin.y);
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)RenderTexture.active.width, (float)RenderTexture.active.height, 0f);
				if (sx < 0f)
				{
					width += sx;
					dx -= sx;
					sx = 0f;
				}
				if (sy < 0f)
				{
					height += sy;
					dy -= sy;
					sy = 0f;
				}
				if (width > (float)texture.width - sx)
				{
					width = (float)texture.width - sx;
				}
				if (height > (float)texture.height - sy)
				{
					height = (float)texture.height - sy;
				}
				if (width > 0f && height > 0f)
				{
					Rect rect = (ignoreFlip ? new Rect(dx, dy, width, height) : this.ApplyFlipMode(new Rect(dx, dy, width, height)));
					Rect rect2 = this.CalcSrcRect(texture, sx, sy, width, height, ignoreFlip);
					SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetColor("_AppendColor", new Color(1f, 1f, 1f, alpha));
					Graphics.DrawTexture(rect, texture, rect2, 0, 0, 0, 0, SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial);
					this.ResetFlipMode();
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.PopMatrix();
			}
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x00122B60 File Offset: 0x00120D60
		private Rect CalcSrcRect(Texture texture, float sx, float sy, float width, float height, bool ignoreFlip)
		{
			float num;
			float num2;
			float num3;
			float num4;
			if (ignoreFlip)
			{
				num = sx / (float)texture.width;
				num2 = ((float)texture.height - (sy + height)) / (float)texture.height;
				num3 = width / (float)texture.width;
				num4 = height / (float)texture.height;
			}
			else
			{
				switch (this.flipMode)
				{
				case 3:
				{
					float num5 = (float)texture.width / width;
					float num6 = (float)texture.height / height;
					num = 1f - 1f / num5 - sx / (float)texture.width;
					num2 = 1f - 1f / num6 - ((float)texture.height - (sy + height)) / (float)texture.height;
					num3 = width / (float)texture.width;
					num4 = height / (float)texture.height;
					break;
				}
				case 4:
				case 7:
				{
					if (texture.width > texture.height)
					{
						float num7 = (float)texture.width / (float)texture.height;
						width /= num7;
						height *= num7;
						sx /= num7;
						sy *= num7;
					}
					else
					{
						float num7 = (float)texture.height / (float)texture.width;
						width *= num7;
						height /= num7;
						sx *= num7;
						sy /= num7;
					}
					float num8 = width;
					width = height;
					height = num8;
					float num9 = sx;
					sx = sy;
					sy = num9;
					num = sx / (float)texture.width;
					num2 = sy / (float)texture.height;
					num3 = width / (float)texture.width;
					num4 = height / (float)texture.height;
					break;
				}
				case 5:
				case 6:
				{
					if (texture.width > texture.height)
					{
						float num10 = (float)texture.width / (float)texture.height;
						width /= num10;
						height *= num10;
						sx /= num10;
						sy *= num10;
					}
					else
					{
						float num10 = (float)texture.height / (float)texture.width;
						width *= num10;
						height /= num10;
						sx *= num10;
						sy /= num10;
					}
					float num11 = width;
					width = height;
					height = num11;
					float num12 = sx;
					sx = sy;
					sy = num12;
					float num13 = (float)texture.width / width;
					num = 1f - 1f / num13 - sx / (float)texture.width;
					num2 = ((float)texture.height - (sy + height)) / (float)texture.height;
					num3 = width / (float)texture.width;
					num4 = height / (float)texture.height;
					break;
				}
				default:
					num = sx / (float)texture.width;
					num2 = ((float)texture.height - (sy + height)) / (float)texture.height;
					num3 = width / (float)texture.width;
					num4 = height / (float)texture.height;
					break;
				}
			}
			return new Rect(num, num2, num3, num4);
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x00122E14 File Offset: 0x00121014
		public void DrawScaledImage(Image image, int dx, int dy, int width, int height, int sx, int sy, int swidth, int sheight)
		{
			if (width < 0 || height < 0 || swidth < 0 || sheight < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null || image.Texture == null)
			{
				return;
			}
			this.ApplyPaletteImage(image);
			Texture texture = image.Texture;
			if (image.Texture == this.renderTexture)
			{
				this.CopyRenderTexture();
				texture = this.copyTexture;
			}
			float num = (float)image.Alpha / 255f;
			this.RenderStart();
			this.DrawScaledImageImpl(texture, (float)dx, (float)dy, (float)width, (float)height, (float)sx, (float)sy, (float)swidth, (float)sheight, num, false);
			this.RenderEnd();
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x00122EC0 File Offset: 0x001210C0
		private void DrawScaledImageImpl(Texture texture, float dx, float dy, float width, float height, float sx, float sy, float swidth, float sheight, float alpha = 1f, bool ignoreFlip = false)
		{
			dx += (float)((int)this.drawOrigin.x);
			dy += (float)((int)this.drawOrigin.y);
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				float num = width / swidth;
				float num2 = height / sheight;
				if (sx < 0f)
				{
					swidth += sx;
					width += sx * num;
					dx -= sx;
					sx = 0f;
				}
				if (sy < 0f)
				{
					sheight += sy;
					height += sy * num2;
					dy -= sy;
					sy = 0f;
				}
				if (swidth > (float)texture.width - sx)
				{
					swidth = (float)texture.width - sx;
					width = swidth * num;
				}
				if (sheight > (float)texture.height - sy)
				{
					sheight = (float)texture.height - sy;
					height = sheight * num2;
				}
				if (swidth > 0f && sheight > 0f)
				{
					Rect rect = (ignoreFlip ? new Rect(dx, dy, width, height) : this.ApplyFlipMode(new Rect(dx, dy, width, height)));
					Rect rect2 = this.CalcSrcRect(texture, sx, sy, swidth, sheight, ignoreFlip);
					SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetColor("_AppendColor", new Color(1f, 1f, 1f, alpha));
					Graphics.DrawTexture(rect, texture, rect2, 0, 0, 0, 0, SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial);
					this.ResetFlipMode();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			finally
			{
				GL.PopMatrix();
			}
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x00123088 File Offset: 0x00121288
		public void DrawImage(Image image, int[] matrix)
		{
			if (matrix.Length < 6)
			{
				throw new IndexOutOfRangeException("Lack of Length");
			}
			if (this.renderTexture == null || image.Texture == null)
			{
				return;
			}
			this.ApplyPaletteImage(image);
			float num = (float)image.Alpha / 255f;
			this.GetUnityMatrix4x4(matrix);
			this.RenderStart();
			this.DrawAffineImageImpl(image.Texture, 0f, 0f, (float)image.Texture.width, (float)image.Texture.height, Matrix4x4.identity, num);
			this.RenderEnd();
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x00123120 File Offset: 0x00121320
		public void DrawImage(Image image, int[] matrix, int sx, int sy, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (matrix.Length < 6)
			{
				throw new IndexOutOfRangeException("Lack of Length");
			}
			if (this.renderTexture == null || image.Texture == null)
			{
				return;
			}
			this.ApplyPaletteImage(image);
			float num = (float)image.Alpha / 255f;
			Matrix4x4 unityMatrix4x = this.GetUnityMatrix4x4(matrix);
			float num2 = (float)(sx + width / 2 / image.Texture.width);
			float num3 = (float)(sy + height / 2 / image.Texture.height);
			Debug.Log("Center X:" + num2.ToString() + " Y:" + num3.ToString());
			this.RenderStart();
			this.DrawAffineImageImpl(image.Texture, (float)sx, (float)sy, (float)width, (float)height, unityMatrix4x, 1f);
			this.RenderEnd();
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x001231FC File Offset: 0x001213FC
		private Matrix4x4 GetUnityMatrix4x4(int[] matrix)
		{
			Matrix4x4 identity = Matrix4x4.identity;
			identity.m00 = (float)matrix[0] / 4096f;
			identity.m01 = (float)matrix[1] / 4096f;
			identity.m02 = (float)matrix[2] / 4096f;
			identity.m10 = (float)matrix[3] / 4096f;
			identity.m11 = (float)matrix[4] / 4096f;
			identity.m12 = (float)matrix[5] / 4096f;
			return identity;
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x00123278 File Offset: 0x00121478
		private void DrawAffineImageImpl(Texture texture, float sx, float sy, float width, float height, Matrix4x4 matrix, float alpha = 1f)
		{
			try
			{
				GL.Begin(7);
				GL.PushMatrix();
				GL.LoadPixelMatrix((float)(-(float)this.renderTexture.width) / 2f, (float)this.renderTexture.width / 2f, (float)this.renderTexture.height / 2f, (float)(-(float)this.renderTexture.height) / 2f);
				GL.MultMatrix(matrix);
				if (width > (float)texture.width - sx)
				{
					width = (float)texture.width - sx;
				}
				if (height > (float)texture.height - sy)
				{
					height = (float)texture.height - sy;
				}
				if (width > 0f && height > 0f)
				{
					Rect rect;
					rect..ctor(sx / (float)texture.width, ((float)texture.height - (sy + height)) / (float)texture.height, width / (float)texture.width, height / (float)texture.height);
					float num = sx - (float)this.renderTexture.width / 2f;
					float num2 = sy - (float)this.renderTexture.height / 2f;
					List<Vector3> list = new List<Vector3>
					{
						new Vector3(num, num2, 0f),
						new Vector3(num, num2 + height, 0f),
						new Vector3(num + width, num2 + height, 0f),
						new Vector3(num + width, num2, 0f)
					};
					List<Vector2> list2 = new List<Vector2>
					{
						new Vector2(rect.x, rect.y + rect.height),
						new Vector2(rect.x, rect.y),
						new Vector2(rect.x + rect.width, rect.y),
						new Vector2(rect.x + rect.width, rect.y + rect.height)
					};
					SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.mainTexture = texture;
					SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetColor("_AppendColor", new Color(1f, 1f, 1f, alpha));
					SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetPass(0);
					for (int i = 0; i < list.Count; i++)
					{
						GL.TexCoord(list2[i]);
						GL.Vertex(list[i]);
					}
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
			}
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x00123558 File Offset: 0x00121758
		private Rect ApplyFlipMode(Rect source)
		{
			Rect rect;
			rect..ctor(source);
			SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 0f);
			switch (this.flipMode)
			{
			case 1:
				rect.x += rect.width;
				rect.width = -rect.width;
				break;
			case 2:
				rect.y += rect.height;
				rect.height = -rect.height;
				break;
			case 3:
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 2f);
				break;
			case 4:
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 3f);
				if (source.width != source.height)
				{
					rect.width = source.height;
					rect.height = source.width;
				}
				break;
			case 5:
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 1f);
				if (source.width != source.height)
				{
					rect.width = source.height;
					rect.height = source.width;
				}
				break;
			case 6:
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 1f);
				if (source.width != source.height)
				{
					rect.width = source.height;
					rect.height = source.width;
				}
				rect.y += rect.height;
				rect.height = -rect.height;
				break;
			case 7:
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 3f);
				if (source.width != source.height)
				{
					rect.width = source.height;
					rect.height = source.width;
				}
				rect.x += rect.width;
				rect.width = -rect.width;
				break;
			}
			return rect;
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x00123795 File Offset: 0x00121995
		private void ResetFlipMode()
		{
			SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetFloat("_RotType", 0f);
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x001237B0 File Offset: 0x001219B0
		public void DrawLine(int x1, int y1, int x2, int y2)
		{
			if (this.renderTexture == null)
			{
				return;
			}
			x1 += (int)this.drawOrigin.x;
			y1 += (int)this.drawOrigin.y;
			x2 += (int)this.drawOrigin.x;
			y2 += (int)this.drawOrigin.y;
			this.RenderStart();
			GL.PushMatrix();
			GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
			GL.Begin(7);
			this.GetGlMaterial().SetPass(0);
			GL.Color(this.currentColor);
			Vector2 normalized = new Vector2((float)(x2 - x1), (float)(y2 - y1)).normalized;
			Vector2 vector;
			vector..ctor(-normalized.y, normalized.x);
			vector *= 0.5f;
			if (x1 <= x2)
			{
				x2++;
			}
			else
			{
				x1++;
			}
			if (y1 <= y2)
			{
				y2++;
			}
			else
			{
				y1++;
			}
			Vector2 vector2 = new Vector2((float)x1, (float)y1) + vector;
			Vector2 vector3 = new Vector2((float)x1, (float)y1) - vector;
			Vector2 vector4 = new Vector2((float)x2, (float)y2) - vector;
			Vector2 vector5 = new Vector2((float)x2, (float)y2) + vector;
			GL.Vertex3(vector2.x, vector2.y, 0f);
			GL.Vertex3(vector3.x, vector3.y, 0f);
			GL.Vertex3(vector4.x, vector4.y, 0f);
			GL.Vertex3(vector5.x, vector5.y, 0f);
			GL.End();
			GL.PopMatrix();
			this.RenderEnd();
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x00123968 File Offset: 0x00121B68
		public void DrawRect(int x, int y, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			this.DrawLine(x, y, x + width, y);
			this.DrawLine(x, y, x, y + height);
			this.DrawLine(x + width, y, x + width, y + height);
			this.DrawLine(x, y + height, x + width, y + height);
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x001239C0 File Offset: 0x00121BC0
		public void FillRect(int x, int y, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			x += (int)this.drawOrigin.x;
			y += (int)this.drawOrigin.y;
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(7);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.currentColor);
				int width2 = this.renderTexture.width;
				int height2 = this.renderTexture.height;
				GL.TexCoord2((float)x / (float)width2, (float)(y + height) / (float)height2);
				GL.Vertex3((float)x, (float)(y + height), 1f);
				GL.TexCoord2((float)x / (float)width2, (float)y / (float)height2);
				GL.Vertex3((float)x, (float)y, 1f);
				GL.TexCoord2((float)(x + width) / (float)width2, (float)y / (float)height2);
				GL.Vertex3((float)(x + width), (float)y, 1f);
				GL.TexCoord2((float)(x + width) / (float)width2, (float)(y + height) / (float)height2);
				GL.Vertex3((float)(x + width), (float)(y + height), 1f);
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x00123B64 File Offset: 0x00121D64
		public void FillRectArray(int[] x, int[] y, int[] width, int[] height, int length)
		{
			if (this.renderTexture == null)
			{
				return;
			}
			int num = (int)this.drawOrigin.x;
			int num2 = (int)this.drawOrigin.y;
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(7);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.currentColor);
				int width2 = this.renderTexture.width;
				int height2 = this.renderTexture.height;
				for (int i = 0; i < length; i++)
				{
					GL.TexCoord2((float)(x[i] + num) / (float)width2, (float)(y[i] + height[i] + num2) / (float)height2);
					GL.Vertex3((float)(x[i] + num), (float)(y[i] + height[i] + num2), 1f);
					GL.TexCoord2((float)(x[i] + num) / (float)width2, (float)(y[i] + num2) / (float)height2);
					GL.Vertex3((float)(x[i] + num), (float)(y[i] + num2), 1f);
					GL.TexCoord2((float)(x[i] + width[i] + num) / (float)width2, (float)(y[i] + num2) / (float)height2);
					GL.Vertex3((float)(x[i] + width[i] + num), (float)(y[i] + num2), 1f);
					GL.TexCoord2((float)(x[i] + width[i] + num) / (float)width2, (float)(y[i] + height[i] + num2) / (float)height2);
					GL.Vertex3((float)(x[i] + width[i] + num), (float)(y[i] + height[i] + num2), 1f);
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x00123D74 File Offset: 0x00121F74
		public void ClearRect(int x, int y, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			this.RenderStart();
			x += (int)this.drawOrigin.x;
			y += (int)this.drawOrigin.y;
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(7);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.backgroundColor);
				int width2 = this.renderTexture.width;
				int height2 = this.renderTexture.height;
				GL.TexCoord2((float)x / (float)width2, (float)(y + height) / (float)height2);
				GL.Vertex3((float)x, (float)(y + height), 1f);
				GL.TexCoord2((float)x / (float)width2, (float)y / (float)height2);
				GL.Vertex3((float)x, (float)y, 1f);
				GL.TexCoord2((float)(x + width) / (float)width2, (float)y / (float)height2);
				GL.Vertex3((float)(x + width), (float)y, 1f);
				GL.TexCoord2((float)(x + width) / (float)width2, (float)(y + height) / (float)height2);
				GL.Vertex3((float)(x + width), (float)(y + height), 1f);
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x00123F18 File Offset: 0x00122118
		public static void ClearRenderTexture(RenderTexture rt)
		{
			if (rt == null)
			{
				return;
			}
			RenderTexture.active = rt;
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)rt.width, (float)rt.height, 0f);
				GL.Clear(true, true, Color.white, 1f);
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				RenderTexture.active = null;
			}
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x00123FB8 File Offset: 0x001221B8
		public void DrawString(string str, int x, int y)
		{
			char[] array;
			if (str != null)
			{
				for (int i = 0; i < this.replaceTarget.Length; i++)
				{
					str = str.Replace(this.replaceTarget[i], this.replaceString[i]);
				}
				array = str.ToCharArray();
			}
			else
			{
				array = new char[0];
			}
			this.DrawCharImpl(array, x, y);
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x0012400C File Offset: 0x0012220C
		public void DrawCharImpl(char[] cText, int offsetX, int offsetY)
		{
			offsetX += (int)this.drawOrigin.x;
			offsetY += (int)this.drawOrigin.y;
			this.currentFont.Font.RequestCharactersInTexture(new string(cText), (int)this.currentFont.Size);
			Font font = this.currentFont.Font;
			if (this.gomiTexture == null)
			{
				this.gomiTexture = new RenderTexture(this.renderTexture);
			}
			Graphics.Blit(this.renderTexture, this.gomiTexture);
			this.RenderStart();
			float num = (float)(this.renderTexture.height - offsetY);
			StFont.FontMeshData fontMeshData = this.currentFont.GenerateFontMesh((float)offsetX, num, cText);
			GL.Begin(7);
			GL.PushMatrix();
			GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, 0f, (float)this.renderTexture.height);
			font.material.SetColor("_Color", this.currentColor);
			font.material.SetPass(0);
			for (int i = 0; i < fontMeshData.vertices.Length; i++)
			{
				GL.TexCoord(fontMeshData.uvs[i]);
				GL.Vertex(fontMeshData.vertices[i]);
			}
			GL.End();
			GL.PopMatrix();
			this.RenderEnd();
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0012415C File Offset: 0x0012235C
		public void FillArc(int x, int y, int width, int height, int startAngle, int arcAngle)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			x += (int)this.drawOrigin.x;
			y += (int)this.drawOrigin.y;
			Vector2[] arcPoint = this.GetArcPoint((float)width, (float)height, (float)startAngle, (float)arcAngle);
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(4);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.currentColor);
				Vector2 vector;
				vector..ctor((float)(x + width / 2), (float)(y + height / 2));
				Vector2 vector2;
				vector2..ctor((vector.x - (float)x) / (float)width, (vector.y - (float)y) / (float)height);
				for (int i = 1; i < arcPoint.Length - 1; i++)
				{
					Vector3 vector3;
					vector3..ctor((float)x + arcPoint[i].x, (float)y + arcPoint[i].y, 1f);
					Vector3 vector4;
					vector4..ctor((float)x + arcPoint[i + 1].x, (float)y + arcPoint[i + 1].y, 1f);
					Vector3 vector5;
					vector5..ctor(vector.x, vector.y, 1f);
					Vector2 vector6;
					vector6..ctor((vector3.x - (float)x) / (float)width, (vector3.y - (float)y) / (float)height);
					Vector2 vector7;
					vector7..ctor((vector4.x - (float)x) / (float)width, (vector4.y - (float)y) / (float)height);
					Vector2 vector8 = vector2;
					GL.TexCoord2(vector6.x, vector6.y);
					GL.Vertex3(vector3.x, vector3.y, vector3.z);
					GL.TexCoord2(vector7.x, vector7.y);
					GL.Vertex3(vector4.x, vector4.y, vector4.z);
					GL.TexCoord2(vector8.x, vector8.y);
					GL.Vertex3(vector5.x, vector5.y, vector5.z);
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x001243FC File Offset: 0x001225FC
		public void DrawArc(int x, int y, int width, int height, int startAngle, int arcAngle)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			x += (int)this.drawOrigin.x;
			y += (int)this.drawOrigin.y;
			width++;
			height++;
			Vector2[] arcPoint = this.GetArcPoint((float)width, (float)height, (float)startAngle, (float)arcAngle);
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(1);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.currentColor);
				for (int i = 1; i < arcPoint.Length - 1; i++)
				{
					Vector3 vector;
					vector..ctor((float)x + arcPoint[i].x, (float)y + arcPoint[i].y, 1f);
					Vector3 vector2;
					vector2..ctor((float)x + arcPoint[i + 1].x, (float)y + arcPoint[i + 1].y, 1f);
					Vector2 vector3;
					vector3..ctor((vector.x - (float)x) / (float)width, (vector.y - (float)y) / (float)height);
					Vector2 vector4;
					vector4..ctor((vector2.x - (float)x) / (float)width, (vector2.y - (float)y) / (float)height);
					GL.TexCoord2(vector3.x, vector3.y);
					GL.Vertex3(vector.x, vector.y, vector.z);
					GL.TexCoord2(vector4.x, vector4.y);
					GL.Vertex3(vector2.x, vector2.y, vector2.z);
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x00124628 File Offset: 0x00122828
		private Vector2[] GetArcPoint(float width, float height, float startAngle, float arcAngle)
		{
			List<Vector2> list = new List<Vector2>();
			list.Add(Vector2.zero);
			Quaternion quaternion = Quaternion.Euler(new Vector3(0f, 0f, startAngle));
			Matrix4x4 matrix4x = default(Matrix4x4);
			matrix4x.SetTRS(Vector3.zero, quaternion, Vector3.one);
			Vector2 vector = matrix4x.MultiplyVector(Vector2.right);
			list.Add(vector);
			float num = arcAngle / 36f;
			quaternion = Quaternion.Euler(new Vector3(0f, 0f, num));
			matrix4x.SetTRS(Vector3.zero, quaternion, Vector3.one);
			float num2 = 0f;
			while (num2 < arcAngle)
			{
				Vector2 vector2 = matrix4x.MultiplyVector(vector);
				num2 += num;
				vector = vector2;
				list.Add(vector);
			}
			float num3 = width / 2f;
			float num4 = height / 2f;
			Vector2 vector3;
			vector3..ctor(width / 2f, height / 2f);
			List<Vector2> list2 = new List<Vector2>();
			for (int i = 0; i < list.Count; i++)
			{
				list2.Add(new Vector2(list[i].x * num3 + vector3.x, list[i].y * num4 + vector3.y));
			}
			return list2.ToArray();
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x00124780 File Offset: 0x00122980
		public void DrawPolyline(int[] xPoints, int[] yPoints, int nPoints)
		{
			if (nPoints < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (xPoints.Length < nPoints || yPoints.Length < nPoints)
			{
				throw new IndexOutOfRangeException();
			}
			if (nPoints == 1)
			{
				this.SetPixel(xPoints[0], yPoints[0]);
				return;
			}
			if (this.renderTexture == null)
			{
				return;
			}
			int num = (int)this.drawOrigin.x;
			int num2 = (int)this.drawOrigin.y;
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(1);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.currentColor);
				int width = this.renderTexture.width;
				int height = this.renderTexture.height;
				for (int i = 0; i < nPoints - 1; i++)
				{
					GL.TexCoord2((float)(xPoints[i] + num) / (float)width, (float)(yPoints[i] + num2) / (float)height);
					GL.Vertex3((float)(xPoints[i] + num), (float)(yPoints[i] + num2), 1f);
					GL.TexCoord2((float)(xPoints[i + 1] + num) / (float)width, (float)(yPoints[i + 1] + num2) / (float)height);
					GL.Vertex3((float)(xPoints[i + 1] + num), (float)(yPoints[i + 1] + num2), 1f);
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x00124930 File Offset: 0x00122B30
		public void DrawPolyline(int[] xPoints, int[] yPoints, int offset, int count)
		{
			if (offset < 0 || count < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (xPoints.Length < offset + count || yPoints.Length < offset + count)
			{
				throw new IndexOutOfRangeException();
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < count; i++)
			{
				list.Add(xPoints[i + offset]);
				list2.Add(yPoints[i + offset]);
			}
			this.DrawPolyline(list.ToArray(), list2.ToArray(), count);
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x001249A8 File Offset: 0x00122BA8
		public void FillPolygon(int[] xPoints, int[] yPoints, int nPoints)
		{
			if (nPoints < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (xPoints.Length < nPoints || yPoints.Length < nPoints)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			int num = (int)this.drawOrigin.x;
			int num2 = (int)this.drawOrigin.y;
			if (nPoints < 3)
			{
				return;
			}
			Vector3[] array = new Vector3[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				array[i] = new Vector3((float)xPoints[i], (float)yPoints[i]);
			}
			List<Vector3> list = new List<Vector3>();
			for (int j = 0; j < array.Length - 2; j++)
			{
				for (int k = j + 1; k < array.Length - 1; k++)
				{
					for (int l = k + 1; l < array.Length; l++)
					{
						bool flag = true;
						for (int m = 1; m < 10; m++)
						{
							Vector3 vector = Vector3.Lerp(Vector3.Lerp(array[j], array[k], (float)m / 10f), array[l], 0.1f);
							if (!StGraphics.CheckInnerPolygon(array, vector, Vector3.zero))
							{
								flag = false;
								break;
							}
							vector = Vector3.Lerp(Vector3.Lerp(array[k], array[l], (float)m / 10f), array[j], 0.1f);
							if (!StGraphics.CheckInnerPolygon(array, vector, Vector3.zero))
							{
								flag = false;
								break;
							}
							vector = Vector3.Lerp(Vector3.Lerp(array[l], array[j], (float)m / 10f), array[k], 0.1f);
							if (!StGraphics.CheckInnerPolygon(array, vector, Vector3.zero))
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							list.Add(array[j]);
							list.Add(array[k]);
							list.Add(array[l]);
						}
					}
				}
			}
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				GL.Begin(4);
				this.GetGlMaterial().SetPass(0);
				GL.Color(this.currentColor);
				if (list.Count > 0)
				{
					float num3 = list.Min((Vector3 v) => v.x);
					float num4 = list.Max((Vector3 v) => v.x);
					float num5 = list.Min((Vector3 v) => v.y);
					float num6 = list.Max((Vector3 v) => v.y);
					float num7 = Mathf.Max(1E-05f, num4 - num3);
					float num8 = Mathf.Max(1E-05f, num6 - num5);
					for (int n = 0; n < list.Count; n++)
					{
						GL.TexCoord2((list[n].x - num3) / num7, (list[n].y - num5) / num8);
						GL.Vertex3(list[n].x + (float)num, list[n].y + (float)num2, 1f);
					}
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.End();
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x00124D90 File Offset: 0x00122F90
		public void FillPolygon(int[] xPoints, int[] yPoints, int offset, int count)
		{
			if (offset < 0 || count < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (xPoints.Length < offset + count || yPoints.Length < offset + count)
			{
				throw new IndexOutOfRangeException();
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < count; i++)
			{
				list.Add(xPoints[i + offset]);
				list2.Add(yPoints[i + offset]);
			}
			this.FillPolygon(list.ToArray(), list2.ToArray(), count);
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x00124E08 File Offset: 0x00123008
		public int GetRGBPixel(int x, int y)
		{
			Color color;
			try
			{
				RenderTexture.active = this.renderTexture;
				RenderTexture active = RenderTexture.active;
				if (this.workGetPixelTexture == null || this.workGetPixelTexture.width != active.width || this.workGetPixelTexture.height != active.height)
				{
					this.workGetPixelTexture = new Texture2D(active.width, active.height, 4, false);
				}
				this.workGetPixelTexture.ReadPixels(new Rect(0f, 0f, (float)active.width, (float)active.height), 0, 0);
				this.workGetPixelTexture.Apply();
				color = this.workGetPixelTexture.GetPixel(x + 1, active.height - (y + 1));
			}
			catch (Exception)
			{
				color = Color.black;
			}
			finally
			{
				RenderTexture.active = null;
			}
			return StGraphics.GetColorOfRGB((int)(color.r * 255f), (int)(color.g * 255f), (int)(color.b * 255f));
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x00124F1C File Offset: 0x0012311C
		public int[] GetRGBPixels(int x, int y, int width, int height, int[] pixels, int off)
		{
			if (width <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (height <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (off < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (pixels != null && pixels.Length < off + width * height)
			{
				throw new IndexOutOfRangeException();
			}
			if (pixels == null)
			{
				pixels = new int[off + width * height];
			}
			try
			{
				RenderTexture.active = this.renderTexture;
				RenderTexture active = RenderTexture.active;
				int width2 = active.width;
				int height2 = active.height;
				if (this.workGetPixelTexture == null || this.workGetPixelTexture.width != width2 || this.workGetPixelTexture.height != height2)
				{
					this.workGetPixelTexture = new Texture2D(width2, height2, 4, false);
				}
				this.workGetPixelTexture.ReadPixels(new Rect(0f, 0f, (float)width2, (float)height2), 0, 0);
				this.workGetPixelTexture.Apply();
				Color[] pixels2 = this.workGetPixelTexture.GetPixels();
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						Color color = pixels2[(height2 - (y + j) - 1) * width2 + (x + i)];
						pixels[off + j * width + i] = StGraphics.GetColorOfRGB((int)(color.r * 255f), (int)(color.g * 255f), (int)(color.b * 255f), 0);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			finally
			{
				RenderTexture.active = null;
			}
			return pixels;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x001250B8 File Offset: 0x001232B8
		public void SetPixel(int x, int y)
		{
			this.FillRect(x, y, 1, 1);
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x001250C4 File Offset: 0x001232C4
		public void SetPixel(int x, int y, int color)
		{
			Color color2 = this.currentColor;
			this.SetColor(color);
			this.SetPixel(x, y);
			this.currentColor = color2;
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x001250F0 File Offset: 0x001232F0
		public void SetRGBPixels(int x, int y, int width, int height, int[] pixels, int off)
		{
			if (pixels == null)
			{
				throw new ArgumentNullException();
			}
			if (width <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (height <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (off < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (pixels != null && pixels.Length < off + width * height)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			x += (int)this.drawOrigin.x;
			y += (int)this.drawOrigin.y;
			this.RenderStart();
			try
			{
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 0f);
				Color[] array = new Color[width * height];
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						int num = pixels[off + j * width + i] | -16777216;
						array[(height - j - 1) * width + i] = StGraphics.CalcColor(num);
					}
				}
				if (this.workGetPixelTexture == null || this.workGetPixelTexture.width != width || this.workGetPixelTexture.height != height)
				{
					this.workGetPixelTexture = new Texture2D(width, height, 4, false);
				}
				this.workGetPixelTexture.SetPixels(array);
				this.workGetPixelTexture.Apply();
				Rect rect = new Rect((float)x, (float)y, (float)width, (float)height);
				Rect rect2 = this.CalcSrcRect(this.workGetPixelTexture, (float)x, (float)y, (float)width, (float)height, true);
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetColor("_AppendColor", new Color(1f, 1f, 1f, 1f));
				Graphics.DrawTexture(rect, this.workGetPixelTexture, rect2, 0, 0, 0, 0, SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial);
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.PopMatrix();
				this.RenderEnd();
			}
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x00125310 File Offset: 0x00123510
		public void SetFont(StFont f)
		{
			this.currentFont = f;
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x00125319 File Offset: 0x00123519
		public void SetOrigin(int x, int y)
		{
			this.drawOrigin = new Vector2((float)x, (float)y);
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x0012532A File Offset: 0x0012352A
		public void SetPictoColorEnabled(bool flag)
		{
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x0012532C File Offset: 0x0012352C
		public void SetFlipMode(int mode)
		{
			this.flipMode = mode;
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00125338 File Offset: 0x00123538
		public void SetClip(int x, int y, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			this.clipRect.x = (float)x;
			this.clipRect.y = (float)y;
			this.clipRect.width = (float)width;
			this.clipRect.height = (float)height;
			if (x == 0 && y == 0 && height >= this.renderTexture.height && width >= this.renderTexture.width)
			{
				this.isClipping = false;
				return;
			}
			if (this.workTexture == null)
			{
				this.workTexture = new RenderTexture(this.renderTexture);
				this.workTexture.Create();
			}
			Graphics.Blit(this.renderTexture, this.workTexture);
			this.isClipping = true;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x001253F7 File Offset: 0x001235F7
		public void ClipRect(int x, int y, int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			this.SetClip(x, y, width, height);
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x00125414 File Offset: 0x00123614
		public void ClearClip()
		{
			this.clipRect.x = 0f;
			this.clipRect.y = 0f;
			this.clipRect.width = 0f;
			this.clipRect.height = 0f;
			this.isClipping = false;
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x00125468 File Offset: 0x00123668
		public void CopyArea(int x, int y, int width, int height, int dx, int dy)
		{
			if (width < 0 || height < 0)
			{
				throw new IndexOutOfRangeException();
			}
			if (this.renderTexture == null)
			{
				return;
			}
			this.CopyRenderTexture();
			this.RenderStart();
			this.DrawImageImpl(this.copyTexture, (float)(x + dx), (float)(y + dy), (float)x, (float)y, (float)width, (float)height, 1f, true);
			this.RenderEnd();
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x001254CA File Offset: 0x001236CA
		private float GetX(float x)
		{
			return this.drawOrigin.x + x;
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x001254D9 File Offset: 0x001236D9
		private float GetY(float y)
		{
			return this.drawOrigin.y + y;
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x001254E8 File Offset: 0x001236E8
		private void RenderStart()
		{
			if (this.isClipping)
			{
				Graphics.Blit(this.renderTexture, this.workTexture);
				RenderTexture.active = this.workTexture;
			}
			else
			{
				RenderTexture.active = this.renderTexture;
			}
			if (this.renderMode == 1 || this.renderMode == 2)
			{
				if (this.bgWorkTexture == null)
				{
					this.bgWorkTexture = new RenderTexture(this.renderTexture);
					this.bgWorkTexture.Create();
				}
				RenderTexture active = RenderTexture.active;
				Graphics.Blit(RenderTexture.active, this.bgWorkTexture);
				RenderTexture.active = active;
				SingletonBehaviour<StScreenManager>.Instance.drawImageMaterial.SetTexture("_BgTex", this.bgWorkTexture);
				SingletonBehaviour<StScreenManager>.Instance.drawGlMaterial.SetTexture("_BgTex", this.bgWorkTexture);
			}
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x001255B4 File Offset: 0x001237B4
		private void RenderEnd()
		{
			RenderTexture.active = null;
			if (this.isClipping)
			{
				RenderTexture.active = this.renderTexture;
				this.DrawImageImpl(this.workTexture, this.clipRect.x, this.clipRect.y, this.clipRect.x, this.clipRect.y, this.clipRect.width, this.clipRect.height, 1f, true);
				RenderTexture.active = null;
			}
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x00125634 File Offset: 0x00123834
		public StGraphics Copy()
		{
			StGraphics2 stGraphics = base.gameObject.GetComponent<StGraphics2>();
			if (stGraphics == null)
			{
				stGraphics = base.gameObject.AddComponent<StGraphics2>();
			}
			stGraphics.RenderTexture = this.renderTexture;
			return stGraphics;
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0012566F File Offset: 0x0012386F
		protected virtual Material GetGlMaterial()
		{
			return SingletonBehaviour<StScreenManager>.Instance.defaultMaterial;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600143B RID: 5179 RVA: 0x0012567B File Offset: 0x0012387B
		public Matrix4x4 Projection
		{
			get
			{
				return this.projectionMatrix;
			}
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x00125684 File Offset: 0x00123884
		private void Init3D()
		{
			GameObject gameObject = AssetLoadUtil.LoadAsset<GameObject>("Prefab/StGraphics3D.prefab", null);
			this.g3dPrefab = Object.Instantiate<GameObject>(gameObject, base.transform);
			this.center.x = (float)(this.renderTexture.width / 2);
			this.center.y = (float)(this.renderTexture.height / 2);
			this.g3dCamera = this.g3dPrefab.GetComponentInChildren<Camera>();
			this.g3dRenderTexture = RenderTexture.GetTemporary(this.renderTexture.width * 2, this.renderTexture.height * 2, 32);
			this.g3dTextureMag = new Vector2((float)this.g3dRenderTexture.width, (float)this.g3dRenderTexture.height).normalized.magnitude;
			this.Clear3DBuffer();
			this.g3dDebugTexture = RenderTexture.GetTemporary(this.g3dRenderTexture.width, this.g3dRenderTexture.height, 32);
			this.figureTexture = RenderTexture.GetTemporary(this.g3dRenderTexture.width, this.g3dRenderTexture.height, 32);
			this.g3dCamera.depthTextureMode |= 1;
			this.g3dCamera.targetTexture = this.g3dRenderTexture;
			this.cameraPos = this.g3dCamera.transform.position;
			this.g3dLight = Object.FindFirstObjectByType<Light>();
			this.viewPort = new AffineTrans();
			this.viewPort.m03 = this.renderTexture.width / 2;
			this.viewPort.m13 = this.renderTexture.height / 2;
			this.SetScreenScale(4096, 4096);
			this.clipRect3D = new Rect(0f, 0f, (float)this.renderTexture.width, (float)this.renderTexture.height);
			this.waitRenderFigure = new List<Figure>();
			this.primitivesCommandList = new List<int>();
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x0012586B File Offset: 0x00123A6B
		public void DrawFigure(Figure figure, StTransform trans, bool immidiate = true)
		{
			this.DrawFigureImpl(figure, trans, immidiate);
		}

		// Token: 0x0600143E RID: 5182 RVA: 0x00125878 File Offset: 0x00123A78
		public void DrawFigure(Figure figure)
		{
			RenderTexture.active = this.g3dRenderTexture;
			GL.Clear(true, true, Color.clear, 1f);
			this.DrawFigureImpl(figure, null, true);
			RenderTexture.active = this.renderTexture;
			this.DrawImageImpl(this.g3dRenderTexture, 0f, 0f, (float)this.renderTexture.width - this.center.x, (float)this.renderTexture.height - this.center.y, (float)this.renderTexture.width, (float)this.renderTexture.height, 1f, true);
			RenderTexture.active = null;
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x00125920 File Offset: 0x00123B20
		protected void DrawFigureImpl(Figure figure, StTransform trans, bool immidiate = false)
		{
			if (this.g3dRenderTexture == null)
			{
				return;
			}
			this.CheckNeed2DFlush();
			try
			{
				GL.PushMatrix();
				GameObject rootObject = figure.RootObject;
				Quaternion rotation = trans.GetUnityMatrix().rotation;
				Quaternion rotation2 = this.viewPort.Matrix.inverse.rotation;
				Quaternion quaternion = rotation;
				Vector3 position = trans.GetUnityMatrix().GetPosition();
				Vector3 vector = trans.GetUnityMatrix().lossyScale / 64f;
				if (this.g3dCamera.orthographic)
				{
					figure.SetRenderEnable(true);
					figure.Renderers[0].material.SetColor("_Ambient", this.isEnableLight ? Color.white : Color.gray);
					this.g3dCamera.targetTexture = this.g3dRenderTexture;
					Quaternion rotation3 = trans.GetUnityMatrix().rotation;
					rootObject.transform.SetPositionAndRotation(position, rotation3);
					rootObject.transform.localScale = Vector3.Scale(Figure.ConvertVector, vector);
					Matrix4x4 matrix4x = this.g3dCamera.projectionMatrix;
					matrix4x.m03 = this.figureCenter.x;
					matrix4x.m13 = this.figureCenter.y;
					this.g3dCamera.projectionMatrix = matrix4x;
					Vector3 position2 = this.viewPort.Matrix.inverse.GetPosition();
					this.g3dCamera.transform.SetPositionAndRotation(position2, this.viewPort.Matrix.inverse.rotation);
					this.g3dCamera.clearFlags = 4;
					this.g3dCamera.Render();
					figure.SetRenderEnable(false);
				}
				else
				{
					this.g3dCamera.targetTexture = this.g3dRenderTexture;
					GL.LoadPixelMatrix(0f, (float)(this.g3dRenderTexture.width / 2), (float)(this.g3dRenderTexture.height / 2), 0f);
					Vector3 position3 = this.viewPort.Matrix.inverse.GetPosition();
					rootObject.transform.localScale = Vector3.Scale(Figure.ConvertVector, vector);
					rootObject.transform.SetPositionAndRotation(position, quaternion);
					this.g3dCamera.transform.SetPositionAndRotation(position3, this.viewPort.Matrix.inverse.rotation);
					this.g3dCamera.clearFlags = 4;
					if (this.ambientLight != null)
					{
						figure.Renderers[0].material.SetColor("_Ambient", StGraphics.CalcColor(this.ambientLight.GetColor()));
					}
					if (immidiate)
					{
						figure.SetRenderEnable(true);
						this.g3dCamera.Render();
						figure.SetRenderEnable(false);
					}
					else
					{
						this.waitRenderFigure.Add(figure);
						this.perspectiveFov = this.g3dCamera.fieldOfView;
						this.perspectiveRect = this.g3dCamera.rect;
					}
				}
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
			finally
			{
				GL.PopMatrix();
			}
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x00125C70 File Offset: 0x00123E70
		public void EnableLight(bool b)
		{
			this.isEnableLight = b;
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x00125C79 File Offset: 0x00123E79
		public void EnableSemiTransparent(bool b)
		{
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x00125C7B File Offset: 0x00123E7B
		public void EnableSphereMap(bool b)
		{
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x00125C7D File Offset: 0x00123E7D
		public void EnableToonShader(bool b)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x00125C84 File Offset: 0x00123E84
		public void ExecuteCommandList(int[] commandlist)
		{
			if (commandlist.Length == 0)
			{
				return;
			}
			int num = -2130706432;
			int num2 = 0;
			PrimitiveArray primitiveArray = null;
			int num3 = 0;
			while (num != -2147483648)
			{
				num = commandlist[num2++];
				int num4 = (int)((ulong)(-16777216) & (ulong)((long)num));
				if (num != -33554431)
				{
					if (num4 == -2130706432)
					{
						int num5 = num & 255;
						num2 += num5;
						continue;
					}
					if (num4 == -2080374784)
					{
						this.SetClipRect3D(commandlist[num2++], commandlist[num2++], commandlist[num2++], commandlist[num2++]);
					}
					else if (num4 == -1845493760)
					{
						this.SetPerspective(commandlist[num2++], commandlist[num2++], commandlist[num2++]);
					}
					else if (num4 == -1828716544)
					{
						this.SetPerspective(commandlist[num2++], commandlist[num2++], commandlist[num2++], commandlist[num2++]);
					}
					else if (num4 == -2063597568)
					{
						this.SetScreenCenter(commandlist[num2++], commandlist[num2++]);
					}
					else if (num4 == -1879048192)
					{
						this.SetScreenScale(commandlist[num2++], commandlist[num2++]);
					}
					else if (num4 == -1862270976)
					{
						this.SetScreenView(commandlist[num2++], commandlist[num2++]);
					}
					else if (num4 == -2030043136)
					{
						this.SetViewTrans(num & 255);
					}
					else if (num4 == -1610612736)
					{
						this.SetAmbientLight(commandlist[num2++]);
					}
					else if (num4 == -1593835520)
					{
						Vector3D vector3D = new Vector3D(commandlist[num2++], commandlist[num2++], commandlist[num2++]);
						this.SetDirectionLight(vector3D, commandlist[num2++]);
					}
					else if (num4 == -2046820352)
					{
						int num6 = num & 255;
						this.SetPrimitiveTexture(num6);
					}
					else if (num4 == 50331648)
					{
						int num7 = (num >> 16) & 255;
						int num8 = num & 255;
						PrimitiveArray primitiveArray2 = new PrimitiveArray(3, num8, num7);
						int[] vertexArray = primitiveArray2.GetVertexArray();
						int[] normalArray = primitiveArray2.GetNormalArray();
						int[] colorArray = primitiveArray2.GetColorArray();
						int[] textureCoordArray = primitiveArray2.GetTextureCoordArray();
						for (int i = 0; i < vertexArray.Length; i++)
						{
							vertexArray[i] = commandlist[num2++];
						}
						for (int j = 0; j < normalArray.Length; j++)
						{
							normalArray[j] = commandlist[num2++];
						}
						for (int k = 0; k < colorArray.Length; k++)
						{
							colorArray[k] = commandlist[num2++];
						}
						for (int l = 0; l < textureCoordArray.Length; l++)
						{
							textureCoordArray[l] = commandlist[num2++];
						}
						this.DrawPrimitives(primitiveArray2, num8, null);
					}
					else if (num4 == 67108864)
					{
						int num9 = (num >> 16) & 255;
						int num10 = num & 65535;
						if (primitiveArray == null || num3 != num9)
						{
							primitiveArray = new PrimitiveArray(4, num10, num9);
							num3 = num9;
						}
						int[] vertexArray2 = primitiveArray.GetVertexArray();
						int[] normalArray2 = primitiveArray.GetNormalArray();
						int[] colorArray2 = primitiveArray.GetColorArray();
						int[] textureCoordArray2 = primitiveArray.GetTextureCoordArray();
						for (int m = 0; m < vertexArray2.Length; m++)
						{
							vertexArray2[m] = commandlist[num2++];
						}
						for (int n = 0; n < normalArray2.Length; n++)
						{
							normalArray2[n] = commandlist[num2++];
						}
						for (int num11 = 0; num11 < colorArray2.Length; num11++)
						{
							colorArray2[num11] = commandlist[num2++];
						}
						for (int num12 = 0; num12 < textureCoordArray2.Length; num12++)
						{
							textureCoordArray2[num12] = commandlist[num2++];
						}
						this.DrawPrimitives(primitiveArray, num10, null);
					}
					else if (num4 == 83886080)
					{
						int num13 = (num >> 16) & 255;
						int num14 = num & 65535;
						PrimitiveArray primitiveArray3 = new PrimitiveArray(5, num14, num13);
						int[] vertexArray3 = primitiveArray3.GetVertexArray();
						int[] pointSpriteArray = primitiveArray3.GetPointSpriteArray();
						for (int num15 = 0; num15 < vertexArray3.Length; num15++)
						{
							vertexArray3[num15] = commandlist[num2++];
						}
						for (int num16 = 0; num16 < pointSpriteArray.Length; num16++)
						{
							pointSpriteArray[num16] = commandlist[num2++];
						}
						this.DrawPrimitives(primitiveArray3, num14, null);
					}
					else if (num4 == -2113929216)
					{
						this.Flush();
					}
				}
				if (num2 > commandlist.Length)
				{
					break;
				}
			}
			if (primitiveArray != null)
			{
			}
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x001260D0 File Offset: 0x001242D0
		private void CheckNeed2DFlush()
		{
			if (!this.isDrawing3D)
			{
				this.ReverseFlush();
				this.isDrawing3D = true;
			}
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x001260E7 File Offset: 0x001242E7
		public void StartRendering()
		{
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x001260EC File Offset: 0x001242EC
		public void Clear3DBuffer()
		{
			RenderTexture active = RenderTexture.active;
			if (this.g3dRenderTexture != null)
			{
				RenderTexture.active = this.g3dRenderTexture;
				GL.Clear(true, true, Color.clear, 1f);
			}
			if (this.figureTexture != null)
			{
				RenderTexture.active = this.figureTexture;
				GL.Clear(true, true, Color.clear, 1f);
			}
			RenderTexture.active = active;
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x00126158 File Offset: 0x00124358
		public void Flush()
		{
			if (this.primitivesCommandList.Count > 0)
			{
				this.primitivesCommandList.Add(int.MinValue);
				this.ExecuteCommandList(this.primitivesCommandList.ToArray());
				this.primitivesCommandList.Clear();
			}
			GL.Flush();
			this.DebugCopy();
			this.FlushImpl();
			this.Clear3DBuffer();
			this.isDrawing3D = false;
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x001261C0 File Offset: 0x001243C0
		private void FlushImpl()
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = this.renderTexture;
			float num = this.clipRect3D.x * (float)SingletonBehaviour<StDisplay>.Instance.Magnification;
			float num2 = this.clipRect3D.y * (float)SingletonBehaviour<StDisplay>.Instance.Magnification;
			float num3 = (float)(this.g3dRenderTexture.width / 2 - this.renderTexture.width / 2) + num;
			float num4 = (float)(this.g3dRenderTexture.height / 2 - this.renderTexture.height / 2) + num2;
			this.DrawImageImpl(this.g3dRenderTexture, num, num2, num3, num4, this.clipRect3D.width, this.clipRect3D.height, 1f, false);
			RenderTexture.active = active;
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0012627C File Offset: 0x0012447C
		private void ReverseFlush()
		{
			this.Clear3DBuffer();
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = this.g3dRenderTexture;
			float num = (float)(this.g3dRenderTexture.width / 2 - this.renderTexture.width / 2);
			float num2 = (float)(this.g3dRenderTexture.height / 2 - this.renderTexture.height / 2);
			this.DrawImageImpl(this.renderTexture, num, num2, 0f, 0f, (float)this.renderTexture.width, (float)this.renderTexture.height, 1f, false);
			RenderTexture.active = active;
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x00126314 File Offset: 0x00124514
		private void DebugCopy()
		{
			Graphics.Blit(this.g3dRenderTexture, this.g3dDebugTexture);
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x00126328 File Offset: 0x00124528
		public void DrawPrimitives(PrimitiveArray primitives, int attr, StTransform trans = null)
		{
			if (primitives == null)
			{
				return;
			}
			if (this.g3dRenderTexture == null)
			{
				return;
			}
			if (trans == null)
			{
				trans = new StTransform();
			}
			this.g3dCamera.targetTexture = this.g3dRenderTexture;
			this.CheckNeed2DFlush();
			if (this.primitiveTextureArray == null)
			{
				if (this.blankTexture == null)
				{
					this.blankTexture = new StTexture(this.planeTextureBytes, false);
				}
				this.SetPrimitiveTextureArray(this.blankTexture);
				this.SetPrimitiveTexture(0);
			}
			StTexture stTexture = ((primitives.Texture != null) ? primitives.Texture : this.primitiveTextureArray[this.primitiveTexture]);
			Material material = stTexture.Material;
			if (primitives.GetTextureCoordArray().Length == 0 && primitives.GetType() != 5)
			{
				if (this.blankTexture == null)
				{
					this.blankTexture = new StTexture(this.planeTextureBytes, false);
				}
				stTexture = this.blankTexture;
				material = SingletonBehaviour<StScreenManager>.Instance.NonTexture3DMaterial;
			}
			try
			{
				this.CheckMaterialSetting(primitives, material, attr, true);
				Matrix4x4 matrix4x = (this.g3dCamera.orthographic ? Matrix4x4.zero : this.projectionMatrix);
				RenderTexture.active = this.g3dRenderTexture;
				primitives.CreateMesh(stTexture, this.viewPort.Matrix, matrix4x, attr, this.center, trans);
				RenderTexture.active = this.renderTexture;
				primitives.SetRenderEnable(false);
			}
			catch (Exception ex)
			{
				string text = "Exception:";
				Exception ex2 = ex;
				Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x00126494 File Offset: 0x00124694
		public bool CheckMaterialSetting(PrimitiveArray primitives, Material material, int attr, bool applyValue)
		{
			int num = 0;
			Color color;
			if ((primitives.GetParam() & 1024) != 0)
			{
				color = StGraphics.CalcColor(primitives.GetColorArray()[0]);
				color.a = 1f;
			}
			else
			{
				color..ctor(1f, 1f, 1f, 1f);
			}
			if ((attr & 96) == 96)
			{
				color.a = (color.r + color.g + color.b) / 3f;
				num += this.CheckMaterialSettingFloat(material, "_BlendOp", 2f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendSrc", 3f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendDst", 2f, applyValue);
			}
			else if ((attr & 32) != 0 || primitives.GetBlendMode() == 32)
			{
				if (primitives.GetBlendMode() == 32)
				{
					color.a = primitives.GetTransparency() / 100f;
				}
				else
				{
					color.a = 0.76f;
				}
				num += this.CheckMaterialSettingFloat(material, "_Alpha", color.a, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendOp", 0f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendSrc", 5f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendDst", 10f, applyValue);
			}
			else if (primitives.GetBlendMode() == 64 || (attr & 64) == 64)
			{
				color.a = 0.66f;
				num += this.CheckMaterialSettingFloat(material, "_Alpha", color.a, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendOp", 0f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendSrc", 1f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendDst", 1f, applyValue);
			}
			else
			{
				color.a = 1f;
				num += this.CheckMaterialSettingFloat(material, "_Alpha", color.a, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendOp", 0f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendSrc", 5f, applyValue);
				num += this.CheckMaterialSettingFloat(material, "_BlendDst", 10f, applyValue);
			}
			if ((attr & 1) != 0)
			{
				float num2 = (float)this.ambientIntensity / 4096f;
				Color color2;
				color2..ctor(1f * num2, 1f * num2, 1f * num2);
				num += this.CheckMaterialSettingColor(material, "_Ambient", color2, applyValue);
			}
			else
			{
				num += this.CheckMaterialSettingColor(material, "_Ambient", new Color(1f, 1f, 1f), applyValue);
			}
			return num > 0;
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x00126741 File Offset: 0x00124941
		public int CheckMaterialSettingFloat(Material mat, string key, float value, bool isApply)
		{
			if (!mat.HasProperty(key))
			{
				return 0;
			}
			if (mat.GetFloat(key) != value)
			{
				if (isApply)
				{
					mat.SetFloat(key, value);
				}
				return 1;
			}
			return 0;
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x00126768 File Offset: 0x00124968
		public int CheckMaterialSettingColor(Material mat, string key, Color value, bool isApply)
		{
			if (!mat.HasProperty(key))
			{
				return 0;
			}
			if (!mat.GetColor(key).Equals(value))
			{
				if (isApply)
				{
					mat.SetColor(key, value);
				}
				return 1;
			}
			return 0;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x001267A4 File Offset: 0x001249A4
		public void RenderPerspective()
		{
			foreach (Figure figure in this.waitRenderFigure)
			{
				figure.SetRenderEnable(true);
			}
			GL.PushMatrix();
			GL.LoadPixelMatrix(0f, (float)this.g3dRenderTexture.width, (float)this.g3dRenderTexture.height, 0f);
			this.g3dCamera.clearFlags = 4;
			this.g3dCamera.Render();
			GL.End();
			GL.PopMatrix();
			foreach (Figure figure2 in this.waitRenderFigure)
			{
				figure2.SetRenderEnable(false);
			}
			this.waitRenderFigure.Clear();
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x00126890 File Offset: 0x00124A90
		public void RenderFigure(Figure figure)
		{
			this.DrawFigureImpl(figure, null, true);
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0012689B File Offset: 0x00124A9B
		public void RenderPrimitives(PrimitiveArray primitives, int attr, bool isImmediate = false)
		{
			if (isImmediate)
			{
				this.DrawPrimitives(primitives, attr, null);
				return;
			}
			this.AddRenderPrimitives(primitives, attr);
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x001268B2 File Offset: 0x00124AB2
		public void RenderPrimitives(PrimitiveArray primitives, int attr, StTransform trans)
		{
			primitives.SetOffset(0);
			primitives.SetLength(-1);
			this.DrawPrimitives(primitives, attr, trans);
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x001268CB File Offset: 0x00124ACB
		public void RenderPrimitives(PrimitiveArray primitives, int offset, int length, int attr)
		{
			primitives.SetOffset(offset);
			primitives.SetLength(length);
			this.DrawPrimitives(primitives, attr, null);
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x001268E8 File Offset: 0x00124AE8
		private void AddRenderPrimitives(PrimitiveArray primitives, int attr)
		{
			int num = (new int[] { 0, 16777216, 33554432, 50331648, 67108864, 83886080 })[primitives.GetType()];
			num |= (primitives.Size() & 255) << 16;
			num |= primitives.GetParam();
			num |= attr;
			this.primitivesCommandList.Add(num);
			foreach (int num2 in primitives.GetVertexArray())
			{
				this.primitivesCommandList.Add(num2);
			}
			foreach (int num3 in primitives.GetNormalArray())
			{
				this.primitivesCommandList.Add(num3);
			}
			foreach (int num4 in primitives.GetColorArray())
			{
				this.primitivesCommandList.Add(num4);
			}
			foreach (int num5 in primitives.GetTextureCoordArray())
			{
				this.primitivesCommandList.Add(num5);
			}
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x001269D4 File Offset: 0x00124BD4
		public void SetClipRect3D(int x, int y, int width, int height)
		{
			Debug.Log(string.Format("Clip Rect 3D x:{0} y:{1} width:{2} height:{3}", new object[] { x, y, width, height }));
			this.clipRect3D = new Rect((float)x, (float)y, (float)(width * SingletonBehaviour<StDisplay>.Instance.Magnification), (float)(height * SingletonBehaviour<StDisplay>.Instance.Magnification));
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x00126A45 File Offset: 0x00124C45
		public void SetDirectionLight(Vector3D direction, int intensity)
		{
			this.g3dLight.transform.localRotation = new Quaternion(-direction.GetUnityVector().x, direction.GetUnityVector().y, direction.GetUnityVector().z, 0f);
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x00126A84 File Offset: 0x00124C84
		public void SetPerspective(int zNear, int zFar, int angle)
		{
			float num = (float)angle / 4096f * 360f;
			this.SetPerspectiveImpl((float)zNear, (float)zFar, num);
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x00126AAC File Offset: 0x00124CAC
		private void SetPerspectiveImpl(float near, float far, float angle)
		{
			float num = (float)SingletonBehaviour<StDisplay>.Instance.Magnification;
			this.g3dCamera.orthographic = false;
			this.g3dCamera.fieldOfView = angle * 1.8f;
			this.g3dCamera.nearClipPlane = near;
			this.g3dCamera.farClipPlane = far;
			float num2 = (float)this.g3dRenderTexture.width / num / ((float)this.g3dRenderTexture.height / num);
			float num3 = near * Mathf.Tan(angle * 0.017453292f);
			this.projectionMatrix = Matrix4x4.Perspective(angle * 1.8f * num, num2, near, far);
			this.projectionMatrix.m22 = -this.projectionMatrix.m22;
			this.projectionMatrix.m32 = -this.projectionMatrix.m32;
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x00126B6E File Offset: 0x00124D6E
		public void SetPerspective(int zNear, int zFar, int width, int height)
		{
			Debug.Log("SetPerspective Width:" + width.ToString() + " Height:" + height.ToString());
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x00126B92 File Offset: 0x00124D92
		public void SetPrimitiveTexture(int index)
		{
			if (this.primitiveTextureArray.Length <= index || index < 0)
			{
				string text = "Illegal Primitive Texture Index:";
				StTexture[] array = this.primitiveTextureArray;
				throw new IndexOutOfRangeException(text + ((array != null) ? array.ToString() : null));
			}
			this.primitiveTexture = index;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x00126BCC File Offset: 0x00124DCC
		public void SetPrimitiveTextureArray(StTexture texture)
		{
			this.primitiveTextureArray = new StTexture[1];
			this.primitiveTextureArray[0] = texture;
			this.primitiveTexture = 0;
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x00126BEA File Offset: 0x00124DEA
		public void SetPrimitiveTextureArray(StTexture[] textures)
		{
			this.primitiveTextureArray = textures;
			this.primitiveTexture = 0;
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x00126BFC File Offset: 0x00124DFC
		public void SetScreenCenter(int cx, int cy)
		{
			if (this.center.x != (float)(cx * SingletonBehaviour<StDisplay>.Instance.Magnification) || this.center.y != (float)(cy * SingletonBehaviour<StDisplay>.Instance.Magnification))
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = this.figureTexture;
				GL.Clear(true, true, Color.clear);
				RenderTexture.active = active;
			}
			this.center.x = (float)(cx * SingletonBehaviour<StDisplay>.Instance.Magnification);
			this.center.y = (float)(cy * SingletonBehaviour<StDisplay>.Instance.Magnification);
			this.figureCenter.x = -0.5f + this.center.x / (float)(this.g3dRenderTexture.width / 2);
			this.figureCenter.y = 0.5f - this.center.y / (float)(this.g3dRenderTexture.height / 2);
			float num = ((float)(this.g3dRenderTexture.width / 4) + this.center.x) / (float)this.g3dRenderTexture.width;
			float num2 = ((float)(this.g3dRenderTexture.height / 4) + ((float)this.renderTexture.height - this.center.y)) / (float)this.g3dRenderTexture.height;
			this.g3dCamera.rect = new Rect(0f, 0f, 1f, 1f);
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x00126D68 File Offset: 0x00124F68
		public void SetScreenScale(int sx, int sy)
		{
			this.g3dCamera.orthographic = true;
			Vector3D vector3D = new Vector3D(sx / SingletonBehaviour<StDisplay>.Instance.Magnification, sy / SingletonBehaviour<StDisplay>.Instance.Magnification, 0);
			this.scale.x = vector3D.GetUnityVector().x;
			this.scale.y = vector3D.GetUnityVector().y;
			Vector2 vector;
			vector..ctor((float)(this.g3dRenderTexture.width / 4), (float)(this.g3dRenderTexture.height / 4));
			this.g3dCamera.orthographicSize = vector.magnitude * this.scale.magnitude;
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x00126E10 File Offset: 0x00125010
		public void SetScreenView(int width, int height)
		{
			this.g3dCamera.orthographic = true;
			Vector2 vector;
			vector..ctor((float)width / 2f, (float)height / 2f);
			this.g3dCamera.orthographicSize = vector.magnitude * this.scale.magnitude * Mathf.Sqrt((float)SingletonBehaviour<StDisplay>.Instance.Magnification);
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x00126E6F File Offset: 0x0012506F
		public void SetSphereTexture(StTexture texture)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x00126E76 File Offset: 0x00125076
		public void SetToonParam(int threshold, int high, int low)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x00126E80 File Offset: 0x00125080
		public void SetViewTrans(int index)
		{
			if (index < 0 || index > this.viewPortList.Length)
			{
				throw new IndexOutOfRangeException("ViewPort List Length:" + this.viewPortList.Length.ToString());
			}
			int num = this.currentIndex;
			this.currentIndex = index;
			this.viewPort = this.viewPortList[index];
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x00126EDA File Offset: 0x001250DA
		public void SetViewTrans(AffineTrans trans)
		{
			this.viewPort = trans.CreateRightTransform();
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x00126EE8 File Offset: 0x001250E8
		public static bool CheckInnerPolygon(Vector3[] points, Vector3 target, Vector3 normal)
		{
			Quaternion quaternion = Quaternion.FromToRotation(normal, -Vector3.forward);
			Vector3[] array = new Vector3[points.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = quaternion * points[i];
			}
			target = quaternion * target;
			int num = 0;
			for (int j = 0; j < array.Length; j++)
			{
				int num2 = j;
				int num3 = (j + 1) % array.Length;
				if (array[num2].y <= target.y && array[num3].y > target.y)
				{
					float num4 = (target.y - array[num2].y) / (array[num3].y - array[num2].y);
					if (target.x < array[num2].x + num4 * (array[num3].x - array[num2].x))
					{
						num++;
					}
				}
				else if (array[num2].y > target.y && array[num3].y <= target.y)
				{
					float num4 = (target.y - array[num2].y) / (array[num3].y - array[num2].y);
					if (target.x < array[num2].x + num4 * (array[num3].x - array[num2].x))
					{
						num--;
					}
				}
			}
			return num != 0;
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x001270A1 File Offset: 0x001252A1
		void StGraphics3D.FlushBuffer()
		{
			this.Flush();
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x001270A9 File Offset: 0x001252A9
		void StGraphics3D.SetViewTrans(AffineTrans at)
		{
			this.viewPort = at.CreateLeftTransform();
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x001270B8 File Offset: 0x001252B8
		void StGraphics3D.SetViewTransArray(AffineTrans[] ats)
		{
			this.viewPortList = new AffineTrans[ats.Length];
			for (int i = 0; i < this.viewPortList.Length; i++)
			{
				this.viewPortList[i] = ats[i].CreateLeftTransform();
			}
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x001270F6 File Offset: 0x001252F6
		void StGraphics3D.SetClipRectFor3D(int originx, int originy, int width, int height)
		{
			Debug.Log("Set Clip Rect3D Width:" + width.ToString() + " Height:" + height.ToString());
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0012711C File Offset: 0x0012531C
		void StGraphics3D.RenderObject3D(DrawableObject3D obj, StTransform transform)
		{
			if (obj is Primitive)
			{
				this.RenderPrimitives((obj as Primitive).PrimitiveData, ((obj as Primitive).blendMode == 32) ? 32 : 0, transform);
			}
			else if (obj is Figure)
			{
				this.DrawFigure((Figure)obj, transform, false);
			}
			else if (obj is StGroup)
			{
				StTransform stTransform = ((transform == null) ? new StTransform() : new StTransform(transform));
				StTransform stTransform2 = new StTransform();
				((StGroup)obj).GetTransform(ref stTransform2);
				if (stTransform2 != null)
				{
					stTransform.Multiply(stTransform2);
				}
				this.RenderGroup(obj as StGroup, stTransform);
			}
			this.RenderPerspective();
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x001271BC File Offset: 0x001253BC
		private void RenderGroup(StGroup group, StTransform transform)
		{
			for (int i = 0; i < group.GetNumElements(); i++)
			{
				Object3D element = group.GetElement(i);
				if (element is Primitive)
				{
					this.RenderPrimitives((element as Primitive).PrimitiveData, ((element as Primitive).blendMode == 32) ? 32 : 0, transform);
				}
				else if (element is Figure)
				{
					StTransform stTransform = ((transform == null) ? new StTransform() : new StTransform(transform));
					this.DrawFigure((Figure)element, stTransform, false);
				}
				else if (element is StGroup)
				{
					StTransform stTransform2 = new StTransform(transform);
					StTransform stTransform3 = new StTransform();
					((StGroup)element).GetTransform(ref stTransform3);
					if (stTransform3 != null)
					{
						stTransform2.Multiply(stTransform3);
					}
					this.RenderGroup(element as StGroup, stTransform2);
				}
			}
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x00127280 File Offset: 0x00125480
		public void ResetLights()
		{
			foreach (Light light in this.lights)
			{
				Object.Destroy(light.gameObject);
			}
			this.lights.Clear();
			this.ambientLight = null;
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x001272E8 File Offset: 0x001254E8
		public void AddLight(StLight light, StTransform transform)
		{
			if (light.UnityLight == null && this.lights.Count < 4)
			{
				if (light.GetMode() == 128)
				{
					this.ambientLight = light;
					return;
				}
				if (light.GetMode() == 129 && this.lights.Count != 0)
				{
					GameObject gameObject = new GameObject("light");
					Light light2 = gameObject.AddComponent<Light>();
					gameObject.transform.rotation = Quaternion.AngleAxis(0f, light.GetVector().GetUnityVector());
					light2.type = 1;
					light.UnityLight = gameObject;
					this.lights.Add(light2);
				}
			}
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0012738F File Offset: 0x0012558F
		public void SetAmbientLight(int intensity)
		{
			this.ambientIntensity = intensity;
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x00127398 File Offset: 0x00125598
		public void SetPerspectiveView(float zNear, float zFar, float angle)
		{
			this.SetPerspectiveImpl(zNear, zFar, angle);
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x001273A3 File Offset: 0x001255A3
		public void SetPerspectiveView(float zNear, float zFar, int width, int height)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x001273AA File Offset: 0x001255AA
		public void SetParallelView(int width, int height)
		{
			this.g3dCamera.orthographic = true;
			this.g3dCamera.orthographicSize = (float)height;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x001273C5 File Offset: 0x001255C5
		public void SetTransform(StTransform trans)
		{
			if (this.viewPort == null)
			{
				this.viewPort = new AffineTrans();
			}
			this.viewPort.SetTransform(new StTransform(trans));
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x001273EB File Offset: 0x001255EB
		public void SetCameraPosition(StTransform t)
		{
		}

		// Token: 0x04000B67 RID: 2919
		public const int FLIP_NONE = 0;

		// Token: 0x04000B68 RID: 2920
		public const int FLIP_HORIZONTAL = 1;

		// Token: 0x04000B69 RID: 2921
		public const int FLIP_VERTICAL = 2;

		// Token: 0x04000B6A RID: 2922
		public const int FLIP_ROTATE = 3;

		// Token: 0x04000B6B RID: 2923
		public const int FLIP_ROTATE_LEFT = 4;

		// Token: 0x04000B6C RID: 2924
		public const int FLIP_ROTATE_RIGHT = 5;

		// Token: 0x04000B6D RID: 2925
		public const int FLIP_ROTATE_RIGHT_HORIZONTAL = 6;

		// Token: 0x04000B6E RID: 2926
		public const int FLIP_ROTATE_RIGHT_VERTICAL = 7;

		// Token: 0x04000B6F RID: 2927
		public const int BLACK = 0;

		// Token: 0x04000B70 RID: 2928
		public const int BLUE = 1;

		// Token: 0x04000B71 RID: 2929
		public const int LIME = 2;

		// Token: 0x04000B72 RID: 2930
		public const int AQUA = 3;

		// Token: 0x04000B73 RID: 2931
		public const int RED = 4;

		// Token: 0x04000B74 RID: 2932
		public const int FUCHSIA = 5;

		// Token: 0x04000B75 RID: 2933
		public const int YELLOW = 6;

		// Token: 0x04000B76 RID: 2934
		public const int WHITE = 7;

		// Token: 0x04000B77 RID: 2935
		public const int GRAY = 8;

		// Token: 0x04000B78 RID: 2936
		public const int NAVY = 9;

		// Token: 0x04000B79 RID: 2937
		public const int GREEN = 10;

		// Token: 0x04000B7A RID: 2938
		public const int TEAL = 11;

		// Token: 0x04000B7B RID: 2939
		public const int MAROON = 12;

		// Token: 0x04000B7C RID: 2940
		public const int PURPLE = 13;

		// Token: 0x04000B7D RID: 2941
		public const int OLIVE = 14;

		// Token: 0x04000B7E RID: 2942
		public const int SILVER = 15;

		// Token: 0x04000B7F RID: 2943
		protected static int[] DEFAULT_COLORS = new int[]
		{
			-16777216, -16776961, -16711936, -16711681, -65536, -65281, -256, -1, -8355712, -16777088,
			-16744448, -16744320, -8388608, -8388480, -8355840, -4144960
		};

		// Token: 0x04000B80 RID: 2944
		private bool isClipping;

		// Token: 0x04000B81 RID: 2945
		[SerializeField]
		private Texture2D baseTexture;

		// Token: 0x04000B82 RID: 2946
		[SerializeField]
		protected RenderTexture renderTexture;

		// Token: 0x04000B83 RID: 2947
		[SerializeField]
		protected StFont currentFont;

		// Token: 0x04000B84 RID: 2948
		[SerializeField]
		private Color currentColor = Color.white;

		// Token: 0x04000B85 RID: 2949
		[SerializeField]
		private Vector2 drawOrigin = Vector2.zero;

		// Token: 0x04000B86 RID: 2950
		[SerializeField]
		private int flipMode;

		// Token: 0x04000B87 RID: 2951
		private int renderMode;

		// Token: 0x04000B88 RID: 2952
		private Color backgroundColor = Color.white;

		// Token: 0x04000B89 RID: 2953
		private Rect clipRect;

		// Token: 0x04000B8A RID: 2954
		private RenderTexture copyTexture;

		// Token: 0x04000B8B RID: 2955
		private RenderTexture workTexture;

		// Token: 0x04000B8C RID: 2956
		private RenderTexture bgWorkTexture;

		// Token: 0x04000B8D RID: 2957
		private RenderTexture gomiTexture;

		// Token: 0x04000B8E RID: 2958
		private Texture2D workGetPixelTexture;

		// Token: 0x04000B8F RID: 2959
		private readonly sbyte[] planeTextureBytes = new sbyte[]
		{
			-119, 80, 78, 71, 13, 10, 26, 10, 0, 0,
			0, 13, 73, 72, 68, 82, 0, 0, 0, 1,
			0, 0, 0, 1, 8, 2, 0, 0, 0, -112,
			119, 83, -34, 0, 0, 0, 9, 112, 72, 89,
			115, 0, 0, 11, 19, 0, 0, 11, 19, 1,
			0, -102, -100, 24, 0, 0, 0, 7, 116, 73,
			77, 69, 7, -28, 10, 30, 7, 52, 36, 57,
			17, -54, -102, 0, 0, 0, 29, 105, 84, 88,
			116, 67, 111, 109, 109, 101, 110, 116, 0, 0,
			0, 0, 0, 67, 114, 101, 97, 116, 101, 100,
			32, 119, 105, 116, 104, 32, 71, 73, 77, 80,
			100, 46, 101, 7, 0, 0, 0, 12, 73, 68,
			65, 84, 8, -41, 99, 96, 96, 96, 0, 0,
			0, 4, 0, 1, 39, 52, 39, 10, 0, 0,
			0, 0, 73, 69, 78, 68, -82, 66, 96, -126
		};

		// Token: 0x04000B90 RID: 2960
		private bool disableOnDestroy;

		// Token: 0x04000B91 RID: 2961
		private string[] replaceTarget = new string[]
		{
			'\ue6e2'.ToString(),
			'\ue6e3'.ToString(),
			'\ue6e4'.ToString()
		};

		// Token: 0x04000B92 RID: 2962
		private string[] replaceString = new string[] { "Ｘ", "Ｙ", "Ａ" };

		// Token: 0x04000B93 RID: 2963
		public const int ATTR_BLEND_ADD = 64;

		// Token: 0x04000B94 RID: 2964
		public const int ATTR_BLEND_HALF = 32;

		// Token: 0x04000B95 RID: 2965
		public const int ATTR_BLEND_NORMAL = 0;

		// Token: 0x04000B96 RID: 2966
		public const int ATTR_BLEND_SUB = 96;

		// Token: 0x04000B97 RID: 2967
		public const int ATTR_COLOR_KEY = 16;

		// Token: 0x04000B98 RID: 2968
		public const int ATTR_LIGHT = 1;

		// Token: 0x04000B99 RID: 2969
		public const int ATTR_SPHERE_MAP = 2;

		// Token: 0x04000B9A RID: 2970
		public const int COLOR_NONE = 0;

		// Token: 0x04000B9B RID: 2971
		public const int COLOR_PER_COMMAND = 1024;

		// Token: 0x04000B9C RID: 2972
		public const int COLOR_PER_PRIMITIVE = 1024;

		// Token: 0x04000B9D RID: 2973
		public const int COLOR_PER_FACE = 2048;

		// Token: 0x04000B9E RID: 2974
		public const int COMMAND_AMBIENT_LIGHT = -1610612736;

		// Token: 0x04000B9F RID: 2975
		public const int COMMAND_ATTRIBUTE = -2097152000;

		// Token: 0x04000BA0 RID: 2976
		public const int COMMAND_CLIP_RECT = -2080374784;

		// Token: 0x04000BA1 RID: 2977
		public const int COMMAND_DIRECTION_LIGHT = -1593835520;

		// Token: 0x04000BA2 RID: 2978
		public const int COMMAND_END = -2147483648;

		// Token: 0x04000BA3 RID: 2979
		public const int COMMAND_FLUSH = -2113929216;

		// Token: 0x04000BA4 RID: 2980
		public const int COMMAND_LIST_VERSION_1 = -33554431;

		// Token: 0x04000BA5 RID: 2981
		public const int COMMAND_NOP = -2130706432;

		// Token: 0x04000BA6 RID: 2982
		public const int COMMAND_PERSPECTIVE1 = -1845493760;

		// Token: 0x04000BA7 RID: 2983
		public const int COMMAND_PERSPECTIVE2 = -1828716544;

		// Token: 0x04000BA8 RID: 2984
		public const int COMMAND_RENDER_LINES = 33554432;

		// Token: 0x04000BA9 RID: 2985
		public const int COMMAND_RENDER_POINT_SPRITES = 83886080;

		// Token: 0x04000BAA RID: 2986
		public const int COMMAND_RENDER_POINTS = 16777216;

		// Token: 0x04000BAB RID: 2987
		public const int COMMAND_RENDER_QUADS = 67108864;

		// Token: 0x04000BAC RID: 2988
		public const int COMMAND_RENDER_TRIANGLES = 50331648;

		// Token: 0x04000BAD RID: 2989
		public const int COMMAND_SCREEN_CENTER = -2063597568;

		// Token: 0x04000BAE RID: 2990
		public const int COMMAND_SCREEN_SCALE = -1879048192;

		// Token: 0x04000BAF RID: 2991
		public const int COMMAND_SCREEN_VIEW = -1862270976;

		// Token: 0x04000BB0 RID: 2992
		public const int COMMAND_TEXTURE = -2046820352;

		// Token: 0x04000BB1 RID: 2993
		public const int COMMAND_TOON_PARAM = -1358954496;

		// Token: 0x04000BB2 RID: 2994
		public const int COMMAND_VIEW_TRANS = -2030043136;

		// Token: 0x04000BB3 RID: 2995
		public const int ENV_ATTR_LIGHT = 1;

		// Token: 0x04000BB4 RID: 2996
		public const int ENV_ATTR_SEMI_TRANSPARENT = 8;

		// Token: 0x04000BB5 RID: 2997
		public const int ENV_ATTR_SPHERE_MAP = 2;

		// Token: 0x04000BB6 RID: 2998
		public const int ENV_ATTR_TOON_SHADER = 4;

		// Token: 0x04000BB7 RID: 2999
		public const int NORMAL_NONE = 0;

		// Token: 0x04000BB8 RID: 3000
		public const int NORMAL_PER_FACE = 512;

		// Token: 0x04000BB9 RID: 3001
		public const int NORMAL_PER_VERTEX = 768;

		// Token: 0x04000BBA RID: 3002
		public const int POINT_SPRITE_FLAG_LOCAL_SIZE = 0;

		// Token: 0x04000BBB RID: 3003
		public const int POINT_SPRITE_FLAG_NO_PERSPECTIVE = 2;

		// Token: 0x04000BBC RID: 3004
		public const int POINT_SPRITE_FLAG_PERSPECTIVE = 0;

		// Token: 0x04000BBD RID: 3005
		public const int POINT_SPRITE_FLAG_PIXEL_SIZE = 1;

		// Token: 0x04000BBE RID: 3006
		public const int POINT_SPRITE_PER_COMMAND = 16384;

		// Token: 0x04000BBF RID: 3007
		public const int POINT_SPRITE_PER_VERTEX = 32768;

		// Token: 0x04000BC0 RID: 3008
		public const int PRIMITIVE_LINES = 2;

		// Token: 0x04000BC1 RID: 3009
		public const int PRIMITIVE_POINT_SPRITES = 5;

		// Token: 0x04000BC2 RID: 3010
		public const int PRIMITIVE_POINTS = 1;

		// Token: 0x04000BC3 RID: 3011
		public const int PRIMITIVE_QUADS = 4;

		// Token: 0x04000BC4 RID: 3012
		public const int PRIMITIVE_TRIANGLES = 3;

		// Token: 0x04000BC5 RID: 3013
		public const int TEXTURE_COORD_NONE = 0;

		// Token: 0x04000BC6 RID: 3014
		public const int TEXTURE_COORD_PER_VERTEX = 12288;

		// Token: 0x04000BC7 RID: 3015
		protected GameObject g3dPrefab;

		// Token: 0x04000BC8 RID: 3016
		[SerializeField]
		private RenderTexture g3dRenderTexture;

		// Token: 0x04000BC9 RID: 3017
		[SerializeField]
		private RenderTexture figureTexture;

		// Token: 0x04000BCA RID: 3018
		private Camera g3dCamera;

		// Token: 0x04000BCB RID: 3019
		private float g3dTextureMag;

		// Token: 0x04000BCC RID: 3020
		[SerializeField]
		private RenderTexture g3dDebugTexture;

		// Token: 0x04000BCD RID: 3021
		private StTexture blankTexture;

		// Token: 0x04000BCE RID: 3022
		private Light g3dLight;

		// Token: 0x04000BCF RID: 3023
		private StLight ambientLight;

		// Token: 0x04000BD0 RID: 3024
		private List<Light> lights = new List<Light>();

		// Token: 0x04000BD1 RID: 3025
		private bool isEnableLight;

		// Token: 0x04000BD2 RID: 3026
		private AffineTrans viewPort;

		// Token: 0x04000BD3 RID: 3027
		private AffineTrans[] viewPortList = new AffineTrans[]
		{
			new AffineTrans(),
			new AffineTrans()
		};

		// Token: 0x04000BD4 RID: 3028
		private Matrix4x4 projectionMatrix = Matrix4x4.identity;

		// Token: 0x04000BD5 RID: 3029
		private Vector2 center;

		// Token: 0x04000BD6 RID: 3030
		private Vector2 figureCenter;

		// Token: 0x04000BD7 RID: 3031
		private Vector2 scale = Vector2.one;

		// Token: 0x04000BD8 RID: 3032
		private Vector3 cameraPos;

		// Token: 0x04000BD9 RID: 3033
		private Rect clipRect3D;

		// Token: 0x04000BDA RID: 3034
		private int ambientIntensity = 4096;

		// Token: 0x04000BDB RID: 3035
		private bool isDrawing3D;

		// Token: 0x04000BDC RID: 3036
		private StTexture[] primitiveTextureArray;

		// Token: 0x04000BDD RID: 3037
		private Dictionary<string, Material> changePrimitiveTextureCache = new Dictionary<string, Material>();

		// Token: 0x04000BDE RID: 3038
		private int primitiveTexture;

		// Token: 0x04000BDF RID: 3039
		private List<Figure> waitRenderFigure;

		// Token: 0x04000BE0 RID: 3040
		private float perspectiveFov;

		// Token: 0x04000BE1 RID: 3041
		private Rect perspectiveRect;

		// Token: 0x04000BE2 RID: 3042
		private List<int> primitivesCommandList;

		// Token: 0x04000BE3 RID: 3043
		private bool isLocked;

		// Token: 0x04000BE4 RID: 3044
		private int currentIndex = -1;

		// Token: 0x04000BE5 RID: 3045
		protected float renderModeOpAddSrcAlpha = -1f;
	}
}
