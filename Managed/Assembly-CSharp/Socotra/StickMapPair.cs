using System;
using Serialize;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000EE RID: 238
	[Serializable]
	public class StickMapPair : KeyAndValue<StInputManager.Key, Vector2>
	{
		// Token: 0x06001325 RID: 4901 RVA: 0x0011FDC8 File Offset: 0x0011DFC8
		public StickMapPair(StInputManager.Key key, Vector2 vec)
			: base(key, vec)
		{
		}
	}
}
