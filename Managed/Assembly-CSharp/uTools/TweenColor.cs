using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x0200007C RID: 124
	public class TweenColor : Tween<Color>
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0011368D File Offset: 0x0011188D
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x00113695 File Offset: 0x00111895
		public override Color value
		{
			get
			{
				return this.mColor;
			}
			set
			{
				this.SetColor(base.transform, value);
				this.mColor = value;
			}
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x001136AB File Offset: 0x001118AB
		protected override void Start()
		{
			this.mGraphics = (this.includeChildren ? base.gameObject.GetComponentsInChildren<Graphic>() : base.gameObject.GetComponents<Graphic>());
			base.Start();
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x001136D9 File Offset: 0x001118D9
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = Color.Lerp(this.from, this.to, factor);
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x001136F4 File Offset: 0x001118F4
		private void SetColor(Transform _transform, Color _color)
		{
			Graphic[] array = this.mGraphics;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = _color;
			}
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00113720 File Offset: 0x00111920
		public static TweenColor Begin(GameObject go, Color from, Color to, float duration, float delay)
		{
			TweenColor tweenColor = Tweener.Begin<TweenColor>(go, duration);
			tweenColor.value = from;
			tweenColor.from = from;
			tweenColor.to = to;
			tweenColor.delay = delay;
			if (duration <= 0f)
			{
				tweenColor.Sample(1f, true);
				tweenColor.enabled = false;
			}
			return tweenColor;
		}

		// Token: 0x0400090E RID: 2318
		public bool includeChildren;

		// Token: 0x0400090F RID: 2319
		private Graphic[] mGraphics;

		// Token: 0x04000910 RID: 2320
		private Color mColor = Color.white;
	}
}
