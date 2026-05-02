using System;
using Socotra.Media;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Video;

namespace Socotra
{
	// Token: 0x020000F7 RID: 247
	public class StVideoManager : SingletonBehaviour<StVideoManager>
	{
		// Token: 0x06001352 RID: 4946 RVA: 0x00120494 File Offset: 0x0011E694
		private void Awake()
		{
			this.isPlayComplete = false;
			this.videoPlayer = SingletonBehaviour<VideoScreenManager>.Instance.VideoPlayer;
			this.videoPlayer.loopPointReached += delegate(VideoPlayer vp)
			{
				this.isPlayComplete = true;
			};
			this.videoPlayer.prepareCompleted += new VideoPlayer.EventHandler(this.OnPrepareCompleted);
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x001204E6 File Offset: 0x0011E6E6
		private void Update()
		{
			this.NotifyMediaEvent();
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x001204EE File Offset: 0x0011E6EE
		private void OnDestroy()
		{
			if (this.videoPlayer == null)
			{
				return;
			}
			this.Init();
			this.videoPlayer.clip = null;
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x00120514 File Offset: 0x0011E714
		public void SetMediaListener(MediaListener listener, MediaPresenter presenter)
		{
			this.mediaListener = listener;
			this.mediaPresenter = presenter;
			StVideoManager.State videoState = this.GetVideoState(this.videoPlayer);
			this.state = videoState;
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x00120543 File Offset: 0x0011E743
		public StVideoManager.State GetVideoState(VideoPlayer videoPlayer)
		{
			if (videoPlayer.isPlaying)
			{
				return StVideoManager.State.PLAYING;
			}
			if (this.isPlayComplete)
			{
				return StVideoManager.State.COMPLETE;
			}
			if (videoPlayer.isPaused)
			{
				return StVideoManager.State.PAUSE;
			}
			return StVideoManager.State.STOP;
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x00120564 File Offset: 0x0011E764
		public void ChangeStateByScript()
		{
			if (this.immediateEvent)
			{
				this.NotifyMediaEvent();
			}
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x00120574 File Offset: 0x0011E774
		private void NotifyMediaEvent()
		{
			if (this.mediaPresenter is VisualPresenter)
			{
				StVideoManager.State videoState = this.GetVideoState(this.videoPlayer);
				if (videoState == this.state)
				{
					return;
				}
				switch (videoState)
				{
				case StVideoManager.State.PLAYING:
				{
					MediaListener mediaListener = this.mediaListener;
					if (mediaListener != null)
					{
						mediaListener.MediaAction(this.mediaPresenter, 1, 0);
					}
					break;
				}
				case StVideoManager.State.STOP:
				{
					MediaListener mediaListener2 = this.mediaListener;
					if (mediaListener2 != null)
					{
						mediaListener2.MediaAction(this.mediaPresenter, 2, 0);
					}
					SingletonBehaviour<VideoScreenManager>.Instance.SetActiveScreen(false);
					SingletonBehaviour<StAudioManager>.Instance.AllUnPause();
					break;
				}
				case StVideoManager.State.COMPLETE:
				{
					MediaListener mediaListener3 = this.mediaListener;
					if (mediaListener3 != null)
					{
						mediaListener3.MediaAction(this.mediaPresenter, 3, 0);
					}
					SingletonBehaviour<VideoScreenManager>.Instance.SetActiveScreen(false);
					SingletonBehaviour<StAudioManager>.Instance.AllUnPause();
					break;
				}
				}
				this.state = videoState;
			}
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x0012063C File Offset: 0x0011E83C
		public void Init()
		{
			this.state = StVideoManager.State.COMPLETE;
			this.isPlayComplete = false;
			this.SetMediaListener(null, null);
			this.SetVideoPlayerAudioMute(false);
			SingletonBehaviour<VideoScreenManager>.Instance.SetActiveScreen(false);
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x00120666 File Offset: 0x0011E866
		public void SetVideoPlayerClip(VideoClip videoClip)
		{
			this.videoPlayer.clip = videoClip;
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x00120674 File Offset: 0x0011E874
		public void SetVideoPlayerAudioVolume(float vol)
		{
			this.videoPlayer.SetDirectAudioVolume(0, vol);
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x00120683 File Offset: 0x0011E883
		public void SetVideoPlayerAudioMute(bool isMute)
		{
			this.videoPlayer.SetDirectAudioMute(0, isMute);
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00120692 File Offset: 0x0011E892
		public void PlayVideo()
		{
			if (this.videoPlayer.clip == null)
			{
				return;
			}
			SingletonBehaviour<StAudioManager>.Instance.AllPause();
			this.isPlayComplete = false;
			SingletonBehaviour<VideoScreenManager>.Instance.SetActiveScreen(true);
			this.videoPlayer.Prepare();
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x001206CF File Offset: 0x0011E8CF
		private void OnPrepareCompleted(VideoPlayer vp)
		{
			SingletonBehaviour<VideoScreenManager>.Instance.SetVideoTexture();
			SingletonBehaviour<VideoScreenManager>.Instance.EnableRawImage();
			this.videoPlayer.Play();
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x001206F0 File Offset: 0x0011E8F0
		public void StopVideo()
		{
			if (this.videoPlayer.clip == null)
			{
				return;
			}
			this.videoPlayer.Stop();
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x00120711 File Offset: 0x0011E911
		public void PauseVideo()
		{
			if (this.videoPlayer.clip == null)
			{
				return;
			}
			this.videoPlayer.Pause();
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x00120732 File Offset: 0x0011E932
		public void ResumeVideo()
		{
			if (this.videoPlayer.clip == null)
			{
				return;
			}
			if (this.videoPlayer.frame == -1L)
			{
				return;
			}
			this.videoPlayer.Play();
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x00120763 File Offset: 0x0011E963
		public void AllPause()
		{
			this.PauseVideo();
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x0012076B File Offset: 0x0011E96B
		public void AllUnPause()
		{
			this.ResumeVideo();
		}

		// Token: 0x04000AD9 RID: 2777
		[SerializeField]
		private bool immediateEvent;

		// Token: 0x04000ADA RID: 2778
		private VideoPlayer videoPlayer;

		// Token: 0x04000ADB RID: 2779
		private bool isPlayComplete;

		// Token: 0x04000ADC RID: 2780
		private MediaPresenter mediaPresenter;

		// Token: 0x04000ADD RID: 2781
		private MediaListener mediaListener;

		// Token: 0x04000ADE RID: 2782
		private StVideoManager.State state;

		// Token: 0x0200023F RID: 575
		public enum State
		{
			// Token: 0x04001501 RID: 5377
			PLAYING,
			// Token: 0x04001502 RID: 5378
			STOP,
			// Token: 0x04001503 RID: 5379
			COMPLETE,
			// Token: 0x04001504 RID: 5380
			PAUSE
		}
	}
}
