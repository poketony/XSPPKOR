using System;
using Steezy.Utility;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class TitleSpriteDatas : SingletonBehaviour<TitleSpriteDatas>
{
	// Token: 0x060000A3 RID: 163 RVA: 0x0000B610 File Offset: 0x00009810
	public Sprite GetPhoneBodySprite(AppliSettingsDataModel.AppliStyle appliStyle)
	{
		return this.phoneBodySprites[(int)appliStyle];
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x0000B628 File Offset: 0x00009828
	public Sprite GetPhoneHilightSprite(AppliSettingsDataModel.AppliStyle appliStyle)
	{
		return this.phoneHilightSprites[(int)appliStyle];
	}

	// Token: 0x040000D1 RID: 209
	[SerializeField]
	private Sprite[] phoneBodySprites;

	// Token: 0x040000D2 RID: 210
	[SerializeField]
	private Sprite[] phoneHilightSprites;
}
