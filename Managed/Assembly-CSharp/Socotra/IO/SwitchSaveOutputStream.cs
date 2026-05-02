using System;
using System.IO;
using UnityEngine;

namespace Socotra.IO
{
	// Token: 0x02000132 RID: 306
	public class SwitchSaveOutputStream : OutputStream
	{
		// Token: 0x0600168F RID: 5775 RVA: 0x0012D8E0 File Offset: 0x0012BAE0
		public SwitchSaveOutputStream(ScratchPadSaveData scratchPad)
		{
			this.scratchPad = scratchPad;
			this.buffer = new byte[scratchPad.Data.Length];
			scratchPad.Data.CopyTo(this.buffer, 0);
			this.memoryStream = new MemoryStream(this.buffer);
			this.binaryWriter = new BinaryWriter(this.memoryStream);
			this.isWrite = false;
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x0012D948 File Offset: 0x0012BB48
		public override void Close()
		{
			this.Flush();
			this.binaryWriter.Close();
			this.memoryStream.Close();
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x0012D968 File Offset: 0x0012BB68
		public override void Flush()
		{
			if (!this.isWrite)
			{
				return;
			}
			this.binaryWriter.Flush();
			this.memoryStream.Flush();
			this.scratchPad.Data = this.buffer;
			this.scratchPad.ReserveSaveData();
			this.isWrite = false;
			Debug.Log("<color=yellow>" + base.GetType().FullName + ".Flush() :</color>" + this.scratchPad.FilePath);
		}

		// Token: 0x06001692 RID: 5778 RVA: 0x0012D9E1 File Offset: 0x0012BBE1
		public override long Skip(long length)
		{
			return this.binaryWriter.Seek((int)length, SeekOrigin.Current);
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x0012D9F1 File Offset: 0x0012BBF1
		public override void Write(int i)
		{
			this.binaryWriter.Write((byte)i);
			this.isWrite = true;
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x0012DA08 File Offset: 0x0012BC08
		public override void Write(sbyte[] b, int off, int len)
		{
			byte[] byteArray = base.GetByteArray(b);
			this.binaryWriter.Write(byteArray, off, len);
			this.isWrite = true;
		}

		// Token: 0x06001695 RID: 5781 RVA: 0x0012DA32 File Offset: 0x0012BC32
		public override void WriteByte(sbyte b)
		{
			this.binaryWriter.Write((byte)b);
			this.isWrite = true;
		}

		// Token: 0x06001696 RID: 5782 RVA: 0x0012DA48 File Offset: 0x0012BC48
		public override void WriteShort(short s)
		{
			this.binaryWriter.Write(s);
			this.isWrite = true;
		}

		// Token: 0x04000CDA RID: 3290
		private ScratchPadSaveData scratchPad;

		// Token: 0x04000CDB RID: 3291
		private MemoryStream memoryStream;

		// Token: 0x04000CDC RID: 3292
		private BinaryWriter binaryWriter;

		// Token: 0x04000CDD RID: 3293
		private byte[] buffer;

		// Token: 0x04000CDE RID: 3294
		private bool isWrite;
	}
}
