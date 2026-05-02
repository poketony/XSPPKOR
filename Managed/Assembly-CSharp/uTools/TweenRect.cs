using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000082 RID: 130
	public class TweenRect : Tween<Vector2>
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x00114454 File Offset: 0x00112654
		public RectTransform cacheRectTransform
		{
			get
			{
				if (this.mRectTransform == null)
				{
					this.mRectTransform = base.GetComponent<RectTransform>();
				}
				return this.mRectTransform;
			}
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x00114476 File Offset: 0x00112676
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
			this.cacheRectTransform.sizeDelta = this.value;
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x001144B4 File Offset: 0x001126B4
		public static TweenRect Begin(RectTransform go, Vector2 from, Vector2 to, float duration, float delay)
		{
			TweenRect tweenRect = Tweener.Begin<TweenRect>(go.gameObject, duration);
			tweenRect.value = from;
			tweenRect.from = from;
			tweenRect.to = to;
			tweenRect.delay = delay;
			if (duration <= 0f)
			{
				tweenRect.Sample(1f, true);
				tweenRect.enabled = false;
			}
			return tweenRect;
		}

		// Token: 0x04000933 RID: 2355
		private RectTransform mRectTransform;
	}
}
