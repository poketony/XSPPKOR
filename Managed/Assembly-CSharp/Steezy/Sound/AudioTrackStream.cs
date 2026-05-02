using System;
using System.IO;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000BB RID: 187
	public class AudioTrackStream
	{
		// Token: 0x060010D3 RID: 4307 RVA: 0x00119E98 File Offset: 0x00118098
		public bool Create(int rate, int channel, int quantum)
		{
			bool flag = false;
			this.audioObj = new GameObject("AudioTrackStream");
			if (this.audioObj != null)
			{
				this.audioSource = this.audioObj.AddComponent<AudioSource>();
				this.acm = new AudioClipMaker();
				if (this.acm != null)
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x00119EEC File Offset: 0x001180EC
		public void Delete()
		{
			if (this.audioClip != null)
			{
				this.audioClip = null;
			}
			if (this.audioSource != null)
			{
				this.audioSource = null;
			}
			if (this.audioObj != null)
			{
				this.audioObj = null;
			}
			if (this.audioData != null)
			{
				this.audioData = null;
			}
			if (this.wavInfo != null)
			{
				this.wavInfo = null;
			}
			if (this.acm != null)
			{
				this.acm = null;
			}
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x00119F68 File Offset: 0x00118168
		public bool LoadSoundData(string path)
		{
			bool flag = false;
			this.wavInfo = new WavInfo();
			if (this.wavInfo != null && this.wavInfo.Create())
			{
				byte[] array = File.ReadAllBytes(path);
				if (array != null && this.wavInfo.Analyze(array))
				{
					this.audioData = this.acm.CreateRangedRawData(this.wavInfo.FrequencyData, this.wavInfo.FrequencyDataOffset, this.wavInfo.SampleValue, this.wavInfo.ChannelNum, this.wavInfo.BitPerSample);
					this.audioClip = this.acm.CreateStream("audioTrackStream", this.wavInfo.SampleValue, this.wavInfo.ChannelNum, this.wavInfo.SamplingRate, false, new AudioClip.PCMReaderCallback(this.OnAudioRead), new AudioClip.PCMSetPositionCallback(this.OnAudioSetPosition));
					if (this.audioClip != null)
					{
						this.audioSource.clip = this.audioClip;
						this.streamPos = 0;
						flag = true;
					}
				}
			}
			return flag;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x0011A07C File Offset: 0x0011827C
		private void OnAudioRead(float[] dat)
		{
			if (this.audioData != null && this.streamPos < this.audioData.Length)
			{
				int i = 0;
				while (i < dat.Length)
				{
					if (i + this.streamPos < this.audioData.Length)
					{
						dat[i] = this.audioData[i + this.streamPos];
						i++;
					}
					else
					{
						i = dat.Length;
					}
				}
				this.streamPos += i;
			}
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0011A0E7 File Offset: 0x001182E7
		private void OnAudioSetPosition(int newPos)
		{
			this.streamPos = newPos;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0011A0F0 File Offset: 0x001182F0
		public void Play(bool loop)
		{
			if (this.audioSource != null)
			{
				this.audioSource.loop = loop;
				this.audioSource.Play();
			}
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0011A117 File Offset: 0x00118317
		public void Play(int pos, bool loop)
		{
			if (this.audioSource != null)
			{
				this.audioSource.loop = loop;
				this.audioSource.Play();
			}
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0011A13E File Offset: 0x0011833E
		public void Stop()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Stop();
			}
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0011A159 File Offset: 0x00118359
		public void Pause()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Pause();
			}
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0011A174 File Offset: 0x00118374
		public void Resume()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Play();
			}
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0011A18F File Offset: 0x0011838F
		public void SetVolume(float volume)
		{
			if (this.audioSource != null)
			{
				this.audioSource.volume = volume;
			}
		}

		// Token: 0x040009C3 RID: 2499
		public const int FAILED = -1;

		// Token: 0x040009C4 RID: 2500
		public const int SUCCESS = 0;

		// Token: 0x040009C5 RID: 2501
		public const int AUDIOFORMAT_QUANTUM_INVALID = 0;

		// Token: 0x040009C6 RID: 2502
		public const int AUDIOFORMAT_QUANTUM_DEFAULT = 1;

		// Token: 0x040009C7 RID: 2503
		public const int AUDIOFORMAT_QUANTUM_16BIT = 2;

		// Token: 0x040009C8 RID: 2504
		public const int AUDIOFORMAT_QUANTUM_8BIT = 3;

		// Token: 0x040009C9 RID: 2505
		public const int AUDIOFROMAT_CHANNEL_OUT_MONO = 4;

		// Token: 0x040009CA RID: 2506
		public const int AUDIOFROMAT_CHANNEL_OUT_STEREO = 12;

		// Token: 0x040009CB RID: 2507
		private string clsPath;

		// Token: 0x040009CC RID: 2508
		private GameObject audioObj;

		// Token: 0x040009CD RID: 2509
		private AudioSource audioSource;

		// Token: 0x040009CE RID: 2510
		private AudioClip audioClip;

		// Token: 0x040009CF RID: 2511
		private WavInfo wavInfo;

		// Token: 0x040009D0 RID: 2512
		private AudioClipMaker acm;

		// Token: 0x040009D1 RID: 2513
		private float[] audioData;

		// Token: 0x040009D2 RID: 2514
		private int streamPos;
	}
}
