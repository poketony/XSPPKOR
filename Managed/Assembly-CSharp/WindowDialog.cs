using System;
using System.Collections.Generic;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000027 RID: 39
public class WindowDialog : SingletonBehaviour<WindowDialog>
{
	// Token: 0x060000B7 RID: 183 RVA: 0x0000BBC4 File Offset: 0x00009DC4
	private void Start()
	{
		this.Init();
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000BBCC File Offset: 0x00009DCC
	private void Update()
	{
		if (this.isInputStart && SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.NEGATIVE, StPadManager.Player.P1))
		{
			SoundManager.Instance.PlaySE("se_cancel", false);
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Setting", null, true);
		}
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0000BC0C File Offset: 0x00009E0C
	private void Init()
	{
		this.mKeyDownTimeUp = 0f;
		this.mKeyDownTimeDwon = 0f;
		this.nowIndex = SingletonData<CommonData>.Instance.windowMode;
		for (int i = 0; i < this.selectables.Length; i++)
		{
			Selectable sel = this.selectables[i];
			EventTrigger eventTrigger = sel.gameObject.AddComponent<EventTrigger>();
			eventTrigger.triggers = new List<EventTrigger.Entry>();
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = 9;
			entry.callback.AddListener(delegate(BaseEventData x)
			{
				if (this.isFirstSelectionExecuted)
				{
					SoundManager.Instance.PlaySE("se_cursol", false);
					return;
				}
				this.isFirstSelectionExecuted = true;
			});
			eventTrigger.triggers.Add(entry);
			EventTrigger.Entry entry2 = new EventTrigger.Entry();
			entry2.eventID = 10;
			entry2.callback.AddListener(delegate(BaseEventData x)
			{
				sel.gameObject.GetComponent<Animator>().Play("Normal");
			});
			eventTrigger.triggers.Add(entry2);
			if (i == this.nowIndex)
			{
				sel.Select();
			}
		}
		this.CallWaitForSecondsRealtime(0.3f, delegate
		{
			this.isInputStart = true;
		});
	}

	// Token: 0x060000BA RID: 186 RVA: 0x0000BD14 File Offset: 0x00009F14
	public void Change(int index)
	{
		if (index < 0 || index >= 6)
		{
			return;
		}
		this.nowIndex = index;
		SingletonData<CommonData>.Instance.windowMode = this.nowIndex;
		switch (SingletonData<CommonData>.Instance.windowMode)
		{
		case 0:
			Screen.SetResolution(1920, 1080, true);
			return;
		case 1:
			Screen.SetResolution(1920, 1080, false);
			return;
		case 2:
			Screen.SetResolution(1600, 900, false);
			return;
		case 3:
			Screen.SetResolution(1440, 810, false);
			return;
		case 4:
			Screen.SetResolution(1280, 720, false);
			return;
		case 5:
			Screen.SetResolution(960, 540, false);
			return;
		default:
			return;
		}
	}

	// Token: 0x060000BB RID: 187 RVA: 0x0000BDD0 File Offset: 0x00009FD0
	public void SaveWindow()
	{
		SaveDataManager.SaveWindowMode(SingletonData<CommonData>.Instance.windowMode, true);
	}

	// Token: 0x060000BC RID: 188 RVA: 0x0000BDE2 File Offset: 0x00009FE2
	public void CloseDialog(UnityAction closeAfterCallback = null)
	{
		if (closeAfterCallback != null)
		{
			this.closeAnimation.closeAfterUnityEvent.AddListener(closeAfterCallback);
		}
		this.closeAnimation.OnClose();
	}

	// Token: 0x040000F0 RID: 240
	private const float KeyDownMoveFirstDelayTime = 0.5f;

	// Token: 0x040000F1 RID: 241
	private const float KeyDownMoveDelayTime = 0.2f;

	// Token: 0x040000F2 RID: 242
	[SerializeField]
	private Selectable[] selectables;

	// Token: 0x040000F3 RID: 243
	[SerializeField]
	private ButtonPopupCloseAnimation closeAnimation;

	// Token: 0x040000F4 RID: 244
	private const int ListCount = 6;

	// Token: 0x040000F5 RID: 245
	private int nowIndex;

	// Token: 0x040000F6 RID: 246
	private float mKeyDownTimeUp;

	// Token: 0x040000F7 RID: 247
	private float mKeyDownTimeDwon;

	// Token: 0x040000F8 RID: 248
	private bool isFirstSelectionExecuted;

	// Token: 0x040000F9 RID: 249
	private bool isInputStart;
}
