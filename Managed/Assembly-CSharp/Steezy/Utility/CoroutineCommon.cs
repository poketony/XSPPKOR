using System;
using System.Collections;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x0200008C RID: 140
	public class CoroutineCommon : MonoBehaviour
	{
		// Token: 0x06000F55 RID: 3925 RVA: 0x00114E36 File Offset: 0x00113036
		static CoroutineCommon()
		{
			GameObject gameObject = new GameObject("CoroutineCommon");
			Object.DontDestroyOnLoad(gameObject);
			CoroutineCommon.mMonoBehaviour = gameObject.AddComponent<CoroutineCommon>();
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x00114E52 File Offset: 0x00113052
		public static void StartExternalCoroutine(IEnumerator coroutine)
		{
			CoroutineCommon.mMonoBehaviour.StartCoroutine(coroutine);
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x00114E60 File Offset: 0x00113060
		public static void StopAllCoroutine()
		{
			CoroutineCommon.mMonoBehaviour.StopAllCoroutines();
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00114E6C File Offset: 0x0011306C
		public static void CallWaitForEndOfFrame(Action act)
		{
			CoroutineCommon.mMonoBehaviour.StartCoroutine(CoroutineCommon.DoCallWaitForEndOfFrame(act));
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00114E7F File Offset: 0x0011307F
		public static void CallWaitForOneFrame(Action act)
		{
			CoroutineCommon.mMonoBehaviour.StartCoroutine(CoroutineCommon.DoCallWaitForOneFrame(act));
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x00114E92 File Offset: 0x00113092
		public static void CallWaitForSeconds(float seconds, Action act)
		{
			CoroutineCommon.mMonoBehaviour.StartCoroutine(CoroutineCommon.DoCallWaitForSeconds(seconds, act));
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x00114EA6 File Offset: 0x001130A6
		private static IEnumerator DoCallWaitForEndOfFrame(Action act)
		{
			yield return new WaitForEndOfFrame();
			act();
			yield break;
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x00114EB5 File Offset: 0x001130B5
		private static IEnumerator DoCallWaitForOneFrame(Action act)
		{
			yield return 0;
			act();
			yield break;
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x00114EC4 File Offset: 0x001130C4
		private static IEnumerator DoCallWaitForSeconds(float seconds, Action act)
		{
			yield return new WaitForSeconds(seconds);
			act();
			yield break;
		}

		// Token: 0x0400095E RID: 2398
		private static readonly MonoBehaviour mMonoBehaviour;
	}
}
