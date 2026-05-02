using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Steezy.Sound
{
	// Token: 0x020000C3 RID: 195
	public class AudioMixerManager : MonoBehaviour
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x0011ABB3 File Offset: 0x00118DB3
		public static AudioMixerManager Instance
		{
			get
			{
				if (AudioMixerManager.instance == null)
				{
					AudioMixerManager.instance = (AudioMixerManager)Object.FindObjectOfType(typeof(AudioMixerManager));
				}
				return AudioMixerManager.instance;
			}
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x0011ABE0 File Offset: 0x00118DE0
		public AudioMixerGroup GetTargetAudioMixerGroup()
		{
			return this.targetAudioMixerGroup;
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x0011ABE8 File Offset: 0x00118DE8
		public void SetMasterMute(bool isMute)
		{
			if (isMute)
			{
				this.audioMixer.SetFloat("masterVolume", -80f);
				return;
			}
			this.audioMixer.ClearFloat("masterVolume");
		}

		// Token: 0x04000A00 RID: 2560
		private static AudioMixerManager instance;

		// Token: 0x04000A01 RID: 2561
		public AudioMixer audioMixer;

		// Token: 0x04000A02 RID: 2562
		public AudioMixerGroup targetAudioMixerGroup;
	}
}
