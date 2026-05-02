using System;

namespace Socotra
{
	// Token: 0x020000F4 RID: 244
	public class StString
	{
		// Token: 0x0600133E RID: 4926 RVA: 0x0012036A File Offset: 0x0011E56A
		internal static string Substring(string str, int index)
		{
			return str.Substring(index);
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x00120373 File Offset: 0x0011E573
		internal static string Substring(string str, int index, int endIndex)
		{
			return str.Substring(index, endIndex - index);
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x0012037F File Offset: 0x0011E57F
		internal static string ValueOf<T>(T val)
		{
			return val.ToString();
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x0012038E File Offset: 0x0011E58E
		internal static string ValueOf(char[] data, int offset, int count)
		{
			return new string(data).Substring(offset, count);
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x0012039D File Offset: 0x0011E59D
		internal static string ValueOf(char[] data)
		{
			return new string(data);
		}
	}
}
