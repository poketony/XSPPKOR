using System;

// Token: 0x0200003F RID: 63
public sealed class XScript06
{
	// Token: 0x06000CB0 RID: 3248 RVA: 0x001037F8 File Offset: 0x001019F8
	protected internal XScript06(XenoPP06Canvas cvs)
	{
		this.parent = cvs;
		this.sc_flg = new int[80];
		this.ScFlagClear();
		this.sc_wk = new int[8];
		this.ScWkClear();
		this.sc_face = 255;
		this.msstr = new sbyte[60];
		this.sc_str = new string[24];
		this.sc_stry = new int[24];
		this.sc_strl = 0;
		this.sc_ifflg = new bool[5];
		this.sc_b_ifflg = new bool[5];
		this.sc_ifdpt = -1;
		this.sc_b_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
		this.sc_messkip = false;
		this.script_b_adr = 65535;
		this.npc_xy = new int[][]
		{
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4]
		};
		this.npc_pn = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.npc_mv = new int[48];
		this.npc_adr = new int[48];
		this.npc_wk = new int[][]
		{
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4]
		};
		this.npc_p = 0;
		this.tobj_xy = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.tobj_adr = new int[45];
		this.tobj_cnd = new int[45];
		this.tobj_pn = new int[45];
		this.tobj_cno = new int[45];
		this.tobj_p = 0;
		this.obj_xy = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.obj_wk = new int[][]
		{
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4]
		};
		this.obj_pn = new int[64];
		this.obj_adr = new int[64];
		this.obj_kill = new int[64];
		this.obj_cmd = new int[64];
		this.obj_anm = new int[][]
		{
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4],
			new int[4]
		};
		this.obj_nflg = new bool[64];
		this.obj_prio = new int[64];
		this.obj_p = 0;
		this.obj_no = 255;
		this.trap_xy = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.trap_id = new int[112];
		this.trap_p = 0;
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x00104CF0 File Offset: 0x00102EF0
	public void ScFlagClear()
	{
		for (int i = 0; i < 80; i++)
		{
			this.sc_flg[i] = 0;
		}
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x00104D14 File Offset: 0x00102F14
	public void ScWkClear()
	{
		for (int i = 0; i < 8; i++)
		{
			this.sc_wk[i] = 0;
		}
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x00104D38 File Offset: 0x00102F38
	public void ObjWkClear()
	{
		for (int i = 0; i < 4; i++)
		{
			this.obj_wk[this.obj_no][i] = 65535;
		}
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x00104D68 File Offset: 0x00102F68
	public sbyte GetScrByte()
	{
		sbyte b;
		if (this.parent.GetSeqNo() == 7)
		{
			b = this.script[this.script_adr];
		}
		else
		{
			b = this.vscript[this.script_adr];
		}
		this.script_adr++;
		return b;
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x00104DB0 File Offset: 0x00102FB0
	public short GetScrShort()
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP06Canvas.ArrayShort2(this.script, this.script_adr);
		}
		else
		{
			num = XenoPP06Canvas.ArrayShort2(this.vscript, this.script_adr);
		}
		this.script_adr += 2;
		return num;
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x00104E00 File Offset: 0x00103000
	public sbyte GetScrByte2(int adr)
	{
		sbyte b;
		if (this.parent.GetSeqNo() == 7)
		{
			b = this.script[adr];
		}
		else
		{
			b = this.vscript[adr];
		}
		return b;
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x00104E30 File Offset: 0x00103030
	public short GetScrShort2(int adr)
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP06Canvas.ArrayShort2(this.script, adr);
		}
		else
		{
			num = XenoPP06Canvas.ArrayShort2(this.vscript, adr);
		}
		return num;
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x00104E68 File Offset: 0x00103068
	public void SetNpcChar(int x, int y, int p, int m, int adr)
	{
		if (this.npc_p < 48)
		{
			this.npc_xy[this.npc_p][0] = (this.npc_xy[this.npc_p][2] = x);
			int[] array = this.npc_xy[this.npc_p];
			int num = 1;
			this.npc_xy[this.npc_p][3] = y;
			array[num] = y;
			this.npc_pn[this.npc_p][0] = p;
			this.npc_pn[this.npc_p][1] = p;
			this.npc_mv[this.npc_p] = m;
			this.npc_adr[this.npc_p] = adr;
			for (int i = 0; i < 4; i++)
			{
				this.npc_wk[this.npc_p][i] = 65535;
			}
			this.npc_wk[this.npc_p][0] = 16;
			while (this.parent.GetAtrNpc(x, y, this.npc_p) != 0)
			{
				x++;
			}
			this.npc_xy[this.npc_p][0] = (this.npc_xy[this.npc_p][2] = x);
			this.npc_p++;
		}
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x00104F84 File Offset: 0x00103184
	public void SetNpcChar2(int x, int y, int p, int p2, int adr)
	{
		if (this.npc_p < 48)
		{
			int[] array = this.npc_xy[this.npc_p];
			int num = 0;
			this.npc_xy[this.npc_p][2] = x;
			array[num] = x;
			int[] array2 = this.npc_xy[this.npc_p];
			int num2 = 1;
			this.npc_xy[this.npc_p][3] = y;
			array2[num2] = y;
			this.npc_pn[this.npc_p][0] = p;
			this.npc_pn[this.npc_p][1] = p2;
			this.npc_mv[this.npc_p] = 0;
			this.npc_adr[this.npc_p] = adr;
			for (int i = 0; i < 4; i++)
			{
				this.npc_wk[this.npc_p][i] = 65535;
			}
			this.npc_p++;
		}
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x00105050 File Offset: 0x00103250
	public void SetMapObj(int x, int y, int adr)
	{
		if (this.obj_p < 64)
		{
			this.obj_xy[this.obj_p][0] = x;
			this.obj_xy[this.obj_p][1] = y;
			for (int i = 0; i < 4; i++)
			{
				this.obj_wk[this.obj_p][i] = 65535;
			}
			this.obj_pn[this.obj_p] = 255;
			this.obj_adr[this.obj_p] = adr;
			this.obj_kill[this.obj_p] = 0;
			this.obj_cmd[this.obj_p] = 255;
			this.obj_nflg[this.obj_p] = true;
			this.obj_prio[this.obj_p] = 0;
			for (int i = 0; i < 4; i++)
			{
				this.obj_anm[this.obj_p][i] = 65535;
			}
			this.obj_p++;
		}
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x00105134 File Offset: 0x00103334
	public void SetTouchObj(int x, int y, int png, int cond, int adr)
	{
		if (this.tobj_p < 64)
		{
			this.tobj_xy[this.tobj_p][0] = x;
			this.tobj_xy[this.tobj_p][1] = y;
			this.tobj_pn[this.tobj_p] = png;
			this.tobj_cnd[this.tobj_p] = cond;
			this.tobj_adr[this.tobj_p] = adr;
			this.tobj_cno[this.tobj_p] = 255;
			this.tobj_p++;
		}
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x001051B8 File Offset: 0x001033B8
	public void SetTrap(int x, int y, int id)
	{
		if (this.trap_p < 112)
		{
			this.trap_xy[this.trap_p][0] = x;
			this.trap_xy[this.trap_p][1] = y;
			this.trap_id[this.trap_p] = id;
			this.trap_p++;
		}
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x0010520B File Offset: 0x0010340B
	public bool IsMessageSelect()
	{
		return this.script_cmd == 59;
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x0010521C File Offset: 0x0010341C
	public bool IsMessageEnd()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || this.script_cmd == 34 || this.script_cmd == 36 || this.script_cmd == 95 || this.script_cmd == 102 || this.script_cmd == 104 || this.script_cmd == 105 || (this.script_cmd == 4 && this.sc_wk[0] == 0);
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x00105290 File Offset: 0x00103490
	public bool IsMessageEnd2()
	{
		return this.script_cmd == 21 || this.script_cmd == 27 || (this.script_cmd != 26 && this.script_cmd != 7) || ((this.script_cmd == 26 || this.script_cmd == 7) && this.sc_wk[0] == 0);
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x001052E4 File Offset: 0x001034E4
	public bool IsMessageEnd3()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || (this.script_cmd == 95 && this.sc_wk[0] >= 2);
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x00105312 File Offset: 0x00103512
	public bool IsMessageEnd4()
	{
		return this.script_cmd == 84;
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x00105321 File Offset: 0x00103521
	public bool IsMessage()
	{
		return this.script_cmd == 4;
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x0010532F File Offset: 0x0010352F
	public bool IsMessage2()
	{
		return this.script_cmd == 26 || this.script_cmd == 7;
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x00105347 File Offset: 0x00103547
	public string SpReplace(string str)
	{
		return str.Replace('Ⅰ', '\ue6e2').Replace('Ⅱ', '\ue6e3').Replace('Ⅲ', '\ue6e4');
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x00105378 File Offset: 0x00103578
	public void ScriptObjInit()
	{
		this.obj_p = 0;
		for (int i = 0; i < 64; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.obj_xy[i][j] = 0;
			}
			for (int j = 0; j < 4; j++)
			{
				this.obj_wk[i][j] = 65535;
			}
			this.obj_pn[i] = 255;
			this.obj_adr[i] = 0;
			this.obj_kill[i] = 0;
			this.obj_prio[i] = 0;
			for (int j = 0; j < 4; j++)
			{
				this.obj_anm[i][j] = 65535;
			}
		}
		this.tobj_p = 0;
		for (int i = 0; i < 45; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.tobj_xy[i][j] = 0;
			}
			this.tobj_adr[i] = 0;
			this.tobj_cnd[i] = 0;
			this.tobj_cno[this.tobj_p] = 255;
		}
		this.trap_p = 0;
		for (int i = 0; i < 112; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.trap_xy[i][j] = 0;
			}
			this.trap_id[i] = 0;
		}
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x00105494 File Offset: 0x00103694
	public void ScriptInit()
	{
		if (this.script_b_adr != 65535)
		{
			this.script_adr = this.script_b_adr;
		}
		else
		{
			this.script_adr = 0;
		}
		this.script_b_adr = 65535;
		this.script_nflg = true;
		this.script_flg = false;
		this.script_adr_ret = 0;
		this.sc_skipadr = 65535;
		this.ScWkClear();
		for (int i = 0; i < 24; i++)
		{
			this.sc_str[i] = string.Empty;
		}
		this.sc_strl = 0;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
		this.npc_p = 0;
		for (int i = 0; i < 48; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				this.npc_xy[i][j] = 0;
			}
			this.npc_pn[i][0] = 0;
			this.npc_pn[i][1] = 0;
			this.npc_mv[i] = 0;
			this.npc_adr[i] = 0;
		}
		this.ScriptObjInit();
		this.sc_drawy = 69;
		this.sc_wait = 0;
		this.sc_picno = -1;
		this.sc_winy = 164;
		this.sc_name = string.Empty;
		for (int i = 48; i < 80; i++)
		{
			this.sc_flg[i] = 0;
		}
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x001055D0 File Offset: 0x001037D0
	public void ScriptInit2(int adr)
	{
		this.script_adr = adr;
		this.script_nflg = true;
		this.script_flg = false;
		this.script_adr_ret = 0;
		if (this.parent.chy - this.parent.mapy >= 160)
		{
			this.sc_winy = 0;
		}
		else
		{
			this.sc_winy = 164;
		}
		this.ScWkClear();
		for (int i = 0; i < 24; i++)
		{
			this.sc_str[i] = string.Empty;
		}
		this.sc_strl = 0;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
		this.sc_name = string.Empty;
	}

	// Token: 0x06000CC8 RID: 3272 RVA: 0x0010567C File Offset: 0x0010387C
	public void ScriptInit3(int adr)
	{
		this.script_adr = adr;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x001056AC File Offset: 0x001038AC
	public bool IsScriptExec()
	{
		return !this.script_flg;
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x001056BC File Offset: 0x001038BC
	public void ScriptExec()
	{
		bool flag = true;
		do
		{
			if (this.script_nflg)
			{
				this.script_cmd = (int)this.GetScrByte();
			}
			switch (this.script_cmd)
			{
			case 0:
				this.ScrSetChar();
				break;
			case 1:
				this.ScrSetObject();
				break;
			case 2:
				this.ScrExit();
				flag = false;
				break;
			case 3:
				this.ScrSetFade();
				if (!this.script_nflg)
				{
					flag = false;
				}
				break;
			case 4:
				if ((this.parent.id_edge & 4112) != 0 || this.parent.GetConfig(2) == 1)
				{
					this.parent.id_edge &= -4113;
					this.sc_messkip = true;
				}
				this.ScrMessage();
				flag = this.sc_messkip;
				break;
			case 5:
				this.ScrFlagOn();
				break;
			case 6:
				this.ScrFlagOff();
				break;
			case 7:
				if ((this.parent.id_edge & 4112) != 0 || this.parent.GetConfig(2) == 1)
				{
					this.parent.id_edge &= -4113;
					this.sc_messkip = true;
				}
				this.ScrMessageY();
				flag = this.sc_messkip;
				break;
			case 11:
				this.ScrIf();
				break;
			case 12:
				this.ScrElseIf();
				break;
			case 13:
				this.ScrElse();
				break;
			case 14:
				this.ScrEndIf();
				break;
			case 15:
				this.ScrSetBattle();
				flag = false;
				break;
			case 16:
				this.ScrSetVisual();
				flag = false;
				break;
			case 17:
				this.ScrGoto();
				break;
			case 18:
				this.ScrGosub();
				break;
			case 19:
				this.ScrReturn();
				break;
			case 20:
				this.ScrSetName();
				break;
			case 21:
				this.ScrMessageEnd();
				this.sc_messkip = false;
				flag = false;
				break;
			case 23:
				this.ScrSetPicture();
				break;
			case 24:
				this.ScrSetPicPos();
				break;
			case 25:
				this.ScrSetPicPosP();
				break;
			case 26:
				this.ScrMessageY();
				flag = false;
				break;
			case 27:
				this.ScrMessageY();
				flag = false;
				break;
			case 28:
				this.ScrMessageClear();
				this.sc_messkip = false;
				break;
			case 29:
				this.ScrWait();
				flag = false;
				break;
			case 30:
				this.ScrSetDrawArea();
				break;
			case 31:
				this.ScrMessageEnd2();
				this.sc_messkip = false;
				flag = false;
				break;
			case 32:
				this.ScrSetFace();
				break;
			case 33:
				this.ScrSetWindowY();
				break;
			case 34:
			case 102:
				this.ScrMessageEndW();
				this.sc_messkip = false;
				if (!this.script_nflg)
				{
					flag = false;
				}
				break;
			case 35:
				this.ScrSetMapPos();
				break;
			case 36:
				this.ScrMessageNW();
				flag = false;
				break;
			case 37:
				this.ScrSetPicScroll();
				flag = false;
				break;
			case 38:
				flag = false;
				break;
			case 39:
				this.ScrSetPng();
				break;
			case 40:
				this.ScrMoveX();
				flag = false;
				break;
			case 41:
				this.ScrMoveY();
				flag = false;
				break;
			case 42:
				this.ScrSetObject2();
				flag = true;
				this.script_nflg = true;
				break;
			case 43:
				this.ScrKillObj();
				flag = false;
				break;
			case 44:
				this.ScrObjWait();
				flag = false;
				break;
			case 45:
				this.script_nflg = false;
				flag = false;
				break;
			case 46:
				this.ScrWalkX();
				flag = false;
				break;
			case 47:
				this.ScrWalkY();
				flag = false;
				break;
			case 48:
				this.ScrSetPlayPos();
				break;
			case 49:
				this.ScrMoveMapX();
				flag = false;
				break;
			case 50:
				this.ScrMoveMapY();
				flag = false;
				break;
			case 51:
				this.ScrAnim();
				break;
			case 52:
				this.ScrChangeMap();
				flag = false;
				break;
			case 53:
				this.ScrSetObject3();
				break;
			case 54:
				this.ScrWalkX2();
				flag = false;
				break;
			case 55:
				this.ScrWalkY2();
				flag = false;
				break;
			case 56:
				this.ScrSetPlayPos2();
				break;
			case 57:
				this.ScrObjectClear();
				break;
			case 58:
				this.ScrSetChar2();
				break;
			case 59:
				this.ScrSelect();
				flag = false;
				break;
			case 60:
				this.ScrSetMapPosP();
				break;
			case 61:
				this.ScrSetPlayPng();
				break;
			case 62:
				this.ScrSetTouchObj();
				break;
			case 63:
				this.ScrSetObjPrio();
				break;
			case 64:
				this.ScrStartLaster();
				break;
			case 65:
				this.ScrEndLaster();
				break;
			case 66:
				this.ScrSetPlayChar();
				break;
			case 67:
				this.ScrSetApprChar();
				break;
			case 68:
				this.ScrGetItem();
				break;
			case 69:
				this.ScrSetTObjPng();
				break;
			case 70:
				this.ScrSetTouchObj2();
				break;
			case 71:
				this.ScrQuake();
				flag = false;
				break;
			case 72:
				this.ScrSpLaser();
				flag = false;
				break;
			case 73:
				this.ScrFadePng();
				flag = false;
				break;
			case 74:
				this.ScrStartLaster2();
				break;
			case 75:
				this.ScrMoveXY();
				flag = false;
				break;
			case 76:
				this.ScrStartVib();
				break;
			case 77:
				this.ScrStopVib();
				break;
			case 78:
				this.ScrLaserReady();
				break;
			case 79:
				this.ScrLaserReadyStop();
				break;
			case 80:
				this.ScrQuake2();
				break;
			case 81:
				this.ScrQuakeStop();
				break;
			case 82:
				this.ScrSkipAddress();
				break;
			case 83:
				this.ScrApprCharClear();
				break;
			case 84:
				this.ScrMessageEndV();
				this.sc_messkip = false;
				flag = false;
				break;
			case 85:
				this.ScrSetNpcPng();
				break;
			case 86:
				this.ScrMoveX2();
				flag = false;
				break;
			case 87:
				this.ScrMoveY2();
				flag = false;
				break;
			case 88:
				this.ScrPlaySe();
				break;
			case 89:
				this.ScrPlayBgm();
				break;
			case 90:
				this.ScrStopBgm();
				break;
			case 91:
				this.ScrRevivePoint();
				break;
			case 92:
				this.ScrStopSe();
				break;
			case 93:
				this.ScrApprCharPush();
				break;
			case 94:
				this.ScrApprCharPop();
				break;
			case 95:
				this.ScrMessageEnd3();
				this.sc_messkip = false;
				if (!this.script_nflg)
				{
					flag = false;
				}
				break;
			case 96:
			case 112:
				this.ScrVisualRead();
				break;
			case 99:
				this.ScrSetTrap();
				break;
			case 100:
				this.ScrSetTouchObj3();
				break;
			case 103:
				this.ScrDestruction();
				break;
			case 104:
			case 105:
				this.ScrMessageEnd3W();
				this.sc_messkip = false;
				if (!this.script_nflg)
				{
					flag = false;
				}
				break;
			case 106:
				this.ScrStartDecieve();
				break;
			case 107:
				this.ScrStopDecieve();
				break;
			case 108:
				this.parent.scrcompred = true;
				break;
			case 109:
				this.parent.scrcompred = false;
				break;
			case 110:
				this.ScrMoveMapX2();
				flag = false;
				break;
			case 111:
				this.ScrMoveMapY2();
				flag = false;
				break;
			case 114:
				this.ScrSetFont();
				break;
			case 115:
				this.parent.dome_flag = 1;
				break;
			case 116:
				this.parent.es_flag = 1;
				break;
			case 117:
				this.ScrOpenLid();
				break;
			case 118:
				this.ScrLuminescence();
				break;
			case 119:
				this.ScrSetTouchObj4();
				break;
			case 120:
				this.ScrSetPngMapChara();
				break;
			}
		}
		while (flag);
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x00105ED4 File Offset: 0x001040D4
	private void ScrSetChar()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		int scrByte = (int)this.GetScrByte();
		int scrShort2 = (int)this.GetScrShort();
		num *= 16;
		num += 8;
		num2 *= 16;
		num2 += 24;
		this.SetNpcChar(num, num2, scrShort, scrByte, scrShort2);
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x00105F24 File Offset: 0x00104124
	private void ScrSetObject()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		if (this.parent.mapno >= 7 && this.parent.mapno <= 10 && num == 0 && num2 == 0)
		{
			num = this.parent.chx - 8;
			num2 = this.parent.chy - 24;
		}
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x00105F99 File Offset: 0x00104199
	private void ScrExit()
	{
		this.GetScrByte();
		this.script_flg = true;
	}

	// Token: 0x06000CCE RID: 3278 RVA: 0x00105FAC File Offset: 0x001041AC
	private void ScrSetFade()
	{
		this.script_nflg = false;
		this.parent.red = true;
		if (this.sc_wk[0] == 0)
		{
			sbyte scrByte = this.GetScrByte();
			if (scrByte == 0)
			{
				this.parent.StartFade(0);
				this.sc_wk[0] = 1;
				return;
			}
			if (scrByte == 1)
			{
				this.parent.StartFade(1);
				this.sc_wk[0] = 2;
				return;
			}
			if (scrByte == 2)
			{
				this.parent.StartFade(2);
				this.sc_wk[0] = 2;
				return;
			}
			if (scrByte == 3)
			{
				this.parent.StartFade(3);
				this.sc_wk[0] = 1;
				return;
			}
			if (scrByte == 4)
			{
				this.parent.StartFade(4);
				this.sc_wk[0] = 2;
				return;
			}
			if (scrByte == 5)
			{
				this.parent.StartFade(5);
				this.sc_wk[0] = 2;
				return;
			}
			if (scrByte == 6)
			{
				this.parent.StartFade(6);
				this.sc_wk[0] = 1;
				return;
			}
			if (scrByte == 7)
			{
				this.parent.battle_fade = 1;
				this.parent.BattleFadeInit();
				this.parent.SetSeqStep(4);
				return;
			}
			if (scrByte == 8)
			{
				this.parent.battle_fade = 2;
				this.parent.StartFade(0, 64);
				this.parent.BattleFadeInit();
				this.parent.SetSeqStep(4);
				return;
			}
			if (scrByte == 9)
			{
				this.parent.StartFade(7);
				this.sc_wk[0] = 2;
				return;
			}
			if (scrByte == 10)
			{
				this.parent.StartFade(8);
				this.sc_wk[0] = 1;
				return;
			}
			if (scrByte == 11)
			{
				this.parent.StartFade(9);
				this.sc_wk[0] = 2;
				return;
			}
		}
		else if (this.sc_wk[0] == 1)
		{
			if (this.parent.IsFade() == 0)
			{
				this.ScWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.sc_wk[0] == 2 && this.parent.IsFade() == 3)
		{
			this.ScWkClear();
			this.script_nflg = true;
		}
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x00106194 File Offset: 0x00104394
	private void ScrMessage()
	{
		if (this.sc_wk[0] == 0)
		{
			int i;
			for (i = 0; i < 60; i++)
			{
				this.msstr[i] = 0;
			}
			this.ScWkClear();
			this.sc_wk[2] = 0;
			int num = (int)this.GetScrShort();
			bool flag = true;
			i = 0;
			int num2 = 0;
			do
			{
				sbyte b = this.GetScrByte2(num);
				num++;
				if (b == 0)
				{
					sbyte scrByte = this.GetScrByte2(num);
					num++;
					if (scrByte == 0)
					{
						flag = false;
					}
					else
					{
						sbyte[] array = this.msstr;
						int num3 = i;
						array[num3] += b;
						i++;
						num2++;
						sbyte[] array2 = this.msstr;
						int num4 = i;
						array2[num4] += scrByte;
						i++;
						num2++;
					}
				}
				else if (128 <= (int)b || b <= -1)
				{
					sbyte[] array3 = this.msstr;
					int num5 = i;
					array3[num5] += b;
					i++;
					b = this.GetScrByte2(num);
					num++;
					sbyte[] array4 = this.msstr;
					int num6 = i;
					array4[num6] += b;
					i++;
					num2++;
				}
				else
				{
					sbyte[] array5 = this.msstr;
					int num7 = i;
					array5[num7] += b;
					i++;
					num2++;
				}
			}
			while (flag);
			if (this.sc_strl >= 23)
			{
				for (i = 0; i < 22; i++)
				{
					this.sc_str[i] = this.sc_str[i + 1];
				}
				this.sc_str[this.sc_strl] = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
				this.sc_str[this.sc_strl] = this.SpReplace(this.sc_str[this.sc_strl]);
				this.sc_wk[3] = num2;
			}
			else
			{
				this.sc_str[this.sc_strl] = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
				this.sc_str[this.sc_strl] = this.SpReplace(this.sc_str[this.sc_strl]);
				this.sc_wk[3] = num2;
				this.sc_strl++;
			}
			this.script_nflg = false;
			if (!this.parent.window_flg)
			{
				this.parent.window_flg = true;
				this.parent.window_cnt = 0;
				this.sc_wk[0] = 1;
			}
			else
			{
				this.sc_wk[0] = 2;
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 1)
		{
			this.parent.window_cnt++;
			if (this.parent.window_cnt >= 5)
			{
				this.sc_wk[0]++;
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 2)
		{
			if (this.sc_messkip)
			{
				this.ScWkClear();
				this.script_nflg = true;
				this.parent.red = true;
				return;
			}
			this.parent.red = true;
			this.sc_wk[2]++;
			if (this.sc_wk[2] >= this.sc_wk[3])
			{
				this.ScWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CD0 RID: 3280 RVA: 0x00106488 File Offset: 0x00104688
	private void ScrFlagOn()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 1;
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x001064A8 File Offset: 0x001046A8
	private void ScrFlagOff()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 0;
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x001064C8 File Offset: 0x001046C8
	private bool ScrIfRoutine(int[] a)
	{
		sbyte scrByte = this.GetScrByte();
		sbyte scrByte2 = this.GetScrByte();
		sbyte scrByte3 = this.GetScrByte();
		sbyte scrByte4 = this.GetScrByte();
		a[0] = (int)this.GetScrShort();
		a[1] = (int)this.GetScrShort();
		if (scrByte != 0)
		{
			if (scrByte == 1)
			{
				sbyte b = 0;
				if (scrByte2 == 0)
				{
					int chc = this.parent.chc;
					if (chc > 14)
					{
						if (chc <= 28)
						{
							if (chc == 21)
							{
								goto IL_00B4;
							}
							if (chc != 28)
							{
								goto IL_00C1;
							}
						}
						else if (chc != 35)
						{
							if (chc != 43)
							{
								goto IL_00C1;
							}
							b = 3;
							goto IL_00C1;
						}
						b = 2;
						goto IL_00C1;
					}
					if (chc == 0 || chc == 7)
					{
						b = 0;
						goto IL_00C1;
					}
					if (chc != 14)
					{
						goto IL_00C1;
					}
					IL_00B4:
					b = 1;
				}
				IL_00C1:
				if (scrByte3 == 0)
				{
					if (b == scrByte4)
					{
						return true;
					}
				}
				else if (scrByte3 == 1 && b != scrByte4)
				{
					return true;
				}
			}
			return false;
		}
		int num;
		if (scrByte4 == 0)
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		if (scrByte3 == 0)
		{
			return this.sc_flg[(int)scrByte2] == num;
		}
		return this.sc_flg[(int)scrByte2] != num;
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x001065AC File Offset: 0x001047AC
	private void ScrIf()
	{
		int[] array = new int[2];
		if (this.ScrIfRoutine(array))
		{
			this.sc_ifdpt += 1;
			this.sc_ifflg[(int)this.sc_ifdpt] = true;
			return;
		}
		if (this.sc_ifdpt != -1)
		{
			this.sc_ifflg[(int)this.sc_ifdpt] = false;
		}
		this.script_adr = array[0];
	}

	// Token: 0x06000CD4 RID: 3284 RVA: 0x00106608 File Offset: 0x00104808
	private void ScrElseIf()
	{
		int[] array = new int[2];
		bool flag = this.ScrIfRoutine(array);
		if (this.sc_ifdpt == -1)
		{
			if (flag)
			{
				this.sc_ifdpt += 1;
				this.sc_ifflg[(int)this.sc_ifdpt] = true;
				return;
			}
			if (this.sc_ifdpt != -1)
			{
				this.sc_ifflg[(int)this.sc_ifdpt] = false;
			}
			this.script_adr = array[0];
			return;
		}
		else
		{
			if (this.sc_ifflg[(int)this.sc_ifdpt])
			{
				this.script_adr = array[1];
				return;
			}
			if (flag)
			{
				this.sc_ifdpt += 1;
				this.sc_ifflg[(int)this.sc_ifdpt] = true;
				return;
			}
			if (this.sc_ifdpt != -1)
			{
				this.sc_ifflg[(int)this.sc_ifdpt] = false;
			}
			this.script_adr = array[0];
			return;
		}
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x001066CC File Offset: 0x001048CC
	private void ScrElse()
	{
		int scrShort = (int)this.GetScrShort();
		if (this.sc_ifdpt == -1)
		{
			this.sc_ifdpt += 1;
			this.sc_ifflg[(int)this.sc_ifdpt] = true;
			return;
		}
		if (!this.sc_ifflg[(int)this.sc_ifdpt])
		{
			this.sc_ifdpt += 1;
			this.sc_ifflg[(int)this.sc_ifdpt] = true;
			return;
		}
		this.script_adr = scrShort;
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x0010673B File Offset: 0x0010493B
	private void ScrEndIf()
	{
		if (this.sc_ifdpt != -1)
		{
			this.sc_ifflg[(int)this.sc_ifdpt] = false;
			this.sc_ifdpt -= 1;
		}
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x00106764 File Offset: 0x00104964
	private void ScrSetBattle()
	{
		sbyte scrByte = this.GetScrByte();
		if (scrByte != 2 || (scrByte == 2 && this.parent.GetRand(0, 99) < 20))
		{
			this.script_b_adr = this.script_adr;
			this.parent.battleno = (int)scrByte;
			this.parent.StopAllSound();
			this.parent.PlaySe(3);
			this.parent.BattleFadeInit();
			this.parent.SetSeqStep(4);
		}
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x001067D8 File Offset: 0x001049D8
	private void ScrSetVisual()
	{
		this.parent.visualno = (int)this.GetScrByte();
		this.parent.SetSeqNo(8);
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x001067F8 File Offset: 0x001049F8
	private void ScrGoto()
	{
		int scrShort = (int)this.GetScrShort();
		this.script_adr = scrShort;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
	}

	// Token: 0x06000CDA RID: 3290 RVA: 0x00106830 File Offset: 0x00104A30
	private void ScrGosub()
	{
		int scrShort = (int)this.GetScrShort();
		this.script_adr_ret = this.script_adr;
		this.script_adr = scrShort;
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x00106857 File Offset: 0x00104A57
	private void ScrReturn()
	{
		this.script_adr = this.script_adr_ret;
	}

	// Token: 0x06000CDC RID: 3292 RVA: 0x00106868 File Offset: 0x00104A68
	private void ScrSetName()
	{
		int i;
		for (i = 0; i < 60; i++)
		{
			this.msstr[i] = 0;
		}
		this.sc_name = string.Empty;
		int num = (int)this.GetScrShort();
		bool flag = true;
		i = 0;
		do
		{
			sbyte b = this.GetScrByte2(num);
			num++;
			if (b == 0)
			{
				sbyte scrByte = this.GetScrByte2(num);
				num++;
				if (scrByte == 0)
				{
					flag = false;
				}
				else
				{
					sbyte[] array = this.msstr;
					int num2 = i;
					array[num2] += b;
					i++;
					sbyte[] array2 = this.msstr;
					int num3 = i;
					array2[num3] += scrByte;
					i++;
				}
			}
			else if (128 <= (int)b || b <= -1)
			{
				sbyte[] array3 = this.msstr;
				int num4 = i;
				array3[num4] += b;
				i++;
				b = this.GetScrByte2(num);
				num++;
				sbyte[] array4 = this.msstr;
				int num5 = i;
				array4[num5] += b;
				i++;
			}
			else
			{
				sbyte[] array5 = this.msstr;
				int num6 = i;
				array5[num6] += b;
				i++;
			}
		}
		while (flag);
		this.sc_name = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x0010697C File Offset: 0x00104B7C
	private void ScrMessageEnd()
	{
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.parent.red = true;
			if ((this.parent.id_edge & 4112) != 0)
			{
				this.sc_wk[0]++;
				return;
			}
		}
		else if (this.sc_wk[0] == 1)
		{
			this.ScWkClear();
			this.sc_strl = 0;
			this.script_nflg = true;
		}
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x001069EC File Offset: 0x00104BEC
	private void ScrSetPicture()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picno = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x00106A14 File Offset: 0x00104C14
	private void ScrSetPicPos()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picy = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x06000CE0 RID: 3296 RVA: 0x00106A3B File Offset: 0x00104C3B
	private void ScrSetPicPosP()
	{
		this.sc_picy++;
		this.parent.red = true;
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x00106A58 File Offset: 0x00104C58
	private void ScrMessageY()
	{
		if (this.sc_wk[0] == 0)
		{
			int i;
			for (i = 0; i < 60; i++)
			{
				this.msstr[i] = 0;
			}
			this.ScWkClear();
			this.sc_wk[1] = (int)this.GetScrShort();
			this.sc_wk[2] = 0;
			int num = (int)this.GetScrShort();
			bool flag = true;
			i = 0;
			int num2 = 0;
			do
			{
				sbyte b = this.GetScrByte2(num);
				num++;
				if (b == 0)
				{
					sbyte scrByte = this.GetScrByte2(num);
					num++;
					if (scrByte == 0)
					{
						flag = false;
					}
					else
					{
						sbyte[] array = this.msstr;
						int num3 = i;
						array[num3] += b;
						i++;
						num2++;
						sbyte[] array2 = this.msstr;
						int num4 = i;
						array2[num4] += scrByte;
						i++;
						num2++;
					}
				}
				else if (128 <= (int)b || b <= -1)
				{
					sbyte[] array3 = this.msstr;
					int num5 = i;
					array3[num5] += b;
					i++;
					b = this.GetScrByte2(num);
					num++;
					sbyte[] array4 = this.msstr;
					int num6 = i;
					array4[num6] += b;
					i++;
					num2++;
				}
				else
				{
					sbyte[] array5 = this.msstr;
					int num7 = i;
					array5[num7] += b;
					i++;
					num2++;
				}
			}
			while (flag);
			if (this.sc_strl >= 23)
			{
				for (i = 0; i < 22; i++)
				{
					this.sc_str[i] = this.sc_str[i + 1];
				}
				this.sc_str[this.sc_strl] = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
				this.sc_str[this.sc_strl] = this.SpReplace(this.sc_str[this.sc_strl]);
				this.sc_stry[this.sc_strl] = this.sc_wk[1];
				this.sc_wk[3] = num2;
			}
			else
			{
				this.sc_str[this.sc_strl] = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
				this.sc_str[this.sc_strl] = this.SpReplace(this.sc_str[this.sc_strl]);
				this.sc_stry[this.sc_strl] = this.sc_wk[1];
				this.sc_wk[3] = num2;
				this.sc_strl++;
			}
			this.parent.red = true;
			this.script_nflg = false;
			this.sc_wk[0] = 1;
			return;
		}
		if (this.sc_wk[0] == 1)
		{
			this.parent.red = true;
			if (this.sc_messkip || this.script_cmd == 27)
			{
				this.ScWkClear();
				this.script_nflg = true;
				return;
			}
			this.sc_wk[2]++;
			if (this.sc_wk[2] >= this.sc_wk[3])
			{
				this.ScWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00106D08 File Offset: 0x00104F08
	private void ScrMessageClear()
	{
		for (int i = 0; i < 24; i++)
		{
			this.sc_str[i] = string.Empty;
			this.sc_strl = 0;
			this.sc_stry[i] = 0;
		}
		this.ScWkClear();
		this.parent.window_cnt = 0;
		this.parent.window_flg = false;
		this.parent.red = true;
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00106D6C File Offset: 0x00104F6C
	private void ScrWait()
	{
		if (this.sc_wk[0] == 0)
		{
			this.sc_wk[0] = 1;
			this.sc_wk[1] = 0;
			this.sc_wk[2] = (int)this.GetScrShort();
			this.script_nflg = false;
			return;
		}
		if (this.sc_wk[0] == 1)
		{
			this.sc_wk[1]++;
			if (this.sc_wk[1] >= this.sc_wk[2])
			{
				this.ScWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CE4 RID: 3300 RVA: 0x00106DE6 File Offset: 0x00104FE6
	private void ScrSetDrawArea()
	{
		this.sc_drawy = (int)this.GetScrShort();
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x00106DF4 File Offset: 0x00104FF4
	private void ScrMessageEnd2()
	{
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.parent.red = true;
			if ((this.parent.id_edge & 4112) != 0)
			{
				this.sc_wk[0]++;
				return;
			}
		}
		else if (this.sc_wk[0] == 1)
		{
			this.parent.red = true;
			this.parent.window_cnt--;
			if (this.parent.window_cnt <= 0)
			{
				this.ScWkClear();
				this.parent.window_cnt = 0;
				this.parent.window_flg = false;
				this.sc_face = 255;
				this.sc_strl = 0;
				this.script_nflg = true;
				this.sc_name = string.Empty;
			}
		}
	}

	// Token: 0x06000CE6 RID: 3302 RVA: 0x00106EC0 File Offset: 0x001050C0
	private void ScrSetFace()
	{
		sbyte scrByte = this.GetScrByte();
		if (scrByte == -1)
		{
			this.sc_face = 255;
			return;
		}
		this.sc_face = (int)scrByte;
	}

	// Token: 0x06000CE7 RID: 3303 RVA: 0x00106EEB File Offset: 0x001050EB
	private void ScrSetWindowY()
	{
		this.sc_winy = (int)this.GetScrShort();
		if (this.sc_winy >= 164)
		{
			this.sc_winy = 164;
		}
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x00106F14 File Offset: 0x00105114
	private void ScrMessageEndW()
	{
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.sc_wk[0] = 1;
			this.sc_wk[1] = (int)this.GetScrShort();
			if (this.parent.GetConfig(2) == 1 && this.sc_wk[1] != 0)
			{
				this.sc_wk[1] += 60;
				return;
			}
		}
		else if (this.sc_wk[0] == 1)
		{
			this.sc_wk[1]--;
			if (this.sc_wk[1] <= 0)
			{
				this.sc_wk[0] = 2;
				this.sc_wk[1] = 0;
				return;
			}
		}
		else if (this.sc_wk[0] == 2)
		{
			this.parent.red = true;
			if (this.script_cmd == 34)
			{
				this.ScWkClear();
				this.sc_strl = 0;
				this.script_nflg = true;
				return;
			}
			if (this.script_cmd == 102)
			{
				this.parent.window_cnt--;
				if (this.parent.window_cnt <= 0)
				{
					this.ScWkClear();
					this.parent.window_cnt = 0;
					this.parent.window_flg = false;
					this.sc_face = 255;
					this.sc_strl = 0;
					this.script_nflg = true;
					this.sc_name = string.Empty;
				}
			}
		}
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x00107060 File Offset: 0x00105260
	private void ScrSetMapPos()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		this.parent.SetMapPosU(num, num2);
		this.parent.red = true;
	}

	// Token: 0x06000CEA RID: 3306 RVA: 0x001070A0 File Offset: 0x001052A0
	private void ScrMessageNW()
	{
		if (this.sc_wk[0] == 0)
		{
			int i;
			for (i = 0; i < 60; i++)
			{
				this.msstr[i] = 0;
			}
			this.ScWkClear();
			int num = (int)this.GetScrShort();
			bool flag = true;
			i = 0;
			int num2 = 0;
			do
			{
				sbyte b = this.GetScrByte2(num);
				num++;
				if (b == 0)
				{
					sbyte scrByte = this.GetScrByte2(num);
					num++;
					if (scrByte == 0)
					{
						flag = false;
					}
					else
					{
						sbyte[] array = this.msstr;
						int num3 = i;
						array[num3] += b;
						i++;
						num2++;
						sbyte[] array2 = this.msstr;
						int num4 = i;
						array2[num4] += scrByte;
						i++;
						num2++;
					}
				}
				else if (128 <= (int)b || b <= -1)
				{
					sbyte[] array3 = this.msstr;
					int num5 = i;
					array3[num5] += b;
					i++;
					b = this.GetScrByte2(num);
					num++;
					sbyte[] array4 = this.msstr;
					int num6 = i;
					array4[num6] += b;
					i++;
					num2++;
				}
				else
				{
					sbyte[] array5 = this.msstr;
					int num7 = i;
					array5[num7] += b;
					i++;
					num2++;
				}
			}
			while (flag);
			if (this.sc_strl >= 23)
			{
				for (i = 0; i < 22; i++)
				{
					this.sc_str[i] = this.sc_str[i + 1];
				}
				this.sc_str[this.sc_strl] = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
				this.sc_str[this.sc_strl] = this.SpReplace(this.sc_str[this.sc_strl]);
				this.sc_wk[3] = num2;
			}
			else
			{
				this.sc_str[this.sc_strl] = SocotraRuntime.GetStringForBytesFromSjis(this.msstr);
				this.sc_str[this.sc_strl] = this.SpReplace(this.sc_str[this.sc_strl]);
				this.sc_wk[3] = num2;
				this.sc_strl++;
			}
			this.script_nflg = false;
			if (!this.parent.window_flg)
			{
				this.parent.window_flg = true;
				this.parent.window_cnt = 0;
				this.sc_wk[0] = 1;
			}
			else
			{
				this.sc_wk[0] = 2;
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 1)
		{
			this.parent.window_cnt++;
			if (this.parent.window_cnt >= 5)
			{
				this.sc_wk[0]++;
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 2)
		{
			this.ScWkClear();
			this.script_nflg = true;
		}
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x00107338 File Offset: 0x00105538
	private void ScrSetPicScroll()
	{
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.sc_wk[0] = 1;
			this.sc_wk[1] = (int)this.GetScrShort();
			return;
		}
		if (this.sc_wk[0] == 1)
		{
			if (this.sc_picy == this.sc_wk[1])
			{
				this.ScWkClear();
				this.script_nflg = true;
			}
			else if (this.sc_picy < this.sc_wk[1])
			{
				this.sc_picy++;
			}
			else if (this.sc_picy > this.sc_wk[1])
			{
				this.sc_picy--;
			}
			this.parent.red = true;
		}
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x001073E4 File Offset: 0x001055E4
	private void ScrSetPng()
	{
		int scrShort = (int)this.GetScrShort();
		if (scrShort < 0)
		{
			this.obj_pn[this.obj_no] = scrShort + 32768;
			this.obj_pn[this.obj_no] |= 32768;
		}
		else
		{
			this.obj_pn[this.obj_no] = scrShort;
		}
		this.parent.red = true;
		this.parent.compred = true;
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x00107454 File Offset: 0x00105654
	private void ScrMoveX()
	{
		this.script_nflg = false;
		this.parent.red = true;
		this.parent.compred = true;
		if (this.obj_wk[this.obj_no][0] == 65535)
		{
			this.obj_wk[this.obj_no][0] = (int)this.GetScrByte();
			this.obj_wk[this.obj_no][1] = (int)this.GetScrByte();
			this.obj_wk[this.obj_no][0] *= 16;
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[this.obj_no][0] == this.obj_wk[this.obj_no][0])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[this.obj_no][0] < this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][0] += this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][0] > this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][0] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[this.obj_no][0] > this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][0] -= this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][0] < this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][0] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x0010763C File Offset: 0x0010583C
	private void ScrMoveY()
	{
		this.script_nflg = false;
		this.parent.red = true;
		this.parent.compred = true;
		if (this.obj_wk[this.obj_no][0] == 65535)
		{
			this.obj_wk[this.obj_no][0] = (int)this.GetScrByte();
			this.obj_wk[this.obj_no][1] = (int)this.GetScrByte();
			this.obj_wk[this.obj_no][0] *= 16;
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[this.obj_no][1] == this.obj_wk[this.obj_no][0])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[this.obj_no][1] < this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][1] += this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][1] >= this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][1] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[this.obj_no][1] > this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][1] -= this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][1] <= this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][1] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00107824 File Offset: 0x00105A24
	private void ScrSetObject2()
	{
		int num = this.obj_xy[this.obj_no][0];
		int num2 = this.obj_xy[this.obj_no][1];
		int scrShort = (int)this.GetScrShort();
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x00107861 File Offset: 0x00105A61
	private void ScrKillObj()
	{
		this.obj_kill[this.obj_no] = 1;
		this.parent.red = true;
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x00107880 File Offset: 0x00105A80
	private void ScrObjWait()
	{
		this.script_nflg = false;
		if (this.obj_wk[this.obj_no][0] == 65535)
		{
			this.obj_wk[this.obj_no][0] = 0;
			this.obj_wk[this.obj_no][1] = (int)this.GetScrShort();
			return;
		}
		this.obj_wk[this.obj_no][1]--;
		if (this.obj_wk[this.obj_no][1] <= 0)
		{
			this.ObjWkClear();
			this.script_nflg = true;
		}
	}

	// Token: 0x06000CF2 RID: 3314 RVA: 0x00107908 File Offset: 0x00105B08
	private void ScrWalkX()
	{
		int num = this.obj_no;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][2] = (int)this.GetScrShort();
			this.obj_wk[num][0] = (int)this.GetScrByte();
			this.obj_wk[num][1] = (int)this.GetScrByte();
			this.obj_wk[num][3] = 0;
			this.obj_wk[num][0] *= 16;
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[num][0] == this.obj_wk[num][0])
		{
			this.obj_pn[num] = this.obj_wk[num][2] + 2;
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[num][0] < this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 3)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 4;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 4)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 3;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 3;
			}
			this.obj_xy[num][0] += this.obj_wk[num][1];
			if (this.obj_xy[num][0] >= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 2;
				this.obj_xy[num][0] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[num][0] > this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 32771)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32772;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 32772)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32771;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 32771;
			}
			this.obj_xy[num][0] -= this.obj_wk[num][1];
			if (this.obj_xy[num][0] <= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 32770;
				this.obj_xy[num][0] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CF3 RID: 3315 RVA: 0x00107CC8 File Offset: 0x00105EC8
	private void ScrWalkY()
	{
		int num = this.obj_no;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][2] = (int)this.GetScrShort();
			this.obj_wk[num][0] = (int)this.GetScrByte();
			this.obj_wk[num][1] = (int)this.GetScrByte();
			this.obj_wk[num][3] = 0;
			this.obj_wk[num][0] *= 16;
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[num][1] == this.obj_wk[num][0])
		{
			this.obj_pn[num] = this.obj_wk[num][2];
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[num][1] < this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 1)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32769;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 32769)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 1;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 1;
			}
			this.obj_xy[num][1] += this.obj_wk[num][1];
			if (this.obj_xy[num][1] >= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2];
				this.obj_xy[num][1] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[num][1] > this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 6)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32774;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 32774)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 6;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 6;
			}
			this.obj_xy[num][1] -= this.obj_wk[num][1];
			if (this.obj_xy[num][1] <= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 5;
				this.obj_xy[num][1] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CF4 RID: 3316 RVA: 0x0010807C File Offset: 0x0010627C
	private void ScrSetPlayPos()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.parent.chx = num + 8;
		this.parent.chy = num2 + 16;
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x001080C0 File Offset: 0x001062C0
	private void ScrMoveMapX()
	{
		this.parent.red = true;
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.sc_wk[0] = 1;
			this.sc_wk[1] = (int)this.GetScrByte();
			this.sc_wk[2] = (int)this.GetScrByte();
			this.sc_wk[1] *= 16;
			return;
		}
		if (this.parent.mapx == this.sc_wk[1])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.parent.mapx < this.sc_wk[1])
		{
			this.parent.mapx += this.sc_wk[2];
			if (this.parent.mapx >= this.sc_wk[1])
			{
				this.parent.mapx = this.sc_wk[1];
				this.ScWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.parent.mapx > this.sc_wk[1])
		{
			this.parent.mapx -= this.sc_wk[2];
			if (this.parent.mapx <= this.sc_wk[1])
			{
				this.parent.mapx = this.sc_wk[1];
				this.ScWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x00108214 File Offset: 0x00106414
	private void ScrMoveMapY()
	{
		this.parent.red = true;
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.sc_wk[0] = 1;
			this.sc_wk[1] = (int)this.GetScrByte();
			this.sc_wk[2] = (int)this.GetScrByte();
			this.sc_wk[1] *= 16;
			return;
		}
		if (this.parent.mapy == this.sc_wk[1])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.parent.mapy < this.sc_wk[1])
		{
			this.parent.mapy += this.sc_wk[2];
			if (this.parent.mapy >= this.sc_wk[1])
			{
				this.parent.mapy = this.sc_wk[1];
				this.ScWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.parent.mapy > this.sc_wk[1])
		{
			this.parent.mapy -= this.sc_wk[2];
			if (this.parent.mapy <= this.sc_wk[1])
			{
				this.parent.mapy = this.sc_wk[1];
				this.ScWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x00108368 File Offset: 0x00106568
	private void ScrMoveMapX2()
	{
		int num = this.obj_no;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][0] = 1;
			this.obj_wk[num][1] = (int)this.GetScrByte();
			this.obj_wk[num][2] = (int)this.GetScrByte();
			this.obj_wk[num][1] *= 16;
			return;
		}
		this.parent.red = true;
		if (this.parent.mapx == this.obj_wk[num][1])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.parent.mapx < this.obj_wk[num][1])
		{
			this.parent.mapx += this.obj_wk[num][2];
			if (this.parent.mapx >= this.obj_wk[num][1])
			{
				this.parent.mapx = this.obj_wk[num][1];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.parent.mapx > this.obj_wk[num][1])
		{
			this.parent.mapx -= this.obj_wk[num][2];
			if (this.parent.mapx <= this.obj_wk[num][1])
			{
				this.parent.mapx = this.obj_wk[num][1];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CF8 RID: 3320 RVA: 0x001084F0 File Offset: 0x001066F0
	private void ScrMoveMapY2()
	{
		int num = this.obj_no;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][0] = 1;
			this.obj_wk[num][1] = (int)this.GetScrByte();
			this.obj_wk[num][2] = (int)this.GetScrByte();
			this.obj_wk[num][1] *= 16;
			return;
		}
		this.parent.red = true;
		if (this.parent.mapy == this.obj_wk[num][1])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.parent.mapy < this.obj_wk[num][1])
		{
			this.parent.mapy += this.obj_wk[num][2];
			if (this.parent.mapy >= this.obj_wk[num][1])
			{
				this.parent.mapy = this.obj_wk[num][1];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.parent.mapy > this.obj_wk[num][1])
		{
			this.parent.mapy -= this.obj_wk[num][2];
			if (this.parent.mapy <= this.obj_wk[num][1])
			{
				this.parent.mapy = this.obj_wk[num][1];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x00108678 File Offset: 0x00106878
	private void ScrAnim()
	{
		int num = (int)this.GetScrShort();
		if (num < 0)
		{
			this.obj_anm[this.obj_no][0] = num + 32768;
			this.obj_anm[this.obj_no][0] |= 32768;
		}
		else
		{
			this.obj_anm[this.obj_no][0] = num;
		}
		num = (int)this.GetScrShort();
		if (num < 0)
		{
			this.obj_anm[this.obj_no][1] = num + 32768;
			this.obj_anm[this.obj_no][1] |= 32768;
		}
		else
		{
			this.obj_anm[this.obj_no][1] = num;
		}
		this.obj_anm[this.obj_no][2] = (int)this.GetScrByte();
		this.obj_anm[this.obj_no][3] = this.obj_anm[this.obj_no][2];
		this.obj_pn[this.obj_no] = this.obj_anm[this.obj_no][0];
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x00108772 File Offset: 0x00106972
	private void ScrChangeMap()
	{
		this.parent.isupdate = false;
		this.parent.mapno = (int)this.GetScrByte();
		this.parent.SetSeqNo(6);
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x001087A0 File Offset: 0x001069A0
	private void ScrSetObject3()
	{
		int num = (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num += scrByte;
		num2 *= 16;
		num2 += scrByte2;
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x001087F0 File Offset: 0x001069F0
	private void ScrWalkX2()
	{
		int num = this.obj_no;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][2] = (int)this.GetScrShort();
			this.obj_wk[num][0] = (int)this.GetScrByte();
			this.obj_wk[num][0] *= 16;
			this.obj_wk[num][0] += (int)this.GetScrByte();
			this.obj_wk[num][1] = (int)this.GetScrByte();
			this.obj_wk[num][3] = 0;
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[num][0] == this.obj_wk[num][0])
		{
			this.obj_pn[num] = this.obj_wk[num][2] + 2;
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[num][0] < this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 3)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 4;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 4)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 3;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 3;
			}
			this.obj_xy[num][0] += this.obj_wk[num][1];
			if (this.obj_xy[num][0] >= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 2;
				this.obj_xy[num][0] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[num][0] > this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 32771)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32772;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 32772)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32771;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 32771;
			}
			this.obj_xy[num][0] -= this.obj_wk[num][1];
			if (this.obj_xy[num][0] <= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 32770;
				this.obj_xy[num][0] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x00108BC8 File Offset: 0x00106DC8
	private void ScrWalkY2()
	{
		int num = this.obj_no;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][2] = (int)this.GetScrShort();
			this.obj_wk[num][0] = (int)this.GetScrByte();
			this.obj_wk[num][0] *= 16;
			this.obj_wk[num][0] += (int)this.GetScrByte();
			this.obj_wk[num][1] = (int)this.GetScrByte();
			this.obj_wk[num][3] = 0;
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[num][1] == this.obj_wk[num][0])
		{
			this.obj_pn[num] = this.obj_wk[num][2];
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[num][1] < this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 1)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32769;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 32769)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 1;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 1;
			}
			this.obj_xy[num][1] += this.obj_wk[num][1];
			if (this.obj_xy[num][1] >= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2];
				this.obj_xy[num][1] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[num][1] > this.obj_wk[num][0])
		{
			if (this.obj_pn[num] == this.obj_wk[num][2] + 6)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 32774;
				}
			}
			else if (this.obj_pn[num] == this.obj_wk[num][2] + 32774)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 16 / this.obj_wk[num][1])
				{
					this.obj_wk[num][3] = 0;
					this.obj_pn[num] = this.obj_wk[num][2] + 6;
				}
			}
			else
			{
				this.obj_wk[num][3] = 0;
				this.obj_pn[num] = this.obj_wk[num][2] + 6;
			}
			this.obj_xy[num][1] -= this.obj_wk[num][1];
			if (this.obj_xy[num][1] <= this.obj_wk[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 5;
				this.obj_xy[num][1] = this.obj_wk[num][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00108F94 File Offset: 0x00107194
	private void ScrSetPlayPos2()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		num += (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		num2 += (int)this.GetScrByte();
		this.parent.chx = num + 8;
		this.parent.chy = num2 + 24;
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x00108FE8 File Offset: 0x001071E8
	private void ScrObjectClear()
	{
		this.ScriptObjInit();
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x00108FF0 File Offset: 0x001071F0
	private void ScrSetChar2()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		num += (int)this.GetScrByte();
		num += 8;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		num2 += (int)this.GetScrByte();
		num2 += 24;
		int num3 = (int)this.GetScrShort();
		if (num3 < 0)
		{
			num3 += 32768;
			num3 |= 32768;
		}
		int num4 = (int)this.GetScrShort();
		if (num4 < 0)
		{
			num4 += 32768;
			num4 |= 32768;
		}
		int scrShort = (int)this.GetScrShort();
		this.SetNpcChar2(num, num2, num3, num4, scrShort);
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00109080 File Offset: 0x00107280
	private void ScrSelect()
	{
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.sc_wk[0] = 1;
			this.sc_wk[1] = (int)this.GetScrShort();
			this.sc_wk[2] = (int)this.GetScrShort();
			this.parent.cur[0] = 0;
			if (!this.parent.window_flg)
			{
				this.parent.window_flg = true;
				this.parent.window_cnt = 0;
				this.sc_wk[0] = 1;
			}
			else
			{
				this.sc_wk[0] = 2;
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 1)
		{
			this.parent.window_cnt++;
			if (this.parent.window_cnt >= 5)
			{
				this.sc_wk[0]++;
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 2)
		{
			if ((this.parent.id_edge & 1) != 0 || (this.parent.id_edge & 2) != 0)
			{
				this.parent.cur[0] = (this.parent.cur[0] + 1) % 2;
				this.parent.PlaySe(2);
			}
			else if ((this.parent.id_edge & 4112) != 0)
			{
				this.sc_wk[0] = 3;
				this.parent.PlaySe(0);
			}
			this.parent.red = true;
			return;
		}
		if (this.sc_wk[0] == 3)
		{
			this.parent.red = true;
			this.parent.window_cnt--;
			if (this.parent.window_cnt <= 0)
			{
				this.script_adr = this.sc_wk[1 + this.parent.cur[0]];
				this.ScWkClear();
				this.parent.window_cnt = 0;
				this.parent.window_flg = false;
				this.sc_face = 255;
				this.sc_strl = 0;
				this.script_nflg = true;
				this.sc_name = string.Empty;
			}
		}
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x00109284 File Offset: 0x00107484
	private void ScrSetMapPosP()
	{
		this.parent.SetMapPos();
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x00109294 File Offset: 0x00107494
	private void ScrSetPlayPng()
	{
		int scrShort = (int)this.GetScrShort();
		if (scrShort < 0)
		{
			this.parent.chm = scrShort + 32768;
			this.parent.chm |= 32768;
			return;
		}
		this.parent.chm = scrShort;
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x001092E4 File Offset: 0x001074E4
	private void ScrSetTouchObj()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetTouchObj(num, num2, 255, scrByte, scrShort);
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x00109326 File Offset: 0x00107526
	private void ScrSetObjPrio()
	{
		this.obj_prio[this.obj_no] = (int)this.GetScrByte();
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x0010933C File Offset: 0x0010753C
	private void ScrStartLaster()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster(scrByte);
		this.parent.PartLasterStart();
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00109372 File Offset: 0x00107572
	private void ScrEndLaster()
	{
		this.parent.PartLasterEnd();
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00109380 File Offset: 0x00107580
	private void ScrSetPlayChar()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.SetMapPlayerChar(scrByte);
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x001093A0 File Offset: 0x001075A0
	private void ScrSetApprChar()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.SetRanks(this.parent.apr_no, scrByte);
		this.parent.SetStatus(scrByte, 20, 0);
		if (this.parent.apr_no == 0)
		{
			this.parent.SetMapPlayerChar(scrByte);
		}
		else if (this.parent.apr_no == 3)
		{
			this.parent.SetStatus(scrByte, 20, 1);
		}
		this.parent.apr_no++;
		if (this.parent.apr_no >= 4)
		{
			this.parent.apr_no = 0;
		}
	}

	// Token: 0x06000D0A RID: 3338 RVA: 0x00109440 File Offset: 0x00107640
	private void ScrGetItem()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.AddItem(scrByte, 1);
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00109464 File Offset: 0x00107664
	private void ScrSetTObjPng()
	{
		int scrShort = (int)this.GetScrShort();
		if (scrShort < 0)
		{
			this.tobj_pn[this.tobj_no] = scrShort + 32768;
			this.tobj_pn[this.tobj_no] |= 32768;
		}
		else
		{
			this.tobj_pn[this.tobj_no] = scrShort;
		}
		this.parent.red = true;
		this.parent.compred = true;
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x001094D4 File Offset: 0x001076D4
	private void ScrSetTouchObj2()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		int scrByte = (int)this.GetScrByte();
		int scrShort2 = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetTouchObj(num, num2, scrShort, scrByte, scrShort2);
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x0010951B File Offset: 0x0010771B
	private void ScrQuake()
	{
		this.parent.quf = 2;
		this.parent.StartVib(65535);
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x0010953C File Offset: 0x0010773C
	private void ScrSpLaser()
	{
		this.parent.slxy[0] = (int)this.GetScrShort();
		this.parent.slxy[1] = (int)this.GetScrShort();
		this.parent.slxy[2] = this.parent.slxy[0];
		this.parent.slxy[3] = this.parent.slxy[1];
		this.parent.slwk[0] = (int)this.GetScrShort();
		this.parent.slwk[1] = (int)this.GetScrShort();
		this.parent.slwk[2] = (this.parent.slwk[0] - this.parent.slxy[0]) / 5;
		this.parent.slwk[3] = (this.parent.slwk[1] - this.parent.slxy[1]) / 5;
		this.parent.slwk[4] = 0;
		this.parent.slf = 1;
		this.parent.PlaySe(10);
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x00109644 File Offset: 0x00107844
	private void ScrFadePng()
	{
		int num = this.obj_no;
		this.parent.red = true;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			int num2;
			if (this.obj_pn[num] == 255)
			{
				num2 = (int)this.GetScrByte();
				this.parent.PngFadeStop();
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
			this.obj_wk[num][0] = 1;
			this.obj_wk[num][1] = this.parent.GetPngHeight(this.obj_pn[num]);
			this.obj_pn[num] |= 65536;
			num2 = (int)this.GetScrByte();
			this.parent.PngFadeInit(num2);
			if (num2 == 2 || num2 == 3 || num2 == 5)
			{
				this.obj_wk[num][3] = this.obj_wk[num][1];
				this.obj_wk[num][1] = 0;
				return;
			}
		}
		else if (this.obj_wk[num][0] == 1)
		{
			if (this.parent.pfflag == 1)
			{
				this.obj_wk[num][1] -= 2;
				if (this.obj_wk[num][1] <= 0)
				{
					this.obj_wk[num][0] = 2;
					this.obj_wk[num][1] = 0;
					this.obj_wk[num][2] = 0;
					return;
				}
			}
			else if (this.parent.pfflag == 2)
			{
				this.obj_wk[num][1] += 2;
				if (this.obj_wk[num][1] >= this.obj_wk[num][3])
				{
					this.obj_wk[num][0] = 2;
					this.obj_wk[num][1] = this.obj_wk[num][3];
					this.obj_wk[num][2] = 0;
					return;
				}
			}
			else if (this.parent.pfflag == 3)
			{
				this.obj_wk[num][1]++;
				if (this.obj_wk[num][1] >= this.obj_wk[num][3])
				{
					this.obj_wk[num][0] = 2;
					this.obj_wk[num][1] = this.obj_wk[num][3];
					this.obj_wk[num][2] = 0;
					return;
				}
			}
			else if (this.parent.pfflag == 4)
			{
				this.obj_wk[num][1]--;
				if (this.obj_wk[num][1] <= 0)
				{
					this.obj_wk[num][0] = 2;
					this.obj_wk[num][1] = 0;
					this.obj_wk[num][2] = 0;
					return;
				}
			}
			else if (this.parent.pfflag == 5)
			{
				this.obj_wk[num][1]++;
				if (this.obj_wk[num][1] >= this.obj_wk[num][3])
				{
					this.obj_wk[num][0] = 2;
					this.obj_wk[num][1] = this.obj_wk[num][3];
					this.obj_wk[num][2] = 0;
					return;
				}
			}
			else if (this.parent.pfflag == 0)
			{
				this.obj_pn[num] = 255;
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_wk[num][0] == 2)
		{
			this.obj_wk[num][2]++;
			if (this.obj_wk[num][2] >= 8)
			{
				if (this.parent.pfflag == 1 || this.parent.pfflag == 3)
				{
					this.obj_pn[num] = 255;
				}
				else if (this.parent.pfflag == 2 || this.parent.pfflag == 4 || this.parent.pfflag == 5)
				{
					this.obj_pn[num] &= -65537;
				}
				this.parent.PngFadeStop();
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x00109A00 File Offset: 0x00107C00
	private void ScrStartLaster2()
	{
		int scrByte = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster2(scrByte, scrByte2);
		this.parent.PartLasterStart();
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x00109A40 File Offset: 0x00107C40
	private void ScrMoveXY()
	{
		int num = this.obj_no;
		this.parent.red = true;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] == 65535)
		{
			this.obj_wk[num][0] = 1;
			int num2 = (int)this.GetScrByte();
			num2 *= 16;
			num2 += (int)this.GetScrByte();
			int num3 = (int)this.GetScrByte();
			num3 *= 16;
			num3 += (int)this.GetScrByte();
			int scrByte = (int)this.GetScrByte();
			this.obj_wk[num][1] = num2;
			this.obj_wk[num][2] = num3;
			this.obj_wk[num][3] = scrByte;
			return;
		}
		if (this.obj_wk[num][0] == 1)
		{
			int num2 = (this.obj_wk[num][1] - this.obj_xy[num][0]) / this.obj_wk[num][3];
			int num3 = (this.obj_wk[num][2] - this.obj_xy[num][1]) / this.obj_wk[num][3];
			this.obj_wk[num][3]--;
			this.obj_xy[num][0] += num2;
			this.obj_xy[num][1] += num3;
			if (this.obj_wk[num][3] <= 0)
			{
				this.obj_xy[num][0] = this.obj_wk[num][1];
				this.obj_xy[num][1] = this.obj_wk[num][2];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x00109BAF File Offset: 0x00107DAF
	private void ScrStartVib()
	{
		this.parent.StartVib(65535);
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x00109BC1 File Offset: 0x00107DC1
	private void ScrStopVib()
	{
		this.parent.StopVib();
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x00109BD0 File Offset: 0x00107DD0
	private void ScrLaserReady()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 2;
		this.parent.slxy[0] = (int)this.GetScrShort();
		this.parent.slxy[1] = (int)this.GetScrShort();
		this.parent.slxy[2] = 0;
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x00109C28 File Offset: 0x00107E28
	private void ScrLaserReadyStop()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 0;
		this.parent.slxy[0] = (this.parent.slxy[1] = (this.parent.slxy[2] = 0));
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x00109C7A File Offset: 0x00107E7A
	private void ScrQuake2()
	{
		this.parent.quf = 1;
		this.parent.StartVib(65535);
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x00109C98 File Offset: 0x00107E98
	private void ScrQuakeStop()
	{
		this.parent.quf = 0;
		this.parent.qux = (this.parent.quy = 0);
		this.parent.StopVib();
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x00109CD6 File Offset: 0x00107ED6
	private void ScrSkipAddress()
	{
		this.sc_skipadr = (int)this.GetScrShort();
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00109CE4 File Offset: 0x00107EE4
	private void ScrApprCharClear()
	{
		this.parent.apr_no = 0;
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, 255);
			this.parent.SetStatus(i, 20, 2);
		}
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x00109D2C File Offset: 0x00107F2C
	private void ScrMessageEndV()
	{
		this.script_nflg = false;
		if (this.sc_wk[0] == 0)
		{
			this.parent.red = true;
			if ((this.parent.id_edge & 4112) != 0)
			{
				this.sc_wk[0] = 1;
				return;
			}
		}
		else if (this.sc_wk[0] == 1)
		{
			for (int i = 0; i < 24; i++)
			{
				this.sc_str[i] = string.Empty;
				this.sc_strl = 0;
				this.sc_stry[i] = 0;
			}
			this.ScWkClear();
			this.sc_strl = 0;
			this.script_nflg = true;
		}
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x00109DBC File Offset: 0x00107FBC
	private void ScrSetNpcPng()
	{
		int num = (int)this.GetScrShort();
		if (num < 0)
		{
			num += 32768;
			num |= 32768;
		}
		int num2 = (int)this.GetScrShort();
		if (num2 < 0)
		{
			num2 += 32768;
			num2 |= 32768;
		}
		this.npc_pn[this.npc_no][0] = num;
		this.npc_pn[this.npc_no][1] = num2;
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x00109E20 File Offset: 0x00108020
	private void ScrMoveX2()
	{
		this.script_nflg = false;
		this.parent.red = true;
		this.parent.compred = true;
		if (this.obj_wk[this.obj_no][0] == 65535)
		{
			this.obj_wk[this.obj_no][0] = (int)this.GetScrByte();
			this.obj_wk[this.obj_no][0] *= 16;
			this.obj_wk[this.obj_no][0] += (int)this.GetScrByte();
			this.obj_wk[this.obj_no][1] = (int)this.GetScrByte();
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[this.obj_no][0] == this.obj_wk[this.obj_no][0])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[this.obj_no][0] < this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][0] += this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][0] > this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][0] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[this.obj_no][0] > this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][0] -= this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][0] < this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][0] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x0010A024 File Offset: 0x00108224
	private void ScrMoveY2()
	{
		this.script_nflg = false;
		this.parent.red = true;
		this.parent.compred = true;
		if (this.obj_wk[this.obj_no][0] == 65535)
		{
			this.obj_wk[this.obj_no][0] = (int)this.GetScrByte();
			this.obj_wk[this.obj_no][0] *= 16;
			this.obj_wk[this.obj_no][0] += (int)this.GetScrByte();
			this.obj_wk[this.obj_no][1] = (int)this.GetScrByte();
			return;
		}
		this.parent.red = true;
		if (this.obj_xy[this.obj_no][1] == this.obj_wk[this.obj_no][0])
		{
			this.ObjWkClear();
			this.script_nflg = true;
			return;
		}
		if (this.obj_xy[this.obj_no][1] < this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][1] += this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][1] >= this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][1] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else if (this.obj_xy[this.obj_no][1] > this.obj_wk[this.obj_no][0])
		{
			this.obj_xy[this.obj_no][1] -= this.obj_wk[this.obj_no][1];
			if (this.obj_xy[this.obj_no][1] <= this.obj_wk[this.obj_no][0])
			{
				this.obj_xy[this.obj_no][1] = this.obj_wk[this.obj_no][0];
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x0010A228 File Offset: 0x00108428
	private void ScrPlaySe()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PlaySe(scrByte);
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x0010A248 File Offset: 0x00108448
	private void ScrPlayBgm()
	{
		int scrByte = (int)this.GetScrByte();
		if (!this.parent.IsNowBgm(scrByte))
		{
			this.parent.StopAllSound();
			this.parent.SetBgm(scrByte);
		}
		if (!this.parent.IsPlayBgm())
		{
			this.parent.PlayBgm();
		}
	}

	// Token: 0x06000D20 RID: 3360 RVA: 0x0010A299 File Offset: 0x00108499
	private void ScrStopBgm()
	{
		this.parent.StopAllSound();
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x0010A2A6 File Offset: 0x001084A6
	private void ScrRevivePoint()
	{
		this.parent.SetRevivePoint();
	}

	// Token: 0x06000D22 RID: 3362 RVA: 0x0010A2B3 File Offset: 0x001084B3
	private void ScrStopSe()
	{
		this.parent.StopSe();
	}

	// Token: 0x06000D23 RID: 3363 RVA: 0x0010A2C0 File Offset: 0x001084C0
	private void ScrApprCharPush()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.ranks2[i][0] = this.parent.GetRanks(i);
			this.parent.ranks2[i][1] = this.parent.GetStatus(i, 20);
		}
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x0010A314 File Offset: 0x00108514
	private void ScrApprCharPop()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, this.parent.ranks2[i][0]);
			this.parent.SetStatus(i, 20, this.parent.ranks2[i][1]);
		}
		this.parent.SetMapPlayerChar(this.parent.ranks2[0][0]);
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x0010A380 File Offset: 0x00108580
	private void ScrMessageEnd3()
	{
		this.script_nflg = false;
		int num;
		if (this.sc_wk[0] != 0)
		{
			if (this.sc_wk[0] == 1)
			{
				this.parent.red = true;
				num = this.sc_wk[1];
				if (this.sc_flg[num] != 0)
				{
					this.sc_wk[0] = 2;
					return;
				}
			}
			else if (this.sc_wk[0] == 2)
			{
				this.parent.red = true;
				if ((this.parent.id_edge & 4112) != 0)
				{
					this.sc_wk[0] = 3;
					return;
				}
			}
			else if (this.sc_wk[0] == 3)
			{
				this.parent.red = true;
				this.parent.window_cnt--;
				if (this.parent.window_cnt <= 0)
				{
					this.ScWkClear();
					this.parent.window_cnt = 0;
					this.parent.window_flg = false;
					this.sc_face = 255;
					this.sc_strl = 0;
					this.script_nflg = true;
					this.sc_name = string.Empty;
				}
			}
			return;
		}
		num = (int)this.GetScrByte();
		this.sc_wk[1] = num;
		this.parent.red = true;
		if (this.sc_flg[num] != 0)
		{
			this.sc_wk[0] = 2;
			return;
		}
		this.sc_wk[0] = 1;
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x0010A4C0 File Offset: 0x001086C0
	private void ScrVisualRead()
	{
		int scrByte = (int)this.GetScrByte();
		if (this.script_cmd == 96)
		{
			this.parent.ReadVisualData(scrByte);
			return;
		}
		if (this.script_cmd == 112)
		{
			this.parent.ReadVisualData2(scrByte);
		}
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x0010A504 File Offset: 0x00108704
	private void ScrSetTrap()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.SetTrap(num, num2, scrByte);
	}

	// Token: 0x06000D28 RID: 3368 RVA: 0x0010A53C File Offset: 0x0010873C
	private void ScrSetTouchObj3()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		int scrByte = (int)this.GetScrByte();
		int scrShort2 = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetTouchObj(num, num2, scrShort, scrByte, scrShort2);
		this.tobj_cno[this.tobj_p - 1] = (int)this.GetScrByte();
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x0010A598 File Offset: 0x00108798
	private void ScrDestruction()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		num += (int)this.GetScrByte();
		num -= 4;
		num -= this.parent.mapx;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		num2 += (int)this.GetScrByte();
		num2 += 8;
		num2 -= this.parent.mapy;
		for (int i = 0; i < 10; i++)
		{
			this.parent.dwk[i][0] = num;
			this.parent.dwk[i][1] = num2;
		}
		this.parent.dflag = 1;
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x0010A62C File Offset: 0x0010882C
	private void ScrMessageEnd3W()
	{
		this.script_nflg = false;
		int num;
		if (this.sc_wk[0] != 0)
		{
			if (this.sc_wk[0] == 1)
			{
				this.parent.red = true;
				num = this.sc_wk[1];
				if (this.sc_flg[num] != 0)
				{
					this.sc_wk[0] = 2;
					return;
				}
			}
			else if (this.sc_wk[0] == 2)
			{
				this.parent.red = true;
				if (this.script_cmd == 105)
				{
					this.ScWkClear();
					this.sc_strl = 0;
					this.script_nflg = true;
					return;
				}
				this.parent.window_cnt--;
				if (this.parent.window_cnt <= 0)
				{
					this.ScWkClear();
					this.parent.window_cnt = 0;
					this.parent.window_flg = false;
					this.sc_face = 255;
					this.sc_strl = 0;
					this.script_nflg = true;
					this.sc_name = string.Empty;
				}
			}
			return;
		}
		num = (int)this.GetScrByte();
		this.sc_wk[1] = num;
		this.parent.red = true;
		if (this.sc_flg[num] != 0)
		{
			this.sc_wk[0] = 2;
			return;
		}
		this.sc_wk[0] = 1;
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x0010A757 File Offset: 0x00108957
	private void ScrStartDecieve()
	{
		this.parent.StartDecieve();
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x0010A764 File Offset: 0x00108964
	private void ScrStopDecieve()
	{
		this.parent.StopDecieve();
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x0010A771 File Offset: 0x00108971
	private void ScrSetFont()
	{
		this.parent.scrfont = (int)this.GetScrByte();
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x0010A784 File Offset: 0x00108984
	private void ScrOpenLid()
	{
		int scrByte = (int)this.GetScrByte();
		if (scrByte == 0)
		{
			this.parent.ol_flag = 1;
			return;
		}
		if (scrByte == 1)
		{
			this.parent.ol_flag = 2;
		}
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x0010A7B8 File Offset: 0x001089B8
	private void ScrLuminescence()
	{
		this.parent.Lum_flag = (int)this.GetScrByte();
		this.parent.Lum_no = this.obj_no;
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x0010A7DC File Offset: 0x001089DC
	private void ScrSetTouchObj4()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		num += (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		num2 += (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		this.SetTouchObj(num, num2, 255, scrByte, scrShort);
	}

	// Token: 0x06000D31 RID: 3377 RVA: 0x0010A830 File Offset: 0x00108A30
	private void ScrSetPngMapChara()
	{
		int num = (int)this.GetScrShort();
		if (num == 255)
		{
			num = this.parent.chm;
			if (num == 32769 || num == 1 || num == 0)
			{
				num = 0;
			}
			else if (num == 4 || num == 3 || num == 2)
			{
				num = 2;
			}
			else if (num == 32774 || num == 6 || num == 5)
			{
				num = 5;
			}
			else if (num == 32772 || num == 32771 || num == 32770)
			{
				num = 32770;
			}
		}
		int num2 = this.parent.chc + num;
		if (num2 < 0)
		{
			this.obj_pn[this.obj_no] = num2 + 32768;
			this.obj_pn[this.obj_no] |= 32768;
		}
		else
		{
			this.obj_pn[this.obj_no] = num2;
		}
		this.parent.red = true;
		this.parent.compred = true;
	}

	// Token: 0x040007B1 RID: 1969
	protected internal XenoPP06Canvas parent;

	// Token: 0x040007B2 RID: 1970
	public sbyte[] script;

	// Token: 0x040007B3 RID: 1971
	public int script_adr;

	// Token: 0x040007B4 RID: 1972
	public int script_adr_ret;

	// Token: 0x040007B5 RID: 1973
	public int script_b_adr;

	// Token: 0x040007B6 RID: 1974
	public bool script_nflg;

	// Token: 0x040007B7 RID: 1975
	public bool script_b_nflg;

	// Token: 0x040007B8 RID: 1976
	public bool script_flg;

	// Token: 0x040007B9 RID: 1977
	public int script_cmd;

	// Token: 0x040007BA RID: 1978
	public int script_b_cmd;

	// Token: 0x040007BB RID: 1979
	public int[] sc_wk;

	// Token: 0x040007BC RID: 1980
	public string[] sc_str;

	// Token: 0x040007BD RID: 1981
	public string sc_name;

	// Token: 0x040007BE RID: 1982
	public int sc_strl;

	// Token: 0x040007BF RID: 1983
	public bool[] sc_ifflg;

	// Token: 0x040007C0 RID: 1984
	public bool[] sc_b_ifflg;

	// Token: 0x040007C1 RID: 1985
	public sbyte sc_ifdpt;

	// Token: 0x040007C2 RID: 1986
	public sbyte sc_b_ifdpt;

	// Token: 0x040007C3 RID: 1987
	public bool sc_messkip;

	// Token: 0x040007C4 RID: 1988
	public int sc_skipadr;

	// Token: 0x040007C5 RID: 1989
	public int[] sc_flg;

	// Token: 0x040007C6 RID: 1990
	public int sc_face;

	// Token: 0x040007C7 RID: 1991
	public sbyte[] vscript;

	// Token: 0x040007C8 RID: 1992
	public int[] sc_stry;

	// Token: 0x040007C9 RID: 1993
	public int sc_picy;

	// Token: 0x040007CA RID: 1994
	public int sc_picno;

	// Token: 0x040007CB RID: 1995
	public int sc_drawy;

	// Token: 0x040007CC RID: 1996
	public int sc_wait;

	// Token: 0x040007CD RID: 1997
	public int sc_winy;

	// Token: 0x040007CE RID: 1998
	private sbyte[] msstr;

	// Token: 0x040007CF RID: 1999
	public int[][] npc_xy;

	// Token: 0x040007D0 RID: 2000
	public int[][] npc_pn;

	// Token: 0x040007D1 RID: 2001
	public int[] npc_mv;

	// Token: 0x040007D2 RID: 2002
	public int[] npc_adr;

	// Token: 0x040007D3 RID: 2003
	public int npc_p;

	// Token: 0x040007D4 RID: 2004
	public int npc_no;

	// Token: 0x040007D5 RID: 2005
	public int[][] npc_wk;

	// Token: 0x040007D6 RID: 2006
	public int[][] obj_xy;

	// Token: 0x040007D7 RID: 2007
	public int[] obj_pn;

	// Token: 0x040007D8 RID: 2008
	public int[] obj_adr;

	// Token: 0x040007D9 RID: 2009
	public int[] obj_kill;

	// Token: 0x040007DA RID: 2010
	public int[] obj_cmd;

	// Token: 0x040007DB RID: 2011
	public int[][] obj_anm;

	// Token: 0x040007DC RID: 2012
	public int[] obj_prio;

	// Token: 0x040007DD RID: 2013
	public bool[] obj_nflg;

	// Token: 0x040007DE RID: 2014
	public int[][] obj_wk;

	// Token: 0x040007DF RID: 2015
	public int obj_p;

	// Token: 0x040007E0 RID: 2016
	public int obj_no;

	// Token: 0x040007E1 RID: 2017
	public int[][] tobj_xy;

	// Token: 0x040007E2 RID: 2018
	public int[] tobj_adr;

	// Token: 0x040007E3 RID: 2019
	public int[] tobj_cnd;

	// Token: 0x040007E4 RID: 2020
	public int[] tobj_pn;

	// Token: 0x040007E5 RID: 2021
	public int tobj_p;

	// Token: 0x040007E6 RID: 2022
	public int tobj_no;

	// Token: 0x040007E7 RID: 2023
	public int[] tobj_cno;

	// Token: 0x040007E8 RID: 2024
	public int[][] trap_xy;

	// Token: 0x040007E9 RID: 2025
	public int[] trap_id;

	// Token: 0x040007EA RID: 2026
	public int trap_p;
}
