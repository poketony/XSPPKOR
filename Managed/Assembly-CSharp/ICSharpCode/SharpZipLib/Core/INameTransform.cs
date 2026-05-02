using System;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x02000194 RID: 404
	public interface INameTransform
	{
		// Token: 0x06001AD0 RID: 6864
		string TransformFile(string name);

		// Token: 0x06001AD1 RID: 6865
		string TransformDirectory(string name);
	}
}
