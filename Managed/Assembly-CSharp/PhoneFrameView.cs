using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000015 RID: 21
public class PhoneFrameView : MonoBehaviour
{
	// Token: 0x0600006D RID: 109 RVA: 0x0000AC04 File Offset: 0x00008E04
	private void Start()
	{
		this.Init();
	}

	// Token: 0x0600006E RID: 110 RVA: 0x0000AC0C File Offset: 0x00008E0C
	private void Init()
	{
		AppliSettingsDataModel.AppliStyle appliStyle = SingletonBehaviour<AppliArchive>.Instance.GetAppliSettingsDataModel().appliStyle;
		this.phoneFrameImage.sprite = this.GetPhoneFrameSprite(appliStyle);
	}

	// Token: 0x0600006F RID: 111 RVA: 0x0000AC3C File Offset: 0x00008E3C
	public Sprite GetPhoneFrameSprite(AppliSettingsDataModel.AppliStyle appliStyle)
	{
		return this.phoneFrameSprites[(int)appliStyle];
	}

	// Token: 0x0400008F RID: 143
	[SerializeField]
	private Image phoneFrameImage;

	// Token: 0x04000090 RID: 144
	[SerializeField]
	private Sprite[] phoneFrameSprites;
}
