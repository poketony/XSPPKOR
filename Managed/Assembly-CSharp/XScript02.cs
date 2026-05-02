using System;

// Token: 0x02000033 RID: 51
public sealed class XScript02
{
	// Token: 0x06000464 RID: 1124 RVA: 0x00056DE4 File Offset: 0x00054FE4
	protected internal XScript02(XenoPP02Canvas cvs)
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

	// Token: 0x06000465 RID: 1125 RVA: 0x00057D94 File Offset: 0x00055F94
	public void ScFlagClear()
	{
		for (int i = 0; i < 80; i++)
		{
			this.sc_flg[i] = 0;
		}
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00057DB8 File Offset: 0x00055FB8
	public void ScWkClear()
	{
		for (int i = 0; i < 8; i++)
		{
			this.sc_wk[i] = 0;
		}
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00057DDC File Offset: 0x00055FDC
	public void ObjWkClear()
	{
		for (int i = 0; i < 4; i++)
		{
			this.obj_wk[this.obj_no][i] = 65535;
		}
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00057E0C File Offset: 0x0005600C
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

	// Token: 0x06000469 RID: 1129 RVA: 0x00057E54 File Offset: 0x00056054
	public short GetScrShort()
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP02Canvas.ArrayShort2(this.script, this.script_adr);
		}
		else
		{
			num = XenoPP02Canvas.ArrayShort2(this.vscript, this.script_adr);
		}
		this.script_adr += 2;
		return num;
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x00057EA4 File Offset: 0x000560A4
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

	// Token: 0x0600046B RID: 1131 RVA: 0x00057ED4 File Offset: 0x000560D4
	public short GetScrShort2(int adr)
	{
		short num;
		if (this.parent.GetSeqNo() == 7)
		{
			num = XenoPP02Canvas.ArrayShort2(this.script, adr);
		}
		else
		{
			num = XenoPP02Canvas.ArrayShort2(this.vscript, adr);
		}
		return num;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00057F0C File Offset: 0x0005610C
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

	// Token: 0x0600046D RID: 1133 RVA: 0x00058028 File Offset: 0x00056228
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

	// Token: 0x0600046E RID: 1134 RVA: 0x000580F4 File Offset: 0x000562F4
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

	// Token: 0x0600046F RID: 1135 RVA: 0x000581D8 File Offset: 0x000563D8
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

	// Token: 0x06000470 RID: 1136 RVA: 0x0005825B File Offset: 0x0005645B
	public bool IsMessageSelect()
	{
		return this.script_cmd == 59;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0005826C File Offset: 0x0005646C
	public bool IsMessageEnd()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || this.script_cmd == 34 || this.script_cmd == 36 || this.script_cmd == 95 || this.script_cmd == 102 || this.script_cmd == 104 || this.script_cmd == 105 || (this.script_cmd == 4 && this.sc_wk[0] == 0);
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x000582E0 File Offset: 0x000564E0
	public bool IsMessageEnd2()
	{
		return this.script_cmd == 21 || this.script_cmd == 27 || (this.script_cmd != 26 && this.script_cmd != 7) || ((this.script_cmd == 26 || this.script_cmd == 7) && this.sc_wk[0] == 0);
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00058334 File Offset: 0x00056534
	public bool IsMessageEnd3()
	{
		return this.script_cmd == 21 || this.script_cmd == 31 || (this.script_cmd == 95 && this.sc_wk[0] >= 2);
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x00058362 File Offset: 0x00056562
	public bool IsMessageEnd4()
	{
		return this.script_cmd == 84;
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x00058371 File Offset: 0x00056571
	public bool IsMessage()
	{
		return this.script_cmd == 4;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0005837F File Offset: 0x0005657F
	public bool IsMessage2()
	{
		return this.script_cmd == 26 || this.script_cmd == 7;
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x00058397 File Offset: 0x00056597
	public string SpReplace(string str)
	{
		return str.Replace('Ⅰ', '\ue6e2').Replace('Ⅱ', '\ue6e3').Replace('Ⅲ', '\ue6e4');
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x000583C8 File Offset: 0x000565C8
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

	// Token: 0x06000479 RID: 1145 RVA: 0x000584B0 File Offset: 0x000566B0
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

	// Token: 0x0600047A RID: 1146 RVA: 0x000585EC File Offset: 0x000567EC
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

	// Token: 0x0600047B RID: 1147 RVA: 0x00058698 File Offset: 0x00056898
	public void ScriptInit3(int adr)
	{
		this.script_adr = adr;
		this.sc_ifdpt = -1;
		for (int i = 0; i < 5; i++)
		{
			this.sc_ifflg[i] = false;
		}
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x000586C8 File Offset: 0x000568C8
	public bool IsScriptExec()
	{
		return !this.script_flg;
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x000586D8 File Offset: 0x000568D8
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

	// Token: 0x0600047E RID: 1150 RVA: 0x00058E5C File Offset: 0x0005705C
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

	// Token: 0x0600047F RID: 1151 RVA: 0x00058EAC File Offset: 0x000570AC
	private void ScrSetObject()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		int scrShort = (int)this.GetScrShort();
		num *= 16;
		num2 *= 16;
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x00058EE1 File Offset: 0x000570E1
	private void ScrExit()
	{
		this.GetScrByte();
		this.script_flg = true;
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x00058EF4 File Offset: 0x000570F4
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

	// Token: 0x06000482 RID: 1154 RVA: 0x000590DC File Offset: 0x000572DC
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

	// Token: 0x06000483 RID: 1155 RVA: 0x000593D0 File Offset: 0x000575D0
	private void ScrFlagOn()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 1;
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x000593F0 File Offset: 0x000575F0
	private void ScrFlagOff()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_flg[(int)scrByte] = 0;
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x00059410 File Offset: 0x00057610
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

	// Token: 0x06000486 RID: 1158 RVA: 0x000594F4 File Offset: 0x000576F4
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

	// Token: 0x06000487 RID: 1159 RVA: 0x00059550 File Offset: 0x00057750
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

	// Token: 0x06000488 RID: 1160 RVA: 0x00059614 File Offset: 0x00057814
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

	// Token: 0x06000489 RID: 1161 RVA: 0x00059683 File Offset: 0x00057883
	private void ScrEndIf()
	{
		if (this.sc_ifdpt != -1)
		{
			this.sc_ifflg[(int)this.sc_ifdpt] = false;
			this.sc_ifdpt -= 1;
		}
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x000596AC File Offset: 0x000578AC
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

	// Token: 0x0600048B RID: 1163 RVA: 0x00059706 File Offset: 0x00057906
	private void ScrSetVisual()
	{
		this.parent.visualno = (int)this.GetScrByte();
		this.parent.SetSeqNo(8);
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x00059728 File Offset: 0x00057928
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

	// Token: 0x0600048D RID: 1165 RVA: 0x00059760 File Offset: 0x00057960
	private void ScrGosub()
	{
		int scrShort = (int)this.GetScrShort();
		this.script_adr_ret = this.script_adr;
		this.script_adr = scrShort;
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x00059787 File Offset: 0x00057987
	private void ScrReturn()
	{
		this.script_adr = this.script_adr_ret;
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x00059798 File Offset: 0x00057998
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

	// Token: 0x06000490 RID: 1168 RVA: 0x000598AC File Offset: 0x00057AAC
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

	// Token: 0x06000491 RID: 1169 RVA: 0x0005991C File Offset: 0x00057B1C
	private void ScrSetPicture()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picno = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x00059944 File Offset: 0x00057B44
	private void ScrSetPicPos()
	{
		sbyte scrByte = this.GetScrByte();
		this.sc_picy = (int)scrByte;
		this.parent.red = true;
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0005996B File Offset: 0x00057B6B
	private void ScrSetPicPosP()
	{
		this.sc_picy++;
		this.parent.red = true;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00059988 File Offset: 0x00057B88
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

	// Token: 0x06000495 RID: 1173 RVA: 0x00059C38 File Offset: 0x00057E38
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

	// Token: 0x06000496 RID: 1174 RVA: 0x00059C9C File Offset: 0x00057E9C
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

	// Token: 0x06000497 RID: 1175 RVA: 0x00059D16 File Offset: 0x00057F16
	private void ScrSetDrawArea()
	{
		this.sc_drawy = (int)this.GetScrShort();
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x00059D24 File Offset: 0x00057F24
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

	// Token: 0x06000499 RID: 1177 RVA: 0x00059DF0 File Offset: 0x00057FF0
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

	// Token: 0x0600049A RID: 1178 RVA: 0x00059E1B File Offset: 0x0005801B
	private void ScrSetWindowY()
	{
		this.sc_winy = (int)this.GetScrShort();
		if (this.sc_winy >= 164)
		{
			this.sc_winy = 164;
		}
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x00059E44 File Offset: 0x00058044
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

	// Token: 0x0600049C RID: 1180 RVA: 0x00059F90 File Offset: 0x00058190
	private void ScrSetMapPos()
	{
		int num = (int)this.GetScrByte();
		num *= 16;
		int num2 = (int)this.GetScrByte();
		num2 *= 16;
		this.parent.SetMapPosU(num, num2);
		this.parent.red = true;
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00059FD0 File Offset: 0x000581D0
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

	// Token: 0x0600049E RID: 1182 RVA: 0x0005A268 File Offset: 0x00058468
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

	// Token: 0x0600049F RID: 1183 RVA: 0x0005A314 File Offset: 0x00058514
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

	// Token: 0x060004A0 RID: 1184 RVA: 0x0005A384 File Offset: 0x00058584
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

	// Token: 0x060004A1 RID: 1185 RVA: 0x0005A56C File Offset: 0x0005876C
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

	// Token: 0x060004A2 RID: 1186 RVA: 0x0005A754 File Offset: 0x00058954
	private void ScrSetObject2()
	{
		int num = this.obj_xy[this.obj_no][0];
		int num2 = this.obj_xy[this.obj_no][1];
		int scrShort = (int)this.GetScrShort();
		this.SetMapObj(num, num2, scrShort);
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x0005A791 File Offset: 0x00058991
	private void ScrKillObj()
	{
		this.obj_kill[this.obj_no] = 1;
		this.parent.red = true;
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0005A7B0 File Offset: 0x000589B0
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

	// Token: 0x060004A5 RID: 1189 RVA: 0x0005A838 File Offset: 0x00058A38
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

	// Token: 0x060004A6 RID: 1190 RVA: 0x0005ABF8 File Offset: 0x00058DF8
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

	// Token: 0x060004A7 RID: 1191 RVA: 0x0005AFAC File Offset: 0x000591AC
	private void ScrSetPlayPos()
	{
		int num = (int)this.GetScrByte();
		int num2 = (int)this.GetScrByte();
		num *= 16;
		num2 *= 16;
		this.parent.chx = num + 8;
		this.parent.chy = num2 + 16;
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x0005AFF0 File Offset: 0x000591F0
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

	// Token: 0x060004A9 RID: 1193 RVA: 0x0005B144 File Offset: 0x00059344
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

	// Token: 0x060004AA RID: 1194 RVA: 0x0005B298 File Offset: 0x00059498
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

	// Token: 0x060004AB RID: 1195 RVA: 0x0005B392 File Offset: 0x00059592
	private void ScrChangeMap()
	{
		this.parent.isupdate = false;
		this.parent.mapno = (int)this.GetScrByte();
		this.parent.SetSeqNo(6);
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0005B3C0 File Offset: 0x000595C0
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

	// Token: 0x060004AD RID: 1197 RVA: 0x0005B410 File Offset: 0x00059610
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

	// Token: 0x060004AE RID: 1198 RVA: 0x0005B7E8 File Offset: 0x000599E8
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

	// Token: 0x060004AF RID: 1199 RVA: 0x0005BBB4 File Offset: 0x00059DB4
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

	// Token: 0x060004B0 RID: 1200 RVA: 0x0005BC08 File Offset: 0x00059E08
	private void ScrObjectClear()
	{
		this.ScriptObjInit();
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x0005BC10 File Offset: 0x00059E10
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

	// Token: 0x060004B2 RID: 1202 RVA: 0x0005BCA0 File Offset: 0x00059EA0
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

	// Token: 0x060004B3 RID: 1203 RVA: 0x0005BEA4 File Offset: 0x0005A0A4
	private void ScrSetMapPosP()
	{
		this.parent.SetMapPos();
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x0005BEB4 File Offset: 0x0005A0B4
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

	// Token: 0x060004B5 RID: 1205 RVA: 0x0005BF04 File Offset: 0x0005A104
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

	// Token: 0x060004B6 RID: 1206 RVA: 0x0005BF46 File Offset: 0x0005A146
	private void ScrSetObjPrio()
	{
		this.obj_prio[this.obj_no] = (int)this.GetScrByte();
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x0005BF5C File Offset: 0x0005A15C
	private void ScrStartLaster()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster(scrByte);
		this.parent.PartLasterStart();
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x0005BF92 File Offset: 0x0005A192
	private void ScrEndLaster()
	{
		this.parent.PartLasterEnd();
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0005BFA0 File Offset: 0x0005A1A0
	private void ScrSetPlayChar()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.SetMapPlayerChar(scrByte);
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0005BFC0 File Offset: 0x0005A1C0
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

	// Token: 0x060004BB RID: 1211 RVA: 0x0005C060 File Offset: 0x0005A260
	private void ScrGetItem()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.AddItem(scrByte, 1);
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0005C084 File Offset: 0x0005A284
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

	// Token: 0x060004BD RID: 1213 RVA: 0x0005C0F4 File Offset: 0x0005A2F4
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

	// Token: 0x060004BE RID: 1214 RVA: 0x0005C13B File Offset: 0x0005A33B
	private void ScrQuake()
	{
		this.parent.quf = 2;
		this.parent.StartVib(65535);
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0005C15C File Offset: 0x0005A35C
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

	// Token: 0x060004C0 RID: 1216 RVA: 0x0005C264 File Offset: 0x0005A464
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

	// Token: 0x060004C1 RID: 1217 RVA: 0x0005C5C4 File Offset: 0x0005A7C4
	private void ScrStartLaster2()
	{
		int scrByte = (int)this.GetScrByte();
		int scrByte2 = (int)this.GetScrByte();
		this.parent.PartLasterWorkClear();
		this.parent.SetPartLaster2(scrByte, scrByte2);
		this.parent.PartLasterStart();
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x0005C604 File Offset: 0x0005A804
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

	// Token: 0x060004C3 RID: 1219 RVA: 0x0005C773 File Offset: 0x0005A973
	private void ScrStartVib()
	{
		this.parent.StartVib(65535);
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0005C785 File Offset: 0x0005A985
	private void ScrStopVib()
	{
		this.parent.StopVib();
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x0005C794 File Offset: 0x0005A994
	private void ScrLaserReady()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 2;
		this.parent.slxy[0] = (int)this.GetScrShort();
		this.parent.slxy[1] = (int)this.GetScrShort();
		this.parent.slxy[2] = 0;
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0005C7EC File Offset: 0x0005A9EC
	private void ScrLaserReadyStop()
	{
		this.parent.StarWorkInit();
		this.parent.slf = 0;
		this.parent.slxy[0] = (this.parent.slxy[1] = (this.parent.slxy[2] = 0));
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x0005C83E File Offset: 0x0005AA3E
	private void ScrQuake2()
	{
		this.parent.quf = 1;
		this.parent.StartVib(65535);
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x0005C85C File Offset: 0x0005AA5C
	private void ScrQuakeStop()
	{
		this.parent.quf = 0;
		this.parent.qux = (this.parent.quy = 0);
		this.parent.StopVib();
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x0005C89A File Offset: 0x0005AA9A
	private void ScrSkipAddress()
	{
		this.sc_skipadr = (int)this.GetScrShort();
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x0005C8A8 File Offset: 0x0005AAA8
	private void ScrApprCharClear()
	{
		this.parent.apr_no = 0;
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, 255);
			this.parent.SetStatus(i, 20, 2);
		}
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0005C8F0 File Offset: 0x0005AAF0
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

	// Token: 0x060004CC RID: 1228 RVA: 0x0005C980 File Offset: 0x0005AB80
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

	// Token: 0x060004CD RID: 1229 RVA: 0x0005C9E4 File Offset: 0x0005ABE4
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

	// Token: 0x060004CE RID: 1230 RVA: 0x0005CBE8 File Offset: 0x0005ADE8
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

	// Token: 0x060004CF RID: 1231 RVA: 0x0005CDEC File Offset: 0x0005AFEC
	private void ScrPlaySe()
	{
		int scrByte = (int)this.GetScrByte();
		this.parent.PlaySe(scrByte);
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x0005CE0C File Offset: 0x0005B00C
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

	// Token: 0x060004D1 RID: 1233 RVA: 0x0005CE5D File Offset: 0x0005B05D
	private void ScrStopBgm()
	{
		this.parent.StopAllSound();
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x0005CE6A File Offset: 0x0005B06A
	private void ScrRevivePoint()
	{
		this.parent.SetRevivePoint();
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x0005CE77 File Offset: 0x0005B077
	private void ScrStopSe()
	{
		this.parent.StopSe();
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x0005CE84 File Offset: 0x0005B084
	private void ScrApprCharPush()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.ranks2[i][0] = this.parent.GetRanks(i);
			this.parent.ranks2[i][1] = this.parent.GetStatus(i, 20);
		}
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x0005CED8 File Offset: 0x0005B0D8
	private void ScrApprCharPop()
	{
		for (int i = 0; i < 4; i++)
		{
			this.parent.SetRanks(i, this.parent.ranks2[i][0]);
			this.parent.SetStatus(i, 20, this.parent.ranks2[i][1]);
		}
		this.parent.SetMapPlayerChar(this.parent.ranks2[0][0]);
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x0005CF44 File Offset: 0x0005B144
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

	// Token: 0x060004D7 RID: 1239 RVA: 0x0005D084 File Offset: 0x0005B284
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

	// Token: 0x060004D8 RID: 1240 RVA: 0x0005D0C8 File Offset: 0x0005B2C8
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

	// Token: 0x060004D9 RID: 1241 RVA: 0x0005D1F4 File Offset: 0x0005B3F4
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

	// Token: 0x060004DA RID: 1242 RVA: 0x0005D248 File Offset: 0x0005B448
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

	// Token: 0x04000308 RID: 776
	protected internal XenoPP02Canvas parent;

	// Token: 0x04000309 RID: 777
	public sbyte[] script;

	// Token: 0x0400030A RID: 778
	public int script_adr;

	// Token: 0x0400030B RID: 779
	public int script_adr_ret;

	// Token: 0x0400030C RID: 780
	public int script_b_adr;

	// Token: 0x0400030D RID: 781
	public bool script_nflg;

	// Token: 0x0400030E RID: 782
	public bool script_b_nflg;

	// Token: 0x0400030F RID: 783
	public bool script_flg;

	// Token: 0x04000310 RID: 784
	public int script_cmd;

	// Token: 0x04000311 RID: 785
	public int script_b_cmd;

	// Token: 0x04000312 RID: 786
	public int[] sc_wk;

	// Token: 0x04000313 RID: 787
	public string[] sc_str;

	// Token: 0x04000314 RID: 788
	public string sc_name;

	// Token: 0x04000315 RID: 789
	public int sc_strl;

	// Token: 0x04000316 RID: 790
	public bool[] sc_ifflg;

	// Token: 0x04000317 RID: 791
	public bool[] sc_b_ifflg;

	// Token: 0x04000318 RID: 792
	public sbyte sc_ifdpt;

	// Token: 0x04000319 RID: 793
	public sbyte sc_b_ifdpt;

	// Token: 0x0400031A RID: 794
	public bool sc_messkip;

	// Token: 0x0400031B RID: 795
	public int sc_skipadr;

	// Token: 0x0400031C RID: 796
	public int[] sc_flg;

	// Token: 0x0400031D RID: 797
	public int sc_face;

	// Token: 0x0400031E RID: 798
	public sbyte[] vscript;

	// Token: 0x0400031F RID: 799
	public int[] sc_stry;

	// Token: 0x04000320 RID: 800
	public int sc_picy;

	// Token: 0x04000321 RID: 801
	public int sc_picno;

	// Token: 0x04000322 RID: 802
	public int sc_drawy;

	// Token: 0x04000323 RID: 803
	public int sc_wait;

	// Token: 0x04000324 RID: 804
	public int sc_winy;

	// Token: 0x04000325 RID: 805
	private sbyte[] msstr;

	// Token: 0x04000326 RID: 806
	public int[][] npc_xy;

	// Token: 0x04000327 RID: 807
	public int[][] npc_pn;

	// Token: 0x04000328 RID: 808
	public int[] npc_mv;

	// Token: 0x04000329 RID: 809
	public int[] npc_adr;

	// Token: 0x0400032A RID: 810
	public int npc_p;

	// Token: 0x0400032B RID: 811
	public int npc_no;

	// Token: 0x0400032C RID: 812
	public int[][] npc_wk;

	// Token: 0x0400032D RID: 813
	public int[][] obj_xy;

	// Token: 0x0400032E RID: 814
	public int[] obj_pn;

	// Token: 0x0400032F RID: 815
	public int[] obj_adr;

	// Token: 0x04000330 RID: 816
	public int[] obj_kill;

	// Token: 0x04000331 RID: 817
	public int[] obj_cmd;

	// Token: 0x04000332 RID: 818
	public int[][] obj_anm;

	// Token: 0x04000333 RID: 819
	public int[] obj_prio;

	// Token: 0x04000334 RID: 820
	public bool[] obj_nflg;

	// Token: 0x04000335 RID: 821
	public int[][] obj_wk;

	// Token: 0x04000336 RID: 822
	public int obj_p;

	// Token: 0x04000337 RID: 823
	public int obj_no;

	// Token: 0x04000338 RID: 824
	public int[][] tobj_xy;

	// Token: 0x04000339 RID: 825
	public int[] tobj_adr;

	// Token: 0x0400033A RID: 826
	public int[] tobj_cnd;

	// Token: 0x0400033B RID: 827
	public int[] tobj_pn;

	// Token: 0x0400033C RID: 828
	public int tobj_p;

	// Token: 0x0400033D RID: 829
	public int tobj_no;

	// Token: 0x0400033E RID: 830
	public int[] tobj_cno;
}
