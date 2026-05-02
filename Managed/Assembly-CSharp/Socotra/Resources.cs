using System;
using Socotra.IO;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000DC RID: 220
	public class Resources : MonoBehaviour
	{
		// Token: 0x060012A9 RID: 4777 RVA: 0x0011EEC2 File Offset: 0x0011D0C2
		public Object GetResource(int index)
		{
			if (this.objects.Length < index)
			{
				return null;
			}
			return this.objects[index];
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x0011EED9 File Offset: 0x0011D0D9
		public Object[] GetResources()
		{
			return this.objects;
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x0011EEE1 File Offset: 0x0011D0E1
		public DataInputStream OpenDataInputStream(int index)
		{
			if (this.objects.Length < index)
			{
				return null;
			}
			if (this.objects[index] is TextAsset)
			{
				return new DataInputStream(new ByteArrayInputStream((this.objects[index] as TextAsset).bytes));
			}
			return null;
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x0011EF1D File Offset: 0x0011D11D
		public byte[] GetByteData(int index)
		{
			if (this.objects.Length < index)
			{
				return null;
			}
			if (this.objects[index] is TextAsset)
			{
				return (this.objects[index] as TextAsset).bytes;
			}
			return null;
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x0011EF4F File Offset: 0x0011D14F
		private void Start()
		{
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x0011EF51 File Offset: 0x0011D151
		private void Update()
		{
		}

		// Token: 0x04000A73 RID: 2675
		[SerializeField]
		private Object[] objects;
	}
}
