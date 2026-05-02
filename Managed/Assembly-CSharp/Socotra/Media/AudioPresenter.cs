using System;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.Media
{
	// Token: 0x02000113 RID: 275
	public class AudioPresenter : MediaPresenter
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600157D RID: 5501 RVA: 0x0012B672 File Offset: 0x00129872
		// (set) Token: 0x0600157E RID: 5502 RVA: 0x0012B67A File Offset: 0x0012987A
		public bool IsStopEvent
		{
			get
			{
				return this.isStopEvent;
			}
			set
			{
				this.isStopEvent = value;
			}
		}

		// Token: 0x0600157F RID: 5503 RVA: 0x0012B683 File Offset: 0x00129883
		public static AudioPresenter GetAudioPresenter()
		{
			return AudioPresenter.GetAudioPresenter(0);
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x0012B68B File Offset: 0x0012988B
		public static AudioPresenter GetAudioPresenter(int port)
		{
			return SingletonBehaviour<StAudioManager>.Instance.GetAudioPresenter(port);
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06001581 RID: 5505 RVA: 0x0012B698 File Offset: 0x00129898
		public AudioSource Source
		{
			get
			{
				return this.audioSource;
			}
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0012B6A0 File Offset: 0x001298A0
		public AudioPresenter(AudioSource mySource)
		{
			this.audioSource = mySource;
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x0012B6B0 File Offset: 0x001298B0
		~AudioPresenter()
		{
			this.audioSource = null;
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x0012B6E0 File Offset: 0x001298E0
		public int GetCurrentTime()
		{
			return (int)((this.audioSource.clip == null) ? 0f : (this.audioSource.time * 1000f));
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x0012B70E File Offset: 0x0012990E
		public MediaResource GetMediaResource()
		{
			return this.myResource;
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x0012B716 File Offset: 0x00129916
		public int GetTotalTime()
		{
			return (int)(this.audioSource.clip.length * 1000f);
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x0012B72F File Offset: 0x0012992F
		public void Pause()
		{
			this.audioSource.Pause();
			SingletonBehaviour<StAudioManager>.Instance.ChangeStateByScript();
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x0012B746 File Offset: 0x00129946
		public void Play()
		{
			this.audioSource.Play();
			SingletonBehaviour<StAudioManager>.Instance.ChangeStateByScript();
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0012B75D File Offset: 0x0012995D
		public void Play(int time)
		{
			this.audioSource.time = (float)time / 1000f;
			this.audioSource.Play();
			SingletonBehaviour<StAudioManager>.Instance.ChangeStateByScript();
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x0012B787 File Offset: 0x00129987
		public void Restart()
		{
			this.audioSource.UnPause();
			SingletonBehaviour<StAudioManager>.Instance.ChangeStateByScript();
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0012B79E File Offset: 0x0012999E
		public void SetAttribute(int attr, int value)
		{
			if (attr == 4)
			{
				this.audioSource.volume = Mathf.Min(1f, (float)value / 100f);
			}
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x0012B7C2 File Offset: 0x001299C2
		public void SetMediaListener(MediaListener listener)
		{
			this.myListener = listener;
			SingletonBehaviour<StAudioManager>.Instance.SetMediaListener(listener, this);
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x0012B7D7 File Offset: 0x001299D7
		public void SetSound(MediaSound sound)
		{
			this.audioSource.clip = sound.Audio;
			this.audioSource.loop = sound.Loop;
			this.myResource = sound;
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x0012B802 File Offset: 0x00129A02
		public void SetSyncEvent(int channel, int key)
		{
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x0012B804 File Offset: 0x00129A04
		public void Stop()
		{
			this.audioSource.Stop();
			this.myResource = null;
			this.isStopEvent = true;
			SingletonBehaviour<StAudioManager>.Instance.ChangeStateByScript();
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x0012B829 File Offset: 0x00129A29
		public void SetLoop(bool loop)
		{
			if (this.audioSource == null)
			{
				return;
			}
			this.audioSource.loop = loop;
		}

		// Token: 0x04000C56 RID: 3158
		public const int ATTR_SYNC_OFF = 0;

		// Token: 0x04000C57 RID: 3159
		public const int ATTR_SYNC_ON = 1;

		// Token: 0x04000C58 RID: 3160
		public const int AUDIO_COMPLETE = 3;

		// Token: 0x04000C59 RID: 3161
		public const int AUDIO_LOOPED = 7;

		// Token: 0x04000C5A RID: 3162
		public const int AUDIO_PAUSED = 5;

		// Token: 0x04000C5B RID: 3163
		public const int AUDIO_PLAYING = 1;

		// Token: 0x04000C5C RID: 3164
		public const int AUDIO_RESTARTED = 6;

		// Token: 0x04000C5D RID: 3165
		public const int AUDIO_STOPPED = 2;

		// Token: 0x04000C5E RID: 3166
		public const int AUDIO_SYNC = 4;

		// Token: 0x04000C5F RID: 3167
		public const int CHANGE_TEMPO = 5;

		// Token: 0x04000C60 RID: 3168
		public const int LOOP_COUNT = 6;

		// Token: 0x04000C61 RID: 3169
		public const int MAX_OPTION_ATTR = 255;

		// Token: 0x04000C62 RID: 3170
		public const int MAX_PRIORITY = 10;

		// Token: 0x04000C63 RID: 3171
		public const int MIN_OPTION_ATTR = 12;

		// Token: 0x04000C64 RID: 3172
		public const int MIN_PRIORITY = 1;

		// Token: 0x04000C65 RID: 3173
		public const int NORM_PRIORITY = 5;

		// Token: 0x04000C66 RID: 3174
		public const int PRIORITY = 1;

		// Token: 0x04000C67 RID: 3175
		public const int SET_VOLUME = 4;

		// Token: 0x04000C68 RID: 3176
		public const int SYNC_MODE = 2;

		// Token: 0x04000C69 RID: 3177
		public const int TRANSPOSE_KEY = 3;

		// Token: 0x04000C6A RID: 3178
		private AudioSource audioSource;

		// Token: 0x04000C6B RID: 3179
		private MediaResource myResource;

		// Token: 0x04000C6C RID: 3180
		private MediaListener myListener;

		// Token: 0x04000C6D RID: 3181
		private bool isStopEvent;
	}
}
