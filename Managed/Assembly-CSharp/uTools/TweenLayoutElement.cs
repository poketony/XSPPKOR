using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x0200007F RID: 127
	public class TweenLayoutElement : Tween<float>
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000F0C RID: 3852 RVA: 0x00113E67 File Offset: 0x00112067
		public LayoutElement cachedLayoutElement
		{
			get
			{
				if (this.mLayoutElement == null)
				{
					this.mLayoutElement = base.GetComponent<LayoutElement>();
				}
				return this.mLayoutElement;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x00113E89 File Offset: 0x00112089
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x00113E94 File Offset: 0x00112094
		public override float value
		{
			get
			{
				return base.value;
			}
			set
			{
				base.value = value;
				switch (this.tweenType)
				{
				case TweenLayoutElement.Element.MinWidth:
					this.cachedLayoutElement.minWidth = value;
					return;
				case TweenLayoutElement.Element.MinHeight:
					this.cachedLayoutElement.minHeight = value;
					return;
				case TweenLayoutElement.Element.PreferredWidth:
					this.cachedLayoutElement.preferredWidth = value;
					return;
				case TweenLayoutElement.Element.PreferredHeight:
					this.cachedLayoutElement.preferredHeight = value;
					return;
				case TweenLayoutElement.Element.FlexibleWidth:
					this.cachedLayoutElement.flexibleWidth = value;
					return;
				case TweenLayoutElement.Element.FlexibleHeight:
					this.cachedLayoutElement.flexibleHeight = value;
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x00113F1B File Offset: 0x0011211B
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x00113F3C File Offset: 0x0011213C
		public static TweenLayoutElement Begin(GameObject go, float from, float to, float duration = 1f, float delay = 0f)
		{
			TweenLayoutElement tweenLayoutElement = Tweener.Begin<TweenLayoutElement>(go, duration);
			tweenLayoutElement.value = from;
			tweenLayoutElement.from = from;
			tweenLayoutElement.to = to;
			tweenLayoutElement.duration = duration;
			tweenLayoutElement.delay = delay;
			if (duration <= 0f)
			{
				tweenLayoutElement.Sample(1f, true);
				tweenLayoutElement.enabled = false;
			}
			return tweenLayoutElement;
		}

		// Token: 0x04000927 RID: 2343
		public TweenLayoutElement.Element tweenType = TweenLayoutElement.Element.PreferredHeight;

		// Token: 0x04000928 RID: 2344
		private LayoutElement mLayoutElement;

		// Token: 0x020001F3 RID: 499
		public enum Element
		{
			// Token: 0x040013BD RID: 5053
			MinWidth,
			// Token: 0x040013BE RID: 5054
			MinHeight,
			// Token: 0x040013BF RID: 5055
			PreferredWidth,
			// Token: 0x040013C0 RID: 5056
			PreferredHeight,
			// Token: 0x040013C1 RID: 5057
			FlexibleWidth,
			// Token: 0x040013C2 RID: 5058
			FlexibleHeight
		}
	}
}
