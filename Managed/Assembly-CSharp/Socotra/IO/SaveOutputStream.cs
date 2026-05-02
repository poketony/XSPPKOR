using System;
using System.IO;
using UnityEngine;

namespace Socotra.IO
{
	// Token: 0x0200012F RID: 303
	public class SaveOutputStream : OutputStream
	{
		// Token: 0x06001680 RID: 5760 RVA: 0x0012D764 File Offset: 0x0012B964
		public SaveOutputStream(string fileName, int size)
		{
			string text = "./save";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, fileName);
			this.fileStream = File.OpenWrite(text2);
			this.binaryWriter = new BinaryWriter(this.fileStream);
			this.isWrite = false;
		}

		// Token: 0x06001681 RID: 5761 RVA: 0x0012D7B8 File Offset: 0x0012B9B8
		public override void Close()
		{
			this.Flush();
			this.binaryWriter.Close();
			this.fileStream.Close();
		}

		// Token: 0x06001682 RID: 5762 RVA: 0x0012D7D8 File Offset: 0x0012B9D8
		public override void Flush()
		{
			if (!this.isWrite)
			{
				return;
			}
			this.binaryWriter.Flush();
			this.fileStream.Flush(true);
			this.isWrite = false;
			Debug.Log("<color=yellow>" + base.GetType().FullName + ".Flush() :</color>" + this.fileStream.Name);
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x0012D836 File Offset: 0x0012BA36
		public override void Write(int i)
		{
			this.binaryWriter.Write((byte)i);
			this.isWrite = true;
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0012D84C File Offset: 0x0012BA4C
		public override void Write(sbyte[] b, int off, int len)
		{
			byte[] byteArray = base.GetByteArray(b);
			this.binaryWriter.Write(byteArray, off, len);
			this.isWrite = true;
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0012D876 File Offset: 0x0012BA76
		public void Write(byte[] b, int off, int len)
		{
			this.binaryWriter.Write(b, off, len);
			this.isWrite = true;
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x0012D88D File Offset: 0x0012BA8D
		public override void WriteByte(sbyte b)
		{
			this.binaryWriter.Write(b);
			this.isWrite = true;
		}

		// Token: 0x06001687 RID: 5767 RVA: 0x0012D8A2 File Offset: 0x0012BAA2
		public override void WriteShort(short s)
		{
			this.binaryWriter.Write(s);
			this.isWrite = true;
		}

		// Token: 0x06001688 RID: 5768 RVA: 0x0012D8B7 File Offset: 0x0012BAB7
		public override long Skip(long length)
		{
			return this.binaryWriter.Seek((int)length, SeekOrigin.Current);
		}

		// Token: 0x04000CD6 RID: 3286
		private FileStream fileStream;

		// Token: 0x04000CD7 RID: 3287
		private BinaryWriter binaryWriter;

		// Token: 0x04000CD8 RID: 3288
		private bool isWrite;
	}
}
