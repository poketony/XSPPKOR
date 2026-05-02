using System;
using System.Collections.Generic;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200000D RID: 13
public class CommonDialog : SingletonBehaviour<CommonDialog>
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000048 RID: 72 RVA: 0x0000A44A File Offset: 0x0000864A
	public UnityAction YesButtonClickCallback
	{
		get
		{
			return this.yesButtonClickCallback;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000049 RID: 73 RVA: 0x0000A452 File Offset: 0x00008652
	public UnityAction NoButtonClickCallback
	{
		get
		{
			return this.noButtonClickCallback;
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x0000A45A File Offset: 0x0000865A
	private void Update()
	{
		if (this.isInputStart && this.negativeButtonClickCallback != null && SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.NEGATIVE, StPadManager.Player.P1) && !this.isNegativeButtonCallBackFlow)
		{
			this.isNegativeButtonCallBackFlow = true;
			this.negativeButtonClickCallback.Invoke();
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x0000A498 File Offset: 0x00008698
	public void Init(string message, UnityAction yesButtonClickCallback = null, UnityAction noButtonClickCallback = null)
	{
		this.Init(message, yesButtonClickCallback, noButtonClickCallback, null);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x0000A4A4 File Offset: 0x000086A4
	public void InitForInvisibleButtons(string message, UnityAction negativeButtonClickCallback)
	{
		this.Init(message, null, null, negativeButtonClickCallback);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x0000A4B0 File Offset: 0x000086B0
	private void Init(string message, UnityAction yesButtonClickCallback, UnityAction noButtonClickCallback, UnityAction negativeButtonClickCallback)
	{
		this.messageText.text = message;
		this.yesButtonClickCallback = yesButtonClickCallback;
		this.noButtonClickCallback = noButtonClickCallback;
		this.negativeButtonClickCallback = negativeButtonClickCallback;
		if (yesButtonClickCallback == null)
		{
			this.yesButton.gameObject.SetActive(false);
		}
		else
		{
			this.SetButtonSelectSe(this.yesButton);
			this.yesButton.gameObject.SetActive(true);
			this.yesButton.Select();
		}
		if (noButtonClickCallback == null)
		{
			this.noButton.gameObject.SetActive(false);
		}
		else
		{
			this.SetButtonSelectSe(this.noButton);
			this.noButton.gameObject.SetActive(true);
			if (yesButtonClickCallback == null)
			{
				this.noButton.Select();
			}
		}
		if (yesButtonClickCallback == null && noButtonClickCallback == null)
		{
			this.buttonParent.SetActive(false);
		}
		else
		{
			this.buttonParent.SetActive(true);
		}
		if (negativeButtonClickCallback == null)
		{
			this.backIconBackObj.SetActive(false);
		}
		else
		{
			this.backIconBackObj.SetActive(false);
		}
		this.CallWaitForSecondsRealtime(0.3f, delegate
		{
			this.isInputStart = true;
		});
	}

	// Token: 0x0600004E RID: 78 RVA: 0x0000A5B4 File Offset: 0x000087B4
	private void SetButtonSelectSe(Selectable selectable)
	{
		EventTrigger eventTrigger = selectable.gameObject.AddComponent<EventTrigger>();
		eventTrigger.triggers = new List<EventTrigger.Entry>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = 9;
		entry.callback.AddListener(delegate(BaseEventData x)
		{
			if (this.isFirstSelectionExecuted)
			{
				if (!this.isClose)
				{
					SoundManager.Instance.PlaySE("se_cursol", false);
					return;
				}
			}
			else
			{
				this.isFirstSelectionExecuted = true;
			}
		});
		eventTrigger.triggers.Add(entry);
	}

	// Token: 0x0600004F RID: 79 RVA: 0x0000A607 File Offset: 0x00008807
	public void CloseDialog(UnityAction closeAfterCallback = null)
	{
		this.isClose = true;
		if (closeAfterCallback != null)
		{
			this.closeAnimation.closeAfterUnityEvent.AddListener(closeAfterCallback);
		}
		this.closeAnimation.OnClose();
	}

	// Token: 0x0400005A RID: 90
	[SerializeField]
	private Text messageText;

	// Token: 0x0400005B RID: 91
	[SerializeField]
	private GameObject buttonParent;

	// Token: 0x0400005C RID: 92
	[SerializeField]
	private Button yesButton;

	// Token: 0x0400005D RID: 93
	[SerializeField]
	private Button noButton;

	// Token: 0x0400005E RID: 94
	[SerializeField]
	private GameObject backIconBackObj;

	// Token: 0x0400005F RID: 95
	[SerializeField]
	private ButtonPopupCloseAnimation closeAnimation;

	// Token: 0x04000060 RID: 96
	private UnityAction yesButtonClickCallback;

	// Token: 0x04000061 RID: 97
	private UnityAction noButtonClickCallback;

	// Token: 0x04000062 RID: 98
	private UnityAction negativeButtonClickCallback;

	// Token: 0x04000063 RID: 99
	private bool isFirstSelectionExecuted;

	// Token: 0x04000064 RID: 100
	private bool isInputStart;

	// Token: 0x04000065 RID: 101
	private bool isClose;

	// Token: 0x04000066 RID: 102
	private bool isNegativeButtonCallBackFlow;
}
