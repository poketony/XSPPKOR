using System;
using Serialize;

// Token: 0x02000045 RID: 69
[Serializable]
public class ScratchPadPair : KeyAndValue<int, ScratchPadData>
{
	// Token: 0x06000D58 RID: 3416 RVA: 0x0010AECB File Offset: 0x001090CB
	public ScratchPadPair(int key, ScratchPadData value)
		: base(key, value)
	{
	}
}
