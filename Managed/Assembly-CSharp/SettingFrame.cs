using System;
using Steezy.Utility;

// Token: 0x0200001F RID: 31
public class SettingFrame : SettingAction
{
	// Token: 0x06000091 RID: 145 RVA: 0x0000B29C File Offset: 0x0000949C
	private void Start()
	{
	}

	// Token: 0x06000092 RID: 146 RVA: 0x0000B29E File Offset: 0x0000949E
	private void Update()
	{
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000B2A0 File Offset: 0x000094A0
	public override void Action(int args)
	{
		if (args != 0)
		{
			SingletonBehaviour<AppliArchive>.Instance.ChangePhoneScreen();
			SingletonData<CommonData>.Instance.isEnableSettingFrame = true;
			return;
		}
		SingletonBehaviour<AppliArchive>.Instance.ChangeFullScreen();
		SingletonData<CommonData>.Instance.isEnableSettingFrame = false;
	}
}
