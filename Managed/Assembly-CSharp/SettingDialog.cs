using System;
using System.Collections.Generic;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200001D RID: 29
public class SettingDialog : SingletonBehaviour<SettingDialog>
{
	// Token: 0x06000085 RID: 133 RVA: 0x0000AF7A File Offset: 0x0000917A
	private void Start()
	{
		this.Init();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x0000AF84 File Offset: 0x00009184
	private void Update()
	{
		if (this.isInputStart)
		{
			Vector2 vector = SingletonBehaviour<StPadManager>.Instance.GetAnalogStick(StPadManager.Player.P1);
			if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.LEFT, StPadManager.Player.P1) || (vector.sqrMagnitude > 0.3f && Vector2.Angle(vector, Vector2.left) < 40f))
			{
				this.frameSettingToggle.OnSelected(StPadManager.PadButton.LEFT);
				this.filterSettingToggle.OnSelected(StPadManager.PadButton.LEFT);
			}
			else if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.RIGHT, StPadManager.Player.P1) || (vector.sqrMagnitude > 0.3f && Vector2.Angle(vector, Vector2.right) < 40f))
			{
				this.frameSettingToggle.OnSelected(StPadManager.PadButton.RIGHT);
				this.filterSettingToggle.OnSelected(StPadManager.PadButton.RIGHT);
			}
			else if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.POSITIVE, StPadManager.Player.P1))
			{
				this.frameSettingToggle.OnSelected(StPadManager.PadButton.POSITIVE);
				this.filterSettingToggle.OnSelected(StPadManager.PadButton.POSITIVE);
			}
			if ((SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.PLUS, StPadManager.Player.P1) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.MINUS, StPadManager.Player.P1)) && !this.isCloseStart)
			{
				this.CloseDialog();
				SoundManager.Instance.PlaySE("se_cancel", false);
			}
		}
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000B0B1 File Offset: 0x000092B1
	public void SaveSettings()
	{
		SaveDataManager.SaveIsEnableSettingFrame(SingletonData<CommonData>.Instance.isEnableSettingFrame, false);
		SaveDataManager.SaveIsEnableSettingFilter(SingletonData<CommonData>.Instance.isEnableSettingFilter, false);
		SaveDataManager.Save();
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000B0D8 File Offset: 0x000092D8
	private void Init()
	{
		bool flag = false;
		this.rankingObj.SetActive(flag);
		this.windowSettingObj.SetActive(true);
		this.exitObj.SetActive(true);
		if (flag)
		{
			RectTransform rectTransform = (RectTransform)this.contentsObj.transform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.y = 472f;
			rectTransform.sizeDelta = sizeDelta;
		}
		this.frameSettingToggle.Init(SingletonData<CommonData>.Instance.isEnableSettingFrame);
		this.filterSettingToggle.Init(SingletonData<CommonData>.Instance.isEnableSettingFilter);
		for (int i = 0; i < this.selectables.Length; i++)
		{
			EventTrigger eventTrigger = this.selectables[i].gameObject.AddComponent<EventTrigger>();
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
		}
		this.CallWaitForSecondsRealtime(0.3f, delegate
		{
			this.isInputStart = true;
		});
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000B1D8 File Offset: 0x000093D8
	public void CloseDialog()
	{
		if (this.isCloseStart)
		{
			return;
		}
		this.isCloseStart = true;
		this.SaveSettings();
		this.closeAnimation.closeAfterUnityEvent.AddListener(delegate
		{
			SingletonBehaviour<AppliArchive>.Instance.Resume();
		});
		this.closeAnimation.OnClose();
	}

	// Token: 0x040000B5 RID: 181
	[SerializeField]
	private SettingToggle frameSettingToggle;

	// Token: 0x040000B6 RID: 182
	[SerializeField]
	private SettingToggle filterSettingToggle;

	// Token: 0x040000B7 RID: 183
	[SerializeField]
	private Selectable[] selectables;

	// Token: 0x040000B8 RID: 184
	[SerializeField]
	private GameObject rankingObj;

	// Token: 0x040000B9 RID: 185
	[SerializeField]
	private GameObject windowSettingObj;

	// Token: 0x040000BA RID: 186
	[SerializeField]
	private GameObject exitObj;

	// Token: 0x040000BB RID: 187
	[SerializeField]
	private GameObject contentsObj;

	// Token: 0x040000BC RID: 188
	[SerializeField]
	private ButtonPopupCloseAnimation closeAnimation;

	// Token: 0x040000BD RID: 189
	private bool isFirstSelectionExecuted;

	// Token: 0x040000BE RID: 190
	private bool isInputStart;

	// Token: 0x040000BF RID: 191
	private bool isCloseStart;
}
