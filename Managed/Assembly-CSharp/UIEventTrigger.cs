using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200005D RID: 93
public class UIEventTrigger : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
	// Token: 0x06000E05 RID: 3589 RVA: 0x0010DEA0 File Offset: 0x0010C0A0
	public static UIEventTrigger Get(GameObject go)
	{
		UIEventTrigger uieventTrigger = go.GetComponent<UIEventTrigger>();
		if (uieventTrigger == null)
		{
			uieventTrigger = go.AddComponent<UIEventTrigger>();
		}
		return uieventTrigger;
	}

	// Token: 0x06000E06 RID: 3590 RVA: 0x0010DEC5 File Offset: 0x0010C0C5
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.onDown != null)
		{
			this.onDown(eventData);
		}
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x0010DEDB File Offset: 0x0010C0DB
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.onUp != null)
		{
			this.onUp(eventData);
		}
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x0010DEF1 File Offset: 0x0010C0F1
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.onClick != null)
		{
			this.onClick(eventData);
		}
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x0010DF07 File Offset: 0x0010C107
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.onBeginDrag != null)
		{
			this.onBeginDrag(eventData);
		}
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x0010DF1D File Offset: 0x0010C11D
	public void OnDrag(PointerEventData eventData)
	{
		if (this.onDrag != null)
		{
			this.onDrag(eventData);
		}
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x0010DF33 File Offset: 0x0010C133
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.onEndDrag != null)
		{
			this.onEndDrag(eventData);
		}
	}

	// Token: 0x06000E0C RID: 3596 RVA: 0x0010DF49 File Offset: 0x0010C149
	public void OnDrop(PointerEventData eventData)
	{
		if (this.onDrop != null)
		{
			this.onDrop(eventData);
		}
	}

	// Token: 0x0400084B RID: 2123
	public UIEventTrigger.EventDataDelegate onDown;

	// Token: 0x0400084C RID: 2124
	public UIEventTrigger.EventDataDelegate onUp;

	// Token: 0x0400084D RID: 2125
	public UIEventTrigger.EventDataDelegate onClick;

	// Token: 0x0400084E RID: 2126
	public UIEventTrigger.EventDataDelegate onBeginDrag;

	// Token: 0x0400084F RID: 2127
	public UIEventTrigger.EventDataDelegate onDrag;

	// Token: 0x04000850 RID: 2128
	public UIEventTrigger.EventDataDelegate onEndDrag;

	// Token: 0x04000851 RID: 2129
	public UIEventTrigger.EventDataDelegate onDrop;

	// Token: 0x020001DE RID: 478
	// (Invoke) Token: 0x06001C60 RID: 7264
	public delegate void VoidDelegate(GameObject go);

	// Token: 0x020001DF RID: 479
	// (Invoke) Token: 0x06001C64 RID: 7268
	public delegate void EventDataDelegate(PointerEventData eventData);
}
