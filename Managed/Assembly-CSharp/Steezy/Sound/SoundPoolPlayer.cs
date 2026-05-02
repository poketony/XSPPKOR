using System;
using System.IO;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000BD RID: 189
	public class SoundPoolPlayer
	{
		// Token: 0x060010EA RID: 4330 RVA: 0x0011A4B8 File Offset: 0x001186B8
		public bool Create(int maxPoolNum)
		{
			bool flag = false;
			this.audioObj = new GameObject("SoundPoolPlayer");
			if (this.audioObj != null)
			{
				this.audioSource = this.audioObj.AddComponent<AudioSource>();
				this.audioClip = new AudioClip[maxPoolNum + 1];
				this.idCounter = 0;
				flag = true;
			}
			return flag;
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0011A50E File Offset: 0x0011870E
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

		// Token: 0x060010EC RID: 4332 RVA: 0x0011A54C File Offset: 0x0011874C
		public int LoadSoundData(string path, int priority)
		{
			int num = -1;
			if (this.idCounter < this.audioClip.Length - 1)
			{
				WavInfo wavInfo = new WavInfo();
				if (wavInfo != null && wavInfo.Create())
				{
					byte[] array = File.ReadAllBytes(path);
					if (array != null && wavInfo.Analyze(array))
					{
						this.idCounter++;
						AudioClipMaker audioClipMaker = new AudioClipMaker();
						this.audioClip[this.idCounter] = audioClipMaker.Create("soundPool" + this.idCounter.ToString(), array, wavInfo.FrequencyDataOffset, wavInfo.BitPerSample, wavInfo.SampleValue, wavInfo.ChannelNum, wavInfo.SamplingRate, false);
						if (this.audioClip[this.idCounter] != null)
						{
							this.audioSource.clip = this.audioClip[this.idCounter];
							num = this.idCounter;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0011A631 File Offset: 0x00118831
		public void UnloadSoundData(int id)
		{
			if (this.audioClip != null && id > 0 && id < this.audioClip.Length)
			{
				this.audioClip[id] = null;
			}
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x0011A654 File Offset: 0x00118854
		public bool IsLoadComplete(int id)
		{
			bool flag = false;
			if (this.audioClip[id] != null)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x0011A678 File Offset: 0x00118878
		public int Play(int id, float volume, int priority, bool loop)
		{
			int num = -1;
			if (this.audioSource != null && this.audioClip != null && id > 0 && id < this.audioClip.Length)
			{
				if (loop)
				{
					this.audioSource.clip = this.audioClip[id];
					this.audioSource.loop = true;
					this.audioSource.Play();
				}
				else
				{
					this.audioSource.loop = false;
					this.audioSource.PlayOneShot(this.audioClip[id]);
				}
				num = 0;
			}
			return num;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0011A6FE File Offset: 0x001188FE
		public void Stop(int id)
		{
			if (this.audioSource != null)
			{
				this.audioSource.Stop();
			}
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x0011A719 File Offset: 0x00118919
		public void Pause(int id)
		{
			if (this.audioSource != null)
			{
				this.audioSource.Pause();
			}
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0011A734 File Offset: 0x00118934
		public void Resume(int id)
		{
			if (this.audioSource != null)
			{
				this.audioSource.Play();
			}
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0011A74F File Offset: 0x0011894F
		public void SetVolume(int id, float volume)
		{
			if (this.audioSource != null)
			{
				this.audioSource.volume = volume;
			}
		}

		// Token: 0x040009DD RID: 2525
		public const int FAILED = -1;

		// Token: 0x040009DE RID: 2526
		public const int SUCCESS = 0;

		// Token: 0x040009DF RID: 2527
		private string clsPath;

		// Token: 0x040009E0 RID: 2528
		private GameObject audioObj;

		// Token: 0x040009E1 RID: 2529
		private AudioSource audioSource;

		// Token: 0x040009E2 RID: 2530
		private AudioClip[] audioClip;

		// Token: 0x040009E3 RID: 2531
		private int idCounter;
	}
}
