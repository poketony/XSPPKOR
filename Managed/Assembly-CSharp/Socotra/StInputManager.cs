using System;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000F1 RID: 241
	public class StInputManager : SingletonBehaviour<StInputManager>
	{
		// Token: 0x06001328 RID: 4904 RVA: 0x0011FDE4 File Offset: 0x0011DFE4
		private void Start()
		{
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x0011FDE6 File Offset: 0x0011DFE6
		private void Update()
		{
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x0011FDE8 File Offset: 0x0011DFE8
		public bool GetKeyStatus(StInputManager.Key target)
		{
			StInputManager.InputType inputType = this.inputType;
			if (inputType != StInputManager.InputType.Keyboard && inputType == StInputManager.InputType.Pad)
			{
				return this.GetPadInput(target);
			}
			return Input.GetKey(this.keyboardMap.GetTable()[target]);
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x0011FE24 File Offset: 0x0011E024
		private bool GetPadInput(StInputManager.Key target)
		{
			Vector2 vector = SingletonBehaviour<StPadManager>.Instance.GetAnalogStick(StPadManager.Player.P1);
			foreach (StickMapPair stickMapPair in this.stickMap.GetList())
			{
				if (target == stickMapPair.Key && Vector2.Angle(vector, stickMapPair.Value) < 30f && vector.sqrMagnitude > 0.2f)
				{
					if (vector.sqrMagnitude > this.stickMagnitudeThreshold)
					{
						return true;
					}
					return false;
				}
			}
			return this.padMap.GetTable().ContainsKey(target) && SingletonBehaviour<StPadManager>.Instance.GetButton(this.padMap.GetTable()[target], StPadManager.Player.P1);
		}

		// Token: 0x04000ABC RID: 2748
		[SerializeField]
		private StInputManager.InputType inputType;

		// Token: 0x04000ABD RID: 2749
		[SerializeField]
		private InputMappingTable keyboardMap;

		// Token: 0x04000ABE RID: 2750
		[SerializeField]
		private StickMappingTable stickMap;

		// Token: 0x04000ABF RID: 2751
		[SerializeField]
		private PadMappingTable padMap;

		// Token: 0x04000AC0 RID: 2752
		[SerializeField]
		[Range(0.2f, 1f)]
		private float stickMagnitudeThreshold = 0.3f;

		// Token: 0x0200023A RID: 570
		public enum Key
		{
			// Token: 0x040014DE RID: 5342
			UP,
			// Token: 0x040014DF RID: 5343
			DOWN,
			// Token: 0x040014E0 RID: 5344
			LEFT,
			// Token: 0x040014E1 RID: 5345
			RIGHT,
			// Token: 0x040014E2 RID: 5346
			NUM_0,
			// Token: 0x040014E3 RID: 5347
			NUM_1,
			// Token: 0x040014E4 RID: 5348
			NUM_2,
			// Token: 0x040014E5 RID: 5349
			NUM_3,
			// Token: 0x040014E6 RID: 5350
			NUM_4,
			// Token: 0x040014E7 RID: 5351
			NUM_5,
			// Token: 0x040014E8 RID: 5352
			NUM_6,
			// Token: 0x040014E9 RID: 5353
			NUM_7,
			// Token: 0x040014EA RID: 5354
			NUM_8,
			// Token: 0x040014EB RID: 5355
			NUM_9,
			// Token: 0x040014EC RID: 5356
			ENTER,
			// Token: 0x040014ED RID: 5357
			SOFT1,
			// Token: 0x040014EE RID: 5358
			SOFT2,
			// Token: 0x040014EF RID: 5359
			SOFT1SUB,
			// Token: 0x040014F0 RID: 5360
			SOFT2SUB,
			// Token: 0x040014F1 RID: 5361
			ASTERISK,
			// Token: 0x040014F2 RID: 5362
			POUND,
			// Token: 0x040014F3 RID: 5363
			_END
		}

		// Token: 0x0200023B RID: 571
		public enum PadButton
		{
			// Token: 0x040014F5 RID: 5365
			POSITIVE,
			// Token: 0x040014F6 RID: 5366
			NEGATIVE
		}

		// Token: 0x0200023C RID: 572
		public enum InputType
		{
			// Token: 0x040014F8 RID: 5368
			Keyboard,
			// Token: 0x040014F9 RID: 5369
			Pad,
			// Token: 0x040014FA RID: 5370
			VitrualPad
		}

		// Token: 0x0200023D RID: 573
		public enum InputMode
		{
			// Token: 0x040014FC RID: 5372
			NORMAL,
			// Token: 0x040014FD RID: 5373
			STEP
		}
	}
}
