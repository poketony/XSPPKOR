using System;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Localize
{
	// Token: 0x020000D0 RID: 208
	[ExecuteInEditMode]
	[AddComponentMenu("Steezy/Localize/FontLocalize")]
	public class FontLocalize : MonoBehaviour
	{
		// Token: 0x17000073 RID: 115
		// (set) Token: 0x06001251 RID: 4689 RVA: 0x0011DC00 File Offset: 0x0011BE00
		public int value
		{
			set
			{
				Font font = this.fonts[value];
				float num = this.lineSpacings[value];
				if (font != null)
				{
					Text component = base.GetComponent<Text>();
					TextMesh component2 = base.GetComponent<TextMesh>();
					if (component != null)
					{
						component.font = font;
						component.lineSpacing = num;
						this.SetDirty(component);
						return;
					}
					if (component2 != null)
					{
						component2.font = font;
						component2.lineSpacing = num;
						this.SetDirty(component2);
					}
				}
			}
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x0011DC73 File Offset: 0x0011BE73
		private void SetDirty(Object target)
		{
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x0011DC75 File Offset: 0x0011BE75
		private void OnEnable()
		{
			if (this.mStarted)
			{
				this.OnLocalize();
			}
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x0011DC85 File Offset: 0x0011BE85
		private void Start()
		{
			this.mStarted = true;
			this.OnLocalize();
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x0011DC94 File Offset: 0x0011BE94
		public void OnLocalize()
		{
			if (Localization.LaunguageIndex >= 0 && Localization.LaunguageIndex < this.fonts.Length)
			{
				this.value = Localization.LaunguageIndex;
			}
		}

		// Token: 0x04000A36 RID: 2614
		public Font[] fonts;

		// Token: 0x04000A37 RID: 2615
		public float[] lineSpacings;

		// Token: 0x04000A38 RID: 2616
		private bool mStarted;
	}
}
