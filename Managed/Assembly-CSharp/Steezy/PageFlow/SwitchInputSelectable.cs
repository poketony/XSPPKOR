using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Steezy.PageFlow
{
	// Token: 0x020000CD RID: 205
	public class SwitchInputSelectable : MonoBehaviour
	{
		// Token: 0x06001244 RID: 4676 RVA: 0x0011D846 File Offset: 0x0011BA46
		private void Start()
		{
			this.ResetSelectable();
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x0011D850 File Offset: 0x0011BA50
		public void ResetSelectable()
		{
			Selectable[] componentsInChildren = base.GetComponentsInChildren<Selectable>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Selectable selectable = componentsInChildren[i];
				EventTrigger eventTrigger = selectable.gameObject.AddComponent<EventTrigger>();
				eventTrigger.triggers = new List<EventTrigger.Entry>();
				EventTrigger.Entry entry = new EventTrigger.Entry();
				entry.eventID = 8;
				entry.callback.AddListener(delegate(BaseEventData x)
				{
					this.nowSelectObj = selectable.gameObject;
				});
				eventTrigger.triggers.Add(entry);
			}
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x0011D8D4 File Offset: 0x0011BAD4
		public void DisableSelectable(params string[] excludeObjNames)
		{
			foreach (Selectable selectable in base.GetComponentsInChildren<Selectable>())
			{
				if (Array.IndexOf<string>(excludeObjNames, selectable.gameObject.name) < 0)
				{
					selectable.interactable = false;
				}
			}
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x0011D918 File Offset: 0x0011BB18
		public void SelectLastSelectable()
		{
			foreach (Selectable selectable in base.GetComponentsInChildren<Selectable>())
			{
				selectable.interactable = true;
				if (selectable.gameObject == this.nowSelectObj)
				{
					selectable.Select();
				}
			}
		}

		// Token: 0x04000A33 RID: 2611
		private GameObject nowSelectObj;
	}
}
