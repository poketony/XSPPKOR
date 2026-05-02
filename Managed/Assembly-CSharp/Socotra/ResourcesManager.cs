using System;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000DE RID: 222
	public class ResourcesManager : SingletonBehaviour<ResourcesManager>
	{
		// Token: 0x060012B2 RID: 4786 RVA: 0x0011EF6B File Offset: 0x0011D16B
		private void Awake()
		{
			this.resourceList = this.resourceRoot.GetComponentsInChildren<Resources>();
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x0011EF7E File Offset: 0x0011D17E
		private void Start()
		{
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x0011EF80 File Offset: 0x0011D180
		private void Update()
		{
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x0011EF84 File Offset: 0x0011D184
		public Resources GetResources(string name)
		{
			foreach (Resources resources in this.resourceList)
			{
				if (resources.gameObject.name.Equals(name))
				{
					return resources;
				}
			}
			Debug.Log("Resources Not Found:" + name);
			return null;
		}

		// Token: 0x04000A75 RID: 2677
		private Resources[] resourceList;

		// Token: 0x04000A76 RID: 2678
		[SerializeField]
		private GameObject resourceRoot;
	}
}
