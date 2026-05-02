using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000095 RID: 149
	public class ObjectPool : MonoBehaviour
	{
		// Token: 0x06000F7D RID: 3965 RVA: 0x001151EF File Offset: 0x001133EF
		private void OnEnable()
		{
			if (this.interval > 0)
			{
				base.StartCoroutine(this.RemoveObjectCheck());
			}
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00115207 File Offset: 0x00113407
		private void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00115210 File Offset: 0x00113410
		public void OnDestroy()
		{
			if (ObjectPool.poolAttachedObject == null)
			{
				return;
			}
			if (ObjectPool.poolAttachedObject.GetComponents<ObjectPool>().Length == 1)
			{
				ObjectPool.poolAttachedObject = null;
			}
			foreach (GameObject gameObject in this.pooledObjectList)
			{
				Object.Destroy(gameObject);
			}
			this.pooledObjectList.Clear();
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x00115290 File Offset: 0x00113490
		// (set) Token: 0x06000F81 RID: 3969 RVA: 0x00115298 File Offset: 0x00113498
		public int Interval
		{
			get
			{
				return this.interval;
			}
			set
			{
				if (this.interval != value)
				{
					this.interval = value;
					base.StopAllCoroutines();
					if (this.interval > 0)
					{
						base.StartCoroutine(this.RemoveObjectCheck());
					}
				}
			}
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x001152C8 File Offset: 0x001134C8
		public static ObjectPool GetObjectPool(GameObject obj, int maxPoolCount = 100, int minPoolCount = 0)
		{
			ObjectPool.maxCount = maxPoolCount;
			ObjectPool.prepareCount = minPoolCount;
			if (ObjectPool.poolAttachedObject == null)
			{
				ObjectPool.poolAttachedObject = GameObject.Find("ObjectPool");
				if (ObjectPool.poolAttachedObject == null)
				{
					ObjectPool.poolAttachedObject = new GameObject("ObjectPool");
				}
			}
			foreach (ObjectPool objectPool in ObjectPool.poolAttachedObject.GetComponents<ObjectPool>())
			{
				if (objectPool.prefab == obj)
				{
					return objectPool;
				}
			}
			foreach (ObjectPool objectPool2 in Object.FindObjectsOfType<ObjectPool>())
			{
				if (objectPool2.prefab == obj)
				{
					return objectPool2;
				}
			}
			ObjectPool objectPool3 = ObjectPool.poolAttachedObject.AddComponent<ObjectPool>();
			objectPool3.prefab = obj;
			return objectPool3;
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x0011537F File Offset: 0x0011357F
		public GameObject GetInstance()
		{
			return this.GetInstance(base.transform);
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00115390 File Offset: 0x00113590
		public GameObject GetInstance(Transform parent)
		{
			this.pooledObjectList.RemoveAll((GameObject obj) => obj == null);
			foreach (GameObject gameObject in this.pooledObjectList)
			{
				if (!gameObject.activeSelf)
				{
					gameObject.SetActive(true);
					return gameObject;
				}
			}
			if (this.pooledObjectList.Count < ObjectPool.maxCount)
			{
				GameObject gameObject2 = Object.Instantiate<GameObject>(this.prefab);
				gameObject2.SetActive(true);
				gameObject2.transform.SetParent(parent, false);
				this.pooledObjectList.Add(gameObject2);
				return gameObject2;
			}
			return null;
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x00115460 File Offset: 0x00113660
		private IEnumerator RemoveObjectCheck()
		{
			for (;;)
			{
				this.RemoveObject(ObjectPool.prepareCount);
				yield return new WaitForSeconds((float)this.interval);
			}
			yield break;
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x00115470 File Offset: 0x00113670
		public void RemoveObject(int max)
		{
			if (this.pooledObjectList.Count > max)
			{
				int num = this.pooledObjectList.Count - max;
				for (int i = 0; i < this.pooledObjectList.Count; i++)
				{
					GameObject gameObject = this.pooledObjectList[i];
					if (num == 0)
					{
						break;
					}
					if (!gameObject.activeSelf)
					{
						this.pooledObjectList.Remove(gameObject);
						Object.Destroy(gameObject);
						num--;
					}
				}
			}
		}

		// Token: 0x04000969 RID: 2409
		public GameObject prefab;

		// Token: 0x0400096A RID: 2410
		public static int maxCount = 100;

		// Token: 0x0400096B RID: 2411
		public static int prepareCount = 0;

		// Token: 0x0400096C RID: 2412
		[SerializeField]
		private int interval = 1;

		// Token: 0x0400096D RID: 2413
		private List<GameObject> pooledObjectList = new List<GameObject>();

		// Token: 0x0400096E RID: 2414
		private static GameObject poolAttachedObject = null;
	}
}
