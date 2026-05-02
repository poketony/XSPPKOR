using System;
using Socotra;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x02000037 RID: 55
public class XenoPP04 : StApplication
{
	// Token: 0x060006ED RID: 1773 RVA: 0x00087A00 File Offset: 0x00085C00
	public override void Started(int arg)
	{
		this.downloadurl = StApplication.GetSourceURL();
		this.args = base.GetArgs();
		this.auth_url = this.args[0];
		this.auth_cmax = Convert.ToInt32(this.args[1]);
		this.auth_tmax = Convert.ToInt32(this.args[2]);
		this.res_name = this.args[3];
		this.afps_wait = Convert.ToInt32(this.args[4]);
		if (this.args[5].Equals("true"))
		{
			this.debug_on = true;
		}
		if (this.args[6].Equals("true"))
		{
			this.chk_mem = true;
		}
		this.res_dir = this.args[7];
		if (this.args[7].Equals("0"))
		{
			this.res_dir = string.Empty;
		}
		this.canvas = SingletonBehaviour<StScreenManager>.Instance.AddFrame<XenoPP04Canvas>("XenoPP04", 240, 240);
		this.self = this;
		this.canvas.parent = this;
		GC.Collect();
		StDisplay.SetCurrent(this.canvas);
		new StThread(this.canvas).Start();
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x00087B2E File Offset: 0x00085D2E
	public override void Resume()
	{
		if (this.init_end)
		{
			this.canvas.InitWorks();
			if (PhoneSystem.GetAttribute(0) == 1)
			{
				PhoneSystem.SetAttribute(0, 1);
			}
		}
	}

	// Token: 0x04000465 RID: 1125
	protected internal XenoPP04 self;

	// Token: 0x04000466 RID: 1126
	protected internal XenoPP04Canvas canvas;

	// Token: 0x04000467 RID: 1127
	protected internal string downloadurl;

	// Token: 0x04000468 RID: 1128
	protected internal string[] args;

	// Token: 0x04000469 RID: 1129
	protected internal string auth_url;

	// Token: 0x0400046A RID: 1130
	protected internal int auth_cmax;

	// Token: 0x0400046B RID: 1131
	protected internal int auth_tmax;

	// Token: 0x0400046C RID: 1132
	protected internal int afps_wait;

	// Token: 0x0400046D RID: 1133
	protected internal string res_name;

	// Token: 0x0400046E RID: 1134
	protected internal bool debug_on;

	// Token: 0x0400046F RID: 1135
	protected internal bool chk_mem;

	// Token: 0x04000470 RID: 1136
	protected internal string res_dir;

	// Token: 0x04000471 RID: 1137
	protected internal bool init_end;
}
