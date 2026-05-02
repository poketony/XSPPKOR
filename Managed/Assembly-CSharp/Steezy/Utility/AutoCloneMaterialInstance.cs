using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000093 RID: 147
	[RequireComponent(typeof(MeshRenderer))]
	public class AutoCloneMaterialInstance : MonoBehaviour
	{
		// Token: 0x06000F79 RID: 3961 RVA: 0x001150F8 File Offset: 0x001132F8
		private void Awake()
		{
			MeshRenderer component = base.GetComponent<MeshRenderer>();
			component.material = Object.Instantiate<Material>(component.material);
		}
	}
}
