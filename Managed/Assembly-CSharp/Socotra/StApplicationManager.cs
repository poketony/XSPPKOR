using System;
using System.Collections.Generic;
using Socotra.Device;
using Socotra.UI;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E8 RID: 232
	public class StApplicationManager : SingletonBehaviour<StApplicationManager>
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06001304 RID: 4868 RVA: 0x0011F811 File Offset: 0x0011DA11
		// (set) Token: 0x06001305 RID: 4869 RVA: 0x0011F819 File Offset: 0x0011DA19
		public StApplication Application
		{
			get
			{
				return this.bootApplication;
			}
			set
			{
				this.bootApplication = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06001306 RID: 4870 RVA: 0x0011F822 File Offset: 0x0011DA22
		public bool IsSuspend
		{
			get
			{
				return this.isSuspend;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06001307 RID: 4871 RVA: 0x0011F82A File Offset: 0x0011DA2A
		// (set) Token: 0x06001308 RID: 4872 RVA: 0x0011F832 File Offset: 0x0011DA32
		public Dictionary<string, string> LaunchParams
		{
			get
			{
				return this.launchParams;
			}
			set
			{
				this.launchParams = value;
			}
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x0011F83B File Offset: 0x0011DA3B
		private void Awake()
		{
			PhoneSystem.StaticInitializer();
			if (this.bootApplication == null)
			{
				this.bootApplication = base.transform.root.GetComponentInChildren<StApplication>();
			}
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x0011F866 File Offset: 0x0011DA66
		private void Start()
		{
			this.bootApplication.Started(0);
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x0011F874 File Offset: 0x0011DA74
		private void Update()
		{
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x0011F876 File Offset: 0x0011DA76
		public void Suspend()
		{
			this.isSuspend = true;
			SingletonBehaviour<StThreadManager>.Instance.Pause();
			SingletonBehaviour<StAudioManager>.Instance.AllPause();
			SingletonBehaviour<StVideoManager>.Instance.AllPause();
			Time.timeScale = 0f;
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x0011F8A7 File Offset: 0x0011DAA7
		public void Resume()
		{
			this.isSuspend = false;
			SingletonBehaviour<StThreadManager>.Instance.Restart();
			SingletonBehaviour<StAudioManager>.Instance.AllUnPause();
			SingletonBehaviour<StVideoManager>.Instance.AllUnPause();
			Time.timeScale = SingletonData<CommonData>.Instance.timeScale;
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x0011F8DD File Offset: 0x0011DADD
		private void Launch()
		{
			this.bootApplication.Started(0);
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x0011F8EB File Offset: 0x0011DAEB
		public void SetCurrentAppIndex(int index)
		{
			this.currentAppIndex = index;
			this.bootApplication = this.applications[this.currentAppIndex];
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x0011F907 File Offset: 0x0011DB07
		public void LaunchApplication(int index)
		{
			this.SetCurrentAppIndex(index);
			this.Launch();
		}

		// Token: 0x04000AAE RID: 2734
		[SerializeField]
		private StApplication bootApplication;

		// Token: 0x04000AAF RID: 2735
		[SerializeField]
		private StApplication[] applications;

		// Token: 0x04000AB0 RID: 2736
		[SerializeField]
		private bool isSuspend;

		// Token: 0x04000AB1 RID: 2737
		private int currentAppIndex;

		// Token: 0x04000AB2 RID: 2738
		private Dictionary<string, string> launchParams = new Dictionary<string, string>();
	}
}
