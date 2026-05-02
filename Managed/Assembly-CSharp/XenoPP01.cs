using System;
using Socotra;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x0200002E RID: 46
public class XenoPP01 : StApplication
{
	// Token: 0x060000CF RID: 207 RVA: 0x0000C170 File Offset: 0x0000A370
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
		this.canvas = SingletonBehaviour<StScreenManager>.Instance.AddFrame<XenoPP01Canvas>("XenoPP01", 240, 240);
		this.self = this;
		this.canvas.parent = this;
		GC.Collect();
		StDisplay.SetCurrent(this.canvas);
		new StThread(this.canvas).Start();
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x0000C29E File Offset: 0x0000A49E
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

	// Token: 0x0400010B RID: 267
	protected internal XenoPP01 self;

	// Token: 0x0400010C RID: 268
	protected internal XenoPP01Canvas canvas;

	// Token: 0x0400010D RID: 269
	protected internal string downloadurl;

	// Token: 0x0400010E RID: 270
	protected internal string[] args;

	// Token: 0x0400010F RID: 271
	protected internal string auth_url;

	// Token: 0x04000110 RID: 272
	protected internal int auth_cmax;

	// Token: 0x04000111 RID: 273
	protected internal int auth_tmax;

	// Token: 0x04000112 RID: 274
	protected internal int afps_wait;

	// Token: 0x04000113 RID: 275
	protected internal string res_name;

	// Token: 0x04000114 RID: 276
	protected internal bool debug_on;

	// Token: 0x04000115 RID: 277
	protected internal bool chk_mem;

	// Token: 0x04000116 RID: 278
	protected internal string res_dir;

	// Token: 0x04000117 RID: 279
	protected internal bool init_end;
}
