using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x02000073 RID: 115
	public class SliderColors : MonoBehaviour
	{
		// Token: 0x06000E99 RID: 3737 RVA: 0x0011254C File Offset: 0x0011074C
		private void Start()
		{
			this.mSlider = base.GetComponent<Slider>();
			if (this.mSlider == null)
			{
				Debug.LogError(" 'uSliderColors' can't find 'Slider'.");
				return;
			}
			if (this.target == null)
			{
				this.target = this.mSlider.GetComponentInChildren<Image>();
			}
			UnityAction<float> unityAction = new UnityAction<float>(this.OnValueChanged);
			this.mSlider.onValueChanged.AddListener(unityAction);
			this.OnValueChanged(this.mSlider.value);
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x001125CC File Offset: 0x001107CC
		public void OnValueChanged(float value)
		{
			float num = value * (float)(this.colors.Length - 1);
			int num2 = Mathf.FloorToInt(num);
			Color color = this.colors[0];
			if (num2 + 1 < this.colors.Length)
			{
				color = Color.Lerp(this.colors[num2], this.colors[num2 + 1], num - (float)num2);
			}
			else if (num2 < this.colors.Length)
			{
				color = this.colors[num2];
			}
			this.target.color = color;
		}

		// Token: 0x040008CE RID: 2254
		public Image target;

		// Token: 0x040008CF RID: 2255
		public Color[] colors = new Color[]
		{
			Color.red,
			Color.yellow,
			Color.green
		};

		// Token: 0x040008D0 RID: 2256
		private Slider mSlider;
	}
}
