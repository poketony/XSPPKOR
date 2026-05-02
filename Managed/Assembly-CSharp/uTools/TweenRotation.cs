using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000084 RID: 132
	public class TweenRotation : Tween<Vector3>
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000F31 RID: 3889 RVA: 0x0011469C File Offset: 0x0011289C
		// (set) Token: 0x06000F32 RID: 3890 RVA: 0x001146A4 File Offset: 0x001128A4
		public override Vector3 value
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

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000F33 RID: 3891 RVA: 0x001146AD File Offset: 0x001128AD
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

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x001146CF File Offset: 0x001128CF
		// (set) Token: 0x06000F35 RID: 3893 RVA: 0x001146DC File Offset: 0x001128DC
		private Quaternion QuaternionValue
		{
			get
			{
				return this.cachedTransform.localRotation;
			}
			set
			{
				this.cachedTransform.localRotation = value;
			}
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x001146EA File Offset: 0x001128EA
		protected override void OnUpdate(float _factor, bool _isFinished)
		{
			this.mValue = Vector3.Lerp(this.from, this.to, _factor);
			this.QuaternionValue = Quaternion.Euler(this.mValue);
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x00114718 File Offset: 0x00112918
		public static TweenRotation Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			TweenRotation tweenRotation = Tweener.Begin<TweenRotation>(go, duration);
			tweenRotation.value = from;
			tweenRotation.from = from;
			tweenRotation.to = to;
			tweenRotation.duration = duration;
			tweenRotation.delay = delay;
			if (duration <= 0f)
			{
				tweenRotation.Sample(1f, true);
				tweenRotation.enabled = false;
			}
			return tweenRotation;
		}

		// Token: 0x04000937 RID: 2359
		private Vector3 mValue;

		// Token: 0x04000938 RID: 2360
		private Transform mTransform;
	}
}
