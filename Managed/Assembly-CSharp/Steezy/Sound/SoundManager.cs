using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000C6 RID: 198
	public class SoundManager : MonoBehaviour
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06001189 RID: 4489 RVA: 0x0011C548 File Offset: 0x0011A748
		// (remove) Token: 0x0600118A RID: 4490 RVA: 0x0011C580 File Offset: 0x0011A780
		public event SoundManager.BGMFadeCallback BGMFadeOutAfter;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600118B RID: 4491 RVA: 0x0011C5B8 File Offset: 0x0011A7B8
		// (remove) Token: 0x0600118C RID: 4492 RVA: 0x0011C5F0 File Offset: 0x0011A7F0
		public event SoundManager.BGMFadeCallback BGMFadeInAfter;

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600118D RID: 4493 RVA: 0x0011C625 File Offset: 0x0011A825
		public static SoundManager Instance
		{
			get
			{
				if (SoundManager.instance == null)
				{
					SoundManager.instance = (SoundManager)Object.FindObjectOfType(typeof(SoundManager));
				}
				return SoundManager.instance;
			}
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x0011C652 File Offset: 0x0011A852
		public void OnApplicationQuit()
		{
			if (SoundManager.instance != null)
			{
				Object.Destroy(SoundManager.instance);
			}
			SoundManager.instance = null;
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x0011C671 File Offset: 0x0011A871
		private void OnDestroy()
		{
			this.controller.Destroy();
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x0011C67E File Offset: 0x0011A87E
		private void Awake()
		{
			if (this.dontDestroyOnLoad)
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
			this.Init();
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x0011C69C File Offset: 0x0011A89C
		private void Update()
		{
			if (this.fadeStatus == SoundManager.BGMFadeStatus.FadeStop || this.fadeStatus == SoundManager.BGMFadeStatus.FadeInFinish || this.fadeStatus == SoundManager.BGMFadeStatus.FadeOutFinish)
			{
				return;
			}
			if (this.fadeStatus == SoundManager.BGMFadeStatus.FadeInPlaying)
			{
				this.controller.NowBGMVolum += Time.deltaTime * this.BGMFadeVolumeRange / this.BGMFadeTime;
				if (this.controller.NowBGMVolum > this.BGMFadeEndVolume)
				{
					this.controller.NowBGMVolum = this.BGMFadeEndVolume;
					this.fadeStatus = SoundManager.BGMFadeStatus.FadeInFinish;
				}
			}
			if (this.fadeStatus == SoundManager.BGMFadeStatus.FadeOutPlaying)
			{
				this.controller.NowBGMVolum -= Time.deltaTime * this.BGMFadeVolumeRange / this.BGMFadeTime;
				if (this.controller.NowBGMVolum <= this.BGMFadeEndVolume)
				{
					this.controller.NowBGMVolum = this.BGMFadeEndVolume;
					this.fadeStatus = SoundManager.BGMFadeStatus.FadeOutFinish;
					this.StopBGM();
					this.ChangeVolume();
				}
			}
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x0011C784 File Offset: 0x0011A984
		public void Init()
		{
			if (this.controller == null)
			{
				if (this.useAudioSource)
				{
					this.controller = base.GetComponent<AudioSourceController>();
				}
				else
				{
					this.controller = base.GetComponent<AudioSourceController>();
				}
				this.controller.Init(base.gameObject, this.isMute, this.volumeBGM, this.volumeSE, this.volumeVoice);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06001193 RID: 4499 RVA: 0x0011C7EA File Offset: 0x0011A9EA
		public float NowBGMVolum
		{
			get
			{
				return this.controller.NowBGMVolum;
			}
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x0011C7F7 File Offset: 0x0011A9F7
		public void ChangeVolume()
		{
			this.controller.ChangeVolume(this.isMute, this.volumeBGM, this.volumeSE, this.volumeVoice);
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x0011C81C File Offset: 0x0011AA1C
		public void SetVolume(float volume)
		{
			this.SetVolumeBGM(volume);
			this.SetVolumeSE(volume);
		}

		// Token: 0x06001196 RID: 4502 RVA: 0x0011C82C File Offset: 0x0011AA2C
		public bool GetMute()
		{
			return this.isMute;
		}

		// Token: 0x06001197 RID: 4503 RVA: 0x0011C834 File Offset: 0x0011AA34
		public void SetMute(bool isMute)
		{
			if (this.isMute != isMute)
			{
				this.controller.SetMute(isMute);
				this.isMute = isMute;
			}
		}

		// Token: 0x06001198 RID: 4504 RVA: 0x0011C852 File Offset: 0x0011AA52
		public List<string> NameListBGM()
		{
			return this.controller.NameListBGM();
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x0011C85F File Offset: 0x0011AA5F
		public void PlayBGM(string BGMAudioClipName, bool isLoop = true, float startTime = 0f)
		{
			this.controller.PlayBGM(BGMAudioClipName, isLoop, startTime);
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x0011C86F File Offset: 0x0011AA6F
		public void StopBGM()
		{
			this.controller.StopBGM();
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0011C87C File Offset: 0x0011AA7C
		public void SetVolumeBGM(float volume)
		{
			if (this.volumeBGM != volume)
			{
				this.controller.SetVolumeBGM(volume);
				this.volumeBGM = volume;
			}
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0011C89A File Offset: 0x0011AA9A
		public bool IsPlayingBGM()
		{
			return this.controller.IsPlayingBGM();
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0011C8A7 File Offset: 0x0011AAA7
		public bool IsPlayingBGM(string BGMAudioClipName)
		{
			return this.controller.IsPlayingBGM(BGMAudioClipName);
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0011C8B5 File Offset: 0x0011AAB5
		public void PauseBGM()
		{
			this.controller.PauseBGM();
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0011C8C2 File Offset: 0x0011AAC2
		public void RestartBGM()
		{
			this.controller.RestartBGM();
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0011C8CF File Offset: 0x0011AACF
		public void LoadBGM(string path, bool isCache = false)
		{
			this.controller.LoadBGM(path, isCache);
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0011C8DE File Offset: 0x0011AADE
		public void LoadBGM(AudioClip audioClip, bool isCache = false)
		{
			this.controller.LoadBGM(audioClip, isCache);
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0011C8ED File Offset: 0x0011AAED
		public void ReleaseBGM()
		{
			this.controller.ReleaseBGM();
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0011C8FA File Offset: 0x0011AAFA
		public float GetBGMPlayTime()
		{
			return this.controller.GetBGMPlayTime();
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x0011C907 File Offset: 0x0011AB07
		public void SetBGMPitch(float pitch)
		{
			this.controller.SetBGMPitch(pitch);
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x0011C915 File Offset: 0x0011AB15
		public List<string> NameListSE()
		{
			return this.controller.NameListSE();
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x0011C922 File Offset: 0x0011AB22
		public void PlaySE(string SEAudioClipName, bool isLoop = false)
		{
			if (string.IsNullOrEmpty(SEAudioClipName))
			{
				return;
			}
			this.controller.PlaySE(SEAudioClipName, isLoop);
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0011C93A File Offset: 0x0011AB3A
		public void StopSE()
		{
			this.controller.StopSE();
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0011C947 File Offset: 0x0011AB47
		public void StopSE(string SEAudioClipName, bool isStopJustForOne = false)
		{
			this.controller.StopSE(SEAudioClipName, isStopJustForOne);
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x0011C956 File Offset: 0x0011AB56
		public void StopLoopSE()
		{
			this.controller.StopLoopSE();
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x0011C963 File Offset: 0x0011AB63
		public void StopLoopSE(string SEAudioClipName, bool isStopJustForOne = false)
		{
			this.controller.StopLoopSE(SEAudioClipName, isStopJustForOne);
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x0011C972 File Offset: 0x0011AB72
		public void SetVolumeSE(float volume)
		{
			if (this.volumeSE != volume)
			{
				this.controller.SetVolumeSE(volume);
				this.volumeSE = volume;
			}
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x0011C990 File Offset: 0x0011AB90
		public bool IsPlayingSE(int trackIndex)
		{
			return this.controller.IsPlayingSE(trackIndex);
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x0011C99E File Offset: 0x0011AB9E
		public bool IsPlayingSE(string SEAudioClipName)
		{
			return this.controller.IsPlayingSE(SEAudioClipName);
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x0011C9AC File Offset: 0x0011ABAC
		public void PauseSE()
		{
			this.controller.PauseSE();
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x0011C9B9 File Offset: 0x0011ABB9
		public void PauseSE(int trackIndex)
		{
			this.controller.PauseSE(trackIndex);
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x0011C9C7 File Offset: 0x0011ABC7
		public void PauseSE(string SEAudioClipName)
		{
			this.controller.PauseSE(SEAudioClipName);
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0011C9D5 File Offset: 0x0011ABD5
		public void PauseLoopSE()
		{
			this.controller.PauseLoopSE();
		}

		// Token: 0x060011B2 RID: 4530 RVA: 0x0011C9E2 File Offset: 0x0011ABE2
		public void RestartSE()
		{
			this.controller.RestartSE();
		}

		// Token: 0x060011B3 RID: 4531 RVA: 0x0011C9EF File Offset: 0x0011ABEF
		public void RestartSE(int trackIndex)
		{
			this.controller.RestartSE(trackIndex);
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0011C9FD File Offset: 0x0011ABFD
		public void RestartSE(string SEAudioClipName)
		{
			this.controller.RestartSE(SEAudioClipName);
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x0011CA0B File Offset: 0x0011AC0B
		public void RestartLoopSE()
		{
			this.controller.RestartLoopSE();
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0011CA18 File Offset: 0x0011AC18
		public void LoadSE(string path, bool isCache = false)
		{
			this.controller.LoadSE(path, isCache);
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0011CA27 File Offset: 0x0011AC27
		public void LoadSE(AudioClip audioClip, bool isCache = false)
		{
			this.controller.LoadSE(audioClip, isCache);
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x0011CA36 File Offset: 0x0011AC36
		public void ReleaseSE()
		{
			this.controller.ReleaseSE();
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x0011CA43 File Offset: 0x0011AC43
		public void PlaySeDelay(float delayTime, string SEAudioClipName, bool isLoop = false)
		{
			base.StartCoroutine(this.CallBackPlaySeDelay(delayTime, SEAudioClipName, isLoop));
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0011CA55 File Offset: 0x0011AC55
		private IEnumerator CallBackPlaySeDelay(float delayTime, string SEAudioClipName, bool isLoop = false)
		{
			yield return new WaitForSeconds(delayTime);
			this.PlaySE(SEAudioClipName, isLoop);
			yield break;
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x0011CA79 File Offset: 0x0011AC79
		public void SetSePitch(string SEAudioClipName, float pitch)
		{
			this.controller.SetSePitch(SEAudioClipName, pitch);
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x0011CA88 File Offset: 0x0011AC88
		public AudioClip GetSeAudioClip(string SEAudioClipName)
		{
			return this.controller.GetSeAudioClip(SEAudioClipName);
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x0011CA96 File Offset: 0x0011AC96
		public AudioSource GetSeAudioSource(string SEAudioClipName)
		{
			return this.controller.GetSeAudioSource(SEAudioClipName);
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0011CAA4 File Offset: 0x0011ACA4
		public List<string> NameListVoice()
		{
			return this.controller.NameListVoice();
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0011CAB1 File Offset: 0x0011ACB1
		public void PlayVoice(string VoiceAudioClipName, bool isLoop = false)
		{
			if (string.IsNullOrEmpty(VoiceAudioClipName))
			{
				return;
			}
			this.controller.PlayVoice(VoiceAudioClipName, isLoop);
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0011CAC9 File Offset: 0x0011ACC9
		public void StopVoice()
		{
			this.controller.StopVoice();
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x0011CAD6 File Offset: 0x0011ACD6
		public void StopVoice(string VoiceAudioClipName)
		{
			this.controller.StopVoice(VoiceAudioClipName);
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x0011CAE4 File Offset: 0x0011ACE4
		public void StopLoopVoice()
		{
			this.controller.StopLoopVoice();
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0011CAF1 File Offset: 0x0011ACF1
		public void SetVolumeVoice(float volume)
		{
			if (this.volumeVoice != volume)
			{
				this.controller.SetVolumeVoice(volume);
				this.volumeVoice = volume;
			}
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0011CB0F File Offset: 0x0011AD0F
		public bool IsPlayingVoice(int trackIndex)
		{
			return this.controller.IsPlayingVoice(trackIndex);
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0011CB1D File Offset: 0x0011AD1D
		public void PauseVoice(int trackIndex)
		{
			this.controller.PauseVoice(trackIndex);
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0011CB2B File Offset: 0x0011AD2B
		public void RestartVoice(int trackIndex)
		{
			this.controller.RestartVoice(trackIndex);
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0011CB39 File Offset: 0x0011AD39
		public void LoadVoice(string path, bool isCache = false)
		{
			this.controller.LoadVoice(path, isCache);
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0011CB48 File Offset: 0x0011AD48
		public void LoadVoice(AudioClip audioClip, bool isCache = false)
		{
			this.controller.LoadVoice(audioClip, isCache);
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0011CB57 File Offset: 0x0011AD57
		public void ReleaseVoice()
		{
			this.controller.ReleaseVoice();
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0011CB64 File Offset: 0x0011AD64
		public void PlayVoiceDelay(float delayTime, string VoiceAudioClipName, bool isLoop = false)
		{
			base.StartCoroutine(this.CallBackPlayVoiceDelay(delayTime, VoiceAudioClipName, isLoop));
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0011CB76 File Offset: 0x0011AD76
		private IEnumerator CallBackPlayVoiceDelay(float delayTime, string VoiceAudioClipName, bool isLoop = false)
		{
			yield return new WaitForSeconds(delayTime);
			this.PlayVoice(VoiceAudioClipName, isLoop);
			yield break;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0011CB9A File Offset: 0x0011AD9A
		public void PlayBGMFadeIn(string BGMName, float fadeTime = 0f, bool isLoop = true, float startTime = 0f, bool hasCheckSameBgm = true)
		{
			this.playBGMName = BGMName;
			this.bgmStartTime = startTime;
			this.PlayBGMFade(SoundManager.BGMFadeType.In, 0f, this.volumeBGM, fadeTime, isLoop, hasCheckSameBgm);
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0011CBC1 File Offset: 0x0011ADC1
		public void PlayBGMFadeOut(float fadeTime = 0f)
		{
			this.playBGMName = "";
			this.PlayBGMFade(SoundManager.BGMFadeType.Out, this.volumeBGM, 0f, fadeTime, true, true);
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0011CBE3 File Offset: 0x0011ADE3
		public void PlayBGMFadeOutIn(string BGMName, float fadeTime = 0f, bool isLoop = true, float startTime = 0f, bool hasCheckSameBgm = true)
		{
			this.playBGMName = BGMName;
			this.bgmStartTime = startTime;
			this.PlayBGMFade(SoundManager.BGMFadeType.OutIn, this.volumeBGM, this.volumeBGM, fadeTime, isLoop, hasCheckSameBgm);
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x0011CC0C File Offset: 0x0011AE0C
		public void PlayBGMFade(SoundManager.BGMFadeType type, float startVolume, float endVolume, float fadeTime = 0f, bool isLoop = true, bool hasCheckSameBgm = true)
		{
			if (this.isFadeIn)
			{
				this.PlayBGM(this.playBGMName, isLoop, this.bgmStartTime);
				return;
			}
			if (hasCheckSameBgm && this.IsPlayingBGM(this.playBGMName))
			{
				return;
			}
			if (fadeTime <= 0f)
			{
				fadeTime = this.defaultBGMFadeTime;
			}
			switch (type)
			{
			case SoundManager.BGMFadeType.In:
				if (!string.IsNullOrEmpty(this.playBGMName))
				{
					this.PlayBGM(this.playBGMName, isLoop, this.bgmStartTime);
				}
				this.BGMFadeTime = fadeTime;
				this.BGMFadeEndVolume = endVolume;
				this.controller.NowBGMVolum = startVolume;
				this.BGMFadeVolumeRange = Math.Abs(this.BGMFadeEndVolume - startVolume);
				this.fadeStatus = SoundManager.BGMFadeStatus.FadeInPlaying;
				base.StartCoroutine(this.BGMFadeInStart());
				return;
			case SoundManager.BGMFadeType.Out:
				this.BGMFadeTime = fadeTime;
				this.BGMFadeEndVolume = endVolume;
				this.controller.NowBGMVolum = startVolume;
				this.BGMFadeVolumeRange = Math.Abs(this.BGMFadeEndVolume - startVolume);
				this.fadeStatus = SoundManager.BGMFadeStatus.FadeOutPlaying;
				base.StartCoroutine(this.BGMFadeOutStart());
				return;
			case SoundManager.BGMFadeType.OutIn:
				this.BGMFadeTime = fadeTime;
				this.controller.NowBGMVolum = startVolume;
				base.StartCoroutine(this.BGMFadeOutInStart(endVolume, isLoop, hasCheckSameBgm));
				return;
			default:
				return;
			}
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0011CD3A File Offset: 0x0011AF3A
		private IEnumerator BGMFadeOutStart()
		{
			yield return new WaitForSeconds(this.BGMFadeTime);
			if (this.BGMFadeOutAfter != null)
			{
				this.BGMFadeOutAfter();
				this.BGMFadeOutAfter = null;
			}
			yield break;
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x0011CD49 File Offset: 0x0011AF49
		private IEnumerator BGMFadeInStart()
		{
			this.isFadeIn = true;
			yield return new WaitForSeconds(this.BGMFadeTime);
			if (this.BGMFadeInAfter != null)
			{
				this.BGMFadeInAfter();
				this.BGMFadeInAfter = null;
			}
			this.isFadeIn = false;
			yield break;
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x0011CD58 File Offset: 0x0011AF58
		private IEnumerator BGMFadeOutInStart(float endVolume, bool isLoop = true, bool hasCheckSameBgm = true)
		{
			this.PlayBGMFade(SoundManager.BGMFadeType.Out, this.NowBGMVolum, 0f, this.BGMFadeTime, isLoop, hasCheckSameBgm);
			yield return new WaitForSeconds(this.BGMFadeTime);
			this.PlayBGMFade(SoundManager.BGMFadeType.In, 0f, endVolume, this.BGMFadeTime, isLoop, hasCheckSameBgm);
			yield break;
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0011CD7C File Offset: 0x0011AF7C
		public float GetBgmSourceVolume()
		{
			return this.controller.GetBgmSourceVolume();
		}

		// Token: 0x04000A12 RID: 2578
		[SerializeField]
		private bool dontDestroyOnLoad = true;

		// Token: 0x04000A13 RID: 2579
		[SerializeField]
		private bool useAudioSource = true;

		// Token: 0x04000A14 RID: 2580
		[SerializeField]
		private float volumeBGM = 1f;

		// Token: 0x04000A15 RID: 2581
		[SerializeField]
		private float volumeSE = 1f;

		// Token: 0x04000A16 RID: 2582
		[SerializeField]
		private float volumeVoice = 1f;

		// Token: 0x04000A17 RID: 2583
		[SerializeField]
		private bool isMute;

		// Token: 0x04000A18 RID: 2584
		[SerializeField]
		private float defaultBGMFadeTime = 3f;

		// Token: 0x04000A19 RID: 2585
		private SoundManager.BGMFadeStatus fadeStatus;

		// Token: 0x04000A1C RID: 2588
		private float BGMFadeEndVolume;

		// Token: 0x04000A1D RID: 2589
		private float BGMFadeVolumeRange;

		// Token: 0x04000A1E RID: 2590
		private float BGMFadeTime;

		// Token: 0x04000A1F RID: 2591
		private static SoundManager instance;

		// Token: 0x04000A20 RID: 2592
		private SoundController controller;

		// Token: 0x04000A21 RID: 2593
		private bool isFadeIn;

		// Token: 0x04000A22 RID: 2594
		private string playBGMName;

		// Token: 0x04000A23 RID: 2595
		private float bgmStartTime;

		// Token: 0x02000213 RID: 531
		public enum BGMFadeStatus
		{
			// Token: 0x0400143F RID: 5183
			FadeStop,
			// Token: 0x04001440 RID: 5184
			FadeInPlaying,
			// Token: 0x04001441 RID: 5185
			FadeInFinish,
			// Token: 0x04001442 RID: 5186
			FadeOutPlaying,
			// Token: 0x04001443 RID: 5187
			FadeOutFinish
		}

		// Token: 0x02000214 RID: 532
		public enum BGMFadeType
		{
			// Token: 0x04001445 RID: 5189
			In,
			// Token: 0x04001446 RID: 5190
			Out,
			// Token: 0x04001447 RID: 5191
			OutIn
		}

		// Token: 0x02000215 RID: 533
		// (Invoke) Token: 0x06001CF9 RID: 7417
		public delegate void BGMFadeCallback();
	}
}
