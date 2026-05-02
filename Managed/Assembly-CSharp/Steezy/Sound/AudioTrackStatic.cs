using System;
using System.IO;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000BA RID: 186
	public class AudioTrackStatic
	{
		// Token: 0x060010CA RID: 4298 RVA: 0x00119CC4 File Offset: 0x00117EC4
		public bool Create(string path)
		{
			bool flag = false;
			byte[] array = File.ReadAllBytes(path);
			if (array != null)
			{
				this.Create(array);
			}
			return flag;
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x00119CE4 File Offset: 0x00117EE4
		public bool Create(byte[] data)
		{
			bool flag = false;
			if (data != null)
			{
				this.audioObj = new GameObject("AudioTrackStatic");
				if (this.audioObj != null)
				{
					this.audioSource = this.audioObj.AddComponent<AudioSource>();
				}
				WavInfo wavInfo = new WavInfo();
				if (wavInfo != null && wavInfo.Create() && wavInfo.Analyze(data))
				{
					AudioClipMaker audioClipMaker = new AudioClipMaker();
					this.audioClip = audioClipMaker.Create("audioTrackStatic", data, wavInfo.FrequencyDataOffset, wavInfo.BitPerSample, wavInfo.SampleValue, wavInfo.ChannelNum, wavInfo.SamplingRate, false);
					if (this.audioClip != null)
					{
						this.audioSource.clip = this.audioClip;
						flag = true;
					}
				}
			}
			return flag;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x00119D9C File Offset: 0x00117F9C
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
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x00119DE8 File Offset: 0x00117FE8
		public void Play()
		{
			if (this.audioSource != null && this.audioClip != null)
			{
				this.audioSource.loop = false;
				this.audioSource.PlayOneShot(this.audioClip);
			}
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x00119E23 File Offset: 0x00118023
		public void Stop()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Stop();
			}
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x00119E3E File Offset: 0x0011803E
		public void Pause()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Pause();
			}
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x00119E59 File Offset: 0x00118059
		public void Resume()
		{
			if (this.audioSource != null)
			{
				this.audioSource.Play();
			}
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x00119E74 File Offset: 0x00118074
		public void SetVolume(float volume)
		{
			if (this.audioSource != null)
			{
				this.audioSource.volume = volume;
			}
		}

		// Token: 0x040009BD RID: 2493
		public const int FAILED = -1;

		// Token: 0x040009BE RID: 2494
		public const int SUCCESS = 0;

		// Token: 0x040009BF RID: 2495
		private string clsPath;

		// Token: 0x040009C0 RID: 2496
		private GameObject audioObj;

		// Token: 0x040009C1 RID: 2497
		private AudioSource audioSource;

		// Token: 0x040009C2 RID: 2498
		private AudioClip audioClip;
	}
}
