using System;
using System.Collections.Generic;
using Steezy.Utility;
using UnityEngine;

// Token: 0x0200004E RID: 78
public class SaveDataManager : SingletonBehaviour<SaveDataManager>
{
	// Token: 0x06000DA4 RID: 3492 RVA: 0x0010CFE8 File Offset: 0x0010B1E8
	public static void SaveRankingScoreDataMap(Dictionary<int, long> rankingScoreDataMap, bool isSave = true)
	{
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x0010CFEA File Offset: 0x0010B1EA
	public string MountName
	{
		get
		{
			return this.mountName;
		}
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x0010CFF2 File Offset: 0x0010B1F2
	private void OnDestroy()
	{
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x0010CFF4 File Offset: 0x0010B1F4
	public void Init()
	{
		Debug.Log("--- init save. ---");
		SaveDataManager.saveDataMap = new Dictionary<string, object>();
		SaveDataManager.Load();
		SaveDataManager.LoadAfterProcess();
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x0010D014 File Offset: 0x0010B214
	public static void ClearSave()
	{
		Debug.Log("--- clear save. ---");
		SaveDataManager.saveDataMap = new Dictionary<string, object>();
		PlayerPrefs.DeleteAll();
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x0010D02F File Offset: 0x0010B22F
	public static void Save()
	{
		Debug.Log("--- save start. ---");
		PlayerPrefsX.SetEncriptDictionary<string, object>("save", SaveDataManager.saveDataMap, "tTmMcxXvly1AEb1S");
		PlayerPrefs.Save();
		Debug.Log("--- save end. ---");
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x0010D060 File Offset: 0x0010B260
	private static void Load()
	{
		Debug.Log("--- load start. ---");
		SaveDataManager.saveDataMap = PlayerPrefsX.GetEncriptDictionary<string, object>("save", "tTmMcxXvly1AEb1S");
		if (SaveDataManager.saveDataMap == null)
		{
			Debug.LogWarning("no save data.");
			SaveDataManager.saveDataMap = new Dictionary<string, object>();
			return;
		}
		Debug.Log("--- load end. ---");
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x0010D0B1 File Offset: 0x0010B2B1
	public static T GetSaveData<T>(string key, T defaultValue = default(T))
	{
		if (SaveDataManager.saveDataMap.ContainsKey(key))
		{
			return (T)((object)SaveDataManager.saveDataMap[key]);
		}
		return defaultValue;
	}

	// Token: 0x06000DAC RID: 3500 RVA: 0x0010D0D2 File Offset: 0x0010B2D2
	public static void SetSaveData<T>(string key, T value)
	{
		SaveDataManager.saveDataMap[key] = value;
	}

	// Token: 0x06000DAD RID: 3501 RVA: 0x0010D0E5 File Offset: 0x0010B2E5
	public static void UpdateVersionProcess(string newClientVersion, string oldClientVersion)
	{
		Debug.Log("SaveDataManager.UpdateVersionProcess(). newClientVersion=" + newClientVersion + ", oldClientVersion=" + oldClientVersion);
	}

	// Token: 0x06000DAE RID: 3502 RVA: 0x0010D100 File Offset: 0x0010B300
	public static void LoadAfterProcess()
	{
		Debug.Log("SaveDataManager.LoadAfterProcess()");
		SaveDataManager.LoadRankingAfterProcess();
		bool saveData = SaveDataManager.GetSaveData<bool>("isEnableSettingFrame", true);
		SingletonData<CommonData>.Instance.isEnableSettingFrame = saveData;
		bool saveData2 = SaveDataManager.GetSaveData<bool>("isEnableSettingFilter", true);
		SingletonData<CommonData>.Instance.isEnableSettingFilter = saveData2;
		int saveData3 = SaveDataManager.GetSaveData<int>("windowMode", 0);
		SingletonData<CommonData>.Instance.windowMode = saveData3;
		int saveData4 = SaveDataManager.GetSaveData<int>("lastPlayApp", 0);
		SingletonData<CommonData>.Instance.lastLaunchApp = saveData4;
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x0010D178 File Offset: 0x0010B378
	private static void LoadRankingAfterProcess()
	{
	}

	// Token: 0x06000DB0 RID: 3504 RVA: 0x0010D17A File Offset: 0x0010B37A
	public static void SaveIsEnableSettingFrame(bool value, bool isSave = true)
	{
		SaveDataManager.SetSaveData<bool>("isEnableSettingFrame", value);
		if (isSave)
		{
			SaveDataManager.Save();
		}
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x0010D18F File Offset: 0x0010B38F
	public static void SaveIsEnableSettingFilter(bool value, bool isSave = true)
	{
		SaveDataManager.SetSaveData<bool>("isEnableSettingFilter", value);
		if (isSave)
		{
			SaveDataManager.Save();
		}
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x0010D1A4 File Offset: 0x0010B3A4
	public static void SaveWindowMode(int value, bool isSave = true)
	{
		SaveDataManager.SetSaveData<int>("windowMode", value);
		if (isSave)
		{
			SaveDataManager.Save();
		}
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x0010D1B9 File Offset: 0x0010B3B9
	public static void SaveLastPlayApp(int value, bool isSave = true)
	{
		SaveDataManager.SetSaveData<int>("lastPlayApp", value);
		if (isSave)
		{
			SaveDataManager.Save();
		}
	}

	// Token: 0x0400081B RID: 2075
	private const string PlayerPrefsSaveKey = "save";

	// Token: 0x0400081C RID: 2076
	private static Dictionary<string, object> saveDataMap = new Dictionary<string, object>();

	// Token: 0x0400081D RID: 2077
	[SerializeField]
	private string mountName;

	// Token: 0x0400081E RID: 2078
	private const string PlayerPrefsEncriptPassword = "tTmMcxXvly1AEb1S";

	// Token: 0x020001D8 RID: 472
	public class SaveKeyConst
	{
		// Token: 0x04001341 RID: 4929
		public const string SAVE_KEY_RANKING_SCORE_DATA_MAP = "rankingScoreDataMap";

		// Token: 0x04001342 RID: 4930
		public const string SAVE_KEY_IS_ENABLE_SETTING_FRAME = "isEnableSettingFrame";

		// Token: 0x04001343 RID: 4931
		public const string SAVE_KEY_IS_ENABLE_SETTING_FILTER = "isEnableSettingFilter";

		// Token: 0x04001344 RID: 4932
		public const string SAVE_KEY_WINDOW_MODE = "windowMode";

		// Token: 0x04001345 RID: 4933
		public const string SAVE_KEY_LAST_PLAY_APP = "lastPlayApp";
	}
}
