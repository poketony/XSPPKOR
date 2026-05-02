using System;
using Steezy.Utility;
using UnityEngine;

// Token: 0x02000051 RID: 81
public class StVibrationManager : SingletonBehaviour<StVibrationManager>
{
	// Token: 0x06000DD0 RID: 3536 RVA: 0x0010D454 File Offset: 0x0010B654
	private void Start()
	{
	}

	// Token: 0x06000DD1 RID: 3537 RVA: 0x0010D456 File Offset: 0x0010B656
	private void Update()
	{
	}

	// Token: 0x06000DD2 RID: 3538 RVA: 0x0010D458 File Offset: 0x0010B658
	public void StartVibration(StVibrationManager.Type t, int option = -1)
	{
		this.currentType = t;
		if (option >= 0 && option < this.vibrationOptionData.Length)
		{
			this.currentVibrationData = option;
			this.vibrationPos = 0;
		}
	}

	// Token: 0x06000DD3 RID: 3539 RVA: 0x0010D47E File Offset: 0x0010B67E
	public void StopVibration()
	{
		this.currentType = StVibrationManager.Type.None;
		SingletonBehaviour<StPadManager>.Instance.SetVibration(0f, 0f);
	}

	// Token: 0x04000821 RID: 2081
	private StVibrationManager.Type currentType;

	// Token: 0x04000822 RID: 2082
	private int currentVibrationData = -1;

	// Token: 0x04000823 RID: 2083
	private int vibrationPos;

	// Token: 0x04000824 RID: 2084
	[SerializeField]
	private TextAsset[] vibrationOptionData;

	// Token: 0x020001D9 RID: 473
	public enum Type
	{
		// Token: 0x04001347 RID: 4935
		None,
		// Token: 0x04001348 RID: 4936
		Low,
		// Token: 0x04001349 RID: 4937
		High,
		// Token: 0x0400134A RID: 4938
		Data
	}
}
