using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200002B RID: 43
public class ButtonSelect : MonoBehaviour
{
	// Token: 0x060000CB RID: 203 RVA: 0x0000C0EE File Offset: 0x0000A2EE
	private void Start()
	{
		base.GetComponent<Selectable>().Select();
	}
}
