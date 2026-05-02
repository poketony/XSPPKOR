using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class SteamPadManager : StPadManager.IStPadManager
{
	// Token: 0x06000D5B RID: 3419 RVA: 0x0010AEE7 File Offset: 0x001090E7
	public override void StartProcess()
	{
		this.m_assignList = new List<StPadManager.Player>();
		this.m_inputHandles = new InputHandle_t[16];
		this.InitInputP1();
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x0010AF08 File Offset: 0x00109108
	private void InitInputP1()
	{
		if (!this.m_assignList.Contains(StPadManager.Player.P1))
		{
			this.m_assignList.Add(StPadManager.Player.P1);
		}
		this.m_inputHandleMap[StPadManager.Player.P1] = null;
		this.m_inputTypeMap[StPadManager.Player.P1] = SteamPadManager.InputType.Keyboard;
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x0010AF54 File Offset: 0x00109154
	public override void UpdateProcess()
	{
		int controllerCount = this.GetControllerCount();
		for (int i = 0; i < controllerCount; i++)
		{
			SteamInput.ActivateActionSet(this.m_inputHandles[i], SteamInput.GetActionSetHandle("InGameControls"));
		}
		foreach (object obj in Enum.GetValues(typeof(StPadManager.Player)))
		{
			StPadManager.Player player = (StPadManager.Player)obj;
			if (this.m_assignList.Contains(player))
			{
				bool flag = false;
				if (controllerCount > 0)
				{
					for (int j = 0; j < controllerCount; j++)
					{
						InputHandle_t? inputHandle_t = this.m_inputHandleMap[player];
						InputHandle_t inputHandle_t2 = this.m_inputHandles[j];
						if (inputHandle_t != null && (inputHandle_t == null || inputHandle_t.GetValueOrDefault() == inputHandle_t2))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					this.m_inputTypeMap[player] = SteamPadManager.InputType.Pad;
				}
				else if (this.m_inputTypeMap[player] == SteamPadManager.InputType.Pad)
				{
					if (player == StPadManager.Player.P1 && this.GetKeyboardPlayerCount() == 0)
					{
						this.m_inputTypeMap[player] = SteamPadManager.InputType.Keyboard;
					}
					else
					{
						this.m_inputTypeMap[player] = SteamPadManager.InputType.None;
					}
				}
				using (Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState>.KeyCollection.Enumerator enumerator2 = SteamPadManager.ButtonStateMapBase.Keys.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						StPadManager.PadButton padButton = enumerator2.Current;
						if (this.GetButton(padButton, player))
						{
							this.ButtonDown(padButton, true, player);
						}
						else
						{
							this.ButtonUp(padButton, false, player);
						}
					}
					continue;
				}
			}
			this.m_inputHandleMap[player] = null;
			this.m_inputTypeMap[player] = SteamPadManager.InputType.None;
		}
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x0010B140 File Offset: 0x00109340
	public override int GetKeyboardPlayerCount()
	{
		int num = 0;
		foreach (StPadManager.Player player in this.m_assignList)
		{
			if (this.m_inputTypeMap[player] == SteamPadManager.InputType.Keyboard)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x0010B1A4 File Offset: 0x001093A4
	public override void ResetAssign()
	{
		this.m_assignList.Clear();
		this.m_assignList.Add(StPadManager.Player.P1);
		foreach (object obj in Enum.GetValues(typeof(StPadManager.Player)))
		{
			StPadManager.Player player = (StPadManager.Player)obj;
			if (player != StPadManager.Player.P1)
			{
				this.m_inputHandleMap[player] = null;
				this.m_inputTypeMap[player] = SteamPadManager.InputType.None;
			}
		}
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x0010B23C File Offset: 0x0010943C
	public override bool AssignPlayer(StPadManager.Player player, StPadManager.PadButton[] buttons, KeyCode[] keyCodes)
	{
		int controllerCount = this.GetControllerCount();
		if (controllerCount >= 1)
		{
			for (int i = 0; i < controllerCount; i++)
			{
				bool flag = false;
				foreach (StPadManager.Player player2 in this.m_assignList)
				{
					if (player2 == player)
					{
						break;
					}
					InputHandle_t? inputHandle_t = this.m_inputHandleMap[player2];
					InputHandle_t inputHandle_t2 = this.m_inputHandles[i];
					if (inputHandle_t != null && (inputHandle_t == null || inputHandle_t.GetValueOrDefault() == inputHandle_t2))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					foreach (StPadManager.PadButton padButton in buttons)
					{
						string[] array = this.ButtonMapSteam[padButton];
						for (int k = 0; k < array.Length; k++)
						{
							InputDigitalActionHandle_t digitalActionHandle = SteamInput.GetDigitalActionHandle(array[k]);
							if (SteamInput.GetDigitalActionData(this.m_inputHandles[i], digitalActionHandle).bState > 0)
							{
								this.m_inputHandleMap[player] = new InputHandle_t?(this.m_inputHandles[i]);
								this.m_inputTypeMap[player] = SteamPadManager.InputType.Pad;
								if (!this.m_assignList.Contains(player))
								{
									this.m_assignList.Add(player);
								}
								return true;
							}
						}
					}
				}
			}
		}
		this.m_inputHandleMap[player] = null;
		if (this.GetKeyboardPlayerCount() >= 2 && (player != StPadManager.Player.P1 || this.m_inputTypeMap[player] != SteamPadManager.InputType.Keyboard))
		{
			return false;
		}
		for (int j = 0; j < keyCodes.Length; j++)
		{
			if (Input.GetKey(keyCodes[j]))
			{
				this.m_inputTypeMap[player] = SteamPadManager.InputType.Keyboard;
				if (!this.m_assignList.Contains(player))
				{
					this.m_assignList.Add(player);
				}
				return true;
			}
		}
		this.m_inputTypeMap[player] = SteamPadManager.InputType.None;
		if (player == StPadManager.Player.P1)
		{
			this.InitInputP1();
		}
		return false;
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x0010B448 File Offset: 0x00109648
	public override Vector3 GetAnalogStick(StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		float num = 0f;
		float num2 = 0f;
		if ((this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Pad && this.m_inputHandleMap[targetPlayer] != null) || this.isInputAllDevice)
		{
			int controllerCount = this.GetControllerCount();
			List<InputHandle_t> list = new List<InputHandle_t>();
			if (this.isInputAllDevice)
			{
				for (int i = 0; i < controllerCount; i++)
				{
					list.Add(this.m_inputHandles[i]);
				}
			}
			else if (controllerCount > 0)
			{
				list.Add(this.m_inputHandleMap[targetPlayer].Value);
			}
			foreach (InputHandle_t inputHandle_t in list)
			{
				bool flag = false;
				bool flag2 = false;
				if (this.GetButton(StPadManager.PadButton.LEFT, true, targetPlayer))
				{
					flag = true;
				}
				if (this.GetButton(StPadManager.PadButton.RIGHT, true, targetPlayer))
				{
					flag2 = true;
				}
				num = (float)((flag ? (-1) : 0) + (flag2 ? 1 : 0));
				bool flag3 = false;
				bool flag4 = false;
				if (this.GetButton(StPadManager.PadButton.DOWN, true, targetPlayer))
				{
					flag3 = true;
				}
				if (this.GetButton(StPadManager.PadButton.UP, true, targetPlayer))
				{
					flag4 = true;
				}
				num2 = (float)((flag3 ? (-1) : 0) + (flag4 ? 1 : 0));
				InputAnalogActionData_t analogActionData = SteamInput.GetAnalogActionData(inputHandle_t, SteamInput.GetAnalogActionHandle("Cursor"));
				num += analogActionData.x;
				num2 += analogActionData.y;
			}
		}
		if (this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Keyboard || this.isInputAllDevice)
		{
			bool flag5 = false;
			bool flag6 = false;
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(StPadManager.PadButton.LEFT, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKey(enumerator2.Current))
					{
						flag5 = true;
					}
				}
			}
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(StPadManager.PadButton.RIGHT, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKey(enumerator2.Current))
					{
						flag6 = true;
					}
				}
			}
			num = (float)((flag5 ? (-1) : 0) + (flag6 ? 1 : 0));
			bool flag7 = false;
			bool flag8 = false;
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(StPadManager.PadButton.DOWN, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKey(enumerator2.Current))
					{
						flag7 = true;
					}
				}
			}
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(StPadManager.PadButton.UP, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKey(enumerator2.Current))
					{
						flag8 = true;
					}
				}
			}
			num2 = (float)((flag7 ? (-1) : 0) + (flag8 ? 1 : 0));
		}
		return new Vector3(num, num2);
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x0010B730 File Offset: 0x00109930
	public override Vector3 GetMotionSensorAcceleration(StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		if ((this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Pad && this.m_inputHandleMap[targetPlayer] != null) || this.isInputAllDevice)
		{
			int controllerCount = this.GetControllerCount();
			List<InputHandle_t> list = new List<InputHandle_t>();
			if (this.isInputAllDevice)
			{
				for (int i = 0; i < controllerCount; i++)
				{
					list.Add(this.m_inputHandles[i]);
				}
			}
			else if (controllerCount > 0)
			{
				list.Add(this.m_inputHandleMap[targetPlayer].Value);
			}
			foreach (InputHandle_t inputHandle_t in list)
			{
				if (this.m_accelerationFrameMap[targetPlayer] != Time.frameCount)
				{
					this.m_accelerationFrameMap[targetPlayer] = Time.frameCount;
					Vector3 inputMotionData = this.GetInputMotionData(inputHandle_t);
					if (this.m_accelerationVectorMap[targetPlayer] == Vector3.zero)
					{
						this.m_accelerationVectorMap[targetPlayer] = inputMotionData;
					}
					this.m_accelerationVectorDiffMap[targetPlayer] = inputMotionData - this.m_accelerationVectorMap[targetPlayer];
					this.m_accelerationVectorMap[targetPlayer] = inputMotionData;
				}
				if (Mathf.Abs(this.m_accelerationVectorDiffMap[targetPlayer].x) > 1000f || Mathf.Abs(this.m_accelerationVectorDiffMap[targetPlayer].y) > 1000f || Mathf.Abs(this.m_accelerationVectorDiffMap[targetPlayer].z) > 1000f)
				{
					return this.m_accelerationVectorDiffMap[targetPlayer].normalized;
				}
			}
		}
		float num = 0f;
		float num2 = 0f;
		if (this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Keyboard || this.isInputAllDevice)
		{
			if (this.GetButtonDown(StPadManager.PadButton.LEFT, targetPlayer))
			{
				num += -1f;
			}
			else if (this.GetButtonDown(StPadManager.PadButton.RIGHT, targetPlayer))
			{
				num += 1f;
			}
			else if (this.GetButtonDown(StPadManager.PadButton.UP, targetPlayer))
			{
				num2 += 1f;
			}
			else if (this.GetButtonDown(StPadManager.PadButton.DOWN, targetPlayer))
			{
				num2 += -1f;
			}
		}
		return new Vector3(num, num2);
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x0010B988 File Offset: 0x00109B88
	private Vector3 GetInputMotionData(InputHandle_t inputHandle_t)
	{
		InputMotionData_t motionData = SteamInput.GetMotionData(inputHandle_t);
		return new Vector3(motionData.rotVelX, motionData.rotVelY, motionData.rotVelZ);
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x0010B9B3 File Offset: 0x00109BB3
	public override bool GetButton(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		return this.GetButton(button, false, targetPlayer);
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x0010B9C0 File Offset: 0x00109BC0
	private bool GetButton(StPadManager.PadButton button, bool callGetAnalogStick, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		if ((this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Pad && this.m_inputHandleMap[targetPlayer] != null) || this.isInputAllDevice)
		{
			int controllerCount = this.GetControllerCount();
			List<InputHandle_t> list = new List<InputHandle_t>();
			if (this.isInputAllDevice)
			{
				for (int i = 0; i < controllerCount; i++)
				{
					list.Add(this.m_inputHandles[i]);
				}
			}
			else if (controllerCount > 0)
			{
				list.Add(this.m_inputHandleMap[targetPlayer].Value);
			}
			foreach (InputHandle_t inputHandle_t in list)
			{
				if (!callGetAnalogStick)
				{
					InputAnalogActionData_t analogActionData = SteamInput.GetAnalogActionData(inputHandle_t, SteamInput.GetAnalogActionHandle("Cursor"));
					switch (button)
					{
					case StPadManager.PadButton.UP:
						if (analogActionData.y > 0.5f)
						{
							return true;
						}
						break;
					case StPadManager.PadButton.DOWN:
						if (analogActionData.y < -0.5f)
						{
							return true;
						}
						break;
					case (StPadManager.PadButton)3:
						break;
					case StPadManager.PadButton.LEFT:
						if (analogActionData.x < -0.5f)
						{
							return true;
						}
						break;
					default:
						if (button == StPadManager.PadButton.RIGHT)
						{
							if (analogActionData.x > 0.5f)
							{
								return true;
							}
						}
						break;
					}
				}
				string[] array = this.ButtonMapSteam[button];
				for (int j = 0; j < array.Length; j++)
				{
					InputDigitalActionHandle_t digitalActionHandle = SteamInput.GetDigitalActionHandle(array[j]);
					if (SteamInput.GetDigitalActionData(inputHandle_t, digitalActionHandle).bState > 0)
					{
						return true;
					}
				}
			}
		}
		if (this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Keyboard || this.isInputAllDevice)
		{
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(button, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKey(enumerator2.Current))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x0010BBCC File Offset: 0x00109DCC
	public override bool GetButtonDown(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		if ((this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Pad && this.m_inputHandleMap[targetPlayer] != null) || this.isInputAllDevice)
		{
			int controllerCount = this.GetControllerCount();
			List<InputHandle_t> list = new List<InputHandle_t>();
			if (this.isInputAllDevice)
			{
				for (int i = 0; i < controllerCount; i++)
				{
					list.Add(this.m_inputHandles[i]);
				}
			}
			else if (controllerCount > 0)
			{
				list.Add(this.m_inputHandleMap[targetPlayer].Value);
			}
			bool flag = false;
			foreach (InputHandle_t inputHandle_t in list)
			{
				InputAnalogActionData_t analogActionData = SteamInput.GetAnalogActionData(inputHandle_t, SteamInput.GetAnalogActionHandle("Cursor"));
				switch (button)
				{
				case StPadManager.PadButton.UP:
					flag = analogActionData.y > 0.5f;
					break;
				case StPadManager.PadButton.DOWN:
					flag = analogActionData.y < -0.5f;
					break;
				case (StPadManager.PadButton)3:
					break;
				case StPadManager.PadButton.LEFT:
					flag = analogActionData.x < -0.5f;
					break;
				default:
					if (button == StPadManager.PadButton.RIGHT)
					{
						flag = analogActionData.x > 0.5f;
					}
					break;
				}
				string[] array = this.ButtonMapSteam[button];
				for (int j = 0; j < array.Length; j++)
				{
					InputDigitalActionHandle_t digitalActionHandle = SteamInput.GetDigitalActionHandle(array[j]);
					if (SteamInput.GetDigitalActionData(inputHandle_t, digitalActionHandle).bState > 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (list.Count > 0 && this.ButtonDown(button, flag, targetPlayer))
			{
				return true;
			}
		}
		if (this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Keyboard || this.isInputAllDevice)
		{
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(button, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKeyDown(enumerator2.Current))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x0010BDD4 File Offset: 0x00109FD4
	public override bool GetButtonUp(StPadManager.PadButton button, StPadManager.Player targetPlayer = StPadManager.Player.P1)
	{
		if ((this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Pad && this.m_inputHandleMap[targetPlayer] != null) || this.isInputAllDevice)
		{
			int controllerCount = this.GetControllerCount();
			List<InputHandle_t> list = new List<InputHandle_t>();
			if (this.isInputAllDevice)
			{
				for (int i = 0; i < controllerCount; i++)
				{
					list.Add(this.m_inputHandles[i]);
				}
			}
			else if (controllerCount > 0)
			{
				list.Add(this.m_inputHandleMap[targetPlayer].Value);
			}
			bool flag = false;
			foreach (InputHandle_t inputHandle_t in list)
			{
				InputAnalogActionData_t analogActionData = SteamInput.GetAnalogActionData(inputHandle_t, SteamInput.GetAnalogActionHandle("Cursor"));
				switch (button)
				{
				case StPadManager.PadButton.UP:
					flag = analogActionData.y > 0.5f;
					break;
				case StPadManager.PadButton.DOWN:
					flag = analogActionData.y < -0.5f;
					break;
				case (StPadManager.PadButton)3:
					break;
				case StPadManager.PadButton.LEFT:
					flag = analogActionData.x < -0.5f;
					break;
				default:
					if (button == StPadManager.PadButton.RIGHT)
					{
						flag = analogActionData.x > 0.5f;
					}
					break;
				}
				string[] array = this.ButtonMapSteam[button];
				for (int j = 0; j < array.Length; j++)
				{
					InputDigitalActionHandle_t digitalActionHandle = SteamInput.GetDigitalActionHandle(array[j]);
					if (SteamInput.GetDigitalActionData(inputHandle_t, digitalActionHandle).bState > 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (list.Count > 0 && this.ButtonUp(button, flag, targetPlayer))
			{
				return true;
			}
		}
		if (this.m_inputTypeMap[targetPlayer] == SteamPadManager.InputType.Keyboard || this.isInputAllDevice)
		{
			using (List<KeyCode>.Enumerator enumerator2 = this.GetButtonMapKeyboard(button, targetPlayer).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (Input.GetKeyUp(enumerator2.Current))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x0010BFDC File Offset: 0x0010A1DC
	private List<KeyCode> GetButtonMapKeyboard(StPadManager.PadButton button, StPadManager.Player targetPlayer)
	{
		Dictionary<StPadManager.PadButton, List<KeyCode>> dictionary;
		if (this.GetKeyboardPlayerCount() == 1)
		{
			dictionary = this.ButtonMapKeyboard;
		}
		else
		{
			int keyboardUserIndex = this.GetKeyboardUserIndex(targetPlayer);
			if (keyboardUserIndex != 0)
			{
				if (keyboardUserIndex != 1)
				{
					return new List<KeyCode>();
				}
				dictionary = this.ButtonMapKeyboard_2nd;
			}
			else
			{
				dictionary = this.ButtonMapKeyboard_1st;
			}
		}
		if (dictionary.ContainsKey(button))
		{
			return dictionary[button];
		}
		return new List<KeyCode>();
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x0010C03A File Offset: 0x0010A23A
	public override bool IsPairing(StPadManager.Player targetPlayer)
	{
		return this.m_assignList.Contains(targetPlayer);
	}

	// Token: 0x06000D6A RID: 3434 RVA: 0x0010C048 File Offset: 0x0010A248
	public override int GetSteamControllerCount()
	{
		return this.GetControllerCount();
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x0010C050 File Offset: 0x0010A250
	public int GetControllerCount()
	{
		return SteamInput.GetConnectedControllers(this.m_inputHandles);
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x0010C05D File Offset: 0x0010A25D
	public override bool IsKeyboardPlayer(StPadManager.Player player)
	{
		return this.m_inputTypeMap[player] == SteamPadManager.InputType.Keyboard;
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x0010C070 File Offset: 0x0010A270
	private int GetKeyboardUserIndex(StPadManager.Player player)
	{
		int num = -1;
		List<StPadManager.Player> list = new List<StPadManager.Player>();
		foreach (StPadManager.Player player2 in this.m_assignList)
		{
			if (this.m_inputTypeMap[player2] == SteamPadManager.InputType.Keyboard)
			{
				list.Add(player2);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == player)
			{
				num = i;
				break;
			}
		}
		return num;
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x0010C100 File Offset: 0x0010A300
	private bool ButtonDown(StPadManager.PadButton padButton, bool Pressed, StPadManager.Player targetPlayer)
	{
		Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState> dictionary = this.m_buttonStateMap[targetPlayer];
		Dictionary<StPadManager.PadButton, int> dictionary2 = this.m_buttonFrameCntMap[targetPlayer];
		if (!Pressed)
		{
			if (dictionary[padButton] == SteamPadManager.ButtonState.Pressed)
			{
				if (padButton == StPadManager.PadButton.PLUS || padButton == StPadManager.PadButton.MINUS)
				{
					dictionary[StPadManager.PadButton.PLUS] = SteamPadManager.ButtonState.BeforeUndo;
					dictionary[StPadManager.PadButton.MINUS] = SteamPadManager.ButtonState.BeforeUndo;
				}
				else
				{
					dictionary[padButton] = SteamPadManager.ButtonState.BeforeUndo;
				}
			}
			else if (padButton == StPadManager.PadButton.PLUS || padButton == StPadManager.PadButton.MINUS)
			{
				dictionary[StPadManager.PadButton.PLUS] = SteamPadManager.ButtonState.None;
				dictionary[StPadManager.PadButton.MINUS] = SteamPadManager.ButtonState.None;
			}
			else
			{
				dictionary[padButton] = SteamPadManager.ButtonState.None;
			}
			return false;
		}
		if (dictionary[padButton] == SteamPadManager.ButtonState.None || dictionary[padButton] == SteamPadManager.ButtonState.Press || dictionary[padButton] == SteamPadManager.ButtonState.BeforeUndo)
		{
			if (padButton == StPadManager.PadButton.PLUS || padButton == StPadManager.PadButton.MINUS)
			{
				dictionary2[StPadManager.PadButton.PLUS] = Time.frameCount;
				dictionary2[StPadManager.PadButton.MINUS] = Time.frameCount;
				dictionary[StPadManager.PadButton.PLUS] = SteamPadManager.ButtonState.Pressed;
				dictionary[StPadManager.PadButton.MINUS] = SteamPadManager.ButtonState.Pressed;
			}
			else
			{
				dictionary2[padButton] = Time.frameCount;
				dictionary[padButton] = SteamPadManager.ButtonState.Pressed;
			}
			return true;
		}
		return dictionary[padButton] == SteamPadManager.ButtonState.Pressed && dictionary2[padButton] == Time.frameCount;
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x0010C238 File Offset: 0x0010A438
	private bool ButtonUp(StPadManager.PadButton padButton, bool Pressed, StPadManager.Player targetPlayer)
	{
		Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState> dictionary = this.m_buttonStateMap[targetPlayer];
		Dictionary<StPadManager.PadButton, int> dictionary2 = this.m_buttonFrameCntMap[targetPlayer];
		if (Pressed)
		{
			if (dictionary[padButton] == SteamPadManager.ButtonState.None)
			{
				if (padButton == StPadManager.PadButton.PLUS || padButton == StPadManager.PadButton.MINUS)
				{
					dictionary[StPadManager.PadButton.PLUS] = SteamPadManager.ButtonState.Press;
					dictionary[StPadManager.PadButton.MINUS] = SteamPadManager.ButtonState.Press;
				}
				else
				{
					dictionary[padButton] = SteamPadManager.ButtonState.Press;
				}
			}
			else if (padButton == StPadManager.PadButton.PLUS || padButton == StPadManager.PadButton.MINUS)
			{
				dictionary[StPadManager.PadButton.PLUS] = SteamPadManager.ButtonState.Pressed;
				dictionary[StPadManager.PadButton.MINUS] = SteamPadManager.ButtonState.Pressed;
			}
			else
			{
				dictionary[padButton] = SteamPadManager.ButtonState.Pressed;
			}
			return false;
		}
		if (dictionary[padButton] == SteamPadManager.ButtonState.Press || dictionary[padButton] == SteamPadManager.ButtonState.Pressed || dictionary[padButton] == SteamPadManager.ButtonState.BeforeUndo)
		{
			if (padButton == StPadManager.PadButton.PLUS || padButton == StPadManager.PadButton.MINUS)
			{
				dictionary2[StPadManager.PadButton.PLUS] = Time.frameCount;
				dictionary2[StPadManager.PadButton.MINUS] = Time.frameCount;
				dictionary[StPadManager.PadButton.PLUS] = SteamPadManager.ButtonState.None;
				dictionary[StPadManager.PadButton.MINUS] = SteamPadManager.ButtonState.None;
			}
			else
			{
				dictionary2[padButton] = Time.frameCount;
				dictionary[padButton] = SteamPadManager.ButtonState.None;
			}
			return true;
		}
		return dictionary[padButton] == SteamPadManager.ButtonState.None && dictionary2[padButton] == Time.frameCount;
	}

	// Token: 0x04000801 RID: 2049
	private List<StPadManager.Player> m_assignList;

	// Token: 0x04000802 RID: 2050
	private Dictionary<StPadManager.Player, SteamPadManager.InputType> m_inputTypeMap = new Dictionary<StPadManager.Player, SteamPadManager.InputType>
	{
		{
			StPadManager.Player.P1,
			SteamPadManager.InputType.None
		},
		{
			StPadManager.Player.P2,
			SteamPadManager.InputType.None
		}
	};

	// Token: 0x04000803 RID: 2051
	private InputHandle_t[] m_inputHandles;

	// Token: 0x04000804 RID: 2052
	private Dictionary<StPadManager.Player, InputHandle_t?> m_inputHandleMap = new Dictionary<StPadManager.Player, InputHandle_t?>
	{
		{
			StPadManager.Player.P1,
			null
		},
		{
			StPadManager.Player.P2,
			null
		}
	};

	// Token: 0x04000805 RID: 2053
	private Dictionary<StPadManager.PadButton, string[]> ButtonMapSteam = new Dictionary<StPadManager.PadButton, string[]>
	{
		{
			StPadManager.PadButton.POSITIVE,
			new string[] { "A" }
		},
		{
			StPadManager.PadButton.NEGATIVE,
			new string[] { "B" }
		},
		{
			StPadManager.PadButton.PLUS,
			new string[] { "SELECT" }
		},
		{
			StPadManager.PadButton.MINUS,
			new string[] { "SELECT" }
		},
		{
			StPadManager.PadButton.L,
			new string[] { "L" }
		},
		{
			StPadManager.PadButton.R,
			new string[] { "R" }
		},
		{
			StPadManager.PadButton.ANY_BUTTON,
			new string[] { "A", "B", "X", "Y" }
		},
		{
			StPadManager.PadButton.UP,
			new string[] { "LEFTSTICK_UP" }
		},
		{
			StPadManager.PadButton.DOWN,
			new string[] { "LEFTSTICK_DOWN" }
		},
		{
			StPadManager.PadButton.LEFT,
			new string[] { "LEFTSTICK_LEFT" }
		},
		{
			StPadManager.PadButton.RIGHT,
			new string[] { "LEFTSTICK_RIGHT" }
		},
		{
			StPadManager.PadButton.X,
			new string[] { "X" }
		},
		{
			StPadManager.PadButton.Y,
			new string[] { "Y" }
		},
		{
			StPadManager.PadButton.ZL,
			new string[] { "ZL" }
		},
		{
			StPadManager.PadButton.ZR,
			new string[] { "ZR" }
		}
	};

	// Token: 0x04000806 RID: 2054
	private Dictionary<StPadManager.PadButton, List<KeyCode>> ButtonMapKeyboard = new Dictionary<StPadManager.PadButton, List<KeyCode>>
	{
		{
			StPadManager.PadButton.POSITIVE,
			new List<KeyCode> { 32, 306, 304, 122 }
		},
		{
			StPadManager.PadButton.NEGATIVE,
			new List<KeyCode> { 120 }
		},
		{
			StPadManager.PadButton.PLUS,
			new List<KeyCode> { 27 }
		},
		{
			StPadManager.PadButton.MINUS,
			new List<KeyCode> { 27 }
		},
		{
			StPadManager.PadButton.L,
			new List<KeyCode> { 113, 108 }
		},
		{
			StPadManager.PadButton.R,
			new List<KeyCode> { 101, 114 }
		},
		{
			StPadManager.PadButton.ANY_BUTTON,
			new List<KeyCode> { 32, 306, 304, 122, 120 }
		},
		{
			StPadManager.PadButton.UP,
			new List<KeyCode> { 119, 273 }
		},
		{
			StPadManager.PadButton.DOWN,
			new List<KeyCode> { 115, 274 }
		},
		{
			StPadManager.PadButton.LEFT,
			new List<KeyCode> { 97, 276 }
		},
		{
			StPadManager.PadButton.RIGHT,
			new List<KeyCode> { 100, 275 }
		},
		{
			StPadManager.PadButton.X,
			new List<KeyCode> { 99 }
		},
		{
			StPadManager.PadButton.Y,
			new List<KeyCode> { 118 }
		},
		{
			StPadManager.PadButton.ZL,
			new List<KeyCode> { 49 }
		},
		{
			StPadManager.PadButton.ZR,
			new List<KeyCode> { 51 }
		}
	};

	// Token: 0x04000807 RID: 2055
	private Dictionary<StPadManager.PadButton, List<KeyCode>> ButtonMapKeyboard_1st = new Dictionary<StPadManager.PadButton, List<KeyCode>>
	{
		{
			StPadManager.PadButton.POSITIVE,
			new List<KeyCode> { 32, 306, 304, 122 }
		},
		{
			StPadManager.PadButton.NEGATIVE,
			new List<KeyCode> { 120 }
		},
		{
			StPadManager.PadButton.PLUS,
			new List<KeyCode> { 27 }
		},
		{
			StPadManager.PadButton.MINUS,
			new List<KeyCode> { 27 }
		},
		{
			StPadManager.PadButton.L,
			new List<KeyCode> { 113, 108 }
		},
		{
			StPadManager.PadButton.R,
			new List<KeyCode> { 101, 114 }
		},
		{
			StPadManager.PadButton.ANY_BUTTON,
			new List<KeyCode> { 32, 306, 304, 122, 120 }
		},
		{
			StPadManager.PadButton.UP,
			new List<KeyCode> { 119 }
		},
		{
			StPadManager.PadButton.DOWN,
			new List<KeyCode> { 115 }
		},
		{
			StPadManager.PadButton.LEFT,
			new List<KeyCode> { 97 }
		},
		{
			StPadManager.PadButton.RIGHT,
			new List<KeyCode> { 100 }
		},
		{
			StPadManager.PadButton.X,
			new List<KeyCode> { 99 }
		},
		{
			StPadManager.PadButton.Y,
			new List<KeyCode> { 118 }
		},
		{
			StPadManager.PadButton.ZL,
			new List<KeyCode> { 49 }
		},
		{
			StPadManager.PadButton.ZR,
			new List<KeyCode> { 51 }
		}
	};

	// Token: 0x04000808 RID: 2056
	private Dictionary<StPadManager.PadButton, List<KeyCode>> ButtonMapKeyboard_2nd = new Dictionary<StPadManager.PadButton, List<KeyCode>>
	{
		{
			StPadManager.PadButton.POSITIVE,
			new List<KeyCode> { 305, 303 }
		},
		{
			StPadManager.PadButton.ANY_BUTTON,
			new List<KeyCode> { 305, 303 }
		},
		{
			StPadManager.PadButton.UP,
			new List<KeyCode> { 273 }
		},
		{
			StPadManager.PadButton.DOWN,
			new List<KeyCode> { 274 }
		},
		{
			StPadManager.PadButton.LEFT,
			new List<KeyCode> { 276 }
		},
		{
			StPadManager.PadButton.RIGHT,
			new List<KeyCode> { 275 }
		}
	};

	// Token: 0x04000809 RID: 2057
	private static readonly Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState> ButtonStateMapBase = new Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState>
	{
		{
			StPadManager.PadButton.POSITIVE,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.NEGATIVE,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.PLUS,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.MINUS,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.L,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.R,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.ANY_BUTTON,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.UP,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.DOWN,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.LEFT,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.RIGHT,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.X,
			SteamPadManager.ButtonState.None
		},
		{
			StPadManager.PadButton.Y,
			SteamPadManager.ButtonState.None
		}
	};

	// Token: 0x0400080A RID: 2058
	private Dictionary<StPadManager.Player, Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState>> m_buttonStateMap = new Dictionary<StPadManager.Player, Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState>>
	{
		{
			StPadManager.Player.P1,
			new Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState>(SteamPadManager.ButtonStateMapBase)
		},
		{
			StPadManager.Player.P2,
			new Dictionary<StPadManager.PadButton, SteamPadManager.ButtonState>(SteamPadManager.ButtonStateMapBase)
		}
	};

	// Token: 0x0400080B RID: 2059
	private static readonly Dictionary<StPadManager.PadButton, int> ButtonFrameCntMapBase = new Dictionary<StPadManager.PadButton, int>
	{
		{
			StPadManager.PadButton.POSITIVE,
			-1
		},
		{
			StPadManager.PadButton.NEGATIVE,
			-1
		},
		{
			StPadManager.PadButton.PLUS,
			-1
		},
		{
			StPadManager.PadButton.MINUS,
			-1
		},
		{
			StPadManager.PadButton.L,
			-1
		},
		{
			StPadManager.PadButton.R,
			-1
		},
		{
			StPadManager.PadButton.ANY_BUTTON,
			-1
		},
		{
			StPadManager.PadButton.UP,
			-1
		},
		{
			StPadManager.PadButton.DOWN,
			-1
		},
		{
			StPadManager.PadButton.LEFT,
			-1
		},
		{
			StPadManager.PadButton.RIGHT,
			-1
		},
		{
			StPadManager.PadButton.X,
			-1
		},
		{
			StPadManager.PadButton.Y,
			-1
		}
	};

	// Token: 0x0400080C RID: 2060
	private Dictionary<StPadManager.Player, Dictionary<StPadManager.PadButton, int>> m_buttonFrameCntMap = new Dictionary<StPadManager.Player, Dictionary<StPadManager.PadButton, int>>
	{
		{
			StPadManager.Player.P1,
			new Dictionary<StPadManager.PadButton, int>(SteamPadManager.ButtonFrameCntMapBase)
		},
		{
			StPadManager.Player.P2,
			new Dictionary<StPadManager.PadButton, int>(SteamPadManager.ButtonFrameCntMapBase)
		}
	};

	// Token: 0x0400080D RID: 2061
	private Dictionary<StPadManager.Player, int> m_accelerationFrameMap = new Dictionary<StPadManager.Player, int>
	{
		{
			StPadManager.Player.P1,
			-1
		},
		{
			StPadManager.Player.P2,
			-1
		}
	};

	// Token: 0x0400080E RID: 2062
	private Dictionary<StPadManager.Player, Vector3> m_accelerationVectorMap = new Dictionary<StPadManager.Player, Vector3>
	{
		{
			StPadManager.Player.P1,
			Vector3.zero
		},
		{
			StPadManager.Player.P2,
			Vector3.zero
		}
	};

	// Token: 0x0400080F RID: 2063
	private Dictionary<StPadManager.Player, Vector3> m_accelerationVectorDiffMap = new Dictionary<StPadManager.Player, Vector3>
	{
		{
			StPadManager.Player.P1,
			Vector3.zero
		},
		{
			StPadManager.Player.P2,
			Vector3.zero
		}
	};

	// Token: 0x020001CE RID: 462
	private enum InputType
	{
		// Token: 0x0400131B RID: 4891
		None,
		// Token: 0x0400131C RID: 4892
		Keyboard,
		// Token: 0x0400131D RID: 4893
		Pad
	}

	// Token: 0x020001CF RID: 463
	private enum ButtonState
	{
		// Token: 0x0400131F RID: 4895
		None,
		// Token: 0x04001320 RID: 4896
		Press,
		// Token: 0x04001321 RID: 4897
		Pressed,
		// Token: 0x04001322 RID: 4898
		BeforeUndo
	}
}
