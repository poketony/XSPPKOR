using System;
using Steezy.Utility;

namespace Socotra.UI
{
	// Token: 0x02000100 RID: 256
	public class StCanvas : Frame
	{
		// Token: 0x060013C2 RID: 5058 RVA: 0x00121792 File Offset: 0x0011F992
		public void Start()
		{
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00121794 File Offset: 0x0011F994
		public virtual void Paint(StGraphics g)
		{
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00121796 File Offset: 0x0011F996
		public void Repaint()
		{
			this.Paint(this.graphics);
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x001217A4 File Offset: 0x0011F9A4
		public virtual void ProcessEvent(int type, int param)
		{
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x001217A6 File Offset: 0x0011F9A6
		public int GetKeypadState()
		{
			return SingletonBehaviour<StDisplay>.Instance.KeyPadState;
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x001217B2 File Offset: 0x0011F9B2
		public StGraphics GetGraphics()
		{
			return base.GetComponent<StGraphics>();
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x001217BA File Offset: 0x0011F9BA
		public virtual void ProcessIMEEvent(int type, string param)
		{
		}

		// Token: 0x04000B26 RID: 2854
		public const int IME_CANCELED = 1;

		// Token: 0x04000B27 RID: 2855
		public const int IME_COMMITTED = 0;
	}
}
