using System;

// Token: 0x02000039 RID: 57
public sealed class XScript04
{
	// Token: 0x06000884 RID: 2180 RVA: 0x000ACBDC File Offset: 0x000AADDC
	protected internal XScript04(XenoPP04Canvas cvs)
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
			new int[2]
		};
		this.tobj_adr = new int[24];
		this.tobj_cnd = new int[24];
		this.tobj_pn = new int[24];
		this.tobj_cno = new int[24];
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
			new int[2]
		};
		this.trap_id = new int[32];
		this.trap_p = 0;
		this.find_xy = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.find_wh = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.find_flag = new int[6];
		this.find_adr = new int[6];
		this.find_p = 0;
		this.walk_stop_flag = false;
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x000ADD8C File Offset: 0x000ABF8C
	public void ScFlagClear()
	{
		for (int i = 0; i < 80; i++)
		{
			this.sc_flg[i] = 0;
		}
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x000ADDB0 File Offset: 0x000ABFB0
	public void ScWkClear()
	{
		for (int i = 0; i < 8; i++)
		{
			this.sc_wk[i] = 0;
		}
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x000ADDD4 File Offset: 0x000ABFD4
	public void ObjWkClear()
	{
		for (int i = 0; i < 4; i++)
		{
			this.obj_wk[this.obj_no][i] = 65535;
		}
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x000ADE04 File Offset: 0x000AC004
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

	// Token: 0x06000889 RID: 2185 RVA: 0x000ADE4C File Offset: 0x000AC04C
	public short GetScrShort()
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP04Canvas.ArrayShort2(this.script, this.script_adr);
		}
		else
		{
			num = XenoPP04Canvas.ArrayShort2(this.vscript, this.script_adr);
		}
		this.script_adr += 2;
		return num;
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x000ADE9C File Offset: 0x000AC09C
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

	// Token: 0x0600088B RID: 2187 RVA: 0x000ADECC File Offset: 0x000AC0CC
	public short GetScrShort2(int adr)
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP04Canvas.ArrayShort2(this.script, adr);
		}
		else
		{
			num = XenoPP04Canvas.ArrayShort2(this.vscript, adr);
		}
		return num;
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x000ADF04 File Offset: 0x000AC104
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
			if (this.parent.mapno == 7)
			{
				this.npc_xy[this.npc_p][1] = (this.npc_xy[this.npc_p][3] = y + 8);
			}
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

	// Token: 0x0600088D RID: 2189 RVA: 0x000AE050 File Offset: 0x000AC250
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

	// Token: 0x0600088E RID: 2190 RVA: 0x000AE11C File Offset: 0x000AC31C
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

	// Token: 0x0600088F RID: 2191 RVA: 0x000AE200 File Offset: 0x000AC400
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

	// Token: 0x06000890 RID: 2192 RVA: 0x000AE284 File Offset: 0x000AC484
	public void SetTrap(int x, int y, int id)
	{
		if (this.trap_p < 32)
		{
			this.trap_xy[this.trap_p][0] = x;
			this.trap_xy[this.trap_p][1] = y;
			this.trap_id[this.trap_p] = id;
			this.trap_p++;
		}
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x000AE2D8 File Offset: 0x000AC4D8
	public void SetFindArea(int x, int y, int w, int h, int flag, int adr)
	{
		if (this.find_p < 6)
		{
			this.find_xy[this.find_p][0] = x;
			this.find_xy[this.find_p][1] = y;
			this.find_wh[this.find_p][0] = w;
			this.find_wh[this.find_p][1] = h;
			this.find_flag[this.find_p] = flag;
			this.find_adr[this.find_p] = adr;
			this.find_p++;
		}
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x000AE35B File Offset: 0x000AC55B
	public bool IsMessageSelect()
	{
		return this.script_cmd == 59;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x000AE36C File Offset: 0x000AC56C
	public bool IsMessageEnd()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || this.script_cmd == 34 || this.script_cmd == 36 || this.script_cmd == 95 || this.script_cmd == 102 || this.script_cmd == 104 || this.script_cmd == 105 || (this.script_cmd == 4 && this.sc_wk[0] == 0);
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x000AE3E0 File Offset: 0x000AC5E0
	public bool IsMessageEnd2()
	{
		return this.script_cmd == 21 || this.script_cmd == 27 || (this.script_cmd != 26 && this.script_cmd != 7) || ((this.script_cmd == 26 || this.script_cmd == 7) && this.sc_wk[0] == 0);
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000AE434 File Offset: 0x000AC634
	public bool IsMessageEnd3()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || (this.script_cmd == 95 && this.sc_wk[0] >= 2);
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000AE462 File Offset: 0x000AC662
	public bool IsMessageEnd4()
	{
		return this.script_cmd == 84;
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x000AE471 File Offset: 0x000AC671
	public bool IsMessage()
	{
		return this.script_cmd == 4;
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000AE47F File Offset: 0x000AC67F
	public bool IsMessage2()
	{
		return this.script_cmd == 26 || this.script_cmd == 7;
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x000AE497 File Offset: 0x000AC697
	public string SpReplace(string str)
	{
		return str.Replace('Ⅰ', '\ue6e2').Replace('Ⅱ', '\ue6e3').Replace('Ⅲ', '\ue6e4');
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x000AE4C8 File Offset: 0x000AC6C8
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
		for (int i = 0; i < 24; i++)
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
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.trap_xy[i][j] = 0;
			}
			this.trap_id[i] = 0;
		}
		this.find_p = 0;
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.find_xy[i][j] = 0;
				this.find_wh[i][j] = 0;
			}
			this.find_flag[i] = 0;
			this.find_adr[i] = 0;
		}
		this.walk_stop_flag = false;
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x000AE630 File Offset: 0x000AC830
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

	// Token: 0x0600089C RID: 2204 RVA: 0x000AE76C File Offset: 0x000AC96C
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

	// Token: 0x0600089D RID: 2205 RVA: 0x000AE818 File Offset: 0x000ACA18
	public void ScriptInit3(int adr)
	{
		this.script_adr = adr;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x000AE848 File Offset: 0x000ACA48
	public void ScriptInit4(int adr)
	{
		this.script_adr = adr;
		this.script_nflg = true;
		this.script_flg = false;
		this.script_adr_ret = 0;
		this.walk_stop_flag = true;
		if (this.parent.chy - this.parent.mapy >= 160)
		{
			this.sc_winy = 0;
			return;
		}
		this.sc_winy = 164;
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x000AE8A9 File Offset: 0x000ACAA9
	public bool IsScriptExec()
	{
		return !this.script_flg;
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x000AE8B8 File Offset: 0x000ACAB8
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
				if (!this.script_nflg)
				{
					flag = false;
				}
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
			case 101:
				this.ScrSetFindArea();
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
			case 108:
				this.parent.scrcompred = true;
				break;
			case 109:
				this.parent.scrcompred = false;
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

	// Token: 0x060008A1 RID: 2209 RVA: 0x000AF074 File Offset: 0x000AD274
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

	// Token: 0x060008A2 RID: 2210 RVA: 0x000AF0C4 File Offset: 0x000AD2C4
	private void ScrSetObject()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x000AF0F9 File Offset: 0x000AD2F9
	private void ScrExit()
	{
		this.GetScrByte();
		this.script_flg = true;
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x000AF10C File Offset: 0x000AD30C
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

	// Token: 0x060008A5 RID: 2213 RVA: 0x000AF2F4 File Offset: 0x000AD4F4
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

	// Token: 0x060008A6 RID: 2214 RVA: 0x000AF5E8 File Offset: 0x000AD7E8
	private void ScrFlagOn()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 1;
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x000AF608 File Offset: 0x000AD808
	private void ScrFlagOff()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 0;
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x000AF628 File Offset: 0x000AD828
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
							if (chc != 42)
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

	// Token: 0x060008A9 RID: 2217 RVA: 0x000AF70C File Offset: 0x000AD90C
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

	// Token: 0x060008AA RID: 2218 RVA: 0x000AF768 File Offset: 0x000AD968
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

	// Token: 0x060008AB RID: 2219 RVA: 0x000AF82C File Offset: 0x000ADA2C
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

	// Token: 0x060008AC RID: 2220 RVA: 0x000AF89B File Offset: 0x000ADA9B
	private void ScrEndIf()
	{
		if (this.sc_ifdpt != -1)
		{
			this.sc_ifflg[(int)this.sc_ifdpt] = false;
			this.sc_ifdpt -= 1;
		}
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x000AF8C4 File Offset: 0x000ADAC4
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

	// Token: 0x060008AE RID: 2222 RVA: 0x000AF938 File Offset: 0x000ADB38
	private void ScrSetVisual()
	{
		this.parent.visualno = (int)this.GetScrByte();
		this.parent.SetSeqNo(8);
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x000AF958 File Offset: 0x000ADB58
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

	// Token: 0x060008B0 RID: 2224 RVA: 0x000AF990 File Offset: 0x000ADB90
	private void ScrGosub()
	{
		int scrShort = (int)this.GetScrShort();
		this.script_adr_ret = this.script_adr;
		this.script_adr = scrShort;
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x000AF9B7 File Offset: 0x000ADBB7
	private void ScrReturn()
	{
		this.script_adr = this.script_adr_ret;
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x000AF9C8 File Offset: 0x000ADBC8
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

	// Token: 0x060008B3 RID: 2227 RVA: 0x000AFADC File Offset: 0x000ADCDC
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

	// Token: 0x060008B4 RID: 2228 RVA: 0x000AFB4C File Offset: 0x000ADD4C
	private void ScrSetPicture()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picno = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x000AFB74 File Offset: 0x000ADD74
	private void ScrSetPicPos()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picy = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x000AFB9B File Offset: 0x000ADD9B
	private void ScrSetPicPosP()
	{
		this.sc_picy++;
		this.parent.red = true;
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x000AFBB8 File Offset: 0x000ADDB8
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

	// Token: 0x060008B8 RID: 2232 RVA: 0x000AFE68 File Offset: 0x000AE068
	private void ScrMessageClear()
	{
		if (this.parent.GetConfig(2) == 1)
		{
			this.script_nflg = false;
			if (this.sc_wk[0] == 0)
			{
				this.sc_wk[0] = 1;
				this.sc_wk[1] = 60;
				return;
			}
			if (this.sc_wk[0] == 1)
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
				this.ScWkClear();
				for (int i = 0; i < 24; i++)
				{
					this.sc_str[i] = string.Empty;
					this.sc_strl = 0;
					this.sc_stry[i] = 0;
				}
				this.parent.red = true;
				this.script_nflg = true;
				return;
			}
		}
		else
		{
			for (int i = 0; i < 24; i++)
			{
				this.sc_str[i] = string.Empty;
				this.sc_strl = 0;
				this.sc_stry[i] = 0;
			}
			this.parent.red = true;
			this.script_nflg = true;
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x000AFF78 File Offset: 0x000AE178
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

	// Token: 0x060008BA RID: 2234 RVA: 0x000AFFF2 File Offset: 0x000AE1F2
	private void ScrSetDrawArea()
	{
		this.sc_drawy = (int)this.GetScrShort();
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000B0000 File Offset: 0x000AE200
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

	// Token: 0x060008BC RID: 2236 RVA: 0x000B00CC File Offset: 0x000AE2CC
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

	// Token: 0x060008BD RID: 2237 RVA: 0x000B00F7 File Offset: 0x000AE2F7
	private void ScrSetWindowY()
	{
		this.sc_winy = (int)this.GetScrShort();
		if (this.sc_winy >= 164)
		{
			this.sc_winy = 164;
		}
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x000B0120 File Offset: 0x000AE320
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

	// Token: 0x060008BF RID: 2239 RVA: 0x000B026C File Offset: 0x000AE46C
	private void ScrSetMapPos()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		this.parent.SetMapPosU(num, num2);
		this.parent.red = true;
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x000B02AC File Offset: 0x000AE4AC
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

	// Token: 0x060008C1 RID: 2241 RVA: 0x000B0544 File Offset: 0x000AE744
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

	// Token: 0x060008C2 RID: 2242 RVA: 0x000B05F0 File Offset: 0x000AE7F0
	private void ScrSetPng()
	{
		int scrShort = (int)this.GetScrShort();
		if (!this.walk_stop_flag && this.sc_flg[37] == 0)
		{
			if (scrShort < 0)
			{
				this.obj_pn[this.obj_no] = scrShort + 32768;
				this.obj_pn[this.obj_no] |= 32768;
			}
			else
			{
				this.obj_pn[this.obj_no] = scrShort;
			}
		}
		this.parent.red = true;
		this.parent.compred = true;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x000B0674 File Offset: 0x000AE874
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

	// Token: 0x060008C4 RID: 2244 RVA: 0x000B085C File Offset: 0x000AEA5C
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

	// Token: 0x060008C5 RID: 2245 RVA: 0x000B0A44 File Offset: 0x000AEC44
	private void ScrSetObject2()
	{
		int num = this.obj_xy[this.obj_no][0];
		int num2 = this.obj_xy[this.obj_no][1];
		int scrShort = (int)this.GetScrShort();
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x000B0A81 File Offset: 0x000AEC81
	private void ScrKillObj()
	{
		this.obj_kill[this.obj_no] = 1;
		this.parent.red = true;
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x000B0AA0 File Offset: 0x000AECA0
	private void ScrObjWait()
	{
		this.script_nflg = false;
		if (this.obj_wk[this.obj_no][0] == 65535)
		{
			this.obj_wk[this.obj_no][0] = 0;
			this.obj_wk[this.obj_no][1] = (int)this.GetScrShort();
			return;
		}
		if (this.sc_flg[37] == 0)
		{
			this.obj_wk[this.obj_no][1]--;
			if (this.obj_wk[this.obj_no][1] <= 0)
			{
				this.ObjWkClear();
				this.script_nflg = true;
			}
		}
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x000B0B34 File Offset: 0x000AED34
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
		if (!this.walk_stop_flag && this.sc_flg[37] == 0)
		{
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
					return;
				}
			}
		}
		else if (this.walk_stop_flag)
		{
			if (this.parent.mapno != 2 || num != 0 || this.obj_xy[num][0] != 96)
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 2;
			}
			if (this.parent.mapno == 1 && num == 1)
			{
				if (this.parent.chx <= this.obj_xy[num][0])
				{
					this.obj_pn[num] = this.obj_wk[num][2] + 32770;
					return;
				}
			}
			else if (this.parent.mapno == 2 && num == 2 && this.parent.chx < this.obj_xy[num][0])
			{
				this.obj_pn[num] = this.obj_wk[num][2] + 32770;
			}
		}
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x000B0FD0 File Offset: 0x000AF1D0
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
		if (!this.walk_stop_flag && this.sc_flg[37] == 0)
		{
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
					return;
				}
			}
		}
		else if (this.walk_stop_flag)
		{
			this.obj_pn[num] = this.obj_wk[num][2];
		}
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x000B13B8 File Offset: 0x000AF5B8
	private void ScrSetPlayPos()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.parent.chx = num + 8;
		this.parent.chy = num2 + 16;
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000B13FC File Offset: 0x000AF5FC
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
			if (this.parent.mapno == 2 && this.obj_xy[0][0] >= this.parent.mapx)
			{
				this.ScWkClear();
				this.script_nflg = true;
				return;
			}
		}
		else
		{
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
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x000B1588 File Offset: 0x000AF788
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

	// Token: 0x060008CD RID: 2253 RVA: 0x000B16DC File Offset: 0x000AF8DC
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

	// Token: 0x060008CE RID: 2254 RVA: 0x000B17D6 File Offset: 0x000AF9D6
	private void ScrChangeMap()
	{
		this.parent.isupdate = false;
		this.parent.mapno = (int)this.GetScrByte();
		this.parent.SetSeqNo(6);
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x000B1804 File Offset: 0x000AFA04
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

	// Token: 0x060008D0 RID: 2256 RVA: 0x000B1854 File Offset: 0x000AFA54
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

	// Token: 0x060008D1 RID: 2257 RVA: 0x000B1C2C File Offset: 0x000AFE2C
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

	// Token: 0x060008D2 RID: 2258 RVA: 0x000B1FF8 File Offset: 0x000B01F8
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

	// Token: 0x060008D3 RID: 2259 RVA: 0x000B204C File Offset: 0x000B024C
	private void ScrObjectClear()
	{
		this.ScriptObjInit();
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x000B2054 File Offset: 0x000B0254
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

	// Token: 0x060008D5 RID: 2261 RVA: 0x000B20E4 File Offset: 0x000B02E4
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

	// Token: 0x060008D6 RID: 2262 RVA: 0x000B22E8 File Offset: 0x000B04E8
	private void ScrSetMapPosP()
	{
		this.parent.SetMapPos();
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x000B22F8 File Offset: 0x000B04F8
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

	// Token: 0x060008D8 RID: 2264 RVA: 0x000B2348 File Offset: 0x000B0548
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

	// Token: 0x060008D9 RID: 2265 RVA: 0x000B238A File Offset: 0x000B058A
	private void ScrSetObjPrio()
	{
		this.obj_prio[this.obj_no] = (int)this.GetScrByte();
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x000B23A0 File Offset: 0x000B05A0
	private void ScrStartLaster()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster(scrByte);
		this.parent.PartLasterStart();
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x000B23D6 File Offset: 0x000B05D6
	private void ScrEndLaster()
	{
		this.parent.PartLasterEnd();
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x000B23E4 File Offset: 0x000B05E4
	private void ScrSetPlayChar()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.SetMapPlayerChar(scrByte);
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x000B2404 File Offset: 0x000B0604
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

	// Token: 0x060008DE RID: 2270 RVA: 0x000B24A4 File Offset: 0x000B06A4
	private void ScrGetItem()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.AddItem(scrByte, 1);
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x000B24C8 File Offset: 0x000B06C8
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

	// Token: 0x060008E0 RID: 2272 RVA: 0x000B2538 File Offset: 0x000B0738
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

	// Token: 0x060008E1 RID: 2273 RVA: 0x000B257F File Offset: 0x000B077F
	private void ScrQuake()
	{
		this.parent.quf = 2;
		this.parent.StartVib(65535);
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x000B25A0 File Offset: 0x000B07A0
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

	// Token: 0x060008E3 RID: 2275 RVA: 0x000B26A8 File Offset: 0x000B08A8
	private void ScrFadePng()
	{
		int num = this.obj_no;
		this.parent.red = true;
		this.parent.compred = true;
		this.script_nflg = false;
		if (this.obj_wk[num][0] != 65535)
		{
			if (this.obj_wk[num][0] == 1)
			{
				if (this.obj_wk[num][2] == 1 || this.obj_wk[num][2] == 7 || this.obj_wk[num][2] == 9)
				{
					this.obj_wk[num][1] -= 2;
					if (this.obj_wk[num][1] <= 0)
					{
						this.obj_wk[num][0] = 2;
						this.obj_wk[num][1] = 0;
						this.obj_wk[num][3] = 0;
						return;
					}
				}
				else if (this.obj_wk[num][2] == 2 || this.obj_wk[num][2] == 6 || this.obj_wk[num][2] == 8)
				{
					this.obj_wk[num][1] += 2;
					if (this.obj_wk[num][1] >= this.obj_wk[num][3])
					{
						this.obj_wk[num][0] = 2;
						this.obj_wk[num][1] = this.obj_wk[num][3];
						this.obj_wk[num][3] = 0;
						return;
					}
				}
				else if (this.obj_wk[num][2] == 3)
				{
					this.obj_wk[num][1]++;
					if (this.obj_wk[num][1] >= this.obj_wk[num][3])
					{
						this.obj_wk[num][0] = 2;
						this.obj_wk[num][1] = this.obj_wk[num][3];
						this.obj_wk[num][3] = 0;
						return;
					}
				}
				else if (this.obj_wk[num][2] == 4)
				{
					this.obj_wk[num][1]--;
					if (this.obj_wk[num][1] <= 0)
					{
						this.obj_wk[num][0] = 2;
						this.obj_wk[num][1] = 0;
						this.obj_wk[num][3] = 0;
						return;
					}
				}
				else if (this.obj_wk[num][2] == 5)
				{
					this.obj_wk[num][1]++;
					if (this.obj_wk[num][1] >= this.obj_wk[num][3])
					{
						this.obj_wk[num][0] = 2;
						this.obj_wk[num][1] = this.obj_wk[num][3];
						this.obj_wk[num][3] = 0;
						return;
					}
				}
				else if (this.obj_wk[num][2] == 0)
				{
					if (this.parent.mapno == 6)
					{
						this.obj_pn[num] &= -65537;
					}
					else
					{
						this.obj_pn[num] = 255;
					}
					this.ObjWkClear();
					this.script_nflg = true;
					return;
				}
			}
			else if (this.obj_wk[num][0] == 2)
			{
				this.obj_wk[num][3]++;
				if (this.obj_wk[num][3] >= 8)
				{
					if (this.obj_wk[num][2] == 1 || this.obj_wk[num][2] == 3 || this.obj_wk[num][2] == 6 || this.obj_wk[num][2] == 8)
					{
						this.obj_pn[num] = 255;
					}
					else if (this.obj_wk[num][2] == 2 || this.obj_wk[num][2] == 4 || this.obj_wk[num][2] == 5 || this.obj_wk[num][2] == 7 || this.obj_wk[num][2] == 9)
					{
						this.obj_pn[num] &= -65537;
					}
					this.parent.PngFadeStop();
					this.ObjWkClear();
					this.script_nflg = true;
				}
			}
			return;
		}
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
		this.obj_wk[num][3] = this.parent.GetPngWidth(this.obj_pn[num]);
		this.obj_pn[num] |= 65536;
		num2 = (int)this.GetScrByte();
		this.parent.PngFadeInit(num2);
		if (num2 == 2 || num2 == 3 || num2 == 5)
		{
			this.obj_wk[num][3] = this.obj_wk[num][1];
			this.obj_wk[num][1] = 0;
		}
		else if (num2 == 6 || num2 == 7 || num2 == 8 || num2 == 9)
		{
			if (num2 == 6 || num2 == 8)
			{
				this.obj_wk[num][1] = 0;
			}
			else
			{
				this.obj_wk[num][1] = this.obj_wk[num][3];
			}
		}
		this.obj_wk[num][2] = num2;
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x000B2B48 File Offset: 0x000B0D48
	private void ScrStartLaster2()
	{
		int scrByte = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster2(scrByte, scrByte2);
		this.parent.PartLasterStart();
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x000B2B88 File Offset: 0x000B0D88
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

	// Token: 0x060008E6 RID: 2278 RVA: 0x000B2CF7 File Offset: 0x000B0EF7
	private void ScrStartVib()
	{
		this.parent.StartVib(65535);
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x000B2D09 File Offset: 0x000B0F09
	private void ScrStopVib()
	{
		this.parent.StopVib();
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x000B2D18 File Offset: 0x000B0F18
	private void ScrLaserReady()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 2;
		this.parent.slxy[0] = (int)this.GetScrShort();
		this.parent.slxy[1] = (int)this.GetScrShort();
		this.parent.slxy[2] = 0;
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x000B2D70 File Offset: 0x000B0F70
	private void ScrLaserReadyStop()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 0;
		this.parent.slxy[0] = (this.parent.slxy[1] = (this.parent.slxy[2] = 0));
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x000B2DC2 File Offset: 0x000B0FC2
	private void ScrQuake2()
	{
		this.parent.quf = 1;
		this.parent.StartVib(65535);
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x000B2DE0 File Offset: 0x000B0FE0
	private void ScrQuakeStop()
	{
		this.parent.quf = 0;
		this.parent.qux = (this.parent.quy = 0);
		this.parent.StopVib();
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x000B2E1E File Offset: 0x000B101E
	private void ScrSkipAddress()
	{
		this.sc_skipadr = (int)this.GetScrShort();
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x000B2E2C File Offset: 0x000B102C
	private void ScrApprCharClear()
	{
		this.parent.apr_no = 0;
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, 255);
			this.parent.SetStatus(i, 20, 2);
		}
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x000B2E74 File Offset: 0x000B1074
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

	// Token: 0x060008EF RID: 2287 RVA: 0x000B2F04 File Offset: 0x000B1104
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

	// Token: 0x060008F0 RID: 2288 RVA: 0x000B2F68 File Offset: 0x000B1168
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

	// Token: 0x060008F1 RID: 2289 RVA: 0x000B316C File Offset: 0x000B136C
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

	// Token: 0x060008F2 RID: 2290 RVA: 0x000B3370 File Offset: 0x000B1570
	private void ScrPlaySe()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PlaySe(scrByte);
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000B3390 File Offset: 0x000B1590
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

	// Token: 0x060008F4 RID: 2292 RVA: 0x000B33E1 File Offset: 0x000B15E1
	private void ScrStopBgm()
	{
		this.parent.StopAllSound();
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x000B33EE File Offset: 0x000B15EE
	private void ScrRevivePoint()
	{
		this.parent.SetRevivePoint();
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x000B33FB File Offset: 0x000B15FB
	private void ScrStopSe()
	{
		this.parent.StopSe();
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x000B3408 File Offset: 0x000B1608
	private void ScrApprCharPush()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.ranks2[i][0] = this.parent.GetRanks(i);
			this.parent.ranks2[i][1] = this.parent.GetStatus(i, 20);
		}
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000B345C File Offset: 0x000B165C
	private void ScrApprCharPop()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, this.parent.ranks2[i][0]);
			this.parent.SetStatus(i, 20, this.parent.ranks2[i][1]);
		}
		this.parent.SetMapPlayerChar(this.parent.ranks2[0][0]);
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x000B34C8 File Offset: 0x000B16C8
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

	// Token: 0x060008FA RID: 2298 RVA: 0x000B3608 File Offset: 0x000B1808
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

	// Token: 0x060008FB RID: 2299 RVA: 0x000B364C File Offset: 0x000B184C
	private void ScrSetTrap()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.SetTrap(num, num2, scrByte);
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x000B3684 File Offset: 0x000B1884
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

	// Token: 0x060008FD RID: 2301 RVA: 0x000B36E0 File Offset: 0x000B18E0
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

	// Token: 0x060008FE RID: 2302 RVA: 0x000B3774 File Offset: 0x000B1974
	private void ScrSetFindArea()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		int scrByte3 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetFindArea(num, num2, scrByte, scrByte2, scrByte3, scrShort);
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000B37C8 File Offset: 0x000B19C8
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

	// Token: 0x06000900 RID: 2304 RVA: 0x000B38F4 File Offset: 0x000B1AF4
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

	// Token: 0x06000901 RID: 2305 RVA: 0x000B3948 File Offset: 0x000B1B48
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

	// Token: 0x0400054E RID: 1358
	protected internal XenoPP04Canvas parent;

	// Token: 0x0400054F RID: 1359
	public sbyte[] script;

	// Token: 0x04000550 RID: 1360
	public int script_adr;

	// Token: 0x04000551 RID: 1361
	public int script_adr_ret;

	// Token: 0x04000552 RID: 1362
	public int script_b_adr;

	// Token: 0x04000553 RID: 1363
	public bool script_nflg;

	// Token: 0x04000554 RID: 1364
	public bool script_b_nflg;

	// Token: 0x04000555 RID: 1365
	public bool script_flg;

	// Token: 0x04000556 RID: 1366
	public int script_cmd;

	// Token: 0x04000557 RID: 1367
	public int script_b_cmd;

	// Token: 0x04000558 RID: 1368
	public int[] sc_wk;

	// Token: 0x04000559 RID: 1369
	public string[] sc_str;

	// Token: 0x0400055A RID: 1370
	public string sc_name;

	// Token: 0x0400055B RID: 1371
	public int sc_strl;

	// Token: 0x0400055C RID: 1372
	public bool[] sc_ifflg;

	// Token: 0x0400055D RID: 1373
	public bool[] sc_b_ifflg;

	// Token: 0x0400055E RID: 1374
	public sbyte sc_ifdpt;

	// Token: 0x0400055F RID: 1375
	public sbyte sc_b_ifdpt;

	// Token: 0x04000560 RID: 1376
	public bool sc_messkip;

	// Token: 0x04000561 RID: 1377
	public int sc_skipadr;

	// Token: 0x04000562 RID: 1378
	public int[] sc_flg;

	// Token: 0x04000563 RID: 1379
	public int sc_face;

	// Token: 0x04000564 RID: 1380
	public sbyte[] vscript;

	// Token: 0x04000565 RID: 1381
	public int[] sc_stry;

	// Token: 0x04000566 RID: 1382
	public int sc_picy;

	// Token: 0x04000567 RID: 1383
	public int sc_picno;

	// Token: 0x04000568 RID: 1384
	public int sc_drawy;

	// Token: 0x04000569 RID: 1385
	public int sc_wait;

	// Token: 0x0400056A RID: 1386
	public int sc_winy;

	// Token: 0x0400056B RID: 1387
	private sbyte[] msstr;

	// Token: 0x0400056C RID: 1388
	public int[][] npc_xy;

	// Token: 0x0400056D RID: 1389
	public int[][] npc_pn;

	// Token: 0x0400056E RID: 1390
	public int[] npc_mv;

	// Token: 0x0400056F RID: 1391
	public int[] npc_adr;

	// Token: 0x04000570 RID: 1392
	public int npc_p;

	// Token: 0x04000571 RID: 1393
	public int npc_no;

	// Token: 0x04000572 RID: 1394
	public int[][] npc_wk;

	// Token: 0x04000573 RID: 1395
	public int[][] obj_xy;

	// Token: 0x04000574 RID: 1396
	public int[] obj_pn;

	// Token: 0x04000575 RID: 1397
	public int[] obj_adr;

	// Token: 0x04000576 RID: 1398
	public int[] obj_kill;

	// Token: 0x04000577 RID: 1399
	public int[] obj_cmd;

	// Token: 0x04000578 RID: 1400
	public int[][] obj_anm;

	// Token: 0x04000579 RID: 1401
	public int[] obj_prio;

	// Token: 0x0400057A RID: 1402
	public bool[] obj_nflg;

	// Token: 0x0400057B RID: 1403
	public int[][] obj_wk;

	// Token: 0x0400057C RID: 1404
	public int obj_p;

	// Token: 0x0400057D RID: 1405
	public int obj_no;

	// Token: 0x0400057E RID: 1406
	public int[][] tobj_xy;

	// Token: 0x0400057F RID: 1407
	public int[] tobj_adr;

	// Token: 0x04000580 RID: 1408
	public int[] tobj_cnd;

	// Token: 0x04000581 RID: 1409
	public int[] tobj_pn;

	// Token: 0x04000582 RID: 1410
	public int tobj_p;

	// Token: 0x04000583 RID: 1411
	public int tobj_no;

	// Token: 0x04000584 RID: 1412
	public int[] tobj_cno;

	// Token: 0x04000585 RID: 1413
	public int[][] trap_xy;

	// Token: 0x04000586 RID: 1414
	public int[] trap_id;

	// Token: 0x04000587 RID: 1415
	public int trap_p;

	// Token: 0x04000588 RID: 1416
	public int[][] find_xy;

	// Token: 0x04000589 RID: 1417
	public int[][] find_wh;

	// Token: 0x0400058A RID: 1418
	public int[] find_flag;

	// Token: 0x0400058B RID: 1419
	public int[] find_adr;

	// Token: 0x0400058C RID: 1420
	public int find_p;

	// Token: 0x0400058D RID: 1421
	public bool walk_stop_flag;
}
