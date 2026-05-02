using System;
using Socotra;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x0200003A RID: 58
public class XenoPP05 : StApplication
{
	// Token: 0x06000902 RID: 2306 RVA: 0x000B3A30 File Offset: 0x000B1C30
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
		this.canvas = SingletonBehaviour<StScreenManager>.Instance.AddFrame<XenoPP05Canvas>("XenoPP05", 240, 260);
		this.self = this;
		this.canvas.parent = this;
		GC.Collect();
		StDisplay.SetCurrent(this.canvas);
		new StThread(this.canvas).Start();
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000B3B5E File Offset: 0x000B1D5E
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

	// Token: 0x0400058E RID: 1422
	protected internal XenoPP05 self;

	// Token: 0x0400058F RID: 1423
	protected internal XenoPP05Canvas canvas;

	// Token: 0x04000590 RID: 1424
	protected internal string downloadurl;

	// Token: 0x04000591 RID: 1425
	protected internal string[] args;

	// Token: 0x04000592 RID: 1426
	protected internal string auth_url;

	// Token: 0x04000593 RID: 1427
	protected internal int auth_cmax;

	// Token: 0x04000594 RID: 1428
	protected internal int auth_tmax;

	// Token: 0x04000595 RID: 1429
	protected internal int afps_wait;

	// Token: 0x04000596 RID: 1430
	protected internal string res_name;

	// Token: 0x04000597 RID: 1431
	protected internal bool debug_on;

	// Token: 0x04000598 RID: 1432
	protected internal bool chk_mem;

	// Token: 0x04000599 RID: 1433
	protected internal string res_dir;

	// Token: 0x0400059A RID: 1434
	protected internal bool init_end;
}
