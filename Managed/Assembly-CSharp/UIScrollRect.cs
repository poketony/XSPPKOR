using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200005F RID: 95
public class UIScrollRect : ScrollRect
{
	// Token: 0x06000E2A RID: 3626 RVA: 0x0010E90C File Offset: 0x0010CB0C
	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
		if (this.onBeginDrag != null)
		{
			this.onBeginDrag(eventData);
		}
	}

	// Token: 0x06000E2B RID: 3627 RVA: 0x0010E929 File Offset: 0x0010CB29
	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		if (this.onDrag != null)
		{
			this.onDrag(eventData);
		}
	}

	// Token: 0x06000E2C RID: 3628 RVA: 0x0010E946 File Offset: 0x0010CB46
	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);
		if (this.onEndDrag != null)
		{
			this.onEndDrag(eventData);
		}
	}

	// Token: 0x04000861 RID: 2145
	public Action<PointerEventData> onBeginDrag;

	// Token: 0x04000862 RID: 2146
	public Action<PointerEventData> onDrag;

	// Token: 0x04000863 RID: 2147
	public Action<PointerEventData> onEndDrag;
}
