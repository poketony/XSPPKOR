using System;

// Token: 0x0200003C RID: 60
public sealed class XScript05
{
	// Token: 0x06000A9A RID: 2714 RVA: 0x000D7254 File Offset: 0x000D5454
	protected internal XScript05(XenoPP05Canvas cvs)
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
			new int[2]
		};
		this.tobj_adr = new int[28];
		this.tobj_cnd = new int[28];
		this.tobj_pn = new int[28];
		this.tobj_cno = new int[28];
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
			new int[2]
		};
		this.trap_id = new int[69];
		this.trap_p = 0;
		this.save_flag = false;
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x000D84FC File Offset: 0x000D66FC
	public void ScFlagClear()
	{
		for (int i = 0; i < 80; i++)
		{
			this.sc_flg[i] = 0;
		}
	}

	// Token: 0x06000A9C RID: 2716 RVA: 0x000D8520 File Offset: 0x000D6720
	public void ScWkClear()
	{
		for (int i = 0; i < 8; i++)
		{
			this.sc_wk[i] = 0;
		}
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x000D8544 File Offset: 0x000D6744
	public void ObjWkClear()
	{
		for (int i = 0; i < 4; i++)
		{
			this.obj_wk[this.obj_no][i] = 65535;
		}
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x000D8574 File Offset: 0x000D6774
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

	// Token: 0x06000A9F RID: 2719 RVA: 0x000D85BC File Offset: 0x000D67BC
	public short GetScrShort()
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP05Canvas.ArrayShort2(this.script, this.script_adr);
		}
		else
		{
			num = XenoPP05Canvas.ArrayShort2(this.vscript, this.script_adr);
		}
		this.script_adr += 2;
		return num;
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x000D860C File Offset: 0x000D680C
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

	// Token: 0x06000AA1 RID: 2721 RVA: 0x000D863C File Offset: 0x000D683C
	public short GetScrShort2(int adr)
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP05Canvas.ArrayShort2(this.script, adr);
		}
		else
		{
			num = XenoPP05Canvas.ArrayShort2(this.vscript, adr);
		}
		return num;
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x000D8674 File Offset: 0x000D6874
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

	// Token: 0x06000AA3 RID: 2723 RVA: 0x000D8790 File Offset: 0x000D6990
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

	// Token: 0x06000AA4 RID: 2724 RVA: 0x000D885C File Offset: 0x000D6A5C
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

	// Token: 0x06000AA5 RID: 2725 RVA: 0x000D8940 File Offset: 0x000D6B40
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

	// Token: 0x06000AA6 RID: 2726 RVA: 0x000D89C4 File Offset: 0x000D6BC4
	public void SetTrap(int x, int y, int id)
	{
		if (this.trap_p < 69)
		{
			this.trap_xy[this.trap_p][0] = x;
			this.trap_xy[this.trap_p][1] = y;
			this.trap_id[this.trap_p] = id;
			this.trap_p++;
		}
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x000D8A17 File Offset: 0x000D6C17
	public bool IsMessageSelect()
	{
		return this.script_cmd == 59;
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x000D8A28 File Offset: 0x000D6C28
	public bool IsMessageEnd()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || this.script_cmd == 34 || this.script_cmd == 36 || this.script_cmd == 95 || this.script_cmd == 102 || this.script_cmd == 104 || this.script_cmd == 105 || (this.script_cmd == 4 && this.sc_wk[0] == 0);
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x000D8A9C File Offset: 0x000D6C9C
	public bool IsMessageEnd2()
	{
		return this.script_cmd == 21 || this.script_cmd == 27 || (this.script_cmd != 26 && this.script_cmd != 7) || ((this.script_cmd == 26 || this.script_cmd == 7) && this.sc_wk[0] == 0);
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x000D8AF0 File Offset: 0x000D6CF0
	public bool IsMessageEnd3()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || (this.script_cmd == 95 && this.sc_wk[0] >= 2);
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x000D8B1E File Offset: 0x000D6D1E
	public bool IsMessageEnd4()
	{
		return this.script_cmd == 84;
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x000D8B2D File Offset: 0x000D6D2D
	public bool IsMessage()
	{
		return this.script_cmd == 4;
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x000D8B3B File Offset: 0x000D6D3B
	public bool IsMessage2()
	{
		return this.script_cmd == 26 || this.script_cmd == 7;
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x000D8B53 File Offset: 0x000D6D53
	public string SpReplace(string str)
	{
		return str.Replace('Ⅰ', '\ue6e2').Replace('Ⅱ', '\ue6e3').Replace('Ⅲ', '\ue6e4');
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x000D8B84 File Offset: 0x000D6D84
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
		for (int i = 0; i < 28; i++)
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
		for (int i = 0; i < 69; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.trap_xy[i][j] = 0;
			}
			this.trap_id[i] = 0;
		}
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000D8CA0 File Offset: 0x000D6EA0
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

	// Token: 0x06000AB1 RID: 2737 RVA: 0x000D8DDC File Offset: 0x000D6FDC
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

	// Token: 0x06000AB2 RID: 2738 RVA: 0x000D8E88 File Offset: 0x000D7088
	public void ScriptInit3(int adr)
	{
		this.script_adr = adr;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x000D8EB8 File Offset: 0x000D70B8
	public bool IsScriptExec()
	{
		return !this.script_flg;
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x000D8EC8 File Offset: 0x000D70C8
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
			case 110:
				this.ScrMoveMapX2();
				flag = false;
				break;
			case 111:
				this.ScrMoveMapY2();
				flag = false;
				break;
			case 113:
				this.save_flag = true;
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

	// Token: 0x06000AB5 RID: 2741 RVA: 0x000D96A0 File Offset: 0x000D78A0
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

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000D96F0 File Offset: 0x000D78F0
	private void ScrSetObject()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x000D9725 File Offset: 0x000D7925
	private void ScrExit()
	{
		this.GetScrByte();
		this.script_flg = true;
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x000D9738 File Offset: 0x000D7938
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

	// Token: 0x06000AB9 RID: 2745 RVA: 0x000D9920 File Offset: 0x000D7B20
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
			if (this.parent.mapno == 0 && this.sc_flg[0] != 1 && this.sc_flg[69] == 1 && this.sc_flg[70] != 1)
			{
				this.sc_wk[2] = 4;
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

	// Token: 0x06000ABA RID: 2746 RVA: 0x000D9C4C File Offset: 0x000D7E4C
	private void ScrFlagOn()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 1;
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x000D9C6C File Offset: 0x000D7E6C
	private void ScrFlagOff()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 0;
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x000D9C8C File Offset: 0x000D7E8C
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

	// Token: 0x06000ABD RID: 2749 RVA: 0x000D9D70 File Offset: 0x000D7F70
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

	// Token: 0x06000ABE RID: 2750 RVA: 0x000D9DCC File Offset: 0x000D7FCC
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

	// Token: 0x06000ABF RID: 2751 RVA: 0x000D9E90 File Offset: 0x000D8090
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

	// Token: 0x06000AC0 RID: 2752 RVA: 0x000D9EFF File Offset: 0x000D80FF
	private void ScrEndIf()
	{
		if (this.sc_ifdpt != -1)
		{
			this.sc_ifflg[(int)this.sc_ifdpt] = false;
			this.sc_ifdpt -= 1;
		}
	}

	// Token: 0x06000AC1 RID: 2753 RVA: 0x000D9F28 File Offset: 0x000D8128
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

	// Token: 0x06000AC2 RID: 2754 RVA: 0x000D9F9C File Offset: 0x000D819C
	private void ScrSetVisual()
	{
		this.parent.visualno = (int)this.GetScrByte();
		this.parent.SetSeqNo(8);
	}

	// Token: 0x06000AC3 RID: 2755 RVA: 0x000D9FBC File Offset: 0x000D81BC
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

	// Token: 0x06000AC4 RID: 2756 RVA: 0x000D9FF4 File Offset: 0x000D81F4
	private void ScrGosub()
	{
		int scrShort = (int)this.GetScrShort();
		this.script_adr_ret = this.script_adr;
		this.script_adr = scrShort;
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x000DA01B File Offset: 0x000D821B
	private void ScrReturn()
	{
		this.script_adr = this.script_adr_ret;
	}

	// Token: 0x06000AC6 RID: 2758 RVA: 0x000DA02C File Offset: 0x000D822C
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

	// Token: 0x06000AC7 RID: 2759 RVA: 0x000DA140 File Offset: 0x000D8340
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

	// Token: 0x06000AC8 RID: 2760 RVA: 0x000DA1B0 File Offset: 0x000D83B0
	private void ScrSetPicture()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picno = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x06000AC9 RID: 2761 RVA: 0x000DA1D8 File Offset: 0x000D83D8
	private void ScrSetPicPos()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picy = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x000DA1FF File Offset: 0x000D83FF
	private void ScrSetPicPosP()
	{
		this.sc_picy++;
		this.parent.red = true;
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x000DA21C File Offset: 0x000D841C
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

	// Token: 0x06000ACC RID: 2764 RVA: 0x000DA4CC File Offset: 0x000D86CC
	private void ScrMessageClear()
	{
		if (this.parent.GetConfig(2) == 1 && (this.parent.visualno == 0 || this.parent.visualno == 1))
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

	// Token: 0x06000ACD RID: 2765 RVA: 0x000DA5FC File Offset: 0x000D87FC
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

	// Token: 0x06000ACE RID: 2766 RVA: 0x000DA676 File Offset: 0x000D8876
	private void ScrSetDrawArea()
	{
		this.sc_drawy = (int)this.GetScrShort();
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x000DA684 File Offset: 0x000D8884
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

	// Token: 0x06000AD0 RID: 2768 RVA: 0x000DA750 File Offset: 0x000D8950
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

	// Token: 0x06000AD1 RID: 2769 RVA: 0x000DA77B File Offset: 0x000D897B
	private void ScrSetWindowY()
	{
		this.sc_winy = (int)this.GetScrShort();
		if (this.sc_winy >= 164)
		{
			this.sc_winy = 164;
		}
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x000DA7A4 File Offset: 0x000D89A4
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

	// Token: 0x06000AD3 RID: 2771 RVA: 0x000DA8F0 File Offset: 0x000D8AF0
	private void ScrSetMapPos()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		this.parent.SetMapPosU(num, num2);
		this.parent.red = true;
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x000DA930 File Offset: 0x000D8B30
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

	// Token: 0x06000AD5 RID: 2773 RVA: 0x000DABC8 File Offset: 0x000D8DC8
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

	// Token: 0x06000AD6 RID: 2774 RVA: 0x000DAC74 File Offset: 0x000D8E74
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

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000DACE4 File Offset: 0x000D8EE4
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

	// Token: 0x06000AD8 RID: 2776 RVA: 0x000DAECC File Offset: 0x000D90CC
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

	// Token: 0x06000AD9 RID: 2777 RVA: 0x000DB0B4 File Offset: 0x000D92B4
	private void ScrSetObject2()
	{
		int num = this.obj_xy[this.obj_no][0];
		int num2 = this.obj_xy[this.obj_no][1];
		int scrShort = (int)this.GetScrShort();
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x000DB0F1 File Offset: 0x000D92F1
	private void ScrKillObj()
	{
		this.obj_kill[this.obj_no] = 1;
		this.parent.red = true;
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x000DB110 File Offset: 0x000D9310
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

	// Token: 0x06000ADC RID: 2780 RVA: 0x000DB198 File Offset: 0x000D9398
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

	// Token: 0x06000ADD RID: 2781 RVA: 0x000DB558 File Offset: 0x000D9758
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

	// Token: 0x06000ADE RID: 2782 RVA: 0x000DB90C File Offset: 0x000D9B0C
	private void ScrSetPlayPos()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.parent.chx = num + 8;
		this.parent.chy = num2 + 16;
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x000DB950 File Offset: 0x000D9B50
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

	// Token: 0x06000AE0 RID: 2784 RVA: 0x000DBAA4 File Offset: 0x000D9CA4
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

	// Token: 0x06000AE1 RID: 2785 RVA: 0x000DBBF8 File Offset: 0x000D9DF8
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

	// Token: 0x06000AE2 RID: 2786 RVA: 0x000DBD80 File Offset: 0x000D9F80
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

	// Token: 0x06000AE3 RID: 2787 RVA: 0x000DBF08 File Offset: 0x000DA108
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

	// Token: 0x06000AE4 RID: 2788 RVA: 0x000DC002 File Offset: 0x000DA202
	private void ScrChangeMap()
	{
		this.parent.isupdate = false;
		this.parent.mapno = (int)this.GetScrByte();
		this.parent.SetSeqNo(6);
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x000DC030 File Offset: 0x000DA230
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

	// Token: 0x06000AE6 RID: 2790 RVA: 0x000DC080 File Offset: 0x000DA280
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

	// Token: 0x06000AE7 RID: 2791 RVA: 0x000DC458 File Offset: 0x000DA658
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

	// Token: 0x06000AE8 RID: 2792 RVA: 0x000DC824 File Offset: 0x000DAA24
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

	// Token: 0x06000AE9 RID: 2793 RVA: 0x000DC878 File Offset: 0x000DAA78
	private void ScrObjectClear()
	{
		this.ScriptObjInit();
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x000DC880 File Offset: 0x000DAA80
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

	// Token: 0x06000AEB RID: 2795 RVA: 0x000DC910 File Offset: 0x000DAB10
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

	// Token: 0x06000AEC RID: 2796 RVA: 0x000DCB14 File Offset: 0x000DAD14
	private void ScrSetMapPosP()
	{
		this.parent.SetMapPos();
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x000DCB24 File Offset: 0x000DAD24
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

	// Token: 0x06000AEE RID: 2798 RVA: 0x000DCB74 File Offset: 0x000DAD74
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

	// Token: 0x06000AEF RID: 2799 RVA: 0x000DCBB6 File Offset: 0x000DADB6
	private void ScrSetObjPrio()
	{
		this.obj_prio[this.obj_no] = (int)this.GetScrByte();
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x000DCBCC File Offset: 0x000DADCC
	private void ScrStartLaster()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster(scrByte);
		this.parent.PartLasterStart();
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x000DCC02 File Offset: 0x000DAE02
	private void ScrEndLaster()
	{
		this.parent.PartLasterEnd();
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x000DCC10 File Offset: 0x000DAE10
	private void ScrSetPlayChar()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.SetMapPlayerChar(scrByte);
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x000DCC30 File Offset: 0x000DAE30
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

	// Token: 0x06000AF4 RID: 2804 RVA: 0x000DCCD0 File Offset: 0x000DAED0
	private void ScrGetItem()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.AddItem(scrByte, 1);
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x000DCCF4 File Offset: 0x000DAEF4
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

	// Token: 0x06000AF6 RID: 2806 RVA: 0x000DCD64 File Offset: 0x000DAF64
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

	// Token: 0x06000AF7 RID: 2807 RVA: 0x000DCDAB File Offset: 0x000DAFAB
	private void ScrQuake()
	{
		this.parent.quf = 2;
		this.parent.StartVib(65535);
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x000DCDCC File Offset: 0x000DAFCC
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

	// Token: 0x06000AF9 RID: 2809 RVA: 0x000DCED4 File Offset: 0x000DB0D4
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
					this.obj_pn[num] = 255;
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

	// Token: 0x06000AFA RID: 2810 RVA: 0x000DD350 File Offset: 0x000DB550
	private void ScrStartLaster2()
	{
		int scrByte = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster2(scrByte, scrByte2);
		this.parent.PartLasterStart();
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x000DD390 File Offset: 0x000DB590
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

	// Token: 0x06000AFC RID: 2812 RVA: 0x000DD4FF File Offset: 0x000DB6FF
	private void ScrStartVib()
	{
		this.parent.StartVib(65535);
	}

	// Token: 0x06000AFD RID: 2813 RVA: 0x000DD511 File Offset: 0x000DB711
	private void ScrStopVib()
	{
		this.parent.StopVib();
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x000DD520 File Offset: 0x000DB720
	private void ScrLaserReady()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 2;
		this.parent.slxy[0] = (int)this.GetScrShort();
		this.parent.slxy[1] = (int)this.GetScrShort();
		this.parent.slxy[2] = 0;
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x000DD578 File Offset: 0x000DB778
	private void ScrLaserReadyStop()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 0;
		this.parent.slxy[0] = (this.parent.slxy[1] = (this.parent.slxy[2] = 0));
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x000DD5CA File Offset: 0x000DB7CA
	private void ScrQuake2()
	{
		this.parent.quf = 1;
		this.parent.StartVib(65535);
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x000DD5E8 File Offset: 0x000DB7E8
	private void ScrQuakeStop()
	{
		this.parent.quf = 0;
		this.parent.qux = (this.parent.quy = 0);
		this.parent.StopVib();
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x000DD626 File Offset: 0x000DB826
	private void ScrSkipAddress()
	{
		this.sc_skipadr = (int)this.GetScrShort();
	}

	// Token: 0x06000B03 RID: 2819 RVA: 0x000DD634 File Offset: 0x000DB834
	private void ScrApprCharClear()
	{
		this.parent.apr_no = 0;
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, 255);
			this.parent.SetStatus(i, 20, 2);
		}
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x000DD67C File Offset: 0x000DB87C
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

	// Token: 0x06000B05 RID: 2821 RVA: 0x000DD70C File Offset: 0x000DB90C
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

	// Token: 0x06000B06 RID: 2822 RVA: 0x000DD770 File Offset: 0x000DB970
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

	// Token: 0x06000B07 RID: 2823 RVA: 0x000DD974 File Offset: 0x000DBB74
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

	// Token: 0x06000B08 RID: 2824 RVA: 0x000DDB78 File Offset: 0x000DBD78
	private void ScrPlaySe()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PlaySe(scrByte);
	}

	// Token: 0x06000B09 RID: 2825 RVA: 0x000DDB98 File Offset: 0x000DBD98
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

	// Token: 0x06000B0A RID: 2826 RVA: 0x000DDBE9 File Offset: 0x000DBDE9
	private void ScrStopBgm()
	{
		this.parent.StopAllSound();
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x000DDBF6 File Offset: 0x000DBDF6
	private void ScrRevivePoint()
	{
		this.parent.SetRevivePoint();
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x000DDC03 File Offset: 0x000DBE03
	private void ScrStopSe()
	{
		this.parent.StopSe();
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x000DDC10 File Offset: 0x000DBE10
	private void ScrApprCharPush()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.ranks2[i][0] = this.parent.GetRanks(i);
			this.parent.ranks2[i][1] = this.parent.GetStatus(i, 20);
		}
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x000DDC64 File Offset: 0x000DBE64
	private void ScrApprCharPop()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, this.parent.ranks2[i][0]);
			this.parent.SetStatus(i, 20, this.parent.ranks2[i][1]);
		}
		this.parent.SetMapPlayerChar(this.parent.ranks2[0][0]);
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x000DDCD0 File Offset: 0x000DBED0
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

	// Token: 0x06000B10 RID: 2832 RVA: 0x000DDE10 File Offset: 0x000DC010
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

	// Token: 0x06000B11 RID: 2833 RVA: 0x000DDE54 File Offset: 0x000DC054
	private void ScrSetTrap()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrByte = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.SetTrap(num, num2, scrByte);
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x000DDE8C File Offset: 0x000DC08C
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

	// Token: 0x06000B13 RID: 2835 RVA: 0x000DDEE8 File Offset: 0x000DC0E8
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

	// Token: 0x06000B14 RID: 2836 RVA: 0x000DDF7C File Offset: 0x000DC17C
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

	// Token: 0x06000B15 RID: 2837 RVA: 0x000DE0A8 File Offset: 0x000DC2A8
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

	// Token: 0x06000B16 RID: 2838 RVA: 0x000DE0FC File Offset: 0x000DC2FC
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

	// Token: 0x04000678 RID: 1656
	protected internal XenoPP05Canvas parent;

	// Token: 0x04000679 RID: 1657
	public sbyte[] script;

	// Token: 0x0400067A RID: 1658
	public int script_adr;

	// Token: 0x0400067B RID: 1659
	public int script_adr_ret;

	// Token: 0x0400067C RID: 1660
	public int script_b_adr;

	// Token: 0x0400067D RID: 1661
	public bool script_nflg;

	// Token: 0x0400067E RID: 1662
	public bool script_b_nflg;

	// Token: 0x0400067F RID: 1663
	public bool script_flg;

	// Token: 0x04000680 RID: 1664
	public int script_cmd;

	// Token: 0x04000681 RID: 1665
	public int script_b_cmd;

	// Token: 0x04000682 RID: 1666
	public int[] sc_wk;

	// Token: 0x04000683 RID: 1667
	public string[] sc_str;

	// Token: 0x04000684 RID: 1668
	public string sc_name;

	// Token: 0x04000685 RID: 1669
	public int sc_strl;

	// Token: 0x04000686 RID: 1670
	public bool[] sc_ifflg;

	// Token: 0x04000687 RID: 1671
	public bool[] sc_b_ifflg;

	// Token: 0x04000688 RID: 1672
	public sbyte sc_ifdpt;

	// Token: 0x04000689 RID: 1673
	public sbyte sc_b_ifdpt;

	// Token: 0x0400068A RID: 1674
	public bool sc_messkip;

	// Token: 0x0400068B RID: 1675
	public int sc_skipadr;

	// Token: 0x0400068C RID: 1676
	public int[] sc_flg;

	// Token: 0x0400068D RID: 1677
	public int sc_face;

	// Token: 0x0400068E RID: 1678
	public sbyte[] vscript;

	// Token: 0x0400068F RID: 1679
	public int[] sc_stry;

	// Token: 0x04000690 RID: 1680
	public int sc_picy;

	// Token: 0x04000691 RID: 1681
	public int sc_picno;

	// Token: 0x04000692 RID: 1682
	public int sc_drawy;

	// Token: 0x04000693 RID: 1683
	public int sc_wait;

	// Token: 0x04000694 RID: 1684
	public int sc_winy;

	// Token: 0x04000695 RID: 1685
	private sbyte[] msstr;

	// Token: 0x04000696 RID: 1686
	public int[][] npc_xy;

	// Token: 0x04000697 RID: 1687
	public int[][] npc_pn;

	// Token: 0x04000698 RID: 1688
	public int[] npc_mv;

	// Token: 0x04000699 RID: 1689
	public int[] npc_adr;

	// Token: 0x0400069A RID: 1690
	public int npc_p;

	// Token: 0x0400069B RID: 1691
	public int npc_no;

	// Token: 0x0400069C RID: 1692
	public int[][] npc_wk;

	// Token: 0x0400069D RID: 1693
	public int[][] obj_xy;

	// Token: 0x0400069E RID: 1694
	public int[] obj_pn;

	// Token: 0x0400069F RID: 1695
	public int[] obj_adr;

	// Token: 0x040006A0 RID: 1696
	public int[] obj_kill;

	// Token: 0x040006A1 RID: 1697
	public int[] obj_cmd;

	// Token: 0x040006A2 RID: 1698
	public int[][] obj_anm;

	// Token: 0x040006A3 RID: 1699
	public int[] obj_prio;

	// Token: 0x040006A4 RID: 1700
	public bool[] obj_nflg;

	// Token: 0x040006A5 RID: 1701
	public int[][] obj_wk;

	// Token: 0x040006A6 RID: 1702
	public int obj_p;

	// Token: 0x040006A7 RID: 1703
	public int obj_no;

	// Token: 0x040006A8 RID: 1704
	public int[][] tobj_xy;

	// Token: 0x040006A9 RID: 1705
	public int[] tobj_adr;

	// Token: 0x040006AA RID: 1706
	public int[] tobj_cnd;

	// Token: 0x040006AB RID: 1707
	public int[] tobj_pn;

	// Token: 0x040006AC RID: 1708
	public int tobj_p;

	// Token: 0x040006AD RID: 1709
	public int tobj_no;

	// Token: 0x040006AE RID: 1710
	public int[] tobj_cno;

	// Token: 0x040006AF RID: 1711
	public int[][] trap_xy;

	// Token: 0x040006B0 RID: 1712
	public int[] trap_id;

	// Token: 0x040006B1 RID: 1713
	public int trap_p;

	// Token: 0x040006B2 RID: 1714
	public bool save_flag;
}
