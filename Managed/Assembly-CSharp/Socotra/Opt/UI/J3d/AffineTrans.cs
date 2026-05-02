using System;
using System.Text;
using Socotra.Util3d;
using UnityEngine;

namespace Socotra.Opt.UI.J3d
{
	// Token: 0x0200010C RID: 268
	public class AffineTrans
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060014C2 RID: 5314 RVA: 0x00127CCF File Offset: 0x00125ECF
		// (set) Token: 0x060014C3 RID: 5315 RVA: 0x00127CD7 File Offset: 0x00125ED7
		public int m00
		{
			get
			{
				return this.matrix00;
			}
			set
			{
				this.matrix00 = value;
				this.matrix.m00 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060014C4 RID: 5316 RVA: 0x00127CF2 File Offset: 0x00125EF2
		// (set) Token: 0x060014C5 RID: 5317 RVA: 0x00127CFA File Offset: 0x00125EFA
		public int m01
		{
			get
			{
				return this.matrix01;
			}
			set
			{
				this.matrix01 = value;
				this.matrix.m01 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060014C6 RID: 5318 RVA: 0x00127D15 File Offset: 0x00125F15
		// (set) Token: 0x060014C7 RID: 5319 RVA: 0x00127D1D File Offset: 0x00125F1D
		public int m02
		{
			get
			{
				return this.matrix02;
			}
			set
			{
				this.matrix02 = value;
				this.matrix.m02 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x00127D38 File Offset: 0x00125F38
		// (set) Token: 0x060014C9 RID: 5321 RVA: 0x00127D40 File Offset: 0x00125F40
		public int m03
		{
			get
			{
				return this.matrix03;
			}
			set
			{
				this.matrix03 = value;
				this.matrix.m03 = (float)value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060014CA RID: 5322 RVA: 0x00127D56 File Offset: 0x00125F56
		// (set) Token: 0x060014CB RID: 5323 RVA: 0x00127D5E File Offset: 0x00125F5E
		public int m10
		{
			get
			{
				return this.matrix10;
			}
			set
			{
				this.matrix10 = value;
				this.matrix.m10 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060014CC RID: 5324 RVA: 0x00127D79 File Offset: 0x00125F79
		// (set) Token: 0x060014CD RID: 5325 RVA: 0x00127D81 File Offset: 0x00125F81
		public int m11
		{
			get
			{
				return this.matrix11;
			}
			set
			{
				this.matrix11 = value;
				this.matrix.m11 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060014CE RID: 5326 RVA: 0x00127D9C File Offset: 0x00125F9C
		// (set) Token: 0x060014CF RID: 5327 RVA: 0x00127DA4 File Offset: 0x00125FA4
		public int m12
		{
			get
			{
				return this.matrix12;
			}
			set
			{
				this.matrix12 = value;
				this.matrix.m12 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060014D0 RID: 5328 RVA: 0x00127DBF File Offset: 0x00125FBF
		// (set) Token: 0x060014D1 RID: 5329 RVA: 0x00127DC7 File Offset: 0x00125FC7
		public int m13
		{
			get
			{
				return this.matrix13;
			}
			set
			{
				this.matrix13 = value;
				this.matrix.m13 = (float)value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060014D2 RID: 5330 RVA: 0x00127DDD File Offset: 0x00125FDD
		// (set) Token: 0x060014D3 RID: 5331 RVA: 0x00127DE5 File Offset: 0x00125FE5
		public int m20
		{
			get
			{
				return this.matrix20;
			}
			set
			{
				this.matrix20 = value;
				this.matrix.m20 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060014D4 RID: 5332 RVA: 0x00127E00 File Offset: 0x00126000
		// (set) Token: 0x060014D5 RID: 5333 RVA: 0x00127E08 File Offset: 0x00126008
		public int m21
		{
			get
			{
				return this.matrix21;
			}
			set
			{
				this.matrix21 = value;
				this.matrix.m21 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060014D6 RID: 5334 RVA: 0x00127E23 File Offset: 0x00126023
		// (set) Token: 0x060014D7 RID: 5335 RVA: 0x00127E2B File Offset: 0x0012602B
		public int m22
		{
			get
			{
				return this.matrix22;
			}
			set
			{
				this.matrix22 = value;
				this.matrix.m22 = this.FixedToFloat(value);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060014D8 RID: 5336 RVA: 0x00127E46 File Offset: 0x00126046
		// (set) Token: 0x060014D9 RID: 5337 RVA: 0x00127E4E File Offset: 0x0012604E
		public int m23
		{
			get
			{
				return this.matrix23;
			}
			set
			{
				this.matrix23 = value;
				this.matrix.m23 = (float)value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060014DA RID: 5338 RVA: 0x00127E64 File Offset: 0x00126064
		// (set) Token: 0x060014DB RID: 5339 RVA: 0x00127E6C File Offset: 0x0012606C
		public Matrix4x4 Matrix
		{
			get
			{
				return this.matrix;
			}
			set
			{
				this.matrix = value;
			}
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00127E75 File Offset: 0x00126075
		public AffineTrans()
		{
			this.matrix = Matrix4x4.identity;
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00127EB0 File Offset: 0x001260B0
		public AffineTrans(int a00, int a01, int a02, int a03, int a10, int a11, int a12, int a13, int a20, int a21, int a22, int a23)
		{
			this.matrix = Matrix4x4.identity;
			this.matrix.m00 = this.FixedToFloat(a00);
			this.matrix.m01 = this.FixedToFloat(a01);
			this.matrix.m02 = this.FixedToFloat(a02);
			this.matrix.m03 = (float)a03;
			this.matrix.m10 = this.FixedToFloat(a10);
			this.matrix.m11 = this.FixedToFloat(a11);
			this.matrix.m12 = this.FixedToFloat(a12);
			this.matrix.m12 = (float)a13;
			this.matrix.m20 = this.FixedToFloat(a20);
			this.matrix.m21 = this.FixedToFloat(a21);
			this.matrix.m22 = this.FixedToFloat(a22);
			this.matrix.m23 = (float)a23;
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x00127FC4 File Offset: 0x001261C4
		public AffineTrans(float a00, float a01, float a02, float a03, float a10, float a11, float a12, float a13, float a20, float a21, float a22, float a23)
		{
			this.matrix = Matrix4x4.identity;
			this.matrix.m00 = a00;
			this.matrix.m01 = a01;
			this.matrix.m02 = a02;
			this.matrix.m03 = a03;
			this.matrix.m10 = a10;
			this.matrix.m11 = a11;
			this.matrix.m12 = a12;
			this.matrix.m12 = a13;
			this.matrix.m20 = a20;
			this.matrix.m21 = a21;
			this.matrix.m22 = a22;
			this.matrix.m23 = a23;
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0012809C File Offset: 0x0012629C
		public void LookAt(Vector3D position, Vector3D look, Vector3D up)
		{
			this.matrix = Matrix4x4.LookAt(new Vector3((float)position.x, (float)position.y, (float)position.z), new Vector3((float)look.x, (float)look.y, (float)look.z), new Vector3((float)up.x, (float)up.y, (float)up.z)).inverse;
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x00128110 File Offset: 0x00126310
		public void Mul(AffineTrans t)
		{
			this.Mul(this, t);
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x0012811C File Offset: 0x0012631C
		public void Mul(AffineTrans t1, AffineTrans t2)
		{
			int num = t1.m00 * t2.m00 + t1.m01 * t2.m10 + t1.m02 * t2.m20 + 2048 >> 12;
			int num2 = t1.m00 * t2.m01 + t1.m01 * t2.m11 + t1.m02 * t2.m21 + 2048 >> 12;
			int num3 = t1.m00 * t2.m02 + t1.m01 * t2.m12 + t1.m02 * t2.m22 + 2048 >> 12;
			int num4 = (t1.m00 * t2.m03 + t1.m01 * t2.m13 + t1.m02 * t2.m23 + 2048 >> 12) + t1.m03;
			int num5 = t1.m10 * t2.m00 + t1.m11 * t2.m10 + t1.m12 * t2.m20 + 2048 >> 12;
			int num6 = t1.m10 * t2.m01 + t1.m11 * t2.m11 + t1.m12 * t2.m21 + 2048 >> 12;
			int num7 = t1.m10 * t2.m02 + t1.m11 * t2.m12 + t1.m12 * t2.m22 + 2048 >> 12;
			int num8 = (t1.m10 * t2.m03 + t1.m11 * t2.m13 + t1.m12 * t2.m23 + 2048 >> 12) + t1.m13;
			int num9 = t1.m20 * t2.m00 + t1.m21 * t2.m10 + t1.m22 * t2.m20 + 2048 >> 12;
			int num10 = t1.m20 * t2.m01 + t1.m21 * t2.m11 + t1.m22 * t2.m21 + 2048 >> 12;
			int num11 = t1.m20 * t2.m02 + t1.m21 * t2.m12 + t1.m22 * t2.m22 + 2048 >> 12;
			int num12 = (t1.m20 * t2.m03 + t1.m21 * t2.m13 + t1.m22 * t2.m23 + 2048 >> 12) + t1.m23;
			this.m00 = num;
			this.m01 = num2;
			this.m02 = num3;
			this.m03 = num4;
			this.m10 = num5;
			this.m11 = num6;
			this.m12 = num7;
			this.m13 = num8;
			this.m20 = num9;
			this.m21 = num10;
			this.m22 = num11;
			this.m23 = num12;
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x00128406 File Offset: 0x00126606
		public void SetColumn(int column, int x, int y, int z)
		{
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x00128408 File Offset: 0x00126608
		public void SetElement(int row, int column, int value)
		{
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0012840C File Offset: 0x0012660C
		public void SetElement(int a00, int a01, int a02, int a03, int a10, int a11, int a12, int a13, int a20, int a21, int a22, int a23)
		{
			this.m00 = a00;
			this.m01 = a01;
			this.m02 = a02;
			this.m03 = a03;
			this.m10 = a10;
			this.m11 = a11;
			this.m12 = a12;
			this.m13 = a13;
			this.m20 = a20;
			this.m21 = a21;
			this.m22 = a22;
			this.m23 = a23;
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x00128476 File Offset: 0x00126676
		public void SetIdentity()
		{
			this.matrix = Matrix4x4.identity;
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0012848C File Offset: 0x0012668C
		public void SetVector(Vector3D v)
		{
			Quaternion quaternion = Quaternion.LookRotation(v.GetUnityVector());
			this.matrix = Matrix4x4.Rotate(quaternion);
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x001284B8 File Offset: 0x001266B8
		public void SetRotateV(Vector3D v, int a)
		{
			Quaternion quaternion = Quaternion.AngleAxis(this.FixedToFloat(a), v.GetUnityVector().normalized);
			Quaternion quaternion2;
			quaternion2..ctor(-quaternion.x, quaternion.y, quaternion.z, -quaternion.w);
			this.matrix = Matrix4x4.Rotate(quaternion2);
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x00128514 File Offset: 0x00126714
		public void SetRotateX(int a)
		{
			Quaternion quaternion = Quaternion.Euler(this.FixedToFloat(a) * 360f, 0f, 0f);
			Quaternion quaternion2;
			quaternion2..ctor(-quaternion.x, quaternion.y, quaternion.z, -quaternion.w);
			this.matrix = Matrix4x4.Rotate(quaternion2);
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x00128574 File Offset: 0x00126774
		public void SetRotateY(int a)
		{
			Quaternion quaternion = Quaternion.Euler(0f, -this.FixedToFloat(a) * 360f, 0f);
			Quaternion quaternion2;
			quaternion2..ctor(-quaternion.x, quaternion.y, quaternion.z, -quaternion.w);
			this.matrix = Matrix4x4.Rotate(quaternion2);
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x001285D4 File Offset: 0x001267D4
		public void SetRotateZ(int a)
		{
			Quaternion quaternion = Quaternion.Euler(0f, 0f, -this.FixedToFloat(a) * 360f);
			Quaternion quaternion2;
			quaternion2..ctor(-quaternion.x, quaternion.y, quaternion.z, -quaternion.w);
			this.matrix = Matrix4x4.Rotate(quaternion2);
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x00128634 File Offset: 0x00126834
		public void SetRow(int row, int x, int y, int z, int w)
		{
			if (row < 0 || row > 2)
			{
				return;
			}
			int num = row * 10;
			this.matrix[num++] = this.FixedToFloat(x);
			this.matrix[num++] = this.FixedToFloat(y);
			this.matrix[num++] = this.FixedToFloat(z);
			this.matrix[num++] = this.FixedToFloat(w);
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x001286B0 File Offset: 0x001268B0
		public void Transform(Vector3D v, ref Vector3D result)
		{
			Vector3 vector = this.matrix.MultiplyPoint(new Vector3((float)v.x, (float)v.y, (float)v.z));
			result = new Vector3D((int)vector.x, (int)vector.y, (int)vector.z);
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x00128700 File Offset: 0x00126900
		public AffineTrans Tranpose()
		{
			return new AffineTrans(this.m00, this.m10, this.m20, -this.m03, this.m01, this.m11, this.m21, -this.m13, this.m02, this.m12, this.m22, -this.m23);
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x0012875D File Offset: 0x0012695D
		protected float FixedToFloat(int fix)
		{
			return (float)fix / 4096f;
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x00128768 File Offset: 0x00126968
		protected int FloatToFixed(float f)
		{
			return (int)(f * 4096f);
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x00128774 File Offset: 0x00126974
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Format("{0} / {1} / {2} / {3} \n\r", new object[] { this.m00, this.m01, this.m02, this.m03 }));
			stringBuilder.Append(string.Format("{0} / {1} / {2} / {3} \n\r", new object[] { this.m10, this.m11, this.m12, this.m13 }));
			stringBuilder.Append(string.Format("{0} / {1} / {2} / {3} \n\r", new object[] { this.m20, this.m21, this.m22, this.m23 }));
			return stringBuilder.ToString();
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0012887C File Offset: 0x00126A7C
		public virtual void SetTransform(StTransform transform)
		{
			this.matrix = Matrix4x4.identity;
			this.matrix.m00 = transform.Get(0);
			this.matrix.m01 = transform.Get(1);
			this.matrix.m02 = transform.Get(2);
			this.matrix.m03 = transform.Get(3);
			this.matrix.m10 = transform.Get(4);
			this.matrix.m11 = transform.Get(5);
			this.matrix.m12 = transform.Get(6);
			this.matrix.m13 = transform.Get(7);
			this.matrix.m20 = transform.Get(8);
			this.matrix.m21 = transform.Get(9);
			this.matrix.m22 = transform.Get(10);
			this.matrix.m23 = transform.Get(11);
			this.matrix.m30 = transform.Get(12);
			this.matrix.m31 = transform.Get(13);
			this.matrix.m32 = transform.Get(14);
			this.matrix.m33 = transform.Get(15);
			this.ConvertSocotraMatrix();
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x001289C4 File Offset: 0x00126BC4
		protected void ConvertSocotraMatrix()
		{
			this.matrix00 = this.FloatToFixed(this.matrix.m00);
			this.matrix01 = this.FloatToFixed(this.matrix.m01);
			this.matrix02 = this.FloatToFixed(this.matrix.m02);
			this.matrix03 = (int)this.matrix.m03;
			this.matrix10 = this.FloatToFixed(this.matrix.m10);
			this.matrix11 = this.FloatToFixed(this.matrix.m11);
			this.matrix12 = this.FloatToFixed(this.matrix.m12);
			this.matrix13 = (int)this.matrix.m13;
			this.matrix20 = this.FloatToFixed(this.matrix.m20);
			this.matrix21 = this.FloatToFixed(this.matrix.m21);
			this.matrix22 = this.FloatToFixed(this.matrix.m22);
			this.matrix23 = (int)this.matrix.m23;
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x00128AD6 File Offset: 0x00126CD6
		public Vector3 GetUnityPosition()
		{
			return new Vector3((float)(-(float)this.matrix23), (float)this.matrix13, (float)this.matrix03);
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x00128AF4 File Offset: 0x00126CF4
		public AffineTrans CreateLeftTransform()
		{
			return new AffineTrans
			{
				m00 = this.m00,
				m01 = -this.m01,
				m02 = -this.m02,
				m03 = -this.m03,
				m10 = -this.m10,
				m11 = this.m11,
				m12 = this.m12,
				m13 = this.m13,
				m20 = -this.m20,
				m21 = this.m21,
				m22 = this.m22,
				m23 = this.m23
			};
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x00128B9C File Offset: 0x00126D9C
		public AffineTrans CreateRightTransform()
		{
			return new AffineTrans
			{
				m00 = this.m22,
				m01 = -this.m20,
				m02 = this.m21,
				m03 = this.m03,
				m10 = -this.m02,
				m11 = this.m00,
				m12 = -this.m01,
				m13 = this.m13,
				m20 = this.m12,
				m21 = -this.m10,
				m22 = this.m11,
				m23 = this.m23
			};
		}

		// Token: 0x04000C1F RID: 3103
		private int matrix00 = 4096;

		// Token: 0x04000C20 RID: 3104
		private int matrix01;

		// Token: 0x04000C21 RID: 3105
		private int matrix02;

		// Token: 0x04000C22 RID: 3106
		private int matrix03;

		// Token: 0x04000C23 RID: 3107
		private int matrix10;

		// Token: 0x04000C24 RID: 3108
		private int matrix11 = 4096;

		// Token: 0x04000C25 RID: 3109
		private int matrix12;

		// Token: 0x04000C26 RID: 3110
		private int matrix13;

		// Token: 0x04000C27 RID: 3111
		private int matrix20;

		// Token: 0x04000C28 RID: 3112
		private int matrix21;

		// Token: 0x04000C29 RID: 3113
		private int matrix22 = 4096;

		// Token: 0x04000C2A RID: 3114
		private int matrix23;

		// Token: 0x04000C2B RID: 3115
		protected Matrix4x4 matrix;
	}
}
