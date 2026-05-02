using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000074 RID: 116
	public class ButtonScale : MonoBehaviour, IPointHandler, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x0011268A File Offset: 0x0011088A
		private RectTransform mCacheTarget
		{
			get
			{
				if (this.tweenTarget == null)
				{
					this.tweenTarget = base.GetComponent<RectTransform>();
					this.mScale = this.tweenTarget.localScale;
				}
				return this.tweenTarget;
			}
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x001126BD File Offset: 0x001108BD
		private void Start()
		{
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.GetComponent<RectTransform>();
			}
			this.mScale = this.tweenTarget.localScale;
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x001126EA File Offset: 0x001108EA
		private void OnDisable()
		{
			this.mCacheTarget.localScale = this.mScale;
			if (this.mTween)
			{
				this.mTween.enabled = false;
			}
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00112716 File Offset: 0x00110916
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.Scale(this.enter);
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x00112724 File Offset: 0x00110924
		public void OnPointerExit(PointerEventData eventData)
		{
			this.Scale(this.mScale);
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00112732 File Offset: 0x00110932
		public void OnPointerDown(PointerEventData eventData)
		{
			this.Scale(this.down);
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00112740 File Offset: 0x00110940
		public void OnPointerUp(PointerEventData eventData)
		{
			this.Scale(this.mScale);
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x0011274E File Offset: 0x0011094E
		public void OnPointerClick(PointerEventData eventData)
		{
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x00112750 File Offset: 0x00110950
		private void Scale(Vector3 to)
		{
			this.mTween = TweenScale.Begin(this.tweenTarget.gameObject, this.tweenTarget.localScale, to, this.duration, 0f);
		}

		// Token: 0x040008D1 RID: 2257
		public RectTransform tweenTarget;

		// Token: 0x040008D2 RID: 2258
		public Vector3 enter = new Vector3(1.1f, 1.1f, 1.1f);

		// Token: 0x040008D3 RID: 2259
		public Vector3 down = new Vector3(1.05f, 1.05f, 1.05f);

		// Token: 0x040008D4 RID: 2260
		public float duration = 0.2f;

		// Token: 0x040008D5 RID: 2261
		private Vector3 mScale;

		// Token: 0x040008D6 RID: 2262
		private TweenScale mTween;
	}
}
