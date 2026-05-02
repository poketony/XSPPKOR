using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Localize
{
	// Token: 0x020000D1 RID: 209
	public class Localization : MonoBehaviour
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06001257 RID: 4695 RVA: 0x0011DCC0 File Offset: 0x0011BEC0
		public static Dictionary<string, string[]> dictionary
		{
			get
			{
				if (!Localization.localizationHasBeenSet)
				{
					Localization.language = Localization.startingLanguage;
				}
				return Localization.mDictionary;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06001258 RID: 4696 RVA: 0x0011DCD8 File Offset: 0x0011BED8
		public static bool isActive
		{
			get
			{
				return Localization.mInstance != null;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06001259 RID: 4697 RVA: 0x0011DCE8 File Offset: 0x0011BEE8
		public static Localization instance
		{
			get
			{
				if (Localization.mInstance == null)
				{
					Localization.mInstance = Object.FindObjectOfType(typeof(Localization)) as Localization;
					if (Localization.mInstance == null)
					{
						GameObject gameObject = new GameObject("_Localization");
						Object.DontDestroyOnLoad(gameObject);
						Localization.mInstance = gameObject.AddComponent<Localization>();
					}
				}
				return Localization.mInstance;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600125A RID: 4698 RVA: 0x0011DD47 File Offset: 0x0011BF47
		public static int LaunguageIndex
		{
			get
			{
				return Localization.mLanguageIndex;
			}
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x0011DD4E File Offset: 0x0011BF4E
		private void Awake()
		{
			if (Localization.mInstance == null)
			{
				Localization.mInstance = this;
				Object.DontDestroyOnLoad(base.gameObject);
				return;
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x0011DD7A File Offset: 0x0011BF7A
		private void OnEnable()
		{
			if (Localization.mInstance == null)
			{
				Localization.mInstance = this;
			}
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x0011DD8F File Offset: 0x0011BF8F
		private void OnDisable()
		{
			Localization.localizationHasBeenSet = false;
			Localization.mLanguageIndex = -1;
			Localization.mDictionary.Clear();
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x0011DDA7 File Offset: 0x0011BFA7
		private void OnDestroy()
		{
			if (Localization.mInstance == this)
			{
				Localization.mInstance = null;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600125F RID: 4703 RVA: 0x0011DDBC File Offset: 0x0011BFBC
		// (set) Token: 0x06001260 RID: 4704 RVA: 0x0011DDC4 File Offset: 0x0011BFC4
		public static string language
		{
			get
			{
				return Localization.mLanguage;
			}
			set
			{
				if (Localization.mLanguage != value)
				{
					if (!string.IsNullOrEmpty(value))
					{
						if (Localization.mDictionary.Count == 0)
						{
							Localization.localizationHasBeenSet = true;
							Localization.LoadCSV();
							Localization.mLanguage = value;
						}
						if (Localization.mDictionary.Count != 0 && Localization.SelectLanguage(value))
						{
							return;
						}
					}
					PlayerPrefs.DeleteKey("Language");
				}
			}
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x0011DE24 File Offset: 0x0011C024
		public static bool LoadCSV()
		{
			List<List<string>> list = CSVReader.ReadCsv("Data/Localization.csv");
			for (int i = 0; i < list.Count; i++)
			{
				List<string> list2 = list[i];
				if (i == 0)
				{
					if (list2.Count < 2)
					{
						return false;
					}
					list2[0] = "KEY";
					if (!string.Equals(list2[0], "KEY"))
					{
						Debug.LogError("Invalid localization CSV file. The first value is expected to be 'KEY', followed by language columns.\nInstead found '" + list2[0] + "' Localization");
						return false;
					}
					Localization.mDictionary.Clear();
				}
				Localization.AddCSV(list2);
			}
			return true;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x0011DEB0 File Offset: 0x0011C0B0
		private static bool SelectLanguage(string language)
		{
			Localization.mLanguageIndex = -1;
			if (Localization.mDictionary.Count == 0)
			{
				return false;
			}
			string[] array;
			if (Localization.mDictionary.TryGetValue("KEY", out array))
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == language)
					{
						Localization.mLanguageIndex = i;
						Localization.mLanguage = language;
						PlayerPrefs.SetString("Language", Localization.mLanguage);
						foreach (GameObject gameObject in (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject)))
						{
							if (gameObject.hideFlags != 8 && gameObject.hideFlags != 61)
							{
								UILocalize component = gameObject.GetComponent<UILocalize>();
								if (component != null)
								{
									component.OnLocalize();
								}
								FontLocalize component2 = gameObject.GetComponent<FontLocalize>();
								if (component2 != null)
								{
									component2.OnLocalize();
								}
								ActiveObjectLocalize component3 = gameObject.GetComponent<ActiveObjectLocalize>();
								if (component3 != null)
								{
									component3.OnLocalize();
								}
							}
						}
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0011DFB4 File Offset: 0x0011C1B4
		private static void AddCSV(List<string> values)
		{
			if (values.Count < 2)
			{
				return;
			}
			string[] array = new string[values.Count - 1];
			for (int i = 1; i < values.Count; i++)
			{
				array[i - 1] = values[i];
			}
			Localization.mDictionary.Add(values[0], array);
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x0011E008 File Offset: 0x0011C208
		public static string Get(string key)
		{
			if (!Localization.localizationHasBeenSet)
			{
				Localization.language = PlayerPrefs.GetString("Language", "English");
			}
			string[] array;
			if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key, out array) && Localization.mLanguageIndex < array.Length)
			{
				return array[Localization.mLanguageIndex];
			}
			return key;
		}

		// Token: 0x04000A39 RID: 2617
		private static Localization mInstance;

		// Token: 0x04000A3A RID: 2618
		public static bool localizationHasBeenSet = false;

		// Token: 0x04000A3B RID: 2619
		[HideInInspector]
		public static string startingLanguage = "Japanese";

		// Token: 0x04000A3C RID: 2620
		private static Dictionary<string, string[]> mDictionary = new Dictionary<string, string[]>();

		// Token: 0x04000A3D RID: 2621
		private static int mLanguageIndex = -1;

		// Token: 0x04000A3E RID: 2622
		private static string mLanguage;
	}
}
