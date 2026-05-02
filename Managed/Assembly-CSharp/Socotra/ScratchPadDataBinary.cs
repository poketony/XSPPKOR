using System;
using Socotra.IO;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E1 RID: 225
	public class ScratchPadDataBinary : ScratchPadData
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060012BF RID: 4799 RVA: 0x0011F012 File Offset: 0x0011D212
		public override int Length
		{
			get
			{
				return this.binaryData.bytes.Length;
			}
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x0011F021 File Offset: 0x0011D221
		public override DataInputStream GetDataInputStream()
		{
			return new DataInputStream(this.GetInputStream());
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x0011F02E File Offset: 0x0011D22E
		public override DataOutputStream GetDataOutputStream()
		{
			FileByteOutputStream fileByteOutputStream = new FileByteOutputStream(this.filePath);
			fileByteOutputStream.Skip(this.offset);
			return new DataOutputStream(fileByteOutputStream);
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x0011F04C File Offset: 0x0011D24C
		public override InputStream GetInputStream()
		{
			if (this.length <= 0 && this.offset < this.binaryData.bytes.Length)
			{
				this.length = this.binaryData.bytes.Length - this.offset;
			}
			this.byteStream = new ByteArrayInputStream(this.binaryData.bytes, this.offset, this.length);
			return this.byteStream;
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x0011F0B9 File Offset: 0x0011D2B9
		public override OutputStream GetOutputStream()
		{
			string persistentDataPath = Application.persistentDataPath;
			return new FileByteOutputStream(this.filePath);
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x0011F0CC File Offset: 0x0011D2CC
		private void Start()
		{
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x0011F0CE File Offset: 0x0011D2CE
		private void Update()
		{
		}

		// Token: 0x04000A7A RID: 2682
		[SerializeField]
		private TextAsset binaryData;

		// Token: 0x04000A7B RID: 2683
		[SerializeField]
		private string filePath;

		// Token: 0x04000A7C RID: 2684
		private ByteArrayInputStream byteStream;
	}
}
