using System;

namespace Steezy.Sound
{
	// Token: 0x020000C2 RID: 194
	public class AudioSourceStringKeyAdaptor3D : AbstractAudioSourceAdaptor3D<string>
	{
		// Token: 0x0600112B RID: 4395 RVA: 0x0011AB9B File Offset: 0x00118D9B
		protected override string GetSeType()
		{
			return this.seType;
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x0011ABA3 File Offset: 0x00118DA3
		protected override string GetAudioSourceKey()
		{
			return this.audioSourceKey;
		}

		// Token: 0x040009FE RID: 2558
		public string seType;

		// Token: 0x040009FF RID: 2559
		public string audioSourceKey;
	}
}
