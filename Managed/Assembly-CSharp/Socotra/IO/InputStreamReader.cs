using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Socotra.IO
{
	// Token: 0x0200012A RID: 298
	public class InputStreamReader
	{
		// Token: 0x06001658 RID: 5720 RVA: 0x0012D376 File Offset: 0x0012B576
		public InputStreamReader(InputStream s)
		{
			this.ConvertStreamReader(s, InputStreamReader.DefaultEncoding);
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x0012D38C File Offset: 0x0012B58C
		public InputStreamReader(InputStream s, string e)
		{
			Encoding encoding = SocotraRuntime.GetEncoding(e);
			this.ConvertStreamReader(s, encoding);
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x0012D3AE File Offset: 0x0012B5AE
		public InputStreamReader(InputStream s, Encoding e)
		{
			this.ConvertStreamReader(s, e);
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x0012D3C0 File Offset: 0x0012B5C0
		private void ConvertStreamReader(InputStream s, Encoding encodeing)
		{
			sbyte[] array = new sbyte[s.Available()];
			s.Read(ref array);
			byte[] byteArray = this.GetByteArray(array);
			this.memoryStream = new MemoryStream(byteArray);
			this.streamReader = new StreamReader(this.memoryStream, encodeing);
		}

		// Token: 0x0600165C RID: 5724 RVA: 0x0012D408 File Offset: 0x0012B608
		public int Read()
		{
			return this.streamReader.Read();
		}

		// Token: 0x0600165D RID: 5725 RVA: 0x0012D415 File Offset: 0x0012B615
		public int Read(ref char[] data, int offset, int length)
		{
			return this.streamReader.Read(data, offset, length);
		}

		// Token: 0x0600165E RID: 5726 RVA: 0x0012D426 File Offset: 0x0012B626
		public void Close()
		{
			if (this.streamReader != null)
			{
				this.streamReader.Close();
			}
			if (this.memoryStream != null)
			{
				this.memoryStream.Close();
			}
		}

		// Token: 0x0600165F RID: 5727 RVA: 0x0012D44E File Offset: 0x0012B64E
		private byte[] GetByteArray(sbyte[] original)
		{
			new byte[original.Length];
			return original.Select((sbyte x) => (byte)x).ToArray<byte>();
		}

		// Token: 0x04000CCD RID: 3277
		private static readonly Encoding DefaultEncoding = Encoding.GetEncoding(932);

		// Token: 0x04000CCE RID: 3278
		private MemoryStream memoryStream;

		// Token: 0x04000CCF RID: 3279
		private StreamReader streamReader;
	}
}
