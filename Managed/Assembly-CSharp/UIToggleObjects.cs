using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000061 RID: 97
[RequireComponent(typeof(Toggle))]
public class UIToggleObjects : MonoBehaviour
{
	// Token: 0x06000E31 RID: 3633 RVA: 0x0010EA00 File Offset: 0x0010CC00
	private void Start()
	{
		this.toggle = base.GetComponent<Toggle>();
		if (this.toggle != null)
		{
			this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.DoToggle));
			this.DoToggle(this.toggle.isOn);
			return;
		}
		Debug.LogError("找不到 Toggle.");
	}

	// Token: 0x06000E32 RID: 3634 RVA: 0x0010EA5F File Offset: 0x0010CC5F
	public void DoToggle()
	{
		this.DoToggle(this.toggle.isOn);
	}

	// Token: 0x06000E33 RID: 3635 RVA: 0x0010EA74 File Offset: 0x0010CC74
	public void DoToggle(bool state)
	{
		for (int i = 0; i < this.active.Count; i++)
		{
			this.Set(this.active[i], state);
		}
		for (int j = 0; j < this.deactive.Count; j++)
		{
			this.Set(this.deactive[j], !state);
		}
	}

	// Token: 0x06000E34 RID: 3636 RVA: 0x0010EAD6 File Offset: 0x0010CCD6
	private void Set(GameObject go, bool state)
	{
		if (go != null)
		{
			go.SetActive(state);
		}
	}

	// Token: 0x04000868 RID: 2152
	public List<GameObject> active = new List<GameObject>();

	// Token: 0x04000869 RID: 2153
	public List<GameObject> deactive = new List<GameObject>();

	// Token: 0x0400086A RID: 2154
	private Toggle toggle;
}
