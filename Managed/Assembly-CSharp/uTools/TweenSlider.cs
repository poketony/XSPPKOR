using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x02000087 RID: 135
	public class TweenSlider : Tween<float>
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x00114B7F File Offset: 0x00112D7F
		private Slider cacheSlider
		{
			get
			{
				this.mSlider = base.GetComponent<Slider>();
				if (this.mSlider == null)
				{
					Debug.LogError("'uTweenSlider' can't find 'Slider'");
				}
				return this.mSlider;
			}
		}

		// Token: 0x1700003F RID: 63
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x00114BAC File Offset: 0x00112DAC
		public float sliderValue
		{
			set
			{
				if (this.NeedCarry)
				{
					if (value >= 1f)
					{
						this.cacheSlider.value = value - Mathf.Floor(value);
						return;
					}
					this.cacheSlider.value = value;
					return;
				}
				else
				{
					if (value > 1f)
					{
						this.cacheSlider.value = value - Mathf.Floor(value);
						return;
					}
					this.cacheSlider.value = value;
					return;
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x00114C12 File Offset: 0x00112E12
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x00114C1A File Offset: 0x00112E1A
		public override float value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
				this.sliderValue = value;
			}
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x00114C2A File Offset: 0x00112E2A
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x00114C48 File Offset: 0x00112E48
		public static TweenSlider Begin(Slider slider, float from, float to, float duration, float delay)
		{
			TweenSlider tweenSlider = Tweener.Begin<TweenSlider>(slider.gameObject, duration);
			tweenSlider.value = from;
			tweenSlider.from = from;
			tweenSlider.to = to;
			tweenSlider.delay = delay;
			if (duration <= 0f)
			{
				tweenSlider.Sample(1f, true);
				tweenSlider.enabled = false;
			}
			return tweenSlider;
		}

		// Token: 0x04000948 RID: 2376
		private float mValue;

		// Token: 0x04000949 RID: 2377
		private Slider mSlider;

		// Token: 0x0400094A RID: 2378
		public bool NeedCarry = true;
	}
}
