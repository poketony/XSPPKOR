using System;
using Steezy.Utility;
using UnityEngine;

// Token: 0x02000049 RID: 73
public class StPadManager : SingletonBehaviour<StPadManager>
{
	// Token: 0x06000D72 RID: 3442 RVA: 0x0010CB95 File Offset: 0x0010AD95
	private void Awake()
	{
		this.padManager = new SteamPadManager();
	}

	// Token: 0x06000D73 RID: 3443 RVA: 0x0010CBA2 File Offset: 0x0010ADA2
	private void Start()
	{
		this.padManager.StartProcess();
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x0010CBAF File Offset: 0x0010ADAF
	private void Update()
	{
		this.padManager.UpdateProcess();
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x0010CBBC File Offset: 0x0010ADBC
	private void OnEnable()
	{
		this.padManager.OnEnable();
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x0010CBC9 File Offset: 0x0010ADC9
	private void OnDisable()
	{
		this.padManager.OnDisable();
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x0010CBD6 File Offset: 0x0010ADD6
	private void OnDestroy()
	{
		this.padManager.OnDisable();
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x0010CBE3 File Offset: 0x0010ADE3
	public Vector3 GetAnalogStick(StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		return this.padManager.GetAnalogStick(targetPlayer);
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x0010CBF1 File Offset: 0x0010ADF1
	public Vector3 GetMotionSensorAcceleration(StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		return this.padManager.GetMotionSensorAcceleration(targetPlayer);
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x0010CBFF File Offset: 0x0010ADFF
	public bool GetButton(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		return this.padManager.GetButton(button, targetPlayer);
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x0010CC0E File Offset: 0x0010AE0E
	public bool GetButtonDown(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		return this.padManager.GetButtonDown(button, targetPlayer);
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x0010CC1D File Offset: 0x0010AE1D
	public bool GetButtonUp(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		return this.padManager.GetButtonUp(button, targetPlayer);
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x0010CC2C File Offset: 0x0010AE2C
	public void StartLrAssignmentMode()
	{
		this.padManager.StartLrAssignmentMode();
		this.padManager.isInputAllDevice = true;
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0010CC45 File Offset: 0x0010AE45
	public void StopLrAssignmentMode()
	{
		this.padManager.StopLrAssignmentMode();
		this.padManager.isInputAllDevice = false;
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x0010CC5E File Offset: 0x0010AE5E
	public void ShowControllerSupport()
	{
		this.padManager.ShowControllerSupport();
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x0010CC6B File Offset: 0x0010AE6B
	public bool IsPairing(StPadManager.Player targetPlayer)
	{
		return this.padManager.IsPairing(targetPlayer);
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x0010CC79 File Offset: 0x0010AE79
	public void SetVibration(float low, float high)
	{
		this.padManager.SetVibration(low, high);
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x0010CC88 File Offset: 0x0010AE88
	public virtual int GetSteamControllerCount()
	{
		return this.padManager.GetSteamControllerCount();
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x0010CC95 File Offset: 0x0010AE95
	public int GetKeyboardPlayerCount()
	{
		return this.padManager.GetKeyboardPlayerCount();
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x0010CCA2 File Offset: 0x0010AEA2
	public void ResetAssign()
	{
		this.padManager.ResetAssign();
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x0010CCAF File Offset: 0x0010AEAF
	public bool AssignPlayer(StPadManager.Player player, StPadManager.PadButton[] buttons, KeyCode[] keyCodes)
	{
		return this.padManager.AssignPlayer(player, buttons, keyCodes);
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x0010CCBF File Offset: 0x0010AEBF
	public bool IsKeyboardPlayer(StPadManager.Player player)
	{
		return this.padManager.IsKeyboardPlayer(player);
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x0010CCCD File Offset: 0x0010AECD
	public void AddKeyboardUser(StPadManager.Player player)
	{
		this.padManager.AddKeyboardUser(player);
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x0010CCDB File Offset: 0x0010AEDB
	public void RemoveKeyboardUser(StPadManager.Player player)
	{
		this.padManager.RemoveKeyboardUser(player);
	}

	// Token: 0x04000810 RID: 2064
	private StPadManager.IStPadManager padManager;

	// Token: 0x020001D0 RID: 464
	public enum PadButton
	{
		// Token: 0x04001324 RID: 4900
		NONE,
		// Token: 0x04001325 RID: 4901
		UP,
		// Token: 0x04001326 RID: 4902
		DOWN,
		// Token: 0x04001327 RID: 4903
		LEFT = 4,
		// Token: 0x04001328 RID: 4904
		RIGHT = 8,
		// Token: 0x04001329 RID: 4905
		POSITIVE = 256,
		// Token: 0x0400132A RID: 4906
		NEGATIVE = 512,
		// Token: 0x0400132B RID: 4907
		X = 1024,
		// Token: 0x0400132C RID: 4908
		Y = 2048,
		// Token: 0x0400132D RID: 4909
		L = 4096,
		// Token: 0x0400132E RID: 4910
		R = 8192,
		// Token: 0x0400132F RID: 4911
		ZL = 16384,
		// Token: 0x04001330 RID: 4912
		ZR = 32768,
		// Token: 0x04001331 RID: 4913
		PLUS = 16777216,
		// Token: 0x04001332 RID: 4914
		MINUS = 33554432,
		// Token: 0x04001333 RID: 4915
		ANY_BUTTON = 1073741824
	}

	// Token: 0x020001D1 RID: 465
	public enum Player
	{
		// Token: 0x04001335 RID: 4917
		P1,
		// Token: 0x04001336 RID: 4918
		P2
	}

	// Token: 0x020001D2 RID: 466
	public abstract class IStPadManager
	{
		// Token: 0x06001C29 RID: 7209
		public abstract void StartProcess();

		// Token: 0x06001C2A RID: 7210
		public abstract void UpdateProcess();

		// Token: 0x06001C2B RID: 7211
		public abstract Vector3 GetAnalogStick(StPadManager.Player targetPlayer = StPadManager.Player.P1);

		// Token: 0x06001C2C RID: 7212
		public abstract Vector3 GetMotionSensorAcceleration(StPadManager.Player targetPlayer = StPadManager.Player.P1);

		// Token: 0x06001C2D RID: 7213
		public abstract bool GetButton(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1);

		// Token: 0x06001C2E RID: 7214
		public abstract bool GetButtonDown(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1);

		// Token: 0x06001C2F RID: 7215
		public abstract bool GetButtonUp(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1);

		// Token: 0x06001C30 RID: 7216 RVA: 0x001453FF File Offset: 0x001435FF
		public virtual void StartLrAssignmentMode()
		{
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x00145401 File Offset: 0x00143601
		public virtual void StopLrAssignmentMode()
		{
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x00145403 File Offset: 0x00143603
		public virtual void ShowControllerSupport()
		{
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x00145405 File Offset: 0x00143605
		public virtual bool IsPairing(StPadManager.Player targetPlayer)
		{
			return true;
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x00145408 File Offset: 0x00143608
		public virtual void SetVibration(float low, float high)
		{
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x0014540A File Offset: 0x0014360A
		public virtual int GetSteamControllerCount()
		{
			return 0;
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x0014540D File Offset: 0x0014360D
		public virtual int GetKeyboardPlayerCount()
		{
			return 0;
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x00145410 File Offset: 0x00143610
		public virtual void ResetAssign()
		{
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x00145412 File Offset: 0x00143612
		public virtual bool AssignPlayer(StPadManager.Player player, StPadManager.PadButton[] buttons, KeyCode[] keyCodes)
		{
			return false;
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x00145415 File Offset: 0x00143615
		public virtual bool IsKeyboardPlayer(StPadManager.Player player)
		{
			return false;
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x00145418 File Offset: 0x00143618
		public virtual void AddKeyboardUser(StPadManager.Player player)
		{
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x0014541A File Offset: 0x0014361A
		public virtual void RemoveKeyboardUser(StPadManager.Player player)
		{
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x0014541C File Offset: 0x0014361C
		public virtual void OnEnable()
		{
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x0014541E File Offset: 0x0014361E
		public virtual void OnDisable()
		{
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x00145420 File Offset: 0x00143620
		public virtual void OnDestroy()
		{
		}

		// Token: 0x04001337 RID: 4919
		public bool isInputAllDevice;
	}
}
