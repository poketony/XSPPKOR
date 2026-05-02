using System;
using Steezy.Utility;

// Token: 0x0200002C RID: 44
public class CommonData : SingletonData<CommonData>
{
	// Token: 0x04000105 RID: 261
	public bool isEnableSettingFrame;

	// Token: 0x04000106 RID: 262
	public bool isEnableSettingFilter;

	// Token: 0x04000107 RID: 263
	public int windowMode;

	// Token: 0x04000108 RID: 264
	public bool enableWaitingForPauseInput;

	// Token: 0x04000109 RID: 265
	public float timeScale = 1f;

	// Token: 0x0400010A RID: 266
	public int lastLaunchApp;
}
