using System;
using Socotra.IO;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E2 RID: 226
	public class ScratchPadDataImage : ScratchPadData
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060012C7 RID: 4807 RVA: 0x0011F0D8 File Offset: 0x0011D2D8
		public override int Length
		{
			get
			{
				return this.baseSprite.texture.GetRawTextureData().Length;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060012C8 RID: 4808 RVA: 0x0011F0EC File Offset: 0x0011D2EC
		public Sprite BaseSprite
		{
			get
			{
				return this.baseSprite;
			}
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x0011F0F4 File Offset: 0x0011D2F4
		public override DataInputStream GetDataInputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x0011F0FB File Offset: 0x0011D2FB
		public override DataOutputStream GetDataOutputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x0011F102 File Offset: 0x0011D302
		public override InputStream GetInputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x0011F109 File Offset: 0x0011D309
		public override OutputStream GetOutputStream()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x0011F110 File Offset: 0x0011D310
		private void Start()
		{
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x0011F112 File Offset: 0x0011D312
		private void Update()
		{
		}

		// Token: 0x04000A7D RID: 2685
		[SerializeField]
		private Sprite baseSprite;
	}
}
