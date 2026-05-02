using System;
using UnityEngine;

// Token: 0x02000054 RID: 84
public static class GameObjectExtension
{
	// Token: 0x06000DDF RID: 3551 RVA: 0x0010D62C File Offset: 0x0010B82C
	public static void SetLayer(this GameObject gameObject, int layerNo, bool needSetChildrens = true)
	{
		if (gameObject == null)
		{
			return;
		}
		gameObject.layer = layerNo;
		if (!needSetChildrens)
		{
			return;
		}
		foreach (object obj in gameObject.transform)
		{
			((Transform)obj).gameObject.SetLayer(layerNo, needSetChildrens);
		}
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x0010D6A0 File Offset: 0x0010B8A0
	public static void SetMaterial(this GameObject gameObject, Material setMaterial, bool needSetChildrens = true)
	{
		if (gameObject == null)
		{
			return;
		}
		if (gameObject.GetComponent<Renderer>())
		{
			gameObject.GetComponent<Renderer>().material = setMaterial;
		}
		if (!needSetChildrens)
		{
			return;
		}
		foreach (object obj in gameObject.transform)
		{
			((Transform)obj).gameObject.SetMaterial(setMaterial, needSetChildrens);
		}
	}
}
