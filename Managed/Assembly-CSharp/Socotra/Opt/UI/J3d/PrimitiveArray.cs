using System;
using System.Collections.Generic;
using Socotra.UI;
using Socotra.Util3d;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Rendering;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x0200010F RID: 271
	public class PrimitiveArray
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600151A RID: 5402 RVA: 0x0012950F File Offset: 0x0012770F
		public StTexture Texture
		{
			get
			{
				return this.customTexture;
			}
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x00129518 File Offset: 0x00127718
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"PrimitiveArray Type:",
				this.type.ToString(),
				" Param:",
				this.param.ToString("X8"),
				" Num:",
				this.primitiveCnt.ToString()
			});
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x00129578 File Offset: 0x00127778
		public static int GetLength(int type, int param, int n)
		{
			int num = 0;
			if (type == 1)
			{
				num += n * 3;
				if ((param & 1024) == 1024)
				{
					num++;
				}
				else if ((param & 2048) == 2048)
				{
					num += n;
				}
			}
			else if (type == 2)
			{
				num += n * 6;
				if ((param & 1024) == 1024)
				{
					num++;
				}
				else if ((param & 2048) == 2048)
				{
					num += n;
				}
			}
			else if (type == 3)
			{
				num += n * 9;
				if ((param & 512) == 512)
				{
					num += n * 3;
				}
				else if ((param & 768) == 768)
				{
					num += n * 9;
				}
				if ((param & 1024) == 1024)
				{
					num++;
				}
				else if ((param & 2048) == 2048)
				{
					num += n;
				}
				if ((param & 12288) == 12288)
				{
					num += n * 8;
				}
			}
			else if (type == 4)
			{
				num += n * 12;
				if ((param & 512) == 512)
				{
					num += n * 3;
				}
				else if ((param & 768) == 768)
				{
					num += n * 12;
				}
				if ((param & 1024) == 1024)
				{
					num++;
				}
				else if ((param & 2048) == 2048)
				{
					num += n;
				}
				if ((param & 12288) == 12288)
				{
					num += n * 8;
				}
			}
			else if (type == 5)
			{
				num += n * 3;
				if ((param & 16384) == 16384)
				{
					num += 8;
				}
				else if ((param & 32768) == 32768)
				{
					num += n * 8;
				}
				else
				{
					num += 8;
				}
			}
			return num;
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x00129720 File Offset: 0x00127920
		public PrimitiveArray(int type, int param, int n)
		{
			this.type = type;
			this.param = param;
			this.primitiveCnt = n;
			if (type == 1)
			{
				this.vertexArray = new int[n * 3];
				this.normalArray = new int[0];
				if ((param & 1024) == 1024 || (param & 1024) == 1024)
				{
					this.colorArray = new int[1];
				}
				else if ((param & 2048) == 2048)
				{
					this.colorArray = new int[n];
				}
				else
				{
					this.colorArray = new int[0];
				}
				this.textureCoordArray = new int[0];
				this.pointSpriteArray = new int[0];
				this.flagArray = new int[0];
				return;
			}
			if (type == 2)
			{
				this.vertexArray = new int[n * 6];
				this.normalArray = new int[0];
				if ((param & 1024) == 1024 || (param & 1024) == 1024)
				{
					this.colorArray = new int[1];
				}
				else if ((param & 2048) == 2048)
				{
					this.colorArray = new int[n];
				}
				else
				{
					this.colorArray = new int[0];
				}
				this.textureCoordArray = new int[0];
				this.pointSpriteArray = new int[0];
				this.flagArray = new int[0];
				return;
			}
			if (type == 3)
			{
				this.vertexArray = new int[n * 9];
				if ((param & 512) == 512)
				{
					this.normalArray = new int[n * 3];
				}
				else if ((param & 768) == 768)
				{
					this.normalArray = new int[n * 9];
				}
				else
				{
					this.normalArray = new int[0];
				}
				if ((param & 1024) == 1024 || (param & 1024) == 1024)
				{
					this.colorArray = new int[1];
				}
				else if ((param & 2048) == 2048)
				{
					this.colorArray = new int[n];
				}
				else
				{
					this.colorArray = new int[1];
				}
				if ((param & 12288) == 12288)
				{
					this.textureCoordArray = new int[n * 8];
				}
				else
				{
					this.textureCoordArray = new int[0];
				}
				this.pointSpriteArray = new int[0];
				this.flagArray = new int[0];
				return;
			}
			if (type == 4)
			{
				this.vertexArray = new int[n * 12];
				if ((param & 768) == 768)
				{
					this.normalArray = new int[n * 12];
				}
				else if ((param & 512) == 512)
				{
					this.normalArray = new int[n * 3];
				}
				else
				{
					this.normalArray = new int[0];
				}
				if ((param & 1024) == 1024 || (param & 1024) == 1024)
				{
					this.colorArray = new int[1];
				}
				else if ((param & 2048) == 2048)
				{
					this.colorArray = new int[n];
				}
				else
				{
					this.colorArray = new int[0];
				}
				if ((param & 12288) == 12288)
				{
					this.textureCoordArray = new int[n * 8];
				}
				else
				{
					this.textureCoordArray = new int[0];
				}
				this.pointSpriteArray = new int[0];
				this.flagArray = new int[0];
				return;
			}
			if (type == 5)
			{
				this.vertexArray = new int[n * 3];
				this.normalArray = new int[0];
				this.colorArray = new int[0];
				this.textureCoordArray = new int[0];
				if ((param & 16384) == 16384)
				{
					this.pointSpriteArray = new int[8];
				}
				else if ((param & 32768) == 32768)
				{
					this.pointSpriteArray = new int[n * 8];
				}
				else
				{
					this.pointSpriteArray = new int[8];
				}
				this.flagArray = new int[n];
			}
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x00129B10 File Offset: 0x00127D10
		~PrimitiveArray()
		{
			this.mMaterial = null;
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x00129B40 File Offset: 0x00127D40
		public void ReleaseMaterial()
		{
			if (this.isNewMaterial)
			{
				Object.Destroy(this.mMaterial);
			}
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00129B55 File Offset: 0x00127D55
		public int[] GetColorArray()
		{
			return this.colorArray;
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x00129B5D File Offset: 0x00127D5D
		public int[] GetNormalArray()
		{
			return this.normalArray;
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x00129B65 File Offset: 0x00127D65
		public int GetParam()
		{
			return this.param;
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00129B6D File Offset: 0x00127D6D
		public int[] GetPointSpriteArray()
		{
			return this.pointSpriteArray;
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x00129B75 File Offset: 0x00127D75
		public int[] GetTextureCoordArray()
		{
			return this.textureCoordArray;
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x00129B7D File Offset: 0x00127D7D
		public new int GetType()
		{
			return this.type;
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x00129B85 File Offset: 0x00127D85
		public int[] GetVertexArray()
		{
			return this.vertexArray;
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x00129B8D File Offset: 0x00127D8D
		public int Size()
		{
			return this.primitiveCnt;
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x00129B95 File Offset: 0x00127D95
		public void SetBlendMode(int blend)
		{
			this.blendMode = blend;
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x00129B9E File Offset: 0x00127D9E
		public int GetBlendMode()
		{
			return this.blendMode;
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x00129BA6 File Offset: 0x00127DA6
		public void SetTransparency(float value)
		{
			this.transparancy = value;
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x00129BAF File Offset: 0x00127DAF
		public float GetTransparency()
		{
			return this.transparancy;
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x00129BB7 File Offset: 0x00127DB7
		public void SetTexture(StTexture texture)
		{
			this.customTexture = texture;
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x00129BC0 File Offset: 0x00127DC0
		public void SetOffset(int offset)
		{
			this.offset = offset;
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x00129BC9 File Offset: 0x00127DC9
		public void SetLength(int length)
		{
			this.length = length;
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x00129BD4 File Offset: 0x00127DD4
		protected void CreateLine()
		{
			this.vertexUnity = new Vector3[this.vertexArray.Length / 3];
			int[] array = new int[this.vertexUnity.Length / 2 * 6];
			for (int i = 0; i < this.vertexUnity.Length; i++)
			{
				int num = i * 3;
				this.vertexUnity[i] = new Vector3((float)this.vertexArray[num], (float)this.vertexArray[num + 1], (float)this.vertexArray[num + 2]);
			}
			(new int[2])[1] = 1;
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = j;
			}
			if (this.colorArray.Length != 0)
			{
				if ((this.param & 1024) == 1024)
				{
					this.colorUnity = new Color[this.vertexArray.Length / 3];
					for (int k = 0; k < this.colorUnity.Length; k++)
					{
						this.colorUnity[k] = StGraphics.CalcColor(this.colorArray[0]);
					}
					return;
				}
				if ((this.param & 1024) == 2048)
				{
					this.colorUnity = new Color[this.vertexArray.Length / 3];
					for (int l = 0; l < this.colorUnity.Length; l++)
					{
						this.colorUnity[l] = StGraphics.CalcColor(this.colorArray[l / 4]);
					}
				}
			}
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x00129D30 File Offset: 0x00127F30
		protected void CreateTriangle(StTexture texture)
		{
			this.vertexUnity = new Vector3[this.vertexArray.Length / 3];
			int[] array = new int[this.vertexUnity.Length];
			for (int i = 0; i < this.vertexUnity.Length; i++)
			{
				int num = i * 3;
				this.vertexUnity[i] = new Vector3((float)this.vertexArray[num], (float)this.vertexArray[num + 1], (float)this.vertexArray[num + 2]);
			}
			int[] array2 = new int[] { 0, 1, 2 };
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = j;
			}
			this.normalUnity = null;
			if (this.normalArray.Length != 0)
			{
				this.normalUnity = new Vector3[this.normalArray.Length / 3];
				for (int k = 0; k < this.normalUnity.Length; k++)
				{
					int num2 = k * 3;
					this.normalUnity[k] = new Vector3((float)this.normalArray[num2] / 4096f, (float)this.normalArray[num2 + 1] / 4096f, (float)this.normalArray[num2 + 2] / 4096f);
				}
			}
			this.colorUnity = null;
			if (this.colorArray.Length != 0)
			{
				if ((this.param & 1024) == 1024)
				{
					this.colorUnity = new Color[this.vertexArray.Length / 3];
					for (int l = 0; l < this.colorUnity.Length; l++)
					{
						this.colorUnity[l] = StGraphics.CalcColor(this.colorArray[0]);
					}
				}
				else if ((this.param & 2048) == 2048)
				{
					this.colorUnity = new Color[this.vertexArray.Length / 3];
					for (int m = 0; m < this.colorUnity.Length; m++)
					{
						this.colorUnity[m] = StGraphics.CalcColor(this.colorArray[m / 4]);
						this.colorUnity[m].a = (((this.param & 32) == 32) ? 0.5f : 1f);
					}
				}
			}
			this.textureCoordUnity = null;
			if (this.textureCoordArray.Length != 0)
			{
				this.textureCoordUnity = new Vector2[this.textureCoordArray.Length / 2];
				for (int n = 0; n < this.textureCoordUnity.Length; n++)
				{
					int num3 = n * 2;
					this.textureCoordUnity[n] = new Vector2((float)this.textureCoordArray[num3] / (float)texture.Texture.width, 1f - (float)this.textureCoordArray[num3 + 1] / (float)texture.Texture.height);
				}
			}
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x00129FD4 File Offset: 0x001281D4
		protected void CreateQuad(StTexture texture, int attr, StTransform trans)
		{
			if (this.vertexUnity == null || this.vertexUnity.Length != this.vertexArray.Length / 3)
			{
				this.vertexUnity = new Vector3[this.vertexArray.Length / 3];
			}
			for (int i = 0; i < this.vertexUnity.Length; i++)
			{
				int num = i * 3;
				this.vertexUnity[i] = trans.GetUnityMatrix().MultiplyPoint(new Vector3((float)(this.vertexArray[num] * SingletonBehaviour<StDisplay>.Instance.Magnification), (float)((240 - this.vertexArray[num + 1]) * SingletonBehaviour<StDisplay>.Instance.Magnification), (float)this.vertexArray[num + 2]));
			}
			if (this.normalArray.Length != 0)
			{
				if (this.normalUnity == null || this.normalUnity.Length != this.normalArray.Length / 3)
				{
					this.normalUnity = new Vector3[this.normalArray.Length / 3];
				}
				for (int j = 0; j < this.normalUnity.Length; j++)
				{
					int num2 = j * 3;
					this.normalUnity[j] = new Vector3((float)this.normalArray[num2] / 4096f, (float)this.normalArray[num2 + 1] / 4096f, (float)this.normalArray[num2 + 2] / 4096f);
				}
			}
			int num3 = attr & 96;
			if (this.colorArray.Length != 0)
			{
				if ((this.param & 1024) == 1024)
				{
					if (this.colorUnity == null || this.colorUnity.Length != this.vertexArray.Length / 3)
					{
						this.colorUnity = new Color[this.vertexArray.Length / 3];
					}
					for (int k = 0; k < this.colorUnity.Length; k++)
					{
						this.colorUnity[k] = StGraphics.CalcColor(this.colorArray[0]);
						float num4 = 1f;
						if (num3 == 32)
						{
							num4 = 0.6f;
						}
						else if (num3 == 64)
						{
							num4 = (this.colorUnity[k].r + this.colorUnity[k].g + this.colorUnity[k].b) / 1.33f;
						}
						else if (num3 == 96)
						{
							num4 = 1f - (this.colorUnity[k].r + this.colorUnity[k].g + this.colorUnity[k].b) / 3f;
						}
						this.colorUnity[k].a = num4;
					}
				}
				else if ((this.param & 2048) == 2048)
				{
					if (this.colorUnity == null || this.colorUnity.Length != this.vertexArray.Length / 3)
					{
						this.colorUnity = new Color[this.vertexArray.Length / 3];
					}
					for (int l = 0; l < this.colorUnity.Length; l++)
					{
						this.colorUnity[l] = StGraphics.CalcColor(this.colorArray[l / 4]);
						float num5 = 1f;
						if (num3 == 32)
						{
							num5 = 0.6f;
						}
						else if (num3 == 64)
						{
							num5 = (this.colorUnity[l].r + this.colorUnity[l].g + this.colorUnity[l].b) / 1.33f;
						}
						else if (num3 == 96)
						{
							num5 = 1f - (this.colorUnity[l].r + this.colorUnity[l].g + this.colorUnity[l].b) / 3f;
						}
						this.colorUnity[l].a = num5;
					}
				}
			}
			else
			{
				if (this.colorUnity == null || this.colorUnity.Length != this.vertexArray.Length / 3)
				{
					this.colorUnity = new Color[this.vertexArray.Length / 3];
				}
				for (int m = 0; m < this.colorUnity.Length; m++)
				{
					this.colorUnity[m] = new Color(1f, 1f, 1f, 1f);
					float num6 = 1f;
					if (num3 == 32)
					{
						num6 = 0.6f;
					}
					else if (num3 == 64)
					{
						num6 = (this.colorUnity[m].r + this.colorUnity[m].g + this.colorUnity[m].b) / 1.33f;
					}
					else if (num3 == 96)
					{
						num6 = 1f - (this.colorUnity[m].r + this.colorUnity[m].g + this.colorUnity[m].b) / 3f;
					}
					this.colorUnity[m].a = num6;
				}
			}
			if (this.textureCoordArray.Length != 0)
			{
				if (this.textureCoordUnity == null || this.textureCoordUnity.Length != this.textureCoordArray.Length / 2)
				{
					this.textureCoordUnity = new Vector2[this.textureCoordArray.Length / 2];
				}
				for (int n = 0; n < this.textureCoordUnity.Length; n++)
				{
					int num7 = n * 2;
					this.textureCoordUnity[n] = new Vector2((float)this.textureCoordArray[num7] / (float)texture.Texture.width, 1f - (float)this.textureCoordArray[num7 + 1] / (float)texture.Texture.height);
				}
			}
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0012A590 File Offset: 0x00128790
		protected void CreatePointSprites(StTexture texture, Matrix4x4 viewPort, Matrix4x4 projection)
		{
			if (this.length < 0)
			{
				this.length = this.primitiveCnt;
			}
			Vector3 zero = Vector3.zero;
			this.vertexUnity = new Vector3[this.length * 4];
			this.textureCoordUnity = new Vector2[this.length * 4];
			int num = 0;
			for (int i = 0; i < this.length; i++)
			{
				int num2 = 0;
				if (this.pointSpriteArray.Length == this.primitiveCnt * 8)
				{
					num2 = (this.offset + i) * 8;
				}
				float num3 = (float)(this.pointSpriteArray[num2] / 2 * SingletonBehaviour<StDisplay>.Instance.Magnification);
				float num4 = (float)(this.pointSpriteArray[num2 + 1] / 2 * SingletonBehaviour<StDisplay>.Instance.Magnification);
				int num5 = (this.pointSpriteArray[num2 + 2] * -360 + 737280) / 4096;
				float num6 = (float)this.pointSpriteArray[num2 + 3] / (float)texture.Texture.width;
				float num7 = 1f - (float)this.pointSpriteArray[num2 + 4] / (float)texture.Texture.height;
				float num8 = (float)this.pointSpriteArray[num2 + 5] / (float)texture.Texture.width;
				float num9 = 1f - (float)this.pointSpriteArray[num2 + 6] / (float)texture.Texture.height;
				int num10 = this.pointSpriteArray[num2 + 7];
				int num11 = i * 3;
				zero..ctor((float)(this.vertexArray[num11] * SingletonBehaviour<StDisplay>.Instance.Magnification), (float)((SingletonBehaviour<StDisplay>.Instance.Height - this.vertexArray[num11 + 1]) * SingletonBehaviour<StDisplay>.Instance.Magnification), (float)this.vertexArray[num11 + 2]);
				if ((num10 & 2) == 2)
				{
					Vector3 vector = viewPort.MultiplyPoint(zero);
					Vector3 vector2;
					vector2..ctor(vector.x - num3, vector.y - num4, vector.z);
					Vector3 vector3;
					vector3..ctor(vector.x + num3, vector.y + num4, vector.z);
					Vector3 vector4 = projection.MultiplyPoint(vector2);
					Vector3 vector5 = projection.MultiplyPoint(vector3);
					float num12 = vector4.x - vector5.x;
					float num13 = vector5.y - vector4.y;
					num4 = -num4 * (num4 / (float)SingletonBehaviour<StDisplay>.Instance.Height / num12);
					num3 = -num3 * (num3 / (float)SingletonBehaviour<StDisplay>.Instance.Width / num13);
				}
				this.flagArray[i] = num10;
				Quaternion quaternion = viewPort.inverse.rotation * Quaternion.Euler(new Vector3(0f, 0f, (float)num5));
				this.vertexUnity[num] = quaternion * new Vector3(num3, -num4, 0f) + zero;
				this.vertexUnity[num + 1] = quaternion * new Vector3(-num3, -num4, 0f) + zero;
				this.vertexUnity[num + 2] = quaternion * new Vector3(-num3, num4, 0f) + zero;
				this.vertexUnity[num + 3] = quaternion * new Vector3(num3, num4, 0f) + zero;
				this.textureCoordUnity[num] = new Vector2(num8, num9);
				this.textureCoordUnity[num + 1] = new Vector2(num6, num9);
				this.textureCoordUnity[num + 2] = new Vector2(num6, num7);
				this.textureCoordUnity[num + 3] = new Vector2(num8, num7);
				num += 4;
			}
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0012A930 File Offset: 0x00128B30
		public Rect GetQuad2D()
		{
			this.vertexUnity = new Vector3[this.vertexArray.Length / 3];
			new int[this.vertexUnity.Length / 4 * 6];
			for (int i = 0; i < this.vertexUnity.Length; i++)
			{
				int num = i * 3;
				this.vertexUnity[i] = new Vector3((float)this.vertexArray[num], (float)this.vertexArray[num + 1], (float)this.vertexArray[num + 2]);
			}
			return new Rect(this.vertexUnity[0], this.vertexUnity[2] - this.vertexUnity[0]);
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0012A9E4 File Offset: 0x00128BE4
		public Rect GetTexcoord2D(StTexture texture)
		{
			if (this.textureCoordArray.Length != 0)
			{
				this.textureCoordUnity = new Vector2[this.textureCoordArray.Length / 2];
				for (int i = 0; i < this.textureCoordUnity.Length; i++)
				{
					int num = i * 2;
					this.textureCoordUnity[i] = new Vector2((float)this.textureCoordArray[num], (float)this.textureCoordArray[num + 1]);
				}
				Vector2 vector = this.textureCoordUnity[2] - this.textureCoordUnity[0];
				return new Rect(new Vector2(this.textureCoordUnity[0].x, this.textureCoordUnity[0].y), new Vector2(vector.x, vector.y));
			}
			return new Rect(0f, 0f, 1f, 1f);
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0012AAC3 File Offset: 0x00128CC3
		public Color GetColor()
		{
			if (this.colorArray == null || this.colorArray.Length == 0)
			{
				return Color.white;
			}
			return StGraphics.CalcColor(this.colorArray[0]);
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06001536 RID: 5430 RVA: 0x0012AAE9 File Offset: 0x00128CE9
		public GameObject RootObject
		{
			get
			{
				return this.rootObject;
			}
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0012AAF1 File Offset: 0x00128CF1
		public Material CreateMaterialIfNeed(Material mat, bool isChanged)
		{
			if (isChanged)
			{
				this.mMaterial = new Material(mat);
			}
			else
			{
				this.mMaterial = mat;
			}
			this.isNewMaterial = isChanged;
			return this.mMaterial;
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0012AB18 File Offset: 0x00128D18
		public void CreateMesh(StTexture texture, Matrix4x4 viewport, Matrix4x4 projection, int attr, Vector2 center, StTransform trans)
		{
			switch (this.type)
			{
			case 2:
				this.CreateLine();
				this.DrawLine(texture, viewport, projection, attr, center);
				break;
			case 3:
				this.CreateTriangle(texture);
				this.DrawGL(4, texture, viewport, projection, attr, center);
				break;
			case 4:
				this.CreateQuad(texture, attr, trans);
				this.DrawQuad(texture, viewport, projection, attr, center);
				break;
			case 5:
				this.CreatePointSprites(texture, viewport, projection);
				this.DrawQuad(texture, viewport, projection, attr, center);
				break;
			}
			this.SetRenderEnable(false);
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0012ABA9 File Offset: 0x00128DA9
		public void DrawQuad(StTexture texture, Matrix4x4 viewport, Matrix4x4 projection, int attr, Vector2 center)
		{
			this.DrawGL(7, texture, viewport, projection, attr, center);
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0012ABB9 File Offset: 0x00128DB9
		public void DrawLine(StTexture texture, Matrix4x4 viewport, Matrix4x4 projection, int attr, Vector2 center)
		{
			this.DrawGL(1, texture, viewport, projection, attr, center);
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0012ABCC File Offset: 0x00128DCC
		protected void DrawGL(int glmode, StTexture texture, Matrix4x4 viewport, Matrix4x4 projection, int attr, Vector2 center)
		{
			int num = attr & 96;
			GL.PushMatrix();
			GL.LoadIdentity();
			GL.MultMatrix(viewport);
			if (projection == Matrix4x4.zero)
			{
				GL.LoadPixelMatrix(0f, (float)RenderTexture.active.width, (float)RenderTexture.active.height, 0f);
				Matrix4x4 matrix4x = default(Matrix4x4);
				matrix4x.SetTRS((center == Vector2.zero) ? new Vector3((float)(RenderTexture.active.width / 4), (float)(RenderTexture.active.height - RenderTexture.active.height / 4), 0f) : center, Quaternion.identity, new Vector3(1f, -1f, 1f));
				GL.MultMatrix(matrix4x);
			}
			else
			{
				GL.LoadProjectionMatrix(projection);
			}
			GL.Begin(glmode);
			BlendOp blendOp = 0;
			BlendMode blendMode = 5;
			BlendMode blendMode2 = 10;
			if (num == 64)
			{
				blendOp = 0;
				blendMode = 1;
				blendMode2 = 1;
			}
			else if (num == 96)
			{
				blendOp = 2;
				blendMode = 3;
				blendMode2 = 2;
			}
			if (this.textureCoordUnity != null)
			{
				texture.Materials[0].SetFloat("_BlendOp", blendOp);
				texture.Materials[0].SetFloat("_BlendSrc", blendMode);
				texture.Materials[0].SetFloat("_BlendDst", blendMode2);
				texture.Materials[0].SetPass(0);
			}
			else
			{
				SingletonBehaviour<StScreenManager>.Instance.NonTexture3DMaterial.SetFloat("_BlendOp", blendOp);
				SingletonBehaviour<StScreenManager>.Instance.NonTexture3DMaterial.SetFloat("_BlendSrc", blendMode);
				SingletonBehaviour<StScreenManager>.Instance.NonTexture3DMaterial.SetFloat("_BlendDst", blendMode2);
				SingletonBehaviour<StScreenManager>.Instance.NonTexture3DMaterial.SetPass(0);
			}
			Color color;
			color..ctor(1f, 1f, 1f, this.transparancy / 100f);
			for (int i = 0; i < this.vertexUnity.Length; i++)
			{
				if (this.colorUnity != null)
				{
					GL.Color(this.colorUnity[i]);
				}
				else
				{
					GL.Color(color);
				}
				if (this.textureCoordUnity != null)
				{
					GL.TexCoord(this.textureCoordUnity[i]);
				}
				GL.Vertex(this.vertexUnity[i]);
			}
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0012AE08 File Offset: 0x00129008
		private Color CalcColor(int color)
		{
			Color color2 = default(Color);
			color2.a = 1f - (float)((color >> 24) & 255) / 255f;
			color2.r = (float)((color >> 16) & 255) / 255f;
			color2.g = (float)((color >> 8) & 255) / 255f;
			color2.b = (float)(color & 255) / 255f;
			return color2;
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0012AE80 File Offset: 0x00129080
		public void SetRenderEnable(bool b)
		{
			if (this.mRenderers == null)
			{
				return;
			}
			if (b)
			{
				for (int i = 0; i < Mathf.Min(this.primitiveCnt, this.mRenderers.Length); i++)
				{
					this.mRenderers[i].enabled = b;
				}
				return;
			}
			Renderer[] array = this.mRenderers;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].enabled = b;
			}
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0012AEE4 File Offset: 0x001290E4
		public void DisposeMesh()
		{
			if (this.mMeshList != null)
			{
				foreach (Mesh mesh in this.mMeshList)
				{
					Object.Destroy(mesh);
				}
				this.mMeshList.Clear();
			}
		}

		// Token: 0x04000C37 RID: 3127
		private GameObject rootObject;

		// Token: 0x04000C38 RID: 3128
		public List<Mesh> mMeshList;

		// Token: 0x04000C39 RID: 3129
		private MeshFilter[] mMeshFilters;

		// Token: 0x04000C3A RID: 3130
		private Material mMaterial;

		// Token: 0x04000C3B RID: 3131
		private bool isNewMaterial;

		// Token: 0x04000C3C RID: 3132
		private Renderer[] mRenderers;

		// Token: 0x04000C3D RID: 3133
		private int type;

		// Token: 0x04000C3E RID: 3134
		private int param;

		// Token: 0x04000C3F RID: 3135
		private int primitiveCnt;

		// Token: 0x04000C40 RID: 3136
		private int blendMode;

		// Token: 0x04000C41 RID: 3137
		private float transparancy = 100f;

		// Token: 0x04000C42 RID: 3138
		private int[] colorArray;

		// Token: 0x04000C43 RID: 3139
		private int[] normalArray;

		// Token: 0x04000C44 RID: 3140
		private int[] pointSpriteArray;

		// Token: 0x04000C45 RID: 3141
		private int[] textureCoordArray;

		// Token: 0x04000C46 RID: 3142
		private int[] vertexArray;

		// Token: 0x04000C47 RID: 3143
		private int[] flagArray;

		// Token: 0x04000C48 RID: 3144
		private Vector3[] vertexUnity;

		// Token: 0x04000C49 RID: 3145
		private Vector3[] normalUnity;

		// Token: 0x04000C4A RID: 3146
		private Color[] colorUnity;

		// Token: 0x04000C4B RID: 3147
		private Vector2[] textureCoordUnity;

		// Token: 0x04000C4C RID: 3148
		private int length;

		// Token: 0x04000C4D RID: 3149
		private int offset;

		// Token: 0x04000C4E RID: 3150
		private StTexture customTexture;

		// Token: 0x04000C4F RID: 3151
		private readonly int[] quad = new int[] { 0, 1, 2, 2, 3, 0 };
	}
}
