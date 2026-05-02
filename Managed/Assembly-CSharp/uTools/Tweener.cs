using System;
using UnityEngine;
using UnityEngine.Events;

namespace uTools
{
	// Token: 0x0200007D RID: 125
	public abstract class Tweener : MonoBehaviour
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x00113784 File Offset: 0x00111984
		public float amountPerDelta
		{
			get
			{
				if (this.mDuration != this.duration)
				{
					this.mDuration = this.duration;
					this.mAmountPerDelta = Mathf.Abs((this.duration > 0f) ? (1f / this.duration) : 1000f) * Mathf.Sign(this.mAmountPerDelta);
				}
				return this.mAmountPerDelta;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x001137E8 File Offset: 0x001119E8
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x001137F0 File Offset: 0x001119F0
		public float tweenFactor
		{
			get
			{
				return this.mFactor;
			}
			set
			{
				this.mFactor = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x001137FE File Offset: 0x001119FE
		public Direction direction
		{
			get
			{
				if (this.amountPerDelta >= 0f)
				{
					return Direction.Forward;
				}
				return Direction.Reverse;
			}
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x00113810 File Offset: 0x00111A10
		private void Reset()
		{
			if (!this.mStarted)
			{
				this.SetStartToCurrentValue();
				this.SetEndToCurrentValue();
			}
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x00113826 File Offset: 0x00111A26
		protected virtual void Start()
		{
			this.Update();
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x00113830 File Offset: 0x00111A30
		private void Update()
		{
			float num = (this.ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
			float num2 = (this.ignoreTimeScale ? Time.unscaledTime : Time.time);
			if (!this.mStarted)
			{
				this.mStarted = true;
				this.mStartTime = num2 + this.delay;
			}
			if (num2 < this.mStartTime)
			{
				return;
			}
			this.mFactor += this.amountPerDelta * num;
			if (this.style == Tweener.Style.Loop)
			{
				if (this.mFactor > 1f)
				{
					this.mFactor -= Mathf.Floor(this.mFactor);
				}
			}
			else if (this.style == Tweener.Style.PingPong)
			{
				if (this.mFactor > 1f)
				{
					this.mFactor = 1f - (this.mFactor - Mathf.Floor(this.mFactor));
					this.mAmountPerDelta = -this.mAmountPerDelta;
				}
				else if (this.mFactor < 0f)
				{
					this.mFactor = -this.mFactor;
					this.mFactor -= Mathf.Floor(this.mFactor);
					this.mAmountPerDelta = -this.mAmountPerDelta;
				}
			}
			if (this.style == Tweener.Style.Once && (this.duration == 0f || this.mFactor > 1f || this.mFactor < 0f))
			{
				this.mFactor = Mathf.Clamp01(this.mFactor);
				this.Sample(this.mFactor, true);
				base.enabled = false;
				if (Tweener.current != this)
				{
					Tweener tweener = Tweener.current;
					Tweener.current = this;
					if (this.onFinished != null)
					{
						this.onFinished.Invoke();
					}
					if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
					{
						this.eventReceiver.SendMessage(this.callWhenFinished, this, 1);
					}
					Tweener.current = tweener;
					return;
				}
			}
			else
			{
				this.Sample(this.mFactor, false);
			}
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x00113A21 File Offset: 0x00111C21
		public void SetOnFinished(UnityEvent finishedCallBack)
		{
			this.onFinished = finishedCallBack;
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00113A2A File Offset: 0x00111C2A
		public void AddOnFinished(UnityEvent finishedCallBack)
		{
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x00113A2C File Offset: 0x00111C2C
		public void RemoveOnFinished(UnityEvent finishedCallBack)
		{
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x00113A2E File Offset: 0x00111C2E
		private void OnDisable()
		{
			this.mStarted = false;
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x00113A38 File Offset: 0x00111C38
		public void Sample(float factor, bool isFinished)
		{
			float num = Mathf.Clamp01(factor);
			num = ((this.method == EaseType.none) ? this.animationCurve.Evaluate(num) : EaseManager.EasingFromType(0f, 1f, num, this.method));
			this.OnUpdate((this.method == EaseType.none) ? this.animationCurve.Evaluate(num) : num, isFinished);
			if (this.onUpdate != null)
			{
				this.onUpdate.Invoke();
			}
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x00113AAA File Offset: 0x00111CAA
		public void PlayForward()
		{
			this.Play(true);
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x00113AB3 File Offset: 0x00111CB3
		public void PlayReverse()
		{
			this.Play(false);
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x00113ABC File Offset: 0x00111CBC
		public void Play(bool forward)
		{
			this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
			if (!forward)
			{
				this.mAmountPerDelta = -this.mAmountPerDelta;
			}
			base.enabled = true;
			this.Update();
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00113AEC File Offset: 0x00111CEC
		public void ResetToBeginning()
		{
			this.mStarted = false;
			this.mFactor = ((this.amountPerDelta < 0f) ? 1f : 0f);
			this.Sample(this.mFactor, false);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x00113B21 File Offset: 0x00111D21
		public void Toggle()
		{
			if (this.mFactor > 0f)
			{
				this.mAmountPerDelta = -this.amountPerDelta;
			}
			else
			{
				this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
			}
			base.enabled = true;
		}

		// Token: 0x06000EFF RID: 3839
		protected abstract void OnUpdate(float factor, bool isFinished);

		// Token: 0x06000F00 RID: 3840 RVA: 0x00113B58 File Offset: 0x00111D58
		public static T Begin<T>(GameObject go, float duration) where T : Tweener
		{
			T t = go.GetComponent<T>();
			if (t != null && t.tweenGroup != 0)
			{
				t = default(T);
				T[] components = go.GetComponents<T>();
				int i = 0;
				int num = components.Length;
				while (i < num)
				{
					t = components[i];
					if (t != null && t.tweenGroup == 0)
					{
						break;
					}
					t = default(T);
					i++;
				}
			}
			if (t == null)
			{
				t = go.AddComponent<T>();
				if (t == null)
				{
					string text = "Unable to add ";
					Type typeFromHandle = typeof(T);
					Debug.LogError(text + ((typeFromHandle != null) ? typeFromHandle.ToString() : null) + " to " + ((go != null) ? go.ToString() : null));
					return default(T);
				}
			}
			t.mStarted = false;
			t.duration = duration;
			t.mFactor = 0f;
			t.mAmountPerDelta = Mathf.Abs(t.amountPerDelta);
			t.style = Tweener.Style.Once;
			t.animationCurve = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f, 0f, 1f),
				new Keyframe(1f, 1f, 1f, 0f)
			});
			t.eventReceiver = null;
			t.callWhenFinished = null;
			t.enabled = true;
			return t;
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00113D00 File Offset: 0x00111F00
		public virtual void SetStartToCurrentValue()
		{
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00113D02 File Offset: 0x00111F02
		public virtual void SetEndToCurrentValue()
		{
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x00113D04 File Offset: 0x00111F04
		public virtual void SetCurrentValueToStart()
		{
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00113D06 File Offset: 0x00111F06
		public virtual void SetCurrentValueToEnd()
		{
		}

		// Token: 0x04000911 RID: 2321
		public static Tweener current;

		// Token: 0x04000912 RID: 2322
		public EaseType method = EaseType.linear;

		// Token: 0x04000913 RID: 2323
		public Tweener.Style style;

		// Token: 0x04000914 RID: 2324
		public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 0f, 1f),
			new Keyframe(1f, 1f, 1f, 0f)
		});

		// Token: 0x04000915 RID: 2325
		public bool ignoreTimeScale = true;

		// Token: 0x04000916 RID: 2326
		public float delay;

		// Token: 0x04000917 RID: 2327
		public float duration = 1f;

		// Token: 0x04000918 RID: 2328
		[HideInInspector]
		public bool steeperCurves;

		// Token: 0x04000919 RID: 2329
		public int tweenGroup;

		// Token: 0x0400091A RID: 2330
		public UnityEvent onFinished;

		// Token: 0x0400091B RID: 2331
		public UnityAction onUpdate;

		// Token: 0x0400091C RID: 2332
		[HideInInspector]
		public GameObject eventReceiver;

		// Token: 0x0400091D RID: 2333
		[HideInInspector]
		public string callWhenFinished;

		// Token: 0x0400091E RID: 2334
		private bool mStarted;

		// Token: 0x0400091F RID: 2335
		private float mStartTime;

		// Token: 0x04000920 RID: 2336
		private float mDuration;

		// Token: 0x04000921 RID: 2337
		private float mAmountPerDelta = 1000f;

		// Token: 0x04000922 RID: 2338
		private float mFactor;

		// Token: 0x020001F2 RID: 498
		public enum Style
		{
			// Token: 0x040013B9 RID: 5049
			Once,
			// Token: 0x040013BA RID: 5050
			Loop,
			// Token: 0x040013BB RID: 5051
			PingPong
		}
	}
}
