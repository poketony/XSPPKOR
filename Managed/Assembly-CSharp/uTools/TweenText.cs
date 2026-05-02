using System;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x02000088 RID: 136
	public class TweenText : Tween<float>
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000F4E RID: 3918 RVA: 0x00114CAA File Offset: 0x00112EAA
		private Text cacheText
		{
			get
			{
				if (this.mText == null)
				{
					this.mText = base.GetComponent<Text>();
				}
				return this.mText;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x00114CCC File Offset: 0x00112ECC
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x00114CD4 File Offset: 0x00112ED4
		public override float value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
				if (this.isTime)
				{
					this.cacheText.text = string.Format(this.format, this.GetTime());
					return;
				}
				this.cacheText.text = Math.Round((double)value, this.digits).ToString();
			}
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00114D30 File Offset: 0x00112F30
		protected string GetTime()
		{
			TimeSpan timeSpan = new TimeSpan(0, 0, (int)this.value);
			string text;
			if (timeSpan.Hours > 0)
			{
				text = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			}
			else
			{
				text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
			}
			return text;
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x00114DB2 File Offset: 0x00112FB2
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x00114DD0 File Offset: 0x00112FD0
		public static TweenText Begin(Text label, float from, float to, float duration, float delay)
		{
			TweenText tweenText = Tweener.Begin<TweenText>(label.gameObject, duration);
			tweenText.value = from;
			tweenText.from = from;
			tweenText.to = to;
			tweenText.delay = delay;
			if (duration <= 0f)
			{
				tweenText.Sample(1f, true);
				tweenText.enabled = false;
			}
			return tweenText;
		}

		// Token: 0x0400094B RID: 2379
		private float mValue;

		// Token: 0x0400094C RID: 2380
		private Text mText;

		// Token: 0x0400094D RID: 2381
		public string format = "{0}";

		// Token: 0x0400094E RID: 2382
		public int digits;

		// Token: 0x0400094F RID: 2383
		public bool isTime;
	}
}
