using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000056 RID: 86
public class ButtonCD : MonoBehaviour
{
	// Token: 0x06000DE4 RID: 3556 RVA: 0x0010D73D File Offset: 0x0010B93D
	private void Awake()
	{
		this.mButton = base.GetComponent<Button>();
		this.mButton.onClick.AddListener(new UnityAction(this.OnPointerClick));
	}

	// Token: 0x06000DE5 RID: 3557 RVA: 0x0010D767 File Offset: 0x0010B967
	private void OnEnable()
	{
		this.SetButtonEnable(true);
	}

	// Token: 0x06000DE6 RID: 3558 RVA: 0x0010D770 File Offset: 0x0010B970
	public void OnPointerClick()
	{
		if (Time.realtimeSinceStartup - this.mClickTime >= this.CD)
		{
			this.mClickTime = Time.realtimeSinceStartup;
			this.SetButtonEnable(false);
			base.StartCoroutine(this.IESetButtonEnable());
		}
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x0010D7A5 File Offset: 0x0010B9A5
	private IEnumerator IESetButtonEnable()
	{
		yield return new WaitForSeconds(this.CD);
		this.SetButtonEnable(true);
		yield break;
	}

	// Token: 0x06000DE8 RID: 3560 RVA: 0x0010D7B4 File Offset: 0x0010B9B4
	private void SetButtonEnable(bool enable)
	{
		if (this.mButton != null)
		{
			this.mButton.enabled = enable;
			if (this.isChangeColor)
			{
				Image[] componentsInChildren = this.mButton.GetComponentsInChildren<Image>();
				Color color = (enable ? Color.white : new Color(0.78f, 0.78f, 0.78f, 1f));
				Image[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].color = color;
				}
			}
		}
	}

	// Token: 0x04000830 RID: 2096
	public float CD = 0.1f;

	// Token: 0x04000831 RID: 2097
	private float mClickTime;

	// Token: 0x04000832 RID: 2098
	public bool isChangeColor;

	// Token: 0x04000833 RID: 2099
	private Button mButton;
}
