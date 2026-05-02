using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000146 RID: 326
	public interface ITaggedData
	{
		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06001752 RID: 5970
		short TagID { get; }

		// Token: 0x06001753 RID: 5971
		void SetData(byte[] data, int offset, int count);

		// Token: 0x06001754 RID: 5972
		byte[] GetData();
	}
}
