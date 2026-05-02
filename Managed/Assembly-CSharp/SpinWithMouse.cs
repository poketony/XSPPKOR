using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200005B RID: 91
public class SpinWithMouse : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	// Token: 0x06000DFD RID: 3581 RVA: 0x0010DD27 File Offset: 0x0010BF27
	private void Start()
	{
		if (!this.target)
		{
			this.target = base.transform;
		}
	}

	// Token: 0x06000DFE RID: 3582 RVA: 0x0010DD44 File Offset: 0x0010BF44
	public void OnDrag(PointerEventData eventData)
	{
		if (this.target)
		{
			this.target.localRotation = Quaternion.Euler(0f, -0.5f * this.speed * eventData.delta.x, 0f) * this.target.localRotation;
		}
	}

	// Token: 0x04000846 RID: 2118
	public float speed = 1f;

	// Token: 0x04000847 RID: 2119
	public Transform target;
}
