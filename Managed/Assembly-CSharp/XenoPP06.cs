using System;
using Socotra;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x0200003D RID: 61
public class XenoPP06 : StApplication
{
	// Token: 0x06000B17 RID: 2839 RVA: 0x000DE1E4 File Offset: 0x000DC3E4
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
		this.canvas = SingletonBehaviour<StScreenManager>.Instance.AddFrame<XenoPP06Canvas>("XenoPP06", 240, 240);
		this.self = this;
		this.canvas.parent = this;
		GC.Collect();
		StDisplay.SetCurrent(this.canvas);
		new StThread(this.canvas).Start();
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x000DE312 File Offset: 0x000DC512
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

	// Token: 0x040006B3 RID: 1715
	protected internal XenoPP06 self;

	// Token: 0x040006B4 RID: 1716
	protected internal XenoPP06Canvas canvas;

	// Token: 0x040006B5 RID: 1717
	protected internal string downloadurl;

	// Token: 0x040006B6 RID: 1718
	protected internal string[] args;

	// Token: 0x040006B7 RID: 1719
	protected internal string auth_url;

	// Token: 0x040006B8 RID: 1720
	protected internal int auth_cmax;

	// Token: 0x040006B9 RID: 1721
	protected internal int auth_tmax;

	// Token: 0x040006BA RID: 1722
	protected internal int afps_wait;

	// Token: 0x040006BB RID: 1723
	protected internal string res_name;

	// Token: 0x040006BC RID: 1724
	protected internal bool debug_on;

	// Token: 0x040006BD RID: 1725
	protected internal bool chk_mem;

	// Token: 0x040006BE RID: 1726
	protected internal string res_dir;

	// Token: 0x040006BF RID: 1727
	protected internal bool init_end;
}
