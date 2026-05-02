using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000052 RID: 82
public class AppliArchiveCharacterInputManager : SingletonBehaviour<AppliArchiveCharacterInputManager>
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x0010D4AA File Offset: 0x0010B6AA
	public string ResultString
	{
		get
		{
			return this.resultString;
		}
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x0010D4B2 File Offset: 0x0010B6B2
	private void LateUpdate()
	{
		if (this.isShowDialog)
		{
			this.isShowDialog = false;
			this.ShowCharacterInputDialogAndPause(this.maxLength, this.message, this.onChangeCallback, this.defaultString);
		}
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x0010D4E1 File Offset: 0x0010B6E1
	public void ShowCharacterInputDialog(int maxLength = 8, string message = "文字を入力してください", UnityAction<string> onChangeCallback = null, string defaultString = "")
	{
		this.maxLength = maxLength;
		this.message = message;
		this.onChangeCallback = onChangeCallback;
		this.defaultString = defaultString;
		this.isShowDialog = true;
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x0010D508 File Offset: 0x0010B708
	private void ShowCharacterInputDialogAndPause(int maxLength = 8, string message = "文字を入力してください", UnityAction<string> onChangeCallback = null, string defaultString = "")
	{
		this.resultString = "";
		this.isClose = false;
		SingletonBehaviour<AppliArchive>.Instance.Pause(null);
		UnityAction<string> <>9__1;
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("CharacterInput", delegate(GameObject popupObj)
		{
			CharacterInputDialog component = popupObj.GetComponent<CharacterInputDialog>();
			int num = maxLength;
			string text = message;
			string text2 = defaultString;
			UnityAction<string> unityAction;
			if ((unityAction = <>9__1) == null)
			{
				unityAction = (<>9__1 = delegate(string result)
				{
					this.resultString = result;
					this.isClose = true;
					if (onChangeCallback != null)
					{
						onChangeCallback.Invoke(result);
					}
					this.CallWaitForEndOfFrame(delegate
					{
						SingletonBehaviour<AppliArchive>.Instance.Resume();
					});
				});
			}
			component.Init(num, text, text2, unityAction);
		}, true);
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x0010D578 File Offset: 0x0010B778
	public bool IsClose()
	{
		return this.isClose && !SingletonBehaviour<AppliArchivePrefabManager>.Instance.HasPopup("CharacterInput");
	}

	// Token: 0x04000825 RID: 2085
	public const int DefaultMaxCaracterLength = 8;

	// Token: 0x04000826 RID: 2086
	public const string DefaultInputMessage = "文字を入力してください";

	// Token: 0x04000827 RID: 2087
	private string resultString = "";

	// Token: 0x04000828 RID: 2088
	private bool isClose = true;

	// Token: 0x04000829 RID: 2089
	private bool isShowDialog;

	// Token: 0x0400082A RID: 2090
	private int maxLength;

	// Token: 0x0400082B RID: 2091
	private string message;

	// Token: 0x0400082C RID: 2092
	private UnityAction<string> onChangeCallback;

	// Token: 0x0400082D RID: 2093
	private string defaultString;
}
