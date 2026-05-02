using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.BZip2
{
	// Token: 0x020001A1 RID: 417
	public static class BZip2
	{
		// Token: 0x06001B18 RID: 6936 RVA: 0x0013F810 File Offset: 0x0013DA10
		public static void Decompress(Stream inStream, Stream outStream, bool isStreamOwner)
		{
			if (inStream == null || outStream == null)
			{
				throw new Exception("Null Stream");
			}
			try
			{
				using (BZip2InputStream bzip2InputStream = new BZip2InputStream(inStream))
				{
					bzip2InputStream.IsStreamOwner = isStreamOwner;
					StreamUtils.Copy(bzip2InputStream, outStream, new byte[4096]);
				}
			}
			finally
			{
				if (isStreamOwner)
				{
					outStream.Dispose();
				}
			}
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x0013F880 File Offset: 0x0013DA80
		public static void Compress(Stream inStream, Stream outStream, bool isStreamOwner, int level)
		{
			if (inStream == null || outStream == null)
			{
				throw new Exception("Null Stream");
			}
			try
			{
				using (BZip2OutputStream bzip2OutputStream = new BZip2OutputStream(outStream, level))
				{
					bzip2OutputStream.IsStreamOwner = isStreamOwner;
					StreamUtils.Copy(inStream, bzip2OutputStream, new byte[4096]);
				}
			}
			finally
			{
				if (isStreamOwner)
				{
					inStream.Dispose();
				}
			}
		}
	}
}
