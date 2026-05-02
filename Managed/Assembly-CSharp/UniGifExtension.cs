using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000065 RID: 101
public static class UniGifExtension
{
	// Token: 0x06000E64 RID: 3684 RVA: 0x0011109C File Offset: 0x0010F29C
	public static int GetNumeral(this BitArray array, int startIndex, int bitLength)
	{
		BitArray bitArray = new BitArray(bitLength);
		for (int i = 0; i < bitLength; i++)
		{
			if (array.Length <= startIndex + i)
			{
				bitArray[i] = false;
			}
			else
			{
				bool flag = array.Get(startIndex + i);
				bitArray[i] = flag;
			}
		}
		return bitArray.ToNumeral();
	}

	// Token: 0x06000E65 RID: 3685 RVA: 0x001110EC File Offset: 0x0010F2EC
	public static int ToNumeral(this BitArray array)
	{
		if (array == null)
		{
			Debug.LogError("array is nothing.");
			return 0;
		}
		if (array.Length > 32)
		{
			Debug.LogError("must be at most 32 bits long.");
			return 0;
		}
		int[] array2 = new int[1];
		array.CopyTo(array2, 0);
		return array2[0];
	}
}
