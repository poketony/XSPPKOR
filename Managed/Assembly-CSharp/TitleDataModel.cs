using System;
using Steezy.Localize;
using UnityEngine;

// Token: 0x02000022 RID: 34
[CreateAssetMenu(menuName = "Create TitleDataModel", fileName = "TitleDataModel")]
public class TitleDataModel : ScriptableObject
{
	// Token: 0x060000A1 RID: 161 RVA: 0x0000B5E5 File Offset: 0x000097E5
	public TitleDataModel.TitleData GetTitleData()
	{
		if (Localization.language == "ja")
		{
			return this.titleData;
		}
		return this.titleDataEn;
	}

	// Token: 0x040000CF RID: 207
	[Header("タイトル画面の表示データの設定")]
	[SerializeField]
	private TitleDataModel.TitleData titleData;

	// Token: 0x040000D0 RID: 208
	[Header("タイトル画面の表示データの設定（英語版）必要な場合に設定する")]
	[SerializeField]
	private TitleDataModel.TitleData titleDataEn;

	// Token: 0x020001BC RID: 444
	[Serializable]
	public class TitleData
	{
		// Token: 0x040012DE RID: 4830
		[Header("タイトルナンバー。Gアカプラス設定の場合は設定不要")]
		public string tilteNumber = "XX";

		// Token: 0x040012DF RID: 4831
		[Multiline(2)]
		public string tilteName = "アーカイブスタイトル";

		// Token: 0x040012E0 RID: 4832
		[TextArea]
		public string aboutGame = "リリース：20XX年XX月\nジャンル：XXXXXXXゲーム\nXXXXXXXXXXXXXXXXXXXXXXXXX";

		// Token: 0x040012E1 RID: 4833
		[Multiline(1)]
		public string copyright = "©G-MODE Corporation";

		// Token: 0x040012E2 RID: 4834
		public string releaseData = "2005/05/00";

		// Token: 0x040012E3 RID: 4835
		public Sprite gameScreeShot;

		// Token: 0x040012E4 RID: 4836
		[Header("ロゴ。未設定時はデフォルトの日本語ロゴが表示される")]
		public Sprite arichivesLogoSprite;

		// Token: 0x040012E5 RID: 4837
		[Header("Gアカプラス用のロゴ。Gアカプラス設定の場合に表示される")]
		public Sprite arichivesPlusLogoSprite;

		// Token: 0x040012E6 RID: 4838
		[Header("タイトル名の画像。文字列で表現できない場合に設定する")]
		public Sprite titleNameSprite;

		// Token: 0x040012E7 RID: 4839
		[Header("コピーライトの画像。文字列で表現できない場合に設定する")]
		public Sprite copyrightSprite;

		// Token: 0x040012E8 RID: 4840
		public AudioClip titleBgm;
	}
}
