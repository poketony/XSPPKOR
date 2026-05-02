using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x0200009F RID: 159
	[ExecuteInEditMode]
	[RequireComponent(typeof(Renderer))]
	public class CanvasSortOrderChildSet : MonoBehaviour
	{
		// Token: 0x06001015 RID: 4117 RVA: 0x00116E4C File Offset: 0x0011504C
		private void Awake()
		{
			this.SetOrderInLayer();
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00116E54 File Offset: 0x00115054
		private void OnValidate()
		{
			this.SetOrderInLayer();
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x00116E5C File Offset: 0x0011505C
		private void SetOrderInLayer()
		{
			Canvas componentInParent = base.GetComponentInParent<Canvas>();
			if (componentInParent != null)
			{
				base.GetComponent<Renderer>().sortingOrder = componentInParent.sortingOrder + this.offsetSortingOrder;
			}
		}

		// Token: 0x04000987 RID: 2439
		public int offsetSortingOrder;
	}
}
