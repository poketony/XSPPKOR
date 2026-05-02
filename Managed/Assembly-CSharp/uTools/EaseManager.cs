using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000078 RID: 120
	public class EaseManager
	{
		// Token: 0x06000EA9 RID: 3753 RVA: 0x00112834 File Offset: 0x00110A34
		private static float linear(float start, float end, float value)
		{
			return Mathf.Lerp(start, end, value);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00112840 File Offset: 0x00110A40
		private static float clerp(float start, float end, float value)
		{
			float num = 0f;
			float num2 = 360f;
			float num3 = Mathf.Abs((num2 - num) / 2f);
			float num5;
			if (end - start < -num3)
			{
				float num4 = (num2 - start + end) * value;
				num5 = start + num4;
			}
			else if (end - start > num3)
			{
				float num4 = -(num2 - end + start) * value;
				num5 = start + num4;
			}
			else
			{
				num5 = start + (end - start) * value;
			}
			return num5;
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x001128AC File Offset: 0x00110AAC
		private static float spring(float start, float end, float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * 3.1415927f * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
			return start + (end - start) * value;
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00112910 File Offset: 0x00110B10
		private static float easeInQuad(float start, float end, float value)
		{
			end -= start;
			return end * value * value + start;
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x0011291E File Offset: 0x00110B1E
		private static float easeOutQuad(float start, float end, float value)
		{
			end -= start;
			return -end * value * (value - 2f) + start;
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00112934 File Offset: 0x00110B34
		private static float easeInOutQuad(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value + start;
			}
			value -= 1f;
			return -end / 2f * (value * (value - 2f) - 1f) + start;
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00112988 File Offset: 0x00110B88
		private static float easeInCubic(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value + start;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00112998 File Offset: 0x00110B98
		private static float easeOutCubic(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return end * (value * value * value + 1f) + start;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x001129B8 File Offset: 0x00110BB8
		private static float easeInOutCubic(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value * value + start;
			}
			value -= 2f;
			return end / 2f * (value * value * value + 2f) + start;
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00112A09 File Offset: 0x00110C09
		private static float easeInQuart(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value * value + start;
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x00112A1B File Offset: 0x00110C1B
		private static float easeOutQuart(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return -end * (value * value * value * value - 1f) + start;
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x00112A40 File Offset: 0x00110C40
		private static float easeInOutQuart(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value * value * value + start;
			}
			value -= 2f;
			return -end / 2f * (value * value * value * value - 2f) + start;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00112A96 File Offset: 0x00110C96
		private static float easeInQuint(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value * value * value + start;
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00112AAA File Offset: 0x00110CAA
		private static float easeOutQuint(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return end * (value * value * value * value * value + 1f) + start;
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00112AD0 File Offset: 0x00110CD0
		private static float easeInOutQuint(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value * value * value * value + start;
			}
			value -= 2f;
			return end / 2f * (value * value * value * value * value + 2f) + start;
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00112B29 File Offset: 0x00110D29
		private static float easeInSine(float start, float end, float value)
		{
			end -= start;
			return -end * Mathf.Cos(value / 1f * 1.5707964f) + end + start;
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00112B49 File Offset: 0x00110D49
		private static float easeOutSine(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Sin(value / 1f * 1.5707964f) + start;
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00112B66 File Offset: 0x00110D66
		private static float easeInOutSine(float start, float end, float value)
		{
			end -= start;
			return -end / 2f * (Mathf.Cos(3.1415927f * value / 1f) - 1f) + start;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00112B90 File Offset: 0x00110D90
		private static float easeInExpo(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2f, 10f * (value / 1f - 1f)) + start;
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00112BB8 File Offset: 0x00110DB8
		private static float easeOutExpo(float start, float end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2f, -10f * value / 1f) + 1f) + start;
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00112BE4 File Offset: 0x00110DE4
		private static float easeInOutExpo(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * Mathf.Pow(2f, 10f * (value - 1f)) + start;
			}
			value -= 1f;
			return end / 2f * (-Mathf.Pow(2f, -10f * value) + 2f) + start;
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x00112C54 File Offset: 0x00110E54
		private static float easeInCirc(float start, float end, float value)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1f - value * value) - 1f) + start;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x00112C74 File Offset: 0x00110E74
		private static float easeOutCirc(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return end * Mathf.Sqrt(1f - value * value) + start;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00112C98 File Offset: 0x00110E98
		private static float easeInOutCirc(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return -end / 2f * (Mathf.Sqrt(1f - value * value) - 1f) + start;
			}
			value -= 2f;
			return end / 2f * (Mathf.Sqrt(1f - value * value) + 1f) + start;
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00112D04 File Offset: 0x00110F04
		private static float easeInBounce(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			return end - EaseManager.easeOutBounce(0f, end, num - value) + start;
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00112D30 File Offset: 0x00110F30
		private static float easeOutBounce(float start, float end, float value)
		{
			value /= 1f;
			end -= start;
			if (value < 0.36363637f)
			{
				return end * (7.5625f * value * value) + start;
			}
			if (value < 0.72727275f)
			{
				value -= 0.54545456f;
				return end * (7.5625f * value * value + 0.75f) + start;
			}
			if ((double)value < 0.9090909090909091)
			{
				value -= 0.8181818f;
				return end * (7.5625f * value * value + 0.9375f) + start;
			}
			value -= 0.95454544f;
			return end * (7.5625f * value * value + 0.984375f) + start;
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x00112DCC File Offset: 0x00110FCC
		private static float easeInOutBounce(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			if (value < num / 2f)
			{
				return EaseManager.easeInBounce(0f, end, value * 2f) * 0.5f + start;
			}
			return EaseManager.easeOutBounce(0f, end, value * 2f - num) * 0.5f + end * 0.5f + start;
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x00112E30 File Offset: 0x00111030
		private static float easeInBack(float start, float end, float value)
		{
			end -= start;
			value /= 1f;
			float num = 1.70158f;
			return end * value * value * ((num + 1f) * value - num) + start;
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x00112E64 File Offset: 0x00111064
		private static float easeOutBack(float start, float end, float value)
		{
			float num = 1.70158f;
			end -= start;
			value = value / 1f - 1f;
			return end * (value * value * ((num + 1f) * value + num) + 1f) + start;
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x00112EA4 File Offset: 0x001110A4
		private static float easeInOutBack(float start, float end, float value)
		{
			float num = 1.70158f;
			end -= start;
			value /= 0.5f;
			if (value < 1f)
			{
				num *= 1.525f;
				return end / 2f * (value * value * ((num + 1f) * value - num)) + start;
			}
			value -= 2f;
			num *= 1.525f;
			return end / 2f * (value * value * ((num + 1f) * value + num) + 2f) + start;
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x00112F20 File Offset: 0x00111120
		private static float punch(float amplitude, float value)
		{
			if (value == 0f)
			{
				return 0f;
			}
			if (value == 1f)
			{
				return 0f;
			}
			float num = 0.3f;
			float num2 = num / 6.2831855f * Mathf.Asin(0f);
			return amplitude * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * 1f - num2) * 6.2831855f / num);
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x00112F94 File Offset: 0x00111194
		private static float easeInElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num) == 1f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.2831855f * Mathf.Asin(end / num3);
			}
			return -(num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.2831855f / num2)) + start;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x0011303C File Offset: 0x0011123C
		private static float easeOutElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num) == 1f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.2831855f * Mathf.Asin(end / num3);
			}
			return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * num - num4) * 6.2831855f / num2) + end + start;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x001130DC File Offset: 0x001112DC
		private static float easeInOutElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num / 2f) == 2f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.2831855f * Mathf.Asin(end / num3);
			}
			if (value < 1f)
			{
				return -0.5f * (num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.2831855f / num2)) + start;
			}
			return num3 * Mathf.Pow(2f, -10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.2831855f / num2) * 0.5f + end + start;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x001131D0 File Offset: 0x001113D0
		public static float EasingFromType(float start, float end, float t, EaseType type)
		{
			switch (type)
			{
			case EaseType.easeInQuad:
				return EaseManager.easeInQuad(start, end, t);
			case EaseType.easeOutQuad:
				return EaseManager.easeOutQuad(start, end, t);
			case EaseType.easeInOutQuad:
				return EaseManager.easeInOutQuad(start, end, t);
			case EaseType.easeInCubic:
				return EaseManager.easeInCubic(start, end, t);
			case EaseType.easeOutCubic:
				return EaseManager.easeOutCubic(start, end, t);
			case EaseType.easeInOutCubic:
				return EaseManager.easeInOutCubic(start, end, t);
			case EaseType.easeInQuart:
				return EaseManager.easeInQuart(start, end, t);
			case EaseType.easeOutQuart:
				return EaseManager.easeOutQuart(start, end, t);
			case EaseType.easeInOutQuart:
				return EaseManager.easeInOutQuart(start, end, t);
			case EaseType.easeInQuint:
				return EaseManager.easeInQuint(start, end, t);
			case EaseType.easeOutQuint:
				return EaseManager.easeOutQuint(start, end, t);
			case EaseType.easeInOutQuint:
				return EaseManager.easeInOutQuint(start, end, t);
			case EaseType.easeInSine:
				return EaseManager.easeInSine(start, end, t);
			case EaseType.easeOutSine:
				return EaseManager.easeOutSine(start, end, t);
			case EaseType.easeInOutSine:
				return EaseManager.easeInOutSine(start, end, t);
			case EaseType.easeInExpo:
				return EaseManager.easeInExpo(start, end, t);
			case EaseType.easeOutExpo:
				return EaseManager.easeOutExpo(start, end, t);
			case EaseType.easeInOutExpo:
				return EaseManager.easeInOutExpo(start, end, t);
			case EaseType.easeInCirc:
				return EaseManager.easeInCirc(start, end, t);
			case EaseType.easeOutCirc:
				return EaseManager.easeOutCirc(start, end, t);
			case EaseType.easeInOutCirc:
				return EaseManager.easeInOutCirc(start, end, t);
			case EaseType.linear:
				return EaseManager.linear(start, end, t);
			case EaseType.spring:
				return EaseManager.spring(start, end, t);
			case EaseType.easeInBounce:
				return EaseManager.easeInBounce(start, end, t);
			case EaseType.easeOutBounce:
				return EaseManager.easeOutBounce(start, end, t);
			case EaseType.easeInOutBounce:
				return EaseManager.easeInOutBounce(start, end, t);
			case EaseType.easeInBack:
				return EaseManager.easeInBack(start, end, t);
			case EaseType.easeOutBack:
				return EaseManager.easeOutBack(start, end, t);
			case EaseType.easeInOutBack:
				return EaseManager.easeInOutBack(start, end, t);
			case EaseType.easeInElastic:
				return EaseManager.easeInElastic(start, end, t);
			case EaseType.easeOutElastic:
				return EaseManager.easeOutElastic(start, end, t);
			case EaseType.easeInOutElastic:
				return EaseManager.easeInOutElastic(start, end, t);
			default:
				return EaseManager.linear(start, end, t);
			}
		}

		// Token: 0x020001F1 RID: 497
		// (Invoke) Token: 0x06001C8A RID: 7306
		public delegate float EaseDelegate(float start, float end, float t);
	}
}
