using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x020000AB RID: 171
	public class ScrollSnap : ScrollRect
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600104E RID: 4174 RVA: 0x00117EC7 File Offset: 0x001160C7
		private float hPerIndex
		{
			get
			{
				if (!base.horizontal || base.content == null || base.content.childCount <= 1)
				{
					return 1f;
				}
				return 1f / (float)(this.horizontalPages - 1);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600104F RID: 4175 RVA: 0x00117F02 File Offset: 0x00116102
		private float vPerIndex
		{
			get
			{
				if (!base.vertical || base.content == null || base.content.childCount <= 1)
				{
					return 1f;
				}
				return 1f / (float)(this.verticalPages - 1);
			}
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x00117F40 File Offset: 0x00116140
		private void Awake()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (base.horizontalScrollbar != null)
			{
				this.AddScrollbarEvent(base.horizontalScrollbar.gameObject);
			}
			if (base.verticalScrollbar != null)
			{
				this.AddScrollbarEvent(base.verticalScrollbar.gameObject);
			}
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00117F93 File Offset: 0x00116193
		private void Start()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			this.targetPosition = this.GetSnapPosition();
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x00117FAC File Offset: 0x001161AC
		private void Update()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (!this.dragging && base.normalizedPosition != this.targetPosition)
			{
				float num = (this.ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
				base.normalizedPosition = Vector2.Lerp(base.normalizedPosition, this.targetPosition, this.smooth * num);
				if (Vector2.Distance(base.normalizedPosition, this.targetPosition) < 0.009f)
				{
					base.normalizedPosition = this.targetPosition;
				}
			}
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x00118034 File Offset: 0x00116234
		public override void OnBeginDrag(PointerEventData eventData)
		{
			base.OnBeginDrag(eventData);
			this.dragging = true;
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x00118044 File Offset: 0x00116244
		public override void OnEndDrag(PointerEventData eventData)
		{
			base.OnEndDrag(eventData);
			this.UpdateIndex();
			this.targetPosition = this.GetSnapPosition();
			this.dragging = false;
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x00118066 File Offset: 0x00116266
		public void OnScrollbarPointerDown(BaseEventData eventData)
		{
			this.OnBeginDrag((PointerEventData)eventData);
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x00118074 File Offset: 0x00116274
		public void OnScrollbarPointerUp(BaseEventData eventData)
		{
			this.OnEndDrag((PointerEventData)eventData);
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x00118084 File Offset: 0x00116284
		private void UpdateIndex()
		{
			Vector2 pageToFloat = this.GetPageToFloat();
			if (base.horizontal && this.horizontalPages > 0)
			{
				int num = Mathf.RoundToInt(pageToFloat.x);
				this.hIndex = num;
			}
			if (base.vertical && this.verticalPages > 0)
			{
				int num2 = Mathf.RoundToInt(pageToFloat.y);
				this.vIndex = num2;
			}
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x001180E4 File Offset: 0x001162E4
		private Vector2 GetSnapPosition()
		{
			return new Vector2((base.horizontal && this.horizontalPages > 0) ? ((float)this.hIndex * this.hPerIndex) : base.normalizedPosition.x, (base.vertical && this.verticalPages > 0) ? ((float)this.vIndex * this.vPerIndex) : base.normalizedPosition.y);
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x00118150 File Offset: 0x00116350
		public Vector2 GetPageToFloat()
		{
			float num = -1f;
			float num2 = -1f;
			if (base.horizontal && this.horizontalPages > 0)
			{
				num = base.normalizedPosition.x / this.hPerIndex;
				num = Mathf.Clamp(num, 0f, (float)(this.horizontalPages - 1));
			}
			if (base.vertical && this.verticalPages > 0)
			{
				num2 = base.normalizedPosition.y / this.vPerIndex;
				num2 = Mathf.Clamp(num2, 0f, (float)(this.verticalPages - 1));
			}
			return new Vector2(num, num2);
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x001181E2 File Offset: 0x001163E2
		public void NonSmoothSetPosition(int hIndex = -2147483648, int vIndex = -2147483648)
		{
			if (hIndex != -2147483648)
			{
				this.hIndex = hIndex;
			}
			if (vIndex != -2147483648)
			{
				this.vIndex = vIndex;
			}
			this.targetPosition = this.GetSnapPosition();
			base.normalizedPosition = this.targetPosition;
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0011821A File Offset: 0x0011641A
		public void SmoothSetPosition(int hIndex = -2147483648, int vIndex = -2147483648)
		{
			if (hIndex != -2147483648)
			{
				this.hIndex = hIndex;
			}
			if (vIndex != -2147483648)
			{
				this.vIndex = vIndex;
			}
			this.targetPosition = this.GetSnapPosition();
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00118248 File Offset: 0x00116448
		private void AddScrollbarEvent(GameObject scrollbarObj)
		{
			EventTrigger eventTrigger = scrollbarObj.AddComponent<EventTrigger>();
			this.AddEventTriggerListener(eventTrigger, 2, new Action<BaseEventData>(this.OnScrollbarPointerDown));
			this.AddEventTriggerListener(eventTrigger, 3, new Action<BaseEventData>(this.OnScrollbarPointerUp));
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x00118284 File Offset: 0x00116484
		private void AddEventTriggerListener(EventTrigger trigger, EventTriggerType eventType, Action<BaseEventData> callback)
		{
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = eventType;
			entry.callback = new EventTrigger.TriggerEvent();
			entry.callback.AddListener(new UnityAction<BaseEventData>(callback.Invoke));
			trigger.triggers.Add(entry);
		}

		// Token: 0x040009A9 RID: 2473
		[Header("ページ数")]
		public int horizontalPages = 3;

		// Token: 0x040009AA RID: 2474
		public int verticalPages = 3;

		// Token: 0x040009AB RID: 2475
		[Header("Smoothing")]
		public float smooth = 10f;

		// Token: 0x040009AC RID: 2476
		public bool ignoreTimeScale = true;

		// Token: 0x040009AD RID: 2477
		[Header("Debug")]
		public int hIndex;

		// Token: 0x040009AE RID: 2478
		public int vIndex;

		// Token: 0x040009AF RID: 2479
		private Vector2 targetPosition;

		// Token: 0x040009B0 RID: 2480
		private bool dragging;
	}
}
