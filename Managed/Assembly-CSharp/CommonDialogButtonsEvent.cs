using System;
using Steezy.PageFlow;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200000E RID: 14
public class CommonDialogButtonsEvent : SimpleBaseButton
{
	// Token: 0x06000053 RID: 83 RVA: 0x0000A66C File Offset: 0x0000886C
	public void OnClickYes()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			if (!SingletonBehaviour<CommonDialog>.Instance)
			{
				return;
			}
			UnityAction yesButtonClickCallback = SingletonBehaviour<CommonDialog>.Instance.YesButtonClickCallback;
			if (yesButtonClickCallback != null)
			{
				yesButtonClickCallback.Invoke();
			}
		}, true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x0000A6C8 File Offset: 0x000088C8
	public void OnClickNo()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			if (!SingletonBehaviour<CommonDialog>.Instance)
			{
				return;
			}
			UnityAction noButtonClickCallback = SingletonBehaviour<CommonDialog>.Instance.NoButtonClickCallback;
			if (noButtonClickCallback != null)
			{
				noButtonClickCallback.Invoke();
			}
		}, true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_cancel", false);
			base.GetComponent<Animator>().Play("Pressed");
		}
	}
}
