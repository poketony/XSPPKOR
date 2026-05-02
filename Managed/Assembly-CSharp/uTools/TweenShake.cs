using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000086 RID: 134
	public class TweenShake : Tweener
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x00114840 File Offset: 0x00112A40
		public Transform target
		{
			get
			{
				if (this.mTarget == null)
				{
					this.mTarget = base.transform;
					this.mRectTransform = this.mTarget as RectTransform;
					this.is3D = !(this.mRectTransform != null);
					this.CacheTargetInfo();
				}
				return this.mTarget;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x0011489C File Offset: 0x00112A9C
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x001148A4 File Offset: 0x00112AA4
		public Vector3 value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
				this.Shake();
			}
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x001148B4 File Offset: 0x00112AB4
		private void CacheTargetInfo()
		{
			this.localPosition = this.target.localPosition;
			this.position = this.target.position;
			this.localScale = this.target.localScale;
			this.localEulerAngles = this.target.localEulerAngles;
			this.eulerAngles = this.target.eulerAngles;
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00114918 File Offset: 0x00112B18
		protected override void OnUpdate(float factor, bool isFinished)
		{
			factor = 1f - factor;
			float num = this.limit.x * factor;
			float num2 = this.limit.y * factor;
			float num3 = this.limit.z * factor;
			this.mValue.x = Random.Range(num * -1f, num);
			this.mValue.y = Random.Range(num2 * -1f, num2);
			this.mValue.z = Random.Range(num3 * -1f, num3);
			this.value = this.mValue;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x001149AC File Offset: 0x00112BAC
		private void Shake()
		{
			if (this.shakeType == ShakeType.ePosition)
			{
				if (this.isLocal)
				{
					this.tempVector3 = this.value + this.localPosition;
					if (this.is3D)
					{
						this.target.localPosition = this.tempVector3;
						return;
					}
					this.mRectTransform.anchoredPosition3D = new Vector3(this.tempVector3.x, this.tempVector3.y, 0f);
					return;
				}
				else
				{
					this.tempVector3 = this.value + this.position;
					if (this.is3D)
					{
						this.target.position = this.tempVector3;
						return;
					}
					this.mRectTransform.anchoredPosition3D = this.tempVector3;
					return;
				}
			}
			else
			{
				if (this.shakeType == ShakeType.eScale)
				{
					this.target.localScale = this.value + this.localScale;
					return;
				}
				if (this.isLocal)
				{
					this.target.localEulerAngles = this.value + this.localEulerAngles;
					return;
				}
				this.target.eulerAngles = this.value + this.eulerAngles;
				return;
			}
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00114AD4 File Offset: 0x00112CD4
		public static TweenShake Begin(GameObject go, Vector3 from, float duration = 1f, float delay = 0f)
		{
			TweenShake tweenShake = Tweener.Begin<TweenShake>(go, duration);
			tweenShake.limit = from;
			tweenShake.duration = duration;
			tweenShake.delay = delay;
			if (duration <= 0f)
			{
				tweenShake.Sample(1f, true);
				tweenShake.enabled = false;
			}
			return tweenShake;
		}

		// Token: 0x0400093B RID: 2363
		private RectTransform mRectTransform;

		// Token: 0x0400093C RID: 2364
		private bool is3D = true;

		// Token: 0x0400093D RID: 2365
		private Transform mTarget;

		// Token: 0x0400093E RID: 2366
		private Vector3 localPosition = Vector3.zero;

		// Token: 0x0400093F RID: 2367
		private Vector3 position = Vector3.zero;

		// Token: 0x04000940 RID: 2368
		private Vector3 localScale = Vector3.zero;

		// Token: 0x04000941 RID: 2369
		private Vector3 localEulerAngles = Vector3.zero;

		// Token: 0x04000942 RID: 2370
		private Vector3 eulerAngles = Vector3.zero;

		// Token: 0x04000943 RID: 2371
		[SerializeField]
		protected Vector3 limit;

		// Token: 0x04000944 RID: 2372
		[SerializeField]
		protected bool isLocal = true;

		// Token: 0x04000945 RID: 2373
		[SerializeField]
		protected ShakeType shakeType;

		// Token: 0x04000946 RID: 2374
		private Vector3 mValue;

		// Token: 0x04000947 RID: 2375
		private Vector3 tempVector3 = Vector3.one;
	}
}
