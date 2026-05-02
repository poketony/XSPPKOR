using System;
using Socotra.IO;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E4 RID: 228
	public class ScratchPadDataSound : ScratchPadData
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060012D8 RID: 4824 RVA: 0x0011F177 File Offset: 0x0011D377
		public AudioClip BaseAudio
		{
			get
			{
				return this.baseAudio;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060012D9 RID: 4825 RVA: 0x0011F17F File Offset: 0x0011D37F
		public bool Loop
		{
			get
			{
				return this.isLoop;
			}
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x0011F187 File Offset: 0x0011D387
		public override DataInputStream GetDataInputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x0011F18E File Offset: 0x0011D38E
		public override DataOutputStream GetDataOutputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x0011F195 File Offset: 0x0011D395
		public override InputStream GetInputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x0011F19C File Offset: 0x0011D39C
		public override OutputStream GetOutputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x0011F1A3 File Offset: 0x0011D3A3
		private void Start()
		{
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x0011F1A5 File Offset: 0x0011D3A5
		private void Update()
		{
		}

		// Token: 0x04000A7F RID: 2687
		[SerializeField]
		private AudioClip baseAudio;

		// Token: 0x04000A80 RID: 2688
		[SerializeField]
		private bool isLoop;
	}
}
