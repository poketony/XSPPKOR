using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000AC RID: 172
	[ExecuteInEditMode]
	[RequireComponent(typeof(Renderer))]
	public class SortingLayer : MonoBehaviour
	{
		// Token: 0x0600105F RID: 4191 RVA: 0x001182F4 File Offset: 0x001164F4
		private void Awake()
		{
			this.LayerName = this.layerName;
			this.OrderInLayer = this.orderInLayer;
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0011830E File Offset: 0x0011650E
		private void OnValidate()
		{
			this.LayerName = this.layerName;
			this.OrderInLayer = this.orderInLayer;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06001061 RID: 4193 RVA: 0x00118328 File Offset: 0x00116528
		// (set) Token: 0x06001062 RID: 4194 RVA: 0x00118330 File Offset: 0x00116530
		public string LayerName
		{
			get
			{
				return this.layerName;
			}
			set
			{
				this.layerName = value;
				Renderer[] components = base.GetComponents<Renderer>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].sortingLayerName = this.layerName;
				}
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06001063 RID: 4195 RVA: 0x00118367 File Offset: 0x00116567
		// (set) Token: 0x06001064 RID: 4196 RVA: 0x00118370 File Offset: 0x00116570
		public int OrderInLayer
		{
			get
			{
				return this.orderInLayer;
			}
			set
			{
				this.orderInLayer = value;
				Renderer[] components = base.GetComponents<Renderer>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].sortingOrder = this.orderInLayer;
				}
			}
		}

		// Token: 0x040009B1 RID: 2481
		[SerializeField]
		[SortingLayer]
		private string layerName = "Default";

		// Token: 0x040009B2 RID: 2482
		[SerializeField]
		private int orderInLayer;

		// Token: 0x040009B3 RID: 2483
		private Renderer _renderer;
	}
}
