using System;
using System.IO;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000BC RID: 188
	public class MMediaPlayer
	{
		// Token: 0x060010DF RID: 4319 RVA: 0x0011A1B4 File Offset: 0x001183B4
		public bool Create()
		{
			bool flag = false;
			this.audioObj = new GameObject("MediaPlayer");
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

		// Token: 0x060010E0 RID: 4320 RVA: 0x0011A208 File Offset: 0x00118408
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

		// Token: 0x060010E1 RID: 4321 RVA: 0x0011A284 File Offset: 0x00118484
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
					this.audioClip = this.acm.CreateStream("MediaPlayer", this.wavInfo.SampleValue, this.wavInfo.ChannelNum, this.wavInfo.SamplingRate, false, new AudioClip.PCMReaderCallback(this.OnAudioRead), new AudioClip.PCMSetPositionCallback(this.OnAudioSetPosition));
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

		// Token: 0x060010E2 RID: 4322 RVA: 0x0011A398 File Offset: 0x00118598
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

		// Token: 0x060010E3 RID: 4323 RVA: 0x0011A403 File Offset: 0x00118603
		private void OnAudioSetPosition(int newPos)
		{
			this.streamPos = newPos;
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0011A40C File Offset: 0x0011860C
		public void Play(bool loop)
		{
			if (this.audioSource != null && this.audioClip != null)
			{
				this.audioSource.loop = loop;
				this.audioSource.Play();
			}
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0011A441 File Offset: 0x00118641
		public void Stop()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Stop();
			}
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0011A45C File Offset: 0x0011865C
		public void Pause()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Pause();
			}
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0011A477 File Offset: 0x00118677
		public void Resume()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Play();
			}
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0011A492 File Offset: 0x00118692
		public void SetVolume(float volume)
		{
			if (this.audioSource != null)
			{
				this.audioSource.volume = volume;
			}
		}

		// Token: 0x040009D3 RID: 2515
		public const int FAILED = -1;

		// Token: 0x040009D4 RID: 2516
		public const int SUCCESS = 0;

		// Token: 0x040009D5 RID: 2517
		private string clsPath;

		// Token: 0x040009D6 RID: 2518
		private GameObject audioObj;

		// Token: 0x040009D7 RID: 2519
		private AudioSource audioSource;

		// Token: 0x040009D8 RID: 2520
		private AudioClip audioClip;

		// Token: 0x040009D9 RID: 2521
		private WavInfo wavInfo;

		// Token: 0x040009DA RID: 2522
		private AudioClipMaker acm;

		// Token: 0x040009DB RID: 2523
		private float[] audioData;

		// Token: 0x040009DC RID: 2524
		private int streamPos;
	}
}
