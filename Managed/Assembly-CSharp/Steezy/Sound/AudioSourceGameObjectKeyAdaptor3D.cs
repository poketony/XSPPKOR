using System;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000C0 RID: 192
	public class AudioSourceGameObjectKeyAdaptor3D : AbstractAudioSourceAdaptor3D<GameObject>
	{
		// Token: 0x06001126 RID: 4390 RVA: 0x0011AB5E File Offset: 0x00118D5E
		protected override string GetSeType()
		{
			return this.seType;
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x0011AB66 File Offset: 0x00118D66
		protected override GameObject GetAudioSourceKey()
		{
			return base.gameObject;
		}

		// Token: 0x040009FD RID: 2557
		public string seType;
	}
}
