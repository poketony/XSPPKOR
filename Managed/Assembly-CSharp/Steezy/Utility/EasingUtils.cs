using System;
using System.Collections;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000B1 RID: 177
	public static class EasingUtils
	{
		// Token: 0x0600107B RID: 4219 RVA: 0x00118704 File Offset: 0x00116904
		public static Func<float, float> EasingFunction(EasingUtils.EaseType easeType)
		{
			switch (easeType)
			{
			case EasingUtils.EaseType.Linear:
				return new Func<float, float>(EasingUtils.Linear);
			case EasingUtils.EaseType.Cleap:
				return new Func<float, float>(EasingUtils.Clerp);
			case EasingUtils.EaseType.Spring:
				return new Func<float, float>(EasingUtils.Spring);
			case EasingUtils.EaseType.InQuad:
				return new Func<float, float>(EasingUtils.EaseInQuad);
			case EasingUtils.EaseType.OutQuad:
				return new Func<float, float>(EasingUtils.EaseOutQuad);
			case EasingUtils.EaseType.InOutQuad:
				return new Func<float, float>(EasingUtils.EaseInOutQuad);
			case EasingUtils.EaseType.InCubic:
				return new Func<float, float>(EasingUtils.EaseInCubic);
			case EasingUtils.EaseType.OutCubic:
				return new Func<float, float>(EasingUtils.EaseOutCubic);
			case EasingUtils.EaseType.InOutCubic:
				return new Func<float, float>(EasingUtils.EaseInOutCubic);
			case EasingUtils.EaseType.InQuart:
				return new Func<float, float>(EasingUtils.EaseInQuart);
			case EasingUtils.EaseType.OutQuart:
				return new Func<float, float>(EasingUtils.EaseOutQuart);
			case EasingUtils.EaseType.InOutQuart:
				return new Func<float, float>(EasingUtils.EaseInOutQuart);
			case EasingUtils.EaseType.InQuint:
				return new Func<float, float>(EasingUtils.EaseInQuint);
			case EasingUtils.EaseType.OutQuint:
				return new Func<float, float>(EasingUtils.EaseOutQuint);
			case EasingUtils.EaseType.InOutQuint:
				return new Func<float, float>(EasingUtils.EaseInOutQuint);
			case EasingUtils.EaseType.InSine:
				return new Func<float, float>(EasingUtils.EaseInSine);
			case EasingUtils.EaseType.OutSine:
				return new Func<float, float>(EasingUtils.EaseOutSine);
			case EasingUtils.EaseType.InOutSine:
				return new Func<float, float>(EasingUtils.EaseInOutSine);
			case EasingUtils.EaseType.InExpo:
				return new Func<float, float>(EasingUtils.EaseInExpo);
			case EasingUtils.EaseType.OutExpo:
				return new Func<float, float>(EasingUtils.EaseOutExpo);
			case EasingUtils.EaseType.InOutExpo:
				return new Func<float, float>(EasingUtils.EaseInOutExpo);
			case EasingUtils.EaseType.InCirc:
				return new Func<float, float>(EasingUtils.EaseInCirc);
			case EasingUtils.EaseType.OutCirc:
				return new Func<float, float>(EasingUtils.EaseOutCirc);
			case EasingUtils.EaseType.InOutCirc:
				return new Func<float, float>(EasingUtils.EaseInOutCirc);
			case EasingUtils.EaseType.InBounce:
				return new Func<float, float>(EasingUtils.EaseInBounce);
			case EasingUtils.EaseType.OutBounce:
				return new Func<float, float>(EasingUtils.EaseOutBounce);
			case EasingUtils.EaseType.InOutBounce:
				return new Func<float, float>(EasingUtils.EaseInOutBounce);
			case EasingUtils.EaseType.InBack:
				return new Func<float, float>(EasingUtils.EaseInBack);
			case EasingUtils.EaseType.OutBack:
				return new Func<float, float>(EasingUtils.EaseOutBack);
			case EasingUtils.EaseType.InOutBack:
				return new Func<float, float>(EasingUtils.EaseInOutBack);
			case EasingUtils.EaseType.InElastic:
				return new Func<float, float>(EasingUtils.EaseInElastic);
			case EasingUtils.EaseType.OutElastic:
				return new Func<float, float>(EasingUtils.EaseOutElastic);
			case EasingUtils.EaseType.InOutElastic:
				return new Func<float, float>(EasingUtils.EaseInOutElastic);
			default:
				return new Func<float, float>(EasingUtils.Linear);
			}
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x0011895C File Offset: 0x00116B5C
		public static IEnumerator PlayEasing(float time, EasingUtils.EaseType easeType, Action<float> updateCallback)
		{
			return EasingUtils.PlayEasingCoroutine(time, delegate(float r)
			{
				updateCallback(EasingUtils.EasingFunction(easeType)(r));
			});
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x0011898F File Offset: 0x00116B8F
		public static IEnumerator PlayLinearEasing(float time, Action<float> updateCallback)
		{
			return EasingUtils.PlayEasing(time, EasingUtils.EaseType.Linear, updateCallback);
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x00118999 File Offset: 0x00116B99
		private static IEnumerator PlayEasingCoroutine(float time, Action<float> updateCallback)
		{
			float easyTime = 0f;
			while (easyTime < time)
			{
				easyTime += Time.deltaTime;
				updateCallback(Mathf.Min(easyTime / time, 1f));
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x001189AF File Offset: 0x00116BAF
		public static float Linear(float value)
		{
			return Mathf.Lerp(0f, 1f, value);
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x001189C4 File Offset: 0x00116BC4
		public static float Clerp(float value)
		{
			float num = 0f;
			float num2 = 360f;
			float num3 = Mathf.Abs((num2 - num) * 0.5f);
			float num4;
			if (1f < -num3)
			{
				num4 = (num2 + 1f) * value;
			}
			else if (1f > num3)
			{
				num4 = -(num2 - 1f) * value;
			}
			else
			{
				num4 = value;
			}
			return num4;
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x00118A20 File Offset: 0x00116C20
		public static float Spring(float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * 3.1415927f * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
			return value;
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x00118A7E File Offset: 0x00116C7E
		public static float EaseInQuad(float value)
		{
			return value * value;
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x00118A83 File Offset: 0x00116C83
		public static float EaseOutQuad(float value)
		{
			return -1f * value * (value - 2f);
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x00118A94 File Offset: 0x00116C94
		public static float EaseInOutQuad(float value)
		{
			value /= 0.5f;
			if (value < 1f)
			{
				return 0.5f * value * value;
			}
			value -= 1f;
			return -0.5f * (value * (value - 2f) - 1f);
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x00118ACF File Offset: 0x00116CCF
		public static float EaseInCubic(float value)
		{
			return value * value * value;
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x00118AD6 File Offset: 0x00116CD6
		public static float EaseOutCubic(float value)
		{
			value -= 1f;
			return value * value * value + 1f;
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x00118AEC File Offset: 0x00116CEC
		public static float EaseInOutCubic(float value)
		{
			value /= 0.5f;
			if (value < 1f)
			{
				return 0.5f * value * value * value;
			}
			value -= 2f;
			return 0.5f * (value * value * value + 2f);
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x00118B25 File Offset: 0x00116D25
		public static float EaseInQuart(float value)
		{
			return value * value * value * value;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x00118B2E File Offset: 0x00116D2E
		public static float EaseOutQuart(float value)
		{
			value -= 1f;
			return -(value * value * value * value - 1f);
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x00118B47 File Offset: 0x00116D47
		public static float EaseInOutQuart(float value)
		{
			value /= 0.5f;
			if (value < 1f)
			{
				return 0.5f * value * value * value * value;
			}
			value -= 2f;
			return -0.5f * (value * value * value * value - 2f);
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x00118B84 File Offset: 0x00116D84
		public static float EaseInQuint(float value)
		{
			return value * value * value * value * value;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00118B8F File Offset: 0x00116D8F
		public static float EaseOutQuint(float value)
		{
			value -= 1f;
			return value * value * value * value * value + 1f;
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x00118BAC File Offset: 0x00116DAC
		public static float EaseInOutQuint(float value)
		{
			value /= 0.5f;
			if (value < 1f)
			{
				return 0.5f * value * value * value * value * value;
			}
			value -= 2f;
			return 0.5f * (value * value * value * value * value + 2f);
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x00118BF8 File Offset: 0x00116DF8
		public static float EaseInSine(float value)
		{
			return -1f * Mathf.Cos(value * 1.5707964f) + 1f;
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x00118C12 File Offset: 0x00116E12
		public static float EaseOutSine(float value)
		{
			return Mathf.Sin(value * 1.5707964f);
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x00118C20 File Offset: 0x00116E20
		public static float EaseInOutSine(float value)
		{
			return -0.2f * (Mathf.Cos(3.1415927f * value) - 1f);
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x00118C3A File Offset: 0x00116E3A
		public static float EaseInExpo(float value)
		{
			return Mathf.Pow(2f, 10f * (value - 1f));
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x00118C53 File Offset: 0x00116E53
		public static float EaseOutExpo(float value)
		{
			return -Mathf.Pow(2f, -10f * value) + 1f;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x00118C70 File Offset: 0x00116E70
		public static float EaseInOutExpo(float value)
		{
			value /= 0.5f;
			if (value < 1f)
			{
				return 0.5f * Mathf.Pow(2f, 10f * (value - 1f));
			}
			value -= 1f;
			return 0.5f * (-Mathf.Pow(2f, -10f * value) + 2f);
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x00118CD3 File Offset: 0x00116ED3
		public static float EaseInCirc(float value)
		{
			return -1f * (Mathf.Sqrt(1f - value * value) - 1f);
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x00118CEF File Offset: 0x00116EEF
		public static float EaseOutCirc(float value)
		{
			value -= 1f;
			return Mathf.Sqrt(1f - value * value);
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x00118D08 File Offset: 0x00116F08
		public static float EaseInOutCirc(float value)
		{
			value /= 0.5f;
			if (value < 1f)
			{
				return -0.5f * (Mathf.Sqrt(1f - value * value) - 1f);
			}
			value -= 2f;
			return 0.5f * (Mathf.Sqrt(1f - value * value) + 1f);
		}

		// Token: 0x06001097 RID: 4247 RVA: 0x00118D64 File Offset: 0x00116F64
		public static float EaseInBounce(float value)
		{
			return 1f - EasingUtils.EaseOutBounce(1f - value);
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x00118D78 File Offset: 0x00116F78
		public static float EaseOutBounce(float value)
		{
			if (value < 0.36363637f)
			{
				return 7.5625f * value * value;
			}
			if (value < 0.72727275f)
			{
				value -= 0.54545456f;
				return 7.5625f * value * value + 0.75f;
			}
			if ((double)value < 0.9090909090909091)
			{
				value -= 0.8181818f;
				return 7.5625f * value * value + 0.9375f;
			}
			value -= 0.95454544f;
			return 7.5625f * value * value + 0.984375f;
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x00118DF6 File Offset: 0x00116FF6
		public static float EaseInOutBounce(float value)
		{
			if (value < 0.5f)
			{
				return EasingUtils.EaseInBounce(value * 2f) * 0.5f;
			}
			return EasingUtils.EaseOutBounce(value * 2f - 1f) * 0.5f + 0.5f;
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x00118E34 File Offset: 0x00117034
		public static float EaseInBack(float value)
		{
			float num = 1.70158f;
			return value * value * ((num + 1f) * value - num);
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x00118E58 File Offset: 0x00117058
		public static float EaseOutBack(float value)
		{
			float num = 1.70158f;
			value -= 1f;
			return value * value * ((num + 1f) * value + num) + 1f;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x00118E8C File Offset: 0x0011708C
		public static float EaseInOutBack(float value)
		{
			float num = 1.70158f;
			value /= 0.5f;
			if (value < 1f)
			{
				num *= 1.525f;
				return 0.5f * (value * value * ((num + 1f) * value - num));
			}
			value -= 2f;
			num *= 1.525f;
			return 0.5f * (value * value * ((num + 1f) * value + num) + 2f);
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x00118EFC File Offset: 0x001170FC
		public static float EaseInElastic(float value)
		{
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return 0f;
			}
			if ((value /= num) == 1f)
			{
				return 1f;
			}
			float num4;
			if (num3 < 1f)
			{
				num3 = 1f;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.2831855f * Mathf.Asin(1f / num3);
			}
			return -(num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.2831855f / num2));
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x00118FA4 File Offset: 0x001171A4
		public static float EaseOutElastic(float value)
		{
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return 0f;
			}
			if ((value /= num) == 1f)
			{
				return 1f;
			}
			float num4;
			if (num3 < 1f)
			{
				num3 = 1f;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.2831855f * Mathf.Asin(1f / num3);
			}
			return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * num - num4) * 6.2831855f / num2) + 1f;
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x00119048 File Offset: 0x00117248
		public static float EaseInOutElastic(float value)
		{
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return 0f;
			}
			if ((value /= num / 2f) == 2f)
			{
				return 1f;
			}
			float num4;
			if (num3 < 1f)
			{
				num3 = 1f;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.2831855f * Mathf.Asin(1f / num3);
			}
			if (value < 1f)
			{
				return -0.5f * (num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.2831855f / num2));
			}
			return num3 * Mathf.Pow(2f, -10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.2831855f / num2) * 0.5f + 1f;
		}

		// Token: 0x0200020F RID: 527
		public enum EaseType
		{
			// Token: 0x04001414 RID: 5140
			Linear,
			// Token: 0x04001415 RID: 5141
			Cleap,
			// Token: 0x04001416 RID: 5142
			Spring,
			// Token: 0x04001417 RID: 5143
			InQuad,
			// Token: 0x04001418 RID: 5144
			OutQuad,
			// Token: 0x04001419 RID: 5145
			InOutQuad,
			// Token: 0x0400141A RID: 5146
			InCubic,
			// Token: 0x0400141B RID: 5147
			OutCubic,
			// Token: 0x0400141C RID: 5148
			InOutCubic,
			// Token: 0x0400141D RID: 5149
			InQuart,
			// Token: 0x0400141E RID: 5150
			OutQuart,
			// Token: 0x0400141F RID: 5151
			InOutQuart,
			// Token: 0x04001420 RID: 5152
			InQuint,
			// Token: 0x04001421 RID: 5153
			OutQuint,
			// Token: 0x04001422 RID: 5154
			InOutQuint,
			// Token: 0x04001423 RID: 5155
			InSine,
			// Token: 0x04001424 RID: 5156
			OutSine,
			// Token: 0x04001425 RID: 5157
			InOutSine,
			// Token: 0x04001426 RID: 5158
			InExpo,
			// Token: 0x04001427 RID: 5159
			OutExpo,
			// Token: 0x04001428 RID: 5160
			InOutExpo,
			// Token: 0x04001429 RID: 5161
			InCirc,
			// Token: 0x0400142A RID: 5162
			OutCirc,
			// Token: 0x0400142B RID: 5163
			InOutCirc,
			// Token: 0x0400142C RID: 5164
			InBounce,
			// Token: 0x0400142D RID: 5165
			OutBounce,
			// Token: 0x0400142E RID: 5166
			InOutBounce,
			// Token: 0x0400142F RID: 5167
			InBack,
			// Token: 0x04001430 RID: 5168
			OutBack,
			// Token: 0x04001431 RID: 5169
			InOutBack,
			// Token: 0x04001432 RID: 5170
			InElastic,
			// Token: 0x04001433 RID: 5171
			OutElastic,
			// Token: 0x04001434 RID: 5172
			InOutElastic
		}
	}
}
