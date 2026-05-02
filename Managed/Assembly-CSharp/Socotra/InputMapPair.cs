using System;
using Serialize;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000EC RID: 236
	[Serializable]
	public class InputMapPair : KeyAndValue<StInputManager.Key, KeyCode>
	{
		// Token: 0x06001323 RID: 4899 RVA: 0x0011FDB6 File Offset: 0x0011DFB6
		public InputMapPair(StInputManager.Key key, KeyCode value)
			: base(key, value)
		{
		}
	}
}
