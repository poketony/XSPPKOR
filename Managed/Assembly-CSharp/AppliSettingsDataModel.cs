using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
[CreateAssetMenu(menuName = "Create AppliSettingsDataModel", fileName = "AppliSettingsDataModel")]
public class AppliSettingsDataModel : ScriptableObject
{
	// Token: 0x04000019 RID: 25
	[Header("オートセーブ無し説明文の表示")]
	[SerializeField]
	public bool showAutoSaveDescription;

	// Token: 0x0400001A RID: 26
	[Header("アプリのスタイル")]
	[SerializeField]
	public AppliSettingsDataModel.AppliStyle appliStyle;

	// Token: 0x020001AD RID: 429
	public enum AppliStyle
	{
		// Token: 0x040012AD RID: 4781
		GmodeArchives,
		// Token: 0x040012AE RID: 4782
		GmodeArchivesPlus
	}
}
