using System;
using System.Collections;
using System.Collections.Generic;
using Steezy.PageFlow;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000003 RID: 3
public class AppliArchivePrefabManager : SingletonBehaviour<AppliArchivePrefabManager>
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public GameObject ScreenParent
	{
		get
		{
			return this.screenParent;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
	public GameObject PopupParent
	{
		get
		{
			return this.popupParent;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002068 File Offset: 0x00000268
	public void InitPopupCache(UnityAction callback = null, params string[] cachePopupPrefabNames)
	{
		CoroutineCommon.StartExternalCoroutine(this.CacheLoadCoroutine(callback, cachePopupPrefabNames));
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002077 File Offset: 0x00000277
	private IEnumerator CacheLoadCoroutine(UnityAction callback = null, params string[] cachePopupPrefabNames)
	{
		int cnt = cachePopupPrefabNames.Length;
		string[] array = cachePopupPrefabNames;
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			string popupPath = "Prefab/" + text + ".prefab";
			if (this.cacheAsyncObjHash.ContainsKey(popupPath))
			{
				int cnt3 = cnt;
				cnt = cnt3 - 1;
				if (callback != null && cnt == 0)
				{
					callback.Invoke();
				}
			}
			else
			{
				yield return AssetLoadUtil.LoadAssetAsync<GameObject>(popupPath, delegate(GameObject UIPopupObj)
				{
					int cnt2 = cnt;
					cnt = cnt2 - 1;
					this.cacheAsyncObjHash[popupPath] = UIPopupObj;
					if (callback != null && cnt == 0)
					{
						callback.Invoke();
					}
				});
			}
		}
		array = null;
		yield break;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002094 File Offset: 0x00000294
	public GameObject CreatePopup(string displayPopupPrefabName, bool isPopupDestroy = true)
	{
		if (isPopupDestroy)
		{
			this.ClearPopup();
		}
		string text = "Prefab/" + displayPopupPrefabName + ".prefab";
		GameObject gameObject = (GameObject)this.cacheObjHash[text];
		if (gameObject == null)
		{
			gameObject = AssetLoadUtil.LoadAsset<GameObject>(text, null);
			this.cacheObjHash.Add(text, gameObject);
		}
		GameObject gameObject2 = null;
		if (gameObject != null && this.popupParent != null)
		{
			gameObject2 = InstantiateManager.Instantiate(this.popupParent, gameObject);
			this.AddActivePopupNames(displayPopupPrefabName);
		}
		SwitchInputSelectable[] array = this.screenParent.transform.GetComponentsInChildren<SwitchInputSelectable>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DisableSelectable(Array.Empty<string>());
		}
		foreach (SwitchInputSelectable switchInputSelectable in this.popupParent.transform.GetComponentsInChildren<SwitchInputSelectable>())
		{
			if (switchInputSelectable.name != gameObject2.name)
			{
				switchInputSelectable.DisableSelectable(Array.Empty<string>());
			}
		}
		return gameObject2;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002194 File Offset: 0x00000394
	public void CreatePopupAsync(string displayPopupPrefabName, UnityAction<GameObject> onLoadCallback = null, bool isPopupDestroy = true)
	{
		if (isPopupDestroy)
		{
			this.ClearPopup();
		}
		SwitchInputSelectable[] array = this.screenParent.transform.GetComponentsInChildren<SwitchInputSelectable>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DisableSelectable(Array.Empty<string>());
		}
		array = this.popupParent.transform.GetComponentsInChildren<SwitchInputSelectable>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DisableSelectable(Array.Empty<string>());
		}
		string popupPath = "Prefab/" + displayPopupPrefabName + ".prefab";
		GameObject gameObject = (GameObject)this.cacheAsyncObjHash[popupPath];
		if (gameObject == null)
		{
			this.AddActivePopupNames(displayPopupPrefabName);
			PageFlowCoroutineCommon.StartExternalCoroutine(AssetLoadUtil.LoadAssetAsync<GameObject>(popupPath, delegate(GameObject UIPopupObj)
			{
				this.cacheAsyncObjHash[popupPath] = UIPopupObj;
				GameObject gameObject3 = null;
				if (UIPopupObj != null && this.popupParent != null)
				{
					gameObject3 = InstantiateManager.Instantiate(this.popupParent, UIPopupObj);
				}
				else
				{
					this.activePopupNames.Remove(displayPopupPrefabName);
				}
				if (onLoadCallback != null)
				{
					onLoadCallback.Invoke(gameObject3);
				}
			}));
			return;
		}
		GameObject gameObject2 = null;
		if (gameObject != null && this.popupParent != null)
		{
			gameObject2 = InstantiateManager.Instantiate(this.popupParent, gameObject);
			this.AddActivePopupNames(displayPopupPrefabName);
		}
		if (onLoadCallback != null)
		{
			onLoadCallback.Invoke(gameObject2);
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000022CA File Offset: 0x000004CA
	private void AddActivePopupNames(string popupName)
	{
		if (!this.activePopupNames.Contains(popupName))
		{
			this.activePopupNames.Add(popupName);
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000022E8 File Offset: 0x000004E8
	public void ClearPopup()
	{
		if (this.popupParent == null)
		{
			return;
		}
		foreach (object obj in this.popupParent.transform)
		{
			Object.Destroy(((Transform)obj).gameObject);
		}
		this.activePopupNames.Clear();
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002364 File Offset: 0x00000564
	public void ClearPopup(string popupName)
	{
		if (this.popupParent == null)
		{
			return;
		}
		bool flag = false;
		foreach (object obj in this.popupParent.transform)
		{
			Transform transform = (Transform)obj;
			if (transform.name == popupName)
			{
				Object.Destroy(transform.gameObject);
				this.activePopupNames.Remove(popupName);
			}
			else
			{
				flag = true;
			}
		}
		if (!flag)
		{
			SwitchInputSelectable[] array = this.screenParent.transform.GetComponentsInChildren<SwitchInputSelectable>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SelectLastSelectable();
			}
		}
		foreach (SwitchInputSelectable switchInputSelectable in this.popupParent.transform.GetComponentsInChildren<SwitchInputSelectable>())
		{
			if (switchInputSelectable.name != popupName)
			{
				switchInputSelectable.SelectLastSelectable();
			}
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000246C File Offset: 0x0000066C
	public GameObject GetPopupObject(string popupName)
	{
		if (this.popupParent == null)
		{
			return null;
		}
		GameObject gameObject = null;
		Transform transform = this.popupParent.transform.Find(popupName);
		if (transform != null)
		{
			gameObject = transform.gameObject;
		}
		return gameObject;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000024AE File Offset: 0x000006AE
	public bool HasPopup()
	{
		return this.HasPopupExclude(new string[] { "" });
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000024C4 File Offset: 0x000006C4
	public bool HasPopup(string targetPopupName)
	{
		return !(this.popupParent == null) && this.activePopupNames.Contains(targetPopupName);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000024E4 File Offset: 0x000006E4
	public bool HasPopupExclude(params string[] excludePopupNames)
	{
		if (this.popupParent == null)
		{
			return false;
		}
		foreach (string text in this.activePopupNames)
		{
			if (Array.IndexOf<string>(excludePopupNames, text) < 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400000E RID: 14
	private const string UIResourcePathPrefab = "Prefab/";

	// Token: 0x0400000F RID: 15
	[SerializeField]
	private GameObject screenParent;

	// Token: 0x04000010 RID: 16
	[SerializeField]
	private GameObject popupParent;

	// Token: 0x04000011 RID: 17
	private Hashtable cacheObjHash = new Hashtable();

	// Token: 0x04000012 RID: 18
	private Hashtable cacheAsyncObjHash = new Hashtable();

	// Token: 0x04000013 RID: 19
	private List<string> activePopupNames = new List<string>();
}
