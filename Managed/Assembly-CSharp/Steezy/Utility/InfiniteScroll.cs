using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x020000A3 RID: 163
	public class InfiniteScroll : UIBehaviour
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06001023 RID: 4131 RVA: 0x0011727D File Offset: 0x0011547D
		protected RectTransform _RectTransform
		{
			get
			{
				if (this.m_rectTransform == null)
				{
					this.m_rectTransform = base.GetComponent<RectTransform>();
				}
				return this.m_rectTransform;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06001024 RID: 4132 RVA: 0x0011729F File Offset: 0x0011549F
		private float AnchoredPosition
		{
			get
			{
				if (this.direction != InfiniteScroll.Direction.Vertical)
				{
					return this._RectTransform.anchoredPosition.x;
				}
				return -this._RectTransform.anchoredPosition.y;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06001025 RID: 4133 RVA: 0x001172CC File Offset: 0x001154CC
		public float ItemScale
		{
			get
			{
				if (this.m_ItemBase != null && this.m_itemScale == -1f)
				{
					this.m_itemScale = ((this.direction == InfiniteScroll.Direction.Vertical) ? this.m_ItemBase.sizeDelta.y : this.m_ItemBase.sizeDelta.x);
				}
				return this.m_itemScale;
			}
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0011732A File Offset: 0x0011552A
		protected override void Awake()
		{
			this.defaultAnchoredPosition = this._RectTransform.anchoredPosition;
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x00117340 File Offset: 0x00115540
		public void Init(bool isResetAnchoredPosition = true)
		{
			if (isResetAnchoredPosition)
			{
				this.ResetAnchoredPosition();
			}
			this.m_currentItemNo = 0;
			this.m_diffPreFramePosition = this.itemUpdateOffsetPosition;
			foreach (RectTransform rectTransform in this.m_itemList)
			{
				Object.Destroy(rectTransform.gameObject);
			}
			this.m_itemList.Clear();
			List<IInfiniteScrollSetup> list = (from item in base.GetComponents<MonoBehaviour>()
				where item is IInfiniteScrollSetup
				select item as IInfiniteScrollSetup).ToList<IInfiniteScrollSetup>();
			ScrollRect componentInParent = base.GetComponentInParent<ScrollRect>();
			componentInParent.horizontal = this.direction == InfiniteScroll.Direction.Horizontal;
			componentInParent.vertical = this.direction == InfiniteScroll.Direction.Vertical;
			componentInParent.content = this._RectTransform;
			this.m_ItemBase.gameObject.SetActive(false);
			for (int i = 0; i < this.m_instantateItemCount; i++)
			{
				RectTransform rectTransform2 = Object.Instantiate<RectTransform>(this.m_ItemBase);
				rectTransform2.SetParent(base.transform, false);
				rectTransform2.name = i.ToString();
				rectTransform2.anchoredPosition = ((this.direction == InfiniteScroll.Direction.Vertical) ? new Vector2(0f, -this.ItemScale * (float)i) : new Vector2(this.ItemScale * (float)i, 0f));
				this.m_itemList.Add(rectTransform2);
				rectTransform2.gameObject.SetActive(true);
			}
			foreach (IInfiniteScrollSetup infiniteScrollSetup in list)
			{
				infiniteScrollSetup.OnPostSetupItems();
			}
			for (int j = 0; j < this.m_itemList.Count; j++)
			{
				foreach (IInfiniteScrollSetup infiniteScrollSetup2 in list)
				{
					infiniteScrollSetup2.OnUpdateItem(j, this.m_itemList[j].gameObject);
				}
			}
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x00117580 File Offset: 0x00115780
		private void Update()
		{
			while (this.AnchoredPosition - this.m_diffPreFramePosition < -this.ItemScale * 2f)
			{
				this.m_diffPreFramePosition -= this.ItemScale;
				RectTransform rectTransform = this.m_itemList[0];
				this.m_itemList.RemoveAt(0);
				this.m_itemList.Add(rectTransform);
				float num = this.ItemScale * (float)this.m_instantateItemCount + this.ItemScale * (float)this.m_currentItemNo;
				rectTransform.anchoredPosition = ((this.direction == InfiniteScroll.Direction.Vertical) ? new Vector2(0f, -num) : new Vector2(num, 0f));
				this.onUpdateItem.Invoke(this.m_currentItemNo + this.m_instantateItemCount, rectTransform.gameObject);
				this.m_currentItemNo++;
			}
			while (this.AnchoredPosition - this.m_diffPreFramePosition > 0f)
			{
				this.m_diffPreFramePosition += this.ItemScale;
				int num2 = this.m_instantateItemCount - 1;
				RectTransform rectTransform2 = this.m_itemList[num2];
				this.m_itemList.RemoveAt(num2);
				this.m_itemList.Insert(0, rectTransform2);
				this.m_currentItemNo--;
				float num3 = this.ItemScale * (float)this.m_currentItemNo;
				rectTransform2.anchoredPosition = ((this.direction == InfiniteScroll.Direction.Vertical) ? new Vector2(0f, -num3) : new Vector2(num3, 0f));
				this.onUpdateItem.Invoke(this.m_currentItemNo, rectTransform2.gameObject);
			}
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x00117716 File Offset: 0x00115916
		public void ResetAnchoredPosition()
		{
			this._RectTransform.anchoredPosition = this.defaultAnchoredPosition;
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00117729 File Offset: 0x00115929
		public void RefreshItem(bool isResetAnchoredPosition = true)
		{
			this.Init(isResetAnchoredPosition);
		}

		// Token: 0x0400098F RID: 2447
		[SerializeField]
		protected RectTransform m_ItemBase;

		// Token: 0x04000990 RID: 2448
		[SerializeField]
		[Range(0f, 30f)]
		private int m_instantateItemCount = 9;

		// Token: 0x04000991 RID: 2449
		public InfiniteScroll.Direction direction;

		// Token: 0x04000992 RID: 2450
		public float itemUpdateOffsetPosition;

		// Token: 0x04000993 RID: 2451
		public InfiniteScroll.OnItemPositionChange onUpdateItem = new InfiniteScroll.OnItemPositionChange();

		// Token: 0x04000994 RID: 2452
		[NonSerialized]
		public List<RectTransform> m_itemList = new List<RectTransform>();

		// Token: 0x04000995 RID: 2453
		protected float m_diffPreFramePosition;

		// Token: 0x04000996 RID: 2454
		protected int m_currentItemNo;

		// Token: 0x04000997 RID: 2455
		private RectTransform m_rectTransform;

		// Token: 0x04000998 RID: 2456
		private float m_itemScale = -1f;

		// Token: 0x04000999 RID: 2457
		private Vector2 defaultAnchoredPosition;

		// Token: 0x0200020B RID: 523
		public enum Direction
		{
			// Token: 0x0400140D RID: 5133
			Vertical,
			// Token: 0x0400140E RID: 5134
			Horizontal
		}

		// Token: 0x0200020C RID: 524
		[Serializable]
		public class OnItemPositionChange : UnityEvent<int, GameObject>
		{
		}
	}
}
