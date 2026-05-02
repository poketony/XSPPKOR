using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x0200005A RID: 90
[RequireComponent(typeof(EventTrigger))]
[AddComponentMenu("UI/Plus/PressGapEvent")]
public class PressGapEvent : MonoBehaviour
{
	// Token: 0x06000DF7 RID: 3575 RVA: 0x0010DBD8 File Offset: 0x0010BDD8
	private void Awake()
	{
		EventTrigger component = base.GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = 2;
		entry.callback.AddListener(new UnityAction<BaseEventData>(this.OnPress));
		component.triggers.Add(entry);
		EventTrigger.Entry entry2 = new EventTrigger.Entry();
		entry2.eventID = 3;
		entry2.callback.AddListener(new UnityAction<BaseEventData>(this.OnRelease));
		component.triggers.Add(entry2);
		this.available = true;
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x0010DC51 File Offset: 0x0010BE51
	private void OnDisable()
	{
		this.m_pressed = false;
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x0010DC5C File Offset: 0x0010BE5C
	private void Update()
	{
		if (!this.available)
		{
			return;
		}
		if (!this.m_pressed)
		{
			return;
		}
		if (Time.realtimeSinceStartup - this.m_lastTime < this.gap)
		{
			return;
		}
		this.m_lastTime = Time.realtimeSinceStartup;
		if (this.pressAction != null)
		{
			this.pressAction.Invoke();
		}
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x0010DCAE File Offset: 0x0010BEAE
	private void OnPress(BaseEventData data)
	{
		this.m_pressed = true;
		if (this.startDelay)
		{
			this.m_lastTime = Time.realtimeSinceStartup;
			return;
		}
		this.m_lastTime = -999f;
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x0010DCD6 File Offset: 0x0010BED6
	private void OnRelease(BaseEventData data)
	{
		this.m_pressed = false;
		if (this.available && this.releaseAction != null)
		{
			this.releaseAction.Invoke();
			return;
		}
		this.available = true;
	}

	// Token: 0x0400083F RID: 2111
	public UnityAction pressAction;

	// Token: 0x04000840 RID: 2112
	public UnityAction releaseAction;

	// Token: 0x04000841 RID: 2113
	public bool available;

	// Token: 0x04000842 RID: 2114
	public float gap = 0.5f;

	// Token: 0x04000843 RID: 2115
	public bool startDelay = true;

	// Token: 0x04000844 RID: 2116
	private float m_lastTime = -999f;

	// Token: 0x04000845 RID: 2117
	private bool m_pressed;
}
