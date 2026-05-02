using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000081 RID: 129
	public class TweenPosition : Tween<Vector3>
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x00114294 File Offset: 0x00112494
		// (set) Token: 0x06000F1C RID: 3868 RVA: 0x001142E0 File Offset: 0x001124E0
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

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x001142EC File Offset: 0x001124EC
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

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000F1E RID: 3870 RVA: 0x00114338 File Offset: 0x00112538
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

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00114377 File Offset: 0x00112577
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x0011439D File Offset: 0x0011259D
		public override Vector3 value
		{
			get
			{
				if (this.is3D)
				{
					return this.cachedTransform.localPosition;
				}
				return this.cachedRectTransform.anchoredPosition;
			}
			set
			{
				if (this.is3D)
				{
					this.cachedTransform.localPosition = value;
					return;
				}
				this.cachedRectTransform.anchoredPosition = value;
			}
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x001143C5 File Offset: 0x001125C5
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x001143F0 File Offset: 0x001125F0
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

		// Token: 0x04000930 RID: 2352
		private RectTransform mRectTransform;

		// Token: 0x04000931 RID: 2353
		private Transform mTransform;

		// Token: 0x04000932 RID: 2354
		private bool mIs3D = true;
	}
}
