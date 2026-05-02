using System;
using Steezy.Utility;
using UnityEngine.Video;

namespace Socotra.Media
{
	// Token: 0x0200011A RID: 282
	public class VisualPresenter : MediaPresenter
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060015BD RID: 5565 RVA: 0x0012C0E8 File Offset: 0x0012A2E8
		public VideoClip VideoClip
		{
			get
			{
				return this.videoClip;
			}
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x0012C0F0 File Offset: 0x0012A2F0
		public MediaResource GetMediaResource()
		{
			return this.mediaImage;
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x0012C0F8 File Offset: 0x0012A2F8
		public void Play()
		{
			SingletonBehaviour<StVideoManager>.Instance.PlayVideo();
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x0012C104 File Offset: 0x0012A304
		public void SetAttribute(int attr, int value)
		{
			if (attr == 0)
			{
				SingletonBehaviour<StVideoManager>.Instance.SetVideoPlayerAudioMute(true);
				return;
			}
			if (attr != 1)
			{
				return;
			}
			SingletonBehaviour<StVideoManager>.Instance.SetVideoPlayerAudioMute(false);
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x0012C125 File Offset: 0x0012A325
		public void SetImage(MediaImage image)
		{
			SingletonBehaviour<StVideoManager>.Instance.Init();
			this.mediaImage = image;
			this.videoClip = image.VideoClip;
			SingletonBehaviour<StVideoManager>.Instance.SetVideoPlayerClip(this.videoClip);
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x0012C154 File Offset: 0x0012A354
		public void SetMediaListener(MediaListener listener)
		{
			SingletonBehaviour<StVideoManager>.Instance.SetMediaListener(listener, this);
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x0012C162 File Offset: 0x0012A362
		public void Stop()
		{
			SingletonBehaviour<StVideoManager>.Instance.StopVideo();
		}

		// Token: 0x04000C78 RID: 3192
		public const int ATTR_AUDIO_OFF = 0;

		// Token: 0x04000C79 RID: 3193
		public const int ATTR_AUDIO_ON = 1;

		// Token: 0x04000C7A RID: 3194
		public const int ATTR_FORCE_FULLSCREEN_PLAYER = 5;

		// Token: 0x04000C7B RID: 3195
		public const int ATTR_FORCE_INLINE_PLAYER = 3;

		// Token: 0x04000C7C RID: 3196
		public const int ATTR_FORCE_NATIVE_PLAYER = 2;

		// Token: 0x04000C7D RID: 3197
		public const int ATTR_PREFER_FULLSCREEN_PLAYER = 4;

		// Token: 0x04000C7E RID: 3198
		public const int ATTR_PREFER_INLINE_PLAYER = 1;

		// Token: 0x04000C7F RID: 3199
		public const int ATTR_PREFER_NATIVE_PLAYER = 0;

		// Token: 0x04000C80 RID: 3200
		public const int AUDIO_MODE = 4;

		// Token: 0x04000C81 RID: 3201
		public const int IMAGE_XPOS = 1;

		// Token: 0x04000C82 RID: 3202
		public const int IMAGE_YPOS = 2;

		// Token: 0x04000C83 RID: 3203
		protected const int MAX_VENDOR_ATTR = 127;

		// Token: 0x04000C84 RID: 3204
		protected const int MAX_VENDOR_VISUAL_EVENT = 127;

		// Token: 0x04000C85 RID: 3205
		protected const int MIN_VENDOR_ATTR = 64;

		// Token: 0x04000C86 RID: 3206
		protected const int MIN_VENDOR_VISUAL_EVENT = 64;

		// Token: 0x04000C87 RID: 3207
		public const int PLAYER_MODE = 3;

		// Token: 0x04000C88 RID: 3208
		public const int VISUAL_COMPLETE = 3;

		// Token: 0x04000C89 RID: 3209
		public const int VISUAL_PLAYING = 1;

		// Token: 0x04000C8A RID: 3210
		public const int VISUAL_STOPPED = 2;

		// Token: 0x04000C8B RID: 3211
		private MediaImage mediaImage;

		// Token: 0x04000C8C RID: 3212
		private VideoClip videoClip;
	}
}
