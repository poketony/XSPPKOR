using System;
using Steezy.Sound;
using UnityEngine;
using uTools;

// Token: 0x02000005 RID: 5
public class AppliSelectorObject : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x00002585 File Offset: 0x00000785
	public void Init(int selectIndex)
	{
		this.SetSelect(selectIndex, false);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002590 File Offset: 0x00000790
	private void SetSelect(int selectIndex, bool isPlaySe = true)
	{
		if (selectIndex < 0 || selectIndex >= this.selectorObjects.Length)
		{
			return;
		}
		for (int i = 0; i < this.selectorObjects.Length; i++)
		{
			AppliSelectorObject.SelectorObject selectorObject = this.selectorObjects[i];
			bool flag = i == selectIndex;
			selectorObject.activeObj.SetActive(flag);
			selectorObject.inactiveObj.SetActive(!flag);
			if (flag)
			{
				foreach (Tweener tweener in selectorObject.focusObj.GetComponents<Tweener>())
				{
					tweener.ResetToBeginning();
					tweener.PlayForward();
				}
			}
		}
		if (isPlaySe)
		{
			SoundManager.Instance.PlaySE("se_cursol", false);
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000262C File Offset: 0x0000082C
	public void Select(int selectIndex)
	{
		this.SetSelect(selectIndex, true);
	}

	// Token: 0x04000018 RID: 24
	[SerializeField]
	private AppliSelectorObject.SelectorObject[] selectorObjects;

	// Token: 0x020001AC RID: 428
	[Serializable]
	public class SelectorObject
	{
		// Token: 0x040012A9 RID: 4777
		[SerializeField]
		public GameObject activeObj;

		// Token: 0x040012AA RID: 4778
		[SerializeField]
		public GameObject inactiveObj;

		// Token: 0x040012AB RID: 4779
		[SerializeField]
		public GameObject focusObj;
	}
}
