using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000094 RID: 148
	public static class InstantiateUtil
	{
		// Token: 0x06000F7B RID: 3963 RVA: 0x00115118 File Offset: 0x00113318
		public static GameObject Instantiate(GameObject parentObj, string createResourcePath)
		{
			GameObject gameObj = ResourcesLoadUtil.GetGameObj(createResourcePath, false);
			GameObject gameObject = Object.Instantiate<GameObject>(gameObj, parentObj.transform.position, parentObj.transform.rotation);
			gameObject.transform.SetParent(parentObj.transform, false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.name = gameObj.name;
			return gameObject;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00115188 File Offset: 0x00113388
		public static GameObject Instantiate(GameObject parentObj, GameObject createObj)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(createObj, parentObj.transform.position, parentObj.transform.rotation);
			gameObject.transform.SetParent(parentObj.transform, false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.name = createObj.name;
			return gameObject;
		}
	}
}
