using System;
using System.Collections;
using System.IO;
using Socotra;
using Socotra.Device;
using Socotra.IO;
using Socotra.Media;
using Socotra.Opt.UI.J3d;
using Socotra.UI;
using Socotra.Util;
using Steezy.Utility;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class XenoPP06Canvas : StCanvas, StRunnable, MediaListener
{
	// Token: 0x06000B1A RID: 2842 RVA: 0x000DE340 File Offset: 0x000DC540
	public XenoPP06Canvas()
	{
		int[][] array = new int[66][];
		array[0] = new int[] { 0, 2, 3, 2 };
		array[1] = new int[] { 0, 2, 3, 2 };
		array[2] = new int[] { 0, 2, 3, 2 };
		array[3] = new int[] { 0, 2, 3, 2 };
		array[4] = new int[] { 0, 2, 3, 2 };
		array[5] = new int[] { 0, 2, 3, 2 };
		array[6] = new int[] { 0, 2, 3, 2 };
		array[7] = new int[] { 0, 2, 3, 2 };
		array[8] = new int[] { 0, 2, 3, 2 };
		array[9] = new int[] { 0, 7, 1, 2 };
		array[10] = new int[] { 0, 7, 1, 2 };
		array[11] = new int[] { 0, 2, 1, 1 };
		array[12] = new int[] { 0, 2, 1, 1 };
		array[13] = new int[] { 0, 2, 1, 1 };
		array[14] = new int[] { 0, 2, 1, 1 };
		array[15] = new int[] { 0, 5, 1, 255 };
		array[16] = new int[] { 0, 5, 2, 255 };
		array[17] = new int[] { 1, 1, 4, 0 };
		array[18] = new int[] { 1, 1, 8, 0 };
		array[19] = new int[] { 1, 1, 13, 0 };
		array[20] = new int[] { 1, 1, 19, 0 };
		array[21] = new int[] { 1, 1, 25, 0 };
		array[22] = new int[] { 1, 1, 30, 0 };
		array[23] = new int[] { 1, 1, 35, 0 };
		array[24] = new int[] { 1, 2, 2, 0 };
		array[25] = new int[] { 1, 2, 7, 0 };
		array[26] = new int[] { 1, 2, 11, 0 };
		array[27] = new int[] { 1, 2, 16, 0 };
		array[28] = new int[] { 1, 2, 20, 0 };
		array[29] = new int[] { 1, 2, 24, 0 };
		array[30] = new int[] { 1, 2, 28, 0 };
		array[31] = new int[] { 1, 4, 2, 0 };
		array[32] = new int[] { 1, 4, 6, 0 };
		array[33] = new int[] { 1, 4, 9, 2 };
		array[34] = new int[] { 1, 4, 12, 4 };
		array[35] = new int[] { 1, 4, 16, 6 };
		array[36] = new int[] { 1, 4, 19, 8 };
		array[37] = new int[] { 1, 4, 22, 10 };
		int num = 38;
		int[] array2 = new int[4];
		array2[0] = 1;
		array2[1] = 8;
		array[num] = array2;
		array[39] = new int[] { 1, 8, 4, 0 };
		array[40] = new int[] { 1, 8, 9, 0 };
		array[41] = new int[] { 1, 8, 14, 0 };
		array[42] = new int[] { 1, 8, 19, 0 };
		array[43] = new int[] { 1, 8, 24, 0 };
		array[44] = new int[] { 1, 8, 30, 0 };
		int num2 = 45;
		int[] array3 = new int[4];
		array3[0] = 2;
		array3[1] = 8;
		array[num2] = array3;
		array[46] = new int[] { 2, 7, 3, 0 };
		array[47] = new int[] { 2, 7, 7, 0 };
		array[48] = new int[] { 2, 8, 4, 0 };
		array[49] = new int[] { 2, 7, 12, 0 };
		array[50] = new int[] { 2, 8, 10, 0 };
		array[51] = new int[] { 2, 7, 17, 0 };
		array[52] = new int[] { 2, 5, 20, 0 };
		array[53] = new int[] { 2, 8, 16, 0 };
		array[54] = new int[] { 2, 7, 25, 2 };
		array[55] = new int[] { 2, 5, 28, 0 };
		array[56] = new int[] { 2, 8, 21, 0 };
		array[57] = new int[] { 2, 7, 30, 0 };
		array[58] = new int[] { 2, 2, 33, 5 };
		array[59] = new int[] { 2, 8, 28, 0 };
		array[60] = new int[] { 2, 7, 38, 3 };
		array[61] = new int[] { 2, 7, 40, 8 };
		array[62] = new int[] { 2, 8, 33, 0 };
		array[63] = new int[] { 0, 255, 4, 255 };
		array[64] = new int[] { 0, 255, 4, 255 };
		array[65] = new int[] { 0, 255, 4, 255 };
		this.ItemData = array;
		this.menuroot = new string[] { "アイテム", "エーテル", "必殺技", "キャラクター", "バトル編成", "ゲーム環境", "セーブ", "ロード", "ヘルプ" };
		this.configmenu = new string[][]
		{
			new string[] { "サウンド", "サウンドのON/OFFを設定します" },
			new string[] { "バイブレーター", "振動のON/OFFを設定します" },
			new string[] { "メッセージ一括表示", "一括表示のON/OFFを設定します" },
			new string[] { "バックライト点灯", "常時点灯のON/OFFを設定します" }
		};
		base..ctor();
		this.self = this;
		this.msg_isactive = true;
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x000E337E File Offset: 0x000E157E
	public virtual IEnumerator Run()
	{
		this.SetBackLight(true);
		this.fps_ot = SingletonBehaviour<SocotraRuntime>.Instance.CurrentTimeMillis();
		this.debugstr = string.Empty;
		this.nowtime = 0L;
		this.oldtime = 0L;
		while (!this.msg_isfinish)
		{
			if (this.msg_isactive)
			{
				this.Game_loop();
				if (this.isupdate)
				{
					this.Paint(base.GetGraphics());
				}
			}
			this.sync = (this.sync + 1) % 9999;
			this.fps_nt = (this.nowtime = SingletonBehaviour<SocotraRuntime>.Instance.CurrentTimeMillis());
			if (this.fps_nt - this.fps_ot > 1000L && this.GetConfig(3) == 1)
			{
				this.SetBackLight(true);
			}
			this.fps_cnt++;
			if (this.fps_nt - this.fps_ot > 1000L)
			{
				this.fps_ot = this.fps_nt;
				this.fps = this.fps_cnt;
				this.fps_cnt = 0;
			}
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}

	// Token: 0x06000B1C RID: 2844 RVA: 0x000E3390 File Offset: 0x000E1590
	public override void Paint(StGraphics g)
	{
		lock (this)
		{
			if ((this.mapno != 25 && this.mapno != 26) || this.xscr.sc_flg[5] != 1 || this.xscr.sc_flg[9] != 1)
			{
				if (this.isupdate)
				{
					g.Lock();
					this.SetFont(g, 0);
					g.SetClip(0, 0, 240, 240);
					this.Game_paint(g, true);
					g.Unlock(true);
				}
			}
		}
	}

	// Token: 0x06000B1D RID: 2845 RVA: 0x000E3438 File Offset: 0x000E1638
	protected internal virtual void SetLoading(bool flg)
	{
		this.isloading = flg;
		if (!flg)
		{
			this.KeyClear();
		}
	}

	// Token: 0x06000B1E RID: 2846 RVA: 0x000E344C File Offset: 0x000E164C
	public virtual void KeyClear()
	{
		this.inputedg = 0;
		this.inputsep = 0;
		this.id_back = 0;
		this.id_data = 0;
		this.id_edge = 0;
		this.id_sepr = 0;
		this.id_rept = 0;
		this.id_count = 0;
		this.id_rwait = 0;
		this.id_rmask = -1;
		this.id_delay = 6;
		this.id_speed = 0;
	}

	// Token: 0x06000B1F RID: 2847 RVA: 0x000E34B0 File Offset: 0x000E16B0
	public override void ProcessEvent(int type, int param)
	{
		lock (this)
		{
		}
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x000E34E8 File Offset: 0x000E16E8
	private int SetKeyBit(int code)
	{
		int num = 0;
		if ((code & 131072) != 0)
		{
			num |= 1;
		}
		if ((code & 524288) != 0)
		{
			num |= 2;
		}
		if ((code & 65536) != 0)
		{
			num |= 4;
		}
		if ((code & 262144) != 0)
		{
			num |= 8;
		}
		if ((code & 1048576) != 0)
		{
			num |= 16;
		}
		if ((code & 2097152) != 0)
		{
			num |= 131072;
		}
		if ((code & 4194304) != 0)
		{
			num |= 262144;
		}
		if ((code & 1024) != 0)
		{
			num |= 32;
		}
		if ((code & 2048) != 0)
		{
			num |= 64;
		}
		if ((code & 2) != 0)
		{
			num |= 256;
		}
		if ((code & 4) != 0)
		{
			num |= 512;
		}
		if ((code & 8) != 0)
		{
			num |= 1024;
		}
		if ((code & 16) != 0)
		{
			num |= 2048;
		}
		if ((code & 32) != 0)
		{
			num |= 4096;
		}
		if ((code & 64) != 0)
		{
			num |= 8192;
		}
		if ((code & 128) != 0)
		{
			num |= 16384;
		}
		if ((code & 256) != 0)
		{
			num |= 32768;
		}
		if ((code & 512) != 0)
		{
			num |= 65536;
		}
		if ((code & 1) != 0)
		{
			num |= 128;
		}
		return num;
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x000E3609 File Offset: 0x000E1809
	public virtual void SetSeqNo(int seq)
	{
		this.seq_no_b = seq;
		this.seq_step_b = 0;
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x000E3619 File Offset: 0x000E1819
	public virtual int GetSeqNo()
	{
		return this.seq_no;
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x000E3621 File Offset: 0x000E1821
	public virtual void SetSeqStep(int step)
	{
		this.seq_step_b = step;
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x000E362C File Offset: 0x000E182C
	public virtual void SetSeqStep2(int step)
	{
		this.seq_step_b = step;
		this.seq_step = step;
	}

	// Token: 0x06000B25 RID: 2853 RVA: 0x000E3649 File Offset: 0x000E1849
	public virtual int GetSeqStep()
	{
		return this.seq_step;
	}

	// Token: 0x06000B26 RID: 2854 RVA: 0x000E3654 File Offset: 0x000E1854
	private void GetKey()
	{
		this.id_back = this.id_data;
		this.id_data = this.SetKeyBit(base.GetKeypadState());
		this.id_edge = (this.id_back ^ this.id_data) & this.id_data;
		if (this.id_data != 0)
		{
			this.id_rept = 0;
			if (this.id_count > 6)
			{
				this.id_rwait++;
				if (this.id_rwait > this.id_speed)
				{
					this.id_rept = this.id_data;
					this.id_rwait = 0;
				}
			}
			else
			{
				this.id_count++;
			}
		}
		else
		{
			this.id_rept = 0;
			this.id_count = 0;
			this.id_rwait = 0;
		}
		this.id_rept |= this.id_edge;
	}

	// Token: 0x06000B27 RID: 2855 RVA: 0x000E371C File Offset: 0x000E191C
	public virtual void Game_loop()
	{
		this.seq_no = this.seq_no_b;
		this.seq_step = this.seq_step_b;
		if (this.sysred)
		{
			this.red = true;
		}
		else
		{
			this.red = false;
		}
		this.compred = false;
		this.GetKey();
		this.CommandAction();
		int seqNo = this.GetSeqNo();
		if (seqNo == 0)
		{
			this.SystemInit();
			this.SoundInit();
			this.ExistSaveData();
			this.KeyClear();
			if (this.parent.chk_mem)
			{
				this.SetSeqNo(23);
				this.isupdate = true;
			}
			else
			{
				this.SetSeqNo(1);
			}
			this.parent.init_end = true;
		}
		else if (seqNo == 23)
		{
			if (XenoPP06Canvas.auth_ret == 100)
			{
				this.Paint(base.GetGraphics());
				if (this.parent.chk_mem)
				{
					XenoPP06Canvas.auth_ret = this.CheckUser();
				}
				else
				{
					XenoPP06Canvas.auth_ret = 1;
				}
				if (XenoPP06Canvas.auth_ret == 1)
				{
					this.SetSeqNo(1);
				}
			}
			if (XenoPP06Canvas.auth_ret <= 0 && (this.id_edge & 4112) != 0)
			{
				this.GameEnd();
			}
			else if (XenoPP06Canvas.auth_ret == 2 && (this.id_edge & 4112) != 0)
			{
				this.AutoUpData();
			}
		}
		else if (seqNo == 1)
		{
			this.DataReadRoutine();
		}
		else if (seqNo == 2)
		{
			this.BattleInit();
		}
		else if (seqNo == 3)
		{
			this.BattleRoutine();
		}
		else if (seqNo == 4)
		{
			this.ResultRoutine();
		}
		else if (seqNo == 5)
		{
			this.GameOverRoutine();
		}
		else if (seqNo == 6)
		{
			this.isupdate = false;
			if (this.mrwait == 0)
			{
				this.vimg = null;
				this.readbuf = null;
				this.xscr.script = null;
				this.mapdat = null;
				this.atrdat = null;
				if (this.befmo != this.mofileno[this.mapno])
				{
					this.mcimg = null;
				}
			}
			this.mrwait++;
			if (this.mrwait >= 20)
			{
				this.mrwait = 0;
				this.SetSeqNo(18);
			}
		}
		else if (seqNo == 18)
		{
			this.SetMapData(this.mapno);
			this.SetMapPos();
			this.KeyClear();
			this.SetSeqNo(7);
		}
		else if (seqNo == 7)
		{
			this.MapRoutine();
		}
		else if (seqNo == 8)
		{
			this.vimg = null;
			this.SetVisualData(this.visualno);
			this.KeyClear();
			this.SetSeqNo(9);
		}
		else if (seqNo == 9)
		{
			this.VisualRoutine();
		}
		else if (seqNo == 10)
		{
			this.SetLoading(true);
			this.titleimg = new Image[6];
			this.readbuf = this.GetResource2(36);
			for (int i = 0; i < 6; i++)
			{
				short[] archive = XenoPP06Canvas.GetArchive(this.readbuf, i);
				int num = (int)archive[0];
				int num2 = (int)archive[1];
				this.titleimg[i] = this.BuildImage(this.readbuf, num, num2);
			}
			this.readbuf = null;
			this.SetLoading(false);
			this.StopAllSound();
			this.StatusInit();
			this.KeyClear();
			this.SetSeqNo(11);
		}
		else if (seqNo == 11)
		{
			this.TitleRoutine();
		}
		else if (seqNo == 12)
		{
			this.readbuf = this.GetResource2(25);
			short[] archive2 = XenoPP06Canvas.GetArchive(this.readbuf, 0);
			int num3 = (int)archive2[0];
			int num4 = (int)archive2[1];
			this.logoimg = this.BuildImage(this.readbuf, num3, num4);
			this.KeyClear();
			this.SetSeqNo(13);
		}
		else if (seqNo == 13)
		{
			this.LogoRoutine();
		}
		else if (seqNo == 14)
		{
			this.ContinueRoutine();
		}
		else if (seqNo == 16)
		{
			this.HelpInit();
		}
		else if (seqNo == 17)
		{
			this.HelpRoutine();
		}
		else if (seqNo == 19)
		{
			this.ClearLoadRoutine();
		}
		else if (seqNo == 21)
		{
			this.StaffRollRoutine();
		}
		this.DecieveRoutine();
		this.ExplosionSmokeRoutine();
		this.OpenLidRoutine();
		this.LuminescenceRoutine();
		this.VibRoutine();
		this.PartLasterRoutine();
		this.LaserRoutine();
		this.DomeEffectRoutine();
		this.DestructionRoutine();
		this.QuakeRoutine();
		this.PngFadeRoutine();
		this.FadeRoutine();
		this.SoundVolChange();
	}

	// Token: 0x06000B28 RID: 2856 RVA: 0x000E3B24 File Offset: 0x000E1D24
	public virtual void InitWorks()
	{
		this.KeyClear();
		this.nowtime = (this.oldtime = 0L);
		if (this.GetSeqNo() == 1 && this.GetSeqStep() == 10)
		{
			this.work[10] = 0;
		}
		this.sysred = true;
		this.red = true;
		this.compred = true;
		if (this.bred != null)
		{
			for (int i = 0; i < 5; i++)
			{
				this.bred[i] = true;
				this.bredn[i] = true;
			}
		}
		try
		{
			this.audio_b.Stop();
			this.audio_s.Stop();
			PhoneSystem.SetAttribute(1, 0);
			if (this.playbgm != -1 && this.nowbgm != -1)
			{
				this.audio_b.Play();
			}
			if (this.playse != -1 && this.se_loop_flag)
			{
				this.audio_s.Play();
			}
			if (this.vib[0] == 1)
			{
				this.StartVib(this.vib[1]);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x000E3C28 File Offset: 0x000E1E28
	public virtual void SystemInit()
	{
		this.sysimg = new Image[99];
		this.SetMenu(4);
		this.sfont = StFont.GetFont(560);
		this.lfont = StFont.GetFont(656);
		this.lfHeight = this.lfont.GetHeight();
		this.rand = new Random();
		this.InitFade();
		this.status = new int[][]
		{
			new int[26],
			new int[26],
			new int[26],
			new int[26]
		};
		this.estatus = new int[][]
		{
			new int[40],
			new int[40],
			new int[40],
			new int[40]
		};
		this.st_ab = new int[][]
		{
			new int[49],
			new int[49],
			new int[49],
			new int[49]
		};
		this.est_ab = new int[][]
		{
			new int[49],
			new int[49],
			new int[49],
			new int[49]
		};
		this.ismenu = new bool[2];
		this.ismenu[0] = false;
		this.ismenu[1] = false;
		this.isboost = new bool[3];
		this.isboost[0] = false;
		this.isboost[1] = false;
		this.isboost[2] = false;
		this.iscboost = false;
		this.gtw = new int[8];
		this.bslot = new int[4];
		this.cur = new int[3];
		this.work = new int[24];
		this.ep = 1;
		this.atkst = new int[4];
		for (int i = 0; i < 4; i++)
		{
			this.bslot[i] = i;
		}
		this.bmstr = new string[66];
		this.bmenu = new int[][]
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
			new int[2]
		};
		for (int i = 0; i < 66; i++)
		{
			this.bmstr[i] = string.Empty;
			for (int j = 0; j < 2; j++)
			{
				this.bmenu[i][j] = -1;
			}
		}
		this.chx = 40;
		this.chy = 48;
		this.chc = 0;
		this.chm = 0;
		this.chw = 0;
		this.SetEncountNum();
		this.eneapr = false;
		this.trap = 255;
		this.trapdmg = 255;
		this.trapdmgwait = 0;
		this.window_flg = false;
		this.window_cnt = 0;
		this.bimg = new Image[70];
		this.faceimg = new Image[29];
		this.befmino = -1;
		this.battleno = 255;
		this.mmstr = new string[66];
		this.mmenu = new int[66];
		for (int i = 0; i < 66; i++)
		{
			this.mmstr[i] = string.Empty;
			this.mmenu[i] = 255;
		}
		this.itempc = new int[][]
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
			new int[2]
		};
		this.config = new int[4];
		for (int i = 0; i < 4; i++)
		{
			this.config[i] = 1;
		}
		this.config[2] = 0;
		this.config[0] = 2;
		this.mapno = 6;
		this.starxy = new int[][]
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
			new int[4]
		};
		this.bred = new bool[5];
		this.bredn = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			this.bred[i] = false;
			this.bredn[i] = false;
		}
		this.vib = new int[3];
		for (int i = 0; i < 3; i++)
		{
			this.vib[i] = 0;
		}
		this.dropitem = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.dropitemp = 0;
		this.nextmenup = 0;
		this.nextmenu = new int[4];
		this.visualno = 0;
		this.slxy = new int[4];
		this.slwk = new int[6];
		this.slf = 0;
		this.dwh = new int[2];
		this.dwk = new int[][]
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
			new int[2]
		};
		this.dflag = 0;
		this.pfflag = 0;
		this.plasf = 0;
		this.plasw = 0;
		this.plasxy = new int[4];
		for (int i = 0; i < 4; i++)
		{
			this.plasxy[i] = 0;
		}
		this.StatusInit();
		this.ranks = new int[4];
		this.ranks2 = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		this.branks = new int[4];
		for (int i = 0; i < 4; i++)
		{
			this.SetRanks(i, i);
			this.branks[i] = 255;
			this.ranks2[i][0] = 255;
			this.ranks2[i][1] = 255;
		}
		this.xscr = new XScript06(this);
		this.PartLasterWorkClear();
		this.bhelpno = new int[4];
		this.bhelpcur = new int[][]
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		for (int i = 0; i < 4; i++)
		{
			this.bhelpno[i] = -1;
			this.bhelpcur[i][0] = 0;
			this.bhelpcur[i][1] = 0;
		}
		this.mip = 225;
		try
		{
			this.bfadeimg = this.XcreateImage(this.GetWidth(), this.GetHeight());
			this.bfadeg = this.bfadeimg.GetGraphics();
		}
		catch (Exception ex)
		{
			string empty = string.Empty;
			Exception ex2 = ex;
			this.debugstr = empty + ((ex2 != null) ? ex2.ToString() : null);
		}
	}

	// Token: 0x06000B2A RID: 2858 RVA: 0x000E48AC File Offset: 0x000E2AAC
	public virtual void SoundInit()
	{
		this.audio_b = AudioPresenter.GetAudioPresenter(0);
		this.audio_s = AudioPresenter.GetAudioPresenter(1);
		this.bgm = new MediaSound[14];
		this.se = new MediaSound[19];
		this.audio_b.SetMediaListener(this);
		this.audio_s.SetMediaListener(this);
	}

	// Token: 0x06000B2B RID: 2859 RVA: 0x000E4903 File Offset: 0x000E2B03
	public virtual void SetBgm(int id)
	{
		this.nowbgm = id;
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x000E490C File Offset: 0x000E2B0C
	public virtual bool IsNowBgm(int id)
	{
		return this.nowbgm == id;
	}

	// Token: 0x06000B2D RID: 2861 RVA: 0x000E491A File Offset: 0x000E2B1A
	public virtual bool IsPlayBgm()
	{
		return this.playbgm != -1;
	}

	// Token: 0x06000B2E RID: 2862 RVA: 0x000E4928 File Offset: 0x000E2B28
	public virtual void SetSoundVol()
	{
		int num = (new int[] { 0, 50, 100 })[this.GetConfig(0)];
		this.audio_b.SetAttribute(4, num);
		this.audio_s.SetAttribute(4, num);
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x000E4968 File Offset: 0x000E2B68
	public virtual void SoundVolChange()
	{
		if ((this.id_edge & 32) != 0)
		{
			if (this.config[0] == 0)
			{
				if (this.Loop_se == 1)
				{
					this.PlaySound(1, 16, 0, 1);
				}
				else if (this.Loop_se == 2)
				{
					this.PlaySound(1, 17, 0, 1);
				}
			}
			else if (this.config[0] == 1)
			{
				int loop_se = this.Loop_se;
				this.StopSe();
				this.Loop_se = loop_se;
			}
			if (this.config[0] == 0)
			{
				this.config[0] = 2;
			}
			else
			{
				this.config[0]--;
			}
			this.SetSoundVol();
			this.SaveOptionData();
		}
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x000E4A0A File Offset: 0x000E2C0A
	public virtual void PlayBgm()
	{
		this.playbgm = this.nowbgm;
		this.PlaySound(0, 0);
	}

	// Token: 0x06000B31 RID: 2865 RVA: 0x000E4A20 File Offset: 0x000E2C20
	public virtual void PlaySe(int id)
	{
		if (id >= 19)
		{
			return;
		}
		this.playse = id;
		this.StopSe();
		if (this.xscr.sc_flg[79] == 1 && id == 16)
		{
			this.Loop_se = 1;
		}
		else if ((this.mapno == 6 || this.mapno == 5) && this.xscr.sc_flg[19] != 1 && id == 17)
		{
			this.Loop_se = 2;
		}
		if (id >= 15 && this.GetConfig(0) == 0)
		{
			return;
		}
		if (this.xscr.sc_flg[79] == 1 && id == 16)
		{
			this.PlaySound(1, id, 0, 1);
			return;
		}
		if ((this.mapno == 6 || this.mapno == 5) && this.xscr.sc_flg[19] != 1 && id == 17)
		{
			this.PlaySound(1, id, 0, 1);
			return;
		}
		this.PlaySound(1, id, 1, 1);
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x000E4AFB File Offset: 0x000E2CFB
	protected internal virtual void PlaySound(int flg, int id)
	{
		this.PlaySound(flg, id, 1, 1);
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x000E4B07 File Offset: 0x000E2D07
	protected internal virtual void PlaySound(int flg, int id, int loop)
	{
		this.PlaySound(flg, id, loop, 1);
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x000E4B14 File Offset: 0x000E2D14
	protected internal virtual void PlaySound(int flg, int id, int loop, int syncr)
	{
		int[] array = new int[] { 0, 50, 100 };
		try
		{
			int num = array[this.GetConfig(0)];
			if (flg == 0)
			{
				this.audio_b.SetSound(this.bgm[this.nowbgm]);
				this.audio_b.SetAttribute(4, num);
				this.audio_b.Play();
			}
			else
			{
				this.se_loop_flag = false;
				if (loop == 0)
				{
					this.se_loop_flag = true;
				}
				this.audio_s.SetSound(this.se[id]);
				this.audio_s.SetAttribute(4, num);
				this.audio_s.Play();
			}
		}
		catch (Exception ex)
		{
			string text = "playSound:";
			Exception ex2 = ex;
			this.debugstr = text + ((ex2 != null) ? ex2.ToString() : null);
		}
	}

	// Token: 0x06000B35 RID: 2869 RVA: 0x000E4BE0 File Offset: 0x000E2DE0
	public virtual void StopAllSound()
	{
		try
		{
			this.audio_b.Stop();
			this.audio_s.Stop();
			this.playbgm = -1;
			this.playse = -1;
			this.se_loop_flag = false;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x000E4C30 File Offset: 0x000E2E30
	protected internal virtual void StopSe()
	{
		try
		{
			this.Loop_se = 0;
			this.audio_s.Stop();
			this.se_loop_flag = false;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x000E4C6C File Offset: 0x000E2E6C
	public virtual int GetConfig(int no)
	{
		return this.config[no];
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x000E4C78 File Offset: 0x000E2E78
	public virtual void ResetConfig()
	{
		if (this.GetConfig(0) == 0)
		{
			if (this.IsPlayBgm())
			{
				this.SetSoundVol();
			}
		}
		else if (this.GetConfig(0) == 1)
		{
			if (this.IsPlayBgm())
			{
				this.SetSoundVol();
			}
		}
		else if (this.IsPlayBgm())
		{
			this.SetSoundVol();
		}
		if (this.GetConfig(3) == 0)
		{
			this.SetBackLight(false);
		}
		else
		{
			this.SetBackLight(true);
		}
		if (this.GetConfig(1) == 0)
		{
			this.StopVib();
		}
	}

	// Token: 0x06000B39 RID: 2873 RVA: 0x000E4CEE File Offset: 0x000E2EEE
	public virtual void SetFont(StGraphics g, int flg)
	{
		if (flg == 0)
		{
			g.SetFont(this.sfont);
		}
		else
		{
			g.SetFont(this.lfont);
		}
		this.nowfont = flg;
	}

	// Token: 0x06000B3A RID: 2874 RVA: 0x000E4D14 File Offset: 0x000E2F14
	public virtual void SetColor(StGraphics g, int color)
	{
		g.SetColor(StGraphics.GetColorOfRGB((color >> 16) & 255, (color >> 8) & 255, color & 255));
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x000E4D3C File Offset: 0x000E2F3C
	public virtual void DrawImage(StGraphics g, Image img, int x, int y, int anc)
	{
		int num = x;
		if ((anc & 1) != 0)
		{
			num -= img.GetWidth() / 2;
		}
		g.DrawImage(img, num + this.qux, y + this.quy);
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x000E4D74 File Offset: 0x000E2F74
	public virtual void DrawRegion(StGraphics g, Image img, int sx, int sy, int w, int h, int tr, int dx, int dy, int anc)
	{
		if (tr != 0)
		{
			g.SetFlipMode(tr);
			g.DrawImage(img, dx + this.qux, dy + this.quy, sx, sy, w, h);
			g.SetFlipMode(0);
			return;
		}
		g.DrawImage(img, dx + this.qux, dy + this.quy, sx, sy, w, h);
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x000E4DD5 File Offset: 0x000E2FD5
	public virtual void DrawString(StGraphics g, string str, int x, int y, int anc)
	{
		this.DrawString(g, str, x, y, anc, true);
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x000E4DE8 File Offset: 0x000E2FE8
	public virtual void DrawString(StGraphics g, string str, int x, int y, int anc, bool ff)
	{
		int num = x;
		int num2 = y;
		g.SetPictoColorEnabled(true);
		int num5;
		int num6;
		if ((anc & 1) != 0)
		{
			int num3 = anc & -2;
			int length = str.Length;
			if (this.nowfont == 0)
			{
				int num4 = this.sfont.StringWidth(str);
				num5 = this.sfont.GetHeight();
				num6 = this.sfont.GetAscent();
				num = x - num4 / 2 - 3;
			}
			else
			{
				int num4 = this.lfont.StringWidth(str);
				num5 = this.lfont.GetHeight();
				num6 = this.lfont.GetAscent();
				num = x - num4 / 2 - 5;
			}
			if (ff)
			{
				num += this.qux;
				num2 += this.quy;
			}
			num2 += num5;
			num2 -= num5 - num6;
			g.DrawString(str, num, num2);
			return;
		}
		if ((anc & 2) != 0)
		{
			int num7 = anc & -3;
			int length2 = str.Length;
			if (this.nowfont == 0)
			{
				int num4 = this.sfont.StringWidth(str);
				num5 = this.sfont.GetHeight();
				num6 = this.sfont.GetAscent();
				num = x - num4 - 3;
			}
			else
			{
				int num4 = this.lfont.StringWidth(str);
				num5 = this.lfont.GetHeight();
				num6 = this.lfont.GetAscent();
				num = x - num4 - 5;
			}
			if (ff)
			{
				num += this.qux;
				num2 += this.quy;
			}
			num2 += num5;
			num2 -= num5 - num6;
			g.DrawString(str, num, num2);
			return;
		}
		if (this.nowfont == 0)
		{
			num5 = this.sfont.GetHeight();
			num6 = this.sfont.GetAscent();
		}
		else
		{
			num5 = this.lfont.GetHeight();
			num6 = this.lfont.GetAscent();
		}
		if (ff)
		{
			num += this.qux;
			num2 += this.quy;
		}
		num2 += num5;
		num2 -= num5 - num6;
		g.DrawString(str, num, num2);
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x000E4FB6 File Offset: 0x000E31B6
	public virtual void FillRect(StGraphics g, int x, int y, int w, int h)
	{
		g.FillRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x000E4FD2 File Offset: 0x000E31D2
	public virtual void FillRoundRect(StGraphics g, int x, int y, int w, int h, int aw, int ah)
	{
		g.FillRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x000E4FEE File Offset: 0x000E31EE
	public virtual void DrawRoundRect(StGraphics g, int x, int y, int w, int h, int aw, int ah)
	{
		g.DrawRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x000E500A File Offset: 0x000E320A
	public virtual void DrawLine(StGraphics g, int x1, int y1, int x2, int y2)
	{
		g.DrawLine(x1 + this.qux, y1 + this.quy, x2 + this.qux, y2 + this.quy);
	}

	// Token: 0x06000B43 RID: 2883 RVA: 0x000E5034 File Offset: 0x000E3234
	public virtual void FillArc(StGraphics g, int x, int y, int w, int h, int sa, int aa)
	{
		g.FillArc(x + this.qux, y + this.quy, w, h, sa, aa);
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x000E5054 File Offset: 0x000E3254
	public virtual void DrawArc(StGraphics g, int x, int y, int w, int h, int sa, int aa)
	{
		g.DrawArc(x + this.qux, y + this.quy, w, h, sa, aa);
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x000E5074 File Offset: 0x000E3274
	public virtual void DrawRect(StGraphics g, int x, int y, int w, int h)
	{
		g.DrawRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x000E5090 File Offset: 0x000E3290
	public virtual int GetRand(int min, int max)
	{
		int num = max - min + 1;
		int num2 = this.rand.Next() % num;
		if (num2 < 0)
		{
			num2 *= -1;
		}
		return num2 + min;
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x000E50C0 File Offset: 0x000E32C0
	public virtual void StarWorkInit()
	{
		for (int i = 0; i < 30; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				this.starxy[i][j] = 0;
			}
		}
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x000E50F4 File Offset: 0x000E32F4
	public virtual void EnemySet(int encp)
	{
		int num = this.EneEncP[encp];
		int num2;
		if (encp == 2)
		{
			num2 = this.battleno;
		}
		else
		{
			num2 = this.GetRand(0, 99);
		}
		int num3 = -1;
		int i;
		for (i = 0; i < num; i++)
		{
			if (num2 <= this.EneEncount[encp][i][0])
			{
				num3 = i;
				break;
			}
		}
		if (num3 == -1)
		{
			num3 = 0;
		}
		this.ep = 0;
		i = 0;
		while (i < 4 && this.EneEncount[encp][num3][1 + i * 3] != -1)
		{
			int num4 = this.EneEncount[encp][num3][1 + i * 3];
			this.SetEnemyStatus2(i, 0, num4);
			for (int j = 1; j < 32; j++)
			{
				this.SetEnemyStatus2(i, j, this.EneParam[num4][j - 1]);
			}
			this.SetEnemyStatus2(i, 32, this.EneEncount[encp][num3][2 + i * 3]);
			this.SetEnemyStatus2(i, 33, this.EneEncount[encp][num3][3 + i * 3]);
			this.SetEnemyStatus2(i, 34, 0);
			this.SetEnemyStatus2(i, 35, 0);
			this.SetEnemyStatus2(i, 36, 0);
			this.SetEnemyStatus2(i, 38, this.GetEnemyStatus2(i, 3));
			this.SetEnemyStatus2(i, 39, 0);
			this.ep++;
			i++;
		}
	}

	// Token: 0x06000B49 RID: 2889 RVA: 0x000E5234 File Offset: 0x000E3434
	public virtual void StatusInit()
	{
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 26; j++)
			{
				this.SetStatus(i, j, 0);
			}
			this.SetStatus(i, 21, 255);
			this.SetStatus(i, 22, 255);
		}
		this.SetStatus(3, 20, 1);
		for (int i = 0; i < 4; i++)
		{
			this.SetLevelStatus(i, 26);
			for (int k = 0; k < this.status[i][0] + 1; k++)
			{
				this.status[i][14] += this.PlyNextLevel[i][k];
			}
			this.SetStatus(i, 2, this.GetStatus(i, 3));
			this.SetStatus(i, 4, this.GetStatus(i, 5));
		}
		for (int i = 0; i < 66; i++)
		{
			this.itempc[i][0] = 0;
			this.itempc[i][1] = 0;
		}
		this.AddItem(22, 1);
		this.AddItem(28, 1);
		this.AddItem(36, 1);
		this.AddItem(43, 1);
		this.AddItem(55, 1);
		this.AddItem(58, 1);
		this.AddItem(54, 1);
		this.AddItem(56, 1);
		this.AddItem(0, 15);
		this.AddItem(1, 15);
		this.AddItem(4, 15);
		this.AddItem(5, 15);
		this.AddItem(9, 5);
		this.AddItem(11, 5);
		this.AddItem(15, 10);
		this.AddItem(16, 5);
		this.SetEquip(0, 21, 22);
		this.SetEquip(1, 21, 28);
		this.SetEquip(2, 21, 36);
		this.SetEquip(3, 21, 43);
		this.SetEquip(0, 22, 55);
		this.SetEquip(1, 22, 58);
		this.SetEquip(2, 22, 54);
		this.SetEquip(3, 22, 56);
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x000E5400 File Offset: 0x000E3600
	public virtual void GameDataClear()
	{
		this.StatusInit();
		this.StatusAbnormalInit();
		this.xscr.ScFlagClear();
		this.rev_mapno = 65535;
		this.rev_mapx = 65535;
		this.rev_mapy = 65535;
		this.rev_chx = 65535;
		this.rev_chy = 65535;
		this.befmo = -1;
		this.mcimgmax = -1;
		this.mcimg = null;
		this.eneimg = null;
		this.bbgimg = null;
		this.vimg = null;
		this.logoimg = null;
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x000E548C File Offset: 0x000E368C
	public virtual void StatusAbnormalInit()
	{
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 49; j++)
			{
				this.CancelStatusAbnormal(i, j);
				this.CancelStatusAbnormal(i + 4, j);
			}
		}
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x000E54C4 File Offset: 0x000E36C4
	public virtual void SetLevelStatus(int id, int level)
	{
		this.SetStatus(id, 0, level);
		this.SetStatus(id, 1, this.PlyParam[id][level][0]);
		this.SetStatus(id, 3, this.PlyParam[id][level][1]);
		this.SetStatus(id, 5, this.PlyParam[id][level][2]);
		this.SetStatus(id, 7, this.PlyParam[id][level][3]);
		this.SetStatus(id, 8, this.PlyParam[id][level][4]);
		this.SetStatus(id, 9, this.PlyParam[id][level][5]);
		this.SetStatus(id, 10, this.PlyParam[id][level][6]);
		this.SetStatus(id, 11, this.PlyParam[id][level][7]);
		this.SetStatus(id, 12, this.PlyParam[id][level][8]);
		this.SetStatus(id, 13, this.PlyParam[id][level][9]);
		if (level >= 59)
		{
			this.SetStatus(id, 15, 99999);
			return;
		}
		this.SetStatus(id, 15, this.PlyNextLevel[id][level + 1]);
	}

	// Token: 0x06000B4D RID: 2893 RVA: 0x000E55D4 File Offset: 0x000E37D4
	public virtual void PlayerStatusMax()
	{
		for (int i = 0; i < 4; i++)
		{
			this.SetStatus(i, 2, this.status[i][3]);
			this.SetStatus(i, 4, this.status[i][5]);
			this.SetStatus(i, 19, 0);
		}
	}

	// Token: 0x06000B4E RID: 2894 RVA: 0x000E561B File Offset: 0x000E381B
	public virtual void AddItem(int id, int piece)
	{
		if (id >= 66)
		{
			return;
		}
		this.itempc[id][0] += piece;
		if (this.itempc[id][0] > 99)
		{
			this.itempc[id][0] = 99;
		}
	}

	// Token: 0x06000B4F RID: 2895 RVA: 0x000E5650 File Offset: 0x000E3850
	public virtual void DelItem(int id, int piece)
	{
		if (id >= 66)
		{
			return;
		}
		this.itempc[id][0] -= piece;
		if (this.itempc[id][0] <= 0)
		{
			this.itempc[id][0] = 0;
		}
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x000E5684 File Offset: 0x000E3884
	public virtual void Game_paint(StGraphics g, bool flg)
	{
		lock (this)
		{
			bool flag2 = true;
			StGraphics stGraphics = g;
			if (this.plasf != 0)
			{
				stGraphics = this.bfadeg;
				this.SetFont(stGraphics, 0);
				stGraphics.SetClip(0, 0, 240, 240);
				this.red = true;
				this.sysred = true;
				this.compred = true;
			}
			if (this.lasf != 0 && this.lasw == 100 && this.battle_fade == 2)
			{
				StGraphics stGraphics2 = this.bfadeg;
				lock (stGraphics2)
				{
					stGraphics = this.bfadeg;
					this.SetFont(stGraphics, 0);
					stGraphics.SetClip(0, 0, 240, 260);
					this.red = true;
					this.sysred = true;
					this.compred = true;
					this.DrawMapScreen(stGraphics);
				}
			}
			if (this.lasf == 0)
			{
				int seqNo = this.GetSeqNo();
				if (seqNo == 3)
				{
					this.DrawBattleScreen(stGraphics);
				}
				else if (seqNo == 1)
				{
					this.DrawDataReadScreen(stGraphics);
				}
				else if (seqNo == 4)
				{
					this.DrawResultScreen(stGraphics);
				}
				else if (seqNo == 5)
				{
					this.DrawGameOverScreen(stGraphics);
				}
				else if (seqNo == 7)
				{
					this.DrawMapScreen(stGraphics);
				}
				else if (seqNo == 9)
				{
					this.DrawVisualScreen(stGraphics);
				}
				else if (seqNo == 11)
				{
					this.DrawTitleScreen(stGraphics);
				}
				else if (seqNo == 13)
				{
					this.DrawLogoScreen(stGraphics);
				}
				else if (seqNo == 14)
				{
					this.DrawContinueScreen(stGraphics);
				}
				else if (seqNo == 17)
				{
					this.DrawHelpScreen(stGraphics);
				}
				else if (seqNo == 19)
				{
					this.DrawClearLoadScreen(stGraphics);
				}
				else if (seqNo == 21)
				{
					this.DrawStaffRollScreen(stGraphics);
				}
				else if (seqNo == 23)
				{
					this.DrawUserCheck(stGraphics);
				}
			}
			if (this.plasf != 0 && flag2)
			{
				g.DrawImage(this.bfadeimg, 0, 0);
			}
			if (flg)
			{
				this.DrawSpLaser(g);
				this.DrawPartLaster(g);
				this.DrawPngFadeEffect(g);
				this.DrawBattleIn(g);
				this.DrawFade(g);
			}
			this.DrawDebug(g);
			this.sysred = false;
		}
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x000E58B4 File Offset: 0x000E3AB4
	public virtual void DrawDebug(StGraphics g)
	{
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x000E58B8 File Offset: 0x000E3AB8
	public virtual void DrawDataReadScreen(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		int seqStep = this.GetSeqStep();
		if (seqStep == 1)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "データチェック中", 12, 72, 0);
			return;
		}
		if (seqStep == 2)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "データダウンロード中", 12, 72, 0);
			int num = this.work[1];
			int num2 = this.work[2];
			int num3;
			if (num2 == 0)
			{
				num3 = 216;
			}
			else
			{
				num3 = num * 100 / num2 * 216 / 100;
			}
			this.SetColor(g, 4243696);
			this.FillRoundRect(g, 12, 86, num3, 14, 8, 8);
			this.SetColor(g, 16777215);
			this.DrawRoundRect(g, 11, 85, 218, 16, 8, 8);
			this.DrawRoundRect(g, 12, 86, 216, 14, 8, 8);
			return;
		}
		if (seqStep == 9)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "データ展開中", 12, 72, 0);
			int num = this.work[3];
			int num2 = this.work[4];
			int num3;
			if (num2 == 0)
			{
				num3 = 216;
			}
			else
			{
				num3 = num * 100 / num2 * 216 / 100;
			}
			this.SetColor(g, 4243696);
			this.FillRoundRect(g, 12, 86, num3, 14, 8, 8);
			this.SetColor(g, 16777215);
			this.DrawRoundRect(g, 11, 85, 218, 16, 8, 8);
			this.DrawRoundRect(g, 12, 86, 216, 14, 8, 8);
			return;
		}
		if (seqStep == 10)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "データ展開中", 12, 72, 0);
			return;
		}
		if (seqStep == 3)
		{
			this.SetColor(g, 16777215);
			int num3 = 120;
			this.DrawString(g, "ダウンロードに失敗しました。", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "アプリの通信設定を許可し、", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "なるべく電波状況の良い場所で", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "通信してください。", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "リトライしますか？", 20, num3, 0);
			return;
		}
		if (seqStep == 4)
		{
			this.SetColor(g, 16777215);
			int num3 = 120;
			this.DrawString(g, "ダウンロードに失敗しました。", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "アプリを終了して", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "ネットワーク設定を許可しない設定に", 20, num3, 0);
			num3 += 14;
			this.DrawString(g, "なっていないか確認して下さい。", 20, num3, 0);
		}
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x000E5B50 File Offset: 0x000E3D50
	public virtual void DrawBattleScreen(StGraphics g)
	{
		int seqStep = this.GetSeqStep();
		this.DrawBattleStatus(g);
		this.DrawBattleEnemyArea(g);
		this.DrawBattleGtw(g);
		if (this.seq_no == this.seq_no_b)
		{
			switch (seqStep)
			{
			case 3:
			case 4:
				this.DrawBattleMenu(g);
				goto IL_0122;
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
				this.DrawBattleMenu(g);
				goto IL_0122;
			case 13:
				this.DrawBattleRootMenu(g);
				goto IL_0122;
			case 14:
				this.DrawBattleEtherMenu(g);
				goto IL_0122;
			case 15:
			case 16:
			case 18:
			case 19:
			case 20:
			case 21:
			case 35:
			case 36:
			case 38:
				this.DrawBattleEtherMenu2(g);
				goto IL_0122;
			case 22:
				this.DrawBattleItemMenu(g);
				goto IL_0122;
			case 26:
			case 34:
			case 37:
				this.DrawBattleItemMenu2(g);
				goto IL_0122;
			case 27:
			case 28:
			case 29:
			case 41:
				this.DrawBattleEnemyMenu(g);
				goto IL_0122;
			}
			this.DrawBattleMenuClear(g);
		}
		IL_0122:
		if (seqStep == 6 && this.work[1] < 32)
		{
			this.DrawBattleSpAttack(g);
			this.DrawBattleSpName(g);
		}
		if (seqStep == 42 && this.work[8] != 65535)
		{
			this.DrawBattleScrollIcon(g);
		}
		if (seqStep == 15)
		{
			this.DrawBattleEtherName(g);
		}
		if (seqStep == 16 || seqStep == 24)
		{
			this.DrawBattleEtherEffect(g);
		}
		if (seqStep == 23)
		{
			this.DrawBattleItemName(g);
		}
		if (seqStep == 33)
		{
			this.DrawBattleGoodbye(g);
		}
		if (seqStep == 34 || seqStep == 35)
		{
			this.DrawBattleNoGoodbye(g);
		}
		if (seqStep == 36)
		{
			this.DrawBattleNoEtherExec(g);
		}
		if (seqStep == 37 || seqStep == 38)
		{
			this.DrawBattleNoEffect(g);
		}
		if (seqStep == 17 && this.work[8] != 65535)
		{
			this.DrawBattleScrollIcon(g);
		}
		if (seqStep == 18)
		{
			this.DrawBattleAnalyze(g);
		}
		if (seqStep == 19)
		{
			this.DrawBattlePsychoPocket(g);
		}
		if (seqStep == 20)
		{
			this.DrawBattleEtherAtk(g);
		}
		if (seqStep == 7 && seqStep == this.seq_step_b)
		{
			this.DrawBattleSpAttackEffect(g);
		}
		if (seqStep == 32)
		{
			if (this.work[5] == 0 && this.work[8] != 65535)
			{
				this.DrawBattleScrollIcon(g);
			}
			else if (this.work[5] == 1)
			{
				int num = this.GetEnemyStatus(this.GetGtw(0) - 4, 32);
				int num2 = this.GetEnemyStatus(this.GetGtw(0) - 4, 33) - 10;
				if (this.GetEnemyStatus(this.GetGtw(0) - 4, 2) == 0)
				{
					num2 -= 24;
				}
				else if (this.GetEnemyStatus(this.GetGtw(0) - 4, 2) == 1)
				{
					num2 -= 32;
				}
				else if (this.GetEnemyStatus(this.GetGtw(0) - 4, 2) == 2)
				{
					num2 -= 32;
				}
				if (this.work[1] < 4)
				{
					this.DrawNumSprBig(g, this.work[6], num, num2 - this.work[1], 3, 1, false, 4);
				}
				else if (this.work[1] < 8)
				{
					this.DrawNumSprBig(g, this.work[6], num, num2 - 3 + this.work[1] - 4, 3, 1, false, 4);
				}
				else
				{
					this.DrawNumSprBig(g, this.work[6], num, num2, 3, 1, false, 4);
				}
			}
		}
		if (this.seq_step == this.seq_step_b)
		{
			if (seqStep == 4)
			{
				int num = this.GetEnemyStatus(this.cur[1], 32) - 4;
				int num2 = this.GetEnemyStatus(this.cur[1], 33) - 20;
				if (this.GetEnemyStatus(this.cur[1], 2) == 0)
				{
					num2 -= 48;
				}
				else if (this.GetEnemyStatus(this.cur[1], 2) == 1)
				{
					num2 -= 64;
				}
				else if (this.GetEnemyStatus(this.cur[1], 2) == 2)
				{
					num2 -= 64;
				}
				this.DrawImage(g, this.sysimg[58], num, num2 + this.sync % 8 / 2, 0);
			}
			else if (seqStep == 8 || seqStep == 46)
			{
				this.DrawBattleAttackEffect(g);
			}
			else if (seqStep == 9 || seqStep == 41 || seqStep == 43)
			{
				if (this.work[0] != 65535)
				{
					this.DrawBattleAttackDmg(g);
				}
				else
				{
					this.DrawBattleAllAttackDmg(g);
				}
			}
			else if (seqStep == 29 || seqStep == 31 || seqStep == 45)
			{
				if (this.work[0] == 65535)
				{
					for (int i = 0; i < 4; i++)
					{
						int num3 = this.GetRanks(i);
						if (num3 != 255 && this.GetStatus(num3, 19) == 0 && this.GetStatus(num3, 20) == 0)
						{
							if (this.work[1] < 4)
							{
								this.DrawNumSprBig(g, this.work[10 + num3], 16 + i * 80, 76 - this.work[1], 1, 1, false, 4);
								if (this.atkst[num3] == 2)
								{
									this.DrawImage(g, this.sysimg[53], i * 80, 76 - this.work[1] - 8, 0);
								}
								else if (this.atkst[num3] == 4)
								{
									this.DrawImage(g, this.sysimg[56], 8 + i * 80, 76 - this.work[1] - 8, 0);
								}
							}
							else if (this.work[1] < 8)
							{
								this.DrawNumSprBig(g, this.work[10 + num3], 16 + i * 80, 73 + this.work[1] - 4, 1, 1, false, 4);
								if (this.atkst[num3] == 2)
								{
									this.DrawImage(g, this.sysimg[53], i * 80, 73 + this.work[1] - 4 - 8, 0);
								}
								else if (this.atkst[num3] == 4)
								{
									this.DrawImage(g, this.sysimg[56], 8 + i * 80, 73 + this.work[1] - 4 - 8, 0);
								}
							}
							else
							{
								this.DrawNumSprBig(g, this.work[10 + num3], 16 + i * 80, 76, 1, 1, false, 4);
								if (this.atkst[num3] == 2)
								{
									this.DrawImage(g, this.sysimg[53], i * 80, 68, 0);
								}
								else if (this.atkst[num3] == 4)
								{
									this.DrawImage(g, this.sysimg[56], 8 + i * 80, 68, 0);
								}
							}
						}
					}
				}
				else
				{
					int num = 0;
					for (int i = 0; i < 4; i++)
					{
						int num3 = this.GetRanks(i);
						if (num3 != 255)
						{
							if (this.cur[1] == num3)
							{
								break;
							}
							num++;
						}
					}
					if (this.atkst[this.cur[1]] == 3)
					{
						if (this.work[1] < 4)
						{
							this.DrawImage(g, this.sysimg[55], 16 + num * 80, 76 - this.work[1], 1);
						}
						else if (this.work[1] < 8)
						{
							this.DrawImage(g, this.sysimg[55], 16 + num * 80, 73 + this.work[1] - 4, 1);
						}
						else
						{
							this.DrawImage(g, this.sysimg[55], 16 + num * 80, 76, 1);
						}
					}
					else if (this.work[1] < 4)
					{
						this.DrawNumSprBig(g, this.work[0], 16 + num * 80, 76 - this.work[1], 1, 1, false, 4);
						if (this.atkst[this.cur[1]] == 2)
						{
							this.DrawImage(g, this.sysimg[53], num * 80, 76 - this.work[1] - 8, 0);
						}
						else if (this.atkst[this.cur[1]] == 4)
						{
							this.DrawImage(g, this.sysimg[56], 8 + num * 80, 76 - this.work[1] - 8, 0);
						}
					}
					else if (this.work[1] < 8)
					{
						this.DrawNumSprBig(g, this.work[0], 16 + num * 80, 73 + this.work[1] - 4, 1, 1, false, 4);
						if (this.atkst[this.cur[1]] == 2)
						{
							this.DrawImage(g, this.sysimg[53], num * 80, 73 + this.work[1] - 4 - 8, 0);
						}
						else if (this.atkst[this.cur[1]] == 4)
						{
							this.DrawImage(g, this.sysimg[56], 8 + num * 80, 73 + this.work[1] - 4 - 8, 0);
						}
					}
					else
					{
						this.DrawNumSprBig(g, this.work[0], 16 + num * 80, 76, 1, 1, false, 4);
						if (this.atkst[this.cur[1]] == 2)
						{
							this.DrawImage(g, this.sysimg[53], num * 80, 68, 0);
						}
						else if (this.atkst[this.cur[1]] == 4)
						{
							this.DrawImage(g, this.sysimg[56], 8 + num * 80, 68, 0);
						}
					}
				}
			}
			else if (seqStep == 21)
			{
				int j = this.GetPlyEtParam(this.work[2], this.work[3], 1);
				if (j != 5 && j != 1 && j != 3)
				{
					int num;
					int num2;
					if (this.cur[0] < 4)
					{
						int num3 = this.cur[0];
						num = num3 * 80 + 8;
						num2 = 10;
					}
					else
					{
						int num3 = this.cur[0] - 4;
						num = this.GetEnemyStatus(num3, 32) - 4;
						num2 = this.GetEnemyStatus(num3, 33) - 20;
						if (this.GetEnemyStatus(num3, 2) == 0)
						{
							num2 -= 48;
						}
						else if (this.GetEnemyStatus(num3, 2) == 1)
						{
							num2 -= 64;
						}
						else if (this.GetEnemyStatus(num3, 2) == 2)
						{
							num2 -= 64;
						}
					}
					this.DrawImage(g, this.sysimg[58], num, num2, 0);
				}
				else if (j == 1)
				{
					for (int i = 0; i < this.ep; i++)
					{
						if (this.GetEnemyStatus(i, 34) == 0)
						{
							int num = this.GetEnemyStatus(i, 32) - 4;
							int num2 = this.GetEnemyStatus(i, 33) - 20;
							if (this.GetEnemyStatus(i, 2) == 0)
							{
								num2 -= 48;
							}
							else if (this.GetEnemyStatus(i, 2) == 1)
							{
								num2 -= 64;
							}
							else if (this.GetEnemyStatus(i, 2) == 2)
							{
								num2 -= 64;
							}
							this.DrawImage(g, this.sysimg[58], num, num2, 0);
						}
					}
				}
				else if (j == 3)
				{
					int num2 = 20;
					int num3 = 0;
					for (int i = 0; i < 4; i++)
					{
						if (this.GetStatus(i, 20) == 0)
						{
							int num = num3 * 80 + 8;
							this.DrawImage(g, this.sysimg[58], num, num2, 0);
							num3++;
						}
					}
				}
			}
			else if (seqStep == 26)
			{
				int num;
				int num2;
				if (this.cur[0] < 4)
				{
					int num3 = this.cur[0];
					num = num3 * 80 + 8;
					num2 = 10;
				}
				else
				{
					int num3 = this.cur[0] - 4;
					num = this.GetEnemyStatus(num3, 32) - 4;
					num2 = this.GetEnemyStatus(num3, 33) - 20;
					if (this.GetEnemyStatus(num3, 2) == 0)
					{
						num2 -= 48;
					}
					else if (this.GetEnemyStatus(num3, 2) == 1)
					{
						num2 -= 64;
					}
					else if (this.GetEnemyStatus(num3, 2) == 2)
					{
						num2 -= 64;
					}
				}
				this.DrawImage(g, this.sysimg[58], num, num2, 0);
			}
			else if (seqStep == 25)
			{
				if (this.work[7] != 65535)
				{
					int num;
					int num2;
					if (this.work[4] < 4)
					{
						int num3 = 0;
						int j = 0;
						while (j < 4 && this.GetRanks(j) != this.work[4])
						{
							num3++;
							j++;
						}
						num = num3 * 80 + 16;
						num2 = 63;
					}
					else
					{
						int num3 = this.work[4] - 4;
						num = this.GetEnemyStatus(num3, 32) - 4;
						num2 = this.GetEnemyStatus(num3, 33) - 20;
						if (this.GetEnemyStatus(num3, 2) == 0)
						{
							num2 -= 24;
						}
						else if (this.GetEnemyStatus(num3, 2) == 1)
						{
							num2 -= 32;
						}
						else if (this.GetEnemyStatus(num3, 2) == 2)
						{
							num2 -= 32;
						}
					}
					if (this.work[1] < 4)
					{
						this.DrawNumSprBig(g, this.work[7], num, num2 + 3 - this.work[1], 3, 1, false, 4);
						if (this.work[3] == 8)
						{
							this.DrawNumSprBig(g, this.GetStatus(this.work[4], 5), num + 30, num2 + 3 - this.work[1], 3, 1, false, 4);
						}
					}
					else if (this.work[1] < 8)
					{
						this.DrawNumSprBig(g, this.work[7], num, num2 + this.work[1] - 4, 3, 1, false, 4);
						if (this.work[3] == 8)
						{
							this.DrawNumSprBig(g, this.GetStatus(this.work[4], 5), num + 30, num2 + this.work[1] - 4, 3, 1, false, 4);
						}
					}
					else
					{
						this.DrawNumSprBig(g, this.work[7], num, num2 + 3, 3, 1, false, 4);
						if (this.work[3] == 8)
						{
							this.DrawNumSprBig(g, this.GetStatus(this.work[4], 5), num + 30, num2 + 3, 3, 1, false, 4);
						}
					}
				}
			}
			else if (seqStep == 17)
			{
				if (this.work[7] != 65535)
				{
					int num4;
					if (this.GetPlyEtParam(this.work[2], this.work[3], 2) == 0)
					{
						num4 = 1;
					}
					else
					{
						num4 = 3;
					}
					int num;
					int num2;
					if (this.work[4] < 4)
					{
						int num3 = 0;
						int j = 0;
						while (j < 4 && this.GetRanks(j) != this.work[4])
						{
							num3++;
							j++;
						}
						num = num3 * 80 + 16;
						num2 = 63;
					}
					else
					{
						int num3 = this.work[4] - 4;
						num = this.GetEnemyStatus(num3, 32) - 4;
						num2 = this.GetEnemyStatus(num3, 33) - 20;
						if (this.GetEnemyStatus(num3, 2) == 0)
						{
							num2 -= 24;
						}
						else if (this.GetEnemyStatus(num3, 2) == 1)
						{
							num2 -= 32;
						}
						else if (this.GetEnemyStatus(num3, 2) == 2)
						{
							num2 -= 32;
						}
					}
					if (this.work[1] < 4)
					{
						this.DrawNumSprBig(g, this.work[7], num, num2 + 3 - this.work[1], num4, 1, false, 4);
					}
					else if (this.work[1] < 8)
					{
						this.DrawNumSprBig(g, this.work[7], num, num2 + this.work[1] - 4, num4, 1, false, 4);
					}
					else
					{
						this.DrawNumSprBig(g, this.work[7], num, num2 + 3, num4, 1, false, 4);
					}
				}
				else
				{
					int num3 = this.GetPlyEtParam(this.work[2], this.work[3], 3);
					int j = this.GetPlyEtParam(this.work[2], this.work[3], 1);
					if ((num3 == 26 || num3 == 27) && j == 3)
					{
						int num4 = 3;
						num3 = 0;
						for (j = 0; j < 4; j++)
						{
							int num5 = this.GetRanks(j);
							if (num5 != 255)
							{
								int num = num3 * 80 + 16;
								int num2 = 63;
								if (this.GetStatus(num5, 19) == 0 && this.GetStatus(num5, 20) == 0 && this.work[9 + num5] != 65535)
								{
									if (this.work[1] < 4)
									{
										this.DrawNumSprBig(g, this.work[9 + num5], num, num2 + 3 - this.work[1], num4, 1, false, 4);
									}
									else if (this.work[1] < 8)
									{
										this.DrawNumSprBig(g, this.work[9 + num5], num, num2 + this.work[1] - 4, num4, 1, false, 4);
									}
									else
									{
										this.DrawNumSprBig(g, this.work[9 + num5], num, num2 + 3, num4, 1, false, 4);
									}
								}
								num3++;
							}
						}
					}
				}
			}
		}
		if (this.isboost[1])
		{
			this.DrawImage(g, this.sysimg[57], 173, 220, 0);
		}
	}

	// Token: 0x06000B54 RID: 2900 RVA: 0x000E6B44 File Offset: 0x000E4D44
	public virtual void DrawBattleStatus(StGraphics g)
	{
		if (!this.bred[0] && !this.sysred)
		{
			return;
		}
		g.SetClip(0, 0, this.GetWidth(), 83);
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), 83);
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetRanks(i);
			if (num2 != 255 && this.GetStatus(num2, 20) == 0)
			{
				int num3 = 3 + num * 80;
				int num4 = 0;
				int num5;
				int j;
				if (this.GetGtw(0) == num2)
				{
					num5 = 14;
					j = 34;
				}
				else
				{
					num5 = 16;
					j = 33;
				}
				this.DrawImage(g, this.bimg[j], num3, num4 + num5, 0);
				this.DrawImage(g, this.bimg[1 + num2], 1 + num3, num4 + num5 + 10, 0);
				this.SetColor(g, 16777215);
				this.DrawString(g, this.PlyName[num2], 40 + num3, num4 + 2, 1);
				int num6 = this.GetStatus(num2, 2) * 100;
				int num7 = this.GetStatus(num2, 3);
				int num8 = 32 * (num6 / num7) / 100;
				this.SetColor(g, 255);
				this.DrawLine(g, num3 + 40, num4 + num5 + 16, num3 + 40 + num8, num4 + num5 + 16);
				this.DrawLine(g, num3 + 40, num4 + num5 + 21, num3 + 40 + num8, num4 + num5 + 21);
				this.SetColor(g, 8947967);
				this.FillRect(g, num3 + 40, num4 + num5 + 17, num8, 4);
				num6 = this.GetStatus(num2, 16) * 100;
				num7 = 100;
				num8 = 16 * (num6 / num7) / 100;
				this.SetColor(g, 16711680);
				this.DrawLine(g, num3 + 39, num4 + num5 + 48, num3 + 39 + num8, num4 + num5 + 48);
				this.DrawLine(g, num3 + 39, num4 + num5 + 51, num3 + 39 + num8, num4 + num5 + 51);
				this.SetColor(g, 16746632);
				this.FillRect(g, num3 + 39, num4 + num5 + 49, num8, 2);
				if (this.GetStatus(num2, 19) == 0)
				{
					this.DrawNumSpr(g, this.GetStatus(num2, 2), num3 + 47, num4 + num5 + 6, 0, 2, false, 4);
				}
				else
				{
					this.DrawNumSpr(g, this.GetStatus(num2, 2), num3 + 47, num4 + num5 + 6, 1, 2, false, 4);
				}
				this.DrawNumSpr(g, this.GetStatus(num2, 4), num3 + 27, num4 + num5 + 28, 0, 2, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 47, num4 + num5 + 28, 0, 2, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 17), num3 + 27, num4 + num5 + 54, 0, 2, false, 4);
				for (j = 0; j < this.GetStatus(num2, 6); j++)
				{
					this.DrawImage(g, this.sysimg[46], num3 + 37 + j * 6, num4 + num5 + 38, 0);
				}
				if (this.GetStatus(num2, 25) != 255)
				{
					int num9 = this.StIcon[this.GetStatus(num2, 25)];
					if (num9 != 255)
					{
						this.DrawImage(g, this.bimg[num9], num3 + 57, num4 + num5 + 47, 0);
					}
				}
				num++;
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B55 RID: 2901 RVA: 0x000E6EB4 File Offset: 0x000E50B4
	public virtual void DrawBattleSlot(StGraphics g)
	{
		this.DrawImage(g, this.bimg[40], 132, 185, 0);
		int num;
		if (this.bslotmove < 10)
		{
			num = this.bslot[(this.bslotno + 3) % 4];
			this.DrawImage(g, this.bimg[35 + num], 135, 228 + this.bslotmove, 0);
		}
		num = this.bslot[this.bslotno];
		this.DrawImage(g, this.bimg[35 + num], 135, 195 + this.bslotmove, 0);
		num = this.bslot[(this.bslotno + 1) % 4];
		this.DrawImage(g, this.bimg[35 + num], 135, 162 + this.bslotmove, 0);
		if (this.bslotmove > 10)
		{
			num = this.bslot[(this.bslotno + 2) % 4];
			this.DrawImage(g, this.bimg[35 + num], 135, 129 + this.bslotmove, 0);
		}
		this.SetColor(g, 0);
		this.FillRect(g, 135, 153, 16, 32);
		this.FillRect(g, 135, 238, 16, 2);
	}

	// Token: 0x06000B56 RID: 2902 RVA: 0x000E6FF8 File Offset: 0x000E51F8
	public virtual void DrawBattleEnemyArea(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		g.SetClip(0, 83, this.GetWidth(), 81);
		this.SetColor(g, 0);
		this.FillRect(g, -4, 83, this.GetWidth() + 4, 81);
		this.DrawImage(g, this.bbgimg, 0, 85, 0);
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) != 0 && (this.battleno == 0 || this.battleno == 1 || this.battleno == 11))
			{
				int num = this.GetEnemyStatus(i, 32);
				int num2 = this.GetEnemyStatus(i, 33) - 10;
				int num3 = this.GetEnemyStatus(i, 1);
				if (this.GetEnemyStatus(i, 2) == 0)
				{
					num -= 24;
					num2 -= 48;
				}
				else if (this.GetEnemyStatus(i, 2) == 1)
				{
					num -= 32;
					num2 -= 64;
				}
				else if (this.GetEnemyStatus(i, 2) == 2)
				{
					num -= 64;
					num2 -= 64;
				}
				this.DrawImage(g, this.eneimg[num3], num, num2, 0);
			}
			else if (this.GetEnemyStatus(i, 34) != 1)
			{
				int num = this.GetEnemyStatus(i, 32);
				int num2 = this.GetEnemyStatus(i, 33) - 10;
				int num4 = 48;
				int num3 = this.GetEnemyStatus(i, 1);
				if (this.GetEnemyStatus(i, 2) == 0)
				{
					num -= 24;
					num2 -= 48;
				}
				else if (this.GetEnemyStatus(i, 2) == 1)
				{
					num -= 32;
					num2 -= 64;
					num4 = 64;
				}
				else if (this.GetEnemyStatus(i, 2) == 2)
				{
					num -= 64;
					num2 -= 64;
					num4 = 128;
				}
				if ((this.GetSeqStep() == 9 || this.GetSeqStep() == 41 || this.GetSeqStep() == 43) && this.seq_step_b == this.seq_step)
				{
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					if (this.work[0] != 65535)
					{
						if (this.cur[1] == i)
						{
							num7 = 1;
						}
					}
					else if (this.GetEnemyStatus(i, 34) == 0)
					{
						num7 = 1;
					}
					if (num7 == 1 && this.work[1] < 16)
					{
						num5 = this.GetRand(-1, 1);
						num6 = this.GetRand(-1, 1);
					}
					this.DrawImage(g, this.eneimg[num3], num + num5, num2 + num6, 0);
				}
				else if (this.GetSeqStep() == 20 && this.seq_step_b == this.seq_step)
				{
					int num5 = 0;
					int num6 = 0;
					int num7 = this.GetPlyEtParam(this.work[2], this.work[3], 3);
					if (num7 == 47)
					{
						if (this.work[4] - 4 == i && this.work[1] < 16)
						{
							num5 = this.GetRand(-1, 1);
							num6 = this.GetRand(-1, 1);
						}
					}
					else if (num7 == 48 && this.work[1] < 16)
					{
						num5 = this.GetRand(-1, 1);
						num6 = this.GetRand(-1, 1);
					}
					this.DrawImage(g, this.eneimg[num3], num + num5, num2 + num6, 0);
				}
				else if (this.GetSeqStep() == 10 && this.GetEnemyStatus(i, 34) == 2)
				{
					int num8 = this.work[1] * (num4 / 16);
					this.DrawRegion(g, this.eneimg[num3], 0, num8, num4, num4 - num8, 0, num, num2 + num8, 0);
				}
				else
				{
					this.DrawImage(g, this.eneimg[num3], num, num2, 0);
				}
			}
		}
		if (this.GetSeqStep() == 27 && this.eneatk >= 48)
		{
			int num3 = this.eneatk - 48;
			this.SetColor(g, 8421504);
			this.FillRect(g, 0, 123, 240, 14);
			this.SetColor(g, 0);
			this.DrawString(g, this.EneSAtkName[num3], 120, 124, 1);
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B57 RID: 2903 RVA: 0x000E73C4 File Offset: 0x000E55C4
	public virtual void DrawBattleGtw(StGraphics g)
	{
		if (!this.bred[3])
		{
			return;
		}
		g.SetClip(130, 164, 110, 80);
		this.SetColor(g, 0);
		this.FillRect(g, 130, 164, 110, 80);
		this.DrawBattleSlot(g);
		this.DrawImage(g, this.bimg[0], 132, 165, 0);
		this.DrawImage(g, this.bimg[39], 132, 181, 0);
		this.DrawImage(g, this.bimg[41], 132, 238, 0);
		this.DrawImage(g, this.bimg[60], 157, 183, 0);
		for (int i = 0; i < this.gtwp; i++)
		{
			if (this.GetGtw(i) <= 3)
			{
				this.DrawImage(g, this.bimg[18 + this.GetGtw(i)], 154 + i * 20, 165, 0);
			}
			else
			{
				int num = this.GetEnemyStatus(this.GetGtw(i) - 4, 1);
				if (this.battleno >= 4 && this.battleno <= 9)
				{
					num += 3;
				}
				else if (this.battleno == 0 || this.battleno == 1 || this.battleno == 10 || this.battleno == 11)
				{
					num += 9;
				}
				this.DrawImage(g, this.bimg[5 + num], 154 + i * 20, 165, 0);
			}
		}
		if (!this.isboost[1] && this.isboost[0])
		{
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 20) == 0 && this.IsBoostEnable(num2))
				{
					if (i == 0)
					{
						this.DrawImage(g, this.bimg[18 + num2], 159, 221, 0);
						this.DrawImage(g, this.bimg[23], 177, 223, 0);
					}
					else if (i == 1)
					{
						this.DrawImage(g, this.bimg[18 + num2], 189, 185, 0);
						this.DrawImage(g, this.bimg[25], 191, 203, 0);
					}
					else if (i == 2)
					{
						this.DrawImage(g, this.bimg[18 + num2], 219, 221, 0);
						this.DrawImage(g, this.bimg[24], 206, 223, 0);
					}
				}
			}
		}
		else if (this.isboost[1])
		{
			if (this.boostno < 4)
			{
				this.DrawImage(g, this.bimg[18 + this.boostno], 189, 203, 0);
			}
			else
			{
				int num = this.GetEnemyStatus(this.boostno - 4, 1);
				if (this.battleno >= 4 && this.battleno <= 9)
				{
					num += 3;
				}
				else if (this.battleno == 0 || this.battleno == 1 || this.battleno == 10 || this.battleno == 11)
				{
					num += 9;
				}
				this.DrawImage(g, this.bimg[5 + num], 189, 203, 0);
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B58 RID: 2904 RVA: 0x000E7714 File Offset: 0x000E5914
	public virtual void DrawBattleEnemyMenu(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.SetColor(g, 0);
		this.FillRect(g, 0, 165, 130, 80);
		this.DrawImage(g, this.bimg[61], 0, 166, 0);
		this.SetColor(g, 16777215);
		this.DrawString(g, this.GetEneName(this.GetEnemyStatus(this.GetGtw(0) - 4, 0)), 8, 167, 0);
		this.SetColor(g, 74);
		this.FillRoundRect(g, 1, 183, 128, 55, 8, 8);
		this.SetColor(g, 204);
		this.DrawRoundRect(g, 1, 183, 128, 55, 8, 8);
		int num;
		int num2;
		string text;
		if (this.eneatk >= 48)
		{
			num = this.eneatk - 48;
			this.SetColor(g, 16777215);
			num2 = 187;
			text = "攻撃タイプ：" + this.GetEneSAtkExp(num, 0);
			this.DrawString(g, text, 8, num2, 0);
			num2 += 12;
			text = "攻撃対象\u3000：" + this.GetEneSAtkExp(num, 1);
			this.DrawString(g, text, 8, num2, 0);
			num2 += 12;
			text = "攻撃属性\u3000：" + this.GetEneSAtkExp(num, 2);
			this.DrawString(g, text, 8, num2, 0);
			num2 += 12;
			text = string.Empty + this.GetEneSAtkExp(num, 3);
			this.DrawString(g, text, 8, num2, 0);
			num2 += 12;
			return;
		}
		num = this.eneatk;
		this.SetColor(g, 16777215);
		num2 = 187;
		text = "攻撃タイプ：" + this.EneNAtkExp[num][0];
		this.DrawString(g, text, 8, num2, 0);
		num2 += 12;
		text = "攻撃対象\u3000：" + this.EneNAtkExp[num][1];
		this.DrawString(g, text, 8, num2, 0);
		num2 += 12;
		text = "攻撃属性\u3000：" + this.EneNAtkExp[num][2];
		this.DrawString(g, text, 8, num2, 0);
		num2 += 12;
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x000E7916 File Offset: 0x000E5B16
	public virtual void DrawBattleMenuClear(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.SetColor(g, 0);
		this.FillRect(g, 0, 164, 130, 80);
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x000E7948 File Offset: 0x000E5B48
	public virtual void DrawBattleMenu(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		if (this.GetGtw(0) <= 3 && this.IsStatusAbnormal(this.GetGtw(0), 22))
		{
			return;
		}
		if (this.bmenup <= 0 || this.nmwait == 0)
		{
			return;
		}
		if (this.nmwait > 0)
		{
			this.DrawBattleMenu2(g);
			return;
		}
		int num = this.GetGtw(0);
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetBMenu(i, 0);
			if (num2 != -1)
			{
				if (num2 == 128 || num2 == 144)
				{
					this.DrawImage(g, this.bimg[63], 0, 166 + i * 19, 0);
				}
				else if (num2 >= 16)
				{
					num2 -= 16;
					if (this.GetPlySAtkParam(num, num2, 0) == 0)
					{
						this.DrawImage(g, this.bimg[28], 0, 166 + i * 19, 0);
					}
					else
					{
						this.DrawImage(g, this.bimg[64], 0, 166 + i * 19, 0);
					}
				}
				else if (this.GetPlyNAtkParam(num, num2, 0) == 0)
				{
					this.DrawImage(g, this.bimg[28], 0, 166 + i * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[64], 0, 166 + i * 19, 0);
				}
			}
			if (this.cur[0] == i)
			{
				this.SetColor(g, 16777215);
			}
			else
			{
				this.SetColor(g, 8421504);
			}
			if (this.GetBMenu(i, 0) != -1)
			{
				this.DrawString(g, this.GetBMStr(i), 26, 169 + i * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[29 + this.GetBMenu(i, 1)], 1, 168 + i * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + i * 19, 16, 16);
			}
		}
	}

	// Token: 0x06000B5B RID: 2907 RVA: 0x000E7B3C File Offset: 0x000E5D3C
	public virtual void DrawBattleMenu2(StGraphics g)
	{
		int num = this.GetSeqStep();
		int num2 = this.cur[0];
		int num3 = this.GetGtw(0);
		num = this.GetBMenu(num2, 0);
		if (num != -1)
		{
			if (num >= 16)
			{
				num -= 16;
				if (this.GetPlySAtkParam(num3, num, 0) == 0)
				{
					this.DrawImage(g, this.bimg[28], 0, 166 + num2 * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[64], 0, 166 + num2 * 19, 0);
				}
			}
			else if (this.GetPlyNAtkParam(num3, num, 0) == 0)
			{
				this.DrawImage(g, this.bimg[28], 0, 166 + num2 * 19, 0);
			}
			else
			{
				this.DrawImage(g, this.bimg[64], 0, 166 + num2 * 19, 0);
			}
			this.SetColor(g, 16777215);
			if (this.GetBMenu(num2, 0) != -1)
			{
				this.DrawString(g, this.GetBMStr(num2), 26, 169 + num2 * 19, 0);
			}
			if (this.GetBMenu(num2, 1) != -1)
			{
				this.DrawImage(g, this.bimg[29 + this.GetBMenu(num2, 1)], 1, 168 + num2 * 19, 0);
				return;
			}
			this.SetColor(g, 0);
			this.FillRect(g, 0, 166 + num2 * 19, 16, 16);
		}
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x000E7C88 File Offset: 0x000E5E88
	public virtual void DrawBattleEtherMenu(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		for (int i = this.cur[2]; i < this.cur[2] + 4; i++)
		{
			if (this.cur[0] == i)
			{
				this.SetColor(g, 16777215);
			}
			else
			{
				this.SetColor(g, 8421504);
			}
			int num = this.GetBMenu(i, 0);
			if (num != -1)
			{
				if (num == 128)
				{
					this.DrawImage(g, this.bimg[63], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[28], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				this.DrawString(g, this.GetBMStr(i), 26, 169 + (i - this.cur[2]) * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[29 + this.GetBMenu(i, 1)], 1, 168 + (i - this.cur[2]) * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + (i - this.cur[2]) * 19, 16, 16);
			}
		}
		if (this.bmenup >= 5)
		{
			this.DrawImage(g, this.bimg[25], 1, 167, 0);
			this.DrawImage(g, this.bimg[22], 1, 227, 0);
		}
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x000E7E14 File Offset: 0x000E6014
	public virtual void DrawBattleEtherMenu2(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		int num = this.work[2];
		int num2 = this.work[3];
		this.DrawImage(g, this.bimg[28], 0, 166, 0);
		this.SetColor(g, 16777215);
		this.DrawString(g, this.GetPlyEtName(num, num2), 26, 169, 0);
		this.SetColor(g, 0);
		this.FillRect(g, 0, 166, 16, 16);
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x000E7EA0 File Offset: 0x000E60A0
	public virtual void DrawBattleItemMenu(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		for (int i = this.cur[2]; i < this.cur[2] + 4; i++)
		{
			if (this.cur[0] == i)
			{
				this.SetColor(g, 16777215);
			}
			else
			{
				this.SetColor(g, 8421504);
			}
			int num = this.GetBMenu(i, 0);
			if (num != -1)
			{
				if (num == 128)
				{
					this.DrawImage(g, this.bimg[63], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[28], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				this.DrawString(g, this.GetBMStr(i), 26, 169 + (i - this.cur[2]) * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[29 + this.GetBMenu(i, 1)], 1, 168 + (i - this.cur[2]) * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + (i - this.cur[2]) * 19, 16, 16);
			}
		}
		if (this.bmenup >= 5)
		{
			this.DrawImage(g, this.bimg[25], 1, 167, 0);
			this.DrawImage(g, this.bimg[22], 1, 227, 0);
		}
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x000E802C File Offset: 0x000E622C
	public virtual void DrawBattleItemMenu2(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		this.DrawImage(g, this.bimg[28], 0, 166, 0);
		this.SetColor(g, 16777215);
		this.DrawString(g, this.GetItemName(this.work[3], 0), 26, 169, 0);
		this.SetColor(g, 0);
		this.FillRect(g, 0, 166, 16, 16);
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x000E80B0 File Offset: 0x000E62B0
	public virtual void DrawBattleRootMenu(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		for (int i = 0; i < 4; i++)
		{
			if (!this.etheruse && i == 0)
			{
				this.SetColor(g, 4210752);
			}
			else if (this.cur[0] == i)
			{
				this.SetColor(g, 16777215);
			}
			else
			{
				this.SetColor(g, 8421504);
			}
			int num = this.GetBMenu(i, 0);
			if (num != -1)
			{
				if (num == 3)
				{
					this.DrawImage(g, this.bimg[63], 0, 166 + i * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[28], 0, 166 + i * 19, 0);
				}
				this.DrawString(g, this.GetBMStr(i), 26, 169 + i * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[29 + this.GetBMenu(i, 1)], 1, 168 + i * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + i * 19, 16, 16);
			}
		}
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x000E81E0 File Offset: 0x000E63E0
	public virtual void DrawBattleSpAttack(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		int num = 172 - (this.lfHeight + 1) - 34 - 6;
		if (this.work[1] <= 7)
		{
			if (this.work[1] == 1)
			{
				this.StarWorkInit();
			}
			this.SetColor(g, 4217080);
			this.FillRect(g, 0, num - this.work[1] * 3, this.work[1] * 30, this.work[1] * 6);
		}
		else
		{
			this.SetColor(g, 4217080);
			this.FillRect(g, 0, num - 24, 240, 60);
		}
		if (this.work[1] >= 8)
		{
			bool flag = false;
			for (int i = 0; i < 20; i++)
			{
				if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0 && !flag)
				{
					this.starxy[i][0] = -20;
					this.starxy[i][1] = num + this.GetRand(-24, 24);
					this.starxy[i][2] = 8 + this.GetRand(0, 15);
					this.starxy[i][3] = 1;
					flag = true;
				}
				else if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
				{
					this.starxy[i][0] += this.starxy[i][2];
					if (250 < this.starxy[i][0])
					{
						this.starxy[i][2] = (this.starxy[i][3] = 0);
					}
				}
				if (this.starxy[i][2] != 0 && this.starxy[i][3] != 0)
				{
					this.SetColor(g, 8454143);
					this.FillRect(g, this.starxy[i][0], this.starxy[i][1], 20, 1);
				}
			}
		}
		if (16 <= this.work[1] && this.work[1] <= 23)
		{
			this.DrawImage(g, this.bimg[66 + this.GetGtw(0)], (this.work[1] - 16) * 12 - 96, 49, 0);
			return;
		}
		if (24 <= this.work[1])
		{
			this.DrawImage(g, this.bimg[66 + this.GetGtw(0)], 0, 49, 0);
		}
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x000E8418 File Offset: 0x000E6618
	public virtual void DrawBattleSpName(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		int num = this.nowmenu - 16;
		this.SetFont(g, 1);
		int num2 = 162 - (this.lfHeight - 5);
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, num2 - 5, 240, this.lfHeight + 2);
		this.SetColor(g, 255);
		this.DrawString(g, this.GetPlySAtkName(this.GetGtw(0), num), 120, num2 - 4, 1);
		this.SetFont(g, 0);
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x000E84AC File Offset: 0x000E66AC
	public virtual void DrawBattleEtherName(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		int num = this.work[2];
		int num2 = this.work[3];
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 255);
		this.DrawString(g, this.GetPlyEtName(num, num2), 120, 124, 1);
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x000E851C File Offset: 0x000E671C
	public virtual void DrawBattleEtherEffect(StGraphics g)
	{
		if (this.GetSeqStep() == 16)
		{
			int plyEtParam = this.GetPlyEtParam(this.work[2], this.work[3], 3);
			if (plyEtParam == 44 || plyEtParam == 47 || plyEtParam == 48)
			{
				if (plyEtParam == 44)
				{
					this.DrawBattleEtherEffectAnalyze(g);
					return;
				}
				if (plyEtParam == 47)
				{
					this.DrawBattleEtherEffectAnalyze(g);
					return;
				}
				if (plyEtParam == 48)
				{
					this.DrawBattleEtherEffectAnalyze(g);
					return;
				}
			}
			else
			{
				if (this.work[6] == 2)
				{
					this.DrawBattleEtherEffectRecover(g);
					return;
				}
				if (this.work[6] == 1)
				{
					this.DrawBattleEtherEffectSupport(g);
					return;
				}
				if (this.work[6] == 0)
				{
					this.DrawBattleEtherEffectAttack(g);
					return;
				}
			}
		}
		else
		{
			if (this.work[6] == 2)
			{
				this.DrawBattleEtherEffectRecover(g);
				return;
			}
			if (this.work[6] == 1)
			{
				this.DrawBattleEtherEffectSupport(g);
				return;
			}
			if (this.work[6] == 0)
			{
				this.DrawBattleEtherEffectAttack(g);
			}
		}
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x000E85F4 File Offset: 0x000E67F4
	public virtual void DrawBattleEtherEffectAnalyze(StGraphics g)
	{
		int num = this.work[1];
		g.SetClip(0, 85, this.GetWidth(), 79);
		if (this.GetPlyEtParam(this.work[2], this.work[3], 3) == 48)
		{
			for (int i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0)
				{
					int num2 = this.GetEnemyStatus(i, 32);
					int num3 = this.GetEnemyStatus(i, 33) - 10;
					if (this.GetEnemyStatus(i, 2) == 0)
					{
						num3 -= 24;
					}
					else if (this.GetEnemyStatus(i, 2) == 1)
					{
						num3 -= 32;
					}
					else if (this.GetEnemyStatus(i, 2) == 2)
					{
						num3 -= 32;
					}
					if (num <= 8)
					{
						int num4 = (10 - num) * 4;
						this.SetColor(g, 16777215);
						this.DrawLine(g, num2 - num4 - 2, num3, num2 + num4 + 2, num3);
						this.DrawLine(g, num2, num3 - num4 - 2, num2, num3 + num4 + 2);
						this.DrawArc(g, num2 - num4 / 2, num3 - num4 / 2, num4, num4, 0, 360);
					}
					else if (num <= 14)
					{
						if (num == 9)
						{
							this.PlaySe(7);
						}
						int num4 = 8;
						this.SetColor(g, 16777215);
						this.DrawLine(g, num2 - num4 - 2, num3, num2 + num4 + 2, num3);
						this.DrawLine(g, num2, num3 - num4 - 2, num2, num3 + num4 + 2);
						this.DrawArc(g, num2 - num4 / 2, num3 - num4 / 2, num4, num4, 0, 360);
						this.SetColor(g, 16711680);
						this.FillArc(g, num2 - 1, num3 - 1, 2, 2, 0, 360);
					}
				}
			}
		}
		else
		{
			int i = this.work[4] - 4;
			int num2 = this.GetEnemyStatus(i, 32);
			int num3 = this.GetEnemyStatus(i, 33) - 10;
			if (this.GetEnemyStatus(i, 2) == 0)
			{
				num3 -= 24;
			}
			else if (this.GetEnemyStatus(i, 2) == 1)
			{
				num3 -= 32;
			}
			else if (this.GetEnemyStatus(i, 2) == 2)
			{
				num3 -= 32;
			}
			if (num <= 8)
			{
				int num4 = (10 - num) * 4;
				this.SetColor(g, 16777215);
				this.DrawLine(g, num2 - num4 - 2, num3, num2 + num4 + 2, num3);
				this.DrawLine(g, num2, num3 - num4 - 2, num2, num3 + num4 + 2);
				this.DrawArc(g, num2 - num4 / 2, num3 - num4 / 2, num4, num4, 0, 360);
			}
			else if (num <= 14)
			{
				if (num == 9)
				{
					this.PlaySe(7);
				}
				int num4 = 8;
				this.SetColor(g, 16777215);
				this.DrawLine(g, num2 - num4 - 2, num3, num2 + num4 + 2, num3);
				this.DrawLine(g, num2, num3 - num4 - 2, num2, num3 + num4 + 2);
				this.DrawArc(g, num2 - num4 / 2, num3 - num4 / 2, num4, num4, 0, 360);
				this.SetColor(g, 16711680);
				this.FillArc(g, num2 - 1, num3 - 1, 2, 2, 0, 360);
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x000E88F4 File Offset: 0x000E6AF4
	public virtual void DrawBattleEtherEffectAttack(StGraphics g)
	{
		int num = this.work[2];
		int i = this.work[3];
		int num2 = this.work[5];
		int num3 = this.work[6];
		g.SetClip(0, 85, this.GetWidth(), 79);
		this.SetColor(g, 16711680);
		if (num2 == 0)
		{
			i = this.work[4] - 4;
			int num4 = this.GetEnemyStatus(i, 32);
			int num5 = this.GetEnemyStatus(i, 33) - 10;
			if (this.GetEnemyStatus(i, 2) == 0)
			{
				num5 -= 24;
			}
			else if (this.GetEnemyStatus(i, 2) == 1)
			{
				num5 -= 32;
			}
			else if (this.GetEnemyStatus(i, 2) == 2)
			{
				num5 -= 32;
			}
			for (int j = 0; j < 6; j++)
			{
				int num6 = this.starxy[j][2] * 1137 / 100;
				int num7 = this.starxy[j][3];
				int num8 = Math3D.Cos(num6) * num7 / 4096;
				int num9 = Math3D.Sin(num6) * num7 / 4096;
				this.FillArc(g, num8 + num4 - 4, num9 + num5 - 4, 8, 8, 0, 360);
			}
		}
		else if (num2 == 1)
		{
			for (i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0)
				{
					int num4 = this.GetEnemyStatus(i, 32);
					int num5 = this.GetEnemyStatus(i, 33) - 10;
					if (this.GetEnemyStatus(i, 2) == 0)
					{
						num5 -= 24;
					}
					else if (this.GetEnemyStatus(i, 2) == 1)
					{
						num5 -= 32;
					}
					else if (this.GetEnemyStatus(i, 2) == 2)
					{
						num5 -= 32;
					}
					for (int j = 0; j < 6; j++)
					{
						int num10 = this.starxy[j][2] * 1137 / 100;
						int num7 = this.starxy[j][3];
						int num8 = Math3D.Cos(num10) * num7 / 4096;
						int num9 = Math3D.Sin(num10) * num7 / 4096;
						this.FillArc(g, num8 + num4 - 4, num9 + num5 - 4, 8, 8, 0, 360);
					}
				}
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x000E8B08 File Offset: 0x000E6D08
	public virtual void DrawBattleEtherEffectSupport(StGraphics g)
	{
		int num = this.work[2];
		int i = this.work[3];
		int num2 = this.work[5];
		int num3 = this.work[6];
		if (num2 == 0 || num2 == 2 || num2 == 7 || num2 == 6)
		{
			int num5;
			int num6;
			if (this.work[4] < 4)
			{
				i = 0;
				for (int j = 0; j < 4; j++)
				{
					int num4 = this.GetRanks(j);
					if (num4 != 255)
					{
						if (num4 == this.work[4])
						{
							break;
						}
						i++;
					}
				}
				num5 = i * 80 + 12;
				num6 = 63;
			}
			else
			{
				i = this.work[4] - 4;
				num5 = this.GetEnemyStatus(i, 32);
				num6 = this.GetEnemyStatus(i, 33) - 10;
			}
			this.DrawBattleEtherEffectSupportOne(g, num5, num6);
			return;
		}
		if (num2 == 1)
		{
			for (i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0)
				{
					int num5 = this.GetEnemyStatus(i, 32);
					int num6 = this.GetEnemyStatus(i, 33) - 10;
					this.DrawBattleEtherEffectSupportOne(g, num5, num6);
				}
			}
			return;
		}
		if (num2 == 3)
		{
			for (int j = 0; j < 4; j++)
			{
				int num4 = this.GetRanks(j);
				if (num4 != 255 && this.GetStatus(num4, 19) == 0 && this.GetStatus(num4, 20) == 0)
				{
					int num5 = j * 80 + 12;
					int num6 = 63;
					this.DrawBattleEtherEffectSupportOne(g, num5, num6);
				}
			}
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x000E8C54 File Offset: 0x000E6E54
	public virtual void DrawBattleEtherEffectSupportOne(StGraphics g, int x, int y)
	{
		g.SetClip(0, 0, this.GetWidth(), 180);
		this.SetColor(g, 49407);
		for (int i = 0; i < 16; i++)
		{
			if (this.starxy[i][3] != 0)
			{
				int num = this.starxy[i][0];
				int num2 = this.starxy[i][1];
				int num3 = this.starxy[i][2];
				if (num3 < 0)
				{
					num3 = 0;
				}
				this.DrawLine(g, x + num, y - num2, x + num, y - num3);
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x000E8CE8 File Offset: 0x000E6EE8
	public virtual void DrawBattleEtherEffectRecover(StGraphics g)
	{
		int num = this.work[2];
		int num2 = this.work[3];
		int num3 = this.work[5];
		int num4 = this.work[6];
		if (num3 == 0 || num3 == 2 || num3 == 7 || num3 == 6)
		{
			int num6;
			int num7;
			if (this.work[4] < 4)
			{
				num2 = 0;
				for (int i = 0; i < 4; i++)
				{
					int num5 = this.GetRanks(i);
					if (num5 != 255)
					{
						if (num5 == this.work[4])
						{
							break;
						}
						num2++;
					}
				}
				num6 = num2 * 80 + 12;
				num7 = 43;
			}
			else
			{
				num2 = this.work[4] - 4;
				num6 = this.GetEnemyStatus(num2, 32);
				num7 = this.GetEnemyStatus(num2, 33) - 30;
			}
			this.DrawBattleEtherEffectRecoverOne(g, num6, num7);
			return;
		}
		if (num3 == 1)
		{
			for (int j = 0; j < this.ep; j++)
			{
				if (this.GetEnemyStatus(j, 34) == 0)
				{
					int num6 = this.GetEnemyStatus(j, 32);
					int num7 = this.GetEnemyStatus(j, 33) - 30;
					this.DrawBattleEtherEffectRecoverOne(g, num6, num7);
				}
			}
			return;
		}
		if (num3 == 3)
		{
			int num7 = 43;
			for (int j = 0; j < 4; j++)
			{
				int num5 = this.GetRanks(j);
				if (num5 != 255 && this.GetStatus(num5, 19) == 0 && this.GetStatus(num5, 20) == 0)
				{
					int num6 = j * 80 + 12;
					this.DrawBattleEtherEffectRecoverOne(g, num6, num7);
				}
			}
		}
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x000E8E40 File Offset: 0x000E7040
	public virtual void DrawBattleEtherEffectRecoverOne(StGraphics g, int x, int y)
	{
		g.SetClip(0, 0, this.GetWidth(), 180);
		this.SetColor(g, 65280);
		for (int i = 0; i < 16; i++)
		{
			int num = this.starxy[i][0];
			if (num != 0)
			{
				int num2 = this.starxy[i][1] * 1137 / 100;
				int num3 = this.starxy[i][2];
				int num4 = Math3D.Cos(num2) * num / 4096;
				int num5 = Math3D.Sin(num2) * num / 4096;
				this.FillArc(g, num4 + x - num3 / 2, num5 + y - num3 / 2, num3, num3, 0, 360);
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x000E8EF8 File Offset: 0x000E70F8
	public virtual void DrawBattleGoodbye(StGraphics g)
	{
		this.SetColor(g, 16777215);
		for (int i = 0; i < 20; i++)
		{
			if (this.starxy[i][2] != 0 && this.starxy[i][3] != 0)
			{
				int num = this.starxy[i][2];
				this.FillArc(g, this.starxy[i][0] - num / 2, this.starxy[i][1] - 10, num, num, 0, 360);
			}
		}
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x000E8F6B File Offset: 0x000E716B
	public virtual void DrawBattleNoGoodbye(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 16711680);
		this.DrawString(g, "逃げられない！", 120, 124, 1);
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x000E8FA7 File Offset: 0x000E71A7
	public virtual void DrawBattleNoEtherExec(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 16711680);
		this.DrawString(g, "EPが足りない！", 120, 124, 1);
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x000E8FE3 File Offset: 0x000E71E3
	public virtual void DrawBattleNoEffect(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 16711680);
		this.DrawString(g, "使用しても効果がない。", 120, 124, 1);
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x000E9020 File Offset: 0x000E7220
	public virtual void DrawBattleScrollIcon(StGraphics g)
	{
		int num = this.IsIconUpDown(this.work[8]);
		int num3;
		int num4;
		if (this.work[4] == 255)
		{
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0)
				{
					num3 = i * 80 + 12;
					num4 = 63;
					if (this.work[8] != 70)
					{
						if (num == 0)
						{
							this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 16 - this.work[1], 0);
						}
						else
						{
							this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 32 + this.work[1], 0);
						}
					}
				}
			}
			return;
		}
		if (this.work[0] == 65535)
		{
			for (int j = 0; j < this.ep; j++)
			{
				if (this.GetEnemyStatus(j, 34) == 0 && this.work[4 + j] != 0)
				{
					num3 = this.GetEnemyStatus(j, 32) - 4;
					num4 = this.GetEnemyStatus(j, 33) - 20;
					if (num == 0)
					{
						this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 16 - this.work[1], 0);
					}
					else
					{
						this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 32 + this.work[1], 0);
					}
				}
			}
			return;
		}
		if (this.work[4] < 4)
		{
			int j = 0;
			for (int k = 0; k < 4; k++)
			{
				int num2 = this.GetRanks(k);
				if (num2 != 255 && this.work[4] == num2)
				{
					j = k;
					break;
				}
			}
			num3 = j * 80 + 12;
			num4 = 63;
		}
		else
		{
			int j = this.work[4] - 4;
			num3 = this.GetEnemyStatus(j, 32) - 4;
			num4 = this.GetEnemyStatus(j, 33) - 20;
		}
		if (this.work[8] != 70)
		{
			if (num == 0)
			{
				this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 16 - this.work[1], 0);
				return;
			}
			this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 32 + this.work[1], 0);
		}
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x000E9270 File Offset: 0x000E7470
	public virtual int IsIconUpDown(int no)
	{
		int num = 0;
		switch (no)
		{
		case 42:
		case 43:
		case 47:
		case 49:
		case 51:
		case 53:
		case 56:
			num = 0;
			break;
		case 44:
		case 45:
		case 46:
		case 48:
		case 50:
		case 52:
		case 54:
		case 55:
		case 57:
		case 58:
		case 59:
			num = 1;
			break;
		}
		return num;
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x000E92DC File Offset: 0x000E74DC
	public virtual void DrawBattleItemName(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		int num = this.work[3];
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 255);
		this.DrawString(g, this.GetItemName(num, 0), 120, 124, 1);
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x000E9344 File Offset: 0x000E7544
	public virtual void DrawBattlePsychoPocket(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		int num = this.work[9];
		string text;
		if (num == -1 || this.work[10] == -1)
		{
			text = "何も盗めなかった";
		}
		else
		{
			text = this.GetItemName(num, 0);
			text += "を盗んだ！";
		}
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 255);
		this.DrawString(g, text, 120, 124, 1);
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x000E93D4 File Offset: 0x000E75D4
	public virtual void DrawBattleAnalyze(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		int num = this.work[4] - 4;
		int num2 = this.GetEnemyStatus(num, 32) - 56;
		if (num2 < 0)
		{
			num2 = 0;
		}
		else if (num2 + 112 >= 240)
		{
			num2 = 127;
		}
		int num3 = 105;
		this.SetColor(g, 74);
		this.FillRoundRect(g, num2, num3, 112, 40, 8, 8);
		this.SetColor(g, 204);
		this.DrawRoundRect(g, num2, num3, 112, 40, 8, 8);
		num2 += 3;
		num3 += 2;
		this.SetColor(g, 16777215);
		this.DrawString(g, this.GetEneName(this.GetEnemyStatus(num, 0)), num2, num3, 0);
		num3 += 12;
		string text = "ＨＰ: " + this.GetEnemyStatus(num, 3).ToString() + " / " + this.GetEnemyStatus(num, 38).ToString();
		this.DrawString(g, text, num2, num3, 0);
		num3 += 12;
		text = "弱点: " + this.EneWeak[this.GetEnemyStatus(num, 19)];
		this.DrawString(g, text, num2, num3, 0);
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x000E94F4 File Offset: 0x000E76F4
	public virtual void DrawBattleEtherAtk(StGraphics g)
	{
		g.SetClip(0, 85, this.GetWidth(), 79);
		int i = this.GetPlyEtParam(this.work[2], this.work[3], 3);
		if (i == 48)
		{
			for (i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0 && this.work[9 + i] != 65535)
				{
					int num = this.GetEnemyStatus(i, 32);
					int num2 = this.GetEnemyStatus(i, 33) - 10;
					num -= 23;
					if (this.GetEnemyStatus(i, 2) == 0)
					{
						num2 -= 48;
					}
					else if (this.GetEnemyStatus(i, 2) == 1)
					{
						num2 -= 64;
					}
					else if (this.GetEnemyStatus(i, 2) == 2)
					{
						num2 -= 64;
					}
					num2 -= 4;
					if (this.work[1] >= 2 && this.work[1] < 16)
					{
						this.DrawImage(g, this.sysimg[47], num - 10, num2 - 10, 0);
					}
					if (this.work[1] >= 4 && this.work[1] < 16)
					{
						this.DrawImage(g, this.sysimg[47], num + 20, num2 - 20, 0);
					}
					if (this.work[1] >= 6 && this.work[1] < 16)
					{
						this.DrawImage(g, this.sysimg[47], num - 20, num2 + 20, 0);
					}
					if (this.work[1] >= 8 && this.work[1] < 16)
					{
						this.DrawImage(g, this.sysimg[47], num + 10, num2 + 10, 0);
					}
					if (this.work[1] == 2)
					{
						this.PlayEtherSe(this.GetPlyEtParam(this.work[2], this.work[3], 3));
					}
					else if (this.work[1] == 4)
					{
						this.PlayEtherSe(this.GetPlyEtParam(this.work[2], this.work[3], 3));
					}
					else if (this.work[1] == 6)
					{
						this.PlayEtherSe(this.GetPlyEtParam(this.work[2], this.work[3], 3));
					}
					else if (this.work[1] == 8)
					{
						this.PlayEtherSe(this.GetPlyEtParam(this.work[2], this.work[3], 3));
					}
					if (this.work[1] >= 16)
					{
						num = this.GetEnemyStatus(i, 32);
						num2 = this.GetEnemyStatus(i, 33) - 10;
						if (this.GetEnemyStatus(i, 2) == 0)
						{
							num2 -= 24;
						}
						else if (this.GetEnemyStatus(i, 2) == 1)
						{
							num2 -= 32;
						}
						else if (this.GetEnemyStatus(i, 2) == 2)
						{
							num2 -= 32;
						}
						if (this.work[1] < 20)
						{
							this.DrawNumSprBig(g, this.work[9 + i], num, num2 - (this.work[1] - 16), 0, 1, false, 4);
						}
						else if (this.work[1] < 24)
						{
							this.DrawNumSprBig(g, this.work[9 + i], num, num2 - 3 + (this.work[1] - 16) - 4, 0, 1, false, 4);
						}
						else
						{
							this.DrawNumSprBig(g, this.work[9 + i], num, num2, 0, 1, false, 4);
						}
					}
				}
			}
			return;
		}
		if (i == 47)
		{
			i = this.work[4] - 4;
			if (this.work[9] != 65535)
			{
				int num = this.GetEnemyStatus(i, 32);
				int num2 = this.GetEnemyStatus(i, 33) - 10;
				num -= 19;
				num2 -= 78;
				num2 -= 80;
				this.DrawImage(g, this.sysimg[51], num - 10, num2 + this.work[1] * 20 - 20, 0);
				this.DrawImage(g, this.sysimg[51], num + 10, num2 + this.work[1] * 20 - 20, 0);
				this.DrawImage(g, this.sysimg[51], num, num2 + this.work[1] * 20, 0);
				if (this.work[1] == 2)
				{
					this.PlayEtherSe(this.GetPlyEtParam(this.work[2], this.work[3], 3));
				}
				if (this.work[1] >= 16)
				{
					num = this.GetEnemyStatus(i, 32);
					num2 = this.GetEnemyStatus(i, 33) - 10;
					if (this.GetEnemyStatus(i, 2) == 0)
					{
						num2 -= 24;
					}
					else if (this.GetEnemyStatus(i, 2) == 1)
					{
						num2 -= 32;
					}
					else if (this.GetEnemyStatus(i, 2) == 2)
					{
						num2 -= 32;
					}
					if (this.work[1] < 20)
					{
						this.DrawNumSprBig(g, this.work[9], num, num2 - (this.work[1] - 16), 0, 1, false, 4);
						return;
					}
					if (this.work[1] < 24)
					{
						this.DrawNumSprBig(g, this.work[9], num, num2 - 3 + (this.work[1] - 16) - 4, 0, 1, false, 4);
						return;
					}
					this.DrawNumSprBig(g, this.work[9], num, num2, 0, 1, false, 4);
				}
			}
		}
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x000E99B0 File Offset: 0x000E7BB0
	public virtual void DrawBattleAttackEffect(StGraphics g)
	{
		g.SetClip(0, 95, this.GetWidth(), 85);
		int num = this.cur[1];
		int num2 = this.GetEnemyStatus(num, 32);
		int num3 = this.GetEnemyStatus(num, 33) - 10;
		if (this.attackef == 0)
		{
			num2 -= 23;
			if (this.GetEnemyStatus(num, 2) == 0)
			{
				num3 -= 48;
			}
			else if (this.GetEnemyStatus(num, 2) == 1)
			{
				num3 -= 64;
			}
			else if (this.GetEnemyStatus(num, 2) == 2)
			{
				num3 -= 64;
			}
			num3 -= 4;
			if (this.work[1] < 4)
			{
				this.DrawImage(g, this.sysimg[47], num2, num3, 0);
			}
		}
		else if (this.attackef == 1)
		{
			num2 -= 23;
			if (this.GetEnemyStatus(num, 2) == 0)
			{
				num3 -= 24;
			}
			else if (this.GetEnemyStatus(num, 2) == 1)
			{
				num3 -= 32;
			}
			else if (this.GetEnemyStatus(num, 2) == 2)
			{
				num3 -= 32;
			}
			num3 -= 24;
			if (this.work[1] < 4)
			{
				this.DrawImage(g, this.sysimg[48], num2, num3, 0);
			}
		}
		else if (this.attackef == 2)
		{
			num2 -= 19;
			num3 -= 78;
			num3 -= 80;
			this.DrawImage(g, this.sysimg[51], num2, num3 + this.work[1] * 20, 0);
		}
		else if (this.attackef == 3)
		{
			if (this.GetEnemyStatus(num, 2) == 0)
			{
				num3 -= 24;
			}
			else if (this.GetEnemyStatus(num, 2) == 1)
			{
				num3 -= 32;
			}
			else if (this.GetEnemyStatus(num, 2) == 2)
			{
				num3 -= 32;
			}
			num2 -= 24;
			num3 -= 24;
			int num4 = this.GetRand(-1, 1);
			num2 += num4;
			num4 = this.GetRand(-1, 1);
			num3 += num4;
			this.DrawImage(g, this.sysimg[52], num2, num3, 0);
		}
		else if (this.attackef == 4)
		{
			if (this.GetEnemyStatus(num, 2) == 0)
			{
				num3 -= 24;
			}
			else if (this.GetEnemyStatus(num, 2) == 1)
			{
				num3 -= 32;
			}
			else if (this.GetEnemyStatus(num, 2) == 2)
			{
				num3 -= 32;
			}
			num2 -= 24;
			num3 -= 24;
			this.DrawImage(g, this.sysimg[49], num2, num3, 0);
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x000E9BE4 File Offset: 0x000E7DE4
	public virtual void DrawBattleSpAttackEffect(StGraphics g)
	{
		g.SetClip(0, 85, this.GetWidth(), 95);
		int num = this.GetGtw(0);
		int num2 = this.nowmenu - 16;
		int plySAtkParam = this.GetPlySAtkParam(num, num2, 11);
		int num3 = this.cur[1];
		int num4 = this.work[1];
		switch (plySAtkParam)
		{
		case 0:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (this.GetEnemyStatus(num3, 2) == 0)
			{
				num6 -= 24;
			}
			else if (this.GetEnemyStatus(num3, 2) == 1)
			{
				num6 -= 32;
			}
			else if (this.GetEnemyStatus(num3, 2) == 2)
			{
				num6 -= 32;
			}
			if (num4 == 1)
			{
				this.PlaySe(9);
			}
			else if (num4 == 12)
			{
				this.PlaySe(16);
			}
			if (num4 <= 4)
			{
				num5 -= 23;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[48], num5, num6, 0);
			}
			else if (num4 <= 12)
			{
				num5 -= 24;
				num6 -= 24;
				int num7 = this.GetRand(-1, 1);
				num5 += num7;
				num7 = this.GetRand(-1, 1);
				num6 += num7;
				this.DrawImage(g, this.sysimg[52], num5, num6, 0);
			}
			break;
		}
		case 1:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (this.GetEnemyStatus(num3, 2) == 0)
			{
				num6 -= 24;
			}
			else if (this.GetEnemyStatus(num3, 2) == 1)
			{
				num6 -= 32;
			}
			else if (this.GetEnemyStatus(num3, 2) == 2)
			{
				num6 -= 32;
			}
			if (num4 < 4)
			{
				this.PlaySe(18);
			}
			else if (num4 == 4)
			{
				this.PlaySe(15);
			}
			if (num4 <= 4)
			{
				if (this.GetEnemyStatus(num3, 2) == 0)
				{
					num6 -= 24;
				}
				else if (this.GetEnemyStatus(num3, 2) == 1)
				{
					num6 -= 32;
				}
				else if (this.GetEnemyStatus(num3, 2) == 2)
				{
					num6 -= 32;
				}
				num5 -= 23;
				num6 -= 4;
				int num7 = this.GetRand(-2, 2);
				num5 += num7;
				num7 = this.GetRand(-2, 2);
				num6 += num7;
				this.DrawImage(g, this.sysimg[47], num5, num6, 0);
			}
			else if (num4 <= 8)
			{
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[49], num5, num6, 0);
			}
			break;
		}
		case 2:
			if (num4 <= 12)
			{
				this.qux = this.GetRand(0, 4);
				this.quy = this.GetRand(0, 4);
				if (num4 == 3 || num4 == 6 || num4 == 9)
				{
					this.PlaySe(17);
				}
			}
			else if (num4 == 13)
			{
				this.qux = 0;
				this.quy = 0;
			}
			break;
		case 3:
			if (num4 <= 8)
			{
				this.qux = this.GetRand(0, 2);
				this.quy = this.GetRand(0, 2);
				int i = (num4 - 1) / 2;
				if (i < this.ep && this.GetEnemyStatus(i, 34) == 0)
				{
					int num5 = this.GetEnemyStatus(i, 32);
					int num6 = this.GetEnemyStatus(i, 33) - 10;
					if (this.GetEnemyStatus(i, 2) == 0)
					{
						num6 -= 24;
					}
					else if (this.GetEnemyStatus(i, 2) == 1)
					{
						num6 -= 32;
					}
					else if (this.GetEnemyStatus(i, 2) == 2)
					{
						num6 -= 32;
					}
					num5 -= 24;
					num6 -= 24;
					this.DrawImage(g, this.sysimg[49], num5, num6, 0);
					if (num4 % 2 == 1)
					{
						this.PlaySe(15);
					}
				}
			}
			else if (num4 <= 9)
			{
				this.qux = 0;
				this.quy = 0;
			}
			break;
		case 4:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (num4 == 1)
			{
				this.PlaySe(10);
			}
			else if (num4 == 8)
			{
				this.PlaySe(17);
			}
			if (num4 <= 4)
			{
				num5 -= 19;
				num6 -= 78;
				num6 -= 80;
				this.DrawImage(g, this.sysimg[51], num5, num6 + num4 * 20, 0);
			}
			else if (num4 <= 8)
			{
				if (this.GetEnemyStatus(num3, 2) == 0)
				{
					num6 -= 24;
				}
				else if (this.GetEnemyStatus(num3, 2) == 1)
				{
					num6 -= 32;
				}
				else if (this.GetEnemyStatus(num3, 2) == 2)
				{
					num6 -= 32;
				}
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[49], num5, num6 + 8 - (num4 - 4), 0);
			}
			break;
		}
		case 5:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (this.GetEnemyStatus(num3, 2) == 0)
			{
				num6 -= 24;
			}
			else if (this.GetEnemyStatus(num3, 2) == 1)
			{
				num6 -= 32;
			}
			else if (this.GetEnemyStatus(num3, 2) == 2)
			{
				num6 -= 32;
			}
			if (num4 <= 8)
			{
				int num7 = (10 - num4) * 4;
				this.SetColor(g, 16777215);
				this.DrawLine(g, num5 - num7 - 4, num6, num5 + num7 + 4, num6);
				this.DrawLine(g, num5, num6 - num7 - 4, num5, num6 + num7 + 4);
				this.DrawRect(g, num5 - num7, num6 - num7, num7 * 2, num7 * 2);
			}
			else if (num4 <= 14)
			{
				if (num4 == 8 || num4 == 13)
				{
					this.PlaySe(15);
				}
				if (num4 != 11 && num4 != 12)
				{
					num5 -= 23;
					num6 -= 24;
					this.DrawImage(g, this.sysimg[47], num5, num6, 0);
				}
			}
			break;
		}
		case 6:
			if (num4 == 1 || num4 == 3 || num4 == 5)
			{
				this.PlaySe(18);
			}
			if (num4 <= 6)
			{
				int num5 = this.GetRand(60, 180);
				int num6 = this.GetRand(110, 140);
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[49], num5, num6, 0);
			}
			break;
		case 7:
			if (num4 == 3 || num4 == 6)
			{
				this.PlaySe(15);
			}
			if (num4 <= 4)
			{
				for (int i = 0; i < this.ep; i++)
				{
					if (this.GetEnemyStatus(i, 34) == 0)
					{
						int num5 = this.GetEnemyStatus(i, 32);
						int num6 = this.GetEnemyStatus(i, 33) - 10;
						if (this.GetEnemyStatus(num3, 2) == 0)
						{
							num6 -= 24;
						}
						else if (this.GetEnemyStatus(num3, 2) == 1)
						{
							num6 -= 32;
						}
						else if (this.GetEnemyStatus(num3, 2) == 2)
						{
							num6 -= 32;
						}
						num5 -= 24;
						num6 -= 24;
						this.DrawImage(g, this.sysimg[47], num5, num6, 0);
					}
				}
			}
			else if (num4 <= 8)
			{
				for (int i = 0; i < this.ep; i++)
				{
					if (this.GetEnemyStatus(i, 34) == 0)
					{
						int num5 = this.GetEnemyStatus(i, 32);
						int num6 = this.GetEnemyStatus(i, 33) - 10;
						if (this.GetEnemyStatus(num3, 2) == 0)
						{
							num6 -= 24;
						}
						else if (this.GetEnemyStatus(num3, 2) == 1)
						{
							num6 -= 32;
						}
						else if (this.GetEnemyStatus(num3, 2) == 2)
						{
							num6 -= 32;
						}
						num5 -= 24;
						num6 -= 24;
						this.DrawImage(g, this.sysimg[49], num5, num6, 0);
					}
				}
			}
			break;
		case 8:
		{
			if (num4 == 1 || num4 == 3)
			{
				this.PlaySe(16);
			}
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (this.GetEnemyStatus(num3, 2) == 0)
			{
				num6 -= 24;
			}
			else if (this.GetEnemyStatus(num3, 2) == 1)
			{
				num6 -= 32;
			}
			else if (this.GetEnemyStatus(num3, 2) == 2)
			{
				num6 -= 32;
			}
			if (num4 <= 4)
			{
				num5 -= 23;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[48], num5 - 8, num6, 0);
				this.DrawImage(g, this.sysimg[48], num5 + 8, num6, 0);
			}
			break;
		}
		case 9:
		{
			if (num4 == 1)
			{
				this.PlaySe(7);
			}
			else if (num4 == 15)
			{
				this.PlaySe(8);
			}
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (this.GetEnemyStatus(num3, 2) == 0)
			{
				num6 -= 24;
			}
			else if (this.GetEnemyStatus(num3, 2) == 1)
			{
				num6 -= 32;
			}
			else if (this.GetEnemyStatus(num3, 2) == 2)
			{
				num6 -= 32;
			}
			if (num4 <= 14)
			{
				this.SetColor(g, 16777215);
				int num7 = num4 * 4;
				if (num7 <= 40)
				{
					this.DrawArc(g, num5 - num7 / 2, num6 - num7 / 2, num7, num7, 0, 360);
				}
				num7 = (num4 - 2) * 4;
				if (0 < num7 && num7 <= 40)
				{
					this.DrawArc(g, num5 - num7 / 2, num6 - num7 / 2, num7, num7, 0, 360);
				}
				num7 = (num4 - 4) * 4;
				if (0 < num7 && num7 <= 40)
				{
					this.DrawArc(g, num5 - num7 / 2, num6 - num7 / 2, num7, num7, 0, 360);
				}
			}
			else if (num4 <= 19)
			{
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[47], num5, num6, 0);
			}
			break;
		}
		case 10:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (num4 == 1)
			{
				this.PlaySe(9);
			}
			else if (num4 == 16)
			{
				this.PlaySe(0);
			}
			if (num4 <= 6)
			{
				if (this.GetEnemyStatus(num3, 2) == 0)
				{
					num6 -= 24;
				}
				else if (this.GetEnemyStatus(num3, 2) == 1)
				{
					num6 -= 32;
				}
				else if (this.GetEnemyStatus(num3, 2) == 2)
				{
					num6 -= 32;
				}
				num5 -= 23;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[48], num5, num6, 0);
			}
			else if (num4 >= 16 && num4 <= 22)
			{
				num5 -= 24;
				num6 -= 48;
				this.DrawImage(g, this.sysimg[50], num5, num6, 0);
			}
			break;
		}
		case 11:
			if (num4 == 1)
			{
				this.PlaySe(11);
			}
			else if (num4 == 15)
			{
				this.PlaySe(17);
			}
			if (num4 <= 14)
			{
				int num7 = Math3D.Sin(num4 * 256) * 45 / 4096;
				if (num4 >= 5 && num4 <= 9)
				{
					num7 = 50;
				}
				else if (num4 >= 10)
				{
					num7 = Math3D.Sin((num4 - 6) * 256) * 45 / 4096;
				}
				this.FillRect(g, 0, 85, this.GetWidth(), num7);
				this.FillRect(g, 0, 165 - num7, this.GetWidth(), num7);
			}
			else if (num4 <= 18)
			{
				int num5 = this.GetEnemyStatus(num3, 32);
				int num6 = this.GetEnemyStatus(num3, 33) - 10;
				if (this.GetEnemyStatus(num3, 2) == 0)
				{
					num6 -= 24;
				}
				else if (this.GetEnemyStatus(num3, 2) == 1)
				{
					num6 -= 32;
				}
				else if (this.GetEnemyStatus(num3, 2) == 2)
				{
					num6 -= 32;
				}
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[47], num5, num6, 0);
			}
			break;
		case 12:
			if (num4 == 1 || num4 == 3 || num4 == 5)
			{
				this.PlaySe(18);
			}
			if (num4 <= 6)
			{
				int num5 = num4 * 30 + 30;
				int num6 = 130;
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[47], num5, num6, 0);
			}
			break;
		case 13:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (num4 == 1)
			{
				this.PlaySe(10);
			}
			if (num4 <= 8)
			{
				num5 -= 19;
				num6 -= 78;
				num6 -= 80;
				if (num4 <= 4)
				{
					this.DrawImage(g, this.sysimg[51], num5, num6 + num4 * 20, 0);
				}
				else
				{
					this.DrawImage(g, this.sysimg[51], num5, num6 + (num4 - 5) * 20, 0);
				}
			}
			else if (num4 <= 12)
			{
				if (this.GetEnemyStatus(num3, 2) == 0)
				{
					num6 -= 24;
				}
				else if (this.GetEnemyStatus(num3, 2) == 1)
				{
					num6 -= 32;
				}
				else if (this.GetEnemyStatus(num3, 2) == 2)
				{
					num6 -= 32;
				}
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[49], num5, num6 + 8 - (num4 - 8), 0);
			}
			break;
		}
		case 14:
		{
			int num5 = this.GetEnemyStatus(num3, 32);
			int num6 = this.GetEnemyStatus(num3, 33) - 10;
			if (this.GetEnemyStatus(num3, 2) == 0)
			{
				num6 -= 24;
			}
			else if (this.GetEnemyStatus(num3, 2) == 1)
			{
				num6 -= 32;
			}
			else if (this.GetEnemyStatus(num3, 2) == 2)
			{
				num6 -= 32;
			}
			if (num4 == 1)
			{
				this.PlaySe(7);
			}
			else if (num4 == 9)
			{
				this.PlaySe(17);
			}
			if (num4 <= 8)
			{
				this.SetColor(g, 16777215);
				for (int i = 0; i < 8; i++)
				{
					int num7 = (8 - num4) * 5;
					int num8 = Math3D.Cos(i * 512 + this.sync * 128) * num7 / 4096;
					int num9 = Math3D.Sin(i * 512 + this.sync * 128) * num7 / 4096;
					int num10 = Math3D.Cos(i * 512 + this.sync * 128) * (num7 + 5) / 4096;
					int num11 = Math3D.Sin(i * 512 + this.sync * 128) * (num7 + 5) / 4096;
					this.DrawLine(g, num8 + num5, num9 + num6, num10 + num5, num11 + num6);
					num8 = Math3D.Cos(i * 512 + this.sync * 128 - 64) * (num7 + 10) / 4096;
					num9 = Math3D.Sin(i * 512 + this.sync * 128 - 64) * (num7 + 10) / 4096;
					this.DrawLine(g, num10 + num5, num11 + num6, num8 + num5, num9 + num6);
				}
			}
			else if (num4 <= 12)
			{
				num5 -= 24;
				num6 -= 24;
				this.DrawImage(g, this.sysimg[47], num5, num6, 0);
			}
			break;
		}
		case 15:
			if (num4 == 1 || num4 == 4 || num4 == 7 || num4 == 11)
			{
				this.PlaySe(16);
			}
			if (num4 <= 14)
			{
				for (int i = 0; i < 6; i++)
				{
					if (i * 2 + 1 <= num4 && num4 <= i * 2 + 4)
					{
						int num5 = i * 30 + 30;
						int num6 = 160;
						num5 -= 19;
						num6 -= 78;
						num6 -= 80;
						int num7 = num4 - i * 2;
						this.DrawImage(g, this.sysimg[51], num5, num6 + num7 * 20, 0);
					}
				}
			}
			else if (num4 <= 18)
			{
				for (int i = 0; i < this.ep; i++)
				{
					if (this.GetEnemyStatus(i, 34) == 0)
					{
						int num5 = this.GetEnemyStatus(i, 32);
						int num6 = this.GetEnemyStatus(i, 33) - 10;
						if (this.GetEnemyStatus(i, 2) == 0)
						{
							num6 -= 24;
						}
						else if (this.GetEnemyStatus(i, 2) == 1)
						{
							num6 -= 32;
						}
						else if (this.GetEnemyStatus(i, 2) == 2)
						{
							num6 -= 32;
						}
						num5 -= 24;
						num6 -= 24;
						this.DrawImage(g, this.sysimg[49], num5, num6 + 8 - (num4 - 15), 0);
					}
				}
			}
			break;
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x000EAC40 File Offset: 0x000E8E40
	public virtual void DrawBattleAttackDmg(StGraphics g)
	{
		int num = this.work[1];
		if (num >= 16)
		{
			int num2 = this.work[0];
			int enemyStatus = this.GetEnemyStatus(this.cur[1], 32);
			int num3 = this.GetEnemyStatus(this.cur[1], 33) - 10;
			if (this.GetEnemyStatus(this.cur[1], 2) == 0)
			{
				num3 -= 24;
			}
			else if (this.GetEnemyStatus(this.cur[1], 2) == 1)
			{
				num3 -= 32;
			}
			else if (this.GetEnemyStatus(this.cur[1], 2) == 2)
			{
				num3 -= 32;
			}
			if (this.atkst[this.cur[1]] == 3)
			{
				if (num < 20)
				{
					this.DrawImage(g, this.sysimg[55], enemyStatus, num3 - (num - 16), 1);
					return;
				}
				if (num < 24)
				{
					this.DrawImage(g, this.sysimg[55], enemyStatus, num3 - 3 + (num - 16) - 4, 1);
					return;
				}
				this.DrawImage(g, this.sysimg[55], enemyStatus, num3, 1);
				return;
			}
			else if (num < 20)
			{
				this.DrawNumSprBig(g, num2, enemyStatus, num3 - (num - 16), 0, 1, false, 4);
				if (this.atkst[this.cur[1]] == 2)
				{
					this.DrawImage(g, this.sysimg[53], enemyStatus - 16, num3 - (num - 16) - 8, 0);
					return;
				}
				if (this.atkst[this.cur[1]] == 4)
				{
					this.DrawImage(g, this.sysimg[56], enemyStatus - 8, num3 - (num - 16) - 8, 0);
					return;
				}
			}
			else if (num < 24)
			{
				this.DrawNumSprBig(g, num2, enemyStatus, num3 - 3 + (num - 16) - 4, 0, 1, false, 4);
				if (this.atkst[this.cur[1]] == 2)
				{
					this.DrawImage(g, this.sysimg[53], enemyStatus - 16, num3 - 3 + (num - 16) - 4 - 8, 0);
					return;
				}
				if (this.atkst[this.cur[1]] == 4)
				{
					this.DrawImage(g, this.sysimg[56], enemyStatus - 8, num3 - 3 + (num - 16) - 4 - 8, 0);
					return;
				}
			}
			else
			{
				this.DrawNumSprBig(g, num2, enemyStatus, num3, 0, 1, false, 4);
				if (this.atkst[this.cur[1]] == 2)
				{
					this.DrawImage(g, this.sysimg[53], enemyStatus - 16, num3 - 8, 0);
					return;
				}
				if (this.atkst[this.cur[1]] == 4)
				{
					this.DrawImage(g, this.sysimg[56], enemyStatus - 8, num3 - 8, 0);
				}
			}
		}
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x000EAEA0 File Offset: 0x000E90A0
	public virtual void DrawBattleAllAttackDmg(StGraphics g)
	{
		int num = this.work[1];
		if (num >= 16)
		{
			for (int i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0)
				{
					int num2 = this.work[9 + i];
					int enemyStatus = this.GetEnemyStatus(i, 32);
					int num3 = this.GetEnemyStatus(i, 33) - 10;
					if (this.GetEnemyStatus(i, 2) == 0)
					{
						num3 -= 24;
					}
					else if (this.GetEnemyStatus(i, 2) == 1)
					{
						num3 -= 32;
					}
					else if (this.GetEnemyStatus(i, 2) == 2)
					{
						num3 -= 32;
					}
					if (this.atkst[i] == 3)
					{
						if (num < 20)
						{
							this.DrawImage(g, this.sysimg[55], enemyStatus, num3 - (num - 16), 1);
						}
						else if (num < 24)
						{
							this.DrawImage(g, this.sysimg[55], enemyStatus, num3 - 3 + (num - 16) - 4, 1);
						}
						else
						{
							this.DrawImage(g, this.sysimg[55], enemyStatus, num3, 1);
						}
					}
					else if (num < 20)
					{
						this.DrawNumSprBig(g, num2, enemyStatus, num3 - (num - 16), 0, 1, false, 4);
						if (this.atkst[i] == 2)
						{
							this.DrawImage(g, this.sysimg[53], enemyStatus - 16, num3 - (num - 16) - 8, 0);
						}
						else if (this.atkst[i] == 4)
						{
							this.DrawImage(g, this.sysimg[56], enemyStatus - 8, num3 - (num - 16) - 8, 0);
						}
					}
					else if (num < 24)
					{
						this.DrawNumSprBig(g, num2, enemyStatus, num3 - 3 + (num - 16) - 4, 0, 1, false, 4);
						if (this.atkst[i] == 2)
						{
							this.DrawImage(g, this.sysimg[53], enemyStatus - 16, num3 - 3 + (num - 16) - 4 - 8, 0);
						}
						else if (this.atkst[i] == 4)
						{
							this.DrawImage(g, this.sysimg[56], enemyStatus - 8, num3 - 3 + (num - 16) - 4 - 8, 0);
						}
					}
					else
					{
						this.DrawNumSprBig(g, num2, enemyStatus, num3, 0, 1, false, 4);
						if (this.atkst[i] == 2)
						{
							this.DrawImage(g, this.sysimg[53], enemyStatus - 16, num3 - 8, 0);
						}
						else if (this.atkst[i] == 4)
						{
							this.DrawImage(g, this.sysimg[56], enemyStatus - 8, num3 - 8, 0);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x000EB0EC File Offset: 0x000E92EC
	public virtual void DrawResultScreen(StGraphics g)
	{
		int seqStep = this.GetSeqStep();
		if (seqStep <= 5)
		{
			this.DrawResultClear(g);
			this.DrawResultCount(g);
			return;
		}
		if (9 <= seqStep && seqStep <= 11)
		{
			if (this.red || this.sysred)
			{
				this.DrawResultClear(g);
				this.DrawResultLearning(g);
				return;
			}
		}
		else if (this.red || this.sysred)
		{
			this.DrawResultClear(g);
			this.DrawResultItemGet(g);
		}
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x000EB15A File Offset: 0x000E935A
	public virtual void DrawResultClear(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x000EB17C File Offset: 0x000E937C
	public virtual void DrawResultCount(StGraphics g)
	{
		this.SetColor(g, 16777215);
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetRanks(i);
			if (num2 != 255 && this.GetStatus(num2, 20) == 0 && this.GetStatus(num2, 19) == 0)
			{
				this.DrawImage(g, this.bimg[62], 24, 1 + num * 63 + 27, 0);
				this.DrawImage(g, this.bimg[1 + num2], 28, 1 + num * 63 + 27 + 5, 0);
				this.SetColor(g, 16777215);
				this.DrawString(g, this.PlyName[num2], 59, 28 + num * 63 + 3, 0);
				string text = string.Empty + (this.GetStatus(num2, 0) + 1).ToString();
				this.DrawString(g, text, 150, 1 + num * 63 + 27 + 3, 0);
				if (this.work[2 + num2] != -1)
				{
					this.SetColor(g, 16776960);
					this.DrawString(g, "LevelUp!", 168, 28 + num * 63 + 3, 0);
				}
				this.DrawNumSpr(g, this.GetStatus(num2, 2), 74, 1 + num * 63 + 27 + 17, 0, 2, false, 4);
				this.DrawNumSpr(g, this.work[10 + num2], 104, 1 + num * 63 + 27 + 17, 0, 0, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 4), 74, 1 + num * 63 + 27 + 26, 0, 2, false, 4);
				this.DrawNumSpr(g, this.work[14 + num2], 104, 1 + num * 63 + 27 + 26, 0, 0, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 15), 110, 1 + num * 63 + 27 + 39, 0, 2, false, 5);
				this.DrawNumSpr(g, this.GetStatus(num2, 14), 104, 1 + num * 63 + 27 + 48, 0, 2, false, 6);
				if (this.work[2 + num2] == -1)
				{
					for (int j = 0; j < 5; j++)
					{
						this.DrawImage(g, this.sysimg[41], 168 + j * 6, 1 + num * 63 + 27 + 18, 0);
					}
				}
				else
				{
					this.DrawImage(g, this.sysimg[40], 168, 1 + num * 63 + 27 + 18, 0);
					this.DrawNumSpr(g, this.work[2 + num2], 174, 1 + num * 63 + 27 + 18, 0, 0, true, 4);
				}
				if (this.work[6 + num2] == -1)
				{
					for (int j = 0; j < 3; j++)
					{
						this.DrawImage(g, this.sysimg[41], 168 + j * 6, 1 + num * 63 + 27 + 27, 0);
					}
				}
				else
				{
					this.DrawImage(g, this.sysimg[40], 168, 1 + num * 63 + 27 + 27, 0);
					this.DrawNumSpr(g, this.work[6 + num2], 174, 1 + num * 63 + 27 + 27, 0, 0, true, 2);
				}
				this.DrawImage(g, this.sysimg[41], 168, 1 + num * 63 + 27 + 39, 0);
				this.DrawNumSpr(g, this.work[18], 174, 1 + num * 63 + 27 + 39, 0, 0, true, 5);
				this.DrawImage(g, this.sysimg[40], 168, 1 + num * 63 + 27 + 48, 0);
				this.DrawNumSpr(g, this.work[18], 174, 1 + num * 63 + 27 + 48, 0, 0, true, 5);
				num++;
			}
		}
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x000EB51C File Offset: 0x000E971C
	public virtual void DrawResultItemGet(StGraphics g)
	{
		this.DrawWindow(g, 70, 80, 100, 14);
		this.SetColor(g, 16777215);
		this.DrawString(g, "獲得アイテム", 120, 82, 1);
		if (this.dropitemp == 0)
		{
			this.DrawWindow(g, 50, 108, 140, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "なし", 120, 110, 1);
			return;
		}
		this.DrawWindow(g, 50, 108, 140, 14 * this.dropitemp);
		this.SetColor(g, 16777215);
		for (int i = 0; i < this.dropitemp; i++)
		{
			this.DrawString(g, this.GetBMStr(i), 62, 110 + i * 14, 0);
			this.DrawString(g, this.mmstr[i], 160, 110 + i * 14, 0);
		}
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x000EB5F8 File Offset: 0x000E97F8
	public virtual void DrawResultLearning(StGraphics g)
	{
		int num = this.work[23];
		this.DrawImage(g, this.bimg[62], 24, 61, 0);
		this.DrawImage(g, this.bimg[1 + num], 28, 66, 0);
		string text = string.Empty + (this.GetStatus(num, 0) + 1).ToString();
		this.SetColor(g, 16777215);
		this.DrawString(g, text, 150, 62, 0);
		this.DrawString(g, this.PlyName[num], 59, 62, 0);
		this.SetColor(g, 4013373);
		this.FillRect(g, 162, 78, 50, 18);
		this.SetColor(g, 5921370);
		this.FillRect(g, 162, 100, 50, 18);
		this.DrawNumSpr(g, this.GetStatus(num, 2), 74, 78, 0, 2, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 3), 104, 78, 0, 0, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 4), 74, 87, 0, 2, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 5), 104, 87, 0, 0, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 15), 110, 100, 0, 2, false, 5);
		this.DrawNumSpr(g, this.GetStatus(num, 14), 104, 109, 0, 2, false, 6);
		int num2 = 158;
		int num3 = (this.work[19 + num] & 65280) >> 8;
		if (num3 != 255)
		{
			this.DrawWindow(g, 24, num2, 192, 16);
			this.SetColor(g, 16777215);
			this.DrawString(g, "必殺技", 20, num2 - 14, 0);
			this.DrawString(g, this.GetPlySAtkName(num, num3), 120, num2 + 2, 1);
			this.DrawString(g, "を習得した。", 220, num2 + 18, 2);
			num2 = 210;
		}
		num3 = this.work[19 + num] & 255;
		if (num3 != 255)
		{
			this.DrawWindow(g, 24, num2, 192, 16);
			this.SetColor(g, 16777215);
			this.DrawString(g, "エーテル", 20, num2 - 14, 0);
			this.DrawString(g, this.GetPlyEtName(num, num3), 120, num2 + 2, 1);
			this.DrawString(g, "を習得した。", 220, num2 + 18, 2);
		}
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x000EB848 File Offset: 0x000E9A48
	public virtual void DrawGameOverScreen(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawImage(g, this.bimg[65], 58, 120, 0);
		this.red = true;
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x000EB883 File Offset: 0x000E9A83
	public virtual void DrawMapScreen(StGraphics g)
	{
		if (this.GetSeqStep() <= 5)
		{
			this.DrawMapTips(g);
			return;
		}
		this.DrawMapMenuObj(g);
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x000EB8A0 File Offset: 0x000E9AA0
	public virtual void DrawMapTips(StGraphics g)
	{
		if (this.scrcompred)
		{
			this.sysred = true;
		}
		if ((this.decieveFlag || this.sysred || this.compred || this.window_cnt != 5) && (this.decieveFlag || this.red || this.sysred))
		{
			if (this.mapno == 6 && this.xscr.sc_flg[77] == 1)
			{
				this.SetColor(g, 16777215);
				this.FillRect(g, 0, 0, 240, 240);
			}
			else
			{
				this.DrawQuestMap(g, this.mapx, this.mapy);
			}
			this.DrawTrap(g);
			this.DrawScrObj(g, 0);
			this.DrawNpcChar(g, false);
			this.DrawDestruction(g);
			this.DrawPlayer(g);
			this.DrawScrObj(g, 1);
			this.DrawNpcChar(g, true);
			if (this.trapdmg != 255)
			{
				this.DrawTrapDmage(g);
			}
		}
		if (this.decieveFlag || this.es_flag != 0)
		{
			this.DrawDecieve(g);
		}
		if (this.dome_flag != 0)
		{
			this.DrawDomeEffect(g);
		}
		if (this.Lum_flag >= 1 && this.Lum_flag <= 3)
		{
			this.DrawLuminescence(g);
		}
		if (this.decieveFlag || this.sysred || this.red)
		{
			this.DrawTalk(g);
		}
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x000EB9F0 File Offset: 0x000E9BF0
	public virtual void DrawVisualScreen(StGraphics g)
	{
		if (this.red || this.sysred)
		{
			if (this.xscr.sc_picno != -1)
			{
				if (this.nowvno == 15 || this.nowvno == 16)
				{
					this.SetColor(g, 0);
					this.FillRect(g, 0, this.xscr.sc_drawy, 240, 80);
					this.DrawImage(g, this.vimg[this.xscr.sc_picno], 72, this.xscr.sc_drawy - this.xscr.sc_picy, 0);
				}
				else if (this.nowvno == 18 || this.nowvno == 19)
				{
					this.SetColor(g, 0);
					this.FillRect(g, 0, this.xscr.sc_drawy, 240, 80);
					this.DrawImage(g, this.vimg[this.xscr.sc_picno], 56, this.xscr.sc_drawy - this.xscr.sc_picy, 0);
				}
				else
				{
					this.DrawImage(g, this.vimg[this.xscr.sc_picno], 0, this.xscr.sc_drawy - this.xscr.sc_picy, 0);
				}
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
			}
			this.DrawScrObj(g, 2);
			if (this.ol_flag != 0)
			{
				this.DrawOpenLid(g);
			}
			this.DrawPicAreaClip(g);
			this.DrawTalk2(g);
		}
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x000EBB70 File Offset: 0x000E9D70
	public virtual void DrawTitleScreen(StGraphics g)
	{
		string[] array = new string[]
		{
			string.Empty,
			"<",
			"<<"
		};
		int num = 0;
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawImage(g, this.titleimg[3], 0, 30, 0);
		this.DrawImage(g, this.titleimg[2], 78, 160 - num, 0);
		this.DrawImage(g, this.titleimg[1], 71, 176 - num, 0);
		this.DrawImage(g, this.titleimg[4], 82, 213, 0);
		this.DrawImage(g, this.titleimg[5], 0, 230, 0);
		this.DrawImage(g, this.titleimg[0], 40, 160 + this.cur[0] * 16 - num, 0);
		this.SetColor(g, 16777215);
		this.DrawString(g, "(*)SOUND", 120, 196, 1);
		this.DrawString(g, array[this.GetConfig(0)], 150, 196, 0);
	}

	// Token: 0x06000B83 RID: 2947 RVA: 0x000EBC8D File Offset: 0x000E9E8D
	public virtual void DrawLogoScreen(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawImage(g, this.logoimg, 66, 122, 0);
	}

	// Token: 0x06000B84 RID: 2948 RVA: 0x000EBCC4 File Offset: 0x000E9EC4
	public virtual void DrawContinueScreen(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, 240, 240);
		this.SetColor(g, 16777215);
		this.DrawString(g, "コンティニューしますか？", 32, 100, 0);
		if (this.cur[0] == 0)
		{
			this.SetColor(g, 16777215);
		}
		else
		{
			this.SetColor(g, 8421504);
		}
		this.DrawString(g, "はい", 120, 140, 0);
		if (this.cur[0] == 1)
		{
			this.SetColor(g, 16777215);
		}
		else
		{
			this.SetColor(g, 8421504);
		}
		this.DrawString(g, "いいえ", 120, 160, 0);
		this.DrawImage(g, this.sysimg[42], 100, 140 + this.cur[0] * 20 + 4, 0);
	}

	// Token: 0x06000B85 RID: 2949 RVA: 0x000EBDA0 File Offset: 0x000E9FA0
	public virtual void DrawClearLoadScreen(StGraphics g)
	{
		int seqStep = this.GetSeqStep();
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, 240, 240);
		if (seqStep <= 2)
		{
			this.DrawWindow(g, 20, 115, 200, 30);
			int num = 23;
			int num2 = 117;
			this.SetColor(g, 16777215);
			this.DrawString(g, "引継ぎデータがあります。", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "引継ぎますか?", num, num2, 0);
			num2 += 13;
			return;
		}
		if (seqStep == 3)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "ロード中です。", 120, 124, 1);
			return;
		}
		if (seqStep == 4)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "ロードが完了しました。", 120, 124, 1);
		}
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x000EBE88 File Offset: 0x000EA088
	public virtual void DrawStaffRollScreen(StGraphics g)
	{
		if (this.GetSeqStep() == 2)
		{
			this.SetColor(g, 0);
			this.FillRect(g, 0, 0, 240, 240);
			this.SetColor(g, 16777215);
			for (int i = 0; i < 70; i++)
			{
				int num = 252 + i * 12 - this.work[0];
				if (num >= -12 && num <= 240)
				{
					this.DrawString(g, this.StaffRollTxt[i], 120, num, 1);
				}
			}
		}
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x000EBF08 File Offset: 0x000EA108
	public virtual void DrawHelpScreen(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawTalkWindow(g, 2, 2, 44, 14);
		this.DrawTalkWindow(g, 2, 16, 236, 216);
		this.SetColor(g, 16777215);
		this.DrawString(g, "ヘルプ", 6, 4, 0);
		int num = ((this.cur[0] + 16 > this.mmenup) ? this.mmenup : (this.cur[0] + 16));
		num -= this.cur[0];
		for (int i = 0; i < num; i++)
		{
			string text = this.mmstr[i + this.cur[0]];
			if (this.mmenu[i + this.cur[0]] != 255)
			{
				int length = text.Length;
				int num2 = this.sfont.StringWidth(text);
				int num3 = i * 13 + 18;
				if (this.cur[1] == i + this.cur[0])
				{
					this.SetColor(g, 4210943);
					this.FillRect(g, 4, num3, num2, 12);
				}
				else
				{
					num3 += 11;
					this.SetColor(g, 16752768);
					this.DrawLine(g, 4, num3, 4 + num2, num3);
				}
			}
			this.SetColor(g, 16777215);
			this.DrawString(g, text, 4, i * 13 + 18, 0);
		}
		if (this.cur[0] > 0)
		{
			this.DrawRegion(g, this.sysimg[43], 0, 0, 8, 8, 2, 231, 8, 0);
		}
		if (this.cur[0] + 16 < this.mmenup)
		{
			this.DrawImage(g, this.sysimg[43], 232, 232, 0);
		}
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x000EC0BC File Offset: 0x000EA2BC
	public virtual void DrawPicAreaClip(StGraphics g)
	{
		if (this.visualno == 2)
		{
			this.SetColor(g, 16777215);
			this.FillRect(g, 0, 0, 240, 240);
			return;
		}
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, 240, this.xscr.sc_drawy);
		this.FillRect(g, 0, this.xscr.sc_drawy + 80, 240, 160 - this.xscr.sc_drawy);
	}

	// Token: 0x06000B89 RID: 2953 RVA: 0x000EC140 File Offset: 0x000EA340
	public virtual void CommandAction()
	{
		if (this.skflag)
		{
			return;
		}
		if (this.menucmd1 != string.Empty && this.menucmd1 != "\u3000" && (this.id_edge & 131072) != 0)
		{
			this.ismenu[0] = true;
		}
		if (this.menucmd2 != string.Empty && this.menucmd2 != "\u3000" && (this.id_edge & 262144) != 0)
		{
			this.ismenu[1] = true;
		}
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x000EC1CC File Offset: 0x000EA3CC
	public virtual void MediaAction(MediaPresenter source, int type, int param)
	{
		lock (this)
		{
			if (type == 3)
			{
				if (this.audio_b == source)
				{
					try
					{
						this.audio_b.Play();
						return;
					}
					catch (Exception)
					{
						return;
					}
				}
				if (this.audio_s == source && this.se_loop_flag)
				{
					try
					{
						this.audio_s.Play();
					}
					catch (Exception)
					{
					}
				}
			}
		}
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x000EC258 File Offset: 0x000EA458
	protected internal virtual void MenuFlagClear()
	{
		for (int i = 0; i < 2; i++)
		{
			this.ismenu[i] = false;
		}
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x000EC27A File Offset: 0x000EA47A
	protected internal static short ArrayShort(sbyte[] array, int ofs)
	{
		return (short)(((((int)array[ofs] + 256) & 255) << 8) | (((int)array[ofs + 1] + 256) & 255));
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x000EC2A0 File Offset: 0x000EA4A0
	protected internal static short ArrayShort2(sbyte[] array, int ofs)
	{
		return (short)(((((int)array[ofs + 1] + 256) & 255) << 8) | (((int)array[ofs] + 256) & 255));
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x000EC2C8 File Offset: 0x000EA4C8
	protected internal static int ArrayInt(sbyte[] array, int ofs)
	{
		return ((((int)array[ofs] + 256) & 255) << 24) | ((((int)array[ofs + 1] + 256) & 255) << 16) | ((((int)array[ofs + 2] + 256) & 255) << 8) | (((int)array[ofs + 3] + 256) & 255);
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x000EC324 File Offset: 0x000EA524
	protected internal static short[] GetArchive(sbyte[] data, int id)
	{
		short[] array = new short[3];
		bool flag = false;
		short num = 0;
		int num2 = 8;
		XenoPP06Canvas.ArrayShort(data, 4);
		int num3 = (int)XenoPP06Canvas.ArrayShort(data, 6);
		for (int i = 0; i < num3; i++)
		{
			short num4 = XenoPP06Canvas.ArrayShort(data, num2 + i * 6);
			if (flag)
			{
				if (num4 != num + 1)
				{
					break;
				}
				num += 1;
			}
			else if (num4 == (short)id)
			{
				short num5 = XenoPP06Canvas.ArrayShort(data, num2 + i * 6 + 2);
				short num6 = XenoPP06Canvas.ArrayShort(data, num2 + i * 6 + 4);
				array[0] = (short)((int)(num5 + 8) + 6 * num3);
				array[1] = num6;
				flag = true;
				num = num4;
			}
		}
		if (flag)
		{
			array[2] = (short)((int)num - id + 1);
			return array;
		}
		return null;
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x000EC3CC File Offset: 0x000EA5CC
	protected internal static int[] GetArchive2(sbyte[] data, int id)
	{
		int[] array = new int[3];
		bool flag = false;
		int num = 0;
		int num2 = 8;
		XenoPP06Canvas.ArrayShort(data, 4);
		int num3 = (int)XenoPP06Canvas.ArrayShort(data, 6);
		for (int i = 0; i < num3; i++)
		{
			int num4 = (int)XenoPP06Canvas.ArrayShort(data, num2 + i * 6);
			if (flag)
			{
				if (num4 != num + 1)
				{
					break;
				}
				num++;
			}
			else if (num4 == id)
			{
				int num5 = (int)XenoPP06Canvas.ArrayShort(data, num2 + i * 6 + 2);
				int num6 = (int)XenoPP06Canvas.ArrayShort(data, num2 + i * 6 + 4);
				if (num5 < 0)
				{
					num5 += 32768;
					num5 |= 32768;
					array[0] = num5 + 8 + 6 * num3;
				}
				else
				{
					array[0] = num5 + 8 + 6 * num3;
				}
				array[1] = num6;
				flag = true;
				num = num4;
			}
		}
		if (flag)
		{
			array[2] = num - id + 1;
			return array;
		}
		return null;
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x000EC49C File Offset: 0x000EA69C
	protected internal virtual MediaSound BuildSound(sbyte[] data, int ofs, int len)
	{
		MediaSound mediaSound = null;
		try
		{
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream(10240);
			byteArrayOutputStream.Write(data, ofs, len);
			byteArrayOutputStream.Close();
			mediaSound = MediaManager.GetSound(byteArrayOutputStream.ToSByteArray());
			mediaSound.Use();
		}
		catch (Exception)
		{
		}
		return mediaSound;
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x000EC4EC File Offset: 0x000EA6EC
	protected internal virtual Image BuildImage(sbyte[] data, int ofs, int len)
	{
		Image image = null;
		try
		{
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream(10240);
			byteArrayOutputStream.Write(data, ofs, len);
			byteArrayOutputStream.Close();
			MediaImage image2 = MediaManager.GetImage(byteArrayOutputStream.ToSByteArray());
			image2.Use();
			image = image2.GetImage();
		}
		catch (Exception)
		{
		}
		return image;
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x000EC540 File Offset: 0x000EA740
	protected internal virtual Image XcreateImage(int width, int height)
	{
		Image image = null;
		try
		{
			image = Image.CreateImage(width, height);
		}
		catch (Exception)
		{
			image = null;
		}
		return image;
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x000EC570 File Offset: 0x000EA770
	public virtual void DrawNumSpr(StGraphics g, int num, int posx, int posy, int col, int ar, bool z, int k)
	{
		bool flag = false;
		if (num < 0)
		{
			return;
		}
		int num2;
		if (ar == 1)
		{
			if (num > 1000)
			{
				num2 = posx - 12;
			}
			else if (num > 100)
			{
				num2 = posx - 9;
			}
			else if (num > 10)
			{
				num2 = posx - 6;
			}
			else
			{
				num2 = posx - 3;
			}
		}
		else
		{
			num2 = posx;
		}
		int num3 = num / 100000 % 10;
		int num4;
		if (num3 != 0 || (z && k >= 6))
		{
			num4 = num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 6;
			}
		}
		if (k >= 6)
		{
			if (ar == 2)
			{
				num2 += 6;
			}
			else if (ar == 1 && flag)
			{
				num2 += 6;
			}
		}
		num3 = num / 10000 % 10;
		if (num3 != 0 || flag || (z && k >= 5))
		{
			num4 = num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			num2 += 6;
		}
		num3 = num / 1000 % 10;
		if (num3 != 0 || flag || (z && k >= 4))
		{
			num4 = num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 6;
			}
		}
		if (ar == 2)
		{
			num2 += 6;
		}
		else if (ar == 1 && flag)
		{
			num2 += 6;
		}
		num3 = num % 1000 / 100;
		if (num3 != 0 || flag || (z && k >= 3))
		{
			num4 = num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 6;
			}
		}
		if (ar == 2)
		{
			num2 += 6;
		}
		else if (ar == 1 && flag)
		{
			num2 += 6;
		}
		num3 = num % 100 / 10;
		if (num3 != 0 || flag || (z && k >= 2))
		{
			num4 = num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 6;
			}
		}
		if (ar == 2)
		{
			num2 += 6;
		}
		else if (ar == 1 && flag)
		{
			num2 += 6;
		}
		num3 = num % 10;
		num4 = num3 + col * 10;
		this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x000EC76C File Offset: 0x000EA96C
	public virtual void DrawNumSprBig(StGraphics g, int num, int posx, int posy, int col, int ar, bool z, int k)
	{
		bool flag = false;
		if (num < 0)
		{
			return;
		}
		int num2;
		if (ar == 1)
		{
			if (num > 1000)
			{
				num2 = posx - 18;
			}
			else if (num > 100)
			{
				num2 = posx - 13;
			}
			else if (num > 10)
			{
				num2 = posx - 9;
			}
			else
			{
				num2 = posx - 4;
			}
		}
		else
		{
			num2 = posx;
		}
		int num3;
		int num4;
		if (z && k == 5)
		{
			num3 = num / 10000 % 10;
			num4 = 59 + num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			num2 += 9;
		}
		num3 = num / 1000 % 10;
		if (num3 != 0 || (z && k >= 4))
		{
			num4 = 59 + num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 9;
			}
		}
		if (ar == 2)
		{
			num2 += 9;
		}
		else if (ar == 1 && flag)
		{
			num2 += 9;
		}
		num3 = num % 1000 / 100;
		if (num3 != 0 || flag || (z && k >= 3))
		{
			num4 = 59 + num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 9;
			}
		}
		if (ar == 2)
		{
			num2 += 9;
		}
		else if (ar == 1 && flag)
		{
			num2 += 9;
		}
		num3 = num % 100 / 10;
		if (num3 != 0 || flag || (z && k >= 2))
		{
			num4 = 59 + num3 + col * 10;
			this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
			flag = true;
			if (ar == 0)
			{
				num2 += 9;
			}
		}
		if (ar == 2)
		{
			num2 += 9;
		}
		else if (ar == 1 && flag)
		{
			num2 += 9;
		}
		num3 = num % 10;
		num4 = 59 + num3 + col * 10;
		this.DrawImage(g, this.sysimg[num4], num2, posy, 0);
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x000EC920 File Offset: 0x000EAB20
	public virtual void DrawWindow(StGraphics g, int x, int y, int w, int h)
	{
		this.SetColor(g, 6843250);
		this.DrawLine(g, x, y, x + w - 1, y);
		this.DrawLine(g, x, y, x, y + h);
		this.SetColor(g, 2565927);
		this.DrawLine(g, x + 1, y + h, x + w, y + h);
		this.DrawLine(g, x + w, y, x + w, y + h);
		this.SetColor(g, 4013373);
		this.FillRect(g, x + 1, y + 1, w - 1, h - 1);
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x000EC9AE File Offset: 0x000EABAE
	public virtual void DrawTalkWindow(StGraphics g, int x, int y, int w, int h)
	{
		this.SetColor(g, 16512);
		g.FillRect(x + 1, y + 1, w - 1, h - 1);
		this.SetColor(g, 32960);
		g.DrawRect(x, y, w, h);
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x000EC9E8 File Offset: 0x000EABE8
	protected internal virtual void SetVisualData(int vno)
	{
		this.SetLoading(true);
		try
		{
			sbyte[] resource = this.GetResource2(this.vfile[vno]);
			int[] array = XenoPP06Canvas.GetArchive2(resource, 0);
			this.xscr.vscript = new sbyte[array[1]];
			Array.Copy(resource, array[0], this.xscr.vscript, 0, array[1]);
			int num = this.vtbl[vno];
			if (num > 0)
			{
				this.vpno = 1;
				this.vimg = new Image[num];
				for (int i = 0; i < num; i++)
				{
					array = XenoPP06Canvas.GetArchive2(resource, i + 1);
					int num2 = array[0];
					int num3 = array[1];
					this.vimg[i] = this.BuildImage(resource, num2, num3);
				}
			}
		}
		catch (Exception)
		{
		}
		this.xscr.sc_picy = 0;
		this.xscr.sc_picno = -1;
		this.nowvno = vno;
		this.SetLoading(false);
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x000ECAD4 File Offset: 0x000EACD4
	protected internal virtual void ReadVisualData(int vno)
	{
		this.SetLoading(true);
		try
		{
			sbyte[] resource = this.GetResource2(this.vfile[vno]);
			int num = this.vtbl[vno];
			if (num > 0)
			{
				this.vpno = 0;
				this.vimg = new Image[num];
				for (int i = 0; i < num; i++)
				{
					int[] archive = XenoPP06Canvas.GetArchive2(resource, i);
					int num2 = archive[0];
					int num3 = archive[1];
					this.vimg[i] = this.BuildImage(resource, num2, num3);
				}
			}
		}
		catch (Exception)
		{
		}
		this.xscr.sc_picno = -1;
		this.nowvno = vno;
		this.SetLoading(false);
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x000ECB74 File Offset: 0x000EAD74
	protected internal virtual void ReadVisualData2(int vno)
	{
		this.SetLoading(true);
		try
		{
			sbyte[] array = this.GetResource2(this.vfile[this.nowvno]);
			int num = this.vtbl[vno];
			this.vimg = new Image[num + 1];
			int[] archive = XenoPP06Canvas.GetArchive2(array, this.vpno);
			int num2 = archive[0];
			int num3 = archive[1];
			this.vimg[0] = this.BuildImage(array, num2, num3);
			if (num > 0)
			{
				array = this.GetResource2(this.vfile[vno]);
				for (int i = 0; i < num; i++)
				{
					int[] archive2 = XenoPP06Canvas.GetArchive2(array, i);
					num2 = archive2[0];
					num3 = archive2[1];
					this.vimg[i + 1] = this.BuildImage(array, num2, num3);
				}
			}
		}
		catch (Exception)
		{
		}
		this.vpno = 0;
		this.nowvno = vno;
		this.SetLoading(false);
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x000ECC48 File Offset: 0x000EAE48
	protected internal virtual void ReleaseVisualData()
	{
		this.vimg = null;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x000ECC54 File Offset: 0x000EAE54
	protected internal virtual void SetMapData(int mno)
	{
		this.SetLoading(true);
		sbyte[] array = this.GetResource2(this.mdfile[mno]);
		short[] array2 = XenoPP06Canvas.GetArchive(array, 0);
		this.xscr.script = new sbyte[(int)array2[1]];
		Array.Copy(array, (int)array2[0], this.xscr.script, 0, (int)array2[1]);
		array2 = XenoPP06Canvas.GetArchive(array, 1);
		this.mapw = (int)XenoPP06Canvas.ArrayShort2(array, (int)array2[0]);
		this.maph = (int)XenoPP06Canvas.ArrayShort2(array, (int)(array2[0] + 2));
		int num = this.mapw * this.maph;
		this.mapdat = new sbyte[num];
		Array.Copy(array, (int)(array2[0] + 4), this.mapdat, 0, num);
		int num2;
		if (this.mapw % 2 == 0)
		{
			num2 = this.mapw / 2 * this.maph;
		}
		else
		{
			num2 = (this.mapw + 1) / 2 * this.maph;
		}
		this.atrdat = new sbyte[num2];
		Array.Copy(array, (int)(array2[0] + 4) + num, this.atrdat, 0, num2);
		if (this.debug_enc)
		{
			this.eneapr = this.miflag[mno][0];
		}
		else
		{
			this.eneapr = false;
		}
		this.etheruse = this.miflag[mno][1];
		int num3 = this.mofileno[mno];
		if (this.befmo != num3)
		{
			int num4 = this.mofmax[num3];
			this.mcimg = new Image[num4];
			array = this.GetResource2(26);
			for (int i = 0; i < 62; i++)
			{
				int[] archive = XenoPP06Canvas.GetArchive2(array, i);
				int num5 = archive[0];
				int num6 = archive[1];
				this.mcimg[i] = this.BuildImage(array, num5, num6);
			}
			array = this.GetResource2(this.mofile[num3]);
			for (int i = 62; i < num4; i++)
			{
				int[] archive2 = XenoPP06Canvas.GetArchive2(array, i);
				int num5 = archive2[0];
				int num6 = archive2[1];
				this.mcimg[i] = this.BuildImage(array, num5, num6);
			}
			this.befmo = num3;
			this.mcimgmax = num4;
		}
		this.SetLoading(false);
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x000ECE54 File Offset: 0x000EB054
	public virtual sbyte GetAtr(int px, int py)
	{
		if (px <= -4 || px >= this.mapw * 16 || py <= 0 || py >= this.maph * 16)
		{
			return 1;
		}
		int num = px / 16;
		int num2 = py / 16;
		int num3 = this.mapw;
		if (this.mapw % 2 == 1)
		{
			num3++;
		}
		num3 /= 2;
		sbyte b = this.atrdat[num2 * num3 + num / 2];
		if (num % 2 == 1)
		{
			b &= 15;
		}
		else
		{
			b = (sbyte)((b >> 4) & 15);
		}
		if (b != 0)
		{
			return b;
		}
		for (int i = 0; i < this.xscr.npc_p; i++)
		{
			num = this.xscr.npc_xy[i][0];
			num2 = this.xscr.npc_xy[i][1];
			if (num - 8 <= px && px <= num + 4 && num2 - 8 <= py && py <= num2 + 2)
			{
				return 15;
			}
		}
		for (int i = 0; i < this.xscr.tobj_p; i++)
		{
			if (this.xscr.tobj_cno[i] == 2)
			{
				if (this.chc == 28 || this.chc == 35)
				{
					num = this.xscr.tobj_xy[i][0];
					num2 = this.xscr.tobj_xy[i][1];
					if ((num > this.chx || this.chx > num + 16 || num2 > this.chy - 1 || this.chy - 4 > num2 + 16) && num <= px && px <= num + 12 && num2 <= py && py <= num2 + 12)
					{
						return 15;
					}
				}
			}
			else if (this.xscr.tobj_pn[i] != 255)
			{
				num = this.xscr.tobj_xy[i][0];
				num2 = this.xscr.tobj_xy[i][1];
				if (num <= px && px <= num + 12 && num2 <= py && py <= num2 + 12)
				{
					return 15;
				}
			}
		}
		return b;
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x000ED030 File Offset: 0x000EB230
	public virtual sbyte GetAtrNpc(int px, int py, int id)
	{
		if (px <= 0 || px >= this.mapw * 16 || py <= 0 || py >= this.maph * 16)
		{
			return 1;
		}
		int num = (px + 8) / 16;
		int num2 = (py - 8) / 16;
		int num3 = this.mapw;
		if (this.mapw % 2 == 1)
		{
			num3++;
		}
		num3 /= 2;
		sbyte b = this.atrdat[num2 * num3 + num / 2];
		if (num % 2 == 1)
		{
			b &= 15;
		}
		else
		{
			b = (sbyte)((b >> 4) & 15);
		}
		if (b != 0)
		{
			return b;
		}
		num = this.chx;
		num2 = this.chy;
		if (num - 8 <= px && px <= num + 8 && num2 - 8 <= py && py <= num2 + 8)
		{
			return 15;
		}
		for (int i = 0; i < this.xscr.npc_p; i++)
		{
			if (id != i)
			{
				num = this.xscr.npc_xy[i][0];
				num2 = this.xscr.npc_xy[i][1];
				if (num - 8 <= px && px <= num + 8 && num2 - 8 <= py && py <= num2 + 2)
				{
					return 15;
				}
			}
		}
		for (int i = 0; i < this.xscr.tobj_p; i++)
		{
			if (this.xscr.tobj_pn[i] != 255)
			{
				num = this.xscr.tobj_xy[i][0];
				num2 = this.xscr.tobj_xy[i][1];
				if (num <= px && px <= num + 12 && num2 <= py && py <= num2 + 12)
				{
					return 15;
				}
			}
		}
		return b;
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x000ED1A4 File Offset: 0x000EB3A4
	public virtual void SetMenu(int no)
	{
		int num = 0;
		this.skflag = true;
		if (no == 0)
		{
			int num2;
			if (this.blast != -1)
			{
				num2 = 0;
			}
			else
			{
				num2 = 1;
			}
			int num3;
			if (!this.isboost[1] && this.isboost[2])
			{
				num3 = 0;
			}
			else
			{
				num3 = 1;
			}
			if (num2 == 0 && num3 == 0)
			{
				num = 0;
			}
			else if (num2 == 1 && num3 == 0)
			{
				num = 1;
			}
			else if (num2 == 0 && num3 == 1)
			{
				num = 2;
			}
			else if (num2 == 1 && num3 == 1)
			{
				num = 3;
			}
		}
		else if (no == 3)
		{
			if (!this.isboost[1] && this.isboost[2])
			{
				num = 4;
			}
			else
			{
				num = 5;
			}
		}
		else if (no == 1)
		{
			if (!this.isboost[1] && this.isboost[2])
			{
				num = 6;
			}
			else
			{
				num = 7;
			}
		}
		else if (no == 2)
		{
			num = 8;
		}
		else if (no == 4)
		{
			num = 9;
		}
		else if (no == 5)
		{
			num = 10;
		}
		else if (no == 6)
		{
			num = 11;
		}
		else if (no == 7)
		{
			num = 12;
		}
		else if (no == 8)
		{
			num = 13;
		}
		else if (no == 9)
		{
			num = 14;
		}
		else if (no == 10)
		{
			num = 15;
		}
		if (this.nowmenuno == num)
		{
			this.skflag = false;
			return;
		}
		this.nowmenuno = num;
		if (no == 0)
		{
			if (this.blast != -1)
			{
				this.menucmd1 = "終了";
			}
			else
			{
				this.menucmd1 = "ﾒﾆｭｰ";
			}
			if (!this.iscboost && !this.isboost[1] && this.isboost[2])
			{
				this.menucmd2 = "ﾌﾞｰｽﾄ";
			}
			else
			{
				this.menucmd2 = null;
			}
		}
		else if (no == 3)
		{
			this.menucmd1 = null;
			if (!this.iscboost && !this.isboost[1] && this.isboost[2])
			{
				this.menucmd2 = "ﾌﾞｰｽﾄ";
			}
			else
			{
				this.menucmd2 = null;
			}
		}
		else if (no == 1)
		{
			this.menucmd1 = "戻る";
			if (!this.iscboost && !this.isboost[1] && this.isboost[2])
			{
				this.menucmd2 = "ﾌﾞｰｽﾄ";
			}
			else
			{
				this.menucmd2 = null;
			}
		}
		else if (no == 2)
		{
			this.menucmd1 = null;
			this.menucmd2 = "戻る";
		}
		else if (no == 4)
		{
			this.menucmd1 = null;
			this.menucmd2 = null;
		}
		else if (no == 5)
		{
			this.menucmd1 = "ﾒﾆｭｰ";
			this.menucmd2 = "隊列";
		}
		else if (no == 6)
		{
			this.menucmd1 = null;
			this.menucmd2 = "ｽｷｯﾌﾟ";
		}
		else if (no == 7)
		{
			this.menucmd1 = "戻る";
			this.menucmd2 = null;
		}
		else if (no == 8)
		{
			this.menucmd1 = null;
			this.menucmd2 = "ﾘﾄﾗｲ";
		}
		else if (no == 9)
		{
			this.menucmd1 = "はい";
			this.menucmd2 = "いいえ";
		}
		else if (no == 10)
		{
			this.menucmd1 = null;
			this.menucmd2 = "ﾍﾙﾌﾟ";
		}
		this.SetSoftLabel(0, this.menucmd1);
		this.SetSoftLabel(1, this.menucmd2);
		this.skflag = false;
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x000ED494 File Offset: 0x000EB694
	public virtual void WorkClear()
	{
		for (int i = 0; i < 24; i++)
		{
			this.work[i] = 0;
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x000ED4B8 File Offset: 0x000EB6B8
	public virtual int GetDmg(int pl, int en)
	{
		int num;
		int num2;
		if (this.IsGuard(en + 4) != 1)
		{
			num = 15;
			num2 = this.GetRand(0, 99);
			if (num2 < num)
			{
				this.SetGuard(en + 4, 2);
			}
			else
			{
				this.SetGuard(en + 4, 0);
			}
		}
		int num3 = this.nowmenu;
		int num4;
		int num5;
		int num6;
		int num7;
		if (num3 >= 16)
		{
			this.attackef = 0;
			num = 100;
			num3 -= 16;
			if (this.GetPlySAtkParam(pl, num3, 0) == 0)
			{
				num4 = this.GetPhysicalSAttackNum(pl, num3);
				num5 = this.GetVit(en + 4);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(en + 4) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEtherSAttackNum(pl, num3);
				num5 = this.GetEDef(en + 4);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(en + 4) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		else
		{
			this.attackef = this.GetPlyNAtkParam(pl, num3, 8);
			num = this.GetHitRate(pl, en, this.GetPlyNAtkParam(pl, num3, 7));
			if (this.GetPlyNAtkParam(pl, num3, 0) == 0)
			{
				num4 = this.GetPhysicalAttackNum(pl, num3);
				num5 = this.GetVit(en + 4);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(en + 4) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEtherAttackNum(pl, num3);
				num5 = this.GetEDef(en + 4);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(en + 4) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		this.atkst[en] = 0;
		num2 = this.GetRand(0, 99);
		if (num2 < num)
		{
			num2 = (num4 - num5) * num6 * num7;
			if (num2 < 0)
			{
				num2 = 0;
			}
			num2 /= 100;
			if (num2 < 1)
			{
				num2 = 1;
			}
			int critical = this.GetCritical(pl, en + 4);
			if (critical == 0)
			{
				this.crtl = 0;
			}
			else if (critical == 1)
			{
				num2 *= 150;
				num2 /= 100;
				this.crtl = critical;
				this.atkst[en] = 2;
			}
			else if (critical == 2)
			{
				num2 *= 2;
				this.crtl = critical;
				this.atkst[en] = 2;
			}
			if (this.atkst[en] == 0 && num7 != 10)
			{
				this.atkst[en] = 4;
			}
			return num2;
		}
		num2 = 0;
		this.atkst[en] = 3;
		return num2;
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x000ED6F4 File Offset: 0x000EB8F4
	public virtual int GetDmg2(int pl, int en)
	{
		int num;
		int num2;
		if (this.IsGuard(pl) != 1)
		{
			num = 15;
			num2 = this.GetRand(0, 99);
			if (num2 < num)
			{
				this.SetGuard(pl, 2);
			}
			else
			{
				this.SetGuard(pl, 0);
			}
		}
		int num4;
		int num5;
		int num6;
		int num7;
		if (this.eneatk >= 48)
		{
			num = 100;
			int num3 = this.eneatk - 48;
			if (this.GetEneSAtkParam(num3, 0) == 0)
			{
				num4 = this.GetEneSAtkParam(num3, 4) + this.GetEnemyStatus(en, 4);
				num5 = this.GetVit(pl) + this.GetArmorDef(pl, false);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(pl) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEneSAtkParam(num3, 4) + this.GetEnemyStatus(en, 6);
				num5 = this.GetEDef(pl) + this.GetArmorDef(pl, true);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(pl) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		else
		{
			int num3 = this.eneatk;
			num = this.GetHitRate(en, pl, this.GetEneNAtkParam(num3, 5));
			if (this.GetEneNAtkParam(num3, 0) == 0)
			{
				num4 = this.GetEneNAtkParam(num3, 4) + this.GetEnemyStatus(en, 4);
				num5 = this.GetVit(pl) + this.GetArmorDef(pl, false);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(pl) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEneNAtkParam(num3, 4) + this.GetEnemyStatus(en, 6);
				num5 = this.GetEDef(pl) + this.GetArmorDef(pl, true);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(pl) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		this.atkst[pl] = 0;
		num2 = this.GetRand(0, 99);
		if (num2 < num)
		{
			num2 = (num4 - num5) * num6 * num7;
			if (num2 < 0)
			{
				num2 = 0;
			}
			num2 /= 100;
			if (num2 < 1)
			{
				num2 = 1;
			}
			int critical = this.GetCritical(en + 4, pl);
			if (critical == 0)
			{
				this.crtl = 0;
			}
			else if (critical == 1)
			{
				num2 *= 150;
				num2 /= 100;
				this.crtl = critical;
				this.atkst[pl] = 2;
			}
			else if (critical == 2)
			{
				this.crtl = critical;
				this.atkst[pl] = 2;
			}
			if (this.atkst[pl] == 0 && num7 != 10)
			{
				this.atkst[pl] = 4;
			}
			return num2;
		}
		num2 = 0;
		this.atkst[pl] = 3;
		return num2;
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x000ED94C File Offset: 0x000EBB4C
	public virtual int GetDmg3(int en2, int en1)
	{
		int num;
		int num2;
		if (this.IsGuard(en2 + 4) != 1)
		{
			num = 15;
			num2 = this.GetRand(0, 99);
			if (num2 < num)
			{
				this.SetGuard(en2 + 4, 2);
			}
			else
			{
				this.SetGuard(en2 + 4, 0);
			}
		}
		int num4;
		int num5;
		int num6;
		int num7;
		if (this.eneatk >= 48)
		{
			num = 100;
			int num3 = this.eneatk - 48;
			if (this.GetEneSAtkParam(num3, 0) == 0)
			{
				num4 = this.GetEneSAtkParam(num3, 4) + this.GetEnemyStatus(en1, 4);
				num5 = this.GetVit(en2 + 4);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(en2 + 4) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEneSAtkParam(num3, 4) + this.GetEnemyStatus(en1, 6);
				num5 = this.GetEDef(en2 + 4);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(en2 + 4) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		else
		{
			int num3 = this.eneatk;
			num = this.GetHitRate(en1, en2, this.GetEneNAtkParam(num3, 5));
			if (this.GetEneNAtkParam(num3, 0) == 0)
			{
				num4 = this.GetEneNAtkParam(num3, 4) + this.GetEnemyStatus(en1, 4);
				num5 = this.GetVit(en2 + 4);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(en2 + 4) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEneNAtkParam(num3, 4) + this.GetEnemyStatus(en1, 6);
				num5 = this.GetEDef(en2 + 4);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(en2 + 4) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		this.atkst[en2] = 0;
		num2 = this.GetRand(0, 99);
		if (num2 < num)
		{
			num2 = (num4 - num5) * num6 * num7;
			if (num2 < 0)
			{
				num2 = 0;
			}
			num2 /= 100;
			if (num2 < 1)
			{
				num2 = 1;
			}
			int critical = this.GetCritical(en1 + 4, en2 + 4);
			if (critical == 0)
			{
				this.crtl = 0;
			}
			else if (critical == 1)
			{
				num2 *= 150;
				num2 /= 100;
				this.crtl = critical;
				this.atkst[en2] = 2;
			}
			else if (critical == 2)
			{
				num2 *= 2;
				this.crtl = critical;
				this.atkst[en2] = 2;
			}
			if (this.atkst[en2] == 0 && num7 != 10)
			{
				this.atkst[en2] = 4;
			}
			return num2;
		}
		num2 = 0;
		this.atkst[en2] = 3;
		return num2;
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x000EDB9C File Offset: 0x000EBD9C
	public virtual int GetDmg4(int pl1, int pl2)
	{
		int num;
		int num2;
		if (this.IsGuard(pl2) != 1)
		{
			num = 15;
			num2 = this.GetRand(0, 99);
			if (num2 < num)
			{
				this.SetGuard(pl2, 2);
			}
			else
			{
				this.SetGuard(pl2, 0);
			}
		}
		int num3 = this.nowmenu;
		int num4;
		int num5;
		int num6;
		int num7;
		if (num3 >= 16)
		{
			num = 100;
			num3 -= 16;
			if (this.GetPlySAtkParam(pl1, num3, 0) == 0)
			{
				num4 = this.GetPhysicalSAttackNum(pl1, num3);
				num5 = this.GetVit(pl2) + this.GetArmorDef(pl2, false);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(pl2) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEtherSAttackNum(pl1, num3);
				num5 = this.GetEDef(pl2) + this.GetArmorDef(pl2, true);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(pl2) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		else
		{
			num = this.GetHitRate(pl1, pl2, this.GetPlyNAtkParam(pl1, num3, 7));
			if (this.GetPlyNAtkParam(pl1, num3, 0) == 0)
			{
				num4 = this.GetPhysicalAttackNum(pl1, num3);
				num5 = this.GetVit(pl2) + this.GetArmorDef(pl2, false);
				num6 = this.GetRand(30, 40);
				if (this.IsGuard(pl2) != 0)
				{
					num7 = 5;
				}
				else
				{
					num7 = 10;
				}
			}
			else
			{
				num4 = this.GetEtherAttackNum(pl1, num3);
				num5 = this.GetEDef(pl2) + this.GetArmorDef(pl2, true);
				num6 = this.GetRand(40, 50);
				if (this.IsGuard(pl2) != 0)
				{
					num7 = 8;
				}
				else
				{
					num7 = 10;
				}
			}
		}
		this.atkst[pl2] = 0;
		num2 = this.GetRand(0, 99);
		if (num2 < num)
		{
			num2 = (num4 - num5) * num6 * num7;
			if (num2 < 0)
			{
				num2 = 0;
			}
			num2 /= 100;
			if (num2 < 1)
			{
				num2 = 1;
			}
			int critical = this.GetCritical(pl1, pl2);
			if (critical == 0)
			{
				this.crtl = 0;
			}
			else if (critical == 1)
			{
				num2 *= 150;
				num2 /= 100;
				this.crtl = critical;
				this.atkst[pl2] = 2;
			}
			else if (critical == 2)
			{
				num2 *= 2;
				this.crtl = critical;
				this.atkst[pl2] = 2;
			}
			if (this.atkst[pl2] == 0 && num7 != 10)
			{
				this.atkst[pl2] = 4;
			}
			return num2;
		}
		num2 = 0;
		this.atkst[pl2] = 3;
		return num2;
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x000EDDD0 File Offset: 0x000EBFD0
	public virtual void SetSpAllEnemyDamage(int id)
	{
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) == 0)
			{
				this.work[9 + i] = this.GetDmg(id, i);
			}
		}
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x000EDE0C File Offset: 0x000EC00C
	public virtual int GetCritical(int id, int id2)
	{
		if (id < 4)
		{
			int num = this.nowmenu;
			int num2;
			int num3;
			if (num >= 16)
			{
				num -= 16;
				num2 = this.GetPlySAtkParam(id, num, 1);
				num3 = this.GetPlySAtkParam(id, num, 2);
			}
			else
			{
				num2 = this.GetPlyNAtkParam(id, num, 1);
				num3 = this.GetPlyNAtkParam(id, num, 2);
			}
			int num4;
			if (this.IsStatusAbnormal(id, 22) && this.cur[0] == 1)
			{
				num4 = this.GetStatus(id2, 1);
			}
			else
			{
				num4 = this.GetEnemyStatus(id2 - 4, 19);
			}
			if (num4 == num2 || num4 == num3)
			{
				return 2;
			}
			int num5;
			if (this.crtl != 0)
			{
				num5 = 80;
			}
			else if (this.bslot[this.bslotno] == 1)
			{
				num5 = 50;
			}
			else
			{
				num5 = 10;
			}
			if (this.GetRand(0, 99) < num5)
			{
				return 1;
			}
		}
		else
		{
			int num = this.eneatk;
			int num2;
			int num3;
			if (num >= 48)
			{
				num -= 48;
				num2 = this.GetEneSAtkParam(num, 1);
				num3 = this.GetEneSAtkParam(num, 2);
			}
			else
			{
				num2 = this.GetEneNAtkParam(num, 1);
				num3 = this.GetEneNAtkParam(num, 2);
			}
			int num4;
			if (this.cur[0] == 0)
			{
				num4 = this.GetEnemyStatus(id2 - 4, 19);
			}
			else
			{
				num4 = this.GetStatus(id2, 1);
			}
			if (num4 == num2 || num4 == num3)
			{
				return 2;
			}
			int num5;
			if (this.crtl != 0)
			{
				num5 = 80;
			}
			else if (this.GetNowSlot() == 1)
			{
				num5 = 50;
			}
			else
			{
				num5 = 10;
			}
			if (this.GetRand(0, 99) < num5)
			{
				return 1;
			}
		}
		return 0;
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x000EDF60 File Offset: 0x000EC160
	public virtual int GetPhysicalSAttackNum(int id, int mno)
	{
		int plySAtkParam = this.GetPlySAtkParam(id, mno, 6);
		int num = this.GetStr(id) + this.GetWeaponStr(id, false);
		return plySAtkParam + num;
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x000EDF8C File Offset: 0x000EC18C
	public virtual int GetEtherSAttackNum(int id, int mno)
	{
		int plySAtkParam = this.GetPlySAtkParam(id, mno, 6);
		int num = this.GetEAtk(id) + this.GetWeaponStr(id, true);
		return plySAtkParam + num;
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x000EDFB8 File Offset: 0x000EC1B8
	public virtual int GetPhysicalAttackNum(int id, int mno)
	{
		int plyNAtkParam = this.GetPlyNAtkParam(id, mno, 4);
		int num = this.GetStr(id) + this.GetWeaponStr(id, false);
		return plyNAtkParam + num;
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x000EDFE4 File Offset: 0x000EC1E4
	public virtual int GetEtherAttackNum(int id, int mno)
	{
		int plyNAtkParam = this.GetPlyNAtkParam(id, mno, 4);
		int num = this.GetEAtk(id) + this.GetWeaponStr(id, true);
		return plyNAtkParam + num;
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x000EE010 File Offset: 0x000EC210
	public virtual int GetEtherAttackNum2(int id, int pow)
	{
		int num = this.GetEAtk(id) + this.GetWeaponStr(id, true);
		return pow + num;
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x000EE034 File Offset: 0x000EC234
	public virtual int GetEtherDmg(int id, int en, int pow)
	{
		int etherAttackNum = this.GetEtherAttackNum2(id, pow);
		int edef = this.GetEDef(en);
		int num = this.GetRand(40, 50);
		int num2 = 10;
		int num3 = (etherAttackNum - edef) * num * num2;
		if (num3 < 0)
		{
			num3 = 0;
		}
		num3 /= 100;
		if (this.IsStatusAbnormal(en, 10))
		{
			num3 *= 75;
			num3 /= 100;
		}
		if (this.IsStatusAbnormal(en, 11))
		{
			num3 *= 125;
			num3 /= 100;
		}
		if (this.IsStatusAbnormal(id, 12))
		{
			num3 *= 2;
		}
		return num3;
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x000EE0AB File Offset: 0x000EC2AB
	public virtual void VibRoutine()
	{
		if (this.vib[0] == 1)
		{
			this.vib[1]--;
			if (this.vib[1] <= 0)
			{
				this.StopVib();
			}
		}
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x000EE0DA File Offset: 0x000EC2DA
	public virtual void StartVib(int time)
	{
		if (this.GetConfig(1) == 0)
		{
			this.vib[0] = 0;
			this.vib[1] = 0;
			return;
		}
		this.vib[0] = 1;
		this.vib[1] = time;
		PhoneSystem.SetAttribute(1, 1);
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x000EE114 File Offset: 0x000EC314
	public virtual void StopVib()
	{
		try
		{
			PhoneSystem.SetAttribute(1, 0);
			this.vib[0] = 0;
			this.vib[1] = 0;
		}
		catch (Exception)
		{
			this.vib[0] = 1;
			this.vib[1] = 0;
		}
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x000EE164 File Offset: 0x000EC364
	public virtual void SetBackLight(bool f)
	{
		if (f)
		{
			PhoneSystem.SetAttribute(0, 1);
			return;
		}
		PhoneSystem.SetAttribute(0, 0);
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x000EE178 File Offset: 0x000EC378
	public virtual void InitFade()
	{
		this.fade = new int[4];
		this.fade[0] = 0;
		this.fade[1] = 0;
		this.fade[2] = 0;
		this.fade[3] = 16;
		this.fade_pa = new PrimitiveArray(4, 1024, 1);
		this.map_pa = new PrimitiveArray(5, 32768, 128);
		this.fade_pa.GetVertexArray()[0] = -1024;
		this.fade_pa.GetVertexArray()[1] = -1024;
		this.fade_pa.GetVertexArray()[3] = 1024;
		this.fade_pa.GetVertexArray()[4] = -1024;
		this.fade_pa.GetVertexArray()[6] = 1024;
		this.fade_pa.GetVertexArray()[7] = 1024;
		this.fade_pa.GetVertexArray()[9] = -1024;
		this.fade_pa.GetVertexArray()[10] = 1024;
		this.dec_pa = new PrimitiveArray(4, 12800, 12);
		this.dec_nor_work = new int[12];
		this.dec_col = new int[12];
		this.dec_flg = new int[12];
		this.dec_y = new int[12];
		this.decieveFlag = false;
		int num;
		int num2;
		for (int i = 0; i < 12; i++)
		{
			this.dec_pa.GetNormalArray()[i * 3 + 2] = -4096;
			this.dec_col[i] = 0;
			this.dec_flg[i] = 0;
			this.dec_y[i] = 0;
			num = 11;
			num2 = 14;
			this.dec_pa.GetTextureCoordArray()[i * 8 + 1] = num2 * 16 + num2 + 1;
			this.dec_pa.GetTextureCoordArray()[i * 8 + 3] = num2 * 16 + num2 + 1;
			this.dec_pa.GetTextureCoordArray()[i * 8 + 5] = num2 * 16 + num2 + 16 - 1;
			this.dec_pa.GetTextureCoordArray()[i * 8 + 7] = num2 * 16 + num2 + 16 - 1;
			int num3 = this.GetRand(0, 1);
			if (num3 == 0)
			{
				this.dec_pa.GetTextureCoordArray()[i * 8] = num * 16 + num + 1;
				this.dec_pa.GetTextureCoordArray()[i * 8 + 2] = num * 16 + num + 64 - 1;
				this.dec_pa.GetTextureCoordArray()[i * 8 + 4] = num * 16 + num + 64 - 1;
				this.dec_pa.GetTextureCoordArray()[i * 8 + 6] = num * 16 + num + 1;
			}
			else if (num3 == 1)
			{
				this.dec_pa.GetTextureCoordArray()[i * 8] = num * 16 + num + 64 - 1;
				this.dec_pa.GetTextureCoordArray()[i * 8 + 2] = num * 16 + num + 1;
				this.dec_pa.GetTextureCoordArray()[i * 8 + 4] = num * 16 + num + 1;
				this.dec_pa.GetTextureCoordArray()[i * 8 + 6] = num * 16 + num + 64 - 1;
			}
		}
		this.dome_pa = new PrimitiveArray(4, 12288, 1);
		num = 3;
		num2 = 13;
		this.dome_pa.GetTextureCoordArray()[0] = num * 16 + num + 1;
		this.dome_pa.GetTextureCoordArray()[1] = num2 * 16 + num2 + 1;
		this.dome_pa.GetTextureCoordArray()[2] = num * 16 + num + 32;
		this.dome_pa.GetTextureCoordArray()[3] = num2 * 16 + num2 + 1;
		this.dome_pa.GetTextureCoordArray()[4] = num * 16 + num + 32;
		this.dome_pa.GetTextureCoordArray()[5] = num2 * 16 + num2 + 32;
		this.dome_pa.GetTextureCoordArray()[6] = num * 16 + num + 1;
		this.dome_pa.GetTextureCoordArray()[7] = num2 * 16 + num2 + 32;
		this.ol_pa = new PrimitiveArray(4, 1024, 1);
		this.ol_pa.GetColorArray()[0] = 8421504;
		this.Lum_pa1 = new PrimitiveArray(4, 12288, 1);
		this.Lum_pa2 = new PrimitiveArray(4, 1024, 1);
		for (int j = 0; j < 12; j++)
		{
			this.Lum_pa1.GetVertexArray()[j] = 0;
		}
		num = 0;
		num2 = 12;
		this.Lum_pa1.GetTextureCoordArray()[0] = num * 16 + num + 1;
		this.Lum_pa1.GetTextureCoordArray()[1] = num2 * 16 + num2 + 1;
		this.Lum_pa1.GetTextureCoordArray()[2] = num * 16 + num + 48;
		this.Lum_pa1.GetTextureCoordArray()[3] = num2 * 16 + num2 + 1;
		this.Lum_pa1.GetTextureCoordArray()[4] = num * 16 + num + 48;
		this.Lum_pa1.GetTextureCoordArray()[5] = num2 * 16 + num2 + 48;
		this.Lum_pa1.GetTextureCoordArray()[6] = num * 16 + num + 1;
		this.Lum_pa1.GetTextureCoordArray()[7] = num2 * 16 + num2 + 48;
		this.Lum_pa2.GetVertexArray()[0] = -1024;
		this.Lum_pa2.GetVertexArray()[1] = -1024;
		this.Lum_pa2.GetVertexArray()[3] = 1024;
		this.Lum_pa2.GetVertexArray()[4] = -1024;
		this.Lum_pa2.GetVertexArray()[6] = 1024;
		this.Lum_pa2.GetVertexArray()[7] = 1024;
		this.Lum_pa2.GetVertexArray()[9] = -1024;
		this.Lum_pa2.GetVertexArray()[10] = 1024;
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x000EE6D1 File Offset: 0x000EC8D1
	public virtual void StartFade(int type)
	{
		this.StartFade(type, 16);
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x000EE6DC File Offset: 0x000EC8DC
	public virtual void StartFade(int type, int spd)
	{
		if (type == 2)
		{
			this.fade[0] = 3;
			this.fade[1] = 1;
			this.fade[2] = 255;
			this.fade[3] = spd;
			return;
		}
		if (type == 5)
		{
			this.fade[0] = 3;
			this.fade[1] = 4;
			this.fade[2] = 255;
			this.fade[3] = spd;
			return;
		}
		if (type == 9)
		{
			this.fade[0] = 3;
			this.fade[1] = 7;
			this.fade[2] = 255;
			this.fade[3] = spd;
			return;
		}
		if (type == 6)
		{
			this.fade[0] = 0;
			this.fade[1] = 0;
			this.fade[2] = 0;
			this.fade[3] = spd;
			return;
		}
		this.fade[0] = 1;
		this.fade[1] = type;
		this.fade[2] = 0;
		this.fade[3] = spd;
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x000EE7C0 File Offset: 0x000EC9C0
	public virtual void FadeRoutine()
	{
		if (this.fade[0] == 1)
		{
			this.fade[0] = 2;
			this.fade[2] = 0;
			this.red = true;
			return;
		}
		if (this.fade[0] == 2)
		{
			this.fade[2] += this.fade[3];
			if (this.fade[2] >= 255)
			{
				if (this.fade[1] == 1 || this.fade[1] == 4 || this.fade[1] == 7)
				{
					this.fade[0] = 3;
					this.fade[2] = 255;
				}
				else
				{
					this.fade[0] = 0;
				}
			}
			this.red = true;
		}
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x000EE870 File Offset: 0x000ECA70
	public virtual void DrawFade(StGraphics g)
	{
		try
		{
			this.g3d = g;
		}
		catch (Exception)
		{
			return;
		}
		if (this.fade[0] == 2 || this.fade[0] == 3)
		{
			int num;
			if (this.fade[1] == 0 || this.fade[1] == 3 || this.fade[1] == 8)
			{
				num = 255 - this.fade[2];
			}
			else
			{
				num = this.fade[2];
			}
			this.g3d.SetScreenCenter(this.GetWidth() / 2, this.GetHeight() / 2);
			this.g3d.EnableSemiTransparent(true);
			this.fade_pa.GetColorArray()[0] = (num << 16) | (num << 8) | num;
			if (this.fade[1] == 0 || this.fade[1] == 1)
			{
				this.g3d.RenderPrimitives(this.fade_pa, 96, false);
			}
			else if (this.fade[1] == 3 || this.fade[1] == 4)
			{
				this.g3d.RenderPrimitives(this.fade_pa, 64, false);
			}
			else if (this.fade[1] == 8 || this.fade[1] == 7)
			{
				if (this.fade[0] == 3)
				{
					this.SetColor(g, 16711680);
					this.FillRect(g, 0, 0, 240, 240);
				}
				else
				{
					this.fade_pa.GetColorArray()[0] = (num << 16) | 0 | 0;
					this.g3d.RenderPrimitives(this.fade_pa, 64, false);
				}
			}
			this.g3d.Flush();
		}
		if (this.mapno == 6 && this.xscr.sc_flg[78] == 1)
		{
			this.DrawScrObj(g, 1);
		}
		if ((this.mapno == 25 || this.mapno == 26) && this.xscr.sc_flg[5] == 1)
		{
			this.DrawScrObj(g, 1);
		}
		if (this.nowvno == 15 || this.nowvno == 16)
		{
			if (this.xscr.sc_flg[79] == 1)
			{
				this.DrawImage(g, this.vimg[this.xscr.sc_picno], 72, this.xscr.sc_drawy - this.xscr.sc_picy, 0);
			}
			if (this.xscr.sc_flg[77] == 1)
			{
				this.DrawImage(g, this.vimg[1], 0, this.xscr.sc_drawy, 0);
			}
		}
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x000EEAD0 File Offset: 0x000ECCD0
	public virtual int IsFade()
	{
		if (this.fade[0] == 3)
		{
			return 3;
		}
		if (this.fade[0] != 0)
		{
			return 2;
		}
		return 0;
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x000EEAEC File Offset: 0x000ECCEC
	public virtual int GetFadeType()
	{
		if (this.IsFade() == 0)
		{
			return 6;
		}
		return this.fade[1];
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x000EEB00 File Offset: 0x000ECD00
	public virtual void QuakeRoutine()
	{
		if (this.quf == 0)
		{
			return;
		}
		if (this.quf == 1)
		{
			this.qux = this.GetRand(0, 3);
			this.quy = this.GetRand(0, 3);
		}
		else if (this.quf == 2)
		{
			this.qux = this.GetRand(0, 3);
			this.quy = 0;
		}
		this.red = true;
		this.compred = true;
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x000EEB6C File Offset: 0x000ECD6C
	public virtual void DrawQuestMap(StGraphics g, int px, int py)
	{
		lock (this)
		{
			int i = 0;
			int num = px / 16;
			int num2 = py / 16;
			int num3 = px % 16;
			int num4 = py % 16;
			int num5;
			if (num3 == 0)
			{
				num5 = 15;
			}
			else
			{
				num5 = 16;
			}
			int num6;
			if (num4 == 0)
			{
				num6 = 15;
			}
			else
			{
				num6 = 16;
			}
			this.SetColor(g, 0);
			g.FillRect(0, 0, 240, 240);
			try
			{
				this.g3d = g;
			}
			catch (Exception)
			{
				return;
			}
			this.g3d.SetScreenCenter(0, 0);
			this.g3d.SetPrimitiveTextureArray(this.mimg);
			this.g3d.SetPrimitiveTexture(0);
			this.g3d.EnableSemiTransparent(true);
			int num7 = 0;
			for (i = 0; i < num6; i++)
			{
				for (int j = 0; j < num5; j++)
				{
					if (num + j < this.mapw && num2 + i < this.maph)
					{
						int num8 = ((int)this.mapdat[(num2 + i) * this.mapw + (num + j)] + 256) & 255;
						if (num8 < this.mip)
						{
							int num9 = num8 % 15;
							int num10 = num8 / 15;
							int num11 = j * 16 - num3 + 8 + this.qux;
							int num12 = i * 16 - num4 + 8 + this.quy;
							if (0 <= num11 + 16 && 0 <= num12 + 16 && num11 <= px + 256 && num12 <= py + 256)
							{
								this.map_pa.GetVertexArray()[num7 * 3] = num11;
								this.map_pa.GetVertexArray()[1 + num7 * 3] = num12;
								this.map_pa.GetVertexArray()[2 + num7 * 3] = 0;
								this.map_pa.GetPointSpriteArray()[num7 * 8] = 16;
								this.map_pa.GetPointSpriteArray()[1 + num7 * 8] = 16;
								this.map_pa.GetPointSpriteArray()[2 + num7 * 8] = 2048;
								this.map_pa.GetPointSpriteArray()[3 + num7 * 8] = num9 * 17;
								this.map_pa.GetPointSpriteArray()[4 + num7 * 8] = num10 * 17;
								this.map_pa.GetPointSpriteArray()[5 + num7 * 8] = num9 * 17 + 16;
								this.map_pa.GetPointSpriteArray()[6 + num7 * 8] = num10 * 17 + 16;
								this.map_pa.GetPointSpriteArray()[7 + num7 * 8] = 1;
								num7++;
							}
						}
					}
				}
				if (i == num6 / 2 - 1 && num7 > 0)
				{
					try
					{
						this.g3d.RenderPrimitives(this.map_pa, 0, num7, 0);
					}
					catch (ArgumentException)
					{
						return;
					}
					num7 = 0;
				}
			}
			if (num7 > 0)
			{
				try
				{
					this.g3d.RenderPrimitives(this.map_pa, 0, num7, 0);
				}
				catch (ArgumentException)
				{
					return;
				}
			}
			try
			{
				this.g3d.Flush();
			}
			catch (Exception)
			{
				this.debugstr = "error:flush";
			}
		}
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x000EEED8 File Offset: 0x000ED0D8
	public virtual void DrawTrap(StGraphics g)
	{
		for (int i = 0; i < this.xscr.trap_p; i++)
		{
			int num = this.xscr.trap_xy[i][0] - this.mapx;
			int num2 = this.xscr.trap_xy[i][1] - this.mapy;
			if (num >= -16 && num + 16 <= 256 && num2 >= -16 && num2 + 16 <= 256)
			{
				switch (this.xscr.trap_id[i])
				{
				case 0:
					this.DrawImage(g, this.mcimg[54], num, num2, 0);
					break;
				case 3:
					this.DrawImage(g, this.mcimg[57], num, num2, 0);
					break;
				case 4:
					if (this.chc == 0 || this.chc == 7)
					{
						this.DrawImage(g, this.mcimg[58], num, num2, 0);
					}
					break;
				case 5:
					if (this.chc == 0 || this.chc == 7)
					{
						this.DrawImage(g, this.mcimg[59], num, num2, 0);
					}
					break;
				}
			}
		}
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x000EF000 File Offset: 0x000ED200
	public virtual void DrawTrapDmage(StGraphics g)
	{
		int num = this.chx - this.mapx;
		int num2 = this.chy - this.mapy - 24;
		if (num2 <= 0)
		{
			num2 += 32;
		}
		switch (this.trapdmg)
		{
		case 0:
			if (num2 - 32 <= 0)
			{
				num2 += 8;
			}
			this.DrawImage(g, this.bimg[50], num - 8, num2 - 16, 0);
			return;
		case 1:
		case 2:
			break;
		case 3:
			this.DrawNumSpr(g, 10, num - 3, num2 - 8, 1, 1, false, 2);
			return;
		case 4:
			this.DrawNumSpr(g, 30, num, num2 - 8, 1, 1, false, 2);
			return;
		case 5:
			this.DrawNumSpr(g, 60, num, num2 - 8, 1, 1, false, 2);
			break;
		default:
			return;
		}
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x000EF0B8 File Offset: 0x000ED2B8
	public virtual void BattleFadeInit()
	{
		this.red = true;
		if (this.bfadeimg != null)
		{
			this.SetFont(this.bfadeg, 0);
			this.bfadeg.SetClip(0, 0, 240, 240);
			this.Game_paint(this.bfadeg, false);
		}
		this.lasf = 1;
		this.lasw = 0;
		if (this.battle_fade == 2)
		{
			this.lasw = 100;
		}
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x000EF12A File Offset: 0x000ED32A
	public virtual void BattleFadeStop()
	{
		this.lasf = 0;
		this.lasw = 0;
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x000EF13C File Offset: 0x000ED33C
	public virtual void DrawBattleIn(StGraphics g)
	{
		if (this.lasf == 0)
		{
			return;
		}
		if (this.bfadeimg == null)
		{
			return;
		}
		try
		{
			for (int i = 0; i < 240; i++)
			{
				int num = Math3D.Sin((i + this.sync) * 64) * this.lasw / 4096;
				int num2 = 240;
				this.DrawRegion(g, this.bfadeimg, 0, i, num2, 1, 0, num, i, 0);
			}
		}
		catch (Exception)
		{
			this.lasf = 0;
		}
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x000EF1C8 File Offset: 0x000ED3C8
	public virtual void PartLasterStart()
	{
		this.plasf = 1;
		this.plasw = 0;
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x000EF1D8 File Offset: 0x000ED3D8
	public virtual void PartLasterWorkClear()
	{
		this.plasf = 0;
		this.plasw = 0;
		for (int i = 0; i < 4; i++)
		{
			this.plasxy[i] = 0;
		}
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x000EF208 File Offset: 0x000ED408
	public virtual void SetPartLaster(int y)
	{
		this.plasxy[0] = 0;
		this.plasxy[1] = y * 16;
		this.plasxy[2] = 240;
		this.plasxy[3] = 48;
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x000EF236 File Offset: 0x000ED436
	public virtual void SetPartLaster2(int x, int y)
	{
		this.plasxy[0] = x * 16;
		this.plasxy[1] = y * 16;
		this.plasxy[2] = 48;
		this.plasxy[3] = 48;
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x000EF264 File Offset: 0x000ED464
	public virtual void PartLasterEnd()
	{
		if (this.plasf == 0)
		{
			return;
		}
		this.plasf = 3;
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x000EF278 File Offset: 0x000ED478
	public virtual void PartLasterRoutine()
	{
		if (this.plasf == 0)
		{
			return;
		}
		if (this.plasf == 1)
		{
			this.plasw++;
			if (this.plasw >= 32)
			{
				this.plasw = 32;
				this.plasf = 2;
				return;
			}
		}
		else if (this.plasf == 3)
		{
			this.plasw--;
			if (this.plasw <= 0)
			{
				this.red = true;
				this.compred = true;
				this.plasw = 0;
				this.plasf = 0;
			}
		}
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x000EF2FC File Offset: 0x000ED4FC
	public virtual void DrawPartLaster(StGraphics g)
	{
		if (this.plasf == 0)
		{
			return;
		}
		if (this.bfadeimg == null)
		{
			return;
		}
		int num = this.plasxy[0] - this.mapx;
		int num2 = this.plasxy[1] - this.mapy;
		int num3 = this.plasxy[2];
		int num4 = this.plasxy[3];
		this.red = true;
		this.compred = true;
		this.sysred = true;
		try
		{
			g.SetClip(num - 16, num2, num3 + 32, num4);
			for (int i = 0; i < num4 - 1; i++)
			{
				int num5;
				if (i <= num4 / 2)
				{
					num5 = this.plasw * (i * 100 / (num4 / 2)) / 100;
				}
				else
				{
					num5 = this.plasw * ((num4 - i) * 100 / (num4 / 2)) / 100;
				}
				int num6 = Math3D.Sin((i * 4 + this.sync) * 64) * num5 / 4096;
				this.DrawRegion(g, this.bfadeimg, num, i + num2, num3, 1, 0, num + num6, num2 + i, 0);
			}
			g.SetClip(0, 0, 240, 240);
		}
		catch (Exception)
		{
			g.SetClip(0, 0, 240, 240);
			this.plasf = 0;
			this.debugstr = "error:laster draw";
		}
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x000EF444 File Offset: 0x000ED644
	public virtual void DrawSpLaser(StGraphics g)
	{
		if (this.slf == 0)
		{
			return;
		}
		int num = this.slxy[0] - this.mapx;
		int num2 = this.slxy[1] - this.mapy;
		int num3 = this.slxy[2] - this.mapx;
		int num4 = this.slxy[3] - this.mapy;
		if (this.slf == 1)
		{
			this.SetColor(g, 16711680);
			this.DrawLine(g, num - 1, num2, num3 - 1, num4);
			this.DrawLine(g, num + 1, num2, num3 + 1, num4);
			this.SetColor(g, 16776960);
			this.DrawLine(g, num, num2, num3, num4);
			return;
		}
		if (this.slf == 2)
		{
			this.SetColor(g, 16777215);
			int num5 = this.slxy[2] + this.GetRand(-2, 2);
			if (num5 < 0)
			{
				num5 = 0;
			}
			this.FillArc(g, num - num5 / 2, num2 - num5 / 2, num5, num5, 0, 360);
			for (int i = 0; i < 20; i++)
			{
				if (this.starxy[i][0] != 0 && this.starxy[i][1] != 0 && this.starxy[i][3] != 0)
				{
					this.FillArc(g, num + this.starxy[i][0], num2 + this.starxy[i][1], 2, 2, 0, 360);
				}
			}
		}
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x000EF590 File Offset: 0x000ED790
	public virtual void LaserRoutine()
	{
		if (this.slf == 0)
		{
			return;
		}
		this.red = true;
		this.compred = true;
		if (this.slf == 1)
		{
			this.slwk[4]++;
			int num = this.slxy[0];
			int num2 = this.slxy[1];
			int num3;
			int num4;
			if (this.slwk[4] >= 5)
			{
				num3 = this.slwk[0];
				num4 = this.slwk[1];
				if (this.slwk[4] >= 6)
				{
					this.slf = 0;
				}
			}
			else
			{
				num3 = num + this.slwk[2] * this.slwk[4];
				num4 = num2 + this.slwk[3] * this.slwk[4];
			}
			this.slxy[2] = num3;
			this.slxy[3] = num4;
			return;
		}
		if (this.slf == 2)
		{
			bool flag = false;
			for (int i = 0; i < 20; i++)
			{
				if (this.starxy[i][0] == 0 && this.starxy[i][1] == 0 && !flag)
				{
					this.starxy[i][2] = this.GetRand(0, 359);
					this.starxy[i][3] = 24;
					this.starxy[i][0] = Math3D.Cos(this.starxy[i][2] * 11) * this.starxy[i][3] / 4096;
					this.starxy[i][1] = Math3D.Sin(this.starxy[i][2] * 11) * this.starxy[i][3] / 4096;
					flag = true;
				}
				else if (this.starxy[i][0] != 0 && this.starxy[i][1] != 0 && this.starxy[i][3] != 0)
				{
					this.starxy[i][0] = Math3D.Cos(this.starxy[i][2] * 11) * this.starxy[i][3] / 4096;
					this.starxy[i][1] = Math3D.Sin(this.starxy[i][2] * 11) * this.starxy[i][3] / 4096;
					this.starxy[i][3]--;
					if (this.starxy[i][3] <= 0)
					{
						this.starxy[i][0] = 0;
						this.starxy[i][1] = 0;
						this.starxy[i][2] = 0;
						this.starxy[i][3] = 0;
					}
				}
			}
			this.slxy[2]++;
			if (this.slxy[2] >= 16)
			{
				this.slxy[2] = 16;
			}
		}
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x000EF818 File Offset: 0x000EDA18
	public virtual void DrawDestruction(StGraphics g)
	{
		if (this.dflag == 0)
		{
			return;
		}
		if (this.dflag == 1)
		{
			int num = this.dwk[0][0];
			int num2 = this.dwk[0][1];
			this.DrawImage(g, this.mcimg[60], num, num2, 0);
		}
		else if (this.dflag <= 5)
		{
			for (int i = 0; i < 6; i++)
			{
				int num = this.dwk[i][0];
				int num2 = this.dwk[i][1];
				this.DrawImage(g, this.mcimg[60], num, num2, 0);
			}
		}
		if (this.dflag > 4 && this.dflag <= 8)
		{
			for (int j = 6; j < 10; j++)
			{
				int num = this.dwk[j][0];
				int num2 = this.dwk[j][1];
				this.DrawImage(g, this.mcimg[60], num, num2, 0);
			}
		}
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x000EF8E8 File Offset: 0x000EDAE8
	public virtual void DestructionRoutine()
	{
		if (this.dflag == 0)
		{
			return;
		}
		int num = 32;
		int num2 = 32;
		num /= 8;
		num2 /= 8;
		this.red = true;
		this.compred = true;
		if (this.dflag > 1 && this.dflag <= 5)
		{
			this.dwk[0][0] -= num * 2;
			this.dwk[0][1] -= num2 / 2;
			this.dwk[1][0] -= num;
			this.dwk[1][1] -= num2;
			this.dwk[2][0] -= num / 2;
			this.dwk[2][1] -= num2 * 2;
			this.dwk[3][0] += num / 2;
			this.dwk[3][1] -= num2 * 2;
			this.dwk[4][0] += num;
			this.dwk[4][1] -= num2;
			this.dwk[5][0] += num * 2;
			this.dwk[5][1] -= num2 / 2;
		}
		if (this.dflag > 4 && this.dflag <= 8)
		{
			this.dwk[6][0] -= num * 2;
			this.dwk[6][1] -= num2;
			this.dwk[7][0] -= num;
			this.dwk[7][1] -= num2 * 2;
			this.dwk[8][0] += num;
			this.dwk[8][1] -= num2 * 2;
			this.dwk[9][0] += num * 2;
			this.dwk[9][1] -= num2;
		}
		this.dflag++;
		if (this.dflag > 8)
		{
			this.dflag = 0;
		}
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x000EFAFE File Offset: 0x000EDCFE
	public virtual bool DataFolderCheck()
	{
		return XenoPP06Canvas.LoadRecord(16) >= 4;
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x000EFB10 File Offset: 0x000EDD10
	public virtual int DataWebDownOne(int no)
	{
		HttpConnection httpConnection = null;
		sbyte[] array = null;
		int num = 1542;
		num += 102400 * no;
		string[] array2 = new string[9];
		array2[0] = this.parent.downloadurl;
		array2[1] = this.parent.res_dir;
		array2[2] = "xenosagapp";
		array2[3] = 6.ToString();
		array2[4] = "_";
		array2[5] = this.parent.res_name;
		array2[6] = "_0";
		array2[7] = no.ToString();
		array2[8] = ".dat?uid=NULLGWDOCOMO";
		string text = string.Concat(array2);
		int num2;
		if (no == 3)
		{
			num2 = 93095;
		}
		else
		{
			num2 = 102400;
		}
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream(5120);
		int num3 = 0;
		int num4 = 0;
		sbyte[] array3 = new sbyte[32];
		try
		{
			httpConnection = Connector.Open(text, Connector.READ, true);
			try
			{
				httpConnection.SetRequestMethod(HttpConnection.GET);
				httpConnection.Connect();
				int responseCode = httpConnection.GetResponseCode();
				if (responseCode < 200 || 300 <= responseCode)
				{
					throw new Exception("response error:" + responseCode.ToString());
				}
				InputStream inputStream = httpConnection.OpenInputStream();
				try
				{
					int num5;
					while ((num5 = inputStream.Read(array3)) >= 0)
					{
						byteArrayOutputStream.Write(array3, 0, num5);
						num4 += num5;
					}
					inputStream.Close();
					byteArrayOutputStream.Close();
					array = byteArrayOutputStream.ToSByteArray();
					if (num4 == num2)
					{
						int num6 = (int)array[0];
						if (num6 < 0)
						{
							num6 += 256;
						}
						int num7 = (int)array[num4 - 1];
						if (num7 < 0)
						{
							num7 += 256;
						}
						num3 = 0;
					}
					else
					{
						num3 = 3;
					}
				}
				catch (Exception)
				{
					num3 = 4;
				}
			}
			catch (IOException ex)
			{
				if (ex.Message.Equals("network locked"))
				{
					num3 = 2;
				}
				else
				{
					num3 = 5;
				}
			}
			catch (Exception)
			{
				num3 = 6;
			}
		}
		catch (Exception)
		{
			num3 = 7;
		}
		finally
		{
			if (httpConnection != null)
			{
				try
				{
					httpConnection.Close();
				}
				catch (Exception)
				{
				}
			}
		}
		if (num3 == 0)
		{
			try
			{
				OutputStream outputStream = Connector.OpenOutputStream("scratchpad:///14;pos=" + num.ToString());
				outputStream.Write(array, 0, array.Length);
				outputStream.Close();
			}
			catch (Exception)
			{
				return -1;
			}
			return num3;
		}
		return num3;
	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x000EFD74 File Offset: 0x000EDF74
	public virtual void DataReadRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.WorkClear();
			this.MenuFlagClear();
			this.isupdate = true;
			this.SetSeqStep(1);
			this.red = true;
			return;
		case 1:
			this.red = true;
			this.work[3] = 0;
			this.work[4] = 232;
			this.work[5] = 0;
			this.SetSeqStep(9);
			return;
		case 2:
			if (this.work[0] == 0)
			{
				this.work[0] = 1;
			}
			if (this.work[0] == 1)
			{
				int num = this.DataWebDownOne(this.work[1]);
				if (num == 0)
				{
					this.work[1]++;
					XenoPP06Canvas.StoreRecord(16, this.work[1]);
					if (this.work[1] >= this.work[2])
					{
						this.work[0] = 2;
					}
				}
				else if (num == 2)
				{
					this.SetMenu(4);
					this.SetSeqStep(4);
				}
				else
				{
					this.SetMenu(8);
					this.SetSeqStep(3);
				}
			}
			if (this.work[0] == 2)
			{
				this.WorkClear();
				this.work[3] = 0;
				this.work[4] = 232;
				this.work[5] = 0;
				this.SetSeqStep(9);
			}
			this.red = true;
			return;
		case 3:
			if (this.ismenu[1])
			{
				this.MenuFlagClear();
				this.SetMenu(4);
				this.SetSeqStep2(2);
				return;
			}
			break;
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			break;
		case 9:
			if (this.work[0] == 0)
			{
				this.SetLoading(true);
				this.work[0] = 1;
				this.work[1] = 0;
				if (this.work[5] != 3)
				{
					this.readbuf = null;
				}
				if (this.work[5] == 0)
				{
					this.readbuf = this.GetResource2(35);
					this.work[2] = 99;
				}
				else if (this.work[5] == 1)
				{
					this.readbuf = this.GetResource2(18);
					this.work[2] = 29;
				}
				else if (this.work[5] == 2)
				{
					this.readbuf = this.GetResource2(1);
					this.work[2] = 70;
				}
				else if (this.work[5] == 3)
				{
					this.work[2] = 1;
				}
				else if (this.work[5] == 4)
				{
					this.readbuf = this.GetResource2(80);
					this.work[2] = 15;
				}
				else if (this.work[5] == 5)
				{
					this.readbuf = this.GetResource2(81);
					this.work[2] = 4;
				}
				else
				{
					this.readbuf = this.GetResource2(66 + this.work[5] - 6);
					this.work[2] = 1;
				}
			}
			if (this.work[0] == 1)
			{
				int num2 = this.work[1];
				int[] array;
				if (this.work[5] < 5)
				{
					array = XenoPP06Canvas.GetArchive2(this.readbuf, num2);
				}
				else if (this.work[5] == 5)
				{
					array = XenoPP06Canvas.GetArchive2(this.readbuf, num2 + 15);
				}
				else
				{
					array = XenoPP06Canvas.GetArchive2(this.readbuf, 0);
				}
				int num3 = array[0];
				int num4 = array[1];
				if (this.work[5] == 0)
				{
					this.sysimg[num2] = this.BuildImage(this.readbuf, num3, num4);
				}
				else if (this.work[5] == 1)
				{
					this.faceimg[num2] = this.BuildImage(this.readbuf, num3, num4);
				}
				else if (this.work[5] == 2)
				{
					this.bimg[num2] = this.BuildImage(this.readbuf, num3, num4);
				}
				else if (this.work[5] == 3)
				{
					this.mimg = new StTexture(this.GetResource2(0), false);
				}
				else
				{
					if (this.work[5] == 4)
					{
						sbyte[] array2 = new sbyte[array[1]];
						Array.Copy(this.readbuf, array[0], array2, 0, array[1]);
						try
						{
							this.se[num2] = this.BuildSound(this.readbuf, num3, num4);
							goto IL_047E;
						}
						catch (Exception)
						{
							goto IL_047E;
						}
					}
					if (this.work[5] == 5)
					{
						sbyte[] array3 = new sbyte[array[1]];
						Array.Copy(this.readbuf, array[0], array3, 0, array[1]);
						try
						{
							this.se[num2 + 15] = this.BuildSound(this.readbuf, num3, num4);
							goto IL_047E;
						}
						catch (Exception)
						{
							goto IL_047E;
						}
					}
					sbyte[] array4 = new sbyte[array[1]];
					Array.Copy(this.readbuf, array[0], array4, 0, array[1]);
					try
					{
						this.bgm[this.work[5] - 6] = this.BuildSound(this.readbuf, num3, num4);
					}
					catch (Exception)
					{
					}
				}
				IL_047E:
				this.work[3]++;
				this.work[1]++;
				if (this.work[1] >= this.work[2])
				{
					this.work[0] = 0;
					this.work[5]++;
					if (this.work[5] >= 20)
					{
						this.readbuf = null;
						this.SetLoading(false);
						this.work[3] = this.work[4];
						this.SetSeqStep(10);
						return;
					}
				}
			}
			break;
		case 10:
			this.fps_wait = this.parent.afps_wait;
			this.WorkClear();
			this.SetSeqStep(11);
			return;
		case 11:
			this.isupdate = false;
			this.SetSeqNo(12);
			break;
		default:
			return;
		}
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x000F02D8 File Offset: 0x000EE4D8
	public virtual void DrawPlayer(StGraphics g)
	{
		int num = this.chx - this.mapx;
		int num2 = this.chy - this.mapy;
		if (-16 < num && num < 272 && 0 < num2 && num2 < 276)
		{
			int num3;
			if ((this.chm & 32768) != 0)
			{
				num3 = this.chc + (this.chm & -32769);
				this.DrawRegion(g, this.mcimg[num3], 0, 0, 16, 24, 1, num - 8, num2 - 24, 0);
				return;
			}
			num3 = this.chc + this.chm;
			this.DrawImage(g, this.mcimg[num3], num - 8, num2 - 24, 0);
		}
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x000F0380 File Offset: 0x000EE580
	public virtual void DrawNpcChar(StGraphics g, bool f)
	{
		int num = this.chx;
		int num2 = this.mapx;
		int num3 = this.chy - this.mapy;
		for (int i = 0; i < this.xscr.npc_p; i++)
		{
			bool flag = false;
			int num4 = this.xscr.npc_xy[i][0] - this.mapx;
			int num5 = this.xscr.npc_xy[i][1] - this.mapy;
			if (this.xscr.npc_pn[i][0] != 65534 && this.xscr.npc_pn[i][1] != 65535 && -16 < num4 && num4 < 272 && 0 < num5 && num5 < 296)
			{
				if (!f)
				{
					if (num5 <= num3)
					{
						flag = true;
					}
				}
				else if (num5 > num3)
				{
					flag = true;
				}
				if (flag)
				{
					if ((this.xscr.npc_pn[i][1] & 32768) != 0)
					{
						int num6 = this.xscr.npc_pn[i][1] & -32769;
						int width = this.mcimg[num6].GetWidth();
						int height = this.mcimg[num6].GetHeight();
						this.DrawRegion(g, this.mcimg[num6], 0, 0, width, height, 1, num4 - 8, num5 - 24, 0);
					}
					else
					{
						this.DrawImage(g, this.mcimg[this.xscr.npc_pn[i][1]], num4 - 8, num5 - 24, 0);
					}
				}
			}
		}
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x000F0504 File Offset: 0x000EE704
	public virtual void DrawScrObj(StGraphics g, int f)
	{
		for (int i = 0; i < this.xscr.tobj_p; i++)
		{
			if (this.xscr.tobj_cno[i] != 2 && this.xscr.tobj_pn[i] != 254 && this.xscr.tobj_pn[i] != 255)
			{
				int num = this.xscr.tobj_xy[i][0] - this.mapx;
				int num2 = this.xscr.tobj_xy[i][1] - this.mapy;
				this.DrawScrObjOne(g, num, num2, 0, this.xscr.tobj_pn[i], f);
			}
			else if (this.xscr.tobj_cno[i] == 2 && this.xscr.tobj_pn[i] != 254 && this.xscr.tobj_pn[i] != 255 && f == 0 && (this.chc == 28 || this.chc == 35))
			{
				int num = this.xscr.tobj_xy[i][0];
				int num2 = this.xscr.tobj_xy[i][1];
				if (num > this.chx || this.chx > num + 16 || num2 > this.chy - 1 || this.chy - 4 > num2 + 16)
				{
					int num3 = this.chx - this.mapx;
					int num4 = this.chy - this.mapy;
					int num5 = this.xscr.tobj_pn[i];
					int num6 = 0;
					int num7 = 0;
					int num8 = 16;
					int num9 = 16;
					num = this.xscr.tobj_xy[i][0] - this.mapx;
					num2 = this.xscr.tobj_xy[i][1] - this.mapy;
					if (this.chm == 32769 || this.chm == 1 || this.chm == 0)
					{
						if (num3 - 24 - 16 <= num && num + 16 <= num3 + 24 + 16 && num4 <= num2 && num2 + 16 <= num4 + 48 + 16)
						{
							if (num3 - 24 > num)
							{
								num6 = num3 - 24 - num;
							}
							else if (num + 16 > num3 + 24)
							{
								num8 = num + 16 - (num3 + 24);
							}
							if (num2 + 16 > num4 + 48)
							{
								num9 = 16 - (num2 + 16 - (num4 + 48));
							}
							this.DrawRegion(g, this.mcimg[num5], num6, num7, num8 - num6, num9 - num7, 0, num + num6, num2 + num7, 0);
						}
					}
					else if (this.chm == 4 || this.chm == 3 || this.chm == 2)
					{
						if (num3 <= num && num + 16 <= num3 + 56 + 16 && num4 - 24 - 16 <= num2 && num2 + 16 <= num4 + 24 + 16)
						{
							if (num4 - 24 > num2)
							{
								num7 = num4 - 24 - num2;
							}
							else if (num2 + 16 > num4 + 24)
							{
								num9 = num2 + 16 - (num4 + 24);
							}
							if (num + 16 > num3 + 56)
							{
								num8 = 16 - (num + 16 - (num3 + 56));
							}
							this.DrawRegion(g, this.mcimg[num5], num6, num7, num8 - num6, num9 - num7, 0, num + num6, num2 + num7, 0);
						}
					}
					else if (this.chm == 32774 || this.chm == 6 || this.chm == 5)
					{
						if (num3 - 24 - 16 <= num && num + 16 <= num3 + 24 + 16 && num4 - 48 - 16 <= num2 && num2 + 16 <= num4)
						{
							if (num3 - 24 > num)
							{
								num6 = num3 - 24 - num;
							}
							else if (num + 16 > num3 + 24)
							{
								num8 = num + 16 - (num3 + 24);
							}
							if (num4 - 48 > num2)
							{
								num7 = num4 - 48 - num2;
							}
							this.DrawRegion(g, this.mcimg[num5], num6, num7, num8 - num6, num9 - num7, 0, num + num6, num2 + num7, 0);
						}
					}
					else if ((this.chm == 32772 || this.chm == 32771 || this.chm == 32770) && num3 - 56 - 16 <= num && num + 16 <= num3 && num4 - 24 - 16 <= num2 && num2 + 16 <= num4 + 24 + 16)
					{
						if (num4 - 24 > num2)
						{
							num7 = num4 - 24 - num2;
						}
						else if (num2 + 16 > num4 + 24)
						{
							num9 = num2 + 16 - (num4 + 24);
						}
						if (num3 - 56 > num)
						{
							num6 = num3 - 56 - num;
						}
						this.DrawRegion(g, this.mcimg[num5], num6, num7, num8 - num6, num9 - num7, 0, num + num6, num2 + num7, 0);
					}
				}
			}
		}
		for (int i = 0; i < this.xscr.obj_p; i++)
		{
			if (this.xscr.obj_pn[i] != 255)
			{
				int num = this.xscr.obj_xy[i][0] - this.mapx;
				int num2 = this.xscr.obj_xy[i][1] - this.mapy;
				if ((this.xscr.obj_pn[i] & 65536) != 0)
				{
					this.DrawScrObjFade(g, num, num2, this.xscr.obj_prio[i], this.xscr.obj_pn[i], this.xscr.obj_wk[i][1], f);
				}
				else
				{
					this.DrawScrObjOne(g, num, num2, this.xscr.obj_prio[i], this.xscr.obj_pn[i], f);
				}
			}
		}
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x000F0A94 File Offset: 0x000EEC94
	public virtual void DrawScrObjOne(StGraphics g, int x, int y, int pr, int pn, int f)
	{
		int num;
		if (this.GetSeqNo() == 9)
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		int num2 = this.chx;
		int num3 = this.mapx;
		int num4 = this.chy - this.mapy;
		int num5;
		if ((pn & 32768) != 0)
		{
			num5 = pn & -32769;
		}
		else
		{
			num5 = pn;
		}
		int num6;
		int num7;
		if (num == 0)
		{
			num6 = this.mcimg[num5].GetWidth();
			num7 = this.mcimg[num5].GetHeight();
		}
		else
		{
			num6 = this.vimg[num5].GetWidth();
			num7 = this.vimg[num5].GetHeight();
		}
		bool flag = false;
		if (((-32 < x && x < 240) || (-32 < x + num6 && x + num6 < 240)) && ((-32 < y && y < 240) || (-32 < y + num7 && y + num7 < 240)))
		{
			if (f == 0)
			{
				if ((y + num7 <= num4 && pr == 0) || pr == 1)
				{
					flag = true;
				}
			}
			else if (f == 1)
			{
				if ((y + num7 > num4 && pr == 0) || pr == 2)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (num == 0)
				{
					if ((pn & 32768) != 0)
					{
						this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, num7, 1, x, y, 0);
						return;
					}
					this.DrawImage(g, this.mcimg[num5], x, y, 0);
					return;
				}
				else
				{
					if ((pn & 32768) != 0)
					{
						this.DrawRegion(g, this.vimg[num5], 0, 0, num6, num7, 1, x, y + this.xscr.sc_drawy, 0);
						return;
					}
					this.DrawImage(g, this.vimg[num5], x, y + this.xscr.sc_drawy, 0);
				}
			}
		}
	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x000F0C30 File Offset: 0x000EEE30
	public virtual void DrawScrObjFade(StGraphics g, int x, int y, int pr, int pn, int dh, int f)
	{
		int num;
		if (this.GetSeqNo() == 9)
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		int num2 = this.chx;
		int num3 = this.mapx;
		int num4 = this.chy - this.mapy;
		int num5;
		if ((pn & 32768) != 0)
		{
			num5 = pn & -32769;
		}
		else
		{
			num5 = pn;
		}
		if ((num5 & 65536) != 0)
		{
			num5 &= -65537;
		}
		else
		{
			num5 = num5;
		}
		int num6;
		int num7;
		if (num == 0)
		{
			num6 = this.mcimg[num5].GetWidth();
			num7 = this.mcimg[num5].GetHeight();
		}
		else
		{
			num6 = this.vimg[num5].GetWidth();
			num7 = this.vimg[num5].GetHeight();
		}
		bool flag = false;
		if (((-32 < x && x < 240) || (-32 < x + num6 && x + num6 < 240)) && ((-32 < y && y < 240) || (-32 < y + num7 && y + num7 < 240)))
		{
			if (f == 0)
			{
				if ((y + num7 <= num4 && pr == 0) || pr == 1)
				{
					flag = true;
				}
			}
			else if (f == 1)
			{
				if ((y + num7 > num4 && pr == 0) || pr == 2)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (this.mapno != 4 && this.pfflag != 5)
				{
					if (this.pfflag == 3)
					{
						this.SetPngFadeEffect(x, y + num7 - dh, y);
					}
					else if (this.pfflag == 4)
					{
						this.SetPngFadeEffect(x, y + num7 - dh, y + num7);
					}
					else
					{
						this.SetPngFadeEffect(x, y + num7 - dh, num6);
						if (this.pfflag == 2)
						{
							this.SetPngFadeEffect(x, y + num7 - dh, num6);
							this.SetPngFadeEffect(x, y + num7 - dh, num6);
						}
					}
				}
				if (num == 0)
				{
					if (this.pfflag == 3 || this.pfflag == 4)
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, num7 - dh, 1, x, y, 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, num7 - dh, 0, x, y, 0);
						return;
					}
					else if (this.pfflag == 5)
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, dh, 1, x, y + (num7 - dh), 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, dh, 0, x, y + (num7 - dh), 0);
						return;
					}
					else
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], 0, num7 - dh, num6, dh, 1, x, y + (num7 - dh), 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], 0, num7 - dh, num6, dh, 0, x, y + (num7 - dh), 0);
						return;
					}
				}
				else
				{
					if ((pn & 32768) != 0)
					{
						this.DrawRegion(g, this.vimg[num5], 0, num7 - dh, num6, dh, 1, x, y + (num7 - dh) + this.xscr.sc_drawy, 0);
						return;
					}
					this.DrawRegion(g, this.vimg[num5], 0, num7 - dh, num6, dh, 0, x, y + (num7 - dh) + this.xscr.sc_drawy, 0);
				}
			}
		}
	}

	// Token: 0x06000BD2 RID: 3026 RVA: 0x000F0F2C File Offset: 0x000EF12C
	public virtual void PngFadeInit(int flg)
	{
		this.StarWorkInit();
		this.pfflag = flg;
	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x000F0F3B File Offset: 0x000EF13B
	public virtual void PngFadeStop()
	{
		this.pfflag = 0;
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x000F0F44 File Offset: 0x000EF144
	public virtual void PngFadeRoutine()
	{
		if (this.pfflag == 0)
		{
			return;
		}
		if (this.pfflag == 1)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
				{
					this.starxy[i][1]--;
					this.starxy[i][2] += 6;
					this.starxy[i][3]--;
					if (this.starxy[i][3] <= 0)
					{
						this.starxy[i][0] = (this.starxy[i][1] = (this.starxy[i][2] = (this.starxy[i][3] = 0)));
					}
				}
			}
			return;
		}
		if (this.pfflag == 2)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
				{
					this.starxy[i][1] += 3;
					this.starxy[i][2]--;
					this.starxy[i][3]--;
					if (this.starxy[i][3] <= 0)
					{
						this.starxy[i][0] = (this.starxy[i][1] = (this.starxy[i][2] = (this.starxy[i][3] = 0)));
					}
				}
			}
			return;
		}
		if (this.pfflag == 3)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][3] != 0)
				{
					this.starxy[i][1] -= 6;
					this.starxy[i][3]--;
					if (this.starxy[i][3] <= 0)
					{
						this.starxy[i][0] = (this.starxy[i][1] = (this.starxy[i][3] = 0));
					}
				}
			}
			return;
		}
		if (this.pfflag == 4)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][3] != 0)
				{
					this.starxy[i][1] += 6;
					this.starxy[i][3]--;
					if (this.starxy[i][3] <= 0)
					{
						this.starxy[i][0] = (this.starxy[i][1] = (this.starxy[i][3] = 0));
					}
				}
			}
		}
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x000F11B0 File Offset: 0x000EF3B0
	public virtual void SetPngFadeEffect(int x, int y, int w)
	{
		if (this.pfflag == 1)
		{
			int num = this.GetRand(x, x + w);
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0)
				{
					this.starxy[i][0] = num;
					this.starxy[i][1] = y;
					this.starxy[i][2] = this.GetRand(0, 359);
					this.starxy[i][3] = 25;
					return;
				}
			}
			return;
		}
		if (this.pfflag == 2)
		{
			int num = this.GetRand(x, x + w);
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0)
				{
					this.starxy[i][0] = num;
					this.starxy[i][1] = y;
					this.starxy[i][2] = 5;
					this.starxy[i][3] = 5;
					return;
				}
			}
			return;
		}
		if (this.pfflag == 3)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][3] == 0)
				{
					this.starxy[i][0] = x;
					this.starxy[i][1] = y;
					this.starxy[i][2] = w;
					this.starxy[i][3] = 50;
					return;
				}
			}
			return;
		}
		if (this.pfflag == 4)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][3] == 0)
				{
					this.starxy[i][0] = x;
					this.starxy[i][1] = y;
					this.starxy[i][2] = w;
					this.starxy[i][3] = 50;
					return;
				}
			}
		}
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x000F1338 File Offset: 0x000EF538
	public virtual void DrawPngFadeEffect(StGraphics g)
	{
		if (this.pfflag == 0)
		{
			return;
		}
		if (this.pfflag == 1)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
				{
					int num = this.starxy[i][0] + Math3D.Sin(this.starxy[i][2] * 32) * (30 - this.starxy[i][3]) / 4096;
					int num2 = this.starxy[i][1];
					if (this.GetRand(0, 1) == 0)
					{
						this.SetColor(g, 0);
					}
					else
					{
						this.SetColor(g, 49152);
					}
					if (this.GetSeqNo() == 9)
					{
						this.FillArc(g, num, num2 + this.xscr.sc_drawy, 2, 2, 0, 360);
					}
					else
					{
						this.FillArc(g, num, num2, 2, 2, 0, 360);
					}
				}
			}
			return;
		}
		if (this.pfflag == 2)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
				{
					int num = this.starxy[i][0];
					int num2 = this.starxy[i][1];
					if (this.GetRand(0, 1) == 0)
					{
						this.SetColor(g, 0);
					}
					else
					{
						this.SetColor(g, 49152);
					}
					int num3 = this.starxy[i][3];
					if (this.GetSeqNo() == 9)
					{
						this.FillArc(g, num, num2 + this.xscr.sc_drawy, 2, 2, 0, 360);
					}
					else
					{
						this.FillArc(g, num, num2, 2, 2, 0, 360);
					}
				}
			}
			return;
		}
		if (this.pfflag == 3)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][3] != 0)
				{
					int num = this.starxy[i][0];
					int num2 = this.starxy[i][1];
					int num3 = this.starxy[i][2];
					this.SetColor(g, 16777215);
					if (num2 >= num3)
					{
						if (this.GetSeqNo() == 9)
						{
							this.FillArc(g, num, num2 + this.xscr.sc_drawy, 16, 4, 0, 360);
						}
						else
						{
							this.FillArc(g, num, num2, 16, 4, 0, 360);
						}
					}
				}
			}
			return;
		}
		if (this.pfflag == 4)
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.starxy[i][3] != 0)
				{
					int num = this.starxy[i][0];
					int num2 = this.starxy[i][1];
					int num3 = this.starxy[i][2];
					this.SetColor(g, 16777215);
					if (num2 + 4 <= num3)
					{
						if (this.GetSeqNo() == 9)
						{
							this.FillArc(g, num, num2 + this.xscr.sc_drawy, 16, 4, 0, 360);
						}
						else
						{
							this.FillArc(g, num, num2, 16, 4, 0, 360);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x000F1604 File Offset: 0x000EF804
	public virtual void DrawMapMenuObj(StGraphics g)
	{
		int[] array = new int[2];
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		array[0] = this.GetSeqStep();
		array[1] = this.work[2];
		for (int i = 0; i < 2; i++)
		{
			int num;
			if (i == 0)
			{
				if (this.work[0] == 0)
				{
					num = 30 * this.work[1] + 12;
				}
				else
				{
					num = 12 - 30 * this.work[1];
				}
			}
			else if (this.work[0] == 0)
			{
				num = 12 - 30 * (8 - this.work[1]);
			}
			else
			{
				num = 30 * (8 - this.work[1]) + 12;
			}
			if ((i != 0 && this.work[1] >= 1) || i == 0)
			{
				if (array[i] == 7)
				{
					this.DrawMapMenuRoot(g, num, i);
				}
				else if (array[i] == 8)
				{
					this.DrawMapMenuItem(g, num, i);
				}
				else if (array[i] == 14 || array[i] == 15 || array[i] == 16 || array[i] == 11 || array[i] == 12)
				{
					this.DrawMapMenuChara(g, num, i);
				}
				else if (array[i] == 9 || array[i] == 10)
				{
					this.DrawMapMenuEther(g, num, i);
				}
				else if (array[i] == 18 || array[i] == 19 || array[i] == 13)
				{
					this.DrawMapMenuEquip(g, num, i);
				}
				else if (array[i] == 20)
				{
					this.DrawMapMenuConfig(g, num, i);
				}
				else if (array[i] == 21 || array[i] == 22)
				{
					this.DrawMapMenuSave(g, num, i);
				}
				else if (array[i] == 23 || array[i] == 24)
				{
					this.DrawMapMenuSave2(g, num, i);
				}
				else if (array[i] == 25 || array[i] == 26)
				{
					this.DrawMapMenuLoad(g, num, i);
				}
				else if (array[i] == 27 || array[i] == 28)
				{
					this.DrawMapMenuLoad2(g, num, i);
				}
			}
		}
		this.red = true;
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x000F17E0 File Offset: 0x000EF9E0
	private void DrawMapMenuRoot(StGraphics g, int x, int j)
	{
		this.DrawWindow(g, x, 80, 216, this.menuroot.Length * 12 + 8);
		for (int i = 0; i < this.menuroot.Length; i++)
		{
			if (j == 1 || i != this.cur[0] || (i == 7 && this.sdflag == 0) || (i == 1 && !this.etheruse))
			{
				this.SetColor(g, 8421504);
			}
			else
			{
				this.SetColor(g, 16777215);
			}
			this.DrawString(g, this.menuroot[i], x + 108, 84 + i * 12, 1);
		}
		if (j == 0)
		{
			this.DrawImage(g, this.sysimg[42], x + 8, 86 + this.cur[0] * 12, 0);
		}
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x000F18A0 File Offset: 0x000EFAA0
	private void DrawMapMenuItem(StGraphics g, int x, int j)
	{
		this.DrawWindow(g, x, 66, 216, 128);
		this.DrawWindow(g, x, 206, 216, 14);
		if (this.mmenup == 0)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "使えるアイテムがありません", x + 108, 70, 1);
		}
		else
		{
			int num;
			for (int i = 0; i < 10; i++)
			{
				num = this.mmenu[this.cur[1] + i];
				if (num != 255)
				{
					if (((this.GetItemData(num, 2) & 4) != 0 || (this.GetItemData(num, 2) & 1) != 0) && (this.GetItemData(num, 2) & 2) == 0)
					{
						this.SetColor(g, 2129952);
					}
					else if (j == 1 || i != this.cur[0] - this.cur[1])
					{
						this.SetColor(g, 8421504);
					}
					else
					{
						this.SetColor(g, 16777215);
					}
					this.DrawString(g, this.mmstr[this.cur[1] + i], x + 24, 68 + i * 12, 0);
					string text = "x" + this.itempc[num][0].ToString();
					this.DrawString(g, text, x + 180, 68 + i * 12, 0);
				}
			}
			num = this.mmenu[this.cur[0]];
			if (num != 255 && j == 0)
			{
				this.SetColor(g, 16777215);
				this.DrawString(g, this.GetItemName(num, 1), x + 24, 207, 0);
			}
		}
		if (j == 0 && this.mmenup != 0)
		{
			this.DrawImage(g, this.sysimg[42], x + 8, 70 + (this.cur[0] - this.cur[1]) * 12, 0);
		}
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x000F1A64 File Offset: 0x000EFC64
	private void DrawMapMenuChara(StGraphics g, int x, int j)
	{
		int[] array = new int[]
		{
			this.GetSeqStep(),
			this.work[2]
		};
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetRanks(i);
			if (num2 != 255)
			{
				this.DrawImage(g, this.bimg[62], x + 12, 4 + num * 59 + 3, 0);
				this.DrawImage(g, this.bimg[1 + num2], x + 12 + 4, 4 + num * 59 + 8, 0);
				string text = string.Empty + (this.GetStatus(num2, 0) + 1).ToString();
				this.SetColor(g, 16777215);
				this.DrawString(g, text, x + 12 + 126, 4 + num * 59 + 4, 0);
				this.DrawString(g, this.PlyName[num2], x + 12 + 35, 4 + num * 59 + 4, 0);
				this.SetColor(g, 4013373);
				this.FillRect(g, x + 12 + 138, 4 + num * 59 + 20, 50, 18);
				this.SetColor(g, 5921370);
				this.FillRect(g, x + 12 + 138, 4 + num * 59 + 42, 50, 18);
				this.SetColor(g, 16776960);
				if (num == 3)
				{
					text = "Reserve";
				}
				else
				{
					text = "Attacker";
				}
				this.DrawString(g, text, x + 12 + 138 + 42, 4 + num * 59 + 44, 2);
				if (num == 0)
				{
					this.DrawString(g, "移動ｷｬﾗ", x + 12 + 138 + 42, 4 + num * 59 + 23, 2);
				}
				this.DrawNumSpr(g, this.GetStatus(num2, 2), x + 12 + 50, 4 + num * 59 + 20, 0, 2, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 3), x + 12 + 80, 4 + num * 59 + 20, 0, 0, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 4), x + 12 + 50, 4 + num * 59 + 30, 0, 2, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 5), x + 12 + 80, 4 + num * 59 + 30, 0, 0, false, 4);
				this.DrawNumSpr(g, this.GetStatus(num2, 15), x + 12 + 86, 4 + num * 59 + 41, 0, 2, false, 5);
				this.DrawNumSpr(g, this.GetStatus(num2, 14), x + 12 + 80, 4 + num * 59 + 50, 0, 2, false, 6);
				num++;
			}
		}
		if (array[j] == 11)
		{
			this.DrawWindow(g, x + 12, 107, 192, 26);
			this.SetColor(g, 16777215);
			this.DrawString(g, "使用しても効果がない", 120, 115, 1);
		}
		else if (array[j] == 12)
		{
			this.DrawWindow(g, x + 12, 107, 192, 26);
			this.SetColor(g, 16777215);
			this.DrawString(g, "使用しても効果がない", 120, 115, 1);
		}
		else if ((array[j] == 15 && j == 0) || (array[j] == 16 && j == 0))
		{
			num = 0;
			if (array[j] == 15)
			{
				if (this.GetItemData(this.work[4], 1) == 5)
				{
					num = 1;
				}
			}
			else if (array[j] == 16 && this.GetPlyEtParam(this.work[5], this.work[6], 1) == 3)
			{
				num = 1;
			}
			if (num == 1)
			{
				num = 0;
				for (int i = 0; i < 4; i++)
				{
					int num2 = this.GetRanks(i);
					if (num2 != 255 && this.GetStatus(num2, 20) != 2)
					{
						int num3 = x + 12 + 12;
						int num4 = 4 + i * 59 + 45;
						if (this.work[13] < 4)
						{
							this.DrawNumSpr(g, this.work[9 + num2], num3, num4 + (3 - this.work[13]) * 2, 3, 1, false, 4);
							if (this.work[4] == 16)
							{
								this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 20, num4 + (3 - this.work[13]) * 2, 3, 1, false, 4);
							}
						}
						else if (this.work[13] < 8)
						{
							this.DrawNumSpr(g, this.work[9 + num2], num3, num4 + (this.work[13] - 4) * 2, 3, 1, false, 4);
							if (this.work[4] == 16)
							{
								this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 20, num4 + (this.work[13] - 4) * 2, 3, 1, false, 4);
							}
						}
						else
						{
							this.DrawNumSpr(g, this.work[9 + num2], num3, num4 + 6, 3, 1, false, 4);
							if (this.work[4] == 16)
							{
								this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 20, num4 + 6, 3, 1, false, 4);
							}
						}
						num++;
					}
				}
			}
			else if (this.work[7] != 65535)
			{
				int num3 = x + 12 + 12;
				int num4 = 4 + this.cur[0] * 59 + 45;
				int num2 = this.GetRanks(this.cur[0]);
				if (this.work[13] < 4)
				{
					this.DrawNumSpr(g, this.work[7], num3, num4 + (3 - this.work[13]) * 2, 3, 1, false, 4);
					if (this.work[4] == 8)
					{
						this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 20, num4 + (3 - this.work[13]) * 2, 3, 1, false, 4);
					}
				}
				else if (this.work[13] < 8)
				{
					this.DrawNumSpr(g, this.work[7], num3, num4 + (this.work[13] - 4) * 2, 3, 1, false, 4);
					if (this.work[4] == 8)
					{
						this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 20, num4 + (this.work[13] - 4) * 2, 3, 1, false, 4);
					}
				}
				else
				{
					this.DrawNumSpr(g, this.work[7], num3, num4 + 6, 3, 1, false, 4);
					if (this.work[4] == 8)
					{
						this.DrawNumSpr(g, this.GetStatus(num2, 5), num3 + 20, num4 + 6, 3, 1, false, 4);
					}
				}
			}
		}
		if (j == 0)
		{
			if (this.work[3] == 8)
			{
				if (this.GetItemData(this.work[4], 1) == 5)
				{
					for (int i = 0; i < 4; i++)
					{
						int num2 = this.GetRanks(i);
						if (num2 != 255 && this.GetStatus(num2, 20) != 2)
						{
							this.DrawImage(g, this.sysimg[42], x + 6, 4 + i * 59 + 26, 0);
						}
					}
					return;
				}
				this.DrawImage(g, this.sysimg[42], x + 6, 4 + this.cur[0] * 59 + 26, 0);
				return;
			}
			else if (this.work[3] == 9)
			{
				if (this.GetPlyEtParam(this.work[5], this.work[6], 1) == 3)
				{
					for (int i = 0; i < 4; i++)
					{
						int num2 = this.GetRanks(i);
						if (num2 != 255 && this.GetStatus(num2, 20) != 2)
						{
							this.DrawImage(g, this.sysimg[42], x + 6, 4 + i * 59 + 26, 0);
						}
					}
					return;
				}
				this.DrawImage(g, this.sysimg[42], x + 6, 4 + this.cur[0] * 59 + 26, 0);
				return;
			}
			else
			{
				if (this.work[3] == 7 && this.work[4] == 17 && this.work[5] != 255 && this.sync % 2 == 1)
				{
					this.DrawImage(g, this.sysimg[42], x + 6, 4 + this.work[5] * 59 + 34, 0);
				}
				this.DrawImage(g, this.sysimg[42], x + 6, 4 + this.cur[0] * 59 + 26, 0);
			}
		}
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x000F2218 File Offset: 0x000F0418
	private void DrawMapMenuEther(StGraphics g, int x, int j)
	{
		int[] array = new int[]
		{
			this.GetSeqStep(),
			this.work[2]
		};
		this.DrawWindow(g, x, 66, 216, 128);
		this.DrawWindow(g, x, 206, 216, 14);
		if (this.mmenup == 0)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "使えるエーテルがありません", x + 108, 68, 1);
		}
		else
		{
			int num;
			int num2;
			for (int i = 0; i < 10; i++)
			{
				if (this.mmenu[this.cur[1] + i] != 255)
				{
					num = this.work[5];
					num2 = this.mmenu[this.cur[1] + i];
					if ((this.GetPlyEtParam(num, num2, 7) & 1) != 0 && (this.GetPlyEtParam(num, num2, 7) & 2) == 0)
					{
						this.SetColor(g, 2129952);
					}
					else if (this.GetPlyEtParam(num, num2, 0) > this.GetStatus(num, 4))
					{
						this.SetColor(g, 16719904);
					}
					else if (j == 1 || i != this.cur[0] - this.cur[1])
					{
						this.SetColor(g, 8421504);
					}
					else
					{
						this.SetColor(g, 16777215);
					}
					num2 = this.cur[1] + i;
					this.DrawString(g, this.mmstr[num2], x + 24, 68 + i * 12, 0);
					int num3 = this.GetPlyEtParam(num, this.mmenu[num2], 0) / 10;
					int num4 = this.GetPlyEtParam(num, this.mmenu[num2], 0) % 10;
					this.DrawString(g, "EP:" + num3.ToString() + num4.ToString(), x + 168, 68 + i * 12, 0);
				}
			}
			num = this.work[5];
			num2 = this.mmenu[this.cur[0]];
			if (num2 != 255 && j == 0)
			{
				this.SetColor(g, 16777215);
				this.DrawString(g, this.PlyEtExp[num][num2], x + 24, 207, 0);
			}
			if (array[j] == 10)
			{
				this.DrawWindow(g, x + 12, 113, 192, 14);
				this.SetColor(g, 16777215);
				this.DrawString(g, "EPが足りない！", 120, 114, 1);
			}
		}
		if (j == 0 && this.mmenup != 0)
		{
			this.DrawImage(g, this.sysimg[42], x + 8, 70 + (this.cur[0] - this.cur[1]) * 12, 0);
		}
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x000F2494 File Offset: 0x000F0694
	private string Num2str(string ss, int num)
	{
		int num2 = num / 100 % 10;
		int num3 = num / 10 % 10;
		int num4 = num % 10;
		return ss + num2.ToString() + num3.ToString() + num4.ToString();
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x000F24D4 File Offset: 0x000F06D4
	private void DrawMapMenuEquip(StGraphics g, int x, int j)
	{
		int[] array = new int[] { 1, 2, 4, 8 };
		int[] array2 = new int[]
		{
			this.GetSeqStep(),
			this.work[2]
		};
		int num = this.work[5];
		this.DrawImage(g, this.bimg[62], x + 12, 23, 0);
		this.DrawImage(g, this.bimg[1 + num], x + 12 + 4, 28, 0);
		string text = string.Empty + (this.GetStatus(num, 0) + 1).ToString();
		this.SetColor(g, 16777215);
		this.DrawString(g, text, x + 12 + 126, 24, 0);
		this.DrawString(g, this.PlyName[num], x + 12 + 35, 24, 0);
		this.SetColor(g, 4013373);
		this.FillRect(g, x + 12 + 138, 40, 50, 18);
		this.SetColor(g, 5921370);
		this.FillRect(g, x + 12 + 138, 62, 50, 18);
		if (this.GetStatus(num, 20) == 1)
		{
			this.SetColor(g, 16776960);
			this.DrawString(g, "Reserve", x + 12 + 138 + 42, 62, 2);
		}
		this.DrawNumSpr(g, this.GetStatus(num, 2), x + 12 + 50, 41, 0, 2, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 3), x + 12 + 80, 41, 0, 0, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 4), x + 12 + 50, 51, 0, 2, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 5), x + 12 + 80, 51, 0, 0, false, 4);
		this.DrawNumSpr(g, this.GetStatus(num, 15), x + 12 + 86, 62, 0, 2, false, 5);
		this.DrawNumSpr(g, this.GetStatus(num, 14), x + 12 + 80, 71, 0, 2, false, 6);
		if (array2[j] == 18)
		{
			this.DrawWindow(g, x + 12, 120, 123, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "武器", x + 12, 105, 0);
			int num2 = this.GetStatus(num, 21);
			if (num2 != 255)
			{
				this.DrawString(g, this.GetItemName(num2, 0), x + 24, 121, 0);
			}
			this.DrawWindow(g, x + 12, 160, 123, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "防具", x + 12, 145, 0);
			num2 = this.GetStatus(num, 22);
			if (num2 != 255)
			{
				this.DrawString(g, this.GetItemName(num2, 0), x + 24, 161, 0);
			}
		}
		else if (array2[j] == 19)
		{
			this.DrawWindow(g, x + 12, 90, 123, 124);
			this.DrawWindow(g, x + 12, 220, 192, 14);
			if (this.mmenup == 0)
			{
				this.SetColor(g, 8421504);
				this.DrawString(g, "装備できる物が", x + 36, 92, 0);
				this.DrawString(g, "ありません", x + 36, 105, 0);
			}
			else
			{
				for (int i = 0; i < 10; i++)
				{
					if (this.mmenu[this.cur[1] + i] != 255)
					{
						int num2 = this.mmenu[this.cur[1] + i];
						if (num2 == 128)
						{
							if (j == 1 || i != this.cur[0] - this.cur[1])
							{
								this.SetColor(g, 8421504);
							}
							else
							{
								this.SetColor(g, 16777215);
							}
						}
						else if ((this.itempc[num2][1] & array[num]) != 0)
						{
							this.SetColor(g, 16777088);
						}
						else if (j == 1 || i != this.cur[0] - this.cur[1])
						{
							this.SetColor(g, 8421504);
						}
						else
						{
							this.SetColor(g, 16777215);
						}
						num2 = this.cur[1] + i;
						this.DrawString(g, this.mmstr[num2], x + 36, 92 + i * 12, 0);
						if (j == 0)
						{
							num2 = this.mmenu[this.cur[0]];
							if (num2 != 128 && num2 != 255 && num2 < 66)
							{
								this.SetColor(g, 16777215);
								this.DrawString(g, this.GetItemName(num2, 1), x + 24, 222, 0);
							}
						}
					}
				}
			}
		}
		else if (array2[j] == 13)
		{
			for (int i = 0; i < 6; i++)
			{
				this.DrawWindow(g, x + 12, 100 + i * 16, 192, 14);
				if (this.mmenu[i] != 255)
				{
					this.SetColor(g, 16777215);
					this.DrawString(g, this.mmstr[i], x + 12 + 42, 101 + i * 16 + 1, 0);
				}
			}
			this.DrawImage(g, this.bimg[29], x + 14, 101, 0);
			this.DrawImage(g, this.bimg[30], x + 14, 117, 0);
			this.DrawImage(g, this.bimg[29], x + 14, 133, 0);
			this.DrawImage(g, this.bimg[29], x + 14 + 14, 133, 0);
			this.DrawImage(g, this.bimg[29], x + 14, 149, 0);
			this.DrawImage(g, this.bimg[30], x + 14 + 14, 149, 0);
			this.DrawImage(g, this.bimg[30], x + 14, 165, 0);
			this.DrawImage(g, this.bimg[29], x + 14 + 14, 165, 0);
			this.DrawImage(g, this.bimg[30], x + 14, 181, 0);
			this.DrawImage(g, this.bimg[30], x + 14 + 14, 181, 0);
			this.DrawWindow(g, x + 12, 212, 192, 14);
			if (this.mmenu[this.cur[0]] != 255)
			{
				num = this.work[5];
				this.SetColor(g, 16777215);
				this.DrawString(g, this.PlySAtkExp[num][this.cur[0]], x + 12 + 12, 213, 0);
			}
		}
		if (array2[j] == 18 || array2[j] == 19)
		{
			this.DrawWindow(g, x + 12 + 123 + 12, 100, 57, 95);
			int num3 = 103;
			int num4;
			if (array2[j] == 19)
			{
				num4 = this.work[15];
				if (this.work[8] < this.work[15])
				{
					this.SetColor(g, 16776960);
				}
				else if (this.work[8] > this.work[15])
				{
					this.SetColor(g, 16711680);
				}
				else
				{
					this.SetColor(g, 16777215);
				}
			}
			else
			{
				num4 = this.work[8];
				this.SetColor(g, 16777215);
			}
			text = this.Num2str("STR:", num4);
			this.DrawString(g, text, x + 12 + 123 + 12 + 9, num3, 0);
			num3 += 13;
			if (array2[j] == 19)
			{
				num4 = this.work[16];
				if (this.work[9] < this.work[16])
				{
					this.SetColor(g, 16776960);
				}
				else if (this.work[9] > this.work[16])
				{
					this.SetColor(g, 16711680);
				}
				else
				{
					this.SetColor(g, 16777215);
				}
			}
			else
			{
				num4 = this.work[9];
				this.SetColor(g, 16777215);
			}
			text = this.Num2str("VIT:", num4);
			this.DrawString(g, text, x + 12 + 130 + 5 + 9, num3, 0);
			num3 += 13;
			if (array2[j] == 19)
			{
				num4 = this.work[17];
				if (this.work[10] < this.work[17])
				{
					this.SetColor(g, 16776960);
				}
				else if (this.work[10] > this.work[17])
				{
					this.SetColor(g, 16711680);
				}
				else
				{
					this.SetColor(g, 16777215);
				}
			}
			else
			{
				num4 = this.work[10];
				this.SetColor(g, 16777215);
			}
			text = this.Num2str("EATK:", num4);
			this.DrawString(g, text, x + 12 + 130 + 5 + 3, num3, 0);
			num3 += 13;
			if (array2[j] == 19)
			{
				num4 = this.work[18];
				if (this.work[11] < this.work[18])
				{
					this.SetColor(g, 16776960);
				}
				else if (this.work[11] > this.work[18])
				{
					this.SetColor(g, 16711680);
				}
				else
				{
					this.SetColor(g, 16777215);
				}
			}
			else
			{
				num4 = this.work[11];
				this.SetColor(g, 16777215);
			}
			text = this.Num2str("EDEF:", num4);
			this.DrawString(g, text, x + 12 + 130 + 5 + 3, num3, 0);
			num3 += 13;
			this.SetColor(g, 16777215);
			num4 = this.work[12];
			text = this.Num2str("DEX:", num4);
			this.DrawString(g, text, x + 12 + 130 + 5 + 9, num3, 0);
			num3 += 13;
			this.SetColor(g, 16777215);
			num4 = this.work[13];
			text = this.Num2str("EVA:", num4);
			this.DrawString(g, text, x + 12 + 130 + 5 + 9, num3, 0);
			num3 += 13;
			this.SetColor(g, 16777215);
			num4 = this.work[14];
			text = this.Num2str("AGL:", num4);
			this.DrawString(g, text, x + 12 + 130 + 5 + 9, num3, 0);
			num3 += 13;
		}
		if (j == 0)
		{
			if (array2[j] == 18)
			{
				this.DrawImage(g, this.sysimg[42], x + 6, 120 + this.cur[0] * 40 + 4, 0);
				return;
			}
			if (array2[j] == 19)
			{
				if (this.mmenup != 0)
				{
					this.DrawImage(g, this.sysimg[42], x + 18, 94 + (this.cur[0] - this.cur[1]) * 12, 0);
					return;
				}
			}
			else if (array2[j] == 13)
			{
				this.DrawImage(g, this.sysimg[42], x + 6, 98 + this.cur[0] * 16 + 6, 0);
			}
		}
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x000F2F60 File Offset: 0x000F1160
	private void DrawMapMenuConfig(StGraphics g, int x, int j)
	{
		string[] array = new string[] { "ＯＦＦ", "ＯＮ" };
		string[] array2 = new string[] { "無音", "小", "最大" };
		this.DrawWindow(g, x, 92, 216, 52);
		for (int i = 0; i < 4; i++)
		{
			if (j == 1 || i != this.cur[0])
			{
				this.SetColor(g, 8421504);
			}
			else
			{
				this.SetColor(g, 16777215);
			}
			this.DrawString(g, this.configmenu[i][0], x + 12, 93 + i * 12, 0);
			if (i == 0)
			{
				this.DrawString(g, array2[this.GetConfig(i)], x + 168, 93 + i * 12, 0);
			}
			else
			{
				this.DrawString(g, array[this.GetConfig(i)], x + 168, 93 + i * 12, 0);
			}
		}
		this.DrawWindow(g, x, 182, 216, 14);
		if (j == 0 && this.cur[0] < 4)
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, this.configmenu[this.cur[0]][1], x + 12, 183, 0);
		}
		if (j == 0)
		{
			this.DrawImage(g, this.sysimg[42], x + 2, 94 + this.cur[0] * 12 + 4, 0);
		}
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x000F30C8 File Offset: 0x000F12C8
	private void DrawMapMenuSave(StGraphics g, int x, int j)
	{
		this.DrawWindow(g, x, 110, 216, 40);
		this.SetColor(g, 16777215);
		this.DrawString(g, "セーブしますか？", x + 12, 117, 0);
		if (this.cur[1] != 0 || j == 1)
		{
			this.SetColor(g, 8421504);
		}
		else
		{
			this.SetColor(g, 16777215);
		}
		this.DrawString(g, "はい", x + 168, 117, 0);
		if (this.cur[1] != 1 || j == 1)
		{
			this.SetColor(g, 8421504);
		}
		else
		{
			this.SetColor(g, 16777215);
		}
		this.DrawString(g, "いいえ", x + 168, 133, 0);
		if (j == 0)
		{
			this.DrawImage(g, this.sysimg[42], x + 148, 116 + this.cur[1] * 18 + 4, 0);
		}
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x000F31B0 File Offset: 0x000F13B0
	private void DrawMapMenuSave2(StGraphics g, int x, int j)
	{
		int[] array = new int[]
		{
			this.GetSeqStep(),
			this.work[2]
		};
		this.DrawWindow(g, x, 120, 216, 20);
		this.SetColor(g, 16777215);
		if (array[j] == 23)
		{
			this.DrawString(g, "セーブ中です。", 120, 124, 1);
			return;
		}
		if (!this.saflag)
		{
			this.DrawString(g, "セーブが完了しました。", 120, 124, 1);
			return;
		}
		this.DrawString(g, "セーブに失敗しました。", 120, 124, 1);
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x000F3238 File Offset: 0x000F1438
	private void DrawMapMenuLoad(StGraphics g, int x, int j)
	{
		this.DrawWindow(g, x, 110, 216, 40);
		this.SetColor(g, 16777215);
		this.DrawString(g, "ロードしますか？", x + 12, 117, 0);
		if (this.cur[1] != 0 || j == 1)
		{
			this.SetColor(g, 8421504);
		}
		else
		{
			this.SetColor(g, 16777215);
		}
		this.DrawString(g, "はい", x + 168, 117, 0);
		if (this.cur[1] != 1 || j == 1)
		{
			this.SetColor(g, 8421504);
		}
		else
		{
			this.SetColor(g, 16777215);
		}
		this.DrawString(g, "いいえ", x + 168, 133, 0);
		if (j == 0)
		{
			this.DrawImage(g, this.sysimg[42], x + 148, 116 + this.cur[1] * 18 + 4, 0);
		}
	}

	// Token: 0x06000BE2 RID: 3042 RVA: 0x000F3320 File Offset: 0x000F1520
	private void DrawMapMenuLoad2(StGraphics g, int x, int j)
	{
		int[] array = new int[]
		{
			this.GetSeqStep(),
			this.work[2]
		};
		this.DrawWindow(g, x, 120, 216, 20);
		this.SetColor(g, 16777215);
		if (array[j] == 27)
		{
			this.DrawString(g, "ロード中です。", 120, 124, 1);
			return;
		}
		this.DrawString(g, "ロードが完了しました。", 120, 124, 1);
	}

	// Token: 0x06000BE3 RID: 3043 RVA: 0x000F3390 File Offset: 0x000F1590
	public virtual bool PlayerMove(int mx, int my)
	{
		if (mx < 0 || this.mapw * 16 < mx || my < 0 || this.maph * 16 < my)
		{
			return false;
		}
		int num = this.chx;
		int num2 = this.chy;
		if (this.GetAtr(mx, my) == 0)
		{
			if (this.chx > mx)
			{
				sbyte b = this.GetAtr(this.chx - 12, my);
				if (b == 0)
				{
					sbyte b2 = this.GetAtr(this.chx - 12, my - 8);
					sbyte b3 = this.GetAtr(this.chx - 12, my + 4);
					sbyte b4 = this.GetAtr(this.chx, my - 8);
					sbyte b5 = this.GetAtr(this.chx, my + 4);
					if (b2 == 0)
					{
						this.chx = mx;
					}
					else if (b2 == 1 && b3 == 0 && b4 == 0 && b5 == 0)
					{
						this.chy = (my + 4) / 4 * 4 + 4;
					}
				}
				else if (b != 15)
				{
					sbyte b2 = this.GetAtr(this.chx - 12, my - 9);
					sbyte b3 = this.GetAtr(this.chx - 12, my - 13);
					sbyte b4 = this.GetAtr(this.chx, my - 9);
					sbyte b5 = this.GetAtr(this.chx, my - 13);
					if (b2 == 0 && b3 == 0 && b4 == 0 && b5 == 0)
					{
						this.chy = (my - 9) / 4 * 4 + 4;
					}
				}
			}
			else if (this.chx < mx)
			{
				sbyte b = this.GetAtr(this.chx + 8, my);
				if (b == 0)
				{
					sbyte b2 = this.GetAtr(this.chx + 8, my - 8);
					sbyte b3 = this.GetAtr(this.chx + 8, my + 4);
					sbyte b4 = this.GetAtr(this.chx, my - 8);
					sbyte b5 = this.GetAtr(this.chx, my + 4);
					if (b2 == 0)
					{
						this.chx = mx;
					}
					else if (b2 == 1 && b3 == 0 && b4 == 0 && b5 == 0)
					{
						this.chy = (my + 4) / 4 * 4 + 4;
					}
				}
				else if (b != 15)
				{
					sbyte b2 = this.GetAtr(this.chx + 8, my - 9);
					sbyte b3 = this.GetAtr(this.chx + 8, my - 13);
					sbyte b4 = this.GetAtr(this.chx, my - 9);
					sbyte b5 = this.GetAtr(this.chx, my - 13);
					if (b2 == 0 && b3 == 0 && b4 == 0 && b5 == 0)
					{
						this.chy = (my - 9) / 4 * 4 + 4;
					}
				}
			}
			else if (this.chy > my)
			{
				if (this.GetAtr(mx, this.chy - 12) == 0)
				{
					sbyte b2 = this.GetAtr(mx - 8, this.chy - 12);
					sbyte b3 = this.GetAtr(mx + 4, this.chy - 12);
					if (b2 == 0 && b3 == 0)
					{
						this.chy = my;
					}
					else if (b2 == 0 && b3 != 15)
					{
						this.chx = (mx - 4) / 4 * 4;
					}
					else if (b2 != 15 && b3 == 0)
					{
						this.chx = (mx + 4) / 4 * 4;
					}
				}
			}
			else
			{
				sbyte b2 = this.GetAtr(mx - 8, my);
				sbyte b3 = this.GetAtr(mx + 4, my);
				if (b2 == 0 && b3 == 0)
				{
					this.chy = my;
				}
				else if (b2 == 0 && b3 != 15)
				{
					this.chx = (mx - 4) / 4 * 4;
				}
				else if (b2 != 15 && b3 == 0)
				{
					this.chx = (mx + 4) / 4 * 4;
				}
			}
		}
		else if (this.chy < my && this.GetAtr(mx, my - 1) == 0)
		{
			sbyte b2 = this.GetAtr(mx - 8, my - 1);
			sbyte b3 = this.GetAtr(mx + 4, my - 1);
			if (b2 == 0 && b3 == 0)
			{
				this.chy = my - 1;
			}
		}
		if (this.chx != num || this.chy != num2)
		{
			this.TrapCheck();
			this.SetMapPos();
			this.encount--;
			this.red = true;
			return true;
		}
		return false;
	}

	// Token: 0x06000BE4 RID: 3044 RVA: 0x000F3789 File Offset: 0x000F1989
	public virtual void SetEncountNum()
	{
		if (this.chc == 14 || this.chc == 21)
		{
			this.encount = this.GetRand(135, 165);
			return;
		}
		this.encount = this.GetRand(80, 100);
	}

	// Token: 0x06000BE5 RID: 3045 RVA: 0x000F37C8 File Offset: 0x000F19C8
	public virtual void SetMapPos()
	{
		this.mapx = this.chx - 120;
		if (this.mapx > this.mapw * 16 - 240)
		{
			this.mapx = this.mapw * 16 - 240;
		}
		if (this.mapx < 0)
		{
			this.mapx = 0;
		}
		this.mapy = this.chy - 120;
		if (this.mapy > this.maph * 16 - 240)
		{
			this.mapy = this.maph * 16 - 240;
		}
		if (this.mapy < 0)
		{
			this.mapy = 0;
		}
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x000F386C File Offset: 0x000F1A6C
	public virtual void SetMapPosU(int x, int y)
	{
		this.mapx = x;
		if (this.mapx > this.mapw * 16 - 240)
		{
			this.mapx = this.mapw * 16 - 240;
		}
		if (this.mapx < 0)
		{
			this.mapx = 0;
		}
		this.mapy = y;
		if (this.mapy > this.maph * 16 - 240)
		{
			this.mapy = this.maph * 16 - 240;
		}
		if (this.mapy < 0)
		{
			this.mapy = 0;
		}
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x000F3900 File Offset: 0x000F1B00
	public virtual void SetBoost(int id)
	{
		int num = this.GetStatus(id, 17);
		this.SetStatus(id, 17, num - 1);
		this.isboost[0] = false;
		this.isboost[1] = true;
		this.isboost[2] = false;
		this.boostno = id;
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x000F3948 File Offset: 0x000F1B48
	public virtual void SetEneBoost(int id)
	{
		int enemyStatus = this.GetEnemyStatus(id, 36);
		this.SetEnemyStatus(id, 36, enemyStatus - 1);
		this.isboost[0] = false;
		this.isboost[1] = true;
		this.isboost[2] = false;
		this.iscboost = true;
		this.boostno = id + 4;
		this.SetMenu(0);
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x000F39A0 File Offset: 0x000F1BA0
	public virtual void BoostPushTurn()
	{
		if (this.GetStatus(this.boostno, 19) != 0)
		{
			this.boostno = 0;
			this.isboost[0] = false;
			this.isboost[1] = false;
			return;
		}
		for (int i = this.gtwp; i >= 1; i--)
		{
			this.SetGtw(i, this.GetGtw(i - 1));
		}
		this.SetGtw(0, this.boostno);
		this.gtwp++;
		this.isboost[0] = false;
		this.isboost[1] = false;
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x000F3A28 File Offset: 0x000F1C28
	public virtual void EneBoostPushTurn()
	{
		if (this.GetEnemyStatus(this.boostno - 4, 34) != 0)
		{
			this.boostno = 0;
			this.isboost[0] = false;
			this.isboost[1] = false;
			this.iscboost = false;
			return;
		}
		for (int i = this.gtwp; i >= 1; i--)
		{
			this.SetGtw(i, this.GetGtw(i - 1));
		}
		this.SetGtw(0, this.boostno);
		this.gtwp++;
		this.isboost[0] = false;
		this.isboost[1] = false;
		this.iscboost = false;
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x000F3AC0 File Offset: 0x000F1CC0
	public virtual bool IsBoostEnable(int id)
	{
		for (int i = 0; i < this.gtwp; i++)
		{
			if (this.GetGtw(i) == id)
			{
				return false;
			}
		}
		return this.GetStatus(id, 17) > 0 && this.GetStatus(id, 19) == 0;
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x000F3B04 File Offset: 0x000F1D04
	public virtual void IsBoostEnable2()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.GetStatus(i, 20) == 0 && this.GetStatus(i, 19) == 0 && this.GetStatus(i, 17) >= 1)
			{
				int num2 = 0;
				for (int j = 0; j < this.gtwp; j++)
				{
					if (this.GetGtw(j) == i)
					{
						num2 = 1;
					}
				}
				if (num2 == 0)
				{
					num++;
				}
			}
		}
		if (num >= 1)
		{
			this.isboost[2] = true;
			return;
		}
		this.isboost[2] = false;
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x000F3B80 File Offset: 0x000F1D80
	public virtual bool IsEneBoostEnable(int id)
	{
		for (int i = 0; i < this.gtwp; i++)
		{
			if (this.GetGtw(i) == id + 4)
			{
				return false;
			}
		}
		return this.GetEnemyStatus(id, 36) > 0 && this.GetEnemyStatus(id, 34) == 0;
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x000F3BC8 File Offset: 0x000F1DC8
	public virtual bool IsCBoostEnable(int id)
	{
		if (this.GetEnemyStatus(id, 3) <= 0)
		{
			return false;
		}
		int enemyStatus = this.GetEnemyStatus(id, 23);
		int i;
		if (enemyStatus == 2)
		{
			if (this.GetEnemyStatus(id, 3) > this.GetEnemyStatus(id, 38) / 5)
			{
				return false;
			}
		}
		else if (enemyStatus == 3)
		{
			if (this.GetEnemyStatus(id, 3) > this.GetEnemyStatus(id, 38) / 2)
			{
				return false;
			}
		}
		else if (enemyStatus == 4)
		{
			int num = 0;
			for (i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0)
				{
					num++;
				}
			}
			if (num > 1)
			{
				return false;
			}
		}
		else if (enemyStatus == 5 && this.GetNowSlot() != 1)
		{
			return false;
		}
		int enemyStatus2 = this.GetEnemyStatus(id, 22);
		if (enemyStatus2 == 1)
		{
			i = 5;
		}
		else if (enemyStatus2 == 2)
		{
			i = 8;
		}
		else if (enemyStatus2 == 3)
		{
			i = 10;
		}
		else if (enemyStatus2 == 4)
		{
			i = 15;
		}
		else
		{
			i = 0;
		}
		return i != 0 && this.GetRand(1, i) == 1;
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x000F3CA0 File Offset: 0x000F1EA0
	public virtual void BattleGtwInit()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetRanks(i);
			if (num2 != 255 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0)
			{
				num++;
			}
		}
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) == 0)
			{
				num++;
			}
		}
		if (num % 2 == 0)
		{
			this.gtwp = num / 2;
		}
		else
		{
			this.gtwp = num / 2 + 1;
		}
		num = 0;
		bool flag = true;
		do
		{
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0 && this.GetStatus(num2, 23) == 0)
				{
					this.SetGtw(num, num2);
					num++;
				}
			}
			for (int i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0 && this.GetEnemyStatus(i, 37) == 0)
				{
					this.SetGtw(num, i + 4);
					num++;
				}
			}
			if (num == 0)
			{
				this.ActionStsInit();
			}
			else
			{
				flag = false;
			}
		}
		while (flag);
		int num3 = 255;
		if (num < this.gtwp)
		{
			if (this.gtwp - num > 1)
			{
				this.gtwp--;
			}
			int num4 = -1000;
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 23) == 1 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0)
				{
					int num5 = this.GetPlyAglNum(num2);
					if (num4 < num5)
					{
						num3 = num2;
						num4 = num5;
					}
				}
			}
			for (int i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0 && this.GetEnemyStatus(i, 37) == 1)
				{
					int num5 = this.GetEneAglNum(i);
					if (num4 < num5)
					{
						num3 = i + 4;
						num4 = num5;
					}
				}
			}
		}
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = this.GetGtw(i);
			int num4;
			if (num2 < 4)
			{
				num4 = this.GetPlyAglNum(num2);
			}
			else
			{
				num4 = this.GetEneAglNum(num2 - 4);
			}
			int num6 = i;
			for (int j = i + 1; j < num; j++)
			{
				num2 = this.GetGtw(j);
				int num5;
				if (num2 < 4)
				{
					num5 = this.GetPlyAglNum(num2);
				}
				else
				{
					num5 = this.GetEneAglNum(num2 - 4);
				}
				if (num4 < num5)
				{
					num4 = num5;
					num6 = j;
				}
			}
			if (num6 != i)
			{
				num2 = this.GetGtw(i);
				this.SetGtw(i, this.GetGtw(num6));
				this.SetGtw(num6, num2);
			}
		}
		if (num3 != 255)
		{
			this.SetGtw(this.gtwp - 1, num3);
		}
		for (int i = 0; i < this.gtwp; i++)
		{
			int num2 = this.GetGtw(i);
			if (num2 < 4)
			{
				if (num2 == num3)
				{
					this.SetStatus(num2, 23, 2);
				}
				else
				{
					this.SetStatus(num2, 23, 1);
				}
				int num4 = this.GetPlyAglNum(num2);
			}
			else if (num2 != 255)
			{
				this.SetEnemyStatus(num2 - 4, 37, 1);
				int num4 = this.GetEneAglNum(num2 - 4);
			}
		}
		for (int i = this.gtwp; i < 8; i++)
		{
			this.SetGtw(i, 255);
		}
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x000F3FCC File Offset: 0x000F21CC
	public virtual void BattleGtwRemove(int id)
	{
		for (int i = 0; i < this.gtwp; i++)
		{
			if (this.GetGtw(i) == id)
			{
				for (int j = i; j < this.gtwp - 1; j++)
				{
					this.SetGtw(j, this.GetGtw(j + 1));
				}
				this.gtwp--;
				return;
			}
		}
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x000F4026 File Offset: 0x000F2226
	public virtual int GetPlyAglNum(int id)
	{
		return (this.GetAgl(id) - this.GetStatus(id, 24)) * (this.GetStatus(id, 0) + 1);
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x000F4044 File Offset: 0x000F2244
	public virtual int GetEneAglNum(int id)
	{
		return this.GetAgl(id + 4);
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x000F4050 File Offset: 0x000F2250
	public virtual void EneCursorLeft()
	{
		int num = this.cur[1];
		bool flag = true;
		do
		{
			if (this.cur[1] == 0)
			{
				this.cur[1] = this.ep - 1;
			}
			else
			{
				this.cur[1]--;
			}
			if (this.GetEnemyStatus(this.cur[1], 34) == 0)
			{
				flag = false;
			}
			else if (num == this.cur[1])
			{
				flag = false;
			}
		}
		while (flag);
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x000F40BC File Offset: 0x000F22BC
	public virtual void EneCursorRight()
	{
		int num = this.cur[1];
		bool flag = true;
		do
		{
			if (this.cur[1] == this.ep - 1)
			{
				this.cur[1] = 0;
			}
			else
			{
				this.cur[1]++;
			}
			if (this.GetEnemyStatus(this.cur[1], 34) == 0)
			{
				flag = false;
			}
			else if (num == this.cur[1])
			{
				flag = false;
			}
		}
		while (flag);
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x000F4128 File Offset: 0x000F2328
	public virtual void MenuCursorUp()
	{
		if (this.cur[0] == 0)
		{
			this.cur[0] = this.bmenup - 1;
		}
		else
		{
			this.cur[0]--;
		}
		if (this.cur[2] > this.cur[0] || this.cur[0] > this.cur[2] + 3)
		{
			if (this.cur[0] == this.bmenup - 1)
			{
				this.cur[2] = this.cur[0] - 3;
				return;
			}
			this.cur[2] = this.cur[0];
		}
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x000F41C0 File Offset: 0x000F23C0
	public virtual void MenuCursorDown()
	{
		if (this.cur[0] == this.bmenup - 1)
		{
			this.cur[0] = 0;
		}
		else
		{
			this.cur[0]++;
		}
		if (this.cur[2] > this.cur[0] || this.cur[0] > this.cur[2] + 3)
		{
			if (this.cur[0] == 0)
			{
				this.cur[2] = 0;
				return;
			}
			this.cur[2] = this.cur[0] - 3;
		}
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x000F4248 File Offset: 0x000F2448
	public virtual void BattleGtwNext()
	{
		for (int i = 0; i < this.gtwp; i++)
		{
			this.SetGtw(i, this.GetGtw(i + 1));
		}
		this.gtwp--;
		if (this.isboost[1])
		{
			if (this.boostno < 4)
			{
				this.BoostPushTurn();
			}
			else
			{
				this.EneBoostPushTurn();
			}
		}
		this.crtl = 0;
		for (int i = 0; i < 4; i++)
		{
			this.atkst[i] = 0;
		}
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x000F42C1 File Offset: 0x000F24C1
	public virtual void EnemyDamage()
	{
		this.HpDec(this.cur[1] + 4, this.work[0]);
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x000F42DC File Offset: 0x000F24DC
	public virtual void EnemyAllDamage()
	{
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) == 0)
			{
				this.HpDec(i + 4, this.work[9 + i]);
			}
		}
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x000F431C File Offset: 0x000F251C
	public virtual void EnemyDamage2()
	{
		int i = this.GetPlyEtParam(this.work[2], this.work[3], 3);
		if (i == 48)
		{
			for (i = 0; i < this.ep; i++)
			{
				if (this.work[9 + i] != 65535 && this.GetEnemyStatus(i, 34) == 0)
				{
					this.HpDec(i + 4, this.work[9 + i]);
				}
			}
			return;
		}
		if (i == 47)
		{
			i = this.work[4] - 4;
			if (this.work[9] != 65535)
			{
				this.HpDec(i + 4, this.work[9]);
			}
		}
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x000F43BB File Offset: 0x000F25BB
	public virtual bool EnemyDead()
	{
		if (this.work[0] == 65535)
		{
			return this.EnemyDead3();
		}
		if (this.GetEnemyStatus(this.cur[1], 3) <= 0)
		{
			this.SetEnemyStatus(this.cur[1], 34, 2);
			return true;
		}
		return false;
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x000F43FC File Offset: 0x000F25FC
	public virtual bool EnemyDead2()
	{
		int i = this.GetPlyEtParam(this.work[2], this.work[3], 3);
		bool flag = false;
		if (i == 48)
		{
			for (i = 0; i < this.ep; i++)
			{
				if (this.work[9 + i] != 65535 && this.GetEnemyStatus(i, 34) == 0 && this.GetEnemyStatus(i, 3) <= 0)
				{
					this.SetEnemyStatus(i, 34, 2);
					flag = true;
				}
			}
		}
		else if (i == 47)
		{
			i = this.work[4] - 4;
			if (this.GetEnemyStatus(i, 3) <= 0)
			{
				this.SetEnemyStatus(i, 34, 2);
				flag = true;
			}
		}
		return flag;
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x000F4498 File Offset: 0x000F2698
	public virtual bool EnemyDead3()
	{
		bool flag = false;
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 3) <= 0 && this.GetEnemyStatus(i, 34) == 0)
			{
				this.SetEnemyStatus(i, 34, 2);
				flag = true;
			}
		}
		return flag;
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x000F44DC File Offset: 0x000F26DC
	public virtual bool EnemyDestroy()
	{
		int num = 0;
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) != 0)
			{
				num++;
			}
		}
		return num >= this.ep;
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x000F4518 File Offset: 0x000F2718
	public virtual void ApRecover(int id)
	{
		int num = this.GetStatus(id, 6);
		num = ((num + 4 >= 6) ? 6 : (num + 4));
		this.SetStatus(id, 6, num);
		this.SetGuard(id, 0);
		this.bnum = 0;
		this.blast = -1;
		this.bmenup = 0;
	}

	// Token: 0x06000C00 RID: 3072 RVA: 0x000F4564 File Offset: 0x000F2764
	public virtual void SetBattleMenu(int id)
	{
		for (int i = 0; i < 4; i++)
		{
			this.SetBMStr(i, string.Empty);
			this.SetBMenu(i, 0, -1);
			this.SetBMenu(i, 1, -1);
		}
		this.bmenup = 0;
		int num = 0;
		for (int i = 0; i < 6; i++)
		{
			if (this.GetPlyNAtkParam(id, i, 5) == this.blast && this.GetStatus(id, 6) >= 2)
			{
				this.SetBMStr(num, this.GetPlyNAtkName(id, i));
				this.SetBMenu(num, 0, i);
				this.SetBMenu(num, 1, this.GetPlyNAtkParam(id, i, 6));
				num++;
			}
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.GetPlySAtkParam(id, i, 10) == this.blast && this.GetStatus(id, 6) >= 2 && this.GetPlySAtkParam(id, i, 8) <= this.GetStatus(id, 0) + 1 && this.GetStatus(id, 0) + 1 < this.GetPlySAtkParam(id, i, 9))
			{
				this.SetBMStr(num, this.GetPlySAtkName(id, i));
				this.SetBMenu(num, 0, 16 + i);
				this.SetBMenu(num, 1, 2);
				num++;
			}
		}
		if (num != 0 && this.blast == -1)
		{
			this.SetBMStr(num, "ﾒﾆｭｰ");
			this.SetBMenu(num, 0, 144);
			this.SetBMenu(num, 1, -1);
			num++;
		}
		else if (num != 0 && this.blast != -1)
		{
			this.SetBMStr(num, "終了");
			this.SetBMenu(num, 0, 128);
			this.SetBMenu(num, 1, -1);
			num++;
		}
		this.bmenup = num;
		this.cur[0] = 0;
		this.cur[2] = 0;
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x000F46F4 File Offset: 0x000F28F4
	public virtual void SetEtherMenu(int id)
	{
		bool flag = false;
		for (int i = 0; i < 10; i++)
		{
			this.SetBMStr(i, string.Empty);
			this.SetBMenu(i, 0, -1);
			this.SetBMenu(i, 1, -1);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.GetStatus(i, 19) != 0)
			{
				flag = true;
			}
		}
		this.bmenup = 0;
		int num = 0;
		int num2 = this.PlyEtPiece[id];
		for (int i = 0; i < num2; i++)
		{
			bool flag2 = true;
			if (this.GetPlyEtParam(id, i, 6) <= this.GetStatus(id, 0) + 1 && (this.GetPlyEtParam(id, i, 7) & 1) != 0)
			{
				if (this.GetPlyEtParam(id, i, 1) == 7 && !flag)
				{
					flag2 = false;
				}
				if (flag2)
				{
					this.SetBMStr(num, this.GetPlyEtName(id, i));
					int length = this.bmstr[num].Length;
					int j;
					for (j = 0; j < 11 - length; j++)
					{
						string[] array = this.bmstr;
						int num3 = num;
						array[num3] += " ";
					}
					this.IsStatusAbnormal(id, 25);
					j = this.GetPlyEtParam(id, i, 0) / 10;
					int num4 = this.GetPlyEtParam(id, i, 0) % 10;
					string[] array2 = this.bmstr;
					int num5 = num;
					array2[num5] = array2[num5] + "EP:" + j.ToString() + num4.ToString();
					this.SetBMenu(num, 0, i);
					this.SetBMenu(num, 1, -1);
					num++;
				}
			}
		}
		this.SetBMStr(num, "戻る");
		this.SetBMenu(num, 0, 128);
		this.SetBMenu(num, 1, -1);
		num++;
		if (num <= 4)
		{
			for (int i = 0; i < num - 1; i++)
			{
				this.SetBMenu(i, 1, i);
			}
		}
		this.bmenup = num;
		this.cur[0] = 0;
		this.cur[2] = 0;
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x000F48B8 File Offset: 0x000F2AB8
	public virtual void SetItemMenu()
	{
		bool flag = false;
		for (int i = 0; i < 66; i++)
		{
			this.SetBMStr(i, string.Empty);
			this.SetBMenu(i, 0, -1);
			this.SetBMenu(i, 1, -1);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.GetStatus(i, 19) != 0)
			{
				flag = true;
			}
		}
		this.bmenup = 0;
		for (int i = 0; i < 66; i++)
		{
			bool flag2 = true;
			if (this.GetItemData(i, 0) == 0 && (this.GetItemData(i, 2) & 1) != 0 && this.itempc[i][0] != 0)
			{
				if (this.GetItemData(i, 1) == 7 && !flag)
				{
					flag2 = false;
				}
				if (flag2)
				{
					this.SetBMStr(this.bmenup, this.GetItemName(i, 0));
					this.SetBMenu(this.bmenup, 0, i);
					this.SetBMenu(this.bmenup, 1, -1);
					int length = this.bmstr[this.bmenup].Length;
					int j;
					for (j = 0; j < 13 - length; j++)
					{
						string[] array = this.bmstr;
						int num = this.bmenup;
						array[num] += " ";
					}
					j = this.itempc[i][0] / 10;
					int num2 = this.itempc[i][0] % 10;
					string[] array2 = this.bmstr;
					int num3 = this.bmenup;
					array2[num3] = array2[num3] + "x" + j.ToString() + num2.ToString();
					this.bmenup++;
				}
			}
		}
		this.SetBMStr(this.bmenup, "戻る");
		this.SetBMenu(this.bmenup, 0, 128);
		this.SetBMenu(this.bmenup, 1, -1);
		this.bmenup++;
		if (this.bmenup <= 4)
		{
			for (int i = 0; i < this.bmenup - 1; i++)
			{
				this.SetBMenu(i, 1, i);
			}
		}
		this.cur[0] = 0;
		this.cur[2] = 0;
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x000F4AAC File Offset: 0x000F2CAC
	public virtual void SetSubMenu()
	{
		for (int i = 0; i < 10; i++)
		{
			this.SetBMStr(i, string.Empty);
			this.SetBMenu(i, 0, -1);
			this.SetBMenu(i, 1, -1);
		}
		this.SetBMStr(0, "ＥＴＨＥＲ");
		this.SetBMenu(0, 0, 0);
		this.SetBMenu(0, 1, 0);
		this.SetBMStr(1, "ＩＴＥＭ");
		this.SetBMenu(1, 0, 1);
		this.SetBMenu(1, 1, 1);
		this.SetBMStr(2, "ＧＵＡＲＤ");
		this.SetBMenu(2, 0, 2);
		this.SetBMenu(2, 1, 2);
		this.SetBMStr(3, "戻る");
		this.SetBMenu(3, 0, 3);
		this.SetBMenu(3, 1, -1);
		this.bmenup = 4;
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x000F4B63 File Offset: 0x000F2D63
	public virtual int GetBMenu(int no, int menu)
	{
		if (no < 0 || no >= 66)
		{
			return 0;
		}
		if (menu < 0 || menu >= 2)
		{
			return 0;
		}
		return this.bmenu[no][menu];
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x000F4B84 File Offset: 0x000F2D84
	public virtual void SetBMenu(int no, int menu, int num)
	{
		if (no < 0 || no >= 66)
		{
			return;
		}
		if (menu < 0 || menu >= 2)
		{
			return;
		}
		this.bmenu[no][menu] = num;
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x000F4BA4 File Offset: 0x000F2DA4
	public virtual string GetBMStr(int no)
	{
		if (no < 0 || no >= 66)
		{
			return string.Empty;
		}
		return this.bmstr[no];
	}

	// Token: 0x06000C07 RID: 3079 RVA: 0x000F4BBD File Offset: 0x000F2DBD
	public virtual void SetBMStr(int no, string str)
	{
		if (no < 0 || no >= 66)
		{
			return;
		}
		this.bmstr[no] = str;
	}

	// Token: 0x06000C08 RID: 3080 RVA: 0x000F4BD2 File Offset: 0x000F2DD2
	public virtual string GetItemName(int no, int menu)
	{
		if (no < 0 || no >= 66)
		{
			return string.Empty;
		}
		if (menu < 0 || menu >= 2)
		{
			return string.Empty;
		}
		return this.ItemName[no][menu];
	}

	// Token: 0x06000C09 RID: 3081 RVA: 0x000F4BFC File Offset: 0x000F2DFC
	public virtual bool BattleMenuSC()
	{
		int num = -1;
		if ((this.id_edge & 256) != 0)
		{
			num = 0;
		}
		else if ((this.id_edge & 512) != 0)
		{
			num = 1;
		}
		else if ((this.id_edge & 1024) != 0)
		{
			num = 2;
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.GetBMenu(i, 1) == num)
			{
				this.cur[0] = i;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x000F4C64 File Offset: 0x000F2E64
	public virtual void SetBLast()
	{
		if (this.blast == -1)
		{
			if (this.GetBMenu(this.cur[0], 1) == 0)
			{
				this.blast = 0;
				return;
			}
			if (this.GetBMenu(this.cur[0], 1) == 1)
			{
				this.blast = 1;
				return;
			}
		}
		else if (this.blast == 0)
		{
			if (this.GetBMenu(this.cur[0], 1) == 0)
			{
				this.blast = 2;
				return;
			}
			if (this.GetBMenu(this.cur[0], 1) == 1)
			{
				this.blast = 3;
				return;
			}
		}
		else if (this.blast == 1)
		{
			if (this.GetBMenu(this.cur[0], 1) == 0)
			{
				this.blast = 4;
				return;
			}
			if (this.GetBMenu(this.cur[0], 1) == 1)
			{
				this.blast = 5;
			}
		}
	}

	// Token: 0x06000C0B RID: 3083 RVA: 0x000F4D24 File Offset: 0x000F2F24
	public virtual void SetBLast2(int sc)
	{
		if (this.blast == -1)
		{
			if (sc == 0)
			{
				this.blast = 0;
				return;
			}
			if (sc == 1)
			{
				this.blast = 1;
				return;
			}
			this.blast = 6;
			return;
		}
		else if (this.blast == 0)
		{
			if (sc == 0)
			{
				this.blast = 2;
				return;
			}
			if (sc == 1)
			{
				this.blast = 3;
				return;
			}
			this.blast = 6;
			return;
		}
		else
		{
			if (this.blast != 1)
			{
				this.blast = 6;
				return;
			}
			if (sc == 0)
			{
				this.blast = 4;
				return;
			}
			if (sc == 1)
			{
				this.blast = 5;
				return;
			}
			this.blast = 6;
			return;
		}
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x000F4DB0 File Offset: 0x000F2FB0
	public virtual int SetBattleRanks(int st, int f)
	{
		for (int i = 0; i < 4; i++)
		{
			this.branks[i] = 255;
		}
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetRanks(i);
			if (num2 != 255 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0)
			{
				this.branks[num] = num2;
				num++;
			}
		}
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = this.branks[i];
			int num3 = this.GetStatus(num2, st);
			int num4 = i;
			for (int j = i + 1; j < num; j++)
			{
				num2 = this.branks[j];
				int num5 = this.GetStatus(num2, st);
				if (f == 0)
				{
					if (num3 > num5)
					{
						num3 = num5;
						num4 = j;
					}
				}
				else if (num3 < num5)
				{
					num3 = num5;
					num4 = j;
				}
			}
			if (num4 != i)
			{
				int num6 = this.branks[i];
				this.branks[i] = this.branks[num4];
				this.branks[num4] = num6;
			}
		}
		return num;
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x000F4EB8 File Offset: 0x000F30B8
	public virtual int Status2id(int st, int f)
	{
		int num = 0;
		int num2 = this.SetBattleRanks(st, f);
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			num3 += i + 1;
		}
		int num4 = this.GetRand(0, 98);
		int num5 = 0;
		for (int i = 0; i < num2; i++)
		{
			int num6 = (num2 + 1 - (i + 1)) * 100 / num3;
			if (num4 < num6 + num5)
			{
				num = this.branks[i];
				break;
			}
			num5 += num6;
		}
		return num;
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x000F4F2C File Offset: 0x000F312C
	public virtual void ApMinus(int id, int num)
	{
		int num2 = this.GetStatus(id, 6);
		num2 -= num;
		if (num2 <= 0)
		{
			num2 = 0;
		}
		this.SetStatus(id, 6, num2);
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x000F4F58 File Offset: 0x000F3158
	public virtual void EpMinus(int id, int num)
	{
		int num2 = this.GetStatus(id, 4);
		int num3 = 1;
		if (this.IsStatusAbnormal(id, 25))
		{
			num3 = 2;
		}
		num2 -= num * num3;
		if (num2 <= 0)
		{
			num2 = 0;
		}
		this.SetStatus(id, 4, num2);
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x000F4F94 File Offset: 0x000F3194
	public virtual void EnemyAttackInit()
	{
		int num = 0;
		int num2 = this.GetGtw(0) - 4;
		int enemyStatus = this.GetEnemyStatus(num2, 20);
		int enemyStatus2 = this.GetEnemyStatus(num2, 21);
		int num3 = this.GetRand(0, 9);
		int num4;
		if (enemyStatus == 0)
		{
			num4 = 10;
		}
		else if (enemyStatus == 1)
		{
			num4 = 7;
		}
		else if (enemyStatus == 2)
		{
			num4 = 5;
		}
		else if (enemyStatus == 3)
		{
			num4 = 3;
		}
		else
		{
			num4 = 0;
		}
		int enemyStatus3 = this.GetEnemyStatus(num2, 23);
		if (enemyStatus3 == 1)
		{
			if (this.GetEnemyStatus(num2, 36) < 1)
			{
				num4 = 10;
			}
		}
		else if (enemyStatus3 == 2)
		{
			if (this.GetEnemyStatus(num2, 3) > this.GetEnemyStatus(num2, 38) / 5)
			{
				num4 = 10;
			}
		}
		else if (enemyStatus3 == 3)
		{
			if (this.GetEnemyStatus(num2, 3) > this.GetEnemyStatus(num2, 38) / 2)
			{
				num4 = 10;
			}
		}
		else if (enemyStatus3 == 4)
		{
			int num5 = 0;
			for (int i = 0; i < this.ep; i++)
			{
				if (this.GetEnemyStatus(i, 34) == 0)
				{
					num5++;
				}
			}
			if (num5 > 1)
			{
				num4 = 10;
			}
		}
		else if (enemyStatus3 == 5 && this.GetNowSlot() != 1)
		{
			num4 = 10;
		}
		if (this.IsStatusAbnormal(num2 + 4, 22))
		{
			num4 = 10;
		}
		if (num3 < num4 && this.estatus[num2][11] != -1)
		{
			this.eneatk = this.GetEnemyStatus(num2, 11);
		}
		else
		{
			num4 = 0;
			for (int j = 0; j < 6; j++)
			{
				if (this.GetEnemyStatus(num2, 13 + j) != -1)
				{
					num4++;
				}
			}
			num3 = this.GetRand(0, num4 - 1);
			this.eneatk = this.GetEnemyStatus(num2, 13 + num3) + 48;
			num = this.GetEneSAtkParam(this.eneatk - 48, 6);
			if (this.GetEneSAtkParam(this.eneatk - 48, 6) > 25 && this.GetEnemyStatus(num2, 3) == this.GetEnemyStatus(num2, 38))
			{
				this.eneatk = this.GetEnemyStatus(num2, 11);
			}
		}
		if (enemyStatus2 == 0)
		{
			this.cur[1] = this.Status2id(2, 0);
		}
		else if (enemyStatus2 == 1)
		{
			this.cur[1] = this.Status2id(2, 1);
		}
		else if (enemyStatus2 == 2)
		{
			this.cur[1] = this.Status2id(13, 1);
		}
		else if (enemyStatus2 == 3)
		{
			this.cur[1] = this.Status2id(13, 0);
		}
		else if (enemyStatus2 == 4)
		{
			this.cur[1] = this.Status2id(7, 1);
		}
		else if (enemyStatus2 == 5)
		{
			this.cur[1] = this.Status2id(9, 1);
		}
		else
		{
			int i;
			bool flag;
			do
			{
				flag = true;
				int j = this.GetRand(0, 3);
				i = this.GetRanks(j);
				if (i != 255 && this.GetStatus(i, 20) == 0 && this.GetStatus(i, 19) == 0)
				{
					flag = false;
				}
			}
			while (flag);
			this.cur[1] = i;
		}
		if (this.eneatk >= 48 && this.GetEneSAtkParam(this.eneatk - 48, 5) != 0 && num >= 13 && num <= 25 && num != 22 && this.IsStatusAbnormal(this.cur[1], num))
		{
			this.eneatk = this.GetEnemyStatus(num2, 11);
		}
		this.cur[0] = 1;
		if (this.IsStatusAbnormal(num2 + 4, 22))
		{
			int i;
			bool flag;
			do
			{
				flag = true;
				this.cur[0] = this.GetRand(0, 1);
				if (this.cur[0] == 0)
				{
					i = this.GetRand(0, this.ep - 1);
					if (i != 255 && this.GetEnemyStatus(i, 34) == 0)
					{
						flag = false;
					}
				}
				else
				{
					int j = this.GetRand(0, 3);
					i = this.GetRanks(j);
					if (i != 255 && this.GetStatus(i, 20) == 0 && this.GetStatus(i, 19) == 0)
					{
						flag = false;
					}
				}
			}
			while (flag);
			this.cur[1] = i;
		}
		if (this.cur[0] == 0)
		{
			this.work[0] = this.GetDmg3(this.cur[1], num2);
		}
		else
		{
			this.work[0] = this.GetDmg2(this.cur[1], num2);
		}
		this.work[1] = 0;
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x000F5384 File Offset: 0x000F3584
	public virtual void ConfusionAttackInit()
	{
		int num = this.GetGtw(0);
		int num2 = this.GetRand(0, 1);
		this.nowmenu = num2;
		bool flag;
		int num3;
		do
		{
			flag = true;
			this.cur[0] = this.GetRand(0, 1);
			if (this.cur[0] == 0)
			{
				num3 = this.GetRand(0, this.ep - 1);
				if (num3 != 255 && this.GetEnemyStatus(num3, 34) == 0)
				{
					flag = false;
				}
			}
			else
			{
				int num4 = this.GetRand(0, 3);
				num3 = this.GetRanks(num4);
				if (num3 != 255 && this.GetStatus(num3, 20) == 0 && this.GetStatus(num3, 19) == 0)
				{
					flag = false;
				}
			}
		}
		while (flag);
		this.cur[1] = num3;
		if (this.cur[0] == 0)
		{
			this.work[0] = this.GetDmg(num, this.cur[1]);
		}
		else
		{
			this.work[0] = this.GetDmg4(num, this.cur[1]);
		}
		this.work[1] = 0;
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x000F5470 File Offset: 0x000F3670
	public virtual bool PlayerDamage(int id)
	{
		this.HpDec(id, this.work[0]);
		if (this.GetStatus(id, 2) <= 0)
		{
			if (this.IsStatusAbnormal(id, 43))
			{
				this.SetStatus(id, 2, 1);
				this.SetStatus(id, 19, 0);
				this.CancelStatusAbnormal(id, 43);
				this.SetAbIcon(id);
			}
			else
			{
				this.SetStatus(id, 2, 0);
				this.SetStatus(id, 19, 1);
				for (int i = 0; i < 49; i++)
				{
					this.CancelStatusAbnormal(id, i);
				}
				this.SetStatus(id, 25, 255);
				this.BattleGtwRemove(id);
			}
		}
		int num2;
		int num = (num2 = 0);
		for (int i = 0; i < 4; i++)
		{
			if (this.GetStatus(i, 20) == 0)
			{
				num++;
				if (this.GetStatus(i, 19) != 0)
				{
					num2++;
				}
			}
		}
		return num2 == num;
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x000F553C File Offset: 0x000F373C
	public virtual bool AllPlayerDamage()
	{
		for (int i = 0; i < 4; i++)
		{
			int num = this.GetRanks(i);
			if (num != 255 && this.GetStatus(num, 19) == 0 && this.GetStatus(num, 20) == 0)
			{
				this.HpDec(num, this.work[10 + num]);
				if (this.GetStatus(num, 2) <= 0)
				{
					if (this.IsStatusAbnormal(num, 43))
					{
						this.SetStatus(num, 2, 1);
						this.SetStatus(num, 19, 0);
						this.CancelStatusAbnormal(num, 43);
						this.SetAbIcon(num);
					}
					else
					{
						this.SetStatus(num, 2, 0);
						this.SetStatus(num, 19, 1);
						for (int j = 0; j < 49; j++)
						{
							this.CancelStatusAbnormal(num, j);
						}
						this.SetStatus(num, 25, 255);
						this.BattleGtwRemove(num);
					}
				}
			}
		}
		int num3;
		int num2 = (num3 = 0);
		for (int i = 0; i < 4; i++)
		{
			if (this.GetStatus(i, 20) == 0)
			{
				num2++;
				if (this.GetStatus(i, 19) != 0)
				{
					num3++;
				}
			}
		}
		return num3 == num2;
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x000F5650 File Offset: 0x000F3850
	public virtual void ActionStsInit()
	{
		for (int i = 0; i < 4; i++)
		{
			this.SetStatus(i, 23, 0);
		}
		for (int i = 0; i < this.ep; i++)
		{
			this.SetEnemyStatus(i, 37, 0);
		}
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x000F5690 File Offset: 0x000F3890
	public virtual void BattleRedrawClear()
	{
		for (int i = 0; i < 5; i++)
		{
			this.bred[i] = false;
		}
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x000F56B4 File Offset: 0x000F38B4
	public virtual void BattleRedrawNextFrame()
	{
		for (int i = 0; i < 5; i++)
		{
			this.bred[i] = this.bredn[i];
		}
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x000F56E0 File Offset: 0x000F38E0
	public virtual void BattleRedrawNClear()
	{
		for (int i = 0; i < 5; i++)
		{
			this.bredn[i] = false;
		}
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x000F5702 File Offset: 0x000F3902
	public virtual void BattleRedraw(int no)
	{
		this.bred[no] = true;
	}

	// Token: 0x06000C19 RID: 3097 RVA: 0x000F570D File Offset: 0x000F390D
	public virtual void BattleRedrawN(int no)
	{
		this.bredn[no] = true;
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x000F5718 File Offset: 0x000F3918
	public virtual int GetGtw(int no)
	{
		if (no < 0 || no >= 8)
		{
			return 0;
		}
		return this.gtw[no];
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x000F572C File Offset: 0x000F392C
	public virtual void SetGtw(int no, int num)
	{
		if (no < 0 || no >= 8)
		{
			return;
		}
		this.gtw[no] = num;
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x000F5740 File Offset: 0x000F3940
	public virtual int GetRanks(int no)
	{
		if (no < 0 || no >= 4)
		{
			return 255;
		}
		return this.ranks[no];
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x000F5758 File Offset: 0x000F3958
	public virtual void SetRanks(int no, int id)
	{
		if (no < 0 || no >= 4)
		{
			return;
		}
		if ((id < 0 || id >= 4) && id != 255)
		{
			return;
		}
		this.ranks[no] = id;
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x000F577D File Offset: 0x000F397D
	public virtual int GetStatus(int id, int no)
	{
		if (id < 0 || id >= 4)
		{
			return 0;
		}
		if (no < 0 || no >= 26)
		{
			return 0;
		}
		return this.status[id][no];
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x000F579E File Offset: 0x000F399E
	public virtual void SetStatus(int id, int no, int num)
	{
		if (id < 0 || id >= 4)
		{
			return;
		}
		if (no < 0 || no >= 26)
		{
			return;
		}
		this.status[id][no] = num;
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x000F57BE File Offset: 0x000F39BE
	public virtual int GetEnemyStatus(int id, int no)
	{
		if (id < 0 || id >= this.ep)
		{
			return 0;
		}
		if (no < 0 || no >= 40)
		{
			return 0;
		}
		return this.estatus[id][no];
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x000F57E4 File Offset: 0x000F39E4
	public virtual int GetEnemyStatus2(int id, int no)
	{
		if (id < 0 || id >= 4)
		{
			return 0;
		}
		if (no < 0 || no >= 40)
		{
			return 0;
		}
		return this.estatus[id][no];
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x000F5805 File Offset: 0x000F3A05
	public virtual void SetEnemyStatus(int id, int no, int num)
	{
		if (id < 0 || id >= this.ep)
		{
			return;
		}
		if (no < 0 || no >= 40)
		{
			return;
		}
		this.estatus[id][no] = num;
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x000F582A File Offset: 0x000F3A2A
	public virtual void SetEnemyStatus2(int id, int no, int num)
	{
		if (id < 0 || id >= 4)
		{
			return;
		}
		if (id < 0 || no >= 40)
		{
			return;
		}
		this.estatus[id][no] = num;
	}

	// Token: 0x06000C24 RID: 3108 RVA: 0x000F584A File Offset: 0x000F3A4A
	public virtual int GetPlyNAtkParam(int id, int menu, int no)
	{
		if (id < 0 || id >= 4)
		{
			return 0;
		}
		if (menu < 0 || menu >= 6)
		{
			return 0;
		}
		if (no < 0 || no >= 9)
		{
			return 0;
		}
		return this.PlyNAtkParam[id][menu][no];
	}

	// Token: 0x06000C25 RID: 3109 RVA: 0x000F5877 File Offset: 0x000F3A77
	public virtual string GetPlyNAtkName(int id, int menu)
	{
		if (id < 0 || id >= 4)
		{
			return string.Empty;
		}
		if (menu < 0 || menu >= 6)
		{
			return string.Empty;
		}
		return this.PlyNAtkName[id][menu];
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x000F589F File Offset: 0x000F3A9F
	public virtual int GetPlySAtkParam(int id, int menu, int no)
	{
		if (id < 0 || id >= 4)
		{
			return 0;
		}
		if (menu < 0 || menu >= 6)
		{
			return 0;
		}
		if (no < 0 || no >= 12)
		{
			return 0;
		}
		return this.PlySAtkParam[id][menu][no];
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x000F58CC File Offset: 0x000F3ACC
	public virtual string GetPlySAtkName(int id, int menu)
	{
		if (id < 0 || id >= 4)
		{
			return string.Empty;
		}
		if (menu < 0 || menu >= 6)
		{
			return string.Empty;
		}
		return this.PlySAtkName[id][menu];
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x000F58F4 File Offset: 0x000F3AF4
	public virtual int GetPlyEtParam(int id, int menu, int no)
	{
		if (id < 0 || id >= 4)
		{
			return 0;
		}
		int num = this.PlyEtPiece[id];
		if (menu < 0 || menu >= num)
		{
			return 0;
		}
		if (no < 0 || no >= 8)
		{
			return 0;
		}
		return this.PlyEtParam[id][menu][no];
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x000F5934 File Offset: 0x000F3B34
	public virtual string GetPlyEtName(int id, int menu)
	{
		if (id < 0 || id >= 4)
		{
			return string.Empty;
		}
		int num = this.PlyEtPiece[id];
		if (menu < 0 || menu >= num)
		{
			return string.Empty;
		}
		return this.PlyEtName[id][menu];
	}

	// Token: 0x06000C2A RID: 3114 RVA: 0x000F5970 File Offset: 0x000F3B70
	public virtual int GetItemData(int id, int no)
	{
		if (id < 0 || id >= 66)
		{
			return 0;
		}
		if (no < 0 || no >= 4)
		{
			return 0;
		}
		return this.ItemData[id][no];
	}

	// Token: 0x06000C2B RID: 3115 RVA: 0x000F5991 File Offset: 0x000F3B91
	public virtual string GetEneName(int no)
	{
		if (no < 0 || no >= 13)
		{
			return string.Empty;
		}
		return this.EneName[no];
	}

	// Token: 0x06000C2C RID: 3116 RVA: 0x000F59AA File Offset: 0x000F3BAA
	public virtual int GetEneNAtkParam(int no, int menu)
	{
		if (no < 0 || no >= 11)
		{
			return 0;
		}
		if (menu < 0 || menu >= 6)
		{
			return 0;
		}
		return this.EneNAtkParam[no][menu];
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x000F59CB File Offset: 0x000F3BCB
	public virtual int GetEneSAtkParam(int no, int menu)
	{
		if (no < 0 || no >= 23)
		{
			return 0;
		}
		if (menu < 0 || menu >= 7)
		{
			return 0;
		}
		return this.EneSAtkParam[no][menu];
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x000F59EC File Offset: 0x000F3BEC
	public virtual string GetEneSAtkExp(int no, int menu)
	{
		if (no < 0 || no >= 23)
		{
			return string.Empty;
		}
		if (menu < 0 || menu >= 4)
		{
			return string.Empty;
		}
		return this.EneSAtkExp[no][menu];
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x000F5A18 File Offset: 0x000F3C18
	public virtual void BattleInit()
	{
		this.SetLoading(true);
		int num;
		int num2;
		if (this.battleno >= 4 && this.battleno <= 9)
		{
			this.eneimg = new Image[6];
			this.readbuf = this.GetResource2(10);
			for (int i = 0; i < 6; i++)
			{
				int[] archive = XenoPP06Canvas.GetArchive2(this.readbuf, i);
				num = archive[0];
				num2 = archive[1];
				this.eneimg[i] = this.BuildImage(this.readbuf, num, num2);
			}
		}
		else if (this.battleno == 0 || this.battleno == 1 || this.battleno == 10 || this.battleno == 11)
		{
			this.eneimg = new Image[4];
			this.readbuf = this.GetResource2(11);
			for (int i = 0; i < 4; i++)
			{
				int[] archive2 = XenoPP06Canvas.GetArchive2(this.readbuf, i);
				num = archive2[0];
				num2 = archive2[1];
				this.eneimg[i] = this.BuildImage(this.readbuf, num, num2);
			}
		}
		else
		{
			this.eneimg = new Image[3];
			this.readbuf = this.GetResource2(9);
			for (int i = 0; i < 3; i++)
			{
				int[] archive3 = XenoPP06Canvas.GetArchive2(this.readbuf, i);
				num = archive3[0];
				num2 = archive3[1];
				this.eneimg[i] = this.BuildImage(this.readbuf, num, num2);
			}
		}
		if (0 <= this.mapno && this.mapno <= 4)
		{
			this.readbuf = this.GetResource2(2);
		}
		else if (7 <= this.mapno && this.mapno <= 9)
		{
			this.readbuf = this.GetResource2(3);
		}
		else if (this.battleno == 11)
		{
			this.readbuf = this.GetResource2(5);
		}
		else if (10 <= this.mapno && this.mapno <= 25)
		{
			this.readbuf = this.GetResource2(4);
		}
		int[] archive4 = XenoPP06Canvas.GetArchive2(this.readbuf, 0);
		num = archive4[0];
		num2 = archive4[1];
		this.bbgimg = this.BuildImage(this.readbuf, num, num2);
		this.readbuf = null;
		this.SetLoading(false);
		this.bslotno = this.GetRand(0, 3);
		this.bslotmove = 0;
		for (int i = 0; i < 4; i++)
		{
			this.SetStatus(i, 17, 0);
			this.SetStatus(i, 16, 0);
			this.SetStatus(i, 6, 0);
			this.SetStatus(i, 24, 0);
			this.SetStatus(i, 25, 255);
			this.SetGuard(i, 0);
		}
		this.StatusAbnormalInit();
		for (int i = 0; i < 8; i++)
		{
			this.SetGtw(i, 255);
		}
		this.gtwp = 0;
		this.isboost[0] = false;
		this.isboost[1] = false;
		this.iscboost = false;
		this.boostno = 0;
		this.getexp = 0;
		if (this.battleno == 0)
		{
			this.EnemySet(3);
		}
		else if (this.battleno == 1)
		{
			this.EnemySet(4);
		}
		else if (this.battleno == 11)
		{
			this.EnemySet(5);
		}
		else if (this.battleno >= 4 && this.battleno <= 10)
		{
			this.EnemySet(2);
		}
		else if (0 <= this.mapno && this.mapno <= 4)
		{
			this.EnemySet(0);
		}
		else
		{
			this.EnemySet(1);
		}
		this.BattleRedrawClear();
		this.BattleRedrawNClear();
		this.nextmenup = 0;
		for (int i = 0; i < 4; i++)
		{
			this.nextmenu[i] = -1;
		}
		if (this.battleno == 11)
		{
			this.PlayerStatusMax();
		}
		this.StopAllSound();
		if (this.battleno == 0 || this.battleno == 1)
		{
			this.SetBgm(3);
		}
		else if (this.battleno >= 4 && this.battleno <= 10)
		{
			this.SetBgm(3);
		}
		else if (this.battleno == 11)
		{
			this.SetBgm(4);
		}
		else
		{
			this.SetBgm(2);
		}
		this.PlayBgm();
		this.KeyClear();
		this.SetSeqNo(3);
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x000F5DCC File Offset: 0x000F3FCC
	public virtual void BattleRoutine()
	{
		this.BattleRedrawNextFrame();
		this.BattleRedrawNClear();
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.StopVib();
			this.isupdate = true;
			this.ActionStsInit();
			this.SetBattleMenuStackDelete();
			this.WorkClear();
			this.SetSeqStep(1);
			this.StartFade(0);
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 1:
			if (this.IsFade() == 0)
			{
				this.SetSeqStep(2);
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 2:
		{
			this.BattleGtwInit();
			this.crtl = 0;
			for (int i = 0; i < 4; i++)
			{
				this.atkst[i] = 0;
			}
			this.work[0] = (this.work[1] = 0);
			if (this.GetGtw(0) <= 3)
			{
				this.SetSeqStep(3);
			}
			else
			{
				this.SetSeqStep(27);
			}
			break;
		}
		case 3:
			if (this.IsStatusAbnormal(this.GetGtw(0), 19))
			{
				this.StatusAbRoutine(this.GetGtw(0));
				this.SetSeqStep(11);
			}
			else if (this.IsStatusAbnormal(this.GetGtw(0), 22))
			{
				this.BattleRedraw(0);
				this.BattleRedraw(3);
				this.BattleRedraw(4);
				this.ConfusionAttackInit();
				this.ApRecover(this.GetGtw(0));
				this.BoostGagePlus(10);
				this.ApMinus(this.GetGtw(0), 2);
				if (this.cur[0] == 0)
				{
					if (this.atkst[this.cur[1]] == 2)
					{
						this.work[15] = 0;
					}
					else
					{
						this.work[15] = 1;
					}
					this.SetSeqStep(46);
				}
				else
				{
					this.StartVib(30);
					this.SetSeqStep(44);
				}
			}
			else
			{
				this.ismenu[0] = false;
				this.cur[1] = 0;
				if (this.GetEnemyStatus(this.cur[1], 34) != 0)
				{
					this.EneCursorRight();
				}
				this.ApRecover(this.GetGtw(0));
				this.SetBattleMenu(this.GetGtw(0));
				this.IsBoostEnable2();
				if (!this.isboost[0])
				{
					this.SetMenu(0);
				}
				this.bsmenu = 0;
				this.SetSeqStep(4);
				this.BattleRedraw(0);
				this.BattleRedraw(3);
				this.BattleRedraw(4);
			}
			break;
		case 4:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.BattleEnemySelRelease();
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			this.BattleRedraw(4);
			break;
		case 5:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.work[0] = this.GetDmg(this.GetGtw(0), this.cur[1]);
			this.work[1] = 0;
			if (this.nowmenu >= 16)
			{
				this.BoostGagePlus(20);
				this.work[15] = 1;
				this.SetSeqStep(6);
				int num = this.GetPlySAtkParam(this.GetGtw(0), this.nowmenu - 16, 11);
				if (num == 2 || num == 3 || num == 6 || num == 7 || num == 12 || num == 15)
				{
					this.work[0] = 65535;
					this.SetSpAllEnemyDamage(this.GetGtw(0));
				}
			}
			else
			{
				this.BoostGagePlus(10);
				if (this.atkst[this.cur[1]] == 2)
				{
					this.work[15] = 0;
				}
				else
				{
					this.work[15] = 1;
				}
				this.SetSeqStep(8);
			}
			this.BattleRedraw(2);
			this.BattleRedraw(0);
			this.BattleRedraw(4);
			break;
		case 6:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.work[1]++;
			if (this.work[1] >= 32)
			{
				this.work[1] = 0;
				this.work[15] = 0;
				this.SetSeqStep(7);
			}
			this.BattleRedraw(2);
			this.BattleRedraw(0);
			this.BattleRedraw(4);
			break;
		case 7:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.work[1]++;
			if (this.work[1] >= this.GetSpAttackRoutineMax(this.GetGtw(0), this.nowmenu - 16))
			{
				this.work[1] = 0;
				this.work[15] = 0;
				this.SetSeqStep(9);
			}
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 8:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.work[1]++;
			if (this.work[1] == 1)
			{
				this.PlayNAtkSe();
			}
			if (this.work[1] >= 2 && this.GetGtw(0) == 3 && (this.nowmenu == 2 || this.nowmenu == 3))
			{
				this.PlayNAtkSe();
			}
			if (this.work[1] >= 5)
			{
				this.work[1] = 0;
				this.work[15]++;
				if (this.work[15] >= 2)
				{
					this.work[15] = 0;
					this.SetSeqStep(9);
				}
			}
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 9:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.work[1]++;
			if (this.work[1] < 16)
			{
				this.work[1]++;
			}
			else if (this.work[1] >= 32 && this.work[1] >= 32)
			{
				this.work[1] = 0;
				if (this.work[0] != 65535)
				{
					this.EnemyDamage();
				}
				else
				{
					this.EnemyAllDamage();
				}
				int num2 = this.cur[1];
				if (this.IsStatusAbnormal(num2 + 4, 22) && this.GetRand(0, 99) < 15)
				{
					this.CancelStatusAbnormal(num2 + 4, 22);
				}
				if (!this.IsStatusAbnormal(num2 + 4, 19) && !this.iscboost && this.IsEneBoostEnable(num2) && this.IsCBoostEnable(num2))
				{
					this.PlaySe(4);
					this.SetEneBoost(num2);
					this.BattleRedraw(3);
				}
				if (this.nowmenu >= 16)
				{
					this.AglWaitClear(this.GetGtw(0));
					this.AglWait(this.GetGtw(0), this.nowmenu - 16, 0);
					if (this.GetStatus(this.GetGtw(0), 23) == 2)
					{
						this.AglWait2(this.GetGtw(0), 10);
					}
					if (this.EnemyDead())
					{
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(10);
					}
					else if (this.GetRand(0, 99) < 30 && this.GetEnemyStatus(this.cur[1], 0) >= 0 && this.GetEnemyStatus(this.cur[1], 0) <= 3 && this.GetPlySAtkParam(this.GetGtw(0), this.nowmenu - 16, 5) == 19)
					{
						this.work[1] = 0;
						this.work[4] = this.cur[1] + 4;
						this.work[8] = 58;
						this.SetSeqStep(42);
					}
					else if (this.work[0] == 65535 && this.GetPlySAtkParam(this.GetGtw(0), this.nowmenu - 16, 5) == 22)
					{
						this.work[1] = 0;
						this.work[4] = 0;
						int num3 = 0;
						for (int j = 0; j < this.ep; j++)
						{
							if (this.GetEnemyStatus(j, 34) == 0 && this.GetRand(0, 99) < 30)
							{
								this.work[4 + j] = 1;
								num3++;
							}
						}
						if (num3 != 0)
						{
							this.work[8] = 46;
							this.SetSeqStep(42);
						}
						else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
						{
							this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
							this.work[1] = 0;
							this.cur[1] = this.GetGtw(0);
							this.SetSeqStep(30);
						}
						else
						{
							this.StatusAbRoutine(this.GetGtw(0));
							this.SetSeqStep(11);
						}
					}
					else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
					{
						this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
						this.work[1] = 0;
						this.cur[1] = this.GetGtw(0);
						this.SetSeqStep(30);
					}
					else
					{
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(11);
					}
				}
				else if (this.nextmenup >= 1 || this.bmenup >= 1)
				{
					this.SetSeqStep(4);
				}
				else
				{
					this.AglWaitClear(this.GetGtw(0));
					if (this.GetStatus(this.GetGtw(0), 23) == 2)
					{
						this.AglWait2(this.GetGtw(0), 10);
					}
					if (this.EnemyDead())
					{
						this.SetSeqStep(10);
					}
					else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
					{
						this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
						this.work[1] = 0;
						this.cur[1] = this.GetGtw(0);
						this.SetSeqStep(30);
					}
					else
					{
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(11);
					}
				}
			}
			this.BattleRedraw(2);
			this.BattleRedraw(4);
			break;
		case 10:
			this.work[1]++;
			if (this.work[1] == 1 && this.battleno != 0 && this.battleno != 1 && this.battleno != 11)
			{
				this.PlaySe(11);
			}
			if (this.work[1] > 16)
			{
				this.EnemyDeadAfter();
				if (this.EnemyDestroy())
				{
					this.SetMenu(4);
					this.StartFade(1);
					this.SetSeqStep(39);
				}
				else if (this.work[0] == 65535 && this.nowmenu >= 16 && this.GetPlySAtkParam(this.GetGtw(0), this.nowmenu - 16, 5) == 22)
				{
					this.work[1] = 0;
					this.work[4] = 0;
					int num4 = 0;
					for (int k = 0; k < this.ep; k++)
					{
						if (this.GetEnemyStatus(k, 34) == 0 && this.GetRand(0, 99) < 30)
						{
							this.work[4 + k] = 1;
							num4++;
						}
					}
					if (num4 != 0)
					{
						this.work[8] = 46;
						this.SetSeqStep(42);
					}
					else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
					{
						this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
						this.work[1] = 0;
						this.cur[1] = this.GetGtw(0);
						this.SetSeqStep(30);
					}
					else
					{
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(11);
					}
				}
				else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(2);
			break;
		case 11:
			this.SetBattleMenuStackDelete();
			this.bslotmove = (this.bslotmove + 4) % 32;
			if (this.bslotmove == 0)
			{
				this.bslotno = (this.bslotno + 1) % 4;
				this.SetSeqStep(12);
			}
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			break;
		case 12:
			this.BattleGtwNext();
			this.work[0] = (this.work[1] = 0);
			if (this.gtwp <= 0)
			{
				this.SetSeqStep(2);
			}
			else if (this.GetGtw(0) <= 3)
			{
				this.SetSeqStep(3);
			}
			else
			{
				this.SetSeqStep(27);
			}
			this.BattleRedraw(3);
			break;
		case 13:
			if (!this.isboost[0])
			{
				if ((this.id_edge & 1) != 0)
				{
					this.MenuCursorUp();
				}
				else if ((this.id_edge & 2) != 0)
				{
					this.MenuCursorDown();
				}
				else if ((this.id_edge & 256) != 0 || (this.id_edge & 512) != 0 || (this.id_edge & 1024) != 0 || (this.id_edge & 4112) != 0)
				{
					if ((this.id_edge & 4112) == 0)
					{
						this.BattleMenuSC();
					}
					if (this.cur[0] == 0)
					{
						if (!this.etheruse)
						{
							this.PlaySe(5);
							return;
						}
						if (this.IsStatusAbnormal(this.GetGtw(0), 24))
						{
							this.PlaySe(5);
							return;
						}
						this.SetEtherMenu(this.GetGtw(0));
						this.SetSeqStep(14);
					}
					else if (this.cur[0] == 1)
					{
						this.SetItemMenu();
						this.SetSeqStep(22);
					}
					else if (this.cur[0] == 2)
					{
						this.ApMinus(this.GetGtw(0), 2);
						this.SetGuard(this.GetGtw(0), 1);
						this.ismenu[0] = false;
						this.SetMenu(0);
						this.bsmenu = 0;
						this.AglWaitClear(this.GetGtw(0));
						if (this.GetStatus(this.GetGtw(0), 23) == 2)
						{
							this.AglWait2(this.GetGtw(0), 10);
						}
						if (this.IsStatusAbnormal(this.GetGtw(0), 17))
						{
							this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
							this.work[1] = 0;
							this.cur[1] = this.GetGtw(0);
							this.SetSeqStep(30);
						}
						else
						{
							this.StatusAbRoutine(this.GetGtw(0));
							this.SetSeqStep(11);
						}
					}
					else if (this.cur[0] == 3)
					{
						this.cur[0] = 0;
						this.ismenu[0] = false;
						this.SetMenu(0);
						this.bsmenu = 0;
						this.SetBattleMenu(this.GetGtw(0));
						if (this.GetEnemyStatus(this.cur[1], 34) != 0)
						{
							this.EneCursorRight();
						}
						this.SetSeqStep(4);
					}
				}
				else if (this.ismenu[0])
				{
					this.cur[0] = 0;
					this.ismenu[0] = false;
					this.SetMenu(0);
					this.bsmenu = 0;
					this.SetBattleMenu(this.GetGtw(0));
					if (this.GetEnemyStatus(this.cur[1], 34) != 0)
					{
						this.EneCursorRight();
					}
					this.SetSeqStep(4);
				}
			}
			this.BattleRedraw(4);
			break;
		case 14:
			if (!this.isboost[0])
			{
				if ((this.id_edge & 1) != 0)
				{
					this.MenuCursorUp();
				}
				else if ((this.id_edge & 2) != 0)
				{
					this.MenuCursorDown();
				}
				else if ((this.id_edge & 256) != 0 || (this.id_edge & 512) != 0 || (this.id_edge & 1024) != 0 || (this.id_edge & 4112) != 0)
				{
					if ((this.id_edge & 4112) == 0)
					{
						this.BattleMenuSC();
					}
					if (this.GetBMenu(this.cur[0], 0) == 128)
					{
						this.cur[0] = 0;
						this.ismenu[0] = false;
						this.SetMenu(1);
						this.bsmenu = 1;
						this.SetSubMenu();
						this.SetSeqStep(13);
					}
					else
					{
						this.ismenu[0] = false;
						this.work[0] = (this.work[1] = 0);
						this.work[2] = this.GetGtw(0);
						this.work[3] = this.GetBMenu(this.cur[0], 0);
						int num5 = 1;
						if (this.IsStatusAbnormal(this.work[2], 25))
						{
							num5 = 2;
						}
						if (this.GetPlyEtParam(this.work[2], this.work[3], 0) * num5 > this.GetStatus(this.work[2], 4))
						{
							this.SetMenu(1);
							this.bsmenu = 1;
							this.work[16] = 14;
							this.work[17] = 0;
							this.SetSeqStep(36);
							return;
						}
						if (this.GetPlyEtParam(this.work[2], this.work[3], 3) != 41)
						{
							if (this.GetPlyEtParam(this.work[2], this.work[3], 1) == 0)
							{
								this.cur[0] = 0;
								this.cur[1] = 0;
								this.EtherMenuCursorChange();
							}
							else if (this.GetPlyEtParam(this.work[2], this.work[3], 1) == 7)
							{
								for (int l = 0; l < 4; l++)
								{
									if (this.GetStatus(this.GetRanks(l), 19) == 1 && this.GetStatus(this.GetRanks(l), 20) == 0)
									{
										this.cur[0] = l;
										break;
									}
								}
								this.cur[1] = 0;
							}
							else
							{
								this.cur[0] = 0;
								this.cur[1] = 0;
								for (int m = 0; m < 4; m++)
								{
									if (this.GetRanks(m) == this.work[2])
									{
										this.cur[0] = m;
										break;
									}
								}
							}
							this.SetMenu(1);
							this.bsmenu = 1;
							this.SetSeqStep(21);
							this.BattleRedrawN(4);
							return;
						}
						if (this.battleno != 255)
						{
							this.SetMenu(1);
							this.bsmenu = 1;
							this.work[16] = 14;
							this.work[17] = 0;
							this.SetSeqStep(35);
							return;
						}
						this.ApMinus(this.GetGtw(0), 4);
						this.EpMinus(this.GetGtw(0), this.GetPlyEtParam(this.work[2], this.work[3], 0));
						this.BattleRedraw(0);
						this.StarWorkInit();
						this.PlaySe(4);
						this.SetSeqStep(33);
						this.cur[0] = (this.cur[1] = (this.cur[2] = 0));
					}
				}
				else if (this.ismenu[0])
				{
					this.cur[0] = 0;
					this.ismenu[0] = false;
					this.SetMenu(1);
					this.bsmenu = 1;
					this.SetSubMenu();
					this.SetSeqStep(13);
				}
			}
			this.BattleRedraw(4);
			break;
		case 15:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				this.work[1] = 0;
				this.EtherEffectInit(this.work[6]);
				this.SetSeqStep(16);
			}
			this.BattleRedraw(2);
			break;
		case 16:
		{
			this.work[1]++;
			int num = this.GetPlyEtParam(this.work[2], this.work[3], 3);
			if (this.work[1] == 1 && num != 47 && num != 48)
			{
				this.PlayEtherSe(this.GetPlyEtParam(this.work[2], this.work[3], 3));
			}
			if (num == 44 || num == 47 || num == 48)
			{
				if (this.IsSpEtherEffectEnd(this.work[1], num))
				{
					this.work[1] = 16;
					this.EtherExecNumCalc(this.work[2], this.work[3], this.work[4]);
					this.SetSeqStep(17);
				}
			}
			else if (this.IsEtherEffectEnd(this.work[1], this.work[6]))
			{
				this.work[1] = 0;
				this.EtherExecNumCalc(this.work[2], this.work[3], this.work[4]);
				this.SetSeqStep(17);
			}
			else if (this.work[6] == 2)
			{
				this.RecoverEffectRoutine();
			}
			else if (this.work[6] == 1)
			{
				this.SupportEffectRoutine();
			}
			else if (this.work[6] == 0)
			{
				this.AttackEffectRoutine();
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			break;
		}
		case 17:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				this.work[1] = 0;
				this.BattleRedrawN(0);
				this.BattleRedrawN(2);
				this.AglWaitClear(this.GetGtw(0));
				if (this.GetStatus(this.GetGtw(0), 23) == 2)
				{
					this.AglWait2(this.GetGtw(0), 10);
				}
				else
				{
					this.AglWait(this.GetGtw(0), this.work[3], 1);
				}
				this.ApMinus(this.GetGtw(0), 4);
				this.EpMinus(this.GetGtw(0), this.GetPlyEtParam(this.work[2], this.work[3], 0));
				if (this.EtherExec(this.work[2], this.work[3], this.work[4]))
				{
					int num = this.GetPlyEtParam(this.work[2], this.work[3], 3);
					if (num == 44)
					{
						this.SetSeqStep(18);
					}
					else if (num == 46)
					{
						this.SetSeqStep(19);
					}
					else if (num == 47 || num == 48)
					{
						this.SetSeqStep(20);
					}
				}
				else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			break;
		case 18:
			if (!this.isboost[0] && ((this.id_edge & 4112) != 0 || this.ismenu[0]))
			{
				this.ismenu[0] = false;
				this.BattleRedrawN(2);
				if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(2);
			break;
		case 19:
			if (!this.isboost[0] && ((this.id_edge & 4112) != 0 || this.ismenu[0]))
			{
				this.ismenu[0] = false;
				this.work[1] = 0;
				this.BattleRedrawN(2);
				if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(2);
			break;
		case 20:
			this.work[1]++;
			if (this.work[1] < 16)
			{
				this.work[1]++;
			}
			else if (this.work[1] >= 32 && this.work[1] >= 32)
			{
				this.work[1] = 0;
				this.EnemyDamage2();
				if (this.EnemyDead2())
				{
					this.SetSeqStep(10);
				}
				else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(2);
			this.BattleRedraw(4);
			break;
		case 21:
			if ((this.id_edge & 1) != 0 || (this.id_edge & 2) != 0)
			{
				if (this.GetPlyEtParam(this.work[2], this.work[3], 1) == 6)
				{
					this.EtherMenuCursorChange();
					this.BattleRedraw(0);
					this.BattleRedraw(2);
				}
			}
			else if ((this.id_edge & 4) != 0)
			{
				if (this.GetPlyEtParam(this.work[2], this.work[3], 1) == 0 || this.GetPlyEtParam(this.work[2], this.work[3], 1) == 2 || this.GetPlyEtParam(this.work[2], this.work[3], 1) == 7 || this.GetPlyEtParam(this.work[2], this.work[3], 1) == 6)
				{
					this.EtherMenuCursorLeft(0);
					this.BattleRedraw(0);
					this.BattleRedraw(2);
				}
			}
			else if ((this.id_edge & 8) != 0)
			{
				if (this.GetPlyEtParam(this.work[2], this.work[3], 1) == 0 || this.GetPlyEtParam(this.work[2], this.work[3], 1) == 2 || this.GetPlyEtParam(this.work[2], this.work[3], 1) == 7 || this.GetPlyEtParam(this.work[2], this.work[3], 1) == 6)
				{
					this.EtherMenuCursorRight(0);
					this.BattleRedraw(0);
					this.BattleRedraw(2);
				}
			}
			else if ((this.id_edge & 4112) != 0)
			{
				this.work[0] = (this.work[1] = 0);
				if (this.cur[0] < 4)
				{
					this.work[4] = this.GetRanks(this.cur[0]);
				}
				else
				{
					this.work[4] = this.cur[0];
				}
				if (!this.IsEtherOk(this.work[4], this.work[2], this.work[3]))
				{
					this.SetMenu(1);
					this.bsmenu = 1;
					this.work[16] = 21;
					this.work[17] = 0;
					this.SetSeqStep(38);
					return;
				}
				this.work[5] = this.GetPlyEtParam(this.work[2], this.work[3], 1);
				this.work[6] = this.GetPlyEtParam(this.work[2], this.work[3], 2);
				this.BattleRedraw(0);
				this.BattleRedrawN(4);
				this.PlaySe(12);
				this.SetSeqStep(15);
			}
			else if (this.ismenu[0])
			{
				this.cur[0] = (this.cur[1] = (this.cur[2] = 0));
				this.ismenu[0] = false;
				this.SetEtherMenu(this.GetGtw(0));
				this.BattleRedrawN(0);
				this.BattleRedrawN(2);
				this.SetSeqStep(14);
			}
			break;
		case 22:
			if (!this.isboost[0])
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MenuCursorUp();
				}
				else if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MenuCursorDown();
				}
				else if ((this.id_edge & 256) != 0 || (this.id_edge & 512) != 0 || (this.id_edge & 1024) != 0 || (this.id_edge & 4112) != 0)
				{
					if ((this.id_edge & 4112) == 0)
					{
						this.BattleMenuSC();
					}
					if (this.GetBMenu(this.cur[0], 0) == 128)
					{
						this.cur[0] = 0;
						this.ismenu[0] = false;
						this.SetMenu(1);
						this.bsmenu = 1;
						this.SetSubMenu();
						this.SetSeqStep(13);
					}
					else
					{
						this.ismenu[0] = false;
						this.work[0] = (this.work[1] = 0);
						this.work[2] = this.GetGtw(0);
						this.work[3] = this.GetBMenu(this.cur[0], 0);
						if (this.work[3] == 15)
						{
							if (this.battleno != 255)
							{
								this.SetMenu(1);
								this.bsmenu = 1;
								this.work[16] = 22;
								this.work[17] = 0;
								this.SetSeqStep(34);
								return;
							}
							this.ApMinus(this.GetGtw(0), 3);
							this.DelItem(this.work[3], 1);
							this.BattleRedraw(0);
							this.StarWorkInit();
							this.PlaySe(4);
							this.SetSeqStep(33);
						}
						else
						{
							if (this.GetItemData(this.work[3], 1) == 7)
							{
								for (int n = 0; n < 4; n++)
								{
									if (this.GetStatus(this.GetRanks(n), 19) == 1 && this.GetStatus(this.GetRanks(n), 20) == 0)
									{
										this.cur[0] = n;
										break;
									}
								}
								this.cur[1] = 0;
							}
							else
							{
								this.cur[0] = 0;
								this.cur[1] = 0;
								for (int num6 = 0; num6 < 4; num6++)
								{
									if (this.GetRanks(num6) == this.work[2])
									{
										this.cur[0] = num6;
										break;
									}
								}
							}
							this.work[0] = (this.work[1] = 0);
							this.SetMenu(1);
							this.bsmenu = 1;
							this.SetSeqStep(26);
							this.BattleRedrawN(4);
						}
					}
				}
				else if (this.ismenu[0])
				{
					this.cur[0] = 0;
					this.ismenu[0] = false;
					this.SetMenu(1);
					this.bsmenu = 1;
					this.SetSubMenu();
					this.SetSeqStep(13);
				}
			}
			this.BattleRedraw(4);
			break;
		case 23:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				this.work[1] = 0;
				this.EtherEffectInit(this.work[6]);
				this.SetSeqStep(24);
			}
			this.BattleRedraw(2);
			break;
		case 24:
			this.work[1]++;
			if (this.work[1] == 1)
			{
				this.PlayItemSe(this.work[3]);
			}
			if (this.IsEtherEffectEnd(this.work[1], this.work[6]))
			{
				this.work[1] = 0;
				this.ItemExecNumCalc(this.work[3], this.work[4]);
				this.SetSeqStep(25);
			}
			if (this.work[6] == 2)
			{
				this.RecoverEffectRoutine();
			}
			else if (this.work[6] == 1)
			{
				this.SupportEffectRoutine();
			}
			else if (this.work[6] == 0)
			{
				this.AttackEffectRoutine();
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			break;
		case 25:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				this.work[1] = 0;
				this.BattleRedrawN(0);
				this.BattleRedrawN(2);
				this.ItemExec(this.work[3], this.work[4]);
				this.AglWaitClear(this.GetGtw(0));
				if (this.GetStatus(this.GetGtw(0), 23) == 2)
				{
					this.AglWait2(this.GetGtw(0), 10);
				}
				if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			break;
		case 26:
			if ((this.id_edge & 1) != 0 || (this.id_edge & 2) != 0)
			{
				if (this.GetItemData(this.work[3], 1) == 6)
				{
					this.EtherMenuCursorChange();
					this.BattleRedraw(0);
					this.BattleRedraw(2);
				}
			}
			else if ((this.id_edge & 4) != 0)
			{
				this.EtherMenuCursorLeft(1);
				this.BattleRedraw(0);
				this.BattleRedraw(2);
			}
			else if ((this.id_edge & 8) != 0)
			{
				this.EtherMenuCursorRight(1);
				this.BattleRedraw(0);
				this.BattleRedraw(2);
			}
			else if ((this.id_edge & 4112) != 0)
			{
				this.work[0] = (this.work[1] = 0);
				if (this.cur[0] < 4)
				{
					this.work[4] = this.GetRanks(this.cur[0]);
				}
				else
				{
					this.work[4] = this.cur[0];
				}
				if (!this.IsItemOk(this.work[4], this.work[3]))
				{
					this.SetMenu(1);
					this.bsmenu = 1;
					this.work[16] = 26;
					this.work[17] = 0;
					this.SetSeqStep(37);
					return;
				}
				this.work[5] = 6;
				this.work[6] = this.GetItemData(this.work[3], 3);
				this.ApMinus(this.GetGtw(0), 3);
				this.DelItem(this.work[3], 1);
				this.BattleRedraw(0);
				this.BattleRedrawN(4);
				this.SetSeqStep(23);
			}
			else if (this.ismenu[0])
			{
				this.cur[0] = (this.cur[1] = (this.cur[2] = 0));
				this.ismenu[0] = false;
				this.SetItemMenu();
				this.BattleRedrawN(0);
				this.BattleRedrawN(2);
				this.SetSeqStep(22);
			}
			break;
		case 27:
			if (this.IsStatusAbnormal(this.GetGtw(0), 19))
			{
				this.StatusAbRoutine(this.GetGtw(0));
				this.SetSeqStep(11);
			}
			else
			{
				if (this.work[1] == 0)
				{
					this.IsBoostEnable2();
					if (!this.isboost[0])
					{
						this.SetMenu(3);
					}
					this.bsmenu = 3;
					this.EnemyAttackInit();
					if (this.eneatk >= 48)
					{
						this.EneBoostGagePlus(20);
					}
					else
					{
						this.EneBoostGagePlus(10);
					}
					this.BattleRedraw(0);
					this.BattleRedraw(2);
					this.BattleRedraw(3);
					this.BattleRedraw(4);
				}
				this.work[1]++;
				if (this.eneatk >= 48)
				{
					if (this.work[1] > 30)
					{
						if (this.GetEneSAtkParam(this.eneatk - 48, 5) == 0)
						{
							int num = this.GetEneSAtkParam(this.eneatk - 48, 3);
							if (num == 0)
							{
								if (this.cur[0] == 1)
								{
									this.StartVib(30);
								}
								this.work[1] = 0;
								this.SetSeqStep(28);
							}
							else if (num == 1)
							{
								if (this.cur[0] == 1)
								{
									this.StartVib(30);
								}
								this.work[1] = 0;
								this.work[0] = 65535;
								if (this.cur[0] == 0)
								{
									for (int num7 = 0; num7 < this.ep; num7++)
									{
										if (this.GetEnemyStatus(num7, 34) == 0)
										{
											this.work[9 + num7] = this.GetDmg3(num7, this.GetGtw(0) - 4);
										}
									}
								}
								else
								{
									for (int num8 = 0; num8 < 4; num8++)
									{
										if (this.GetStatus(num8, 19) == 0 && this.GetStatus(num8, 20) == 0)
										{
											this.work[10 + num8] = this.GetDmg2(num8, this.GetGtw(0) - 4);
										}
										else
										{
											this.work[10 + num8] = 65535;
										}
									}
								}
								this.SetSeqStep(28);
							}
						}
						else
						{
							this.work[1] = 0;
							this.SetEneSpData();
							this.SetSeqStep(32);
						}
					}
				}
				else if (this.work[1] > 8)
				{
					if (this.cur[0] == 1)
					{
						this.StartVib(30);
					}
					this.work[1] = 0;
					this.SetSeqStep(28);
				}
			}
			break;
		case 28:
		case 30:
			if (this.cur[0] == 1)
			{
				this.qux = this.GetRand(0, 2);
				this.quy = this.GetRand(0, 2);
			}
			this.work[1]++;
			if (this.work[1] > 4)
			{
				this.qux = (this.quy = 0);
				this.work[1] = 0;
				this.StopVib();
				if (this.GetSeqStep() == 30)
				{
					this.SetSeqStep(31);
				}
				else if (this.cur[0] == 0)
				{
					this.SetSeqStep(41);
				}
				else
				{
					this.SetSeqStep(29);
				}
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 29:
		case 31:
			this.work[1]++;
			if (this.work[1] > 16)
			{
				this.work[1] = 0;
				if (this.work[0] == 65535)
				{
					if (this.AllPlayerDamage())
					{
						this.SetMenu(4);
						this.StartFade(1);
						this.SetSeqStep(40);
					}
					else if (this.GetSeqStep() == 29)
					{
						for (int num9 = 0; num9 < 4; num9++)
						{
							int num10 = this.GetRanks(num9);
							if (num10 != 255 && this.GetStatus(num10, 19) == 0 && this.GetStatus(num10, 20) == 0 && this.IsStatusAbnormal(num10, 22) && this.GetRand(0, 99) < 15)
							{
								this.CancelStatusAbnormal(num10, 22);
								this.SetAbIcon(num10);
							}
						}
						if (this.eneatk >= 48 && this.GetEneSAtkParam(this.eneatk - 48, 5) == 0 && this.GetEneSAtkParam(this.eneatk - 48, 6) != 0)
						{
							this.SetEneSpData();
							this.SetSeqStep(32);
						}
						else
						{
							this.StatusAbRoutine(this.GetGtw(0));
							this.SetSeqStep(11);
						}
					}
					else
					{
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(11);
					}
				}
				else if (this.PlayerDamage(this.cur[1]))
				{
					this.SetMenu(4);
					this.StartFade(1);
					this.SetSeqStep(40);
				}
				else if (this.GetSeqStep() == 29 && this.GetStatus(this.cur[1], 19) == 0)
				{
					if (this.IsStatusAbnormal(this.cur[1], 22) && this.GetRand(0, 99) < 15)
					{
						this.CancelStatusAbnormal(this.cur[1], 22);
						this.SetAbIcon(this.cur[1]);
					}
					if (this.eneatk >= 48 && this.GetEneSAtkParam(this.eneatk - 48, 5) == 0 && this.GetEneSAtkParam(this.eneatk - 48, 6) != 0)
					{
						if (this.GetEneSAtkParam(this.eneatk - 48, 6) != 19)
						{
							this.SetEneSpData();
							this.SetSeqStep(32);
						}
						else if (this.GetRand(0, 99) < 30 && this.GetEneSAtkParam(this.eneatk - 48, 6) == 19)
						{
							this.SetEneSpData();
							this.SetSeqStep(32);
						}
						else
						{
							this.StatusAbRoutine(this.GetGtw(0));
							this.SetSeqStep(11);
						}
					}
					else
					{
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(11);
					}
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(0);
			break;
		case 32:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				if (this.work[5] == 1)
				{
					this.HpRecover(this.work[4], this.work[6]);
				}
				else
				{
					this.SetEneSpDataExec();
				}
				this.BattleRedrawN(0);
				this.BattleRedrawN(2);
				this.StatusAbRoutine(this.GetGtw(0));
				this.SetSeqStep(11);
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			break;
		case 33:
			this.BubbleRoutine(1);
			if (this.work[0] == 0)
			{
				this.work[1]++;
				if (this.work[1] >= 32)
				{
					this.work[0] = 1;
					this.work[1] = 0;
					this.SetMenu(4);
					this.StartFade(1);
				}
			}
			else if (this.IsFade() == 3)
			{
				this.StopAllSound();
				this.WorkClear();
				this.SetSeqNo(4);
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 34:
		case 35:
			this.work[17]++;
			if (this.work[17] >= 30)
			{
				this.MenuFlagClear();
				this.work[17] = 0;
				this.SetSeqStep(this.work[16]);
				this.BattleRedrawN(2);
			}
			break;
		case 36:
			this.work[17]++;
			if (this.work[17] >= 30)
			{
				this.MenuFlagClear();
				this.work[17] = 0;
				this.SetSeqStep(this.work[16]);
				this.BattleRedrawN(2);
			}
			break;
		case 37:
		case 38:
			this.work[17]++;
			if (this.work[17] >= 30)
			{
				this.MenuFlagClear();
				this.work[17] = 0;
				this.SetSeqStep(this.work[16]);
				this.BattleRedrawN(2);
			}
			break;
		case 39:
			if (this.IsFade() == 3)
			{
				this.StopAllSound();
				this.SetSeqNo(4);
			}
			break;
		case 40:
			if (this.IsFade() == 3)
			{
				this.xscr.script_b_adr = 65535;
				this.StopAllSound();
				this.eneimg = null;
				this.bbgimg = null;
				this.SetSeqNo(5);
			}
			break;
		case 41:
			this.BattleEnemySelRoutineBef();
			if (!this.isboost[0])
			{
				this.BattleEnemySelRoutine();
			}
			this.work[1]++;
			if (this.work[1] < 16)
			{
				this.work[1]++;
			}
			else if (this.work[1] < 32)
			{
				if (this.work[1] == 31)
				{
					int num11 = this.cur[1];
					if (this.IsStatusAbnormal(num11 + 4, 22) && this.GetRand(0, 99) < 15)
					{
						this.CancelStatusAbnormal(num11 + 4, 22);
					}
					if (!this.IsStatusAbnormal(num11 + 4, 19) && !this.iscboost && this.IsEneBoostEnable(num11) && this.IsCBoostEnable(num11))
					{
						this.PlaySe(4);
						this.SetEneBoost(num11);
						this.BattleRedraw(3);
					}
				}
			}
			else if (this.work[1] >= 32)
			{
				this.work[1] = 0;
				if (this.work[0] != 65535)
				{
					this.EnemyDamage();
				}
				else
				{
					this.EnemyAllDamage();
				}
				this.StatusAbRoutine(this.GetGtw(0));
				this.SetSeqStep(11);
				if (this.EnemyDead())
				{
					this.work[0] = 0;
					this.SetSeqStep(10);
				}
			}
			this.BattleRedraw(2);
			this.BattleRedraw(4);
			break;
		case 42:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				if (this.work[8] == 58)
				{
					this.est_ab[this.cur[1]][19] = 5;
				}
				else
				{
					for (int num12 = 0; num12 < this.ep; num12++)
					{
						if (this.GetEnemyStatus(num12, 34) == 0 && this.work[4 + num12] != 0)
						{
							this.est_ab[num12][22] = 5;
						}
					}
				}
				this.BattleRedrawN(0);
				this.BattleRedrawN(2);
				if (this.IsStatusAbnormal(this.GetGtw(0), 17))
				{
					this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
					this.work[1] = 0;
					this.cur[1] = this.GetGtw(0);
					this.SetSeqStep(30);
				}
				else
				{
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			break;
		case 43:
			this.work[1]++;
			if (this.work[1] < 16)
			{
				this.work[1]++;
			}
			else if (this.work[1] < 32)
			{
				if (this.work[1] == 31)
				{
					int num13 = this.cur[1];
					if (this.IsStatusAbnormal(num13 + 4, 22) && this.GetRand(0, 99) < 15)
					{
						this.CancelStatusAbnormal(num13 + 4, 22);
					}
					if (!this.IsStatusAbnormal(num13 + 4, 19) && !this.iscboost && this.IsEneBoostEnable(num13) && this.IsCBoostEnable(num13))
					{
						this.PlaySe(4);
						this.SetEneBoost(num13);
						this.BattleRedraw(3);
					}
				}
			}
			else if (this.work[1] >= 32)
			{
				this.work[1] = 0;
				if (this.work[0] != 65535)
				{
					this.EnemyDamage();
				}
				else
				{
					this.EnemyAllDamage();
				}
				this.StatusAbRoutine(this.GetGtw(0));
				this.SetSeqStep(11);
				if (this.EnemyDead())
				{
					this.SetSeqStep(10);
				}
			}
			this.BattleRedraw(2);
			this.BattleRedraw(4);
			break;
		case 44:
			this.qux = this.GetRand(0, 2);
			this.quy = this.GetRand(0, 2);
			this.work[1]++;
			if (this.work[1] > 4)
			{
				this.qux = (this.quy = 0);
				this.work[1] = 0;
				this.StopVib();
				this.SetSeqStep(45);
			}
			this.BattleRedraw(0);
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		case 45:
			this.work[1]++;
			if (this.work[1] > 16)
			{
				this.work[1] = 0;
				if (this.work[0] == 65535)
				{
					if (this.AllPlayerDamage())
					{
						this.SetMenu(4);
						this.StartFade(1);
						this.SetSeqStep(40);
					}
					else
					{
						for (int num14 = 0; num14 < 4; num14++)
						{
							int num15 = this.GetRanks(num14);
							if (num15 != 255 && this.GetStatus(num15, 19) == 0 && this.GetStatus(num15, 20) == 0 && this.IsStatusAbnormal(num15, 22) && this.GetRand(0, 99) < 15)
							{
								this.CancelStatusAbnormal(num15, 22);
								this.SetAbIcon(num15);
							}
						}
						this.StatusAbRoutine(this.GetGtw(0));
						this.SetSeqStep(11);
					}
				}
				else if (this.PlayerDamage(this.cur[1]))
				{
					this.SetMenu(4);
					this.StartFade(1);
					this.SetSeqStep(40);
				}
				else
				{
					if (this.IsStatusAbnormal(this.cur[1], 22) && this.GetRand(0, 99) < 15)
					{
						this.CancelStatusAbnormal(this.cur[1], 22);
						this.SetAbIcon(this.cur[1]);
					}
					this.StatusAbRoutine(this.GetGtw(0));
					this.SetSeqStep(11);
				}
			}
			this.BattleRedraw(0);
			break;
		case 46:
			this.work[1]++;
			if (this.work[1] == 1)
			{
				this.PlayNAtkSe();
			}
			if (this.work[1] >= 2 && this.GetGtw(0) == 3 && (this.nowmenu == 2 || this.nowmenu == 3))
			{
				this.PlayNAtkSe();
			}
			if (this.work[1] >= 5)
			{
				this.work[1] = 0;
				this.work[15]++;
				if (this.work[15] >= 2)
				{
					this.work[15] = 0;
					this.SetSeqStep(43);
				}
			}
			this.BattleRedraw(2);
			this.BattleRedraw(3);
			this.BattleRedraw(4);
			break;
		}
		if (this.seq_step != 0 && this.seq_step <= 32)
		{
			if (this.ismenu[1] && !this.isboost[1])
			{
				if (this.isboost[0])
				{
					this.isboost[0] = false;
					this.SetMenu(this.bsmenu);
				}
				else if (this.isboost[2])
				{
					this.isboost[0] = true;
					this.SetMenu(2);
				}
				this.BattleRedraw(3);
			}
			this.ismenu[1] = false;
			if (!this.isboost[1] && this.isboost[0])
			{
				bool flag = false;
				if (!this.isboost[2])
				{
					this.isboost[0] = false;
					this.isboost[1] = false;
					this.SetMenu(this.bsmenu);
					this.BattleRedraw(3);
					return;
				}
				int num = 0;
				if ((this.id_edge & 4) != 0)
				{
					num = 0;
					flag = true;
				}
				else if ((this.id_edge & 1) != 0)
				{
					num = 1;
					flag = true;
				}
				else if ((this.id_edge & 8) != 0)
				{
					num = 2;
					flag = true;
				}
				if (flag)
				{
					int num16 = 0;
					while (num16 < 4)
					{
						int num17 = this.GetRanks(num16);
						if (num17 != 255 && this.GetStatus(num17, 20) == 0 && this.IsBoostEnable(num17) && num16 == num)
						{
							if (!this.IsStatusAbnormal(num17, 19) && !this.IsStatusAbnormal(num17, 23))
							{
								this.PlaySe(4);
								this.SetBoost(num17);
								this.SetMenu(this.bsmenu);
								break;
							}
							this.PlaySe(5);
							return;
						}
						else
						{
							num16++;
						}
					}
					this.BattleRedraw(3);
				}
			}
		}
	}

	// Token: 0x06000C31 RID: 3121 RVA: 0x000F8E8C File Offset: 0x000F708C
	public virtual bool IsEtherOk(int id, int useid, int menuno)
	{
		if (id >= 4)
		{
			return true;
		}
		int plyEtParam = this.GetPlyEtParam(useid, menuno, 3);
		if (plyEtParam == 26)
		{
			int num = this.GetStatus(id, 2);
			int num2 = this.GetStatus(id, 3);
			if (num == num2)
			{
				return false;
			}
		}
		else
		{
			if (plyEtParam == 27)
			{
				for (int i = 0; i < 4; i++)
				{
					id = this.GetRanks(i);
					if (id != 255)
					{
						if (this.GetSeqNo() == 3)
						{
							if (this.GetStatus(i, 20) == 0 && this.GetStatus(i, 19) == 0)
							{
								int num3 = this.GetStatus(i, 2);
								int num2 = this.GetStatus(i, 3);
								if (num3 != num2)
								{
									return true;
								}
							}
						}
						else
						{
							int num4 = this.GetStatus(i, 2);
							int num2 = this.GetStatus(i, 3);
							if (num4 != num2)
							{
								return true;
							}
						}
					}
				}
				return false;
			}
			if (plyEtParam == 37)
			{
				for (int i = 13; i <= 19; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				for (int i = 20; i <= 25; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				for (int i = 1; i <= 12; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				return this.IsStatusAbnormal(id, 43) || this.IsStatusAbnormal(id, 45);
			}
			if (plyEtParam == 40)
			{
				if (this.GetStatus(id, 17) >= 3)
				{
					return false;
				}
			}
			else if (plyEtParam == 43 && this.IsStatusAbnormal(id, 43))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000C32 RID: 3122 RVA: 0x000F8FCC File Offset: 0x000F71CC
	public virtual bool IsItemOk(int id, int no)
	{
		if (id >= 4)
		{
			return true;
		}
		if (no <= 3)
		{
			int num = this.GetStatus(id, 2);
			int num2 = this.GetStatus(id, 3);
			if (num == num2)
			{
				return false;
			}
		}
		else if (no <= 7)
		{
			int num3 = this.GetStatus(id, 4);
			int num2 = this.GetStatus(id, 5);
			if (num3 == num2)
			{
				return false;
			}
		}
		else if (no == 8)
		{
			int num4 = this.GetStatus(id, 2);
			int num2 = this.GetStatus(id, 3);
			if (num4 != num2)
			{
				return true;
			}
			int num5 = this.GetStatus(id, 4);
			num2 = this.GetStatus(id, 5);
			return num5 != num2;
		}
		else
		{
			if (no == 11)
			{
				for (int i = 13; i <= 19; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				for (int i = 20; i <= 25; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				return false;
			}
			if (no == 12)
			{
				for (int i = 13; i <= 19; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				return false;
			}
			if (no == 13)
			{
				for (int i = 20; i <= 25; i++)
				{
					if (this.IsStatusAbnormal(id, i))
					{
						return true;
					}
				}
				return false;
			}
			if (no == 14)
			{
				if (this.GetStatus(id, 17) >= 3)
				{
					return false;
				}
			}
			else if (no == 16)
			{
				for (int i = 0; i < 4; i++)
				{
					int num6 = this.GetRanks(i);
					if (num6 != 255)
					{
						int num7 = this.GetStatus(num6, 2);
						int num2 = this.GetStatus(num6, 3);
						if (num7 != num2)
						{
							return true;
						}
						int num8 = this.GetStatus(num6, 4);
						num2 = this.GetStatus(num6, 5);
						if (num8 != num2)
						{
							return true;
						}
					}
				}
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x000F912C File Offset: 0x000F732C
	public virtual void SetEneSpData()
	{
		int num = this.eneatk - 48;
		this.work[2] = this.GetEneSAtkParam(num, 3);
		this.work[3] = this.GetEneSAtkParam(num, 6);
		this.work[4] = 0;
		this.work[8] = 0;
		this.work[5] = 0;
		this.work[6] = 0;
		if (this.work[2] == 4)
		{
			this.work[4] = this.GetGtw(0);
			if (this.work[3] <= 25)
			{
				this.work[8] = this.StIcon[this.work[3]];
				this.work[5] = 0;
				return;
			}
			this.work[5] = 1;
			this.work[6] = this.EnemyHpRecover(this.GetGtw(0), num, this.GetGtw(0));
			return;
		}
		else
		{
			if (this.work[2] == 0)
			{
				this.work[4] = this.cur[1];
				this.work[8] = this.StIcon[this.work[3]];
				this.work[5] = 0;
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0)
				{
					this.work[4] = 255;
					this.work[8] = this.StIcon[this.work[3]];
					this.work[5] = 0;
				}
			}
			return;
		}
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x000F9290 File Offset: 0x000F7490
	public virtual void SetEneSpDataExec()
	{
		int num = 5;
		switch (this.work[3])
		{
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 20:
		case 21:
		case 23:
		case 24:
		case 25:
			num = 255;
			break;
		}
		if (this.work[2] == 4)
		{
			if (this.work[3] <= 25)
			{
				this.SetStatusAbnormal(this.work[4], this.work[3], num);
				return;
			}
		}
		else
		{
			if (this.work[2] == 0)
			{
				this.SetStatusAbnormal(this.cur[1], this.work[3], num);
				this.SetStatus(this.cur[1], 25, this.work[3]);
				return;
			}
			if (this.work[2] == 1)
			{
				for (int i = 0; i < 4; i++)
				{
					int num2 = this.GetRanks(i);
					if (num2 != 255 && this.GetStatus(num2, 19) == 0 && this.GetStatus(num2, 20) == 0)
					{
						this.SetStatusAbnormal(num2, this.work[3], num);
						this.SetStatus(num2, 25, this.work[3]);
					}
				}
			}
		}
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x000F93B8 File Offset: 0x000F75B8
	public virtual void PlayNAtkSe()
	{
		int num = this.GetGtw(0);
		int num2 = this.nowmenu;
		if (num == 0)
		{
			if (num2 == 3)
			{
				this.PlaySe(17);
				return;
			}
			if (num2 == 0 || num2 == 1 || num2 == 5)
			{
				this.PlaySe(8);
				return;
			}
			this.PlaySe(9);
			return;
		}
		else
		{
			if (num == 1)
			{
				this.PlaySe(18);
				return;
			}
			if (num == 2)
			{
				if (num2 == 0)
				{
					this.PlaySe(8);
					return;
				}
				if (num2 == 1 || num2 == 5)
				{
					this.PlaySe(10);
					return;
				}
				if (num2 == 2)
				{
					this.PlaySe(16);
					return;
				}
				if (num2 == 3)
				{
					this.PlaySe(15);
					return;
				}
				if (num2 == 4)
				{
					this.PlaySe(9);
					return;
				}
			}
			else if (num == 3)
			{
				if (num2 == 0)
				{
					this.PlaySe(8);
					return;
				}
				if (num2 == 1)
				{
					this.PlaySe(10);
					return;
				}
				if (num2 == 2 || num2 == 3)
				{
					this.PlaySe(18);
					return;
				}
				if (num2 == 4)
				{
					this.PlaySe(15);
					return;
				}
				if (num2 == 5)
				{
					this.PlaySe(17);
				}
			}
			return;
		}
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x000F949C File Offset: 0x000F769C
	public virtual void EtherEffectInit(int eff)
	{
		this.StarWorkInit();
		if (eff == 0)
		{
			for (int i = 0; i < 6; i++)
			{
				this.starxy[i][0] = 0;
				this.starxy[i][1] = 0;
				this.starxy[i][2] = i * 60;
				this.starxy[i][3] = 24;
			}
		}
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x000F94F0 File Offset: 0x000F76F0
	public virtual void RecoverEffectRoutine()
	{
		bool flag = false;
		for (int i = 0; i < 16; i++)
		{
			if (this.starxy[i][0] == 0 && !flag)
			{
				this.starxy[i][0] = 32;
				this.starxy[i][1] = this.GetRand(0, 359);
				this.starxy[i][2] = this.GetRand(4, 8);
				flag = true;
			}
			else if (this.starxy[i][0] != 0)
			{
				this.starxy[i][0] -= 4;
				this.starxy[i][2] -= this.GetRand(0, 1);
				if (this.starxy[i][2] < 2)
				{
					this.starxy[i][2] = 2;
				}
				if (this.starxy[i][0] <= 0)
				{
					this.starxy[i][0] = (this.starxy[i][1] = (this.starxy[i][2] = (this.starxy[i][3] = 0)));
				}
			}
		}
	}

	// Token: 0x06000C38 RID: 3128 RVA: 0x000F95F0 File Offset: 0x000F77F0
	public virtual void SupportEffectRoutine()
	{
		bool flag = false;
		for (int i = 0; i < 16; i++)
		{
			if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0 && !flag)
			{
				this.starxy[i][0] = this.GetRand(-20, 20);
				this.starxy[i][1] = 0;
				this.starxy[i][2] = -10;
				this.starxy[i][3] = 10;
				flag = true;
			}
			else if (this.starxy[i][3] != 0)
			{
				this.starxy[i][1] += 6;
				this.starxy[i][2] += 6;
				this.starxy[i][3]--;
				if (this.starxy[i][3] <= 0)
				{
					this.starxy[i][0] = (this.starxy[i][1] = (this.starxy[i][2] = (this.starxy[i][3] = 0)));
				}
			}
		}
	}

	// Token: 0x06000C39 RID: 3129 RVA: 0x000F96F0 File Offset: 0x000F78F0
	public virtual void AttackEffectRoutine()
	{
		int num = this.work[1];
		for (int i = 0; i < 6; i++)
		{
			if (num <= 8)
			{
				this.starxy[i][2] += 24;
			}
			else if (num <= 16)
			{
				this.starxy[i][2] += 24;
				this.starxy[i][3] -= 3;
			}
			else if (num <= 23)
			{
				this.starxy[i][3] += 5;
			}
		}
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x000F9772 File Offset: 0x000F7972
	public virtual bool IsSpEtherEffectEnd(int no, int sp)
	{
		if (sp == 44)
		{
			if (no >= 14)
			{
				return true;
			}
		}
		else if (sp == 47)
		{
			if (no >= 14)
			{
				return true;
			}
		}
		else if (sp == 48 && no >= 14)
		{
			return true;
		}
		return false;
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x000F9799 File Offset: 0x000F7999
	public virtual bool IsEtherEffectEnd(int no, int eff)
	{
		if (eff == 2)
		{
			if (no >= 16)
			{
				return true;
			}
		}
		else if (eff == 1)
		{
			if (no >= 26)
			{
				return true;
			}
		}
		else if (eff == 0 && no >= 24)
		{
			return true;
		}
		return false;
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x000F97BC File Offset: 0x000F79BC
	public virtual void PlayEtherSe(int seff)
	{
		if (seff <= 11)
		{
			if (seff != 1 && seff - 10 > 1)
			{
				return;
			}
		}
		else if (seff != 13)
		{
			if (seff - 26 > 1)
			{
				switch (seff)
				{
				case 35:
				case 37:
				case 43:
					goto IL_005F;
				case 36:
				case 38:
				case 39:
				case 41:
				case 42:
					break;
				case 40:
				case 44:
				case 45:
				case 46:
					goto IL_0067;
				case 47:
					this.PlaySe(10);
					return;
				case 48:
					this.PlaySe(18);
					break;
				default:
					return;
				}
				return;
			}
			IL_005F:
			this.PlaySe(0);
			return;
		}
		IL_0067:
		this.PlaySe(7);
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x000F984C File Offset: 0x000F7A4C
	public virtual void PlayItemSe(int no)
	{
		switch (no)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 16:
			this.PlaySe(0);
			return;
		case 14:
			this.PlaySe(7);
			return;
		case 15:
			this.PlaySe(4);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x000F98BC File Offset: 0x000F7ABC
	public virtual int GetSpAttackRoutineMax(int id, int menu)
	{
		int plySAtkParam = this.GetPlySAtkParam(id, menu, 11);
		return this.PlySAtkEffMax[plySAtkParam];
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x000F98DC File Offset: 0x000F7ADC
	public virtual void EnemyDeadAfter()
	{
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) == 2)
			{
				this.SetEnemyStatus(i, 34, 1);
				int num;
				if (this.GetNowSlot() == 3)
				{
					num = this.GetEnemyStatus(i, 25) * 150;
					num /= 100;
				}
				else
				{
					num = this.GetEnemyStatus(i, 25);
				}
				this.getexp += num;
				this.BattleGtwRemove(i + 4);
			}
		}
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x000F9951 File Offset: 0x000F7B51
	public virtual int GetNowSlot()
	{
		return this.bslot[this.bslotno];
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x000F9960 File Offset: 0x000F7B60
	public virtual void SetBattleMenuStackDelete()
	{
		this.nextmenup = 0;
		for (int i = 0; i < 4; i++)
		{
			this.nextmenu[i] = -1;
		}
		this.nmwait = -1;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x000F9990 File Offset: 0x000F7B90
	public virtual bool SetBattleMenuStack(int menu, int sc)
	{
		if (menu == -1)
		{
			return false;
		}
		if (this.nextmenup <= 3)
		{
			this.nextmenu[this.nextmenup] = menu;
			this.nextmenup++;
			if (sc != -1)
			{
				this.SetBLast2(sc);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x000F99CC File Offset: 0x000F7BCC
	public virtual int SetBattleMenuStackRelease()
	{
		if (this.nextmenup <= 0)
		{
			return -1;
		}
		int num = this.nextmenu[0];
		this.nextmenup--;
		for (int i = 0; i < this.nextmenup; i++)
		{
			this.nextmenu[i] = this.nextmenu[i + 1];
		}
		return num;
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x000F9A20 File Offset: 0x000F7C20
	public virtual void BattleEnemySelRoutineBef()
	{
		if (this.nmwait > 0)
		{
			this.nmwait--;
			return;
		}
		if (this.nmwait == 0)
		{
			if (this.blast == 6)
			{
				this.bmenup = -1;
				this.nmwait = -1;
				return;
			}
			this.SetBattleMenu(this.GetGtw(0));
			this.nmwait = -1;
		}
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x000F9A7C File Offset: 0x000F7C7C
	public virtual void BattleEnemySelRoutine()
	{
		if (this.bmenup == -1)
		{
			return;
		}
		if (this.nmwait >= 0)
		{
			return;
		}
		if ((this.id_edge & 256) != 0 || (this.id_edge & 512) != 0 || (this.id_edge & 1024) != 0)
		{
			if (this.BattleMenuSC() && this.SetBattleMenuStack(this.GetBMenu(this.cur[0], 0), this.GetBMenu(this.cur[0], 1)))
			{
				this.nmwait = 3;
				this.ApMinus(this.GetGtw(0), 2);
				if (this.bmenup == 0)
				{
					this.BattleRedraw(4);
				}
				else
				{
					this.BattleRedrawN(4);
				}
				if (!this.isboost[0])
				{
					this.SetMenu(0);
				}
				this.bsmenu = 0;
				return;
			}
		}
		else if (this.blast == -1 && (this.id_edge & 4) != 0)
		{
			if (this.bmenup > 0)
			{
				this.EneCursorLeft();
				this.BattleRedraw(4);
				return;
			}
		}
		else if (this.blast == -1 && (this.id_edge & 8) != 0)
		{
			if (this.bmenup > 0)
			{
				this.EneCursorRight();
				this.BattleRedraw(4);
				return;
			}
		}
		else if ((this.id_edge & 1) != 0)
		{
			if (this.bmenup > 0)
			{
				this.MenuCursorUp();
				this.BattleRedraw(4);
				return;
			}
		}
		else if ((this.id_edge & 2) != 0)
		{
			if (this.bmenup > 0)
			{
				this.MenuCursorDown();
				this.BattleRedraw(4);
				return;
			}
		}
		else if ((this.id_edge & 4112) != 0 && this.bmenup > 0)
		{
			if (this.GetBMenu(this.cur[0], 0) == 128)
			{
				if (this.SetBattleMenuStack(128, -1))
				{
					this.bmenup = -1;
					this.BattleRedrawN(4);
					return;
				}
			}
			else if (this.GetBMenu(this.cur[0], 0) == 144)
			{
				if (this.SetBattleMenuStack(144, -1))
				{
					this.bmenup = -1;
					this.BattleRedrawN(4);
					return;
				}
			}
			else if (this.SetBattleMenuStack(this.GetBMenu(this.cur[0], 0), this.GetBMenu(this.cur[0], 1)))
			{
				this.nmwait = 3;
				this.ApMinus(this.GetGtw(0), 2);
				if (this.bmenup == 0)
				{
					this.BattleRedraw(4);
				}
				else
				{
					this.BattleRedrawN(4);
				}
				if (!this.isboost[0])
				{
					this.SetMenu(0);
				}
				this.bsmenu = 0;
				return;
			}
		}
		else
		{
			if (this.ismenu[0] && this.blast == -1)
			{
				this.ismenu[0] = false;
				this.bmenup = -1;
				this.SetBattleMenuStack(144, -1);
				this.BattleRedraw(4);
				return;
			}
			if (this.ismenu[0] && this.blast != -1 && this.bmenup > 0)
			{
				this.ismenu[0] = false;
				this.bmenup = -1;
				this.SetBattleMenuStack(128, -1);
				this.BattleRedraw(4);
			}
		}
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x000F9D54 File Offset: 0x000F7F54
	public virtual void BoostGagePlus(int p)
	{
		int num = p;
		if (this.GetNowSlot() == 2)
		{
			num *= 3;
		}
		int num2 = this.GetStatus(this.GetGtw(0), 16) + num;
		this.SetStatus(this.GetGtw(0), 16, num2);
		if (num2 >= 100)
		{
			int num3 = this.GetStatus(this.GetGtw(0), 17);
			if (num3 < 3)
			{
				this.SetStatus(this.GetGtw(0), 17, num3 + 1);
				num2 %= 100;
				this.SetStatus(this.GetGtw(0), 16, num2);
				return;
			}
			this.SetStatus(this.GetGtw(0), 16, 100);
		}
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x000F9DE4 File Offset: 0x000F7FE4
	public virtual void EneBoostGagePlus(int p)
	{
		int num = p;
		if (this.GetNowSlot() == 2)
		{
			num *= 3;
		}
		int num2 = this.GetGtw(0) - 4;
		int num3 = this.GetEnemyStatus(num2, 35) + num;
		this.SetEnemyStatus(num2, 35, num3);
		if (num3 >= 100)
		{
			int enemyStatus = this.GetEnemyStatus(num2, 36);
			if (enemyStatus < 3)
			{
				this.SetEnemyStatus(num2, 36, enemyStatus + 1);
				num3 %= 100;
				this.SetEnemyStatus(num2, 35, num3);
				return;
			}
			this.SetEnemyStatus(num2, 35, 100);
		}
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x000F9E5C File Offset: 0x000F805C
	public virtual void BattleEnemySelRelease()
	{
		int num = this.SetBattleMenuStackRelease();
		if (num == -1)
		{
			return;
		}
		this.nowmenu = num;
		if (num == 128)
		{
			this.ismenu[0] = false;
			this.AglWaitClear(this.GetGtw(0));
			if (this.GetStatus(this.GetGtw(0), 23) == 2)
			{
				this.AglWait2(this.GetGtw(0), 10);
			}
			if (this.EnemyDead())
			{
				this.SetSeqStep(10);
			}
			else if (this.IsStatusAbnormal(this.GetGtw(0), 17))
			{
				this.work[0] = this.GetStatus(this.GetGtw(0), 3) / 5;
				this.work[1] = 0;
				this.cur[1] = this.GetGtw(0);
				this.SetSeqStep(30);
			}
			else
			{
				this.StatusAbRoutine(this.GetGtw(0));
				this.SetSeqStep(11);
			}
			this.SetBattleMenuStackDelete();
			return;
		}
		if (num == 144)
		{
			this.cur[0] = 0;
			this.ismenu[0] = false;
			if (!this.isboost[0])
			{
				this.SetMenu(1);
			}
			this.bsmenu = 1;
			this.SetSubMenu();
			this.SetSeqStep(13);
			this.SetBattleMenuStackDelete();
			return;
		}
		this.SetSeqStep(5);
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x000F9F88 File Offset: 0x000F8188
	public virtual void StatusAbRoutine(int id)
	{
		int num = 255;
		for (int i = 0; i < 49; i++)
		{
			if (id >= 4)
			{
				if (this.est_ab[id - 4][i] != 0 && this.est_ab[id - 4][i] != 255)
				{
					this.est_ab[id - 4][i]--;
					if (this.est_ab[id - 4][i] <= 0)
					{
						this.est_ab[id - 4][i] = 0;
					}
				}
			}
			else if (this.st_ab[id][i] != 0)
			{
				if (this.st_ab[id][i] == 255)
				{
					if (num > i)
					{
						num = i;
					}
				}
				else
				{
					this.st_ab[id][i]--;
					if (this.st_ab[id][i] <= 0)
					{
						this.st_ab[id][i] = 0;
						if (this.GetStatus(id, 25) == i)
						{
							this.SetStatus(id, 25, 255);
						}
					}
				}
			}
		}
		if (id < 4 && this.GetStatus(id, 25) == 255 && num != 255)
		{
			this.SetStatus(id, 25, num);
		}
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x000FA09C File Offset: 0x000F829C
	public virtual void AglWait(int id, int no, int f)
	{
		int num;
		if (f == 0)
		{
			num = this.GetPlySAtkParam(id, no, 7);
		}
		else
		{
			num = this.GetPlyEtParam(id, no, 5);
		}
		int num2 = this.GetStatus(id, 24);
		num2 += num;
		this.SetStatus(id, 24, num2);
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x000FA0DC File Offset: 0x000F82DC
	public virtual void AglWait2(int id, int num)
	{
		int num2 = this.GetStatus(id, 24);
		num2 += num;
		this.SetStatus(id, 24, num2);
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x000FA101 File Offset: 0x000F8301
	public virtual void AglWaitClear(int id)
	{
		this.SetStatus(id, 24, 0);
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x000FA110 File Offset: 0x000F8310
	public virtual void BubbleRoutine(int rt)
	{
		bool flag = false;
		for (int i = 0; i < 20; i++)
		{
			if (rt == 0)
			{
				if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0 && !flag)
				{
					this.starxy[i][0] = this.GetRand(-20, 20);
					this.starxy[i][1] = 0;
					this.starxy[i][2] = this.GetRand(8, 16);
					this.starxy[i][3] = this.GetRand(3, 6);
					flag = true;
				}
				else if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
				{
					this.starxy[i][1] -= this.starxy[i][3];
					this.starxy[i][2]--;
					if (this.starxy[i][2] <= 0)
					{
						this.starxy[i][2] = (this.starxy[i][3] = 0);
					}
				}
			}
			else if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0 && !flag)
			{
				this.starxy[i][0] = this.GetRand(0, 239);
				this.starxy[i][1] = 180;
				this.starxy[i][2] = this.GetRand(8, 16);
				this.starxy[i][3] = this.GetRand(3, 6);
				flag = true;
			}
			else if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
			{
				this.starxy[i][1] -= this.starxy[i][3];
				this.starxy[i][2]++;
				if (this.starxy[i][1] <= 95)
				{
					this.starxy[i][2] = (this.starxy[i][3] = 0);
				}
			}
		}
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x000FA2EC File Offset: 0x000F84EC
	public virtual void EtherMenuCursorChange()
	{
		bool flag = true;
		if (this.cur[1] == 0)
		{
			this.cur[0] = 4;
			this.cur[1] = 1;
			do
			{
				if (this.GetEnemyStatus(this.cur[0] - 4, 34) == 0)
				{
					flag = false;
				}
				else
				{
					this.cur[0]++;
					if (this.cur[0] == this.ep + 4)
					{
						this.cur[0] = 4;
						flag = false;
					}
				}
			}
			while (flag);
			return;
		}
		this.cur[0] = 0;
		this.cur[1] = 0;
		do
		{
			int num = this.GetRanks(this.cur[0]);
			if (num != 255)
			{
				if (this.GetStatus(num, 19) == 0 && this.GetStatus(num, 20) == 0)
				{
					flag = false;
				}
				else
				{
					this.cur[0]++;
					if (this.cur[0] == 4)
					{
						this.cur[0] = 0;
						flag = false;
					}
				}
			}
			else
			{
				this.cur[0]++;
				if (this.cur[0] == 4)
				{
					this.cur[0] = 0;
					flag = false;
				}
			}
		}
		while (flag);
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x000FA3FC File Offset: 0x000F85FC
	public virtual void EtherMenuCursorLeft(int rt)
	{
		int num = this.cur[0];
		int num2 = this.cur[1];
		int num3 = this.work[2];
		int num4 = this.work[3];
		int num5;
		if (rt == 0)
		{
			num5 = this.GetPlyEtParam(num3, num4, 1);
		}
		else
		{
			num5 = this.GetItemData(num4, 1);
		}
		bool flag = true;
		do
		{
			if (this.cur[1] == 0)
			{
				if (this.cur[0] == 0)
				{
					bool flag2 = false;
					if (num5 == 6)
					{
						flag2 = true;
					}
					if (flag2)
					{
						this.cur[0] = this.ep - 1 + 4;
						this.cur[1] = 1;
					}
					else
					{
						this.cur[0] = 3;
					}
				}
				else
				{
					this.cur[0]--;
				}
			}
			else if (this.cur[0] == 4)
			{
				bool flag2 = false;
				if (num5 == 6)
				{
					flag2 = true;
				}
				if (flag2)
				{
					this.cur[0] = 3;
					this.cur[1] = 0;
				}
				else
				{
					this.cur[0] = this.ep - 1 + 4;
				}
			}
			else
			{
				this.cur[0]--;
			}
			if (this.cur[1] == 0)
			{
				if (num5 == 7)
				{
					int num6 = this.GetRanks(this.cur[0]);
					if (num6 != 255 && this.GetStatus(num6, 19) == 1 && this.GetStatus(num6, 20) == 0)
					{
						flag = false;
					}
				}
				else
				{
					int num6 = this.GetRanks(this.cur[0]);
					if (num6 != 255 && this.GetStatus(num6, 19) == 0 && this.GetStatus(num6, 20) == 0)
					{
						flag = false;
					}
				}
			}
			else if (this.cur[1] == 1 && this.cur[0] >= 4 && this.GetEnemyStatus(this.cur[0] - 4, 34) == 0)
			{
				flag = false;
			}
			if (num == this.cur[0] && num2 == this.cur[1])
			{
				flag = false;
			}
		}
		while (flag);
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x000FA5C8 File Offset: 0x000F87C8
	public virtual void EtherMenuCursorRight(int rt)
	{
		int num = this.cur[0];
		int num2 = this.cur[1];
		int num3 = this.work[2];
		int num4 = this.work[3];
		int num5;
		if (rt == 0)
		{
			num5 = this.GetPlyEtParam(num3, num4, 1);
		}
		else
		{
			num5 = this.GetItemData(num4, 1);
		}
		bool flag = true;
		do
		{
			if (this.cur[1] == 0)
			{
				if (this.cur[0] == 3)
				{
					bool flag2 = false;
					if (num5 == 6)
					{
						flag2 = true;
					}
					if (flag2)
					{
						this.cur[0] = 4;
						this.cur[1] = 1;
					}
					else
					{
						this.cur[0] = 0;
					}
				}
				else
				{
					this.cur[0]++;
				}
			}
			else if (this.cur[1] == 1)
			{
				if (this.cur[0] == this.ep - 1 + 4)
				{
					bool flag2 = false;
					if (num5 == 6)
					{
						flag2 = true;
					}
					if (flag2)
					{
						this.cur[0] = 0;
						this.cur[1] = 0;
					}
					else
					{
						this.cur[0] = 4;
					}
				}
				else
				{
					this.cur[0]++;
				}
			}
			if (this.cur[1] == 0)
			{
				if (num5 == 7)
				{
					int num6 = this.GetRanks(this.cur[0]);
					if (num6 != 255 && this.GetStatus(num6, 19) == 1 && this.GetStatus(num6, 20) == 0)
					{
						flag = false;
					}
				}
				else
				{
					int num6 = this.GetRanks(this.cur[0]);
					if (num6 != 255 && this.GetStatus(num6, 19) == 0 && this.GetStatus(num6, 20) == 0)
					{
						flag = false;
					}
				}
			}
			else if (this.cur[1] == 1 && this.cur[0] >= 4 && this.GetEnemyStatus(this.cur[0] - 4, 34) == 0)
			{
				flag = false;
			}
			if (num == this.cur[0] && num2 == this.cur[1])
			{
				flag = false;
			}
		}
		while (flag);
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x000FA798 File Offset: 0x000F8998
	public virtual void ResultRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
		{
			this.StatusAbnormalInit();
			this.MenuFlagClear();
			this.StopVib();
			this.isupdate = true;
			this.SetMenu(4);
			if (this.battleno == 11)
			{
				this.SetSeqStep(8);
				return;
			}
			this.StartFade(0, 32);
			this.SetSeqStep(1);
			this.WorkClear();
			this.work[0] = this.getexp;
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 19) == 0)
				{
					num++;
				}
			}
			this.work[0] /= num;
			for (int i = 0; i < 4; i++)
			{
				this.work[2 + i] = -1;
				this.work[6 + i] = -1;
				this.work[10 + i] = -1;
				this.work[14 + i] = -1;
			}
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255)
				{
					this.work[2 + num2] = -1;
					this.work[6 + num2] = -1;
					this.work[10 + num2] = this.GetStatus(num2, 3);
					this.work[14 + num2] = this.GetStatus(num2, 5);
					if (this.GetStatus(num2, 20) == 1 && this.GetStatus(num2, 0) + 1 < 60)
					{
						num = this.work[0] * 75 / 100;
						int num3 = this.GetStatus(num2, 14) + num;
						this.SetStatus(num2, 14, num3);
						num3 = this.GetStatus(num2, 15) - num;
						this.SetStatus(num2, 15, num3);
						do
						{
							if (this.GetStatus(num2, 15) <= 0 && this.GetStatus(num2, 0) + 1 < 60)
							{
								this.work[19 + num2]++;
								num = this.GetStatus(num2, 15) * -1;
								this.SetLevelStatus(num2, this.GetStatus(num2, 0) + 1);
								if (this.GetStatus(num2, 0) + 1 < 60)
								{
									num3 = this.GetStatus(num2, 15) - num;
									this.SetStatus(num2, 15, num3);
								}
							}
						}
						while (this.GetStatus(num2, 15) <= 0);
					}
				}
			}
			this.work[18] = this.work[0];
			this.DropItemCalc();
			return;
		}
		case 1:
			this.red = true;
			if (this.IsFade() == 0)
			{
				this.StopAllSound();
				this.PlaySe(13);
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			this.work[1]++;
			if (this.work[1] >= 8)
			{
				this.work[1] = 0;
				this.SetSeqStep(3);
				return;
			}
			break;
		case 3:
		{
			this.red = true;
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255 && this.GetStatus(num2, 20) == 0 && this.GetStatus(num2, 19) == 0)
				{
					if (this.work[0] > 0 && this.GetStatus(num2, 0) + 1 < 60)
					{
						int num3 = this.GetStatus(num2, 14) + 1;
						this.SetStatus(num2, 14, num3);
						num3 = this.GetStatus(num2, 15) - 1;
						this.SetStatus(num2, 15, num3);
					}
					if (this.GetStatus(num2, 15) <= 0 && this.GetStatus(num2, 0) + 1 < 60)
					{
						this.work[19 + num2]++;
						this.SetLevelStatus(num2, this.GetStatus(num2, 0) + 1);
						this.work[2 + num2] = this.GetStatus(num2, 3) - this.work[10 + num2];
						this.work[6 + num2] = this.GetStatus(num2, 5) - this.work[14 + num2];
					}
				}
			}
			if (this.work[0] > 0)
			{
				this.work[0]--;
			}
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.GetRanks(i);
				if (num2 != 255)
				{
					if (this.work[2 + num2] > 0)
					{
						this.work[2 + num2]--;
						this.work[10 + num2]++;
					}
					if (this.work[6 + num2] > 0)
					{
						this.work[6 + num2]--;
						this.work[14 + num2]++;
					}
				}
			}
			int num = 0;
			if (this.work[0] <= 0)
			{
				num++;
			}
			for (int i = 0; i < 4; i++)
			{
				if (this.work[2 + i] <= 0)
				{
					num++;
				}
				if (this.work[6 + i] <= 0)
				{
					num++;
				}
			}
			if ((this.id_edge & 4112) != 0)
			{
				while (this.work[0] > 0)
				{
					for (int i = 0; i < 4; i++)
					{
						int num2 = this.GetRanks(i);
						if (num2 != 255 && this.GetStatus(num2, 20) == 0 && this.GetStatus(num2, 19) == 0)
						{
							if (this.GetStatus(num2, 0) + 1 < 60)
							{
								int num3 = this.GetStatus(num2, 14) + 1;
								this.SetStatus(num2, 14, num3);
								num3 = this.GetStatus(num2, 15) - 1;
								this.SetStatus(num2, 15, num3);
							}
							if (this.GetStatus(num2, 15) <= 0 && this.GetStatus(num2, 0) + 1 < 60)
							{
								this.work[19 + num2]++;
								this.SetLevelStatus(num2, this.GetStatus(num2, 0) + 1);
								this.work[2 + num2] = this.GetStatus(num2, 3) - this.work[10 + num2];
								this.work[6 + num2] = this.GetStatus(num2, 5) - this.work[14 + num2];
							}
						}
					}
					this.work[0]--;
				}
				this.SetSeqStep(4);
			}
			if (num == 9)
			{
				this.SetSeqStep(4);
				return;
			}
			break;
		}
		case 4:
			if ((this.id_edge & 4112) != 0)
			{
				this.StartFade(1, 32);
				this.SetSeqStep(5);
				return;
			}
			break;
		case 5:
			if (this.IsFade() == 3)
			{
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					if (this.work[19 + i] != 0)
					{
						num++;
					}
				}
				if (num == 0)
				{
					this.StartFade(0, 32);
					this.SetSeqStep(6);
					return;
				}
				this.work[23] = 0;
				do
				{
					num = 0;
					if (this.work[19 + this.work[23]] == 0)
					{
						this.work[23]++;
						if (this.work[23] >= 4)
						{
							num = 1;
						}
					}
					else
					{
						num = 1;
					}
				}
				while (num == 0);
				if (this.work[23] >= 4)
				{
					for (int i = 0; i < 4; i++)
					{
						this.work[19 + i] = 0;
					}
					return;
				}
				if (this.SetLearningSkill(this.work[23]))
				{
					this.StartFade(0, 32);
					this.SetSeqStep(9);
					return;
				}
				this.work[19 + this.work[23]] = 0;
				return;
			}
			break;
		case 6:
			this.red = true;
			if (this.IsFade() == 0)
			{
				this.WorkClear();
				this.SetSeqStep(7);
				return;
			}
			break;
		case 7:
			if ((this.id_edge & 4112) != 0)
			{
				this.StartFade(1, 32);
				this.SetSeqStep(8);
				return;
			}
			break;
		case 8:
			if (this.IsFade() == 3)
			{
				this.DeadPlayerRevive();
				this.WorkClear();
				this.eneimg = null;
				this.bbgimg = null;
				this.SetSeqNo(6);
				return;
			}
			break;
		case 9:
			this.red = true;
			if (this.IsFade() == 0)
			{
				this.SetSeqStep(10);
				return;
			}
			break;
		case 10:
			if ((this.id_edge & 4112) != 0)
			{
				this.StartFade(1, 32);
				this.SetSeqStep(11);
				return;
			}
			break;
		case 11:
			this.red = true;
			if (this.IsFade() == 3)
			{
				this.work[19 + this.work[23]] = 0;
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					if (this.work[19 + i] != 0)
					{
						num++;
					}
				}
				if (num == 0)
				{
					this.StartFade(0, 32);
					this.SetSeqStep(6);
					return;
				}
				this.work[23] = 0;
				do
				{
					num = 0;
					if (this.work[19 + this.work[23]] == 0)
					{
						this.work[23]++;
						if (this.work[23] >= 4)
						{
							num = 1;
						}
					}
					else
					{
						num = 1;
					}
				}
				while (num == 0);
				if (this.work[23] >= 4)
				{
					for (int i = 0; i < 4; i++)
					{
						this.work[19 + i] = 0;
					}
					return;
				}
				if (this.SetLearningSkill(this.work[23]))
				{
					this.StartFade(0, 32);
					this.SetSeqStep(9);
					return;
				}
				this.work[19 + this.work[23]] = 0;
				this.work[23] = 0;
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x000FB040 File Offset: 0x000F9240
	public virtual bool SetLearningSkill(int id)
	{
		int num = 255;
		for (int i = 0; i < 6; i++)
		{
			if (this.GetPlySAtkParam(id, i, 8) == this.GetStatus(id, 0) + 1)
			{
				num = i;
				break;
			}
		}
		int num2 = 255;
		int num3 = this.PlyEtPiece[id];
		for (int i = 0; i < num3; i++)
		{
			if (this.GetPlyEtParam(id, i, 6) == this.GetStatus(id, 0) + 1)
			{
				num2 = i;
				break;
			}
		}
		int num4 = (num << 8) | num2;
		if (num4 == 65535)
		{
			return false;
		}
		this.work[19 + id] = num4;
		return true;
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x000FB0CC File Offset: 0x000F92CC
	public virtual void DeadPlayerRevive()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.GetStatus(i, 19) != 0)
			{
				this.SetStatus(i, 19, 0);
				this.SetStatus(i, 2, 1);
			}
		}
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x000FB104 File Offset: 0x000F9304
	public virtual void DropItemCalc()
	{
		this.dropitemp = 0;
		for (int i = 0; i < 8; i++)
		{
			this.dropitem[i][0] = 255;
			this.dropitem[i][1] = 0;
		}
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) != 0)
			{
				for (int j = 0; j < 2; j++)
				{
					int num;
					int num2;
					int num3;
					if (j == 0)
					{
						num = this.GetEnemyStatus(i, 28);
						num2 = this.GetEnemyStatus(i, 27);
						num3 = this.GetEnemyStatus(i, 26);
					}
					else
					{
						num = this.GetEnemyStatus(i, 31);
						num2 = this.GetEnemyStatus(i, 30);
						num3 = this.GetEnemyStatus(i, 29);
					}
					if (num2 != -1)
					{
						int k = this.GetRand(0, 99);
						int num4 = 0;
						if (num3 != -1)
						{
							if (num3 == 0)
							{
								num4 = 10;
							}
							else if (num3 == 1)
							{
								num4 = 20;
							}
							else if (num3 == 2)
							{
								num4 = 100;
							}
						}
						if (k < num4)
						{
							num4 = this.dropitemp;
							for (k = 0; k < this.dropitemp; k++)
							{
								if (this.dropitem[k][0] == num)
								{
									num4 = k;
									break;
								}
							}
							if (num2 == 1)
							{
								k = 1;
							}
							else
							{
								k = this.GetRand(1, num2);
							}
							this.dropitem[num4][1] += k;
							if (num4 == this.dropitemp)
							{
								this.dropitem[num4][0] = num;
								this.dropitemp++;
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < this.dropitemp; i++)
		{
			int num = this.dropitem[i][0];
			int num2 = this.dropitem[i][1];
			this.SetBMStr(i, this.GetItemName(num, 0));
			int num5 = num2 / 10;
			int num6 = num2 % 10;
			this.mmstr[i] = "x" + num5.ToString() + num6.ToString();
			this.AddItem(num, num2);
		}
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x000FB2D8 File Offset: 0x000F94D8
	public virtual void GameOverRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.isupdate = true;
			this.StartFade(0);
			this.SetSeqStep(1);
			this.SetMenu(4);
			this.work[0] = (this.work[1] = 0);
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.PlaySe(14);
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			this.work[1]++;
			if (this.work[1] >= 16)
			{
				this.work[1] = 0;
				this.StartFade(1);
				this.SetSeqStep(3);
				return;
			}
			break;
		case 3:
			if (this.IsFade() == 3)
			{
				this.SetSeqNo(14);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x000FB398 File Offset: 0x000F9598
	public virtual void SetMapMenu(int kind, int id)
	{
		int[] array = new int[] { 1, 2, 4, 8 };
		for (int i = 0; i < 66; i++)
		{
			this.mmstr[i] = string.Empty;
			this.mmenu[i] = 255;
		}
		this.mmenup = 0;
		if (kind <= 3)
		{
			for (int i = 0; i < 66; i++)
			{
				if (kind == this.GetItemData(i, 0) && this.itempc[i][0] >= 1)
				{
					bool flag = false;
					if (kind == 0)
					{
						flag = true;
					}
					else if ((this.GetItemData(i, 1) & array[id]) != 0)
					{
						int num = 0;
						for (int j = 0; j < 4; j++)
						{
							if ((this.itempc[i][1] & array[j]) != 0 && j != id)
							{
								num++;
							}
						}
						if (num < this.itempc[i][0])
						{
							flag = true;
						}
					}
					if (flag)
					{
						this.mmstr[this.mmenup] = this.GetItemName(i, 0);
						this.mmenu[this.mmenup] = i;
						this.mmenup++;
					}
				}
			}
			return;
		}
		if (kind == 4)
		{
			for (int i = 0; i < this.PlyEtPiece[id]; i++)
			{
				if (this.GetPlyEtParam(id, i, 6) <= this.GetStatus(id, 0) + 1)
				{
					this.mmstr[this.mmenup] = this.GetPlyEtName(id, i);
					this.mmenu[this.mmenup] = i;
					this.mmenup++;
				}
			}
			return;
		}
		if (kind == 5)
		{
			for (int i = 0; i < 6; i++)
			{
				if (this.GetPlySAtkParam(id, i, 8) <= this.GetStatus(id, 0) + 1 && this.GetStatus(id, 0) + 1 < this.GetPlySAtkParam(id, i, 9))
				{
					this.mmstr[i] = this.GetPlySAtkName(id, i);
					this.mmenu[i] = i;
				}
				else
				{
					this.mmstr[i] = string.Empty;
					this.mmenu[i] = 255;
				}
				this.mmenup++;
			}
		}
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x000FB580 File Offset: 0x000F9780
	public virtual void MMenuCursorUp(int line, int max)
	{
		if (max == 0)
		{
			this.cur[0] = 0;
			return;
		}
		this.PlaySe(2);
		if (this.cur[0] == 0)
		{
			this.cur[0] = max - 1;
		}
		else
		{
			this.cur[0]--;
		}
		if (this.cur[1] > this.cur[0] || this.cur[0] > this.cur[1] + (line - 1))
		{
			if (this.cur[0] == max - 1)
			{
				this.cur[1] = this.cur[0] - (line - 1);
				return;
			}
			this.cur[1] = this.cur[0];
		}
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x000FB624 File Offset: 0x000F9824
	public virtual void MMenuCursorDown(int line, int max)
	{
		if (max == 0)
		{
			this.cur[0] = 0;
			return;
		}
		this.PlaySe(2);
		if (this.cur[0] == max - 1)
		{
			this.cur[0] = 0;
		}
		else
		{
			this.cur[0]++;
		}
		if (this.cur[1] > this.cur[0] || this.cur[0] > this.cur[1] + (line - 1))
		{
			if (this.cur[0] == 0)
			{
				this.cur[1] = 0;
				return;
			}
			this.cur[1] = this.cur[0] - (line - 1);
		}
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x000FB6C0 File Offset: 0x000F98C0
	public virtual void SetEquip(int id, int st, int no)
	{
		int num = this.GetStatus(id, st);
		int[] array = new int[] { 1, 2, 4, 8 };
		if (num != 255)
		{
			this.itempc[num][1] &= ~array[id];
		}
		if (no == 128)
		{
			this.SetStatus(id, st, 255);
			return;
		}
		this.SetStatus(id, st, no);
		this.itempc[no][1] |= array[id];
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x000FB73C File Offset: 0x000F993C
	public virtual void ItemExecNumCalc(int no, int id)
	{
		if (id == 255)
		{
			return;
		}
		switch (no)
		{
		case 0:
			this.work[7] = 50;
			return;
		case 1:
			this.work[7] = 250;
			return;
		case 2:
			this.work[7] = 500;
			return;
		case 3:
			if (this.work[4] < 4)
			{
				this.work[7] = this.GetStatus(id, 3);
				return;
			}
			this.work[7] = this.GetEnemyStatus(id - 4, 38);
			return;
		case 4:
			this.work[7] = 10;
			return;
		case 5:
			this.work[7] = 20;
			return;
		case 6:
			this.work[7] = 30;
			return;
		case 7:
			this.work[7] = this.GetStatus(id, 5);
			return;
		case 8:
			this.work[7] = this.GetStatus(id, 3);
			return;
		case 9:
			this.work[7] = 100;
			return;
		case 10:
			this.work[7] = this.GetStatus(id, 3);
			return;
		case 11:
			this.work[7] = 65535;
			return;
		case 12:
			this.work[7] = 65535;
			return;
		case 13:
			this.work[7] = 65535;
			return;
		case 14:
			this.work[7] = 1;
			return;
		case 15:
			this.work[7] = 65535;
			return;
		case 16:
		{
			this.work[7] = 65535;
			for (int i = 0; i < 4; i++)
			{
				this.work[9 + i] = this.GetStatus(i, 3);
			}
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x000FB8C4 File Offset: 0x000F9AC4
	public virtual void ItemExec(int no, int id)
	{
		if (id == 255)
		{
			return;
		}
		switch (no)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			this.HpRecover(id, this.work[7]);
			return;
		case 4:
		case 5:
		case 6:
		case 7:
		{
			int num = this.GetStatus(id, 4) + this.work[7];
			this.SetStatus(id, 4, num);
			if (this.GetStatus(id, 4) > this.GetStatus(id, 5))
			{
				this.SetStatus(id, 4, this.GetStatus(id, 5));
				return;
			}
			break;
		}
		case 8:
			this.HpRecover(id, this.work[7]);
			this.SetStatus(id, 4, this.GetStatus(id, 5));
			return;
		case 9:
		case 10:
			this.SetStatus(id, 19, 0);
			this.HpRecover(id, this.work[7]);
			return;
		case 11:
		{
			for (int i = 13; i <= 19; i++)
			{
				this.CancelStatusAbnormal(id, i);
			}
			for (int i = 20; i <= 25; i++)
			{
				this.CancelStatusAbnormal(id, i);
			}
			this.SetAbIcon(id);
			return;
		}
		case 12:
		{
			for (int i = 13; i <= 19; i++)
			{
				this.CancelStatusAbnormal(id, i);
			}
			this.SetAbIcon(id);
			return;
		}
		case 13:
		{
			for (int i = 20; i <= 25; i++)
			{
				this.CancelStatusAbnormal(id, i);
			}
			this.SetAbIcon(id);
			return;
		}
		case 14:
		{
			int num = this.GetStatus(id, 17) + this.work[7];
			this.SetStatus(id, 17, num);
			if (this.GetStatus(id, 17) > 3)
			{
				this.SetStatus(id, 17, 3);
				return;
			}
			break;
		}
		case 15:
			break;
		case 16:
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.GetStatus(i, 20) != 2)
				{
					this.HpRecover(i, this.GetStatus(i, 3));
					this.SetStatus(i, 4, this.GetStatus(i, 5));
				}
			}
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x000FBA8C File Offset: 0x000F9C8C
	public virtual void EtherExecNumCalc(int id, int no, int id2)
	{
		if (id == 255 || id2 == 255)
		{
			return;
		}
		int plyEtParam = this.GetPlyEtParam(id, no, 3);
		if (plyEtParam <= 11)
		{
			if (plyEtParam != 1 && plyEtParam - 10 > 1)
			{
				goto IL_0286;
			}
		}
		else if (plyEtParam != 13)
		{
			switch (plyEtParam)
			{
			case 26:
			{
				if (this.GetPlyEtParam(id, no, 1) != 3)
				{
					this.work[7] = this.EtherHpRecover(id, no, id2);
					goto IL_0293;
				}
				this.work[7] = 65535;
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					if (this.GetStatus(i, 20) == 0)
					{
						if (this.GetStatus(i, 19) == 0)
						{
							this.work[9 + num] = this.EtherHpRecover(id, no, i);
						}
						else
						{
							this.work[9 + num] = 65535;
						}
						num++;
					}
				}
				goto IL_0293;
			}
			case 27:
			{
				if (this.GetPlyEtParam(id, no, 1) != 3)
				{
					this.work[7] = this.EtherHpRecover(id, no, id2);
					goto IL_0293;
				}
				this.work[7] = 65535;
				for (int i = 0; i < 4; i++)
				{
					int num = this.GetRanks(i);
					if (this.GetSeqNo() == 3)
					{
						if (num != 255 && this.GetStatus(num, 20) == 0)
						{
							if (this.GetStatus(num, 19) == 0)
							{
								this.work[9 + num] = this.EtherHpRecover(id, no, num);
							}
							else
							{
								this.work[9 + num] = 65535;
							}
						}
					}
					else
					{
						this.work[9 + i] = this.EtherHpRecover(id, no, i);
					}
				}
				goto IL_0293;
			}
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 36:
			case 38:
			case 39:
			case 42:
				goto IL_0286;
			case 35:
				this.work[7] = this.EtherHpRecover(id, no, id2);
				goto IL_0293;
			case 37:
			case 41:
			case 43:
			case 44:
			case 45:
			case 46:
				break;
			case 40:
				this.work[7] = 1;
				goto IL_0293;
			case 47:
				this.work[7] = 65535;
				this.work[9] = this.GetEtherDmg(id, id2, this.GetPlyEtParam(id, no, 4));
				goto IL_0293;
			case 48:
			{
				this.work[7] = 65535;
				for (int i = 0; i < this.ep; i++)
				{
					if (this.GetEnemyStatus(i, 34) == 0)
					{
						this.work[9 + i] = this.GetEtherDmg(id, i + 4, this.GetPlyEtParam(id, no, 4));
					}
					else
					{
						this.work[9 + i] = 65535;
					}
				}
				goto IL_0293;
			}
			default:
				goto IL_0286;
			}
		}
		this.work[7] = 65535;
		goto IL_0293;
		IL_0286:
		this.work[7] = 65535;
		IL_0293:
		this.work[8] = 65535;
		if (plyEtParam <= 11)
		{
			if (plyEtParam != 1 && plyEtParam - 10 > 1)
			{
				goto IL_02D1;
			}
		}
		else if (plyEtParam != 13 && plyEtParam != 43 && plyEtParam != 45)
		{
			goto IL_02D1;
		}
		this.work[8] = this.StIcon[plyEtParam];
		IL_02D1:
		if (plyEtParam == 46)
		{
			this.work[9] = this.GetEnemyStatus(id2 - 4, 28);
			this.work[10] = this.GetEnemyStatus(id2 - 4, 27);
			if (this.work[9] != -1)
			{
				this.SetEnemyStatus(id2 - 4, 27, -1);
			}
		}
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x000FBDB0 File Offset: 0x000F9FB0
	public virtual bool EtherExec(int id, int no, int id2)
	{
		bool flag = false;
		if (id == 255 || id2 == 255)
		{
			return flag;
		}
		int plyEtParam = this.GetPlyEtParam(id, no, 3);
		if (plyEtParam <= 11)
		{
			if (plyEtParam == 1 || plyEtParam - 10 <= 1)
			{
				this.SetStatusAbnormal(id2, plyEtParam, 5);
				if (id2 < 4)
				{
					this.SetStatus(id2, 25, plyEtParam);
				}
			}
		}
		else if (plyEtParam != 13)
		{
			switch (plyEtParam)
			{
			case 26:
			case 27:
				if (this.GetPlyEtParam(id, no, 1) != 3)
				{
					this.HpRecover(id2, this.work[7]);
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						int j = this.GetRanks(i);
						if (this.GetSeqNo() == 3)
						{
							if (j != 255 && this.GetStatus(j, 20) == 0 && this.GetStatus(j, 19) == 0 && this.work[9 + j] != 65535)
							{
								this.HpRecover(j, this.work[9 + j]);
							}
						}
						else
						{
							this.HpRecover(i, this.work[9 + i]);
						}
					}
				}
				break;
			case 35:
				this.SetStatus(id2, 19, 0);
				this.HpRecover(id2, this.work[7]);
				break;
			case 37:
			{
				for (int i = 13; i <= 19; i++)
				{
					this.CancelStatusAbnormal(id2, i);
				}
				for (int i = 20; i <= 25; i++)
				{
					this.CancelStatusAbnormal(id2, i);
				}
				for (int i = 1; i <= 12; i++)
				{
					this.CancelStatusAbnormal(id2, i);
				}
				this.CancelStatusAbnormal(id2, 43);
				this.CancelStatusAbnormal(id2, 45);
				this.SetAbIcon(id2);
				break;
			}
			case 40:
			{
				int num = this.GetStatus(id2, 17) + 1;
				this.SetStatus(id2, 17, num);
				if (this.GetStatus(id2, 17) > 3)
				{
					this.SetStatus(id2, 17, 3);
				}
				break;
			}
			case 43:
			case 45:
				this.SetStatusAbnormal(id2, plyEtParam, 255);
				this.SetStatus(id2, 25, plyEtParam);
				break;
			case 44:
				flag = true;
				break;
			case 46:
				flag = true;
				break;
			case 47:
				flag = true;
				break;
			case 48:
			{
				flag = true;
				for (int i = 0; i < this.ep; i++)
				{
					if (this.GetEnemyStatus(i, 34) == 0)
					{
						for (int j = 0; j < 49; j++)
						{
							this.CancelStatusAbnormal(i + 4, j);
						}
					}
				}
				break;
			}
			}
		}
		else
		{
			this.SetStatusAbnormal(id2, plyEtParam, 255);
			if (id2 < 4)
			{
				this.SetStatus(id2, 25, plyEtParam);
			}
		}
		if (plyEtParam == 46 && this.work[9] != -1 && this.work[10] != -1)
		{
			this.AddItem(this.work[9], this.work[10]);
		}
		return flag;
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x000FC080 File Offset: 0x000FA280
	public virtual void SetAbIcon(int id)
	{
		if (id >= 4)
		{
			return;
		}
		int num = 255;
		for (int i = 0; i < 49; i++)
		{
			if (this.st_ab[id][i] != 0)
			{
				if (this.st_ab[id][i] == 255)
				{
					if (num > i)
					{
						num = i;
					}
				}
				else if (this.st_ab[id][i] != 0 && num > i)
				{
					num = i;
				}
			}
		}
		this.SetStatus(id, 25, num);
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x000FC0E8 File Offset: 0x000FA2E8
	public virtual void HpRecover(int id, int num)
	{
		if (id < 4)
		{
			int num2 = this.GetStatus(id, 2) + num;
			this.SetStatus(id, 2, num2);
			if (this.GetStatus(id, 2) > this.GetStatus(id, 3))
			{
				this.SetStatus(id, 2, this.GetStatus(id, 3));
			}
			if (this.GetStatus(id, 2) <= 0)
			{
				this.SetStatus(id, 2, 0);
				return;
			}
		}
		else
		{
			int num2 = this.GetEnemyStatus(id - 4, 3) + num;
			this.SetEnemyStatus(id - 4, 3, num2);
			if (this.GetEnemyStatus(id - 4, 3) > this.GetEnemyStatus(id - 4, 38))
			{
				this.SetEnemyStatus(id - 4, 3, this.GetEnemyStatus(id - 4, 38));
			}
			if (this.GetEnemyStatus(id - 4, 3) <= 0)
			{
				this.SetEnemyStatus(id - 4, 3, 0);
			}
		}
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x000FC1A0 File Offset: 0x000FA3A0
	public virtual void HpDec(int id, int num)
	{
		if (id < 4)
		{
			int num2 = this.GetStatus(id, 2) - num;
			this.SetStatus(id, 2, num2);
			if (this.GetStatus(id, 2) <= 0)
			{
				this.SetStatus(id, 2, 0);
			}
			if (this.GetStatus(id, 2) > this.GetStatus(id, 3))
			{
				this.SetStatus(id, 2, this.GetStatus(id, 3));
				return;
			}
		}
		else
		{
			int num2 = this.GetEnemyStatus(id - 4, 3) - num;
			this.SetEnemyStatus(id - 4, 3, num2);
			if (this.GetEnemyStatus(id - 4, 3) <= 0)
			{
				this.SetEnemyStatus(id - 4, 3, 0);
			}
			if (this.GetEnemyStatus(id - 4, 3) > this.GetEnemyStatus(id - 4, 38))
			{
				this.SetEnemyStatus(id - 4, 3, this.GetEnemyStatus(id - 4, 38));
			}
		}
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x000FC258 File Offset: 0x000FA458
	public virtual int EtherHpRecover(int id, int no, int id2)
	{
		int num = this.GetPlyEtParam(id, no, 4);
		int eatk = this.GetEAtk(id);
		if (this.IsStatusAbnormal(id, 12))
		{
			num *= 2;
		}
		int num2 = num + eatk * 10;
		if (this.IsStatusAbnormal(id2, 10))
		{
			num2 *= 75;
			num2 /= 100;
		}
		if (this.IsStatusAbnormal(id2, 11))
		{
			num2 *= 125;
			num2 /= 100;
		}
		if (this.IsStatusAbnormal(id2, 18))
		{
			num2 /= 2;
		}
		return num2;
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x000FC2C8 File Offset: 0x000FA4C8
	public virtual int EnemyHpRecover(int id, int no, int id2)
	{
		int num = this.GetEneSAtkParam(no, 4);
		int eatk = this.GetEAtk(id);
		if (this.IsStatusAbnormal(id, 12))
		{
			num *= 2;
		}
		int num2 = num + eatk * 10;
		if (this.IsStatusAbnormal(id2, 10))
		{
			num2 *= 75;
			num2 /= 100;
		}
		if (this.IsStatusAbnormal(id2, 11))
		{
			num2 *= 125;
			num2 /= 100;
		}
		if (this.IsStatusAbnormal(id2, 18))
		{
			num2 /= 2;
		}
		return num2;
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x000FC338 File Offset: 0x000FA538
	public virtual int GetEAtk(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 9);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 6);
		}
		if (this.IsStatusAbnormal(id, 8))
		{
			num *= 125;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 9))
		{
			num *= 75;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 20))
		{
			num *= 75;
			num /= 100;
		}
		return num;
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x000FC3A4 File Offset: 0x000FA5A4
	public virtual int GetAgl(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 13);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 10);
		}
		if (this.IsStatusAbnormal(id, 45))
		{
			num *= 125;
			num /= 100;
		}
		return num;
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x000FC3E8 File Offset: 0x000FA5E8
	public virtual int GetStr(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 7);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 4);
		}
		if (this.IsStatusAbnormal(id, 1))
		{
			num *= 120;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 3))
		{
			num *= 125;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 4))
		{
			num *= 75;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 13))
		{
			num *= 75;
			num /= 100;
		}
		return num;
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x000FC464 File Offset: 0x000FA664
	public virtual int GetVit(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 8);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 5);
		}
		if (this.IsStatusAbnormal(id, 2))
		{
			num *= 120;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 3))
		{
			num *= 75;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 4))
		{
			num *= 125;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 14))
		{
			num *= 75;
			num /= 100;
		}
		return num;
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x000FC4E0 File Offset: 0x000FA6E0
	public virtual int GetEDef(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 10);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 7);
		}
		if (this.IsStatusAbnormal(id, 8))
		{
			num *= 75;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 9))
		{
			num *= 125;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 20))
		{
			num *= 75;
			num /= 100;
		}
		return num;
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x000FC54C File Offset: 0x000FA74C
	public virtual int GetDex(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 11);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 8);
		}
		if (this.IsStatusAbnormal(id, 5))
		{
			num *= 125;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 15))
		{
			num /= 2;
		}
		return num;
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x000FC59C File Offset: 0x000FA79C
	public virtual int GetEva(int id)
	{
		int num;
		if (id < 4)
		{
			num = this.GetStatus(id, 12);
		}
		else
		{
			num = this.GetEnemyStatus(id - 4, 9);
		}
		if (this.IsStatusAbnormal(id, 6))
		{
			num *= 125;
			num /= 100;
		}
		if (this.IsStatusAbnormal(id, 16))
		{
			num /= 2;
		}
		return num;
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x000FC5EC File Offset: 0x000FA7EC
	public virtual int GetHitRate(int id, int id2, int hit)
	{
		int dex = this.GetDex(id);
		int num = this.GetRand(-10, 10);
		int eva = this.GetEva(id2);
		return hit + dex + num - eva;
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x000FC61B File Offset: 0x000FA81B
	public virtual void SetStatusAbnormal(int id, int st_ab, int turn)
	{
		if (id < 4)
		{
			this.st_ab[id][st_ab] = turn;
			return;
		}
		this.est_ab[id - 4][st_ab] = turn;
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x000FC63A File Offset: 0x000FA83A
	public virtual void CancelStatusAbnormal(int id, int st_ab)
	{
		if (id < 4)
		{
			this.st_ab[id][st_ab] = 0;
			return;
		}
		this.est_ab[id - 4][st_ab] = 0;
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x000FC659 File Offset: 0x000FA859
	public virtual bool IsStatusAbnormal(int id, int st_ab)
	{
		if (id < 4)
		{
			return this.st_ab[id][st_ab] != 0;
		}
		return this.est_ab[id - 4][st_ab] != 0;
	}

	// Token: 0x06000C6E RID: 3182 RVA: 0x000FC680 File Offset: 0x000FA880
	public virtual int GetWeaponStr(int id, bool ef)
	{
		int num = this.GetStatus(id, 21);
		if (num == 255)
		{
			return 0;
		}
		if (!ef)
		{
			return this.GetItemData(num, 2);
		}
		return this.GetItemData(num, 3);
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x000FC6B8 File Offset: 0x000FA8B8
	public virtual int GetArmorDef(int id, bool ef)
	{
		int num = this.GetStatus(id, 22);
		if (num == 255)
		{
			return 0;
		}
		if (!ef)
		{
			return this.GetItemData(num, 2);
		}
		return this.GetItemData(num, 3);
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x000FC6ED File Offset: 0x000FA8ED
	public virtual int IsGuard(int id)
	{
		if (id < 4)
		{
			return this.GetStatus(id, 18);
		}
		return this.GetEnemyStatus(id - 4, 39);
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x000FC708 File Offset: 0x000FA908
	public virtual void SetGuard(int id, int g)
	{
		if (id < 4)
		{
			this.SetStatus(id, 18, g);
			return;
		}
		this.SetEnemyStatus(id - 4, 39, g);
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x000FC728 File Offset: 0x000FA928
	public virtual void SetMapPlayerChar(int id)
	{
		int num = 1;
		if (id >= 4)
		{
			return;
		}
		if (6 <= this.mapno && this.mapno <= 5)
		{
			num = 0;
		}
		if (id == 0)
		{
			if (num == 0)
			{
				this.chc = 0;
				return;
			}
			this.chc = 7;
			return;
		}
		else if (id == 1)
		{
			if (num == 0)
			{
				this.chc = 14;
				return;
			}
			this.chc = 21;
			return;
		}
		else
		{
			if (id != 2)
			{
				if (id == 3)
				{
					this.chc = 43;
				}
				return;
			}
			if (num == 0)
			{
				this.chc = 28;
				return;
			}
			this.chc = 35;
			return;
		}
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x000FC7A4 File Offset: 0x000FA9A4
	public virtual void MapRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.isupdate = true;
			this.ismenu[0] = (this.ismenu[1] = false);
			this.WorkClear();
			this.xscr.ScriptInit();
			if (this.IsFade() == 3)
			{
				if (this.GetFadeType() == 4)
				{
					this.StartFade(5);
				}
				else if (this.GetFadeType() == 7)
				{
					this.StartFade(9);
				}
				else
				{
					this.StartFade(2);
				}
			}
			else
			{
				this.StartFade(2);
			}
			this.PlayerTouch();
			this.SetMenu(4);
			this.SetSeqStep(1);
			this.red = true;
			return;
		case 1:
			this.xscr.ScriptExec();
			this.NpcCharRoutine();
			this.ScrObjRoutine();
			if (!this.xscr.IsScriptExec())
			{
				this.ismenu[0] = (this.ismenu[1] = false);
				this.PlayerTouch();
				this.SetMenu(5);
				this.SetSeqStep(3);
				return;
			}
			break;
		case 2:
			if (this.IsFade() == 0)
			{
				this.MenuFlagClear();
				this.PlayerTouch();
				this.SetSeqStep(3);
				return;
			}
			break;
		case 3:
			this.PlayerMoveRoutine();
			this.NpcCharRoutine();
			this.ScrObjRoutine();
			if (this.id_edge == 0 && this.ismenu[1] && this.GetRanks(2) != 255)
			{
				int num = this.GetRanks(0);
				if (this.GetRanks(1) != 255)
				{
					this.SetRanks(0, this.GetRanks(1));
				}
				if (this.GetRanks(2) != 255)
				{
					this.SetRanks(1, this.GetRanks(2));
				}
				else
				{
					this.SetRanks(1, num);
				}
				if (this.GetRanks(3) != 255)
				{
					this.SetRanks(2, this.GetRanks(3));
					this.SetRanks(3, num);
				}
				else
				{
					this.SetRanks(2, num);
				}
				for (int i = 0; i < 4; i++)
				{
					this.SetStatus(i, 20, 0);
				}
				if (this.GetRanks(3) != 255)
				{
					this.SetStatus(this.GetRanks(3), 20, 1);
				}
				this.SetMapPlayerChar(this.GetRanks(0));
				this.red = true;
				this.ismenu[1] = false;
			}
			if (this.seq_no_b == this.seq_no && this.seq_step_b == this.seq_step)
			{
				if (this.ismenu[0])
				{
					this.trapdmgwait = 0;
					this.trapdmg = 255;
					this.StopVib();
					this.WorkClear();
					this.ismenu[0] = false;
					this.StartFade(1);
					this.SetSeqStep(6);
					return;
				}
				if (this.encount <= 0)
				{
					this.battleno = 255;
					this.SetEncountNum();
					if (this.eneapr)
					{
						this.trapdmgwait = 0;
						this.trapdmg = 255;
						this.StopVib();
						this.SetMenu(4);
						this.StopAllSound();
						this.PlaySe(3);
						this.BattleFadeInit();
						this.SetSeqStep(4);
						return;
					}
				}
			}
			break;
		case 4:
			this.red = true;
			if (this.battle_fade == 2)
			{
				this.lasw -= 2;
				if (this.lasw < 0)
				{
					this.lasw = 0;
					this.BattleFadeStop();
					this.battle_fade = 0;
					this.xscr.script_nflg = true;
					this.SetSeqStep(1);
					return;
				}
			}
			else
			{
				if (this.battle_fade == 1)
				{
					this.lasw += 2;
				}
				else
				{
					this.lasw += 10;
				}
				if (this.lasw >= 100)
				{
					this.lasw = 100;
					this.StartFade(1, 64);
					this.SetSeqStep(5);
					return;
				}
			}
			break;
		case 5:
			if (this.IsFade() == 3)
			{
				this.BattleFadeStop();
				if (this.battle_fade == 1)
				{
					this.battle_fade = 0;
					this.xscr.script_nflg = true;
					this.SetSeqStep(1);
					return;
				}
				this.SetSeqNo(2);
				return;
			}
			break;
		case 6:
			if (this.IsFade() == 3)
			{
				this.SetMenu(7);
				this.StartFade(6);
				this.WorkClear();
				this.work[0] = 0;
				this.work[1] = 8;
				this.work[2] = 255;
				this.cur[0] = (this.cur[1] = 0);
				this.SetSeqStep(7);
				return;
			}
			break;
		case 7:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				this.work[1] = 0;
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MMenuCursorUp(9, 9);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MMenuCursorDown(9, 9);
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					if (this.cur[0] == 0)
					{
						this.PlaySe(0);
						this.SetMapMenu(0, 0);
						this.SetSeqStep(8);
					}
					else if (this.cur[0] == 1)
					{
						if (!this.etheruse)
						{
							this.PlaySe(5);
							return;
						}
						this.PlaySe(0);
						this.work[4] = 9;
						this.SetSeqStep(14);
					}
					else if (this.cur[0] == 2)
					{
						this.PlaySe(0);
						this.work[4] = 13;
						this.SetSeqStep(14);
					}
					else if (this.cur[0] == 3)
					{
						this.PlaySe(0);
						this.work[4] = 18;
						this.SetSeqStep(14);
					}
					else if (this.cur[0] == 4)
					{
						this.PlaySe(0);
						this.work[4] = 17;
						this.work[5] = 255;
						this.SetSeqStep(14);
					}
					else if (this.cur[0] == 5)
					{
						this.PlaySe(0);
						this.SetSeqStep(20);
					}
					else if (this.cur[0] == 6)
					{
						this.PlaySe(0);
						this.SetSeqStep(22);
					}
					else if (this.cur[0] == 7)
					{
						if (this.sdflag != 1)
						{
							this.PlaySe(5);
							return;
						}
						this.PlaySe(0);
						this.SetSeqStep(26);
					}
					else if (this.cur[0] == 8)
					{
						this.PlaySe(0);
						this.bhelpseq = 1;
						this.StartFade(1, 32);
						this.SetSeqStep(31);
					}
					this.work[0] = 0;
					this.work[1] = 8;
					this.work[2] = 7;
					this.work[3] = 7;
					this.cur[0] = (this.cur[1] = 0);
					return;
				}
				if (this.ismenu[0])
				{
					this.mmenuflag = true;
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.StartFade(1);
					this.SetSeqStep(29);
					return;
				}
			}
			break;
		case 8:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MMenuCursorUp(10, this.mmenup);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MMenuCursorDown(10, this.mmenup);
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					if (this.mmenup <= 0)
					{
						this.PlaySe(5);
						return;
					}
					if (this.mmenu[this.cur[0]] != 255)
					{
						if (((this.GetItemData(this.mmenu[this.cur[0]], 2) & 4) != 0 || (this.GetItemData(this.mmenu[this.cur[0]], 2) & 1) != 0) && (this.GetItemData(this.mmenu[this.cur[0]], 2) & 2) == 0)
						{
							this.PlaySe(5);
							return;
						}
						this.PlaySe(0);
						this.work[0] = 0;
						this.work[1] = 8;
						this.work[2] = 8;
						this.work[3] = 8;
						this.work[4] = this.mmenu[this.cur[0]];
						this.cur[0] = (this.cur[1] = 0);
						this.SetSeqStep(14);
						return;
					}
				}
				else if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 8;
					this.cur[0] = 0;
					this.cur[1] = 0;
					this.SetSeqStep(7);
					return;
				}
			}
			break;
		case 9:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MMenuCursorUp(10, this.mmenup);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MMenuCursorDown(10, this.mmenup);
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					if (this.mmenup == 0)
					{
						this.PlaySe(5);
						return;
					}
					int num2 = this.mmenu[this.cur[0]];
					if ((this.GetPlyEtParam(this.work[5], num2, 7) & 1) != 0 && (this.GetPlyEtParam(this.work[5], num2, 7) & 2) == 0)
					{
						this.PlaySe(5);
						return;
					}
					if (this.GetPlyEtParam(this.work[5], num2, 0) <= this.GetStatus(this.work[5], 4))
					{
						this.PlaySe(0);
						this.work[0] = 0;
						this.work[1] = 8;
						this.work[2] = 9;
						this.work[3] = 9;
						this.work[6] = this.mmenu[this.cur[0]];
						this.cur[0] = (this.cur[1] = 0);
						this.SetSeqStep(14);
						return;
					}
					if (this.GetPlyEtParam(this.work[5], num2, 0) > this.GetStatus(this.work[5], 4))
					{
						this.work[16] = 0;
						this.SetSeqStep(10);
						return;
					}
				}
				else if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 9;
					for (int i = 0; i < 4; i++)
					{
						if (this.GetRanks(i) == this.work[5])
						{
							this.cur[0] = i;
							break;
						}
					}
					this.cur[1] = 0;
					this.SetSeqStep(14);
					this.work[3] = 7;
					return;
				}
			}
			break;
		case 10:
			this.work[16]++;
			if (this.work[16] >= 40 || (this.id_edge & 4112) != 0)
			{
				this.SetSeqStep(9);
				return;
			}
			break;
		case 11:
		case 12:
			this.work[16]++;
			if (this.work[16] >= 40 || (this.id_edge & 4112) != 0)
			{
				this.SetSeqStep(14);
				return;
			}
			break;
		case 13:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MMenuCursorUp(6, 6);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MMenuCursorDown(6, 6);
					return;
				}
				if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 13;
					for (int i = 0; i < 4; i++)
					{
						if (this.GetRanks(i) == this.work[5])
						{
							this.cur[0] = i;
							break;
						}
					}
					this.cur[1] = 0;
					this.SetSeqStep(14);
					this.work[3] = 7;
					return;
				}
			}
			break;
		case 14:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				if (this.GetRanks(this.cur[0]) == 255)
				{
					this.cur[0] = (this.cur[0] + 1) % 4;
				}
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					do
					{
						if (this.work[3] == 8)
						{
							if (this.GetItemData(this.work[4], 1) != 5)
							{
								this.MMenuCursorUp(4, 4);
							}
						}
						else if (this.work[3] == 9)
						{
							if (this.GetPlyEtParam(this.work[5], this.work[6], 1) != 3)
							{
								this.MMenuCursorUp(4, 4);
							}
						}
						else
						{
							this.MMenuCursorUp(4, 4);
						}
					}
					while (this.GetRanks(this.cur[0]) == 255);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					do
					{
						if (this.work[3] == 8)
						{
							if (this.GetItemData(this.work[4], 1) != 5)
							{
								this.MMenuCursorDown(4, 4);
							}
						}
						else if (this.work[3] == 9)
						{
							if (this.GetPlyEtParam(this.work[5], this.work[6], 1) != 3)
							{
								this.MMenuCursorDown(4, 4);
							}
						}
						else
						{
							this.MMenuCursorDown(4, 4);
						}
					}
					while (this.GetRanks(this.cur[0]) == 255);
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					this.PlaySe(0);
					if (this.work[3] == 8)
					{
						if (!this.IsItemOk(this.GetRanks(this.cur[0]), this.work[4]))
						{
							this.work[16] = 0;
							this.SetSeqStep(12);
							return;
						}
						this.work[13] = 0;
						this.ItemExecNumCalc(this.work[4], this.GetRanks(this.cur[0]));
						this.SetSeqStep(15);
						return;
					}
					else if (this.work[3] == 9)
					{
						if (!this.IsEtherOk(this.GetRanks(this.cur[0]), this.work[5], this.work[6]))
						{
							this.work[16] = 0;
							this.SetSeqStep(11);
							return;
						}
						this.work[13] = 0;
						this.EtherExecNumCalc(this.work[5], this.work[6], this.GetRanks(this.cur[0]));
						this.SetSeqStep(16);
						return;
					}
					else if (this.work[3] == 7)
					{
						if (this.work[4] == 17)
						{
							if (this.work[5] == 255)
							{
								this.work[5] = this.cur[0];
								return;
							}
							int i = this.GetRanks(this.work[5]);
							this.SetRanks(this.work[5], this.GetRanks(this.cur[0]));
							this.SetRanks(this.cur[0], i);
							for (i = 0; i < 4; i++)
							{
								this.SetStatus(i, 20, 0);
							}
							if (this.GetRanks(3) != 255)
							{
								this.SetStatus(this.GetRanks(3), 20, 1);
							}
							if (this.GetRanks(0) != 255)
							{
								this.SetMapPlayerChar(this.GetRanks(0));
							}
							this.work[5] = 255;
							return;
						}
						else
						{
							this.work[0] = 0;
							this.work[1] = 8;
							this.work[2] = 14;
							this.work[3] = 14;
							this.work[5] = this.GetRanks(this.cur[0]);
							this.cur[0] = (this.cur[1] = 0);
							this.SetSeqStep(this.work[4]);
							if (this.work[4] == 9)
							{
								this.SetMapMenu(4, this.work[5]);
								return;
							}
							if (this.work[4] == 13)
							{
								this.SetMapMenu(5, this.work[5]);
								return;
							}
						}
					}
				}
				else if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 14;
					if (this.work[3] == 7)
					{
						if (this.work[4] == 9)
						{
							this.cur[0] = 1;
						}
						else if (this.work[4] == 13)
						{
							this.cur[0] = 2;
						}
						else if (this.work[4] == 18)
						{
							this.cur[0] = 3;
						}
						else if (this.work[4] == 17)
						{
							this.cur[0] = 4;
						}
					}
					else if (this.work[3] == 9)
					{
						this.SetMapMenu(4, this.work[5]);
						this.work[0] = 1;
						this.work[1] = 8;
						this.work[2] = 14;
						this.cur[0] = (this.cur[1] = 0);
						this.SetSeqStep(9);
					}
					else if (this.work[3] == 8)
					{
						this.SetMapMenu(0, 0);
						this.work[0] = 1;
						this.work[1] = 8;
						this.work[2] = 14;
						this.cur[0] = (this.cur[1] = 0);
						this.work[11] = 0;
						this.SetSeqStep(8);
					}
					else
					{
						this.cur[0] = 0;
					}
					this.cur[1] = 0;
					this.SetSeqStep(this.work[3]);
					return;
				}
			}
			break;
		case 15:
			this.work[13]++;
			if (this.work[13] > 16)
			{
				this.ItemExec(this.work[4], this.GetRanks(this.cur[0]));
				this.DelItem(this.work[4], 1);
				if (this.itempc[this.work[4]][0] < 1)
				{
					this.SetMapMenu(0, 0);
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 14;
					this.cur[0] = (this.cur[1] = 0);
					this.work[13] = 0;
					this.SetSeqStep(this.work[3]);
					return;
				}
				this.work[13] = 0;
				this.SetSeqStep(14);
				return;
			}
			break;
		case 16:
			this.work[13]++;
			if (this.work[13] > 16)
			{
				this.EtherExec(this.work[5], this.work[6], this.GetRanks(this.cur[0]));
				this.EpMinus(this.work[5], this.GetPlyEtParam(this.work[5], this.work[6], 0));
				if (this.GetStatus(this.work[5], 4) < this.GetPlyEtParam(this.work[5], this.work[6], 0))
				{
					this.SetMapMenu(4, this.work[5]);
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 14;
					this.work[3] = 14;
					this.cur[0] = (this.cur[1] = 0);
					this.work[13] = 0;
					this.SetSeqStep(9);
					return;
				}
				this.work[13] = 0;
				this.SetSeqStep(14);
				return;
			}
			break;
		case 17:
		case 21:
		case 25:
			break;
		case 18:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				if (this.work[1] == 7)
				{
					this.SetParamWork();
				}
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MMenuCursorUp(2, 2);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MMenuCursorDown(2, 2);
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					this.PlaySe(0);
					if (this.cur[0] == 0)
					{
						this.SetMapMenu(1, this.work[5]);
					}
					else
					{
						this.SetMapMenu(2, this.work[5]);
					}
					this.work[0] = 0;
					this.work[1] = 8;
					this.work[2] = 18;
					this.work[3] = 18;
					this.work[6] = this.cur[0];
					this.cur[0] = (this.cur[1] = 0);
					this.SetParamNowSel();
					this.SetSeqStep(19);
					return;
				}
				if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 18;
					for (int i = 0; i < 4; i++)
					{
						if (this.GetRanks(i) == this.work[5])
						{
							this.cur[0] = i;
							break;
						}
					}
					this.cur[1] = 0;
					this.SetSeqStep(14);
					this.work[3] = 7;
					return;
				}
			}
			break;
		case 19:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					if (this.mmenup != 0)
					{
						this.MMenuCursorUp(10, this.mmenup);
						this.SetParamNowSel();
						return;
					}
				}
				else if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					if (this.mmenup != 0)
					{
						this.MMenuCursorDown(10, this.mmenup);
						this.SetParamNowSel();
						return;
					}
				}
				else if ((this.id_edge & 4112) != 0)
				{
					this.PlaySe(0);
					if (this.mmenup != 0)
					{
						this.SetEquip(this.work[5], this.work[6] + 21, this.mmenu[this.cur[0]]);
						this.SetParamWork();
						return;
					}
				}
				else if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 19;
					this.cur[0] = this.work[6];
					this.cur[1] = 0;
					this.SetSeqStep(18);
					this.work[3] = 14;
					return;
				}
			}
			break;
		case 20:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
				{
					this.MMenuCursorUp(4, 4);
					return;
				}
				if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.MMenuCursorDown(4, 4);
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					this.PlaySe(0);
					if (this.cur[0] == 0)
					{
						if (this.config[0] == 0)
						{
							this.config[0] = 2;
						}
						else
						{
							this.config[0]--;
						}
					}
					else if (this.GetConfig(this.cur[0]) == 1)
					{
						this.config[this.cur[0]] = 0;
					}
					else
					{
						this.config[this.cur[0]] = 1;
					}
					if (this.cur[0] == 3)
					{
						if (this.GetConfig(3) == 0)
						{
							this.SetBackLight(false);
						}
						else
						{
							this.SetBackLight(true);
						}
					}
					else if (this.cur[0] == 0)
					{
						if (this.GetConfig(0) == 0)
						{
							this.StopAllSound();
						}
						else if (this.GetConfig(0) == 1)
						{
							if (!this.IsPlayBgm())
							{
								this.PlayBgm();
							}
							else
							{
								this.SetSoundVol();
							}
						}
						else if (!this.IsPlayBgm())
						{
							this.PlayBgm();
						}
						else
						{
							this.SetSoundVol();
						}
					}
					this.SaveOptionData();
					return;
				}
				if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 20;
					this.cur[0] = 5;
					this.cur[1] = 0;
					this.SetSeqStep(7);
					return;
				}
			}
			break;
		case 22:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0 || (this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.PlaySe(2);
					this.cur[1] = (this.cur[1] + 1) % 2;
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					this.PlaySe(0);
					if (this.cur[1] == 0)
					{
						this.work[16] = 0;
						this.SetSeqStep(23);
						return;
					}
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 22;
					this.cur[0] = 6;
					this.cur[1] = 0;
					this.SetSeqStep(7);
					return;
				}
				else if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 22;
					this.cur[0] = 6;
					this.cur[1] = 0;
					this.SetSeqStep(7);
					return;
				}
			}
			break;
		case 23:
			if (this.work[16] == 0)
			{
				this.work[16] = 1;
				return;
			}
			this.work[16] = 0;
			this.XenoSave();
			this.ismenu[0] = false;
			this.SetSeqStep(24);
			return;
		case 24:
			this.work[16]++;
			if (this.work[16] >= 60 || (this.id_edge & 4112) != 0 || this.ismenu[0])
			{
				this.ismenu[0] = false;
				this.sdflag = 1;
				this.SaveOptionData();
				this.work[16] = 0;
				this.SetSeqStep(22);
				return;
			}
			break;
		case 26:
			if (this.work[1] > 0)
			{
				this.ismenu[0] = false;
				this.work[1]--;
			}
			if (this.work[1] <= 0)
			{
				if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0 || (this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
				{
					this.PlaySe(2);
					this.cur[1] = (this.cur[1] + 1) % 2;
					return;
				}
				if ((this.id_edge & 4112) != 0)
				{
					this.PlaySe(0);
					if (this.cur[1] == 0)
					{
						this.work[16] = 0;
						this.SetSeqStep(27);
						return;
					}
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 26;
					this.cur[0] = 7;
					this.cur[1] = 0;
					this.SetSeqStep(7);
					return;
				}
				else if (this.ismenu[0])
				{
					this.PlaySe(1);
					this.ismenu[0] = false;
					this.work[0] = 1;
					this.work[1] = 8;
					this.work[2] = 26;
					this.cur[0] = 7;
					this.cur[1] = 0;
					this.SetSeqStep(7);
					return;
				}
			}
			break;
		case 27:
			if (this.work[16] == 0)
			{
				this.work[16] = 1;
				return;
			}
			this.work[16] = 0;
			this.StopDecieve();
			this.XenoLoad();
			this.SetSeqStep(28);
			return;
		case 28:
			this.work[16]++;
			if (this.work[16] >= 60 || (this.id_edge & 4112) != 0)
			{
				this.WorkClear();
				this.StartFade(1);
				this.SetSeqStep(30);
				return;
			}
			break;
		case 29:
			if (this.IsFade() == 3)
			{
				this.SetMenu(5);
				this.StartFade(0);
				this.SetSeqStep(2);
				this.red = true;
				return;
			}
			break;
		case 30:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.SetSeqNo(6);
				return;
			}
			break;
		case 31:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.helpno = 0;
				this.bhelp = 0;
				this.cur[0] = 0;
				this.cur[1] = -1;
				this.SetSeqNo(16);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x000FE3A8 File Offset: 0x000FC5A8
	private void SetParamWork()
	{
		int num = this.work[5];
		this.work[8] = this.GetStr(num) + this.GetWeaponStr(num, false);
		this.work[9] = this.GetVit(num) + this.GetArmorDef(num, false);
		this.work[10] = this.GetEAtk(num) + this.GetWeaponStr(num, true);
		this.work[11] = this.GetEDef(num) + this.GetArmorDef(num, true);
		this.work[12] = this.GetDex(num);
		this.work[13] = this.GetEva(num);
		this.work[14] = this.GetAgl(num);
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x000FE454 File Offset: 0x000FC654
	private void SetParamNowSel()
	{
		int num = this.work[5];
		int num2 = this.work[6];
		int num3 = this.mmenu[this.cur[0]];
		int num4;
		if (this.mmenup != 0 && num2 == 0)
		{
			if (num3 != 128 && num3 != 255)
			{
				num4 = this.GetStr(num) + this.GetItemData(num3, 2);
			}
			else
			{
				num4 = this.GetStr(num);
			}
		}
		else
		{
			num4 = this.GetStr(num) + this.GetWeaponStr(num, false);
		}
		this.work[15] = num4;
		if (this.mmenup != 0 && num2 == 1)
		{
			if (num3 != 128 && num3 != 255)
			{
				num4 = this.GetVit(num) + this.GetItemData(num3, 2);
			}
			else
			{
				num4 = this.GetVit(num);
			}
		}
		else
		{
			num4 = this.GetVit(num) + this.GetArmorDef(num, false);
		}
		this.work[16] = num4;
		if (this.mmenup != 0 && num2 == 0)
		{
			if (num3 != 128 && num3 != 255)
			{
				num4 = this.GetEAtk(num) + this.GetItemData(num3, 3);
			}
			else
			{
				num4 = this.GetEAtk(num);
			}
		}
		else
		{
			num4 = this.GetEAtk(num) + this.GetWeaponStr(num, true);
		}
		this.work[17] = num4;
		if (this.mmenup != 0 && num2 == 1)
		{
			if (num3 != 128 && num3 != 255)
			{
				num4 = this.GetEDef(num) + this.GetItemData(num3, 3);
			}
			else
			{
				num4 = this.GetEDef(num);
			}
		}
		else
		{
			num4 = this.GetEDef(num) + this.GetArmorDef(num, true);
		}
		this.work[18] = num4;
		this.work[19] = this.GetDex(num);
		this.work[20] = this.GetEva(num);
		this.work[21] = this.GetAgl(num);
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x000FE604 File Offset: 0x000FC804
	public virtual void VisualRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.StopVib();
			this.MenuFlagClear();
			this.isupdate = true;
			this.xscr.ScriptInit();
			if (this.visualno == 2 || this.visualno == 3 || this.visualno == 4)
			{
				this.StartFade(5);
			}
			else if (this.visualno == 15)
			{
				this.StartFade(9);
			}
			else
			{
				this.StartFade(2);
			}
			this.SetMenu(6);
			if (this.visualno == 2 || (this.visualno >= 17 && this.visualno <= 19))
			{
				this.SetMenu(4);
			}
			this.SetSeqStep(1);
			return;
		case 1:
			if (this.ismenu[1] && this.xscr.sc_skipadr != 65535 && this.xscr.sc_skipadr > this.xscr.script_adr)
			{
				this.ismenu[1] = false;
				this.xscr.script_adr = this.xscr.sc_skipadr;
				this.xscr.sc_skipadr = 65535;
				this.StopSe();
				this.xscr.sc_ifdpt = -1;
				this.SetMenu(4);
				this.PngFadeStop();
				this.xscr.ScWkClear();
				this.xscr.sc_strl = 0;
				this.xscr.script_nflg = true;
				for (int i = 0; i < 5; i++)
				{
					this.xscr.sc_ifflg[i] = false;
				}
				for (int i = 0; i < 24; i++)
				{
					this.xscr.sc_str[i] = string.Empty;
					this.xscr.sc_strl = 0;
					this.xscr.sc_stry[i] = 0;
				}
			}
			if (this.xscr.sc_skipadr == this.xscr.script_adr)
			{
				this.SetMenu(4);
			}
			this.xscr.ScriptExec();
			this.ScrObjRoutine();
			if (!this.xscr.IsScriptExec())
			{
				if (this.seq_no == this.seq_no_b)
				{
					this.MenuFlagClear();
					if (this.visualno == 2)
					{
						this.StartFade(4);
					}
					else
					{
						this.StartFade(1);
					}
					this.SetSeqStep(2);
					return;
				}
				this.isupdate = false;
				this.ReleaseVisualData();
				return;
			}
			break;
		case 2:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.ReleaseVisualData();
				if (this.nowvno == 2)
				{
					this.visualno = 3;
					this.SetSeqNo(8);
					return;
				}
				if (this.nowvno == 15 || this.nowvno == 16)
				{
					this.SetSeqNo(21);
					return;
				}
				this.SetSeqNo(10);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x000FE894 File Offset: 0x000FCA94
	public virtual void StarRoutine()
	{
		bool flag = false;
		for (int i = 0; i < 20; i++)
		{
			if (this.starxy[i][2] == 0 && this.starxy[i][3] == 0 && !flag)
			{
				this.starxy[i][0] = 120;
				this.starxy[i][1] = 130;
				this.starxy[i][2] = this.GetRand(-2, 2);
				this.starxy[i][3] = this.GetRand(-2, 2);
				flag = true;
			}
			else if (this.starxy[i][2] != 0 || this.starxy[i][3] != 0)
			{
				this.starxy[i][0] += this.starxy[i][2];
				this.starxy[i][1] += this.starxy[i][3];
				if (this.starxy[i][0] < -10 || 250 < this.starxy[i][0] || this.starxy[i][1] < -10 || 270 < this.starxy[i][1])
				{
					this.starxy[i][2] = (this.starxy[i][3] = 0);
				}
			}
		}
	}

	// Token: 0x06000C78 RID: 3192 RVA: 0x000FE9C4 File Offset: 0x000FCBC4
	public virtual void TitleRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.isupdate = true;
			this.cur[1] = 0;
			if (this.sdflag == 1)
			{
				this.cur[0] = 1;
			}
			else
			{
				this.cur[0] = 0;
			}
			this.MenuFlagClear();
			this.StartFade(0);
			this.SetMenu(10);
			this.SetSeqStep(1);
			this.WorkClear();
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			if ((this.id_edge & 1) != 0)
			{
				this.PlaySe(2);
				this.work[0] = 0;
				if (this.cur[0] != 0)
				{
					this.cur[0]--;
					return;
				}
				if (this.cdflag == 1)
				{
					this.cur[0] = 2;
					return;
				}
				this.cur[0] = 1;
				return;
			}
			else if ((this.id_edge & 2) != 0)
			{
				this.PlaySe(2);
				this.work[0] = 0;
				if ((this.cdflag == 0 && this.cur[0] == 1) || this.cur[0] == 2)
				{
					this.cur[0] = 0;
					return;
				}
				this.cur[0]++;
				return;
			}
			else if ((this.id_edge & 4112) != 0)
			{
				if (this.cur[0] == 0)
				{
					this.PlaySe(0);
					this.GameDataClear();
					this.SetMenu(4);
					this.StartFade(1);
					this.SetSeqStep(3);
					return;
				}
				if (this.cur[0] == 1)
				{
					if (this.sdflag == 1)
					{
						this.SetMenu(4);
						this.PlaySe(0);
						this.XenoLoad();
						this.StartFade(1);
						this.SetSeqStep(5);
						return;
					}
					this.PlaySe(5);
					return;
				}
			}
			else if (this.ismenu[1])
			{
				this.SetMenu(4);
				this.MenuFlagClear();
				this.StartFade(1, 32);
				this.SetSeqStep(4);
				return;
			}
			break;
		case 3:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.titleimg = null;
				this.mapno = 6;
				this.SetSeqNo(6);
				if (StApplication.GetCurrentApp().GetParameter("PP0" + 5.ToString()) != null)
				{
					this.SetSeqNo(19);
					return;
				}
			}
			break;
		case 4:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.bhelpseq = 0;
				this.helpno = 0;
				this.bhelp = 0;
				this.cur[0] = 0;
				this.cur[1] = -1;
				this.SetSeqNo(16);
				return;
			}
			break;
		case 5:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.titleimg = null;
				this.SetSeqNo(6);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x000FEC58 File Offset: 0x000FCE58
	public virtual void LogoRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.isupdate = true;
			this.StartFade(0);
			this.SetMenu(4);
			this.SetSeqStep(1);
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.WorkClear();
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			this.work[0]++;
			if (this.work[0] >= 40)
			{
				this.WorkClear();
				this.StartFade(1);
				this.SetSeqStep(3);
				return;
			}
			break;
		case 3:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.logoimg = null;
				this.SetSeqNo(10);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x000FED10 File Offset: 0x000FCF10
	public virtual void ContinueRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.isupdate = true;
			this.cur[0] = 0;
			this.StartFade(0);
			this.SetMenu(4);
			this.SetSeqStep(1);
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.WorkClear();
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			if ((this.id_edge & 1) != 0 || (this.id_edge & 2) != 0)
			{
				this.cur[0] = (this.cur[0] + 1) % 2;
				return;
			}
			if ((this.id_edge & 4112) != 0)
			{
				this.StartFade(1);
				if (this.cur[0] == 0)
				{
					this.SetSeqStep(3);
					return;
				}
				this.SetSeqStep(4);
				return;
			}
			break;
		case 3:
			if (this.IsFade() == 3)
			{
				if (this.chm == 32769 || this.chm == 1)
				{
					this.chm = 0;
				}
				else if (this.chm == 4 || this.chm == 3)
				{
					this.chm = 2;
				}
				else if (this.chm == 32774 || this.chm == 6)
				{
					this.chm = 5;
				}
				else if (this.chm == 32772 || this.chm == 32771)
				{
					this.chm = 32770;
				}
				this.isupdate = false;
				this.PlayerStatusMax();
				this.StatusAbnormalInit();
				this.SetReviveData();
				this.SetSeqNo(6);
				return;
			}
			break;
		case 4:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.SetSeqNo(10);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C7B RID: 3195 RVA: 0x000FEEA4 File Offset: 0x000FD0A4
	public virtual void ClearLoadRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.StopAllSound();
			this.isupdate = true;
			this.StartFade(6);
			this.SetMenu(4);
			this.SetSeqStep(1);
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.ismenu[0] = false;
				this.ismenu[1] = false;
				this.WorkClear();
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			this.SetMenu(9);
			if (this.ismenu[0])
			{
				this.MenuFlagClear();
				this.SetMenu(4);
				this.SetSeqStep(3);
				return;
			}
			if (this.ismenu[1])
			{
				this.MenuFlagClear();
				this.SetMenu(4);
				this.StartFade(1, 32);
				this.SetSeqStep(5);
				return;
			}
			break;
		case 3:
			this.work[0]++;
			if (this.work[0] >= 2)
			{
				this.WorkClear();
				this.XenoClearLoad();
				this.PlayerStatusMax();
				this.SetSeqStep(4);
				return;
			}
			break;
		case 4:
			this.work[0]++;
			if (this.work[0] >= 120 || (this.id_edge & 4112) != 0)
			{
				this.WorkClear();
				this.StartFade(1, 32);
				this.SetSeqStep(5);
				return;
			}
			break;
		case 5:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.mapno = 6;
				this.SetSeqNo(6);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x000FF010 File Offset: 0x000FD210
	public virtual void StaffRollRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.isupdate = true;
			this.StartFade(6);
			this.SetMenu(4);
			this.SetSeqStep(1);
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.WorkClear();
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			this.SetMenu(4);
			if ((this.id_data & 4112) != 0)
			{
				this.work[0]++;
			}
			this.work[0]++;
			if (this.work[0] >= 1104)
			{
				this.WorkClear();
				this.SetMenu(4);
				this.StartFade(1, 32);
				this.SetSeqStep(3);
				return;
			}
			break;
		case 3:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.visualno = 17;
				this.SetSeqNo(8);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x000FF0F4 File Offset: 0x000FD2F4
	public virtual void HelpInit()
	{
		sbyte[] array = new sbyte[50];
		int num = (new int[]
		{
			0, 366, 642, 1329, 2974, 3063, 3206, 3339, 3850, 4353,
			4472, 4875, 5276, 5845, 6523, 7929, 8294, 9184, 9935, 10201,
			10518, 10797, 11086, 11244, 11893
		})[this.helpno];
		for (int i = 0; i < 50; i++)
		{
			array[i] = 0;
		}
		sbyte[] resource = this.GetResource2(19);
		for (int i = 0; i < 66; i++)
		{
			this.mmstr[i] = string.Empty;
			this.mmenu[i] = 255;
		}
		this.mmenup = ((int)resource[num] + 256) & 255;
		for (int i = 0; i < this.mmenup; i++)
		{
			int num2 = ((int)resource[i * 4 + 1 + num] + 256) & 255;
			int num3 = (int)XenoPP06Canvas.ArrayShort(resource, i * 4 + 2 + num);
			int num4 = ((int)resource[i * 4 + 4 + num] + 256) & 255;
			for (int j = 0; j < 50; j++)
			{
				array[j] = 0;
			}
			this.mmenu[i] = num2;
			if (num4 == 0)
			{
				this.mmstr[i] = string.Empty;
			}
			else
			{
				for (int j = 0; j < num4; j++)
				{
					array[j] = resource[num3 + j + num];
				}
				this.mmstr[i] = SocotraRuntime.GetStringForBytesFromSjis(array, 0, num4);
				this.mmstr[i] = this.xscr.SpReplace(this.mmstr[i]);
			}
		}
		if (this.cur[1] == -1)
		{
			for (int i = 0; i < this.mmenup; i++)
			{
				if (this.mmenu[i] != 255)
				{
					this.cur[1] = i;
					break;
				}
			}
		}
		else if (this.cur[1] == -2)
		{
			this.cur[1] = this.bhelpcur[this.bhelp][1];
		}
		this.SetSeqNo(17);
	}

	// Token: 0x06000C7E RID: 3198 RVA: 0x000FF2B4 File Offset: 0x000FD4B4
	public virtual void HelpRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.isupdate = true;
			this.SetMenu(7);
			if (this.IsFade() == 3)
			{
				this.StartFade(0, 32);
			}
			this.SetSeqStep(1);
			return;
		case 1:
			if (this.IsFade() == 0)
			{
				this.SetSeqStep(2);
				return;
			}
			break;
		case 2:
			if ((this.id_edge & 1) != 0 || (this.id_rept & 1) != 0)
			{
				if (!this.HelpCursorUp() && this.cur[0] > 0)
				{
					this.cur[0]--;
					return;
				}
			}
			else if ((this.id_edge & 2) != 0 || (this.id_rept & 2) != 0)
			{
				if (!this.HelpCursorDown() && this.cur[0] + 16 < this.mmenup)
				{
					this.cur[0]++;
					return;
				}
			}
			else if ((this.id_edge & 4112) != 0)
			{
				if (this.cur[1] != -1 && this.cur[1] != this.mmenup && this.mmenu[this.cur[1]] != 255)
				{
					this.bhelpno[this.bhelp] = this.helpno;
					this.bhelpcur[this.bhelp][0] = this.cur[0];
					this.bhelpcur[this.bhelp][1] = this.cur[1];
					this.bhelp++;
					this.helpno = this.mmenu[this.cur[1]];
					this.cur[0] = 0;
					this.cur[1] = -1;
					this.SetSeqNo(16);
					return;
				}
			}
			else if (this.ismenu[0])
			{
				if (this.bhelp > 0)
				{
					this.bhelp--;
					this.helpno = this.bhelpno[this.bhelp];
					this.cur[0] = this.bhelpcur[this.bhelp][0];
					this.cur[1] = -2;
					this.SetSeqNo(16);
					return;
				}
				this.StartFade(1, 32);
				this.SetSeqStep(3);
				return;
			}
			break;
		case 3:
			if (this.IsFade() == 3)
			{
				if (this.bhelpseq == 0)
				{
					this.seq_no = (this.seq_no_b = 11);
					this.seq_step = (this.seq_step_b = 0);
					return;
				}
				if (this.bhelpseq == 1)
				{
					this.seq_no = (this.seq_no_b = 7);
					this.seq_step = (this.seq_step_b = 6);
				}
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x000FF540 File Offset: 0x000FD740
	public virtual bool HelpCursorUp()
	{
		int num = this.cur[0];
		int num2;
		if (this.cur[1] != -1 && this.cur[1] != this.mmenup)
		{
			num2 = this.cur[1] - 1;
		}
		else
		{
			num2 = ((this.cur[0] + 16 < this.mmenup) ? (this.cur[0] + 16) : (this.mmenup - 1));
		}
		for (int i = num2; i >= num; i--)
		{
			if (this.mmenu[i] != 255)
			{
				this.cur[1] = i;
				return true;
			}
		}
		if (this.cur[1] != -1 && this.cur[1] != this.mmenup)
		{
			num2 = ((this.cur[0] + 16 < this.mmenup) ? (this.cur[0] + 18) : (this.mmenup - 1));
		}
		for (int i = num2; i >= num; i--)
		{
			if (this.mmenu[i] != 255)
			{
				this.cur[1] = i;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000C80 RID: 3200 RVA: 0x000FF638 File Offset: 0x000FD838
	public virtual bool HelpCursorDown()
	{
		int num;
		if (this.cur[1] != -1 && this.cur[1] != this.mmenup)
		{
			num = this.cur[1] + 1;
		}
		else
		{
			num = this.cur[0];
		}
		int num2 = ((this.cur[0] + 16 < this.mmenup) ? (this.cur[0] + 16) : this.mmenup);
		for (int i = num; i < num2; i++)
		{
			if (this.mmenu[i] != 255)
			{
				this.cur[1] = i;
				return true;
			}
		}
		if (this.cur[1] != -1 && this.cur[1] != this.mmenup)
		{
			num = this.cur[0];
		}
		for (int i = num; i < num2; i++)
		{
			if (this.mmenu[i] != 255)
			{
				this.cur[1] = i;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x000FF710 File Offset: 0x000FD910
	public virtual void NpcCharRoutine()
	{
		if (this.xscr.IsScriptExec())
		{
			return;
		}
		for (int i = 0; i < this.xscr.npc_p; i++)
		{
			int num = this.xscr.npc_mv[i];
			if (num != 0)
			{
				this.NpcCharMove(num, i);
			}
		}
	}

	// Token: 0x06000C82 RID: 3202 RVA: 0x000FF75C File Offset: 0x000FD95C
	private void NpcCharMove(int mv, int id)
	{
		if (mv != 1)
		{
			if (mv == 2)
			{
				this.red = true;
				this.compred = true;
				int num = this.xscr.npc_xy[id][0];
				int num2 = this.xscr.npc_xy[id][1];
				if (this.GetAtrNpc(num - 2, num2, id) == 0)
				{
					this.xscr.npc_xy[id][0] = num - 2;
				}
				if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 32771)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32772;
					}
				}
				else if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 32772)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32771;
					}
				}
				else
				{
					this.xscr.npc_wk[id][1] = 0;
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32771;
				}
			}
			else if (mv == 3)
			{
				this.red = true;
				this.compred = true;
				int num = this.xscr.npc_xy[id][0];
				int num2 = this.xscr.npc_xy[id][1];
				if (this.GetAtrNpc(num + 2, num2, id) == 0)
				{
					this.xscr.npc_xy[id][0] = num + 2;
				}
				if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 3)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 4;
					}
				}
				else if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 4)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 3;
					}
				}
				else
				{
					this.xscr.npc_wk[id][1] = 0;
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 3;
				}
			}
			else if (mv == 4)
			{
				this.red = true;
				this.compred = true;
				int num = this.xscr.npc_xy[id][0];
				int num2 = this.xscr.npc_xy[id][1];
				if (this.GetAtrNpc(num, num2 - 2, id) == 0)
				{
					this.xscr.npc_xy[id][1] = num2 - 2;
				}
				if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 6)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32774;
					}
				}
				else if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 32774)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 6;
					}
				}
				else
				{
					this.xscr.npc_wk[id][1] = 0;
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 6;
				}
			}
			else if (mv == 5)
			{
				this.red = true;
				this.compred = true;
				int num = this.xscr.npc_xy[id][0];
				int num2 = this.xscr.npc_xy[id][1];
				if (this.GetAtrNpc(num, num2 + 2, id) == 0)
				{
					this.xscr.npc_xy[id][1] = num2 + 2;
				}
				if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 1)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32769;
					}
				}
				else if (this.xscr.npc_pn[id][1] == this.xscr.npc_pn[id][0] + 32769)
				{
					this.xscr.npc_wk[id][1]++;
					if (this.xscr.npc_wk[id][1] >= 4)
					{
						this.xscr.npc_wk[id][1] = 0;
						this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 1;
					}
				}
				else
				{
					this.xscr.npc_wk[id][1] = 0;
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 1;
				}
			}
		}
		this.xscr.npc_wk[id][0]--;
		if (this.xscr.npc_wk[id][0] <= 0)
		{
			this.xscr.npc_mv[id] = this.GetRand(1, 5);
			this.xscr.npc_wk[id][0] = this.GetRand(8, 16);
			this.xscr.npc_wk[id][1] = 0;
			if (this.xscr.npc_mv[id] == 1)
			{
				this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
				if (mv == 2)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32770;
					return;
				}
				if (mv == 3)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 2;
					return;
				}
				if (mv == 4)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 5;
					return;
				}
				if (mv == 5)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0];
					return;
				}
			}
			else
			{
				if (this.xscr.npc_mv[id] == 2)
				{
					if (this.xscr.npc_xy[id][0] <= this.xscr.npc_xy[id][2] - 16)
					{
						this.xscr.npc_mv[id] = 1;
						this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
					}
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32770;
					return;
				}
				if (this.xscr.npc_mv[id] == 3)
				{
					if (this.xscr.npc_xy[id][0] >= this.xscr.npc_xy[id][2] + 16)
					{
						this.xscr.npc_mv[id] = 1;
						this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
					}
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 2;
					return;
				}
				if (this.xscr.npc_mv[id] == 4)
				{
					if (this.xscr.npc_xy[id][1] <= this.xscr.npc_xy[id][3] - 16)
					{
						this.xscr.npc_mv[id] = 1;
						this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
					}
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 5;
					return;
				}
				if (this.xscr.npc_mv[id] == 5)
				{
					if (this.xscr.npc_xy[id][1] >= this.xscr.npc_xy[id][3] - 16)
					{
						this.xscr.npc_mv[id] = 1;
						this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
					}
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0];
				}
			}
		}
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x0010010C File Offset: 0x000FE30C
	public virtual void ScrObjRoutine()
	{
		int script_adr = this.xscr.script_adr;
		this.xscr.script_b_cmd = this.xscr.script_cmd;
		this.xscr.script_b_nflg = this.xscr.script_nflg;
		this.xscr.sc_b_ifdpt = this.xscr.sc_ifdpt;
		for (int i = 0; i < 5; i++)
		{
			this.xscr.sc_b_ifflg[i] = this.xscr.sc_ifflg[i];
		}
		int num = this.xscr.obj_p;
		for (int i = 0; i < num; i++)
		{
			this.xscr.obj_no = i;
			if (this.xscr.obj_kill[i] == 0)
			{
				this.xscr.ScriptInit3(this.xscr.obj_adr[i]);
				this.xscr.script_cmd = this.xscr.obj_cmd[i];
				this.xscr.script_nflg = this.xscr.obj_nflg[i];
				this.xscr.ScriptExec();
				this.xscr.obj_adr[i] = this.xscr.script_adr;
				this.xscr.obj_cmd[i] = this.xscr.script_cmd;
				this.xscr.obj_nflg[i] = this.xscr.script_nflg;
			}
			if (this.xscr.obj_anm[i][0] != 65535)
			{
				this.xscr.obj_anm[i][3]--;
				if (this.xscr.obj_anm[i][3] <= 0)
				{
					if (this.xscr.obj_pn[i] == this.xscr.obj_anm[i][0])
					{
						this.xscr.obj_pn[i] = this.xscr.obj_anm[i][1];
					}
					else
					{
						this.xscr.obj_pn[i] = this.xscr.obj_anm[i][0];
					}
					this.xscr.obj_anm[i][3] = this.xscr.obj_anm[i][2];
					this.red = true;
				}
			}
		}
		this.xscr.script_adr = script_adr;
		this.xscr.script_cmd = this.xscr.script_b_cmd;
		this.xscr.script_nflg = this.xscr.script_b_nflg;
		this.xscr.sc_ifdpt = this.xscr.sc_b_ifdpt;
		for (int i = 0; i < 5; i++)
		{
			this.xscr.sc_ifflg[i] = this.xscr.sc_b_ifflg[i];
		}
		num = this.xscr.obj_p;
		for (int i = num - 1; i >= 0; i--)
		{
			if (this.xscr.obj_kill[i] == 1)
			{
				for (int j = i; j < num - 1; j++)
				{
					for (int k = 0; k < 2; k++)
					{
						this.xscr.obj_xy[j][k] = this.xscr.obj_xy[j + 1][k];
					}
					for (int k = 0; k < 4; k++)
					{
						this.xscr.obj_wk[j][k] = this.xscr.obj_wk[j + 1][k];
					}
					this.xscr.obj_pn[j] = this.xscr.obj_pn[j + 1];
					this.xscr.obj_adr[j] = this.xscr.obj_adr[j + 1];
					this.xscr.obj_kill[j] = this.xscr.obj_kill[j + 1];
					this.xscr.obj_cmd[j] = this.xscr.obj_cmd[j + 1];
					this.xscr.obj_nflg[j] = this.xscr.obj_nflg[j + 1];
					for (int k = 0; k < 4; k++)
					{
						this.xscr.obj_anm[j][k] = this.xscr.obj_anm[j + 1][k];
					}
				}
				this.xscr.obj_p--;
			}
		}
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x00100504 File Offset: 0x000FE704
	public virtual int IsTalk()
	{
		int num = this.chx;
		int num2 = this.chy;
		int num3 = this.chm;
		if (num3 == 32769 || num3 == 1 || num3 == 0)
		{
			num2 += 12;
		}
		else if (num3 == 4 || num3 == 3 || num3 == 2)
		{
			num += 12;
		}
		else if (num3 == 32774 || num3 == 6 || num3 == 5)
		{
			num2 -= 12;
		}
		else if (num3 == 32772 || num3 == 32771 || num3 == 32770)
		{
			num -= 12;
		}
		for (int i = 0; i < this.xscr.npc_p; i++)
		{
			if (this.xscr.npc_pn[i][0] != 65534)
			{
				int num4 = this.xscr.npc_xy[i][0];
				int num5 = this.xscr.npc_xy[i][1];
				if (num4 - 8 <= num && num <= num4 + 8 && num5 - 8 <= num2 && num2 <= num5 + 8)
				{
					return i;
				}
			}
		}
		for (int i = 0; i < this.xscr.tobj_p; i++)
		{
			if (this.xscr.tobj_pn[i] != 255 && this.xscr.tobj_cnd[i] == 5)
			{
				int num4 = this.xscr.tobj_xy[i][0];
				int num5 = this.xscr.tobj_xy[i][1];
				if (this.xscr.tobj_cno[i] == 255 || (this.xscr.tobj_cno[i] == 2 && (this.chc == 28 || this.chc == 35)) || (this.xscr.tobj_cno[i] == 3 && this.chc == 43))
				{
					num4 = this.xscr.tobj_xy[i][0];
					num5 = this.xscr.tobj_xy[i][1];
					if (this.xscr.tobj_cno[i] == 2)
					{
						if ((this.chc == 28 || this.chc == 35) && (num4 > this.chx || this.chx > num4 + 16 || num5 > this.chy - 1 || this.chy - 4 > num5 + 16) && num4 <= num && num <= num4 + 16 && num5 <= num2 && num2 <= num5 + 16)
						{
							return i + 48;
						}
					}
					else if (num4 <= num && num <= num4 + 16 && num5 <= num2 && num2 <= num5 + 16)
					{
						return i + 48;
					}
				}
			}
		}
		return -1;
	}

	// Token: 0x06000C85 RID: 3205 RVA: 0x00100768 File Offset: 0x000FE968
	public virtual void PlayerTouch()
	{
		int num = this.chm;
		if (num == 32769 || num == 1 || num == 0)
		{
			this.TouchObjCheck(2);
			return;
		}
		if (num == 4 || num == 3 || num == 2)
		{
			this.TouchObjCheck(4);
			return;
		}
		if (num == 32774 || num == 6 || num == 5)
		{
			this.TouchObjCheck(1);
			return;
		}
		if (num == 32772 || num == 32771 || num == 32770)
		{
			this.TouchObjCheck(3);
		}
	}

	// Token: 0x06000C86 RID: 3206 RVA: 0x001007E0 File Offset: 0x000FE9E0
	public virtual void PlayerMoveRoutine()
	{
		if ((this.id_data & 1) != 0)
		{
			if (this.chm == 6)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 32774;
				}
			}
			else if (this.chm == 32774)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 6;
				}
			}
			else
			{
				this.chw = 0;
				this.chm = 6;
			}
			if (!this.PlayerMove(this.chx, this.chy - 4))
			{
				this.chw = 0;
				if (this.chm != 5)
				{
					this.chm = 5;
					this.red = true;
				}
			}
			this.TouchObjCheck(1);
		}
		else if ((this.id_data & 2) != 0)
		{
			if (this.chm == 1)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 32769;
				}
			}
			else if (this.chm == 32769)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 1;
				}
			}
			else
			{
				this.chw = 0;
				this.chm = 1;
			}
			if (!this.PlayerMove(this.chx, this.chy + 4))
			{
				this.chw = 0;
				if (this.chm != 0)
				{
					this.chm = 0;
					this.red = true;
				}
			}
			this.TouchObjCheck(2);
		}
		else if ((this.id_data & 4) != 0)
		{
			if (this.chm == 32771)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 32772;
				}
			}
			else if (this.chm == 32772)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 32771;
				}
			}
			else
			{
				this.chw = 0;
				this.chm = 32771;
			}
			if (!this.PlayerMove(this.chx - 4, this.chy))
			{
				this.chw = 0;
				if (this.chm != 32770)
				{
					this.chm = 32770;
					this.red = true;
				}
			}
			this.TouchObjCheck(3);
		}
		else if ((this.id_data & 8) != 0)
		{
			if (this.chm == 3)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 4;
				}
			}
			else if (this.chm == 4)
			{
				this.chw++;
				if (this.chw >= 4)
				{
					this.chw = 0;
					this.chm = 3;
				}
			}
			else
			{
				this.chw = 0;
				this.chm = 3;
			}
			if (!this.PlayerMove(this.chx + 4, this.chy))
			{
				this.chw = 0;
				if (this.chm != 2)
				{
					this.chm = 2;
					this.red = true;
				}
			}
			this.TouchObjCheck(4);
		}
		else if ((this.id_edge & 4112) != 0)
		{
			int num = 0;
			int num2 = this.IsTalk();
			if (num2 != -1 && num2 < 48)
			{
				if (this.chm == 1 || this.chm == 32769 || this.chm == 0)
				{
					num = 5;
				}
				else if (this.chm == 6 || this.chm == 32774 || this.chm == 5)
				{
					num = 0;
				}
				else if (this.chm == 32771 || this.chm == 32772 || this.chm == 32770)
				{
					num = 2;
				}
				else if (this.chm == 3 || this.chm == 4 || this.chm == 2)
				{
					num = 32770;
				}
				if (this.xscr.npc_pn[num2][0] == 65535)
				{
					this.xscr.npc_pn[num2][1] = 65535;
				}
				else
				{
					this.xscr.npc_pn[num2][1] = this.xscr.npc_pn[num2][0] + num;
				}
				this.xscr.npc_no = num2;
				this.xscr.ScriptInit2(this.xscr.npc_adr[num2]);
				this.SetMenu(4);
				this.SetSeqStep(1);
				this.red = true;
			}
			else if (num2 != -1)
			{
				num2 -= 48;
				this.xscr.tobj_no = num2;
				this.xscr.ScriptInit2(this.xscr.tobj_adr[num2]);
				this.SetMenu(4);
				this.SetSeqStep(1);
				this.red = true;
			}
		}
		else
		{
			this.chw = 0;
			if (this.chm == 1 || this.chm == 32769)
			{
				this.chm = 0;
				this.red = true;
			}
			else if (this.chm == 6 || this.chm == 32774)
			{
				this.chm = 5;
				this.red = true;
			}
			else if (this.chm == 32771 || this.chm == 32772)
			{
				this.chm = 32770;
				this.red = true;
			}
			else if (this.chm == 3 || this.chm == 4)
			{
				this.chm = 2;
				this.red = true;
			}
		}
		if (this.trapdmg != 255)
		{
			this.trapdmgwait--;
			if (this.trapdmgwait < 0)
			{
				this.StopVib();
				this.trapdmg = 255;
				this.red = true;
			}
		}
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x00100D70 File Offset: 0x000FEF70
	public virtual void TouchObjCheck(int cond)
	{
		if (this.mmenuflag)
		{
			this.mmenuflag = false;
			return;
		}
		int num = this.chx;
		int num2 = this.chy;
		for (int i = 0; i < this.xscr.tobj_p; i++)
		{
			int num3 = this.xscr.tobj_xy[i][0];
			int num4 = this.xscr.tobj_xy[i][1];
			if (this.xscr.tobj_cnd[i] == 6 || this.xscr.tobj_cnd[i] == 0 || this.xscr.tobj_cnd[i] == cond)
			{
				if (this.xscr.tobj_cnd[i] == 6)
				{
					if (this.chm == 1 || this.chm == 32769 || this.chm == 0 || this.chm == 6 || this.chm == 32774 || this.chm == 5)
					{
						if (num3 + 4 <= num && num <= num3 + 12 && num4 + 6 <= num2 && num2 <= num4 + 10)
						{
							this.xscr.ScriptInit2(this.xscr.tobj_adr[i]);
							this.SetMenu(4);
							this.SetSeqStep(1);
							return;
						}
					}
					else if ((this.chm == 32771 || this.chm == 32772 || this.chm == 32770 || this.chm == 3 || this.chm == 4 || this.chm == 2) && num3 + 6 <= num && num <= num3 + 10 && num4 + 4 <= num2 && num2 <= num4 + 16)
					{
						this.xscr.ScriptInit2(this.xscr.tobj_adr[i]);
						this.SetMenu(4);
						this.SetSeqStep(1);
						return;
					}
				}
				else if (num3 <= num && num <= num3 + 16 && num4 <= num2 && num2 <= num4 + 16)
				{
					if (this.xscr.tobj_cnd[i] == 0)
					{
						this.xscr.ScriptInit2(this.xscr.tobj_adr[i]);
						this.xscr.ScriptExec();
						return;
					}
					this.xscr.ScriptInit2(this.xscr.tobj_adr[i]);
					this.SetMenu(4);
					this.SetSeqStep(1);
					return;
				}
			}
		}
	}

	// Token: 0x06000C88 RID: 3208 RVA: 0x00100FB0 File Offset: 0x000FF1B0
	public virtual void TrapCheck()
	{
		int num = this.chx;
		int num2 = this.chy;
		if (this.trap != 255)
		{
			int num3 = this.xscr.trap_xy[this.trap][0];
			int num4 = this.xscr.trap_xy[this.trap][1];
			if (num3 > num || num > num3 + 16 || num4 > num2 || num2 > num4 + 16)
			{
				this.trap = 255;
			}
		}
		if (this.trap == 255)
		{
			for (int i = 0; i < this.xscr.trap_p; i++)
			{
				int num3 = this.xscr.trap_xy[i][0];
				int num4 = this.xscr.trap_xy[i][1];
				if (num3 <= num && num <= num3 + 16 && num4 <= num2 && num2 <= num4 + 16)
				{
					this.trap = i;
					this.trapdmg = this.xscr.trap_id[i];
					if (this.trapdmg != 2)
					{
						this.trapdmgwait = 15;
					}
					switch (this.xscr.trap_id[i])
					{
					case 0:
					{
						for (int j = 0; j < 4; j++)
						{
							this.HpDec(j, this.GetStatus(j, 3) / 5);
						}
						this.PlaySe(8);
						this.StartVib(15);
						break;
					}
					case 3:
					{
						for (int j = 0; j < 4; j++)
						{
							this.HpDec(j, 10);
						}
						this.PlaySe(8);
						this.StartVib(15);
						break;
					}
					case 4:
					{
						for (int j = 0; j < 4; j++)
						{
							this.HpDec(j, 30);
						}
						this.PlaySe(8);
						this.StartVib(15);
						break;
					}
					case 5:
					{
						for (int j = 0; j < 4; j++)
						{
							this.HpDec(j, 60);
						}
						this.PlaySe(8);
						this.StartVib(15);
						break;
					}
					}
					for (int j = 0; j < 4; j++)
					{
						if (this.GetStatus(j, 2) == 0)
						{
							this.SetStatus(j, 2, 1);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x001011B8 File Offset: 0x000FF3B8
	public virtual int GetPngHeight(int no)
	{
		int num = no;
		if ((no & 32768) != 0)
		{
			num = no & -32769;
		}
		if (this.GetSeqNo() == 9)
		{
			if (num >= this.vtbl[this.nowvno])
			{
				return 0;
			}
			return this.vimg[num].GetHeight();
		}
		else
		{
			if (num >= this.mcimgmax)
			{
				return 0;
			}
			return this.mcimg[num].GetHeight();
		}
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x0010121C File Offset: 0x000FF41C
	public virtual void DrawTalk(StGraphics g)
	{
		if (!this.sysred && (this.window_cnt == 0 || !this.window_flg))
		{
			return;
		}
		if (this.window_cnt == 0)
		{
			return;
		}
		this.SetFont(g, this.scrfont);
		if (this.window_cnt < 5)
		{
			this.DrawTalkWindow(g, 0, this.xscr.sc_winy + 41 - this.window_cnt * 16 / 2, 239, this.window_cnt * 16);
			return;
		}
		int num = this.xscr.sc_winy + 4;
		int num2 = 6;
		this.DrawTalkWindow(g, 0, this.xscr.sc_winy, 239, 75);
		if (this.xscr.IsMessageSelect())
		{
			this.SetColor(g, 16777215);
			this.DrawString(g, "はい", num2 + 12, num, 0, false);
			this.DrawString(g, "いいえ", num2 + 12, num + 12, 0, false);
			g.DrawImage(this.sysimg[42], num2 + 2, num + this.cur[0] * 12 + 4);
			return;
		}
		if (this.xscr.sc_face != 255)
		{
			g.DrawImage(this.faceimg[this.xscr.sc_face], 2, this.xscr.sc_winy + 6 + 9);
			num2 += 24;
		}
		this.SetColor(g, 16777215);
		if (this.xscr.sc_name != string.Empty)
		{
			this.DrawString(g, this.xscr.sc_name, num2, num, 0, false);
			num += 13;
		}
		if (this.xscr.IsMessageEnd() || this.scrcompred)
		{
			for (int i = 0; i < this.xscr.sc_strl; i++)
			{
				this.SetColor(g, 16777215);
				this.DrawString(g, this.xscr.sc_str[i], num2, num, 0, false);
				num += 13;
			}
		}
		else if (this.xscr.IsMessage())
		{
			for (int i = 0; i < this.xscr.sc_strl - 1; i++)
			{
				this.SetColor(g, 16777215);
				this.DrawString(g, this.xscr.sc_str[i], num2, num, 0, false);
				num += 13;
			}
			string text = StString.Substring(this.xscr.sc_str[this.xscr.sc_strl - 1], 0, this.xscr.sc_wk[2]);
			this.SetColor(g, 16777215);
			this.DrawString(g, text, num2, num, 0, false);
		}
		if (this.xscr.IsMessageEnd3() && this.window_flg)
		{
			g.DrawImage(this.sysimg[43], 232, this.xscr.sc_winy + 66 + this.sync % 4);
		}
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x001014D0 File Offset: 0x000FF6D0
	public virtual void DrawTalk2(StGraphics g)
	{
		this.SetFont(g, this.scrfont);
		if (this.xscr.IsMessageEnd2())
		{
			for (int i = 0; i < this.xscr.sc_strl; i++)
			{
				this.SetColor(g, 16777215);
				if (this.visualno == 2)
				{
					this.SetColor(g, 0);
				}
				if (this.visualno >= 15 && this.visualno <= 16 && this.xscr.sc_flg[78] == 1)
				{
					this.DrawString(g, this.xscr.sc_str[i], 0, this.xscr.sc_stry[i], 0);
				}
				else if (this.visualno >= 17 && this.visualno <= 19 && this.xscr.sc_flg[78] == 1)
				{
					this.DrawString(g, this.xscr.sc_str[i], 80, this.xscr.sc_stry[i], 0);
				}
				else
				{
					this.DrawString(g, this.xscr.sc_str[i], 2, this.xscr.sc_stry[i], 0);
				}
			}
		}
		else if (this.xscr.IsMessage2())
		{
			for (int i = 0; i < this.xscr.sc_strl - 1; i++)
			{
				this.SetColor(g, 16777215);
				if (this.visualno == 2)
				{
					this.SetColor(g, 0);
				}
				if (this.visualno >= 15 && this.visualno <= 16 && this.xscr.sc_flg[78] == 1)
				{
					this.DrawString(g, this.xscr.sc_str[i], 0, this.xscr.sc_stry[i], 0);
				}
				else if (this.visualno >= 17 && this.visualno <= 19 && this.xscr.sc_flg[78] == 1)
				{
					this.DrawString(g, this.xscr.sc_str[i], 80, this.xscr.sc_stry[i], 0);
				}
				else
				{
					this.DrawString(g, this.xscr.sc_str[i], 2, this.xscr.sc_stry[i], 0);
				}
			}
			string text = StString.Substring(this.xscr.sc_str[this.xscr.sc_strl - 1], 0, this.xscr.sc_wk[2]);
			this.SetColor(g, 16777215);
			if (this.visualno == 2)
			{
				this.SetColor(g, 0);
			}
			if (this.visualno >= 15 && this.visualno <= 16 && this.xscr.sc_flg[78] == 1)
			{
				this.DrawString(g, text, 0, this.xscr.sc_stry[this.xscr.sc_strl - 1], 0);
			}
			else if (this.visualno >= 17 && this.visualno <= 19 && this.xscr.sc_flg[78] == 1)
			{
				this.DrawString(g, text, 80, this.xscr.sc_stry[this.xscr.sc_strl - 1], 0);
			}
			else
			{
				this.DrawString(g, text, 2, this.xscr.sc_stry[this.xscr.sc_strl - 1], 0);
			}
		}
		if (this.xscr.IsMessageEnd4())
		{
			int num = this.xscr.sc_stry[this.xscr.sc_strl - 1] + 12;
			if (this.visualno < 15 || this.visualno > 19 || this.xscr.sc_flg[78] != 1)
			{
				g.DrawImage(this.sysimg[43], 230, num + this.sync % 4);
			}
		}
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x00101862 File Offset: 0x000FFA62
	protected internal virtual void SetArrayByte(sbyte[] data, int ofs, sbyte num)
	{
		data[ofs] = num;
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x00101868 File Offset: 0x000FFA68
	protected internal virtual void SetArrayInt(sbyte[] data, int ofs, int num)
	{
		data[ofs] = (sbyte)((num >> 24) & 255);
		data[ofs + 1] = (sbyte)((num >> 16) & 255);
		data[ofs + 2] = (sbyte)((num >> 8) & 255);
		data[ofs + 3] = (sbyte)(num & 255);
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x001018A4 File Offset: 0x000FFAA4
	protected internal virtual void XenoSave()
	{
		sbyte[] array = this.XenoSaveDataCreate();
		this.StoreRecords(52, array, array.Length);
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x001018C8 File Offset: 0x000FFAC8
	protected internal virtual sbyte[] XenoSaveDataCreate()
	{
		sbyte[] array = new sbyte[1370];
		int num = 0;
		int i;
		for (i = 0; i < 1370; i++)
		{
			array[i] = 0;
		}
		for (i = 0; i < 4; i++)
		{
			this.SetArrayInt(array, num, this.GetRanks(i));
			num += 4;
		}
		int j;
		for (i = 0; i < 4; i++)
		{
			for (j = 0; j < 26; j++)
			{
				this.SetArrayInt(array, num, this.GetStatus(i, j));
				num += 4;
			}
		}
		this.SetArrayInt(array, num, this.mapno);
		num += 4;
		this.SetArrayInt(array, num, this.mapx);
		num += 4;
		this.SetArrayInt(array, num, this.mapy);
		num += 4;
		this.SetArrayInt(array, num, this.chm);
		num += 4;
		this.SetArrayInt(array, num, this.chc);
		num += 4;
		this.SetArrayInt(array, num, this.chx);
		num += 4;
		this.SetArrayInt(array, num, this.chy);
		num += 4;
		for (i = 0; i < 66; i++)
		{
			for (j = 0; j < 2; j++)
			{
				this.SetArrayInt(array, num, this.itempc[i][j]);
				num += 4;
			}
		}
		for (i = 0; i < 80; i++)
		{
			this.SetArrayInt(array, num, this.xscr.sc_flg[i]);
			num += 4;
		}
		this.SetArrayInt(array, num, this.rev_mapno);
		num += 4;
		this.SetArrayInt(array, num, this.rev_mapx);
		num += 4;
		this.SetArrayInt(array, num, this.rev_mapy);
		num += 4;
		this.SetArrayInt(array, num, this.rev_chx);
		num += 4;
		this.SetArrayInt(array, num, this.rev_chy);
		num += 4;
		StCalendar instance = StCalendar.GetInstance();
		char[] array2 = "1.0.0".ToCharArray();
		string text = string.Empty;
		i = 0;
		while (i < array2.Length && array2[i] != '.')
		{
			text += array2[i].ToString();
			i++;
		}
		int num2 = Convert.ToInt32(text);
		text = string.Empty;
		j = 0;
		for (i = 0; i < array2.Length; i++)
		{
			if (array2[i] == '.')
			{
				j++;
				if (j == 2)
				{
					break;
				}
				text = string.Empty;
			}
			else
			{
				text += array2[i].ToString();
			}
		}
		int num3 = Convert.ToInt32(text);
		text = string.Empty;
		for (i = 0; i < array2.Length; i++)
		{
			if (array2[i] == '.')
			{
				text = string.Empty;
			}
			else
			{
				text += array2[i].ToString();
			}
		}
		int num4 = Convert.ToInt32(text);
		int num5 = instance.Get(1) - 1900;
		int num6 = instance.Get(2);
		int num7 = instance.Get(5);
		int num8 = instance.Get(11);
		int num9 = instance.Get(12);
		int num10 = instance.Get(13);
		this.SetArrayInt(array, num, num2);
		num += 4;
		this.SetArrayInt(array, num, num3);
		num += 4;
		this.SetArrayInt(array, num, num4);
		num += 4;
		this.SetArrayInt(array, num, num5);
		num += 4;
		this.SetArrayInt(array, num, num6);
		num += 4;
		this.SetArrayInt(array, num, num7);
		num += 4;
		this.SetArrayInt(array, num, num8);
		num += 4;
		this.SetArrayInt(array, num, num9);
		num += 4;
		this.SetArrayInt(array, num, num10);
		num += 4;
		this.SetArrayInt(array, num, 5);
		num += 4;
		return array;
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x00101C28 File Offset: 0x000FFE28
	protected internal virtual void XenoLoad()
	{
		sbyte[] array = this.LoadRecords(52, 1370);
		int num = 0;
		if (array == null)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			this.SetRanks(i, XenoPP06Canvas.ArrayInt(array, num));
			num += 4;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 26; j++)
			{
				this.SetStatus(i, j, XenoPP06Canvas.ArrayInt(array, num));
				num += 4;
			}
		}
		this.mapno = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.mapx = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.mapy = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.chm = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.chc = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.chx = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.chy = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		for (int i = 0; i < 66; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.itempc[i][j] = XenoPP06Canvas.ArrayInt(array, num);
				num += 4;
			}
		}
		for (int i = 0; i < 80; i++)
		{
			this.xscr.sc_flg[i] = XenoPP06Canvas.ArrayInt(array, num);
			num += 4;
		}
		this.rev_mapno = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_mapx = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_mapy = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_chx = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_chy = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x00101DB4 File Offset: 0x000FFFB4
	protected internal static int LoadRecord(int id)
	{
		Type typeFromHandle = typeof(XenoPP06Canvas);
		int num2;
		lock (typeFromHandle)
		{
			int num = 0;
			try
			{
				string text = "pos=" + id.ToString();
				DataInputStream dataInputStream = Connector.OpenDataInputStream("scratchpad:///14;" + text);
				num = dataInputStream.ReadInt();
				dataInputStream.Close();
			}
			catch (Exception)
			{
			}
			num2 = num;
		}
		return num2;
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x00101E38 File Offset: 0x00100038
	protected internal virtual sbyte[] LoadRecords(int id, int len)
	{
		sbyte[] array3;
		lock (this)
		{
			sbyte[] array = null;
			try
			{
				string text = "pos=" + id.ToString();
				InputStream inputStream = Connector.OpenDataInputStream("scratchpad:///14;" + text);
				int num = 0;
				sbyte[] array2 = new sbyte[32];
				ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream(10240);
				int num2;
				while ((num2 = inputStream.Read(array2)) >= 0)
				{
					byteArrayOutputStream.Write(array2, 0, num2);
					num += num2;
					if (num >= len)
					{
						break;
					}
				}
				inputStream.Close();
				byteArrayOutputStream.Close();
				array = byteArrayOutputStream.ToSByteArray();
			}
			catch (Exception)
			{
			}
			array3 = array;
		}
		return array3;
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x00101F00 File Offset: 0x00100100
	protected internal static void StoreRecord(int id, int val)
	{
		Type typeFromHandle = typeof(XenoPP06Canvas);
		lock (typeFromHandle)
		{
			try
			{
				string text = "pos=" + id.ToString();
				DataOutputStream dataOutputStream = Connector.OpenDataOutputStream("scratchpad:///14;" + text);
				dataOutputStream.WriteInt(val);
				dataOutputStream.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x00101F7C File Offset: 0x0010017C
	protected internal void StoreRecords(int id, sbyte[] data, int len)
	{
		Type typeFromHandle = typeof(XenoPP06Canvas);
		lock (typeFromHandle)
		{
			this.saflag = false;
			try
			{
				string text = "pos=" + id.ToString();
				OutputStream outputStream = Connector.OpenOutputStream("scratchpad:///14;" + text);
				outputStream.Write(data, 0, len);
				outputStream.Close();
			}
			catch (Exception)
			{
				this.saflag = true;
			}
		}
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x00102008 File Offset: 0x00100208
	protected internal virtual void ExistSaveData()
	{
		if (XenoPP06Canvas.ArrayInt(this.LoadRecords(20, 24), 20) == 1)
		{
			this.LoadOptionData();
			this.ResetConfig();
			return;
		}
		this.SaveOptionData();
		this.XenoSave();
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x00102038 File Offset: 0x00100238
	protected internal virtual void LoadOptionData()
	{
		int num = 0;
		sbyte[] array = this.LoadRecords(20, 24);
		for (int i = 0; i < 4; i++)
		{
			this.config[i] = XenoPP06Canvas.ArrayInt(array, num);
			num += 4;
		}
		this.sdflag = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
		this.opflag = XenoPP06Canvas.ArrayInt(array, num);
		num += 4;
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x00102094 File Offset: 0x00100294
	protected internal virtual void SaveOptionData()
	{
		this.opflag = 1;
		sbyte[] array = this.XenoOptionDataCreate();
		this.StoreRecords(20, array, array.Length);
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x001020C0 File Offset: 0x001002C0
	protected internal virtual sbyte[] XenoOptionDataCreate()
	{
		int num = 0;
		sbyte[] array = new sbyte[24];
		for (int i = 0; i < 20; i++)
		{
			array[i] = 0;
		}
		for (int i = 0; i < 4; i++)
		{
			this.SetArrayInt(array, num, this.config[i]);
			num += 4;
		}
		this.SetArrayInt(array, num, this.sdflag);
		num += 4;
		this.SetArrayInt(array, num, this.opflag);
		num += 4;
		return array;
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x00102130 File Offset: 0x00100330
	public virtual void SetRevivePoint()
	{
		this.rev_mapno = this.mapno;
		this.rev_mapx = this.mapx;
		this.rev_mapy = this.mapy;
		this.rev_chx = this.chx;
		this.rev_chy = this.chy;
		if (this.mapno == 5)
		{
			this.PlayerStatusMax();
		}
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x00102188 File Offset: 0x00100388
	public virtual void SetReviveData()
	{
		if (this.rev_mapno != 65535)
		{
			this.mapno = this.rev_mapno;
			this.mapx = this.rev_mapx;
			this.mapy = this.rev_mapy;
			this.chx = this.rev_chx;
			this.chy = this.rev_chy;
		}
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x001021E0 File Offset: 0x001003E0
	protected internal virtual void XenoClearLoad()
	{
		int num = 0;
		string parameter;
		try
		{
			parameter = StApplication.GetCurrentApp().GetParameter("PP0" + 5.ToString());
		}
		catch (Exception)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			this.SetStatus(i, 0, Convert.ToInt32(StString.Substring(parameter, num, num + 2)));
			num += 2;
			this.SetLevelStatus(i, this.GetStatus(i, 0));
			this.SetStatus(i, 14, Convert.ToInt32(StString.Substring(parameter, num, num + 6)));
			num += 6;
			this.SetStatus(i, 15, Convert.ToInt32(StString.Substring(parameter, num, num + 5)));
			num += 5;
			this.SetEquip(i, 21, Convert.ToInt32(StString.Substring(parameter, num, num + 2)));
			num += 2;
			this.SetEquip(i, 22, Convert.ToInt32(StString.Substring(parameter, num, num + 2)));
			num += 2;
		}
		for (int i = 0; i < 63; i++)
		{
			this.itempc[i][0] = Convert.ToInt32(StString.Substring(parameter, num, num + 2));
			num += 2;
		}
		this.AddItem(1, 15);
		this.AddItem(2, 10);
		this.AddItem(5, 15);
		this.AddItem(6, 10);
		this.AddItem(9, 10);
		this.AddItem(11, 15);
		this.AddItem(14, 5);
		this.AddItem(15, 10);
		this.AddItem(16, 5);
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x00102350 File Offset: 0x00100550
	protected internal virtual sbyte[] GetResource2(int fid)
	{
		sbyte[] array = null;
		int num = 1542;
		if (fid != 0)
		{
			for (int i = 0; i < fid; i++)
			{
				num += this.downfilechk[i][1];
			}
		}
		int num2;
		int num3;
		string text;
		if (fid == 81)
		{
			num2 = this.se_wav_downfilechk[3][0];
			num3 = this.se_wav_downfilechk[3][1];
			text = "se_SH.dat";
		}
		else
		{
			num2 = this.downfilechk[fid][0];
			num3 = this.downfilechk[fid][1];
			text = this.dfilename[fid][0] + this.dfilename[fid][1];
		}
		try
		{
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream(10240);
			sbyte[] array2 = new sbyte[1024];
			InputStream inputStream = Connector.OpenDataInputStream("scratchpad:///14;pos=" + num.ToString() + ",length=" + num3.ToString());
			JarInflater jarInflater = new JarInflater(inputStream);
			InputStream inputStream2 = jarInflater.GetInputStream(text);
			int num4 = 0;
			int num5;
			while ((num5 = inputStream2.Read(array2)) >= 0)
			{
				byteArrayOutputStream.Write(array2, 0, num5);
				num4 += num5;
				if (num4 >= num2)
				{
					break;
				}
			}
			inputStream.Close();
			inputStream2.Close();
			jarInflater.Close();
			byteArrayOutputStream.Close();
			array = byteArrayOutputStream.ToSByteArray();
		}
		catch (Exception)
		{
		}
		return array;
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x00102494 File Offset: 0x00100694
	public virtual void StartDecieve()
	{
		for (int i = 0; i < 12; i++)
		{
			this.dec_flg[i] = this.GetRand(0, 1);
			this.dec_y[i] = this.GetRand(-1, 1);
			this.GetRand(5, 125);
			this.dec_col[i] = this.GetRand(1, 3);
			int num;
			if (this.dec_flg[i] == 0)
			{
				num = 240 + this.GetRand(0, 32);
				this.dec_col[i] *= -1;
			}
			else
			{
				num = this.GetRand(0, 32) - 128;
			}
			int num2 = this.GetRand(0, 224);
			int num3 = this.GetRand(80, 128);
			int num4 = this.GetRand(8, 16);
			this.dec_pa.GetVertexArray()[i * 12] = num;
			this.dec_pa.GetVertexArray()[i * 12 + 1] = num2;
			this.dec_pa.GetVertexArray()[i * 12 + 3] = num + num3;
			this.dec_pa.GetVertexArray()[i * 12 + 4] = num2;
			this.dec_pa.GetVertexArray()[i * 12 + 6] = num + num3;
			this.dec_pa.GetVertexArray()[i * 12 + 7] = num2 + num4;
			this.dec_pa.GetVertexArray()[i * 12 + 9] = num;
			this.dec_pa.GetVertexArray()[i * 12 + 10] = num2 + num4;
			if (this.GetRand(0, 1) == 0)
			{
				this.dec_pa.GetNormalArray()[i * 3 + 2] = -4096;
				this.dec_nor_work[i] = this.GetRand(1, 4) * 10;
			}
			else
			{
				this.dec_pa.GetNormalArray()[i * 3 + 2] = 0;
				this.dec_nor_work[i] = this.GetRand(1, 4) * -10;
			}
		}
		this.decieveFlag = true;
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x00102654 File Offset: 0x00100854
	public virtual void StopDecieve()
	{
		for (int i = 0; i < 12; i++)
		{
			this.dec_col[i] = 0;
			this.dec_flg[i] = 0;
			this.dec_y[i] = 0;
			for (int j = 0; j < 12; j++)
			{
				this.dec_pa.GetVertexArray()[i * 12 + j] = 0;
			}
			this.dec_pa.GetNormalArray()[i * 3 + 2] = -4096;
			this.dec_nor_work[i] = 0;
		}
		this.decieveFlag = false;
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x001026D0 File Offset: 0x001008D0
	public virtual void DrawDecieve(StGraphics g)
	{
		((StGraphics3D)g).SetScreenCenter(0, 0);
		((StGraphics3D)g).SetPrimitiveTextureArray(this.mimg);
		((StGraphics3D)g).SetPrimitiveTexture(0);
		((StGraphics3D)g).EnableSemiTransparent(true);
		if (this.decieveFlag)
		{
			((StGraphics3D)g).EnableLight(true);
			((StGraphics3D)g).RenderPrimitives(this.dec_pa, 65, false);
		}
		else
		{
			((StGraphics3D)g).EnableLight(false);
			((StGraphics3D)g).RenderPrimitives(this.dec_pa, 64, false);
		}
		((StGraphics3D)g).Flush();
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x00102740 File Offset: 0x00100940
	public virtual void DecieveRoutine()
	{
		if (!this.decieveFlag)
		{
			return;
		}
		for (int i = 0; i < 12; i++)
		{
			if (this.GetRand(0, 1) == 0)
			{
				this.dec_pa.GetNormalArray()[i * 3 + 2] += this.dec_nor_work[i];
			}
			if (this.dec_pa.GetNormalArray()[i * 3 + 2] > 0 || this.dec_pa.GetNormalArray()[i * 3 + 2] < -4096)
			{
				this.dec_nor_work[i] *= -1;
			}
			if (this.dec_flg[i] == 0 || this.dec_flg[i] == 1)
			{
				this.dec_pa.GetVertexArray()[i * 12] += this.dec_col[i];
				this.dec_pa.GetVertexArray()[i * 12 + 3] += this.dec_col[i];
				this.dec_pa.GetVertexArray()[i * 12 + 6] += this.dec_col[i];
				this.dec_pa.GetVertexArray()[i * 12 + 9] += this.dec_col[i];
				if (this.dec_y[i] != 0)
				{
					int num = this.GetRand(-9, 1);
					if (num == 1)
					{
						num *= this.dec_y[i];
						this.dec_pa.GetVertexArray()[i * 12 + 1] += num;
						this.dec_pa.GetVertexArray()[i * 12 + 4] += num;
						this.dec_pa.GetVertexArray()[i * 12 + 7] += num;
						this.dec_pa.GetVertexArray()[i * 12 + 10] += num;
					}
				}
				if ((this.dec_flg[i] == 0 && this.dec_pa.GetVertexArray()[i * 12 + 3] <= 0) || (this.dec_flg[i] == 1 && this.dec_pa.GetVertexArray()[i * 12] >= 240))
				{
					this.dec_flg[i] = 2;
				}
			}
			else if (this.dec_flg[i] == 2)
			{
				this.dec_col[i] = this.GetRand(1, 3);
				this.dec_flg[i] = this.GetRand(0, 1);
				this.dec_y[i] = this.GetRand(-1, 1);
				if (this.GetRand(0, 1) == 0)
				{
					this.dec_pa.GetNormalArray()[i * 3 + 2] = -4096;
					this.dec_nor_work[i] = this.GetRand(1, 4) * 10;
				}
				else
				{
					this.dec_pa.GetNormalArray()[i * 3 + 2] = 0;
					this.dec_nor_work[i] = this.GetRand(1, 4) * -10;
				}
				int num2;
				if (this.dec_flg[i] == 0)
				{
					num2 = 240 + this.GetRand(0, 32);
					this.dec_col[i] *= -1;
				}
				else
				{
					num2 = this.GetRand(0, 32) - 128;
				}
				int num3 = this.GetRand(0, 224);
				int num4 = this.GetRand(80, 128);
				int num5 = this.GetRand(8, 16);
				this.dec_pa.GetVertexArray()[i * 12] = num2;
				this.dec_pa.GetVertexArray()[i * 12 + 1] = num3;
				this.dec_pa.GetVertexArray()[i * 12 + 3] = num2 + num4;
				this.dec_pa.GetVertexArray()[i * 12 + 4] = num3;
				this.dec_pa.GetVertexArray()[i * 12 + 6] = num2 + num4;
				this.dec_pa.GetVertexArray()[i * 12 + 7] = num3 + num5;
				this.dec_pa.GetVertexArray()[i * 12 + 9] = num2;
				this.dec_pa.GetVertexArray()[i * 12 + 10] = num3 + num5;
				num2 = 11;
				int num = this.GetRand(0, 1);
				if (num == 0)
				{
					this.dec_pa.GetTextureCoordArray()[i * 8] = num2 * 16 + num2 + 1;
					this.dec_pa.GetTextureCoordArray()[i * 8 + 2] = num2 * 16 + num2 + 64 - 1;
					this.dec_pa.GetTextureCoordArray()[i * 8 + 4] = num2 * 16 + num2 + 64 - 1;
					this.dec_pa.GetTextureCoordArray()[i * 8 + 6] = num2 * 16 + num2 + 1;
				}
				else if (num == 1)
				{
					this.dec_pa.GetTextureCoordArray()[i * 8] = num2 * 16 + num2 + 64 - 1;
					this.dec_pa.GetTextureCoordArray()[i * 8 + 2] = num2 * 16 + num2 + 1;
					this.dec_pa.GetTextureCoordArray()[i * 8 + 4] = num2 * 16 + num2 + 1;
					this.dec_pa.GetTextureCoordArray()[i * 8 + 6] = num2 * 16 + num2 + 64 - 1;
				}
			}
		}
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x00102BF0 File Offset: 0x00100DF0
	public virtual void DrawDomeEffect(StGraphics g)
	{
		((StGraphics3D)g).SetScreenCenter(0, 0);
		((StGraphics3D)g).SetPrimitiveTextureArray(this.mimg);
		((StGraphics3D)g).SetPrimitiveTexture(0);
		((StGraphics3D)g).EnableSemiTransparent(true);
		((StGraphics3D)g).RenderPrimitives(this.dome_pa, 64, false);
		((StGraphics3D)g).Flush();
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x00102C2C File Offset: 0x00100E2C
	public virtual void DomeEffectRoutine()
	{
		if (this.dome_flag == 0)
		{
			return;
		}
		this.red = true;
		int num = 120;
		int num2 = 138;
		if (this.dome_flag == 1)
		{
			this.dome_pa.GetVertexArray()[0] = num;
			this.dome_pa.GetVertexArray()[1] = num2;
			this.dome_pa.GetVertexArray()[3] = num;
			this.dome_pa.GetVertexArray()[4] = num2;
			this.dome_pa.GetVertexArray()[6] = num;
			this.dome_pa.GetVertexArray()[7] = num2;
			this.dome_pa.GetVertexArray()[9] = num;
			this.dome_pa.GetVertexArray()[10] = num2;
			this.dome_flag = 2;
			return;
		}
		if (this.dome_flag == 2)
		{
			int num3 = this.dome_work / 3;
			int num4 = this.dome_work / 6;
			this.dome_pa.GetVertexArray()[0] = num - num3;
			this.dome_pa.GetVertexArray()[1] = num2 - num3;
			this.dome_pa.GetVertexArray()[3] = num + num3;
			this.dome_pa.GetVertexArray()[4] = num2 - num3;
			this.dome_pa.GetVertexArray()[6] = num + num3;
			this.dome_pa.GetVertexArray()[7] = num2 + num4;
			this.dome_pa.GetVertexArray()[9] = num - num3;
			this.dome_pa.GetVertexArray()[10] = num2 + num4;
			this.dome_work++;
			if (this.dome_work >= 150)
			{
				this.dome_work = 0;
				this.dome_flag = 3;
				return;
			}
		}
		else if (this.dome_flag == 3 && this.xscr.sc_flg[55] == 1)
		{
			this.dome_flag = 0;
			for (int i = 0; i < 12; i++)
			{
				this.dome_pa.GetVertexArray()[i] = 0;
			}
		}
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x00102DE0 File Offset: 0x00100FE0
	public virtual void ExplosionSmokeRoutine()
	{
		if (this.es_flag == 0)
		{
			return;
		}
		this.red = true;
		if (this.es_flag == 1)
		{
			int num = 80;
			int num2 = 88;
			int num3 = 80;
			int num4 = 72;
			for (int i = 0; i < 3; i++)
			{
				this.dec_pa.GetVertexArray()[i * 12] = num;
				this.dec_pa.GetVertexArray()[i * 12 + 1] = num2;
				this.dec_pa.GetVertexArray()[i * 12 + 3] = num + num3;
				this.dec_pa.GetVertexArray()[i * 12 + 4] = num2;
				this.dec_pa.GetVertexArray()[i * 12 + 6] = num + num3;
				this.dec_pa.GetVertexArray()[i * 12 + 7] = num2 + num4;
				this.dec_pa.GetVertexArray()[i * 12 + 9] = num;
				this.dec_pa.GetVertexArray()[i * 12 + 10] = num2 + num4;
			}
			this.es_flag = 2;
			return;
		}
		if (this.es_flag == 2)
		{
			this.dome_work++;
			if (this.dome_work >= 30)
			{
				this.dome_work = 0;
				this.es_flag = 3;
				for (int j = 0; j < 12; j++)
				{
					this.dec_pa.GetVertexArray()[24 + j] = 0;
				}
				return;
			}
		}
		else if (this.es_flag == 3)
		{
			this.dome_work++;
			if (this.dome_work >= 30)
			{
				this.dome_work = 0;
				this.es_flag = 4;
				for (int j = 0; j < 12; j++)
				{
					this.dec_pa.GetVertexArray()[12 + j] = 0;
				}
				return;
			}
		}
		else if (this.es_flag == 4)
		{
			this.dome_work++;
			if (this.dome_work >= 30)
			{
				this.dome_work = 0;
				this.es_flag = 0;
				for (int j = 0; j < 12; j++)
				{
					this.dec_pa.GetVertexArray()[j] = 0;
				}
			}
		}
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x00102FCD File Offset: 0x001011CD
	public virtual void DrawOpenLid(StGraphics g)
	{
		((StGraphics3D)g).SetScreenCenter(0, 0);
		((StGraphics3D)g).EnableSemiTransparent(true);
		((StGraphics3D)g).RenderPrimitives(this.ol_pa, 96, false);
		((StGraphics3D)g).Flush();
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x00102FF4 File Offset: 0x001011F4
	public virtual void OpenLidRoutine()
	{
		if (this.ol_flag == 0)
		{
			return;
		}
		this.red = true;
		if (this.ol_flag == 1)
		{
			this.ol_pa.GetVertexArray()[0] = 56;
			this.ol_pa.GetVertexArray()[1] = this.xscr.sc_drawy;
			this.ol_pa.GetVertexArray()[3] = 184;
			this.ol_pa.GetVertexArray()[4] = this.xscr.sc_drawy;
			this.ol_pa.GetVertexArray()[6] = 184;
			this.ol_pa.GetVertexArray()[7] = this.xscr.sc_drawy + 80;
			this.ol_pa.GetVertexArray()[9] = 56;
			this.ol_pa.GetVertexArray()[10] = this.xscr.sc_drawy + 80;
			return;
		}
		if (this.ol_flag == 2)
		{
			this.ol_pa.GetVertexArray()[7]--;
			this.ol_pa.GetVertexArray()[10]--;
			if (this.ol_pa.GetVertexArray()[7] == this.xscr.sc_drawy)
			{
				this.ol_flag = 0;
				for (int i = 0; i < 12; i++)
				{
					this.ol_pa.GetVertexArray()[i] = 0;
				}
			}
		}
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x0010313C File Offset: 0x0010133C
	public virtual void DrawLuminescence(StGraphics g)
	{
		((StGraphics3D)g).SetScreenCenter(0, 0);
		((StGraphics3D)g).SetPrimitiveTextureArray(this.mimg);
		((StGraphics3D)g).SetPrimitiveTexture(0);
		((StGraphics3D)g).EnableSemiTransparent(true);
		((StGraphics3D)g).RenderPrimitives(this.Lum_pa1, 64, false);
		if (this.Lum_flag == 2 || this.Lum_flag == 3)
		{
			this.Lum_pa2.GetColorArray()[0] = (this.Lum_col_work << 16) | (this.Lum_col_work << 8) | this.Lum_col_work;
		}
		((StGraphics3D)g).Flush();
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x001031B8 File Offset: 0x001013B8
	public virtual void LuminescenceRoutine()
	{
		if (this.Lum_flag == 0)
		{
			return;
		}
		int num = this.xscr.obj_xy[this.Lum_no][0] - this.mapx + 24;
		int num2 = this.xscr.obj_xy[this.Lum_no][1] - this.mapy + 32;
		this.Lum_pa1.GetVertexArray()[0] = num - 8;
		this.Lum_pa1.GetVertexArray()[1] = num2 - 8;
		this.Lum_pa1.GetVertexArray()[3] = num + 8;
		this.Lum_pa1.GetVertexArray()[4] = num2 - 8;
		this.Lum_pa1.GetVertexArray()[6] = num + 8;
		this.Lum_pa1.GetVertexArray()[7] = num2 + 8;
		this.Lum_pa1.GetVertexArray()[9] = num - 8;
		this.Lum_pa1.GetVertexArray()[10] = num2 + 8;
		if (this.Lum_flag >= 1 && this.Lum_flag <= 3)
		{
			this.red = true;
			this.compred = true;
			this.Lum_pa1.GetVertexArray()[0] -= this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[1] -= this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[3] += this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[4] -= this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[6] += this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[7] += this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[9] -= this.Lum_work2;
			this.Lum_pa1.GetVertexArray()[10] += this.Lum_work2;
			this.Lum_work++;
			if (this.Lum_work <= 24)
			{
				this.Lum_work2++;
				if (this.Lum_flag == 2)
				{
					this.Lum_col_work += 3;
				}
				else if (this.Lum_flag == 3)
				{
					this.Lum_col_work += 6;
				}
			}
			else
			{
				this.Lum_work2--;
				if (this.Lum_flag == 2)
				{
					this.Lum_col_work -= 3;
				}
				else if (this.Lum_flag == 3)
				{
					this.Lum_col_work -= 6;
				}
			}
			if (this.Lum_work >= 32)
			{
				this.Lum_work = 16;
				this.Lum_col_work = 24;
				if (this.Lum_flag == 3)
				{
					this.Lum_col_work = 48;
					return;
				}
			}
		}
		else if (this.Lum_flag == 4)
		{
			this.Lum_no = 0;
			this.Lum_work = 0;
			this.Lum_work2 = 0;
			this.Lum_flag = 0;
			for (int i = 0; i < 12; i++)
			{
				this.Lum_pa1.GetVertexArray()[i] = 0;
			}
			this.Lum_col_work = 0;
		}
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x00103498 File Offset: 0x00101698
	public virtual int CheckUser()
	{
		int num = 1;
		int num2 = (int)(SingletonBehaviour<SocotraRuntime>.Instance.CurrentTimeMillis() / 1000L);
		int num3 = this.LoadIntSP(0);
		int num4 = this.LoadIntSP(4);
		int num5 = this.LoadIntSP(8);
		int num6 = this.LoadIntSP(12);
		if (num3 > 0)
		{
			if (num5 < this.parent.auth_cmax && num3 < num2 && num2 - num4 < this.parent.auth_tmax)
			{
				num5++;
			}
			else
			{
				num = this.HttpAuth();
				if (num == -1)
				{
					if (num6 > 3)
					{
						return num;
					}
					num6++;
					num5 = this.parent.auth_cmax;
					num = 1;
				}
				else if (num == 0)
				{
					num5 = this.parent.auth_cmax;
				}
				else if (num > 0)
				{
					num5 = 0;
					num6 = 0;
					num4 = num2;
				}
			}
		}
		else
		{
			num5 = 0;
			num6 = 0;
			num4 = num2;
		}
		num3 = num2;
		this.SaveIntSP(num3, 0);
		this.SaveIntSP(num4, 4);
		this.SaveIntSP(num5, 8);
		this.SaveIntSP(num6, 12);
		return num;
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x00103584 File Offset: 0x00101784
	private bool SaveIntSP(int val, int offset)
	{
		try
		{
			DataOutputStream dataOutputStream = Connector.OpenDataOutputStream("scratchpad:///14;pos=" + offset.ToString());
			dataOutputStream.WriteInt(val);
			dataOutputStream.Close();
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	// Token: 0x06000CAA RID: 3242 RVA: 0x001035D0 File Offset: 0x001017D0
	private int LoadIntSP(int offset)
	{
		int num;
		try
		{
			DataInputStream dataInputStream = Connector.OpenDataInputStream("scratchpad:///14;pos=" + offset.ToString());
			num = dataInputStream.ReadInt();
			dataInputStream.Close();
		}
		catch (Exception)
		{
			return 0;
		}
		return num;
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x0010361C File Offset: 0x0010181C
	public virtual int HttpAuth()
	{
		int num = 1;
		int num2 = 0;
		try
		{
			HttpConnection httpConnection = Connector.Open(this.parent.downloadurl + this.parent.auth_url, Connector.READ, true);
			httpConnection.SetRequestMethod(HttpConnection.GET);
			httpConnection.Connect();
			InputStream inputStream = httpConnection.OpenInputStream();
			if (inputStream != null)
			{
				num2 = inputStream.Read();
				inputStream.Close();
			}
			httpConnection.Close();
			if (num2 == 85)
			{
				num = 2;
			}
			else if (num2 == 78)
			{
				num = 0;
			}
		}
		catch (Exception)
		{
			num = -1;
		}
		return num;
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x001036A8 File Offset: 0x001018A8
	private void DrawUserCheck(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.SetColor(g, 16777215);
		if (XenoPP06Canvas.auth_ret == 100 || XenoPP06Canvas.auth_ret == 1)
		{
			this.DrawString(g, "起動中", 12, 72, 0);
			return;
		}
		string[][] array = new string[][]
		{
			new string[] { "通信に失敗しました。", "現在通信できない状況にあるか", "通信が許可されていません。", "ご確認下さい。" },
			new string[]
			{
				"ユーザー登録に誤りがあるか",
				"登録がされていません。",
				"ご確認下さい。",
				string.Empty
			},
			new string[]
			{
				"登録情報が確認されました。",
				string.Empty,
				string.Empty,
				string.Empty
			},
			new string[]
			{
				"登録情報が確認されました。",
				"アプリをバージョンアップをします。",
				"決定キーを押して下さい。",
				string.Empty
			}
		};
		for (int i = 0; i < 4; i++)
		{
			this.DrawString(g, array[XenoPP06Canvas.auth_ret + 1][i], 12, 90 + i * 15, 0);
		}
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x001037D4 File Offset: 0x001019D4
	private void AutoUpData()
	{
		StApplication.GetCurrentApp().Launch(2, null);
	}

	// Token: 0x06000CAE RID: 3246 RVA: 0x001037E2 File Offset: 0x001019E2
	private void GameEnd()
	{
		StApplication.GetCurrentApp().Terminate();
	}

	// Token: 0x040006C0 RID: 1728
	protected internal static int auth_ret = 100;

	// Token: 0x040006C1 RID: 1729
	protected internal XenoPP06Canvas self;

	// Token: 0x040006C2 RID: 1730
	public XenoPP06 parent;

	// Token: 0x040006C3 RID: 1731
	protected internal XScript06 xscr;

	// Token: 0x040006C4 RID: 1732
	protected internal bool saflag;

	// Token: 0x040006C5 RID: 1733
	protected internal int inputedg;

	// Token: 0x040006C6 RID: 1734
	protected internal int inputsep;

	// Token: 0x040006C7 RID: 1735
	private int id_back;

	// Token: 0x040006C8 RID: 1736
	protected internal int id_data;

	// Token: 0x040006C9 RID: 1737
	public int id_edge;

	// Token: 0x040006CA RID: 1738
	protected internal int id_sepr;

	// Token: 0x040006CB RID: 1739
	public int id_rept;

	// Token: 0x040006CC RID: 1740
	private int id_count;

	// Token: 0x040006CD RID: 1741
	private int id_rwait;

	// Token: 0x040006CE RID: 1742
	protected internal int id_rmask = -1;

	// Token: 0x040006CF RID: 1743
	protected internal int id_delay = 6;

	// Token: 0x040006D0 RID: 1744
	protected internal int id_speed;

	// Token: 0x040006D1 RID: 1745
	public bool red;

	// Token: 0x040006D2 RID: 1746
	protected internal bool sysred;

	// Token: 0x040006D3 RID: 1747
	public bool compred;

	// Token: 0x040006D4 RID: 1748
	public bool scrcompred;

	// Token: 0x040006D5 RID: 1749
	public bool isloading;

	// Token: 0x040006D6 RID: 1750
	public bool isupdate;

	// Token: 0x040006D7 RID: 1751
	protected internal bool msg_isactive;

	// Token: 0x040006D8 RID: 1752
	protected internal bool msg_isfinish;

	// Token: 0x040006D9 RID: 1753
	protected internal Random rand;

	// Token: 0x040006DA RID: 1754
	protected internal StFont sfont;

	// Token: 0x040006DB RID: 1755
	protected internal StFont lfont;

	// Token: 0x040006DC RID: 1756
	protected internal int lfHeight;

	// Token: 0x040006DD RID: 1757
	protected internal int nowfont;

	// Token: 0x040006DE RID: 1758
	public int scrfont;

	// Token: 0x040006DF RID: 1759
	protected internal int sync;

	// Token: 0x040006E0 RID: 1760
	public int quf;

	// Token: 0x040006E1 RID: 1761
	public int qux;

	// Token: 0x040006E2 RID: 1762
	public int quy;

	// Token: 0x040006E3 RID: 1763
	protected internal int[] fade;

	// Token: 0x040006E4 RID: 1764
	public int lasf;

	// Token: 0x040006E5 RID: 1765
	public int lasw;

	// Token: 0x040006E6 RID: 1766
	private int[] config;

	// Token: 0x040006E7 RID: 1767
	private int fps;

	// Token: 0x040006E8 RID: 1768
	private int fps_cnt;

	// Token: 0x040006E9 RID: 1769
	private long fps_ot;

	// Token: 0x040006EA RID: 1770
	private long fps_nt;

	// Token: 0x040006EB RID: 1771
	private bool fps_disp;

	// Token: 0x040006EC RID: 1772
	private int fps_wait = 30;

	// Token: 0x040006ED RID: 1773
	public int mapno;

	// Token: 0x040006EE RID: 1774
	private Image[] sysimg;

	// Token: 0x040006EF RID: 1775
	private int[] vib;

	// Token: 0x040006F0 RID: 1776
	private Image bfadeimg;

	// Token: 0x040006F1 RID: 1777
	private StGraphics bfadeg;

	// Token: 0x040006F2 RID: 1778
	private sbyte[] readbuf;

	// Token: 0x040006F3 RID: 1779
	private int plasf;

	// Token: 0x040006F4 RID: 1780
	private int plasw;

	// Token: 0x040006F5 RID: 1781
	private int[] plasxy;

	// Token: 0x040006F6 RID: 1782
	public int[] ranks;

	// Token: 0x040006F7 RID: 1783
	public int[] branks;

	// Token: 0x040006F8 RID: 1784
	public int[][] ranks2;

	// Token: 0x040006F9 RID: 1785
	public int apr_no;

	// Token: 0x040006FA RID: 1786
	private int sdflag;

	// Token: 0x040006FB RID: 1787
	private int opflag;

	// Token: 0x040006FC RID: 1788
	private int cdflag;

	// Token: 0x040006FD RID: 1789
	private int nowmenuno = -1;

	// Token: 0x040006FE RID: 1790
	private bool skflag;

	// Token: 0x040006FF RID: 1791
	private long nowtime;

	// Token: 0x04000700 RID: 1792
	private long oldtime;

	// Token: 0x04000701 RID: 1793
	private StGraphics3D g3d;

	// Token: 0x04000702 RID: 1794
	private string menucmd1 = string.Empty;

	// Token: 0x04000703 RID: 1795
	private string menucmd2 = string.Empty;

	// Token: 0x04000704 RID: 1796
	private int rev_mapno = 65535;

	// Token: 0x04000705 RID: 1797
	private int rev_mapx = 65535;

	// Token: 0x04000706 RID: 1798
	private int rev_mapy = 65535;

	// Token: 0x04000707 RID: 1799
	private int rev_chx = 65535;

	// Token: 0x04000708 RID: 1800
	private int rev_chy = 65535;

	// Token: 0x04000709 RID: 1801
	private ByteArrayOutputStream dfbaos;

	// Token: 0x0400070A RID: 1802
	private Image[] faceimg;

	// Token: 0x0400070B RID: 1803
	public int[] slxy;

	// Token: 0x0400070C RID: 1804
	public int[] slwk;

	// Token: 0x0400070D RID: 1805
	public int slf;

	// Token: 0x0400070E RID: 1806
	public int[] dwh;

	// Token: 0x0400070F RID: 1807
	public int[][] dwk;

	// Token: 0x04000710 RID: 1808
	public int dflag;

	// Token: 0x04000711 RID: 1809
	public int pfflag;

	// Token: 0x04000712 RID: 1810
	private Image[] vimg;

	// Token: 0x04000713 RID: 1811
	private int nowvno;

	// Token: 0x04000714 RID: 1812
	public int visualno;

	// Token: 0x04000715 RID: 1813
	public int vpno;

	// Token: 0x04000716 RID: 1814
	public bool window_flg;

	// Token: 0x04000717 RID: 1815
	public int window_cnt;

	// Token: 0x04000718 RID: 1816
	protected internal int seq_no;

	// Token: 0x04000719 RID: 1817
	protected internal int seq_no_b;

	// Token: 0x0400071A RID: 1818
	protected internal int seq_step;

	// Token: 0x0400071B RID: 1819
	protected internal int seq_step_b;

	// Token: 0x0400071C RID: 1820
	protected internal bool[] ismenu;

	// Token: 0x0400071D RID: 1821
	public int[][] status;

	// Token: 0x0400071E RID: 1822
	private int[][] estatus;

	// Token: 0x0400071F RID: 1823
	private int[][] st_ab;

	// Token: 0x04000720 RID: 1824
	private int[][] est_ab;

	// Token: 0x04000721 RID: 1825
	private Image[] bimg;

	// Token: 0x04000722 RID: 1826
	private Image bbgimg;

	// Token: 0x04000723 RID: 1827
	private int[] gtw;

	// Token: 0x04000724 RID: 1828
	private int gtwp;

	// Token: 0x04000725 RID: 1829
	private int[] bslot;

	// Token: 0x04000726 RID: 1830
	private int bslotno;

	// Token: 0x04000727 RID: 1831
	private int bslotmove;

	// Token: 0x04000728 RID: 1832
	private int ep;

	// Token: 0x04000729 RID: 1833
	public int[] cur;

	// Token: 0x0400072A RID: 1834
	private int[] work;

	// Token: 0x0400072B RID: 1835
	private bool[] isboost;

	// Token: 0x0400072C RID: 1836
	private bool iscboost;

	// Token: 0x0400072D RID: 1837
	private int boostno;

	// Token: 0x0400072E RID: 1838
	private int eneatk;

	// Token: 0x0400072F RID: 1839
	private int[] atkst;

	// Token: 0x04000730 RID: 1840
	private int crtl;

	// Token: 0x04000731 RID: 1841
	private string[] bmstr;

	// Token: 0x04000732 RID: 1842
	private int[][] bmenu;

	// Token: 0x04000733 RID: 1843
	private int blast;

	// Token: 0x04000734 RID: 1844
	private int bnum;

	// Token: 0x04000735 RID: 1845
	private int bmenup;

	// Token: 0x04000736 RID: 1846
	private Image[] eneimg;

	// Token: 0x04000737 RID: 1847
	private bool[] bred;

	// Token: 0x04000738 RID: 1848
	private bool[] bredn;

	// Token: 0x04000739 RID: 1849
	public int battleno;

	// Token: 0x0400073A RID: 1850
	private int[][] dropitem;

	// Token: 0x0400073B RID: 1851
	private int dropitemp;

	// Token: 0x0400073C RID: 1852
	private int[] nextmenu;

	// Token: 0x0400073D RID: 1853
	private int nextmenup;

	// Token: 0x0400073E RID: 1854
	private int nowmenu;

	// Token: 0x0400073F RID: 1855
	private int nmwait;

	// Token: 0x04000740 RID: 1856
	private int attackef;

	// Token: 0x04000741 RID: 1857
	private int getexp;

	// Token: 0x04000742 RID: 1858
	private int bsmenu;

	// Token: 0x04000743 RID: 1859
	private int[][] itempc;

	// Token: 0x04000744 RID: 1860
	protected internal sbyte[] mapdat;

	// Token: 0x04000745 RID: 1861
	protected internal sbyte[] atrdat;

	// Token: 0x04000746 RID: 1862
	private StTexture mimg;

	// Token: 0x04000747 RID: 1863
	private int mip;

	// Token: 0x04000748 RID: 1864
	private int befmino;

	// Token: 0x04000749 RID: 1865
	private int befmo = -1;

	// Token: 0x0400074A RID: 1866
	private int mapw;

	// Token: 0x0400074B RID: 1867
	private int maph;

	// Token: 0x0400074C RID: 1868
	public int mapx;

	// Token: 0x0400074D RID: 1869
	public int mapy;

	// Token: 0x0400074E RID: 1870
	public int chx;

	// Token: 0x0400074F RID: 1871
	public int chy;

	// Token: 0x04000750 RID: 1872
	public int chm;

	// Token: 0x04000751 RID: 1873
	private int chw;

	// Token: 0x04000752 RID: 1874
	public int chc;

	// Token: 0x04000753 RID: 1875
	private int encount;

	// Token: 0x04000754 RID: 1876
	private Image[] mcimg;

	// Token: 0x04000755 RID: 1877
	private int mcimgmax = -1;

	// Token: 0x04000756 RID: 1878
	private bool eneapr;

	// Token: 0x04000757 RID: 1879
	private bool etheruse = true;

	// Token: 0x04000758 RID: 1880
	private int trap;

	// Token: 0x04000759 RID: 1881
	private int trapdmg;

	// Token: 0x0400075A RID: 1882
	private int trapdmgwait;

	// Token: 0x0400075B RID: 1883
	private int mrwait;

	// Token: 0x0400075C RID: 1884
	private bool debug_enc = true;

	// Token: 0x0400075D RID: 1885
	private string debugstr = string.Empty;

	// Token: 0x0400075E RID: 1886
	private string[] mmstr;

	// Token: 0x0400075F RID: 1887
	private int[] mmenu;

	// Token: 0x04000760 RID: 1888
	private int mmenup;

	// Token: 0x04000761 RID: 1889
	private bool mmenuflag;

	// Token: 0x04000762 RID: 1890
	private Image[] titleimg;

	// Token: 0x04000763 RID: 1891
	private int[][] starxy;

	// Token: 0x04000764 RID: 1892
	private Image logoimg;

	// Token: 0x04000765 RID: 1893
	protected internal AudioPresenter audio_b;

	// Token: 0x04000766 RID: 1894
	protected internal AudioPresenter audio_s;

	// Token: 0x04000767 RID: 1895
	protected internal MediaSound[] bgm;

	// Token: 0x04000768 RID: 1896
	protected internal MediaSound[] se;

	// Token: 0x04000769 RID: 1897
	protected internal int Loop_se;

	// Token: 0x0400076A RID: 1898
	protected internal int nowbgm = -1;

	// Token: 0x0400076B RID: 1899
	protected internal int playbgm = -1;

	// Token: 0x0400076C RID: 1900
	protected internal int sndvol = 127;

	// Token: 0x0400076D RID: 1901
	protected internal int playse = -1;

	// Token: 0x0400076E RID: 1902
	private bool se_loop_flag;

	// Token: 0x0400076F RID: 1903
	internal PrimitiveArray fade_pa;

	// Token: 0x04000770 RID: 1904
	public int battle_fade;

	// Token: 0x04000771 RID: 1905
	internal PrimitiveArray map_pa;

	// Token: 0x04000772 RID: 1906
	private bool decieveFlag;

	// Token: 0x04000773 RID: 1907
	internal PrimitiveArray dec_pa;

	// Token: 0x04000774 RID: 1908
	private int[] dec_nor_work;

	// Token: 0x04000775 RID: 1909
	private int[] dec_col;

	// Token: 0x04000776 RID: 1910
	private int[] dec_flg;

	// Token: 0x04000777 RID: 1911
	private int[] dec_y;

	// Token: 0x04000778 RID: 1912
	internal PrimitiveArray dome_pa;

	// Token: 0x04000779 RID: 1913
	public int dome_flag;

	// Token: 0x0400077A RID: 1914
	private int dome_work;

	// Token: 0x0400077B RID: 1915
	public int es_flag;

	// Token: 0x0400077C RID: 1916
	public int ol_flag;

	// Token: 0x0400077D RID: 1917
	internal PrimitiveArray ol_pa;

	// Token: 0x0400077E RID: 1918
	internal PrimitiveArray Lum_pa1;

	// Token: 0x0400077F RID: 1919
	internal PrimitiveArray Lum_pa2;

	// Token: 0x04000780 RID: 1920
	public int Lum_flag;

	// Token: 0x04000781 RID: 1921
	public int Lum_no;

	// Token: 0x04000782 RID: 1922
	private int Lum_work;

	// Token: 0x04000783 RID: 1923
	private int Lum_work2;

	// Token: 0x04000784 RID: 1924
	private int Lum_col_work;

	// Token: 0x04000785 RID: 1925
	private string[] StaffRollTxt = new string[]
	{
		"[XPP Project]",
		string.Empty,
		"ディレクター",
		"Gouda Tsutomu",
		string.Empty,
		"企画",
		"Gouda Tsutomu",
		string.Empty,
		"脚本/監修",
		"-MONOLITH SOFTWARE INC-",
		"Takahashi Tetsuya",
		"Hayashi Koji",
		"Hagiwara Tomohiro",
		"Nagata Yoko",
		string.Empty,
		"企画/グラフィック",
		"-TOM CREATE-",
		"Ikeda Masaru",
		"Kitamura Satoshi",
		"Ohwaki Yuji",
		"Saito Motoi",
		"Sato Kouichi",
		"Ohyama Shuhei",
		"Takahashi Aki",
		"Shibuki Ayako",
		string.Empty,
		"プログラム/グラフィック",
		"-io-spiral-",
		"Takeuchi Jun",
		"Morisawa Kazunori",
		"Iwasaki Seiichiro",
		"Kawamura Yuhei",
		"Mizukami Keita",
		"Song Kenichi",
		"Goto Taiki",
		"Hiramine Tsutomu",
		"Ito Chikanobu",
		"Maki Sayaka",
		"Nam Soo-youn",
		string.Empty,
		"サウンド",
		"-TWO FIVE-",
		"Ushiyama Tomokazu",
		"Muraki Kousei",
		string.Empty,
		"キャラクターデザイン",
		"-ASTROVISION-",
		"Minohara Noboru",
		"Nishiwaki Yu-ri",
		string.Empty,
		"制作管理",
		"Gouda Tsutomu",
		"Fukushima Naoko",
		string.Empty,
		"広報",
		"Oomori Tomoyuki",
		"Shigihara Morihiro",
		string.Empty,
		"ユーザーサポート",
		"Ono Yukito",
		string.Empty,
		"サーバー開発",
		"-Index Corporation-",
		"Nihei Hiromitsu",
		string.Empty,
		"AND",
		"ALL AUDIENCE",
		string.Empty,
		"PRODUCED BY NBGI",
		string.Empty,
		"(C)2001 2006 NBGI LTD."
	};

	// Token: 0x04000786 RID: 1926
	private int helpno;

	// Token: 0x04000787 RID: 1927
	private int[] bhelpno;

	// Token: 0x04000788 RID: 1928
	private int[][] bhelpcur;

	// Token: 0x04000789 RID: 1929
	private int bhelp;

	// Token: 0x0400078A RID: 1930
	private int bhelpseq;

	// Token: 0x0400078B RID: 1931
	private int[] mofile = new int[] { 27, 28, 29, 30 };

	// Token: 0x0400078C RID: 1932
	private int[] mofmax = new int[] { 75, 119, 70, 98 };

	// Token: 0x0400078D RID: 1933
	private int[] mofileno = new int[]
	{
		0, 0, 0, 0, 0, 1, 1, 2, 2, 2,
		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 2, 3, 3
	};

	// Token: 0x0400078E RID: 1934
	private int[] mdfile = new int[]
	{
		58, 59, 61, 60, 62, 7, 8, 40, 41, 42,
		43, 44, 45, 46, 47, 48, 49, 50, 51, 52,
		53, 54, 55, 56, 57, 65, 37
	};

	// Token: 0x0400078F RID: 1935
	private bool[][] miflag = new bool[][]
	{
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[]
		{
			default(bool),
			true
		},
		new bool[] { true, true },
		new bool[] { true, true }
	};

	// Token: 0x04000790 RID: 1936
	private int[] vfile = new int[]
	{
		6, 64, 33, 17, 34, 63, 20, 21, 22, 32,
		31, 38, 39, 23, 24, 12, 13, 14, 15, 16
	};

	// Token: 0x04000791 RID: 1937
	private int[] vtbl = new int[]
	{
		0, 1, 0, 2, 0, 1, 0, 1, 1, 1,
		0, 1, 1, 1, 1, 4, 4, 1, 1, 2
	};

	// Token: 0x04000792 RID: 1938
	private int[][] downfilechk = new int[][]
	{
		new int[] { 66394, 23950 },
		new int[] { 25518, 23164 },
		new int[] { 8899, 8992 },
		new int[] { 10071, 10021 },
		new int[] { 12223, 12260 },
		new int[] { 9241, 9226 },
		new int[] { 157, 284 },
		new int[] { 2151, 1304 },
		new int[] { 7252, 4275 },
		new int[] { 1711, 1812 },
		new int[] { 8313, 8269 },
		new int[] { 5284, 5347 },
		new int[] { 15213, 13186 },
		new int[] { 11628, 10947 },
		new int[] { 9392, 9475 },
		new int[] { 18558, 18380 },
		new int[] { 1499, 1368 },
		new int[] { 14428, 13846 },
		new int[] { 19851, 18241 },
		new int[] { 12872, 6468 },
		new int[] { 1234, 919 },
		new int[] { 11611, 11513 },
		new int[] { 10940, 10875 },
		new int[] { 8302, 8326 },
		new int[] { 9261, 9293 },
		new int[] { 230, 373 },
		new int[] { 15842, 9505 },
		new int[] { 2808, 2131 },
		new int[] { 18268, 14628 },
		new int[] { 5350, 5186 },
		new int[] { 8637, 6696 },
		new int[] { 504, 531 },
		new int[] { 11479, 11329 },
		new int[] { 123, 238 },
		new int[] { 85, 231 },
		new int[] { 11292, 5636 },
		new int[] { 9497, 9431 },
		new int[] { 950, 642 },
		new int[] { 10282, 9608 },
		new int[] { 8163, 8316 },
		new int[] { 4413, 2368 },
		new int[] { 3753, 1498 },
		new int[] { 3979, 2311 },
		new int[] { 508, 434 },
		new int[] { 1357, 1046 },
		new int[] { 555, 434 },
		new int[] { 443, 383 },
		new int[] { 555, 435 },
		new int[] { 443, 382 },
		new int[] { 555, 435 },
		new int[] { 443, 382 },
		new int[] { 555, 436 },
		new int[] { 443, 384 },
		new int[] { 580, 447 },
		new int[] { 443, 384 },
		new int[] { 557, 436 },
		new int[] { 443, 385 },
		new int[] { 967, 799 },
		new int[] { 2756, 1888 },
		new int[] { 4043, 1309 },
		new int[] { 3823, 1118 },
		new int[] { 5481, 3264 },
		new int[] { 5602, 3292 },
		new int[] { 9430, 9458 },
		new int[] { 8506, 8503 },
		new int[] { 9711, 5518 },
		new int[] { 1157, 697 },
		new int[] { 1813, 722 },
		new int[] { 2353, 978 },
		new int[] { 4341, 1330 },
		new int[] { 3953, 1059 },
		new int[] { 705, 572 },
		new int[] { 1525, 920 },
		new int[] { 1653, 850 },
		new int[] { 613, 500 },
		new int[] { 1841, 763 },
		new int[] { 1121, 546 },
		new int[] { 813, 622 },
		new int[] { 2593, 695 },
		new int[] { 1629, 877 },
		new int[] { 4816, 2226 }
	};

	// Token: 0x04000793 RID: 1939
	private int[][] se_wav_downfilechk = new int[][]
	{
		new int[] { 13942, 13240 },
		new int[] { 14046, 12834 },
		new int[] { 13942, 13196 },
		new int[] { 14290, 12987 }
	};

	// Token: 0x04000794 RID: 1940
	private string[][] dfilename = new string[][]
	{
		new string[] { "map", ".tex" },
		new string[] { "battle", ".dat" },
		new string[] { "bbg1", ".dat" },
		new string[] { "bbg2", ".dat" },
		new string[] { "bbg3", ".dat" },
		new string[] { "bbg4", ".dat" },
		new string[] { "cathedral", ".dat" },
		new string[] { "cathedral_crystal", ".dat" },
		new string[] { "cathedral_main", ".dat" },
		new string[] { "enemy1", ".dat" },
		new string[] { "enemy2", ".dat" },
		new string[] { "enemy3", ".dat" },
		new string[] { "epilogue1_01", ".dat" },
		new string[] { "epilogue1_02", ".dat" },
		new string[] { "epilogue2_01", ".dat" },
		new string[] { "epilogue2_02", ".dat" },
		new string[] { "epilogue2_03", ".dat" },
		new string[] { "eri_house", ".dat" },
		new string[] { "face", ".dat" },
		new string[] { "help0", ".xhf" },
		new string[] { "hiding_place01", ".dat" },
		new string[] { "hiding_place02", ".dat" },
		new string[] { "hiding_place03", ".dat" },
		new string[] { "jan_kill01", ".dat" },
		new string[] { "jan_kill02", ".dat" },
		new string[] { "logo", ".dat" },
		new string[] { "map0", ".dat" },
		new string[] { "map1", ".dat" },
		new string[] { "map2", ".dat" },
		new string[] { "map3", ".dat" },
		new string[] { "map4", ".dat" },
		new string[] { "on_zohalu", ".dat" },
		new string[] { "oneside_time", ".dat" },
		new string[] { "pp06_start", ".dat" },
		new string[] { "sha_scene", ".dat" },
		new string[] { "system", ".dat" },
		new string[] { "title", ".dat" },
		new string[] { "udu_consciousness_room", ".dat" },
		new string[] { "udu_disappears01", ".dat" },
		new string[] { "udu_disappears02", ".dat" },
		new string[] { "udu_main_a", ".dat" },
		new string[] { "udu_main_b", ".dat" },
		new string[] { "udu_main_c", ".dat" },
		new string[] { "udu_main_d_b01f", ".dat" },
		new string[] { "udu_main_d_b02f", ".dat" },
		new string[] { "udu_main_d_b03f", ".dat" },
		new string[] { "udu_main_d_b04f", ".dat" },
		new string[] { "udu_main_d_b05f", ".dat" },
		new string[] { "udu_main_d_b06f", ".dat" },
		new string[] { "udu_main_d_b07f", ".dat" },
		new string[] { "udu_main_d_b08f", ".dat" },
		new string[] { "udu_main_d_b09f", ".dat" },
		new string[] { "udu_main_d_b10f", ".dat" },
		new string[] { "udu_main_d_b11f", ".dat" },
		new string[] { "udu_main_d_b12f", ".dat" },
		new string[] { "udu_main_d_b13f", ".dat" },
		new string[] { "udu_main_d_b14f", ".dat" },
		new string[] { "udu_main_d_b15f", ".dat" },
		new string[] { "voyager_entrance", ".dat" },
		new string[] { "voyager_main_a", ".dat" },
		new string[] { "voyager_main_b", ".dat" },
		new string[] { "voyager_point_a", ".dat" },
		new string[] { "voyager_point_b", ".dat" },
		new string[] { "white_robe", ".dat" },
		new string[] { "zohalu", ".dat" },
		new string[] { "zohalu_main", ".dat" },
		new string[] { "bgm01", ".dat" },
		new string[] { "bgm02", ".dat" },
		new string[] { "bgm03", ".dat" },
		new string[] { "bgm04", ".dat" },
		new string[] { "bgm05", ".dat" },
		new string[] { "bgm06", ".dat" },
		new string[] { "bgm07", ".dat" },
		new string[] { "bgm08", ".dat" },
		new string[] { "bgm09", ".dat" },
		new string[] { "bgm10", ".dat" },
		new string[] { "bgm11", ".dat" },
		new string[] { "bgm12", ".dat" },
		new string[] { "bgm13", ".dat" },
		new string[] { "bgm14", ".dat" },
		new string[] { "se", ".dat" }
	};

	// Token: 0x04000795 RID: 1941
	private string[] PlyName = new string[] { "ジャン", "メリス", "ラクティス", "バグス" };

	// Token: 0x04000796 RID: 1942
	private readonly int[][][] PlyParam = new int[][][]
	{
		new int[][]
		{
			new int[] { 3, 127, 5, 6, 3, 3, 2, 2, 1, 7 },
			new int[] { 3, 145, 5, 7, 4, 4, 3, 3, 2, 7 },
			new int[] { 3, 172, 6, 9, 5, 5, 4, 3, 2, 7 },
			new int[] { 3, 191, 6, 10, 6, 6, 4, 4, 3, 7 },
			new int[] { 3, 201, 7, 11, 6, 6, 5, 5, 4, 7 },
			new int[] { 3, 219, 8, 12, 7, 7, 6, 6, 4, 7 },
			new int[] { 3, 237, 8, 13, 8, 8, 7, 6, 5, 7 },
			new int[] { 3, 264, 9, 15, 9, 9, 7, 7, 6, 7 },
			new int[] { 3, 283, 9, 16, 10, 9, 8, 8, 6, 7 },
			new int[] { 3, 301, 10, 17, 11, 10, 9, 8, 7, 7 },
			new int[] { 3, 311, 11, 18, 11, 11, 10, 9, 8, 7 },
			new int[] { 3, 329, 11, 19, 12, 12, 10, 10, 8, 7 },
			new int[] { 3, 348, 12, 20, 13, 12, 11, 11, 9, 7 },
			new int[] { 3, 375, 12, 22, 14, 13, 12, 11, 10, 7 },
			new int[] { 3, 393, 13, 23, 15, 14, 13, 12, 10, 7 },
			new int[] { 3, 412, 14, 24, 16, 15, 13, 13, 11, 7 },
			new int[] { 3, 421, 14, 25, 16, 15, 14, 13, 12, 7 },
			new int[] { 3, 440, 15, 26, 17, 16, 15, 14, 12, 7 },
			new int[] { 3, 458, 15, 27, 18, 17, 16, 15, 13, 7 },
			new int[] { 3, 485, 16, 29, 19, 18, 16, 16, 14, 7 },
			new int[] { 3, 504, 17, 30, 20, 18, 17, 16, 14, 7 },
			new int[] { 3, 522, 17, 31, 21, 19, 18, 17, 15, 7 },
			new int[] { 3, 532, 18, 32, 21, 20, 19, 18, 16, 7 },
			new int[] { 3, 550, 19, 33, 22, 21, 19, 18, 16, 7 },
			new int[] { 3, 569, 19, 34, 23, 21, 20, 19, 17, 7 },
			new int[] { 3, 596, 20, 36, 24, 22, 21, 20, 18, 7 },
			new int[] { 3, 614, 20, 37, 25, 23, 22, 21, 18, 7 },
			new int[] { 3, 632, 21, 38, 26, 24, 22, 21, 19, 7 },
			new int[] { 3, 651, 22, 39, 27, 24, 23, 22, 20, 7 },
			new int[] { 3, 661, 22, 40, 27, 25, 24, 23, 20, 7 },
			new int[] { 3, 679, 23, 41, 28, 26, 25, 24, 21, 7 },
			new int[] { 3, 706, 23, 43, 29, 27, 25, 24, 22, 7 },
			new int[] { 3, 724, 24, 44, 30, 27, 26, 25, 22, 7 },
			new int[] { 3, 743, 25, 45, 31, 28, 27, 26, 23, 7 },
			new int[] { 3, 761, 25, 46, 32, 29, 28, 26, 24, 7 },
			new int[] { 3, 771, 26, 47, 32, 30, 28, 27, 24, 7 },
			new int[] { 3, 789, 26, 48, 33, 30, 29, 28, 25, 7 },
			new int[] { 3, 816, 27, 50, 34, 31, 30, 29, 26, 7 },
			new int[] { 3, 835, 28, 51, 35, 32, 31, 29, 26, 7 },
			new int[] { 3, 853, 28, 52, 36, 33, 31, 30, 27, 7 },
			new int[] { 3, 872, 29, 53, 37, 33, 32, 31, 28, 7 },
			new int[] { 3, 881, 29, 54, 37, 34, 33, 31, 28, 7 },
			new int[] { 3, 900, 30, 55, 38, 35, 34, 32, 29, 7 },
			new int[] { 3, 927, 31, 57, 39, 36, 34, 33, 30, 7 },
			new int[] { 3, 945, 31, 58, 40, 36, 35, 34, 30, 7 },
			new int[] { 3, 964, 32, 59, 41, 37, 36, 34, 31, 7 },
			new int[] { 3, 982, 32, 60, 42, 38, 37, 35, 32, 7 },
			new int[] { 3, 992, 33, 61, 42, 39, 37, 36, 32, 7 },
			new int[] { 3, 1010, 34, 62, 43, 39, 38, 36, 33, 7 },
			new int[] { 3, 1037, 34, 64, 44, 40, 39, 37, 33, 7 },
			new int[] { 3, 1056, 35, 65, 45, 41, 40, 38, 34, 7 },
			new int[] { 3, 1074, 36, 66, 46, 42, 40, 39, 35, 7 },
			new int[] { 3, 1092, 36, 67, 47, 42, 41, 39, 35, 7 },
			new int[] { 3, 1111, 37, 68, 48, 43, 42, 40, 36, 7 },
			new int[] { 3, 1129, 37, 70, 48, 44, 43, 41, 37, 7 },
			new int[] { 3, 1148, 38, 71, 49, 45, 43, 42, 37, 7 },
			new int[] { 3, 1166, 39, 72, 50, 45, 44, 42, 38, 7 },
			new int[] { 3, 1184, 39, 73, 51, 46, 45, 43, 39, 7 },
			new int[] { 3, 1203, 40, 74, 52, 47, 46, 44, 39, 7 },
			new int[] { 3, 1221, 40, 75, 53, 48, 46, 44, 40, 7 }
		},
		new int[][]
		{
			new int[] { 3, 102, 5, 4, 2, 3, 3, 3, 1, 10 },
			new int[] { 3, 121, 5, 5, 3, 4, 4, 4, 2, 10 },
			new int[] { 3, 140, 6, 6, 4, 5, 4, 5, 3, 10 },
			new int[] { 3, 150, 7, 7, 4, 6, 5, 6, 4, 10 },
			new int[] { 3, 169, 7, 8, 5, 7, 6, 6, 5, 10 },
			new int[] { 3, 188, 8, 9, 6, 7, 7, 7, 5, 10 },
			new int[] { 3, 206, 8, 10, 7, 8, 7, 8, 6, 10 },
			new int[] { 3, 216, 9, 11, 7, 9, 8, 9, 7, 10 },
			new int[] { 3, 235, 10, 12, 8, 10, 9, 10, 8, 10 },
			new int[] { 3, 254, 10, 13, 9, 10, 10, 11, 8, 10 },
			new int[] { 3, 273, 11, 14, 10, 11, 11, 11, 9, 10 },
			new int[] { 3, 283, 12, 15, 10, 12, 11, 12, 10, 10 },
			new int[] { 3, 302, 12, 16, 11, 13, 12, 13, 11, 10 },
			new int[] { 3, 312, 13, 16, 12, 14, 13, 14, 12, 10 },
			new int[] { 3, 330, 14, 17, 13, 14, 14, 15, 12, 10 },
			new int[] { 3, 340, 14, 18, 13, 15, 14, 16, 13, 10 },
			new int[] { 3, 359, 15, 19, 14, 16, 15, 16, 14, 10 },
			new int[] { 3, 378, 16, 20, 15, 17, 16, 17, 15, 10 },
			new int[] { 3, 397, 16, 21, 16, 17, 17, 18, 15, 10 },
			new int[] { 3, 407, 17, 22, 16, 18, 18, 19, 16, 10 },
			new int[] { 3, 426, 17, 23, 17, 19, 18, 20, 17, 10 },
			new int[] { 3, 444, 18, 24, 18, 20, 19, 21, 18, 10 },
			new int[] { 3, 463, 19, 25, 19, 21, 20, 21, 19, 10 },
			new int[] { 3, 473, 19, 26, 19, 21, 21, 22, 19, 10 },
			new int[] { 3, 492, 20, 27, 20, 22, 21, 23, 20, 10 },
			new int[] { 3, 511, 21, 28, 21, 23, 22, 24, 21, 10 },
			new int[] { 3, 530, 21, 29, 22, 24, 23, 25, 22, 10 },
			new int[] { 3, 540, 22, 30, 22, 24, 24, 26, 23, 10 },
			new int[] { 3, 558, 23, 31, 23, 25, 25, 27, 23, 10 },
			new int[] { 3, 577, 23, 32, 24, 26, 25, 27, 24, 10 },
			new int[] { 3, 596, 24, 33, 25, 27, 26, 28, 25, 10 },
			new int[] { 3, 606, 24, 34, 25, 28, 27, 29, 26, 10 },
			new int[] { 3, 625, 25, 35, 26, 28, 28, 30, 26, 10 },
			new int[] { 3, 644, 26, 36, 27, 29, 28, 31, 27, 10 },
			new int[] { 3, 662, 26, 37, 28, 30, 29, 32, 28, 10 },
			new int[] { 3, 672, 27, 38, 28, 31, 30, 32, 29, 10 },
			new int[] { 3, 691, 28, 39, 29, 31, 31, 33, 30, 10 },
			new int[] { 3, 710, 28, 40, 30, 32, 32, 34, 30, 10 },
			new int[] { 3, 729, 29, 41, 31, 33, 32, 35, 31, 10 },
			new int[] { 3, 739, 30, 42, 31, 34, 33, 36, 32, 10 },
			new int[] { 3, 758, 30, 43, 32, 35, 34, 37, 33, 10 },
			new int[] { 3, 776, 31, 44, 33, 35, 35, 37, 33, 10 },
			new int[] { 3, 795, 32, 45, 34, 36, 36, 38, 34, 10 },
			new int[] { 3, 805, 32, 46, 34, 37, 36, 39, 35, 10 },
			new int[] { 3, 824, 33, 47, 35, 38, 37, 40, 36, 10 },
			new int[] { 3, 843, 33, 48, 36, 39, 38, 41, 37, 10 },
			new int[] { 3, 862, 34, 49, 37, 39, 39, 42, 37, 10 },
			new int[] { 3, 872, 35, 50, 37, 40, 39, 42, 38, 10 },
			new int[] { 3, 890, 35, 51, 38, 41, 40, 43, 39, 10 },
			new int[] { 3, 909, 36, 52, 39, 42, 41, 44, 40, 10 },
			new int[] { 3, 928, 37, 53, 40, 42, 42, 45, 40, 10 },
			new int[] { 3, 938, 37, 54, 40, 43, 43, 46, 41, 10 },
			new int[] { 3, 957, 38, 55, 41, 44, 43, 47, 42, 10 },
			new int[] { 3, 976, 39, 56, 42, 45, 44, 48, 43, 10 },
			new int[] { 3, 994, 39, 57, 43, 46, 45, 48, 44, 10 },
			new int[] { 3, 1004, 40, 58, 43, 46, 46, 49, 44, 10 },
			new int[] { 3, 1023, 40, 59, 44, 47, 46, 50, 45, 10 },
			new int[] { 3, 1042, 41, 60, 45, 48, 47, 51, 46, 10 },
			new int[] { 3, 1061, 42, 61, 46, 49, 48, 52, 47, 10 },
			new int[] { 3, 1071, 42, 62, 46, 49, 49, 53, 47, 10 }
		},
		new int[][]
		{
			new int[] { 3, 80, 5, 3, 1, 4, 5, 3, 1, 9 },
			new int[] { 3, 97, 6, 4, 2, 5, 6, 4, 2, 9 },
			new int[] { 3, 114, 7, 5, 3, 6, 7, 4, 3, 9 },
			new int[] { 3, 130, 8, 6, 4, 7, 7, 5, 4, 9 },
			new int[] { 3, 139, 9, 7, 4, 8, 8, 6, 4, 9 },
			new int[] { 3, 156, 9, 8, 5, 9, 9, 7, 5, 9 },
			new int[] { 3, 172, 10, 9, 6, 9, 10, 7, 6, 9 },
			new int[] { 3, 189, 11, 10, 7, 10, 11, 8, 7, 9 },
			new int[] { 3, 198, 12, 11, 7, 11, 12, 9, 8, 9 },
			new int[] { 3, 222, 12, 13, 8, 12, 13, 10, 9, 9 },
			new int[] { 3, 239, 13, 14, 9, 13, 14, 11, 10, 9 },
			new int[] { 3, 255, 14, 15, 10, 14, 15, 11, 11, 9 },
			new int[] { 3, 264, 15, 16, 10, 14, 16, 12, 11, 9 },
			new int[] { 3, 281, 15, 17, 11, 15, 16, 13, 12, 9 },
			new int[] { 3, 297, 16, 18, 12, 16, 17, 14, 13, 9 },
			new int[] { 3, 314, 17, 19, 13, 17, 18, 14, 14, 9 },
			new int[] { 3, 323, 18, 20, 13, 18, 19, 15, 15, 9 },
			new int[] { 3, 339, 19, 21, 14, 19, 20, 16, 16, 9 },
			new int[] { 3, 356, 19, 22, 15, 20, 21, 17, 17, 9 },
			new int[] { 3, 373, 20, 23, 16, 20, 22, 18, 17, 9 },
			new int[] { 3, 382, 21, 24, 16, 21, 23, 18, 18, 9 },
			new int[] { 3, 398, 22, 25, 17, 22, 24, 19, 19, 9 },
			new int[] { 3, 415, 23, 26, 18, 23, 25, 20, 20, 9 },
			new int[] { 3, 431, 23, 27, 19, 24, 25, 21, 21, 9 },
			new int[] { 3, 440, 24, 28, 19, 25, 26, 21, 22, 9 },
			new int[] { 3, 457, 25, 29, 20, 25, 27, 22, 23, 9 },
			new int[] { 3, 473, 26, 30, 21, 26, 28, 23, 24, 9 },
			new int[] { 3, 490, 26, 31, 22, 27, 29, 24, 24, 9 },
			new int[] { 3, 499, 27, 32, 22, 28, 30, 25, 25, 9 },
			new int[] { 3, 516, 28, 33, 23, 29, 31, 25, 26, 9 },
			new int[] { 3, 532, 29, 34, 24, 30, 32, 26, 27, 9 },
			new int[] { 3, 549, 29, 35, 25, 30, 33, 27, 28, 9 },
			new int[] { 3, 558, 30, 36, 25, 31, 34, 28, 29, 9 },
			new int[] { 3, 574, 31, 37, 26, 32, 34, 28, 30, 9 },
			new int[] { 3, 591, 32, 38, 27, 33, 35, 29, 31, 9 },
			new int[] { 3, 607, 33, 39, 28, 34, 36, 30, 31, 9 },
			new int[] { 3, 616, 33, 40, 28, 35, 37, 31, 32, 9 },
			new int[] { 3, 633, 34, 41, 29, 35, 38, 32, 33, 9 },
			new int[] { 3, 650, 35, 42, 30, 36, 39, 32, 34, 9 },
			new int[] { 3, 666, 36, 43, 31, 37, 40, 33, 35, 9 },
			new int[] { 3, 675, 36, 44, 31, 38, 41, 34, 36, 9 },
			new int[] { 3, 692, 37, 45, 32, 39, 42, 35, 37, 9 },
			new int[] { 3, 708, 38, 46, 33, 40, 43, 36, 37, 9 },
			new int[] { 3, 725, 39, 47, 34, 41, 43, 36, 38, 9 },
			new int[] { 3, 734, 39, 48, 34, 41, 44, 37, 39, 9 },
			new int[] { 3, 750, 40, 49, 35, 42, 45, 38, 40, 9 },
			new int[] { 3, 767, 41, 50, 36, 43, 46, 39, 41, 9 },
			new int[] { 3, 784, 42, 51, 37, 44, 47, 39, 42, 9 },
			new int[] { 3, 792, 43, 52, 37, 45, 48, 40, 43, 9 },
			new int[] { 3, 809, 43, 53, 38, 46, 49, 41, 44, 9 },
			new int[] { 3, 826, 44, 54, 39, 46, 50, 42, 44, 9 },
			new int[] { 3, 842, 45, 55, 40, 47, 51, 43, 45, 9 },
			new int[] { 3, 851, 46, 56, 40, 48, 52, 43, 46, 9 },
			new int[] { 3, 868, 46, 57, 41, 49, 52, 44, 47, 9 },
			new int[] { 3, 884, 47, 58, 42, 50, 53, 45, 48, 9 },
			new int[] { 3, 901, 48, 59, 43, 51, 54, 46, 49, 9 },
			new int[] { 3, 910, 49, 60, 43, 51, 55, 46, 50, 9 },
			new int[] { 3, 926, 50, 61, 44, 52, 56, 47, 51, 9 },
			new int[] { 3, 943, 50, 62, 45, 53, 57, 48, 51, 9 },
			new int[] { 3, 967, 51, 64, 46, 54, 58, 49, 52, 9 }
		},
		new int[][]
		{
			new int[] { 5, 106, 4, 5, 2, 3, 1, 3, 0, 7 },
			new int[] { 5, 123, 5, 6, 3, 3, 2, 4, 1, 7 },
			new int[] { 5, 140, 5, 7, 4, 4, 3, 5, 2, 7 },
			new int[] { 5, 157, 6, 8, 5, 5, 4, 6, 2, 7 },
			new int[] { 5, 174, 6, 9, 6, 5, 4, 7, 3, 7 },
			new int[] { 5, 192, 7, 10, 7, 6, 5, 7, 4, 7 },
			new int[] { 5, 209, 7, 11, 8, 7, 6, 8, 4, 7 },
			new int[] { 5, 226, 8, 12, 9, 8, 7, 9, 5, 7 },
			new int[] { 5, 251, 9, 14, 10, 8, 7, 10, 6, 7 },
			new int[] { 5, 268, 9, 15, 11, 9, 8, 10, 7, 7 },
			new int[] { 5, 286, 10, 16, 12, 10, 9, 11, 7, 7 },
			new int[] { 5, 295, 10, 17, 12, 10, 10, 12, 8, 7 },
			new int[] { 5, 312, 11, 18, 13, 11, 10, 13, 9, 7 },
			new int[] { 5, 329, 11, 19, 14, 12, 11, 14, 9, 7 },
			new int[] { 5, 346, 12, 20, 15, 13, 12, 14, 10, 7 },
			new int[] { 5, 364, 12, 21, 16, 13, 13, 15, 11, 7 },
			new int[] { 5, 381, 13, 22, 17, 14, 13, 16, 12, 7 },
			new int[] { 5, 398, 13, 23, 18, 15, 14, 17, 12, 7 },
			new int[] { 5, 415, 14, 24, 19, 15, 15, 17, 13, 7 },
			new int[] { 5, 432, 14, 25, 20, 16, 16, 18, 14, 7 },
			new int[] { 5, 458, 15, 27, 21, 17, 16, 19, 15, 7 },
			new int[] { 5, 475, 15, 28, 22, 18, 17, 20, 15, 7 },
			new int[] { 5, 492, 16, 29, 23, 18, 18, 21, 16, 7 },
			new int[] { 5, 509, 16, 30, 24, 19, 19, 21, 17, 7 },
			new int[] { 5, 526, 17, 31, 25, 20, 19, 22, 17, 7 },
			new int[] { 5, 544, 17, 32, 26, 21, 20, 23, 18, 7 },
			new int[] { 5, 561, 18, 33, 27, 21, 21, 24, 19, 7 },
			new int[] { 5, 578, 19, 34, 28, 22, 22, 24, 20, 7 },
			new int[] { 5, 595, 19, 35, 29, 23, 22, 25, 20, 7 },
			new int[] { 5, 612, 20, 36, 30, 23, 23, 26, 21, 7 },
			new int[] { 5, 630, 20, 37, 31, 24, 24, 27, 22, 7 },
			new int[] { 5, 647, 21, 38, 32, 25, 25, 28, 22, 7 },
			new int[] { 5, 664, 21, 39, 33, 26, 25, 28, 23, 7 },
			new int[] { 5, 689, 22, 41, 34, 26, 26, 29, 24, 7 },
			new int[] { 5, 706, 22, 42, 35, 27, 27, 30, 25, 7 },
			new int[] { 5, 724, 23, 43, 36, 28, 28, 31, 25, 7 },
			new int[] { 5, 733, 23, 44, 36, 28, 28, 31, 26, 7 },
			new int[] { 5, 750, 24, 45, 37, 29, 29, 32, 27, 7 },
			new int[] { 5, 767, 24, 46, 38, 30, 30, 33, 27, 7 },
			new int[] { 5, 784, 25, 47, 39, 31, 31, 34, 28, 7 },
			new int[] { 5, 802, 25, 48, 40, 31, 31, 35, 29, 7 },
			new int[] { 5, 819, 26, 49, 41, 32, 32, 35, 30, 7 },
			new int[] { 5, 836, 26, 50, 42, 33, 33, 36, 30, 7 },
			new int[] { 5, 853, 27, 51, 43, 33, 34, 37, 31, 7 },
			new int[] { 5, 870, 28, 52, 44, 34, 34, 38, 32, 7 },
			new int[] { 5, 896, 28, 54, 45, 35, 35, 39, 33, 7 },
			new int[] { 5, 913, 29, 55, 46, 36, 36, 39, 33, 7 },
			new int[] { 5, 930, 29, 56, 47, 36, 37, 40, 34, 7 },
			new int[] { 5, 947, 30, 57, 48, 37, 37, 41, 35, 7 },
			new int[] { 5, 964, 30, 58, 49, 38, 38, 42, 35, 7 },
			new int[] { 5, 982, 31, 59, 50, 39, 39, 42, 36, 7 },
			new int[] { 5, 999, 31, 60, 51, 39, 40, 43, 37, 7 },
			new int[] { 5, 1016, 32, 61, 52, 40, 40, 44, 38, 7 },
			new int[] { 5, 1033, 32, 62, 53, 41, 41, 45, 38, 7 },
			new int[] { 5, 1050, 33, 63, 54, 41, 42, 46, 39, 7 },
			new int[] { 5, 1068, 33, 64, 55, 42, 43, 46, 40, 7 },
			new int[] { 5, 1085, 34, 65, 56, 43, 43, 47, 40, 7 },
			new int[] { 5, 1102, 34, 66, 57, 44, 44, 48, 41, 7 },
			new int[] { 5, 1127, 35, 68, 58, 44, 45, 49, 42, 7 },
			new int[] { 5, 1144, 35, 69, 59, 45, 46, 49, 43, 7 }
		}
	};

	// Token: 0x04000797 RID: 1943
	private readonly int[][] PlyNextLevel = new int[][]
	{
		new int[]
		{
			0, 17, 33, 80, 128, 182, 236, 291, 345, 453,
			585, 717, 849, 981, 1114, 1246, 1378, 1547, 1716, 1885,
			2055, 2224, 2393, 2562, 2731, 2900, 3110, 3320, 3531, 3741,
			3951, 4161, 4371, 4581, 4791, 5001, 5275, 5549, 5823, 6096,
			6370, 6644, 7054, 7464, 7874, 8284, 8694, 9199, 9704, 10210,
			10715, 11220, 11725, 12231, 12736, 13303, 13870, 14437, 15003, 16029
		},
		new int[]
		{
			0, 16, 32, 78, 124, 177, 230, 283, 336, 441,
			570, 699, 828, 957, 1087, 1216, 1345, 1510, 1675, 1840,
			2006, 2171, 2336, 2501, 2666, 2831, 3037, 3242, 3447, 3652,
			3857, 4063, 4268, 4473, 4678, 4883, 5151, 5418, 5685, 5952,
			6220, 6487, 6887, 7288, 7688, 8089, 8489, 8982, 9476, 9969,
			10463, 10956, 11450, 11943, 12437, 12990, 13544, 14098, 14651, 15653
		},
		new int[]
		{
			0, 19, 38, 93, 148, 212, 276, 339, 403, 529,
			684, 838, 993, 1148, 1303, 1458, 1612, 1810, 2008, 2206,
			2404, 2602, 2800, 2998, 3196, 3394, 3640, 3886, 4132, 4378,
			4624, 4870, 5116, 5362, 5608, 5854, 6175, 6495, 6816, 7136,
			7456, 7777, 8257, 8737, 9217, 9697, 10177, 10768, 11360, 11952,
			12543, 13135, 13726, 14318, 14910, 15573, 16237, 16900, 17564, 18765
		},
		new int[]
		{
			0, 14, 30, 75, 119, 171, 223, 274, 326, 428,
			554, 680, 806, 932, 1057, 1183, 1309, 1470, 1631, 1792,
			1952, 2113, 2274, 2435, 2596, 2757, 2957, 3157, 3356, 3556,
			3756, 3956, 4156, 4356, 4556, 4756, 5016, 5276, 5537, 5797,
			6057, 6317, 6707, 7097, 7487, 7877, 8267, 8748, 9229, 9710,
			10190, 10671, 11152, 11632, 12113, 12652, 13191, 13730, 14270, 15246
		}
	};

	// Token: 0x04000798 RID: 1944
	private string[][] PlyNAtkName = new string[][]
	{
		new string[] { "ｽｸﾘｭｰﾌﾞﾛｰ", "ﾊｲｷｯｸ", "ｽﾗｯｼｭﾌﾞﾚｰﾄﾞ", "ﾋｰﾄﾌﾞﾛｰ", "ｽﾗｯｼｭﾌﾞﾚｰﾄﾞ", "ﾄﾙﾈｰﾄﾞｷｯｸ" },
		new string[] { "S RANGE SHOT", "L RANGE SHOT", "QUICK FIRE", "SNIPE SHOT", "SNIPE SHOT", "QUICK FIRE" },
		new string[] { "ﾊﾟﾜｰｽﾄﾗｲｸ", "ﾚｰｻﾞｰｶﾞﾝ", "ﾌﾟﾗｽﾞﾏｱｰﾑ", "ﾌﾞﾗｽﾄﾎﾞﾑ", "ｿﾆｯｸｸﾛｰ", "ﾚｰｻﾞｰｶﾞﾝ" },
		new string[] { "GRAPPLE", "LG19BGS", "SMG24BGS", "HGG-BGS", "GRD20BGS", "FLM53BGS" }
	};

	// Token: 0x04000799 RID: 1945
	private int[][][] PlyNAtkParam = new int[][][]
	{
		new int[][]
		{
			new int[] { 0, 2, 9, 0, 3, -1, 0, 95, 0 },
			new int[] { 0, 2, 9, 0, 2, -1, 1, 90, 0 },
			new int[] { 0, 0, 9, 0, 5, 0, 0, 100, 1 },
			new int[] { 0, 2, 3, 0, 4, 0, 1, 100, 4 },
			new int[] { 0, 0, 9, 0, 4, 1, 0, 100, 1 },
			new int[] { 0, 2, 9, 0, 5, 1, 1, 80, 0 }
		},
		new int[][]
		{
			new int[] { 0, 1, 9, 0, 2, -1, 0, 95, 0 },
			new int[] { 0, 1, 9, 0, 1, -1, 1, 85, 0 },
			new int[] { 0, 1, 9, 0, 3, 0, 0, 95, 0 },
			new int[] { 0, 1, 9, 0, 4, 0, 1, 100, 0 },
			new int[] { 0, 1, 9, 0, 3, 1, 0, 80, 0 },
			new int[] { 0, 1, 9, 0, 2, 1, 1, 75, 0 }
		},
		new int[][]
		{
			new int[] { 0, 2, 9, 0, 2, -1, 0, 100, 0 },
			new int[] { 1, 7, 9, 0, 3, -1, 1, 95, 2 },
			new int[] { 1, 1, 5, 0, 4, 0, 0, 100, 3 },
			new int[] { 0, 3, 9, 0, 2, 0, 1, 85, 4 },
			new int[] { 0, 0, 9, 0, 2, 1, 0, 85, 1 },
			new int[] { 1, 7, 9, 0, 3, 1, 1, 95, 2 }
		},
		new int[][]
		{
			new int[] { 0, 2, 9, 0, 2, -1, 0, 100, 0 },
			new int[] { 0, 7, 9, 0, 3, -1, 1, 80, 2 },
			new int[] { 0, 1, 9, 0, 4, 0, 0, 100, 0 },
			new int[] { 0, 1, 9, 0, 5, 0, 1, 95, 0 },
			new int[] { 0, 2, 9, 1, 4, 1, 0, 100, 0 },
			new int[] { 1, 3, 9, 0, 3, 1, 1, 100, 4 }
		}
	};

	// Token: 0x0400079A RID: 1946
	private string[][] PlySAtkName = new string[][]
	{
		new string[] { "ﾗｲﾄﾆﾝｸﾞﾌﾞﾚｰﾄﾞ", "ﾍﾙｸﾘﾒｲｼｮﾝ", "ﾗｲﾄﾆﾝｸﾞﾌﾞﾚｰﾄﾞ", "ﾊﾞｰﾆﾝｸﾞﾗｯｼｭ", "ｸﾞﾗﾝﾄﾞｼｪｲｶｰ", "ﾍﾙｸﾘﾒｲｼｮﾝ" },
		new string[] { "JUSTICE SPIRIT", "JUDGMENT OF LAW", "SHINING SHOT", "JUSTICE SPIRIT", "FIRE AT RANDOM", "JUDGMENT OF LAW" },
		new string[] { "ｳﾙﾌﾌｧﾝｸﾞ", "ｽﾊﾟｲﾗﾙｽﾋﾟｱ", "ｳﾙﾌﾌｧﾝｸﾞ", "ｽﾊﾟｲﾗﾙｽﾋﾟｱ", "ｱｲｼｸﾙｿｰﾄﾞ", "ｼｬｯﾀｰｿｳﾙ" },
		new string[] { "BMP44BGS", "BBC-BGS", "BMP44BGS", "BL21BGS", "LC-BGS", "BBC-BGS" }
	};

	// Token: 0x0400079B RID: 1947
	private string[][] PlySAtkExp = new string[][]
	{
		new string[] { "敵単体・エーテル・雷／斬", "敵全体・物理・炎", "敵単体・エーテル・雷／斬", "敵単体・物理・炎／打", "敵全体・物理・打", "敵全体・物理・炎" },
		new string[] { "敵単体・物理・突／気", "敵全体・エーテル・突／Ｓ", "敵単体・エーテル・突／Ｂ", "敵単体・物理・突／気", "敵全体・物理・突", "敵全体・エーテル・突／Ｓ" },
		new string[] { "敵単体・物理・斬／気", "敵単体・エーテル・突", "敵単体・物理・斬／気", "敵単体・エーテル・突", "敵単体・エーテル・斬／冷", "敵単体・エーテル・気／Ｓ" },
		new string[] { "敵全体・物理・打", "敵全体・エーテル・Ｂ", "敵全体・物理・打", "敵単体・エーテル・Ｂ", "敵単体・物理・打", "敵全体・エーテル・Ｂ" }
	};

	// Token: 0x0400079C RID: 1948
	private int[][][] PlySAtkParam = new int[][][]
	{
		new int[][]
		{
			new int[]
			{
				1, 5, 0, 0, 0, 0, 30, 10, 51, 99,
				0, 0
			},
			new int[]
			{
				0, 3, 9, 1, 0, 0, 23, 10, 55, 99,
				1, 3
			},
			new int[]
			{
				1, 5, 0, 0, 0, 0, 30, 10, 1, 99,
				2, 0
			},
			new int[]
			{
				0, 3, 2, 0, 0, 0, 28, 10, 1, 99,
				3, 1
			},
			new int[]
			{
				0, 2, 9, 1, 0, 0, 20, 10, 20, 99,
				4, 2
			},
			new int[]
			{
				0, 3, 9, 1, 0, 0, 23, 10, 10, 99,
				5, 3
			}
		},
		new int[][]
		{
			new int[]
			{
				0, 1, 6, 0, 0, 0, 23, 10, 45, 99,
				0, 5
			},
			new int[]
			{
				1, 1, 8, 1, 0, 22, 15, 10, 50, 99,
				1, 7
			},
			new int[]
			{
				1, 1, 7, 0, 0, 0, 18, 10, 1, 99,
				2, 4
			},
			new int[]
			{
				0, 1, 6, 0, 0, 0, 23, 10, 1, 99,
				3, 5
			},
			new int[]
			{
				0, 1, 9, 1, 0, 0, 13, 10, 12, 99,
				4, 6
			},
			new int[]
			{
				1, 1, 8, 1, 0, 22, 15, 10, 24, 99,
				5, 7
			}
		},
		new int[][]
		{
			new int[]
			{
				0, 0, 6, 0, 0, 0, 22, 10, 53, 99,
				0, 8
			},
			new int[]
			{
				1, 1, 9, 0, 0, 0, 18, 10, 48, 99,
				1, 9
			},
			new int[]
			{
				0, 0, 6, 0, 0, 0, 22, 10, 12, 99,
				2, 8
			},
			new int[]
			{
				1, 1, 9, 0, 0, 0, 18, 10, 1, 99,
				3, 9
			},
			new int[]
			{
				1, 0, 6, 0, 0, 0, 17, 10, 24, 99,
				4, 10
			},
			new int[]
			{
				1, 6, 8, 0, 0, 19, 25, 10, 32, 99,
				5, 11
			}
		},
		new int[][]
		{
			new int[]
			{
				0, 2, 5, 1, 0, 0, 24, 10, 54, 99,
				0, 12
			},
			new int[]
			{
				1, 7, 3, 1, 0, 0, 26, 10, 58, 99,
				1, 15
			},
			new int[]
			{
				0, 2, 5, 1, 0, 0, 24, 10, 1, 99,
				2, 12
			},
			new int[]
			{
				1, 7, 9, 0, 0, 0, 20, 10, 18, 99,
				3, 13
			},
			new int[]
			{
				0, 2, 9, 0, 0, 0, 22, 10, 8, 99,
				4, 14
			},
			new int[]
			{
				1, 7, 3, 1, 0, 0, 26, 10, 1, 99,
				5, 15
			}
		}
	};

	// Token: 0x0400079D RID: 1949
	private int[] PlySAtkEffMax = new int[]
	{
		13, 9, 14, 10, 9, 15, 7, 9, 5, 20,
		22, 19, 7, 13, 19, 19
	};

	// Token: 0x0400079E RID: 1950
	private string[][] PlyEtName = new string[][]
	{
		new string[] { "ﾒﾃﾞｨｶ", "ｸﾞｯﾊﾞｲ" },
		new string[] { "ｸﾞｯﾊﾞｲ", "ﾛｽﾄﾊﾟﾜｰ", "ｴｸｽﾄﾗﾊﾟﾜｰ", "ｻｲｺﾎﾟｹｯﾄ" },
		new string[] { "ﾒﾃﾞｨｶ", "ｱﾅﾗｲｽﾞ", "ﾘﾌﾚｯｼｭ", "ｴｰﾃﾙﾌﾞﾚｽ", "ｴｰﾃﾙﾘﾐｯﾄ", "ｸｲｯｸ", "ﾒﾃﾞｨｶｽｵｰﾙ", "ﾌﾞｰｽﾄﾜﾝ", "ﾘﾊﾞﾄｰ", "ｾﾌﾃｨｰﾚﾍﾞﾙ" },
		new string[] { "ﾊﾞﾆｼﾝｸﾞｶﾉﾝ", "ﾌﾞｰｽﾄﾜﾝ", "ﾊﾞｸﾞﾌｧﾗﾝｸｽ" }
	};

	// Token: 0x0400079F RID: 1951
	private string[][] PlyEtExp = new string[][]
	{
		new string[] { "HP回復", "戦闘から逃走" },
		new string[] { "戦闘から逃走", "物理攻撃力25％ﾀﾞｳﾝ", "物理攻撃力25％ｱｯﾌﾟ", "ｱｲﾃﾑを盗む" },
		new string[] { "HP回復", "敵のHPなどを調べる", "全ｽﾃｰﾀｽをｸﾘｱ", "ｴｰﾃﾙ系の効果を25％ｱｯﾌﾟ", "ｴｰﾃﾙ系の効果を25％ﾀﾞｳﾝ", "行動速度25％ｱｯﾌﾟ", "ﾊﾟｰﾃｨｰ全員のHP回復", "ﾌﾞｰｽﾄ回数+1", "戦闘不能回復&HP回復", "HP1で一度だけ生き残る" },
		new string[] { "無属性のｴｰﾃﾙ攻撃", "ﾌﾞｰｽﾄ回数+1", "無属性のｴｰﾃﾙ攻撃&敵にﾘﾌﾚｯｼｭ効果" }
	};

	// Token: 0x040007A0 RID: 1952
	private int[] PlyEtPiece = new int[] { 2, 4, 10, 3 };

	// Token: 0x040007A1 RID: 1953
	private int[][][] PlyEtParam = new int[][][]
	{
		new int[][]
		{
			new int[] { 2, 2, 2, 26, 50, 1, 1, 3 },
			new int[] { 1, 5, 1, 41, 0, 1, 1, 1 }
		},
		new int[][]
		{
			new int[] { 1, 5, 1, 41, 0, 1, 1, 1 },
			new int[] { 3, 0, 0, 13, 0, 2, 12, 1 },
			new int[] { 3, 2, 1, 1, 0, 2, 14, 1 },
			new int[] { 4, 0, 0, 46, 0, 4, 16, 1 }
		},
		new int[][]
		{
			new int[] { 2, 2, 2, 26, 50, 1, 1, 3 },
			new int[] { 2, 0, 1, 44, 0, 1, 6, 1 },
			new int[] { 2, 2, 1, 37, 0, 1, 10, 1 },
			new int[] { 4, 6, 1, 11, 0, 3, 16, 1 },
			new int[] { 4, 6, 1, 10, 0, 3, 18, 1 },
			new int[] { 7, 2, 1, 45, 0, 2, 20, 1 },
			new int[] { 8, 3, 2, 27, 10, 2, 22, 3 },
			new int[] { 6, 2, 1, 40, 0, 4, 26, 1 },
			new int[] { 10, 7, 2, 35, 5, 2, 30, 1 },
			new int[] { 11, 2, 2, 43, 0, 3, 32, 1 }
		},
		new int[][]
		{
			new int[] { 6, 0, 0, 47, 50, 1, 22, 1 },
			new int[] { 6, 2, 1, 40, 0, 4, 26, 1 },
			new int[] { 11, 1, 0, 48, 70, 4, 40, 1 }
		}
	};

	// Token: 0x040007A2 RID: 1954
	private int[] StIcon = new int[]
	{
		70, 49, 49, 49, 49, 49, 49, 57, 49, 49,
		59, 42, 47, 48, 48, 48, 48, 50, 52, 58,
		48, 54, 46, 44, 44, 52, 70, 70, 70, 70,
		70, 70, 70, 70, 70, 70, 70, 70, 70, 70,
		70, 70, 70, 53, 70, 56, 70, 70, 70
	};

	// Token: 0x040007A3 RID: 1955
	private string[] EneName = new string[]
	{
		"ﾈﾗｲｱ", "ｱﾚｵｽ", "強化U.M.N.ﾃﾛﾘｽﾄ", "ｽﾚｲﾌﾟﾆﾙ", "ｱｳﾄﾞﾑﾗ", "ﾊﾞﾙﾄﾞﾙ", "ｶﾞﾙﾑ", "ｴｰｷﾞﾙ", "ﾛｷ2", "ｱﾙｷｭｵﾈｽ",
		"ｳﾞｫｲｼﾞｬｰ", "ｳﾞｫｲｼﾞｬｰ", "ｳﾞｫｲｼﾞｬｰ"
	};

	// Token: 0x040007A4 RID: 1956
	private int[][] EneParam = new int[][]
	{
		new int[]
		{
			0, 0, 623, 37, 30, 37, 26, 70, 40, 16,
			-1, -1, 0, -1, -1, -1, -1, -1, 3, 0,
			1, 4, 0, 0, 873, 1, 4, 2, 0, 2,
			13
		},
		new int[]
		{
			1, 0, 628, 37, 30, 37, 26, 70, 41, 16,
			-1, -1, 1, -1, -1, -1, -1, -1, 3, 4,
			1, 4, 0, 0, 882, 1, 4, 6, 0, 2,
			12
		},
		new int[]
		{
			2, 0, 844, 30, 33, 40, 35, 75, 47, 17,
			0, -1, 2, -1, -1, -1, -1, -1, 3, 1,
			6, 3, 0, 3, 936, 1, 3, 11, 0, 1,
			16
		},
		new int[]
		{
			0, 1, 2598, 51, 48, 52, 42, 85, 52, 14,
			1, -1, 3, 4, -1, -1, -1, -1, 5, 2,
			1, 4, 0, 3, 957, 1, 4, 2, 0, 1,
			13
		},
		new int[]
		{
			1, 2, 2736, 51, 55, 52, 43, 90, 52, 15,
			2, -1, 5, 6, -1, -1, -1, -1, 5, 2,
			1, 3, 0, 3, 3195, 1, 4, 6, 0, 1,
			12
		},
		new int[]
		{
			2, 1, 3179, 55, 59, 51, 46, 95, 57, 16,
			3, -1, 7, 8, -1, -1, -1, -1, 3, 2,
			1, 3, 0, 3, 3425, 1, 3, 2, 0, 1,
			11
		},
		new int[]
		{
			3, 2, 3671, 56, 64, 53, 45, 95, 57, 17,
			4, -1, 9, 10, -1, -1, -1, -1, 5, 2,
			1, 2, 0, 3, 4533, 1, 3, 2, 0, 1,
			9
		},
		new int[]
		{
			4, 1, 4000, 55, 62, 54, 46, 100, 55, 18,
			5, -1, 11, 12, -1, -1, -1, -1, 3, 2,
			1, 3, 0, 3, 4959, 1, 2, 6, 0, 1,
			10
		},
		new int[]
		{
			5, 2, 4292, 55, 64, 54, 46, 100, 55, 19,
			6, -1, 13, 14, -1, -1, -1, -1, 3, 3,
			1, 2, 0, 3, 5178, 1, 2, 6, 0, 1,
			16
		},
		new int[]
		{
			0, 2, 5300, 57, 69, 55, 47, 100, 70, 20,
			7, -1, 15, 16, -1, -1, -1, -1, 6, 2,
			1, 1, 0, 1, 5231, 2, 2, 2, 0, 1,
			3
		},
		new int[]
		{
			1, 1, 1500, 56, 65, 56, 48, 100, 61, 21,
			8, -1, 17, 18, -1, -1, -1, -1, 7, 2,
			6, 0, 0, 0, 6380, 2, 2, 6, 0, 1,
			7
		},
		new int[]
		{
			2, 1, 3000, 56, 68, 56, 49, 100, 62, 22,
			9, -1, 19, 20, -1, -1, -1, -1, 0, 2,
			6, 0, 0, 0, 6478, 2, 2, 9, 0, 1,
			10
		},
		new int[]
		{
			3, 2, 6500, 58, 70, 58, 50, 100, 64, 23,
			10, -1, 21, 22, -1, -1, -1, -1, 10, 2,
			1, 4, 0, 3, 6478, -1, -1, -1, -1, -1,
			-1
		}
	};

	// Token: 0x040007A5 RID: 1957
	private string[] EneWeak = new string[]
	{
		"斬", "突", "打", "炎", "冷", "雷", "気", "Ｂ", "Ｓ", "無",
		"なし"
	};

	// Token: 0x040007A6 RID: 1958
	private int[][] EneNAtkParam = new int[][]
	{
		new int[] { 1, 7, -1, 0, 15, 50 },
		new int[] { 0, 1, -1, 0, 40, 50 },
		new int[] { 0, 7, -1, 0, 42, 70 },
		new int[] { 0, 9, -1, 0, 44, 70 },
		new int[] { 0, 1, -1, 0, 46, 70 },
		new int[] { 0, 1, -1, 0, 48, 70 },
		new int[] { 0, 2, -1, 0, 48, 70 },
		new int[] { 0, 2, -1, 0, 50, 70 },
		new int[] { 0, 2, -1, 0, 55, 70 },
		new int[] { 0, 2, -1, 0, 60, 70 },
		new int[] { 0, 1, -1, 0, 70, 70 }
	};

	// Token: 0x040007A7 RID: 1959
	private string[][] EneNAtkExp = new string[][]
	{
		new string[] { "エーテル", "単体", "Ｂ" },
		new string[] { "物理", "単体", "突" },
		new string[] { "物理", "単体", "Ｂ" },
		new string[] { "物理", "単体", "無" },
		new string[] { "物理", "単体", "突" },
		new string[] { "物理", "単体", "突" },
		new string[] { "物理", "単体", "打" },
		new string[] { "物理", "単体", "打" },
		new string[] { "物理", "単体", "打" },
		new string[] { "物理", "単体", "打" },
		new string[] { "物理", "単体", "斬" }
	};

	// Token: 0x040007A8 RID: 1960
	private string[] EneSAtkName = new string[]
	{
		"ビームキャノン", "火炎放射", "ハンドグレネード", "スピットファイア", "煙幕", "ブレイクダウン", "高速移動", "ポイズン", "増殖", "機関銃",
		"大砲", "伸し掛かり", "固着", "紅の爪", "蒼の爪", "ブレイズインパクト", "ブライトグレイサー", "大なる地震", "数多の電光", "ブレインバースト",
		"ブレインジャック", "ウェイバーソニック", "ラストアンセム"
	};

	// Token: 0x040007A9 RID: 1961
	private int[][] EneSAtkParam = new int[][]
	{
		new int[] { 1, 7, -1, 0, 18, 0, 0 },
		new int[] { 0, 3, -1, 1, 30, 0, 0 },
		new int[] { 0, 3, -1, 1, 34, 0, 0 },
		new int[] { 0, 7, 3, 1, 36, 0, 0 },
		new int[] { 1, 8, -1, 1, 0, 1, 15 },
		new int[] { 1, 2, 8, 0, 38, 0, 14 },
		new int[] { 1, 8, -1, 4, 0, 1, 6 },
		new int[] { 1, 8, -1, 1, 22, 0, 17 },
		new int[] { 1, -1, -1, 4, 10, 2, 26 },
		new int[] { 0, 1, -1, 1, 38, 0, 0 },
		new int[] { 0, 1, -1, 0, 41, 0, 0 },
		new int[] { 0, 2, -1, 0, 42, 0, 0 },
		new int[] { 1, 8, -1, 0, 40, 0, 24 },
		new int[] { 0, 0, 8, 0, 42, 0, 18 },
		new int[] { 1, 0, 8, 0, 42, 0, 25 },
		new int[] { 0, 3, 8, 1, 30, 0, 14 },
		new int[] { 1, 4, 8, 1, 31, 0, 20 },
		new int[] { 0, 2, -1, 1, 38, 0, 0 },
		new int[] { 1, 5, -1, 1, 38, 0, 0 },
		new int[] { 1, 8, -1, 0, 37, 0, 22 },
		new int[] { 1, 8, -1, 1, 35, 0, 23 },
		new int[] { 1, 4, 8, 0, 38, 0, 19 },
		new int[] { 1, 5, -1, 1, 40, 0, 0 }
	};

	// Token: 0x040007AA RID: 1962
	private string[][] EneSAtkExp = new string[][]
	{
		new string[]
		{
			"エーテル",
			"単体",
			"Ｂ",
			string.Empty
		},
		new string[]
		{
			"物理",
			"全体",
			"炎",
			string.Empty
		},
		new string[]
		{
			"物理",
			"全体",
			"炎",
			string.Empty
		},
		new string[]
		{
			"物理",
			"全体",
			"突／炎",
			string.Empty
		},
		new string[] { "エーテル", "全体", "Ｓ", "命中ダウン" },
		new string[] { "エーテル", "単体", "Ｂ／Ｓ", "物理防御力ダウン" },
		new string[] { "エーテル", "自分", "Ｓ", "回避アップ" },
		new string[] { "エーテル", "全体", "Ｓ", "毒" },
		new string[]
		{
			"エーテル",
			"自分",
			string.Empty,
			"ＨＰ回復"
		},
		new string[]
		{
			"物理",
			"全体",
			"突",
			string.Empty
		},
		new string[]
		{
			"物理",
			"単体",
			"突",
			string.Empty
		},
		new string[]
		{
			"物理",
			"単体",
			"打",
			string.Empty
		},
		new string[] { "エーテル", "単体", "Ｓ", "ロスト" },
		new string[] { "物理", "単体", "斬／Ｓ", "ＨＰハーフ" },
		new string[] { "エーテル", "単体", "斬／Ｓ", "ＥＰオーバー" },
		new string[] { "物理", "全体", "炎／Ｓ", "物理防御力ダウン" },
		new string[] { "エーテル", "全体", "冷／Ｓ", "エーテル力ダウン" },
		new string[]
		{
			"物理",
			"全体",
			"打",
			string.Empty
		},
		new string[]
		{
			"エーテル",
			"全体",
			"雷",
			string.Empty
		},
		new string[] { "エーテル", "単体", "Ｓ", "混乱" },
		new string[] { "エーテル", "全体", "Ｓ", "ブースト封鎖" },
		new string[] { "エーテル", "単体", "冷／Ｓ", "ストップ" },
		new string[]
		{
			"エーテル",
			"全体",
			"雷",
			string.Empty
		}
	};

	// Token: 0x040007AB RID: 1963
	private int[] EneEncP = new int[] { 5, 5, 7, 1, 1, 1 };

	// Token: 0x040007AC RID: 1964
	private int[][][] EneEncount = new int[][][]
	{
		new int[][]
		{
			new int[]
			{
				19, 0, 60, 170, 0, 120, 160, 0, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				39, 1, 60, 170, 1, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				59, 0, 40, 170, 0, 90, 160, 1, 140, 170,
				1, 190, 160
			},
			new int[]
			{
				79, 0, 60, 170, 2, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				99, 2, 40, 170, 2, 90, 160, 2, 140, 170,
				2, 190, 160
			}
		},
		new int[][]
		{
			new int[]
			{
				19, 0, 60, 170, 0, 120, 160, 0, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				39, 1, 60, 170, 1, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				59, 0, 40, 170, 0, 90, 160, 1, 140, 170,
				1, 190, 160
			},
			new int[]
			{
				79, 0, 60, 170, 2, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				99, 2, 40, 170, 2, 90, 160, 2, 140, 170,
				2, 190, 160
			}
		},
		new int[][]
		{
			new int[]
			{
				4, 3, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			},
			new int[]
			{
				5, 4, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			},
			new int[]
			{
				6, 5, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			},
			new int[]
			{
				7, 6, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			},
			new int[]
			{
				8, 7, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			},
			new int[]
			{
				9, 8, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			},
			new int[]
			{
				10, 9, 120, 170, -1, -1, -1, -1, -1, -1,
				-1, -1, -1
			}
		},
		new int[][] { new int[]
		{
			99, 10, 120, 170, -1, -1, -1, -1, -1, -1,
			-1, -1, -1
		} },
		new int[][] { new int[]
		{
			99, 11, 120, 170, -1, -1, -1, -1, -1, -1,
			-1, -1, -1
		} },
		new int[][] { new int[]
		{
			99, 12, 120, 169, -1, -1, -1, -1, -1, -1,
			-1, -1, -1
		} }
	};

	// Token: 0x040007AD RID: 1965
	private string[][] ItemName = new string[][]
	{
		new string[] { "ｱｸｱｼﾞｽﾄ", "HPを小回復" },
		new string[] { "ｱｸｱｼﾞｽﾄS", "HPを中回復" },
		new string[] { "ｱｸｱｼﾞｽﾄDX", "HPを大回復" },
		new string[] { "ｱｸｱMAX", "HPを最大まで回復" },
		new string[] { "ﾛｰｽﾞｼﾞｽﾄ", "EPを小回復" },
		new string[] { "ﾛｰｽﾞｼﾞｽﾄS", "EPを中回復" },
		new string[] { "ﾛｰｽﾞｼﾞｽﾄDX", "EPを大回復" },
		new string[] { "ﾛｰｽﾞMAX", "EPを最大まで回復" },
		new string[] { "ｱｸｱﾛｰｽﾞ", "HPとEPを最大まで回復" },
		new string[] { "ｾﾞｰﾀｼﾞｽﾄ", "戦闘不能とHPを小回復" },
		new string[] { "ｾﾞｰﾀｼﾞｽﾄDX", "戦闘不能とHPを最大まで回復" },
		new string[] { "ｴｸｽﾄﾗｼﾞｽﾄ", "すべてのｽﾃｰﾀｽ異常を回復" },
		new string[] { "ｹﾙﾊﾞｰｼﾞｽﾄ", "肉体系ｽﾃｰﾀｽ異常のみ回復" },
		new string[] { "ｶﾞｲｽﾄｼﾞｽﾄ", "精神系ｽﾃｰﾀｽ異常のみ回復" },
		new string[] { "ﾎﾞﾙﾃｰｼﾞ", "ﾌﾞｰｽﾄ回数+1" },
		new string[] { "ｴｽｹｰﾌﾟﾎﾞｰﾙ", "戦闘から逃走" },
		new string[] { "ｽﾍﾟｰｽﾃﾝﾄ", "HP&EPを最大回復" },
		new string[] { "ﾐﾘﾀﾘｰﾀﾞｶﾞｰ", "物理攻撃力:4\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "ﾒﾀﾙﾄﾝﾌｧｰ", "物理攻撃力:8\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "ﾚｰｻﾞｰﾀﾞｶﾞｰ", "物理攻撃力:13\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "ﾌﾚｲﾑﾀﾞｶﾞｰ", "物理攻撃力:19\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "ﾌﾞﾘｯﾂｴｯｼﾞ", "物理攻撃力:25\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "ﾌﾞﾗｯﾃﾞｨﾀﾞｶﾞｰ", "物理攻撃力:30\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "ｼﾞｬｯｸﾌﾞﾚｰﾄﾞ", "物理攻撃力:35\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "PEACEMAKER", "物理攻撃力:2\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "FIVESEVEN", "物理攻撃力:7\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "GOVERMENT", "物理攻撃力:11\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "JERICHO", "物理攻撃力:16\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "PYTHON", "物理攻撃力:20\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "LAWMAN", "物理攻撃力:24\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "EAGLE", "物理攻撃力:28\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "強化兵装\u3000壱式", "物理攻撃力:2\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "強化兵装\u3000弐式", "物理攻撃力:6\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "強化兵装\u3000参式", "物理攻撃力:9\u3000ｴｰﾃﾙ攻撃力:2" },
		new string[] { "強化兵装\u3000四式", "物理攻撃力:12\u3000ｴｰﾃﾙ攻撃力:4" },
		new string[] { "強化兵装\u3000五式", "物理攻撃力:16\u3000ｴｰﾃﾙ攻撃力:6" },
		new string[] { "強化兵装\u3000六式", "物理攻撃力:19\u3000ｴｰﾃﾙ攻撃力:8" },
		new string[] { "強化兵装\u3000零式", "物理攻撃力:22\u3000ｴｰﾃﾙ攻撃力:10" },
		new string[] { "HAND", "物理攻撃力:0\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "SWD18BGS", "物理攻撃力:4\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "AXE06BGS", "物理攻撃力:9\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "BAI12BGS", "物理攻撃力:14\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "HMR33BGS", "物理攻撃力:19\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "LM07BGS", "物理攻撃力:24\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "BSW11BGS", "物理攻撃力:30\u3000ｴｰﾃﾙ攻撃力:0" },
		new string[] { "NONE", "物理防御力:0\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "制服", "物理防御力:3\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "防護服", "物理防御力:7\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "BGS-A01", "物理防御力:4\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ﾌｧｲﾊﾞｰｽｰﾂ", "物理防御力:12\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "BGS-A02", "物理防御力:10\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ﾒﾀﾙｸﾛｽ", "物理防御力:17\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ﾌｫｼﾙｱｰﾏｰ", "物理防御力:20\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "BGS-A03", "物理防御力:16\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ｴｸｽﾄﾗｽｰﾂ", "物理防御力:25\u3000ｴｰﾃﾙ防御力:2" },
		new string[] { "ﾃﾞｭｱﾙｱｰﾏｰ", "物理防御力:28\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "BGS-A04", "物理防御力:21\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ﾊﾞﾄﾙｽｰﾂ", "物理防御力:30\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ﾊﾞﾙｷﾘｰｱｰﾏｰ", "物理防御力:33\u3000ｴｰﾃﾙ防御力:5" },
		new string[] { "BGS-A05", "物理防御力:28\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "ｱｽﾄﾗﾙｽｰﾂ", "物理防御力:38\u3000ｴｰﾃﾙ防御力:3" },
		new string[] { "ｿｳﾙｶﾞｰﾄﾞ", "物理防御力:40\u3000ｴｰﾃﾙ防御力:8" },
		new string[] { "BGS-A06", "物理防御力:33\u3000ｴｰﾃﾙ防御力:0" },
		new string[] { "応接室のｶｰﾄﾞｷｰ", "応接室の扉を開けるのに必要" },
		new string[] { "所長室のｶｰﾄﾞｷｰ", "所長室の扉を開けるのに必要" },
		new string[] { "ｲﾝｷｭﾍﾞﾝﾄﾙｰﾑのｶｰﾄﾞｷｰ", "ｲﾝｷｭﾍﾞﾝﾄﾙｰﾑの扉を開けるのに必要" }
	};

	// Token: 0x040007AE RID: 1966
	private int[][] ItemData;

	// Token: 0x040007AF RID: 1967
	private string[] menuroot;

	// Token: 0x040007B0 RID: 1968
	private string[][] configmenu;
}
