using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000C7 RID: 199
	public abstract class SoundController : MonoBehaviour
	{
		// Token: 0x060011D5 RID: 4565
		public abstract void Destroy();

		// Token: 0x060011D6 RID: 4566
		public abstract void Init(GameObject gameObject, bool isMute, float volumeBGM, float volumeSE, float volumeVoice);

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060011D7 RID: 4567
		// (set) Token: 0x060011D8 RID: 4568
		public abstract float NowBGMVolum { get; set; }

		// Token: 0x060011D9 RID: 4569
		public abstract void ChangeVolume(bool isMute, float volumeBGM, float volumeSE, float volumeVoice);

		// Token: 0x060011DA RID: 4570
		public abstract void SetVolume(float volume);

		// Token: 0x060011DB RID: 4571
		public abstract void SetMute(bool isMute);

		// Token: 0x060011DC RID: 4572
		public abstract List<string> NameListBGM();

		// Token: 0x060011DD RID: 4573
		public abstract void PlayBGM(string BGMAudioClipName, bool isLoop = true, float startTime = 0f);

		// Token: 0x060011DE RID: 4574
		public abstract void PlayBGM(AudioClip audioClip, bool isLoop = true, float startTime = 0f);

		// Token: 0x060011DF RID: 4575
		public abstract void StopBGM();

		// Token: 0x060011E0 RID: 4576
		public abstract void SetVolumeBGM(float volume);

		// Token: 0x060011E1 RID: 4577
		public abstract bool IsPlayingBGM();

		// Token: 0x060011E2 RID: 4578
		public abstract bool IsPlayingBGM(string BGMAudioClipName);

		// Token: 0x060011E3 RID: 4579
		public abstract void PauseBGM();

		// Token: 0x060011E4 RID: 4580
		public abstract void RestartBGM();

		// Token: 0x060011E5 RID: 4581
		public abstract void LoadBGM(string path, bool isCache = false);

		// Token: 0x060011E6 RID: 4582
		public abstract void LoadBGM(AudioClip audioClip, bool isCache = false);

		// Token: 0x060011E7 RID: 4583
		public abstract void ReleaseBGM();

		// Token: 0x060011E8 RID: 4584
		public abstract float GetBGMPlayTime();

		// Token: 0x060011E9 RID: 4585
		public abstract float GetBGMLength();

		// Token: 0x060011EA RID: 4586
		public abstract void SetBGMPitch(float pitch);

		// Token: 0x060011EB RID: 4587
		public abstract List<string> NameListSE();

		// Token: 0x060011EC RID: 4588
		public abstract void PlaySE(string SEAudioClipName, bool isLoop = false);

		// Token: 0x060011ED RID: 4589
		public abstract void PlaySE(AudioClip audioClip, bool isLoop = false);

		// Token: 0x060011EE RID: 4590
		public abstract void StopSE();

		// Token: 0x060011EF RID: 4591
		public abstract void StopSE(string SEAudioClipName, bool isStopJustForOne = false);

		// Token: 0x060011F0 RID: 4592
		public abstract void StopLoopSE();

		// Token: 0x060011F1 RID: 4593
		public abstract void StopLoopSE(string SEAudioClipName, bool isStopJustForOne = false);

		// Token: 0x060011F2 RID: 4594
		public abstract void SetVolumeSE(float volume);

		// Token: 0x060011F3 RID: 4595
		public abstract bool IsPlayingSE(int trackIndex);

		// Token: 0x060011F4 RID: 4596
		public abstract bool IsPlayingSE(string SEAudioClipName);

		// Token: 0x060011F5 RID: 4597
		public abstract void PauseSE();

		// Token: 0x060011F6 RID: 4598
		public abstract void PauseSE(int trackIndex);

		// Token: 0x060011F7 RID: 4599
		public abstract void PauseSE(string SEAudioClipName);

		// Token: 0x060011F8 RID: 4600
		public abstract void PauseLoopSE();

		// Token: 0x060011F9 RID: 4601
		public abstract void RestartSE();

		// Token: 0x060011FA RID: 4602
		public abstract void RestartSE(int trackIndex);

		// Token: 0x060011FB RID: 4603
		public abstract void RestartSE(string SEAudioClipName);

		// Token: 0x060011FC RID: 4604
		public abstract void RestartLoopSE();

		// Token: 0x060011FD RID: 4605
		public abstract void LoadSE(string path, bool isCache = false);

		// Token: 0x060011FE RID: 4606
		public abstract void LoadSE(AudioClip audioClip, bool isCache = false);

		// Token: 0x060011FF RID: 4607
		public abstract void ReleaseSE();

		// Token: 0x06001200 RID: 4608
		public abstract void SetSePitch(string SEAudioClipName, float pitch);

		// Token: 0x06001201 RID: 4609
		public abstract AudioClip GetSeAudioClip(string SEAudioClipName);

		// Token: 0x06001202 RID: 4610
		public abstract AudioSource GetSeAudioSource(string SEAudioClipName);

		// Token: 0x06001203 RID: 4611
		public abstract List<string> NameListVoice();

		// Token: 0x06001204 RID: 4612
		public abstract void PlayVoice(string VoiceAudioClipName, bool isLoop = false);

		// Token: 0x06001205 RID: 4613
		public abstract void PlayVoice(AudioClip audioClip, bool isLoop = false);

		// Token: 0x06001206 RID: 4614
		public abstract void StopVoice();

		// Token: 0x06001207 RID: 4615
		public abstract void StopVoice(string VoiceAudioClipName);

		// Token: 0x06001208 RID: 4616
		public abstract void StopLoopVoice();

		// Token: 0x06001209 RID: 4617
		public abstract void SetVolumeVoice(float volume);

		// Token: 0x0600120A RID: 4618
		public abstract bool IsPlayingVoice(int trackIndex);

		// Token: 0x0600120B RID: 4619
		public abstract void PauseVoice(int trackIndex);

		// Token: 0x0600120C RID: 4620
		public abstract void RestartVoice(int trackIndex);

		// Token: 0x0600120D RID: 4621
		public abstract void LoadVoice(string path, bool isCache = false);

		// Token: 0x0600120E RID: 4622
		public abstract void LoadVoice(AudioClip audioClip, bool isCache = false);

		// Token: 0x0600120F RID: 4623
		public abstract void ReleaseVoice();

		// Token: 0x06001210 RID: 4624
		public abstract float GetBgmSourceVolume();
	}
}
