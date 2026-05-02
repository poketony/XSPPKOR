using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005E RID: 94
public class UILoop : MonoBehaviour
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000E0E RID: 3598 RVA: 0x0010DF67 File Offset: 0x0010C167
	private Vector2 CellRect
	{
		get
		{
			if (!(this.m_Cell != null))
			{
				return new Vector2(100f, 100f);
			}
			return this.m_Cell.sizeDelta + this.m_CellGap;
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0010DF9D File Offset: 0x0010C19D
	protected float CellScale
	{
		get
		{
			if (this.direction != UILoop.Direction.Horizontal)
			{
				return this.CellRect.y;
			}
			return this.CellRect.x;
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000E10 RID: 3600 RVA: 0x0010DFBE File Offset: 0x0010C1BE
	private float DirectionPos
	{
		get
		{
			if (this.direction != UILoop.Direction.Horizontal)
			{
				return this.m_Rect.anchoredPosition.y;
			}
			return this.m_Rect.anchoredPosition.x;
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000E11 RID: 3601 RVA: 0x0010DFEC File Offset: 0x0010C1EC
	private Vector2 InstantiateSize
	{
		get
		{
			if (this.m_InstantiateSize == Vector2.zero)
			{
				float num;
				float num2;
				if (this.direction == UILoop.Direction.Horizontal)
				{
					num = this.m_Page.x;
					num2 = this.m_Page.y + (float)this.m_BufferNo;
				}
				else
				{
					num = this.m_Page.x + (float)this.m_BufferNo;
					num2 = this.m_Page.y;
				}
				this.m_InstantiateSize = new Vector2(num, num2);
			}
			return this.m_InstantiateSize;
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000E12 RID: 3602 RVA: 0x0010E068 File Offset: 0x0010C268
	private int PageCount
	{
		get
		{
			return (int)this.m_Page.x * (int)this.m_Page.y;
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000E13 RID: 3603 RVA: 0x0010E083 File Offset: 0x0010C283
	private int PageScale
	{
		get
		{
			if (this.direction != UILoop.Direction.Horizontal)
			{
				return (int)this.m_Page.y;
			}
			return (int)this.m_Page.x;
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000E14 RID: 3604 RVA: 0x0010E0A6 File Offset: 0x0010C2A6
	private int InstantiateCount
	{
		get
		{
			return (int)this.InstantiateSize.x * (int)this.InstantiateSize.y;
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000E15 RID: 3605 RVA: 0x0010E0C1 File Offset: 0x0010C2C1
	protected float scale
	{
		get
		{
			if (this.direction != UILoop.Direction.Horizontal)
			{
				return -1f;
			}
			return 1f;
		}
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x0010E0D8 File Offset: 0x0010C2D8
	private void Awake()
	{
		this.m_ScrollRect = base.GetComponentInParent<ScrollRect>();
		this.m_ScrollRect.horizontal = this.direction == UILoop.Direction.Horizontal;
		this.m_ScrollRect.vertical = this.direction == UILoop.Direction.Vertical;
		this.m_Rect = base.GetComponent<RectTransform>();
		this.m_Rect.anchoredPosition = Vector2.zero;
		this.m_Cell.gameObject.SetActive(false);
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x0010E148 File Offset: 0x0010C348
	private void Start()
	{
		if (this.m_InstantiateItems.Count == 0)
		{
			for (int i = 0; i < this.InstantiateCount; i++)
			{
				this.CreateItem(i);
			}
		}
		this.HideAllItem();
		this.m_CurrentIndex = 0;
		this.m_PrevPos = 0f;
		this.m_InstantiateItems.Sort((RectTransform rect1, RectTransform rect2) => int.Parse(rect1.gameObject.name).CompareTo(int.Parse(rect2.gameObject.name)));
		if (this.m_ItemsCount > this.PageCount)
		{
			this.SetBound(this.GetRectByNum(this.m_ItemsCount));
		}
		else
		{
			this.SetBound(this.m_Page);
		}
		if (this.m_ItemsCount > this.InstantiateCount)
		{
			for (int j = 0; j < this.InstantiateCount; j++)
			{
				this.ShowItem(j);
				this.MoveItemToIndex(j, this.m_InstantiateItems[j]);
			}
			return;
		}
		for (int k = 0; k < this.m_ItemsCount; k++)
		{
			this.ShowItem(k);
			this.MoveItemToIndex(k, this.m_InstantiateItems[k]);
		}
	}

	// Token: 0x06000E18 RID: 3608 RVA: 0x0010E24F File Offset: 0x0010C44F
	private void ShowItem(int index)
	{
		this.m_InstantiateItems[index].gameObject.SetActive(true);
	}

	// Token: 0x06000E19 RID: 3609 RVA: 0x0010E268 File Offset: 0x0010C468
	private void HideItem(int index)
	{
		this.m_InstantiateItems[index].gameObject.SetActive(false);
	}

	// Token: 0x06000E1A RID: 3610 RVA: 0x0010E284 File Offset: 0x0010C484
	private void HideAllItem()
	{
		for (int i = 0; i < this.InstantiateCount; i++)
		{
			this.HideItem(i);
		}
	}

	// Token: 0x06000E1B RID: 3611 RVA: 0x0010E2AC File Offset: 0x0010C4AC
	private void CreateItem(int index)
	{
		RectTransform rectTransform = Object.Instantiate<RectTransform>(this.m_Cell);
		rectTransform.SetParent(base.transform, false);
		rectTransform.anchorMax = Vector2.up;
		rectTransform.anchorMin = Vector2.up;
		rectTransform.pivot = Vector2.up;
		rectTransform.name = index.ToString() ?? "";
		rectTransform.anchoredPosition = ((this.direction == UILoop.Direction.Horizontal) ? new Vector2(Mathf.Floor((float)index / this.InstantiateSize.x) * this.CellRect.x, -((float)index % this.InstantiateSize.x) * this.CellRect.y) : new Vector2((float)index % this.InstantiateSize.y * this.CellRect.x, -Mathf.Floor((float)index / this.InstantiateSize.y) * this.CellRect.y));
		this.m_InstantiateItems.Add(rectTransform);
		rectTransform.gameObject.SetActive(true);
		if (this.onCreate != null)
		{
			this.onCreate(index, rectTransform.gameObject);
		}
	}

	// Token: 0x06000E1C RID: 3612 RVA: 0x0010E3CC File Offset: 0x0010C5CC
	protected void RemoveItem(int index)
	{
		RectTransform rectTransform = this.m_InstantiateItems[index];
		this.m_InstantiateItems.Remove(rectTransform);
		Object.Destroy(rectTransform.gameObject);
		if (this.onRemove != null)
		{
			this.onRemove(index, rectTransform.gameObject);
		}
	}

	// Token: 0x06000E1D RID: 3613 RVA: 0x0010E418 File Offset: 0x0010C618
	protected void ClearAll()
	{
		if (this.m_Rect == null)
		{
			return;
		}
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			if (transform != this.m_Cell)
			{
				Object.Destroy(transform.gameObject);
			}
		}
		this.m_InstantiateItems = new List<RectTransform>();
		this.m_Rect.anchoredPosition = Vector2.zero;
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x0010E4B0 File Offset: 0x0010C6B0
	protected void Reset()
	{
		this.m_Rect.anchoredPosition = Vector2.zero;
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x0010E4C4 File Offset: 0x0010C6C4
	private Vector2 GetRectByNum(int num)
	{
		if (this.direction != UILoop.Direction.Horizontal)
		{
			return new Vector2((float)Mathf.CeilToInt((float)num / this.m_Page.y), this.m_Page.y);
		}
		return new Vector2(this.m_Page.x, (float)Mathf.CeilToInt((float)num / this.m_Page.x));
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x0010E522 File Offset: 0x0010C722
	private void SetBound(Vector2 bound)
	{
		this.m_Rect.sizeDelta = new Vector2(bound.y * this.CellRect.x, bound.x * this.CellRect.y);
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000E21 RID: 3617 RVA: 0x0010E558 File Offset: 0x0010C758
	protected float MaxPrevPos
	{
		get
		{
			Vector2 rectByNum = this.GetRectByNum(this.m_ItemsCount);
			float num;
			if (this.direction == UILoop.Direction.Horizontal)
			{
				num = rectByNum.y - this.m_Page.y;
			}
			else
			{
				num = rectByNum.x - this.m_Page.x;
			}
			return num * this.CellScale;
		}
	}

	// Token: 0x06000E22 RID: 3618 RVA: 0x0010E5AC File Offset: 0x0010C7AC
	private void Update()
	{
		if (this.m_ItemsCount == 0)
		{
			return;
		}
		while (this.scale * this.DirectionPos - this.m_PrevPos < -this.CellScale * 2f)
		{
			if (this.m_PrevPos <= -this.MaxPrevPos)
			{
				return;
			}
			this.m_PrevPos -= this.CellScale;
			List<RectTransform> range = this.m_InstantiateItems.GetRange(0, this.PageScale);
			this.m_InstantiateItems.RemoveRange(0, this.PageScale);
			this.m_InstantiateItems.AddRange(range);
			for (int i = 0; i < range.Count; i++)
			{
				this.MoveItemToIndex(this.m_CurrentIndex * this.PageScale + this.m_InstantiateItems.Count + i, range[i]);
			}
			this.m_CurrentIndex++;
		}
		while (this.scale * this.DirectionPos - this.m_PrevPos > -this.CellScale)
		{
			if (Mathf.RoundToInt(this.m_PrevPos) >= 0)
			{
				return;
			}
			this.m_PrevPos += this.CellScale;
			this.m_CurrentIndex--;
			if (this.m_CurrentIndex < 0)
			{
				return;
			}
			List<RectTransform> range2 = this.m_InstantiateItems.GetRange(this.m_InstantiateItems.Count - this.PageScale, this.PageScale);
			this.m_InstantiateItems.RemoveRange(this.m_InstantiateItems.Count - this.PageScale, this.PageScale);
			this.m_InstantiateItems.InsertRange(0, range2);
			for (int j = 0; j < range2.Count; j++)
			{
				this.MoveItemToIndex(this.m_CurrentIndex * this.PageScale + j, range2[j]);
			}
		}
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x0010E766 File Offset: 0x0010C966
	protected void MoveItemToIndex(int index, RectTransform item)
	{
		item.anchoredPosition = this.getPosByIndex(index);
		this.UpdateItem(index, item.gameObject);
	}

	// Token: 0x06000E24 RID: 3620 RVA: 0x0010E784 File Offset: 0x0010C984
	private Vector2 getPosByIndex(int index)
	{
		float num;
		float num2;
		if (this.direction == UILoop.Direction.Horizontal)
		{
			num = (float)index % this.m_Page.x;
			num2 = (float)Mathf.FloorToInt((float)index / this.m_Page.x);
		}
		else
		{
			num = (float)Mathf.FloorToInt((float)index / this.m_Page.y);
			num2 = (float)index % this.m_Page.y;
		}
		return new Vector2(num2 * this.CellRect.x, -num * this.CellRect.y);
	}

	// Token: 0x06000E25 RID: 3621 RVA: 0x0010E803 File Offset: 0x0010CA03
	private void UpdateItem(int index, GameObject item)
	{
		item.SetActive(index < this.m_ItemsCount);
		if (item.activeSelf && this.onUpdate != null)
		{
			this.onUpdate(index, item);
		}
	}

	// Token: 0x06000E26 RID: 3622 RVA: 0x0010E831 File Offset: 0x0010CA31
	protected int GetFirstItemCell()
	{
		return int.Parse(this.m_InstantiateItems[0].name);
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x0010E84C File Offset: 0x0010CA4C
	public int GetCellIndexByItemIndex(int index)
	{
		if (index < this.m_CurrentIndex * this.PageScale)
		{
			return -1;
		}
		if (index >= this.m_CurrentIndex * this.PageScale + this.InstantiateCount)
		{
			return -1;
		}
		return this.GetFirstItemCell() + index - this.m_CurrentIndex * this.PageScale;
	}

	// Token: 0x06000E28 RID: 3624 RVA: 0x0010E89C File Offset: 0x0010CA9C
	public int GetRealCellIndexByCurCellIndex(int curCell)
	{
		int firstItemCell = this.GetFirstItemCell();
		int num;
		if (curCell >= firstItemCell)
		{
			num = this.m_CurrentIndex * (int)this.m_Page.y + curCell - firstItemCell;
		}
		else
		{
			num = this.m_CurrentIndex * (int)this.m_Page.y + this.InstantiateCount - firstItemCell + curCell;
		}
		return num;
	}

	// Token: 0x04000852 RID: 2130
	[SerializeField]
	protected RectTransform m_Cell;

	// Token: 0x04000853 RID: 2131
	[SerializeField]
	protected Vector2 m_CellGap;

	// Token: 0x04000854 RID: 2132
	[SerializeField]
	protected Vector2 m_Page;

	// Token: 0x04000855 RID: 2133
	[SerializeField]
	private UILoop.Direction direction;

	// Token: 0x04000856 RID: 2134
	[SerializeField]
	[Range(0f, 10f)]
	private int m_BufferNo;

	// Token: 0x04000857 RID: 2135
	[SerializeField]
	private int m_ItemsCount;

	// Token: 0x04000858 RID: 2136
	private List<RectTransform> m_InstantiateItems = new List<RectTransform>();

	// Token: 0x04000859 RID: 2137
	private float m_PrevPos;

	// Token: 0x0400085A RID: 2138
	private int m_CurrentIndex;

	// Token: 0x0400085B RID: 2139
	public UILoop.UILoopCallBack onUpdate;

	// Token: 0x0400085C RID: 2140
	public UILoop.UILoopCallBack onCreate;

	// Token: 0x0400085D RID: 2141
	public UILoop.UILoopCallBack onRemove;

	// Token: 0x0400085E RID: 2142
	private Vector2 m_InstantiateSize = Vector2.zero;

	// Token: 0x0400085F RID: 2143
	private ScrollRect m_ScrollRect;

	// Token: 0x04000860 RID: 2144
	private RectTransform m_Rect;

	// Token: 0x020001E0 RID: 480
	// (Invoke) Token: 0x06001C68 RID: 7272
	public delegate void UILoopCallBack(int index, GameObject go);

	// Token: 0x020001E1 RID: 481
	private enum Direction
	{
		// Token: 0x04001359 RID: 4953
		Horizontal,
		// Token: 0x0400135A RID: 4954
		Vertical
	}
}
