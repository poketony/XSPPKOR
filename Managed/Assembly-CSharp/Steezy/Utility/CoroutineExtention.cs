using System;
using System.Collections;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x0200008D RID: 141
	public static class CoroutineExtention
	{
		// Token: 0x06000F5F RID: 3935 RVA: 0x00114EE2 File Offset: 0x001130E2
		public static void CallWaitForEndOfFrame(this MonoBehaviour monoBehaviour, Action act)
		{
			monoBehaviour.StartCoroutine(CoroutineExtention.DoCallWaitForEndOfFrame(act));
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x00114EF1 File Offset: 0x001130F1
		public static void CallWaitForOneFrame(this MonoBehaviour monoBehaviour, Action act)
		{
			monoBehaviour.StartCoroutine(CoroutineExtention.DoCallWaitForOneFrame(act));
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x00114F00 File Offset: 0x00113100
		public static void CallWaitForSeconds(this MonoBehaviour monoBehaviour, float seconds, Action act)
		{
			monoBehaviour.StartCoroutine(CoroutineExtention.DoCallWaitForSeconds(seconds, act));
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x00114F10 File Offset: 0x00113110
		public static void CallWaitForSecondsRealtime(this MonoBehaviour monoBehaviour, float seconds, Action act)
		{
			monoBehaviour.StartCoroutine(CoroutineExtention.DoWaitForSecondsRealtime(seconds, act));
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x00114F20 File Offset: 0x00113120
		private static IEnumerator DoCallWaitForEndOfFrame(Action act)
		{
			yield return new WaitForEndOfFrame();
			act();
			yield break;
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x00114F2F File Offset: 0x0011312F
		private static IEnumerator DoCallWaitForOneFrame(Action act)
		{
			yield return 0;
			act();
			yield break;
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x00114F3E File Offset: 0x0011313E
		private static IEnumerator DoCallWaitForSeconds(float seconds, Action act)
		{
			yield return new WaitForSeconds(seconds);
			act();
			yield break;
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x00114F54 File Offset: 0x00113154
		private static IEnumerator DoWaitForSecondsRealtime(float seconds, Action act)
		{
			yield return new WaitForSecondsRealtime(seconds);
			act();
			yield break;
		}
	}
}
