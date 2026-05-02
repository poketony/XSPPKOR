using System;
using System.Collections.Generic;
using Steezy.Sound;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

// Token: 0x02000020 RID: 32
[RequireComponent(typeof(Selectable), typeof(SettingAction))]
public class SettingToggle : MonoBehaviour
{
	// Token: 0x06000095 RID: 149 RVA: 0x0000B2D8 File Offset: 0x000094D8
	public void Init(bool toggleStatus)
	{
		this.status = toggleStatus;
		this.SetToggleStatus(true);
		EventTrigger eventTrigger = base.gameObject.AddComponent<EventTrigger>();
		eventTrigger.triggers = new List<EventTrigger.Entry>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = 9;
		entry.callback.AddListener(delegate(BaseEventData x)
		{
			this.isSelect = true;
			this.SetToggleStatus(false);
		});
		eventTrigger.triggers.Add(entry);
		entry = new EventTrigger.Entry();
		entry.eventID = 10;
		entry.callback.AddListener(delegate(BaseEventData x)
		{
			this.isSelect = false;
			this.SetToggleStatus(false);
		});
		eventTrigger.triggers.Add(entry);
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000B36C File Offset: 0x0000956C
	private void SetToggleStatus(bool isPlaySe = true)
	{
		this.settingOnActiveObj.SetActive(this.status);
		this.settingOnInactiveObj.SetActive(!this.status);
		this.settingOffActiveObj.SetActive(!this.status);
		this.settingOffInactiveObj.SetActive(this.status);
		this.settingOnFocusObj.SetActive(this.isSelect);
		this.settingOnFocusInvisibleObj.SetActive(!this.isSelect);
		this.settingOffFocusObj.SetActive(this.isSelect);
		this.settingOffFocusInvisibleObj.SetActive(!this.isSelect);
		if (this.isSelect)
		{
			if (isPlaySe)
			{
				SoundManager.Instance.PlaySE("se_cursol", false);
			}
			if (this.status)
			{
				foreach (Tweener tweener in this.settingOnFocusObj.GetComponents<Tweener>())
				{
					tweener.ResetToBeginning();
					tweener.PlayForward();
				}
				return;
			}
			foreach (Tweener tweener2 in this.settingOffFocusObj.GetComponents<Tweener>())
			{
				tweener2.ResetToBeginning();
				tweener2.PlayForward();
			}
		}
	}

	// Token: 0x06000097 RID: 151 RVA: 0x0000B484 File Offset: 0x00009684
	public void OnSelected(StPadManager.PadButton button)
	{
		if (!this.isSelect)
		{
			return;
		}
		if (button == StPadManager.PadButton.POSITIVE)
		{
			this.status = !this.status;
		}
		else if (button == StPadManager.PadButton.LEFT)
		{
			if (this.status)
			{
				return;
			}
			this.status = true;
		}
		else if (button == StPadManager.PadButton.RIGHT)
		{
			if (!this.status)
			{
				return;
			}
			this.status = false;
		}
		this.SetToggleStatus(true);
		SettingAction component = base.GetComponent<SettingAction>();
		if (component)
		{
			component.Action(this.status ? 1 : 0);
		}
	}

	// Token: 0x040000C0 RID: 192
	[SerializeField]
	private GameObject settingOnActiveObj;

	// Token: 0x040000C1 RID: 193
	[SerializeField]
	private GameObject settingOnInactiveObj;

	// Token: 0x040000C2 RID: 194
	[SerializeField]
	private GameObject settingOnFocusObj;

	// Token: 0x040000C3 RID: 195
	[SerializeField]
	private GameObject settingOnFocusInvisibleObj;

	// Token: 0x040000C4 RID: 196
	[SerializeField]
	private GameObject settingOffActiveObj;

	// Token: 0x040000C5 RID: 197
	[SerializeField]
	private GameObject settingOffInactiveObj;

	// Token: 0x040000C6 RID: 198
	[SerializeField]
	private GameObject settingOffFocusObj;

	// Token: 0x040000C7 RID: 199
	[SerializeField]
	private GameObject settingOffFocusInvisibleObj;

	// Token: 0x040000C8 RID: 200
	[SerializeField]
	private Toggle settingOn;

	// Token: 0x040000C9 RID: 201
	[SerializeField]
	private Toggle settingOff;

	// Token: 0x040000CA RID: 202
	private bool status = true;

	// Token: 0x040000CB RID: 203
	private bool isSelect;
}
