using System;
using System.Collections.Generic;
using Socotra.IO;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E3 RID: 227
	public class ScratchPadDataJar : ScratchPadData
	{
		// Token: 0x060012D0 RID: 4816 RVA: 0x0011F11C File Offset: 0x0011D31C
		public override DataInputStream GetDataInputStream()
		{
			return new JarDataInputStream(new JarInputStream(this));
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x0011F129 File Offset: 0x0011D329
		public override DataOutputStream GetDataOutputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x0011F130 File Offset: 0x0011D330
		public override InputStream GetInputStream()
		{
			return new JarInputStream(this);
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x0011F138 File Offset: 0x0011D338
		public override OutputStream GetOutputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x0011F140 File Offset: 0x0011D340
		public ScratchPadData GetData(string name)
		{
			Dictionary<string, ScratchPadData> table = this.containDataTable.GetTable();
			if (table.ContainsKey(name))
			{
				return table[name];
			}
			return null;
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x0011F16B File Offset: 0x0011D36B
		private void Start()
		{
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x0011F16D File Offset: 0x0011D36D
		private void Update()
		{
		}

		// Token: 0x04000A7E RID: 2686
		[SerializeField]
		private ScratchPadJarTable containDataTable;
	}
}
