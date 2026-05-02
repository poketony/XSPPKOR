using System;
using System.Collections;
using System.Collections.Generic;
using Socotra;
using Socotra.UI;
using Steamworks;
using Steezy.Fade;
using Steezy.PageFlow;
using Steezy.Sound;
using Steezy.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000040 RID: 64
public class AppliArchive : SingletonBehaviour<AppliArchive>
{
	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000D32 RID: 3378 RVA: 0x0010A915 File Offset: 0x00108B15
	// (set) Token: 0x06000D33 RID: 3379 RVA: 0x0010A91D File Offset: 0x00108B1D
	public int AppliIndex { get; set; }

	// Token: 0x06000D34 RID: 3380 RVA: 0x0010A926 File Offset: 0x00108B26
	private void Awake()
	{
		this.backGroundUI.SetActive(false);
		this.phoneFrameUI.SetActive(false);
		this.launchParams = null;
		this.keyGuideUI.SetActive(false);
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x0010A953 File Offset: 0x00108B53
	private void Start()
	{
		Cursor.visible = false;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		if (SteamManager.Initialized)
		{
			SteamAPI.Init();
			SteamInput.Init(true);
		}
		this.Init();
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x0010A984 File Offset: 0x00108B84
	private void Update()
	{
		if (SingletonData<CommonData>.Instance.enableWaitingForPauseInput && (SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.PLUS, StPadManager.Player.P1) || SingletonBehaviour<StPadManager>.Instance.GetButtonDown(StPadManager.PadButton.MINUS, StPadManager.Player.P1)))
		{
			this.Pause(delegate
			{
				SoundManager.Instance.PlaySE("se_decision", false);
			});
		}
		this.ClockUpdate();
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x0010A9EC File Offset: 0x00108BEC
	private void Init()
	{
		SingletonData<LocalizeSettings>.Instance.SetLocalizeLanguage();
		SingletonBehaviour<SaveDataManager>.Instance.Init();
		switch (SingletonData<CommonData>.Instance.windowMode)
		{
		case 0:
			Screen.SetResolution(1920, 1080, true);
			break;
		case 1:
			Screen.SetResolution(1920, 1080, false);
			break;
		case 2:
			Screen.SetResolution(1600, 900, false);
			break;
		case 3:
			Screen.SetResolution(1440, 810, false);
			break;
		case 4:
			Screen.SetResolution(1280, 720, false);
			break;
		case 5:
			Screen.SetResolution(960, 540, false);
			break;
		}
		this.ChangeState(AppliArchive.State.SPLASH);
		this.isFinishedResourceCache = false;
		this.ResourceCache(delegate
		{
			this.isFinishedResourceCache = true;
		});
		Time.timeScale = SingletonData<CommonData>.Instance.timeScale;
		this.AppliIndex = SingletonData<CommonData>.Instance.lastLaunchApp;
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x0010AAE4 File Offset: 0x00108CE4
	private void ClockUpdate()
	{
		this.clock.text = DateTime.Now.ToString("HH:mm");
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x0010AB10 File Offset: 0x00108D10
	public void ChangeFullScreen()
	{
		this.fullSizeScreen.SetActive(true);
		this.phoneSizeScreen.SetActive(false);
		this.phoneFrameUI.SetActive(false);
		SingletonBehaviour<VideoScreenManager>.Instance.ChangeVideoScreenSize(true);
		SingletonBehaviour<StDisplay>.Instance.SetTargetRenderer(this.fullSizeScreen.GetComponent<Renderer>());
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x0010AB64 File Offset: 0x00108D64
	public void ChangePhoneScreen()
	{
		this.fullSizeScreen.SetActive(false);
		this.phoneFrameUI.SetActive(true);
		this.phoneSizeScreen.SetActive(true);
		SingletonBehaviour<VideoScreenManager>.Instance.ChangeVideoScreenSize(false);
		SingletonBehaviour<StDisplay>.Instance.SetTargetRenderer(this.phoneSizeScreen.GetComponent<Renderer>());
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x0010ABB5 File Offset: 0x00108DB5
	public void Pause(UnityAction action = null)
	{
		if (SingletonBehaviour<AppliArchivePrefabManager>.Instance.HasPopup())
		{
			return;
		}
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Setting", null, true);
		SingletonBehaviour<StApplicationManager>.Instance.Suspend();
		if (action != null)
		{
			action.Invoke();
		}
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x0010ABE8 File Offset: 0x00108DE8
	public void Resume()
	{
		SingletonBehaviour<StApplicationManager>.Instance.Resume();
		SingletonBehaviour<StDisplay>.Instance.UpdateKeypadState();
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x0010AC00 File Offset: 0x00108E00
	public void ChangeState(AppliArchive.State next)
	{
		switch (next)
		{
		case AppliArchive.State.SPLASH:
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Splash", null, true);
			break;
		case AppliArchive.State.TITLE:
			SingletonData<CommonData>.Instance.enableWaitingForPauseInput = false;
			this.ScreenClear();
			FadeManager.Instance.ImmidiateFade(FadeManager.FadeType.Out);
			SingletonBehaviour<AppliArchivePrefabManager>.Instance.CreatePopupAsync("Title", delegate(GameObject obj)
			{
				FadeManager.Instance.PlayAll(FadeManager.FadeType.In, 0.2f);
			}, true);
			this.loadingUI.SetActive(false);
			this.fullSizeScreen.SetActive(false);
			this.phoneSizeScreen.SetActive(false);
			this.phoneFrameUI.SetActive(false);
			this.pauseUI.SetActive(false);
			this.autoSaveDescriptionUI.SetActive(false);
			this.backGroundUI.SetActive(true);
			break;
		case AppliArchive.State.GAME:
			FadeManager.Instance.FadeOutAfter += delegate
			{
				Resources.UnloadUnusedAssets();
				base.StartCoroutine(this.WaitResourceChacheCoroutine(delegate
				{
					FadeManager.Instance.ImmidiateFade(FadeManager.FadeType.In);
					this.ScreenClear();
					this.loadingUI.SetActive(true);
					float autoSaveDescriptionWaitStartTime = 0f;
					if (this.GetAppliSettingsDataModel().showAutoSaveDescription)
					{
						this.autoSaveDescriptionUI.SetActive(true);
						autoSaveDescriptionWaitStartTime = Time.time;
					}
					Debug.Log("Load AssetBundle Start ");
					base.StartCoroutine(AssetLoadUtil.LoadAssetAsync<GameObject>("Prefab/" + this.prefabName + ".prefab", delegate(GameObject obj)
					{
						Action action = delegate
						{
							this.currentPrefab = Object.Instantiate<GameObject>(obj);
							Debug.Log("Load AssetBundle End");
							this.loadingUI.SetActive(false);
							this.phoneSizeScreen.SetActive(true);
							this.fullSizeScreen.SetActive(false);
							this.phoneFrameUI.SetActive(true);
							this.pauseUI.SetActive(true);
							this.autoSaveDescriptionUI.SetActive(false);
							SingletonBehaviour<StDisplay>.Instance.SetTargetRenderer(this.phoneSizeScreen.GetComponent<Renderer>());
							SingletonBehaviour<StDisplay>.Instance.SetFiltering(SingletonData<CommonData>.Instance.isEnableSettingFilter);
							if (SingletonData<CommonData>.Instance.isEnableSettingFrame)
							{
								SingletonBehaviour<AppliArchive>.Instance.ChangePhoneScreen();
							}
							else
							{
								SingletonBehaviour<AppliArchive>.Instance.ChangeFullScreen();
							}
							SingletonBehaviour<StApplicationManager>.Instance.SetCurrentAppIndex(this.AppliIndex);
							if (this.launchParams != null)
							{
								SingletonBehaviour<StApplicationManager>.Instance.LaunchParams = this.launchParams;
								this.launchParams = null;
							}
							SaveDataManager.SaveLastPlayApp(this.AppliIndex, true);
							SingletonData<CommonData>.Instance.enableWaitingForPauseInput = true;
						};
						float num = 2.5f - (Time.time - autoSaveDescriptionWaitStartTime);
						if (num > 0f)
						{
							this.CallWaitForSeconds(num, action);
							return;
						}
						action();
					}));
				}));
			};
			FadeManager.Instance.PlayAll(FadeManager.FadeType.Out, 0.5f);
			break;
		}
		this.current = next;
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x0010AD0A File Offset: 0x00108F0A
	private IEnumerator WaitResourceChacheCoroutine(UnityAction callback)
	{
		while (!this.isFinishedResourceCache)
		{
			yield return null;
		}
		callback.Invoke();
		yield break;
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x0010AD20 File Offset: 0x00108F20
	private void ScreenClear()
	{
		if (this.currentPrefab != null)
		{
			Object.Destroy(this.currentPrefab);
		}
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.ClearPopup();
		Resources.UnloadUnusedAssets();
		this.currentPrefab = null;
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x0010AD52 File Offset: 0x00108F52
	private void ResourceCache(UnityAction callback)
	{
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.InitPopupCache(callback, new string[] { "Setting", "HowToPlay", "Ranking", "DialogCommon", "CharacterInput" });
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x0010AD8D File Offset: 0x00108F8D
	public AppliSettingsDataModel GetAppliSettingsDataModel()
	{
		return this.appliSettingsDataModel;
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0010AD95 File Offset: 0x00108F95
	public void Relaunch(int appindex, Dictionary<string, string> launchparams)
	{
		this.launchParams = launchparams;
		this.AppliIndex = appindex;
		this.ChangeState(AppliArchive.State.GAME);
	}

	// Token: 0x040007EB RID: 2027
	private const float AutoSaveDescriptionShowMinTime = 2.5f;

	// Token: 0x040007EC RID: 2028
	[SerializeField]
	private AppliSettingsDataModel appliSettingsDataModel;

	// Token: 0x040007ED RID: 2029
	[SerializeField]
	private GameObject loadingUI;

	// Token: 0x040007EE RID: 2030
	[SerializeField]
	private GameObject backGroundUI;

	// Token: 0x040007EF RID: 2031
	[SerializeField]
	private GameObject phoneFrameUI;

	// Token: 0x040007F0 RID: 2032
	[SerializeField]
	private GameObject pauseUI;

	// Token: 0x040007F1 RID: 2033
	[SerializeField]
	private GameObject autoSaveDescriptionUI;

	// Token: 0x040007F2 RID: 2034
	[SerializeField]
	private GameObject keyGuideUI;

	// Token: 0x040007F3 RID: 2035
	[SerializeField]
	private GameObject fullSizeScreen;

	// Token: 0x040007F4 RID: 2036
	[SerializeField]
	private GameObject phoneSizeScreen;

	// Token: 0x040007F5 RID: 2037
	[SerializeField]
	private TextMeshProUGUI clock;

	// Token: 0x040007F6 RID: 2038
	[SerializeField]
	private string prefabName;

	// Token: 0x040007F7 RID: 2039
	private GameObject currentPrefab;

	// Token: 0x040007F8 RID: 2040
	private AppliArchive.State current;

	// Token: 0x040007F9 RID: 2041
	private bool isPaused;

	// Token: 0x040007FA RID: 2042
	private bool isFilter = true;

	// Token: 0x040007FB RID: 2043
	private int ScreenMode;

	// Token: 0x040007FC RID: 2044
	private bool isFinishedResourceCache;

	// Token: 0x040007FE RID: 2046
	private Dictionary<string, string> launchParams;

	// Token: 0x020001C9 RID: 457
	public enum State
	{
		// Token: 0x0400130B RID: 4875
		NONE,
		// Token: 0x0400130C RID: 4876
		SPLASH,
		// Token: 0x0400130D RID: 4877
		TITLE,
		// Token: 0x0400130E RID: 4878
		GAME
	}
}
