using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Steezy.Utility
{
	// Token: 0x020000B6 RID: 182
	public static class StringUtility
	{
		// Token: 0x060010AD RID: 4269 RVA: 0x00119524 File Offset: 0x00117724
		public static string ToStringDictionary(IDictionary dictionary)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			foreach (object obj in dictionary.Keys)
			{
				object obj2 = dictionary[obj];
				stringBuilder.Append(obj);
				stringBuilder.Append(":");
				if (obj2 is IDictionary)
				{
					stringBuilder.Append(StringUtility.ToStringDictionary(obj2 as IDictionary));
				}
				else if (obj2 is IList)
				{
					stringBuilder.Append(StringUtility.ToStringList(obj2 as IList));
				}
				else
				{
					stringBuilder.Append(obj2);
				}
				stringBuilder.Append(",");
			}
			if (dictionary.Count > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0011961C File Offset: 0x0011781C
		public static string ToStringList(IList list)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			foreach (object obj in list)
			{
				if (obj is IDictionary)
				{
					stringBuilder.Append(StringUtility.ToStringDictionary(obj as IDictionary));
				}
				else if (obj is IList)
				{
					stringBuilder.Append(StringUtility.ToStringList(obj as IList));
				}
				else
				{
					stringBuilder.Append(obj);
				}
				stringBuilder.Append(",");
			}
			if (list.Count > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x001196F0 File Offset: 0x001178F0
		public static string ToString(IList list, string separator = ",")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object obj in list)
			{
				if (obj is IDictionary)
				{
					stringBuilder.Append(StringUtility.ToStringDictionary(obj as IDictionary));
				}
				else if (obj is IList)
				{
					stringBuilder.Append(StringUtility.ToStringList(obj as IList));
				}
				else
				{
					stringBuilder.Append(obj);
				}
				stringBuilder.Append(separator);
			}
			if (list.Count > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x001197A8 File Offset: 0x001179A8
		public static List<string> SplitCommaToList(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return new List<string>();
			}
			return new List<string>(str.Split(',', StringSplitOptions.None));
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x001197C8 File Offset: 0x001179C8
		public static string Mid(string str, int start, int len)
		{
			if (start <= 0)
			{
				throw new ArgumentException("引数'start'は1以上でなければなりません。");
			}
			if (len < 0)
			{
				throw new ArgumentException("引数'len'は0以上でなければなりません。");
			}
			if (str == null || str.Length < start)
			{
				return "";
			}
			if (str.Length < start + len)
			{
				return str.Substring(start - 1);
			}
			return str.Substring(start - 1, len);
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x00119824 File Offset: 0x00117A24
		public static string Mid(string str, int start)
		{
			return StringUtility.Mid(str, start, str.Length);
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x00119833 File Offset: 0x00117A33
		public static string Left(string str, int len)
		{
			if (len < 0)
			{
				throw new ArgumentException("引数'len'は0以上でなければなりません。");
			}
			if (str == null)
			{
				return "";
			}
			if (str.Length <= len)
			{
				return str;
			}
			return str.Substring(0, len);
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x00119860 File Offset: 0x00117A60
		public static string Right(string str, int len)
		{
			if (len < 0)
			{
				throw new ArgumentException("引数'len'は0以上でなければなりません。");
			}
			if (str == null)
			{
				return "";
			}
			if (str.Length <= len)
			{
				return str;
			}
			return str.Substring(str.Length - len, len);
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x00119894 File Offset: 0x00117A94
		public static string StringReplace(string input, string oldValue, string newValue, int count, CompareInfo compInfo, CompareOptions compOptions)
		{
			if (input == null || input.Length == 0 || oldValue == null || oldValue.Length == 0 || count == 0)
			{
				return input;
			}
			if (compInfo == null)
			{
				compInfo = CultureInfo.InvariantCulture.CompareInfo;
				compOptions = CompareOptions.Ordinal;
			}
			int length = input.Length;
			int length2 = oldValue.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			int num = 0;
			int num2 = 0;
			for (;;)
			{
				int num3 = compInfo.IndexOf(input, oldValue, num, compOptions);
				if (num3 < 0)
				{
					break;
				}
				stringBuilder.Append(input.Substring(num, num3 - num));
				stringBuilder.Append(newValue);
				num = num3 + length2;
				num2++;
				if (num2 == count)
				{
					goto Block_7;
				}
				if (num >= length)
				{
					goto IL_00B0;
				}
			}
			stringBuilder.Append(input.Substring(num));
			goto IL_00B0;
			Block_7:
			stringBuilder.Append(input.Substring(num));
			IL_00B0:
			return stringBuilder.ToString();
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x00119957 File Offset: 0x00117B57
		public static string StringReplace(string input, string oldValue, string newValue, int count, bool ignoreCase)
		{
			if (ignoreCase)
			{
				return StringUtility.StringReplace(input, oldValue, newValue, count, CultureInfo.InvariantCulture.CompareInfo, CompareOptions.OrdinalIgnoreCase);
			}
			return StringUtility.StringReplace(input, oldValue, newValue, count, CultureInfo.InvariantCulture.CompareInfo, CompareOptions.Ordinal);
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x0011998E File Offset: 0x00117B8E
		public static string StringReplace(string input, string oldValue, string newValue, int count)
		{
			return StringUtility.StringReplace(input, oldValue, newValue, count, CultureInfo.InvariantCulture.CompareInfo, CompareOptions.Ordinal);
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x001199A8 File Offset: 0x00117BA8
		public static string JoinString<T>(this IEnumerable<T> values, string separator, Func<T, string> converter = null)
		{
			List<string> list = new List<string>();
			if (converter != null)
			{
				using (IEnumerator<T> enumerator = values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T t = enumerator.Current;
						list.Add(converter(t));
					}
					goto IL_0071;
				}
			}
			foreach (T t2 in values)
			{
				list.Add(t2.ToString());
			}
			IL_0071:
			return string.Join(separator, list.ToArray());
		}
	}
}
