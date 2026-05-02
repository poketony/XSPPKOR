using System;
using Socotra;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;

// Token: 0x02000034 RID: 52
public class XenoPP03 : StApplication
{
	// Token: 0x060004DB RID: 1243 RVA: 0x0005D330 File Offset: 0x0005B530
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
		this.canvas = SingletonBehaviour<StScreenManager>.Instance.AddFrame<XenoPP03Canvas>("XenoPP03", 240, 240);
		this.self = this;
		this.canvas.parent = this;
		GC.Collect();
		StDisplay.SetCurrent(this.canvas);
		new StThread(this.canvas).Start();
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x0005D45E File Offset: 0x0005B65E
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

	// Token: 0x0400033F RID: 831
	protected internal XenoPP03 self;

	// Token: 0x04000340 RID: 832
	protected internal XenoPP03Canvas canvas;

	// Token: 0x04000341 RID: 833
	protected internal string downloadurl;

	// Token: 0x04000342 RID: 834
	protected internal string[] args;

	// Token: 0x04000343 RID: 835
	protected internal string auth_url;

	// Token: 0x04000344 RID: 836
	protected internal int auth_cmax;

	// Token: 0x04000345 RID: 837
	protected internal int auth_tmax;

	// Token: 0x04000346 RID: 838
	protected internal int afps_wait;

	// Token: 0x04000347 RID: 839
	protected internal string res_name;

	// Token: 0x04000348 RID: 840
	protected internal bool debug_on;

	// Token: 0x04000349 RID: 841
	protected internal bool chk_mem;

	// Token: 0x0400034A RID: 842
	protected internal string res_dir;

	// Token: 0x0400034B RID: 843
	protected internal bool init_end;
}
