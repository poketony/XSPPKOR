using System;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Localize
{
	// Token: 0x020000D2 RID: 210
	[ExecuteInEditMode]
	[AddComponentMenu("Steezy/Localize/UILocalize")]
	public class UILocalize : MonoBehaviour
	{
		// Token: 0x17000079 RID: 121
		// (set) Token: 0x06001267 RID: 4711 RVA: 0x0011E084 File Offset: 0x0011C284
		public string value
		{
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					Text component = base.GetComponent<Text>();
					Image component2 = base.GetComponent<Image>();
					SpriteRenderer component3 = base.GetComponent<SpriteRenderer>();
					TextMesh component4 = base.GetComponent<TextMesh>();
					if (component != null)
					{
						component.text = value;
						this.SetDirty(component);
						return;
					}
					if (component2 != null)
					{
						int num = value.LastIndexOf("/");
						if (num != -1)
						{
							Sprite sprite = this.LoadSprite(value.Substring(0, num), value.Substring(num + 1));
							if (sprite != null)
							{
								component2.sprite = sprite;
								this.SetDirty(component2);
								return;
							}
						}
					}
					else if (component3 != null)
					{
						int num2 = value.LastIndexOf("/");
						if (num2 != -1)
						{
							Sprite sprite2 = this.LoadSprite(value.Substring(0, num2), value.Substring(num2 + 1));
							if (sprite2 != null)
							{
								component3.sprite = sprite2;
								this.SetDirty(component3);
								return;
							}
						}
					}
					else if (component4 != null)
					{
						component4.text = value;
						this.SetDirty(component4);
					}
				}
			}
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x0011E18A File Offset: 0x0011C38A
		private void SetDirty(Object target)
		{
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x0011E18C File Offset: 0x0011C38C
		private Sprite LoadSprite(string fileName, string spriteName)
		{
			return Array.Find<Sprite>(Resources.LoadAll<Sprite>(fileName), (Sprite sprite) => sprite.name.Equals(spriteName));
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x0011E1BD File Offset: 0x0011C3BD
		private void OnEnable()
		{
			if (this.mStarted)
			{
				this.OnLocalize();
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x0011E1CD File Offset: 0x0011C3CD
		private void Start()
		{
			this.mStarted = true;
			this.OnLocalize();
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x0011E1DC File Offset: 0x0011C3DC
		public void OnLocalize()
		{
			if (string.IsNullOrEmpty(this.key))
			{
				Text component = base.GetComponent<Text>();
				if (component != null)
				{
					this.key = component.text;
				}
			}
			if (!string.IsNullOrEmpty(this.key))
			{
				this.value = Localization.Get(this.key);
			}
		}

		// Token: 0x04000A3F RID: 2623
		public string key;

		// Token: 0x04000A40 RID: 2624
		private bool mStarted;
	}
}
