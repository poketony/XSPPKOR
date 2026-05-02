using System;
using Serialize;

namespace Socotra
{
	// Token: 0x020000F0 RID: 240
	[Serializable]
	public class PadMapPair : KeyAndValue<StInputManager.Key, StPadManager.PadButton>
	{
		// Token: 0x06001327 RID: 4903 RVA: 0x0011FDDA File Offset: 0x0011DFDA
		public PadMapPair(StInputManager.Key key, StPadManager.PadButton button)
			: base(key, button)
		{
		}
	}
}
