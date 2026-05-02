using System;
using Serialize;

// Token: 0x02000047 RID: 71
[Serializable]
public class ScratchPadJarPair : KeyAndValue<string, ScratchPadData>
{
	// Token: 0x06000D5A RID: 3418 RVA: 0x0010AEDD File Offset: 0x001090DD
	public ScratchPadJarPair(string name, ScratchPadData value)
		: base(name, value)
	{
	}
}
