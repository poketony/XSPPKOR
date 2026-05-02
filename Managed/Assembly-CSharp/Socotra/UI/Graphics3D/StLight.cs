using System;
using Socotra.Opt.UI.J3d;
using UnityEngine;

namespace Socotra.UI.Graphics3D
{
	// Token: 0x02000109 RID: 265
	public class StLight : Object3D
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x001279B0 File Offset: 0x00125BB0
		// (set) Token: 0x0600149B RID: 5275 RVA: 0x001279B8 File Offset: 0x00125BB8
		public GameObject UnityLight
		{
			get
			{
				return this.unityLight;
			}
			set
			{
				this.unityLight = value;
			}
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x001279C1 File Offset: 0x00125BC1
		public static int GetMaxLights()
		{
			return 4;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x001279C4 File Offset: 0x00125BC4
		public Vector3D GetPosition()
		{
			return this.position;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x001279CC File Offset: 0x00125BCC
		public Vector3D GetVector()
		{
			return this.vector;
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x001279D4 File Offset: 0x00125BD4
		public void StAttenuation(float constant, float linear, float quadratic)
		{
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x001279D6 File Offset: 0x00125BD6
		public void SetColor(int RGB)
		{
			this.color = RGB;
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x001279DF File Offset: 0x00125BDF
		public void SetIntensity(float intensity)
		{
			this.intensity = intensity;
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x001279E8 File Offset: 0x00125BE8
		public void SetMode(int mode)
		{
			this.mode = mode;
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x001279F1 File Offset: 0x00125BF1
		private void SetPosition(Vector3D v)
		{
			this.position = v;
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x001279FA File Offset: 0x00125BFA
		private void SetSpotAngle(float angle)
		{
			this.spotAngle = angle;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x00127A03 File Offset: 0x00125C03
		public void SetSpotExponent(float exponent)
		{
			this.spotExponent = exponent;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x00127A0C File Offset: 0x00125C0C
		public void SetVector(Vector3D v)
		{
			this.vector = v;
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x00127A15 File Offset: 0x00125C15
		public void SetVector(Vector3 v)
		{
			this.vectorUnity = v;
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x00127A1E File Offset: 0x00125C1E
		public int GetMode()
		{
			return this.mode;
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x00127A26 File Offset: 0x00125C26
		public int GetColor()
		{
			return this.color;
		}

		// Token: 0x04000C0B RID: 3083
		private GameObject unityLight;

		// Token: 0x04000C0C RID: 3084
		private Vector3D position;

		// Token: 0x04000C0D RID: 3085
		private Vector3D vector;

		// Token: 0x04000C0E RID: 3086
		private Vector3 vectorUnity;

		// Token: 0x04000C0F RID: 3087
		private int color;

		// Token: 0x04000C10 RID: 3088
		private int mode;

		// Token: 0x04000C11 RID: 3089
		private float intensity;

		// Token: 0x04000C12 RID: 3090
		private float spotAngle;

		// Token: 0x04000C13 RID: 3091
		private float spotExponent;

		// Token: 0x04000C14 RID: 3092
		public const int AMBIENT = 128;

		// Token: 0x04000C15 RID: 3093
		public const int DIRECTIONAL = 129;

		// Token: 0x04000C16 RID: 3094
		public const int OMNI = 130;

		// Token: 0x04000C17 RID: 3095
		public const int SPOT = 131;
	}
}
