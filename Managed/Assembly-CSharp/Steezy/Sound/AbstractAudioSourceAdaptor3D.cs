using System;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000BF RID: 191
	[RequireComponent(typeof(AudioSource))]
	public abstract class AbstractAudioSourceAdaptor3D<T> : MonoBehaviour
	{
		// Token: 0x0600111F RID: 4383 RVA: 0x0011AAEA File Offset: 0x00118CEA
		private void Start()
		{
			this.AddAudioSource();
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x0011AAF4 File Offset: 0x00118CF4
		private void AddAudioSource()
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.outputAudioMixerGroup = AudioMixerManager.Instance.GetTargetAudioMixerGroup();
			AudioSourceManager3D.AddAudioSource<T>(this.GetSeType(), this.GetAudioSourceKey(), component, true);
		}

		// Token: 0x06001121 RID: 4385
		protected abstract string GetSeType();

		// Token: 0x06001122 RID: 4386
		protected abstract T GetAudioSourceKey();

		// Token: 0x06001123 RID: 4387 RVA: 0x0011AB2B File Offset: 0x00118D2B
		private void OnApplicationQuit()
		{
			this.isOnDestroy = false;
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x0011AB34 File Offset: 0x00118D34
		private void OnDestroy()
		{
			if (this.isOnDestroy)
			{
				AudioSourceManager3D.RemoveAudioSource<T>(this.GetSeType(), this.GetAudioSourceKey());
			}
		}

		// Token: 0x040009FC RID: 2556
		public bool isOnDestroy = true;
	}
}
