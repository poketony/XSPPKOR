using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000079 RID: 121
	public class PlayTween : MonoBehaviour, IPointHandler, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler
	{
		// Token: 0x06000ECD RID: 3789 RVA: 0x0011339C File Offset: 0x0011159C
		private void Start()
		{
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.gameObject;
			}
			this.mTweeners = (this.inCludeChildren ? this.tweenTarget.GetComponentsInChildren<Tweener>() : this.tweenTarget.GetComponents<Tweener>());
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x001133E9 File Offset: 0x001115E9
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerEnter);
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x001133F2 File Offset: 0x001115F2
		public void OnPointerDown(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerDown);
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x001133FB File Offset: 0x001115FB
		public void OnPointerClick(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerClick);
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x00113404 File Offset: 0x00111604
		public void OnPointerUp(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerUp);
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x0011340D File Offset: 0x0011160D
		public void OnPointerExit(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerExit);
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x00113416 File Offset: 0x00111616
		private void TriggerPlay(Trigger _trigger)
		{
			if (_trigger == this.trigger)
			{
				this.Play();
			}
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x00113428 File Offset: 0x00111628
		private void Play()
		{
			if (this.playDirection == Direction.Toggle)
			{
				foreach (Tweener tweener in this.mTweeners)
				{
					if (tweener.tweenGroup == this.tweenGroup)
					{
						tweener.Toggle();
					}
				}
				return;
			}
			foreach (Tweener tweener2 in this.mTweeners)
			{
				if (tweener2.tweenGroup == this.tweenGroup)
				{
					tweener2.Play(this.playDirection == Direction.Forward);
				}
			}
		}

		// Token: 0x040008FF RID: 2303
		public GameObject tweenTarget;

		// Token: 0x04000900 RID: 2304
		public Direction playDirection = Direction.Forward;

		// Token: 0x04000901 RID: 2305
		public Trigger trigger = Trigger.OnPointerClick;

		// Token: 0x04000902 RID: 2306
		public int tweenGroup;

		// Token: 0x04000903 RID: 2307
		public bool inCludeChildren;

		// Token: 0x04000904 RID: 2308
		private Tweener[] mTweeners;
	}
}
