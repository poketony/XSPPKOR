using System;
using System.Collections.Generic;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.PageFlow
{
	// Token: 0x020000CC RID: 204
	public class SimpleBaseButton : MonoBehaviour
	{
		// Token: 0x06001239 RID: 4665 RVA: 0x0011D468 File Offset: 0x0011B668
		private void Awake()
		{
			Button component = base.GetComponent<Button>();
			if (component != null)
			{
				component.interactable = this.isButtonInteractable;
				this.SetInteractable(base.gameObject, this.isButtonInteractable);
			}
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x0011D4A3 File Offset: 0x0011B6A3
		public bool CheckTransition(bool isSetTransitionExecute = true, float transitionStateReleaceTime = 0f)
		{
			if (SimpleBaseButton.IsPageFlowExecute)
			{
				return false;
			}
			if (isSetTransitionExecute)
			{
				SimpleBaseButton.IsPageFlowExecute = true;
				this.TransitionReleace(transitionStateReleaceTime);
			}
			return true;
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x0011D4BF File Offset: 0x0011B6BF
		public bool CheckTransitionWait()
		{
			if (SimpleBaseButton.IsPageFlowExecute)
			{
				return false;
			}
			SimpleBaseButton.IsPageFlowExecute = true;
			return true;
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x0011D4D4 File Offset: 0x0011B6D4
		public bool CheckTransitionAndExecute(Action action, bool isSetTransitionExecute = true, float transitionStateReleaceTime = 0f)
		{
			if (SimpleBaseButton.IsPageFlowExecute)
			{
				return false;
			}
			if (isSetTransitionExecute)
			{
				SimpleBaseButton.IsPageFlowExecute = true;
				this.TransitionReleace(transitionStateReleaceTime);
			}
			SwitchInputSelectable[] array = SingletonBehaviour<AppliArchivePrefabManager>.Instance.ScreenParent.transform.GetComponentsInChildren<SwitchInputSelectable>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DisableSelectable(new string[] { base.gameObject.name });
			}
			array = SingletonBehaviour<AppliArchivePrefabManager>.Instance.PopupParent.transform.GetComponentsInChildren<SwitchInputSelectable>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DisableSelectable(new string[] { base.gameObject.name });
			}
			PageFlowCoroutineCommon.CallWaitForSecondsRealtime(transitionStateReleaceTime, action);
			return true;
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x0011D580 File Offset: 0x0011B780
		public void ReleaceTransitionWait()
		{
			this.TransitionReleace(0f);
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x0011D58D File Offset: 0x0011B78D
		public void SetInteractable(bool isInteractable)
		{
			this.SetInteractable(base.gameObject, isInteractable);
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x0011D59C File Offset: 0x0011B79C
		private void SetInteractable(GameObject gameObject, bool isInteractable)
		{
			this.isButtonInteractable = isInteractable;
			foreach (object obj in gameObject.transform)
			{
				Transform transform = (Transform)obj;
				for (int i = 0; i < transform.childCount; i++)
				{
					this.SetInteractable(transform.GetChild(i).gameObject, isInteractable);
				}
				this.SetInteractableObject(transform.gameObject, isInteractable);
			}
			this.SetInteractableObject(gameObject, isInteractable);
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x0011D630 File Offset: 0x0011B830
		private void SetInteractableObject(GameObject gameObject, bool isInteractable)
		{
			if (SimpleBaseButton.objColor == null)
			{
				SimpleBaseButton.objColor = new Dictionary<int, Color32>();
			}
			Image component = gameObject.GetComponent<Image>();
			if (component != null)
			{
				Color32 color = component.color;
				if (!SimpleBaseButton.objColor.TryGetValue(component.GetInstanceID(), out color))
				{
					SimpleBaseButton.objColor.Add(component.GetInstanceID(), color = component.color);
				}
				component.color = ((!isInteractable) ? this.GetHarfColor32(color) : color);
			}
			RawImage component2 = gameObject.GetComponent<RawImage>();
			if (component2 != null)
			{
				Color32 color2 = component2.color;
				if (!SimpleBaseButton.objColor.TryGetValue(component2.GetInstanceID(), out color2))
				{
					SimpleBaseButton.objColor.Add(component2.GetInstanceID(), color2 = component2.color);
				}
				component2.color = ((!isInteractable) ? this.GetHarfColor32(color2) : color2);
			}
			Text component3 = gameObject.GetComponent<Text>();
			if (component3 != null)
			{
				Color32 color3 = component3.color;
				if (!SimpleBaseButton.objColor.TryGetValue(component3.GetInstanceID(), out color3))
				{
					SimpleBaseButton.objColor.Add(component3.GetInstanceID(), color3 = component3.color);
				}
				component3.color = ((!isInteractable) ? this.GetHarfColor32(color3) : color3);
			}
			Button component4 = gameObject.GetComponent<Button>();
			if (component4 != null)
			{
				component4.interactable = isInteractable;
			}
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x0011D7A0 File Offset: 0x0011B9A0
		private Color32 GetHarfColor32(Color32 color)
		{
			Color32 color2 = default(Color32);
			color2.a = color.a;
			color2.r = (byte)((float)color.r / this.transparent);
			color2.g = (byte)((float)color.g / this.transparent);
			color2.b = (byte)((float)color.b / this.transparent);
			return color2;
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x0011D805 File Offset: 0x0011BA05
		public void TransitionReleace(float transitionStateReleaceTime)
		{
			PageFlowCoroutineCommon.CallWaitForSecondsRealtime(transitionStateReleaceTime, delegate
			{
				SimpleBaseButton.IsPageFlowExecute = false;
			});
		}

		// Token: 0x04000A2E RID: 2606
		public const float TransitionStateReleaceTime = 0f;

		// Token: 0x04000A2F RID: 2607
		public bool isButtonInteractable = true;

		// Token: 0x04000A30 RID: 2608
		private float transparent = 2f;

		// Token: 0x04000A31 RID: 2609
		private static IDictionary<int, Color32> objColor;

		// Token: 0x04000A32 RID: 2610
		private static bool IsPageFlowExecute;
	}
}
