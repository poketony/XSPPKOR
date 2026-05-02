using System;
using System.Linq;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000B0 RID: 176
	public static class ArrayUtils
	{
		// Token: 0x06001078 RID: 4216 RVA: 0x0011864C File Offset: 0x0011684C
		public static int GetRandomIndex(params int[] weightTable)
		{
			int num = weightTable.Sum();
			int num2 = Random.Range(1, num + 1);
			int num3 = -1;
			for (int i = 0; i < weightTable.Length; i++)
			{
				if (weightTable[i] >= num2)
				{
					num3 = i;
					break;
				}
				num2 -= weightTable[i];
			}
			return num3;
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x0011868C File Offset: 0x0011688C
		public static T GetRandomArrayValue<T>(this T[] array)
		{
			int num = array.Length;
			return array[Random.Range(0, num)];
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x001186AC File Offset: 0x001168AC
		public static T[] ArrayShuffle<T>(this T[] array)
		{
			int num = array.Length;
			T[] array2 = new T[num];
			Array.Copy(array, array2, num);
			int num2 = num;
			while (1 < num2)
			{
				num2--;
				int num3 = Random.Range(0, num2 + 1);
				T t = array2[num3];
				array2[num3] = array2[num2];
				array2[num2] = t;
			}
			return array2;
		}
	}
}
