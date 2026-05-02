using System;

namespace Socotra.IO
{
	// Token: 0x02000130 RID: 304
	public class SoundInputStream : InputStream
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06001689 RID: 5769 RVA: 0x0012D8C7 File Offset: 0x0012BAC7
		public ScratchPadDataSound Sound
		{
			get
			{
				return this.baseSound;
			}
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x0012D8CF File Offset: 0x0012BACF
		public SoundInputStream(ScratchPadDataSound sound)
		{
			this.baseSound = sound;
		}

		// Token: 0x04000CD9 RID: 3289
		private ScratchPadDataSound baseSound;
	}
}
