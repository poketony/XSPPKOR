using System;
using Steezy.PageFlow;
using Steezy.Sound;
using Steezy.Utility;
using UnityEngine;

// Token: 0x02000026 RID: 38
public class WindowButtonsEvent : SimpleBaseButton
{
	// Token: 0x060000B5 RID: 181 RVA: 0x0000BB6C File Offset: 0x00009D6C
	public void OnClick(int index)
	{
		if (base.CheckTransition(true, 0.4f))
		{
			SoundManager.Instance.PlaySE("se_decision", false);
			base.GetComponent<Animator>().Play("Pressed");
			SingletonBehaviour<WindowDialog>.Instance.Change(index);
			SingletonBehaviour<WindowDialog>.Instance.SaveWindow();
		}
	}
}
