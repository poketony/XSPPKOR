using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Socotra.UI
{
	// Token: 0x02000102 RID: 258
	public class StDisplay : SingletonBehaviour<StDisplay>
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x00121824 File Offset: 0x0011FA24
		public int KeyPadState
		{
			get
			{
				return this.keypadState;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060013D2 RID: 5074 RVA: 0x0012182C File Offset: 0x0011FA2C
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x00121834 File Offset: 0x0011FA34
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060013D4 RID: 5076 RVA: 0x0012183C File Offset: 0x0011FA3C
		public int Magnification
		{
			get
			{
				return this.magnification;
			}
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x00121844 File Offset: 0x0011FA44
		private void Awake()
		{
			this.renderTexture = new RenderTexture(this.width * this.magnification, this.height * this.magnification, this.depth);
			this.renderTexture.Create();
			StGraphics.ClearRenderTexture(this.renderTexture);
			base.GetComponent<Renderer>().material.SetTexture("_MainTex", this.renderTexture);
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x001218AE File Offset: 0x0011FAAE
		private void Start()
		{
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x001218B0 File Offset: 0x0011FAB0
		private void Update()
		{
			if (SingletonBehaviour<StDisplay>.Instance.currentFrame != null && !SingletonBehaviour<StApplicationManager>.Instance.IsSuspend)
			{
				this.GetKeyEvent();
			}
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x001218D6 File Offset: 0x0011FAD6
		private void OnDestroy()
		{
			if (this.renderTexture)
			{
				this.renderTexture.Release();
				Object.Destroy(this.renderTexture);
			}
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x001218FB File Offset: 0x0011FAFB
		public void SetTargetRenderer(Renderer target)
		{
			Debug.Log("Target Renderer:" + ((target != null) ? target.ToString() : null));
			target.material.SetTexture("_MainTex", this.renderTexture);
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x0012192F File Offset: 0x0011FB2F
		public void SetFiltering(bool onFilter)
		{
			this.renderTexture.filterMode = (onFilter ? 2 : 0);
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x00121944 File Offset: 0x0011FB44
		protected void GetKeyEvent()
		{
			int currentPadState = this.GetCurrentPadState();
			if ((currentPadState ^ this.lastKeypadState) != 0)
			{
				int num = currentPadState ^ this.lastKeypadState;
				int num2 = currentPadState & num;
				this.keypadState = currentPadState;
				this.lastKeypadState = currentPadState;
				if (this.currentFrame as StCanvas && num != 0)
				{
					for (int i = 0; i < 32; i++)
					{
						if ((num & 1) > 0)
						{
							int num3 = i;
							int num4;
							if ((num2 & 1) > 0)
							{
								num4 = 1;
							}
							else
							{
								num4 = 2;
							}
							(this.currentFrame as StCanvas).ProcessEvent(num4, num3);
						}
						num >>= 1;
						num2 >>= 1;
					}
				}
			}
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x001219DC File Offset: 0x0011FBDC
		private int GetCurrentPadState()
		{
			int num = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.UP) ? 1 : 0);
			int num2 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.DOWN) ? 1 : 0);
			int num3 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.RIGHT) ? 1 : 0);
			int num4 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.LEFT) ? 1 : 0);
			int num5 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_0) ? 1 : 0);
			int num6 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_1) ? 1 : 0);
			int num7 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_2) ? 1 : 0);
			int num8 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_3) ? 1 : 0);
			int num9 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_4) ? 1 : 0);
			int num10 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_5) ? 1 : 0);
			int num11 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_6) ? 1 : 0);
			int num12 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_7) ? 1 : 0);
			int num13 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_8) ? 1 : 0);
			int num14 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.NUM_9) ? 1 : 0);
			int num15 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.ENTER) ? 1 : 0);
			int num16 = ((SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.SOFT1) || SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.SOFT1SUB)) ? 1 : 0);
			int num17 = ((SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.SOFT2) || SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.SOFT2SUB)) ? 1 : 0);
			int num18 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.ASTERISK) ? 1 : 0);
			int num19 = (SingletonBehaviour<StInputManager>.Instance.GetKeyStatus(StInputManager.Key.POUND) ? 1 : 0);
			return (num << 17) | (num2 << 19) | (num3 << 18) | (num4 << 16) | num5 | (num6 << 1) | (num7 << 2) | (num8 << 3) | (num9 << 4) | (num10 << 5) | (num11 << 6) | (num12 << 7) | (num13 << 8) | (num14 << 9) | (num15 << 20) | (num16 << 21) | (num17 << 22) | (num18 << 10) | (num19 << 11);
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x00121BD2 File Offset: 0x0011FDD2
		public static void SetCurrent(Frame newFrame)
		{
			SingletonBehaviour<StDisplay>.Instance.currentFrame = newFrame;
			if (newFrame as StCanvas)
			{
				((StCanvas)newFrame).GetGraphics().RenderTexture = SingletonBehaviour<StDisplay>.Instance.renderTexture;
			}
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x00121C06 File Offset: 0x0011FE06
		public static Frame GetCurrent()
		{
			return SingletonBehaviour<StDisplay>.Instance.currentFrame;
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x00121C14 File Offset: 0x0011FE14
		public void SetSoftkeyLabel(int key, string label)
		{
			if (key == 0)
			{
				this.softKey1Label.text = label;
				this.softkey1.SetActive(label != null && label.Length > 0);
				return;
			}
			if (key != 1)
			{
				return;
			}
			this.softKey2Label.text = label;
			this.softkey2.SetActive(label != null && label.Length > 0);
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x00121C78 File Offset: 0x0011FE78
		public string GetSoftkeyLabel(int key)
		{
			string text = null;
			if (key != 0)
			{
				if (key == 1)
				{
					text = this.softKey2Label.text;
				}
			}
			else
			{
				text = this.softKey1Label.text;
			}
			return text;
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x00121CAB File Offset: 0x0011FEAB
		public void UpdateKeypadState()
		{
			this.keypadState = this.GetCurrentPadState();
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x00121CB9 File Offset: 0x0011FEB9
		public static int GetWidth()
		{
			return SingletonBehaviour<StDisplay>.Instance.width;
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x00121CC5 File Offset: 0x0011FEC5
		public static int GetHeight()
		{
			return SingletonBehaviour<StDisplay>.Instance.height;
		}

		// Token: 0x04000B2C RID: 2860
		public const int KEY_PRESSED_EVENT = 1;

		// Token: 0x04000B2D RID: 2861
		public const int KEY_RELEASED_EVENT = 2;

		// Token: 0x04000B2E RID: 2862
		public const int KEY_0 = 0;

		// Token: 0x04000B2F RID: 2863
		public const int KEY_1 = 1;

		// Token: 0x04000B30 RID: 2864
		public const int KEY_2 = 2;

		// Token: 0x04000B31 RID: 2865
		public const int KEY_3 = 3;

		// Token: 0x04000B32 RID: 2866
		public const int KEY_4 = 4;

		// Token: 0x04000B33 RID: 2867
		public const int KEY_5 = 5;

		// Token: 0x04000B34 RID: 2868
		public const int KEY_6 = 6;

		// Token: 0x04000B35 RID: 2869
		public const int KEY_7 = 7;

		// Token: 0x04000B36 RID: 2870
		public const int KEY_8 = 8;

		// Token: 0x04000B37 RID: 2871
		public const int KEY_9 = 9;

		// Token: 0x04000B38 RID: 2872
		public const int KEY_DOWN = 19;

		// Token: 0x04000B39 RID: 2873
		public const int KEY_LEFT = 16;

		// Token: 0x04000B3A RID: 2874
		public const int KEY_RIGHT = 18;

		// Token: 0x04000B3B RID: 2875
		public const int KEY_UP = 17;

		// Token: 0x04000B3C RID: 2876
		public const int KEY_SELECT = 20;

		// Token: 0x04000B3D RID: 2877
		public const int KEY_CLEAR = 32;

		// Token: 0x04000B3E RID: 2878
		public const int KEY_SOFT1 = 21;

		// Token: 0x04000B3F RID: 2879
		public const int KEY_SOFT2 = 22;

		// Token: 0x04000B40 RID: 2880
		public const int KEY_SOFT3 = 12;

		// Token: 0x04000B41 RID: 2881
		public const int KEY_SOFT4 = 13;

		// Token: 0x04000B42 RID: 2882
		public const int KEY_ASTERISK = 10;

		// Token: 0x04000B43 RID: 2883
		public const int KEY_POUND = 11;

		// Token: 0x04000B44 RID: 2884
		public const int RESET_VM_EVENT = 5;

		// Token: 0x04000B45 RID: 2885
		public const int RESUME_VM_EVENT = 4;

		// Token: 0x04000B46 RID: 2886
		public const int TIMER_EXPIRED_EVENT = 7;

		// Token: 0x04000B47 RID: 2887
		public const int UPDATE_VM_EVENT = 6;

		// Token: 0x04000B48 RID: 2888
		private Frame currentFrame;

		// Token: 0x04000B49 RID: 2889
		private RenderTexture renderTexture;

		// Token: 0x04000B4A RID: 2890
		[SerializeField]
		private int width;

		// Token: 0x04000B4B RID: 2891
		[SerializeField]
		private int height;

		// Token: 0x04000B4C RID: 2892
		[SerializeField]
		private int depth;

		// Token: 0x04000B4D RID: 2893
		[SerializeField]
		private int magnification;

		// Token: 0x04000B4E RID: 2894
		[SerializeField]
		private int keypadState;

		// Token: 0x04000B4F RID: 2895
		[SerializeField]
		private Text softKey1Label;

		// Token: 0x04000B50 RID: 2896
		[SerializeField]
		private Text softKey2Label;

		// Token: 0x04000B51 RID: 2897
		[SerializeField]
		private GameObject softkey1;

		// Token: 0x04000B52 RID: 2898
		[SerializeField]
		private GameObject softkey2;

		// Token: 0x04000B53 RID: 2899
		private int lastKeypadState;
	}
}
