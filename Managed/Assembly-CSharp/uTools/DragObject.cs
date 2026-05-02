using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000075 RID: 117
	public class DragObject : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x001127D2 File Offset: 0x001109D2
		private RectTransform cacheTarget
		{
			get
			{
				if (this.target == null)
				{
					this.target = base.GetComponent<RectTransform>();
				}
				return this.target;
			}
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x001127F4 File Offset: 0x001109F4
		public void OnDrag(PointerEventData eventData)
		{
			this.cacheTarget.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0f);
		}

		// Token: 0x040008D7 RID: 2263
		public RectTransform target;
	}
}
