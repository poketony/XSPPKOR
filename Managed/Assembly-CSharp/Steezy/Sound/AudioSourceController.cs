using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000C5 RID: 197
	public class AudioSourceController : SoundController
	{
		// Token: 0x06001147 RID: 4423 RVA: 0x0011B0C0 File Offset: 0x001192C0
		private void OnDestroy()
		{
			this.DestroyAudioSource();
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x0011B0C8 File Offset: 0x001192C8
		public override void Destroy()
		{
			this.DestroyAudioSource();
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x0011B0D0 File Offset: 0x001192D0
		private void DestroyAudioSource()
		{
			if (this.audioSourceBGM != null)
			{
				this.audioSourceBGM = null;
			}
			if (this.audioSourceSE != null)
			{
				for (int i = 0; i < this.audioSourceSE.Length; i++)
				{
					this.audioSourceSE[i] = null;
				}
				this.audioSourceSE = null;
			}
			if (this.audioSourceVoice != null)
			{
				for (int j = 0; j < this.audioSourceVoice.Length; j++)
				{
					this.audioSourceVoice[j] = null;
				}
				this.audioSourceVoice = null;
			}
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x0011B148 File Offset: 0x00119348
		public override void Init(GameObject gameObject, bool isMute, float volumeBGM, float volumeSE, float volumeVoice)
		{
			this.InitAudioSource(gameObject);
			this.ChangeVolume(isMute, volumeBGM, volumeSE, volumeVoice);
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x0011B160 File Offset: 0x00119360
		private void InitAudioSource(GameObject gameObject)
		{
			this.audioSourceBGM = gameObject.AddComponent<AudioSource>();
			this.audioSourceBGM.loop = true;
			this.audioSourceSE = new AudioSource[this.SEAudioSourceCount];
			for (int i = 0; i < this.SEAudioSourceCount; i++)
			{
				this.audioSourceSE[i] = gameObject.AddComponent<AudioSource>();
			}
			this.audioSourceVoice = new AudioSource[this.VoiceAudioSourceCount];
			for (int j = 0; j < this.VoiceAudioSourceCount; j++)
			{
				this.audioSourceVoice[j] = gameObject.AddComponent<AudioSource>();
			}
			this.audioClipBGMList = new List<AudioClip>();
			this.audioClipSEList = new List<AudioClip>();
			this.audioClipVoiceList = new List<AudioClip>();
			this.cacheAudioSourceNameList = new List<string>();
			if (this.audioClipBGMCacheList.Count > 0)
			{
				foreach (AudioClip audioClip in this.audioClipBGMCacheList)
				{
					if (!(audioClip == null))
					{
						this.cacheAudioSourceNameList.Add(audioClip.name);
					}
				}
			}
			if (this.audioClipSECacheList.Count > 0)
			{
				foreach (AudioClip audioClip2 in this.audioClipSECacheList)
				{
					if (!(audioClip2 == null))
					{
						this.cacheAudioSourceNameList.Add(audioClip2.name);
					}
				}
			}
			if (this.audioClipVoiceCacheList.Count > 0)
			{
				foreach (AudioClip audioClip3 in this.audioClipVoiceCacheList)
				{
					if (!(audioClip3 == null))
					{
						this.cacheAudioSourceNameList.Add(audioClip3.name);
					}
				}
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600114C RID: 4428 RVA: 0x0011B344 File Offset: 0x00119544
		// (set) Token: 0x0600114D RID: 4429 RVA: 0x0011B351 File Offset: 0x00119551
		public override float NowBGMVolum
		{
			get
			{
				return this.audioSourceBGM.volume;
			}
			set
			{
				this.audioSourceBGM.volume = value;
			}
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x0011B360 File Offset: 0x00119560
		public override void ChangeVolume(bool isMute, float volumeBGM, float volumeSE, float volumeVoice)
		{
			if (this.audioSourceBGM != null)
			{
				this.audioSourceBGM.mute = isMute;
				this.audioSourceBGM.volume = volumeBGM;
			}
			if (this.audioSourceSE != null)
			{
				for (int i = 0; i < this.audioSourceSE.Length; i++)
				{
					this.audioSourceSE[i].mute = isMute;
					this.audioSourceSE[i].volume = volumeSE;
				}
			}
			if (this.audioSourceVoice != null)
			{
				for (int j = 0; j < this.audioSourceVoice.Length; j++)
				{
					this.audioSourceVoice[j].mute = isMute;
					this.audioSourceVoice[j].volume = volumeVoice;
				}
			}
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x0011B402 File Offset: 0x00119602
		public override void SetVolume(float volume)
		{
			this.SetVolumeBGM(volume);
			this.SetVolumeSE(volume);
			this.SetVolumeVoice(volume);
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x0011B41C File Offset: 0x0011961C
		public override void SetMute(bool isMute)
		{
			this.audioSourceBGM.mute = isMute;
			AudioSource[] array = this.audioSourceSE;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].mute = isMute;
			}
			array = this.audioSourceVoice;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].mute = isMute;
			}
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x0011B474 File Offset: 0x00119674
		public override List<string> NameListBGM()
		{
			List<string> list = new List<string>();
			foreach (AudioClip audioClip in this.audioClipBGMCacheList)
			{
				if (!(audioClip == null))
				{
					list.Add(audioClip.name);
				}
			}
			foreach (AudioClip audioClip2 in this.audioClipBGMList)
			{
				if (!(audioClip2 == null))
				{
					list.Add(audioClip2.name);
				}
			}
			return list;
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x0011B52C File Offset: 0x0011972C
		public override void PlayBGM(string BGMAudioClipName, bool isLoop = true, float startTime = 0f)
		{
			AudioClip audioClip = null;
			if (this.cacheAudioSourceNameList.Contains(BGMAudioClipName))
			{
				using (List<AudioClip>.Enumerator enumerator = this.audioClipBGMCacheList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AudioClip audioClip2 = enumerator.Current;
						if (!(audioClip2 == null) && BGMAudioClipName.Equals(audioClip2.name))
						{
							audioClip = audioClip2;
							break;
						}
					}
					goto IL_00A4;
				}
			}
			foreach (AudioClip audioClip3 in this.audioClipBGMList)
			{
				if (!(audioClip3 == null) && BGMAudioClipName.Equals(audioClip3.name))
				{
					audioClip = audioClip3;
					break;
				}
			}
			IL_00A4:
			this.PlayBGM(audioClip, isLoop, startTime);
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x0011B604 File Offset: 0x00119804
		public override void PlayBGM(AudioClip audioClip, bool isLoop = true, float startTime = 0f)
		{
			if (audioClip == null || this.audioSourceBGM.clip == audioClip)
			{
				return;
			}
			this.audioSourceBGM.Stop();
			this.audioSourceBGM.clip = audioClip;
			this.audioSourceBGM.loop = isLoop;
			this.audioSourceBGM.time = Mathf.Clamp(startTime, 0f, audioClip.length);
			this.audioSourceBGM.Play();
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x0011B678 File Offset: 0x00119878
		public override void StopBGM()
		{
			this.audioSourceBGM.Stop();
			this.audioSourceBGM.clip = null;
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x0011B691 File Offset: 0x00119891
		public override void SetVolumeBGM(float volume)
		{
			this.audioSourceBGM.volume = volume;
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x0011B69F File Offset: 0x0011989F
		public override bool IsPlayingBGM()
		{
			return this.audioSourceBGM.isPlaying;
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x0011B6AC File Offset: 0x001198AC
		public override bool IsPlayingBGM(string BGMAudioClipName)
		{
			return this.audioSourceBGM.clip == this.GetBGMAudioClip(BGMAudioClipName) && this.audioSourceBGM.isPlaying;
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x0011B6D4 File Offset: 0x001198D4
		public override void PauseBGM()
		{
			this.audioSourceBGM.Pause();
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x0011B6E1 File Offset: 0x001198E1
		public override void RestartBGM()
		{
			this.audioSourceBGM.Play();
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0011B6F0 File Offset: 0x001198F0
		public override void LoadBGM(string path, bool isCache = false)
		{
			AudioClip audioClip = Resources.Load(path, typeof(AudioClip)) as AudioClip;
			this.LoadBGM(audioClip, isCache);
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0011B71C File Offset: 0x0011991C
		public override void LoadBGM(AudioClip audioClip, bool isCache = false)
		{
			if (isCache)
			{
				if (!this.cacheAudioSourceNameList.Contains(audioClip.name))
				{
					this.audioClipBGMCacheList.Add(audioClip);
					this.cacheAudioSourceNameList.Add(audioClip.name);
					return;
				}
			}
			else
			{
				this.audioClipBGMList.Add(audioClip);
			}
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x0011B76C File Offset: 0x0011996C
		public override void ReleaseBGM()
		{
			if (this.audioClipBGMList != null)
			{
				for (int i = this.audioClipBGMList.Count - 1; i >= 0; i--)
				{
					this.audioClipBGMList[i] = null;
				}
				this.audioClipBGMList.Clear();
			}
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x0011B7B4 File Offset: 0x001199B4
		private AudioClip GetBGMAudioClip(string BGMAudioClipName)
		{
			AudioClip audioClip = null;
			if (this.cacheAudioSourceNameList.Contains(BGMAudioClipName))
			{
				using (List<AudioClip>.Enumerator enumerator = this.audioClipBGMCacheList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AudioClip audioClip2 = enumerator.Current;
						if (BGMAudioClipName.Equals(audioClip2.name))
						{
							audioClip = audioClip2;
							break;
						}
					}
					return audioClip;
				}
			}
			foreach (AudioClip audioClip3 in this.audioClipBGMList)
			{
				if (BGMAudioClipName.Equals(audioClip3.name))
				{
					audioClip = audioClip3;
					break;
				}
			}
			return audioClip;
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0011B870 File Offset: 0x00119A70
		public override float GetBGMPlayTime()
		{
			return this.audioSourceBGM.time;
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x0011B880 File Offset: 0x00119A80
		public override float GetBGMLength()
		{
			float num = 0f;
			if (this.audioSourceBGM.clip != null)
			{
				num = this.audioSourceBGM.clip.length;
			}
			return num;
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x0011B8B8 File Offset: 0x00119AB8
		public override void SetBGMPitch(float pitch)
		{
			this.audioSourceBGM.pitch = pitch;
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0011B8C8 File Offset: 0x00119AC8
		public override List<string> NameListSE()
		{
			List<string> list = new List<string>();
			foreach (AudioClip audioClip in this.audioClipSECacheList)
			{
				list.Add(audioClip.name);
			}
			foreach (AudioClip audioClip2 in this.audioClipSEList)
			{
				list.Add(audioClip2.name);
			}
			return list;
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x0011B970 File Offset: 0x00119B70
		public override void PlaySE(string SEAudioClipName, bool isLoop = false)
		{
			if (string.IsNullOrEmpty(SEAudioClipName))
			{
				return;
			}
			AudioClip audioClip = null;
			if (this.cacheAudioSourceNameList.Contains(SEAudioClipName))
			{
				using (List<AudioClip>.Enumerator enumerator = this.audioClipSECacheList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AudioClip audioClip2 = enumerator.Current;
						if (!(audioClip2 == null) && SEAudioClipName == audioClip2.name)
						{
							audioClip = audioClip2;
							break;
						}
					}
					goto IL_00AD;
				}
			}
			foreach (AudioClip audioClip3 in this.audioClipSEList)
			{
				if (!(audioClip3 == null) && SEAudioClipName == audioClip3.name)
				{
					audioClip = audioClip3;
					break;
				}
			}
			IL_00AD:
			this.PlaySE(audioClip, isLoop);
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x0011BA50 File Offset: 0x00119C50
		public override void PlaySE(AudioClip audioClip, bool isLoop = false)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!audioSource.isPlaying && audioSource.time == 0f)
				{
					audioSource.clip = audioClip;
					audioSource.loop = isLoop;
					audioSource.Play();
					return;
				}
			}
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0011BAA0 File Offset: 0x00119CA0
		public override void StopSE()
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				audioSource.Stop();
				audioSource.loop = false;
				audioSource.clip = null;
			}
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x0011BAD8 File Offset: 0x00119CD8
		public override void StopSE(string SEAudioClipName, bool isStopJustForOne = false)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && SEAudioClipName == audioSource.clip.name)
				{
					audioSource.Stop();
					audioSource.loop = false;
					audioSource.clip = null;
					if (isStopJustForOne)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x0011BB38 File Offset: 0x00119D38
		public override void StopLoopSE()
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && audioSource.loop)
				{
					audioSource.Stop();
					audioSource.loop = false;
					audioSource.clip = null;
				}
			}
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x0011BB88 File Offset: 0x00119D88
		public override void StopLoopSE(string SEAudioClipName, bool isStopJustForOne = false)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && SEAudioClipName == audioSource.clip.name && audioSource.loop)
				{
					audioSource.Stop();
					audioSource.loop = false;
					audioSource.clip = null;
					if (isStopJustForOne)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x0011BBF0 File Offset: 0x00119DF0
		public override void SetVolumeSE(float volume)
		{
			AudioSource[] array = this.audioSourceSE;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].volume = volume;
			}
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x0011BC1B File Offset: 0x00119E1B
		public override bool IsPlayingSE(int trackIndex)
		{
			return this.audioSourceSE[trackIndex].isPlaying;
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x0011BC2C File Offset: 0x00119E2C
		public override bool IsPlayingSE(string SEAudioClipName)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && audioSource.clip == this.GetSEAudioClip(SEAudioClipName) && audioSource.isPlaying)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x0011BC80 File Offset: 0x00119E80
		public override void PauseSE()
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null))
				{
					audioSource.Pause();
				}
			}
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x0011BCBA File Offset: 0x00119EBA
		public override void PauseSE(int trackIndex)
		{
			this.audioSourceSE[trackIndex].Pause();
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x0011BCCC File Offset: 0x00119ECC
		public override void PauseSE(string SEAudioClipName)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && audioSource.clip == this.GetSEAudioClip(SEAudioClipName))
				{
					audioSource.Pause();
				}
			}
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x0011BD1C File Offset: 0x00119F1C
		public override void PauseLoopSE()
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && audioSource.loop)
				{
					audioSource.Pause();
				}
			}
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x0011BD60 File Offset: 0x00119F60
		public override void RestartSE()
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null))
				{
					audioSource.UnPause();
				}
			}
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x0011BD9C File Offset: 0x00119F9C
		public override void RestartSE(string SEAudioClipName)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && audioSource.clip == this.GetSEAudioClip(SEAudioClipName))
				{
					audioSource.UnPause();
				}
			}
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x0011BDEA File Offset: 0x00119FEA
		public override void RestartSE(int trackIndex)
		{
			this.audioSourceSE[trackIndex].UnPause();
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x0011BDFC File Offset: 0x00119FFC
		public override void RestartLoopSE()
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && audioSource.loop)
				{
					audioSource.UnPause();
				}
			}
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x0011BE40 File Offset: 0x0011A040
		public override void LoadSE(string path, bool isCache = false)
		{
			AudioClip audioClip = Resources.Load(path, typeof(AudioClip)) as AudioClip;
			this.LoadSE(audioClip, isCache);
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x0011BE6C File Offset: 0x0011A06C
		public override void LoadSE(AudioClip audioClip, bool isCache = false)
		{
			if (isCache)
			{
				if (!this.cacheAudioSourceNameList.Contains(audioClip.name))
				{
					this.audioClipSECacheList.Add(audioClip);
					this.cacheAudioSourceNameList.Add(audioClip.name);
					return;
				}
			}
			else
			{
				this.audioClipSEList.Add(audioClip);
			}
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x0011BEBC File Offset: 0x0011A0BC
		public override void ReleaseSE()
		{
			if (this.audioClipSEList != null)
			{
				for (int i = this.audioClipSEList.Count - 1; i >= 0; i--)
				{
					this.audioClipSEList[i] = null;
				}
				this.audioClipSEList.Clear();
			}
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x0011BF04 File Offset: 0x0011A104
		private AudioClip GetSEAudioClip(string SEAudioClipName)
		{
			if (string.IsNullOrEmpty(SEAudioClipName))
			{
				return null;
			}
			AudioClip audioClip = null;
			if (this.cacheAudioSourceNameList.Contains(SEAudioClipName))
			{
				using (List<AudioClip>.Enumerator enumerator = this.audioClipSECacheList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AudioClip audioClip2 = enumerator.Current;
						if (!(audioClip2 == null) && SEAudioClipName == audioClip2.name)
						{
							audioClip = audioClip2;
							break;
						}
					}
					return audioClip;
				}
			}
			foreach (AudioClip audioClip3 in this.audioClipSEList)
			{
				if (!(audioClip3 == null) && SEAudioClipName == audioClip3.name)
				{
					audioClip = audioClip3;
					break;
				}
			}
			return audioClip;
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x0011BFDC File Offset: 0x0011A1DC
		public override void SetSePitch(string SEAudioClipName, float pitch)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && SEAudioClipName == audioSource.clip.name)
				{
					audioSource.pitch = pitch;
				}
			}
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x0011C02C File Offset: 0x0011A22C
		public override AudioClip GetSeAudioClip(string SEAudioClipName)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && SEAudioClipName == audioSource.clip.name)
				{
					return audioSource.clip;
				}
			}
			return null;
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x0011C07C File Offset: 0x0011A27C
		public override AudioSource GetSeAudioSource(string SEAudioClipName)
		{
			foreach (AudioSource audioSource in this.audioSourceSE)
			{
				if (!(audioSource.clip == null) && SEAudioClipName == audioSource.clip.name)
				{
					return audioSource;
				}
			}
			return null;
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x0011C0C8 File Offset: 0x0011A2C8
		public override List<string> NameListVoice()
		{
			List<string> list = new List<string>();
			foreach (AudioClip audioClip in this.audioClipVoiceCacheList)
			{
				if (!(audioClip == null))
				{
					list.Add(audioClip.name);
				}
			}
			foreach (AudioClip audioClip2 in this.audioClipVoiceList)
			{
				if (!(audioClip2 == null))
				{
					list.Add(audioClip2.name);
				}
			}
			return list;
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x0011C180 File Offset: 0x0011A380
		public override void PlayVoice(string VoiceAudioClipName, bool isLoop = false)
		{
			if (string.IsNullOrEmpty(VoiceAudioClipName))
			{
				return;
			}
			AudioClip audioClip = null;
			if (this.cacheAudioSourceNameList.Contains(VoiceAudioClipName))
			{
				using (List<AudioClip>.Enumerator enumerator = this.audioClipVoiceCacheList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AudioClip audioClip2 = enumerator.Current;
						if (!(audioClip2 == null) && VoiceAudioClipName == audioClip2.name)
						{
							audioClip = audioClip2;
							break;
						}
					}
					goto IL_00AD;
				}
			}
			foreach (AudioClip audioClip3 in this.audioClipVoiceList)
			{
				if (!(audioClip3 == null) && VoiceAudioClipName == audioClip3.name)
				{
					audioClip = audioClip3;
					break;
				}
			}
			IL_00AD:
			this.PlayVoice(audioClip, isLoop);
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x0011C260 File Offset: 0x0011A460
		public override void PlayVoice(AudioClip audioClip, bool isLoop = false)
		{
			foreach (AudioSource audioSource in this.audioSourceVoice)
			{
				if (!audioSource.isPlaying)
				{
					audioSource.clip = audioClip;
					audioSource.loop = isLoop;
					audioSource.Play();
					return;
				}
			}
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x0011C2A4 File Offset: 0x0011A4A4
		public override void StopVoice()
		{
			foreach (AudioSource audioSource in this.audioSourceVoice)
			{
				audioSource.Stop();
				audioSource.loop = false;
				audioSource.clip = null;
			}
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x0011C2DC File Offset: 0x0011A4DC
		public override void StopVoice(string VoiceAudioClipName)
		{
			foreach (AudioSource audioSource in this.audioSourceVoice)
			{
				if (!(audioSource.clip == null) && VoiceAudioClipName == audioSource.clip.name)
				{
					audioSource.Stop();
					audioSource.loop = false;
					audioSource.clip = null;
				}
			}
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x0011C338 File Offset: 0x0011A538
		public override void StopLoopVoice()
		{
			foreach (AudioSource audioSource in this.audioSourceVoice)
			{
				if (audioSource.loop)
				{
					audioSource.Stop();
					audioSource.loop = false;
					audioSource.clip = null;
				}
			}
		}

		// Token: 0x06001180 RID: 4480 RVA: 0x0011C37C File Offset: 0x0011A57C
		public override void SetVolumeVoice(float volume)
		{
			AudioSource[] array = this.audioSourceVoice;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].volume = volume;
			}
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x0011C3A7 File Offset: 0x0011A5A7
		public override bool IsPlayingVoice(int trackIndex)
		{
			return this.audioSourceVoice[trackIndex].isPlaying;
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x0011C3B6 File Offset: 0x0011A5B6
		public override void PauseVoice(int trackIndex)
		{
			this.audioSourceVoice[trackIndex].Pause();
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x0011C3C5 File Offset: 0x0011A5C5
		public override void RestartVoice(int trackIndex)
		{
			this.audioSourceVoice[trackIndex].Play();
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x0011C3D4 File Offset: 0x0011A5D4
		public override void LoadVoice(string path, bool isCache = false)
		{
			AudioClip audioClip = Resources.Load(path, typeof(AudioClip)) as AudioClip;
			this.LoadVoice(audioClip, isCache);
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x0011C400 File Offset: 0x0011A600
		public override void LoadVoice(AudioClip audioClip, bool isCache = false)
		{
			if (isCache)
			{
				if (!this.cacheAudioSourceNameList.Contains(audioClip.name))
				{
					this.audioClipVoiceCacheList.Add(audioClip);
					this.cacheAudioSourceNameList.Add(audioClip.name);
					return;
				}
			}
			else
			{
				this.audioClipVoiceList.Add(audioClip);
			}
		}

		// Token: 0x06001186 RID: 4486 RVA: 0x0011C450 File Offset: 0x0011A650
		public override void ReleaseVoice()
		{
			if (this.audioClipVoiceList != null)
			{
				for (int i = this.audioClipVoiceList.Count - 1; i >= 0; i--)
				{
					this.audioClipVoiceList[i] = null;
				}
				this.audioClipVoiceList.Clear();
			}
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x0011C498 File Offset: 0x0011A698
		public override float GetBgmSourceVolume()
		{
			float num = 0f;
			if (this.audioSourceBGM.clip == null)
			{
				return num;
			}
			float[] array = new float[256];
			for (int i = 0; i < this.audioSourceBGM.clip.channels; i++)
			{
				float num2 = 0f;
				float num3 = 0f;
				this.audioSourceBGM.GetOutputData(array, i);
				float[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					float num4 = Mathf.Abs(array2[j]);
					num2 += num4;
					num3 += 1f;
				}
				num2 /= num3;
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x04000A06 RID: 2566
		[SerializeField]
		private int SEAudioSourceCount;

		// Token: 0x04000A07 RID: 2567
		[SerializeField]
		private int VoiceAudioSourceCount;

		// Token: 0x04000A08 RID: 2568
		[SerializeField]
		private List<AudioClip> audioClipBGMCacheList;

		// Token: 0x04000A09 RID: 2569
		[SerializeField]
		private List<AudioClip> audioClipSECacheList;

		// Token: 0x04000A0A RID: 2570
		[SerializeField]
		private List<AudioClip> audioClipVoiceCacheList;

		// Token: 0x04000A0B RID: 2571
		private List<AudioClip> audioClipBGMList;

		// Token: 0x04000A0C RID: 2572
		private List<AudioClip> audioClipSEList;

		// Token: 0x04000A0D RID: 2573
		private List<AudioClip> audioClipVoiceList;

		// Token: 0x04000A0E RID: 2574
		private List<string> cacheAudioSourceNameList;

		// Token: 0x04000A0F RID: 2575
		private AudioSource audioSourceBGM;

		// Token: 0x04000A10 RID: 2576
		private AudioSource[] audioSourceSE;

		// Token: 0x04000A11 RID: 2577
		private AudioSource[] audioSourceVoice;
	}
}
