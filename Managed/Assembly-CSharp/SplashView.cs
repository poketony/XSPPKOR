using System;
using System.Collections;
using Steezy.Fade;
using Steezy.Utility;
using UnityEngine;

// Token: 0x02000021 RID: 33
public class SplashView : MonoBehaviour
{
	// Token: 0x0600009B RID: 155 RVA: 0x0000B534 File Offset: 0x00009734
	private void Awake()
	{
		this.splashAnmationParent.SetActive(false);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000B542 File Offset: 0x00009742
	private void Start()
	{
		base.StartCoroutine(this.Init());
		base.StartCoroutine(this.StartInput());
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000B55E File Offset: 0x0000975E
	private IEnumerator Init()
	{
		FadeManager.Instance.ImmidiateFade(FadeManager.FadeType.Out);
		yield return new WaitForSeconds(1f);
		FadeManager.Instance.PlayAll(FadeManager.FadeType.In, 0.2f);
		this.splashAnmationParent.SetActive(true);
		yield return new WaitForSeconds(this.viewTime);
		this.NextScreen();
		yield break;
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000B56D File Offset: 0x0000976D
	private IEnumerator StartInput()
	{
		while (!Application.isEditor || (!SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.ANY_BUTTON, StPadManager.Player.P1) && !SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.L, StPadManager.Player.P1) && !SingletonBehaviour<StPadManager>.Instance.GetButton(StPadManager.PadButton.R, StPadManager.Player.P1) && !Input.GetMouseButtonDown(0)))
		{
			yield return null;
		}
		this.NextScreen();
		yield break;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000B57C File Offset: 0x0000977C
	private void NextScreen()
	{
		if (this.isNextScreen)
		{
			return;
		}
		this.isNextScreen = true;
		FadeManager.Instance.FadeOutAfter += delegate
		{
			SingletonBehaviour<AppliArchive>.Instance.ChangeState(AppliArchive.State.TITLE);
		};
		FadeManager.Instance.PlayAll(FadeManager.FadeType.Out, 0.2f);
	}

	// Token: 0x040000CC RID: 204
	[SerializeField]
	private float viewTime = 4f;

	// Token: 0x040000CD RID: 205
	[SerializeField]
	private GameObject splashAnmationParent;

	// Token: 0x040000CE RID: 206
	private bool isNextScreen;
}
