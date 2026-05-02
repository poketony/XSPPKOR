using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000083 RID: 131
	public class TweenRectTransformWidthHeight : Tween<Vector2>
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x00114510 File Offset: 0x00112710
		// (set) Token: 0x06000F29 RID: 3881 RVA: 0x0011455C File Offset: 0x0011275C
		private bool is3D
		{
			get
			{
				if (this.mTransform == null)
				{
					this.mTransform = base.transform;
					RectTransform rectTransform = this.cachedTransform as RectTransform;
					this.mIs3D = !(rectTransform != null);
				}
				return this.mIs3D;
			}
			set
			{
				this.mIs3D = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x00114568 File Offset: 0x00112768
		private Transform cachedTransform
		{
			get
			{
				if (this.mTransform == null)
				{
					this.mTransform = base.transform;
					RectTransform rectTransform = this.cachedTransform as RectTransform;
					this.is3D = !(rectTransform != null);
				}
				return this.mTransform;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x001145B4 File Offset: 0x001127B4
		private RectTransform cachedRectTransform
		{
			get
			{
				if (this.mRectTransform == null)
				{
					this.mRectTransform = this.cachedTransform as RectTransform;
					this.is3D = !(this.mRectTransform != null);
				}
				return this.mRectTransform;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x001145F3 File Offset: 0x001127F3
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00114600 File Offset: 0x00112800
		public override Vector2 value
		{
			get
			{
				return this.cachedRectTransform.sizeDelta;
			}
			set
			{
				this.cachedRectTransform.sizeDelta = value;
			}
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0011460E File Offset: 0x0011280E
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x00114638 File Offset: 0x00112838
		public static TweenPosition Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			TweenPosition tweenPosition = Tweener.Begin<TweenPosition>(go, duration);
			tweenPosition.value = from;
			tweenPosition.from = from;
			tweenPosition.to = to;
			tweenPosition.duration = duration;
			tweenPosition.delay = delay;
			if (duration <= 0f)
			{
				tweenPosition.Sample(1f, true);
				tweenPosition.enabled = false;
			}
			return tweenPosition;
		}

		// Token: 0x04000934 RID: 2356
		private RectTransform mRectTransform;

		// Token: 0x04000935 RID: 2357
		private Transform mTransform;

		// Token: 0x04000936 RID: 2358
		private bool mIs3D = true;
	}
}
