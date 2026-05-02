using System;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x0200001E RID: 30
public class SettingFilter : SettingAction
{
	// Token: 0x0600008D RID: 141 RVA: 0x0000B268 File Offset: 0x00009468
	private void Start()
	{
	}

	// Token: 0x0600008E RID: 142 RVA: 0x0000B26A File Offset: 0x0000946A
	private void Update()
	{
	}

	// Token: 0x0600008F RID: 143 RVA: 0x0000B26C File Offset: 0x0000946C
	public override void Action(int args)
	{
		bool flag = args != 0;
		SingletonBehaviour<StDisplay>.Instance.SetFiltering(flag);
		SingletonData<CommonData>.Instance.isEnableSettingFilter = flag;
	}
}
