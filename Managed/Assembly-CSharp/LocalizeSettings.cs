using System;
using Steezy.Localize;
using Steezy.Utility;

// Token: 0x02000014 RID: 20
public class LocalizeSettings : SingletonData<LocalizeSettings>
{
	// Token: 0x0600006A RID: 106 RVA: 0x0000ABDF File Offset: 0x00008DDF
	public void SetLocalizeLanguage()
	{
		Localization.language = "ja";
	}

	// Token: 0x0600006B RID: 107 RVA: 0x0000ABEB File Offset: 0x00008DEB
	public bool IsJapaneseLanguage()
	{
		return Localization.language == "ja";
	}

	// Token: 0x0400008E RID: 142
	private const string UnityEditorLanguage = "ja";

	// Token: 0x020001B3 RID: 435
	public static class UILocalizeKey
	{
		// Token: 0x040012BC RID: 4796
		public const string Japanese = "ja";

		// Token: 0x040012BD RID: 4797
		public const string English = "en";
	}
}
