using System;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;

// Token: 0x02000007 RID: 7
public class CharacterInputDialog : SingletonBehaviour<CharacterInputDialog>
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000016 RID: 22 RVA: 0x00002646 File Offset: 0x00000846
	public bool IsInputStart
	{
		get
		{
			return this.isInputStart;
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000264E File Offset: 0x0000084E
	private void Awake()
	{
		this.SetWindowSize();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002658 File Offset: 0x00000858
	private void Update()
	{
		if (this.isInputStart && !SingletonBehaviour<AppliArchivePrefabManager>.Instance.HasPopupExclude(new string[] { "CharacterInput" }))
		{
			if (this.IsExecRepeatingKey(SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.NEGATIVE, StPadManager.Player.P1), ref this.mKeyDownTimeNegative))
			{
				SoundManager.Instance.PlaySE("se_cancel", false);
				this.BackSpaceText(true);
			}
			if (this.IsExecRepeatingKey(SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.R, StPadManager.Player.P1), ref this.mKeyDownTimeRight) && SingletonBehaviour<CharacterInputKeyManager>.Instance.ChangeKanjiPageNext())
			{
				SoundManager.Instance.PlaySE("se_cursol", false);
			}
			if (this.IsExecRepeatingKey(SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.L, StPadManager.Player.P1), ref this.mKeyDownTimeLeft) && SingletonBehaviour<CharacterInputKeyManager>.Instance.ChangeKanjiPagePrev())
			{
				SoundManager.Instance.PlaySE("se_cursol", false);
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.PLUS, StPadManager.Player.P1) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.MINUS, StPadManager.Player.P1))
			{
				SingletonBehaviour<CharacterInputKeyManager>.Instance.DecisionKey();
				SoundManager.Instance.PlaySE("se_decision", false);
			}
		}
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002774 File Offset: 0x00000974
	public void Init(int maxLength, string message, string defaultString = "", UnityAction<string> onChangeCallback = null)
	{
		this.onChangeCallback = onChangeCallback;
		this.mKeyDownTimeNegative = 0f;
		this.mKeyDownTimeLeft = 0f;
		this.mKeyDownTimeRight = 0f;
		SingletonBehaviour<CharacterInputKeyManager>.Instance.Init();
		this.inputField.characterLimit = maxLength;
		this.messageText.text = message;
		this.inputField.text = defaultString;
		Vector2 sizeDelta = this.inputTextUnderLineTr.sizeDelta;
		sizeDelta.x = (float)(24 * maxLength) * 1.1f;
		this.inputTextUnderLineTr.sizeDelta = sizeDelta;
		this.inputTextCaret.UpdateCaretPosition();
		this.CallWaitForSecondsRealtime(0.3f, delegate
		{
			this.isInputStart = true;
		});
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002824 File Offset: 0x00000A24
	public void InputConfirm()
	{
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("DialogCommon", delegate(GameObject popupObj)
		{
			CommonDialog commonDialog = popupObj.GetComponent<CommonDialog>();
			commonDialog.Init(string.Format("「{0}」で宜しいですか？", this.inputField.text), delegate
			{
				commonDialog.CloseDialog(null);
				this.CloseDialog(delegate
				{
					this.InputComplete();
				});
			}, delegate
			{
				commonDialog.CloseDialog(null);
			});
		}, false);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002842 File Offset: 0x00000A42
	private void InputComplete()
	{
		if (this.onChangeCallback != null)
		{
			this.onChangeCallback.Invoke(this.inputField.text);
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002862 File Offset: 0x00000A62
	private void CloseDialog(UnityAction closeAfterCallback = null)
	{
		if (closeAfterCallback != null)
		{
			this.closeAnimation.closeAfterUnityEvent.AddListener(closeAfterCallback);
		}
		this.closeAnimation.OnClose(false, true, 0f, true);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000288C File Offset: 0x00000A8C
	public void InputKey(string keyString)
	{
		if (this.inputField.text.Length >= this.inputField.characterLimit)
		{
			this.BackSpaceText(false);
		}
		InputField inputField = this.inputField;
		inputField.text += keyString;
		this.inputTextCaret.UpdateCaretPosition();
		if (this.inputField.text.Length >= this.inputField.characterLimit)
		{
			this.inputTextCaret.SetVisibleCaret(false);
			return;
		}
		this.inputTextCaret.SetVisibleCaret(true);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002918 File Offset: 0x00000B18
	public void BackSpaceText(bool isUpdateCaret = true)
	{
		if (this.inputField.text.Length > 0)
		{
			this.inputField.text = this.inputField.text.Substring(0, this.inputField.text.Length - 1);
			if (isUpdateCaret)
			{
				this.inputTextCaret.UpdateCaretPosition();
				this.inputTextCaret.SetVisibleCaret(true);
			}
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002980 File Offset: 0x00000B80
	public void SetVisiblePageArrowPrev(bool visible)
	{
		this.pageArrowPrevImage.enabled = visible;
	}

	// Token: 0x06000020 RID: 32 RVA: 0x0000298E File Offset: 0x00000B8E
	public void SetVisiblePageArrowNext(bool visible)
	{
		this.pageArrowNextImage.enabled = visible;
	}

	// Token: 0x06000021 RID: 33 RVA: 0x0000299C File Offset: 0x00000B9C
	private bool IsExecRepeatingKey(bool isButtonDown, ref float keyDownTime)
	{
		if (!isButtonDown)
		{
			keyDownTime = float.MinValue;
			return false;
		}
		if (keyDownTime <= 0f)
		{
			if (keyDownTime == -3.4028235E+38f)
			{
				keyDownTime = 0.5f;
			}
			else
			{
				keyDownTime += 0.15f;
			}
			return true;
		}
		keyDownTime -= Time.unscaledDeltaTime;
		return false;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000029DC File Offset: 0x00000BDC
	private void SetWindowSize()
	{
		Vector2 sizeDelta = this.listBgTr.sizeDelta;
		Vector2 sizeDelta2 = this.listBgTr.sizeDelta;
		sizeDelta2.y = 504f;
		this.listBgTr.sizeDelta = sizeDelta2;
		Vector2 vector = this.listBgTr.localPosition;
		vector.y += (sizeDelta.y - 504f) / 2f;
		this.listBgTr.localPosition = vector;
		foreach (TweenRectTransformWidthHeight tweenRectTransformWidthHeight in this.listBgTransformTweeners)
		{
			if (tweenRectTransformWidthHeight.from.y == sizeDelta.y)
			{
				tweenRectTransformWidthHeight.from.y = 504f;
			}
			if (tweenRectTransformWidthHeight.to.y == sizeDelta.y)
			{
				tweenRectTransformWidthHeight.to.y = 504f;
			}
		}
		vector = this.allParentTr.localPosition;
		vector.y -= (sizeDelta.y - 504f) / 2f;
		this.allParentTr.localPosition = vector;
	}

	// Token: 0x0400001B RID: 27
	private const string CharacterInputConfirmMessage = "「{0}」で宜しいですか？";

	// Token: 0x0400001C RID: 28
	private const float KeyDownMoveFirstDelayTime = 0.5f;

	// Token: 0x0400001D RID: 29
	private const float KeyDownMoveDelayTime = 0.15f;

	// Token: 0x0400001E RID: 30
	private const int InputTextUnderLineSizePerChara = 24;

	// Token: 0x0400001F RID: 31
	private const float InputTextUnderLineSizeMerginRatio = 1.1f;

	// Token: 0x04000020 RID: 32
	[SerializeField]
	private Text messageText;

	// Token: 0x04000021 RID: 33
	[SerializeField]
	private InputField inputField;

	// Token: 0x04000022 RID: 34
	[SerializeField]
	private CharacterInputTextCaret inputTextCaret;

	// Token: 0x04000023 RID: 35
	[SerializeField]
	private RectTransform inputTextUnderLineTr;

	// Token: 0x04000024 RID: 36
	[SerializeField]
	private ButtonPopupCloseAnimation closeAnimation;

	// Token: 0x04000025 RID: 37
	[SerializeField]
	private Image pageArrowPrevImage;

	// Token: 0x04000026 RID: 38
	[SerializeField]
	private Image pageArrowNextImage;

	// Token: 0x04000027 RID: 39
	[SerializeField]
	private RectTransform listBgTr;

	// Token: 0x04000028 RID: 40
	[SerializeField]
	private TweenRectTransformWidthHeight[] listBgTransformTweeners;

	// Token: 0x04000029 RID: 41
	[SerializeField]
	private RectTransform allParentTr;

	// Token: 0x0400002A RID: 42
	private UnityAction<string> onChangeCallback;

	// Token: 0x0400002B RID: 43
	private float mKeyDownTimeNegative;

	// Token: 0x0400002C RID: 44
	private float mKeyDownTimeLeft;

	// Token: 0x0400002D RID: 45
	private float mKeyDownTimeRight;

	// Token: 0x0400002E RID: 46
	private bool isInputStart;
}
