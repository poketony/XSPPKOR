using System;
using System.Collections.Generic;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000009 RID: 9
public class CharacterInputKeyItem : MonoBehaviour
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000029 RID: 41 RVA: 0x00002BD3 File Offset: 0x00000DD3
	public bool IsSelect
	{
		get
		{
			return this.isSelect;
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002BDC File Offset: 0x00000DDC
	public void Init(string keyString, UnityAction<string> onInputAction, bool selected = false, bool isEnableNavigation = true, string submitSeName = "se_decision")
	{
		this.keyString = keyString;
		this.onInputAction = onInputAction;
		this.submitSeName = submitSeName;
		this.keyText.text = keyString;
		if (selected)
		{
			this.button.Select();
		}
		if (string.IsNullOrEmpty(keyString) || !isEnableNavigation)
		{
			Navigation navigation = this.button.navigation;
			navigation.mode = 0;
			this.button.navigation = navigation;
		}
		else
		{
			Navigation navigation2 = this.button.navigation;
			navigation2.mode = 3;
			this.button.navigation = navigation2;
		}
		if (this.currentTrigger == null)
		{
			this.currentTrigger = this.button.gameObject.AddComponent<EventTrigger>();
			this.currentTrigger.triggers = new List<EventTrigger.Entry>();
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = 8;
			entry.callback.AddListener(delegate(BaseEventData x)
			{
				this.isSelect = true;
			});
			this.currentTrigger.triggers.Add(entry);
			entry = new EventTrigger.Entry();
			entry.eventID = 10;
			entry.callback.AddListener(delegate(BaseEventData x)
			{
				this.isSelect = false;
			});
			this.currentTrigger.triggers.Add(entry);
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002D09 File Offset: 0x00000F09
	public void OnClick()
	{
		if (!SingletonBehaviour<CharacterInputDialog>.Instance.IsInputStart)
		{
			return;
		}
		SoundManager.Instance.PlaySE(this.submitSeName, false);
		this.onInputAction.Invoke(this.keyString);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002D3A File Offset: 0x00000F3A
	public void SetSelectablePosition(CharacterInputKeyItem.Direction selectablePosition)
	{
		this.selectablePosition = selectablePosition;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002D43 File Offset: 0x00000F43
	public bool IsLoopNavigation(CharacterInputKeyItem.Direction inputDirection)
	{
		return this.selectablePosition.HasFlag(inputDirection);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002D5B File Offset: 0x00000F5B
	public Selectable GetSelectable()
	{
		return this.button;
	}

	// Token: 0x0400002F RID: 47
	[SerializeField]
	private Text keyText;

	// Token: 0x04000030 RID: 48
	[SerializeField]
	private Button button;

	// Token: 0x04000031 RID: 49
	private string keyString;

	// Token: 0x04000032 RID: 50
	private UnityAction<string> onInputAction;

	// Token: 0x04000033 RID: 51
	private string submitSeName;

	// Token: 0x04000034 RID: 52
	private CharacterInputKeyItem.Direction selectablePosition;

	// Token: 0x04000035 RID: 53
	private bool isSelect;

	// Token: 0x04000036 RID: 54
	private EventTrigger currentTrigger;

	// Token: 0x020001AF RID: 431
	[Flags]
	public enum Direction
	{
		// Token: 0x040012B2 RID: 4786
		None = 1,
		// Token: 0x040012B3 RID: 4787
		Upper = 2,
		// Token: 0x040012B4 RID: 4788
		Lower = 4,
		// Token: 0x040012B5 RID: 4789
		Left = 8,
		// Token: 0x040012B6 RID: 4790
		Right = 16
	}
}
