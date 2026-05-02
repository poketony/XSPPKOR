using System;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000012 RID: 18
public class HowToPlayDialog : SingletonBehaviour<HowToPlayDialog>
{
	// Token: 0x06000061 RID: 97 RVA: 0x0000A830 File Offset: 0x00008A30
	private void Update()
	{
		if (this.isInputStart)
		{
			if (this.pageCount > 1)
			{
				Vector2 vector = SingletonBehaviour<StPadManager>.Instance.GetAnalogStick(StPadManager.Player.P1);
				if (this.nowPage > 1)
				{
					if (SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.LEFT, StPadManager.Player.P1) || (vector.sqrMagnitude > 0.3f && Vector2.Angle(vector, Vector2.left) < 40f) || SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.L, StPadManager.Player.P1))
					{
						if (this.mKeyDownTimeLeft <= 0f)
						{
							if (this.mKeyDownTimeLeft == -3.4028235E+38f)
							{
								this.mKeyDownTimeLeft = 0.5f;
							}
							else
							{
								this.mKeyDownTimeLeft += 0.2f;
							}
							SoundManager.Instance.PlaySE("se_cursol", false);
							this.ChangePage(this.nowPage - 1);
						}
						else
						{
							this.mKeyDownTimeLeft -= Time.unscaledDeltaTime;
						}
					}
					else
					{
						this.mKeyDownTimeLeft = float.MinValue;
					}
				}
				if (this.nowPage < this.pageCount)
				{
					if (SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.RIGHT, StPadManager.Player.P1) || (vector.sqrMagnitude > 0.3f && Vector2.Angle(vector, Vector2.right) < 40f) || SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.R, StPadManager.Player.P1))
					{
						if (this.mKeyDownTimeRight <= 0f)
						{
							if (this.mKeyDownTimeRight == -3.4028235E+38f)
							{
								this.mKeyDownTimeRight = 0.5f;
							}
							else
							{
								this.mKeyDownTimeRight += 0.2f;
							}
							SoundManager.Instance.PlaySE("se_cursol", false);
							this.ChangePage(this.nowPage + 1);
						}
						else
						{
							this.mKeyDownTimeRight -= Time.unscaledDeltaTime;
						}
					}
					else
					{
						this.mKeyDownTimeRight = float.MinValue;
					}
				}
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.NEGATIVE, StPadManager.Player.P1) && !this.isCallBackFlow)
			{
				this.isCallBackFlow = true;
				SoundManager.Instance.PlaySE("se_cancel", false);
				this.PopupClose();
			}
		}
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000AA2C File Offset: 0x00008C2C
	public void PopupClose()
	{
		if (this._playPopupCloseAnimation)
		{
			if (this._onCloseCallback != null)
			{
				this.closeAnimation.closeAfterUnityEvent.AddListener(this._onCloseCallback);
			}
			this.closeAnimation.OnClose();
			return;
		}
		if (this._onCloseCallback != null)
		{
			this._onCloseCallback.Invoke();
		}
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000AA80 File Offset: 0x00008C80
	public void Init(UnityAction onCloseCallback = null, bool playPopupCloseAnimation = true)
	{
		this._onCloseCallback = onCloseCallback;
		this._playPopupCloseAnimation = playPopupCloseAnimation;
		this.mKeyDownTimeLeft = 0f;
		this.mKeyDownTimeRight = 0f;
		this.nowPage = 1;
		this.pageCount = this.howToPlayDataModel.GetHowToPlayImages().Length;
		this.backIconBackObj.SetActive(false);
		this.ChangePage(this.nowPage);
		this.CallWaitForSecondsRealtime(0.3f, delegate
		{
			this.isInputStart = true;
		});
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000AAFA File Offset: 0x00008CFA
	private void ChangePage(int page)
	{
		if (page < 1 || page > this.pageCount)
		{
			return;
		}
		this.nowPage = page;
		this.SetArrow(page);
		this.guideImage.sprite = this.howToPlayDataModel.GetHowToPlayImages()[this.nowPage - 1];
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000AB38 File Offset: 0x00008D38
	private void SetArrow(int page)
	{
		if (this.pageCount > 1 && page > 1)
		{
			this.arrowLeftObj.SetActive(true);
		}
		else
		{
			this.arrowLeftObj.SetActive(false);
		}
		if (this.pageCount > 1 && page < this.pageCount)
		{
			this.arrowRightObj.SetActive(true);
			return;
		}
		this.arrowRightObj.SetActive(false);
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0000AB97 File Offset: 0x00008D97
	public void CloseDialog(UnityAction closeAfterCallback = null)
	{
		if (closeAfterCallback != null)
		{
			this.closeAnimation.closeAfterUnityEvent.AddListener(closeAfterCallback);
		}
		this.closeAnimation.OnClose();
	}

	// Token: 0x0400006D RID: 109
	private const float KeyDownMoveFirstDelayTime = 0.5f;

	// Token: 0x0400006E RID: 110
	private const float KeyDownMoveDelayTime = 0.2f;

	// Token: 0x0400006F RID: 111
	[SerializeField]
	private HowToPlayDataModel howToPlayDataModel;

	// Token: 0x04000070 RID: 112
	[SerializeField]
	private Image guideImage;

	// Token: 0x04000071 RID: 113
	[SerializeField]
	private GameObject arrowLeftObj;

	// Token: 0x04000072 RID: 114
	[SerializeField]
	private GameObject arrowRightObj;

	// Token: 0x04000073 RID: 115
	[SerializeField]
	private ButtonPopupCloseAnimation closeAnimation;

	// Token: 0x04000074 RID: 116
	[SerializeField]
	private GameObject backIconBackObj;

	// Token: 0x04000075 RID: 117
	private int pageCount = 1;

	// Token: 0x04000076 RID: 118
	private int nowPage = 1;

	// Token: 0x04000077 RID: 119
	private float mKeyDownTimeLeft;

	// Token: 0x04000078 RID: 120
	private float mKeyDownTimeRight;

	// Token: 0x04000079 RID: 121
	private bool isInputStart;

	// Token: 0x0400007A RID: 122
	private UnityAction _onCloseCallback;

	// Token: 0x0400007B RID: 123
	private bool _playPopupCloseAnimation;

	// Token: 0x0400007C RID: 124
	private bool isCallBackFlow;
}
