using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200005C RID: 92
public class UIActiveObjects : MonoBehaviour
{
	// Token: 0x06000E00 RID: 3584 RVA: 0x0010DDB4 File Offset: 0x0010BFB4
	private void Start()
	{
		this.mButton = base.GetComponent<Button>();
		if (this.mButton != null)
		{
			this.mButton.onClick.AddListener(new UnityAction(this.OnClick));
			return;
		}
		Debug.LogError("找不到 Button.");
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x0010DE02 File Offset: 0x0010C002
	public void OnClick()
	{
		this.OnClick(true);
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x0010DE0C File Offset: 0x0010C00C
	public void OnClick(bool state)
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

	// Token: 0x06000E03 RID: 3587 RVA: 0x0010DE6E File Offset: 0x0010C06E
	private void Set(GameObject go, bool state)
	{
		if (go != null)
		{
			go.SetActive(state);
		}
	}

	// Token: 0x04000848 RID: 2120
	public List<GameObject> active = new List<GameObject>();

	// Token: 0x04000849 RID: 2121
	public List<GameObject> deactive = new List<GameObject>();

	// Token: 0x0400084A RID: 2122
	private Button mButton;
}
