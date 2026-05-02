using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000060 RID: 96
[RequireComponent(typeof(Toggle))]
public class UIToggleColor : MonoBehaviour
{
	// Token: 0x06000E2E RID: 3630 RVA: 0x0010E96C File Offset: 0x0010CB6C
	private void Start()
	{
		this.toggle = base.GetComponent<Toggle>();
		if (this.toggle != null)
		{
			this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggle));
			this.OnToggle(this.toggle.isOn);
			return;
		}
		Debug.LogError("找不到 Toggle.");
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x0010E9CB File Offset: 0x0010CBCB
	public void OnToggle(bool state)
	{
		if (this.target != null)
		{
			this.target.color = (state ? this.activeColor : this.deactiveColor);
		}
	}

	// Token: 0x04000864 RID: 2148
	public Graphic target;

	// Token: 0x04000865 RID: 2149
	public Color activeColor;

	// Token: 0x04000866 RID: 2150
	public Color deactiveColor;

	// Token: 0x04000867 RID: 2151
	private Toggle toggle;
}
