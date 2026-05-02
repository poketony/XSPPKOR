using System;
using System.Collections;
using System.IO;
using System.Security;
using Socotra;
using Socotra.Device;
using Socotra.IO;
using Socotra.Media;
using Socotra.Opt.UI.J3d;
using Socotra.UI;
using Socotra.Util;
using Steezy.Utility;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class XenoPP03Canvas : StCanvas, StRunnable, MediaListener
{
	// Token: 0x060004DE RID: 1246 RVA: 0x0005D48C File Offset: 0x0005B68C
	public XenoPP03Canvas()
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

	// Token: 0x060004DF RID: 1247 RVA: 0x00061867 File Offset: 0x0005FA67
	public IEnumerator Run()
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
			this.oldtime = this.nowtime;
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x00061878 File Offset: 0x0005FA78
	public override void Paint(StGraphics g)
	{
		lock (this)
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

	// Token: 0x060004E1 RID: 1249 RVA: 0x000618E8 File Offset: 0x0005FAE8
	protected internal virtual void SetLoading(bool flg)
	{
		this.isloading = flg;
		if (!flg)
		{
			this.KeyClear();
		}
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x000618FC File Offset: 0x0005FAFC
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

	// Token: 0x060004E3 RID: 1251 RVA: 0x00061960 File Offset: 0x0005FB60
	public override void ProcessEvent(int type, int param)
	{
		lock (this)
		{
		}
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00061998 File Offset: 0x0005FB98
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

	// Token: 0x060004E5 RID: 1253 RVA: 0x00061AB9 File Offset: 0x0005FCB9
	public virtual void SetSeqNo(int seq)
	{
		this.seq_no_b = seq;
		this.seq_step_b = 0;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00061AC9 File Offset: 0x0005FCC9
	public virtual int GetSeqNo()
	{
		return this.seq_no;
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00061AD1 File Offset: 0x0005FCD1
	public virtual void SetSeqStep(int step)
	{
		this.seq_step_b = step;
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00061ADC File Offset: 0x0005FCDC
	public virtual void SetSeqStep2(int step)
	{
		this.seq_step_b = step;
		this.seq_step = step;
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00061AF9 File Offset: 0x0005FCF9
	public virtual int GetSeqStep()
	{
		return this.seq_step;
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00061B04 File Offset: 0x0005FD04
	public virtual void GetKey()
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

	// Token: 0x060004EB RID: 1259 RVA: 0x00061BCC File Offset: 0x0005FDCC
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
			this.ExistClearData();
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
			if (XenoPP03Canvas.auth_ret == 100)
			{
				this.Paint(base.GetGraphics());
				if (this.parent.chk_mem)
				{
					XenoPP03Canvas.auth_ret = this.CheckUser();
				}
				else
				{
					XenoPP03Canvas.auth_ret = 1;
				}
				if (XenoPP03Canvas.auth_ret == 1)
				{
					this.SetSeqNo(1);
				}
			}
			if (XenoPP03Canvas.auth_ret <= 0 && (this.id_edge & 4112) != 0)
			{
				this.GameEnd();
			}
			else if (XenoPP03Canvas.auth_ret == 2 && (this.id_edge & 4112) != 0)
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
			this.readbuf = this.GetResource2(43);
			for (int i = 0; i < 6; i++)
			{
				short[] archive = XenoPP03Canvas.GetArchive(this.readbuf, i);
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
			this.readbuf = this.GetResource2(18);
			short[] archive2 = XenoPP03Canvas.GetArchive(this.readbuf, 0);
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
		else if (seqNo == 15)
		{
			this.ClearSaveRoutine();
		}
		else if (seqNo == 22)
		{
			this.ClearSendRoutine();
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
		this.VibRoutine();
		this.PartLasterRoutine();
		this.LaserRoutine();
		this.DestructionRoutine();
		this.QuakeRoutine();
		this.PngFadeRoutine();
		this.FadeRoutine();
		this.SoundVolChange();
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x00061FC8 File Offset: 0x000601C8
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

	// Token: 0x060004ED RID: 1261 RVA: 0x000620CC File Offset: 0x000602CC
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
		this.bimg = new Image[63];
		this.faceimg = new Image[24];
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
		this.mapno = 1;
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
		this.xscr = new XScript03(this);
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

	// Token: 0x060004EE RID: 1262 RVA: 0x00062D50 File Offset: 0x00060F50
	public virtual void SoundInit()
	{
		this.audio_b = AudioPresenter.GetAudioPresenter(0);
		this.audio_s = AudioPresenter.GetAudioPresenter(1);
		this.bgm = new MediaSound[14];
		this.se = new MediaSound[23];
		this.audio_b.SetMediaListener(this);
		this.audio_s.SetMediaListener(this);
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x00062DA7 File Offset: 0x00060FA7
	public virtual void SetBgm(int id)
	{
		this.nowbgm = id;
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x00062DB0 File Offset: 0x00060FB0
	public virtual bool IsNowBgm(int id)
	{
		return this.nowbgm == id;
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x00062DBE File Offset: 0x00060FBE
	public virtual bool IsPlayBgm()
	{
		return this.playbgm != -1;
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x00062DCC File Offset: 0x00060FCC
	public virtual void SetSoundVol()
	{
		int num = (new int[] { 0, 50, 100 })[this.GetConfig(0)];
		this.audio_b.SetAttribute(4, num);
		this.audio_s.SetAttribute(4, num);
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00062E0C File Offset: 0x0006100C
	public virtual void SoundVolChange()
	{
		if ((this.id_edge & 32) != 0)
		{
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

	// Token: 0x060004F4 RID: 1268 RVA: 0x00062E4B File Offset: 0x0006104B
	public virtual void PlayBgm()
	{
		this.playbgm = this.nowbgm;
		this.PlaySound(0, 0);
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00062E64 File Offset: 0x00061064
	public virtual void PlaySe(int id)
	{
		if (id >= 23)
		{
			return;
		}
		this.playse = id;
		this.StopSe();
		if (id >= 17 && this.GetConfig(0) == 0)
		{
			return;
		}
		if (id == 13 || id == 14)
		{
			this.PlaySound(1, id, 0, 1);
			return;
		}
		this.PlaySound(1, id, 1, 1);
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x00062EB2 File Offset: 0x000610B2
	protected internal virtual void PlaySound(int flg, int id)
	{
		this.PlaySound(flg, id, 1, 1);
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00062EBE File Offset: 0x000610BE
	protected internal virtual void PlaySound(int flg, int id, int loop)
	{
		this.PlaySound(flg, id, loop, 1);
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x00062ECC File Offset: 0x000610CC
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

	// Token: 0x060004F9 RID: 1273 RVA: 0x00062F98 File Offset: 0x00061198
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

	// Token: 0x060004FA RID: 1274 RVA: 0x00062FE8 File Offset: 0x000611E8
	protected internal virtual void StopSe()
	{
		try
		{
			this.audio_s.Stop();
			this.se_loop_flag = false;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x0006301C File Offset: 0x0006121C
	public virtual int GetConfig(int no)
	{
		return this.config[no];
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00063028 File Offset: 0x00061228
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

	// Token: 0x060004FD RID: 1277 RVA: 0x0006309E File Offset: 0x0006129E
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

	// Token: 0x060004FE RID: 1278 RVA: 0x000630C4 File Offset: 0x000612C4
	public virtual void SetColor(StGraphics g, int color)
	{
		g.SetColor(StGraphics.GetColorOfRGB((color >> 16) & 255, (color >> 8) & 255, color & 255));
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x000630EC File Offset: 0x000612EC
	public virtual void DrawImage(StGraphics g, Image img, int x, int y, int anc)
	{
		int num = x;
		if ((anc & 1) != 0)
		{
			num -= img.GetWidth() / 2;
		}
		g.DrawImage(img, num + this.qux, y + this.quy);
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x00063124 File Offset: 0x00061324
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

	// Token: 0x06000501 RID: 1281 RVA: 0x00063185 File Offset: 0x00061385
	public virtual void DrawString(StGraphics g, string str, int x, int y, int anc)
	{
		this.DrawString(g, str, x, y, anc, true);
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00063198 File Offset: 0x00061398
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

	// Token: 0x06000503 RID: 1283 RVA: 0x00063366 File Offset: 0x00061566
	public virtual void FillRect(StGraphics g, int x, int y, int w, int h)
	{
		g.FillRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00063382 File Offset: 0x00061582
	public virtual void FillRoundRect(StGraphics g, int x, int y, int w, int h, int aw, int ah)
	{
		g.FillRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x0006339E File Offset: 0x0006159E
	public virtual void DrawRoundRect(StGraphics g, int x, int y, int w, int h, int aw, int ah)
	{
		g.DrawRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x000633BA File Offset: 0x000615BA
	public virtual void DrawLine(StGraphics g, int x1, int y1, int x2, int y2)
	{
		g.DrawLine(x1 + this.qux, y1 + this.quy, x2 + this.qux, y2 + this.quy);
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x000633E4 File Offset: 0x000615E4
	public virtual void FillArc(StGraphics g, int x, int y, int w, int h, int sa, int aa)
	{
		g.FillArc(x + this.qux, y + this.quy, w, h, sa, aa);
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00063404 File Offset: 0x00061604
	public virtual void DrawArc(StGraphics g, int x, int y, int w, int h, int sa, int aa)
	{
		g.DrawArc(x + this.qux, y + this.quy, w, h, sa, aa);
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x00063424 File Offset: 0x00061624
	public virtual void DrawRect(StGraphics g, int x, int y, int w, int h)
	{
		g.DrawRect(x + this.qux, y + this.quy, w, h);
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00063440 File Offset: 0x00061640
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

	// Token: 0x0600050B RID: 1291 RVA: 0x00063470 File Offset: 0x00061670
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

	// Token: 0x0600050C RID: 1292 RVA: 0x000634A4 File Offset: 0x000616A4
	public virtual void EnemySet(int encp)
	{
		int num = this.EneEncP[encp];
		int num2;
		if (encp == 4)
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

	// Token: 0x0600050D RID: 1293 RVA: 0x000635E4 File Offset: 0x000617E4
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
			this.SetLevelStatus(i, 10);
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
		this.AddItem(18, 1);
		this.AddItem(26, 1);
		this.AddItem(32, 1);
		this.AddItem(39, 1);
		this.AddItem(49, 2);
		this.AddItem(47, 1);
		this.AddItem(50, 1);
		this.AddItem(0, 15);
		this.AddItem(1, 5);
		this.AddItem(4, 10);
		this.AddItem(12, 5);
		this.AddItem(15, 10);
		this.AddItem(16, 5);
		this.SetEquip(0, 21, 18);
		this.SetEquip(1, 21, 26);
		this.SetEquip(2, 21, 32);
		this.SetEquip(3, 21, 39);
		this.SetEquip(0, 22, 49);
		this.SetEquip(1, 22, 47);
		this.SetEquip(2, 22, 49);
		this.SetEquip(3, 22, 50);
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00063794 File Offset: 0x00061994
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

	// Token: 0x0600050F RID: 1295 RVA: 0x00063820 File Offset: 0x00061A20
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

	// Token: 0x06000510 RID: 1296 RVA: 0x00063858 File Offset: 0x00061A58
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

	// Token: 0x06000511 RID: 1297 RVA: 0x00063968 File Offset: 0x00061B68
	public virtual void PlayerStatusMax()
	{
		for (int i = 0; i < 4; i++)
		{
			this.SetStatus(i, 2, this.status[i][3]);
			this.SetStatus(i, 4, this.status[i][5]);
			this.SetStatus(i, 19, 0);
		}
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x000639AF File Offset: 0x00061BAF
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

	// Token: 0x06000513 RID: 1299 RVA: 0x000639E4 File Offset: 0x00061BE4
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

	// Token: 0x06000514 RID: 1300 RVA: 0x00063A18 File Offset: 0x00061C18
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
				else if (seqNo == 15)
				{
					this.DrawClearSaveScreen(stGraphics);
				}
				else if (seqNo == 22)
				{
					this.DrawClearSendScreen(stGraphics);
				}
				else if (seqNo == 17)
				{
					this.DrawHelpScreen(stGraphics);
				}
				else if (seqNo == 19)
				{
					this.DrawClearLoadScreen(stGraphics);
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

	// Token: 0x06000515 RID: 1301 RVA: 0x00063C58 File Offset: 0x00061E58
	public virtual void DrawDebug(StGraphics g)
	{
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00063C5C File Offset: 0x00061E5C
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

	// Token: 0x06000517 RID: 1303 RVA: 0x00063EF4 File Offset: 0x000620F4
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

	// Token: 0x06000518 RID: 1304 RVA: 0x00064EE8 File Offset: 0x000630E8
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
					j = 27;
				}
				else
				{
					num5 = 16;
					j = 26;
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

	// Token: 0x06000519 RID: 1305 RVA: 0x00065258 File Offset: 0x00063458
	public virtual void DrawBattleSlot(StGraphics g)
	{
		this.DrawImage(g, this.bimg[33], 132, 185, 0);
		int num;
		if (this.bslotmove < 10)
		{
			num = this.bslot[(this.bslotno + 3) % 4];
			this.DrawImage(g, this.bimg[28 + num], 135, 228 + this.bslotmove, 0);
		}
		num = this.bslot[this.bslotno];
		this.DrawImage(g, this.bimg[28 + num], 135, 195 + this.bslotmove, 0);
		num = this.bslot[(this.bslotno + 1) % 4];
		this.DrawImage(g, this.bimg[28 + num], 135, 162 + this.bslotmove, 0);
		if (this.bslotmove > 10)
		{
			num = this.bslot[(this.bslotno + 2) % 4];
			this.DrawImage(g, this.bimg[28 + num], 135, 129 + this.bslotmove, 0);
		}
		this.SetColor(g, 0);
		this.FillRect(g, 135, 153, 16, 32);
		this.FillRect(g, 135, 238, 16, 2);
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x0006539C File Offset: 0x0006359C
	public virtual void DrawBattleEnemyArea(StGraphics g)
	{
		if (!this.bred[2] && !this.sysred)
		{
			return;
		}
		g.SetClip(0, 83, this.GetWidth(), 81);
		this.SetColor(g, 0);
		this.FillRect(g, -4, 83, this.GetWidth() + 4, 81);
		if (this.mapno != 24)
		{
			this.DrawImage(g, this.bbgimg, 0, 85, 0);
		}
		for (int i = 0; i < this.ep; i++)
		{
			if (this.GetEnemyStatus(i, 34) != 1)
			{
				int num = this.GetEnemyStatus(i, 32);
				int num2 = this.GetEnemyStatus(i, 33) - 10;
				int num3 = 48;
				int num4 = this.GetEnemyStatus(i, 1);
				if (this.GetEnemyStatus(i, 2) == 0)
				{
					num -= 24;
					num2 -= 48;
				}
				else if (this.GetEnemyStatus(i, 2) == 1)
				{
					num -= 32;
					num2 -= 64;
					num3 = 64;
				}
				else if (this.GetEnemyStatus(i, 2) == 2)
				{
					num -= 64;
					num2 -= 64;
					num3 = 128;
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
					this.DrawImage(g, this.eneimg[num4], num + num5, num2 + num6, 0);
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
					this.DrawImage(g, this.eneimg[num4], num + num5, num2 + num6, 0);
				}
				else if (this.GetSeqStep() == 10 && this.GetEnemyStatus(i, 34) == 2)
				{
					int num8 = this.work[1] * (num3 / 16);
					this.DrawRegion(g, this.eneimg[num4], 0, num8, num3, num3 - num8, 0, num, num2 + num8, 0);
				}
				else
				{
					this.DrawImage(g, this.eneimg[num4], num, num2, 0);
				}
			}
		}
		if (this.GetSeqStep() == 27 && this.eneatk >= 48)
		{
			int num4 = this.eneatk - 48;
			this.SetColor(g, 8421504);
			this.FillRect(g, 0, 123, 240, 14);
			this.SetColor(g, 0);
			this.DrawString(g, this.EneSAtkName[num4], 120, 124, 1);
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x000656C4 File Offset: 0x000638C4
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
		this.DrawImage(g, this.bimg[32], 132, 181, 0);
		this.DrawImage(g, this.bimg[34], 132, 238, 0);
		this.DrawImage(g, this.bimg[53], 157, 183, 0);
		for (int i = 0; i < this.gtwp; i++)
		{
			if (this.GetGtw(i) <= 3)
			{
				this.DrawImage(g, this.bimg[11 + this.GetGtw(i)], 154 + i * 20, 165, 0);
			}
			else
			{
				int num = this.GetEnemyStatus(this.GetGtw(i) - 4, 1);
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
						this.DrawImage(g, this.bimg[11 + num2], 159, 221, 0);
						this.DrawImage(g, this.bimg[16], 177, 223, 0);
					}
					else if (i == 1)
					{
						this.DrawImage(g, this.bimg[11 + num2], 189, 185, 0);
						this.DrawImage(g, this.bimg[18], 191, 203, 0);
					}
					else if (i == 2)
					{
						this.DrawImage(g, this.bimg[11 + num2], 219, 221, 0);
						this.DrawImage(g, this.bimg[17], 206, 223, 0);
					}
				}
			}
		}
		else if (this.isboost[1])
		{
			if (this.boostno < 4)
			{
				this.DrawImage(g, this.bimg[11 + this.boostno], 189, 203, 0);
			}
			else
			{
				int num = this.GetEnemyStatus(this.boostno - 4, 1);
				this.DrawImage(g, this.bimg[5 + num], 189, 203, 0);
			}
		}
		g.SetClip(0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00065984 File Offset: 0x00063B84
	public virtual void DrawBattleEnemyMenu(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.SetColor(g, 0);
		this.FillRect(g, 0, 165, 130, 80);
		this.DrawImage(g, this.bimg[54], 0, 166, 0);
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

	// Token: 0x0600051D RID: 1309 RVA: 0x00065B86 File Offset: 0x00063D86
	public virtual void DrawBattleMenuClear(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.SetColor(g, 0);
		this.FillRect(g, 0, 164, 130, 80);
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00065BB8 File Offset: 0x00063DB8
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
					this.DrawImage(g, this.bimg[56], 0, 166 + i * 19, 0);
				}
				else if (num2 >= 16)
				{
					num2 -= 16;
					if (this.GetPlySAtkParam(num, num2, 0) == 0)
					{
						this.DrawImage(g, this.bimg[21], 0, 166 + i * 19, 0);
					}
					else
					{
						this.DrawImage(g, this.bimg[57], 0, 166 + i * 19, 0);
					}
				}
				else if (this.GetPlyNAtkParam(num, num2, 0) == 0)
				{
					this.DrawImage(g, this.bimg[21], 0, 166 + i * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[57], 0, 166 + i * 19, 0);
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
				this.DrawImage(g, this.bimg[22 + this.GetBMenu(i, 1)], 1, 168 + i * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + i * 19, 16, 16);
			}
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00065DAC File Offset: 0x00063FAC
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
					this.DrawImage(g, this.bimg[21], 0, 166 + num2 * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[57], 0, 166 + num2 * 19, 0);
				}
			}
			else if (this.GetPlyNAtkParam(num3, num, 0) == 0)
			{
				this.DrawImage(g, this.bimg[21], 0, 166 + num2 * 19, 0);
			}
			else
			{
				this.DrawImage(g, this.bimg[57], 0, 166 + num2 * 19, 0);
			}
			this.SetColor(g, 16777215);
			if (this.GetBMenu(num2, 0) != -1)
			{
				this.DrawString(g, this.GetBMStr(num2), 26, 169 + num2 * 19, 0);
			}
			if (this.GetBMenu(num2, 1) != -1)
			{
				this.DrawImage(g, this.bimg[22 + this.GetBMenu(num2, 1)], 1, 168 + num2 * 19, 0);
				return;
			}
			this.SetColor(g, 0);
			this.FillRect(g, 0, 166 + num2 * 19, 16, 16);
		}
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00065EF8 File Offset: 0x000640F8
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
					this.DrawImage(g, this.bimg[56], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[21], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				this.DrawString(g, this.GetBMStr(i), 26, 169 + (i - this.cur[2]) * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[22 + this.GetBMenu(i, 1)], 1, 168 + (i - this.cur[2]) * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + (i - this.cur[2]) * 19, 16, 16);
			}
		}
		if (this.bmenup >= 5)
		{
			this.DrawImage(g, this.bimg[18], 1, 167, 0);
			this.DrawImage(g, this.bimg[15], 1, 227, 0);
		}
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x00066084 File Offset: 0x00064284
	public virtual void DrawBattleEtherMenu2(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		int num = this.work[2];
		int num2 = this.work[3];
		this.DrawImage(g, this.bimg[21], 0, 166, 0);
		this.SetColor(g, 16777215);
		this.DrawString(g, this.GetPlyEtName(num, num2), 26, 169, 0);
		this.SetColor(g, 0);
		this.FillRect(g, 0, 166, 16, 16);
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x00066110 File Offset: 0x00064310
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
					this.DrawImage(g, this.bimg[56], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[21], 0, 166 + (i - this.cur[2]) * 19, 0);
				}
				this.DrawString(g, this.GetBMStr(i), 26, 169 + (i - this.cur[2]) * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[22 + this.GetBMenu(i, 1)], 1, 168 + (i - this.cur[2]) * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + (i - this.cur[2]) * 19, 16, 16);
			}
		}
		if (this.bmenup >= 5)
		{
			this.DrawImage(g, this.bimg[18], 1, 167, 0);
			this.DrawImage(g, this.bimg[15], 1, 227, 0);
		}
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x0006629C File Offset: 0x0006449C
	public virtual void DrawBattleItemMenu2(StGraphics g)
	{
		if (!this.bred[4] && !this.sysred)
		{
			return;
		}
		this.DrawBattleMenuClear(g);
		this.DrawImage(g, this.bimg[21], 0, 166, 0);
		this.SetColor(g, 16777215);
		this.DrawString(g, this.GetItemName(this.work[3], 0), 26, 169, 0);
		this.SetColor(g, 0);
		this.FillRect(g, 0, 166, 16, 16);
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x00066320 File Offset: 0x00064520
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
					this.DrawImage(g, this.bimg[56], 0, 166 + i * 19, 0);
				}
				else
				{
					this.DrawImage(g, this.bimg[21], 0, 166 + i * 19, 0);
				}
				this.DrawString(g, this.GetBMStr(i), 26, 169 + i * 19, 0);
			}
			if (this.GetBMenu(i, 1) != -1)
			{
				this.DrawImage(g, this.bimg[22 + this.GetBMenu(i, 1)], 1, 168 + i * 19, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 166 + i * 19, 16, 16);
			}
		}
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x00066450 File Offset: 0x00064650
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
			this.DrawImage(g, this.bimg[59 + this.GetGtw(0)], (this.work[1] - 16) * 12 - 96, 49, 0);
			return;
		}
		if (24 <= this.work[1])
		{
			this.DrawImage(g, this.bimg[59 + this.GetGtw(0)], 0, 49, 0);
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x00066688 File Offset: 0x00064888
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

	// Token: 0x06000527 RID: 1319 RVA: 0x0006671C File Offset: 0x0006491C
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

	// Token: 0x06000528 RID: 1320 RVA: 0x0006678C File Offset: 0x0006498C
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

	// Token: 0x06000529 RID: 1321 RVA: 0x00066864 File Offset: 0x00064A64
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

	// Token: 0x0600052A RID: 1322 RVA: 0x00066B64 File Offset: 0x00064D64
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

	// Token: 0x0600052B RID: 1323 RVA: 0x00066D78 File Offset: 0x00064F78
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

	// Token: 0x0600052C RID: 1324 RVA: 0x00066EC4 File Offset: 0x000650C4
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

	// Token: 0x0600052D RID: 1325 RVA: 0x00066F58 File Offset: 0x00065158
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

	// Token: 0x0600052E RID: 1326 RVA: 0x000670B0 File Offset: 0x000652B0
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

	// Token: 0x0600052F RID: 1327 RVA: 0x00067168 File Offset: 0x00065368
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

	// Token: 0x06000530 RID: 1328 RVA: 0x000671DB File Offset: 0x000653DB
	public virtual void DrawBattleNoGoodbye(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 16711680);
		this.DrawString(g, "逃げられない！", 120, 124, 1);
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00067217 File Offset: 0x00065417
	public virtual void DrawBattleNoEtherExec(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 16711680);
		this.DrawString(g, "EPが足りない！", 120, 124, 1);
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00067253 File Offset: 0x00065453
	public virtual void DrawBattleNoEffect(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 123, 240, 14);
		this.SetColor(g, 16711680);
		this.DrawString(g, "使用しても効果がない。", 120, 124, 1);
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x00067290 File Offset: 0x00065490
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
					if (this.work[8] != 63)
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
		if (this.work[8] != 63)
		{
			if (num == 0)
			{
				this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 16 - this.work[1], 0);
				return;
			}
			this.DrawImage(g, this.bimg[this.work[8]], num3, num4 - 32 + this.work[1], 0);
		}
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x000674E0 File Offset: 0x000656E0
	public virtual int IsIconUpDown(int no)
	{
		int num = 0;
		switch (no)
		{
		case 35:
		case 36:
		case 40:
		case 42:
		case 44:
		case 46:
		case 49:
			num = 0;
			break;
		case 37:
		case 38:
		case 39:
		case 41:
		case 43:
		case 45:
		case 47:
		case 48:
		case 50:
		case 51:
		case 52:
			num = 1;
			break;
		}
		return num;
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0006754C File Offset: 0x0006574C
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

	// Token: 0x06000536 RID: 1334 RVA: 0x000675B4 File Offset: 0x000657B4
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

	// Token: 0x06000537 RID: 1335 RVA: 0x00067644 File Offset: 0x00065844
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

	// Token: 0x06000538 RID: 1336 RVA: 0x00067764 File Offset: 0x00065964
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

	// Token: 0x06000539 RID: 1337 RVA: 0x00067C20 File Offset: 0x00065E20
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

	// Token: 0x0600053A RID: 1338 RVA: 0x00067E54 File Offset: 0x00066054
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
				this.PlaySe(18);
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
				this.PlaySe(20);
			}
			else if (num4 == 4)
			{
				this.PlaySe(17);
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
					this.PlaySe(19);
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
						this.PlaySe(17);
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
				this.PlaySe(19);
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
					this.PlaySe(17);
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
				this.PlaySe(20);
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
				this.PlaySe(17);
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
				this.PlaySe(18);
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
				this.PlaySe(19);
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
				this.PlaySe(20);
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
				this.PlaySe(19);
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
				this.PlaySe(18);
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

	// Token: 0x0600053B RID: 1339 RVA: 0x00068EB0 File Offset: 0x000670B0
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

	// Token: 0x0600053C RID: 1340 RVA: 0x00069110 File Offset: 0x00067310
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

	// Token: 0x0600053D RID: 1341 RVA: 0x0006935C File Offset: 0x0006755C
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

	// Token: 0x0600053E RID: 1342 RVA: 0x000693CA File Offset: 0x000675CA
	public virtual void DrawResultClear(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x000693EC File Offset: 0x000675EC
	public virtual void DrawResultCount(StGraphics g)
	{
		this.SetColor(g, 16777215);
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = this.GetRanks(i);
			if (num2 != 255 && this.GetStatus(num2, 20) == 0 && this.GetStatus(num2, 19) == 0)
			{
				this.DrawImage(g, this.bimg[55], 24, 1 + num * 63 + 27, 0);
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

	// Token: 0x06000540 RID: 1344 RVA: 0x0006978C File Offset: 0x0006798C
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

	// Token: 0x06000541 RID: 1345 RVA: 0x00069868 File Offset: 0x00067A68
	public virtual void DrawResultLearning(StGraphics g)
	{
		int num = this.work[23];
		this.DrawImage(g, this.bimg[55], 24, 61, 0);
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

	// Token: 0x06000542 RID: 1346 RVA: 0x00069AB8 File Offset: 0x00067CB8
	public virtual void DrawGameOverScreen(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawImage(g, this.bimg[58], 58, 120, 0);
		this.red = true;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00069AF3 File Offset: 0x00067CF3
	public virtual void DrawMapScreen(StGraphics g)
	{
		if (this.GetSeqStep() <= 5)
		{
			this.DrawMapTips(g);
			return;
		}
		this.DrawMapMenuObj(g);
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x00069B10 File Offset: 0x00067D10
	public virtual void DrawMapTips(StGraphics g)
	{
		if (this.scrcompred)
		{
			this.sysred = true;
		}
		if ((this.decieveFlag || this.maploopred || this.sysred || this.compred || this.window_cnt != 5) && (this.decieveFlag || this.red || this.sysred))
		{
			this.DrawQuestMap(g, this.mapx, this.mapy);
			if (this.maploopred && !this.maploopstop)
			{
				this.maploopwait += 2;
				if (this.maploopwait > 256)
				{
					this.maploopwait = 0;
				}
			}
			if (this.mapno == 23)
			{
				int num = -10;
				if (this.xscr.sc_flg[79] == 1)
				{
					num = 0;
				}
				else if (this.xscr.sc_flg[78] == 1)
				{
					num = 16;
				}
				else if (this.xscr.sc_flg[77] == 1)
				{
					num = 32;
				}
				if (num != -10)
				{
					this.SetColor(g, 16763040);
					this.FillRect(g, 46, 14 + num, 132, 10);
					this.SetColor(g, 16777215);
					this.FillRect(g, 48, 16 + num, 128, 6);
				}
			}
			if (this.xscr.sc_flg[24] == 1)
			{
				this.DrawTrap(g);
			}
			this.DrawScrObj(g, 0);
			this.DrawNpcChar(g, false);
			this.DrawDestruction(g);
			this.DrawPlayer(g);
			this.DrawScrObj(g, 1);
			this.DrawNpcChar(g, true);
			if (this.xscr.sc_flg[24] == 1 && this.trapdmg != 255)
			{
				this.DrawTrapDmage(g);
			}
		}
		if (this.decieveFlag || this.sysred || this.red)
		{
			this.DrawTalk(g);
		}
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x00069CD8 File Offset: 0x00067ED8
	public virtual void DrawVisualScreen(StGraphics g)
	{
		if (this.red || this.sysred)
		{
			if (this.xscr.sc_picno != -1)
			{
				this.DrawImage(g, this.vimg[this.xscr.sc_picno], 0, this.xscr.sc_drawy - this.xscr.sc_picy, 0);
			}
			else
			{
				this.SetColor(g, 0);
				this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
			}
			this.DrawScrObj(g, 2);
			this.DrawPicAreaClip(g);
			this.DrawTalk2(g);
		}
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x00069D6C File Offset: 0x00067F6C
	public virtual void DrawTitleScreen(StGraphics g)
	{
		string[] array = new string[]
		{
			string.Empty,
			"<",
			"<<"
		};
		int num = 0;
		if (this.cdflag == 1)
		{
			num = 16;
		}
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawImage(g, this.titleimg[3], 0, 30, 0);
		this.DrawImage(g, this.titleimg[2], 78, 160 - num, 0);
		this.DrawImage(g, this.titleimg[1], 71, 176 - num, 0);
		this.DrawImage(g, this.titleimg[4], 82, 213, 0);
		this.DrawImage(g, this.titleimg[5], 0, 230, 0);
		this.DrawImage(g, this.titleimg[0], 40, 160 + this.cur[0] * 16 - num, 0);
		this.SetColor(g, 16777215);
		if (this.cdflag == 1)
		{
			this.DrawString(g, "データ転送", 120, 178, 1);
		}
		this.DrawString(g, "(*)SOUND", 120, 196, 1);
		this.DrawString(g, array[this.GetConfig(0)], 150, 196, 0);
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x00069EB2 File Offset: 0x000680B2
	public virtual void DrawLogoScreen(StGraphics g)
	{
		this.SetColor(g, 16777215);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.DrawImage(g, this.logoimg, 66, 122, 0);
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x00069EE8 File Offset: 0x000680E8
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

	// Token: 0x06000549 RID: 1353 RVA: 0x00069FC4 File Offset: 0x000681C4
	public virtual void DrawClearSaveScreen(StGraphics g)
	{
		int seqStep = this.GetSeqStep();
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, 240, 240);
		if (seqStep <= 2)
		{
			this.DrawWindow(g, 20, 75, 200, 96);
			int num = 22;
			int num2 = 78;
			this.SetColor(g, 16777215);
			this.DrawString(g, "次章アプリにデータを", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "引き継げます。", num, num2, 0);
			num2 += 13;
			this.SetColor(g, 16711680);
			num2 += 13;
			this.DrawString(g, "ご注意", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "本アプリを削除されますと", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "次章アプリに", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "データを引き継ぐ事ができません。", num, num2, 0);
			num2 += 13;
			return;
		}
		if (seqStep == 4)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "引継ぎデータをセーブしますか？", 120, 124, 1);
			return;
		}
		if (seqStep == 3)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "セーブ中です。", 120, 124, 1);
			return;
		}
		if (seqStep == 5)
		{
			this.DrawWindow(g, 20, 115, 200, 30);
			int num = 23;
			int num2 = 117;
			this.SetColor(g, 16777215);
			this.DrawString(g, "データが作成できませんでした。", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "再度、データを作成しますか？", num, num2, 0);
			num2 += 13;
			return;
		}
		if (seqStep == 6)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "セーブが完了しました。", 120, 124, 1);
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x0006A194 File Offset: 0x00068394
	public virtual void DrawClearSendScreen(StGraphics g)
	{
		int seqStep = this.GetSeqStep();
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, 240, 240);
		if (seqStep <= 2)
		{
			this.DrawWindow(g, 20, 75, 200, 96);
			int num = 22;
			int num2 = 78;
			this.SetColor(g, 16777215);
			this.DrawString(g, "次章アプリにデータを", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "転送します。", num, num2, 0);
			num2 += 13;
			this.SetColor(g, 16711680);
			num2 += 13;
			this.DrawString(g, "ご注意", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "次章アプリをダウンロード", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "していませんと次章アプリに", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "データを転送する事ができません。", num, num2, 0);
			num2 += 13;
			return;
		}
		if (seqStep == 4)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "引継ぎデータを転送しますか？", 120, 124, 1);
			return;
		}
		if (seqStep == 3)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "アプリ起動中です。", 120, 124, 1);
			return;
		}
		if (seqStep == 5)
		{
			this.DrawWindow(g, 20, 123, 200, 14);
			this.SetColor(g, 16777215);
			this.DrawString(g, "次章アプリが見つかりません。", 120, 124, 1);
			return;
		}
		if (seqStep == 6)
		{
			this.DrawWindow(g, 20, 115, 200, 30);
			int num = 23;
			int num2 = 117;
			this.SetColor(g, 16777215);
			this.DrawString(g, "アプリの起動に失敗しました。", num, num2, 0);
			num2 += 13;
			this.DrawString(g, "再度、アプリを起動しますか？", num, num2, 0);
			num2 += 13;
		}
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x0006A364 File Offset: 0x00068564
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

	// Token: 0x0600054C RID: 1356 RVA: 0x0006A44C File Offset: 0x0006864C
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

	// Token: 0x0600054D RID: 1357 RVA: 0x0006A600 File Offset: 0x00068800
	public virtual void DrawPicAreaClip(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, 240, this.xscr.sc_drawy);
		this.FillRect(g, 0, this.xscr.sc_drawy + 80, 240, 160 - this.xscr.sc_drawy);
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0006A65C File Offset: 0x0006885C
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

	// Token: 0x0600054F RID: 1359 RVA: 0x0006A6E8 File Offset: 0x000688E8
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

	// Token: 0x06000550 RID: 1360 RVA: 0x0006A774 File Offset: 0x00068974
	protected internal virtual void MenuFlagClear()
	{
		for (int i = 0; i < 2; i++)
		{
			this.ismenu[i] = false;
		}
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0006A796 File Offset: 0x00068996
	protected internal static short ArrayShort(sbyte[] array, int ofs)
	{
		return (short)(((((int)array[ofs] + 256) & 255) << 8) | (((int)array[ofs + 1] + 256) & 255));
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x0006A7BC File Offset: 0x000689BC
	protected internal static short ArrayShort2(sbyte[] array, int ofs)
	{
		return (short)(((((int)array[ofs + 1] + 256) & 255) << 8) | (((int)array[ofs] + 256) & 255));
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x0006A7E4 File Offset: 0x000689E4
	protected internal static int ArrayInt(sbyte[] array, int ofs)
	{
		return ((((int)array[ofs] + 256) & 255) << 24) | ((((int)array[ofs + 1] + 256) & 255) << 16) | ((((int)array[ofs + 2] + 256) & 255) << 8) | (((int)array[ofs + 3] + 256) & 255);
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0006A840 File Offset: 0x00068A40
	protected internal static short[] GetArchive(sbyte[] data, int id)
	{
		short[] array = new short[3];
		bool flag = false;
		short num = 0;
		int num2 = 8;
		XenoPP03Canvas.ArrayShort(data, 4);
		int num3 = (int)XenoPP03Canvas.ArrayShort(data, 6);
		for (int i = 0; i < num3; i++)
		{
			short num4 = XenoPP03Canvas.ArrayShort(data, num2 + i * 6);
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
				short num5 = XenoPP03Canvas.ArrayShort(data, num2 + i * 6 + 2);
				short num6 = XenoPP03Canvas.ArrayShort(data, num2 + i * 6 + 4);
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

	// Token: 0x06000555 RID: 1365 RVA: 0x0006A8E8 File Offset: 0x00068AE8
	protected internal static int[] GetArchive2(sbyte[] data, int id)
	{
		int[] array = new int[3];
		bool flag = false;
		int num = 0;
		int num2 = 8;
		XenoPP03Canvas.ArrayShort(data, 4);
		int num3 = (int)XenoPP03Canvas.ArrayShort(data, 6);
		for (int i = 0; i < num3; i++)
		{
			int num4 = (int)XenoPP03Canvas.ArrayShort(data, num2 + i * 6);
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
				int num5 = (int)XenoPP03Canvas.ArrayShort(data, num2 + i * 6 + 2);
				int num6 = (int)XenoPP03Canvas.ArrayShort(data, num2 + i * 6 + 4);
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

	// Token: 0x06000556 RID: 1366 RVA: 0x0006A9B8 File Offset: 0x00068BB8
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

	// Token: 0x06000557 RID: 1367 RVA: 0x0006AA08 File Offset: 0x00068C08
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

	// Token: 0x06000558 RID: 1368 RVA: 0x0006AA5C File Offset: 0x00068C5C
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

	// Token: 0x06000559 RID: 1369 RVA: 0x0006AA8C File Offset: 0x00068C8C
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

	// Token: 0x0600055A RID: 1370 RVA: 0x0006AC88 File Offset: 0x00068E88
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

	// Token: 0x0600055B RID: 1371 RVA: 0x0006AE3C File Offset: 0x0006903C
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

	// Token: 0x0600055C RID: 1372 RVA: 0x0006AECA File Offset: 0x000690CA
	public virtual void DrawTalkWindow(StGraphics g, int x, int y, int w, int h)
	{
		this.SetColor(g, 16512);
		g.FillRect(x + 1, y + 1, w - 1, h - 1);
		this.SetColor(g, 32960);
		g.DrawRect(x, y, w, h);
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0006AF04 File Offset: 0x00069104
	protected internal virtual void SetVisualData(int vno)
	{
		this.SetLoading(true);
		try
		{
			sbyte[] resource = this.GetResource2(this.vfile[vno]);
			int[] array = XenoPP03Canvas.GetArchive2(resource, 0);
			this.xscr.vscript = new sbyte[array[1]];
			Array.Copy(resource, array[0], this.xscr.vscript, 0, array[1]);
			int num = this.vtbl[vno];
			if (num > 0)
			{
				this.vpno = 1;
				this.vimg = new Image[num];
				for (int i = 0; i < num; i++)
				{
					array = XenoPP03Canvas.GetArchive2(resource, i + 1);
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

	// Token: 0x0600055E RID: 1374 RVA: 0x0006AFF0 File Offset: 0x000691F0
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
					int[] archive = XenoPP03Canvas.GetArchive2(resource, i);
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

	// Token: 0x0600055F RID: 1375 RVA: 0x0006B090 File Offset: 0x00069290
	protected internal virtual void ReadVisualData2(int vno)
	{
		this.SetLoading(true);
		try
		{
			sbyte[] array = this.GetResource2(this.vfile[this.nowvno]);
			int num = this.vtbl[vno];
			this.vimg = new Image[num + 1];
			int[] archive = XenoPP03Canvas.GetArchive2(array, this.vpno);
			int num2 = archive[0];
			int num3 = archive[1];
			this.vimg[0] = this.BuildImage(array, num2, num3);
			if (num > 0)
			{
				array = this.GetResource2(this.vfile[vno]);
				for (int i = 0; i < num; i++)
				{
					int[] archive2 = XenoPP03Canvas.GetArchive2(array, i);
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

	// Token: 0x06000560 RID: 1376 RVA: 0x0006B164 File Offset: 0x00069364
	protected internal virtual void ReleaseVisualData()
	{
		this.vimg = null;
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0006B170 File Offset: 0x00069370
	protected internal virtual void SetMapData(int mno)
	{
		this.SetLoading(true);
		sbyte[] array = this.GetResource2(this.mdfile[mno]);
		short[] array2 = XenoPP03Canvas.GetArchive(array, 0);
		this.xscr.script = new sbyte[(int)array2[1]];
		Array.Copy(array, (int)array2[0], this.xscr.script, 0, (int)array2[1]);
		array2 = XenoPP03Canvas.GetArchive(array, 1);
		this.mapw = (int)XenoPP03Canvas.ArrayShort2(array, (int)array2[0]);
		this.maph = (int)XenoPP03Canvas.ArrayShort2(array, (int)(array2[0] + 2));
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
			array = this.GetResource2(22);
			for (int i = 0; i < 73; i++)
			{
				int[] archive = XenoPP03Canvas.GetArchive2(array, i);
				int num5 = archive[0];
				int num6 = archive[1];
				this.mcimg[i] = this.BuildImage(array, num5, num6);
			}
			array = this.GetResource2(this.mofile[num3]);
			for (int i = 73; i < num4; i++)
			{
				int[] archive2 = XenoPP03Canvas.GetArchive2(array, i);
				int num5 = archive2[0];
				int num6 = archive2[1];
				this.mcimg[i] = this.BuildImage(array, num5, num6);
			}
			this.befmo = num3;
			this.mcimgmax = num4;
		}
		this.SetLoading(false);
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0006B370 File Offset: 0x00069570
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

	// Token: 0x06000563 RID: 1379 RVA: 0x0006B54C File Offset: 0x0006974C
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

	// Token: 0x06000564 RID: 1380 RVA: 0x0006B6C0 File Offset: 0x000698C0
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

	// Token: 0x06000565 RID: 1381 RVA: 0x0006B9B0 File Offset: 0x00069BB0
	public virtual void WorkClear()
	{
		for (int i = 0; i < 24; i++)
		{
			this.work[i] = 0;
		}
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0006B9D4 File Offset: 0x00069BD4
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

	// Token: 0x06000567 RID: 1383 RVA: 0x0006BC10 File Offset: 0x00069E10
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

	// Token: 0x06000568 RID: 1384 RVA: 0x0006BE68 File Offset: 0x0006A068
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

	// Token: 0x06000569 RID: 1385 RVA: 0x0006C0B8 File Offset: 0x0006A2B8
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

	// Token: 0x0600056A RID: 1386 RVA: 0x0006C2EC File Offset: 0x0006A4EC
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

	// Token: 0x0600056B RID: 1387 RVA: 0x0006C328 File Offset: 0x0006A528
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

	// Token: 0x0600056C RID: 1388 RVA: 0x0006C47C File Offset: 0x0006A67C
	public virtual int GetPhysicalSAttackNum(int id, int mno)
	{
		int plySAtkParam = this.GetPlySAtkParam(id, mno, 6);
		int num = this.GetStr(id) + this.GetWeaponStr(id, false);
		return plySAtkParam + num;
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x0006C4A8 File Offset: 0x0006A6A8
	public virtual int GetEtherSAttackNum(int id, int mno)
	{
		int plySAtkParam = this.GetPlySAtkParam(id, mno, 6);
		int num = this.GetEAtk(id) + this.GetWeaponStr(id, true);
		return plySAtkParam + num;
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x0006C4D4 File Offset: 0x0006A6D4
	public virtual int GetPhysicalAttackNum(int id, int mno)
	{
		int plyNAtkParam = this.GetPlyNAtkParam(id, mno, 4);
		int num = this.GetStr(id) + this.GetWeaponStr(id, false);
		return plyNAtkParam + num;
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x0006C500 File Offset: 0x0006A700
	public virtual int GetEtherAttackNum(int id, int mno)
	{
		int plyNAtkParam = this.GetPlyNAtkParam(id, mno, 4);
		int num = this.GetEAtk(id) + this.GetWeaponStr(id, true);
		return plyNAtkParam + num;
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x0006C52C File Offset: 0x0006A72C
	public virtual int GetEtherAttackNum2(int id, int pow)
	{
		int num = this.GetEAtk(id) + this.GetWeaponStr(id, true);
		return pow + num;
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0006C550 File Offset: 0x0006A750
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

	// Token: 0x06000572 RID: 1394 RVA: 0x0006C5C7 File Offset: 0x0006A7C7
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

	// Token: 0x06000573 RID: 1395 RVA: 0x0006C5F6 File Offset: 0x0006A7F6
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

	// Token: 0x06000574 RID: 1396 RVA: 0x0006C630 File Offset: 0x0006A830
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

	// Token: 0x06000575 RID: 1397 RVA: 0x0006C680 File Offset: 0x0006A880
	public virtual void SetBackLight(bool f)
	{
		if (f)
		{
			PhoneSystem.SetAttribute(0, 1);
			return;
		}
		PhoneSystem.SetAttribute(0, 0);
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x0006C694 File Offset: 0x0006A894
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
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x0006C78C File Offset: 0x0006A98C
	public virtual void StartFade(int type)
	{
		this.StartFade(type, 16);
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x0006C798 File Offset: 0x0006A998
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

	// Token: 0x06000579 RID: 1401 RVA: 0x0006C87C File Offset: 0x0006AA7C
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

	// Token: 0x0600057A RID: 1402 RVA: 0x0006C92C File Offset: 0x0006AB2C
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
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x0006CABC File Offset: 0x0006ACBC
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

	// Token: 0x0600057C RID: 1404 RVA: 0x0006CAD8 File Offset: 0x0006ACD8
	public virtual int GetFadeType()
	{
		if (this.IsFade() == 0)
		{
			return 6;
		}
		return this.fade[1];
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x0006CAEC File Offset: 0x0006ACEC
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

	// Token: 0x0600057E RID: 1406 RVA: 0x0006CB58 File Offset: 0x0006AD58
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
			if (this.maploopred && this.maploopwait != 0)
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
								if (this.maploopred)
								{
									this.map_pa.GetVertexArray()[num7 * 3] = num11 - this.maploopwait;
									if (this.map_pa.GetVertexArray()[num7 * 3] < -8)
									{
										this.map_pa.GetVertexArray()[num7 * 3] += 256;
									}
								}
								else
								{
									this.map_pa.GetVertexArray()[num7 * 3] = num11;
								}
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

	// Token: 0x0600057F RID: 1407 RVA: 0x0006CF2C File Offset: 0x0006B12C
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
					this.DrawImage(g, this.mcimg[66], num, num2, 0);
					break;
				case 3:
					this.DrawImage(g, this.mcimg[69], num, num2, 0);
					break;
				case 4:
					if (this.chc == 0 || this.chc == 7)
					{
						this.DrawImage(g, this.mcimg[70], num, num2, 0);
					}
					break;
				case 5:
					if (this.chc == 0 || this.chc == 7)
					{
						this.DrawImage(g, this.mcimg[71], num, num2, 0);
					}
					break;
				}
			}
		}
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x0006D054 File Offset: 0x0006B254
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
			this.DrawImage(g, this.bimg[43], num - 8, num2 - 16, 0);
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

	// Token: 0x06000581 RID: 1409 RVA: 0x0006D10C File Offset: 0x0006B30C
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

	// Token: 0x06000582 RID: 1410 RVA: 0x0006D17E File Offset: 0x0006B37E
	public virtual void BattleFadeStop()
	{
		this.lasf = 0;
		this.lasw = 0;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x0006D190 File Offset: 0x0006B390
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

	// Token: 0x06000584 RID: 1412 RVA: 0x0006D21C File Offset: 0x0006B41C
	public virtual void PartLasterStart()
	{
		this.plasf = 1;
		this.plasw = 0;
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x0006D22C File Offset: 0x0006B42C
	public virtual void PartLasterWorkClear()
	{
		this.plasf = 0;
		this.plasw = 0;
		for (int i = 0; i < 4; i++)
		{
			this.plasxy[i] = 0;
		}
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x0006D25C File Offset: 0x0006B45C
	public virtual void SetPartLaster(int y)
	{
		this.plasxy[0] = 0;
		this.plasxy[1] = y * 16;
		this.plasxy[2] = 240;
		this.plasxy[3] = 48;
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x0006D28A File Offset: 0x0006B48A
	public virtual void SetPartLaster2(int x, int y)
	{
		this.plasxy[0] = x * 16;
		this.plasxy[1] = y * 16;
		this.plasxy[2] = 48;
		this.plasxy[3] = 48;
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x0006D2B8 File Offset: 0x0006B4B8
	public virtual void PartLasterEnd()
	{
		if (this.plasf == 0)
		{
			return;
		}
		this.plasf = 3;
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x0006D2CC File Offset: 0x0006B4CC
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

	// Token: 0x0600058A RID: 1418 RVA: 0x0006D350 File Offset: 0x0006B550
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

	// Token: 0x0600058B RID: 1419 RVA: 0x0006D498 File Offset: 0x0006B698
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

	// Token: 0x0600058C RID: 1420 RVA: 0x0006D5E4 File Offset: 0x0006B7E4
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

	// Token: 0x0600058D RID: 1421 RVA: 0x0006D86C File Offset: 0x0006BA6C
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
			this.DrawImage(g, this.mcimg[72], num, num2, 0);
		}
		else if (this.dflag <= 5)
		{
			for (int i = 0; i < 6; i++)
			{
				int num = this.dwk[i][0];
				int num2 = this.dwk[i][1];
				this.DrawImage(g, this.mcimg[72], num, num2, 0);
			}
		}
		if (this.dflag > 4 && this.dflag <= 8)
		{
			for (int j = 6; j < 10; j++)
			{
				int num = this.dwk[j][0];
				int num2 = this.dwk[j][1];
				this.DrawImage(g, this.mcimg[72], num, num2, 0);
			}
		}
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x0006D93C File Offset: 0x0006BB3C
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

	// Token: 0x0600058F RID: 1423 RVA: 0x0006DB52 File Offset: 0x0006BD52
	public virtual bool DataFolderCheck()
	{
		return XenoPP03Canvas.LoadRecord(16) >= 4;
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x0006DB64 File Offset: 0x0006BD64
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
		array2[3] = 3.ToString();
		array2[4] = "_";
		array2[5] = this.parent.res_name;
		array2[6] = "_0";
		array2[7] = no.ToString();
		array2[8] = ".dat?uid=NULLGWDOCOMO";
		string text = string.Concat(array2);
		int num2;
		if (no == 3)
		{
			num2 = 21745;
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
				OutputStream outputStream = Connector.OpenOutputStream("scratchpad:///11;pos=" + num.ToString());
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

	// Token: 0x06000591 RID: 1425 RVA: 0x0006DDC8 File Offset: 0x0006BFC8
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
			this.work[4] = 224;
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
					XenoPP03Canvas.StoreRecord(16, this.work[1]);
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
				this.work[4] = 224;
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
					this.readbuf = this.GetResource2(42);
					this.work[2] = 99;
				}
				else if (this.work[5] == 1)
				{
					this.readbuf = this.GetResource2(15);
					this.work[2] = 24;
				}
				else if (this.work[5] == 2)
				{
					this.readbuf = this.GetResource2(1);
					this.work[2] = 63;
				}
				else if (this.work[5] == 3)
				{
					this.work[2] = 1;
				}
				else if (this.work[5] == 4)
				{
					this.readbuf = this.GetResource2(63);
					this.work[2] = 17;
				}
				else if (this.work[5] == 5)
				{
					this.readbuf = this.GetResource2(64);
					this.work[2] = 6;
				}
				else
				{
					this.readbuf = this.GetResource2(49 + this.work[5] - 6);
					this.work[2] = 1;
				}
			}
			if (this.work[0] == 1)
			{
				int num2 = this.work[1];
				int[] array;
				if (this.work[5] < 5)
				{
					array = XenoPP03Canvas.GetArchive2(this.readbuf, num2);
				}
				else if (this.work[5] == 5)
				{
					array = XenoPP03Canvas.GetArchive2(this.readbuf, num2 + 17);
				}
				else
				{
					array = XenoPP03Canvas.GetArchive2(this.readbuf, 0);
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
							this.se[num2 + 17] = this.BuildSound(this.readbuf, num3, num4);
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

	// Token: 0x06000592 RID: 1426 RVA: 0x0006E32C File Offset: 0x0006C52C
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

	// Token: 0x06000593 RID: 1427 RVA: 0x0006E3D4 File Offset: 0x0006C5D4
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

	// Token: 0x06000594 RID: 1428 RVA: 0x0006E558 File Offset: 0x0006C758
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
					this.DrawScrObjFade(g, num, num2, this.xscr.obj_prio[i], this.xscr.obj_pn[i], this.xscr.obj_wk[i][1], this.xscr.obj_wk[i][2], f);
				}
				else
				{
					this.DrawScrObjOne(g, num, num2, this.xscr.obj_prio[i], this.xscr.obj_pn[i], f);
				}
			}
		}
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x0006EAF4 File Offset: 0x0006CCF4
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

	// Token: 0x06000596 RID: 1430 RVA: 0x0006EC90 File Offset: 0x0006CE90
	public virtual void DrawScrObjFade(StGraphics g, int x, int y, int pr, int pn, int dh, int pf, int f)
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
				if (num == 0)
				{
					if (pf == 3 || pf == 4)
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, num7 - dh, 1, x, y, 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, num7 - dh, 0, x, y, 0);
						return;
					}
					else if (pf == 5)
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, dh, 1, x, y + (num7 - dh), 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], 0, 0, num6, dh, 0, x, y + (num7 - dh), 0);
						return;
					}
					else if (pf == 6 || pf == 7)
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], dh, 0, num6 - dh, num7, 1, x, y, 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], dh, 0, num6 - dh, num7, 0, x, y, 0);
						return;
					}
					else if (pf == 8 || pf == 9)
					{
						if ((pn & 32768) != 0)
						{
							this.DrawRegion(g, this.mcimg[num5], 0, 0, num6 - dh, num7, 1, x + dh, y, 0);
							return;
						}
						this.DrawRegion(g, this.mcimg[num5], 0, 0, num6 - dh, num7, 0, x + dh, y, 0);
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

	// Token: 0x06000597 RID: 1431 RVA: 0x0006F00B File Offset: 0x0006D20B
	public virtual void PngFadeInit(int flg)
	{
		this.StarWorkInit();
		this.pfflag = flg;
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x0006F01A File Offset: 0x0006D21A
	public virtual void PngFadeStop()
	{
		this.pfflag = 0;
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x0006F024 File Offset: 0x0006D224
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

	// Token: 0x0600059A RID: 1434 RVA: 0x0006F290 File Offset: 0x0006D490
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

	// Token: 0x0600059B RID: 1435 RVA: 0x0006F418 File Offset: 0x0006D618
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

	// Token: 0x0600059C RID: 1436 RVA: 0x0006F6E4 File Offset: 0x0006D8E4
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

	// Token: 0x0600059D RID: 1437 RVA: 0x0006F8C0 File Offset: 0x0006DAC0
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

	// Token: 0x0600059E RID: 1438 RVA: 0x0006F980 File Offset: 0x0006DB80
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

	// Token: 0x0600059F RID: 1439 RVA: 0x0006FB44 File Offset: 0x0006DD44
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
				this.DrawImage(g, this.bimg[55], x + 12, 4 + num * 59 + 3, 0);
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

	// Token: 0x060005A0 RID: 1440 RVA: 0x000702F8 File Offset: 0x0006E4F8
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

	// Token: 0x060005A1 RID: 1441 RVA: 0x00070574 File Offset: 0x0006E774
	private string Num2str(string ss, int num)
	{
		int num2 = num / 100 % 10;
		int num3 = num / 10 % 10;
		int num4 = num % 10;
		return ss + num2.ToString() + num3.ToString() + num4.ToString();
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x000705B4 File Offset: 0x0006E7B4
	private void DrawMapMenuEquip(StGraphics g, int x, int j)
	{
		int[] array = new int[] { 1, 2, 4, 8 };
		int[] array2 = new int[]
		{
			this.GetSeqStep(),
			this.work[2]
		};
		int num = this.work[5];
		this.DrawImage(g, this.bimg[55], x + 12, 23, 0);
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
			this.DrawImage(g, this.bimg[22], x + 14, 101, 0);
			this.DrawImage(g, this.bimg[23], x + 14, 117, 0);
			this.DrawImage(g, this.bimg[22], x + 14, 133, 0);
			this.DrawImage(g, this.bimg[22], x + 14 + 14, 133, 0);
			this.DrawImage(g, this.bimg[22], x + 14, 149, 0);
			this.DrawImage(g, this.bimg[23], x + 14 + 14, 149, 0);
			this.DrawImage(g, this.bimg[23], x + 14, 165, 0);
			this.DrawImage(g, this.bimg[22], x + 14 + 14, 165, 0);
			this.DrawImage(g, this.bimg[23], x + 14, 181, 0);
			this.DrawImage(g, this.bimg[23], x + 14 + 14, 181, 0);
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

	// Token: 0x060005A3 RID: 1443 RVA: 0x00071040 File Offset: 0x0006F240
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

	// Token: 0x060005A4 RID: 1444 RVA: 0x000711A8 File Offset: 0x0006F3A8
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

	// Token: 0x060005A5 RID: 1445 RVA: 0x00071290 File Offset: 0x0006F490
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

	// Token: 0x060005A6 RID: 1446 RVA: 0x00071318 File Offset: 0x0006F518
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

	// Token: 0x060005A7 RID: 1447 RVA: 0x00071400 File Offset: 0x0006F600
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

	// Token: 0x060005A8 RID: 1448 RVA: 0x00071470 File Offset: 0x0006F670
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
			if (this.xscr.sc_flg[24] == 1)
			{
				this.TrapCheck();
			}
			this.SetMapPos();
			this.encount--;
			this.red = true;
			return true;
		}
		return false;
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x0007187A File Offset: 0x0006FA7A
	public virtual void SetEncountNum()
	{
		if (this.chc == 14 || this.chc == 21)
		{
			this.encount = this.GetRand(135, 165);
			return;
		}
		this.encount = this.GetRand(90, 110);
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x000718B8 File Offset: 0x0006FAB8
	public virtual void SetMapPos()
	{
		if (this.mapno == 8)
		{
			this.mapx = 0;
			this.mapy = 0;
			return;
		}
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

	// Token: 0x060005AB RID: 1451 RVA: 0x00071974 File Offset: 0x0006FB74
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

	// Token: 0x060005AC RID: 1452 RVA: 0x00071A08 File Offset: 0x0006FC08
	public virtual void SetBoost(int id)
	{
		int num = this.GetStatus(id, 17);
		this.SetStatus(id, 17, num - 1);
		this.isboost[0] = false;
		this.isboost[1] = true;
		this.isboost[2] = false;
		this.boostno = id;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00071A50 File Offset: 0x0006FC50
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

	// Token: 0x060005AE RID: 1454 RVA: 0x00071AA8 File Offset: 0x0006FCA8
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

	// Token: 0x060005AF RID: 1455 RVA: 0x00071B30 File Offset: 0x0006FD30
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

	// Token: 0x060005B0 RID: 1456 RVA: 0x00071BC8 File Offset: 0x0006FDC8
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

	// Token: 0x060005B1 RID: 1457 RVA: 0x00071C0C File Offset: 0x0006FE0C
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

	// Token: 0x060005B2 RID: 1458 RVA: 0x00071C88 File Offset: 0x0006FE88
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

	// Token: 0x060005B3 RID: 1459 RVA: 0x00071CD0 File Offset: 0x0006FED0
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

	// Token: 0x060005B4 RID: 1460 RVA: 0x00071DA8 File Offset: 0x0006FFA8
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

	// Token: 0x060005B5 RID: 1461 RVA: 0x000720D4 File Offset: 0x000702D4
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

	// Token: 0x060005B6 RID: 1462 RVA: 0x0007212E File Offset: 0x0007032E
	public virtual int GetPlyAglNum(int id)
	{
		return (this.GetAgl(id) - this.GetStatus(id, 24)) * (this.GetStatus(id, 0) + 1);
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x0007214C File Offset: 0x0007034C
	public virtual int GetEneAglNum(int id)
	{
		return this.GetAgl(id + 4);
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x00072158 File Offset: 0x00070358
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

	// Token: 0x060005B9 RID: 1465 RVA: 0x000721C4 File Offset: 0x000703C4
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

	// Token: 0x060005BA RID: 1466 RVA: 0x00072230 File Offset: 0x00070430
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

	// Token: 0x060005BB RID: 1467 RVA: 0x000722C8 File Offset: 0x000704C8
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

	// Token: 0x060005BC RID: 1468 RVA: 0x00072350 File Offset: 0x00070550
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

	// Token: 0x060005BD RID: 1469 RVA: 0x000723C9 File Offset: 0x000705C9
	public virtual void EnemyDamage()
	{
		this.HpDec(this.cur[1] + 4, this.work[0]);
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x000723E4 File Offset: 0x000705E4
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

	// Token: 0x060005BF RID: 1471 RVA: 0x00072424 File Offset: 0x00070624
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

	// Token: 0x060005C0 RID: 1472 RVA: 0x000724C3 File Offset: 0x000706C3
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

	// Token: 0x060005C1 RID: 1473 RVA: 0x00072504 File Offset: 0x00070704
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

	// Token: 0x060005C2 RID: 1474 RVA: 0x000725A0 File Offset: 0x000707A0
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

	// Token: 0x060005C3 RID: 1475 RVA: 0x000725E4 File Offset: 0x000707E4
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

	// Token: 0x060005C4 RID: 1476 RVA: 0x00072620 File Offset: 0x00070820
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

	// Token: 0x060005C5 RID: 1477 RVA: 0x0007266C File Offset: 0x0007086C
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

	// Token: 0x060005C6 RID: 1478 RVA: 0x000727FC File Offset: 0x000709FC
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

	// Token: 0x060005C7 RID: 1479 RVA: 0x000729C0 File Offset: 0x00070BC0
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

	// Token: 0x060005C8 RID: 1480 RVA: 0x00072BB4 File Offset: 0x00070DB4
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

	// Token: 0x060005C9 RID: 1481 RVA: 0x00072C6B File Offset: 0x00070E6B
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

	// Token: 0x060005CA RID: 1482 RVA: 0x00072C8C File Offset: 0x00070E8C
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

	// Token: 0x060005CB RID: 1483 RVA: 0x00072CAC File Offset: 0x00070EAC
	public virtual string GetBMStr(int no)
	{
		if (no < 0 || no >= 66)
		{
			return string.Empty;
		}
		return this.bmstr[no];
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x00072CC5 File Offset: 0x00070EC5
	public virtual void SetBMStr(int no, string str)
	{
		if (no < 0 || no >= 66)
		{
			return;
		}
		this.bmstr[no] = str;
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00072CDA File Offset: 0x00070EDA
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

	// Token: 0x060005CE RID: 1486 RVA: 0x00072D04 File Offset: 0x00070F04
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

	// Token: 0x060005CF RID: 1487 RVA: 0x00072D6C File Offset: 0x00070F6C
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

	// Token: 0x060005D0 RID: 1488 RVA: 0x00072E2C File Offset: 0x0007102C
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

	// Token: 0x060005D1 RID: 1489 RVA: 0x00072EB8 File Offset: 0x000710B8
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

	// Token: 0x060005D2 RID: 1490 RVA: 0x00072FC0 File Offset: 0x000711C0
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

	// Token: 0x060005D3 RID: 1491 RVA: 0x00073034 File Offset: 0x00071234
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

	// Token: 0x060005D4 RID: 1492 RVA: 0x00073060 File Offset: 0x00071260
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

	// Token: 0x060005D5 RID: 1493 RVA: 0x0007309C File Offset: 0x0007129C
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

	// Token: 0x060005D6 RID: 1494 RVA: 0x0007348C File Offset: 0x0007168C
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

	// Token: 0x060005D7 RID: 1495 RVA: 0x00073578 File Offset: 0x00071778
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

	// Token: 0x060005D8 RID: 1496 RVA: 0x00073644 File Offset: 0x00071844
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

	// Token: 0x060005D9 RID: 1497 RVA: 0x00073758 File Offset: 0x00071958
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

	// Token: 0x060005DA RID: 1498 RVA: 0x00073798 File Offset: 0x00071998
	public virtual void BattleRedrawClear()
	{
		for (int i = 0; i < 5; i++)
		{
			this.bred[i] = false;
		}
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x000737BC File Offset: 0x000719BC
	public virtual void BattleRedrawNextFrame()
	{
		for (int i = 0; i < 5; i++)
		{
			this.bred[i] = this.bredn[i];
		}
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x000737E8 File Offset: 0x000719E8
	public virtual void BattleRedrawNClear()
	{
		for (int i = 0; i < 5; i++)
		{
			this.bredn[i] = false;
		}
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x0007380A File Offset: 0x00071A0A
	public virtual void BattleRedraw(int no)
	{
		this.bred[no] = true;
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x00073815 File Offset: 0x00071A15
	public virtual void BattleRedrawN(int no)
	{
		this.bredn[no] = true;
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x00073820 File Offset: 0x00071A20
	public virtual int GetGtw(int no)
	{
		if (no < 0 || no >= 8)
		{
			return 0;
		}
		return this.gtw[no];
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x00073834 File Offset: 0x00071A34
	public virtual void SetGtw(int no, int num)
	{
		if (no < 0 || no >= 8)
		{
			return;
		}
		this.gtw[no] = num;
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x00073848 File Offset: 0x00071A48
	public virtual int GetRanks(int no)
	{
		if (no < 0 || no >= 4)
		{
			return 255;
		}
		return this.ranks[no];
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x00073860 File Offset: 0x00071A60
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

	// Token: 0x060005E3 RID: 1507 RVA: 0x00073885 File Offset: 0x00071A85
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

	// Token: 0x060005E4 RID: 1508 RVA: 0x000738A6 File Offset: 0x00071AA6
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

	// Token: 0x060005E5 RID: 1509 RVA: 0x000738C6 File Offset: 0x00071AC6
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

	// Token: 0x060005E6 RID: 1510 RVA: 0x000738EC File Offset: 0x00071AEC
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

	// Token: 0x060005E7 RID: 1511 RVA: 0x0007390D File Offset: 0x00071B0D
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

	// Token: 0x060005E8 RID: 1512 RVA: 0x00073932 File Offset: 0x00071B32
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

	// Token: 0x060005E9 RID: 1513 RVA: 0x00073952 File Offset: 0x00071B52
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

	// Token: 0x060005EA RID: 1514 RVA: 0x0007397F File Offset: 0x00071B7F
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

	// Token: 0x060005EB RID: 1515 RVA: 0x000739A7 File Offset: 0x00071BA7
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

	// Token: 0x060005EC RID: 1516 RVA: 0x000739D4 File Offset: 0x00071BD4
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

	// Token: 0x060005ED RID: 1517 RVA: 0x000739FC File Offset: 0x00071BFC
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

	// Token: 0x060005EE RID: 1518 RVA: 0x00073A3C File Offset: 0x00071C3C
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

	// Token: 0x060005EF RID: 1519 RVA: 0x00073A78 File Offset: 0x00071C78
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

	// Token: 0x060005F0 RID: 1520 RVA: 0x00073A99 File Offset: 0x00071C99
	public virtual string GetEneName(int no)
	{
		if (no < 0 || no >= 6)
		{
			return string.Empty;
		}
		return this.EneName[no];
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00073AB1 File Offset: 0x00071CB1
	public virtual int GetEneNAtkParam(int no, int menu)
	{
		if (no < 0 || no >= 6)
		{
			return 0;
		}
		if (menu < 0 || menu >= 6)
		{
			return 0;
		}
		return this.EneNAtkParam[no][menu];
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00073AD1 File Offset: 0x00071CD1
	public virtual int GetEneSAtkParam(int no, int menu)
	{
		if (no < 0 || no >= 8)
		{
			return 0;
		}
		if (menu < 0 || menu >= 7)
		{
			return 0;
		}
		return this.EneSAtkParam[no][menu];
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00073AF1 File Offset: 0x00071CF1
	public virtual string GetEneSAtkExp(int no, int menu)
	{
		if (no < 0 || no >= 8)
		{
			return string.Empty;
		}
		if (menu < 0 || menu >= 4)
		{
			return string.Empty;
		}
		return this.EneSAtkExp[no][menu];
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00073B1C File Offset: 0x00071D1C
	public virtual void BattleInit()
	{
		this.SetLoading(true);
		this.eneimg = new Image[6];
		this.readbuf = this.GetResource2(14);
		int num;
		int num2;
		for (int i = 0; i < 6; i++)
		{
			int[] archive = XenoPP03Canvas.GetArchive2(this.readbuf, i);
			num = archive[0];
			num2 = archive[1];
			this.eneimg[i] = this.BuildImage(this.readbuf, num, num2);
		}
		if ((7 <= this.mapno && this.mapno <= 14) || this.mapno == 24)
		{
			this.readbuf = this.GetResource2(2);
		}
		else if (this.mapno != 24)
		{
			this.readbuf = this.GetResource2(3);
		}
		int[] archive2 = XenoPP03Canvas.GetArchive2(this.readbuf, 0);
		num = archive2[0];
		num2 = archive2[1];
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
			this.EnemySet(1);
		}
		else if (this.battleno == 1)
		{
			this.EnemySet(2);
		}
		else if (this.battleno >= 4 && this.battleno <= 11)
		{
			this.EnemySet(4);
		}
		else if (7 <= this.mapno && this.mapno <= 14)
		{
			this.EnemySet(0);
		}
		else
		{
			this.EnemySet(3);
		}
		this.BattleRedrawClear();
		this.BattleRedrawNClear();
		this.nextmenup = 0;
		for (int i = 0; i < 4; i++)
		{
			this.nextmenu[i] = -1;
		}
		this.StopAllSound();
		if (this.battleno == 0 || this.battleno == 1)
		{
			this.SetBgm(3);
		}
		else
		{
			this.SetBgm(2);
		}
		this.PlayBgm();
		this.KeyClear();
		this.SetSeqNo(3);
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00073D68 File Offset: 0x00071F68
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
						this.work[8] = 51;
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
							this.work[8] = 39;
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
			if (this.work[1] == 1)
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
						this.work[8] = 39;
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
				if (this.work[8] == 51)
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

	// Token: 0x060005F6 RID: 1526 RVA: 0x00076E0C File Offset: 0x0007500C
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

	// Token: 0x060005F7 RID: 1527 RVA: 0x00076F4C File Offset: 0x0007514C
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

	// Token: 0x060005F8 RID: 1528 RVA: 0x000770AC File Offset: 0x000752AC
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

	// Token: 0x060005F9 RID: 1529 RVA: 0x00077210 File Offset: 0x00075410
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

	// Token: 0x060005FA RID: 1530 RVA: 0x00077338 File Offset: 0x00075538
	public virtual void PlayNAtkSe()
	{
		int num = this.GetGtw(0);
		int num2 = this.nowmenu;
		if (num == 0)
		{
			if (num2 == 3)
			{
				this.PlaySe(19);
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
				this.PlaySe(20);
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
					this.PlaySe(18);
					return;
				}
				if (num2 == 3)
				{
					this.PlaySe(17);
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
					this.PlaySe(20);
					return;
				}
				if (num2 == 4)
				{
					this.PlaySe(17);
					return;
				}
				if (num2 == 5)
				{
					this.PlaySe(19);
				}
			}
			return;
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0007741C File Offset: 0x0007561C
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

	// Token: 0x060005FC RID: 1532 RVA: 0x00077470 File Offset: 0x00075670
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

	// Token: 0x060005FD RID: 1533 RVA: 0x00077570 File Offset: 0x00075770
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

	// Token: 0x060005FE RID: 1534 RVA: 0x00077670 File Offset: 0x00075870
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

	// Token: 0x060005FF RID: 1535 RVA: 0x000776F2 File Offset: 0x000758F2
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

	// Token: 0x06000600 RID: 1536 RVA: 0x00077719 File Offset: 0x00075919
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

	// Token: 0x06000601 RID: 1537 RVA: 0x0007773C File Offset: 0x0007593C
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
					this.PlaySe(20);
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

	// Token: 0x06000602 RID: 1538 RVA: 0x000777CC File Offset: 0x000759CC
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

	// Token: 0x06000603 RID: 1539 RVA: 0x0007783C File Offset: 0x00075A3C
	public virtual int GetSpAttackRoutineMax(int id, int menu)
	{
		int plySAtkParam = this.GetPlySAtkParam(id, menu, 11);
		return this.PlySAtkEffMax[plySAtkParam];
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x0007785C File Offset: 0x00075A5C
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

	// Token: 0x06000605 RID: 1541 RVA: 0x000778D1 File Offset: 0x00075AD1
	public virtual int GetNowSlot()
	{
		return this.bslot[this.bslotno];
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x000778E0 File Offset: 0x00075AE0
	public virtual void SetBattleMenuStackDelete()
	{
		this.nextmenup = 0;
		for (int i = 0; i < 4; i++)
		{
			this.nextmenu[i] = -1;
		}
		this.nmwait = -1;
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00077910 File Offset: 0x00075B10
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

	// Token: 0x06000608 RID: 1544 RVA: 0x0007794C File Offset: 0x00075B4C
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

	// Token: 0x06000609 RID: 1545 RVA: 0x000779A0 File Offset: 0x00075BA0
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

	// Token: 0x0600060A RID: 1546 RVA: 0x000779FC File Offset: 0x00075BFC
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

	// Token: 0x0600060B RID: 1547 RVA: 0x00077CD4 File Offset: 0x00075ED4
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

	// Token: 0x0600060C RID: 1548 RVA: 0x00077D64 File Offset: 0x00075F64
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

	// Token: 0x0600060D RID: 1549 RVA: 0x00077DDC File Offset: 0x00075FDC
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

	// Token: 0x0600060E RID: 1550 RVA: 0x00077F08 File Offset: 0x00076108
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

	// Token: 0x0600060F RID: 1551 RVA: 0x0007801C File Offset: 0x0007621C
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

	// Token: 0x06000610 RID: 1552 RVA: 0x0007805C File Offset: 0x0007625C
	public virtual void AglWait2(int id, int num)
	{
		int num2 = this.GetStatus(id, 24);
		num2 += num;
		this.SetStatus(id, 24, num2);
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x00078081 File Offset: 0x00076281
	public virtual void AglWaitClear(int id)
	{
		this.SetStatus(id, 24, 0);
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x00078090 File Offset: 0x00076290
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

	// Token: 0x06000613 RID: 1555 RVA: 0x0007826C File Offset: 0x0007646C
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

	// Token: 0x06000614 RID: 1556 RVA: 0x0007837C File Offset: 0x0007657C
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

	// Token: 0x06000615 RID: 1557 RVA: 0x00078548 File Offset: 0x00076748
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

	// Token: 0x06000616 RID: 1558 RVA: 0x00078718 File Offset: 0x00076918
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
					if (this.GetStatus(num2, 20) == 1 && this.GetStatus(num2, 0) + 1 < 30)
					{
						num = this.work[0] * 75 / 100;
						int num3 = this.GetStatus(num2, 14) + num;
						this.SetStatus(num2, 14, num3);
						num3 = this.GetStatus(num2, 15) - num;
						this.SetStatus(num2, 15, num3);
						do
						{
							if (this.GetStatus(num2, 15) <= 0 && this.GetStatus(num2, 0) + 1 < 30)
							{
								this.work[19 + num2]++;
								num = this.GetStatus(num2, 15) * -1;
								this.SetLevelStatus(num2, this.GetStatus(num2, 0) + 1);
								if (this.GetStatus(num2, 0) + 1 < 30)
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
				this.PlaySe(15);
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
					if (this.work[0] > 0 && this.GetStatus(num2, 0) + 1 < 30)
					{
						int num3 = this.GetStatus(num2, 14) + 1;
						this.SetStatus(num2, 14, num3);
						num3 = this.GetStatus(num2, 15) - 1;
						this.SetStatus(num2, 15, num3);
					}
					if (this.GetStatus(num2, 15) <= 0 && this.GetStatus(num2, 0) + 1 < 30)
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
							if (this.GetStatus(num2, 0) + 1 < 30)
							{
								int num3 = this.GetStatus(num2, 14) + 1;
								this.SetStatus(num2, 14, num3);
								num3 = this.GetStatus(num2, 15) - 1;
								this.SetStatus(num2, 15, num3);
							}
							if (this.GetStatus(num2, 15) <= 0 && this.GetStatus(num2, 0) + 1 < 30)
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

	// Token: 0x06000617 RID: 1559 RVA: 0x00078FB0 File Offset: 0x000771B0
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

	// Token: 0x06000618 RID: 1560 RVA: 0x0007903C File Offset: 0x0007723C
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

	// Token: 0x06000619 RID: 1561 RVA: 0x00079074 File Offset: 0x00077274
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

	// Token: 0x0600061A RID: 1562 RVA: 0x00079248 File Offset: 0x00077448
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
				this.PlaySe(16);
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

	// Token: 0x0600061B RID: 1563 RVA: 0x00079308 File Offset: 0x00077508
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

	// Token: 0x0600061C RID: 1564 RVA: 0x000794F0 File Offset: 0x000776F0
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

	// Token: 0x0600061D RID: 1565 RVA: 0x00079594 File Offset: 0x00077794
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

	// Token: 0x0600061E RID: 1566 RVA: 0x00079630 File Offset: 0x00077830
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

	// Token: 0x0600061F RID: 1567 RVA: 0x000796AC File Offset: 0x000778AC
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

	// Token: 0x06000620 RID: 1568 RVA: 0x00079834 File Offset: 0x00077A34
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

	// Token: 0x06000621 RID: 1569 RVA: 0x000799FC File Offset: 0x00077BFC
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

	// Token: 0x06000622 RID: 1570 RVA: 0x00079D20 File Offset: 0x00077F20
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

	// Token: 0x06000623 RID: 1571 RVA: 0x00079FF0 File Offset: 0x000781F0
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

	// Token: 0x06000624 RID: 1572 RVA: 0x0007A058 File Offset: 0x00078258
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

	// Token: 0x06000625 RID: 1573 RVA: 0x0007A110 File Offset: 0x00078310
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

	// Token: 0x06000626 RID: 1574 RVA: 0x0007A1C8 File Offset: 0x000783C8
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

	// Token: 0x06000627 RID: 1575 RVA: 0x0007A238 File Offset: 0x00078438
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

	// Token: 0x06000628 RID: 1576 RVA: 0x0007A2A8 File Offset: 0x000784A8
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

	// Token: 0x06000629 RID: 1577 RVA: 0x0007A314 File Offset: 0x00078514
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

	// Token: 0x0600062A RID: 1578 RVA: 0x0007A358 File Offset: 0x00078558
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

	// Token: 0x0600062B RID: 1579 RVA: 0x0007A3D4 File Offset: 0x000785D4
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

	// Token: 0x0600062C RID: 1580 RVA: 0x0007A450 File Offset: 0x00078650
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

	// Token: 0x0600062D RID: 1581 RVA: 0x0007A4BC File Offset: 0x000786BC
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

	// Token: 0x0600062E RID: 1582 RVA: 0x0007A50C File Offset: 0x0007870C
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

	// Token: 0x0600062F RID: 1583 RVA: 0x0007A55C File Offset: 0x0007875C
	public virtual int GetHitRate(int id, int id2, int hit)
	{
		int dex = this.GetDex(id);
		int num = this.GetRand(-10, 10);
		int eva = this.GetEva(id2);
		return hit + dex + num - eva;
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x0007A58B File Offset: 0x0007878B
	public virtual void SetStatusAbnormal(int id, int st_ab, int turn)
	{
		if (id < 4)
		{
			this.st_ab[id][st_ab] = turn;
			return;
		}
		this.est_ab[id - 4][st_ab] = turn;
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0007A5AA File Offset: 0x000787AA
	public virtual void CancelStatusAbnormal(int id, int st_ab)
	{
		if (id < 4)
		{
			this.st_ab[id][st_ab] = 0;
			return;
		}
		this.est_ab[id - 4][st_ab] = 0;
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0007A5C9 File Offset: 0x000787C9
	public virtual bool IsStatusAbnormal(int id, int st_ab)
	{
		if (id < 4)
		{
			return this.st_ab[id][st_ab] != 0;
		}
		return this.est_ab[id - 4][st_ab] != 0;
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0007A5F0 File Offset: 0x000787F0
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

	// Token: 0x06000634 RID: 1588 RVA: 0x0007A628 File Offset: 0x00078828
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

	// Token: 0x06000635 RID: 1589 RVA: 0x0007A65D File Offset: 0x0007885D
	public virtual int IsGuard(int id)
	{
		if (id < 4)
		{
			return this.GetStatus(id, 18);
		}
		return this.GetEnemyStatus(id - 4, 39);
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x0007A678 File Offset: 0x00078878
	public virtual void SetGuard(int id, int g)
	{
		if (id < 4)
		{
			this.SetStatus(id, 18, g);
			return;
		}
		this.SetEnemyStatus(id - 4, 39, g);
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0007A698 File Offset: 0x00078898
	public virtual void SetMapPlayerChar(int id)
	{
		int num = 1;
		if (id >= 4)
		{
			return;
		}
		if (0 <= this.mapno && this.mapno <= 6)
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
					this.chc = 42;
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

	// Token: 0x06000638 RID: 1592 RVA: 0x0007A714 File Offset: 0x00078914
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
			if (this.mapno == 1)
			{
				this.SetMenu(6);
			}
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
			}
			if (this.mapno == 1 && this.ismenu[1] && this.xscr.sc_skipadr != 65535 && this.xscr.sc_skipadr > this.xscr.script_adr)
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
				this.window_cnt = 0;
				this.window_flg = false;
				this.xscr.sc_face = 255;
			}
			if (this.xscr.sc_flg[14] == 1)
			{
				this.miflag[7][0] = true;
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

	// Token: 0x06000639 RID: 1593 RVA: 0x0007C414 File Offset: 0x0007A614
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

	// Token: 0x0600063A RID: 1594 RVA: 0x0007C4C0 File Offset: 0x0007A6C0
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

	// Token: 0x0600063B RID: 1595 RVA: 0x0007C670 File Offset: 0x0007A870
	public virtual void VisualRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.StopVib();
			this.MenuFlagClear();
			this.isupdate = true;
			this.xscr.ScriptInit();
			this.StartFade(2);
			this.SetMenu(6);
			if (this.visualno == 1)
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
					this.StartFade(1);
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
				if (this.nowvno == 1)
				{
					this.mapno = 3;
					this.SetSeqNo(6);
					return;
				}
				if (this.nowvno == 8)
				{
					this.SetSeqNo(15);
					return;
				}
				this.SetSeqNo(10);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0007C894 File Offset: 0x0007AA94
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

	// Token: 0x0600063D RID: 1597 RVA: 0x0007C9C4 File Offset: 0x0007ABC4
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
				else if (this.cur[0] == 2)
				{
					this.StartFade(1, 32);
					this.SetSeqStep(6);
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
				this.visualno = 0;
				this.SetSeqNo(8);
				if (StApplication.GetCurrentApp().GetParameter("PP0" + 2.ToString()) != null)
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
				return;
			}
			break;
		case 6:
			if (this.IsFade() == 3)
			{
				this.isupdate = false;
				this.titleimg = null;
				this.SetSeqNo(22);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x0007CCA0 File Offset: 0x0007AEA0
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

	// Token: 0x0600063F RID: 1599 RVA: 0x0007CD58 File Offset: 0x0007AF58
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

	// Token: 0x06000640 RID: 1600 RVA: 0x0007CEEC File Offset: 0x0007B0EC
	public virtual void ClearSaveRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.StopAllSound();
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
			if ((this.id_edge & 4112) != 0)
			{
				this.work[0] = 0;
				this.ismenu[0] = false;
				this.ismenu[1] = false;
				this.SetMenu(9);
				this.SetSeqStep(4);
				return;
			}
			break;
		case 3:
			this.work[0]++;
			if (this.work[0] >= 2)
			{
				this.WorkClear();
				if (!this.XenoClearSave())
				{
					this.ismenu[0] = false;
					this.ismenu[1] = false;
					this.SetMenu(9);
					this.SetSeqStep(5);
					return;
				}
				this.SetSeqStep(6);
				return;
			}
			break;
		case 4:
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
				this.SetSeqStep(7);
				return;
			}
			break;
		case 5:
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
				this.SetSeqStep(7);
				return;
			}
			break;
		case 6:
			this.work[0]++;
			if (this.work[0] >= 120 || (this.id_edge & 4112) != 0)
			{
				this.WorkClear();
				this.StartFade(1, 32);
				this.SetSeqStep(7);
				return;
			}
			break;
		case 7:
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

	// Token: 0x06000641 RID: 1601 RVA: 0x0007D0E8 File Offset: 0x0007B2E8
	public virtual void ClearSendRoutine()
	{
		switch (this.GetSeqStep())
		{
		case 0:
			this.MenuFlagClear();
			this.StopAllSound();
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
			if ((this.id_edge & 4112) != 0)
			{
				this.work[0] = 0;
				this.ismenu[0] = false;
				this.ismenu[1] = false;
				this.SetMenu(9);
				this.SetSeqStep(4);
				return;
			}
			break;
		case 3:
			this.work[0]++;
			if (this.work[0] >= 2)
			{
				this.WorkClear();
				if (this.XenoClearSend() == 1)
				{
					this.SetSeqStep(5);
					return;
				}
				this.ismenu[0] = false;
				this.ismenu[1] = false;
				this.SetMenu(9);
				this.SetSeqStep(6);
				return;
			}
			break;
		case 4:
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
				this.SetSeqStep(7);
				return;
			}
			break;
		case 5:
			if ((this.id_edge & 4112) != 0)
			{
				this.MenuFlagClear();
				this.SetMenu(4);
				this.StartFade(1, 32);
				this.SetSeqStep(7);
				return;
			}
			break;
		case 6:
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
				this.SetSeqStep(7);
				return;
			}
			break;
		case 7:
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

	// Token: 0x06000642 RID: 1602 RVA: 0x0007D2D0 File Offset: 0x0007B4D0
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
				this.visualno = 0;
				this.SetSeqNo(8);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x0007D43C File Offset: 0x0007B63C
	public virtual void HelpInit()
	{
		sbyte[] array = new sbyte[50];
		int num = (new int[]
		{
			0, 337, 613, 1300, 2945, 3034, 3177, 3310, 4357, 4860,
			4979, 5382, 5783, 6352, 7030, 8436, 8801, 9691, 10442, 10708,
			11025, 11304, 11593, 11751
		})[this.helpno];
		for (int i = 0; i < 50; i++)
		{
			array[i] = 0;
		}
		sbyte[] resource = this.GetResource2(16);
		for (int i = 0; i < 66; i++)
		{
			this.mmstr[i] = string.Empty;
			this.mmenu[i] = 255;
		}
		this.mmenup = ((int)resource[num] + 256) & 255;
		for (int i = 0; i < this.mmenup; i++)
		{
			int num2 = ((int)resource[i * 4 + 1 + num] + 256) & 255;
			int num3 = (int)XenoPP03Canvas.ArrayShort(resource, i * 4 + 2 + num);
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

	// Token: 0x06000644 RID: 1604 RVA: 0x0007D5FC File Offset: 0x0007B7FC
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

	// Token: 0x06000645 RID: 1605 RVA: 0x0007D888 File Offset: 0x0007BA88
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

	// Token: 0x06000646 RID: 1606 RVA: 0x0007D980 File Offset: 0x0007BB80
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

	// Token: 0x06000647 RID: 1607 RVA: 0x0007DA58 File Offset: 0x0007BC58
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

	// Token: 0x06000648 RID: 1608 RVA: 0x0007DAA4 File Offset: 0x0007BCA4
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
			if (this.mapno == 4)
			{
				this.xscr.npc_mv[id] = this.GetRand(1, 3);
			}
			this.xscr.npc_wk[id][0] = this.GetRand(8, 16);
			this.xscr.npc_wk[id][1] = 0;
			if (this.xscr.npc_mv[id] == 1)
			{
				this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
				if (mv == 2)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32770;
				}
				else if (mv == 3)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 2;
				}
				else if (mv == 4)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 5;
				}
				else if (mv == 5)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0];
				}
				if (this.mapno == 4)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 5;
					return;
				}
			}
			else if (this.xscr.npc_mv[id] == 2)
			{
				if (this.xscr.npc_xy[id][0] <= this.xscr.npc_xy[id][2] - 16)
				{
					this.xscr.npc_mv[id] = 1;
					this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
				}
				this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 32770;
				if (this.mapno == 4)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 5;
					return;
				}
			}
			else if (this.xscr.npc_mv[id] == 3)
			{
				if (this.xscr.npc_xy[id][0] >= this.xscr.npc_xy[id][2] + 16)
				{
					this.xscr.npc_mv[id] = 1;
					this.xscr.npc_wk[id][0] += this.GetRand(8, 16);
				}
				this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 2;
				if (this.mapno == 4)
				{
					this.xscr.npc_pn[id][1] = this.xscr.npc_pn[id][0] + 5;
					return;
				}
			}
			else
			{
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

	// Token: 0x06000649 RID: 1609 RVA: 0x0007E4FC File Offset: 0x0007C6FC
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

	// Token: 0x0600064A RID: 1610 RVA: 0x0007E8F4 File Offset: 0x0007CAF4
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
				if (this.xscr.tobj_cno[i] == 255 || (this.xscr.tobj_cno[i] == 2 && (this.chc == 28 || this.chc == 35)) || (this.xscr.tobj_cno[i] == 3 && this.chc == 42))
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

	// Token: 0x0600064B RID: 1611 RVA: 0x0007EB58 File Offset: 0x0007CD58
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

	// Token: 0x0600064C RID: 1612 RVA: 0x0007EBD0 File Offset: 0x0007CDD0
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

	// Token: 0x0600064D RID: 1613 RVA: 0x0007F160 File Offset: 0x0007D360
	public virtual void TouchObjCheck(int cond)
	{
		if (this.mmenuflag)
		{
			this.mmenuflag = false;
			return;
		}
		int num = this.chx;
		int num2 = this.chy;
		int i = 0;
		while (i < this.xscr.tobj_p)
		{
			int num3 = this.xscr.tobj_xy[i][0];
			int num4 = this.xscr.tobj_xy[i][1];
			if ((this.xscr.tobj_cnd[i] == 6 || this.xscr.tobj_cnd[i] == 0 || this.xscr.tobj_cnd[i] == cond) && num3 <= num && num <= num3 + 16 && num4 <= num2 && num2 <= num4 + 16)
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
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0007F26C File Offset: 0x0007D46C
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

	// Token: 0x0600064F RID: 1615 RVA: 0x0007F474 File Offset: 0x0007D674
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

	// Token: 0x06000650 RID: 1616 RVA: 0x0007F4D8 File Offset: 0x0007D6D8
	public virtual int GetPngWidth(int no)
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
			return this.vimg[num].GetWidth();
		}
		else
		{
			if (num >= this.mcimgmax)
			{
				return 0;
			}
			return this.mcimg[num].GetWidth();
		}
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0007F53C File Offset: 0x0007D73C
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

	// Token: 0x06000652 RID: 1618 RVA: 0x0007F7E0 File Offset: 0x0007D9E0
	public virtual void DrawTalk2(StGraphics g)
	{
		if (this.xscr.IsMessageEnd2())
		{
			for (int i = 0; i < this.xscr.sc_strl; i++)
			{
				this.SetColor(g, 16777215);
				this.DrawString(g, this.xscr.sc_str[i], 2, this.xscr.sc_stry[i], 0);
			}
		}
		else if (this.xscr.IsMessage2())
		{
			for (int i = 0; i < this.xscr.sc_strl - 1; i++)
			{
				this.SetColor(g, 16777215);
				this.DrawString(g, this.xscr.sc_str[i], 2, this.xscr.sc_stry[i], 0);
			}
			string text = StString.Substring(this.xscr.sc_str[this.xscr.sc_strl - 1], 0, this.xscr.sc_wk[2]);
			this.SetColor(g, 16777215);
			this.DrawString(g, text, 2, this.xscr.sc_stry[this.xscr.sc_strl - 1], 0);
		}
		if (this.xscr.IsMessageEnd4())
		{
			int num = this.xscr.sc_stry[this.xscr.sc_strl - 1] + 12;
			g.DrawImage(this.sysimg[43], 230, num + this.sync % 4);
		}
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0007F93F File Offset: 0x0007DB3F
	protected internal virtual void SetArrayByte(sbyte[] data, int ofs, sbyte num)
	{
		data[ofs] = num;
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0007F945 File Offset: 0x0007DB45
	protected internal virtual void SetArrayInt(sbyte[] data, int ofs, int num)
	{
		data[ofs] = (sbyte)((num >> 24) & 255);
		data[ofs + 1] = (sbyte)((num >> 16) & 255);
		data[ofs + 2] = (sbyte)((num >> 8) & 255);
		data[ofs + 3] = (sbyte)(num & 255);
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0007F984 File Offset: 0x0007DB84
	protected internal virtual void XenoSave()
	{
		sbyte[] array = this.XenoSaveDataCreate();
		this.StoreRecords(52, array, array.Length);
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0007F9A8 File Offset: 0x0007DBA8
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
		this.SetArrayInt(array, num, 2);
		num += 4;
		return array;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0007FD08 File Offset: 0x0007DF08
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
			this.SetRanks(i, XenoPP03Canvas.ArrayInt(array, num));
			num += 4;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 26; j++)
			{
				this.SetStatus(i, j, XenoPP03Canvas.ArrayInt(array, num));
				num += 4;
			}
		}
		this.mapno = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.mapx = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.mapy = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.chm = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.chc = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.chx = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.chy = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		for (int i = 0; i < 66; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				this.itempc[i][j] = XenoPP03Canvas.ArrayInt(array, num);
				num += 4;
			}
		}
		for (int i = 0; i < 80; i++)
		{
			this.xscr.sc_flg[i] = XenoPP03Canvas.ArrayInt(array, num);
			num += 4;
		}
		if (this.xscr.sc_flg[14] == 1)
		{
			this.miflag[7][0] = true;
		}
		this.rev_mapno = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_mapx = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_mapy = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_chx = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.rev_chy = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0007FEB0 File Offset: 0x0007E0B0
	protected internal static int LoadRecord(int id)
	{
		Type typeFromHandle = typeof(XenoPP03Canvas);
		int num2;
		lock (typeFromHandle)
		{
			int num = 0;
			try
			{
				string text = "pos=" + id.ToString();
				DataInputStream dataInputStream = Connector.OpenDataInputStream("scratchpad:///11;" + text);
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

	// Token: 0x06000659 RID: 1625 RVA: 0x0007FF34 File Offset: 0x0007E134
	protected internal virtual sbyte[] LoadRecords(int id, int len)
	{
		sbyte[] array3;
		lock (this)
		{
			sbyte[] array = null;
			try
			{
				string text = "pos=" + id.ToString();
				InputStream inputStream = Connector.OpenDataInputStream("scratchpad:///11;" + text);
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

	// Token: 0x0600065A RID: 1626 RVA: 0x0007FFFC File Offset: 0x0007E1FC
	protected internal static void StoreRecord(int id, int val)
	{
		Type typeFromHandle = typeof(XenoPP03Canvas);
		lock (typeFromHandle)
		{
			try
			{
				string text = "pos=" + id.ToString();
				DataOutputStream dataOutputStream = Connector.OpenDataOutputStream("scratchpad:///11;" + text);
				dataOutputStream.WriteInt(val);
				dataOutputStream.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x00080078 File Offset: 0x0007E278
	protected internal void StoreRecords(int id, sbyte[] data, int len)
	{
		Type typeFromHandle = typeof(XenoPP03Canvas);
		lock (typeFromHandle)
		{
			this.saflag = false;
			try
			{
				string text = "pos=" + id.ToString();
				OutputStream outputStream = Connector.OpenOutputStream("scratchpad:///11;" + text);
				outputStream.Write(data, 0, len);
				outputStream.Close();
			}
			catch (Exception)
			{
				this.saflag = true;
			}
		}
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x00080104 File Offset: 0x0007E304
	protected internal virtual void ExistSaveData()
	{
		if (XenoPP03Canvas.ArrayInt(this.LoadRecords(20, 24), 20) == 1)
		{
			this.LoadOptionData();
			this.ResetConfig();
			return;
		}
		this.SaveOptionData();
		this.XenoSave();
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x00080134 File Offset: 0x0007E334
	protected internal virtual void LoadOptionData()
	{
		int num = 0;
		sbyte[] array = this.LoadRecords(20, 24);
		for (int i = 0; i < 4; i++)
		{
			this.config[i] = XenoPP03Canvas.ArrayInt(array, num);
			num += 4;
		}
		this.sdflag = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
		this.opflag = XenoPP03Canvas.ArrayInt(array, num);
		num += 4;
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x00080190 File Offset: 0x0007E390
	protected internal virtual void SaveOptionData()
	{
		this.opflag = 1;
		sbyte[] array = this.XenoOptionDataCreate();
		this.StoreRecords(20, array, array.Length);
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x000801BC File Offset: 0x0007E3BC
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

	// Token: 0x06000660 RID: 1632 RVA: 0x00080229 File Offset: 0x0007E429
	public virtual void SetRevivePoint()
	{
		this.rev_mapno = this.mapno;
		this.rev_mapx = this.mapx;
		this.rev_mapy = this.mapy;
		this.rev_chx = this.chx;
		this.rev_chy = this.chy;
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x00080268 File Offset: 0x0007E468
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

	// Token: 0x06000662 RID: 1634 RVA: 0x000802C0 File Offset: 0x0007E4C0
	protected internal virtual bool XenoClearSave()
	{
		try
		{
			sbyte[] array = this.XenoClearDataCreate();
			this.StoreRecords(1422, array, array.Length);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x00080300 File Offset: 0x0007E500
	protected internal virtual sbyte[] XenoClearDataCreate()
	{
		sbyte[] array = new sbyte[120];
		int num = 0;
		for (int i = 0; i < 120; i++)
		{
			array[i] = 0;
		}
		this.cdflag = 1;
		array[num++] = 1;
		for (int i = 0; i < 4; i++)
		{
			array[num++] = (sbyte)this.GetStatus(i, 0);
			this.SetArrayInt(array, num, this.GetStatus(i, 14));
			num += 4;
			this.SetArrayInt(array, num, this.GetStatus(i, 15));
			num += 4;
			array[num++] = (sbyte)this.GetStatus(i, 21);
			array[num++] = (sbyte)this.GetStatus(i, 22);
		}
		for (int i = 0; i < 63; i++)
		{
			array[num++] = (sbyte)this.itempc[i][0];
		}
		return array;
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x000803BF File Offset: 0x0007E5BF
	protected internal virtual bool ExistClearData()
	{
		if (this.LoadRecords(1422, 1)[0] == 1)
		{
			this.cdflag = 1;
			return true;
		}
		return false;
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x000803DC File Offset: 0x0007E5DC
	protected internal virtual int XenoClearSend()
	{
		string[] array = new string[3];
		array[0] = "3";
		array[1] = "PP0" + 3.ToString();
		array[2] = string.Empty + this.XenoStrClearDataCreate();
		try
		{
			StApplication.GetCurrentApp().Launch(3, array);
		}
		catch (SecurityException)
		{
			return 1;
		}
		catch (Exception)
		{
			return 2;
		}
		return 0;
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x00080458 File Offset: 0x0007E658
	protected internal virtual string XenoStrClearDataCreate()
	{
		string text = string.Empty;
		int num = 0;
		sbyte[] array = this.LoadRecords(1422, 120);
		num++;
		for (int i = 0; i < 4; i++)
		{
			int num2 = (int)array[num++];
			if (num2 < 10)
			{
				text = text + "0" + num2.ToString();
			}
			else
			{
				text += num2.ToString();
			}
			num2 = XenoPP03Canvas.ArrayInt(array, num);
			num += 4;
			if (num2 >= 100000)
			{
				text += num2.ToString();
			}
			else if (num2 >= 10000)
			{
				text = text + "0" + num2.ToString();
			}
			else if (num2 >= 1000)
			{
				text = text + "00" + num2.ToString();
			}
			else if (num2 >= 100)
			{
				text = text + "000" + num2.ToString();
			}
			else if (num2 >= 10)
			{
				text = text + "0000" + num2.ToString();
			}
			else
			{
				text = text + "00000" + num2.ToString();
			}
			num2 = XenoPP03Canvas.ArrayInt(array, num);
			num += 4;
			if (num2 >= 10000)
			{
				text += num2.ToString();
			}
			else if (num2 >= 1000)
			{
				text = text + "0" + num2.ToString();
			}
			else if (num2 >= 100)
			{
				text = text + "00" + num2.ToString();
			}
			else if (num2 >= 10)
			{
				text = text + "000" + num2.ToString();
			}
			else
			{
				text = text + "0000" + num2.ToString();
			}
			text += array[num++].ToString();
			text += array[num++].ToString();
		}
		for (int i = 0; i < 63; i++)
		{
			int num2 = (int)array[num++];
			if (num2 < 10)
			{
				text = text + "0" + num2.ToString();
			}
			else
			{
				text += num2.ToString();
			}
		}
		return text;
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x00080664 File Offset: 0x0007E864
	protected internal virtual void XenoClearLoad()
	{
		int num = 0;
		string parameter;
		try
		{
			parameter = StApplication.GetCurrentApp().GetParameter("PP0" + 2.ToString());
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
		this.AddItem(0, 5);
		this.AddItem(1, 5);
		this.AddItem(4, 5);
		this.AddItem(15, 5);
		this.AddItem(16, 3);
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x000807AC File Offset: 0x0007E9AC
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
		if (fid == 64)
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
			InputStream inputStream = Connector.OpenDataInputStream("scratchpad:///11;pos=" + num.ToString() + ",length=" + num3.ToString());
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

	// Token: 0x06000669 RID: 1641 RVA: 0x000808F0 File Offset: 0x0007EAF0
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

	// Token: 0x0600066A RID: 1642 RVA: 0x000809DC File Offset: 0x0007EBDC
	private bool SaveIntSP(int val, int offset)
	{
		try
		{
			DataOutputStream dataOutputStream = Connector.OpenDataOutputStream("scratchpad:///11;pos=" + offset.ToString());
			dataOutputStream.WriteInt(val);
			dataOutputStream.Close();
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x00080A28 File Offset: 0x0007EC28
	private int LoadIntSP(int offset)
	{
		int num;
		try
		{
			DataInputStream dataInputStream = Connector.OpenDataInputStream("scratchpad:///11;pos=" + offset.ToString());
			num = dataInputStream.ReadInt();
			dataInputStream.Close();
		}
		catch (Exception)
		{
			return 0;
		}
		return num;
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x00080A74 File Offset: 0x0007EC74
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

	// Token: 0x0600066D RID: 1645 RVA: 0x00080B00 File Offset: 0x0007ED00
	private void DrawUserCheck(StGraphics g)
	{
		this.SetColor(g, 0);
		this.FillRect(g, 0, 0, this.GetWidth(), this.GetHeight());
		this.SetColor(g, 16777215);
		if (XenoPP03Canvas.auth_ret == 100 || XenoPP03Canvas.auth_ret == 1)
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
			this.DrawString(g, array[XenoPP03Canvas.auth_ret + 1][i], 12, 90 + i * 15, 0);
		}
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x00080C2C File Offset: 0x0007EE2C
	private void AutoUpData()
	{
		StApplication.GetCurrentApp().Launch(2, null);
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x00080C3A File Offset: 0x0007EE3A
	private void GameEnd()
	{
		StApplication.GetCurrentApp().Terminate();
	}

	// Token: 0x0400034C RID: 844
	protected internal static int auth_ret = 100;

	// Token: 0x0400034D RID: 845
	protected internal XenoPP03Canvas self;

	// Token: 0x0400034E RID: 846
	public XenoPP03 parent;

	// Token: 0x0400034F RID: 847
	protected internal XScript03 xscr;

	// Token: 0x04000350 RID: 848
	protected internal bool saflag;

	// Token: 0x04000351 RID: 849
	protected internal int inputedg;

	// Token: 0x04000352 RID: 850
	protected internal int inputsep;

	// Token: 0x04000353 RID: 851
	private int id_back;

	// Token: 0x04000354 RID: 852
	protected internal int id_data;

	// Token: 0x04000355 RID: 853
	public int id_edge;

	// Token: 0x04000356 RID: 854
	protected internal int id_sepr;

	// Token: 0x04000357 RID: 855
	public int id_rept;

	// Token: 0x04000358 RID: 856
	private int id_count;

	// Token: 0x04000359 RID: 857
	private int id_rwait;

	// Token: 0x0400035A RID: 858
	protected internal int id_rmask = -1;

	// Token: 0x0400035B RID: 859
	protected internal int id_delay = 6;

	// Token: 0x0400035C RID: 860
	protected internal int id_speed;

	// Token: 0x0400035D RID: 861
	public bool red;

	// Token: 0x0400035E RID: 862
	protected internal bool sysred;

	// Token: 0x0400035F RID: 863
	public bool compred;

	// Token: 0x04000360 RID: 864
	public bool scrcompred;

	// Token: 0x04000361 RID: 865
	protected internal bool maploopred;

	// Token: 0x04000362 RID: 866
	protected internal bool maploopstop;

	// Token: 0x04000363 RID: 867
	protected internal int maploopwait;

	// Token: 0x04000364 RID: 868
	public bool isloading;

	// Token: 0x04000365 RID: 869
	public bool isupdate;

	// Token: 0x04000366 RID: 870
	protected internal bool msg_isactive;

	// Token: 0x04000367 RID: 871
	protected internal bool msg_isfinish;

	// Token: 0x04000368 RID: 872
	protected internal Random rand;

	// Token: 0x04000369 RID: 873
	protected internal StFont sfont;

	// Token: 0x0400036A RID: 874
	protected internal StFont lfont;

	// Token: 0x0400036B RID: 875
	protected internal int lfHeight;

	// Token: 0x0400036C RID: 876
	protected internal int nowfont;

	// Token: 0x0400036D RID: 877
	protected internal int sync;

	// Token: 0x0400036E RID: 878
	public int quf;

	// Token: 0x0400036F RID: 879
	public int qux;

	// Token: 0x04000370 RID: 880
	public int quy;

	// Token: 0x04000371 RID: 881
	protected internal int[] fade;

	// Token: 0x04000372 RID: 882
	public int lasf;

	// Token: 0x04000373 RID: 883
	public int lasw;

	// Token: 0x04000374 RID: 884
	private int[] config;

	// Token: 0x04000375 RID: 885
	private int fps;

	// Token: 0x04000376 RID: 886
	private int fps_cnt;

	// Token: 0x04000377 RID: 887
	private long fps_ot;

	// Token: 0x04000378 RID: 888
	private long fps_nt;

	// Token: 0x04000379 RID: 889
	private bool fps_disp;

	// Token: 0x0400037A RID: 890
	private int fps_wait = 30;

	// Token: 0x0400037B RID: 891
	public int mapno;

	// Token: 0x0400037C RID: 892
	private Image[] sysimg;

	// Token: 0x0400037D RID: 893
	private int[] vib;

	// Token: 0x0400037E RID: 894
	private Image bfadeimg;

	// Token: 0x0400037F RID: 895
	private StGraphics bfadeg;

	// Token: 0x04000380 RID: 896
	private sbyte[] readbuf;

	// Token: 0x04000381 RID: 897
	private int plasf;

	// Token: 0x04000382 RID: 898
	private int plasw;

	// Token: 0x04000383 RID: 899
	private int[] plasxy;

	// Token: 0x04000384 RID: 900
	public int[] ranks;

	// Token: 0x04000385 RID: 901
	public int[] branks;

	// Token: 0x04000386 RID: 902
	public int[][] ranks2;

	// Token: 0x04000387 RID: 903
	public int apr_no;

	// Token: 0x04000388 RID: 904
	private int sdflag;

	// Token: 0x04000389 RID: 905
	private int opflag;

	// Token: 0x0400038A RID: 906
	private int cdflag;

	// Token: 0x0400038B RID: 907
	private int nowmenuno = -1;

	// Token: 0x0400038C RID: 908
	private bool skflag;

	// Token: 0x0400038D RID: 909
	private long nowtime;

	// Token: 0x0400038E RID: 910
	private long oldtime;

	// Token: 0x0400038F RID: 911
	private StGraphics3D g3d;

	// Token: 0x04000390 RID: 912
	private string menucmd1 = string.Empty;

	// Token: 0x04000391 RID: 913
	private string menucmd2 = string.Empty;

	// Token: 0x04000392 RID: 914
	private int rev_mapno = 65535;

	// Token: 0x04000393 RID: 915
	private int rev_mapx = 65535;

	// Token: 0x04000394 RID: 916
	private int rev_mapy = 65535;

	// Token: 0x04000395 RID: 917
	private int rev_chx = 65535;

	// Token: 0x04000396 RID: 918
	private int rev_chy = 65535;

	// Token: 0x04000397 RID: 919
	private ByteArrayOutputStream dfbaos;

	// Token: 0x04000398 RID: 920
	private Image[] faceimg;

	// Token: 0x04000399 RID: 921
	public int[] slxy;

	// Token: 0x0400039A RID: 922
	public int[] slwk;

	// Token: 0x0400039B RID: 923
	public int slf;

	// Token: 0x0400039C RID: 924
	public int[] dwh;

	// Token: 0x0400039D RID: 925
	public int[][] dwk;

	// Token: 0x0400039E RID: 926
	public int dflag;

	// Token: 0x0400039F RID: 927
	public int pfflag;

	// Token: 0x040003A0 RID: 928
	private Image[] vimg;

	// Token: 0x040003A1 RID: 929
	private int nowvno;

	// Token: 0x040003A2 RID: 930
	public int visualno;

	// Token: 0x040003A3 RID: 931
	public int vpno;

	// Token: 0x040003A4 RID: 932
	public bool window_flg;

	// Token: 0x040003A5 RID: 933
	public int window_cnt;

	// Token: 0x040003A6 RID: 934
	protected internal int seq_no;

	// Token: 0x040003A7 RID: 935
	protected internal int seq_no_b;

	// Token: 0x040003A8 RID: 936
	protected internal int seq_step;

	// Token: 0x040003A9 RID: 937
	protected internal int seq_step_b;

	// Token: 0x040003AA RID: 938
	protected internal bool[] ismenu;

	// Token: 0x040003AB RID: 939
	public int[][] status;

	// Token: 0x040003AC RID: 940
	private int[][] estatus;

	// Token: 0x040003AD RID: 941
	private int[][] st_ab;

	// Token: 0x040003AE RID: 942
	private int[][] est_ab;

	// Token: 0x040003AF RID: 943
	private Image[] bimg;

	// Token: 0x040003B0 RID: 944
	private Image bbgimg;

	// Token: 0x040003B1 RID: 945
	private int[] gtw;

	// Token: 0x040003B2 RID: 946
	private int gtwp;

	// Token: 0x040003B3 RID: 947
	private int[] bslot;

	// Token: 0x040003B4 RID: 948
	private int bslotno;

	// Token: 0x040003B5 RID: 949
	private int bslotmove;

	// Token: 0x040003B6 RID: 950
	private int ep;

	// Token: 0x040003B7 RID: 951
	public int[] cur;

	// Token: 0x040003B8 RID: 952
	private int[] work;

	// Token: 0x040003B9 RID: 953
	private bool[] isboost;

	// Token: 0x040003BA RID: 954
	private bool iscboost;

	// Token: 0x040003BB RID: 955
	private int boostno;

	// Token: 0x040003BC RID: 956
	private int eneatk;

	// Token: 0x040003BD RID: 957
	private int[] atkst;

	// Token: 0x040003BE RID: 958
	private int crtl;

	// Token: 0x040003BF RID: 959
	private string[] bmstr;

	// Token: 0x040003C0 RID: 960
	private int[][] bmenu;

	// Token: 0x040003C1 RID: 961
	private int blast;

	// Token: 0x040003C2 RID: 962
	private int bnum;

	// Token: 0x040003C3 RID: 963
	private int bmenup;

	// Token: 0x040003C4 RID: 964
	private Image[] eneimg;

	// Token: 0x040003C5 RID: 965
	private bool[] bred;

	// Token: 0x040003C6 RID: 966
	private bool[] bredn;

	// Token: 0x040003C7 RID: 967
	public int battleno;

	// Token: 0x040003C8 RID: 968
	private int[][] dropitem;

	// Token: 0x040003C9 RID: 969
	private int dropitemp;

	// Token: 0x040003CA RID: 970
	private int[] nextmenu;

	// Token: 0x040003CB RID: 971
	private int nextmenup;

	// Token: 0x040003CC RID: 972
	private int nowmenu;

	// Token: 0x040003CD RID: 973
	private int nmwait;

	// Token: 0x040003CE RID: 974
	private int attackef;

	// Token: 0x040003CF RID: 975
	private int getexp;

	// Token: 0x040003D0 RID: 976
	private int bsmenu;

	// Token: 0x040003D1 RID: 977
	private int[][] itempc;

	// Token: 0x040003D2 RID: 978
	protected internal sbyte[] mapdat;

	// Token: 0x040003D3 RID: 979
	protected internal sbyte[] atrdat;

	// Token: 0x040003D4 RID: 980
	private StTexture mimg;

	// Token: 0x040003D5 RID: 981
	private int mip;

	// Token: 0x040003D6 RID: 982
	private int befmino;

	// Token: 0x040003D7 RID: 983
	private int befmo = -1;

	// Token: 0x040003D8 RID: 984
	private int mapw;

	// Token: 0x040003D9 RID: 985
	private int maph;

	// Token: 0x040003DA RID: 986
	public int mapx;

	// Token: 0x040003DB RID: 987
	public int mapy;

	// Token: 0x040003DC RID: 988
	public int chx;

	// Token: 0x040003DD RID: 989
	public int chy;

	// Token: 0x040003DE RID: 990
	public int chm;

	// Token: 0x040003DF RID: 991
	private int chw;

	// Token: 0x040003E0 RID: 992
	public int chc;

	// Token: 0x040003E1 RID: 993
	private int encount;

	// Token: 0x040003E2 RID: 994
	private Image[] mcimg;

	// Token: 0x040003E3 RID: 995
	private int mcimgmax = -1;

	// Token: 0x040003E4 RID: 996
	private bool eneapr;

	// Token: 0x040003E5 RID: 997
	private bool etheruse = true;

	// Token: 0x040003E6 RID: 998
	private int trap;

	// Token: 0x040003E7 RID: 999
	private int trapdmg;

	// Token: 0x040003E8 RID: 1000
	private int trapdmgwait;

	// Token: 0x040003E9 RID: 1001
	private int mrwait;

	// Token: 0x040003EA RID: 1002
	private bool debug_enc = true;

	// Token: 0x040003EB RID: 1003
	private string debugstr = string.Empty;

	// Token: 0x040003EC RID: 1004
	private string[] mmstr;

	// Token: 0x040003ED RID: 1005
	private int[] mmenu;

	// Token: 0x040003EE RID: 1006
	private int mmenup;

	// Token: 0x040003EF RID: 1007
	private bool mmenuflag;

	// Token: 0x040003F0 RID: 1008
	private Image[] titleimg;

	// Token: 0x040003F1 RID: 1009
	private int[][] starxy;

	// Token: 0x040003F2 RID: 1010
	private Image logoimg;

	// Token: 0x040003F3 RID: 1011
	protected internal AudioPresenter audio_b;

	// Token: 0x040003F4 RID: 1012
	protected internal AudioPresenter audio_s;

	// Token: 0x040003F5 RID: 1013
	protected internal MediaSound[] bgm;

	// Token: 0x040003F6 RID: 1014
	protected internal MediaSound[] se;

	// Token: 0x040003F7 RID: 1015
	protected internal int nowbgm = -1;

	// Token: 0x040003F8 RID: 1016
	protected internal int playbgm = -1;

	// Token: 0x040003F9 RID: 1017
	protected internal int sndvol = 127;

	// Token: 0x040003FA RID: 1018
	protected internal int playse = -1;

	// Token: 0x040003FB RID: 1019
	private bool se_loop_flag;

	// Token: 0x040003FC RID: 1020
	internal PrimitiveArray fade_pa;

	// Token: 0x040003FD RID: 1021
	public int battle_fade;

	// Token: 0x040003FE RID: 1022
	internal PrimitiveArray map_pa;

	// Token: 0x040003FF RID: 1023
	private bool decieveFlag;

	// Token: 0x04000400 RID: 1024
	private int helpno;

	// Token: 0x04000401 RID: 1025
	private int[] bhelpno;

	// Token: 0x04000402 RID: 1026
	private int[][] bhelpcur;

	// Token: 0x04000403 RID: 1027
	private int bhelp;

	// Token: 0x04000404 RID: 1028
	private int bhelpseq;

	// Token: 0x04000405 RID: 1029
	private int[] mofile = new int[] { 23, 24, 25, 26 };

	// Token: 0x04000406 RID: 1030
	private int[] mofmax = new int[] { 130, 158, 82, 83 };

	// Token: 0x04000407 RID: 1031
	private int[] mofileno = new int[]
	{
		0, 0, 0, 1, 1, 1, 1, 2, 2, 2,
		2, 2, 2, 2, 2, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3
	};

	// Token: 0x04000408 RID: 1032
	private int[] mdfile = new int[]
	{
		28, 29, 30, 34, 33, 37, 35, 44, 47, 45,
		46, 41, 39, 40, 38, 4, 5, 6, 7, 8,
		9, 10, 11, 12, 13
	};

	// Token: 0x04000409 RID: 1033
	private bool[][] miflag = new bool[][]
	{
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
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true },
		new bool[] { true, true }
	};

	// Token: 0x0400040A RID: 1034
	private int[] vfile = new int[] { 27, 31, 36, 32, 48, 21, 20, 19, 17 };

	// Token: 0x0400040B RID: 1035
	private int[] vtbl = new int[] { 1, 0, 2, 1, 1, 2, 1, 1, 1 };

	// Token: 0x0400040C RID: 1036
	private int[][] downfilechk = new int[][]
	{
		new int[] { 66554, 20423 },
		new int[] { 24258, 22193 },
		new int[] { 11475, 11335 },
		new int[] { 10268, 10339 },
		new int[] { 824, 587 },
		new int[] { 1008, 682 },
		new int[] { 1044, 703 },
		new int[] { 1294, 721 },
		new int[] { 1249, 808 },
		new int[] { 1041, 717 },
		new int[] { 1062, 723 },
		new int[] { 1211, 830 },
		new int[] { 1020, 638 },
		new int[] { 2709, 1806 },
		new int[] { 5799, 5781 },
		new int[] { 16580, 15145 },
		new int[] { 12400, 6257 },
		new int[] { 10797, 10343 },
		new int[] { 230, 373 },
		new int[] { 11236, 11302 },
		new int[] { 12488, 12228 },
		new int[] { 11720, 11340 },
		new int[] { 17081, 9720 },
		new int[] { 19425, 15206 },
		new int[] { 23468, 16503 },
		new int[] { 5024, 4844 },
		new int[] { 3123, 2860 },
		new int[] { 11251, 10662 },
		new int[] { 2430, 1385 },
		new int[] { 900, 679 },
		new int[] { 1459, 945 },
		new int[] { 122, 238 },
		new int[] { 10496, 10271 },
		new int[] { 1390, 805 },
		new int[] { 9463, 5353 },
		new int[] { 2522, 1585 },
		new int[] { 21830, 21149 },
		new int[] { 780, 567 },
		new int[] { 4810, 3074 },
		new int[] { 3844, 2290 },
		new int[] { 3791, 2301 },
		new int[] { 3083, 2088 },
		new int[] { 11292, 5636 },
		new int[] { 9497, 9431 },
		new int[] { 1110, 910 },
		new int[] { 2746, 1493 },
		new int[] { 4940, 2824 },
		new int[] { 2671, 1840 },
		new int[] { 14489, 14029 },
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
		new int[] { 5600, 2324 }
	};

	// Token: 0x0400040D RID: 1037
	private int[][] se_wav_downfilechk = new int[][]
	{
		new int[] { 24398, 19123 },
		new int[] { 24554, 19143 },
		new int[] { 24398, 19075 },
		new int[] { 24920, 21528 }
	};

	// Token: 0x0400040E RID: 1038
	private string[][] dfilename = new string[][]
	{
		new string[] { "map", ".tex" },
		new string[] { "battle", ".dat" },
		new string[] { "bbg1", ".dat" },
		new string[] { "bbg2", ".dat" },
		new string[] { "building_1f", ".dat" },
		new string[] { "building_2f", ".dat" },
		new string[] { "building_3f", ".dat" },
		new string[] { "building_4f", ".dat" },
		new string[] { "building_5f", ".dat" },
		new string[] { "building_6f", ".dat" },
		new string[] { "building_7f", ".dat" },
		new string[] { "building_8f", ".dat" },
		new string[] { "building_ele", ".dat" },
		new string[] { "building_roof", ".dat" },
		new string[] { "enemy", ".dat" },
		new string[] { "face", ".dat" },
		new string[] { "help0", ".xhf" },
		new string[] { "jan_return", ".dat" },
		new string[] { "logo", ".dat" },
		new string[] { "man_kill2", ".dat" },
		new string[] { "man_kill", ".dat" },
		new string[] { "man_true", ".dat" },
		new string[] { "map0", ".dat" },
		new string[] { "map1", ".dat" },
		new string[] { "map2", ".dat" },
		new string[] { "map3", ".dat" },
		new string[] { "map4", ".dat" },
		new string[] { "op_demo", ".dat" },
		new string[] { "pl_brief", ".dat" },
		new string[] { "pl_manager", ".dat" },
		new string[] { "pl_perusal", ".dat" },
		new string[] { "pp03_start", ".dat" },
		new string[] { "sha_meet", ".dat" },
		new string[] { "ship_cookloom", ".dat" },
		new string[] { "ship_deck", ".dat" },
		new string[] { "ship_jan", ".dat" },
		new string[] { "ship_party", ".dat" },
		new string[] { "ship_werehouse", ".dat" },
		new string[] { "sur_dummy", ".dat" },
		new string[] { "sur_main1", ".dat" },
		new string[] { "sur_main2", ".dat" },
		new string[] { "sur_start", ".dat" },
		new string[] { "system", ".dat" },
		new string[] { "title", ".dat" },
		new string[] { "trap_city", ".dat" },
		new string[] { "trap_city_main1", ".dat" },
		new string[] { "trap_city_main2", ".dat" },
		new string[] { "trap_citystart", ".dat" },
		new string[] { "voi_capture", ".dat" },
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

	// Token: 0x0400040F RID: 1039
	private string[] PlyName = new string[] { "ジャン", "メリス", "ラクティス", "バグス" };

	// Token: 0x04000410 RID: 1040
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

	// Token: 0x04000411 RID: 1041
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

	// Token: 0x04000412 RID: 1042
	private string[][] PlyNAtkName = new string[][]
	{
		new string[] { "ｽｸﾘｭｰﾌﾞﾛｰ", "ﾊｲｷｯｸ", "ｽﾗｯｼｭﾌﾞﾚｰﾄﾞ", "ﾋｰﾄﾌﾞﾛｰ", "ｽﾗｯｼｭﾌﾞﾚｰﾄﾞ", "ﾄﾙﾈｰﾄﾞｷｯｸ" },
		new string[] { "S RANGE SHOT", "L RANGE SHOT", "QUICK FIRE", "SNIPE SHOT", "SNIPE SHOT", "QUICK FIRE" },
		new string[] { "ﾊﾟﾜｰｽﾄﾗｲｸ", "ﾚｰｻﾞｰｶﾞﾝ", "ﾌﾟﾗｽﾞﾏｱｰﾑ", "ﾌﾞﾗｽﾄﾎﾞﾑ", "ｿﾆｯｸｸﾛｰ", "ﾚｰｻﾞｰｶﾞﾝ" },
		new string[] { "GRAPPLE", "LG19BGS", "SMG24BGS", "HGG-BGS", "GRD20BGS", "FLM53BGS" }
	};

	// Token: 0x04000413 RID: 1043
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

	// Token: 0x04000414 RID: 1044
	private string[][] PlySAtkName = new string[][]
	{
		new string[] { "ﾗｲﾄﾆﾝｸﾞﾌﾞﾚｰﾄﾞ", "ﾍﾙｸﾘﾒｲｼｮﾝ", "ﾗｲﾄﾆﾝｸﾞﾌﾞﾚｰﾄﾞ", "ﾊﾞｰﾆﾝｸﾞﾗｯｼｭ", "ｸﾞﾗﾝﾄﾞｼｪｲｶｰ", "ﾍﾙｸﾘﾒｲｼｮﾝ" },
		new string[] { "JUSTICE SPIRIT", "JUDGMENT OF LAW", "SHINING SHOT", "JUSTICE SPIRIT", "FIRE AT RANDOM", "JUDGMENT OF LAW" },
		new string[] { "ｳﾙﾌﾌｧﾝｸﾞ", "ｽﾊﾟｲﾗﾙｽﾋﾟｱ", "ｳﾙﾌﾌｧﾝｸﾞ", "ｽﾊﾟｲﾗﾙｽﾋﾟｱ", "ｱｲｼｸﾙｿｰﾄﾞ", "ｼｬｯﾀｰｿｳﾙ" },
		new string[] { "BMP44BGS", "BBC-BGS", "BMP44BGS", "BL21BGS", "LC-BGS", "BBC-BGS" }
	};

	// Token: 0x04000415 RID: 1045
	private string[][] PlySAtkExp = new string[][]
	{
		new string[] { "敵単体・エーテル・雷／斬", "敵全体・物理・炎", "敵単体・エーテル・雷／斬", "敵単体・物理・炎／打", "敵全体・物理・打", "敵全体・物理・炎" },
		new string[] { "敵単体・物理・突／気", "敵全体・エーテル・突／Ｓ", "敵単体・エーテル・突／Ｂ", "敵単体・物理・突／気", "敵全体・物理・突", "敵全体・エーテル・突／Ｓ" },
		new string[] { "敵単体・物理・斬／気", "敵単体・エーテル・突", "敵単体・物理・斬／気", "敵単体・エーテル・突", "敵単体・エーテル・斬／冷", "敵単体・エーテル・気／Ｓ" },
		new string[] { "敵全体・物理・打", "敵全体・エーテル・Ｂ", "敵全体・物理・打", "敵単体・エーテル・Ｂ", "敵単体・物理・打", "敵全体・エーテル・Ｂ" }
	};

	// Token: 0x04000416 RID: 1046
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

	// Token: 0x04000417 RID: 1047
	private int[] PlySAtkEffMax = new int[]
	{
		13, 9, 14, 10, 9, 15, 7, 9, 5, 20,
		22, 19, 7, 13, 19, 19
	};

	// Token: 0x04000418 RID: 1048
	private string[][] PlyEtName = new string[][]
	{
		new string[] { "ﾒﾃﾞｨｶ", "ｸﾞｯﾊﾞｲ" },
		new string[] { "ｸﾞｯﾊﾞｲ", "ﾛｽﾄﾊﾟﾜｰ", "ｴｸｽﾄﾗﾊﾟﾜｰ", "ｻｲｺﾎﾟｹｯﾄ" },
		new string[] { "ﾒﾃﾞｨｶ", "ｱﾅﾗｲｽﾞ", "ﾘﾌﾚｯｼｭ", "ｴｰﾃﾙﾌﾞﾚｽ", "ｴｰﾃﾙﾘﾐｯﾄ", "ｸｲｯｸ", "ﾒﾃﾞｨｶｽｵｰﾙ", "ﾌﾞｰｽﾄﾜﾝ", "ﾘﾊﾞﾄｰ", "ｾﾌﾃｨｰﾚﾍﾞﾙ" },
		new string[] { "ﾊﾞﾆｼﾝｸﾞｶﾉﾝ", "ﾌﾞｰｽﾄﾜﾝ", "ﾊﾞｸﾞﾌｧﾗﾝｸｽ" }
	};

	// Token: 0x04000419 RID: 1049
	private string[][] PlyEtExp = new string[][]
	{
		new string[] { "HP回復", "戦闘から逃走" },
		new string[] { "戦闘から逃走", "物理攻撃力25％ﾀﾞｳﾝ", "物理攻撃力25％ｱｯﾌﾟ", "ｱｲﾃﾑを盗む" },
		new string[] { "HP回復", "敵のHPなどを調べる", "全ｽﾃｰﾀｽをｸﾘｱ", "ｴｰﾃﾙ系の効果を25％ｱｯﾌﾟ", "ｴｰﾃﾙ系の効果を25％ﾀﾞｳﾝ", "行動速度25％ｱｯﾌﾟ", "ﾊﾟｰﾃｨｰ全員のHP回復", "ﾌﾞｰｽﾄ回数+1", "戦闘不能回復&HP回復", "HP1で一度だけ生き残る" },
		new string[] { "無属性のｴｰﾃﾙ攻撃", "ﾌﾞｰｽﾄ回数+1", "無属性のｴｰﾃﾙ攻撃&敵にﾘﾌﾚｯｼｭ効果" }
	};

	// Token: 0x0400041A RID: 1050
	private int[] PlyEtPiece = new int[] { 2, 4, 10, 3 };

	// Token: 0x0400041B RID: 1051
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

	// Token: 0x0400041C RID: 1052
	private int[] StIcon = new int[]
	{
		63, 42, 42, 42, 42, 42, 42, 50, 42, 42,
		52, 35, 40, 41, 41, 41, 41, 43, 45, 51,
		41, 47, 39, 37, 37, 45, 63, 63, 63, 63,
		63, 63, 63, 63, 63, 63, 63, 63, 63, 63,
		63, 63, 63, 46, 63, 49, 63, 63, 63
	};

	// Token: 0x0400041D RID: 1053
	private string[] EneName = new string[] { "ﾌﾟﾛﾄｷｬﾝｻｰ", "U.M.N.ﾃﾛﾘｽﾄC", "U.M.N.ｺﾏﾝﾀﾞｰ", "ﾂｧｰﾙ", "ｶﾞﾙﾑ", "ｴｰｷﾞﾙ" };

	// Token: 0x0400041E RID: 1054
	private int[][] EneParam = new int[][]
	{
		new int[]
		{
			0, 1, 287, 21, 20, 18, 15, 30, 18, 8,
			0, -1, 0, -1, -1, -1, -1, -1, 5, 1,
			1, 0, 0, 3, 126, 1, 4, 5, 0, 1,
			15
		},
		new int[]
		{
			1, 0, 198, 20, 18, 20, 16, 32, 18, 9,
			1, -1, 1, -1, -1, -1, -1, -1, 3, 1,
			6, 0, 0, 0, 130, 1, 3, 1, 0, 1,
			13
		},
		new int[]
		{
			2, 0, 205, 23, 19, 22, 18, 34, 19, 10,
			2, -1, 2, -1, -1, -1, -1, -1, 3, 1,
			6, 0, 0, 3, 204, 1, 3, 1, 0, 1,
			12
		},
		new int[]
		{
			3, 0, 476, 24, 22, 24, 20, 36, 31, 9,
			3, -1, 3, -1, -1, -1, -1, -1, 5, 2,
			1, 0, 0, 2, 298, 1, 4, 14, 0, 1,
			16
		},
		new int[]
		{
			4, 2, 2171, 26, 32, 25, 20, 33, 27, 10,
			4, -1, 4, 5, -1, -1, -1, -1, 5, 3,
			1, 1, 0, 3, 511, 1, 4, 2, 0, 1,
			2
		},
		new int[]
		{
			5, 1, 3457, 38, 31, 30, 22, 41, 32, 11,
			5, -1, 6, 7, -1, -1, -1, -1, 3, 3,
			1, 1, 0, 3, 653, 1, 4, 6, 0, 1,
			6
		}
	};

	// Token: 0x0400041F RID: 1055
	private string[] EneWeak = new string[]
	{
		"斬", "突", "打", "炎", "冷", "雷", "気", "Ｂ", "Ｓ", "無",
		"なし"
	};

	// Token: 0x04000420 RID: 1056
	private int[][] EneNAtkParam = new int[][]
	{
		new int[] { 0, 0, -1, 0, 7, 50 },
		new int[] { 0, 1, -1, 0, 8, 50 },
		new int[] { 0, 1, -1, 0, 9, 50 },
		new int[] { 0, 0, -1, 0, 15, 50 },
		new int[] { 0, 1, -1, 0, 18, 50 },
		new int[] { 0, 1, -1, 0, 20, 50 }
	};

	// Token: 0x04000421 RID: 1057
	private string[][] EneNAtkExp = new string[][]
	{
		new string[] { "物理", "単体", "斬" },
		new string[] { "物理", "単体", "突" },
		new string[] { "物理", "単体", "突" },
		new string[] { "物理", "単体", "斬" },
		new string[] { "物理", "単体", "突" },
		new string[] { "物理", "単体", "突" }
	};

	// Token: 0x04000422 RID: 1058
	private string[] EneSAtkName = new string[] { "マシンガン", "グレネード", "火炎放射", "オフェンシブ", "機関銃", "大砲", "伸し掛かり", "固着" };

	// Token: 0x04000423 RID: 1059
	private int[][] EneSAtkParam = new int[][]
	{
		new int[] { 0, 1, -1, 0, 7, 0, 0 },
		new int[] { 0, 3, -1, 1, 8, 0, 0 },
		new int[] { 0, 3, -1, 1, 10, 0, 0 },
		new int[] { 1, -1, -1, 4, -1, 1, 3 },
		new int[] { 0, 1, -1, 1, 18, 0, 0 },
		new int[] { 0, 1, -1, 0, 23, 0, 0 },
		new int[] { 0, 2, -1, 0, 35, 0, 0 },
		new int[] { 1, 8, -1, 0, 20, 0, 24 }
	};

	// Token: 0x04000424 RID: 1060
	private string[][] EneSAtkExp = new string[][]
	{
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
			"エーテル",
			"自分",
			string.Empty,
			"物理攻撃力重視"
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
		new string[] { "エーテル", "単体", "Ｓ", "ロスト" }
	};

	// Token: 0x04000425 RID: 1061
	private int[] EneEncP = new int[] { 4, 1, 1, 4, 8 };

	// Token: 0x04000426 RID: 1062
	private int[][][] EneEncount = new int[][][]
	{
		new int[][]
		{
			new int[]
			{
				29, 0, 60, 170, 0, 120, 170, 0, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				69, 1, 60, 170, 1, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				84, 1, 40, 170, 2, 90, 160, 1, 140, 170,
				2, 190, 160
			},
			new int[]
			{
				99, 2, 60, 170, 0, 120, 170, 2, 180, 170,
				-1, -1, -1
			}
		},
		new int[][] { new int[]
		{
			99, 4, 120, 170, -1, -1, -1, -1, -1, -1,
			-1, -1, -1
		} },
		new int[][] { new int[]
		{
			99, 5, 120, 170, -1, -1, -1, -1, -1, -1,
			-1, -1, -1
		} },
		new int[][]
		{
			new int[]
			{
				29, 1, 40, 170, 2, 90, 160, 1, 140, 170,
				2, 190, 160
			},
			new int[]
			{
				59, 2, 60, 170, 2, 120, 160, 2, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				89, 3, 60, 170, 2, 120, 160, 3, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				99, 3, 60, 170, 3, 120, 160, 3, 180, 170,
				-1, -1, -1
			}
		},
		new int[][]
		{
			new int[]
			{
				4, 1, 60, 170, 1, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				5, 0, 60, 170, 1, 120, 160, 0, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				6, 1, 60, 170, 2, 120, 160, 1, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				7, 2, 60, 170, 1, 120, 160, 2, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				8, 2, 60, 170, 2, 120, 160, 2, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				9, 2, 60, 170, 3, 120, 160, 2, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				10, 3, 60, 170, 2, 120, 160, 3, 180, 170,
				-1, -1, -1
			},
			new int[]
			{
				11, 3, 60, 170, 3, 120, 160, 3, 180, 170,
				-1, -1, -1
			}
		}
	};

	// Token: 0x04000427 RID: 1063
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

	// Token: 0x04000428 RID: 1064
	private int[][] ItemData;

	// Token: 0x04000429 RID: 1065
	private string[] menuroot;

	// Token: 0x0400042A RID: 1066
	private string[][] configmenu;
}
