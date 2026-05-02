using System;
using Socotra.UI;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000EA RID: 234
	public class StFontManager : SingletonBehaviour<StFontManager>
	{
		// Token: 0x06001320 RID: 4896 RVA: 0x0011FD50 File Offset: 0x0011DF50
		public StFont GetFont(int size)
		{
			foreach (StFontManager.FontSizeMap fontSizeMap in this.fontSizeMappings)
			{
				if (fontSizeMap.fontSize == size)
				{
					return new StFont(fontSizeMap.font, (float)size);
				}
			}
			return new StFont(this.defaultFont, (float)size);
		}

		// Token: 0x04000ABA RID: 2746
		[SerializeField]
		private Font defaultFont;

		// Token: 0x04000ABB RID: 2747
		[Header("指定のフォントサイズ時に使用するFontを設定するリスト")]
		[SerializeField]
		private StFontManager.FontSizeMap[] fontSizeMappings = new StFontManager.FontSizeMap[0];

		// Token: 0x02000239 RID: 569
		[Serializable]
		public class FontSizeMap
		{
			// Token: 0x040014DB RID: 5339
			public int fontSize;

			// Token: 0x040014DC RID: 5340
			public Font font;
		}
	}
}
