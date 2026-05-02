using System;

// Token: 0x02000030 RID: 48
public sealed class XScript
{
	// Token: 0x0600025C RID: 604 RVA: 0x0002DE7C File Offset: 0x0002C07C
	protected internal XScript(XenoPP01Canvas cvs)
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
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0002EE2C File Offset: 0x0002D02C
	public void ScFlagClear()
	{
		for (int i = 0; i < 80; i++)
		{
			this.sc_flg[i] = 0;
		}
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0002EE50 File Offset: 0x0002D050
	public void ScWkClear()
	{
		for (int i = 0; i < 8; i++)
		{
			this.sc_wk[i] = 0;
		}
	}

	// Token: 0x0600025F RID: 607 RVA: 0x0002EE74 File Offset: 0x0002D074
	public void ObjWkClear()
	{
		for (int i = 0; i < 4; i++)
		{
			this.obj_wk[this.obj_no][i] = 65535;
		}
	}

	// Token: 0x06000260 RID: 608 RVA: 0x0002EEA4 File Offset: 0x0002D0A4
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

	// Token: 0x06000261 RID: 609 RVA: 0x0002EEEC File Offset: 0x0002D0EC
	public short GetScrShort()
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP01Canvas.ArrayShort2(this.script, this.script_adr);
		}
		else
		{
			num = XenoPP01Canvas.ArrayShort2(this.vscript, this.script_adr);
		}
		this.script_adr += 2;
		return num;
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0002EF3C File Offset: 0x0002D13C
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

