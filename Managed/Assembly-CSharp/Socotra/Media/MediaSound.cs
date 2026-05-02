using System;
using UnityEngine;

namespace Socotra.Media
{
	// Token: 0x02000119 RID: 281
	public class MediaSound : MediaResource
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060015B7 RID: 5559 RVA: 0x0012C09D File Offset: 0x0012A29D
		public AudioClip Audio
		{
			get
			{
				return this.audio;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060015B8 RID: 5560 RVA: 0x0012C0A5 File Offset: 0x0012A2A5
		// (set) Token: 0x060015B9 RID: 5561 RVA: 0x0012C0AD File Offset: 0x0012A2AD
		public bool Loop
		{
			get
			{
				return this.loop;
			}
			set
			{
				this.loop = value;
			}
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x0012C0B6 File Offset: 0x0012A2B6
		public MediaSound(AudioClip source)
		{
			this.audio = source;
			this.Loop = false;
			this.audio.LoadAudioData();
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x0012C0D8 File Offset: 0x0012A2D8
		public void Use()
		{
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x0012C0DA File Offset: 0x0012A2DA
		public override void Unuse()
		{
			this.audio.UnloadAudioData();
		}

		// Token: 0x04000C76 RID: 3190
		private AudioClip audio;

		// Token: 0x04000C77 RID: 3191
		private bool loop;
	}
}
