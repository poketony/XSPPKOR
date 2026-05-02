using System;
using System.Collections.Generic;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E0 RID: 224
	public class ScratchPad : MonoBehaviour
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x0011EFF1 File Offset: 0x0011D1F1
		public int Number
		{
			get
			{
				return this.scratchPadNumber;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060012BB RID: 4795 RVA: 0x0011EFF9 File Offset: 0x0011D1F9
		public Dictionary<int, ScratchPadData> Table
		{
			get
			{
				return this.scratchPadTable.GetTable();
			}
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x0011F006 File Offset: 0x0011D206
		private void Start()
		{
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x0011F008 File Offset: 0x0011D208
		private void Update()
		{
		}

		// Token: 0x04000A78 RID: 2680
		[SerializeField]
		private int scratchPadNumber;

		// Token: 0x04000A79 RID: 2681
		[SerializeField]
		private ScratchPadTable scratchPadTable;
	}
}
