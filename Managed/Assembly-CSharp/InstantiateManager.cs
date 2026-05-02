using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
public static class InstantiateManager
{
	// Token: 0x060000CE RID: 206 RVA: 0x0000C118 File Offset: 0x0000A318
	public static GameObject Instantiate(GameObject parentObj, GameObject createObj)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(createObj, parentObj.transform.position, parentObj.transform.rotation);
		gameObject.transform.SetParent(parentObj.transform, false);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.name = createObj.name;
		return gameObject;
	}
}
