using System;
using System.IO;

namespace Socotra.IO
{
	// Token: 0x02000125 RID: 293
	public class FileByteOutputStream : OutputStream
	{
		// Token: 0x0600162C RID: 5676 RVA: 0x0012CFC8 File Offset: 0x0012B1C8
		public FileByteOutputStream(string filepath)
		{
			this.fileStream = File.OpenWrite(filepath);
			this.binaryWriter = new BinaryWriter(this.fileStream);
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x0012CFED File Offset: 0x0012B1ED
		public override void Close()
		{
			this.binaryWriter.Close();
			this.fileStream.Close();
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x0012D005 File Offset: 0x0012B205
		public override void Flush()
		{
			this.binaryWriter.Flush();
			this.fileStream.Flush(true);
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x0012D01E File Offset: 0x0012B21E
		public override void Write(int i)
		{
			this.binaryWriter.Write((byte)i);
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x0012D030 File Offset: 0x0012B230
		public override void Write(sbyte[] b, int off, int len)
		{
			byte[] byteArray = base.GetByteArray(b);
			this.binaryWriter.Write(byteArray, off, len);
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x0012D053 File Offset: 0x0012B253
		public override void WriteByte(sbyte b)
		{
			this.binaryWriter.Write(b);
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x0012D061 File Offset: 0x0012B261
		public override void WriteShort(short s)
		{
			this.binaryWriter.Write(s);
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x0012D06F File Offset: 0x0012B26F
		public void Skip(int length)
		{
			this.binaryWriter.Seek(length, SeekOrigin.Current);
		}

		// Token: 0x04000C9F RID: 3231
		private FileStream fileStream;

		// Token: 0x04000CA0 RID: 3232
		private BinaryWriter binaryWriter;
	}
}
