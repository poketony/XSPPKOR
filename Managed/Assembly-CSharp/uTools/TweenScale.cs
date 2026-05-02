using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000085 RID: 133
	public class TweenScale : Tween<Vector3>
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x00114775 File Offset: 0x00112975
		private Transform cachedTransform
		{
			get
			{
				if (this.mTransform == null)
				{
					this.mTransform = base.transform;
				}
				return this.mTransform;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000F3A RID: 3898 RVA: 0x00114797 File Offset: 0x00112997
		// (set) Token: 0x06000F3B RID: 3899 RVA: 0x0011479F File Offset: 0x0011299F
		public override Vector3 value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
				this.cachedTransform.localScale = value;
			}
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x001147B4 File Offset: 0x001129B4
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x001147E0 File Offset: 0x001129E0
		public static TweenScale Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			TweenScale tweenScale = Tweener.Begin<TweenScale>(go, duration);
			tweenScale.value = from;
			tweenScale.from = from;
			tweenScale.to = to;
			tweenScale.duration = duration;
			tweenScale.delay = delay;
			if (duration <= 0f)
			{
				tweenScale.Sample(1f, true);
				tweenScale.enabled = false;
			}
			return tweenScale;
		}

		// Token: 0x04000939 RID: 2361
		private Vector3 mValue;

		// Token: 0x0400093A RID: 2362
		private Transform mTransform;
	}
}
