using System;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x02000028 RID: 40
public class WindowType : SettingAction
{
	// Token: 0x060000C0 RID: 192 RVA: 0x0000BE36 File Offset: 0x0000A036
	private void Start()
	{
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x0000BE38 File Offset: 0x0000A038
	private void Update()
	{
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x0000BE3C File Offset: 0x0000A03C
	public override void Action(int args)
	{
		bool flag = args != 0;
		SingletonBehaviour<StDisplay>.Instance.SetFiltering(flag);
		SingletonData<CommonData>.Instance.isEnableSettingFilter = flag;
	}
}
