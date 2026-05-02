using System;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000C1 RID: 193
	[RequireComponent(typeof(AudioSource))]
	public class AudioSourceInitializer : MonoBehaviour
	{
		// Token: 0x06001129 RID: 4393 RVA: 0x0011AB76 File Offset: 0x00118D76
		private void Start()
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.mute = AudioSourceManager3D.IsMute;
			component.volume = AudioSourceManager3D.Volume;
		}
	}
}
