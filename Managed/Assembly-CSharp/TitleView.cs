using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Steezy.Sound;
using Steezy.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000024 RID: 36
public class TitleView : MonoBehaviour
{
	// Token: 0x060000A6 RID: 166 RVA: 0x0000B647 File Offset: 0x00009847
	private void Awake()
	{
		this.titleData = this.titleDataModel.GetTitleData();
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000B65A File Offset: 0x0000985A
	private void Start()
	{
		this.Init();
		base.StartCoroutine(this.SplashScreenWait(delegate
		{
			if (this.titleData.titleBgm != null)
			{
				SoundManager.Instance.LoadBGM(this.titleData.titleBgm, true);
				SoundManager.Instance.PlayBGM(this.titleData.titleBgm.name, true, 0f);
			}
		}));
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000B67B File Offset: 0x0000987B
	private IEnumerator SplashScreenWait(UnityAction callback)
	{
		while (!SplashScreen.isFinished)
		{
			yield return null;
		}
		callback.Invoke();
		yield break;
		yield break;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x0000B68C File Offset: 0x0000988C
	private void Init()
	{
		this.tilteNumberText.SetText(this.titleData.tilteNumber);
		this.tilteNameText.text = this.titleData.tilteName;
		this.aboutGameText.text = this.titleData.aboutGame;
		this.copyrightText.text = this.titleData.copyright;
		this.releaseDataText.text = this.titleData.releaseData;
		this.gameScreenShotImage.sprite = this.titleData.gameScreeShot;
		AppliSettingsDataModel.AppliStyle appliStyle = SingletonBehaviour<AppliArchive>.Instance.GetAppliSettingsDataModel().appliStyle;
		if (appliStyle == AppliSettingsDataModel.AppliStyle.GmodeArchives)
		{
			this.tilteNumberTextsParent.SetActive(true);
			if (this.titleData.arichivesLogoSprite != null)
			{
				this.archivesLogoImage.sprite = this.titleData.arichivesLogoSprite;
			}
		}
		else
		{
			this.tilteNumberTextsParent.SetActive(false);
			this.archivesLogoImage.sprite = this.titleData.arichivesPlusLogoSprite;
		}
		this.phoneBodyImage.sprite = SingletonBehaviour<TitleSpriteDatas>.Instance.GetPhoneBodySprite(appliStyle);
		this.phoneBodyImage.enabled = this.phoneBodyImage.sprite != null;
		this.phoneHilightImage.sprite = SingletonBehaviour<TitleSpriteDatas>.Instance.GetPhoneHilightSprite(appliStyle);
		this.phoneHilightImage.enabled = this.phoneHilightImage.sprite != null;
		this.titleNameImage.sprite = this.titleData.titleNameSprite;
		this.titleNameImage.enabled = this.titleNameImage.sprite != null;
		this.copyrightImage.sprite = this.titleData.copyrightSprite;
		this.copyrightImage.enabled = this.copyrightImage.sprite != null;
		this.appliSelectorObject.Init(SingletonBehaviour<AppliArchive>.Instance.AppliIndex);
		this.pressText.text = "Press Any Button";
		this.pressText.rectTransform.sizeDelta = new Vector2(260f, 36f);
		this.pressText.rectTransform.anchoredPosition = new Vector2(180f, 0f);
		this.pressKeyLImage.gameObject.SetActive(false);
		this.pressKeyRImage.gameObject.SetActive(false);
		this.pressPlusText.gameObject.SetActive(false);
		base.StartCoroutine(this.StartInput());
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0000B8F4 File Offset: 0x00009AF4
	private IEnumerator StartInput()
	{
		SingletonBehaviour<StPadManager>.Instance.StartLrAssignmentMode();
		for (;;)
		{
			StPadManager instance = SingletonBehaviour<StPadManager>.Instance;
			StPadManager.Player player = StPadManager.Player.P1;
			StPadManager.PadButton[] array = new StPadManager.PadButton[] { StPadManager.PadButton.ANY_BUTTON };
			KeyCode[] array2 = new KeyCode[4];
			RuntimeHelpers.InitializeArray(array2, fieldof(<PrivateImplementationDetails>.5C4907452777AFE9F9839E7FEA051FC9BC3E247A4AC4AE9AC82AA0EF8E8D40B9).FieldHandle);
			if (instance.AssignPlayer(player, array, array2))
			{
				break;
			}
			if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.LEFT, StPadManager.Player.P1))
			{
				if (SingletonBehaviour<AppliArchive>.Instance.AppliIndex > 1)
				{
					SingletonBehaviour<AppliArchive>.Instance.AppliIndex -= 2;
					this.appliSelectorObject.Select(SingletonBehaviour<AppliArchive>.Instance.AppliIndex);
				}
			}
			else if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.RIGHT, StPadManager.Player.P1))
			{
				if (SingletonBehaviour<AppliArchive>.Instance.AppliIndex < 4)
				{
					SingletonBehaviour<AppliArchive>.Instance.AppliIndex += 2;
					this.appliSelectorObject.Select(SingletonBehaviour<AppliArchive>.Instance.AppliIndex);
				}
			}
			else if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.UP, StPadManager.Player.P1))
			{
				if (SingletonBehaviour<AppliArchive>.Instance.AppliIndex > 0)
				{
					AppliArchive instance2 = SingletonBehaviour<AppliArchive>.Instance;
					int num = instance2.AppliIndex;
					instance2.AppliIndex = num - 1;
					this.appliSelectorObject.Select(SingletonBehaviour<AppliArchive>.Instance.AppliIndex);
				}
			}
			else if (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.DOWN, StPadManager.Player.P1) && SingletonBehaviour<AppliArchive>.Instance.AppliIndex < 5)
			{
				AppliArchive instance3 = SingletonBehaviour<AppliArchive>.Instance;
				int num = instance3.AppliIndex;
				instance3.AppliIndex = num + 1;
				this.appliSelectorObject.Select(SingletonBehaviour<AppliArchive>.Instance.AppliIndex);
			}
			yield return null;
		}
		SingletonBehaviour<StPadManager>.Instance.StopLrAssignmentMode();
		this.titleTransitionAnimator.enabled = true;
		this.titleTransitionAnimator.Play("TitleTransitionAnimForPC");
		SoundManager.Instance.PlaySE("se_decision2", false);
		yield return new WaitForSeconds(this.titleTransitionDelay);
		SoundManager.Instance.PlayBGMFadeOut(0.5f);
		SingletonBehaviour<AppliArchive>.Instance.ChangeState(AppliArchive.State.GAME);
		yield break;
	}

	// Token: 0x040000D3 RID: 211
	[SerializeField]
	private TitleDataModel titleDataModel;

	// Token: 0x040000D4 RID: 212
	[SerializeField]
	private GameObject tilteNumberTextsParent;

	// Token: 0x040000D5 RID: 213
	[SerializeField]
	private TextMeshProUGUI tilteNumberText;

	// Token: 0x040000D6 RID: 214
	[SerializeField]
	private Text tilteNameText;

	// Token: 0x040000D7 RID: 215
	[SerializeField]
	private Text aboutGameText;

	// Token: 0x040000D8 RID: 216
	[SerializeField]
	private Text copyrightText;

	// Token: 0x040000D9 RID: 217
	[SerializeField]
	private TextMeshProUGUI releaseDataText;

	// Token: 0x040000DA RID: 218
	[SerializeField]
	private Image gameScreenShotImage;

	// Token: 0x040000DB RID: 219
	[SerializeField]
	private Image archivesLogoImage;

	// Token: 0x040000DC RID: 220
	[SerializeField]
	private Image phoneBodyImage;

	// Token: 0x040000DD RID: 221
	[SerializeField]
	private Image phoneHilightImage;

	// Token: 0x040000DE RID: 222
	[SerializeField]
	private Image titleNameImage;

	// Token: 0x040000DF RID: 223
	[SerializeField]
	private Image copyrightImage;

	// Token: 0x040000E0 RID: 224
	[SerializeField]
	private Text pressText;

	// Token: 0x040000E1 RID: 225
	[SerializeField]
	private Image pressKeyLImage;

	// Token: 0x040000E2 RID: 226
	[SerializeField]
	private Image pressKeyRImage;

	// Token: 0x040000E3 RID: 227
	[SerializeField]
	private Text pressPlusText;

	// Token: 0x040000E4 RID: 228
	[SerializeField]
	private Animator titleTransitionAnimator;

	// Token: 0x040000E5 RID: 229
	[SerializeField]
	private float titleTransitionDelay = 1f;

	// Token: 0x040000E6 RID: 230
	[SerializeField]
	private AppliSelectorObject appliSelectorObject;

	// Token: 0x040000E7 RID: 231
	private TitleDataModel.TitleData titleData;
}
