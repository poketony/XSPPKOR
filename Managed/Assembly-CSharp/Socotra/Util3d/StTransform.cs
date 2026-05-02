using System;
using UnityEngine;

namespace Socotra.Util3d
{
	// Token: 0x020000F9 RID: 249
	public class StTransform
	{
		// Token: 0x06001370 RID: 4976 RVA: 0x001207E0 File Offset: 0x0011E9E0
		public StTransform()
		{
			this.umat = Matrix4x4.identity;
			this.trans = new float[]
			{
				this.umat.m00,
				this.umat.m01,
				this.umat.m02,
				this.umat.m03,
				this.umat.m10,
				this.umat.m11,
				this.umat.m12,
				this.umat.m13,
				this.umat.m20,
				this.umat.m21,
				this.umat.m22,
				this.umat.m23,
				this.umat.m30,
				this.umat.m31,
				this.umat.m32,
				this.umat.m33
			};
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x001208FF File Offset: 0x0011EAFF
		public StTransform(StTransform baseTransform)
		{
			baseTransform.Get(ref this.trans);
			this.ConvertUnity();
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x00120926 File Offset: 0x0011EB26
		public void SetIdentity()
		{
			this.umat = Matrix4x4.identity;
			this.ConvertSocotra();
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x00120939 File Offset: 0x0011EB39
		public void Get(ref float[] matrix)
		{
			this.ConvertSocotra();
			this.trans.CopyTo(matrix, 0);
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0012094F File Offset: 0x0011EB4F
		public float Get(int index)
		{
			this.ConvertSocotra();
			return this.trans[index];
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x0012095F File Offset: 0x0011EB5F
		public void Set(float[] matrix)
		{
			matrix.CopyTo(this.trans, 0);
			this.ConvertUnity();
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x00120974 File Offset: 0x0011EB74
		public void Set(int index, float value)
		{
			this.trans[index] = value;
			this.ConvertUnity();
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x00120985 File Offset: 0x0011EB85
		public void Set(StTransform value)
		{
			this.umat = value.umat;
			this.ConvertSocotra();
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0012099C File Offset: 0x0011EB9C
		public void Scale(float x, float y, float z)
		{
			Matrix4x4 identity = Matrix4x4.identity;
			identity.m00 = x;
			identity.m11 = y;
			identity.m22 = z;
			this.umat *= identity;
			this.ConvertSocotra();
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x001209E0 File Offset: 0x0011EBE0
		public void Multiply(StTransform trans)
		{
			Matrix4x4 matrix4x = this.GetUnityMatrix() * trans.GetUnityMatrix();
			this.umat = matrix4x;
			this.ConvertSocotra();
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00120A0C File Offset: 0x0011EC0C
		public void Rotate(float x, float y, float z, float angle)
		{
			Matrix4x4 matrix4x = Matrix4x4.Rotate(Quaternion.AngleAxis(angle, new Vector3(x, y, z)));
			new StTransform();
			this.umat *= matrix4x;
			this.ConvertSocotra();
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x00120A4C File Offset: 0x0011EC4C
		public void TransVector(Vector3 v1, ref Vector3 v2)
		{
			v2 = this.umat * v1;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00120A6C File Offset: 0x0011EC6C
		private void ConvertUnity()
		{
			this.umat.m00 = this.trans[0];
			this.umat.m01 = this.trans[1];
			this.umat.m02 = this.trans[2];
			this.umat.m03 = this.trans[3];
			this.umat.m10 = this.trans[4];
			this.umat.m11 = this.trans[5];
			this.umat.m12 = this.trans[6];
			this.umat.m13 = this.trans[7];
			this.umat.m20 = this.trans[8];
			this.umat.m21 = this.trans[9];
			this.umat.m22 = this.trans[10];
			this.umat.m23 = this.trans[11];
			this.umat.m30 = this.trans[12];
			this.umat.m31 = this.trans[13];
			this.umat.m32 = this.trans[14];
			this.umat.m33 = this.trans[15];
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00120BB0 File Offset: 0x0011EDB0
		private void ConvertSocotra()
		{
			this.trans = new float[]
			{
				this.umat.m00,
				this.umat.m01,
				this.umat.m02,
				this.umat.m03,
				this.umat.m10,
				this.umat.m11,
				this.umat.m12,
				this.umat.m13,
				this.umat.m20,
				this.umat.m21,
				this.umat.m22,
				this.umat.m23,
				this.umat.m30,
				this.umat.m31,
				this.umat.m32,
				this.umat.m33
			};
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x00120CB1 File Offset: 0x0011EEB1
		public Matrix4x4 GetUnityMatrix()
		{
			return this.umat;
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00120CB9 File Offset: 0x0011EEB9
		public Vector3 GetUnityPosition()
		{
			return new Vector3(this.umat.m03, this.umat.m13, this.umat.m23);
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00120CE1 File Offset: 0x0011EEE1
		public override string ToString()
		{
			return this.umat.ToString();
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x00120CF4 File Offset: 0x0011EEF4
		public static Matrix4x4 CreateLeftTransform(Matrix4x4 m)
		{
			Matrix4x4 matrix4x = default(Matrix4x4);
			matrix4x.m00 = m.m00;
			matrix4x.m01 = -m.m01;
			matrix4x.m02 = -m.m02;
			matrix4x.m03 = -m.m03;
			matrix4x.m10 = -m.m10;
			matrix4x.m11 = m.m11;
			matrix4x.m12 = m.m12;
			matrix4x.m13 = m.m13;
			matrix4x.m20 = -m.m20;
			matrix4x.m21 = m.m21;
			matrix4x.m22 = m.m22;
			matrix4x.m23 = m.m23;
			return matrix4x;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x00120DAC File Offset: 0x0011EFAC
		public static Matrix4x4 CreateRightTransform(Matrix4x4 m)
		{
			Matrix4x4 matrix4x = default(Matrix4x4);
			matrix4x.m00 = m.m22;
			matrix4x.m01 = -m.m20;
			matrix4x.m02 = m.m21;
			matrix4x.m03 = m.m03;
			matrix4x.m10 = -m.m02;
			matrix4x.m11 = m.m00;
			matrix4x.m12 = -m.m01;
			matrix4x.m13 = m.m13;
			matrix4x.m20 = m.m12;
			matrix4x.m21 = -m.m10;
			matrix4x.m22 = m.m11;
			matrix4x.m23 = m.m23;
			return matrix4x;
		}

		// Token: 0x04000ADF RID: 2783
		private Matrix4x4 umat;

		// Token: 0x04000AE0 RID: 2784
		private float[] trans = new float[16];
	}
}
