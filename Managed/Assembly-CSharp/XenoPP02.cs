using System;
using Socotra;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x02000031 RID: 49
public class XenoPP02 : StApplication
{
	// Token: 0x060002D3 RID: 723 RVA: 0x00034308 File Offset: 0x00032508
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
		this.canvas = SingletonBehaviour<StScreenManager>.Instance.AddFrame<XenoPP02Canvas>("XenoPP02", 240, 240);
		this.self = this;
		this.canvas.parent = this;
		GC.Collect();
		StDisplay.SetCurrent(this.canvas);
		new StThread(this.canvas).Start();
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x00034436 File Offset: 0x00032636
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

	// Token: 0x04000225 RID: 549
	protected internal XenoPP02 self;

	// Token: 0x04000226 RID: 550
	protected internal XenoPP02Canvas canvas;

	// Token: 0x04000227 RID: 551
	protected internal string downloadurl;

	// Token: 0x04000228 RID: 552
	protected internal string[] args;

	// Token: 0x04000229 RID: 553
	protected internal string auth_url;

	// Token: 0x0400022A RID: 554
	protected internal int auth_cmax;

	// Token: 0x0400022B RID: 555
	protected internal int auth_tmax;

	// Token: 0x0400022C RID: 556
	protected internal int afps_wait;

	// Token: 0x0400022D RID: 557
	protected internal string res_name;

	// Token: 0x0400022E RID: 558
	protected internal bool debug_on;

	// Token: 0x0400022F RID: 559
	protected internal bool chk_mem;

	// Token: 0x04000230 RID: 560
	protected internal string res_dir;

	// Token: 0x04000231 RID: 561
	protected internal bool init_end;
}
