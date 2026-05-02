using System;
using Steezy.Localize;
using UnityEngine;

// Token: 0x02000011 RID: 17
[CreateAssetMenu(menuName = "Create HowToPlayDataModel", fileName = "HowToPlayDataModel")]
public class HowToPlayDataModel : ScriptableObject
{
	// Token: 0x0600005F RID: 95 RVA: 0x0000A805 File Offset: 0x00008A05
	public Sprite[] GetHowToPlayImages()
	{
		if (Localization.language == "ja")
		{
			return this.howToPlayImages;
		}
		return this.howToPlayImagesEn;
	}

	// Token: 0x0400006B RID: 107
	[Header("遊び方画像を1ページ目からの表示順に設定する")]
	[SerializeField]
	private Sprite[] howToPlayImages;

	// Token: 0x0400006C RID: 108
	[Header("遊び方画像の設定（英語版）必要な場合に設定する")]
	[SerializeField]
	private Sprite[] howToPlayImagesEn;
}
