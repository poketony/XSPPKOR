using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000B3 RID: 179
	public static class ProbabilityCalclator
	{
		// Token: 0x060010A3 RID: 4259 RVA: 0x0011919D File Offset: 0x0011739D
		public static bool DetectFromPercent(int percent)
		{
			return ProbabilityCalclator.DetectFromPercent((float)percent);
		}

		// Token: 0x060010A4 RID: 4260 RVA: 0x001191A8 File Offset: 0x001173A8
		public static bool DetectFromPercent(float percent)
		{
			int num = 0;
			if (percent.ToString().IndexOf(".") > 0)
			{
				num = percent.ToString().Split('.', StringSplitOptions.None)[1].Length;
				num = Mathf.Min(num, int.MaxValue.ToString().Length);
			}
			int num2 = (int)Mathf.Pow(10f, (float)num);
			int num3 = 100 * num2;
			int num4 = (int)((float)num2 * percent);
			return Random.Range(0, num3) < num4;
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x00119220 File Offset: 0x00117420
		public static T DetermineFromDict<T>(Dictionary<T, int> targetDict)
		{
			Dictionary<T, float> dictionary = new Dictionary<T, float>();
			foreach (KeyValuePair<T, int> keyValuePair in targetDict)
			{
				dictionary.Add(keyValuePair.Key, (float)keyValuePair.Value);
			}
			return ProbabilityCalclator.DetermineFromDict<T>(dictionary);
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x00119288 File Offset: 0x00117488
		public static T DetermineFromDict<T>(Dictionary<T, float> targetDict)
		{
			float num = 0f;
			foreach (float num2 in targetDict.Values)
			{
				num += num2;
			}
			float num3 = Random.Range(0f, num);
			foreach (KeyValuePair<T, float> keyValuePair in targetDict)
			{
				num3 -= keyValuePair.Value;
				if (num3 < 0f)
				{
					return keyValuePair.Key;
				}
			}
			Debug.LogError("抽選ができませんでした");
			return new List<T>(targetDict.Keys)[0];
		}
	}
}
