using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x0200007E RID: 126
	public class TweenImage : Tweener
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x00113D91 File Offset: 0x00111F91
		// (set) Token: 0x06000F07 RID: 3847 RVA: 0x00113D99 File Offset: 0x00111F99
		public float value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x00113DA2 File Offset: 0x00111FA2
		public Image cacheImage
		{
			get
			{
				if (this.mImage == null)
				{
					this.mImage = base.GetComponent<Image>();
					if (this.mImage.type != 3)
					{
						Debug.LogWarning("[uTweenImage] To use tween the image type must be [Image.Type.Filled]");
					}
				}
				return this.mImage;
			}
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x00113DDC File Offset: 0x00111FDC
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
			this.cacheImage.fillAmount = this.value;
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x00113E0C File Offset: 0x0011200C
		public static TweenImage Begin(Image go, float from, float to, float duration, float delay)
		{
			TweenImage tweenImage = Tweener.Begin<TweenImage>(go.gameObject, duration);
			tweenImage.value = from;
			tweenImage.from = from;
			tweenImage.to = to;
			tweenImage.delay = delay;
			if (duration <= 0f)
			{
				tweenImage.Sample(1f, true);
				tweenImage.enabled = false;
			}
			return tweenImage;
		}

		// Token: 0x04000923 RID: 2339
		[Range(0f, 1f)]
		public float from;

		// Token: 0x04000924 RID: 2340
		[Range(0f, 1f)]
		public float to;

		// Token: 0x04000925 RID: 2341
		private float mValue;

		// Token: 0x04000926 RID: 2342
		private Image mImage;
	}
}
