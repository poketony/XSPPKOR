using System;
using System.IO;

namespace Socotra.IO
{
	// Token: 0x02000124 RID: 292
	public class FileByteInputStream : InputStream
	{
		// Token: 0x06001624 RID: 5668 RVA: 0x0012CEEB File Offset: 0x0012B0EB
		public FileByteInputStream(string path)
		{
			this.fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
			this.binaryReader = new BinaryReader(this.fileStream);
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x0012CF12 File Offset: 0x0012B112
		public override int Available()
		{
			return (int)(this.binaryReader.BaseStream.Length - this.binaryReader.BaseStream.Position);
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x0012CF36 File Offset: 0x0012B136
		public override void Close()
		{
			base.Close();
			this.binaryReader.Close();
			this.fileStream.Close();
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x0012CF54 File Offset: 0x0012B154
		public override int Read()
		{
			return (int)this.binaryReader.ReadByte();
		}

		// Token: 0x06001628 RID: 5672 RVA: 0x0012CF61 File Offset: 0x0012B161
		public override int Read(sbyte[] data)
		{
			return this.binaryReader.Read(InputStream.ToBytesSpan(data.AsSpan<sbyte>()));
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x0012CF7C File Offset: 0x0012B17C
		public override int Read(sbyte[] data, int offset, int length)
		{
			return this.binaryReader.Read(InputStream.ToBytesSpan(data.AsSpan<sbyte>()).Slice(offset, length));
		}

		// Token: 0x0600162A RID: 5674 RVA: 0x0012CFA9 File Offset: 0x0012B1A9
		public override sbyte ReadByte()
		{
			return (sbyte)this.binaryReader.ReadByte();
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x0012CFB7 File Offset: 0x0012B1B7
		public override long Skip(long length)
		{
			this.binaryReader.ReadBytes((int)length);
			return length;
		}

		// Token: 0x04000C9D RID: 3229
		private FileStream fileStream;

		// Token: 0x04000C9E RID: 3230
		private BinaryReader binaryReader;
	}
}
