using System;
using System.Collections.Generic;
using System.Linq;
using Socotra.Media;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E9 RID: 233
	public class StAudioManager : SingletonBehaviour<StAudioManager>
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x0011F929 File Offset: 0x0011DB29
		public Dictionary<int, AudioPresenter> Presenters
		{
			get
			{
				return this.presenters;
			}
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x0011F931 File Offset: 0x0011DB31
		public AudioPresenter GetAudioPresenter(int port)
		{
			if (!this.presenters.ContainsKey(port))
			{
				this.presenters.Add(port, this.AddAudioPresenter());
			}
			return this.presenters[port];
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x0011F95F File Offset: 0x0011DB5F
		private void Awake()
		{
			this.listenerList = new Dictionary<MediaPresenter, MediaListener>();
			this.stateList = new Dictionary<MediaPresenter, StAudioManager.State>();
			this.presenters = new Dictionary<int, AudioPresenter>();
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x0011F982 File Offset: 0x0011DB82
		private void Start()
		{
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x0011F984 File Offset: 0x0011DB84
		private void Update()
		{
			this.NotifyMediaEvent();
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0011F98C File Offset: 0x0011DB8C
		private void OnDestroy()
		{
			foreach (AudioPresenter audioPresenter in this.presenters.Values)
			{
				Object.Destroy(audioPresenter.Source);
			}
			this.presenters.Clear();
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x0011F9F4 File Offset: 0x0011DBF4
		public AudioPresenter AddAudioPresenter()
		{
			return new AudioPresenter(this.audioSourceRoot.AddComponent<AudioSource>());
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x0011FA08 File Offset: 0x0011DC08
		public void SetMediaListener(MediaListener listener, MediaPresenter presenter)
		{
			if (this.listenerList.ContainsKey(presenter))
			{
				this.listenerList[presenter] = listener;
			}
			else
			{
				this.listenerList.Add(presenter, listener);
			}
			StAudioManager.State state = StAudioManager.State.END;
			if (presenter is AudioPresenter)
			{
				state = this.GetAudioState((presenter as AudioPresenter).Source);
			}
			if (this.stateList.ContainsKey(presenter))
			{
				this.stateList[presenter] = state;
				return;
			}
			this.stateList.Add(presenter, state);
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x0011FA84 File Offset: 0x0011DC84
		public StAudioManager.State GetAudioState(AudioSource source)
		{
			if (source.isPlaying)
			{
				return StAudioManager.State.PLAYING;
			}
			if (source.clip == null || source.time == 0f)
			{
				return StAudioManager.State.END;
			}
			return StAudioManager.State.PAUSE;
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x0011FAAE File Offset: 0x0011DCAE
		public void ChangeStateByScript()
		{
			if (this.immediateEvent)
			{
				this.NotifyMediaEvent();
			}
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x0011FAC0 File Offset: 0x0011DCC0
		private void NotifyMediaEvent()
		{
			foreach (MediaPresenter mediaPresenter in this.listenerList.Keys.ToList<MediaPresenter>())
			{
				if (mediaPresenter is AudioPresenter)
				{
					AudioPresenter audioPresenter = (AudioPresenter)mediaPresenter;
					AudioSource source = audioPresenter.Source;
					StAudioManager.State audioState = this.GetAudioState(source);
					if (audioState == this.stateList[mediaPresenter])
					{
						audioPresenter.IsStopEvent = false;
					}
					else
					{
						switch (audioState)
						{
						case StAudioManager.State.PLAYING:
							if (this.stateList[mediaPresenter] == StAudioManager.State.PAUSE)
							{
								MediaListener mediaListener = this.listenerList[mediaPresenter];
								if (mediaListener != null)
								{
									mediaListener.MediaAction(mediaPresenter, 6, 0);
								}
							}
							else
							{
								MediaListener mediaListener2 = this.listenerList[mediaPresenter];
								if (mediaListener2 != null)
								{
									mediaListener2.MediaAction(mediaPresenter, 1, 0);
								}
							}
							break;
						case StAudioManager.State.PAUSE:
						{
							MediaListener mediaListener3 = this.listenerList[mediaPresenter];
							if (mediaListener3 != null)
							{
								mediaListener3.MediaAction(mediaPresenter, 5, 0);
							}
							break;
						}
						case StAudioManager.State.END:
							if (audioPresenter.IsStopEvent)
							{
								audioPresenter.IsStopEvent = false;
								MediaListener mediaListener4 = this.listenerList[mediaPresenter];
								if (mediaListener4 != null)
								{
									mediaListener4.MediaAction(mediaPresenter, 2, 0);
								}
							}
							else
							{
								MediaListener mediaListener5 = this.listenerList[mediaPresenter];
								if (mediaListener5 != null)
								{
									mediaListener5.MediaAction(mediaPresenter, 3, 0);
								}
							}
							break;
						}
						this.stateList[mediaPresenter] = audioState;
					}
				}
			}
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x0011FC38 File Offset: 0x0011DE38
		public void AllPause()
		{
			if (this.pauseCount > 0)
			{
				this.pauseCount++;
				return;
			}
			this.resumeAudioSourceList = new List<AudioSource>();
			foreach (AudioSource audioSource in this.audioSourceRoot.GetComponents<AudioSource>())
			{
				if (audioSource.isPlaying)
				{
					audioSource.Pause();
					this.resumeAudioSourceList.Add(audioSource);
				}
			}
			this.pauseCount++;
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x0011FCB0 File Offset: 0x0011DEB0
		public void AllUnPause()
		{
			if (this.pauseCount <= 0)
			{
				return;
			}
			if (this.pauseCount > 1)
			{
				this.pauseCount--;
				return;
			}
			foreach (AudioSource audioSource in this.resumeAudioSourceList)
			{
				audioSource.UnPause();
			}
			this.resumeAudioSourceList.Clear();
			this.pauseCount--;
		}

		// Token: 0x04000AB3 RID: 2739
		[SerializeField]
		private GameObject audioSourceRoot;

		// Token: 0x04000AB4 RID: 2740
		[SerializeField]
		private bool immediateEvent;

		// Token: 0x04000AB5 RID: 2741
		private Dictionary<MediaPresenter, MediaListener> listenerList;

		// Token: 0x04000AB6 RID: 2742
		private Dictionary<MediaPresenter, StAudioManager.State> stateList;

		// Token: 0x04000AB7 RID: 2743
		private Dictionary<int, AudioPresenter> presenters;

		// Token: 0x04000AB8 RID: 2744
		private List<AudioSource> resumeAudioSourceList = new List<AudioSource>();

		// Token: 0x04000AB9 RID: 2745
		private int pauseCount;

		// Token: 0x02000238 RID: 568
		public enum State
		{
			// Token: 0x040014D8 RID: 5336
			PLAYING,
			// Token: 0x040014D9 RID: 5337
			PAUSE,
			// Token: 0x040014DA RID: 5338
			END
		}
	}
}
