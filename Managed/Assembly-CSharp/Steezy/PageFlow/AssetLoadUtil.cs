using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Steezy.PageFlow
{
	// Token: 0x020000C8 RID: 200
	public static class AssetLoadUtil
	{
		// Token: 0x06001212 RID: 4626 RVA: 0x0011CDE1 File Offset: 0x0011AFE1
		static AssetLoadUtil()
		{
			AssetLoadUtil.Init();
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x0011CDE8 File Offset: 0x0011AFE8
		public static void Init()
		{
			AssetLoadUtil.assetCacheMap = new Dictionary<string, Object>();
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x0011CDF4 File Offset: 0x0011AFF4
		public static void UnloadAssets(string assetPath)
		{
			if (AssetLoadUtil.assetCacheMap.ContainsKey(assetPath))
			{
				if (AssetLoadUtil.assetCacheMap[assetPath])
				{
					Addressables.Release<Object>(AssetLoadUtil.assetCacheMap[assetPath]);
				}
				AssetLoadUtil.assetCacheMap.Remove(assetPath);
			}
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x0011CE34 File Offset: 0x0011B034
		public static void UnloadAllAssets()
		{
			AssetBundle.UnloadAllAssetBundles(false);
			foreach (Object @object in AssetLoadUtil.assetCacheMap.Values)
			{
				if (@object != null)
				{
					Addressables.Release<Object>(@object);
				}
			}
			AssetLoadUtil.assetCacheMap = new Dictionary<string, Object>();
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x0011CEA4 File Offset: 0x0011B0A4
		public static T LoadAsset<T>(string assetPath, UnityAction<AssetBundle> onCompleteCallback = null) where T : Object
		{
			T t = default(T);
			string text = "Assets/Res/" + assetPath;
			if (AssetLoadUtil.assetCacheMap.ContainsKey(text) && AssetLoadUtil.assetCacheMap[text] && typeof(T) == AssetLoadUtil.assetCacheMap[text].GetType())
			{
				t = (T)((object)AssetLoadUtil.assetCacheMap[text]);
			}
			else
			{
				AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(text, null);
				asyncOperationHandle.WaitForCompletion();
				if (asyncOperationHandle.Status == 1 && asyncOperationHandle.Result.Count > 0)
				{
					t = Addressables.LoadAssetAsync<T>(text).WaitForCompletion();
					AssetLoadUtil.assetCacheMap[text] = t;
				}
			}
			return t;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x0011CF62 File Offset: 0x0011B162
		public static IEnumerator LoadAssetAsync<T>(string assetPath, UnityAction<T> onLoadCallback) where T : Object
		{
			T obj = default(T);
			string address = "Assets/Res/" + assetPath;
			if (AssetLoadUtil.assetCacheMap.ContainsKey(address) && AssetLoadUtil.assetCacheMap[address] && typeof(T) == AssetLoadUtil.assetCacheMap[address].GetType())
			{
				obj = (T)((object)AssetLoadUtil.assetCacheMap[address]);
			}
			else
			{
				AsyncOperationHandle<IList<IResourceLocation>> validateAddress = Addressables.LoadResourceLocationsAsync(address, null);
				yield return validateAddress;
				if (validateAddress.Status == 1 && validateAddress.Result.Count > 0)
				{
					AsyncOperationHandle<T> op = Addressables.LoadAssetAsync<T>(address);
					yield return op;
					obj = op.Result;
					AssetLoadUtil.assetCacheMap[address] = obj;
					op = default(AsyncOperationHandle<T>);
				}
				validateAddress = default(AsyncOperationHandle<IList<IResourceLocation>>);
			}
			onLoadCallback.Invoke(obj);
			yield break;
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x0011CF78 File Offset: 0x0011B178
		public static void LoadLabelAssets<T>(string label, UnityAction<T> onLoadCallback) where T : Object
		{
			if (AssetLoadUtil.assetCacheMap.ContainsKey(label) && AssetLoadUtil.assetCacheMap[label] && typeof(T) == AssetLoadUtil.assetCacheMap[label].GetType())
			{
				T t = (T)((object)AssetLoadUtil.assetCacheMap[label]);
				return;
			}
			AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(label, null);
			asyncOperationHandle.WaitForCompletion();
			if (asyncOperationHandle.Status == 1 && asyncOperationHandle.Result.Count > 0)
			{
				Addressables.LoadAssetsAsync<T>(label, delegate(T obj)
				{
					onLoadCallback.Invoke(obj);
					AssetLoadUtil.assetCacheMap[label] = obj;
				}).WaitForCompletion();
			}
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x0011D04D File Offset: 0x0011B24D
		public static IEnumerator LoadLabelAssetsAsync<T>(string label, UnityAction<T> onLoadCallback, UnityAction onCompleteCallback = null) where T : Object
		{
			if (AssetLoadUtil.assetCacheMap.ContainsKey(label) && AssetLoadUtil.assetCacheMap[label] && typeof(T) == AssetLoadUtil.assetCacheMap[label].GetType())
			{
				T t = (T)((object)AssetLoadUtil.assetCacheMap[label]);
			}
			else
			{
				AsyncOperationHandle<IList<IResourceLocation>> validateAddress = Addressables.LoadResourceLocationsAsync(label, null);
				yield return validateAddress;
				if (validateAddress.Status == 1 && validateAddress.Result.Count > 0)
				{
					AsyncOperationHandle<IList<T>> asyncOperationHandle = Addressables.LoadAssetsAsync<T>(label, delegate(T obj)
					{
						onLoadCallback.Invoke(obj);
						AssetLoadUtil.assetCacheMap[label] = obj;
					});
					yield return asyncOperationHandle;
				}
				validateAddress = default(AsyncOperationHandle<IList<IResourceLocation>>);
			}
			if (onCompleteCallback != null)
			{
				onCompleteCallback.Invoke();
			}
			yield break;
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x0011D06A File Offset: 0x0011B26A
		public static IEnumerator PreloadAssetAsync(string assetPath, UnityAction onLoadCallback = null)
		{
			string address = "Assets/Res/" + assetPath;
			AsyncOperationHandle<IList<IResourceLocation>> validateAddress = Addressables.LoadResourceLocationsAsync(address, null);
			yield return validateAddress;
			if (validateAddress.Status == 1 && validateAddress.Result.Count > 0)
			{
				AsyncOperationHandle asyncOperationHandle = Addressables.DownloadDependenciesAsync(address, false);
				yield return asyncOperationHandle;
			}
			if (onLoadCallback != null)
			{
				onLoadCallback.Invoke();
			}
			yield break;
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x0011D080 File Offset: 0x0011B280
		public static IEnumerator PreloadLabelAssetsAsync(string label, UnityAction onCompleteCallback = null)
		{
			AsyncOperationHandle<IList<IResourceLocation>> validateAddress = Addressables.LoadResourceLocationsAsync(label, null);
			yield return validateAddress;
			if (validateAddress.Status == 1 && validateAddress.Result.Count > 0)
			{
				AsyncOperationHandle asyncOperationHandle = Addressables.DownloadDependenciesAsync(label, false);
				yield return asyncOperationHandle;
			}
			if (onCompleteCallback != null)
			{
				onCompleteCallback.Invoke();
			}
			yield break;
		}

		// Token: 0x04000A24 RID: 2596
		private const string AddressableCommonAddressPrefix = "Assets/Res/";

		// Token: 0x04000A25 RID: 2597
		private static Dictionary<string, Object> assetCacheMap;
	}
}
