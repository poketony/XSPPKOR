using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x0200007B RID: 123
	public class TweenAlpha : Tween<float>
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x00113508 File Offset: 0x00111708
		private Transform CachedTranform
		{
			get
			{
				if (this.mTransform == null)
				{
					this.mTransform = base.GetComponent<Transform>();
				}
				return this.mTransform;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0011352A File Offset: 0x0011172A
		private Graphic[] CachedGraphics
		{
			get
			{
				if (this.mGraphics == null)
				{
					this.mGraphics = (this.includeChildren ? base.gameObject.GetComponentsInChildren<Graphic>() : base.gameObject.GetComponents<Graphic>());
				}
				return this.mGraphics;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x00113560 File Offset: 0x00111760
		private CanvasGroup CacheCanvasGroup
		{
			get
			{
				if (this.mCanvasGroup == null)
				{
					this.mCanvasGroup = base.gameObject.GetComponent<CanvasGroup>();
				}
				return this.mCanvasGroup;
			}
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x00113587 File Offset: 0x00111787
		protected override void Start()
		{
			base.Start();
			if (this.CacheCanvasGroup != null)
			{
				this.isCanvasGroup = true;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x001135A4 File Offset: 0x001117A4
		// (set) Token: 0x06000EE2 RID: 3810 RVA: 0x001135AC File Offset: 0x001117AC
		public override float value
		{
			get
			{
				return this.mAlpha;
			}
			set
			{
				this.mAlpha = value;
				this.SetAlpha(this.CachedTranform, value);
			}
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x001135C2 File Offset: 0x001117C2
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x001135E0 File Offset: 0x001117E0
		private void SetAlpha(Transform _transform, float _alpha)
		{
			if (this.isCanvasGroup)
			{
				this.CacheCanvasGroup.alpha = _alpha;
				return;
			}
			foreach (Graphic graphic in this.CachedGraphics)
			{
				Color color = graphic.color;
				color.a = _alpha;
				graphic.color = color;
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x00113630 File Offset: 0x00111830
		public static TweenAlpha Begin(GameObject go, float from, float to, float duration = 1f, float delay = 0f)
		{
			TweenAlpha tweenAlpha = Tweener.Begin<TweenAlpha>(go, duration);
			tweenAlpha.value = from;
			tweenAlpha.from = from;
			tweenAlpha.to = to;
			tweenAlpha.duration = duration;
			tweenAlpha.delay = delay;
			if (duration <= 0f)
			{
				tweenAlpha.Sample(1f, true);
				tweenAlpha.enabled = false;
			}
			return tweenAlpha;
		}

		// Token: 0x04000908 RID: 2312
		public bool includeChildren;

		// Token: 0x04000909 RID: 2313
		private bool isCanvasGroup;

		// Token: 0x0400090A RID: 2314
		private float mAlpha;

		// Token: 0x0400090B RID: 2315
		private Transform mTransform;

		// Token: 0x0400090C RID: 2316
		private Graphic[] mGraphics;

		// Token: 0x0400090D RID: 2317
		private CanvasGroup mCanvasGroup;
	}
}
