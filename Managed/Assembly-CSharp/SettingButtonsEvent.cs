using System;
using Socotra.UI;
using Steezy.Fade;
using Steezy.Localize;
using Steezy.PageFlow;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class SettingButtonsEvent : SimpleBaseButton
{
	// Token: 0x0600007E RID: 126 RVA: 0x0000AD84 File Offset: 0x00008F84
	public void OnClickHowToPlay()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("HowToPlay", delegate(GameObject popupObj)
			{
				popupObj.GetComponent<HowToPlayDialog>().Init(delegate
				{
					SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Setting", null, true);
				}, false);
			}, true);
		}, true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
			SingletonBehaviour<SettingDialog>.Instance.SaveSettings();
		}
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000ADE8 File Offset: 0x00008FE8
	public void OnClickWindow()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Window", null, true);
		}, true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
			SingletonBehaviour<SettingDialog>.Instance.SaveSettings();
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x0000AE4C File Offset: 0x0000904C
	public void OnClickRanking()
	{
	}

	// Token: 0x06000081 RID: 129 RVA: 0x0000AE50 File Offset: 0x00009050
	public void OnClickBackToTitle()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("DialogCommon", delegate(GameObject popupObj)
			{
				CommonDialog commonDialog = popupObj.GetComponent<CommonDialog>();
				commonDialog.Init(Localization.Get("common_dialog_titlescreen_msg"), delegate
				{
					SingletonData<CommonData>.Instance.enableWaitingForPauseInput = false;
					commonDialog.CloseDialog(delegate
					{
						FadeManager.Instance.FadeOutAfter += delegate
						{
							SingletonBehaviour<AppliArchive>.Instance.Resume();
							StApplication stApplication = Object.FindObjectOfType<StApplication>();
							if (stApplication != null)
							{
								stApplication.Terminate();
							}
						};
						FadeManager.Instance.PlayAll(FadeManager.FadeType.Out, 0.5f);
					});
				}, delegate
				{
					SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Setting", null, true);
				});
			}, true);
		}, true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
			SingletonBehaviour<SettingDialog>.Instance.SaveSettings();
		}
	}

	// Token: 0x06000082 RID: 130 RVA: 0x0000AEB4 File Offset: 0x000090B4
	public void OnClickExit()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("DialogCommon", delegate(GameObject popupObj)
			{
				CommonDialog commonDialog = popupObj.GetComponent<CommonDialog>();
				commonDialog.Init(Localization.Get("common_dialog_exit_game_msg"), delegate
				{
					SingletonData<CommonData>.Instance.enableWaitingForPauseInput = false;
					commonDialog.CloseDialog(delegate
					{
						FadeManager.Instance.FadeOutAfter += delegate
						{
							SingletonBehaviour<AppliArchive>.Instance.Resume();
							Application.Quit();
						};
						FadeManager.Instance.PlayAll(FadeManager.FadeType.Out, 0.5f);
					});
				}, delegate
				{
					SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Setting", null, true);
				});
			}, true);
		}, true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
			SingletonBehaviour<SettingDialog>.Instance.SaveSettings();
		}
	}

	// Token: 0x06000083 RID: 131 RVA: 0x0000AF18 File Offset: 0x00009118
	public void OnClickClose()
	{
		if (base.CheckTransitionAndExecute(delegate
		{
			SingletonBehaviour<SettingDialog>.Instance.CloseDialog();
		}, false, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
		}
	}
}
