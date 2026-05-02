using System;

namespace ICSharpCode.SharpZipLib.Checksum
{
	// Token: 0x020001A0 RID: 416
	public interface IChecksum
	{
		// Token: 0x06001B13 RID: 6931
		void Reset();

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06001B14 RID: 6932
		long Value { get; }

		// Token: 0x06001B15 RID: 6933
		void Update(int bval);

		// Token: 0x06001B16 RID: 6934
		void Update(byte[] buffer);

		// Token: 0x06001B17 RID: 6935
		void Update(ArraySegment<byte> segment);
	}
}
