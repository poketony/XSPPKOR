using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000010 RID: 16
public class DebugView : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x0000A732 File Offset: 0x00008932
	private void Start()
	{
		this.Init();
	}

	// Token: 0x06000058 RID: 88 RVA: 0x0000A73A File Offset: 0x0000893A
	private void Init()
	{
		this.SetTimeScaleText();
	}

	// Token: 0x06000059 RID: 89 RVA: 0x0000A742 File Offset: 0x00008942
	public void OnClose()
	{
		SingletonBehaviour<AppliArchivePrefabManager>.Instance.ClearPopup("DebugMenu");
	}

	// Token: 0x0600005A RID: 90 RVA: 0x0000A753 File Offset: 0x00008953
	public void OnTimeScalePlus()
	{
		this.ChangeScalePlus(true);
	}

	// Token: 0x0600005B RID: 91 RVA: 0x0000A75C File Offset: 0x0000895C
	public void OnTimeScaleMinus()
	{
		this.ChangeScalePlus(false);
	}

	// Token: 0x0600005C RID: 92 RVA: 0x0000A768 File Offset: 0x00008968
	private void ChangeScalePlus(bool isPlus)
	{
		float num = SingletonData<CommonData>.Instance.timeScale;
		if (isPlus)
		{
			if (num >= 5f)
			{
				return;
			}
			if (num >= 1f)
			{
				num += 1f;
			}
			else
			{
				num += 0.1f;
			}
		}
		else
		{
			if (num <= 0.1f)
			{
				return;
			}
			if (num > 1f)
			{
				num -= 1f;
			}
			else
			{
				num -= 0.1f;
			}
		}
		SingletonData<CommonData>.Instance.timeScale = num;
		this.SetTimeScaleText();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x0000A7DC File Offset: 0x000089DC
	private void SetTimeScaleText()
	{
		this.timeScaleText.text = SingletonData<CommonData>.Instance.timeScale.ToString("f1");
	}

	// Token: 0x0400006A RID: 106
	[SerializeField]
	private Text timeScaleText;
}
