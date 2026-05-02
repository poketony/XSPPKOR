using System;
using System.Collections;
using UnityEngine;

namespace Steezy.PageFlow
{
	// Token: 0x020000CB RID: 203
	public class PageFlowCoroutineCommon : MonoBehaviour
	{
		// Token: 0x0600122D RID: 4653 RVA: 0x0011D390 File Offset: 0x0011B590
		static PageFlowCoroutineCommon()
		{
			GameObject gameObject = new GameObject("PageFlowCoroutineCommon");
			Object.DontDestroyOnLoad(gameObject);
			PageFlowCoroutineCommon.mMonoBehaviour = gameObject.AddComponent<PageFlowCoroutineCommon>();
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x0011D3AC File Offset: 0x0011B5AC
		public static void StartExternalCoroutine(IEnumerator coroutine)
		{
			PageFlowCoroutineCommon.mMonoBehaviour.StartCoroutine(coroutine);
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x0011D3BA File Offset: 0x0011B5BA
		public static void StopAllCoroutine()
		{
			PageFlowCoroutineCommon.mMonoBehaviour.StopAllCoroutines();
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0011D3C6 File Offset: 0x0011B5C6
		public static void CallWaitForEndOfFrame(Action act)
		{
			PageFlowCoroutineCommon.mMonoBehaviour.StartCoroutine(PageFlowCoroutineCommon.DoCallWaitForEndOfFrame(act));
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x0011D3D9 File Offset: 0x0011B5D9
		public static void CallWaitForOneFrame(Action act)
		{
			PageFlowCoroutineCommon.mMonoBehaviour.StartCoroutine(PageFlowCoroutineCommon.DoCallWaitForOneFrame(act));
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0011D3EC File Offset: 0x0011B5EC
		public static void CallWaitForSeconds(float seconds, Action act)
		{
			PageFlowCoroutineCommon.mMonoBehaviour.StartCoroutine(PageFlowCoroutineCommon.DoCallWaitForSeconds(seconds, act));
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x0011D400 File Offset: 0x0011B600
		public static void CallWaitForSecondsRealtime(float seconds, Action act)
		{
			PageFlowCoroutineCommon.mMonoBehaviour.StartCoroutine(PageFlowCoroutineCommon.DoWaitForSecondsRealtime(seconds, act));
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0011D414 File Offset: 0x0011B614
		private static IEnumerator DoCallWaitForEndOfFrame(Action act)
		{
			yield return new WaitForEndOfFrame();
			act();
			yield break;
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x0011D423 File Offset: 0x0011B623
		private static IEnumerator DoCallWaitForOneFrame(Action act)
		{
			yield return 0;
			act();
			yield break;
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x0011D432 File Offset: 0x0011B632
		private static IEnumerator DoCallWaitForSeconds(float seconds, Action act)
		{
			yield return new WaitForSeconds(seconds);
			act();
			yield break;
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x0011D448 File Offset: 0x0011B648
		private static IEnumerator DoWaitForSecondsRealtime(float seconds, Action act)
		{
			yield return new WaitForSecondsRealtime(seconds);
			act();
			yield break;
		}

		// Token: 0x04000A2D RID: 2605
		private static readonly MonoBehaviour mMonoBehaviour;
	}
}
