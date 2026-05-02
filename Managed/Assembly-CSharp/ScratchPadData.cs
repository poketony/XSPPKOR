using System;
using Socotra.IO;
using UnityEngine;

// Token: 0x02000043 RID: 67
public abstract class ScratchPadData : MonoBehaviour
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000D4E RID: 3406 RVA: 0x0010AE99 File Offset: 0x00109099
	// (set) Token: 0x06000D4F RID: 3407 RVA: 0x0010AEA1 File Offset: 0x001090A1
	public int Offset
	{
		get
		{
			return this.offset;
		}
		set
		{
			this.offset = value;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000D50 RID: 3408 RVA: 0x0010AEAA File Offset: 0x001090AA
	// (set) Token: 0x06000D51 RID: 3409 RVA: 0x0010AEB2 File Offset: 0x001090B2
	public virtual int Length
	{
		get
		{
			return this.length;
		}
		set
		{
			this.length = value;
		}
	}

	// Token: 0x06000D52 RID: 3410
	public abstract InputStream GetInputStream();

	// Token: 0x06000D53 RID: 3411
	public abstract DataInputStream GetDataInputStream();

	// Token: 0x06000D54 RID: 3412
	public abstract OutputStream GetOutputStream();

	// Token: 0x06000D55 RID: 3413
	public abstract DataOutputStream GetDataOutputStream();

	// Token: 0x040007FF RID: 2047
	protected int offset;

	// Token: 0x04000800 RID: 2048
	protected int length;
}
