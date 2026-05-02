using System;
using System.Collections;
using Steezy.PageFlow;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using uTools;

// Token: 0x0200002A RID: 42
public class ButtonPopupCloseAnimation : SimpleBaseButton
{
	// Token: 0x060000C6 RID: 198 RVA: 0x0000BE82 File Offset: 0x0000A082
	public virtual void OnClose()
	{
		this.OnClose(true, true, this.transitionStateReleaceTime, true);
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x0000BE93 File Offset: 0x0000A093
	public virtual void OnCloseDoNotSetTransitionExecute()
	{
		this.OnClose(true, false, 0f, true);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
	public virtual void OnClose(bool isCheckTransition, bool isSetTransitionExecute = true, float transitionStateReleaceTime = 0f, bool isPlaySound = true)
	{
		this.isCheckTransition = isCheckTransition;
		if (isCheckTransition)
		{
			if (transitionStateReleaceTime > 0f)
			{
				if (!base.CheckTransition(isSetTransitionExecute, transitionStateReleaceTime))
				{
					return;
				}
			}
			else
			{
				if (!base.CheckTransition(false, transitionStateReleaceTime))
				{
					return;
				}
				base.CheckTransitionWait();
			}
		}
		if (this.closePopupObj != null)
		{
			if (this.closeWhenParticleInactivate)
			{
				ParticleSystem[] componentsInChildren = this.closePopupObj.GetComponentsInChildren<ParticleSystem>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.SetActive(false);
				}
			}
			if (this.closeAnimation != null)
			{
				this.closeAnimation.ResetToBeginning();
				this.closeAnimation.tweenFactor = 0f;
				this.closeAnimation.enabled = true;
				this.closeAnimation.onFinished.AddListener(delegate
				{
					if (isCheckTransition)
					{
						this.ReleaceTransitionWait();
					}
				});
				this.closeAnimation.onFinished.AddListener(delegate
				{
					SingletonBehaviour<AppliArchivePrefabManager>.Instance.ClearPopup(this.closePopupObj.name);
				});
				this.closeAnimation.onFinished.AddListener(delegate
				{
					if (this.callBack != null)
					{
						this.callBack();
						this.callBack = null;
					}
					if (this.closeAfterUnityEvent != null)
					{
						this.closeAfterUnityEvent.Invoke();
						this.closeAfterUnityEvent = null;
					}
				});
			}
			if (this.closeAnimations != null)
			{
				UnityAction <>9__3;
				UnityAction <>9__4;
				UnityAction <>9__5;
				for (int j = 0; j < this.closeAnimations.Length; j++)
				{
					Tweener tweener = this.closeAnimations[j];
					tweener.ResetToBeginning();
					tweener.tweenFactor = 0f;
					tweener.enabled = true;
					if (j == 0)
					{
						UnityEvent onFinished = tweener.onFinished;
						UnityAction unityAction;
						if ((unityAction = <>9__3) == null)
						{
							unityAction = (<>9__3 = delegate
							{
								if (isCheckTransition)
								{
									this.ReleaceTransitionWait();
								}
							});
						}
						onFinished.AddListener(unityAction);
						UnityEvent onFinished2 = tweener.onFinished;
						UnityAction unityAction2;
						if ((unityAction2 = <>9__4) == null)
						{
							unityAction2 = (<>9__4 = delegate
							{
								SingletonBehaviour<AppliArchivePrefabManager>.Instance.ClearPopup(this.closePopupObj.name);
							});
						}
						onFinished2.AddListener(unityAction2);
						UnityEvent onFinished3 = tweener.onFinished;
						UnityAction unityAction3;
						if ((unityAction3 = <>9__5) == null)
						{
							unityAction3 = (<>9__5 = delegate
							{
								if (this.callBack != null)
								{
									this.callBack();
									this.callBack = null;
								}
								if (this.closeAfterUnityEvent != null)
								{
									this.closeAfterUnityEvent.Invoke();
									this.closeAfterUnityEvent = null;
								}
							});
						}
						onFinished3.AddListener(unityAction3);
					}
				}
			}
			if (this.closeAnimator != null && !string.IsNullOrEmpty(this.playAnimationState))
			{
				this.closeAnimator.Play(this.playAnimationState);
				base.StartCoroutine(this.OnCloseAnimation());
			}
		}
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x0000C0D7 File Offset: 0x0000A2D7
	private IEnumerator OnCloseAnimation()
	{
		yield return null;
		while (!AnimatorUtil.IsPlayOnce(this.closeAnimator, 1f))
		{
			yield return null;
		}
		if (this.isCheckTransition)
		{
			base.ReleaceTransitionWait();
		}
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.ClearPopup(this.closePopupObj.name);
		if (this.callBack != null)
		{
			this.callBack();
			this.callBack = null;
		}
		if (this.closeAfterUnityEvent != null)
		{
			this.closeAfterUnityEvent.Invoke();
		}
		yield break;
	}

	// Token: 0x040000FA RID: 250
	public bool closeWhenParticleInactivate;

	// Token: 0x040000FB RID: 251
	public float transitionStateReleaceTime;

	// Token: 0x040000FC RID: 252
	private bool isPlaySound;

	// Token: 0x040000FD RID: 253
	public GameObject closePopupObj;

	// Token: 0x040000FE RID: 254
	[Header("tweener用")]
	public Tweener closeAnimation;

	// Token: 0x040000FF RID: 255
	[Header("複数のtweener用 ※1つ目のアニメーションに対してコールバック実行")]
	public Tweener[] closeAnimations;

	// Token: 0x04000100 RID: 256
	[Header("Animator用")]
	public Animator closeAnimator;

	// Token: 0x04000101 RID: 257
	public string playAnimationState;

	// Token: 0x04000102 RID: 258
	[Header("CallBackEvent")]
	public UnityEvent closeAfterUnityEvent;

	// Token: 0x04000103 RID: 259
	public ButtonPopupCloseAnimation.CloseAfterEvent callBack;

	// Token: 0x04000104 RID: 260
	private bool isCheckTransition;

	// Token: 0x020001C0 RID: 448
	// (Invoke) Token: 0x06001BE7 RID: 7143
	public delegate void CloseAfterEvent();
}
