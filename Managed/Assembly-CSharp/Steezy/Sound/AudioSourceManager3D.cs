using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000C4 RID: 196
	public class AudioSourceManager3D : MonoBehaviour
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x0011AC1D File Offset: 0x00118E1D
		public static bool IsMute
		{
			get
			{
				return AudioSourceManager3D.isMute;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06001133 RID: 4403 RVA: 0x0011AC24 File Offset: 0x00118E24
		public static float Volume
		{
			get
			{
				return AudioSourceManager3D.volume;
			}
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x0011AC2C File Offset: 0x00118E2C
		public static void AddAudioSource<T>(string seType, T key, AudioSource source, bool setCommonVolume = true)
		{
			if (!AudioSourceManager3D.audioSources.ContainsKey(seType))
			{
				Dictionary<object, AudioSource> dictionary = new Dictionary<object, AudioSource>();
				if (setCommonVolume)
				{
					source.mute = AudioSourceManager3D.isMute;
					source.volume = AudioSourceManager3D.volume;
				}
				dictionary.Add(key, source);
				AudioSourceManager3D.audioSources.Add(seType, dictionary);
				return;
			}
			Dictionary<object, AudioSource> dictionary2 = AudioSourceManager3D.audioSources[seType];
			if (dictionary2.ContainsKey(key))
			{
				Debug.LogWarning("it contains AudioSource");
				return;
			}
			if (setCommonVolume)
			{
				source.mute = AudioSourceManager3D.isMute;
				source.volume = AudioSourceManager3D.volume;
			}
			dictionary2.Add(key, source);
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x0011ACCC File Offset: 0x00118ECC
		public static AudioSource GetAudioSource<T>(string seType, T key)
		{
			if (AudioSourceManager3D.audioSources.ContainsKey(seType))
			{
				Dictionary<object, AudioSource> dictionary = AudioSourceManager3D.audioSources[seType];
				if (dictionary.ContainsKey(key))
				{
					return dictionary[key];
				}
			}
			Debug.LogWarning("AudioSource is not found");
			return null;
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x0011AD18 File Offset: 0x00118F18
		public static void RemoveAudioSource<T>(string seType, T key)
		{
			if (AudioSourceManager3D.audioSources.ContainsKey(seType))
			{
				Dictionary<object, AudioSource> dictionary = AudioSourceManager3D.audioSources[seType];
				if (dictionary.ContainsKey(key))
				{
					dictionary.Remove(key);
					return;
				}
			}
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x0011AD5A File Offset: 0x00118F5A
		public static void RemoveAudioSourceType(string seType)
		{
			if (AudioSourceManager3D.audioSources.ContainsKey(seType))
			{
				AudioSourceManager3D.audioSources.Remove(seType);
			}
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x0011AD75 File Offset: 0x00118F75
		private void OnDestroy()
		{
			AudioSourceManager3D.DestroyAudioSource();
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0011AD7C File Offset: 0x00118F7C
		public static void Destroy()
		{
			AudioSourceManager3D.DestroyAudioSource();
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x0011AD83 File Offset: 0x00118F83
		private static void DestroyAudioSource()
		{
			if (AudioSourceManager3D.audioSources != null)
			{
				AudioSourceManager3D.audioSources = new Dictionary<string, Dictionary<object, AudioSource>>();
			}
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x0011AD96 File Offset: 0x00118F96
		public static void Init(bool isMuteCommon, float volumeCommon)
		{
			AudioSourceManager3D.Destroy();
			AudioSourceManager3D.audioSources = new Dictionary<string, Dictionary<object, AudioSource>>();
			AudioSourceManager3D.isMute = isMuteCommon;
			AudioSourceManager3D.volume = volumeCommon;
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x0011ADB4 File Offset: 0x00118FB4
		public static void PlaySE<T>(string seType, T key, bool isLoop = false)
		{
			AudioSource audioSource = AudioSourceManager3D.GetAudioSource<T>(seType, key);
			if (audioSource != null)
			{
				audioSource.loop = isLoop;
				audioSource.Play();
			}
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0011ADE0 File Offset: 0x00118FE0
		public static void StopAllSE()
		{
			foreach (KeyValuePair<string, Dictionary<object, AudioSource>> keyValuePair in AudioSourceManager3D.audioSources)
			{
				foreach (KeyValuePair<object, AudioSource> keyValuePair2 in keyValuePair.Value)
				{
					keyValuePair2.Value.Stop();
				}
			}
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x0011AE74 File Offset: 0x00119074
		public static void StopSE(string seType)
		{
			if (AudioSourceManager3D.audioSources.ContainsKey(seType))
			{
				foreach (KeyValuePair<object, AudioSource> keyValuePair in AudioSourceManager3D.audioSources[seType])
				{
					keyValuePair.Value.Stop();
				}
			}
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0011AEE0 File Offset: 0x001190E0
		public static void StopSE<T>(string seType, T key)
		{
			AudioSource audioSource = AudioSourceManager3D.GetAudioSource<T>(seType, key);
			if (audioSource != null)
			{
				audioSource.Stop();
			}
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x0011AF04 File Offset: 0x00119104
		public static void SetMuteAllSE(bool isMute)
		{
			foreach (KeyValuePair<string, Dictionary<object, AudioSource>> keyValuePair in AudioSourceManager3D.audioSources)
			{
				foreach (KeyValuePair<object, AudioSource> keyValuePair2 in keyValuePair.Value)
				{
					keyValuePair2.Value.mute = isMute;
				}
			}
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x0011AF98 File Offset: 0x00119198
		public static void SetVolumeAllSE(float volume)
		{
			foreach (KeyValuePair<string, Dictionary<object, AudioSource>> keyValuePair in AudioSourceManager3D.audioSources)
			{
				foreach (KeyValuePair<object, AudioSource> keyValuePair2 in keyValuePair.Value)
				{
					keyValuePair2.Value.volume = volume;
				}
			}
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x0011B02C File Offset: 0x0011922C
		public static bool IsPlayingSE<T>(string seType, T key)
		{
			AudioSource audioSource = AudioSourceManager3D.GetAudioSource<T>(seType, key);
			return audioSource != null && audioSource.isPlaying;
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x0011B054 File Offset: 0x00119254
		public static void PauseSE<T>(string seType, T key)
		{
			AudioSource audioSource = AudioSourceManager3D.GetAudioSource<T>(seType, key);
			if (audioSource != null)
			{
				audioSource.Pause();
			}
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x0011B078 File Offset: 0x00119278
		public static void RestartSE<T>(string seType, T key)
		{
			AudioSource audioSource = AudioSourceManager3D.GetAudioSource<T>(seType, key);
			if (audioSource != null)
			{
				audioSource.Play();
			}
		}

		// Token: 0x04000A03 RID: 2563
		private static Dictionary<string, Dictionary<object, AudioSource>> audioSources = new Dictionary<string, Dictionary<object, AudioSource>>();

		// Token: 0x04000A04 RID: 2564
		private static bool isMute = false;

		// Token: 0x04000A05 RID: 2565
		private static float volume = 1f;
	}
}
