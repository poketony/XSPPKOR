using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200014A RID: 330
	internal interface ITaggedDataFactory
	{
		// Token: 0x06001774 RID: 6004
		ITaggedData Create(short tag, byte[] data, int offset, int count);
	}
}
