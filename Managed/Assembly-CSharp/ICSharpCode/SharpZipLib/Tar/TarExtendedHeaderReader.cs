using System;
using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000177 RID: 375
	public class TarExtendedHeaderReader
	{
		// Token: 0x060019CA RID: 6602 RVA: 0x0013B442 File Offset: 0x00139642
		public TarExtendedHeaderReader()
		{
			this.ResetBuffers();
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x0013B484 File Offset: 0x00139684
		public void Read(byte[] buffer, int length)
		{
			for (int i = 0; i < length; i++)
			{
				byte b = buffer[i];
				if (b == TarExtendedHeaderReader.StateNext[this.state])
				{
					this.Flush();
					this.headerParts[this.state] = this.sb.ToString();
					this.sb.Clear();
					int num = this.state + 1;
					this.state = num;
					if (num == 3)
					{
						this.headers.Add(this.headerParts[1], this.headerParts[2]);
						this.headerParts = new string[3];
						this.state = 0;
					}
				}
				else
				{
					byte[] array = this.byteBuffer;
					int num = this.bbIndex;
					this.bbIndex = num + 1;
					array[num] = b;
					if (this.bbIndex == 4)
					{
						this.Flush();
					}
				}
			}
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x0013B54C File Offset: 0x0013974C
		private void Flush()
		{
			int num;
			int num2;
			bool flag;
			this.decoder.Convert(this.byteBuffer, 0, this.bbIndex, this.charBuffer, 0, 4, false, out num, out num2, out flag);
			this.sb.Append(this.charBuffer, 0, num2);
			this.ResetBuffers();
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x0013B59A File Offset: 0x0013979A
		private void ResetBuffers()
		{
			this.charBuffer = new char[4];
			this.byteBuffer = new byte[4];
			this.bbIndex = 0;
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060019CE RID: 6606 RVA: 0x0013B5BB File Offset: 0x001397BB
		public Dictionary<string, string> Headers
		{
			get
			{
				return this.headers;
			}
		}

		// Token: 0x04000EC8 RID: 3784
		private const byte LENGTH = 0;

		// Token: 0x04000EC9 RID: 3785
		private const byte KEY = 1;

		// Token: 0x04000ECA RID: 3786
		private const byte VALUE = 2;

		// Token: 0x04000ECB RID: 3787
		private const byte END = 3;

		// Token: 0x04000ECC RID: 3788
		private readonly Dictionary<string, string> headers = new Dictionary<string, string>();

		// Token: 0x04000ECD RID: 3789
		private string[] headerParts = new string[3];

		// Token: 0x04000ECE RID: 3790
		private int bbIndex;

		// Token: 0x04000ECF RID: 3791
		private byte[] byteBuffer;

		// Token: 0x04000ED0 RID: 3792
		private char[] charBuffer;

		// Token: 0x04000ED1 RID: 3793
		private readonly StringBuilder sb = new StringBuilder();

		// Token: 0x04000ED2 RID: 3794
		private readonly Decoder decoder = Encoding.UTF8.GetDecoder();

		// Token: 0x04000ED3 RID: 3795
		private int state;

		// Token: 0x04000ED4 RID: 3796
		private static readonly byte[] StateNext = new byte[] { 32, 61, 10 };
	}
}
