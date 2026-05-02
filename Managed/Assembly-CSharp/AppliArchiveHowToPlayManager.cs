using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000053 RID: 83
public class AppliArchiveHowToPlayManager : SingletonBehaviour<AppliArchiveHowToPlayManager>
{
	// Token: 0x06000DDB RID: 3547 RVA: 0x0010D5B0 File Offset: 0x0010B7B0
	private void LateUpdate()
	{
		if (this.isShowDialog)
		{
			this.isShowDialog = false;
			this.ShowHowToPlayDialogAndPause(this.onCloseCallback);
		}
	}

	// Token: 0x06000DDC RID: 3548 RVA: 0x0010D5CD File Offset: 0x0010B7CD
	public void ShowHowToPlayDialog(UnityAction onCloseCallback = null)
	{
		this.onCloseCallback = onCloseCallback;
		this.isShowDialog = true;
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x0010D5E0 File Offset: 0x0010B7E0
	private void ShowHowToPlayDialogAndPause(UnityAction onCloseCallback = null)
	{
		SingletonBehaviour<AppliArchive>.Instance.Pause(null);
		UnityAction <>9__1;
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("HowToPlay", delegate(GameObject popupObj)
		{
			HowToPlayDialog component = popupObj.GetComponent<HowToPlayDialog>();
			UnityAction unityAction;
			if ((unityAction = <>9__1) == null)
			{
				unityAction = (<>9__1 = delegate
				{
					SingletonBehaviour<AppliArchive>.Instance.Resume();
					if (onCloseCallback != null)
					{
						onCloseCallback.Invoke();
					}
				});
			}
			component.Init(unityAction, true);
		}, true);
	}

	// Token: 0x0400082E RID: 2094
	private bool isShowDialog;

	// Token: 0x0400082F RID: 2095
	private UnityAction onCloseCallback;
}
