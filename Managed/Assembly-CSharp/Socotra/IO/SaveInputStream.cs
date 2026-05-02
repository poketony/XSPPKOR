using System;
using System.IO;

namespace Socotra.IO
{
	// Token: 0x0200012E RID: 302
	public class SaveInputStream : InputStream
	{
		// Token: 0x06001677 RID: 5751 RVA: 0x0012D5D0 File Offset: 0x0012B7D0
		public SaveInputStream(string fileName, int size)
		{
			string text = "./save";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			this.filePath = Path.Combine(text, fileName);
			if (!File.Exists(this.filePath))
			{
				if (!Directory.Exists(Path.GetDirectoryName(this.filePath)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(this.filePath));
				}
				this.fileStream = File.Create(this.filePath);
				this.fileStream.Write(new byte[size], 0, size);
				this.fileStream.Flush();
				this.fileStream.Close();
			}
			this.fileStream = File.OpenRead(this.filePath);
			this.reader = new BinaryReader(this.fileStream);
			this.length = this.fileStream.Length;
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0012D6A2 File Offset: 0x0012B8A2
		public override int Available()
		{
			return (int)(this.reader.BaseStream.Length - this.reader.BaseStream.Position);
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x0012D6C6 File Offset: 0x0012B8C6
		public override void Close()
		{
			this.reader.Close();
			this.fileStream.Close();
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x0012D6DE File Offset: 0x0012B8DE
		public override int Read()
		{
			return (int)this.reader.ReadByte();
		}

		// Token: 0x0600167B RID: 5755 RVA: 0x0012D6EB File Offset: 0x0012B8EB
		public override int Read(sbyte[] data)
		{
			return this.reader.Read(InputStream.ToBytesSpan(data.AsSpan<sbyte>()));
		}

		// Token: 0x0600167C RID: 5756 RVA: 0x0012D704 File Offset: 0x0012B904
		public override int Read(sbyte[] data, int offset, int length)
		{
			return this.reader.Read(InputStream.ToBytesSpan(data.AsSpan<sbyte>()).Slice(offset, length));
		}

		// Token: 0x0600167D RID: 5757 RVA: 0x0012D731 File Offset: 0x0012B931
		public int Read(byte[] data, int offset, int length)
		{
			return this.reader.Read(data, offset, length);
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0012D741 File Offset: 0x0012B941
		public override sbyte ReadByte()
		{
			return this.reader.ReadSByte();
		}

		// Token: 0x0600167F RID: 5759 RVA: 0x0012D74E File Offset: 0x0012B94E
		public override long Skip(long length)
		{
			return this.reader.BaseStream.Seek(length, SeekOrigin.Current);
		}

		// Token: 0x04000CD2 RID: 3282
		private string filePath;

		// Token: 0x04000CD3 RID: 3283
		private FileStream fileStream;

		// Token: 0x04000CD4 RID: 3284
		private BinaryReader reader;

		// Token: 0x04000CD5 RID: 3285
		private long length;
	}
}
