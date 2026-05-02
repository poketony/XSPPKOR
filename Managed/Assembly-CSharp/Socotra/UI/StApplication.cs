using System;
using System.Collections.Generic;
using Socotra.Media;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x020000FF RID: 255
	public class StApplication : MonoBehaviour
	{
		// Token: 0x060013B3 RID: 5043 RVA: 0x00121607 File Offset: 0x0011F807
		private void Start()
		{
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x00121609 File Offset: 0x0011F809
		private void Update()
		{
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0012160B File Offset: 0x0011F80B
		private void OnDestroy()
		{
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0012160D File Offset: 0x0011F80D
		public virtual void Started(int arg)
		{
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0012160F File Offset: 0x0011F80F
		public virtual void Resume()
		{
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x00121611 File Offset: 0x0011F811
		public void Terminate()
		{
			Object.Destroy(base.transform.root.gameObject);
			SingletonBehaviour<AppliArchive>.Instance.ChangeState(AppliArchive.State.TITLE);
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x00121633 File Offset: 0x0011F833
		public static StApplication GetThisStarApplication()
		{
			return SingletonBehaviour<StApplicationManager>.Instance.Application;
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x0012163F File Offset: 0x0011F83F
		public static StApplication GetCurrentApp()
		{
			return SingletonBehaviour<StApplicationManager>.Instance.Application;
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x0012164B File Offset: 0x0011F84B
		public static string GetSourceURL()
		{
			return "";
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x00121652 File Offset: 0x0011F852
		public int GetLaunchType()
		{
			return 0;
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x00121655 File Offset: 0x0011F855
		public string[] GetArgs()
		{
			return SingletonBehaviour<SocotraRuntime>.Instance.GetArgs();
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x00121664 File Offset: 0x0011F864
		public string GetParameter(string param)
		{
			string text = "";
			SingletonBehaviour<StApplicationManager>.Instance.LaunchParams.TryGetValue(param, out text);
			return text;
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x0012168C File Offset: 0x0011F88C
		public void Launch(int launchType, string[] paramArray)
		{
			paramArray = ((paramArray == null) ? new string[0] : paramArray);
			if (launchType == 3)
			{
				Debug.Log("launchType:" + launchType.ToString() + ", paramArray:" + string.Join(",", paramArray));
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				int num = int.Parse(paramArray[0]);
				for (int i = 1; i < paramArray.Length; i += 2)
				{
					string text = "";
					if (i + 1 < paramArray.Length)
					{
						text = paramArray[i + 1];
					}
					dictionary[paramArray[i]] = text;
				}
				StApplication.GetCurrentApp().Suspend();
				foreach (AudioPresenter audioPresenter in SingletonBehaviour<StAudioManager>.Instance.Presenters.Values)
				{
					audioPresenter.Pause();
				}
				Object.Destroy(base.transform.root.gameObject);
				SingletonBehaviour<AppliArchive>.Instance.Relaunch(num, dictionary);
			}
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x00121788 File Offset: 0x0011F988
		public virtual void Suspend()
		{
		}

		// Token: 0x04000AFB RID: 2811
		public const int LAUNCHED_FROM_MENU = 0;

		// Token: 0x04000AFC RID: 2812
		public const int LAUNCHED_AFTER_DOWNLOAD = 1;

		// Token: 0x04000AFD RID: 2813
		public const int LAUNCHED_FROM_TIMER = 2;

		// Token: 0x04000AFE RID: 2814
		public const int LAUNCHED_AS_CONCIERGE = 3;

		// Token: 0x04000AFF RID: 2815
		public const int LAUNCHED_FROM_EXT = 4;

		// Token: 0x04000B00 RID: 2816
		public const int LAUNCHED_FROM_BROWSER = 5;

		// Token: 0x04000B01 RID: 2817
		public const int LAUNCHED_FROM_MAILER = 6;

		// Token: 0x04000B02 RID: 2818
		public const int LAUNCHED_FROM_IAPPLI = 7;

		// Token: 0x04000B03 RID: 2819
		public const int LAUNCHED_FROM_LAUNCHER = 8;

		// Token: 0x04000B04 RID: 2820
		public const int LAUNCHED_AS_ILET = 9;

		// Token: 0x04000B05 RID: 2821
		public const int LAUNCHED_MSG_RECEIVED = 10;

		// Token: 0x04000B06 RID: 2822
		public const int LAUNCHED_MSG_SENT = 11;

		// Token: 0x04000B07 RID: 2823
		public const int LAUNCHED_MSG_UNSENT = 12;

		// Token: 0x04000B08 RID: 2824
		public const int LAUNCHED_FROM_LOCATION_INFO = 13;

		// Token: 0x04000B09 RID: 2825
		public const int LAUNCHED_FROM_LOCATION_IMAGE = 14;

		// Token: 0x04000B0A RID: 2826
		public const int LAUNCHED_FROM_PHONEBOOK = 15;

		// Token: 0x04000B0B RID: 2827
		public const int LAUNCHED_FROM_DTV = 17;

		// Token: 0x04000B0C RID: 2828
		public const int LAUNCHED_FROM_TORUCA = 18;

		// Token: 0x04000B0D RID: 2829
		public const int LAUNCHED_FROM_FELICA_ADHOC = 19;

		// Token: 0x04000B0E RID: 2830
		public const int LAUNCHED_FROM_MENU_FOR_DELETION = 20;

		// Token: 0x04000B0F RID: 2831
		public const int LAUNCHED_FROM_BML = 21;

		// Token: 0x04000B10 RID: 2832
		public const int LAUNCH_BROWSER = 1;

		// Token: 0x04000B11 RID: 2833
		public const int LAUNCH_VERSIONUP = 2;

		// Token: 0x04000B12 RID: 2834
		public const int LAUNCH_IAPPLI = 3;

		// Token: 0x04000B13 RID: 2835
		public const int LAUNCH_AS_LAUNCHER = 4;

		// Token: 0x04000B14 RID: 2836
		public const int LAUNCH_MAILMENU = 5;

		// Token: 0x04000B15 RID: 2837
		public const int LAUNCH_SCHEDULER = 6;

		// Token: 0x04000B16 RID: 2838
		public const int LAUNCH_MAIL_RECEIVED = 7;

		// Token: 0x04000B17 RID: 2839
		public const int LAUNCH_MAIL_SENT = 8;

		// Token: 0x04000B18 RID: 2840
		public const int LAUNCH_MAIL_UNSENT = 9;

		// Token: 0x04000B19 RID: 2841
		public const int LAUNCH_MAIL_LAST_INCOMING = 10;

		// Token: 0x04000B1A RID: 2842
		public const int LAUNCH_DTV = 12;

		// Token: 0x04000B1B RID: 2843
		public const int LAUNCH_BROWSER_SUSPEND = 13;

		// Token: 0x04000B1C RID: 2844
		public const int SUSPEND_BY_NATIVE = 1;

		// Token: 0x04000B1D RID: 2845
		public const int SUSPEND_BY_IAPP = 2;

		// Token: 0x04000B1E RID: 2846
		public const int SUSPEND_PACKETIN = 256;

		// Token: 0x04000B1F RID: 2847
		public const int SUSPEND_CALL_OUT = 512;

		// Token: 0x04000B20 RID: 2848
		public const int SUSPEND_CALL_IN = 1024;

		// Token: 0x04000B21 RID: 2849
		public const int SUSPEND_MAIL_SEND = 2048;

		// Token: 0x04000B22 RID: 2850
		public const int SUSPEND_MAIL_RECEIVE = 4096;

		// Token: 0x04000B23 RID: 2851
		public const int SUSPEND_MESSAGE_RECEIVE = 8192;

		// Token: 0x04000B24 RID: 2852
		public const int SUSPEND_SCHEDULE_NOTIFY = 16384;

		// Token: 0x04000B25 RID: 2853
		public const int SUSPEND_MULTITASK_APPLICATION = 32768;
	}
}