	// Token: 0x06000263 RID: 611 RVA: 0x0002EF6C File Offset: 0x0002D16C
	public short GetScrShort2(int adr)
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP01Canvas.ArrayShort2(this.script, adr);
		}
		else
		{
			num = XenoPP01Canvas.ArrayShort2(this.vscript, adr);
		}
		return num;
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0002EFA4 File Offset: 0x0002D1A4
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

	// Token: 0x06000265 RID: 613 RVA: 0x0002F0C0 File Offset: 0x0002D2C0
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

	// Token: 0x06000266 RID: 614 RVA: 0x0002F18C File Offset: 0x0002D38C
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

	// Token: 0x06000267 RID: 615 RVA: 0x0002F270 File Offset: 0x0002D470
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

	// Token: 0x06000268 RID: 616 RVA: 0x0002F2F3 File Offset: 0x0002D4F3
	public bool IsMessageSelect()
	{
		return this.script_cmd == 59;
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0002F304 File Offset: 0x0002D504
	public bool IsMessageEnd()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || this.script_cmd == 34 || this.script_cmd == 36 || this.script_cmd == 95 || this.script_cmd == 102 || this.script_cmd == 104 || this.script_cmd == 105 || (this.script_cmd == 4 && this.sc_wk[0] == 0);
	}

	// Token: 0x0600026A RID: 618 RVA: 0x0002F378 File Offset: 0x0002D578
	public bool IsMessageEnd2()
	{
		return this.script_cmd == 21 || this.script_cmd == 27 || (this.script_cmd != 26 && this.script_cmd != 7) || ((this.script_cmd == 26 || this.script_cmd == 7) && this.sc_wk[0] == 0);
	}

	// Token: 0x0600026B RID: 619 RVA: 0x0002F3CC File Offset: 0x0002D5CC
	public bool IsMessageEnd3()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || (this.script_cmd == 95 && this.sc_wk[0] >= 2);
	}

	// Token: 0x0600026C RID: 620 RVA: 0x0002F3FA File Offset: 0x0002D5FA
	public bool IsMessageEnd4()
	{
		return this.script_cmd == 84;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0002F409 File Offset: 0x0002D609
	public bool IsMessage()
	{
		return this.script_cmd == 4;
	}

	// Token: 0x0600026E RID: 622 RVA: 0x0002F417 File Offset: 0x0002D617
	public bool IsMessage2()
	{
		return this.script_cmd == 26 || this.script_cmd == 7;
	}

	// Token: 0x0600026F RID: 623 RVA: 0x0002F42F File Offset: 0x0002D62F
	public string SpReplace(string str)
	{
		return str.Replace('Ⅰ', '\ue6e2').Replace('Ⅱ', '\ue6e3').Replace('Ⅲ', '\ue6e4');
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0002F460 File Offset: 0x0002D660
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
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0002F548 File Offset: 0x0002D748
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

	// Token: 0x06000272 RID: 626 RVA: 0x0002F684 File Offset: 0x0002D884
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

	// Token: 0x06000273 RID: 627 RVA: 0x0002F730 File Offset: 0x0002D930
	public void ScriptInit3(int adr)
	{
		this.script_adr = adr;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0002F760 File Offset: 0x0002D960
	public bool IsScriptExec()
	{
		return !this.script_flg;
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0002F770 File Offset: 0x0002D970
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

	// Token: 0x06000276 RID: 630 RVA: 0x0002FEF4 File Offset: 0x0002E0F4
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

	// Token: 0x06000277 RID: 631 RVA: 0x0002FF44 File Offset: 0x0002E144
	private void ScrSetObject()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0002FF79 File Offset: 0x0002E179
	private void ScrExit()
	{
		this.GetScrByte();
		this.script_flg = true;
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0002FF8C File Offset: 0x0002E18C
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

	// Token: 0x0600027A RID: 634 RVA: 0x00030174 File Offset: 0x0002E374
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

	// Token: 0x0600027B RID: 635 RVA: 0x00030468 File Offset: 0x0002E668
	private void ScrFlagOn()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 1;
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00030488 File Offset: 0x0002E688
	private void ScrFlagOff()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 0;
	}

	// Token: 0x0600027D RID: 637 RVA: 0x000304A8 File Offset: 0x0002E6A8
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

	// Token: 0x0600027E RID: 638 RVA: 0x0003058C File Offset: 0x0002E78C
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

	// Token: 0x0600027F RID: 639 RVA: 0x000305E8 File Offset: 0x0002E7E8
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

	// Token: 0x06000280 RID: 640 RVA: 0x000306AC File Offset: 0x0002E8AC
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

	// Token: 0x06000281 RID: 641 RVA: 0x0003071B File Offset: 0x0002E91B
	private void ScrEndIf()
	{
		if (this.sc_ifdpt != -1)
		{
			this.sc_ifflg[(int)this.sc_ifdpt] = false;
			this.sc_ifdpt -= 1;
		}
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00030744 File Offset: 0x0002E944
	private void ScrSetBattle()
	{
		sbyte scrByte = this.GetScrByte();
		this.script_b_adr = this.script_adr;
		this.parent.battleno = (int)scrByte;
		this.parent.StopAllSound();
		this.parent.PlaySe(3);
		this.parent.BattleFadeInit();
		this.parent.SetSeqStep(4);
	}

	// Token: 0x06000283 RID: 643 RVA: 0x0003079E File Offset: 0x0002E99E
	private void ScrSetVisual()
	{
		this.parent.visualno = (int)this.GetScrByte();
		this.parent.SetSeqNo(8);
	}

	// Token: 0x06000284 RID: 644 RVA: 0x000307C0 File Offset: 0x0002E9C0
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

	// Token: 0x06000285 RID: 645 RVA: 0x000307F8 File Offset: 0x0002E9F8
	private void ScrGosub()
	{
		int scrShort = (int)this.GetScrShort();
		this.script_adr_ret = this.script_adr;
		this.script_adr = scrShort;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0003081F File Offset: 0x0002EA1F
	private void ScrReturn()
	{
		this.script_adr = this.script_adr_ret;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00030830 File Offset: 0x0002EA30
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

	// Token: 0x06000288 RID: 648 RVA: 0x00030944 File Offset: 0x0002EB44
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

	// Token: 0x06000289 RID: 649 RVA: 0x000309B4 File Offset: 0x0002EBB4
	private void ScrSetPicture()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picno = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x0600028A RID: 650 RVA: 0x000309DC File Offset: 0x0002EBDC
	private void ScrSetPicPos()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picy = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00030A03 File Offset: 0x0002EC03
	private void ScrSetPicPosP()
	{
		this.sc_picy++;
		this.parent.red = true;
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00030A20 File Offset: 0x0002EC20
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

	// Token: 0x0600028D RID: 653 RVA: 0x00030CD0 File Offset: 0x0002EED0
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

	// Token: 0x0600028E RID: 654 RVA: 0x00030D34 File Offset: 0x0002EF34
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

	// Token: 0x0600028F RID: 655 RVA: 0x00030DAE File Offset: 0x0002EFAE
	private void ScrSetDrawArea()
	{
		this.sc_drawy = (int)this.GetScrShort();
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00030DBC File Offset: 0x0002EFBC
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

	// Token: 0x06000291 RID: 657 RVA: 0x00030E88 File Offset: 0x0002F088
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

	// Token: 0x06000292 RID: 658 RVA: 0x00030EB3 File Offset: 0x0002F0B3
	private void ScrSetWindowY()
	{
		this.sc_winy = (int)this.GetScrShort();
		if (this.sc_winy >= 164)
		{
			this.sc_winy = 164;
		}
	}

	// Token: 0x06000293 RID: 659 RVA: 0x00030EDC File Offset: 0x0002F0DC
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

	// Token: 0x06000294 RID: 660 RVA: 0x00031028 File Offset: 0x0002F228
	private void ScrSetMapPos()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		this.parent.SetMapPosU(num, num2);
		this.parent.red = true;
	}

	// Token: 0x06000295 RID: 661 RVA: 0x00031068 File Offset: 0x0002F268
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

	// Token: 0x06000296 RID: 662 RVA: 0x00031300 File Offset: 0x0002F500
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

	// Token: 0x06000297 RID: 663 RVA: 0x000313AC File Offset: 0x0002F5AC
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

	// Token: 0x06000298 RID: 664 RVA: 0x0003141C File Offset: 0x0002F61C
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

	// Token: 0x06000299 RID: 665 RVA: 0x00031604 File Offset: 0x0002F804
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

	// Token: 0x0600029A RID: 666 RVA: 0x000317EC File Offset: 0x0002F9EC
	private void ScrSetObject2()
	{
		int num = this.obj_xy[this.obj_no][0];
		int num2 = this.obj_xy[this.obj_no][1];
		int scrShort = (int)this.GetScrShort();
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00031829 File Offset: 0x0002FA29
	private void ScrKillObj()
	{
		this.obj_kill[this.obj_no] = 1;
		this.parent.red = true;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00031848 File Offset: 0x0002FA48
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

	// Token: 0x0600029D RID: 669 RVA: 0x000318D0 File Offset: 0x0002FAD0
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

	// Token: 0x0600029E RID: 670 RVA: 0x00031C90 File Offset: 0x0002FE90
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

	// Token: 0x0600029F RID: 671 RVA: 0x00032044 File Offset: 0x00030244
	private void ScrSetPlayPos()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.parent.chx = num + 8;
		this.parent.chy = num2 + 16;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x00032088 File Offset: 0x00030288
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

	// Token: 0x060002A1 RID: 673 RVA: 0x000321DC File Offset: 0x000303DC
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

	// Token: 0x060002A2 RID: 674 RVA: 0x00032330 File Offset: 0x00030530
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

	// Token: 0x060002A3 RID: 675 RVA: 0x0003242A File Offset: 0x0003062A
	private void ScrChangeMap()
	{
		this.parent.isupdate = false;
		this.parent.mapno = (int)this.GetScrByte();
		this.parent.SetSeqNo(6);
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00032458 File Offset: 0x00030658
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

	// Token: 0x060002A5 RID: 677 RVA: 0x000324A8 File Offset: 0x000306A8
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

	// Token: 0x060002A6 RID: 678 RVA: 0x00032880 File Offset: 0x00030A80
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

	// Token: 0x060002A7 RID: 679 RVA: 0x00032C4C File Offset: 0x00030E4C
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

	// Token: 0x060002A8 RID: 680 RVA: 0x00032CA0 File Offset: 0x00030EA0
	private void ScrObjectClear()
	{
		this.ScriptObjInit();
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x00032CA8 File Offset: 0x00030EA8
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

	// Token: 0x060002AA RID: 682 RVA: 0x00032D38 File Offset: 0x00030F38
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

	// Token: 0x060002AB RID: 683 RVA: 0x00032F3C File Offset: 0x0003113C
	private void ScrSetMapPosP()
	{
		this.parent.SetMapPos();
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00032F4C File Offset: 0x0003114C
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

	// Token: 0x060002AD RID: 685 RVA: 0x00032F9C File Offset: 0x0003119C
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

	// Token: 0x060002AE RID: 686 RVA: 0x00032FDE File Offset: 0x000311DE
	private void ScrSetObjPrio()
	{
		this.obj_prio[this.obj_no] = (int)this.GetScrByte();
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00032FF4 File Offset: 0x000311F4
	private void ScrStartLaster()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster(scrByte);
		this.parent.PartLasterStart();
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x0003302A File Offset: 0x0003122A
	private void ScrEndLaster()
	{
		this.parent.PartLasterEnd();
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00033038 File Offset: 0x00031238
	private void ScrSetPlayChar()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.SetMapPlayerChar(scrByte);
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00033058 File Offset: 0x00031258
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

	// Token: 0x060002B3 RID: 691 RVA: 0x000330F8 File Offset: 0x000312F8
	private void ScrGetItem()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.AddItem(scrByte, 1);
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x0003311C File Offset: 0x0003131C
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

	// Token: 0x060002B5 RID: 693 RVA: 0x0003318C File Offset: 0x0003138C
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

	// Token: 0x060002B6 RID: 694 RVA: 0x000331D3 File Offset: 0x000313D3
	private void ScrQuake()
	{
		this.parent.quf = 2;
		this.parent.StartVib(65535);
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x000331F4 File Offset: 0x000313F4
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

	// Token: 0x060002B8 RID: 696 RVA: 0x000332FC File Offset: 0x000314FC
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

	// Token: 0x060002B9 RID: 697 RVA: 0x0003359C File Offset: 0x0003179C
	private void ScrStartLaster2()
	{
		int scrByte = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster2(scrByte, scrByte2);
		this.parent.PartLasterStart();
	}

	// Token: 0x060002BA RID: 698 RVA: 0x000335DC File Offset: 0x000317DC
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

	// Token: 0x060002BB RID: 699 RVA: 0x0003374B File Offset: 0x0003194B
	private void ScrStartVib()
	{
		this.parent.StartVib(65535);
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0003375D File Offset: 0x0003195D
	private void ScrStopVib()
	{
		this.parent.StopVib();
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0003376C File Offset: 0x0003196C
	private void ScrLaserReady()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 2;
		this.parent.slxy[0] = (int)this.GetScrShort();
		this.parent.slxy[1] = (int)this.GetScrShort();
		this.parent.slxy[2] = 0;
	}

	// Token: 0x060002BE RID: 702 RVA: 0x000337C4 File Offset: 0x000319C4
	private void ScrLaserReadyStop()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 0;
		this.parent.slxy[0] = (this.parent.slxy[1] = (this.parent.slxy[2] = 0));
	}

	// Token: 0x060002BF RID: 703 RVA: 0x00033816 File Offset: 0x00031A16
	private void ScrQuake2()
	{
		this.parent.quf = 1;
		this.parent.StartVib(65535);
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00033834 File Offset: 0x00031A34
	private void ScrQuakeStop()
	{
		this.parent.quf = 0;
		this.parent.qux = (this.parent.quy = 0);
		this.parent.StopVib();
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00033872 File Offset: 0x00031A72
	private void ScrSkipAddress()
	{
		this.sc_skipadr = (int)this.GetScrShort();
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x00033880 File Offset: 0x00031A80
	private void ScrApprCharClear()
	{
		this.parent.apr_no = 0;
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, 255);
			this.parent.SetStatus(i, 20, 2);
		}
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x000338C8 File Offset: 0x00031AC8
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

	// Token: 0x060002C4 RID: 708 RVA: 0x00033958 File Offset: 0x00031B58
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

	// Token: 0x060002C5 RID: 709 RVA: 0x000339BC File Offset: 0x00031BBC
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

	// Token: 0x060002C6 RID: 710 RVA: 0x00033BC0 File Offset: 0x00031DC0
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

	// Token: 0x060002C7 RID: 711 RVA: 0x00033DC4 File Offset: 0x00031FC4
	private void ScrPlaySe()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PlaySe(scrByte);
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x00033DE4 File Offset: 0x00031FE4
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

	// Token: 0x060002C9 RID: 713 RVA: 0x00033E35 File Offset: 0x00032035
	private void ScrStopBgm()
	{
		this.parent.StopAllSound();
	}

	// Token: 0x060002CA RID: 714 RVA: 0x00033E42 File Offset: 0x00032042
	private void ScrRevivePoint()
	{
		this.parent.SetRevivePoint();
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00033E4F File Offset: 0x0003204F
	private void ScrStopSe()
	{
		this.parent.StopSe();
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00033E5C File Offset: 0x0003205C
	private void ScrApprCharPush()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.ranks2[i][0] = this.parent.GetRanks(i);
			this.parent.ranks2[i][1] = this.parent.GetStatus(i, 20);
		}
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00033EB0 File Offset: 0x000320B0
	private void ScrApprCharPop()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, this.parent.ranks2[i][0]);
			this.parent.SetStatus(i, 20, this.parent.ranks2[i][1]);
		}
		this.parent.SetMapPlayerChar(this.parent.ranks2[0][0]);
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00033F1C File Offset: 0x0003211C
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

	// Token: 0x060002CF RID: 719 RVA: 0x0003405C File Offset: 0x0003225C
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

	// Token: 0x060002D0 RID: 720 RVA: 0x000340A0 File Offset: 0x000322A0
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

	// Token: 0x060002D1 RID: 721 RVA: 0x000341CC File Offset: 0x000323CC
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

	// Token: 0x060002D2 RID: 722 RVA: 0x00034220 File Offset: 0x00032420
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

	// Token: 0x040001EE RID: 494
	protected internal XenoPP01Canvas parent;

	// Token: 0x040001EF RID: 495
	public sbyte[] script;

	// Token: 0x040001F0 RID: 496
	public int script_adr;

	// Token: 0x040001F1 RID: 497
	public int script_adr_ret;

	// Token: 0x040001F2 RID: 498
	public int script_b_adr;

	// Token: 0x040001F3 RID: 499
	public bool script_nflg;

	// Token: 0x040001F4 RID: 500
	public bool script_b_nflg;

	// Token: 0x040001F5 RID: 501
	public bool script_flg;

	// Token: 0x040001F6 RID: 502
	public int script_cmd;

	// Token: 0x040001F7 RID: 503
	public int script_b_cmd;

	// Token: 0x040001F8 RID: 504
	public int[] sc_wk;

	// Token: 0x040001F9 RID: 505
	public string[] sc_str;

	// Token: 0x040001FA RID: 506
	public string sc_name;

	// Token: 0x040001FB RID: 507
	public int sc_strl;

	// Token: 0x040001FC RID: 508
	public bool[] sc_ifflg;

	// Token: 0x040001FD RID: 509
	public bool[] sc_b_ifflg;

	// Token: 0x040001FE RID: 510
	public sbyte sc_ifdpt;

	// Token: 0x040001FF RID: 511
	public sbyte sc_b_ifdpt;

	// Token: 0x04000200 RID: 512
	public bool sc_messkip;

	// Token: 0x04000201 RID: 513
	public int sc_skipadr;

	// Token: 0x04000202 RID: 514
	public int[] sc_flg;

	// Token: 0x04000203 RID: 515
	public int sc_face;

	// Token: 0x04000204 RID: 516
	public sbyte[] vscript;

	// Token: 0x04000205 RID: 517
	public int[] sc_stry;

	// Token: 0x04000206 RID: 518
	public int sc_picy;

	// Token: 0x04000207 RID: 519
	public int sc_picno;

	// Token: 0x04000208 RID: 520
	public int sc_drawy;

	// Token: 0x04000209 RID: 521
	public int sc_wait;

	// Token: 0x0400020A RID: 522
	public int sc_winy;

	// Token: 0x0400020B RID: 523
	private sbyte[] msstr;

	// Token: 0x0400020C RID: 524
	public int[][] npc_xy;

	// Token: 0x0400020D RID: 525
	public int[][] npc_pn;

	// Token: 0x0400020E RID: 526
	public int[] npc_mv;

	// Token: 0x0400020F RID: 527
	public int[] npc_adr;

	// Token: 0x04000210 RID: 528
	public int npc_p;

	// Token: 0x04000211 RID: 529
	public int npc_no;

	// Token: 0x04000212 RID: 530
	public int[][] npc_wk;

	// Token: 0x04000213 RID: 531
	public int[][] obj_xy;

	// Token: 0x04000214 RID: 532
	public int[] obj_pn;

	// Token: 0x04000215 RID: 533
	public int[] obj_adr;

	// Token: 0x04000216 RID: 534
	public int[] obj_kill;

	// Token: 0x04000217 RID: 535
	public int[] obj_cmd;

	// Token: 0x04000218 RID: 536
	public int[][] obj_anm;

	// Token: 0x04000219 RID: 537
	public int[] obj_prio;

	// Token: 0x0400021A RID: 538
	public bool[] obj_nflg;

	// Token: 0x0400021B RID: 539
	public int[][] obj_wk;

	// Token: 0x0400021C RID: 540
	public int obj_p;

	// Token: 0x0400021D RID: 541
	public int obj_no;

	// Token: 0x0400021E RID: 542
	public int[][] tobj_xy;

	// Token: 0x0400021F RID: 543
	public int[] tobj_adr;

	// Token: 0x04000220 RID: 544
	public int[] tobj_cnd;

	// Token: 0x04000221 RID: 545
	public int[] tobj_pn;

	// Token: 0x04000222 RID: 546
	public int tobj_p;

	// Token: 0x04000223 RID: 547
	public int tobj_no;

	// Token: 0x04000224 RID: 548
	public int[] tobj_cno;
}
