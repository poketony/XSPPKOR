using System;
using UnityEngine;

namespace Steezy.Localize
{
	// Token: 0x020000CE RID: 206
	[ExecuteInEditMode]
	[AddComponentMenu("Steezy/Localize/ActiveObjectLocalize")]
	public class ActiveObjectLocalize : MonoBehaviour
	{
		// Token: 0x17000072 RID: 114
		// (set) Token: 0x06001249 RID: 4681 RVA: 0x0011D968 File Offset: 0x0011BB68
		public GameObject value
		{
			set
			{
				foreach (GameObject gameObject in this.gameObjects)
				{
					if (!(gameObject == null))
					{
						if (gameObject == value)
						{
							gameObject.SetActive(true);
						}
						else
						{
							gameObject.SetActive(false);
						}
					}
				}
			}
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x0011D9B0 File Offset: 0x0011BBB0
		private void SetDirty(Object target)
		{
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x0011D9B2 File Offset: 0x0011BBB2
		private void OnEnable()
		{
			if (this.mStarted)
			{
				this.OnLocalize();
			}
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x0011D9C2 File Offset: 0x0011BBC2
		private void Start()
		{
			this.mStarted = true;
			this.OnLocalize();
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x0011D9D1 File Offset: 0x0011BBD1
		public void OnLocalize()
		{
			if (Localization.LaunguageIndex >= 0 && Localization.LaunguageIndex < this.gameObjects.Length)
			{
				this.value = this.gameObjects[Localization.LaunguageIndex];
			}
		}

		// Token: 0x04000A34 RID: 2612
		public GameObject[] gameObjects;

		// Token: 0x04000A35 RID: 2613
		private bool mStarted;
	}
}
