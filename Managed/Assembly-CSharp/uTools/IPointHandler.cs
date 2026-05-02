using System;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000072 RID: 114
	public interface IPointHandler : IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler
	{
		// Token: 0x06000E94 RID: 3732
		void OnPointerEnter(PointerEventData eventData);

		// Token: 0x06000E95 RID: 3733
		void OnPointerDown(PointerEventData eventData);

		// Token: 0x06000E96 RID: 3734
		void OnPointerClick(PointerEventData eventData);

		// Token: 0x06000E97 RID: 3735
		void OnPointerUp(PointerEventData eventData);

		// Token: 0x06000E98 RID: 3736
		void OnPointerExit(PointerEventData eventData);
	}
}
